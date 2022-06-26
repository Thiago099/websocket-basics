using WebSocketSharp;
using WebSocketSharp.Server;

string adress = "localhost:7890";
WebSocketServer server = new WebSocketServer($"ws://{adress}");
server.AddWebSocketService<Echo>("/Echo");

server.Start();
Console.WriteLine($"Server started on {adress}");
Console.ReadKey();
server.Stop();