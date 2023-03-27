
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DiagnosisRuleSet")] 

    public  partial class DiagnosisRuleSet : TTObject
    {
        public class DiagnosisRuleSetList : TTObjectCollection<DiagnosisRuleSet> { }
                    
        public class ChildDiagnosisRuleSetCollection : TTObject.TTChildObjectCollection<DiagnosisRuleSet>
        {
            public ChildDiagnosisRuleSetCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDiagnosisRuleSetCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Tanı-Tanı Kural Setleri
    /// </summary>
        public DiagnosisDefinition Diagnosis
        {
            get { return (DiagnosisDefinition)((ITTObject)this).GetParent("DIAGNOSIS"); }
            set { this["DIAGNOSIS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Kural Seti-Tanı Kural Setleri
    /// </summary>
        public RuleSet RuleSet
        {
            get { return (RuleSet)((ITTObject)this).GetParent("RULESET"); }
            set { this["RULESET"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DiagnosisRuleSet(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DiagnosisRuleSet(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DiagnosisRuleSet(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DiagnosisRuleSet(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DiagnosisRuleSet(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DIAGNOSISRULESET", dataRow) { }
        protected DiagnosisRuleSet(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DIAGNOSISRULESET", dataRow, isImported) { }
        public DiagnosisRuleSet(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DiagnosisRuleSet(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DiagnosisRuleSet() : base() { }

    }
}