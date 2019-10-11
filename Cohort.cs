using System.Collections.Generic;

namespace StudentExercises
{
    class Cohort
    {
        public string Name { get; set; }
        public List<Student> students = new List<Student>();
        public List<Instructor> instructors = new List<Instructor>();
    }
}