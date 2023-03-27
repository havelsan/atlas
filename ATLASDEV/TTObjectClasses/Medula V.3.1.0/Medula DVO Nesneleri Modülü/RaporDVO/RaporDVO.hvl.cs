
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="RaporDVO")] 

    public  partial class RaporDVO : BaseMedulaObject
    {
        public class RaporDVOList : TTObjectCollection<RaporDVO> { }
                    
        public class ChildRaporDVOCollection : TTObject.TTChildObjectCollection<RaporDVO>
        {
            public ChildRaporDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildRaporDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public string duzenlemeTuru
        {
            get { return (string)this["DUZENLEMETURU"]; }
            set { this["DUZENLEMETURU"] = value; }
        }

        public string protokolNo
        {
            get { return (string)this["PROTOKOLNO"]; }
            set { this["PROTOKOLNO"] = value; }
        }

        public string protokolTarihi
        {
            get { return (string)this["PROTOKOLTARIHI"]; }
            set { this["PROTOKOLTARIHI"] = value; }
        }

        public string turu
        {
            get { return (string)this["TURU"]; }
            set { this["TURU"] = value; }
        }

        public string baslangicTarihi
        {
            get { return (string)this["BASLANGICTARIHI"]; }
            set { this["BASLANGICTARIHI"] = value; }
        }

        public string bitisTarihi
        {
            get { return (string)this["BITISTARIHI"]; }
            set { this["BITISTARIHI"] = value; }
        }

        public string aciklama
        {
            get { return (string)this["ACIKLAMA"]; }
            set { this["ACIKLAMA"] = value; }
        }

        public string takipNo
        {
            get { return (string)this["TAKIPNO"]; }
            set { this["TAKIPNO"] = value; }
        }

        public string klinikTani
        {
            get { return (string)this["KLINIKTANI"]; }
            set { this["KLINIKTANI"] = value; }
        }

        public string durum
        {
            get { return (string)this["DURUM"]; }
            set { this["DURUM"] = value; }
        }

        public RaporBilgisiDVO raporBilgisi
        {
            get { return (RaporBilgisiDVO)((ITTObject)this).GetParent("RAPORBILGISI"); }
            set { this["RAPORBILGISI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public HakSahibiBilgisiDVO hakSahibi
        {
            get { return (HakSahibiBilgisiDVO)((ITTObject)this).GetParent("HAKSAHIBI"); }
            set { this["HAKSAHIBI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateteshislerCollection()
        {
            _teshisler = new TeshisBilgisiDVO.ChildTeshisBilgisiDVOCollection(this, new Guid("ff1c4738-9454-41f3-adc8-0ef8b2e49d45"));
            ((ITTChildObjectCollection)_teshisler).GetChildren();
        }

        protected TeshisBilgisiDVO.ChildTeshisBilgisiDVOCollection _teshisler = null;
        public TeshisBilgisiDVO.ChildTeshisBilgisiDVOCollection teshisler
        {
            get
            {
                if (_teshisler == null)
                    CreateteshislerCollection();
                return _teshisler;
            }
        }

        virtual protected void CreateilacTeshislerCollection()
        {
            _ilacTeshisler = new IlacTeshisBilgiDVO.ChildIlacTeshisBilgiDVOCollection(this, new Guid("948cfc4d-a7d4-40bf-ab38-b9c0113f38be"));
            ((ITTChildObjectCollection)_ilacTeshisler).GetChildren();
        }

        protected IlacTeshisBilgiDVO.ChildIlacTeshisBilgiDVOCollection _ilacTeshisler = null;
        public IlacTeshisBilgiDVO.ChildIlacTeshisBilgiDVOCollection ilacTeshisler
        {
            get
            {
                if (_ilacTeshisler == null)
                    CreateilacTeshislerCollection();
                return _ilacTeshisler;
            }
        }

        virtual protected void CreatedoktorlarCollection()
        {
            _doktorlar = new DoktorBilgisiDVO.ChildDoktorBilgisiDVOCollection(this, new Guid("96edd63b-eaf4-4065-9682-8210fe89a4f5"));
            ((ITTChildObjectCollection)_doktorlar).GetChildren();
        }

        protected DoktorBilgisiDVO.ChildDoktorBilgisiDVOCollection _doktorlar = null;
        public DoktorBilgisiDVO.ChildDoktorBilgisiDVOCollection doktorlar
        {
            get
            {
                if (_doktorlar == null)
                    CreatedoktorlarCollection();
                return _doktorlar;
            }
        }

        virtual protected void CreatetanilarCollection()
        {
            _tanilar = new TaniBilgisi_RaporDVO.ChildTaniBilgisi_RaporDVOCollection(this, new Guid("aa5bd965-7dbb-4fdc-a93b-8076da26d8e9"));
            ((ITTChildObjectCollection)_tanilar).GetChildren();
        }

        protected TaniBilgisi_RaporDVO.ChildTaniBilgisi_RaporDVOCollection _tanilar = null;
        public TaniBilgisi_RaporDVO.ChildTaniBilgisi_RaporDVOCollection tanilar
        {
            get
            {
                if (_tanilar == null)
                    CreatetanilarCollection();
                return _tanilar;
            }
        }

        protected RaporDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected RaporDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected RaporDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected RaporDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected RaporDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RAPORDVO", dataRow) { }
        protected RaporDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RAPORDVO", dataRow, isImported) { }
        public RaporDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public RaporDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public RaporDVO() : base() { }

    }
}