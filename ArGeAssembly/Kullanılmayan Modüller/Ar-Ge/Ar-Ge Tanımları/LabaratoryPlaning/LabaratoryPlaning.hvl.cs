
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="LabaratoryPlaning")] 

    public  partial class LabaratoryPlaning : TTObject
    {
        public class LabaratoryPlaningList : TTObjectCollection<LabaratoryPlaning> { }
                    
        public class ChildLabaratoryPlaningCollection : TTObject.TTChildObjectCollection<LabaratoryPlaning>
        {
            public ChildLabaratoryPlaningCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildLabaratoryPlaningCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class getLabaratoryPlaning_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public DateTime? ReserveDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESERVEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABARATORYPLANING"].AllPropertyDefs["RESERVEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public int? Period
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PERIOD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABARATORYPLANING"].AllPropertyDefs["PERIOD"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public bool? IsUsed
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISUSED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABARATORYPLANING"].AllPropertyDefs["ISUSED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? LabStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LABSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABARATORYPLANING"].AllPropertyDefs["LABSTATUS"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string StatusComment
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STATUSCOMMENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABARATORYPLANING"].AllPropertyDefs["STATUSCOMMENT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Labname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LABNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABARATORYDEF"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Labobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["LABOBJECTID"]);
                }
            }

            public getLabaratoryPlaning_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public getLabaratoryPlaning_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected getLabaratoryPlaning_Class() : base() { }
        }

        public static BindingList<LabaratoryPlaning.getLabaratoryPlaning_Class> getLabaratoryPlaning(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABARATORYPLANING"].QueryDefs["getLabaratoryPlaning"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<LabaratoryPlaning.getLabaratoryPlaning_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<LabaratoryPlaning.getLabaratoryPlaning_Class> getLabaratoryPlaning(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABARATORYPLANING"].QueryDefs["getLabaratoryPlaning"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<LabaratoryPlaning.getLabaratoryPlaning_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public bool? IsUsed
        {
            get { return (bool?)this["ISUSED"]; }
            set { this["ISUSED"] = value; }
        }

        public bool? LabStatus
        {
            get { return (bool?)this["LABSTATUS"]; }
            set { this["LABSTATUS"] = value; }
        }

        public string StatusComment
        {
            get { return (string)this["STATUSCOMMENT"]; }
            set { this["STATUSCOMMENT"] = value; }
        }

        public DateTime? ReserveDate
        {
            get { return (DateTime?)this["RESERVEDATE"]; }
            set { this["RESERVEDATE"] = value; }
        }

        public int? Period
        {
            get { return (int?)this["PERIOD"]; }
            set { this["PERIOD"] = value; }
        }

        public LabaratoryDef Labaratory
        {
            get { return (LabaratoryDef)((ITTObject)this).GetParent("LABARATORY"); }
            set { this["LABARATORY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreatePlansCollection()
        {
            _Plans = new LabaratoryReservation.ChildLabaratoryReservationCollection(this, new Guid("77835ba1-52eb-49a3-a8dc-4b326f1c883d"));
            ((ITTChildObjectCollection)_Plans).GetChildren();
        }

        protected LabaratoryReservation.ChildLabaratoryReservationCollection _Plans = null;
        public LabaratoryReservation.ChildLabaratoryReservationCollection Plans
        {
            get
            {
                if (_Plans == null)
                    CreatePlansCollection();
                return _Plans;
            }
        }

        protected LabaratoryPlaning(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected LabaratoryPlaning(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected LabaratoryPlaning(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected LabaratoryPlaning(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected LabaratoryPlaning(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "LABARATORYPLANING", dataRow) { }
        protected LabaratoryPlaning(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "LABARATORYPLANING", dataRow, isImported) { }
        public LabaratoryPlaning(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public LabaratoryPlaning(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public LabaratoryPlaning() : base() { }

    }
}