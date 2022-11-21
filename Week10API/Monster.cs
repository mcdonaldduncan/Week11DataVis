using System.Text.Json.Serialization;

namespace Week10API
{
    public class Monster
    {
        [JsonPropertyName("id")]
        public string ID { get; set; }

        [JsonPropertyName("Name")]
        public string? Name { get; set; }

        [JsonPropertyName("Type")]
        public string? Type { get; set; }

        [JsonPropertyName("HP")]
        public string? HP { get; set; }

        [JsonPropertyName("MP")]
        public string? MP { get; set; }

        [JsonPropertyName("Location")]
        public string? Location { get; set; }


        public Monster(List<string> props)
        {
            if (props.Count == 6)
            {
                ID = props[0];
                Name = props[1];
                Type = props[2];
                HP = props[3];
                MP = props[4];
                Location = props[5];
            }
            else
            {
                ID = "error";
                Name = "error";
                Type = "error";
                HP = "error";
                MP = "error";
                Location = "error";
            }
            
        }

    }
}
