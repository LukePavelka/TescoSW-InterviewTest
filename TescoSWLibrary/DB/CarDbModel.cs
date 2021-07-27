using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TescoSWLibrary.Xml.Models;

namespace TescoSWLibrary.DB
{
    /// <summary>
    /// Model that is used for the database within the ef core.
    /// </summary>
    public class CarDbModel : CarModel
    {
        // Primary key
        [Key]
        // Auto gen new GUID key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }

        public static explicit operator CarDbModel(CarModelExtended v)
        {
            return new CarDbModel
            {
                DPH = v.DPH,
                Price = v.Price,
                Sale = v.Sale,
                Series = v.Series
            };
        }
    }
}
