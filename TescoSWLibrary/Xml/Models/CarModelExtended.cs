using System;
using TescoSWLibrary.DB;

namespace TescoSWLibrary.Xml.Models
{
    public class CarModelExtended : CarModel
    {
        public CarModelExtended(CarModel Parent)
        {
            foreach (var prop in Parent.GetType().GetProperties())
            {
                this.GetType().GetProperty(prop.Name).SetValue(this, prop.GetValue(Parent, null), null);
            }
            this.SaleDay = Sale.DayOfWeek;
            this.PriceInclVAT = ((DPH / 100) * Price) + Price;
            this.ReadableSaleDay = Sale.ToLongDateString();
        }

        public CarModelExtended(double dPH, string series, double price, DateTime sale)
        {
            DPH = dPH;
            Series = series;
            Price = price;
            Sale = sale;
            this.SaleDay = Sale.DayOfWeek;
            this.PriceInclVAT = ((DPH / 100) * Price) + Price;
            this.ReadableSaleDay = Sale.ToLongDateString();
        }

        public DayOfWeek SaleDay { get; set; }
        public double PriceInclVAT { get; set; }
        public string ReadableSaleDay { get; set; }

        public static explicit operator CarModelExtended(CarDbModel v)
        {
            return new CarModelExtended(v.DPH,v.Series,v.Price,v.Sale);
        }
    }
}
