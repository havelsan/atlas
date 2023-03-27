using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.AtlasWebSocketManager.Containers
{
    interface I_AtlasWebSocketContainer
    {
        List<string> users { get; set; }
        object actionData { get; set; }
        string content { get; set; }
        AtlasContentType contentType { get; set; }
        AtlasSourceType sourceType { get; set; }
        bool dataProcessedSuccessfully { get; set; }
        string status { get; set; }
        string headerDefinition { get; set; }
        string currentTimeStr { get; set; }
        DateTime currentTime { get; set; }
    }

    public class AtlasWebSocketContainer : I_AtlasWebSocketContainer
    {
        public List<string> users { get; set; }
        public object actionData { get; set; }
        public string content { get; set; }
        public AtlasContentType contentType { get; set; }
        public AtlasSourceType sourceType { get; set; }
        public string status { get; set; }
        public bool dataProcessedSuccessfully { get; set; }

        //Notification un eventin turunu belirleyen bir isim (orn : YeniHastaKaydi)
        public string headerDefinition { get; set; }

        public string currentTimeStr { get; set; }
        public DateTime currentTime { get; set; }

        public AtlasWebSocketContainer()
        {
            this.currentTime = DateTime.Now;
            this.currentTimeStr = this.currentTime.ToShortTimeString();
        }
    }


}
