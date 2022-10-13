using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace MeddelandeCentralen.Data
{
    public class SampleHub : Hub
    {
        public const string HubUrl = "/chat";

        public async Task Broadcast(string username, string message)
        {
            await Clients.All.SendAsync("Broadcast", username, message);
        }

        public override Task OnConnectedAsync()
        {
            Console.WriteLine($"{Context.ConnectionId} connected");
            return base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception error)
        {
            Console.WriteLine($"Disconnected {error?.Message} {Context.ConnectionId}");
            await base.OnDisconnectedAsync(error);
        }
    }
}