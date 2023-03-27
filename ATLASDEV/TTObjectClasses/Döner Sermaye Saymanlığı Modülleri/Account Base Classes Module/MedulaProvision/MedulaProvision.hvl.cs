
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MedulaProvision")] 

    /// <summary>
    /// Medula Takip 
    /// </summary>
    public  partial class MedulaProvision : TTObject
    {
        public class MedulaProvisionList : TTObjectCollection<MedulaProvision> { }
                    
        public class ChildMedulaProvisionCollection : TTObject.TTChildObjectCollection<MedulaProvision>
        {
            public ChildMedulaProvisionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMedulaProvisionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid New { get { return new Guid("f0f051d1-0e02-496c-9494-4aafd2a35a9d"); } }
            public static Guid Cancelled { get { return new Guid("896b5f0b-ac66-4eb3-bfe0-4a754e80d1c8"); } }
        }

        public static BindingList<MedulaProvision> GetMedulaProvisionsByApplicationNo(TTObjectContext objectContext, string APPLICATIONNO)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDULAPROVISION"].QueryDefs["GetMedulaProvisionsByApplicationNo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("APPLICATIONNO", APPLICATIONNO);

            return ((ITTQuery)objectContext).QueryObjects<MedulaProvision>(queryDef, paramList);
        }

    /// <summary>
    /// Son Güncellenme Tarihi
    /// </summary>
        public DateTime? UpDateLast
        {
            get { return (DateTime?)this["UPDATELAST"]; }
            set { this["UPDATELAST"] = value; }
        }

    /// <summary>
    /// YUPASS ID
    /// </summary>
        public int? YUPASSID
        {
            get { return (int?)this["YUPASSID"]; }
            set { this["YUPASSID"] = value; }
        }

    /// <summary>
    /// Medula Takip No
    /// </summary>
        public string ProvisionNo
        {
            get { return (string)this["PROVISIONNO"]; }
            set { this["PROVISIONNO"] = value; }
        }

    /// <summary>
    /// Takip Tarihi
    /// </summary>
        public DateTime? ProvisionDate
        {
            get { return (DateTime?)this["PROVISIONDATE"]; }
            set { this["PROVISIONDATE"] = value; }
        }

    /// <summary>
    /// Durumu
    /// </summary>
        public MedulaSubEpisodeStatusEnum? Status
        {
            get { return (MedulaSubEpisodeStatusEnum?)(int?)this["STATUS"]; }
            set { this["STATUS"] = value; }
        }

    /// <summary>
    /// Donör TCKimlikNo
    /// </summary>
        public long? DonorUniqueRefno
        {
            get { return (long?)this["DONORUNIQUEREFNO"]; }
            set { this["DONORUNIQUEREFNO"] = value; }
        }

    /// <summary>
    /// Plaka No
    /// </summary>
        public string LicensePlateNo
        {
            get { return (string)this["LICENSEPLATENO"]; }
            set { this["LICENSEPLATENO"] = value; }
        }

    /// <summary>
    /// yesilKartSevkEdenTesisKodu
    /// </summary>
        public string GreenCardSendingFacilityCode
        {
            get { return (string)this["GREENCARDSENDINGFACILITYCODE"]; }
            set { this["GREENCARDSENDINGFACILITYCODE"] = value; }
        }

    /// <summary>
    /// İlişkili Medula Takip No
    /// </summary>
        public string RelatedProvisionNo
        {
            get { return (string)this["RELATEDPROVISIONNO"]; }
            set { this["RELATEDPROVISIONNO"] = value; }
        }

    /// <summary>
    /// Katılım Payından Muaf
    /// </summary>
        public string PatientParticipationInfo
        {
            get { return (string)this["PATIENTPARTICIPATIONINFO"]; }
            set { this["PATIENTPARTICIPATIONINFO"] = value; }
        }

    /// <summary>
    /// Kullanıcı Notu
    /// </summary>
        public string UserNote
        {
            get { return (string)this["USERNOTE"]; }
            set { this["USERNOTE"] = value; }
        }

    /// <summary>
    /// Sıra No
    /// </summary>
        public int? OrderNo
        {
            get { return (int?)this["ORDERNO"]; }
            set { this["ORDERNO"] = value; }
        }

    /// <summary>
    /// Sonuç Mesajı
    /// </summary>
        public string ResultMessage
        {
            get { return (string)this["RESULTMESSAGE"]; }
            set { this["RESULTMESSAGE"] = value; }
        }

    /// <summary>
    /// Sonuç Kodu
    /// </summary>
        public string ResultCode
        {
            get { return (string)this["RESULTCODE"]; }
            set { this["RESULTCODE"] = value; }
        }

    /// <summary>
    /// FaturaKayıt HizmetDetayDVO daki açıklama
    /// </summary>
        public string InvoiceDescription
        {
            get { return (string)this["INVOICEDESCRIPTION"]; }
            set { this["INVOICEDESCRIPTION"] = value; }
        }

    /// <summary>
    /// Meduladan Dönen Fatura Tutarı
    /// </summary>
        public Currency? InvoicePrice
        {
            get { return (Currency?)this["INVOICEPRICE"]; }
            set { this["INVOICEPRICE"] = value; }
        }

    /// <summary>
    /// Medula Başvuru Numarası
    /// </summary>
        public string ApplicationNo
        {
            get { return (string)this["APPLICATIONNO"]; }
            set { this["APPLICATIONNO"] = value; }
        }

        public SpecialityDefinition Brans
        {
            get { return (SpecialityDefinition)((ITTObject)this).GetParent("BRANS"); }
            set { this["BRANS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SigortaliTuru SigortaliTuru
        {
            get { return (SigortaliTuru)((ITTObject)this).GetParent("SIGORTALITURU"); }
            set { this["SIGORTALITURU"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DevredilenKurum DevredilenKurum
        {
            get { return (DevredilenKurum)((ITTObject)this).GetParent("DEVREDILENKURUM"); }
            set { this["DEVREDILENKURUM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ProvizyonTipi ProvizyonTipi
        {
            get { return (ProvizyonTipi)((ITTObject)this).GetParent("PROVIZYONTIPI"); }
            set { this["PROVIZYONTIPI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public TakipTipi TakipTipi
        {
            get { return (TakipTipi)((ITTObject)this).GetParent("TAKIPTIPI"); }
            set { this["TAKIPTIPI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public TedaviTuru TedaviTuru
        {
            get { return (TedaviTuru)((ITTObject)this).GetParent("TEDAVITURU"); }
            set { this["TEDAVITURU"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public TedaviTipi TedaviTipi
        {
            get { return (TedaviTipi)((ITTObject)this).GetParent("TEDAVITIPI"); }
            set { this["TEDAVITIPI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public OzelDurum OzelDurum
        {
            get { return (OzelDurum)((ITTObject)this).GetParent("OZELDURUM"); }
            set { this["OZELDURUM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// FaturaKayıt HizmetDetayDVO daki taburcuKodu
    /// </summary>
        public TaburcuKodu TaburcuKodu
        {
            get { return (TaburcuKodu)((ITTObject)this).GetParent("TABURCUKODU"); }
            set { this["TABURCUKODU"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public IstisnaiHal IstisnaiHal
        {
            get { return (IstisnaiHal)((ITTObject)this).GetParent("ISTISNAIHAL"); }
            set { this["ISTISNAIHAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MedulaProvision(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MedulaProvision(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MedulaProvision(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MedulaProvision(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MedulaProvision(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MEDULAPROVISION", dataRow) { }
        protected MedulaProvision(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MEDULAPROVISION", dataRow, isImported) { }
        public MedulaProvision(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MedulaProvision(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MedulaProvision() : base() { }

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