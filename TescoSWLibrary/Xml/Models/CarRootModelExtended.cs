using System.Collections.Generic;
using System.Linq;

namespace TescoSWLibrary.Xml.Models
{
    public class CarRootModelExtended
    {
        public List<CarModelExtended> CarsExtended { get; set; }
        public CarRootModelExtended()
        {

        }
        public CarRootModelExtended(CarRootModel CarRoot)
        {
            CarsExtended = new List<CarModelExtended>();
            if (CarRoot.Cars != null)
            {
                foreach (var car in CarRoot.Cars)
                {
                    CarsExtended.Add(new CarModelExtended(car));
                }
            }
        }
        public IEnumerable<CarSeriesModel> GetWeekendSoldCars()
        {
            var ResultsFiltered = new List<CarModelExtended>();
            foreach (var car in CarsExtended ?? null)
            {
                if (car.SaleDay == System.DayOfWeek.Saturday | car.SaleDay == System.DayOfWeek.Sunday)
                {
                    ResultsFiltered.Add(car);
                }
            }
            var Results = from car in ResultsFiltered
                          group car by car.Series into g
                          select new CarSeriesModel()
                          {
                              Series = g.Key,
                              Price = g.Sum(x => x.Price),
                              PriceInclVAT = g.Sum(x => x.PriceInclVAT)
                          };
            return Results;
        }
    }
}
