using System.ComponentModel.DataAnnotations;

namespace PostTestApp.Model
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public int Year { get; set; }
        public string Model { get; set; }
        public bool SpareWheel { get; set; }
    }
}