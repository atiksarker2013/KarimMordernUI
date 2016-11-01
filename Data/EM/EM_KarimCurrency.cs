using Models;

namespace Data.EM
{
    public static class EM_KarimCurrency
    {
        public static KarimCurrency ConverToModel(tbl_KarimCurrency entity)
        {
            KarimCurrency model = new KarimCurrency();
            model.Id = entity.Id;
            model.CurrencyName = entity.CurrencyName;
            model.CurrencySymbol = entity.CurrencySymbol;
            model.TakaInAmount = entity.TakaInAmount ?? 0;
            return model;
        }

        public static tbl_KarimCurrency ConvertToEntity(KarimCurrency model)
        {
            tbl_KarimCurrency entity = new tbl_KarimCurrency();
            entity.Id = model.Id;
            entity.CurrencyName = model.CurrencyName;
            entity.CurrencySymbol = model.CurrencySymbol;
            entity.TakaInAmount = model.TakaInAmount;
            return entity;
        }
    }
}
