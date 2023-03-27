
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BirSonrakiHizmetIhtiyaci")] 

    public  partial class BirSonrakiHizmetIhtiyaci : TTObject
    {
        public class BirSonrakiHizmetIhtiyaciList : TTObjectCollection<BirSonrakiHizmetIhtiyaci> { }
                    
        public class ChildBirSonrakiHizmetIhtiyaciCollection : TTObject.TTChildObjectCollection<BirSonrakiHizmetIhtiyaci>
        {
            public ChildBirSonrakiHizmetIhtiyaciCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBirSonrakiHizmetIhtiyaciCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public EvdeSaglikIzlemVeriSeti EvdeSaglikIzlemVeriSeti
        {
            get { return (EvdeSaglikIzlemVeriSeti)((ITTObject)this).GetParent("EVDESAGLIKIZLEMVERISETI"); }
            set { this["EVDESAGLIKIZLEMVERISETI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSBirSonrakiHizmetIhtiyaci SKRSBirSonrakiHizmetIhtiyaci
        {
            get { return (SKRSBirSonrakiHizmetIhtiyaci)((ITTObject)this).GetParent("SKRSBIRSONRAKIHIZMETIHTIYACI"); }
            set { this["SKRSBIRSONRAKIHIZMETIHTIYACI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected BirSonrakiHizmetIhtiyaci(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BirSonrakiHizmetIhtiyaci(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BirSonrakiHizmetIhtiyaci(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BirSonrakiHizmetIhtiyaci(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BirSonrakiHizmetIhtiyaci(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BIRSONRAKIHIZMETIHTIYACI", dataRow) { }
        protected BirSonrakiHizmetIhtiyaci(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BIRSONRAKIHIZMETIHTIYACI", dataRow, isImported) { }
        public BirSonrakiHizmetIhtiyaci(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BirSonrakiHizmetIhtiyaci(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BirSonrakiHizmetIhtiyaci() : base() { }

    }
}