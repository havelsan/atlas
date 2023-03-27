
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HizmetOkuGirisDVO")] 

    public  partial class HizmetOkuGirisDVO : BaseMedulaObject
    {
        public class HizmetOkuGirisDVOList : TTObjectCollection<HizmetOkuGirisDVO> { }
                    
        public class ChildHizmetOkuGirisDVOCollection : TTObject.TTChildObjectCollection<HizmetOkuGirisDVO>
        {
            public ChildHizmetOkuGirisDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHizmetOkuGirisDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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
    /// Takip Numarası
    /// </summary>
        public string takipNo
        {
            get { return (string)this["TAKIPNO"]; }
            set { this["TAKIPNO"] = value; }
        }

        public HizmetOkuCevapDVO hizmetOkuCevapDVO
        {
            get { return (HizmetOkuCevapDVO)((ITTObject)this).GetParent("HIZMETOKUCEVAPDVO"); }
            set { this["HIZMETOKUCEVAPDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateislemSiraNumarasiDVOsCollection()
        {
            _islemSiraNumarasiDVOs = new IslemSiraNoDVO.ChildIslemSiraNoDVOCollection(this, new Guid("13ff8e31-8b29-422c-adbd-e35968ddbee7"));
            ((ITTChildObjectCollection)_islemSiraNumarasiDVOs).GetChildren();
        }

        protected IslemSiraNoDVO.ChildIslemSiraNoDVOCollection _islemSiraNumarasiDVOs = null;
    /// <summary>
    /// Child collection for Hizmet Oku Giriş-İşlem Sıra Numaraları
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

        virtual protected void CreatehizmetSunucuRefNoDVOsCollection()
        {
            _hizmetSunucuRefNoDVOs = new HizmetSunucuRefNoDVO.ChildHizmetSunucuRefNoDVOCollection(this, new Guid("6211b45a-b771-47ba-bd30-190e716b3cc2"));
            ((ITTChildObjectCollection)_hizmetSunucuRefNoDVOs).GetChildren();
        }

        protected HizmetSunucuRefNoDVO.ChildHizmetSunucuRefNoDVOCollection _hizmetSunucuRefNoDVOs = null;
    /// <summary>
    /// Child collection for Hizmet Oku Giriş-Hizmet Sunucu Ref Nolar
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

        protected HizmetOkuGirisDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HizmetOkuGirisDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HizmetOkuGirisDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HizmetOkuGirisDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HizmetOkuGirisDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HIZMETOKUGIRISDVO", dataRow) { }
        protected HizmetOkuGirisDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HIZMETOKUGIRISDVO", dataRow, isImported) { }
        public HizmetOkuGirisDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HizmetOkuGirisDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HizmetOkuGirisDVO() : base() { }

    }
}