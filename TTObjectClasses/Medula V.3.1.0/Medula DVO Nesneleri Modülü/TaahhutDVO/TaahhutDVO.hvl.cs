
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TaahhutDVO")] 

    public  partial class TaahhutDVO : BaseMedulaObject
    {
        public class TaahhutDVOList : TTObjectCollection<TaahhutDVO> { }
                    
        public class ChildTaahhutDVOCollection : TTObject.TTChildObjectCollection<TaahhutDVO>
        {
            public ChildTaahhutDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTaahhutDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public string adressCaddeSokak
        {
            get { return (string)this["ADRESSCADDESOKAK"]; }
            set { this["ADRESSCADDESOKAK"] = value; }
        }

        public string adressDisKapiNo
        {
            get { return (string)this["ADRESSDISKAPINO"]; }
            set { this["ADRESSDISKAPINO"] = value; }
        }

        public string adressEposta
        {
            get { return (string)this["ADRESSEPOSTA"]; }
            set { this["ADRESSEPOSTA"] = value; }
        }

        public string adressIcKapiNo
        {
            get { return (string)this["ADRESSICKAPINO"]; }
            set { this["ADRESSICKAPINO"] = value; }
        }

        public string adressIlce
        {
            get { return (string)this["ADRESSILCE"]; }
            set { this["ADRESSILCE"] = value; }
        }

        public int? adressIlPlaka
        {
            get { return (int?)this["ADRESSILPLAKA"]; }
            set { this["ADRESSILPLAKA"] = value; }
        }

        public string adressPostaKodu
        {
            get { return (string)this["ADRESSPOSTAKODU"]; }
            set { this["ADRESSPOSTAKODU"] = value; }
        }

        public string adressTelefon
        {
            get { return (string)this["ADRESSTELEFON"]; }
            set { this["ADRESSTELEFON"] = value; }
        }

        public string hastaTCKimlikNo
        {
            get { return (string)this["HASTATCKIMLIKNO"]; }
            set { this["HASTATCKIMLIKNO"] = value; }
        }

        public string taahhutAlanAd
        {
            get { return (string)this["TAAHHUTALANAD"]; }
            set { this["TAAHHUTALANAD"] = value; }
        }

        public string taahhutAlanSoyad
        {
            get { return (string)this["TAAHHUTALANSOYAD"]; }
            set { this["TAAHHUTALANSOYAD"] = value; }
        }

        public Il IlTTObject
        {
            get { return (Il)((ITTObject)this).GetParent("ILTTOBJECT"); }
            set { this["ILTTOBJECT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Ilce IlceTTObject
        {
            get { return (Ilce)((ITTObject)this).GetParent("ILCETTOBJECT"); }
            set { this["ILCETTOBJECT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected TaahhutDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TaahhutDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TaahhutDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TaahhutDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TaahhutDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TAAHHUTDVO", dataRow) { }
        protected TaahhutDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TAAHHUTDVO", dataRow, isImported) { }
        public TaahhutDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TaahhutDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TaahhutDVO() : base() { }

    }
}