using System;
using Microsoft.Bot.Builder.Luis.Models;

namespace Bot.Jack.Engine.Nodes
{
    public class DefaultJackEngineNode : JackEngineNode
    {
        public override string HandleRequest(LuisResult result, JackEngineDataNode nodeData, JackEngineData globalData)
        {
            return "Sorry, but I don't understand";
        }
    }
}