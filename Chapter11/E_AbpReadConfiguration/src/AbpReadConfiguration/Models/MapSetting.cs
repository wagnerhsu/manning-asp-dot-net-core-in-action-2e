namespace AbpReadConfiguration.Models
{
    public class MapSetting
    {
        public int DefaultZoomLevel { get; set; }
        public Location DefaultLocation { get; set; }
    }

    public class Location
    {
        public double Latitude { get; set; }

        public double Longitude { get; set; }
    }
}