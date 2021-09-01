using Dapper;
using Niis.Eokno.DataAccess.Abstractions;
using Niis.Eokno.Domain;
using Serilog;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Niis.Eokno.DataAccess
{
	public class CustomerTrademarkRepository : ICustomerTrademarkRepository
	{
		private readonly string _connectionString;
		private readonly ILogger _logger;

		public CustomerTrademarkRepository(string connectionString, ILogger logger)
		{
			_connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
			_logger = logger ?? throw new ArgumentNullException(nameof(logger));
		}

		public TrademarkInfo GetTrademarkInfo(int patentTypeId, string gosNumber)
		{
			return GetTrademarkInfoAsync(patentTypeId, gosNumber).GetAwaiter().GetResult();
		}

		public async Task<TrademarkInfo> GetTrademarkInfoAsync(int patentTypeId,
			string gosNumber, CancellationToken cancellationToken = default)
		{
			using (var connection = new SqlConnection(_connectionString))
			{
				await connection.OpenAsync(cancellationToken);

				_logger.Information("Retrieve customer trademark validity info by gos number: {GosNumber} and patent type id: {PatentTypeId}", gosNumber, patentTypeId);

				const string trademarkQuery = @"
SELECT TOP 1 [D].[U_ID] AS [DocumentId]
            ,[B].[U_ID] AS [PatentId]
            ,[B].[NAME_540_EN] AS [PatentNameEn]
            ,[B].[NAME_540_RU] AS [PatentNameRu]
            ,[B].[NAME_540_KZ] AS [PatentNameKz]
            ,[B].[IMAGE] AS [Image]
            ,ISNULL([B].[STZ176],[B].[STZ17]) AS [ValidityDate]
            ,[B].[GOS_DATE_11] AS [RegistrationDate]
        FROM [dbNiis].[dbo].[BT_BASE_PATENT] AS [B]
        INNER JOIN [dbNiis].[dbo].[DD_DOCUMENT] AS [D]
        ON [D].[DOC_ID] = [B].[U_ID]
        WHERE TYPE_ID = @patentType AND GOS_NUMBER_11 = @gosNumber";

				var trademarkInfo = await connection.QueryFirstOrDefaultAsync<TrademarkInfo>(trademarkQuery, new { gosNumber, patentType = patentTypeId });
				if (trademarkInfo == null) return null;

				const string contractsQuery = @"
        SELECT [C].[Number],
            [C].[RegistrationDate],
            [C].[ContractTypeEn],
            [C].[ContractTypeKz],
            [C].[ContractTypeRu],
            [C].[SubjectEn],
            [C].[SubjectKz],
            [C].[SubjectRu],
            [C].[Side1],
            [C].[Side2] FROM [dbNiis].[dbo].[PatentViewContract] AS [C]
        INNER JOIN [dbNiis].[dbo].[RefContractPatent] AS [R]
        ON [C].[Id] = [R].[ContractId]
        WHERE [R].[PatentId] = @patentId";

				trademarkInfo.Contracts = (await connection.QueryAsync<Contract>(contractsQuery, new { patentId = trademarkInfo.PatentId }))
					?.ToList()
					?.AsReadOnly();

				const string trademarkClassificationQuery = @"
        SELECT [C].[CODE] AS [Code]
            ,[C].[FULL_DESC] AS [Description]
        FROM [dbNiis].[dbo].[RF_TM_ICGS] AS [R]
        INNER JOIN [dbNiis].[dbo].[CL_TM_ICGS] AS [C]
        ON [R].[ICPS_ID] = [C].[U_ID]
        WHERE [R].[DOC_ID] = @patentId";

				trademarkInfo.ICGS = (await connection.QueryAsync<TrademarkClassification>(trademarkClassificationQuery, new { patentId = trademarkInfo.PatentId }))
					?.ToList()
					?.AsReadOnly();


				const string customersQuery = @"
        SELECT [C].[flXin] AS [Xin]
            ,[C].[TYPE_ID] AS [CustomerType]
            ,[C].[CUS_NAME_ML_EN] AS[OwnerNameEn]
            ,[C].[CUS_NAME_ML_RU] AS[OwnerNameRu]
            ,[C].[CUS_NAME_ML_KZ] AS[OwnerNameKz]
            ,[C].[COUNTRY_ID] AS[LocationId]
            , (SELECT TOP 1[NAME_ML_RU] FROM[dbNiis].[dbo].[CL_LOCATION] WHERE[U_ID] = [C].[COUNTRY_ID]) AS[Location]
            ,ISNULL((SELECT TOP 1[NAME_ML_EN] FROM[dbNiis].[dbo].[CL_LOCATION] WHERE[U_ID] = [A].[LOCATION_ID]), '') + ', ' + [A].[ADDRESS_ML_EN] AS[AddressEn]
            ,ISNULL((SELECT TOP 1[NAME_ML_RU] FROM[dbNiis].[dbo].[CL_LOCATION] WHERE[U_ID] = [A].[LOCATION_ID]), '') + ', ' + [A].[ADDRESS_ML_RU] AS[AddressRu]
            ,ISNULL((SELECT TOP 1[NAME_ML_KZ] FROM[dbNiis].[dbo].[CL_LOCATION] WHERE[U_ID] = [A].[LOCATION_ID]), '') + ', ' + [A].[ADDRESS_ML_KZ] AS[AddressKz]
            ,[A].[POST_BOX]
            AS[AddressPostCode]
        FROM[dbNiis].[dbo].[RF_CUSTOMER]
            AS[R]
        INNER JOIN[dbNiis].[dbo].[WT_CUSTOMER]
            AS[C]
        ON[C].[U_ID] = [R].[CUSTOMER_ID]
        INNER JOIN[dbNiis].[dbo].[WT_ADDRESS]
        AS[A]
        ON[C].[ADDRESS_ID] = [A].[U_ID]
        WHERE[R].[C_TYPE] = 3 AND[R].[DOC_ID] = @patentId";

				trademarkInfo.Owners = (await connection.QueryAsync<Customer>(customersQuery, new { patentId = trademarkInfo.PatentId }))
					?.ToList()
					?.AsReadOnly();

				return trademarkInfo;
			}
		}
	}
}