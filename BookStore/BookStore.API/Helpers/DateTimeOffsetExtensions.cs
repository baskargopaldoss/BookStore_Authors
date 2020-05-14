using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.API.Helpers
{
    public static class DateTimeOffsetExtensions //class Author => public DateTimeOffset DateOfBirth { get; set; } 
  {
        public static int GetCurrentAge(this DateTimeOffset dateTimeOffset)
        {
            var currentDate = DateTime.UtcNow;
            int age = currentDate.Year - dateTimeOffset.Year;

            if (currentDate < dateTimeOffset.AddYears(age))
            {
                age--;
            }

            return age;
        }
    }
}
