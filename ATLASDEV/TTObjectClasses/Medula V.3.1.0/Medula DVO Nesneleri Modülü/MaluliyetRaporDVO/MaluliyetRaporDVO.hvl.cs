
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MaluliyetRaporDVO")] 

    public  partial class MaluliyetRaporDVO : BaseMedulaObject
    {
        public class MaluliyetRaporDVOList : TTObjectCollection<MaluliyetRaporDVO> { }
                    
        public class ChildMaluliyetRaporDVOCollection : TTObject.TTChildObjectCollection<MaluliyetRaporDVO>
        {
            public ChildMaluliyetRaporDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMaluliyetRaporDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public string maluliyetYuzdesi
        {
            get { return (string)this["MALULIYETYUZDESI"]; }
            set { this["MALULIYETYUZDESI"] = value; }
        }

        public string aciklama
        {
            get { return (string)this["ACIKLAMA"]; }
            set { this["ACIKLAMA"] = value; }
        }

        public RaporDVO raporDVO
        {
            get { return (RaporDVO)((ITTObject)this).GetParent("RAPORDVO"); }
            set { this["RAPORDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreatebransGorusleriCollection()
        {
            _bransGorusleri = new BransGorusBilgisiDVO.ChildBransGorusBilgisiDVOCollection(this, new Guid("f066fcc0-9707-4879-802c-bb39e9569c53"));
            ((ITTChildObjectCollection)_bransGorusleri).GetChildren();
        }

        protected BransGorusBilgisiDVO.ChildBransGorusBilgisiDVOCollection _bransGorusleri = null;
        public BransGorusBilgisiDVO.ChildBransGorusBilgisiDVOCollection bransGorusleri
        {
            get
            {
                if (_bransGorusleri == null)
                    CreatebransGorusleriCollection();
                return _bransGorusleri;
            }
        }

        protected MaluliyetRaporDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MaluliyetRaporDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MaluliyetRaporDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MaluliyetRaporDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MaluliyetRaporDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MALULIYETRAPORDVO", dataRow) { }
        protected MaluliyetRaporDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MALULIYETRAPORDVO", dataRow, isImported) { }
        public MaluliyetRaporDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MaluliyetRaporDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MaluliyetRaporDVO() : base() { }

    }
}