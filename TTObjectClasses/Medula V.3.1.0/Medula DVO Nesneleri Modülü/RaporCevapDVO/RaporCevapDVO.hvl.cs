
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="RaporCevapDVO")] 

    public  partial class RaporCevapDVO : BaseMedulaRaporCevap
    {
        public class RaporCevapDVOList : TTObjectCollection<RaporCevapDVO> { }
                    
        public class ChildRaporCevapDVOCollection : TTObject.TTChildObjectCollection<RaporCevapDVO>
        {
            public ChildRaporCevapDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildRaporCevapDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public long? raporTakipNo
        {
            get { return (long?)this["RAPORTAKIPNO"]; }
            set { this["RAPORTAKIPNO"] = value; }
        }

        public string raporTuru
        {
            get { return (string)this["RAPORTURU"]; }
            set { this["RAPORTURU"] = value; }
        }

        public DogumOncesiCalisabilirRaporDVO dogumOncesiCalisabilirRapor
        {
            get { return (DogumOncesiCalisabilirRaporDVO)((ITTObject)this).GetParent("DOGUMONCESICALISABILIRRAPOR"); }
            set { this["DOGUMONCESICALISABILIRRAPOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DogumRaporDVO dogumRapor
        {
            get { return (DogumRaporDVO)((ITTObject)this).GetParent("DOGUMRAPOR"); }
            set { this["DOGUMRAPOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public IlacRaporDVO ilacRapor
        {
            get { return (IlacRaporDVO)((ITTObject)this).GetParent("ILACRAPOR"); }
            set { this["ILACRAPOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public IsgoremezlikRaporDVO isgoremezlikRapor
        {
            get { return (IsgoremezlikRaporDVO)((ITTObject)this).GetParent("ISGOREMEZLIKRAPOR"); }
            set { this["ISGOREMEZLIKRAPOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MaluliyetRaporDVO maluliyetRapor
        {
            get { return (MaluliyetRaporDVO)((ITTObject)this).GetParent("MALULIYETRAPOR"); }
            set { this["MALULIYETRAPOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ProtezRaporDVO protezRapor
        {
            get { return (ProtezRaporDVO)((ITTObject)this).GetParent("PROTEZRAPOR"); }
            set { this["PROTEZRAPOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public TedaviRaporDVO tedaviRapor
        {
            get { return (TedaviRaporDVO)((ITTObject)this).GetParent("TEDAVIRAPOR"); }
            set { this["TEDAVIRAPOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public AnalikIsgoremezlikRaporDVO analikRapor
        {
            get { return (AnalikIsgoremezlikRaporDVO)((ITTObject)this).GetParent("ANALIKRAPOR"); }
            set { this["ANALIKRAPOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public RaporCevapTCKimlikNodanDVO RaporCevapTCKimlikNodanDVO
        {
            get { return (RaporCevapTCKimlikNodanDVO)((ITTObject)this).GetParent("RAPORCEVAPTCKIMLIKNODANDVO"); }
            set { this["RAPORCEVAPTCKIMLIKNODANDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateisgoremezlikRaporEkleriCollection()
        {
            _isgoremezlikRaporEkleri = new IsgoremezlikRaporEkDVO.ChildIsgoremezlikRaporEkDVOCollection(this, new Guid("ed033779-b911-406a-8c10-5280630c0be9"));
            ((ITTChildObjectCollection)_isgoremezlikRaporEkleri).GetChildren();
        }

        protected IsgoremezlikRaporEkDVO.ChildIsgoremezlikRaporEkDVOCollection _isgoremezlikRaporEkleri = null;
        public IsgoremezlikRaporEkDVO.ChildIsgoremezlikRaporEkDVOCollection isgoremezlikRaporEkleri
        {
            get
            {
                if (_isgoremezlikRaporEkleri == null)
                    CreateisgoremezlikRaporEkleriCollection();
                return _isgoremezlikRaporEkleri;
            }
        }

        protected RaporCevapDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected RaporCevapDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected RaporCevapDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected RaporCevapDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected RaporCevapDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RAPORCEVAPDVO", dataRow) { }
        protected RaporCevapDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RAPORCEVAPDVO", dataRow, isImported) { }
        public RaporCevapDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public RaporCevapDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public RaporCevapDVO() : base() { }

    }
}