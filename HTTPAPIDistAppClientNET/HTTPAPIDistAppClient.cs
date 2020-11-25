using System;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Sockets;
using System.Collections.Generic;
using System.IO;

//Combined from SimpleChat and this link that showed how to http post json  in c# http://zetcode.com/csharp/httpclient/
namespace HttpAPIDistAppClientNET
{
    class HttpAPIDistAppClient
    {
        const int PORT = 8088;
        string serverHost;
        string gson;
        private string server;
        TcpClient socketForServer = null;
        private NetworkStream networkStream;
        private Socket socketForClient;

        public HttpAPIDistAppClient()
        {

            Console.WriteLine("Enter host server:");
            server = Console.ReadLine();
            Console.WriteLine();
            TcpListener tcpListener = null;
            socketForClient = null;

            Console.WriteLine("Connecting to server ...");
            socketForServer = new TcpClient(server, PORT);
            Console.WriteLine("Connected to server " + socketForServer.Client.AddressFamily.ToString());
            networkStream = socketForServer.GetStream();

            read();
        }


        public async void read()
        {

            List<string> urls = new List<string>();
            using (StreamReader reader = new StreamReader("urls.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    urls.Add(line);
                }
            }

           /* foreach(string u in urls)
            {
                Console.WriteLine(u);
            }*/
            var json = JsonConvert.SerializeObject(urls);
            var data = new StringContent(json, Encoding.UTF8, "application/json");


            var url = "http://localhost" + ":" + PORT + "/news";
            using var client = new HttpClient();
            //Console.WriteLine(url);

            var response = client.PostAsync(url, data).Result;
            if (response.StatusCode != System.Net.HttpStatusCode.Created)
            {
                //Console.WriteLine(response);
            }

            response.EnsureSuccessStatusCode();
            var resp = await response.Content.ReadAsStringAsync();

            List<News> news = JsonConvert.DeserializeObject<List<News>>(resp);
            news.ForEach(Console.WriteLine);
            

        }


        static void Main(string[] args)
        {
            new HttpAPIDistAppClient();
        }
    }
}