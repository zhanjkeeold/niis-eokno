using Dapper;
using Niis.Eokno.DataAccess.Abstractions;
using Niis.Eokno.Domain;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Niis.Eokno.DataAccess
{
	public class TrademarkDictionaryRepository : ITrademarkDictionaryRepository
	{
		private readonly string _connectionString;
		private readonly ILogger _logger;

		public TrademarkDictionaryRepository(string connectionString, ILogger logger)
		{
			_connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
			_logger = logger ?? throw new ArgumentNullException(nameof(logger));
		}

		public IReadOnlyCollection<TrademarkClassification> GetAll()
		{
			return GetAllAsync().GetAwaiter().GetResult();
		}

		public async Task<IReadOnlyCollection<TrademarkClassification>> GetAllAsync(
			CancellationToken cancellationToken = default)
		{
			using (var connection = new SqlConnection(_connectionString))
			{
				await connection.OpenAsync(cancellationToken);

				_logger.Information("Retrieve trademark classification");

				const string query = @"
SELECT [U_ID] AS [Id]
      ,[CODE] AS [Code]
      ,[FULL_DESC] AS [Description]
  FROM [dbNiis].[dbo].[CL_TM_ICGS] WHERE [CODE] IS NOT NULL";

				var queryResult = await connection.QueryAsync<TrademarkClassification>(query);

				return queryResult.ToList().AsReadOnly();
			}
		}
	}
}