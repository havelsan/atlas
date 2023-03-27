
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SKRSOlayAfetBilgisiGetir")] 

    /// <summary>
    /// Olay Afet Bilgisini SKRS den çeker
    /// </summary>
    public  partial class SKRSOlayAfetBilgisiGetir : BaseScheduledTask
    {
        public class SKRSOlayAfetBilgisiGetirList : TTObjectCollection<SKRSOlayAfetBilgisiGetir> { }
                    
        public class ChildSKRSOlayAfetBilgisiGetirCollection : TTObject.TTChildObjectCollection<SKRSOlayAfetBilgisiGetir>
        {
            public ChildSKRSOlayAfetBilgisiGetirCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSKRSOlayAfetBilgisiGetirCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected SKRSOlayAfetBilgisiGetir(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SKRSOlayAfetBilgisiGetir(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SKRSOlayAfetBilgisiGetir(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SKRSOlayAfetBilgisiGetir(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SKRSOlayAfetBilgisiGetir(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SKRSOLAYAFETBILGISIGETIR", dataRow) { }
        protected SKRSOlayAfetBilgisiGetir(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SKRSOLAYAFETBILGISIGETIR", dataRow, isImported) { }
        public SKRSOlayAfetBilgisiGetir(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SKRSOlayAfetBilgisiGetir(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SKRSOlayAfetBilgisiGetir() : base() { }

    }
}