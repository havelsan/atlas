
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MBSStudent")] 

    public  partial class MBSStudent : MBSPerson
    {
        public class MBSStudentList : TTObjectCollection<MBSStudent> { }
                    
        public class ChildMBSStudentCollection : TTObject.TTChildObjectCollection<MBSStudent>
        {
            public ChildMBSStudentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMBSStudentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Okul
    /// </summary>
        public string School
        {
            get { return (string)this["SCHOOL"]; }
            set { this["SCHOOL"] = value; }
        }

    /// <summary>
    /// Uyruk
    /// </summary>
        public string Citizen
        {
            get { return (string)this["CITIZEN"]; }
            set { this["CITIZEN"] = value; }
        }

    /// <summary>
    /// Sınıf
    /// </summary>
        public string Class
        {
            get { return (string)this["CLASS"]; }
            set { this["CLASS"] = value; }
        }

        protected MBSStudent(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MBSStudent(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MBSStudent(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MBSStudent(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MBSStudent(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MBSSTUDENT", dataRow) { }
        protected MBSStudent(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MBSSTUDENT", dataRow, isImported) { }
        public MBSStudent(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MBSStudent(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MBSStudent() : base() { }

    }
}