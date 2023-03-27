
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="NATOGroupCode")] 

    public  partial class NATOGroupCode : TerminologyManagerDef
    {
        public class NATOGroupCodeList : TTObjectCollection<NATOGroupCode> { }
                    
        public class ChildNATOGroupCodeCollection : TTObject.TTChildObjectCollection<NATOGroupCode>
        {
            public ChildNATOGroupCodeCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildNATOGroupCodeCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Kodu
    /// </summary>
        public int? Code
        {
            get { return (int?)this["CODE"]; }
            set { this["CODE"] = value; }
        }

    /// <summary>
    /// Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        protected NATOGroupCode(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected NATOGroupCode(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected NATOGroupCode(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected NATOGroupCode(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected NATOGroupCode(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "NATOGROUPCODE", dataRow) { }
        protected NATOGroupCode(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "NATOGROUPCODE", dataRow, isImported) { }
        public NATOGroupCode(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public NATOGroupCode(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public NATOGroupCode() : base() { }

    }
}