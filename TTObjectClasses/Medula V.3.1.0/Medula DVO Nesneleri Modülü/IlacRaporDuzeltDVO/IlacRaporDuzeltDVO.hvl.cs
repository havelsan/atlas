
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="IlacRaporDuzeltDVO")] 

    public  partial class IlacRaporDuzeltDVO : BaseMedulaRaporObject
    {
        public class IlacRaporDuzeltDVOList : TTObjectCollection<IlacRaporDuzeltDVO> { }
                    
        public class ChildIlacRaporDuzeltDVOCollection : TTObject.TTChildObjectCollection<IlacRaporDuzeltDVO>
        {
            public ChildIlacRaporDuzeltDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildIlacRaporDuzeltDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public string raporTarihi
        {
            get { return (string)this["RAPORTARIHI"]; }
            set { this["RAPORTARIHI"] = value; }
        }

        public string raporTuru
        {
            get { return (string)this["RAPORTURU"]; }
            set { this["RAPORTURU"] = value; }
        }

        public int? tesisKodu
        {
            get { return (int?)this["TESISKODU"]; }
            set { this["TESISKODU"] = value; }
        }

        public string drTescilNo
        {
            get { return (string)this["DRTESCILNO"]; }
            set { this["DRTESCILNO"] = value; }
        }

        public string duzeltmeBilgisi
        {
            get { return (string)this["DUZELTMEBILGISI"]; }
            set { this["DUZELTMEBILGISI"] = value; }
        }

        public string duzeltmeTarihi
        {
            get { return (string)this["DUZELTMETARIHI"]; }
            set { this["DUZELTMETARIHI"] = value; }
        }

        public string raporNo
        {
            get { return (string)this["RAPORNO"]; }
            set { this["RAPORNO"] = value; }
        }

    /// <summary>
    /// Rapor Cevap
    /// </summary>
        public RaporCevapDVO raporCevapDVO
        {
            get { return (RaporCevapDVO)((ITTObject)this).GetParent("RAPORCEVAPDVO"); }
            set { this["RAPORCEVAPDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreatetanilarCollection()
        {
            _tanilar = new TaniBilgisi_RaporDVO.ChildTaniBilgisi_RaporDVOCollection(this, new Guid("34fe18e6-d288-4414-8515-73b2a82de1db"));
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

        virtual protected void CreateraporEtkinMaddelerCollection()
        {
            _raporEtkinMaddeler = new RaporEtkinMaddeDVO.ChildRaporEtkinMaddeDVOCollection(this, new Guid("34d17ada-6564-4025-8a94-a9458ed7f8c5"));
            ((ITTChildObjectCollection)_raporEtkinMaddeler).GetChildren();
        }

        protected RaporEtkinMaddeDVO.ChildRaporEtkinMaddeDVOCollection _raporEtkinMaddeler = null;
        public RaporEtkinMaddeDVO.ChildRaporEtkinMaddeDVOCollection raporEtkinMaddeler
        {
            get
            {
                if (_raporEtkinMaddeler == null)
                    CreateraporEtkinMaddelerCollection();
                return _raporEtkinMaddeler;
            }
        }

        protected IlacRaporDuzeltDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected IlacRaporDuzeltDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected IlacRaporDuzeltDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected IlacRaporDuzeltDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected IlacRaporDuzeltDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ILACRAPORDUZELTDVO", dataRow) { }
        protected IlacRaporDuzeltDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ILACRAPORDUZELTDVO", dataRow, isImported) { }
        public IlacRaporDuzeltDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public IlacRaporDuzeltDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public IlacRaporDuzeltDVO() : base() { }

    }
}