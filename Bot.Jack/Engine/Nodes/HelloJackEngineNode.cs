using System.Text;
using Microsoft.Bot.Builder.Luis.Models;

namespace Bot.Jack.Engine.Nodes
{
    public class HelloJackEngineNode : JackEngineNode
    {
        public const string HasSaidHelloKey = "HelloNode.HasSaidHello";

        public override string HandleRequest(LuisResult result, JackEngineDataNode nodeData, JackEngineData globalData)
        {
            bool hasSaidHello = HasSaidHello(globalData);
            var message = new StringBuilder();
            message.Append("Why hello!");
            message.Append(hasSaidHello
                ? " Although, we've met before, so why are you saying 'hi!' to me again?"
                : " I'm Jack! Your friendly neighborhood robot.");
            HasSaidHello(globalData, true);
            return message.ToString();
        }

        public static void HasSaidHello(JackEngineData globalData, bool saidHello)
        {
            globalData.SetValue(HasSaidHelloKey, saidHello);
        }

        public static bool HasSaidHello(JackEngineData globalData)
        {
            return globalData.GetBoolean(HasSaidHelloKey, false);
        }
        
    }
}