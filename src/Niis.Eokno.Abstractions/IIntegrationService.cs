using Niis.Eokno.Abstractions.Requests;
using Niis.Eokno.Abstractions.Responses;
using System.ServiceModel;

namespace Niis.Eokno.Abstractions
{
	[ServiceContract(Namespace = "http://bip.bee.kz/SyncChannel/v10/Types")]
	public interface IIntegrationService
	{
		[OperationContract(
			Name = Global.SendMessage,
			Action = Global.Empty)]
		SendMessageResponse SendMessage(SendMessageRequest request);
	}
}