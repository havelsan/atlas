
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ServiceLogInfo")] 

    public  partial class ServiceLogInfo : TTObject
    {
        public class ServiceLogInfoList : TTObjectCollection<ServiceLogInfo> { }
                    
        public class ChildServiceLogInfoCollection : TTObject.TTChildObjectCollection<ServiceLogInfo>
        {
            public ChildServiceLogInfoCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildServiceLogInfoCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public Guid? LOGID
        {
            get { return (Guid?)this["LOGID"]; }
            set { this["LOGID"] = value; }
        }

        public string StatusCode
        {
            get { return (string)this["STATUSCODE"]; }
            set { this["STATUSCODE"] = value; }
        }

        public string RequestPath
        {
            get { return (string)this["REQUESTPATH"]; }
            set { this["REQUESTPATH"] = value; }
        }

        public DateTime? CallDate
        {
            get { return (DateTime?)this["CALLDATE"]; }
            set { this["CALLDATE"] = value; }
        }

        public string WorkstationIp
        {
            get { return (string)this["WORKSTATIONIP"]; }
            set { this["WORKSTATIONIP"] = value; }
        }

        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

        public Guid? UserID
        {
            get { return (Guid?)this["USERID"]; }
            set { this["USERID"] = value; }
        }

        public ServiceLogTypeEnum? LogType
        {
            get { return (ServiceLogTypeEnum?)(int?)this["LOGTYPE"]; }
            set { this["LOGTYPE"] = value; }
        }

        protected ServiceLogInfo(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ServiceLogInfo(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ServiceLogInfo(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ServiceLogInfo(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ServiceLogInfo(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SERVICELOGINFO", dataRow) { }
        protected ServiceLogInfo(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SERVICELOGINFO", dataRow, isImported) { }
        public ServiceLogInfo(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ServiceLogInfo(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ServiceLogInfo() : base() { }

    }
}