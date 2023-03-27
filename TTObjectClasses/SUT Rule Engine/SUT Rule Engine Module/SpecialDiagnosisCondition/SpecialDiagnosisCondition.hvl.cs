
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SpecialDiagnosisCondition")] 

    public  partial class SpecialDiagnosisCondition : RuleConditionBase
    {
        public class SpecialDiagnosisConditionList : TTObjectCollection<SpecialDiagnosisCondition> { }
                    
        public class ChildSpecialDiagnosisConditionCollection : TTObject.TTChildObjectCollection<SpecialDiagnosisCondition>
        {
            public ChildSpecialDiagnosisConditionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSpecialDiagnosisConditionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected SpecialDiagnosisCondition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SpecialDiagnosisCondition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SpecialDiagnosisCondition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SpecialDiagnosisCondition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SpecialDiagnosisCondition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SPECIALDIAGNOSISCONDITION", dataRow) { }
        protected SpecialDiagnosisCondition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SPECIALDIAGNOSISCONDITION", dataRow, isImported) { }
        public SpecialDiagnosisCondition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SpecialDiagnosisCondition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SpecialDiagnosisCondition() : base() { }

    }
}