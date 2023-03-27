
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HizmetKayitCevapDVO")] 

    public  partial class HizmetKayitCevapDVO : BaseMedulaCevap
    {
        public class HizmetKayitCevapDVOList : TTObjectCollection<HizmetKayitCevapDVO> { }
                    
        public class ChildHizmetKayitCevapDVOCollection : TTObject.TTChildObjectCollection<HizmetKayitCevapDVO>
        {
            public ChildHizmetKayitCevapDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHizmetKayitCevapDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Takip Numarası
    /// </summary>
        public string takipNo
        {
            get { return (string)this["TAKIPNO"]; }
            set { this["TAKIPNO"] = value; }
        }

    /// <summary>
    /// Hastanın Başvuru Numarası
    /// </summary>
        public string hastaBasvuruNo
        {
            get { return (string)this["HASTABASVURUNO"]; }
            set { this["HASTABASVURUNO"] = value; }
        }

    /// <summary>
    /// Tesis Kodu
    /// </summary>
        public int? saglikTesisKodu
        {
            get { return (int?)this["SAGLIKTESISKODU"]; }
            set { this["SAGLIKTESISKODU"] = value; }
        }

        virtual protected void CreatehataliKayitlarCollection()
        {
            _hataliKayitlar = new HataliIslemBilgisiDVO.ChildHataliIslemBilgisiDVOCollection(this, new Guid("371a7612-3b6a-487c-a31a-831bc645ccbd"));
            ((ITTChildObjectCollection)_hataliKayitlar).GetChildren();
        }

        protected HataliIslemBilgisiDVO.ChildHataliIslemBilgisiDVOCollection _hataliKayitlar = null;
    /// <summary>
    /// Child collection for Hizmet Kayıt Cevap-Hatalı Kayıtlar
    /// </summary>
        public HataliIslemBilgisiDVO.ChildHataliIslemBilgisiDVOCollection hataliKayitlar
        {
            get
            {
                if (_hataliKayitlar == null)
                    CreatehataliKayitlarCollection();
                return _hataliKayitlar;
            }
        }

        virtual protected void CreateislemBilgileriCollection()
        {
            _islemBilgileri = new KayitliIslemBilgisiDVO.ChildKayitliIslemBilgisiDVOCollection(this, new Guid("42699df0-20cf-4cec-8a05-e508fb6d5a38"));
            ((ITTChildObjectCollection)_islemBilgileri).GetChildren();
        }

        protected KayitliIslemBilgisiDVO.ChildKayitliIslemBilgisiDVOCollection _islemBilgileri = null;
    /// <summary>
    /// Child collection for Hizmet Kayıt Cevap-islemBilgileri
    /// </summary>
        public KayitliIslemBilgisiDVO.ChildKayitliIslemBilgisiDVOCollection islemBilgileri
        {
            get
            {
                if (_islemBilgileri == null)
                    CreateislemBilgileriCollection();
                return _islemBilgileri;
            }
        }

        protected HizmetKayitCevapDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HizmetKayitCevapDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HizmetKayitCevapDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HizmetKayitCevapDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HizmetKayitCevapDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HIZMETKAYITCEVAPDVO", dataRow) { }
        protected HizmetKayitCevapDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HIZMETKAYITCEVAPDVO", dataRow, isImported) { }
        public HizmetKayitCevapDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HizmetKayitCevapDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HizmetKayitCevapDVO() : base() { }

    }
}