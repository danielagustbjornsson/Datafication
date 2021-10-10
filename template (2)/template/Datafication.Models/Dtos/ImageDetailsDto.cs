namespace Datafication.Models.Dtos
{
    public class ImageDetailsDto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public IceCreamDto IceCream { get; set; }
    }
}