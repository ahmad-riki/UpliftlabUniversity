using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace UpliftlabUniversity.Models
{
    public class Student
    {
        public int StudentID { get; set; }

        [Required(ErrorMessage = "Last Name is Required.")] //Message for error
        [Display(Name = "Last Name")]
        [MaxLength(50)] // Limitation lenght of the Last Name
        public string LastName { get; set; }

        [Required(ErrorMessage = "First Name is Required.")]
        [Column("First Name")]
        [MaxLength(50)]
        public string FirstMidname { get; set; }

        [Required(ErrorMessage = "Enrollment Date is Required.")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Display(Name = "Enrollment Date")]
        public DateTime? EnrollmentDate { get; set; }

        public string Fullname
        {
            get
            {
                return LastName + ", " + FirstMidname;
            }
        }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}