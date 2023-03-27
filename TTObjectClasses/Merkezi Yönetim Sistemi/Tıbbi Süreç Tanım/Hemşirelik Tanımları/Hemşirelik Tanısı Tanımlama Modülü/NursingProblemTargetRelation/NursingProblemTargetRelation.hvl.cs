
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="NursingProblemTargetRelation")] 

    /// <summary>
    /// Hemşirelik Tanısı Hedef İlişkisi
    /// </summary>
    public  partial class NursingProblemTargetRelation : TTDefinitionSet
    {
        public class NursingProblemTargetRelationList : TTObjectCollection<NursingProblemTargetRelation> { }
                    
        public class ChildNursingProblemTargetRelationCollection : TTObject.TTChildObjectCollection<NursingProblemTargetRelation>
        {
            public ChildNursingProblemTargetRelationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildNursingProblemTargetRelationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public NursingProblemDefinition NursingProblem
        {
            get { return (NursingProblemDefinition)((ITTObject)this).GetParent("NURSINGPROBLEM"); }
            set { this["NURSINGPROBLEM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public NursingTargetDefinition NursingTarget
        {
            get { return (NursingTargetDefinition)((ITTObject)this).GetParent("NURSINGTARGET"); }
            set { this["NURSINGTARGET"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected NursingProblemTargetRelation(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected NursingProblemTargetRelation(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected NursingProblemTargetRelation(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected NursingProblemTargetRelation(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected NursingProblemTargetRelation(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "NURSINGPROBLEMTARGETRELATION", dataRow) { }
        protected NursingProblemTargetRelation(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "NURSINGPROBLEMTARGETRELATION", dataRow, isImported) { }
        public NursingProblemTargetRelation(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public NursingProblemTargetRelation(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public NursingProblemTargetRelation() : base() { }

    }
}