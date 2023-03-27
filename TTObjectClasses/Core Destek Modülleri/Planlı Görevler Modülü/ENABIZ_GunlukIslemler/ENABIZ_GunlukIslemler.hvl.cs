
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ENABIZ_GunlukIslemler")] 

    public  partial class ENABIZ_GunlukIslemler : BaseScheduledTask
    {
        public class ENABIZ_GunlukIslemlerList : TTObjectCollection<ENABIZ_GunlukIslemler> { }
                    
        public class ChildENABIZ_GunlukIslemlerCollection : TTObject.TTChildObjectCollection<ENABIZ_GunlukIslemler>
        {
            public ChildENABIZ_GunlukIslemlerCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildENABIZ_GunlukIslemlerCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected ENABIZ_GunlukIslemler(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ENABIZ_GunlukIslemler(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ENABIZ_GunlukIslemler(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ENABIZ_GunlukIslemler(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ENABIZ_GunlukIslemler(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ENABIZ_GUNLUKISLEMLER", dataRow) { }
        protected ENABIZ_GunlukIslemler(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ENABIZ_GUNLUKISLEMLER", dataRow, isImported) { }
        public ENABIZ_GunlukIslemler(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ENABIZ_GunlukIslemler(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ENABIZ_GunlukIslemler() : base() { }

    }
}