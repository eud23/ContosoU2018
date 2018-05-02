using System.ComponentModel.DataAnnotations;
namespace ContosoU2018.Models
{
    public class Enrollment
    {
        /*
         * The EnrollmentID property will be the primary key:  this entity used the ClassNameID pattern
         * instead of the ID by itself that you have in the Student Entity
         */
        public int EnrollmentID { get; set; }//PK

        public int CourseID { get; set; } //FK with corresponding navigation property Course

        public int StudentID { get; set; }//FK with corresponding navigation property Student

        //Display "No Grade Yet" when the Grade is null
        [DisplayFormat(NullDisplayText ="No Grade Yet")]
        public Grade? Grade { get; set; }//? meaning is nullable - because we don't start with a grade

        //Navigation Property :  Each enrollment must be for one student
        public virtual Student Student { get; set; }

        public virtual Course Course { get; set; }
    }

    //Grade enumeration
    public enum Grade
    {
        A, B, C, D, F
    }
}