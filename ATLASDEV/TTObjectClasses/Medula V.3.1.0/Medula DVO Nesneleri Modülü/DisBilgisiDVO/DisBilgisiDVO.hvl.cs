
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DisBilgisiDVO")] 

    public  partial class DisBilgisiDVO : BaseHizmetKayitDVO
    {
        public class DisBilgisiDVOList : TTObjectCollection<DisBilgisiDVO> { }
                    
        public class ChildDisBilgisiDVOCollection : TTObject.TTChildObjectCollection<DisBilgisiDVO>
        {
            public ChildDisBilgisiDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDisBilgisiDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Sağ Üst Çenedeki Dişler
    /// </summary>
        public string sagUstCene
        {
            get { return (string)this["SAGUSTCENE"]; }
            set { this["SAGUSTCENE"] = value; }
        }

    /// <summary>
    /// Sol Alt Çenedeki Dişler
    /// </summary>
        public string solAltCene
        {
            get { return (string)this["SOLALTCENE"]; }
            set { this["SOLALTCENE"] = value; }
        }

    /// <summary>
    /// Çocukta Sağ Alt Çenedeki Süt Dişleri
    /// </summary>
        public string sagSutAltCene
        {
            get { return (string)this["SAGSUTALTCENE"]; }
            set { this["SAGSUTALTCENE"] = value; }
        }

    /// <summary>
    /// Çocukta Sağ Üst Çenedeki Süt Dişleri
    /// </summary>
        public string sagSutUstCene
        {
            get { return (string)this["SAGSUTUSTCENE"]; }
            set { this["SAGSUTUSTCENE"] = value; }
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
    /// SUT Kodu
    /// </summary>
        public string sutKodu
        {
            get { return (string)this["SUTKODU"]; }
            set { this["SUTKODU"] = value; }
        }

    /// <summary>
    /// Anomali
    /// </summary>
        public string anomali
        {
            get { return (string)this["ANOMALI"]; }
            set { this["ANOMALI"] = value; }
        }

    /// <summary>
    /// Sağ Alt Çenedeki Dişler
    /// </summary>
        public string sagAltCene
        {
            get { return (string)this["SAGALTCENE"]; }
            set { this["SAGALTCENE"] = value; }
        }

    /// <summary>
    /// Sol Üst Çenedeki Dişler
    /// </summary>
        public string solUstCene
        {
            get { return (string)this["SOLUSTCENE"]; }
            set { this["SOLUSTCENE"] = value; }
        }

    /// <summary>
    /// Çocukta Sol Alt Çenedeki Süt Dişleri
    /// </summary>
        public string solSutAltCene
        {
            get { return (string)this["SOLSUTALTCENE"]; }
            set { this["SOLSUTALTCENE"] = value; }
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
    /// Çocukta Sol Üst Çenedeki Süt Dişleri
    /// </summary>
        public string solSutUstCene
        {
            get { return (string)this["SOLSUTUSTCENE"]; }
            set { this["SOLSUTUSTCENE"] = value; }
        }

    /// <summary>
    /// Hizmet-Diş Bilgileri
    /// </summary>
        public HizmetDVO HizmetDVO
        {
            get { return (HizmetDVO)((ITTObject)this).GetParent("HIZMETDVO"); }
            set { this["HIZMETDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Hizmet Kayıt Giriş-Diş Bilgileri
    /// </summary>
        public HizmetKayitGirisDVO HizmetKayitGirisDVO
        {
            get { return (HizmetKayitGirisDVO)((ITTObject)this).GetParent("HIZMETKAYITGIRISDVO"); }
            set { this["HIZMETKAYITGIRISDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DisBilgisiDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DisBilgisiDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DisBilgisiDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DisBilgisiDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DisBilgisiDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DISBILGISIDVO", dataRow) { }
        protected DisBilgisiDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DISBILGISIDVO", dataRow, isImported) { }
        public DisBilgisiDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DisBilgisiDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DisBilgisiDVO() : base() { }

    }
}