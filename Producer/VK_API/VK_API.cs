using Newtonsoft.Json;
using Producer.RabbitMQ;
using VkNet;
using VkNet.Model;

namespace Producer.VK_API
{
    public class VK_API : IVK_API
    {
        public async void GetRequest(VK_Client client)
        {
            int i = 0;
            //int ID = 210063492;
            //object API = "vk1.a.RkstJ7-3M-yG05t6b7BchYcovDnNTWJkJ3BwhnaJlhEcJxCZuk8vQArcDIw17c7cqzVN2gDs1Lmk55eRS7mTMcN2o5k9jNvC1wcA1ceTdOHp4-hp3-kwTKlYu8SL4zWILhLmR91fjSnFyrNXn7MYwd9B4kBv5BdARWix0Q3-mpHMp7Pouz9QDjJvFID8Zlbf";
            var user = new VK_Client();

            HttpResponseMessage responseMessage1 = await user.client.GetAsync($"https://api.vk.com/method/groups.getById?group_id={client.ID}&PARAMS&access_token={client.API}&v=5.131&count");
            //HttpResponseMessage responseMessage2 = await client.client.GetAsync($"https://api.vk.com/method/groups.getMembers?group_id={user.ID}&PARAMS&access_token={user.API}&v=5.131&sort={"id_asc"}&fields={"photo_max"}&offset={i}");

            

            

            RabbitMqService service = new RabbitMqService();
            //service.SendMessage(b1);
            //service.SendMessage(b2);

            //i += 1000;
            //var res = await GetResponseMembers(client, i);
            var zl = responseMessage1.Content.ReadAsStringAsync().Result.Equals("count");

            //var responseMessage1 = await GetResponseGroup(client, i);
            string json1 = responseMessage1.Content.ReadAsStringAsync().Result;

            object a1 = JsonConvert.DeserializeObject(json1);
            string b1 = JsonConvert.SerializeObject(a1, Formatting.Indented);
            service.SendMessage(b1);
            //while (i < 500000)
            //{
            //    if (i > 25000)
            //    {
            //        Thread.Sleep(10000);
            //    }
               
                

                //var responseMessage2 = await GetResponseMembers(client, i);
                //var zl2 = responseMessage2.Content.ReadAsStringAsync().Result.Equals("count");
                //string json2 = responseMessage2.Content.ReadAsStringAsync().Result;
                //object a2 = JsonConvert.DeserializeObject(json2);
                //string b2 = JsonConvert.SerializeObject(a2, Formatting.Indented);
                ////Console.WriteLine(b2);

                //service.SendMessage(b2);
                ////service.SendMessage(b1);
                //i += 1000;
            //}


        }

        public void StartMethod()
        {

            

            //api.Authorize(new ApiAuthParams
            //{
            //    AccessToken = "39b45ff1262e16fb0dcc15cab1b835de004b75cef5e8d7c3f7c3e2e9b0d7a8e8985aa35f0ece57304dcfb"

            //});
            //API = api.Token;
            var api = new VkApi();

            api.Authorize(new ApiAuthParams
            {
                AccessToken = "39b45ff1262e16fb0dcc15cab1b835de004b75cef5e8d7c3f7c3e2e9b0d7a8e8985aa35f0ece57304dcfb"//"vk1.a.RkstJ7-3M-yG05t6b7BchYcovDnNTWJkJ3BwhnaJlhEcJxCZuk8vQArcDIw17c7cqzVN2gDs1Lmk55eRS7mTMcN2o5k9jNvC1wcA1ceTdOHp4-hp3-kwTKlYu8SL4zWILhLmR91fjSnFyrNXn7MYwd9B4kBv5BdARWix0Q3-mpHMp7Pouz9QDjJvFID8Zlbf"//"39b45ff1262e16fb0dcc15cab1b835de004b75cef5e8d7c3f7c3e2e9b0d7a8e8985aa35f0ece57304dcfb"

            });
            VK_Client client1 = new();
            client1.API = api.Token;
            GetRequest(client1);
        }
        public async Task<HttpResponseMessage> GetResponseGroup(VK_Client _Client, int i)
        {
            HttpResponseMessage responseMessage1 = await _Client.client.GetAsync($"https://api.vk.com/method/groups.getById?group_id={_Client.ID}&PARAMS&access_token={_Client.API}&v=5.131&count");
            return responseMessage1;
            
        }

        public async Task<HttpResponseMessage> GetResponseMembers(VK_Client _Client, int i)
        {
            //var mass = new HttpResponseMessage[5000000];int k = 0;
            var responseMessage2 = await _Client.client.GetAsync($"https://api.vk.com/method/groups.getMembers?group_id={_Client.ID}&PARAMS&access_token={_Client.API}&v=5.131&sort={"id_asc"}&fields={"photo_max"}&offset={i}");
            //mass[k] = responseMessage2;k++;
            //while(i<500000)
            //{
            //    if (i > 25000)
            //    {
            //        Thread.Sleep(10000);
            //    }
            //    i += 1000;
            //    responseMessage2 = await _Client.client.GetAsync($"https://api.vk.com/method/groups.getMembers?group_id={_Client.ID}&PARAMS&access_token={_Client.API}&v=5.131&sort={"id_asc"}&fields={"photo_max"}&offset={i}");
            //    mass[k] = responseMessage2 ;k++;
            //}
            //return mass;
            return responseMessage2;

        }

    }
}
