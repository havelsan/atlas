
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HastaYatisBilgisiDVO")] 

    public  partial class HastaYatisBilgisiDVO : BaseHizmetKayitDVO
    {
        public class HastaYatisBilgisiDVOList : TTObjectCollection<HastaYatisBilgisiDVO> { }
                    
        public class ChildHastaYatisBilgisiDVOCollection : TTObject.TTChildObjectCollection<HastaYatisBilgisiDVO>
        {
            public ChildHastaYatisBilgisiDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHastaYatisBilgisiDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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
    /// Doktor Tescil No
    /// </summary>
        public string drTescilNo
        {
            get { return (string)this["DRTESCILNO"]; }
            set { this["DRTESCILNO"] = value; }
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
    /// Refakatçi Gün Sayısı
    /// </summary>
        public string refakatciGunSayisi
        {
            get { return (string)this["REFAKATCIGUNSAYISI"]; }
            set { this["REFAKATCIGUNSAYISI"] = value; }
        }

    /// <summary>
    /// Yatış Başlangıç Tarihi
    /// </summary>
        public string yatisBaslangicTarihi
        {
            get { return (string)this["YATISBASLANGICTARIHI"]; }
            set { this["YATISBASLANGICTARIHI"] = value; }
        }

    /// <summary>
    /// Yatış Bitiş Tarihi
    /// </summary>
        public string yatisBitisTarihi
        {
            get { return (string)this["YATISBITISTARIHI"]; }
            set { this["YATISBITISTARIHI"] = value; }
        }

    /// <summary>
    /// Hizmet-Hasta Yatış Bilgileri
    /// </summary>
        public HizmetDVO HizmetDVO
        {
            get { return (HizmetDVO)((ITTObject)this).GetParent("HIZMETDVO"); }
            set { this["HIZMETDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Hizmet Kayıt Giriş-Hasta Yatış Bilgileri
    /// </summary>
        public HizmetKayitGirisDVO HizmetKayitGirisDVO
        {
            get { return (HizmetKayitGirisDVO)((ITTObject)this).GetParent("HIZMETKAYITGIRISDVO"); }
            set { this["HIZMETKAYITGIRISDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected HastaYatisBilgisiDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HastaYatisBilgisiDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HastaYatisBilgisiDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HastaYatisBilgisiDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HastaYatisBilgisiDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HASTAYATISBILGISIDVO", dataRow) { }
        protected HastaYatisBilgisiDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HASTAYATISBILGISIDVO", dataRow, isImported) { }
        public HastaYatisBilgisiDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HastaYatisBilgisiDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HastaYatisBilgisiDVO() : base() { }

    }
}