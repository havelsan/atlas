
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MhSTrusteeDefinition")] 

    /// <summary>
    /// Mutemet
    /// </summary>
    public  partial class MhSTrusteeDefinition : TTDefinitionSet
    {
        public class MhSTrusteeDefinitionList : TTObjectCollection<MhSTrusteeDefinition> { }
                    
        public class ChildMhSTrusteeDefinitionCollection : TTObject.TTChildObjectCollection<MhSTrusteeDefinition>
        {
            public ChildMhSTrusteeDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMhSTrusteeDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Kod
    /// </summary>
        public string Code
        {
            get { return (string)this["CODE"]; }
            set { this["CODE"] = value; }
        }

    /// <summary>
    /// Soyad
    /// </summary>
        public string Surname
        {
            get { return (string)this["SURNAME"]; }
            set { this["SURNAME"] = value; }
        }

    /// <summary>
    /// Ad
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        protected MhSTrusteeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MhSTrusteeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MhSTrusteeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MhSTrusteeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MhSTrusteeDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MHSTRUSTEEDEFINITION", dataRow) { }
        protected MhSTrusteeDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MHSTRUSTEEDEFINITION", dataRow, isImported) { }
        public MhSTrusteeDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MhSTrusteeDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MhSTrusteeDefinition() : base() { }

    }
}