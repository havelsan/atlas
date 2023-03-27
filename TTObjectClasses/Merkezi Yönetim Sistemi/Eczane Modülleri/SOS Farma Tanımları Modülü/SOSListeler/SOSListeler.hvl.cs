
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SOSListeler")] 

    public  partial class SOSListeler : TerminologyManagerDef
    {
        public class SOSListelerList : TTObjectCollection<SOSListeler> { }
                    
        public class ChildSOSListelerCollection : TTObject.TTChildObjectCollection<SOSListeler>
        {
            public ChildSOSListelerCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSOSListelerCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public long? SOSID
        {
            get { return (long?)this["SOSID"]; }
            set { this["SOSID"] = value; }
        }

    /// <summary>
    /// Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Tip
    /// </summary>
        public string Type
        {
            get { return (string)this["TYPE"]; }
            set { this["TYPE"] = value; }
        }

    /// <summary>
    /// Değer
    /// </summary>
        public string Value
        {
            get { return (string)this["VALUE"]; }
            set { this["VALUE"] = value; }
        }

        public UnitDefinition XXXXXXUnitDefinition
        {
            get { return (UnitDefinition)((ITTObject)this).GetParent("XXXXXXUNITDEFINITION"); }
            set { this["XXXXXXUNITDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected SOSListeler(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SOSListeler(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SOSListeler(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SOSListeler(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SOSListeler(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SOSLISTELER", dataRow) { }
        protected SOSListeler(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SOSLISTELER", dataRow, isImported) { }
        public SOSListeler(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SOSListeler(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SOSListeler() : base() { }

    }
}