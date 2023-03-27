
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TahlilBilgisiDVO")] 

    public  partial class TahlilBilgisiDVO : BaseHizmetKayitDVO
    {
        public class TahlilBilgisiDVOList : TTObjectCollection<TahlilBilgisiDVO> { }
                    
        public class ChildTahlilBilgisiDVOCollection : TTObject.TTChildObjectCollection<TahlilBilgisiDVO>
        {
            public ChildTahlilBilgisiDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTahlilBilgisiDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Branş Kodu
    /// </summary>
        public string bransKodu
        {
            get { return (string)this["BRANSKODU"]; }
            set { this["BRANSKODU"] = value; }
        }

    /// <summary>
    /// SUT Kodu
    /// </summary>
        public string sutKodu
        {
            get { return (string)this["SUTKODU"]; }
            set { this["SUTKODU"] = value; }
        }

    /// <summary>
    /// Doktor Tescil No
    /// </summary>
        public string drTescilNo
        {
            get { return (string)this["DRTESCILNO"]; }
            set { this["DRTESCILNO"] = value; }
        }

    /// <summary>
    /// İşlem Tarihi
    /// </summary>
        public string islemTarihi
        {
            get { return (string)this["ISLEMTARIHI"]; }
            set { this["ISLEMTARIHI"] = value; }
        }

    /// <summary>
    /// Adet
    /// </summary>
        public int? adet
        {
            get { return (int?)this["ADET"]; }
            set { this["ADET"] = value; }
        }

    /// <summary>
    /// Hizmet-Tahlil Bilgileri
    /// </summary>
        public HizmetDVO HizmetDVO
        {
            get { return (HizmetDVO)((ITTObject)this).GetParent("HIZMETDVO"); }
            set { this["HIZMETDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Hizmet Kayıt Giriş-Tahlil Bilgileri
    /// </summary>
        public HizmetKayitGirisDVO HizmetKayitGirisDVO
        {
            get { return (HizmetKayitGirisDVO)((ITTObject)this).GetParent("HIZMETKAYITGIRISDVO"); }
            set { this["HIZMETKAYITGIRISDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected TahlilBilgisiDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TahlilBilgisiDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TahlilBilgisiDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TahlilBilgisiDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TahlilBilgisiDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TAHLILBILGISIDVO", dataRow) { }
        protected TahlilBilgisiDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TAHLILBILGISIDVO", dataRow, isImported) { }
        public TahlilBilgisiDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TahlilBilgisiDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TahlilBilgisiDVO() : base() { }

    }
}