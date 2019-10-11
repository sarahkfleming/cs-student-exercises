using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create Exercises
            Exercise celebrityTribute = new Exercise()
            {
                Name = "Celebrity Tribute",
                ProgrammingLanguage = "HTML and CSS"
            };

            Exercise chickenMonkey = new Exercise()
            {
                Name = "Chicken Monkey",
                ProgrammingLanguage = "JavaScript"
            };

            Exercise kneelDiamonds = new Exercise()
            {
                Name = "Kneel Diamonds",
                ProgrammingLanguage = "JavaScript"
            };

            Exercise planYourHeist = new Exercise()
            {
                Name = "Plan Your Heist",
                ProgrammingLanguage = "C#"
            };

            // Create Cohorts
            Cohort evening09 = new Cohort()
            {
                Name = "Evening Cohort 09"
            };
            Cohort day34 = new Cohort()
            {
                Name = "Day Cohort 34"
            };
            Cohort day35 = new Cohort()
            {
                Name = "Day Cohort 35"
            };

            // Create Students
            Student angela = new Student()
            {
                FirstName = "Angela",
                LastName = "Anderson",
                SlackHandle = "@angela",
                Cohort = evening09
            };

            Student blake = new Student()
            {
                FirstName = "Blake",
                LastName = "Buford",
                SlackHandle = "@blake",
                Cohort = day34
            };

            Student chris = new Student()
            {
                FirstName = "Chris",
                LastName = "Collinsworth",
                SlackHandle = "@chris",
                Cohort = day34
            };

            Student jason = new Student()
            {
                FirstName = "Jason",
                LastName = "Jones",
                SlackHandle = "@jason",
                Cohort = day35
            };

            Student zack = new Student()
            {
                FirstName = "Zack",
                LastName = "Zelson",
                SlackHandle = "@zack",
                Cohort = day34
            };

            evening09.students.Add(angela);
            day34.students.Add(blake);
            day34.students.Add(chris);
            day35.students.Add(jason);
            day34.students.Add(zack);

            // Create Instructors
            Instructor andy = new Instructor()
            {
                FirstName = "Andy",
                LastName = "Collins",
                SlackHandle = "@andy",
                Specialty = "Pointing",
                Cohort = evening09
            };

            Instructor bryan = new Instructor()
            {
                FirstName = "Bryan",
                LastName = "Nilsen",
                SlackHandle = "@bry-5",
                Specialty = "High-fiving",
                Cohort = day34
            };

            Instructor jenna = new Instructor()
            {
                FirstName = "Jenna",
                LastName = "Solis",
                SlackHandle = "@jenna",
                Specialty = "Stuffed animal conveyor belts",
                Cohort = day35
            };

            evening09.instructors.Add(andy);
            day34.instructors.Add(bryan);
            day35.instructors.Add(jenna);

            andy.AssignExercise(angela, celebrityTribute);
            bryan.AssignExercise(blake, celebrityTribute);
            bryan.AssignExercise(blake, chickenMonkey);
            andy.AssignExercise(blake, kneelDiamonds);
            bryan.AssignExercise(jason, celebrityTribute);
            jenna.AssignExercise(jason, chickenMonkey);
            andy.AssignExercise(chris, celebrityTribute);
            andy.AssignExercise(chris, chickenMonkey);
            jenna.AssignExercise(chris, kneelDiamonds);
            jenna.AssignExercise(chris, planYourHeist);

            // Generate a report that displays which students are working on which exercises.
            // Clarification: Iterate over all exercises and then only print the students who are assigned to that exercise. 

            List<Student> students = new List<Student>()
            {
                zack, angela, blake, chris, jason
            };

            List<Exercise> exercises = new List<Exercise>()
            {
                celebrityTribute, chickenMonkey, kneelDiamonds, planYourHeist
            };

            foreach (Exercise exercise in exercises)
            {
                Console.WriteLine();
                Console.WriteLine("-------------------------");
                Console.WriteLine(exercise.Name);
                Console.WriteLine("-------------------------");

                foreach (Student student in students)
                {
                    if (student.exercises.Contains(exercise))
                    {
                        Console.WriteLine($"{student.FirstName} {student.LastName}");
                    }
                }
            }

            // Student Exercises: Part 2
            List<Instructor> instructors = new List<Instructor>()
            {
              andy, bryan, jenna
            };

            List<Cohort> cohorts = new List<Cohort>()
            {
              evening09, day34, day35
            };

            // List exercises for the JavaScript language by using the Where() LINQ method.
            List<Exercise> javaScriptExercises = exercises.Where(exercise => exercise.ProgrammingLanguage == "JavaScript").ToList();

            // List students in a particular cohort by using the Where() LINQ method.
            List<Student> cohort34Students = students.Where(student => student.Cohort == day34).ToList();

            // List instructors in a particular cohort by using the Where() LINQ method.
            List<Instructor> cohort34Instructors = instructors.Where(instructor => instructor.Cohort == day34).ToList();

            // Sort the students by their last name.
            var studentsSortedABC = students.OrderBy(student => student.LastName);

            // Display any students that aren't working on any exercises (Make sure one of your student instances don't have any exercises. Create a new student if you need to.)
            var studentsWithoutExercises = students.Where(student => student.exercises.Count == 0);

            // Which student is working on the most exercises? Make sure one of your students has more exercises than the others.
            var studentWithMostExercises = students.OrderByDescending(student => student.exercises.Count()).First();
                        
            // How many students in each cohort?
            var studentCount = students.GroupBy(
                student => student.Cohort,
                (key, value) => new
                {
                    StudentName = key,
                    StudentCount = value.Count()
                });
        }
    }
}