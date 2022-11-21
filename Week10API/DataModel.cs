using System.Reflection.Metadata.Ecma335;

namespace Week10API
{
    public class DataModel
    {
        public string X { get; set; }
        public string Y { get; set; }

        public int _X => SetInt(X);
        public int _Y => SetInt(Y);

        static int SetInt(string str)
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

        public DataModel(List<string> props)
        {
            if (props.Count == 2)
            {
                X = props[0];
                Y = props[1];   
            }
            else
            {
                X = "error";
                Y = "error";
            }
        }
    }
}
