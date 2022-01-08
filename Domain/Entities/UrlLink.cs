namespace Domain.Entities
{
    public class UrlLink 
    {
        public string InputUrl { get; set; }

        public UrlLink(string inputUrl)
        {
            InputUrl = inputUrl;
        }
    }
}
