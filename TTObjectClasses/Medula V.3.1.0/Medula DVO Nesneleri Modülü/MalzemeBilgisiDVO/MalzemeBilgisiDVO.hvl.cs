
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MalzemeBilgisiDVO")] 

    public  partial class MalzemeBilgisiDVO : BaseHizmetKayitDVO
    {
        public class MalzemeBilgisiDVOList : TTObjectCollection<MalzemeBilgisiDVO> { }
                    
        public class ChildMalzemeBilgisiDVOCollection : TTObject.TTChildObjectCollection<MalzemeBilgisiDVO>
        {
            public ChildMalzemeBilgisiDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMalzemeBilgisiDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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
        public double? adet
        {
            get { return (double?)this["ADET"]; }
            set { this["ADET"] = value; }
        }

    /// <summary>
    /// UBB Malzeme Barkod Bilgisi
    /// </summary>
        public string barkod
        {
            get { return (string)this["BARKOD"]; }
            set { this["BARKOD"] = value; }
        }

    /// <summary>
    /// Kodsuz Malzemenin Fiyatı
    /// </summary>
        public double? kodsuzMalzemeFiyati
        {
            get { return (double?)this["KODSUZMALZEMEFIYATI"]; }
            set { this["KODSUZMALZEMEFIYATI"] = value; }
        }

    /// <summary>
    /// Malzemenin Türü
    /// </summary>
        public string malzemeTuru
        {
            get { return (string)this["MALZEMETURU"]; }
            set { this["MALZEMETURU"] = value; }
        }

    /// <summary>
    /// Paket Hariç Bilgisi
    /// </summary>
        public string paketHaric
        {
            get { return (string)this["PAKETHARIC"]; }
            set { this["PAKETHARIC"] = value; }
        }

    /// <summary>
    /// Kodsuz Malzemenin Adı
    /// </summary>
        public string kodsuzMalzemeAdi
        {
            get { return (string)this["KODSUZMALZEMEADI"]; }
            set { this["KODSUZMALZEMEADI"] = value; }
        }

    /// <summary>
    /// Malzemenin Kodu
    /// </summary>
        public string malzemeKodu
        {
            get { return (string)this["MALZEMEKODU"]; }
            set { this["MALZEMEKODU"] = value; }
        }

    /// <summary>
    /// Katkı Payı Bilgisi
    /// </summary>
        public string katkiPayi
        {
            get { return (string)this["KATKIPAYI"]; }
            set { this["KATKIPAYI"] = value; }
        }

    /// <summary>
    /// Hizmet-Malzeme Bilgileri
    /// </summary>
        public HizmetDVO HizmetDVO
        {
            get { return (HizmetDVO)((ITTObject)this).GetParent("HIZMETDVO"); }
            set { this["HIZMETDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Hizmet Kayıt Giriş-Malzeme Bilgileri
    /// </summary>
        public HizmetKayitGirisDVO HizmetKayitGirisDVO
        {
            get { return (HizmetKayitGirisDVO)((ITTObject)this).GetParent("HIZMETKAYITGIRISDVO"); }
            set { this["HIZMETKAYITGIRISDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MalzemeBilgisiDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MalzemeBilgisiDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MalzemeBilgisiDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MalzemeBilgisiDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MalzemeBilgisiDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MALZEMEBILGISIDVO", dataRow) { }
        protected MalzemeBilgisiDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MALZEMEBILGISIDVO", dataRow, isImported) { }
        public MalzemeBilgisiDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MalzemeBilgisiDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MalzemeBilgisiDVO() : base() { }

    }
}