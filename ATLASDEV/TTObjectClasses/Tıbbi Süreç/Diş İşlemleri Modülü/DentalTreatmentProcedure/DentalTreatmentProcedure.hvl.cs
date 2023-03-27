
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DentalTreatmentProcedure")] 

    /// <summary>
    /// Diş Tedavi Prosedür
    /// </summary>
    public  partial class DentalTreatmentProcedure : BaseDentalTreatment, IAppointmentDef, IWorkListEpisodeAction, ITreatmentMaterialCollection
    {
        public class DentalTreatmentProcedureList : TTObjectCollection<DentalTreatmentProcedure> { }
                    
        public class ChildDentalTreatmentProcedureCollection : TTObject.TTChildObjectCollection<DentalTreatmentProcedure>
        {
            public ChildDentalTreatmentProcedureCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDentalTreatmentProcedureCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Appointment { get { return new Guid("0cd7b905-3fbd-4516-b66c-498a1601a0f6"); } }
            public static Guid Completed { get { return new Guid("70a6be7e-9fad-4624-8d61-5f1ed356cb4e"); } }
            public static Guid TreatmentProcedure { get { return new Guid("5aaa321d-d2f8-48d3-81e2-9be6e2d027e3"); } }
            public static Guid Cancelled { get { return new Guid("23589daa-24cb-4010-8e9d-7a013b604774"); } }
            public static Guid ApprovalTechnicanProcedure { get { return new Guid("d3498685-53ef-4a6f-a634-ebf2b4efc649"); } }
            public static Guid TechnicianProcedure { get { return new Guid("c41cb353-8217-4a23-844b-c239c6c0d9b0"); } }
            public static Guid Rejected { get { return new Guid("8a728003-9a39-45b7-bbd2-f8f41d912917"); } }
        }

        public static BindingList<DentalTreatmentProcedure> GetUncompletedProceduresByEpisode(TTObjectContext objectContext, Guid EPISODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DENTALTREATMENTPROCEDURE"].QueryDefs["GetUncompletedProceduresByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return ((ITTQuery)objectContext).QueryObjects<DentalTreatmentProcedure>(queryDef, paramList);
        }

    /// <summary>
    /// Teknisyen Notu
    /// </summary>
        public string TechnicianNote
        {
            get { return (string)this["TECHNICIANNOTE"]; }
            set { this["TECHNICIANNOTE"] = value; }
        }

    /// <summary>
    /// Diş No
    /// </summary>
        public ToothNumberEnum? ToothNumber
        {
            get { return (ToothNumberEnum?)(int?)this["TOOTHNUMBER"]; }
            set { this["TOOTHNUMBER"] = value; }
        }

        public DateTime? ProcessDate
        {
            get { return (DateTime?)this["PROCESSDATE"]; }
            set { this["PROCESSDATE"] = value; }
        }

    /// <summary>
    /// Diş Tedavi Açıklama
    /// </summary>
        public string DentalTreatmentDescription
        {
            get { return (string)this["DENTALTREATMENTDESCRIPTION"]; }
            set { this["DENTALTREATMENTDESCRIPTION"] = value; }
        }

    /// <summary>
    /// Teknisyene İşlem Açıklaması
    /// </summary>
        public string DefinitiontoTechnician
        {
            get { return (string)this["DEFINITIONTOTECHNICIAN"]; }
            set { this["DEFINITIONTOTECHNICIAN"] = value; }
        }

    /// <summary>
    /// İade Sebebi
    /// </summary>
        public string ReasonOfReturn
        {
            get { return (string)this["REASONOFRETURN"]; }
            set { this["REASONOFRETURN"] = value; }
        }

    /// <summary>
    /// Pozisyon
    /// </summary>
        public DentalPositionEnum? DentalPosition
        {
            get { return (DentalPositionEnum?)(int?)this["DENTALPOSITION"]; }
            set { this["DENTALPOSITION"] = value; }
        }

    /// <summary>
    /// Genel Anestezi
    /// </summary>
        public bool? GeneralAnesthesia
        {
            get { return (bool?)this["GENERALANESTHESIA"]; }
            set { this["GENERALANESTHESIA"] = value; }
        }

    /// <summary>
    /// Diş Taahhüt Numarası
    /// </summary>
        public int? DisTaahhutNo
        {
            get { return (int?)this["DISTAAHHUTNO"]; }
            set { this["DISTAAHHUTNO"] = value; }
        }

    /// <summary>
    /// Anestezi Doktor Tescil No
    /// </summary>
        public string DrAnesteziTescilNo
        {
            get { return (string)this["DRANESTEZITESCILNO"]; }
            set { this["DRANESTEZITESCILNO"] = value; }
        }

    /// <summary>
    /// Anomali
    /// </summary>
        public bool? Anomali
        {
            get { return (bool?)this["ANOMALI"]; }
            set { this["ANOMALI"] = value; }
        }

    /// <summary>
    /// Tedavi İstek Türü
    /// </summary>
        public DentalRequestTypeDefinition DentalRequestType
        {
            get { return (DentalRequestTypeDefinition)((ITTObject)this).GetParent("DENTALREQUESTTYPE"); }
            set { this["DENTALREQUESTTYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Teknisyen işlemleri Birimi
    /// </summary>
        public ResSection TechnicalDepartment
        {
            get { return (ResSection)((ITTObject)this).GetParent("TECHNICALDEPARTMENT"); }
            set { this["TECHNICALDEPARTMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DentalTreatmentRequestSuggestedTreatment SuggestedTreatment
        {
            get { return (DentalTreatmentRequestSuggestedTreatment)((ITTObject)this).GetParent("SUGGESTEDTREATMENT"); }
            set { this["SUGGESTEDTREATMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Tedavi Birimi
    /// </summary>
        public ResSection ProcedureDepartment
        {
            get { return (ResSection)((ITTObject)this).GetParent("PROCEDUREDEPARTMENT"); }
            set { this["PROCEDUREDEPARTMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// DentalTreatmentProcedure_AyniFarkliKesi
    /// </summary>
        public AyniFarkliKesi AyniFarkliKesi
        {
            get { return (AyniFarkliKesi)((ITTObject)this).GetParent("AYNIFARKLIKESI"); }
            set { this["AYNIFARKLIKESI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public OzelDurum OzelDurum
        {
            get { return (OzelDurum)((ITTObject)this).GetParent("OZELDURUM"); }
            set { this["OZELDURUM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResUser ResUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESUSER"); }
            set { this["RESUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DentalTreatmentRequest DentalTreatmentRequest
        {
            get 
            {   
                if (EpisodeAction is DentalTreatmentRequest)
                    return (DentalTreatmentRequest)EpisodeAction; 
                return null;
            }            
            set { EpisodeAction = value; }
        }

        protected DentalTreatmentProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DentalTreatmentProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DentalTreatmentProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DentalTreatmentProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DentalTreatmentProcedure(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DENTALTREATMENTPROCEDURE", dataRow) { }
        protected DentalTreatmentProcedure(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DENTALTREATMENTPROCEDURE", dataRow, isImported) { }
        public DentalTreatmentProcedure(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DentalTreatmentProcedure(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DentalTreatmentProcedure() : base() { }

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