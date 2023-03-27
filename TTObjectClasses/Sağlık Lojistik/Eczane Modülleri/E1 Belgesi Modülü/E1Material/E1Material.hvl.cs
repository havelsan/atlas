
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="E1Material")] 

    public  partial class E1Material : StockActionDetailOut
    {
        public class E1MaterialList : TTObjectCollection<E1Material> { }
                    
        public class ChildE1MaterialCollection : TTObject.TTChildObjectCollection<E1Material>
        {
            public ChildE1MaterialCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildE1MaterialCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Karantina No
    /// </summary>
        public string QuarantineNO
        {
            get { return (string)this["QUARANTINENO"]; }
            set { this["QUARANTINENO"] = value; }
        }

    /// <summary>
    /// Mevcut
    /// </summary>
        public Currency? Inheld
        {
            get { return (Currency?)this["INHELD"]; }
            set { this["INHELD"] = value; }
        }

        protected E1Material(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected E1Material(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected E1Material(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected E1Material(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected E1Material(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "E1MATERIAL", dataRow) { }
        protected E1Material(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "E1MATERIAL", dataRow, isImported) { }
        public E1Material(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public E1Material(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public E1Material() : base() { }

    }
}