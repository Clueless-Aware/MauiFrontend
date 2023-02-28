using ProjectWork.Models.Artwork;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ProjectWork.Models.Core
{
    public class Parameters
    {

        public Dictionary<string, string> dictionary = new Dictionary<string, string>()
        {
            ["page"]="1"
        };
        public void SetPage(int page)
        {
            dictionary["page"] = page.ToString();
        }
        public void SetOrdering(string orderingFilter)
        {
            dictionary["ordering"] = orderingFilter;
        }
        public void SetSearch(string searchFilter)
        {
            dictionary["search"] = searchFilter;
        }
        //TODO: To test
        public void SetSpecific<T>(T @base)
        {
            var options = new JsonSerializerOptions
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };
            var specificParemeters = JsonSerializer.Deserialize<Dictionary<string, object>>(JsonSerializer.Serialize(@base), options);
            foreach (var specific in specificParemeters)
            {
                dictionary[specific.Key] = specific.Value.ToString();
            }
        }
    }
}
