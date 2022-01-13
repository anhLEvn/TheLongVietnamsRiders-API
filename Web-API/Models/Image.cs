namespace Web_API.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string NameImage { get; set; }
        public string UlrImage { get; set; }
        public string SourceImage { get; set; } // Where the image is from
        //public TourPackage TourPackage { get; set; }
    }
}