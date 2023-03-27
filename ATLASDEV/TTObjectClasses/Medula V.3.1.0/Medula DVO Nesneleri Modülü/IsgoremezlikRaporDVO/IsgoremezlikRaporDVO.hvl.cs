
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="IsgoremezlikRaporDVO")] 

    public  partial class IsgoremezlikRaporDVO : BaseMedulaObject
    {
        public class IsgoremezlikRaporDVOList : TTObjectCollection<IsgoremezlikRaporDVO> { }
                    
        public class ChildIsgoremezlikRaporDVOCollection : TTObject.TTChildObjectCollection<IsgoremezlikRaporDVO>
        {
            public ChildIsgoremezlikRaporDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildIsgoremezlikRaporDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public string kontrolMu
        {
            get { return (string)this["KONTROLMU"]; }
            set { this["KONTROLMU"] = value; }
        }

        public string kontrolTarihi
        {
            get { return (string)this["KONTROLTARIHI"]; }
            set { this["KONTROLTARIHI"] = value; }
        }

        public string hastaYatisVarMi
        {
            get { return (string)this["HASTAYATISVARMI"]; }
            set { this["HASTAYATISVARMI"] = value; }
        }

        public RaporDVO raporDVO
        {
            get { return (RaporDVO)((ITTObject)this).GetParent("RAPORDVO"); }
            set { this["RAPORDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateyatislarCollection()
        {
            _yatislar = new HastaYatisBilgisi_RaporDVO.ChildHastaYatisBilgisi_RaporDVOCollection(this, new Guid("7c489b92-7082-4fb5-925e-6c801c042d76"));
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

        protected IsgoremezlikRaporDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected IsgoremezlikRaporDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected IsgoremezlikRaporDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected IsgoremezlikRaporDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected IsgoremezlikRaporDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ISGOREMEZLIKRAPORDVO", dataRow) { }
        protected IsgoremezlikRaporDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ISGOREMEZLIKRAPORDVO", dataRow, isImported) { }
        public IsgoremezlikRaporDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public IsgoremezlikRaporDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public IsgoremezlikRaporDVO() : base() { }

    }
}