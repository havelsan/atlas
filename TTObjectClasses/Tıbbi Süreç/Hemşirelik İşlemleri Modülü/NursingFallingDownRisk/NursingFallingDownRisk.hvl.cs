
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="NursingFallingDownRisk")] 

    public  partial class NursingFallingDownRisk : TTObject
    {
        public class NursingFallingDownRiskList : TTObjectCollection<NursingFallingDownRisk> { }
                    
        public class ChildNursingFallingDownRiskCollection : TTObject.TTChildObjectCollection<NursingFallingDownRisk>
        {
            public ChildNursingFallingDownRiskCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildNursingFallingDownRiskCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Tarih
    /// </summary>
        public DateTime? ActionDate
        {
            get { return (DateTime?)this["ACTIONDATE"]; }
            set { this["ACTIONDATE"] = value; }
        }

    /// <summary>
    /// Risk Faktörü
    /// </summary>
        public FallingDownRiskDefinition RiskFactor
        {
            get { return (FallingDownRiskDefinition)((ITTObject)this).GetParent("RISKFACTOR"); }
            set { this["RISKFACTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public BaseNursingFallingDownRisk BaseNursingFallingDownRisk
        {
            get { return (BaseNursingFallingDownRisk)((ITTObject)this).GetParent("BASENURSINGFALLINGDOWNRISK"); }
            set { this["BASENURSINGFALLINGDOWNRISK"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected NursingFallingDownRisk(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected NursingFallingDownRisk(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected NursingFallingDownRisk(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected NursingFallingDownRisk(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected NursingFallingDownRisk(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "NURSINGFALLINGDOWNRISK", dataRow) { }
        protected NursingFallingDownRisk(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "NURSINGFALLINGDOWNRISK", dataRow, isImported) { }
        public NursingFallingDownRisk(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public NursingFallingDownRisk(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public NursingFallingDownRisk() : base() { }

    }
}