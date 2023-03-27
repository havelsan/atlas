
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="IntiharIzlemYontemi")] 

    public  partial class IntiharIzlemYontemi : TTObject
    {
        public class IntiharIzlemYontemiList : TTObjectCollection<IntiharIzlemYontemi> { }
                    
        public class ChildIntiharIzlemYontemiCollection : TTObject.TTChildObjectCollection<IntiharIzlemYontemi>
        {
            public ChildIntiharIzlemYontemiCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildIntiharIzlemYontemiCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public IntiharIzlemVeriSeti IntiharIzlemVeriSeti
        {
            get { return (IntiharIzlemVeriSeti)((ITTObject)this).GetParent("INTIHARIZLEMVERISETI"); }
            set { this["INTIHARIZLEMVERISETI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSICD SKRSICD
        {
            get { return (SKRSICD)((ITTObject)this).GetParent("SKRSICD"); }
            set { this["SKRSICD"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected IntiharIzlemYontemi(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected IntiharIzlemYontemi(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected IntiharIzlemYontemi(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected IntiharIzlemYontemi(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected IntiharIzlemYontemi(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "INTIHARIZLEMYONTEMI", dataRow) { }
        protected IntiharIzlemYontemi(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "INTIHARIZLEMYONTEMI", dataRow, isImported) { }
        public IntiharIzlemYontemi(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public IntiharIzlemYontemi(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public IntiharIzlemYontemi() : base() { }

    }
}