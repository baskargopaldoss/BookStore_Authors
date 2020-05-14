using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.API.Models
{
    public class AuthorForUpdateDto
    {

    [Required(ErrorMessage = "You should fill out the last name.")]
    [MaxLength(100, ErrorMessage = "The name shouldn't have more than 15 characters.")] 
    public string LastName { get; set; }


    //public string MainCategory { get; set; }
    // public ICollection<CourseForCreationDto> Courses { get; set; }= new List<CourseForCreationDto>();
  }
}
