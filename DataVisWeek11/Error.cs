namespace DataVisWeek11
{
    internal class Error
    {
        public string ErrorMessage { get; set; }
        public string Source { get; set; }

        public Error(string message, string source)
        {
            ErrorMessage = message;
            Source = source;
        }

        public override string ToString()
        {
            return $"Error: {ErrorMessage} Source: {Source}";
        }
    }
}
