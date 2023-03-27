
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MuayeneGiris")] 

    public  partial class MuayeneGiris : BaseMedulaAction
    {
        public class MuayeneGirisList : TTObjectCollection<MuayeneGiris> { }
                    
        public class ChildMuayeneGirisCollection : TTObject.TTChildObjectCollection<MuayeneGiris>
        {
            public ChildMuayeneGirisCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMuayeneGirisCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class MUAYENEBILGILERIReportQuery_Class : TTReportNqlObject 
        {
            public Guid? Muayenegirisobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MUAYENEGIRISOBJECTID"]);
                }
            }

            public int? HealthFacilityID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HEALTHFACILITYID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MUAYENEGIRIS"].AllPropertyDefs["HEALTHFACILITYID"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public long? MedulaActionID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULAACTIONID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MUAYENEGIRIS"].AllPropertyDefs["MEDULAACTIONID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? WorkListDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKLISTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MUAYENEGIRIS"].AllPropertyDefs["WORKLISTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string hastaTCKimlikNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASTATCKIMLIKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MUAYENEGIRISDVO"].AllPropertyDefs["HASTATCKIMLIKNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string muayeneTarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MUAYENETARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MUAYENEGIRISDVO"].AllPropertyDefs["MUAYENETARIHI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? referansNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REFERANSNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MUAYENEGIRISDVO"].AllPropertyDefs["REFERANSNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public bool? gizliTutulsunmu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GIZLITUTULSUNMU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MUAYENEGIRISDVO"].AllPropertyDefs["GIZLITUTULSUNMU"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string sonucKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SONUCKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MUAYENEGIRISCEVAPDVO"].AllPropertyDefs["SONUCKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string sonucMesaji
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SONUCMESAJI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MUAYENEGIRISCEVAPDVO"].AllPropertyDefs["SONUCMESAJI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public MUAYENEBILGILERIReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public MUAYENEBILGILERIReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected MUAYENEBILGILERIReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMuayeneGirisWillBeSentToMedulaRQ_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetMuayeneGirisWillBeSentToMedulaRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMuayeneGirisWillBeSentToMedulaRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMuayeneGirisWillBeSentToMedulaRQ_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMuayeneGirisReportQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string hastaTCKimlikNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASTATCKIMLIKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MUAYENEGIRISDVO"].AllPropertyDefs["HASTATCKIMLIKNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string muayeneTarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MUAYENETARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MUAYENEGIRISDVO"].AllPropertyDefs["MUAYENETARIHI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? referansNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REFERANSNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MUAYENEGIRISDVO"].AllPropertyDefs["REFERANSNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public GetMuayeneGirisReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMuayeneGirisReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMuayeneGirisReportQuery_Class() : base() { }
        }

        new public static class States
        {
            public static Guid Cancelled { get { return new Guid("377cec90-a6e4-4060-88c7-30fe1a96a9a3"); } }
            public static Guid CompletedSuccessfully { get { return new Guid("6c9d4ab2-e312-40fd-9160-04fcc00ab96d"); } }
            public static Guid CompletedUnsuccessfully { get { return new Guid("7f7f8abc-1db3-40dc-8224-329941c975a0"); } }
            public static Guid New { get { return new Guid("43b0e87d-7738-4c04-8088-8ae13b0e33fc"); } }
            public static Guid SentMedula { get { return new Guid("c7d6ba89-65ad-4eb5-a567-1a4ff2059313"); } }
            public static Guid SentServer { get { return new Guid("6e8b9cae-441d-46ef-829f-38b2d7b4b4ab"); } }
        }

        public static BindingList<MuayeneGiris.MUAYENEBILGILERIReportQuery_Class> MUAYENEBILGILERIReportQuery(int HEALTHFACILITYID, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MUAYENEGIRIS"].QueryDefs["MUAYENEBILGILERIReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<MuayeneGiris.MUAYENEBILGILERIReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<MuayeneGiris.MUAYENEBILGILERIReportQuery_Class> MUAYENEBILGILERIReportQuery(TTObjectContext objectContext, int HEALTHFACILITYID, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MUAYENEGIRIS"].QueryDefs["MUAYENEBILGILERIReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<MuayeneGiris.MUAYENEBILGILERIReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<MuayeneGiris.GetMuayeneGirisWillBeSentToMedulaRQ_Class> GetMuayeneGirisWillBeSentToMedulaRQ(int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MUAYENEGIRIS"].QueryDefs["GetMuayeneGirisWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<MuayeneGiris.GetMuayeneGirisWillBeSentToMedulaRQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MuayeneGiris.GetMuayeneGirisWillBeSentToMedulaRQ_Class> GetMuayeneGirisWillBeSentToMedulaRQ(TTObjectContext objectContext, int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MUAYENEGIRIS"].QueryDefs["GetMuayeneGirisWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<MuayeneGiris.GetMuayeneGirisWillBeSentToMedulaRQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MuayeneGiris.GetMuayeneGirisReportQuery_Class> GetMuayeneGirisReportQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MUAYENEGIRIS"].QueryDefs["GetMuayeneGirisReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MuayeneGiris.GetMuayeneGirisReportQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MuayeneGiris.GetMuayeneGirisReportQuery_Class> GetMuayeneGirisReportQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MUAYENEGIRIS"].QueryDefs["GetMuayeneGirisReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MuayeneGiris.GetMuayeneGirisReportQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public MuayeneGirisDVO muayeneGirisDVO
        {
            get { return (MuayeneGirisDVO)((ITTObject)this).GetParent("MUAYENEGIRISDVO"); }
            set { this["MUAYENEGIRISDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreatePatientExaminationCollection()
        {
            _PatientExamination = new PatientExamination.ChildPatientExaminationCollection(this, new Guid("bcb1fe44-ecb6-4605-84ef-4994bec3f568"));
            ((ITTChildObjectCollection)_PatientExamination).GetChildren();
        }

        protected PatientExamination.ChildPatientExaminationCollection _PatientExamination = null;
        public PatientExamination.ChildPatientExaminationCollection PatientExamination
        {
            get
            {
                if (_PatientExamination == null)
                    CreatePatientExaminationCollection();
                return _PatientExamination;
            }
        }

        virtual protected void CreatemuayeneBilgisiSillerCollection()
        {
            _muayeneBilgisiSiller = new MuayeneBilgisiSil.ChildMuayeneBilgisiSilCollection(this, new Guid("bf5bff08-0d88-4fdd-940e-22cd23efc345"));
            ((ITTChildObjectCollection)_muayeneBilgisiSiller).GetChildren();
        }

        protected MuayeneBilgisiSil.ChildMuayeneBilgisiSilCollection _muayeneBilgisiSiller = null;
        public MuayeneBilgisiSil.ChildMuayeneBilgisiSilCollection muayeneBilgisiSiller
        {
            get
            {
                if (_muayeneBilgisiSiller == null)
                    CreatemuayeneBilgisiSillerCollection();
                return _muayeneBilgisiSiller;
            }
        }

        virtual protected void CreateEmergencyInterventionCollection()
        {
            _EmergencyIntervention = new EmergencyIntervention.ChildEmergencyInterventionCollection(this, new Guid("1bdc123d-a2d7-44eb-9b3e-17fa19934e38"));
            ((ITTChildObjectCollection)_EmergencyIntervention).GetChildren();
        }

        protected EmergencyIntervention.ChildEmergencyInterventionCollection _EmergencyIntervention = null;
        public EmergencyIntervention.ChildEmergencyInterventionCollection EmergencyIntervention
        {
            get
            {
                if (_EmergencyIntervention == null)
                    CreateEmergencyInterventionCollection();
                return _EmergencyIntervention;
            }
        }

        protected MuayeneGiris(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MuayeneGiris(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MuayeneGiris(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MuayeneGiris(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MuayeneGiris(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MUAYENEGIRIS", dataRow) { }
        protected MuayeneGiris(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MUAYENEGIRIS", dataRow, isImported) { }
        public MuayeneGiris(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MuayeneGiris(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MuayeneGiris() : base() { }

        override protected void RunPreTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePreScript(transDef))
                base.RunPreTransition(transDef.BaseTransDef);
            this.PreTransition(transDef);
        }
        override protected void RunPostTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePostScript(transDef))
                base.RunPostTransition(transDef.BaseTransDef);
            this.PostTransition(transDef);
        }
        override protected void RunUndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBaseUndoScript(transDef))
                base.RunUndoTransition(transDef.BaseTransDef);
            this.UndoTransition(transDef);
        }
    }
}