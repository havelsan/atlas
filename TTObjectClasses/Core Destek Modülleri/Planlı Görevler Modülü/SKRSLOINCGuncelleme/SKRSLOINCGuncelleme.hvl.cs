
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SKRSLOINCGuncelleme")] 

    /// <summary>
    /// SKRSLOINC Tablosunu Güncelleyen AutoScript
    /// </summary>
    public  partial class SKRSLOINCGuncelleme : BaseScheduledTask
    {
        public class SKRSLOINCGuncellemeList : TTObjectCollection<SKRSLOINCGuncelleme> { }
                    
        public class ChildSKRSLOINCGuncellemeCollection : TTObject.TTChildObjectCollection<SKRSLOINCGuncelleme>
        {
            public ChildSKRSLOINCGuncellemeCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSKRSLOINCGuncellemeCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected SKRSLOINCGuncelleme(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SKRSLOINCGuncelleme(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SKRSLOINCGuncelleme(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SKRSLOINCGuncelleme(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SKRSLOINCGuncelleme(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SKRSLOINCGUNCELLEME", dataRow) { }
        protected SKRSLOINCGuncelleme(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SKRSLOINCGUNCELLEME", dataRow, isImported) { }
        public SKRSLOINCGuncelleme(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SKRSLOINCGuncelleme(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SKRSLOINCGuncelleme() : base() { }

    }
}