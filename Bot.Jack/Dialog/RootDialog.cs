using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Bot.Jack.Engine;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;

namespace Bot.Jack.Dialog
{
    [LuisModel("e1c105a9-59f4-4a54-a58f-fe4bc25f2bc3", "18469b78dc774c8cb95b5544773ef58d")]
    [Serializable]
    public class RootDialog : LuisDialog<object>
    {
        private JackEngine engine;

        public JackEngine Engine
        {
            get { return engine ?? (engine = new JackEngine()); }
            set { engine = value; }
        }

        private async Task ProcessIntent(string intent, IDialogContext context, LuisResult result)
        {
            var message = Engine.ProcessIntent(intent, result);
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent(Intents.Default)]
        public async Task None(IDialogContext context, LuisResult result)
        {
            await ProcessIntent(Intents.Default, context, result);
        }

        [LuisIntent(Intents.SayHello)]
        public async Task SayHello(IDialogContext context, LuisResult result)
        {
            await ProcessIntent(Intents.SayHello, context, result);
        }

        [LuisIntent(Intents.SayName)]
        public async Task SayName(IDialogContext context, LuisResult result)
        {
            await ProcessIntent(Intents.SayName, context, result);
        }
    }
}