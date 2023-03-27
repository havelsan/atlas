
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="FillDiagnosisToPA")] 

    public  partial class FillDiagnosisToPA : BaseScheduledTask
    {
        public class FillDiagnosisToPAList : TTObjectCollection<FillDiagnosisToPA> { }
                    
        public class ChildFillDiagnosisToPACollection : TTObject.TTChildObjectCollection<FillDiagnosisToPA>
        {
            public ChildFillDiagnosisToPACollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildFillDiagnosisToPACollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected FillDiagnosisToPA(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected FillDiagnosisToPA(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected FillDiagnosisToPA(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected FillDiagnosisToPA(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected FillDiagnosisToPA(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "FILLDIAGNOSISTOPA", dataRow) { }
        protected FillDiagnosisToPA(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "FILLDIAGNOSISTOPA", dataRow, isImported) { }
        public FillDiagnosisToPA(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public FillDiagnosisToPA(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public FillDiagnosisToPA() : base() { }

    }
}