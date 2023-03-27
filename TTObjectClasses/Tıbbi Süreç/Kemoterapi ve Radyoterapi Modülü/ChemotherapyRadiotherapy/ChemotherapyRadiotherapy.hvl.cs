
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ChemotherapyRadiotherapy")] 

    /// <summary>
    /// Kemoterapi ve Radyoterapi için kullanılacak temel nesne
    /// </summary>
    public  partial class ChemotherapyRadiotherapy : EpisodeAction
    {
        public class ChemotherapyRadiotherapyList : TTObjectCollection<ChemotherapyRadiotherapy> { }
                    
        public class ChildChemotherapyRadiotherapyCollection : TTObject.TTChildObjectCollection<ChemotherapyRadiotherapy>
        {
            public ChildChemotherapyRadiotherapyCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildChemotherapyRadiotherapyCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetChemoRadiotherapyForWL_Class : TTReportNqlObject 
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

            public bool? Isemergency
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISEMERGENCY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CHEMOTHERAPYRADIOTHERAPY"].AllPropertyDefs["EMERGENCY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
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

            public DateTime? Date
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CHEMOTHERAPYRADIOTHERAPY"].AllPropertyDefs["REQUESTDATE"].DataType;
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

            public string Masterresource
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MASTERRESOURCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Fromresource
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FROMRESOURCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Doctorname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCTORNAME"]);
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

            public SubEpisodeStatusEnum? PatientStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["PATIENTSTATUS"].DataType;
                    return (SubEpisodeStatusEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GetChemoRadiotherapyForWL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetChemoRadiotherapyForWL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetChemoRadiotherapyForWL_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// İstek Yapıldı
    /// </summary>
            public static Guid Request { get { return new Guid("cc38d1bd-f5c4-4c81-a732-6aaa9413ea90"); } }
    /// <summary>
    /// Doktor Planlama
    /// </summary>
            public static Guid DoctorPlanned { get { return new Guid("89346553-55ae-43e6-b3ab-724304671346"); } }
    /// <summary>
    /// Hemşire Onayı
    /// </summary>
            public static Guid NurseApproved { get { return new Guid("a2fa62be-3f9b-44b4-947b-607f5e7af931"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("04f27f18-aeb7-420d-8676-d3ec11ebfa0d"); } }
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("a0539871-054d-4504-a5d1-c1d02d76959b"); } }
        }

        public static BindingList<ChemotherapyRadiotherapy.GetChemoRadiotherapyForWL_Class> GetChemoRadiotherapyForWL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CHEMOTHERAPYRADIOTHERAPY"].QueryDefs["GetChemoRadiotherapyForWL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ChemotherapyRadiotherapy.GetChemoRadiotherapyForWL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ChemotherapyRadiotherapy.GetChemoRadiotherapyForWL_Class> GetChemoRadiotherapyForWL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CHEMOTHERAPYRADIOTHERAPY"].QueryDefs["GetChemoRadiotherapyForWL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ChemotherapyRadiotherapy.GetChemoRadiotherapyForWL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ChemotherapyRadiotherapy> GetPatientsChemotherapyRadiotherapies(TTObjectContext objectContext, Guid PATIENT, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CHEMOTHERAPYRADIOTHERAPY"].QueryDefs["GetPatientsChemotherapyRadiotherapies"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return ((ITTQuery)objectContext).QueryObjects<ChemotherapyRadiotherapy>(queryDef, paramList, injectionSQL);
        }

    /// <summary>
    /// Tedavi Başlangıç Tarihi
    /// </summary>
        public DateTime? CureStartDate
        {
            get { return (DateTime?)this["CURESTARTDATE"]; }
            set { this["CURESTARTDATE"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public object Description
        {
            get { return (object)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Eski Subepisode
    /// </summary>
        public SubEpisode OldSubEpisode
        {
            get { return (SubEpisode)((ITTObject)this).GetParent("OLDSUBEPISODE"); }
            set { this["OLDSUBEPISODE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public BaseAction CreatedAction
        {
            get { return (BaseAction)((ITTObject)this).GetParent("CREATEDACTION"); }
            set { this["CREATEDACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateChemoRadioCureProtocolCollection()
        {
            _ChemoRadioCureProtocol = new ChemoRadioCureProtocol.ChildChemoRadioCureProtocolCollection(this, new Guid("32e5b921-209a-47c3-897b-37af4a0d0ba5"));
            ((ITTChildObjectCollection)_ChemoRadioCureProtocol).GetChildren();
        }

        protected ChemoRadioCureProtocol.ChildChemoRadioCureProtocolCollection _ChemoRadioCureProtocol = null;
        public ChemoRadioCureProtocol.ChildChemoRadioCureProtocolCollection ChemoRadioCureProtocol
        {
            get
            {
                if (_ChemoRadioCureProtocol == null)
                    CreateChemoRadioCureProtocolCollection();
                return _ChemoRadioCureProtocol;
            }
        }

        override protected void CreateTreatmentMaterialsCollectionViews()
        {
            base.CreateTreatmentMaterialsCollectionViews();
            _ChemotherapyRadiotherapies = new ChemoRadiotherapyMaterial.ChildChemoRadiotherapyMaterialCollection(_TreatmentMaterials, "ChemotherapyRadiotherapies");
        }

        private ChemoRadiotherapyMaterial.ChildChemoRadiotherapyMaterialCollection _ChemotherapyRadiotherapies = null;
        public ChemoRadiotherapyMaterial.ChildChemoRadiotherapyMaterialCollection ChemotherapyRadiotherapies
        {
            get
            {
                if (_TreatmentMaterials == null)
                    CreateTreatmentMaterialsCollection();
                return _ChemotherapyRadiotherapies;
            }            
        }

        protected ChemotherapyRadiotherapy(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ChemotherapyRadiotherapy(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ChemotherapyRadiotherapy(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ChemotherapyRadiotherapy(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ChemotherapyRadiotherapy(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CHEMOTHERAPYRADIOTHERAPY", dataRow) { }
        protected ChemotherapyRadiotherapy(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CHEMOTHERAPYRADIOTHERAPY", dataRow, isImported) { }
        public ChemotherapyRadiotherapy(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ChemotherapyRadiotherapy(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ChemotherapyRadiotherapy() : base() { }

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