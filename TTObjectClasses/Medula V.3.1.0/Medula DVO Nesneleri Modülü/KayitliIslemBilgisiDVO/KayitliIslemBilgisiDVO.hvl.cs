
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="KayitliIslemBilgisiDVO")] 

    public  partial class KayitliIslemBilgisiDVO : BaseMedulaObject
    {
        public class KayitliIslemBilgisiDVOList : TTObjectCollection<KayitliIslemBilgisiDVO> { }
                    
        public class ChildKayitliIslemBilgisiDVOCollection : TTObject.TTChildObjectCollection<KayitliIslemBilgisiDVO>
        {
            public ChildKayitliIslemBilgisiDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildKayitliIslemBilgisiDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// İşlem Sıra Numarası
    /// </summary>
        public string islemSiraNo
        {
            get { return (string)this["ISLEMSIRANO"]; }
            set { this["ISLEMSIRANO"] = value; }
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
    /// Hizmet Kayıt Cevap-islemBilgileri
    /// </summary>
        public HizmetKayitCevapDVO HizmetKayitCevapDVO
        {
            get { return (HizmetKayitCevapDVO)((ITTObject)this).GetParent("HIZMETKAYITCEVAPDVO"); }
            set { this["HIZMETKAYITCEVAPDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected KayitliIslemBilgisiDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected KayitliIslemBilgisiDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected KayitliIslemBilgisiDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected KayitliIslemBilgisiDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected KayitliIslemBilgisiDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "KAYITLIISLEMBILGISIDVO", dataRow) { }
        protected KayitliIslemBilgisiDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "KAYITLIISLEMBILGISIDVO", dataRow, isImported) { }
        public KayitliIslemBilgisiDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public KayitliIslemBilgisiDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public KayitliIslemBilgisiDVO() : base() { }

    }
}