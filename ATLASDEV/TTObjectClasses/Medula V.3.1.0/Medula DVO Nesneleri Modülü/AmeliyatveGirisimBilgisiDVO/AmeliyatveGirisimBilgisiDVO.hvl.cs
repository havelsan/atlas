
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AmeliyatveGirisimBilgisiDVO")] 

    public  partial class AmeliyatveGirisimBilgisiDVO : BaseHizmetKayitDVO
    {
        public class AmeliyatveGirisimBilgisiDVOList : TTObjectCollection<AmeliyatveGirisimBilgisiDVO> { }
                    
        public class ChildAmeliyatveGirisimBilgisiDVOCollection : TTObject.TTChildObjectCollection<AmeliyatveGirisimBilgisiDVO>
        {
            public ChildAmeliyatveGirisimBilgisiDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAmeliyatveGirisimBilgisiDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Aynı Kesi / Seans Bilgisi
    /// </summary>
        public string ayniFarkliKesi
        {
            get { return (string)this["AYNIFARKLIKESI"]; }
            set { this["AYNIFARKLIKESI"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string aciklama
        {
            get { return (string)this["ACIKLAMA"]; }
            set { this["ACIKLAMA"] = value; }
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
    /// İşlem Tarihi
    /// </summary>
        public string islemTarihi
        {
            get { return (string)this["ISLEMTARIHI"]; }
            set { this["ISLEMTARIHI"] = value; }
        }

    /// <summary>
    /// Sağ Taraf, Sol Taraf
    /// </summary>
        public string sagSol
        {
            get { return (string)this["SAGSOL"]; }
            set { this["SAGSOL"] = value; }
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
    /// Euroscore
    /// </summary>
        public string euroscore
        {
            get { return (string)this["EUROSCORE"]; }
            set { this["EUROSCORE"] = value; }
        }

    /// <summary>
    /// Hizmet Kayıt Giriş-Ameliyat ve Girişim Bilgileri
    /// </summary>
        public HizmetKayitGirisDVO HizmetKayitGirisDVO
        {
            get { return (HizmetKayitGirisDVO)((ITTObject)this).GetParent("HIZMETKAYITGIRISDVO"); }
            set { this["HIZMETKAYITGIRISDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Hizmet-Ameliyat ve Girişim Bilgileri
    /// </summary>
        public HizmetDVO HizmetDVO
        {
            get { return (HizmetDVO)((ITTObject)this).GetParent("HIZMETDVO"); }
            set { this["HIZMETDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected AmeliyatveGirisimBilgisiDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AmeliyatveGirisimBilgisiDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AmeliyatveGirisimBilgisiDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AmeliyatveGirisimBilgisiDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AmeliyatveGirisimBilgisiDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "AMELIYATVEGIRISIMBILGISIDVO", dataRow) { }
        protected AmeliyatveGirisimBilgisiDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "AMELIYATVEGIRISIMBILGISIDVO", dataRow, isImported) { }
        public AmeliyatveGirisimBilgisiDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AmeliyatveGirisimBilgisiDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AmeliyatveGirisimBilgisiDVO() : base() { }

    }
}