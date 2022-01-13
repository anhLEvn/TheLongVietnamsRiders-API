using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_API.Models
{
    public class TourPackage
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        //public int Id { get; set; }
        public string NameTour { get; set; }
        public string DescriptionTour { get; set; }
        public string ItineraryUrl { get; set; } // should be ItineraryUrl
        public float PriceTour { get; set; }
        public int  TimeTour{ get; set; }
        public IList<Image> ImageUrls;
        //public int CreatedBy { get; set; } // id of User who build the itinerary for this package TODO later

    }
}
