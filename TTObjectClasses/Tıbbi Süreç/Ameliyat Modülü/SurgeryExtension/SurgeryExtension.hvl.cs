
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SurgeryExtension")] 

    public  partial class SurgeryExtension : EpisodeAction, IStockOutCancel, IWorkListEpisodeAction
    {
        public class SurgeryExtensionList : TTObjectCollection<SurgeryExtension> { }
                    
        public class ChildSurgeryExtensionCollection : TTObject.TTChildObjectCollection<SurgeryExtension>
        {
            public ChildSurgeryExtensionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSurgeryExtensionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSurgeryExtensionForWL_Class : TTReportNqlObject 
        {
            public String ObjectDefName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OBJECTDEFNAME"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public Guid? ObjectDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTDEFID"]);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Prioritystatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRIORITYSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRIORITYSTATUSDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? SurgeryStartTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SURGERYSTARTTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERY"].AllPropertyDefs["SURGERYSTARTTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? SurgeryEndTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SURGERYENDTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERY"].AllPropertyDefs["SURGERYENDTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? PlannedSurgeryDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PLANNEDSURGERYDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERY"].AllPropertyDefs["PLANNEDSURGERYDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Object Patientnamesurname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTNAMESURNAME"]);
                }
            }

            public string Kabulno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KABULNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? UniqueRefNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNIQUEREFNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["UNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Object Episodeactionname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["EPISODEACTIONNAME"]);
                }
            }

            public String Statename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STATENAME"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public string Surgerydepartment
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SURGERYDEPARTMENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Inpatientclinic
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INPATIENTCLINIC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Surgeryroom
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SURGERYROOM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSURGERYROOM"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Surgerydesk
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SURGERYDESK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSURGERYDESK"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Operator
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OPERATOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Anesthesist
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ANESTHESIST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Admissiontype
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADMISSIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROVIZYONTIPI"].AllPropertyDefs["PROVIZYONTIPIADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Payername
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Cinsiyet
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CINSIYET"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSCINSIYET"].AllPropertyDefs["ADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? BirthDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIRTHDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["BIRTHDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string FatherName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FATHERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["FATHERNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Telno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TELNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTIDENTITYANDADDRESS"].AllPropertyDefs["MOBILEPHONE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public PatientClassTypeEnum? Hastaturu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASTATURU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].AllPropertyDefs["PATIENTCLASSGROUP"].DataType;
                    return (PatientClassTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public ApplicationReasonEnum? Basvuruturu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BASVURUTURU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].AllPropertyDefs["APPLICATIONREASON"].DataType;
                    return (ApplicationReasonEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Oncelikdurumu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ONCELIKDURUMU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRIORITYSTATUSDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetSurgeryExtensionForWL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSurgeryExtensionForWL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSurgeryExtensionForWL_Class() : base() { }
        }

        public static class States
        {
            public static Guid Application { get { return new Guid("37f51ea0-1869-4a21-a3b0-1a211094bf03"); } }
            public static Guid Completed { get { return new Guid("b6408d31-bd36-4d37-a462-b681f69467a1"); } }
            public static Guid Cancelled { get { return new Guid("dc2233e5-e7c0-42c9-967d-fb7a5301a097"); } }
            public static Guid Rejected { get { return new Guid("c4309480-449a-477a-89b1-5eff89756e07"); } }
        }

        public static BindingList<SurgeryExtension> GetByEpisode(TTObjectContext objectContext, Guid EPISODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERYEXTENSION"].QueryDefs["GetByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return ((ITTQuery)objectContext).QueryObjects<SurgeryExtension>(queryDef, paramList);
        }

        public static BindingList<SurgeryExtension.GetSurgeryExtensionForWL_Class> GetSurgeryExtensionForWL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERYEXTENSION"].QueryDefs["GetSurgeryExtensionForWL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SurgeryExtension.GetSurgeryExtensionForWL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SurgeryExtension.GetSurgeryExtensionForWL_Class> GetSurgeryExtensionForWL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERYEXTENSION"].QueryDefs["GetSurgeryExtensionForWL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SurgeryExtension.GetSurgeryExtensionForWL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Ön Hazırlık İçin Direktifler
    /// </summary>
        public object DescriptionToPreOp
        {
            get { return (object)this["DESCRIPTIONTOPREOP"]; }
            set { this["DESCRIPTIONTOPREOP"] = value; }
        }

        public bool? CancelledBySurgery
        {
            get { return (bool?)this["CANCELLEDBYSURGERY"]; }
            set { this["CANCELLEDBYSURGERY"] = value; }
        }

    /// <summary>
    /// Ön Hazırlık Açıklamaları
    /// </summary>
        public string PreOpDescriptions
        {
            get { return (string)this["PREOPDESCRIPTIONS"]; }
            set { this["PREOPDESCRIPTIONS"] = value; }
        }

        public Surgery MainSurgery
        {
            get { return (Surgery)((ITTObject)this).GetParent("MAINSURGERY"); }
            set { this["MAINSURGERY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateSurgeriesCollection()
        {
            _Surgeries = new Surgery.ChildSurgeryCollection(this, new Guid("ce9f7eee-7f8e-4f9e-9d8d-87b4d91be17d"));
            ((ITTChildObjectCollection)_Surgeries).GetChildren();
        }

        protected Surgery.ChildSurgeryCollection _Surgeries = null;
        public Surgery.ChildSurgeryCollection Surgeries
        {
            get
            {
                if (_Surgeries == null)
                    CreateSurgeriesCollection();
                return _Surgeries;
            }
        }

        override protected void CreateTreatmentMaterialsCollectionViews()
        {
            base.CreateTreatmentMaterialsCollectionViews();
            _SurgeryExtensionExpends = new SurgeryExpend.ChildSurgeryExpendCollection(_TreatmentMaterials, "SurgeryExtensionExpends");
        }

        private SurgeryExpend.ChildSurgeryExpendCollection _SurgeryExtensionExpends = null;
        public SurgeryExpend.ChildSurgeryExpendCollection SurgeryExtensionExpends
        {
            get
            {
                if (_TreatmentMaterials == null)
                    CreateTreatmentMaterialsCollection();
                return _SurgeryExtensionExpends;
            }            
        }

        protected SurgeryExtension(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SurgeryExtension(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SurgeryExtension(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SurgeryExtension(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SurgeryExtension(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SURGERYEXTENSION", dataRow) { }
        protected SurgeryExtension(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SURGERYEXTENSION", dataRow, isImported) { }
        public SurgeryExtension(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SurgeryExtension(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SurgeryExtension() : base() { }

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