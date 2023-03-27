
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="IsgoremezlikRaporEkDVO")] 

    public  partial class IsgoremezlikRaporEkDVO : BaseMedulaRaporObject
    {
        public class IsgoremezlikRaporEkDVOList : TTObjectCollection<IsgoremezlikRaporEkDVO> { }
                    
        public class ChildIsgoremezlikRaporEkDVOCollection : TTObject.TTChildObjectCollection<IsgoremezlikRaporEkDVO>
        {
            public ChildIsgoremezlikRaporEkDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildIsgoremezlikRaporEkDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public string kontrolTarihi
        {
            get { return (string)this["KONTROLTARIHI"]; }
            set { this["KONTROLTARIHI"] = value; }
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

        public string aciklama
        {
            get { return (string)this["ACIKLAMA"]; }
            set { this["ACIKLAMA"] = value; }
        }

        public string bitisTarihi
        {
            get { return (string)this["BITISTARIHI"]; }
            set { this["BITISTARIHI"] = value; }
        }

        public string durum
        {
            get { return (string)this["DURUM"]; }
            set { this["DURUM"] = value; }
        }

        public string duzenlemeTuru
        {
            get { return (string)this["DUZENLEMETURU"]; }
            set { this["DUZENLEMETURU"] = value; }
        }

        public string hastaYatisVarMi
        {
            get { return (string)this["HASTAYATISVARMI"]; }
            set { this["HASTAYATISVARMI"] = value; }
        }

        public string kontrolMu
        {
            get { return (string)this["KONTROLMU"]; }
            set { this["KONTROLMU"] = value; }
        }

    /// <summary>
    /// Rapor Uzat Cevap
    /// </summary>
        public RaporUzatCevapDVO raporUzatCevapDVO
        {
            get { return (RaporUzatCevapDVO)((ITTObject)this).GetParent("RAPORUZATCEVAPDVO"); }
            set { this["RAPORUZATCEVAPDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public RaporBilgisiDVO raporBilgisiDVO
        {
            get { return (RaporBilgisiDVO)((ITTObject)this).GetParent("RAPORBILGISIDVO"); }
            set { this["RAPORBILGISIDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public RaporCevapDVO RaporCevapDVO
        {
            get { return (RaporCevapDVO)((ITTObject)this).GetParent("RAPORCEVAPDVO"); }
            set { this["RAPORCEVAPDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateyatislarCollection()
        {
            _yatislar = new HastaYatisBilgisi_RaporDVO.ChildHastaYatisBilgisi_RaporDVOCollection(this, new Guid("cf316617-9d1e-4467-8e9c-92b60661efce"));
            ((ITTChildObjectCollection)_yatislar).GetChildren();
        }

        protected HastaYatisBilgisi_RaporDVO.ChildHastaYatisBilgisi_RaporDVOCollection _yatislar = null;
        public HastaYatisBilgisi_RaporDVO.ChildHastaYatisBilgisi_RaporDVOCollection yatislar
        {
            get
            {
                if (_yatislar == null)
                    CreateyatislarCollection();
                return _yatislar;
            }
        }

        virtual protected void CreatedoktorlarCollection()
        {
            _doktorlar = new DoktorBilgisiDVO.ChildDoktorBilgisiDVOCollection(this, new Guid("e8ab68da-f4d9-4622-9df4-8739d269b443"));
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
            _tanilar = new TaniBilgisi_RaporDVO.ChildTaniBilgisi_RaporDVOCollection(this, new Guid("7cb8609a-6600-4944-bc15-2a2a4a014816"));
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

        protected IsgoremezlikRaporEkDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected IsgoremezlikRaporEkDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected IsgoremezlikRaporEkDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected IsgoremezlikRaporEkDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected IsgoremezlikRaporEkDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ISGOREMEZLIKRAPOREKDVO", dataRow) { }
        protected IsgoremezlikRaporEkDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ISGOREMEZLIKRAPOREKDVO", dataRow, isImported) { }
        public IsgoremezlikRaporEkDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public IsgoremezlikRaporEkDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public IsgoremezlikRaporEkDVO() : base() { }

    }
}