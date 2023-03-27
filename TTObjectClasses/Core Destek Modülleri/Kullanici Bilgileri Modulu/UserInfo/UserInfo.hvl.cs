
using System;
using System.Xml;
using System.Data;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

using TTUtils;
using TTObjectClasses;
using TTDataDictionary;
using TTCoreDefinitions;
using TTConnectionManager;
using TTInstanceManagement;
using TTDefinitionManagement;
using TTStorageManager.Security;

using TTStorageManager;
using System.Runtime.Versioning;
namespace TTObjectClasses
{
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="UserInfo")] 

    public  partial class UserInfo : TTObject
    {
        public class UserInfoList : TTObjectCollection<UserInfo> { }
                    
        public class ChildUserInfoCollection : TTObject.TTChildObjectCollection<UserInfo>
        {
            public ChildUserInfoCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildUserInfoCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public string UserName
        {
            get { return (string)this["USERNAME"]; }
            set { this["USERNAME"] = value; }
        }

        public string Ping
        {
            get { return (string)this["PING"]; }
            set { this["PING"] = value; }
        }

        public string ChromeVersion
        {
            get { return (string)this["CHROMEVERSION"]; }
            set { this["CHROMEVERSION"] = value; }
        }

        public string SoftwareVersion
        {
            get { return (string)this["SOFTWAREVERSION"]; }
            set { this["SOFTWAREVERSION"] = value; }
        }

        public string CPU
        {
            get { return (string)this["CPU"]; }
            set { this["CPU"] = value; }
        }

        public string RAM
        {
            get { return (string)this["RAM"]; }
            set { this["RAM"] = value; }
        }

        public string Width
        {
            get { return (string)this["WIDTH"]; }
            set { this["WIDTH"] = value; }
        }

        public string Height
        {
            get { return (string)this["HEIGHT"]; }
            set { this["HEIGHT"] = value; }
        }

        public string ServerTime
        {
            get { return (string)this["SERVERTIME"]; }
            set { this["SERVERTIME"] = value; }
        }

        public string JSTime
        {
            get { return (string)this["JSTIME"]; }
            set { this["JSTIME"] = value; }
        }

        public string IP
        {
            get { return (string)this["IP"]; }
            set { this["IP"] = value; }
        }

        public int? PingCount
        {
            get { return (int?)this["PINGCOUNT"]; }
            set { this["PINGCOUNT"] = value; }
        }

        public ResUser User
        {
            get { return (ResUser)((ITTObject)this).GetParent("USER"); }
            set { this["USER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected UserInfo(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected UserInfo(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected UserInfo(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected UserInfo(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected UserInfo(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "USERINFO", dataRow) { }
        protected UserInfo(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "USERINFO", dataRow, isImported) { }
        public UserInfo(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public UserInfo(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public UserInfo() : base() { }

    }
}