using System.Net;
using System.Net.Sockets;

class Receiver
{
    static async Task Main(string[] args)
    {
        TcpListener listener = new TcpListener(IPAddress.Any, 5714);

        try
        {
            listener.Start();
            while (true) { 
            TcpClient client = await listener.AcceptTcpClientAsync();   
            _ = GetMessage(client);
            }

        }catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    static async Task GetMessage(TcpClient client)
    {
        NetworkStream stream = client.GetStream();
        StreamReader reader = new StreamReader(stream);
        try
        {
            string message = await reader.ReadLineAsync();
            if(message != null)
            {
                Console.Write(message);
            }
            stream.Close();
            reader.Close();
            client.Close();
        }catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
