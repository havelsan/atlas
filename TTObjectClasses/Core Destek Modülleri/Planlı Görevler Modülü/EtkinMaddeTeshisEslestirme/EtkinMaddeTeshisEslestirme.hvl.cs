
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="EtkinMaddeTeshisEslestirme")] 

    public  partial class EtkinMaddeTeshisEslestirme : BaseScheduledTask
    {
        public class EtkinMaddeTeshisEslestirmeList : TTObjectCollection<EtkinMaddeTeshisEslestirme> { }
                    
        public class ChildEtkinMaddeTeshisEslestirmeCollection : TTObject.TTChildObjectCollection<EtkinMaddeTeshisEslestirme>
        {
            public ChildEtkinMaddeTeshisEslestirmeCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildEtkinMaddeTeshisEslestirmeCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected EtkinMaddeTeshisEslestirme(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected EtkinMaddeTeshisEslestirme(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected EtkinMaddeTeshisEslestirme(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected EtkinMaddeTeshisEslestirme(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected EtkinMaddeTeshisEslestirme(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ETKINMADDETESHISESLESTIRME", dataRow) { }
        protected EtkinMaddeTeshisEslestirme(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ETKINMADDETESHISESLESTIRME", dataRow, isImported) { }
        public EtkinMaddeTeshisEslestirme(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public EtkinMaddeTeshisEslestirme(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public EtkinMaddeTeshisEslestirme() : base() { }

    }
}