namespace Kazpatent.IntegrationKGD.ApplicationCore.TrademarkInfo.Models
{
    public class CustomerInfo
    {
        public string Xin { get; set; }
        public int CustomerType { get; set; }
        public string OwnerNameEn { get; set; }
        public string OwnerNameRu { get; set; }
        public string OwnerNameKz { get; set; }
        public int? LocationId { get; set; }
        public string Location { get; set; }
        public string AddressEn { get; set; }
        public string AddressRu { get; set; }
        public string AddressKz { get; set; }
        public string AddressPostCode { get; set; }
    }
}