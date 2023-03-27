
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HizmetDVO")] 

    public  partial class HizmetDVO : BaseMedulaObject
    {
        public class HizmetDVOList : TTObjectCollection<HizmetDVO> { }
                    
        public class ChildHizmetDVOCollection : TTObject.TTChildObjectCollection<HizmetDVO>
        {
            public ChildHizmetDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHizmetDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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
    /// Ödeme Sorgunun Durumu
    /// </summary>
        public string odemeSorguDurum
        {
            get { return (string)this["ODEMESORGUDURUM"]; }
            set { this["ODEMESORGUDURUM"] = value; }
        }

    /// <summary>
    /// Muayene Bilgisi
    /// </summary>
        public MuayeneBilgisiDVO muayeneBilgisi
        {
            get { return (MuayeneBilgisiDVO)((ITTObject)this).GetParent("MUAYENEBILGISI"); }
            set { this["MUAYENEBILGISI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreatehastaYatisBilgileriCollection()
        {
            _hastaYatisBilgileri = new HastaYatisBilgisiDVO.ChildHastaYatisBilgisiDVOCollection(this, new Guid("4c35acf3-1f15-4d9e-97d3-c2f6203f28a4"));
            ((ITTChildObjectCollection)_hastaYatisBilgileri).GetChildren();
        }

        protected HastaYatisBilgisiDVO.ChildHastaYatisBilgisiDVOCollection _hastaYatisBilgileri = null;
    /// <summary>
    /// Child collection for Hizmet-Hasta Yatış Bilgileri
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

        virtual protected void CreatemalzemeBilgileriCollection()
        {
            _malzemeBilgileri = new MalzemeBilgisiDVO.ChildMalzemeBilgisiDVOCollection(this, new Guid("2cbb99ab-6408-4bd3-9d6d-f1819f98023d"));
            ((ITTChildObjectCollection)_malzemeBilgileri).GetChildren();
        }

        protected MalzemeBilgisiDVO.ChildMalzemeBilgisiDVOCollection _malzemeBilgileri = null;
    /// <summary>
    /// Child collection for Hizmet-Malzeme Bilgileri
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

        virtual protected void CreatedisBilgileriCollection()
        {
            _disBilgileri = new DisBilgisiDVO.ChildDisBilgisiDVOCollection(this, new Guid("461861c1-8fa3-4ebc-b9cc-2c329f27a49f"));
            ((ITTChildObjectCollection)_disBilgileri).GetChildren();
        }

        protected DisBilgisiDVO.ChildDisBilgisiDVOCollection _disBilgileri = null;
    /// <summary>
    /// Child collection for Hizmet-Diş Bilgileri
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

        virtual protected void CreatedigerIslemBilgileriCollection()
        {
            _digerIslemBilgileri = new DigerIslemBilgisiDVO.ChildDigerIslemBilgisiDVOCollection(this, new Guid("6d1aeb92-01cb-4083-a085-60f96da53ffb"));
            ((ITTChildObjectCollection)_digerIslemBilgileri).GetChildren();
        }

        protected DigerIslemBilgisiDVO.ChildDigerIslemBilgisiDVOCollection _digerIslemBilgileri = null;
    /// <summary>
    /// Child collection for Hizmet-Diğer İşlem Bilgileri
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

        virtual protected void CreateilacBilgileriCollection()
        {
            _ilacBilgileri = new IlacBilgisiDVO.ChildIlacBilgisiDVOCollection(this, new Guid("fcb7eba6-52cc-4822-ba02-ad4b4e136c8f"));
            ((ITTChildObjectCollection)_ilacBilgileri).GetChildren();
        }

        protected IlacBilgisiDVO.ChildIlacBilgisiDVOCollection _ilacBilgileri = null;
    /// <summary>
    /// Child collection for Hizmet-İlaç Bilgileri
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

        virtual protected void CreatekonsultasyonBilgileriCollection()
        {
            _konsultasyonBilgileri = new KonsultasyonBilgisiDVO.ChildKonsultasyonBilgisiDVOCollection(this, new Guid("35474268-7aeb-42ce-8fcc-9c58a904f1aa"));
            ((ITTChildObjectCollection)_konsultasyonBilgileri).GetChildren();
        }

        protected KonsultasyonBilgisiDVO.ChildKonsultasyonBilgisiDVOCollection _konsultasyonBilgileri = null;
    /// <summary>
    /// Child collection for Hizmet-Konsültasyon Bilgileri
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

        virtual protected void CreatetanilarCollection()
        {
            _tanilar = new TaniBilgisiDVO.ChildTaniBilgisiDVOCollection(this, new Guid("952634d0-8437-43ca-a662-15f02f808058"));
            ((ITTChildObjectCollection)_tanilar).GetChildren();
        }

        protected TaniBilgisiDVO.ChildTaniBilgisiDVOCollection _tanilar = null;
    /// <summary>
    /// Child collection for Hizmet-Tanılar
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

        virtual protected void CreatetahlilBilgileriCollection()
        {
            _tahlilBilgileri = new TahlilBilgisiDVO.ChildTahlilBilgisiDVOCollection(this, new Guid("324023b4-7aac-42b7-a448-bb63be5dfd14"));
            ((ITTChildObjectCollection)_tahlilBilgileri).GetChildren();
        }

        protected TahlilBilgisiDVO.ChildTahlilBilgisiDVOCollection _tahlilBilgileri = null;
    /// <summary>
    /// Child collection for Hizmet-Tahlil Bilgileri
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

        virtual protected void CreatetetkikveRadyolojiBilgileriCollection()
        {
            _tetkikveRadyolojiBilgileri = new TetkikveRadyolojiBilgisiDVO.ChildTetkikveRadyolojiBilgisiDVOCollection(this, new Guid("f0f07402-6bcb-4357-8c37-4601660edd2d"));
            ((ITTChildObjectCollection)_tetkikveRadyolojiBilgileri).GetChildren();
        }

        protected TetkikveRadyolojiBilgisiDVO.ChildTetkikveRadyolojiBilgisiDVOCollection _tetkikveRadyolojiBilgileri = null;
    /// <summary>
    /// Child collection for Hizmet-Tetkik ve Radyoloji Bilgileri
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

        virtual protected void CreateameliyatveGirisimBilgileriCollection()
        {
            _ameliyatveGirisimBilgileri = new AmeliyatveGirisimBilgisiDVO.ChildAmeliyatveGirisimBilgisiDVOCollection(this, new Guid("a1c63b1f-b72a-4382-9f31-a7b7606f30a2"));
            ((ITTChildObjectCollection)_ameliyatveGirisimBilgileri).GetChildren();
        }

        protected AmeliyatveGirisimBilgisiDVO.ChildAmeliyatveGirisimBilgisiDVOCollection _ameliyatveGirisimBilgileri = null;
    /// <summary>
    /// Child collection for Hizmet-Ameliyat ve Girişim Bilgileri
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

        protected HizmetDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HizmetDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HizmetDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HizmetDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HizmetDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HIZMETDVO", dataRow) { }
        protected HizmetDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HIZMETDVO", dataRow, isImported) { }
        public HizmetDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HizmetDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HizmetDVO() : base() { }

    }
}