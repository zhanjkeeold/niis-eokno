using Kazpatent.IntegrationKGD.ApplicationCore.TrademarkInfo.Models;
using System;
using System.Collections.Generic;

namespace Niis.Eokno.Domain
{
    public class CustomerTrademarkValidityInfo
    {
        public int PatentId { get; set; }
        public int DocumentId { get; set; }
        public string PatentNameEn { get; set; }
        public string PatentNameRu { get; set; }
        public string PatentNameKz { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public DateTime? ValidityDate { get; set; }
        public byte[] Image { get; set; }
        public IReadOnlyCollection<TrademarkClassification> ICGS { get; set; }
        public IReadOnlyCollection<CustomerInfo> Owners { get; set; }
        public IReadOnlyCollection<Contract> Contracts { get; set; }
    }
}
