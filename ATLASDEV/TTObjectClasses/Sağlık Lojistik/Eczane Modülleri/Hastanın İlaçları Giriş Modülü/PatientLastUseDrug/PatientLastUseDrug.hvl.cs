
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PatientLastUseDrug")] 

    public  partial class PatientLastUseDrug : TTObject
    {
        public class PatientLastUseDrugList : TTObjectCollection<PatientLastUseDrug> { }
                    
        public class ChildPatientLastUseDrugCollection : TTObject.TTChildObjectCollection<PatientLastUseDrug>
        {
            public ChildPatientLastUseDrugCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPatientLastUseDrugCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetPatientLastUseDrugs_Class : TTReportNqlObject 
        {
            public string Drugname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DRUGNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTLASTUSEDRUG"].AllPropertyDefs["AMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public GetPatientLastUseDrugs_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPatientLastUseDrugs_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPatientLastUseDrugs_Class() : base() { }
        }

        public static BindingList<PatientLastUseDrug.GetPatientLastUseDrugs_Class> GetPatientLastUseDrugs(Guid SUBEPISODEID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTLASTUSEDRUG"].QueryDefs["GetPatientLastUseDrugs"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODEID", SUBEPISODEID);

            return TTReportNqlObject.QueryObjects<PatientLastUseDrug.GetPatientLastUseDrugs_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PatientLastUseDrug.GetPatientLastUseDrugs_Class> GetPatientLastUseDrugs(TTObjectContext objectContext, Guid SUBEPISODEID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTLASTUSEDRUG"].QueryDefs["GetPatientLastUseDrugs"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODEID", SUBEPISODEID);

            return TTReportNqlObject.QueryObjects<PatientLastUseDrug.GetPatientLastUseDrugs_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Miktar
    /// </summary>
        public double? Amount
        {
            get { return (double?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

    /// <summary>
    /// İlaç
    /// </summary>
        public Material Material
        {
            get { return (Material)((ITTObject)this).GetParent("MATERIAL"); }
            set { this["MATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PatientOwnDrugEntry PatientOwnDrugEntry
        {
            get { return (PatientOwnDrugEntry)((ITTObject)this).GetParent("PATIENTOWNDRUGENTRY"); }
            set { this["PATIENTOWNDRUGENTRY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PatientLastUseDrug(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PatientLastUseDrug(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PatientLastUseDrug(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PatientLastUseDrug(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PatientLastUseDrug(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PATIENTLASTUSEDRUG", dataRow) { }
        protected PatientLastUseDrug(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PATIENTLASTUSEDRUG", dataRow, isImported) { }
        public PatientLastUseDrug(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PatientLastUseDrug(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PatientLastUseDrug() : base() { }

    }
}