using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace RestFulWebApiAssignment.Models
{
    public class StudentModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }
        [Required(ErrorMessage = "City is required.")]

        public string City { get; set; }
        [Required(ErrorMessage = "Department is required.")]

        public int Department { get; set; }
    }
}