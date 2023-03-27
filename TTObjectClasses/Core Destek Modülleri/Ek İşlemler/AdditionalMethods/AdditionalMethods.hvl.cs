
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AdditionalMethods")] 

    public  partial class AdditionalMethods : TTObject
    {
        public class AdditionalMethodsList : TTObjectCollection<AdditionalMethods> { }
                    
        public class ChildAdditionalMethodsCollection : TTObject.TTChildObjectCollection<AdditionalMethods>
        {
            public ChildAdditionalMethodsCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAdditionalMethodsCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public string RoleID
        {
            get { return (string)this["ROLEID"]; }
            set { this["ROLEID"] = value; }
        }

        public string Method
        {
            get { return (string)this["METHOD"]; }
            set { this["METHOD"] = value; }
        }

    /// <summary>
    /// Başlık
    /// </summary>
        public string Title
        {
            get { return (string)this["TITLE"]; }
            set { this["TITLE"] = value; }
        }

        protected AdditionalMethods(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AdditionalMethods(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AdditionalMethods(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AdditionalMethods(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AdditionalMethods(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ADDITIONALMETHODS", dataRow) { }
        protected AdditionalMethods(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ADDITIONALMETHODS", dataRow, isImported) { }
        public AdditionalMethods(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AdditionalMethods(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AdditionalMethods() : base() { }

    }
}