using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UpliftlabUniversity.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }
        [Required(ErrorMessage = "Department Name is Required.")]
        [MaxLength(50)]
        public string Name { get; set; }
        [DisplayFormat(DataFormatString = "{0:c}")]
        [Required(ErrorMessage = "Budget is Required.")]
        [Column(TypeName = "Money")]
        public decimal? Budget { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Start Date is Required.")]
        public DateTime StartDate { get; set; }
        [Display(Name = "Administrator")]
        public int? InstructorID { get; set; }

        public virtual Instructor Administrator { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}