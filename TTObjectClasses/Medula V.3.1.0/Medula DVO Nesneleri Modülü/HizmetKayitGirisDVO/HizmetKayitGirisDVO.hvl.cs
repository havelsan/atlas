
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HizmetKayitGirisDVO")] 

    public  partial class HizmetKayitGirisDVO : BaseMedulaObject
    {
        public class HizmetKayitGirisDVOList : TTObjectCollection<HizmetKayitGirisDVO> { }
                    
        public class ChildHizmetKayitGirisDVOCollection : TTObject.TTChildObjectCollection<HizmetKayitGirisDVO>
        {
            public ChildHizmetKayitGirisDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHizmetKayitGirisDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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
    /// Tesis Kodu
    /// </summary>
        public int? saglikTesisKodu
        {
            get { return (int?)this["SAGLIKTESISKODU"]; }
            set { this["SAGLIKTESISKODU"] = value; }
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
    /// Muayene Bilgisi
    /// </summary>
        public MuayeneBilgisiDVO muayeneBilgisi
        {
            get { return (MuayeneBilgisiDVO)((ITTObject)this).GetParent("MUAYENEBILGISI"); }
            set { this["MUAYENEBILGISI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Hizmet Kayıt Cevap
    /// </summary>
        public HizmetKayitCevapDVO hizmetKayitCevapDVO
        {
            get { return (HizmetKayitCevapDVO)((ITTObject)this).GetParent("HIZMETKAYITCEVAPDVO"); }
            set { this["HIZMETKAYITCEVAPDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateameliyatveGirisimBilgileriCollection()
        {
            _ameliyatveGirisimBilgileri = new AmeliyatveGirisimBilgisiDVO.ChildAmeliyatveGirisimBilgisiDVOCollection(this, new Guid("20333c1b-db2d-4ef7-9e2c-d78f8f5ce754"));
            ((ITTChildObjectCollection)_ameliyatveGirisimBilgileri).GetChildren();
        }

        protected AmeliyatveGirisimBilgisiDVO.ChildAmeliyatveGirisimBilgisiDVOCollection _ameliyatveGirisimBilgileri = null;
    /// <summary>
    /// Child collection for Hizmet Kayıt Giriş-Ameliyat ve Girişim Bilgileri
    /// </summary>
        public AmeliyatveGirisimBilgisiDVO.ChildAmeliyatveGirisimBilgisiDVOCollection ameliyatveGirisimBilgileri
        {
            get
            {
                if (_ameliyatveGirisimBilgileri == null)
                    CreateameliyatveGirisimBilgileriCollection();
                return _ameliyatveGirisimBilgileri;
            }
        }

        virtual protected void CreatedisBilgileriCollection()
        {
            _disBilgileri = new DisBilgisiDVO.ChildDisBilgisiDVOCollection(this, new Guid("21dfa828-d647-4e63-a2da-4445ae48fdcd"));
            ((ITTChildObjectCollection)_disBilgileri).GetChildren();
        }

        protected DisBilgisiDVO.ChildDisBilgisiDVOCollection _disBilgileri = null;
    /// <summary>
    /// Child collection for Hizmet Kayıt Giriş-Diş Bilgileri
    /// </summary>
        public DisBilgisiDVO.ChildDisBilgisiDVOCollection disBilgileri
        {
            get
            {
                if (_disBilgileri == null)
                    CreatedisBilgileriCollection();
                return _disBilgileri;
            }
        }

        virtual protected void CreateilacBilgileriCollection()
        {
            _ilacBilgileri = new IlacBilgisiDVO.ChildIlacBilgisiDVOCollection(this, new Guid("28656b7d-b22c-414a-8a9d-df886cf28b6e"));
            ((ITTChildObjectCollection)_ilacBilgileri).GetChildren();
        }

        protected IlacBilgisiDVO.ChildIlacBilgisiDVOCollection _ilacBilgileri = null;
    /// <summary>
    /// Child collection for Hizmet Kayıt Giriş-İlaç Bilgileri
    /// </summary>
        public IlacBilgisiDVO.ChildIlacBilgisiDVOCollection ilacBilgileri
        {
            get
            {
                if (_ilacBilgileri == null)
                    CreateilacBilgileriCollection();
                return _ilacBilgileri;
            }
        }

        virtual protected void CreatemalzemeBilgileriCollection()
        {
            _malzemeBilgileri = new MalzemeBilgisiDVO.ChildMalzemeBilgisiDVOCollection(this, new Guid("23744745-2f40-4f32-800c-9ea07633cca2"));
            ((ITTChildObjectCollection)_malzemeBilgileri).GetChildren();
        }

        protected MalzemeBilgisiDVO.ChildMalzemeBilgisiDVOCollection _malzemeBilgileri = null;
    /// <summary>
    /// Child collection for Hizmet Kayıt Giriş-Malzeme Bilgileri
    /// </summary>
        public MalzemeBilgisiDVO.ChildMalzemeBilgisiDVOCollection malzemeBilgileri
        {
            get
            {
                if (_malzemeBilgileri == null)
                    CreatemalzemeBilgileriCollection();
                return _malzemeBilgileri;
            }
        }

        virtual protected void CreatetahlilBilgileriCollection()
        {
            _tahlilBilgileri = new TahlilBilgisiDVO.ChildTahlilBilgisiDVOCollection(this, new Guid("088f47a4-0144-44e1-83ef-9596cbda8685"));
            ((ITTChildObjectCollection)_tahlilBilgileri).GetChildren();
        }

        protected TahlilBilgisiDVO.ChildTahlilBilgisiDVOCollection _tahlilBilgileri = null;
    /// <summary>
    /// Child collection for Hizmet Kayıt Giriş-Tahlil Bilgileri
    /// </summary>
        public TahlilBilgisiDVO.ChildTahlilBilgisiDVOCollection tahlilBilgileri
        {
            get
            {
                if (_tahlilBilgileri == null)
                    CreatetahlilBilgileriCollection();
                return _tahlilBilgileri;
            }
        }

        virtual protected void CreatehastaYatisBilgileriCollection()
        {
            _hastaYatisBilgileri = new HastaYatisBilgisiDVO.ChildHastaYatisBilgisiDVOCollection(this, new Guid("d1e6765f-0314-497c-b9c6-ced19889332c"));
            ((ITTChildObjectCollection)_hastaYatisBilgileri).GetChildren();
        }

        protected HastaYatisBilgisiDVO.ChildHastaYatisBilgisiDVOCollection _hastaYatisBilgileri = null;
    /// <summary>
    /// Child collection for Hizmet Kayıt Giriş-Hasta Yatış Bilgileri
    /// </summary>
        public HastaYatisBilgisiDVO.ChildHastaYatisBilgisiDVOCollection hastaYatisBilgileri
        {
            get
            {
                if (_hastaYatisBilgileri == null)
                    CreatehastaYatisBilgileriCollection();
                return _hastaYatisBilgileri;
            }
        }

        virtual protected void CreatetanilarCollection()
        {
            _tanilar = new TaniBilgisiDVO.ChildTaniBilgisiDVOCollection(this, new Guid("a3ade86b-ef38-400f-b21f-e30e3a76eeff"));
            ((ITTChildObjectCollection)_tanilar).GetChildren();
        }

        protected TaniBilgisiDVO.ChildTaniBilgisiDVOCollection _tanilar = null;
    /// <summary>
    /// Child collection for Hizmet Kayıt Giriş-Tanılar
    /// </summary>
        public TaniBilgisiDVO.ChildTaniBilgisiDVOCollection tanilar
        {
            get
            {
                if (_tanilar == null)
                    CreatetanilarCollection();
                return _tanilar;
            }
        }

        virtual protected void CreatedigerIslemBilgileriCollection()
        {
            _digerIslemBilgileri = new DigerIslemBilgisiDVO.ChildDigerIslemBilgisiDVOCollection(this, new Guid("2b1384d5-7a16-43c1-96a9-ffc2bb67949a"));
            ((ITTChildObjectCollection)_digerIslemBilgileri).GetChildren();
        }

        protected DigerIslemBilgisiDVO.ChildDigerIslemBilgisiDVOCollection _digerIslemBilgileri = null;
    /// <summary>
    /// Child collection for Hizmet Kayıt Giriş-Diğer İşlem Bilgileri
    /// </summary>
        public DigerIslemBilgisiDVO.ChildDigerIslemBilgisiDVOCollection digerIslemBilgileri
        {
            get
            {
                if (_digerIslemBilgileri == null)
                    CreatedigerIslemBilgileriCollection();
                return _digerIslemBilgileri;
            }
        }

        virtual protected void CreatekonsultasyonBilgileriCollection()
        {
            _konsultasyonBilgileri = new KonsultasyonBilgisiDVO.ChildKonsultasyonBilgisiDVOCollection(this, new Guid("7aed1f18-ee17-4f34-b0c9-9d6f93c9e3db"));
            ((ITTChildObjectCollection)_konsultasyonBilgileri).GetChildren();
        }

        protected KonsultasyonBilgisiDVO.ChildKonsultasyonBilgisiDVOCollection _konsultasyonBilgileri = null;
    /// <summary>
    /// Child collection for Hizmet Kayıt Giriş-Konsültasyon Bilgileri
    /// </summary>
        public KonsultasyonBilgisiDVO.ChildKonsultasyonBilgisiDVOCollection konsultasyonBilgileri
        {
            get
            {
                if (_konsultasyonBilgileri == null)
                    CreatekonsultasyonBilgileriCollection();
                return _konsultasyonBilgileri;
            }
        }

        virtual protected void CreatetetkikveRadyolojiBilgileriCollection()
        {
            _tetkikveRadyolojiBilgileri = new TetkikveRadyolojiBilgisiDVO.ChildTetkikveRadyolojiBilgisiDVOCollection(this, new Guid("d13b1605-f68b-4b4f-aa83-49cbe8b2e286"));
            ((ITTChildObjectCollection)_tetkikveRadyolojiBilgileri).GetChildren();
        }

        protected TetkikveRadyolojiBilgisiDVO.ChildTetkikveRadyolojiBilgisiDVOCollection _tetkikveRadyolojiBilgileri = null;
    /// <summary>
    /// Child collection for Hizmet Kayıt Giriş-Tetkik ve Radyoloji Bilgileri
    /// </summary>
        public TetkikveRadyolojiBilgisiDVO.ChildTetkikveRadyolojiBilgisiDVOCollection tetkikveRadyolojiBilgileri
        {
            get
            {
                if (_tetkikveRadyolojiBilgileri == null)
                    CreatetetkikveRadyolojiBilgileriCollection();
                return _tetkikveRadyolojiBilgileri;
            }
        }

        protected HizmetKayitGirisDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HizmetKayitGirisDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HizmetKayitGirisDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HizmetKayitGirisDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HizmetKayitGirisDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HIZMETKAYITGIRISDVO", dataRow) { }
        protected HizmetKayitGirisDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HIZMETKAYITGIRISDVO", dataRow, isImported) { }
        public HizmetKayitGirisDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HizmetKayitGirisDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HizmetKayitGirisDVO() : base() { }

    }
}