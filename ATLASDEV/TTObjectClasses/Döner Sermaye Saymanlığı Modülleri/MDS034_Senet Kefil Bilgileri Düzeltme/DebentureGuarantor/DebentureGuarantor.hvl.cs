
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DebentureGuarantor")] 

    /// <summary>
    /// Kefil Bilgisi
    /// </summary>
    public  partial class DebentureGuarantor : TTObject
    {
        public class DebentureGuarantorList : TTObjectCollection<DebentureGuarantor> { }
                    
        public class ChildDebentureGuarantorCollection : TTObject.TTChildObjectCollection<DebentureGuarantor>
        {
            public ChildDebentureGuarantorCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDebentureGuarantorCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Cilt No
    /// </summary>
        public string VolumeNo
        {
            get { return (string)this["VOLUMENO"]; }
            set { this["VOLUMENO"] = value; }
        }

    /// <summary>
    /// Baba Adı
    /// </summary>
        public string FatherName
        {
            get { return (string)this["FATHERNAME"]; }
            set { this["FATHERNAME"] = value; }
        }

    /// <summary>
    /// Ev Telefonu
    /// </summary>
        public string HomePhone
        {
            get { return (string)this["HOMEPHONE"]; }
            set { this["HOMEPHONE"] = value; }
        }

    /// <summary>
    /// İş Telefonu
    /// </summary>
        public string WorkPhone
        {
            get { return (string)this["WORKPHONE"]; }
            set { this["WORKPHONE"] = value; }
        }

    /// <summary>
    /// Ev Adresi
    /// </summary>
        public string HomeAddress
        {
            get { return (string)this["HOMEADDRESS"]; }
            set { this["HOMEADDRESS"] = value; }
        }

    /// <summary>
    /// Kayıtlı Olduğu Mahalle/Köy
    /// </summary>
        public string VillageOfRegistry
        {
            get { return (string)this["VILLAGEOFREGISTRY"]; }
            set { this["VILLAGEOFREGISTRY"] = value; }
        }

    /// <summary>
    /// Sayfa No
    /// </summary>
        public string PageNo
        {
            get { return (string)this["PAGENO"]; }
            set { this["PAGENO"] = value; }
        }

    /// <summary>
    /// İş Adresi
    /// </summary>
        public string WorkAddress
        {
            get { return (string)this["WORKADDRESS"]; }
            set { this["WORKADDRESS"] = value; }
        }

    /// <summary>
    /// Ad
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Aile Sıra No
    /// </summary>
        public string FamilyOrderNo
        {
            get { return (string)this["FAMILYORDERNO"]; }
            set { this["FAMILYORDERNO"] = value; }
        }

    /// <summary>
    /// Doğum Tarihi
    /// </summary>
        public DateTime? BirthDate
        {
            get { return (DateTime?)this["BIRTHDATE"]; }
            set { this["BIRTHDATE"] = value; }
        }

    /// <summary>
    /// TC Kimlik No
    /// </summary>
        public string UniqueRefNo
        {
            get { return (string)this["UNIQUEREFNO"]; }
            set { this["UNIQUEREFNO"] = value; }
        }

    /// <summary>
    /// Doğum Yeri
    /// </summary>
        public City CityOfBirth
        {
            get { return (City)((ITTObject)this).GetParent("CITYOFBIRTH"); }
            set { this["CITYOFBIRTH"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Nüfusa Kayıtlı Olduğu İl
    /// </summary>
        public City CityOfRegistry
        {
            get { return (City)((ITTObject)this).GetParent("CITYOFREGISTRY"); }
            set { this["CITYOFREGISTRY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Nüfusa Kayıtlı Olduğu İlçe
    /// </summary>
        public TownDefinitions TownOfRegistry
        {
            get { return (TownDefinitions)((ITTObject)this).GetParent("TOWNOFREGISTRY"); }
            set { this["TOWNOFREGISTRY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateDebenturesCollection()
        {
            _Debentures = new Debenture.ChildDebentureCollection(this, new Guid("d3023ce1-ef00-4270-b496-92cc2a27fc5f"));
            ((ITTChildObjectCollection)_Debentures).GetChildren();
        }

        protected Debenture.ChildDebentureCollection _Debentures = null;
    /// <summary>
    /// Child collection for Garantöre ilişki
    /// </summary>
        public Debenture.ChildDebentureCollection Debentures
        {
            get
            {
                if (_Debentures == null)
                    CreateDebenturesCollection();
                return _Debentures;
            }
        }

        protected DebentureGuarantor(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DebentureGuarantor(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DebentureGuarantor(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DebentureGuarantor(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DebentureGuarantor(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DEBENTUREGUARANTOR", dataRow) { }
        protected DebentureGuarantor(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DEBENTUREGUARANTOR", dataRow, isImported) { }
        public DebentureGuarantor(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DebentureGuarantor(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DebentureGuarantor() : base() { }

    }
}