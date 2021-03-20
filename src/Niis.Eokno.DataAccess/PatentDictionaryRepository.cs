using Niis.Eokno.DataAccess.Abstractions;
using Niis.Eokno.Domain;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Niis.Eokno.DataAccess
{
    public class PatentDictionaryRepository : IPatentDictionaryRepository
    {
        public PatentDictionaryRepository(string connectionString)
        {

        }

        public IReadOnlyCollection<PatentDictionary> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<PatentDictionary>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
