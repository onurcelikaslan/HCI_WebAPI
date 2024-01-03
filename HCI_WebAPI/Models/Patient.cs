using System.ComponentModel.DataAnnotations;

namespace HCI_WebAPI.Models
{
    public class Patient
    {

        [Key]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
