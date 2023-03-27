
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="EvdeSaglikHizmetleri")] 

    public  partial class EvdeSaglikHizmetleri : TTObject
    {
        public class EvdeSaglikHizmetleriList : TTObjectCollection<EvdeSaglikHizmetleri> { }
                    
        public class ChildEvdeSaglikHizmetleriCollection : TTObject.TTChildObjectCollection<EvdeSaglikHizmetleri>
        {
            public ChildEvdeSaglikHizmetleriCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildEvdeSaglikHizmetleriCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("39c8f810-c844-42c8-b9b8-304004663639"); } }
            public static Guid Save { get { return new Guid("4e2f14f8-2a6f-40bc-a51f-8071f0bc3b6c"); } }
        }

        public static BindingList<EvdeSaglikHizmetleri> GetHomeCarePatientByBasvuruIDNQL(TTObjectContext objectContext, int BASVURUID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EVDESAGLIKHIZMETLERI"].QueryDefs["GetHomeCarePatientByBasvuruIDNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("BASVURUID", BASVURUID);

            return ((ITTQuery)objectContext).QueryObjects<EvdeSaglikHizmetleri>(queryDef, paramList);
        }

        public static BindingList<EvdeSaglikHizmetleri> GetHomeCarePatientsByDateNQL(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EVDESAGLIKHIZMETLERI"].QueryDefs["GetHomeCarePatientsByDateNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<EvdeSaglikHizmetleri>(queryDef, paramList);
        }

        public bool? IsDeleted
        {
            get { return (bool?)this["ISDELETED"]; }
            set { this["ISDELETED"] = value; }
        }

    /// <summary>
    /// Hata Kodu
    /// </summary>
        public int? HataKodu
        {
            get { return (int?)this["HATAKODU"]; }
            set { this["HATAKODU"] = value; }
        }

    /// <summary>
    /// Hata Açıklaması
    /// </summary>
        public string HataAciklamasi
        {
            get { return (string)this["HATAACIKLAMASI"]; }
            set { this["HATAACIKLAMASI"] = value; }
        }

    /// <summary>
    /// Başvuran Telefon
    /// </summary>
        public long? BasvuranTel
        {
            get { return (long?)this["BASVURANTEL"]; }
            set { this["BASVURANTEL"] = value; }
        }

    /// <summary>
    /// Başvuran Ad
    /// </summary>
        public string BasvuranAd
        {
            get { return (string)this["BASVURANAD"]; }
            set { this["BASVURANAD"] = value; }
        }

    /// <summary>
    /// Başvuran Soyad
    /// </summary>
        public string BasvuranSoyad
        {
            get { return (string)this["BASVURANSOYAD"]; }
            set { this["BASVURANSOYAD"] = value; }
        }

    /// <summary>
    /// Başvuran TC
    /// </summary>
        public long? BasvuranTC
        {
            get { return (long?)this["BASVURANTC"]; }
            set { this["BASVURANTC"] = value; }
        }

    /// <summary>
    /// Başvuran Açıklaması
    /// </summary>
        public string BasvuranAciklamasi
        {
            get { return (string)this["BASVURANACIKLAMASI"]; }
            set { this["BASVURANACIKLAMASI"] = value; }
        }

    /// <summary>
    /// Alınan Notlar
    /// </summary>
        public string AlinanNotlar
        {
            get { return (string)this["ALINANNOTLAR"]; }
            set { this["ALINANNOTLAR"] = value; }
        }

        public TTSequence BasvuruID
        {
            get { return GetSequence("BASVURUID"); }
        }

    /// <summary>
    /// Hasta TC
    /// </summary>
        public long? HastaTC
        {
            get { return (long?)this["HASTATC"]; }
            set { this["HASTATC"] = value; }
        }

    /// <summary>
    /// Hasta Ad
    /// </summary>
        public string HastaAd
        {
            get { return (string)this["HASTAAD"]; }
            set { this["HASTAAD"] = value; }
        }

    /// <summary>
    /// Hasta Soyad
    /// </summary>
        public string HastaSoyad
        {
            get { return (string)this["HASTASOYAD"]; }
            set { this["HASTASOYAD"] = value; }
        }

    /// <summary>
    /// Hasta Adres
    /// </summary>
        public string HastaAdres
        {
            get { return (string)this["HASTAADRES"]; }
            set { this["HASTAADRES"] = value; }
        }

    /// <summary>
    /// Hizmet Emri Tarihi
    /// </summary>
        public DateTime? HizmetEmriTarihi
        {
            get { return (DateTime?)this["HIZMETEMRITARIHI"]; }
            set { this["HIZMETEMRITARIHI"] = value; }
        }

        public ResUser ResponsibleDoctor
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESPONSIBLEDOCTOR"); }
            set { this["RESPONSIBLEDOCTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected EvdeSaglikHizmetleri(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected EvdeSaglikHizmetleri(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected EvdeSaglikHizmetleri(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected EvdeSaglikHizmetleri(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected EvdeSaglikHizmetleri(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EVDESAGLIKHIZMETLERI", dataRow) { }
        protected EvdeSaglikHizmetleri(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EVDESAGLIKHIZMETLERI", dataRow, isImported) { }
        public EvdeSaglikHizmetleri(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public EvdeSaglikHizmetleri(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public EvdeSaglikHizmetleri() : base() { }

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