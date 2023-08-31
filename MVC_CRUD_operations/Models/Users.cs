using System.ComponentModel.DataAnnotations;

namespace MVC_CRUD_operations.Models
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
    }
}
