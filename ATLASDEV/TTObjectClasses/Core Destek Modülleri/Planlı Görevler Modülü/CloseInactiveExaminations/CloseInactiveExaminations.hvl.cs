
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CloseInactiveExaminations")] 

    /// <summary>
    /// Hasta Gelmeyen Muayeneleri Kapatma
    /// </summary>
    public  partial class CloseInactiveExaminations : BaseScheduledTask
    {
        public class CloseInactiveExaminationsList : TTObjectCollection<CloseInactiveExaminations> { }
                    
        public class ChildCloseInactiveExaminationsCollection : TTObject.TTChildObjectCollection<CloseInactiveExaminations>
        {
            public ChildCloseInactiveExaminationsCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCloseInactiveExaminationsCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected CloseInactiveExaminations(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CloseInactiveExaminations(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CloseInactiveExaminations(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CloseInactiveExaminations(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CloseInactiveExaminations(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CLOSEINACTIVEEXAMINATIONS", dataRow) { }
        protected CloseInactiveExaminations(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CLOSEINACTIVEEXAMINATIONS", dataRow, isImported) { }
        public CloseInactiveExaminations(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CloseInactiveExaminations(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CloseInactiveExaminations() : base() { }

    }
}