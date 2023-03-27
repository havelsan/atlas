
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DiagnosisCondition")] 

    public  partial class DiagnosisCondition : RuleConditionBase
    {
        public class DiagnosisConditionList : TTObjectCollection<DiagnosisCondition> { }
                    
        public class ChildDiagnosisConditionCollection : TTObject.TTChildObjectCollection<DiagnosisCondition>
        {
            public ChildDiagnosisConditionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDiagnosisConditionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Tanı
    /// </summary>
        public DiagnosisDefinition Diagnosis
        {
            get { return (DiagnosisDefinition)((ITTObject)this).GetParent("DIAGNOSIS"); }
            set { this["DIAGNOSIS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DiagnosisCondition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DiagnosisCondition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DiagnosisCondition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DiagnosisCondition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DiagnosisCondition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DIAGNOSISCONDITION", dataRow) { }
        protected DiagnosisCondition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DIAGNOSISCONDITION", dataRow, isImported) { }
        public DiagnosisCondition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DiagnosisCondition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DiagnosisCondition() : base() { }

    }
}