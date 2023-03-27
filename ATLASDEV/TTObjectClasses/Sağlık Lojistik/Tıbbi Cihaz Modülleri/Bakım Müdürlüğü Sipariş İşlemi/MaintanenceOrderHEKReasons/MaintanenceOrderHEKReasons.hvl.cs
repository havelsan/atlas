
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MaintanenceOrderHEKReasons")] 

    public  partial class MaintanenceOrderHEKReasons : TTObject
    {
        public class MaintanenceOrderHEKReasonsList : TTObjectCollection<MaintanenceOrderHEKReasons> { }
                    
        public class ChildMaintanenceOrderHEKReasonsCollection : TTObject.TTChildObjectCollection<MaintanenceOrderHEKReasons>
        {
            public ChildMaintanenceOrderHEKReasonsCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMaintanenceOrderHEKReasonsCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public bool? Check
        {
            get { return (bool?)this["CHECK"]; }
            set { this["CHECK"] = value; }
        }

    /// <summary>
    /// CousesOfTheHekDefinition
    /// </summary>
        public CousesOfTheHekDefinition CousesOfTheHekDefinition
        {
            get { return (CousesOfTheHekDefinition)((ITTObject)this).GetParent("COUSESOFTHEHEKDEFINITION"); }
            set { this["COUSESOFTHEHEKDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// MaintenanceOrder
    /// </summary>
        public MaintenanceOrder MaintenanceOrder
        {
            get { return (MaintenanceOrder)((ITTObject)this).GetParent("MAINTENANCEORDER"); }
            set { this["MAINTENANCEORDER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MaintanenceOrderHEKReasons(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MaintanenceOrderHEKReasons(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MaintanenceOrderHEKReasons(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MaintanenceOrderHEKReasons(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MaintanenceOrderHEKReasons(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MAINTANENCEORDERHEKREASONS", dataRow) { }
        protected MaintanenceOrderHEKReasons(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MAINTANENCEORDERHEKREASONS", dataRow, isImported) { }
        public MaintanenceOrderHEKReasons(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MaintanenceOrderHEKReasons(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MaintanenceOrderHEKReasons() : base() { }

    }
}