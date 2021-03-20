namespace Niis.Eokno.DataAccess.Abstractions
{
    public interface IUnitOfWork
    {
        IPatentDictionaryRepository PatentDictionaryRepository { get; }
        ITrademarkDictionaryRepository TrademarkDictionaryRepository { get; }
        ICustomerTrademarkRepository CustomerTrademarkRepository { get; }
    }
}
