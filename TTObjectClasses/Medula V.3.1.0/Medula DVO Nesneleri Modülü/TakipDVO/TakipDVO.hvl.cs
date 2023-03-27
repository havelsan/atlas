
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TakipDVO")] 

    public  partial class TakipDVO : BaseMedulaCevap
    {
        public class TakipDVOList : TTObjectCollection<TakipDVO> { }
                    
        public class ChildTakipDVOCollection : TTObject.TTChildObjectCollection<TakipDVO>
        {
            public ChildTakipDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTakipDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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
    /// Tesis kodu
    /// </summary>
        public int? tesisKodu
        {
            get { return (int?)this["TESISKODU"]; }
            set { this["TESISKODU"] = value; }
        }

    /// <summary>
    /// Yeni Doğan Çocuk Sıra
    /// </summary>
        public string yeniDoganCocukSiraNo
        {
            get { return (string)this["YENIDOGANCOCUKSIRANO"]; }
            set { this["YENIDOGANCOCUKSIRANO"] = value; }
        }

    /// <summary>
    /// İlk Takip Numarası
    /// </summary>
        public string ilkTakipNo
        {
            get { return (string)this["ILKTAKIPNO"]; }
            set { this["ILKTAKIPNO"] = value; }
        }

    /// <summary>
    /// Takip Tarihi
    /// </summary>
        public string takipTarihi
        {
            get { return (string)this["TAKIPTARIHI"]; }
            set { this["TAKIPTARIHI"] = value; }
        }

    /// <summary>
    /// Kayıt Tarihi
    /// </summary>
        public string kayitTarihi
        {
            get { return (string)this["KAYITTARIHI"]; }
            set { this["KAYITTARIHI"] = value; }
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
    /// Donörün TC Kimlik Numarası
    /// </summary>
        public string donorTCKimlikNo
        {
            get { return (string)this["DONORTCKIMLIKNO"]; }
            set { this["DONORTCKIMLIKNO"] = value; }
        }

    /// <summary>
    /// Hastanın Başvuru Numarası
    /// </summary>
        public string hastaBasvuruNo
        {
            get { return (string)this["HASTABASVURUNO"]; }
            set { this["HASTABASVURUNO"] = value; }
        }

    /// <summary>
    /// Takip Tipi
    /// </summary>
        public string takipTipi
        {
            get { return (string)this["TAKIPTIPI"]; }
            set { this["TAKIPTIPI"] = value; }
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
    /// Provizyon Tipi
    /// </summary>
        public string provizyonTipi
        {
            get { return (string)this["PROVIZYONTIPI"]; }
            set { this["PROVIZYONTIPI"] = value; }
        }

    /// <summary>
    /// Takip Durumu
    /// </summary>
        public string takipDurumu
        {
            get { return (string)this["TAKIPDURUMU"]; }
            set { this["TAKIPDURUMU"] = value; }
        }

    /// <summary>
    /// Fatura Teslim No
    /// </summary>
        public string faturaTeslimNo
        {
            get { return (string)this["FATURATESLIMNO"]; }
            set { this["FATURATESLIMNO"] = value; }
        }

    /// <summary>
    /// Sevk Durumu
    /// </summary>
        public string sevkDurumu
        {
            get { return (string)this["SEVKDURUMU"]; }
            set { this["SEVKDURUMU"] = value; }
        }

    /// <summary>
    /// Yeni Doğan Doğum Tar.
    /// </summary>
        public string yeniDoganDogumTarihi
        {
            get { return (string)this["YENIDOGANDOGUMTARIHI"]; }
            set { this["YENIDOGANDOGUMTARIHI"] = value; }
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
    /// Hasta Bilgileri
    /// </summary>
        public HastaBilgileriDVO hastaBilgileri
        {
            get { return (HastaBilgileriDVO)((ITTObject)this).GetParent("HASTABILGILERI"); }
            set { this["HASTABILGILERI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Takip Ara Cevap-Takipler
    /// </summary>
        public TakipAraCevapDVO TakipAraCevapDVO
        {
            get { return (TakipAraCevapDVO)((ITTObject)this).GetParent("TAKIPARACEVAPDVO"); }
            set { this["TAKIPARACEVAPDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected TakipDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TakipDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TakipDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TakipDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TakipDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TAKIPDVO", dataRow) { }
        protected TakipDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TAKIPDVO", dataRow, isImported) { }
        public TakipDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TakipDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TakipDVO() : base() { }

    }
}