
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SurgeryAppointment")] 

    /// <summary>
    /// Ameliyat Randevuları Nesnesi
    /// </summary>
    public  partial class SurgeryAppointment : TTObject
    {
        public class SurgeryAppointmentList : TTObjectCollection<SurgeryAppointment> { }
                    
        public class ChildSurgeryAppointmentCollection : TTObject.TTChildObjectCollection<SurgeryAppointment>
        {
            public ChildSurgeryAppointmentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSurgeryAppointmentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Sekreter Randevuyu oluşturduğunda İşlemin başlayacağı adım
    /// </summary>
            public static Guid DoctorApproval { get { return new Guid("67a5fd03-99a6-4a02-bf66-00135b67beb2"); } }
    /// <summary>
    /// Doktor Randevu Eklediğinde Parametre Açıksa İşlemin Başlayacağı Adım
    /// </summary>
            public static Guid HeadDoctorApproval { get { return new Guid("44004a61-52b3-4949-b0c7-541fb1b1fc1f"); } }
    /// <summary>
    /// Doktor Randevu Eklediğinde Parametre Kapalı ise İşlemin Başlayacağı Adım
    /// </summary>
            public static Guid Approved { get { return new Guid("40729e78-c210-4237-8b1e-7b5f4a167498"); } }
    /// <summary>
    /// Ameliyat istek yapılırken randevu seçildi ise randevu bu adıma alınacak
    /// </summary>
            public static Guid Completed { get { return new Guid("a8888ff1-0c6b-4b9e-8991-c1a9f90835e9"); } }
            public static Guid Cancelled { get { return new Guid("63c81710-93ac-4ebd-8312-85e89b846cf4"); } }
        }

        public static BindingList<SurgeryAppointment> GetSurgeryAppointmentsForWL(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERYAPPOINTMENT"].QueryDefs["GetSurgeryAppointmentsForWL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<SurgeryAppointment>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<SurgeryAppointment> GetPatientsApprovedAppointments(TTObjectContext objectContext, Guid PATIENT, DateTime PLANNEDSURGERYSTARTDATE, DateTime TODAY)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERYAPPOINTMENT"].QueryDefs["GetPatientsApprovedAppointments"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);
            paramList.Add("PLANNEDSURGERYSTARTDATE", PLANNEDSURGERYSTARTDATE);
            paramList.Add("TODAY", TODAY);

            return ((ITTQuery)objectContext).QueryObjects<SurgeryAppointment>(queryDef, paramList);
        }

        public string PlannedSurgeryDescription
        {
            get { return (string)this["PLANNEDSURGERYDESCRIPTION"]; }
            set { this["PLANNEDSURGERYDESCRIPTION"] = value; }
        }

    /// <summary>
    /// Ön Hazırlık İçin Direktifler
    /// </summary>
        public object DescriptionToPreOp
        {
            get { return (object)this["DESCRIPTIONTOPREOP"]; }
            set { this["DESCRIPTIONTOPREOP"] = value; }
        }

    /// <summary>
    /// Anestezi Bölümü İçin Açıklamalar
    /// </summary>
        public string NotesToAnesthesia
        {
            get { return (string)this["NOTESTOANESTHESIA"]; }
            set { this["NOTESTOANESTHESIA"] = value; }
        }

    /// <summary>
    /// Planlanan Ameliyat Başlangıç Tarihi
    /// </summary>
        public DateTime? PlannedSurgeryStartDate
        {
            get { return (DateTime?)this["PLANNEDSURGERYSTARTDATE"]; }
            set { this["PLANNEDSURGERYSTARTDATE"] = value; }
        }

    /// <summary>
    /// Planlanan Ameliyat Bitiş Tarihi
    /// </summary>
        public DateTime? PlannedSurgeryEndDate
        {
            get { return (DateTime?)this["PLANNEDSURGERYENDDATE"]; }
            set { this["PLANNEDSURGERYENDDATE"] = value; }
        }

        public string ComplicationDescription
        {
            get { return (string)this["COMPLICATIONDESCRIPTION"]; }
            set { this["COMPLICATIONDESCRIPTION"] = value; }
        }

        public bool? IsComplicationSurgery
        {
            get { return (bool?)this["ISCOMPLICATIONSURGERY"]; }
            set { this["ISCOMPLICATIONSURGERY"] = value; }
        }

        public bool? IsNeedAnesthesia
        {
            get { return (bool?)this["ISNEEDANESTHESIA"]; }
            set { this["ISNEEDANESTHESIA"] = value; }
        }

    /// <summary>
    /// Randevu Oluşturulma Tarihi
    /// </summary>
        public DateTime? CreatedDate
        {
            get { return (DateTime?)this["CREATEDDATE"]; }
            set { this["CREATEDDATE"] = value; }
        }

    /// <summary>
    /// İşlemin Acil Olup Olmadığını Tutan Alandır
    /// </summary>
        public bool? Emergency
        {
            get { return (bool?)this["EMERGENCY"]; }
            set { this["EMERGENCY"] = value; }
        }

    /// <summary>
    /// Ameliyat Masası
    /// </summary>
        public ResSurgeryDesk SurgeryDesk
        {
            get { return (ResSurgeryDesk)((ITTObject)this).GetParent("SURGERYDESK"); }
            set { this["SURGERYDESK"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Ameliyat Salonu
    /// </summary>
        public ResSurgeryRoom SurgeryRoom
        {
            get { return (ResSurgeryRoom)((ITTObject)this).GetParent("SURGERYROOM"); }
            set { this["SURGERYROOM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İşlemi Gerçekleştiren Doktor Nesnesini Taşıyan Alandır
    /// </summary>
        public ResUser ProcedureDoctor
        {
            get { return (ResUser)((ITTObject)this).GetParent("PROCEDUREDOCTOR"); }
            set { this["PROCEDUREDOCTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İşlemi Yapan Birimin  Tutulduğu Alan
    /// </summary>
        public ResSection MasterResource
        {
            get { return (ResSection)((ITTObject)this).GetParent("MASTERRESOURCE"); }
            set { this["MASTERRESOURCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Randevuyu Oluşturan Kullanıcıyı Tutan Alandır
    /// </summary>
        public ResUser CreatedBy
        {
            get { return (ResUser)((ITTObject)this).GetParent("CREATEDBY"); }
            set { this["CREATEDBY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Patient Patient
        {
            get { return (Patient)((ITTObject)this).GetParent("PATIENT"); }
            set { this["PATIENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Surgery Surgery
        {
            get { return (Surgery)((ITTObject)this).GetParent("SURGERY"); }
            set { this["SURGERY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateSurgeryAppointmentProceduresCollection()
        {
            _SurgeryAppointmentProcedures = new SurgeryAppointmentProc.ChildSurgeryAppointmentProcCollection(this, new Guid("76b8ad84-b159-4c15-be4d-ef1688e96a26"));
            ((ITTChildObjectCollection)_SurgeryAppointmentProcedures).GetChildren();
        }

        protected SurgeryAppointmentProc.ChildSurgeryAppointmentProcCollection _SurgeryAppointmentProcedures = null;
        public SurgeryAppointmentProc.ChildSurgeryAppointmentProcCollection SurgeryAppointmentProcedures
        {
            get
            {
                if (_SurgeryAppointmentProcedures == null)
                    CreateSurgeryAppointmentProceduresCollection();
                return _SurgeryAppointmentProcedures;
            }
        }

        virtual protected void CreateSurgeryAppointmentMaterialsCollection()
        {
            _SurgeryAppointmentMaterials = new SurgeryAppointmentMaterial.ChildSurgeryAppointmentMaterialCollection(this, new Guid("68adef0f-5d66-4c0d-8ab9-61bff85dbe02"));
            ((ITTChildObjectCollection)_SurgeryAppointmentMaterials).GetChildren();
        }

        protected SurgeryAppointmentMaterial.ChildSurgeryAppointmentMaterialCollection _SurgeryAppointmentMaterials = null;
        public SurgeryAppointmentMaterial.ChildSurgeryAppointmentMaterialCollection SurgeryAppointmentMaterials
        {
            get
            {
                if (_SurgeryAppointmentMaterials == null)
                    CreateSurgeryAppointmentMaterialsCollection();
                return _SurgeryAppointmentMaterials;
            }
        }

        protected SurgeryAppointment(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SurgeryAppointment(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SurgeryAppointment(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SurgeryAppointment(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SurgeryAppointment(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SURGERYAPPOINTMENT", dataRow) { }
        protected SurgeryAppointment(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SURGERYAPPOINTMENT", dataRow, isImported) { }
        public SurgeryAppointment(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SurgeryAppointment(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SurgeryAppointment() : base() { }

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