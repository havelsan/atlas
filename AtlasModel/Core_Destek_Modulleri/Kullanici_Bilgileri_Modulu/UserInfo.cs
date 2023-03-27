using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class UserInfo
    {
        public Guid ObjectId { get; set; }
        public string UserName { get; set; }
        public string Ping { get; set; }
        public string ChromeVersion { get; set; }
        public string SoftwareVersion { get; set; }
        public string CPU { get; set; }
        public string RAM { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public string ServerTime { get; set; }
        public string JSTime { get; set; }
        public string IP { get; set; }
        public int? PingCount { get; set; }
        public Guid? UserRef { get; set; }

        #region Parent Relations
        public virtual ResUser User { get; set; }
        #endregion Parent Relations
    }
}