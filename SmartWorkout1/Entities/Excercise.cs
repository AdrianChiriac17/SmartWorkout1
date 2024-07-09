namespace SmartWorkout1.Entities
{
    public class Excercise
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }

        public string ImageURL { get; set; }    


        public ICollection<ExcerciseLog> ExcerciseLogs { get; set; }
    }
}
