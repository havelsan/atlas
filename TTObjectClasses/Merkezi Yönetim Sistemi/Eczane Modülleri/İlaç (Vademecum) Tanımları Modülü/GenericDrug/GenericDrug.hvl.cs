
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="GenericDrug")] 

    /// <summary>
    /// İlaç Jeneriği
    /// </summary>
    public  partial class GenericDrug : TerminologyManagerDef
    {
        public class GenericDrugList : TTObjectCollection<GenericDrug> { }
                    
        public class ChildGenericDrugCollection : TTObject.TTChildObjectCollection<GenericDrug>
        {
            public ChildGenericDrugCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildGenericDrugCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetGenericDrugListRQ_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GENERICDRUG"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Name_Shadow
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME_SHADOW"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GENERICDRUG"].AllPropertyDefs["NAME_SHADOW"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetGenericDrugListRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetGenericDrugListRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetGenericDrugListRQ_Class() : base() { }
        }

        public static BindingList<GenericDrug> GetGenericDrugBySPTSGenericDrugID(TTObjectContext objectContext, long GENERICDRUGID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["GENERICDRUG"].QueryDefs["GetGenericDrugBySPTSGenericDrugID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("GENERICDRUGID", GENERICDRUGID);

            return ((ITTQuery)objectContext).QueryObjects<GenericDrug>(queryDef, paramList);
        }

        public static BindingList<GenericDrug> GetGenericDrugbyLastupdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["GENERICDRUG"].QueryDefs["GetGenericDrugbyLastupdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<GenericDrug>(queryDef, paramList);
        }

        public static BindingList<GenericDrug.GetGenericDrugListRQ_Class> GetGenericDrugListRQ(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["GENERICDRUG"].QueryDefs["GetGenericDrugListRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<GenericDrug.GetGenericDrugListRQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<GenericDrug.GetGenericDrugListRQ_Class> GetGenericDrugListRQ(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["GENERICDRUG"].QueryDefs["GetGenericDrugListRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<GenericDrug.GetGenericDrugListRQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Jenerik İlaç Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Hızlı Referans
    /// </summary>
        public string QREF
        {
            get { return (string)this["QREF"]; }
            set { this["QREF"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

        public long? SPTSGenericDrugID
        {
            get { return (long?)this["SPTSGENERICDRUGID"]; }
            set { this["SPTSGENERICDRUGID"] = value; }
        }

        public long? VademecumID
        {
            get { return (long?)this["VADEMECUMID"]; }
            set { this["VADEMECUMID"] = value; }
        }

        protected GenericDrug(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected GenericDrug(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected GenericDrug(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected GenericDrug(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected GenericDrug(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "GENERICDRUG", dataRow) { }
        protected GenericDrug(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "GENERICDRUG", dataRow, isImported) { }
        public GenericDrug(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public GenericDrug(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public GenericDrug() : base() { }

    }
}