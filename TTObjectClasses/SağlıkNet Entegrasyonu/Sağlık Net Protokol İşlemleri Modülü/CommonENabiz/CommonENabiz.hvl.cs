
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CommonENabiz")] 

    public  partial class CommonENabiz : TTObject
    {
        public class CommonENabizList : TTObjectCollection<CommonENabiz> { }
                    
        public class ChildCommonENabizCollection : TTObject.TTChildObjectCollection<CommonENabiz>
        {
            public ChildCommonENabizCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCommonENabizCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected CommonENabiz(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CommonENabiz(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CommonENabiz(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CommonENabiz(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CommonENabiz(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "COMMONENABIZ", dataRow) { }
        protected CommonENabiz(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "COMMONENABIZ", dataRow, isImported) { }
        protected CommonENabiz(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CommonENabiz(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CommonENabiz() : base() { }

    }
}