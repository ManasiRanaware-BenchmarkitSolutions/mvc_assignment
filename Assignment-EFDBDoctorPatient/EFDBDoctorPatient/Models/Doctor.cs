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
    
    public partial class Doctor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Doctor()
        {
            this.Patients = new HashSet<Patient>();
        }
    
        public long DoctorID { get; set; }

        [Required(ErrorMessage = "Doctor Name cannot be blank")]
        [Display(Name = "Doctor Name")]
        [MaxLength(20, ErrorMessage = "Doctor Name can be maximum 20 characters long")]
        [MinLength(4, ErrorMessage ="Doctor Name should contain ateast 4 characters")]
        public string DoctorName { get; set; }

        [Required(ErrorMessage ="Specialization cannot be blank")]
        [Display(Name = "Specialization")]
        [MaxLength(10, ErrorMessage = "Max 10 characters")]
        public string Specialization { get; set; }

        [Required]
        [Display(Name = "Doctor Address")]
        [MaxLength(100, ErrorMessage = "Max 100 characters")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Contact No should contain only digits")]
        [Display(Name = "Doctor Phone")]
        [RegularExpression(@"[0-9]{10}", ErrorMessage = "Numbers Only")]
        [MaxLength(10)]
        [MinLength(10)]
        public string Contact { get; set; }
        public string Photo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Patient> Patients { get; set; }
    }
}