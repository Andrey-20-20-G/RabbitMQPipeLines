namespace Producer.VK_API
{
    public class VK_Client
    {
        public HttpClient client;

        public string API;

        public object ID { get; set; } = 210063492;

        public VK_Client()
        {
            client = new HttpClient();
        }

    }
}
