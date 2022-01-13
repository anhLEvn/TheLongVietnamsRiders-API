using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppAPI_TLVNsR.Models
{
    public class TourCategory
    {
        public int Id { get; set; }
        public string  NameCategory { get; set; }
        public string DescriptionCate { get; set; }
        public string  AvatarImageFileName { get; set; }
        public ICollection<Tour> Tours { get; set; }
    }
}
