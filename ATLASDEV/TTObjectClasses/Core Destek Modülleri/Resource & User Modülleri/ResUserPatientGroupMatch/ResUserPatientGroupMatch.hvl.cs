
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ResUserPatientGroupMatch")] 

    /// <summary>
    /// ResUser PatientGroup Eşleştirme
    /// </summary>
    public  partial class ResUserPatientGroupMatch : TTObject
    {
        public class ResUserPatientGroupMatchList : TTObjectCollection<ResUserPatientGroupMatch> { }
                    
        public class ChildResUserPatientGroupMatchCollection : TTObject.TTChildObjectCollection<ResUserPatientGroupMatch>
        {
            public ChildResUserPatientGroupMatchCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildResUserPatientGroupMatchCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// IsAssignable
    /// </summary>
        public bool? IsAssignable
        {
            get { return (bool?)this["ISASSIGNABLE"]; }
            set { this["ISASSIGNABLE"] = value; }
        }

        public PatientGroupDefinition PatientGroup
        {
            get { return (PatientGroupDefinition)((ITTObject)this).GetParent("PATIENTGROUP"); }
            set { this["PATIENTGROUP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResUser ResUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESUSER"); }
            set { this["RESUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ResUserPatientGroupMatch(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ResUserPatientGroupMatch(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ResUserPatientGroupMatch(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ResUserPatientGroupMatch(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ResUserPatientGroupMatch(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RESUSERPATIENTGROUPMATCH", dataRow) { }
        protected ResUserPatientGroupMatch(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RESUSERPATIENTGROUPMATCH", dataRow, isImported) { }
        public ResUserPatientGroupMatch(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ResUserPatientGroupMatch(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ResUserPatientGroupMatch() : base() { }

    }
}