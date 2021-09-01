using Niis.Eokno.Abstractions.Requests;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Niis.Eokno.Abstractions
{
	public interface IHandler
	{
		/// <summary>
		///		Gets the action name.
		/// </summary>
		ActionName ActionName { get; }

		/// <summary>
		///		Handle the request.
		/// </summary>
		Task<XElement> Handle(SendMessageRequest request, CancellationToken cancellationToken = default);
	}
}
