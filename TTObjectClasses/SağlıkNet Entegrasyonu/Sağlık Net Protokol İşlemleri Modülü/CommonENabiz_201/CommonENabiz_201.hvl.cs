
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CommonENabiz_201")] 

    public  partial class CommonENabiz_201 : TTObject
    {
        public class CommonENabiz_201List : TTObjectCollection<CommonENabiz_201> { }
                    
        public class ChildCommonENabiz_201Collection : TTObject.TTChildObjectCollection<CommonENabiz_201>
        {
            public ChildCommonENabiz_201Collection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCommonENabiz_201Collection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected CommonENabiz_201(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CommonENabiz_201(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CommonENabiz_201(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CommonENabiz_201(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CommonENabiz_201(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "COMMONENABIZ_201", dataRow) { }
        protected CommonENabiz_201(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "COMMONENABIZ_201", dataRow, isImported) { }
        public CommonENabiz_201(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CommonENabiz_201(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CommonENabiz_201() : base() { }

    }
}