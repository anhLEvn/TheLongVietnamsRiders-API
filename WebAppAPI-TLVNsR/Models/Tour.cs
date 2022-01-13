using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppAPI_TLVNsR.Models
{
    public class Tour
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        //public int Id { get; set; }
        public string TitleTour { get; set; }
        public string DescriptionTour { get; set; }
        public string ItineraryFileName { get; set; }        
        public float PriceTour { get; set; }
        public int LengthTour { get; set; }
        public int MinParticipant { get; set; }
        public int MaxParticipant { get; set; }
        public string ImageFileName { get; set; }
        public DateTime DateCreated { get; set; }
        public TourCategory TourCategory { get; set; }
        //public string  TourIncluded { get; set; }
        //public string  TourExcluded { get; set; }
    }
}
