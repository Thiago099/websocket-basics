using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using WebSocketSharp.Server;
internal static class WebSocketConnections
{
    public static Dictionary<string, List<string>> connections = new Dictionary<string, List<string>>();
    public static WebSocketSessionManager session;

    
}
