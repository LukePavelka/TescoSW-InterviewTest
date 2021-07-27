using System;
using System.Collections.Generic;
using System.Text;
using TescoSWLibrary.Xml.Models;

namespace TescoSWLibrary.Xml
{
    public class CarTestData
    {
        /// 1. Škoda Oktávia 2.12.2010 500.000,- 20
        /// 2. Škoda Felicia 3.12.2000 210.000,- 20
        /// 3. Škoda Fabia 4.12.2010 350.000,- 20
        /// 4. Škoda Oktávia 4.12.2010 500.000,- 20
        /// 5. Škoda Oktávia 5.12.2010 500.000,- 20
        /// 6. Škoda Fabia 5.12.2010 350.000,- 20
        /// 7. Škoda Fabia 6.12.2010 350.000,- 20
        /// 8. Škoda Forman 4.12.2000 100.000,- 19
        /// 9. Škoda Favorit 5.12.2000 80.000,- 19
        // 10. Škoda Forman 6.12.2000 100.000,- 19
        // 11. Škoda Felicia 3.12.2000 210.000,- 19
        // 12. Škoda Felicia 2.12.2000 210.000,- 19
        // 13. Škoda Oktávia 7.12.2010 500.000,- 20
        public static CarRootModel GetExampleData()
        {
            CarRootModel CarSold = new CarRootModel
            {
                Cars = new List<CarModel>()
            };
            CarModel Car1 = new CarModel
            {
                Series = "Škoda Oktávia",
                Sale = DateTime.Parse("2.12.2010"),
                Price = 500000,
                DPH = 20
            };
            CarSold.Cars.Add(Car1);
            CarModel Car2 = new CarModel
            {
                Series = "Škoda Felicia",
                Sale = DateTime.Parse("3.12.2000"),
                Price = 210000,
                DPH = 20
            };
            CarSold.Cars.Add(Car2);
            CarModel Car3 = new CarModel
            {
                Series = "Škoda Fabia",
                Sale = DateTime.Parse("4.12.2010"),
                Price = 350000,
                DPH = 20
            };
            CarSold.Cars.Add(Car3);
            CarModel Car4 = new CarModel
            {
                Series = "Škoda Oktávia",
                Sale = DateTime.Parse("4.12.2010"),
                Price = 500000,
                DPH = 20
            };
            CarSold.Cars.Add(Car4);
            CarModel Car5 = new CarModel
            {
                Series = "Škoda Oktávia",
                Sale = DateTime.Parse("5.12.2010"),
                Price = 500000,
                DPH = 20
            };
            CarSold.Cars.Add(Car5);
            CarModel Car6 = new CarModel
            {
                Series = "Škoda Fabia",
                Sale = DateTime.Parse("5.12.2010"),
                Price = 350000,
                DPH = 20
            };
            CarSold.Cars.Add(Car6);
            CarModel Car7 = new CarModel
            {
                Series = "Škoda Fabia",
                Sale = DateTime.Parse("6.12.2010"),
                Price = 350000,
                DPH = 20
            };
            CarSold.Cars.Add(Car7);
            CarModel Car8 = new CarModel
            {
                Series = "Škoda Forman",
                Sale = DateTime.Parse("4.12.2000"),
                Price = 100000,
                DPH = 19
            };
            CarSold.Cars.Add(Car8);
            CarModel Car9 = new CarModel
            {
                Series = "Škoda Favorit",
                Sale = DateTime.Parse("5.12.2000"),
                Price = 80000,
                DPH = 19
            };
            CarSold.Cars.Add(Car9);
            CarModel Car10 = new CarModel
            {
                Series = "Škoda Forman",
                Sale = DateTime.Parse("6.12.2000"),
                Price = 100000,
                DPH = 19
            };
            CarSold.Cars.Add(Car10);
            CarModel Car11 = new CarModel
            {
                Series = "Škoda Felicia",
                Sale = DateTime.Parse("3.12.2000"),
                Price = 210000,
                DPH = 19
            };
            CarSold.Cars.Add(Car11);
            CarModel Car12 = new CarModel
            {
                Series = "Škoda Felicia",
                Sale = DateTime.Parse("2.12.2000"),
                Price = 210000,
                DPH = 19
            };
            CarSold.Cars.Add(Car12);
            CarModel Car13 = new CarModel
            {
                Series = "Škoda Oktávia",
                Sale = DateTime.Parse("7.12.2010"),
                Price = 500000,
                DPH = 20
            };
            CarSold.Cars.Add(Car13);
            Car.XmlSerialise(CarSold, "test.xml");
            return CarSold;
        }
        public static void SaveExampleData(string Path) 
        {
            var Data = GetExampleData();
            Car.XmlSerialise(Data, Path);
        }
    }
}
