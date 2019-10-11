namespace StudentExercises
{
    class Instructor
    {
       public string FirstName { get; set; } 
       public string LastName { get; set; } 
       public string SlackHandle { get; set; }
       public Cohort Cohort { get; set; }
       public string Specialty { get; set; }
       public void AssignExercise(Student student, Exercise exercise)
       {
           student.exercises.Add(exercise);
       }
    }
}