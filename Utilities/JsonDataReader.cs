using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace FlipKartWebSite.Utilities
{
    public static class JsonDataReader
    {
        public static List<string> GetCategorylist(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Json file not found: {filePath}");
            }

            string _jsonContent = File.ReadAllText(filePath);

            var categories = JsonConvert.DeserializeObject<List<CategoryData>>(_jsonContent);

            var categoryNames = new List<string>();

            foreach (var category in categories)
            {
                categoryNames.Add(category.CategoryName);
            }
            return categoryNames;
        }


        public class CategoryData
        {
            public string CategoryName { get; set; }
        }
    }
}
