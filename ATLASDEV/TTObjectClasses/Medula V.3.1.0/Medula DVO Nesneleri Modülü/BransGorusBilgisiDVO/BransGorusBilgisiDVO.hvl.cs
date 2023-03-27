
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BransGorusBilgisiDVO")] 

    public  partial class BransGorusBilgisiDVO : BaseMedulaObject
    {
        public class BransGorusBilgisiDVOList : TTObjectCollection<BransGorusBilgisiDVO> { }
                    
        public class ChildBransGorusBilgisiDVOCollection : TTObject.TTChildObjectCollection<BransGorusBilgisiDVO>
        {
            public ChildBransGorusBilgisiDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBransGorusBilgisiDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public string bransKodu
        {
            get { return (string)this["BRANSKODU"]; }
            set { this["BRANSKODU"] = value; }
        }

        public string aciklama
        {
            get { return (string)this["ACIKLAMA"]; }
            set { this["ACIKLAMA"] = value; }
        }

        public MaluliyetRaporDVO MaluliyetRaporDVO
        {
            get { return (MaluliyetRaporDVO)((ITTObject)this).GetParent("MALULIYETRAPORDVO"); }
            set { this["MALULIYETRAPORDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected BransGorusBilgisiDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BransGorusBilgisiDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BransGorusBilgisiDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BransGorusBilgisiDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BransGorusBilgisiDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BRANSGORUSBILGISIDVO", dataRow) { }
        protected BransGorusBilgisiDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BRANSGORUSBILGISIDVO", dataRow, isImported) { }
        public BransGorusBilgisiDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BransGorusBilgisiDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BransGorusBilgisiDVO() : base() { }

    }
}