using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class FileCreationAndAnalysis
    {
        public Guid ObjectId { get; set; }
        public bool? InIncompleteArea { get; set; }
        public bool? InArchive { get; set; }
        public string OnlyYear { get; set; }
        public bool? HMHASTAYAKINI { get; set; }
        public string Room { get; set; }
        public bool? AdliVaka { get; set; }
        public bool? HMHEMSHIZ { get; set; }
        public bool? HMHASTYAKFORM { get; set; }
        public bool? HMHEMSBAKPL { get; set; }
        public bool? HMSIVIZFORM { get; set; }
        public bool? HMDIGER { get; set; }
        public string HMACIKLAMA { get; set; }
        public bool? HKMESANFORM { get; set; }
        public bool? HKGUNMUSKAG { get; set; }
        public bool? HKANESTEZI { get; set; }
        public bool? HKONAM { get; set; }
        public bool? HKCERTARONFORM { get; set; }
        public bool? HKTABHASTBIL { get; set; }
        public bool? HKSAGKURRAP { get; set; }
        public bool? HKEPIKRIZ { get; set; }
        public bool? HKHASTTAB { get; set; }
        public bool? HKDUSRISOL { get; set; }
        public bool? HKGUCCERKONT { get; set; }
        public bool? HKDIGER { get; set; }
        public string HKACIKLAMA { get; set; }
        public bool? SEKHASGIRKAG { get; set; }
        public string SEKACIKLAMA { get; set; }
        public bool? HMHEMGOZFORM { get; set; }
        public Guid? FileLocationRef { get; set; }

        #region Base Object Navigation Property
        public virtual EpisodeAction EpisodeAction { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual ResSection FileLocation { get; set; }
        #endregion Parent Relations
    }
}