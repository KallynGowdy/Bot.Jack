using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Bot.Builder.Luis.Models;

namespace Bot.Jack.Engine
{
    public abstract class JackEngineNode
    {
        public virtual string GetNodeKey() => this.GetType().FullName;

        public abstract string HandleRequest(LuisResult result, JackEngineDataNode nodeData, JackEngineData globalData);
    }
}