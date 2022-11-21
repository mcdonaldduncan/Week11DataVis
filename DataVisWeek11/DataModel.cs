using System.Text.Json.Serialization;


namespace DataVisWeek11
{
    public class DataModel
    {
        [JsonPropertyName("X")]
        public string X { get; set; }

        [JsonPropertyName("Y")]
        public string Y { get; set; }

        public int _X => SetInt(X);
        public int _Y => SetInt(Y);

        int SetInt(string str)
        {
            if (int.TryParse(str, out int temp))
            {
                return temp;
            }
            else
            {
                return 0;
            }
        }
    }
}
