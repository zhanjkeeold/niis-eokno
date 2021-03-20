using System.ServiceModel;

namespace Niis.Eokno.Abstractions.Responses
{
    /// <summary>
    ///     Ответ для ШЭП-а.
    /// </summary>
    [MessageContract(
        IsWrapped = true,
        WrapperName = Global.SendMessage,
        WrapperNamespace = Global.ServiceContractNamespace)]
    public class SendMessageRespose
    {
    }
}
