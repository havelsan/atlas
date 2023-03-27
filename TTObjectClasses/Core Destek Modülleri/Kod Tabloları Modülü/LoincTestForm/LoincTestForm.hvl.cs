
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="LoincTestForm")] 

    /// <summary>
    /// LoincTestForm
    /// </summary>
    public  partial class LoincTestForm : TTObject
    {
        public class LoincTestFormList : TTObjectCollection<LoincTestForm> { }
                    
        public class ChildLoincTestFormCollection : TTObject.TTChildObjectCollection<LoincTestForm>
        {
            public ChildLoincTestFormCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildLoincTestFormCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected LoincTestForm(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected LoincTestForm(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected LoincTestForm(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected LoincTestForm(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected LoincTestForm(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "LOINCTESTFORM", dataRow) { }
        protected LoincTestForm(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "LOINCTESTFORM", dataRow, isImported) { }
        public LoincTestForm(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public LoincTestForm(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public LoincTestForm() : base() { }

    }
}