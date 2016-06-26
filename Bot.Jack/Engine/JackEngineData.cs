using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bot.Jack.Engine
{
    /// <summary>
    /// Defines a serializable group of data that Jack has obtained over the conversation.
    /// </summary>
    [Serializable]
    public class JackEngineData : DictionaryDataStore
    {
        /// <summary>
        /// Gets the node data for the conversation.
        /// </summary>
        public Dictionary<string, JackEngineDataNode> NodeData { get; set; } = new Dictionary<string, JackEngineDataNode>();

        /// <summary>
        /// Gets the map of global conversation data.
        /// </summary>
        public Dictionary<string, object> GlobalData => Data;
    }
}