using Niis.Eokno.Domain;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Niis.Eokno.DataAccess.Abstractions
{
    public interface IPatentDictionaryRepository
    {
        IReadOnlyCollection<PatentDictionary> GetAll();

        Task<IReadOnlyCollection<PatentDictionary>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}
