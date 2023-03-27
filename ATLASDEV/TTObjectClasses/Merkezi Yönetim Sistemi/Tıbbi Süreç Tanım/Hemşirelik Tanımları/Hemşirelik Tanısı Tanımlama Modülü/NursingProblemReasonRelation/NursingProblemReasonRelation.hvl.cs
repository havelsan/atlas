
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="NursingProblemReasonRelation")] 

    /// <summary>
    /// Hemşirelik Tanısı Neden İlişkisi
    /// </summary>
    public  partial class NursingProblemReasonRelation : TTDefinitionSet
    {
        public class NursingProblemReasonRelationList : TTObjectCollection<NursingProblemReasonRelation> { }
                    
        public class ChildNursingProblemReasonRelationCollection : TTObject.TTChildObjectCollection<NursingProblemReasonRelation>
        {
            public ChildNursingProblemReasonRelationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildNursingProblemReasonRelationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public NursingProblemDefinition NursingProblem
        {
            get { return (NursingProblemDefinition)((ITTObject)this).GetParent("NURSINGPROBLEM"); }
            set { this["NURSINGPROBLEM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public NursingReasonDefinition NursingReason
        {
            get { return (NursingReasonDefinition)((ITTObject)this).GetParent("NURSINGREASON"); }
            set { this["NURSINGREASON"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected NursingProblemReasonRelation(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected NursingProblemReasonRelation(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected NursingProblemReasonRelation(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected NursingProblemReasonRelation(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected NursingProblemReasonRelation(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "NURSINGPROBLEMREASONRELATION", dataRow) { }
        protected NursingProblemReasonRelation(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "NURSINGPROBLEMREASONRELATION", dataRow, isImported) { }
        public NursingProblemReasonRelation(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public NursingProblemReasonRelation(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public NursingProblemReasonRelation() : base() { }

    }
}