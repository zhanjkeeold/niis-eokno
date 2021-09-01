using Niis.Eokno.Abstractions.Responses.Dictionaries;
using Niis.Eokno.Domain;

namespace Niis.Eokno.Mappers
{
	public static class DictionaryMapper
	{
		public static PatentType ToResponse(this PatentDictionary source)
		{
			if (source == null)
				return null;

			return new PatentType
			{
				Id = source.Id,
				NameEn = source.NameEn,
				NameKz = source.NameKz,
				NameRu = source.NameRu
			};
		}

		public static TrademarkClassificationType ToResponse(this TrademarkClassification source)
		{
			if (source == null)
				return null;

			return new TrademarkClassificationType
			{
				Id = source.Id,
				Code = source.Code,
				Description = source.Description
			};
		}
	}
}
