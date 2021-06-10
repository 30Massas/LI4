using System.Collections.Generic;

namespace MapIntegration.Models
{
    public class Locations
    {
        public int LocationId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public Locations(int locid, string title, string desc, string latitude, string longitude)
        {
            this.LocationId = locid;
            this.Title = title;
            this.Description = desc;
            this.Latitude = latitude;
            this.Longitude = longitude;
        }
    }




    public class LocationLists
    {
        public IEnumerable<Locations> LocationList { get; set; }
    }








}