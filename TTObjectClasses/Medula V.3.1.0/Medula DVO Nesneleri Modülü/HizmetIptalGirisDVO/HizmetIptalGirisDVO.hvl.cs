
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HizmetIptalGirisDVO")] 

    public  partial class HizmetIptalGirisDVO : BaseMedulaObject
    {
        public class HizmetIptalGirisDVOList : TTObjectCollection<HizmetIptalGirisDVO> { }
                    
        public class ChildHizmetIptalGirisDVOCollection : TTObject.TTChildObjectCollection<HizmetIptalGirisDVO>
        {
            public ChildHizmetIptalGirisDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHizmetIptalGirisDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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
    /// Tesis Kodu
    /// </summary>
        public int? saglikTesisKodu
        {
            get { return (int?)this["SAGLIKTESISKODU"]; }
            set { this["SAGLIKTESISKODU"] = value; }
        }

    /// <summary>
    /// Hizmet İptal Cevap
    /// </summary>
        public HizmetIptalCevapDVO hizmetIptalCevapDVO
        {
            get { return (HizmetIptalCevapDVO)((ITTObject)this).GetParent("HIZMETIPTALCEVAPDVO"); }
            set { this["HIZMETIPTALCEVAPDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreatehizmetSunucuRefNoDVOsCollection()
        {
            _hizmetSunucuRefNoDVOs = new HizmetSunucuRefNoDVO.ChildHizmetSunucuRefNoDVOCollection(this, new Guid("024a0c2e-7ac6-46b2-af17-88b07c9e3ce2"));
            ((ITTChildObjectCollection)_hizmetSunucuRefNoDVOs).GetChildren();
        }

        protected HizmetSunucuRefNoDVO.ChildHizmetSunucuRefNoDVOCollection _hizmetSunucuRefNoDVOs = null;
    /// <summary>
    /// Child collection for Hizmet İptal Giriş-Hizmet Sunucu Ref Nolar
    /// </summary>
        public HizmetSunucuRefNoDVO.ChildHizmetSunucuRefNoDVOCollection hizmetSunucuRefNoDVOs
        {
            get
            {
                if (_hizmetSunucuRefNoDVOs == null)
                    CreatehizmetSunucuRefNoDVOsCollection();
                return _hizmetSunucuRefNoDVOs;
            }
        }

        virtual protected void CreateislemSiraNumarasiDVOsCollection()
        {
            _islemSiraNumarasiDVOs = new IslemSiraNoDVO.ChildIslemSiraNoDVOCollection(this, new Guid("ff5ebff6-6759-40ac-ae7b-19e6a7dcd386"));
            ((ITTChildObjectCollection)_islemSiraNumarasiDVOs).GetChildren();
        }

        protected IslemSiraNoDVO.ChildIslemSiraNoDVOCollection _islemSiraNumarasiDVOs = null;
    /// <summary>
    /// Child collection for Hizmet İptal Giriş-İşlem Sıra Numaraları
    /// </summary>
        public IslemSiraNoDVO.ChildIslemSiraNoDVOCollection islemSiraNumarasiDVOs
        {
            get
            {
                if (_islemSiraNumarasiDVOs == null)
                    CreateislemSiraNumarasiDVOsCollection();
                return _islemSiraNumarasiDVOs;
            }
        }

        protected HizmetIptalGirisDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HizmetIptalGirisDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HizmetIptalGirisDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HizmetIptalGirisDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HizmetIptalGirisDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HIZMETIPTALGIRISDVO", dataRow) { }
        protected HizmetIptalGirisDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HIZMETIPTALGIRISDVO", dataRow, isImported) { }
        public HizmetIptalGirisDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HizmetIptalGirisDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HizmetIptalGirisDVO() : base() { }

    }
}