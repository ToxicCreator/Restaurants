using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
public class OpenData
{
    private static FoodPlace[] restorans;

    public OpenData(string fileName)
    {
        string fullPath = Path.Combine(Directory.GetCurrentDirectory(), fileName);
        string json = File.ReadAllText(fullPath);
    }

    public FoodPlace[] GetFoodPlaces()
    {
        return restorans;
    }

    public class PublicPhoneItem
    {
        public string PublicPhone { get; set; }
    }

    public class GeoData
    {
        public string type { get; set; }
        public List<double> coordinates { get; set; }
    }

    public class FoodPlace
    {
        public int global_id { get; set; }

        public string Latitude_WGS84 { get; set; }

        public string ID { get; set; }

        public string Name { get; set; }

        public string IsNetObject { get; set; }

        public string TypeObject { get; set; }

        public string AdmArea { get; set; }

        public string District { get; set; }

        public string Address { get; set; }

        public List<PublicPhoneItem> PublicPhone { get; set; }

        public int SeatsCount { get; set; }

        public string SocialPrivileges { get; set; }

        public string Longitude_WGS84 { get; set; }

        public GeoData geoData { get; set; }
    }

}