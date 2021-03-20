using System;
using System.Collections.Generic;

namespace Niis.Eokno.Abstractions.Dtos
{
    public class CustomerTrademarkValidityInfoDto
    {
        public int PatentId { get; set; }
        public int DocumentId { get; set; }
        public string PatentNameEn { get; set; }
        public string PatentNameRu { get; set; }
        public string PatentNameKz { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public DateTime? ValidityDate { get; set; }
        public byte[] Image { get; set; }
        public IReadOnlyCollection<TrademarkClassificationDto> ICGS { get; set; }
        public IReadOnlyCollection<CustomerInfoDto> Owners { get; set; }
        public IReadOnlyCollection<ContractDto> Contracts { get; set; }
    }
}
