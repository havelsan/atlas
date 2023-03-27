
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="NursingProblemCareRelation")] 

    /// <summary>
    /// Hemşirelik Tanısı Girişim İlişkisi
    /// </summary>
    public  partial class NursingProblemCareRelation : TerminologyManagerDef
    {
        public class NursingProblemCareRelationList : TTObjectCollection<NursingProblemCareRelation> { }
                    
        public class ChildNursingProblemCareRelationCollection : TTObject.TTChildObjectCollection<NursingProblemCareRelation>
        {
            public ChildNursingProblemCareRelationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildNursingProblemCareRelationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public NursingProblemDefinition NursingProblem
        {
            get { return (NursingProblemDefinition)((ITTObject)this).GetParent("NURSINGPROBLEM"); }
            set { this["NURSINGPROBLEM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public NursingCareDefinition NursingCare
        {
            get { return (NursingCareDefinition)((ITTObject)this).GetParent("NURSINGCARE"); }
            set { this["NURSINGCARE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected NursingProblemCareRelation(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected NursingProblemCareRelation(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected NursingProblemCareRelation(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected NursingProblemCareRelation(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected NursingProblemCareRelation(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "NURSINGPROBLEMCARERELATION", dataRow) { }
        protected NursingProblemCareRelation(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "NURSINGPROBLEMCARERELATION", dataRow, isImported) { }
        public NursingProblemCareRelation(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public NursingProblemCareRelation(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public NursingProblemCareRelation() : base() { }

    }
}