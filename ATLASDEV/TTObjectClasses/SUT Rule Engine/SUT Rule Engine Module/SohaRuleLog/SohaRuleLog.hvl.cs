
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SohaRuleLog")] 

    /// <summary>
    /// Log
    /// </summary>
    public  partial class SohaRuleLog : TTObject
    {
        public class SohaRuleLogList : TTObjectCollection<SohaRuleLog> { }
                    
        public class ChildSohaRuleLogCollection : TTObject.TTChildObjectCollection<SohaRuleLog>
        {
            public ChildSohaRuleLogCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSohaRuleLogCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// LogDate
    /// </summary>
        public DateTime? LogDate
        {
            get { return (DateTime?)this["LOGDATE"]; }
            set { this["LOGDATE"] = value; }
        }

    /// <summary>
    /// İşlem Tipi
    /// </summary>
        public OperationTypeEnum? LogType
        {
            get { return (OperationTypeEnum?)(int?)this["LOGTYPE"]; }
            set { this["LOGTYPE"] = value; }
        }

        public SohaRule SohaRule
        {
            get { return (SohaRule)((ITTObject)this).GetParent("SOHARULE"); }
            set { this["SOHARULE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResUser User
        {
            get { return (ResUser)((ITTObject)this).GetParent("USER"); }
            set { this["USER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected SohaRuleLog(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SohaRuleLog(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SohaRuleLog(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SohaRuleLog(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SohaRuleLog(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SOHARULELOG", dataRow) { }
        protected SohaRuleLog(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SOHARULELOG", dataRow, isImported) { }
        public SohaRuleLog(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SohaRuleLog(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SohaRuleLog() : base() { }

    }
}