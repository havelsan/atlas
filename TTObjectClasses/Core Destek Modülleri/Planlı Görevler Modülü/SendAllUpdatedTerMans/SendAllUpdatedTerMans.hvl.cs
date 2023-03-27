
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SendAllUpdatedTerMans")] 

    public  partial class SendAllUpdatedTerMans : BaseScheduledTask
    {
        public class SendAllUpdatedTerMansList : TTObjectCollection<SendAllUpdatedTerMans> { }
                    
        public class ChildSendAllUpdatedTerMansCollection : TTObject.TTChildObjectCollection<SendAllUpdatedTerMans>
        {
            public ChildSendAllUpdatedTerMansCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSendAllUpdatedTerMansCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<SendAllUpdatedTerMans> GetExecutions(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SENDALLUPDATEDTERMANS"].QueryDefs["GetExecutions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<SendAllUpdatedTerMans>(queryDef, paramList);
        }

        protected SendAllUpdatedTerMans(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SendAllUpdatedTerMans(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SendAllUpdatedTerMans(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SendAllUpdatedTerMans(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SendAllUpdatedTerMans(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SENDALLUPDATEDTERMANS", dataRow) { }
        protected SendAllUpdatedTerMans(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SENDALLUPDATEDTERMANS", dataRow, isImported) { }
        public SendAllUpdatedTerMans(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SendAllUpdatedTerMans(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SendAllUpdatedTerMans() : base() { }

    }
}