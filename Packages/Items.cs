using System.ComponentModel.DataAnnotations;

namespace Packages
{
    public class Items
    {
        [Key]
        public int? Id { get; set; }
        public int Index { get; set; }
        public double Weight { get; set; }
        public double Cost { get; set; }
    }
}
