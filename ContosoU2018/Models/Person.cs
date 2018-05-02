using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoU2018.Models
{
    public abstract class Person
    {
        //Person properties - characteristics 

        /*
         *  These properties will become database fields within the Person table
         *  by using the Entity Framework Core 
         *  The ID Property will become the Primary Key Column of the database table that correspondes
         *  to this class (Person).  
         *  By default the EF interprets a property that's named ID or ClassNameID as the PK
         *  for example:  
         *      - ID
         *      - PersonID
         */
        public int ID { get; set; }
        [Display(Name = "First Name")]
        [Required]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required]
        [StringLength(65, ErrorMessage = "Last name cannot be longer than 65 characters.")]
        public string LastName { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [StringLength(150)]//only requirement is the size, it will use a default error message
        public string Address { get; set; }
        [Required]
        [StringLength(60)]
        public string City { get; set; }
        [Display(Name = "Postal Code")]
        [Required]
        [StringLength(7)]
        [Column(TypeName ="nchar(7)")]
        [DataType(DataType.PostalCode)]
        public string PostalCode { get; set; }
        [Required]
        [StringLength(2)]
        [Column(TypeName ="nchar(2)")]
        public string Province { get; set; }


        //Read Only properties
        [Display(Name ="Name")]
        public string FullName
        {
            get
            {
                //return LastName + ", " + FirstName;
                return FirstName + " "  + LastName;
            }
        }

        public string IDFullName
        {
            get
            {
                return "(" + ID + ") " + LastName + ", " + FirstName;
            }
        }


    }
}
