using System.ComponentModel.DataAnnotations;

namespace HCI_WebAPI.Models
{
    public class Hospital
    {
        [Key]
        public Guid Id { get; set; } 
        public string Name { get; set; }
    }
}
