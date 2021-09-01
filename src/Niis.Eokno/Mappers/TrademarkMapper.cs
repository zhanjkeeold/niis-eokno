using Niis.Eokno.Abstractions.Responses.Trademarks;
using Niis.Eokno.Domain;
using System.Linq;

namespace Niis.Eokno.Mappers
{
	public static class TrademarkMapper
	{
		public static TrademarkInfoResponse ToResponse(this TrademarkInfo source)
		{
			if (source == null)
				return null;

			return new TrademarkInfoResponse
			{
				DocumentId = source.DocumentId,
				Contracts = source.Contracts.Select(x => x.ToResponse()).ToArray(),
				TrademarkClassificationTypes = source.ICGS.Select(x=>x.ToResponse()).ToArray(),
				Image = source.Image,
				Owners = source.Owners.Select(x=>x.ToResponse()).ToArray(),
				PatentId = source.PatentId,
				PatentNameEn = source.PatentNameEn,
				PatentNameKz = source.PatentNameKz,
				PatentNameRu = source.PatentNameRu,
				RegistrationDate = source.RegistrationDate,
				ValidityDate = source.ValidityDate
			};
		}

		public static CustomerInfo ToResponse(this Customer source)
		{
			if (source == null)
				return null;

			return new CustomerInfo
			{
				AddressEn = source.AddressEn,
				AddressKz = source.AddressKz,
				AddressPostCode = source.AddressPostCode,
				AddressRu = source.AddressRu,
				CustomerType = source.CustomerType,
				Location = source.Location,
				LocationId = source.LocationId,
				OwnerNameEn = source.OwnerNameEn,
				OwnerNameKz = source.OwnerNameKz,
				OwnerNameRu = source.OwnerNameRu,
				Xin = source.Xin
			};
		}

		public static ContractInfo ToResponse(this Contract source)
		{
			if (source == null)
				return null;

			return new ContractInfo
			{
				ContractTypeEn = source.ContractTypeEn,
				ContractTypeKz = source.ContractTypeKz,
				ContractTypeRu = source.ContractTypeRu,
				Number = source.Number,
				RegistrationDate = source.RegistrationDate,
				Side1 = source.Side1,
				Side2 = source.Side2,
				SubjectEn = source.SubjectEn,
				SubjectKz = source.SubjectKz,
				SubjectRu = source.SubjectRu
			};
		}
	}
}
