
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ProductTreeAnalyseTest")] 

    public  partial class ProductTreeAnalyseTest : TTObject
    {
        public class ProductTreeAnalyseTestList : TTObjectCollection<ProductTreeAnalyseTest> { }
                    
        public class ChildProductTreeAnalyseTestCollection : TTObject.TTChildObjectCollection<ProductTreeAnalyseTest>
        {
            public ChildProductTreeAnalyseTestCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildProductTreeAnalyseTestCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public ProductAnalysisTestDefinition ProductAnalysisTestDefinition
        {
            get { return (ProductAnalysisTestDefinition)((ITTObject)this).GetParent("PRODUCTANALYSISTESTDEFINITION"); }
            set { this["PRODUCTANALYSISTESTDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ProductTreeDefinition ProductTreeDefinition
        {
            get { return (ProductTreeDefinition)((ITTObject)this).GetParent("PRODUCTTREEDEFINITION"); }
            set { this["PRODUCTTREEDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ProductTreeAnalyseTest(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ProductTreeAnalyseTest(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ProductTreeAnalyseTest(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ProductTreeAnalyseTest(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ProductTreeAnalyseTest(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PRODUCTTREEANALYSETEST", dataRow) { }
        protected ProductTreeAnalyseTest(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PRODUCTTREEANALYSETEST", dataRow, isImported) { }
        public ProductTreeAnalyseTest(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ProductTreeAnalyseTest(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ProductTreeAnalyseTest() : base() { }

    }
}