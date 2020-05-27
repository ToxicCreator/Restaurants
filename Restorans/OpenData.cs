using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class OpenData
{
    private FoodPlace[] restorans;

    public OpenData(string fileName)
    {
        string fullPath = Path.Combine(Directory.GetCurrentDirectory(), fileName);
        string json = File.ReadAllText(fullPath, Encoding.UTF8);
        restorans = JsonConvert.DeserializeObject<FoodPlace[]>(json);
    }

    public FoodPlace[] GetFoodPlaces()
    {
        return restorans;
    }

    public FoodPlace[] FindFoodPlaces(string name)
    {
        if (name.Length > 0)
        {
            return restorans.Where(food => food.Name.ToLower().Contains(name.ToLower())).ToArray();
        }
        else
        {
            return restorans;
        }
    }

    public FoodPlace[] FindFoodPlaces(string name, FoodPlace[] foodPlaces) //Делает поиск среди массива foodPlaces
    {
        if (name.Length > 0)
        {
            return foodPlaces.Where(food => food.Name.ToLower().Contains(name.ToLower())).ToArray();
        }
        else
        {
            return restorans;
        }
    }

    public string[] GetUniqueType()
    {
        List<string> types = new List<string>();
        foreach (var x in restorans)
        {
            types.Add(x.TypeObject);
        }

        return types.Distinct().ToArray();
    }

    public FoodPlace[] FindFoodPlacesOnTypeObject(string typeObject)
    {
        return restorans.Where(food => food.TypeObject.ToLower().Contains(typeObject.ToLower())).ToArray();
    }

        

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