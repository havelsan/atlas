
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="IlacRaporDVO")] 

    public  partial class IlacRaporDVO : BaseMedulaObject
    {
        public class IlacRaporDVOList : TTObjectCollection<IlacRaporDVO> { }
                    
        public class ChildIlacRaporDVOCollection : TTObject.TTChildObjectCollection<IlacRaporDVO>
        {
            public ChildIlacRaporDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildIlacRaporDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public string takipFormuNo
        {
            get { return (string)this["TAKIPFORMUNO"]; }
            set { this["TAKIPFORMUNO"] = value; }
        }

        public RaporDVO raporDVO
        {
            get { return (RaporDVO)((ITTObject)this).GetParent("RAPORDVO"); }
            set { this["RAPORDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateraporEtkinMaddelerCollection()
        {
            _raporEtkinMaddeler = new RaporEtkinMaddeDVO.ChildRaporEtkinMaddeDVOCollection(this, new Guid("369d6f46-185d-4448-a211-cfc8ff7b98e8"));
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

        protected IlacRaporDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected IlacRaporDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected IlacRaporDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected IlacRaporDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected IlacRaporDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ILACRAPORDVO", dataRow) { }
        protected IlacRaporDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ILACRAPORDVO", dataRow, isImported) { }
        public IlacRaporDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public IlacRaporDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public IlacRaporDVO() : base() { }

    }
}