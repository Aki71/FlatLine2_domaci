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
        public TimeSpan Duration { get; set; }
        public byte[]? ProfilePicture { get; set; }
        public string? ProfilePictureFileName { get; set; }
        public string? ProfilePictureContentType { get; set; }
    }
}
