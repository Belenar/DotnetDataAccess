using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Part7.CodeFirstInheritance
{
    public class Car : Vehicle
    {
        public int HorsePower { get; set; }
        public int Seats { get; set; }
    }
}