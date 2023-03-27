
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MARLabaratory")] 

    /// <summary>
    /// Labaratuvar
    /// </summary>
    public  partial class MARLabaratory : TTDefinitionSet
    {
        public class MARLabaratoryList : TTObjectCollection<MARLabaratory> { }
                    
        public class ChildMARLabaratoryCollection : TTObject.TTChildObjectCollection<MARLabaratory>
        {
            public ChildMARLabaratoryCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMARLabaratoryCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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
    /// Kodu
    /// </summary>
        public string Code
        {
            get { return (string)this["CODE"]; }
            set { this["CODE"] = value; }
        }

        protected MARLabaratory(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MARLabaratory(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MARLabaratory(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MARLabaratory(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MARLabaratory(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MARLABARATORY", dataRow) { }
        protected MARLabaratory(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MARLABARATORY", dataRow, isImported) { }
        public MARLabaratory(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MARLabaratory(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MARLabaratory() : base() { }

    }
}