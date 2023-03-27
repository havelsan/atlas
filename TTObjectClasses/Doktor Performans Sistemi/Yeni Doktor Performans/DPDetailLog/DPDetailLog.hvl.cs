
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DPDetailLog")] 

    public  partial class DPDetailLog : TTObject
    {
        public class DPDetailLogList : TTObjectCollection<DPDetailLog> { }
                    
        public class ChildDPDetailLogCollection : TTObject.TTChildObjectCollection<DPDetailLog>
        {
            public ChildDPDetailLogCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDPDetailLogCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<DPDetailLog> GetDetailLogByTermAndDoctor(TTObjectContext objectContext, Guid TERM, Guid DOCTOR)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DPDETAILLOG"].QueryDefs["GetDetailLogByTermAndDoctor"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERM", TERM);
            paramList.Add("DOCTOR", DOCTOR);

            return ((ITTQuery)objectContext).QueryObjects<DPDetailLog>(queryDef, paramList);
        }

    /// <summary>
    /// Sorgulama Tarihi
    /// </summary>
        public DateTime? ExecDate
        {
            get { return (DateTime?)this["EXECDATE"]; }
            set { this["EXECDATE"] = value; }
        }

        public object Log
        {
            get { return (object)this["LOG"]; }
            set { this["LOG"] = value; }
        }

        public int? TotalCalcPoint
        {
            get { return (int?)this["TOTALCALCPOINT"]; }
            set { this["TOTALCALCPOINT"] = value; }
        }

        public DoctorPerformanceTerm Term
        {
            get { return (DoctorPerformanceTerm)((ITTObject)this).GetParent("TERM"); }
            set { this["TERM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResUser Doctor
        {
            get { return (ResUser)((ITTObject)this).GetParent("DOCTOR"); }
            set { this["DOCTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DPDetailLog(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DPDetailLog(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DPDetailLog(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DPDetailLog(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DPDetailLog(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DPDETAILLOG", dataRow) { }
        protected DPDetailLog(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DPDETAILLOG", dataRow, isImported) { }
        public DPDetailLog(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DPDetailLog(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DPDetailLog() : base() { }

    }
}