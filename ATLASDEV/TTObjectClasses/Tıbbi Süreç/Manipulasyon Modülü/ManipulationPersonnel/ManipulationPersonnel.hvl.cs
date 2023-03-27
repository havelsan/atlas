
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ManipulationPersonnel")] 

    public  partial class ManipulationPersonnel : TTObject
    {
        public class ManipulationPersonnelList : TTObjectCollection<ManipulationPersonnel> { }
                    
        public class ChildManipulationPersonnelCollection : TTObject.TTChildObjectCollection<ManipulationPersonnel>
        {
            public ChildManipulationPersonnelCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildManipulationPersonnelCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// RTF
    /// </summary>
        public object RTF
        {
            get { return (object)this["RTF"]; }
            set { this["RTF"] = value; }
        }

    /// <summary>
    /// Uygulama Personeli
    /// </summary>
        public ResUser Personnel
        {
            get { return (ResUser)((ITTObject)this).GetParent("PERSONNEL"); }
            set { this["PERSONNEL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Manipulation Manipulation
        {
            get { return (Manipulation)((ITTObject)this).GetParent("MANIPULATION"); }
            set { this["MANIPULATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ManipulationPersonnel(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ManipulationPersonnel(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ManipulationPersonnel(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ManipulationPersonnel(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ManipulationPersonnel(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MANIPULATIONPERSONNEL", dataRow) { }
        protected ManipulationPersonnel(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MANIPULATIONPERSONNEL", dataRow, isImported) { }
        public ManipulationPersonnel(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ManipulationPersonnel(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ManipulationPersonnel() : base() { }

    }
}