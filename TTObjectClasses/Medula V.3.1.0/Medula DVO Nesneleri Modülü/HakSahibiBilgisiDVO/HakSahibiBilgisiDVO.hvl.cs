
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HakSahibiBilgisiDVO")] 

    public  partial class HakSahibiBilgisiDVO : BaseMedulaObject
    {
        public class HakSahibiBilgisiDVOList : TTObjectCollection<HakSahibiBilgisiDVO> { }
                    
        public class ChildHakSahibiBilgisiDVOCollection : TTObject.TTChildObjectCollection<HakSahibiBilgisiDVO>
        {
            public ChildHakSahibiBilgisiDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHakSahibiBilgisiDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public string provizyonTarihi
        {
            get { return (string)this["PROVIZYONTARIHI"]; }
            set { this["PROVIZYONTARIHI"] = value; }
        }

        public string adi
        {
            get { return (string)this["ADI"]; }
            set { this["ADI"] = value; }
        }

        public string soyadi
        {
            get { return (string)this["SOYADI"]; }
            set { this["SOYADI"] = value; }
        }

        public string tckimlikNo
        {
            get { return (string)this["TCKIMLIKNO"]; }
            set { this["TCKIMLIKNO"] = value; }
        }

        public string karneNo
        {
            get { return (string)this["KARNENO"]; }
            set { this["KARNENO"] = value; }
        }

        public string sosyalGuvenlikNo
        {
            get { return (string)this["SOSYALGUVENLIKNO"]; }
            set { this["SOSYALGUVENLIKNO"] = value; }
        }

        public string yakinlikKodu
        {
            get { return (string)this["YAKINLIKKODU"]; }
            set { this["YAKINLIKKODU"] = value; }
        }

        public string sigortaliTuru
        {
            get { return (string)this["SIGORTALITURU"]; }
            set { this["SIGORTALITURU"] = value; }
        }

        public string devredilenKurum
        {
            get { return (string)this["DEVREDILENKURUM"]; }
            set { this["DEVREDILENKURUM"] = value; }
        }

        public string provizyonTipi
        {
            get { return (string)this["PROVIZYONTIPI"]; }
            set { this["PROVIZYONTIPI"] = value; }
        }

        protected HakSahibiBilgisiDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HakSahibiBilgisiDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HakSahibiBilgisiDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HakSahibiBilgisiDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HakSahibiBilgisiDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HAKSAHIBIBILGISIDVO", dataRow) { }
        protected HakSahibiBilgisiDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HAKSAHIBIBILGISIDVO", dataRow, isImported) { }
        public HakSahibiBilgisiDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HakSahibiBilgisiDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HakSahibiBilgisiDVO() : base() { }

    }
}