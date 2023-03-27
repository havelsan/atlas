
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MNZFirm")] 

    /// <summary>
    /// DE_Firma Tanımı
    /// </summary>
    public  partial class MNZFirm : MNZActor
    {
        public class MNZFirmList : TTObjectCollection<MNZFirm> { }
                    
        public class ChildMNZFirmCollection : TTObject.TTChildObjectCollection<MNZFirm>
        {
            public ChildMNZFirmCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMNZFirmCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Firma Girişi Tamamlandı
    /// </summary>
            public static Guid Complete { get { return new Guid("6c395ed9-9472-4af9-87cb-472ed6977630"); } }
    /// <summary>
    /// Yeni Firma Girişi
    /// </summary>
            public static Guid New { get { return new Guid("30e09f63-00e5-4c8e-8c29-e556d2808b16"); } }
        }

    /// <summary>
    /// Sorumlu Kişi Ünvanı
    /// </summary>
        public string LiablePersonTitle
        {
            get { return (string)this["LIABLEPERSONTITLE"]; }
            set { this["LIABLEPERSONTITLE"] = value; }
        }

    /// <summary>
    /// Ticaret Sicil No
    /// </summary>
        public string RegistryNo
        {
            get { return (string)this["REGISTRYNO"]; }
            set { this["REGISTRYNO"] = value; }
        }

    /// <summary>
    /// Adres Satırı 1
    /// </summary>
        public string AddressLine1
        {
            get { return (string)this["ADDRESSLINE1"]; }
            set { this["ADDRESSLINE1"] = value; }
        }

    /// <summary>
    /// Adres Satırı 2
    /// </summary>
        public string AddressLine2
        {
            get { return (string)this["ADDRESSLINE2"]; }
            set { this["ADDRESSLINE2"] = value; }
        }

    /// <summary>
    /// Fax Numarası
    /// </summary>
        public string FaxNumber
        {
            get { return (string)this["FAXNUMBER"]; }
            set { this["FAXNUMBER"] = value; }
        }

    /// <summary>
    /// Sorumlu Kişi
    /// </summary>
        public string LiablePerson
        {
            get { return (string)this["LIABLEPERSON"]; }
            set { this["LIABLEPERSON"] = value; }
        }

    /// <summary>
    /// Bitiş Günü
    /// </summary>
        public DateTime? EndDate
        {
            get { return (DateTime?)this["ENDDATE"]; }
            set { this["ENDDATE"] = value; }
        }

    /// <summary>
    /// Firma Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Başlangıç Günü
    /// </summary>
        public DateTime? StartDate
        {
            get { return (DateTime?)this["STARTDATE"]; }
            set { this["STARTDATE"] = value; }
        }

    /// <summary>
    /// Telefon Numarası
    /// </summary>
        public string PhoneNumber
        {
            get { return (string)this["PHONENUMBER"]; }
            set { this["PHONENUMBER"] = value; }
        }

    /// <summary>
    /// Firma Unvanı
    /// </summary>
        public string Title
        {
            get { return (string)this["TITLE"]; }
            set { this["TITLE"] = value; }
        }

    /// <summary>
    /// Ili
    /// </summary>
        public City City
        {
            get { return (City)((ITTObject)this).GetParent("CITY"); }
            set { this["CITY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İlçesi
    /// </summary>
        public TownDefinitions Town
        {
            get { return (TownDefinitions)((ITTObject)this).GetParent("TOWN"); }
            set { this["TOWN"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateAllowedPeriodCollection()
        {
            _AllowedPeriod = new MNZAllowedPeriod.ChildMNZAllowedPeriodCollection(this, new Guid("0b56ad9b-f23b-411d-899f-53b834f0ddb3"));
            ((ITTChildObjectCollection)_AllowedPeriod).GetChildren();
        }

        protected MNZAllowedPeriod.ChildMNZAllowedPeriodCollection _AllowedPeriod = null;
    /// <summary>
    /// Child collection for Fimanın İzin Günleri
    /// </summary>
        public MNZAllowedPeriod.ChildMNZAllowedPeriodCollection AllowedPeriod
        {
            get
            {
                if (_AllowedPeriod == null)
                    CreateAllowedPeriodCollection();
                return _AllowedPeriod;
            }
        }

        protected MNZFirm(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MNZFirm(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MNZFirm(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MNZFirm(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MNZFirm(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MNZFIRM", dataRow) { }
        protected MNZFirm(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MNZFIRM", dataRow, isImported) { }
        public MNZFirm(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MNZFirm(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MNZFirm() : base() { }

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