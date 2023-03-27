
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ehrIntensiveCareAfterSurgery")] 

    /// <summary>
    /// Ameliyat  Derlenme
    /// </summary>
    public  partial class ehrIntensiveCareAfterSurgery : ehrBaseInpatientAdmission
    {
        public class ehrIntensiveCareAfterSurgeryList : TTObjectCollection<ehrIntensiveCareAfterSurgery> { }
                    
        public class ChildehrIntensiveCareAfterSurgeryCollection : TTObject.TTChildObjectCollection<ehrIntensiveCareAfterSurgery>
        {
            public ChildehrIntensiveCareAfterSurgeryCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildehrIntensiveCareAfterSurgeryCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Active { get { return new Guid("d82caca1-a08a-43fa-b009-be70b816c5ec"); } }
            public static Guid UnActive { get { return new Guid("8abe0000-7e19-46e0-a07f-e69109e6aa4c"); } }
        }

        protected ehrIntensiveCareAfterSurgery(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ehrIntensiveCareAfterSurgery(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ehrIntensiveCareAfterSurgery(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ehrIntensiveCareAfterSurgery(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ehrIntensiveCareAfterSurgery(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EHRINTENSIVECAREAFTERSURGERY", dataRow) { }
        protected ehrIntensiveCareAfterSurgery(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EHRINTENSIVECAREAFTERSURGERY", dataRow, isImported) { }
        public ehrIntensiveCareAfterSurgery(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ehrIntensiveCareAfterSurgery(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ehrIntensiveCareAfterSurgery() : base() { }

    }
}