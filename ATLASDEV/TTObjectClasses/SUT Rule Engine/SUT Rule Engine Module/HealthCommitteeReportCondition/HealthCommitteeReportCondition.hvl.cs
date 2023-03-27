
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HealthCommitteeReportCondition")] 

    public  partial class HealthCommitteeReportCondition : RuleConditionBase
    {
        public class HealthCommitteeReportConditionList : TTObjectCollection<HealthCommitteeReportCondition> { }
                    
        public class ChildHealthCommitteeReportConditionCollection : TTObject.TTChildObjectCollection<HealthCommitteeReportCondition>
        {
            public ChildHealthCommitteeReportConditionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHealthCommitteeReportConditionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected HealthCommitteeReportCondition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HealthCommitteeReportCondition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HealthCommitteeReportCondition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HealthCommitteeReportCondition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HealthCommitteeReportCondition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HEALTHCOMMITTEEREPORTCONDITION", dataRow) { }
        protected HealthCommitteeReportCondition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HEALTHCOMMITTEEREPORTCONDITION", dataRow, isImported) { }
        public HealthCommitteeReportCondition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HealthCommitteeReportCondition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HealthCommitteeReportCondition() : base() { }

    }
}