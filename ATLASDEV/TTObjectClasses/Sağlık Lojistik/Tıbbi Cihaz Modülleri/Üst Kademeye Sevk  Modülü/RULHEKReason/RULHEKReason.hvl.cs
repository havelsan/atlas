
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="RULHEKReason")] 

    public  partial class RULHEKReason : TTObject
    {
        public class RULHEKReasonList : TTObjectCollection<RULHEKReason> { }
                    
        public class ChildRULHEKReasonCollection : TTObject.TTChildObjectCollection<RULHEKReason>
        {
            public ChildRULHEKReasonCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildRULHEKReasonCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Seç
    /// </summary>
        public bool? Check
        {
            get { return (bool?)this["CHECK"]; }
            set { this["CHECK"] = value; }
        }

        public CousesOfTheHekDefinition CousesOfTheHekDefinition
        {
            get { return (CousesOfTheHekDefinition)((ITTObject)this).GetParent("COUSESOFTHEHEKDEFINITION"); }
            set { this["COUSESOFTHEHEKDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ReferToUpperLevel ReferToUpperLevel
        {
            get { return (ReferToUpperLevel)((ITTObject)this).GetParent("REFERTOUPPERLEVEL"); }
            set { this["REFERTOUPPERLEVEL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Repair Repair
        {
            get { return (Repair)((ITTObject)this).GetParent("REPAIR"); }
            set { this["REPAIR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected RULHEKReason(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected RULHEKReason(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected RULHEKReason(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected RULHEKReason(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected RULHEKReason(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RULHEKREASON", dataRow) { }
        protected RULHEKReason(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RULHEKREASON", dataRow, isImported) { }
        public RULHEKReason(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public RULHEKReason(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public RULHEKReason() : base() { }

    }
}