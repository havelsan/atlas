using Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Core.Models
{
    public class PatientListViewModel
    {
        [Required]
        public string ObjectId;
        [CombinedMinLength(20, "Bar", "Baz", ErrorMessage = "The combined minimum length of the Foo, Bar and Baz properties should be longer than 20")]
        public string Name;
    }
}