using System;
using System.Text;
using Microsoft.Bot.Builder.Luis.Models;

namespace Bot.Jack.Engine.Nodes
{
    public class NameJackEngineNode : JackEngineNode
    {
        public override string HandleRequest(LuisResult result, JackEngineDataNode nodeData, JackEngineData globalData)
        {
            var message = new StringBuilder();
            message.Append("My name is Jack");
            var knowsName = HelloJackEngineNode.HasSaidHello(globalData);
            message.Append(knowsName ? ", but you already know my name, don't you?" : ".");
            HelloJackEngineNode.HasSaidHello(globalData, true);
            return message.ToString();
        }
    }
}