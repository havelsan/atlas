using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class SKRSSistemKodlari
    {
        public Guid ObjectId { get; set; }
        public string SKRSGuid { get; set; }
        public string Adi { get; set; }
        public string SqlFilter { get; set; }
        public string AKTIF { get; set; }
    }
}