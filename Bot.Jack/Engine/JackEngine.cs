using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bot.Jack.Engine.Nodes;
using Microsoft.Bot.Builder.Luis.Models;

namespace Bot.Jack.Engine
{
    /// <summary>
    /// An engine that drives a conversation with Jack.
    /// </summary>
    [Serializable]
    public class JackEngine
    {
        public static readonly IDictionary<string, JackEngineNode> NodeMap = new Dictionary<string, JackEngineNode>()
        {
            {Intents.Default, new DefaultJackEngineNode() },
            {Intents.SayHello, new HelloJackEngineNode() },
            {Intents.SayName, new NameJackEngineNode() }
        };

        /// <summary>
        /// The data that Jack knows.
        /// This stores the conversational and factual information that Jack can recall.
        /// </summary>
        public JackEngineData Data { get; set; } = new JackEngineData();

        /// <summary>
        /// Processes the given intent and message in the engine, updates the data, and returns a response message.
        /// </summary>
        /// <param name="intent">The intent that should be handled.</param>
        /// <param name="result">The processed LUIS data.</param>
        /// <returns></returns>
        public string ProcessIntent(string intent, LuisResult result)
        {
            var node = GetNodeForIntent(intent) ?? NodeMap[Intents.Default];
            return UseNode(node, result);
        }

        private string UseNode(JackEngineNode node, LuisResult result)
        {
            var nodeData = GetNodeData(node);
            var message = node.HandleRequest(result, nodeData, Data);
            SaveNodeData(node, nodeData);
            return message;
        }

        private JackEngineDataNode GetNodeData(JackEngineNode node)
        {
            var key = node.GetNodeKey();
            JackEngineDataNode nodeData = null;
            if (Data.NodeData.ContainsKey(key))
            {
                nodeData = Data.NodeData[key];
            }
            return nodeData ?? new JackEngineDataNode();
        }

        private void SaveNodeData(JackEngineNode node, JackEngineDataNode data)
        {
            var key = node.GetNodeKey();
            if (Data.NodeData.ContainsKey(key))
            {
                Data.NodeData[key] = data;
            }
            else
            {
                Data.NodeData.Add(key, data);
            }
        }

        private JackEngineNode GetNodeForIntent(string intent)
        {
            if (NodeMap.ContainsKey(intent))
            {
                return NodeMap[intent];
            }
            else
            {
                return null;
            }
        }
    }
}