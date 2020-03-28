using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace ConsoleSignalRClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            HubConnection _hubConnection = new HubConnectionBuilder()
                .WithUrl("https://localhost:5001/chatHub")
                .Build();

            _hubConnection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                var encodedMsg = $"{user}: {message}";
                Console.WriteLine($"    {encodedMsg}");
            });

            await _hubConnection.StartAsync();

            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();
        }
    }
}
