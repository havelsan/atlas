
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SKRSMahkumiyetTutuklulukDurumu")] 

    /// <summary>
    /// e1446d54-3538-47d8-9e56-04b31418cc41
    /// </summary>
    public  partial class SKRSMahkumiyetTutuklulukDurumu : BaseSKRSCommonDef
    {
        public class SKRSMahkumiyetTutuklulukDurumuList : TTObjectCollection<SKRSMahkumiyetTutuklulukDurumu> { }
                    
        public class ChildSKRSMahkumiyetTutuklulukDurumuCollection : TTObject.TTChildObjectCollection<SKRSMahkumiyetTutuklulukDurumu>
        {
            public ChildSKRSMahkumiyetTutuklulukDurumuCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSKRSMahkumiyetTutuklulukDurumuCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected SKRSMahkumiyetTutuklulukDurumu(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SKRSMahkumiyetTutuklulukDurumu(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SKRSMahkumiyetTutuklulukDurumu(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SKRSMahkumiyetTutuklulukDurumu(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SKRSMahkumiyetTutuklulukDurumu(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SKRSMAHKUMIYETTUTUKLULUKDURUMU", dataRow) { }
        protected SKRSMahkumiyetTutuklulukDurumu(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SKRSMAHKUMIYETTUTUKLULUKDURUMU", dataRow, isImported) { }
        public SKRSMahkumiyetTutuklulukDurumu(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SKRSMahkumiyetTutuklulukDurumu(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SKRSMahkumiyetTutuklulukDurumu() : base() { }

    }
}