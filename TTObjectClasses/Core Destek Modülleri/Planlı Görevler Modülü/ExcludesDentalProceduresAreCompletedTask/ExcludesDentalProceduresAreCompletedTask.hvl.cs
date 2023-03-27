
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ExcludesDentalProceduresAreCompletedTask")] 

    /// <summary>
    /// Diş Tedavi Prosedürleri Tamamlanmayanlar 
    /// </summary>
    public  partial class ExcludesDentalProceduresAreCompletedTask : BaseScheduledTask
    {
        public class ExcludesDentalProceduresAreCompletedTaskList : TTObjectCollection<ExcludesDentalProceduresAreCompletedTask> { }
                    
        public class ChildExcludesDentalProceduresAreCompletedTaskCollection : TTObject.TTChildObjectCollection<ExcludesDentalProceduresAreCompletedTask>
        {
            public ChildExcludesDentalProceduresAreCompletedTaskCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildExcludesDentalProceduresAreCompletedTaskCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected ExcludesDentalProceduresAreCompletedTask(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ExcludesDentalProceduresAreCompletedTask(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ExcludesDentalProceduresAreCompletedTask(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ExcludesDentalProceduresAreCompletedTask(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ExcludesDentalProceduresAreCompletedTask(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EXCLUDESDENTALPROCEDURESARECOMPLETEDTASK", dataRow) { }
        protected ExcludesDentalProceduresAreCompletedTask(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EXCLUDESDENTALPROCEDURESARECOMPLETEDTASK", dataRow, isImported) { }
        public ExcludesDentalProceduresAreCompletedTask(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ExcludesDentalProceduresAreCompletedTask(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ExcludesDentalProceduresAreCompletedTask() : base() { }

    }
}