
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SetAmountOfBedProcedures")] 

    /// <summary>
    /// Yatak Hizmeti Miktar Güncelleme
    /// </summary>
    public  partial class SetAmountOfBedProcedures : BaseScheduledTask
    {
        public class SetAmountOfBedProceduresList : TTObjectCollection<SetAmountOfBedProcedures> { }
                    
        public class ChildSetAmountOfBedProceduresCollection : TTObject.TTChildObjectCollection<SetAmountOfBedProcedures>
        {
            public ChildSetAmountOfBedProceduresCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSetAmountOfBedProceduresCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected SetAmountOfBedProcedures(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SetAmountOfBedProcedures(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SetAmountOfBedProcedures(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SetAmountOfBedProcedures(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SetAmountOfBedProcedures(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SETAMOUNTOFBEDPROCEDURES", dataRow) { }
        protected SetAmountOfBedProcedures(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SETAMOUNTOFBEDPROCEDURES", dataRow, isImported) { }
        public SetAmountOfBedProcedures(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SetAmountOfBedProcedures(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SetAmountOfBedProcedures() : base() { }

    }
}