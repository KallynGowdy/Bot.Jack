using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bot.Jack.Engine
{
    /// <summary>
    /// Defines a piece of data that Jack stores about nodes.
    /// </summary>
    [Serializable]
    public class JackEngineDataNode : DictionaryDataStore
    {
        public Dictionary<string, object> LocalData => Data;
    }
}