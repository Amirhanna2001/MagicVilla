using System.ComponentModel.DataAnnotations;

namespace MagicVilla.Dtos
{
    public class VillaDto
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
