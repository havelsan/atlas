
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CommonENabiz_102")] 

    public  partial class CommonENabiz_102 : TTObject
    {
        public class CommonENabiz_102List : TTObjectCollection<CommonENabiz_102> { }
                    
        public class ChildCommonENabiz_102Collection : TTObject.TTChildObjectCollection<CommonENabiz_102>
        {
            public ChildCommonENabiz_102Collection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCommonENabiz_102Collection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected CommonENabiz_102(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CommonENabiz_102(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CommonENabiz_102(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CommonENabiz_102(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CommonENabiz_102(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "COMMONENABIZ_102", dataRow) { }
        protected CommonENabiz_102(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "COMMONENABIZ_102", dataRow, isImported) { }
        public CommonENabiz_102(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CommonENabiz_102(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CommonENabiz_102() : base() { }

    }
}