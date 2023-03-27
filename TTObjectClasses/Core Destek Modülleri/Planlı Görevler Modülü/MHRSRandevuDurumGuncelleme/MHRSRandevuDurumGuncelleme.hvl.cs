
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MHRSRandevuDurumGuncelleme")] 

    /// <summary>
    /// MHRS Randevu Durum Güncelleme
    /// </summary>
    public  partial class MHRSRandevuDurumGuncelleme : BaseScheduledTask
    {
        public class MHRSRandevuDurumGuncellemeList : TTObjectCollection<MHRSRandevuDurumGuncelleme> { }
                    
        public class ChildMHRSRandevuDurumGuncellemeCollection : TTObject.TTChildObjectCollection<MHRSRandevuDurumGuncelleme>
        {
            public ChildMHRSRandevuDurumGuncellemeCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMHRSRandevuDurumGuncellemeCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected MHRSRandevuDurumGuncelleme(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MHRSRandevuDurumGuncelleme(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MHRSRandevuDurumGuncelleme(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MHRSRandevuDurumGuncelleme(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MHRSRandevuDurumGuncelleme(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MHRSRANDEVUDURUMGUNCELLEME", dataRow) { }
        protected MHRSRandevuDurumGuncelleme(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MHRSRANDEVUDURUMGUNCELLEME", dataRow, isImported) { }
        public MHRSRandevuDurumGuncelleme(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MHRSRandevuDurumGuncelleme(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MHRSRandevuDurumGuncelleme() : base() { }

    }
}