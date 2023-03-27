
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MedulaOptikReport")] 

    public  partial class MedulaOptikReport : EpisodeActionWithDiagnosis, IWorkListEpisodeAction
    {
        public class MedulaOptikReportList : TTObjectCollection<MedulaOptikReport> { }
                    
        public class ChildMedulaOptikReportCollection : TTObject.TTChildObjectCollection<MedulaOptikReport>
        {
            public ChildMedulaOptikReportCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMedulaOptikReportCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("b941dfa0-1135-4c02-9f19-3c586c77184c"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("2adabbaf-f8b4-4cb3-86b5-f918e170b9a0"); } }
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("6f5a33b0-5dd6-4e6b-bffc-dad6f74a8b4e"); } }
            public static Guid Approval { get { return new Guid("f8869386-3809-40c4-a4a0-c32c73843b05"); } }
            public static Guid HeadDoctorApproval { get { return new Guid("80c12d98-d7d1-4b5b-8ebb-7beb065e05be"); } }
        }

    /// <summary>
    /// Başhekim Onay Durumu
    /// </summary>
        public bool? IsHeadDoctorApproved
        {
            get { return (bool?)this["ISHEADDOCTORAPPROVED"]; }
            set { this["ISHEADDOCTORAPPROVED"] = value; }
        }

        public string raporId
        {
            get { return (string)this["RAPORID"]; }
            set { this["RAPORID"] = value; }
        }

    /// <summary>
    /// Rapor Tipi
    /// </summary>
        public MedulaOptikTipEnum? RaporTipi
        {
            get { return (MedulaOptikTipEnum?)(int?)this["RAPORTIPI"]; }
            set { this["RAPORTIPI"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string RaporAciklama
        {
            get { return (string)this["RAPORACIKLAMA"]; }
            set { this["RAPORACIKLAMA"] = value; }
        }

    /// <summary>
    /// Rapor Düzenleme Türü
    /// </summary>
        public MedulaOptikRaporDuzenlenmeTuruEnum? RaporDuzenlemeTuru
        {
            get { return (MedulaOptikRaporDuzenlenmeTuruEnum?)(int?)this["RAPORDUZENLEMETURU"]; }
            set { this["RAPORDUZENLEMETURU"] = value; }
        }

    /// <summary>
    /// Rapor Kayıt Şekli
    /// </summary>
        public MedulaOptikRaporKayitSekliEnum? RaporKayitSekli
        {
            get { return (MedulaOptikRaporKayitSekliEnum?)(int?)this["RAPORKAYITSEKLI"]; }
            set { this["RAPORKAYITSEKLI"] = value; }
        }

        public string SonucKodu
        {
            get { return (string)this["SONUCKODU"]; }
            set { this["SONUCKODU"] = value; }
        }

        public string SonucMesaji
        {
            get { return (string)this["SONUCMESAJI"]; }
            set { this["SONUCMESAJI"] = value; }
        }

        public string UyariMesaji
        {
            get { return (string)this["UYARIMESAJI"]; }
            set { this["UYARIMESAJI"] = value; }
        }

        public string eReceteNo
        {
            get { return (string)this["ERECETENO"]; }
            set { this["ERECETENO"] = value; }
        }

        public DateTime? RaporBaslangicTarih
        {
            get { return (DateTime?)this["RAPORBASLANGICTARIH"]; }
            set { this["RAPORBASLANGICTARIH"] = value; }
        }

        public DateTime? RaporBitisTarih
        {
            get { return (DateTime?)this["RAPORBITISTARIH"]; }
            set { this["RAPORBITISTARIH"] = value; }
        }

        public TTSequence RaporSequenceNo
        {
            get { return GetSequence("RAPORSEQUENCENO"); }
        }

    /// <summary>
    /// Durum
    /// </summary>
        public string Durum
        {
            get { return (string)this["DURUM"]; }
            set { this["DURUM"] = value; }
        }

    /// <summary>
    /// E Reçete Şifresi 
    /// </summary>
        public string ERecetePassword
        {
            get { return (string)this["ERECETEPASSWORD"]; }
            set { this["ERECETEPASSWORD"] = value; }
        }

    /// <summary>
    /// Raporun Alındığı Takip No
    /// </summary>
        public string RaporTakipNo
        {
            get { return (string)this["RAPORTAKIPNO"]; }
            set { this["RAPORTAKIPNO"] = value; }
        }

        public DiagnosisDefinition DiagnosisDefinition
        {
            get { return (DiagnosisDefinition)((ITTObject)this).GetParent("DIAGNOSISDEFINITION"); }
            set { this["DIAGNOSISDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateOptikDoctorsGridCollection()
        {
            _OptikDoctorsGrid = new OptikDoctorsGrid.ChildOptikDoctorsGridCollection(this, new Guid("410b4f63-ff86-4cc2-8100-cddd70765a93"));
            ((ITTChildObjectCollection)_OptikDoctorsGrid).GetChildren();
        }

        protected OptikDoctorsGrid.ChildOptikDoctorsGridCollection _OptikDoctorsGrid = null;
        public OptikDoctorsGrid.ChildOptikDoctorsGridCollection OptikDoctorsGrid
        {
            get
            {
                if (_OptikDoctorsGrid == null)
                    CreateOptikDoctorsGridCollection();
                return _OptikDoctorsGrid;
            }
        }

        protected MedulaOptikReport(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MedulaOptikReport(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MedulaOptikReport(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MedulaOptikReport(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MedulaOptikReport(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MEDULAOPTIKREPORT", dataRow) { }
        protected MedulaOptikReport(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MEDULAOPTIKREPORT", dataRow, isImported) { }
        public MedulaOptikReport(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MedulaOptikReport(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MedulaOptikReport() : base() { }

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