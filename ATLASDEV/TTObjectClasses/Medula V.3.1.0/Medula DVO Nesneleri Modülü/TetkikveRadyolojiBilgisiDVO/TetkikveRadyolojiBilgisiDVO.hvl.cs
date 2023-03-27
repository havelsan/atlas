
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TetkikveRadyolojiBilgisiDVO")] 

    public  partial class TetkikveRadyolojiBilgisiDVO : BaseHizmetKayitDVO
    {
        public class TetkikveRadyolojiBilgisiDVOList : TTObjectCollection<TetkikveRadyolojiBilgisiDVO> { }
                    
        public class ChildTetkikveRadyolojiBilgisiDVOCollection : TTObject.TTChildObjectCollection<TetkikveRadyolojiBilgisiDVO>
        {
            public ChildTetkikveRadyolojiBilgisiDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTetkikveRadyolojiBilgisiDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public string aciklama
        {
            get { return (string)this["ACIKLAMA"]; }
            set { this["ACIKLAMA"] = value; }
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
    /// Hizmet-Tetkik ve Radyoloji Bilgileri
    /// </summary>
        public HizmetDVO HizmetDVO
        {
            get { return (HizmetDVO)((ITTObject)this).GetParent("HIZMETDVO"); }
            set { this["HIZMETDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Hizmet Kayıt Giriş-Tetkik ve Radyoloji Bilgileri
    /// </summary>
        public HizmetKayitGirisDVO HizmetKayitGirisDVO
        {
            get { return (HizmetKayitGirisDVO)((ITTObject)this).GetParent("HIZMETKAYITGIRISDVO"); }
            set { this["HIZMETKAYITGIRISDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected TetkikveRadyolojiBilgisiDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TetkikveRadyolojiBilgisiDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TetkikveRadyolojiBilgisiDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TetkikveRadyolojiBilgisiDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TetkikveRadyolojiBilgisiDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TETKIKVERADYOLOJIBILGISIDVO", dataRow) { }
        protected TetkikveRadyolojiBilgisiDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TETKIKVERADYOLOJIBILGISIDVO", dataRow, isImported) { }
        public TetkikveRadyolojiBilgisiDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TetkikveRadyolojiBilgisiDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TetkikveRadyolojiBilgisiDVO() : base() { }

    }
}