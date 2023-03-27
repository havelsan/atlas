
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SubActionPackageProcedure")] 

    public  partial class SubActionPackageProcedure : SubActionProcedure
    {
        public class SubActionPackageProcedureList : TTObjectCollection<SubActionPackageProcedure> { }
                    
        public class ChildSubActionPackageProcedureCollection : TTObject.TTChildObjectCollection<SubActionPackageProcedure>
        {
            public ChildSubActionPackageProcedureCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSubActionPackageProcedureCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid New { get { return new Guid("1c28a828-4470-46a5-af69-701b5322df1f"); } }
            public static Guid Completed { get { return new Guid("35536bbc-e567-46c8-be88-3bc9d65bfd5f"); } }
            public static Guid Cancelled { get { return new Guid("d16bf872-a7d1-476c-806d-92fd1852dccc"); } }
        }

    /// <summary>
    /// Paket Başlangıç Tarihi
    /// </summary>
        public DateTime? StartDate
        {
            get { return (DateTime?)this["STARTDATE"]; }
            set { this["STARTDATE"] = value; }
        }

    /// <summary>
    /// Paket Bitiş Tarihi
    /// </summary>
        public DateTime? EndDate
        {
            get { return (DateTime?)this["ENDDATE"]; }
            set { this["ENDDATE"] = value; }
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
    /// Rapor Takip No
    /// </summary>
        public string RaporTakipNo
        {
            get { return (string)this["RAPORTAKIPNO"]; }
            set { this["RAPORTAKIPNO"] = value; }
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
    /// Sonuç
    /// </summary>
        public string Sonuc
        {
            get { return (string)this["SONUC"]; }
            set { this["SONUC"] = value; }
        }

    /// <summary>
    /// Refakatçi Gün Sayısı
    /// </summary>
        public int? RefakatciGunSayisi
        {
            get { return (int?)this["REFAKATCIGUNSAYISI"]; }
            set { this["REFAKATCIGUNSAYISI"] = value; }
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
    /// Sağ Sol
    /// </summary>
        public SagSol SagSol
        {
            get { return (SagSol)((ITTObject)this).GetParent("SAGSOL"); }
            set { this["SAGSOL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PackageAdding PackageAdding
        {
            get 
            {   
                if (EpisodeAction is PackageAdding)
                    return (PackageAdding)EpisodeAction; 
                return null;
            }            
            set { EpisodeAction = value; }
        }

        virtual protected void CreateTransferFromPackSubActPacsCollection()
        {
            _TransferFromPackSubActPacs = new TransferFromPackSubActPacs.ChildTransferFromPackSubActPacsCollection(this, new Guid("d881be73-e09f-4aae-8a27-92571ea78bdb"));
            ((ITTChildObjectCollection)_TransferFromPackSubActPacs).GetChildren();
        }

        protected TransferFromPackSubActPacs.ChildTransferFromPackSubActPacsCollection _TransferFromPackSubActPacs = null;
    /// <summary>
    /// Child collection for Paket hizmet hareketi ile ilişki
    /// </summary>
        public TransferFromPackSubActPacs.ChildTransferFromPackSubActPacsCollection TransferFromPackSubActPacs
        {
            get
            {
                if (_TransferFromPackSubActPacs == null)
                    CreateTransferFromPackSubActPacsCollection();
                return _TransferFromPackSubActPacs;
            }
        }

        protected SubActionPackageProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SubActionPackageProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SubActionPackageProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SubActionPackageProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SubActionPackageProcedure(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SUBACTIONPACKAGEPROCEDURE", dataRow) { }
        protected SubActionPackageProcedure(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SUBACTIONPACKAGEPROCEDURE", dataRow, isImported) { }
        public SubActionPackageProcedure(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SubActionPackageProcedure(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SubActionPackageProcedure() : base() { }

    }
}