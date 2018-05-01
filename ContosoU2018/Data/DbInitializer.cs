using ContosoU2018.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoU2018.Data
{
    public class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            //EnsureCreated method will automatically create the database
            //if it does not already exist.
            context.Database.EnsureCreated();

            //First look for any students
            //========================= STUDENTS ==========================//
            if (context.Students.Any())
            {
                //Database has alredy been seeded with students
                return; //exits
            }
            //if we get here - students do not already exist - seed 
            var students = new Student[]
            {
                new Student
                {
                    FirstName = "Carson",
                    LastName = "Alexander",
                    Email = "calexander@contoso.com",
                    EnrollmentDate = DateTime.Parse("2017-09-01"),
                    Address = "4 Flanders Court",
                    City= "Moncton",
                    Province = "NB",
                    PostalCode = "E1C 0K6"
                },
                new Student
                {
                    FirstName = "Meridith",
                    LastName = "Alonso",
                    Email = "malonso@contoso.com",
                    EnrollmentDate = DateTime.Parse("2017-09-01"),
                    Address = "205 Argyle Street",
                    City= "Moncton",
                    Province = "NB",
                    PostalCode = "E1C 8V2"
                }
            };

            //Loop the students array and add each student to the database context
            foreach(Student s in students)
            {
                context.Students.Add(s);
            }

            //Save context 
            context.SaveChanges();


            //====================== INSTRUCTORS ==========================//
            var instructors = new Instructor[]
            {
                new Instructor
                {
                    FirstName = "Marc",
                    LastName = "Williams",
                    Email = "mwilliams@faculty.contoso.com",
                    HireDate = DateTime.Parse("1996-01-31"),
                    Address = "123 Main Street",
                    City = "Moncton",
                    Province = "NB",
                    PostalCode = "E1C 3G4"
                },
                new Instructor
                {
                    FirstName = "Frank",
                    LastName = "Bekkering",
                    Email = "fbekkering@faculty.contoso.com",
                    HireDate = DateTime.Parse("1996-01-31"),
                    Address = "456 Main Street",
                    City = "Moncton",
                    Province = "NB",
                    PostalCode = "E1C 3G4"
                }
            };
            foreach(Instructor i in instructors)
            {
                context.Instructors.Add(i);
            }
            //save it
            context.SaveChanges();

            //====================== COURSES ==========================//
            var courses = new Course[]
            {
                new Course{CourseID=1050,Title="Chemistry",Credits=3},
                new Course{CourseID=4022,Title="MicroEconomics",Credits=3}
            };
            foreach (Course c in courses)
            {
                context.Add(c);
            }
            context.SaveChanges();

            //====================== ENROLLMENT ====================//
            var enrollments = new Enrollment[]
            {
                new Enrollment{CourseID= 1050,
                               StudentID=students.Single(s=>s.LastName=="Alexander").ID,
                               Grade = Grade.A},
                new Enrollment{CourseID= 4022,
                               StudentID=students.Single(s=>s.LastName=="Alonso").ID,
                               Grade = Grade.B},
            };
            foreach(Enrollment e in enrollments)
            {
                context.Enrollments.Add(e);
            }
            context.SaveChanges();
        }
    }
}
