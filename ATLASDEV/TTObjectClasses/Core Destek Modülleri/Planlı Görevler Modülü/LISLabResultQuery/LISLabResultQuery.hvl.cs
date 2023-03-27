
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="LISLabResultQuery")] 

    /// <summary>
    /// Laboratuvar Sonuçlarını LIS den Sorgulama
    /// </summary>
    public  partial class LISLabResultQuery : BaseScheduledTask
    {
        public class LISLabResultQueryList : TTObjectCollection<LISLabResultQuery> { }
                    
        public class ChildLISLabResultQueryCollection : TTObject.TTChildObjectCollection<LISLabResultQuery>
        {
            public ChildLISLabResultQueryCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildLISLabResultQueryCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected LISLabResultQuery(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected LISLabResultQuery(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected LISLabResultQuery(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected LISLabResultQuery(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected LISLabResultQuery(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "LISLABRESULTQUERY", dataRow) { }
        protected LISLabResultQuery(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "LISLABRESULTQUERY", dataRow, isImported) { }
        public LISLabResultQuery(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public LISLabResultQuery(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public LISLabResultQuery() : base() { }

    }
}