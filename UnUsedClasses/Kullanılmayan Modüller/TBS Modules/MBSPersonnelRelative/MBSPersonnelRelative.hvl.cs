
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MBSPersonnelRelative")] 

    public  partial class MBSPersonnelRelative : MBSPerson
    {
        public class MBSPersonnelRelativeList : TTObjectCollection<MBSPersonnelRelative> { }
                    
        public class ChildMBSPersonnelRelativeCollection : TTObject.TTChildObjectCollection<MBSPersonnelRelative>
        {
            public ChildMBSPersonnelRelativeCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMBSPersonnelRelativeCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Sabit Unsur
    /// </summary>
        public double? FixPrice
        {
            get { return (double?)this["FIXPRICE"]; }
            set { this["FIXPRICE"] = value; }
        }

    /// <summary>
    /// Akrabalık
    /// </summary>
        public string Relationship
        {
            get { return (string)this["RELATIONSHIP"]; }
            set { this["RELATIONSHIP"] = value; }
        }

        protected MBSPersonnelRelative(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MBSPersonnelRelative(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MBSPersonnelRelative(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MBSPersonnelRelative(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MBSPersonnelRelative(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MBSPERSONNELRELATIVE", dataRow) { }
        protected MBSPersonnelRelative(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MBSPERSONNELRELATIVE", dataRow, isImported) { }
        public MBSPersonnelRelative(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MBSPersonnelRelative(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MBSPersonnelRelative() : base() { }

    }
}