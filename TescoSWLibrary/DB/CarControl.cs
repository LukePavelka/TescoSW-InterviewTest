using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TescoSWLibrary.DB
{
    /// <summary>
    /// This class contains static methods for basic database operations.
    /// </summary>
    public class CarControl
    {
        public static async Task SaveAsync(CarDbModel Request)
        {
            using var db = new DB.CarContext();
            db.Add(Request);
            await db.SaveChangesAsync();
        }
        public static IEnumerable<CarDbModel> GetAll()
        {
            using var db = new DB.CarContext();
            return db.CarDb.ToList();
        }
        public static async Task<CarDbModel> FindAsync(Guid Id)
        {
            using var db = new DB.CarContext();
            var Search = await db.CarDb.FindAsync(Id);
            return Search;
        }
        public static async Task<bool> DeleteAsync(Guid Id)
        {
            var Obj = await FindAsync(Id);
            if (Obj != null)
            {
                using var db = new DB.CarContext();
                db.CarDb.Remove(Obj);
                await db.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
        public static async Task DeleteAllAsync()
        {
            using var db = new DB.CarContext();
            foreach (var item in GetAll())
            {
                db.CarDb.Remove(item);
            }
            await db.SaveChangesAsync();
        }
    }
}
