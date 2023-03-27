
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="IntiharGirisimiYontemi")] 

    public  partial class IntiharGirisimiYontemi : TTObject
    {
        public class IntiharGirisimiYontemiList : TTObjectCollection<IntiharGirisimiYontemi> { }
                    
        public class ChildIntiharGirisimiYontemiCollection : TTObject.TTChildObjectCollection<IntiharGirisimiYontemi>
        {
            public ChildIntiharGirisimiYontemiCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildIntiharGirisimiYontemiCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public SKRSICD SKRSIntiharGirisimiYontemiICD
        {
            get { return (SKRSICD)((ITTObject)this).GetParent("SKRSINTIHARGIRISIMIYONTEMIICD"); }
            set { this["SKRSINTIHARGIRISIMIYONTEMIICD"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public IntiharGirisimKrizVeriSeti IntiharGirisimKrizVeriSeti
        {
            get { return (IntiharGirisimKrizVeriSeti)((ITTObject)this).GetParent("INTIHARGIRISIMKRIZVERISETI"); }
            set { this["INTIHARGIRISIMKRIZVERISETI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected IntiharGirisimiYontemi(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected IntiharGirisimiYontemi(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected IntiharGirisimiYontemi(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected IntiharGirisimiYontemi(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected IntiharGirisimiYontemi(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "INTIHARGIRISIMIYONTEMI", dataRow) { }
        protected IntiharGirisimiYontemi(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "INTIHARGIRISIMIYONTEMI", dataRow, isImported) { }
        public IntiharGirisimiYontemi(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public IntiharGirisimiYontemi(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public IntiharGirisimiYontemi() : base() { }

    }
}