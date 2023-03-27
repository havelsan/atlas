
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ProvizyonGirisDVO")] 

    public  partial class ProvizyonGirisDVO : BaseMedulaObject
    {
        public class ProvizyonGirisDVOList : TTObjectCollection<ProvizyonGirisDVO> { }
                    
        public class ChildProvizyonGirisDVOCollection : TTObject.TTChildObjectCollection<ProvizyonGirisDVO>
        {
            public ChildProvizyonGirisDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildProvizyonGirisDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Tedavi Türü
    /// </summary>
        public string tedaviTuru
        {
            get { return (string)this["TEDAVITURU"]; }
            set { this["TEDAVITURU"] = value; }
        }

    /// <summary>
    /// Tedavi Tipi
    /// </summary>
        public string tedaviTipi
        {
            get { return (string)this["TEDAVITIPI"]; }
            set { this["TEDAVITIPI"] = value; }
        }

    /// <summary>
    /// Provizyon Alınış Tarihi
    /// </summary>
        public string provizyonTarihi
        {
            get { return (string)this["PROVIZYONTARIHI"]; }
            set { this["PROVIZYONTARIHI"] = value; }
        }

    /// <summary>
    /// Hastanın Devredilen Kurumu
    /// </summary>
        public string devredilenKurum
        {
            get { return (string)this["DEVREDILENKURUM"]; }
            set { this["DEVREDILENKURUM"] = value; }
        }

    /// <summary>
    /// Donörün TC Kimlik Numarası
    /// </summary>
        public string donorTCKimlikNo
        {
            get { return (string)this["DONORTCKIMLIKNO"]; }
            set { this["DONORTCKIMLIKNO"] = value; }
        }

    /// <summary>
    /// Provizyonun Tipi
    /// </summary>
        public string provizyonTipi
        {
            get { return (string)this["PROVIZYONTIPI"]; }
            set { this["PROVIZYONTIPI"] = value; }
        }

    /// <summary>
    /// Takibin Tipi
    /// </summary>
        public string takipTipi
        {
            get { return (string)this["TAKIPTIPI"]; }
            set { this["TAKIPTIPI"] = value; }
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
    /// Yatış Bitiş Tarihi
    /// </summary>
        public string yatisBitisTarihi
        {
            get { return (string)this["YATISBITISTARIHI"]; }
            set { this["YATISBITISTARIHI"] = value; }
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
    /// Hastanın TC Kimlik Numarası
    /// </summary>
        public string hastaTCKimlikNo
        {
            get { return (string)this["HASTATCKIMLIKNO"]; }
            set { this["HASTATCKIMLIKNO"] = value; }
        }

    /// <summary>
    /// Sigortalı Türü
    /// </summary>
        public string sigortaliTuru
        {
            get { return (string)this["SIGORTALITURU"]; }
            set { this["SIGORTALITURU"] = value; }
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
    /// Yeni Doğan Bebeklerin Bilgisi
    /// </summary>
        public YeniDoganBilgisiDVO yeniDoganBilgisi
        {
            get { return (YeniDoganBilgisiDVO)((ITTObject)this).GetParent("YENIDOGANBILGISI"); }
            set { this["YENIDOGANBILGISI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Provizyon Cevap
    /// </summary>
        public ProvizyonCevapDVO provizyonCevapDVO
        {
            get { return (ProvizyonCevapDVO)((ITTObject)this).GetParent("PROVIZYONCEVAPDVO"); }
            set { this["PROVIZYONCEVAPDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ProvizyonGirisDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ProvizyonGirisDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ProvizyonGirisDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ProvizyonGirisDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ProvizyonGirisDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PROVIZYONGIRISDVO", dataRow) { }
        protected ProvizyonGirisDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PROVIZYONGIRISDVO", dataRow, isImported) { }
        public ProvizyonGirisDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ProvizyonGirisDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ProvizyonGirisDVO() : base() { }

    }
}