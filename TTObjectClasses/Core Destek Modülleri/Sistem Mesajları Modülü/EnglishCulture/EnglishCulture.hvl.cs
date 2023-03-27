
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="EnglishCulture")] 

    public  partial class EnglishCulture : BaseCulture
    {
        public class EnglishCultureList : TTObjectCollection<EnglishCulture> { }
                    
        public class ChildEnglishCultureCollection : TTObject.TTChildObjectCollection<EnglishCulture>
        {
            public ChildEnglishCultureCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildEnglishCultureCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected EnglishCulture(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected EnglishCulture(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected EnglishCulture(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected EnglishCulture(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected EnglishCulture(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ENGLISHCULTURE", dataRow) { }
        protected EnglishCulture(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ENGLISHCULTURE", dataRow, isImported) { }
        public EnglishCulture(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public EnglishCulture(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public EnglishCulture() : base() { }

    }
}