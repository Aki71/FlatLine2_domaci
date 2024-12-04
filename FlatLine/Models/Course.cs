namespace FlatLine.Models
{
    public class Course
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? ShortDescription { get; set; }
        public string? LongDescription { get; set; }
        public string? Author { get; set; }
        public decimal Price { get; set; }
        public int Duration { get; set; }


    }
}
