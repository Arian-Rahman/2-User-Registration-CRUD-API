using System.ComponentModel.DataAnnotations;

namespace User_Registration_CRUD_API.Models
{
    public class user
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Phone { get; set;}
    }
    }

