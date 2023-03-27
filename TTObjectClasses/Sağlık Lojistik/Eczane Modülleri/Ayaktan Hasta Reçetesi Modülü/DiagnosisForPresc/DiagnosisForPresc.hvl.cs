
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DiagnosisForPresc")] 

    /// <summary>
    /// Hasta Tanıları Sekmesi
    /// </summary>
    public  partial class DiagnosisForPresc : TTObject
    {
        public class DiagnosisForPrescList : TTObjectCollection<DiagnosisForPresc> { }
                    
        public class ChildDiagnosisForPrescCollection : TTObject.TTChildObjectCollection<DiagnosisForPresc>
        {
            public ChildDiagnosisForPrescCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDiagnosisForPrescCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetDiagosisForPrescription_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISFORPRESC"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISFORPRESC"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetDiagosisForPrescription_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDiagosisForPrescription_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDiagosisForPrescription_Class() : base() { }
        }

        public static BindingList<DiagnosisForPresc.GetDiagosisForPrescription_Class> GetDiagosisForPrescription(Guid PRESOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISFORPRESC"].QueryDefs["GetDiagosisForPrescription"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PRESOBJECTID", PRESOBJECTID);

            return TTReportNqlObject.QueryObjects<DiagnosisForPresc.GetDiagosisForPrescription_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DiagnosisForPresc.GetDiagosisForPrescription_Class> GetDiagosisForPrescription(TTObjectContext objectContext, Guid PRESOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISFORPRESC"].QueryDefs["GetDiagosisForPrescription"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PRESOBJECTID", PRESOBJECTID);

            return TTReportNqlObject.QueryObjects<DiagnosisForPresc.GetDiagosisForPrescription_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Kodu
    /// </summary>
        public string Code
        {
            get { return (string)this["CODE"]; }
            set { this["CODE"] = value; }
        }

    /// <summary>
    /// Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Seç
    /// </summary>
        public bool? Check
        {
            get { return (bool?)this["CHECK"]; }
            set { this["CHECK"] = value; }
        }

        public Prescription Prescription
        {
            get { return (Prescription)((ITTObject)this).GetParent("PRESCRIPTION"); }
            set { this["PRESCRIPTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DrugOrderIntroduction DrugOrderIntroduction
        {
            get { return (DrugOrderIntroduction)((ITTObject)this).GetParent("DRUGORDERINTRODUCTION"); }
            set { this["DRUGORDERINTRODUCTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DiagnosisForPresc(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DiagnosisForPresc(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DiagnosisForPresc(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DiagnosisForPresc(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DiagnosisForPresc(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DIAGNOSISFORPRESC", dataRow) { }
        protected DiagnosisForPresc(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DIAGNOSISFORPRESC", dataRow, isImported) { }
        public DiagnosisForPresc(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DiagnosisForPresc(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DiagnosisForPresc() : base() { }

    }
}