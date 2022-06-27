using WebSocketSharp;
using WebSocketSharp.Server;
internal class PosicaoNotificacacaoBehavior : WebSocketBehavior
{
    protected override void OnMessage(MessageEventArgs e)
    {
        Console.WriteLine("Recived message from client: " + e.Data);
        Send(e.Data);
        Sessions.Broadcast(e.Data);
    }
    protected override void OnOpen()
    {
        var query = Context.QueryString;
        var name = query["token"];
        Console.WriteLine($"Client {name} connected on id {ID}");

        if (!WebSocketConnections.connections.ContainsKey(name))
        {
            WebSocketConnections.connections[name] = new List<string>();
        }
        WebSocketConnections.connections[name].Add(ID);
    }
    protected override void OnClose(CloseEventArgs e)
    {
        var query = Context.QueryString;
        var name = query["token"];
        Console.WriteLine($"Client {name} disconected on id {ID}");
        WebSocketConnections.connections[name].Remove(ID);
    }
}

