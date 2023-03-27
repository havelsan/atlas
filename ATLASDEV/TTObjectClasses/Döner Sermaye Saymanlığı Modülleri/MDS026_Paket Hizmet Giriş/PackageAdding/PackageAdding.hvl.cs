
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PackageAdding")] 

    /// <summary>
    /// Paket Hizmet Girişi
    /// </summary>
    public  partial class PackageAdding : EpisodeAction
    {
        public class PackageAddingList : TTObjectCollection<PackageAdding> { }
                    
        public class ChildPackageAddingCollection : TTObject.TTChildObjectCollection<PackageAdding>
        {
            public ChildPackageAddingCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPackageAddingCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid New { get { return new Guid("bab7b94f-c4d7-4065-a24b-a4765ff1e86a"); } }
            public static Guid Completed { get { return new Guid("fd15e933-0744-4950-b4e9-6377a5b2a6ff"); } }
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("ab7dee39-8f92-40c3-985f-9facac1d462a"); } }
        }

    /// <summary>
    /// Bitiş Tarihi
    /// </summary>
        public DateTime? EndDate
        {
            get { return (DateTime?)this["ENDDATE"]; }
            set { this["ENDDATE"] = value; }
        }

    /// <summary>
    /// Başlangıç Tarihi
    /// </summary>
        public DateTime? StartDate
        {
            get { return (DateTime?)this["STARTDATE"]; }
            set { this["STARTDATE"] = value; }
        }

    /// <summary>
    /// İndirim Oranı
    /// </summary>
        public double? DiscountPercent
        {
            get { return (double?)this["DISCOUNTPERCENT"]; }
            set { this["DISCOUNTPERCENT"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Aciklama
        {
            get { return (string)this["ACIKLAMA"]; }
            set { this["ACIKLAMA"] = value; }
        }

    /// <summary>
    /// Birim
    /// </summary>
        public string Birim
        {
            get { return (string)this["BIRIM"]; }
            set { this["BIRIM"] = value; }
        }

    /// <summary>
    /// Rapor Takip No
    /// </summary>
        public string RaporTakipNo
        {
            get { return (string)this["RAPORTAKIPNO"]; }
            set { this["RAPORTAKIPNO"] = value; }
        }

    /// <summary>
    /// Refakatçi Gün Sayısı
    /// </summary>
        public int? RefakatciGunSayisi
        {
            get { return (int?)this["REFAKATCIGUNSAYISI"]; }
            set { this["REFAKATCIGUNSAYISI"] = value; }
        }

    /// <summary>
    /// Sonuç
    /// </summary>
        public string Sonuc
        {
            get { return (string)this["SONUC"]; }
            set { this["SONUC"] = value; }
        }

        public MedulaEuroScoreEnum? MedulaEuroScore
        {
            get { return (MedulaEuroScoreEnum?)(int?)this["MEDULAEUROSCORE"]; }
            set { this["MEDULAEUROSCORE"] = value; }
        }

    /// <summary>
    /// Branş
    /// </summary>
        public SpecialityDefinition Brans
        {
            get { return (SpecialityDefinition)((ITTObject)this).GetParent("BRANS"); }
            set { this["BRANS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İki Tarih Arası Paket Hizmet
    /// </summary>
        public PackageProcedureDefinition PackageProcedureDefinition
        {
            get { return (PackageProcedureDefinition)((ITTObject)this).GetParent("PACKAGEPROCEDUREDEFINITION"); }
            set { this["PACKAGEPROCEDUREDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Paket Alt Vaka
    /// </summary>
        public SubEpisode PackageSubEpisode
        {
            get { return (SubEpisode)((ITTObject)this).GetParent("PACKAGESUBEPISODE"); }
            set { this["PACKAGESUBEPISODE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Anestezi Doktor
    /// </summary>
        public ResUser AnesteziDoktor
        {
            get { return (ResUser)((ITTObject)this).GetParent("ANESTEZIDOKTOR"); }
            set { this["ANESTEZIDOKTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Aynı Farklı Kesi
    /// </summary>
        public AyniFarkliKesi AyniFarkliKesi
        {
            get { return (AyniFarkliKesi)((ITTObject)this).GetParent("AYNIFARKLIKESI"); }
            set { this["AYNIFARKLIKESI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Doktor
    /// </summary>
        public ResUser Doktor
        {
            get { return (ResUser)((ITTObject)this).GetParent("DOKTOR"); }
            set { this["DOKTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Özel Durum
    /// </summary>
        public OzelDurum OzelDurum
        {
            get { return (OzelDurum)((ITTObject)this).GetParent("OZELDURUM"); }
            set { this["OZELDURUM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Sağ Sol
    /// </summary>
        public SagSol SagSol
        {
            get { return (SagSol)((ITTObject)this).GetParent("SAGSOL"); }
            set { this["SAGSOL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        override protected void CreateSubactionProceduresCollectionViews()
        {
            base.CreateSubactionProceduresCollectionViews();
            _SubActionPackageProcedures = new SubActionPackageProcedure.ChildSubActionPackageProcedureCollection(_SubactionProcedures, "SubActionPackageProcedures");
        }

        private SubActionPackageProcedure.ChildSubActionPackageProcedureCollection _SubActionPackageProcedures = null;
        public SubActionPackageProcedure.ChildSubActionPackageProcedureCollection SubActionPackageProcedures
        {
            get
            {
                if (_SubactionProcedures == null)
                    CreateSubactionProceduresCollection();
                return _SubActionPackageProcedures;
            }            
        }

        protected PackageAdding(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PackageAdding(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PackageAdding(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PackageAdding(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PackageAdding(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PACKAGEADDING", dataRow) { }
        protected PackageAdding(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PACKAGEADDING", dataRow, isImported) { }
        public PackageAdding(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PackageAdding(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PackageAdding() : base() { }

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