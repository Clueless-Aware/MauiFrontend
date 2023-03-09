using ProjectWork.Models.Artwork;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ProjectWork.Models.Core
{
    /// <summary>
    /// Set the Query Parameters for url page, ordering, search and specific to test
    /// </summary>
    public class Parameters
    {

        public Dictionary<string, string> Dictionary = new Dictionary<string, string>()
        {
            ["page"]="1"
        };
        public void SetPage(int page)
        {
            Dictionary["page"] = page.ToString();
        }
        public void SetOrdering(string orderingFilter)
        {
            Dictionary["ordering"] = orderingFilter;
        }
        public void SetSearch(string searchFilter)
        {
            Dictionary["search"] = searchFilter;
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
                Dictionary[specific.Key] = specific.Value.ToString();
            }
        }
    }
}
