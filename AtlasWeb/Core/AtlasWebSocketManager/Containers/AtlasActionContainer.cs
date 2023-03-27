using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.AtlasWebSocketManager.Containers
{
    public class AtlasActionContainer : AtlasWebSocketContainer, I_AtlasWebSocketContainer
    {
        public AtlasActionType actionType { get; set; }
        public bool isExecuted { get; set; }
        public string actionDefinition { get; set; }
        public string actionMethod { get; set; }

        public AtlasActionContainer() : base()
        {

        }

    }
}
