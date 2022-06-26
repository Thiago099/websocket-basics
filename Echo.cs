using WebSocketSharp;
using WebSocketSharp.Server;
internal class Echo : WebSocketBehavior
{
    protected override void OnMessage(MessageEventArgs e)
    {
        Console.WriteLine("Recived message from client: " + e.Data);
        Send(e.Data);
        Sessions.Broadcast(e.Data);
    }
}

