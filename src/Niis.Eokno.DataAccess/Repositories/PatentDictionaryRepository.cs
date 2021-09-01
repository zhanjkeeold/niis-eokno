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
	public class PatentDictionaryRepository : IPatentDictionaryRepository
	{
		private readonly string _connectionString;
		private readonly ILogger _logger;

		public PatentDictionaryRepository(string connectionString, ILogger logger)
		{
			_connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
			_logger = logger ?? throw new ArgumentNullException(nameof(logger));
		}

		public IReadOnlyCollection<PatentDictionary> GetAll()
		{
			return GetAllAsync().GetAwaiter().GetResult();
		}

		public async Task<IReadOnlyCollection<PatentDictionary>> GetAllAsync(
			CancellationToken cancellationToken = default)
		{
			using (var connection = new SqlConnection(_connectionString))
			{
				await connection.OpenAsync(cancellationToken);

				_logger.Information("Retrieve patent types");

				const string query = @"
SELECT [U_ID] AS [Id]
      ,[NAME_ML_EN] AS[NameEn]
      ,[NAME_ML_RU] AS[NameRu]
      ,[NAME_ML_KZ] AS[NameKz]
  FROM[dbNiis].[dbo].[SP_TYPE_PATENT]";

				var queryResult = await connection.QueryAsync<PatentDictionary>(query);

				return queryResult.ToList().AsReadOnly();
			}
		}
	}
}