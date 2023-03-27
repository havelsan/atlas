
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="LinenType")] 

    public  partial class LinenType : TTDefinitionSet
    {
        public class LinenTypeList : TTObjectCollection<LinenType> { }
                    
        public class ChildLinenTypeCollection : TTObject.TTChildObjectCollection<LinenType>
        {
            public ChildLinenTypeCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildLinenTypeCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public string Type
        {
            get { return (string)this["TYPE"]; }
            set { this["TYPE"] = value; }
        }

        public int? MaxWashingCount
        {
            get { return (int?)this["MAXWASHINGCOUNT"]; }
            set { this["MAXWASHINGCOUNT"] = value; }
        }

        public string IntegrationCode
        {
            get { return (string)this["INTEGRATIONCODE"]; }
            set { this["INTEGRATIONCODE"] = value; }
        }

        public LinenGroup LinenGroup
        {
            get { return (LinenGroup)((ITTObject)this).GetParent("LINENGROUP"); }
            set { this["LINENGROUP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected LinenType(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected LinenType(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected LinenType(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected LinenType(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected LinenType(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "LINENTYPE", dataRow) { }
        protected LinenType(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "LINENTYPE", dataRow, isImported) { }
        public LinenType(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public LinenType(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public LinenType() : base() { }

    }
}