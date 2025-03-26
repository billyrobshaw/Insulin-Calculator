using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insulin_Converter.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Brand
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Food
    {
        public string revisionId { get; set; }
        public Brand brand { get; set; }
        public string name { get; set; }

        public List<Serving> servings { get; set; }
        public string classification { get; set; }
        public Nutrients nutrients { get; set; }
    }

    public class Metadata
    {
        public int total { get; set; }
        public int limit { get; set; }
        public int offset { get; set; }
    }

    public class Nutrients
    {
        public double energy { get; set; }
        public double fat { get; set; }
        public double netCarbs { get; set; }
        public double protein { get; set; }
        public double sugar { get; set; }
        public double sodium { get; set; }
        public double satFat { get; set; }
        public double alcohol { get; set; }
        public double? totalCarbs { get; set; }
        public double? addedSugar { get; set; }
        public double? fiber { get; set; }
        public double? calcium { get; set; }
        public double? transFat { get; set; }
        public double? cholesterol { get; set; }
        public double? iron { get; set; }
    }

    public class Root
    {
        public Metadata metadata { get; set; }
        public List<Food> foods { get; set; }
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

    public class DefaultServing
    {
        public string name { get; set; }
        public double scale { get; set; }
        public string type { get; set; }
        public bool isDefault { get; set; }
    }

    public class Serving
    {
        public string name { get; set; }
        public double scale { get; set; }
        public string type { get; set; }
        public bool isDefault { get; set; }
    }




}
