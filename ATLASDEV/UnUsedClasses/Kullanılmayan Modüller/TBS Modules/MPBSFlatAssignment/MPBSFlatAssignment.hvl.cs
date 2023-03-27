
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MPBSFlatAssignment")] 

    /// <summary>
    /// Daire Tahsis
    /// </summary>
    public  partial class MPBSFlatAssignment : TTObject
    {
        public class MPBSFlatAssignmentList : TTObjectCollection<MPBSFlatAssignment> { }
                    
        public class ChildMPBSFlatAssignmentCollection : TTObject.TTChildObjectCollection<MPBSFlatAssignment>
        {
            public ChildMPBSFlatAssignmentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMPBSFlatAssignmentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Çıkış Tarihi
    /// </summary>
        public DateTime? MoveOutDate
        {
            get { return (DateTime?)this["MOVEOUTDATE"]; }
            set { this["MOVEOUTDATE"] = value; }
        }

    /// <summary>
    /// Giriş Tarihi
    /// </summary>
        public DateTime? MoveInDate
        {
            get { return (DateTime?)this["MOVEINDATE"]; }
            set { this["MOVEINDATE"] = value; }
        }

        protected MPBSFlatAssignment(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MPBSFlatAssignment(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MPBSFlatAssignment(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MPBSFlatAssignment(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MPBSFlatAssignment(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MPBSFLATASSIGNMENT", dataRow) { }
        protected MPBSFlatAssignment(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MPBSFLATASSIGNMENT", dataRow, isImported) { }
        public MPBSFlatAssignment(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MPBSFlatAssignment(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MPBSFlatAssignment() : base() { }

    }
}