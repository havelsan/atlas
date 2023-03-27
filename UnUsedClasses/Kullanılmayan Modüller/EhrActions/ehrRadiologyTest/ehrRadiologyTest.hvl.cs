
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ehrRadiologyTest")] 

    /// <summary>
    /// Radyoloji Test
    /// </summary>
    public  partial class ehrRadiologyTest : ehrSubactionFlowable
    {
        public class ehrRadiologyTestList : TTObjectCollection<ehrRadiologyTest> { }
                    
        public class ChildehrRadiologyTestCollection : TTObject.TTChildObjectCollection<ehrRadiologyTest>
        {
            public ChildehrRadiologyTestCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildehrRadiologyTestCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Active { get { return new Guid("d82caca1-a08a-43fa-b009-be70b816c5ec"); } }
            public static Guid UnActive { get { return new Guid("8abe0000-7e19-46e0-a07f-e69109e6aa4c"); } }
        }

    /// <summary>
    /// Rapor
    /// </summary>
        public object Report
        {
            get { return (object)this["REPORT"]; }
            set { this["REPORT"] = value; }
        }

        protected ehrRadiologyTest(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ehrRadiologyTest(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ehrRadiologyTest(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ehrRadiologyTest(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ehrRadiologyTest(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EHRRADIOLOGYTEST", dataRow) { }
        protected ehrRadiologyTest(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EHRRADIOLOGYTEST", dataRow, isImported) { }
        public ehrRadiologyTest(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ehrRadiologyTest(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ehrRadiologyTest() : base() { }

    }
}