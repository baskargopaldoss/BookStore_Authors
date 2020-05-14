using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.API.Entities
{
  public class User
  {
    [Key]
    public string UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
    //public DateTime CreatedDate { get; set; }
   

   // [ForeignKey("RoleId")]
   // public Role Role { get; set; }
  }
}
