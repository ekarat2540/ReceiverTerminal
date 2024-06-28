using System.Net;
using System.Net.Sockets;

class Receiver
{
    static async Task Main(string[] args)
    {
        TcpListener listener = new TcpListener(IPAddress.Any, 5714);

        try
        {

        }catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
