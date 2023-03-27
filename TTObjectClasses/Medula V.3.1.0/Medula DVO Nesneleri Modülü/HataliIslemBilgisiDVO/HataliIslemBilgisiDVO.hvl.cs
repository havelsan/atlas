
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HataliIslemBilgisiDVO")] 

    public  partial class HataliIslemBilgisiDVO : BaseMedulaObject
    {
        public class HataliIslemBilgisiDVOList : TTObjectCollection<HataliIslemBilgisiDVO> { }
                    
        public class ChildHataliIslemBilgisiDVOCollection : TTObject.TTChildObjectCollection<HataliIslemBilgisiDVO>
        {
            public ChildHataliIslemBilgisiDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHataliIslemBilgisiDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Hizmet Sunucu Referans Numarası
    /// </summary>
        public string hizmetSunucuRefNo
        {
            get { return (string)this["HIZMETSUNUCUREFNO"]; }
            set { this["HIZMETSUNUCUREFNO"] = value; }
        }

    /// <summary>
    /// Hata Kodu
    /// </summary>
        public string hataKodu
        {
            get { return (string)this["HATAKODU"]; }
            set { this["HATAKODU"] = value; }
        }

    /// <summary>
    /// Hata Mesajı
    /// </summary>
        public string hataMesaji
        {
            get { return (string)this["HATAMESAJI"]; }
            set { this["HATAMESAJI"] = value; }
        }

    /// <summary>
    /// Hizmet Kayıt Cevap-Hatalı Kayıtlar
    /// </summary>
        public HizmetKayitCevapDVO HizmetKayitCevapDVO
        {
            get { return (HizmetKayitCevapDVO)((ITTObject)this).GetParent("HIZMETKAYITCEVAPDVO"); }
            set { this["HIZMETKAYITCEVAPDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Önceki İşlem Bilgisi
    /// </summary>
        public OncekiIslemBilgisiDVO oncekiIslemBilgisi
        {
            get { return (OncekiIslemBilgisiDVO)((ITTObject)this).GetParent("ONCEKIISLEMBILGISI"); }
            set { this["ONCEKIISLEMBILGISI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected HataliIslemBilgisiDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HataliIslemBilgisiDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HataliIslemBilgisiDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HataliIslemBilgisiDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HataliIslemBilgisiDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HATALIISLEMBILGISIDVO", dataRow) { }
        protected HataliIslemBilgisiDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HATALIISLEMBILGISIDVO", dataRow, isImported) { }
        public HataliIslemBilgisiDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HataliIslemBilgisiDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HataliIslemBilgisiDVO() : base() { }

    }
}