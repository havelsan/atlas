
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SendDoctorPerformanceLog")] 

    /// <summary>
    /// Doktor Performans Log
    /// </summary>
    public  partial class SendDoctorPerformanceLog : TTObject
    {
        public class SendDoctorPerformanceLogList : TTObjectCollection<SendDoctorPerformanceLog> { }
                    
        public class ChildSendDoctorPerformanceLogCollection : TTObject.TTChildObjectCollection<SendDoctorPerformanceLog>
        {
            public ChildSendDoctorPerformanceLogCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSendDoctorPerformanceLogCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Log Tarihi
    /// </summary>
        public DateTime? LogDate
        {
            get { return (DateTime?)this["LOGDATE"]; }
            set { this["LOGDATE"] = value; }
        }

    /// <summary>
    /// LOG
    /// </summary>
        public string Log
        {
            get { return (string)this["LOG"]; }
            set { this["LOG"] = value; }
        }

    /// <summary>
    /// Mettot Adı
    /// </summary>
        public string MethodName
        {
            get { return (string)this["METHODNAME"]; }
            set { this["METHODNAME"] = value; }
        }

    /// <summary>
    /// Log enum tipi
    /// </summary>
        public DPDetailedErrorTypes? LogType
        {
            get { return (DPDetailedErrorTypes?)(int?)this["LOGTYPE"]; }
            set { this["LOGTYPE"] = value; }
        }

        public SendToDoctorPerformance SendToDoctorPerformance
        {
            get { return (SendToDoctorPerformance)((ITTObject)this).GetParent("SENDTODOCTORPERFORMANCE"); }
            set { this["SENDTODOCTORPERFORMANCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected SendDoctorPerformanceLog(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SendDoctorPerformanceLog(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SendDoctorPerformanceLog(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SendDoctorPerformanceLog(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SendDoctorPerformanceLog(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SENDDOCTORPERFORMANCELOG", dataRow) { }
        protected SendDoctorPerformanceLog(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SENDDOCTORPERFORMANCELOG", dataRow, isImported) { }
        public SendDoctorPerformanceLog(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SendDoctorPerformanceLog(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SendDoctorPerformanceLog() : base() { }

    }
}