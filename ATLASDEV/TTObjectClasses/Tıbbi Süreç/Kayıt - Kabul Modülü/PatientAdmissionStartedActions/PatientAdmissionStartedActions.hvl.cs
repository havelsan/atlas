
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PatientAdmissionStartedActions")] 

    /// <summary>
    /// Hasta kabul esnasında başlatılacak işlem/hizmetler
    /// </summary>
    public  partial class PatientAdmissionStartedActions : TerminologyManagerDef
    {
        public class PatientAdmissionStartedActionsList : TTObjectCollection<PatientAdmissionStartedActions> { }
                    
        public class ChildPatientAdmissionStartedActionsCollection : TTObject.TTChildObjectCollection<PatientAdmissionStartedActions>
        {
            public ChildPatientAdmissionStartedActionsCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPatientAdmissionStartedActionsCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetPAStartedActionsDefinition_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public AdmissionStatusEnum? AdmissionStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADMISSIONSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSIONSTARTEDACTIONS"].AllPropertyDefs["ADMISSIONSTATUS"].DataType;
                    return (AdmissionStatusEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GetPAStartedActionsDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPAStartedActionsDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPAStartedActionsDefinition_Class() : base() { }
        }

        public static BindingList<PatientAdmissionStartedActions> GetByAdmissionStatus(TTObjectContext objectContext, AdmissionStatusEnum ADMISSIONSTATUS, Guid PARESOURCE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSIONSTARTEDACTIONS"].QueryDefs["GetByAdmissionStatus"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ADMISSIONSTATUS", (int)ADMISSIONSTATUS);
            paramList.Add("PARESOURCE", PARESOURCE);

            return ((ITTQuery)objectContext).QueryObjects<PatientAdmissionStartedActions>(queryDef, paramList);
        }

        public static BindingList<PatientAdmissionStartedActions> GetByDeathAdmissionStatus(TTObjectContext objectContext, AdmissionStatusEnum ADMISSIONSTATUS)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSIONSTARTEDACTIONS"].QueryDefs["GetByDeathAdmissionStatus"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ADMISSIONSTATUS", (int)ADMISSIONSTATUS);

            return ((ITTQuery)objectContext).QueryObjects<PatientAdmissionStartedActions>(queryDef, paramList);
        }

        public static BindingList<PatientAdmissionStartedActions.GetPAStartedActionsDefinition_Class> GetPAStartedActionsDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSIONSTARTEDACTIONS"].QueryDefs["GetPAStartedActionsDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PatientAdmissionStartedActions.GetPAStartedActionsDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PatientAdmissionStartedActions.GetPAStartedActionsDefinition_Class> GetPAStartedActionsDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSIONSTARTEDACTIONS"].QueryDefs["GetPAStartedActionsDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PatientAdmissionStartedActions.GetPAStartedActionsDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PatientAdmissionStartedActions> GetPAStartedActions(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSIONSTARTEDACTIONS"].QueryDefs["GetPAStartedActions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<PatientAdmissionStartedActions>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<PatientAdmissionStartedActions> GetStartedActionByStatus(TTObjectContext objectContext, AdmissionStatusEnum ADMISSIONSTATUS)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSIONSTARTEDACTIONS"].QueryDefs["GetStartedActionByStatus"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ADMISSIONSTATUS", (int)ADMISSIONSTATUS);

            return ((ITTQuery)objectContext).QueryObjects<PatientAdmissionStartedActions>(queryDef, paramList);
        }

    /// <summary>
    /// Başlatılacak İşlem Tipi(Varsayılan)
    /// </summary>
        public ActionTypeEnum? DefaultActionType
        {
            get { return (ActionTypeEnum?)(int?)this["DEFAULTACTIONTYPE"]; }
            set { this["DEFAULTACTIONTYPE"] = value; }
        }

    /// <summary>
    /// Kabul tipi
    /// </summary>
        public AdmissionStatusEnum? AdmissionStatus
        {
            get { return (AdmissionStatusEnum?)(int?)this["ADMISSIONSTATUS"]; }
            set { this["ADMISSIONSTATUS"] = value; }
        }

        public SKRSVakaTuru SKRSVakaTuru
        {
            get { return (SKRSVakaTuru)((ITTObject)this).GetParent("SKRSVAKATURU"); }
            set { this["SKRSVAKATURU"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreatePAActionTypeObjectCollection()
        {
            _PAActionTypeObject = new PAActionTypeObject.ChildPAActionTypeObjectCollection(this, new Guid("b62b8e9d-c212-4836-9bbb-411c71165ed1"));
            ((ITTChildObjectCollection)_PAActionTypeObject).GetChildren();
        }

        protected PAActionTypeObject.ChildPAActionTypeObjectCollection _PAActionTypeObject = null;
        public PAActionTypeObject.ChildPAActionTypeObjectCollection PAActionTypeObject
        {
            get
            {
                if (_PAActionTypeObject == null)
                    CreatePAActionTypeObjectCollection();
                return _PAActionTypeObject;
            }
        }

        virtual protected void CreatePAProcedureObjectCollection()
        {
            _PAProcedureObject = new PAProcedureObject.ChildPAProcedureObjectCollection(this, new Guid("e464dc76-9c4f-4831-97b1-c54c1bb3365e"));
            ((ITTChildObjectCollection)_PAProcedureObject).GetChildren();
        }

        protected PAProcedureObject.ChildPAProcedureObjectCollection _PAProcedureObject = null;
        public PAProcedureObject.ChildPAProcedureObjectCollection PAProcedureObject
        {
            get
            {
                if (_PAProcedureObject == null)
                    CreatePAProcedureObjectCollection();
                return _PAProcedureObject;
            }
        }

        protected PatientAdmissionStartedActions(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PatientAdmissionStartedActions(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PatientAdmissionStartedActions(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PatientAdmissionStartedActions(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PatientAdmissionStartedActions(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PATIENTADMISSIONSTARTEDACTIONS", dataRow) { }
        protected PatientAdmissionStartedActions(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PATIENTADMISSIONSTARTEDACTIONS", dataRow, isImported) { }
        public PatientAdmissionStartedActions(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PatientAdmissionStartedActions(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PatientAdmissionStartedActions() : base() { }

    }
}