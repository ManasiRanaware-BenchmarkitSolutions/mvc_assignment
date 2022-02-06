//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EFDBDoctorPatient.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class Patient
    {
       
        public long PatientID { get; set; }

        [Required(ErrorMessage = "Patient Name cannot be blank")]
        //[RegularExpression(@"[A-Za-z]", ErrorMessage = "Alphabets Only")]
        [Display(Name = "Patient Name")]
        [MaxLength(20, ErrorMessage = "Patient Name can be maximum 20 characters long")]
        [MinLength(4, ErrorMessage = "Patient Name should contain ateast 4 characters")]
        public string PatientName { get; set; }

        [Required(ErrorMessage ="Gender cannot be empty")]
        public string Gender { get; set; }

        
        public Nullable<int> Age { get; set; }
        public string Address { get; set; }

        [Required(ErrorMessage = "Contact No cannot be blank")]
        [RegularExpression(@"[0-9]{10}", ErrorMessage = "Numbers Only")]
        [Display(Name = "Contact")]
        [MaxLength(10)]
        [MinLength(10)]
        public string Contact { get; set; }

        [Required]
        [Display(Name = "Date Of Admission")]
        public Nullable<System.DateTime> DOA { get; set; }

    
        public Nullable<long> DoctorID { get; set; }
        public string Photo { get; set; }

       
        public virtual Doctor Doctor { get; set; }
    }
}
