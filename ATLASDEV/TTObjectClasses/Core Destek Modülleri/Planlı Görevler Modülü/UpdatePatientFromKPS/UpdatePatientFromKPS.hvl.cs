
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="UpdatePatientFromKPS")] 

    /// <summary>
    /// KPS üserinden hasta bilgilerini düzenler
    /// </summary>
    public  partial class UpdatePatientFromKPS : BaseScheduledTask
    {
        public class UpdatePatientFromKPSList : TTObjectCollection<UpdatePatientFromKPS> { }
                    
        public class ChildUpdatePatientFromKPSCollection : TTObject.TTChildObjectCollection<UpdatePatientFromKPS>
        {
            public ChildUpdatePatientFromKPSCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildUpdatePatientFromKPSCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected UpdatePatientFromKPS(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected UpdatePatientFromKPS(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected UpdatePatientFromKPS(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected UpdatePatientFromKPS(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected UpdatePatientFromKPS(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "UPDATEPATIENTFROMKPS", dataRow) { }
        protected UpdatePatientFromKPS(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "UPDATEPATIENTFROMKPS", dataRow, isImported) { }
        public UpdatePatientFromKPS(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public UpdatePatientFromKPS(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public UpdatePatientFromKPS() : base() { }

    }
}