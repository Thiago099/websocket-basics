using WebSocketSharp;
using WebSocketSharp.Server;

string adress = "localhost:7890";
WebSocketServer server = new WebSocketServer($"ws://{adress}");
server.AddWebSocketService<PosicaoNotificacacaoBehavior>("/PosicaoNotificacacao");
server.Start();
WebSocketConnections.session = server.WebSocketServices["/PosicaoNotificacacao"].Sessions;


Console.WriteLine($"Server started on {adress}");

while(true)
{
    if (WebSocketConnections.connections.ContainsKey("gugu"))
    {
        foreach (var id in WebSocketConnections.connections["gugu"])
        {
            WebSocketConnections.session.SendTo("gugu é o cara", id);
        }
        Thread.Sleep(1000);
    }
    if (WebSocketConnections.connections.ContainsKey("thithi"))
    {
        foreach (var id in WebSocketConnections.connections["thithi"])
        {
            WebSocketConnections.session.SendTo("thithi é o cara", id);
        }
        Thread.Sleep(1000);
    }
    if (WebSocketConnections.connections.ContainsKey("oH1eRpUZgxVm7jZ9fKaVD6n2wzwxYqcdmROjfw3d"))
    {
        foreach (var id in WebSocketConnections.connections["oH1eRpUZgxVm7jZ9fKaVD6n2wzwxYqcdmROjfw3d"])
        {
            WebSocketConnections.session.SendTo("{\"idCliente\": \"25\",\"evento\": \"BUTTON\",\"dataUTC\": \"2019-09-12 21:07:45\",\"lat\": \"-19.84973\",\"lng\": \"-43.94702\",\"idPosicao\": \"XeNzdgDqZwrQBbNgypOaBxMLlmoGpaOA\",\"IMEI\": \"102094\",\"emailAssunto\": \"PR-VSA - MONITORAMENTO DESATIVADO\",\"emailTexto\": \"O MONITORAMENTO DA AERONAVE PR-VSA FOI SUSPENSO.\",\"smsTexto\": \"PR-VSA - MONITORAMENTO DESATIVADO\"}", id);
        }
        Console.WriteLine("message sent");
        Thread.Sleep(5000);
    }

}

Console.ReadKey();
server.Stop();