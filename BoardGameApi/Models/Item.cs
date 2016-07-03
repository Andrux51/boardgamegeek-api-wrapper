using System.Collections.Generic;
using RestSharp.Deserializers;

namespace BoardGameApi.Models
{
    public class SearchResults
    {
        public int Total { get; set; }

        public List<Item> Items { get; set; }
    }

    public class Item
    {
        public string Type { get; set; }
        public int Id { get; set; }

        public Name Name { get; set; }
    }

    public class Name
    {
        public string Type { get; set; }

        [DeserializeAs(Attribute = true, Name = "value")]
        public string Value { get; set; }
    }

    public class ThingDetail : Item
    {
        public string Description { get; set; }
        public string Image { get; set; }
    }
}