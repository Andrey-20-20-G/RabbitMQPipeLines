namespace Producer.VK_API
{
    public interface IVK_API
    {
        void GetRequest(VK_Client vK_Client);

        Task<HttpResponseMessage> GetResponseGroup(VK_Client _Client, int i);
        void StartMethod();
    }
}
