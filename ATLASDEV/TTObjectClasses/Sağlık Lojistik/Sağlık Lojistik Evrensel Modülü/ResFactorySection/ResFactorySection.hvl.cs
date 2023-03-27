
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ResFactorySection")] 

    /// <summary>
    /// Fabrika Kısım Tanımı
    /// </summary>
    public  partial class ResFactorySection : ResSection
    {
        public class ResFactorySectionList : TTObjectCollection<ResFactorySection> { }
                    
        public class ChildResFactorySectionCollection : TTObject.TTChildObjectCollection<ResFactorySection>
        {
            public ChildResFactorySectionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildResFactorySectionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// XXXXXX-Fabrika Kısımları
    /// </summary>
        public ResHospital Hospital
        {
            get { return (ResHospital)((ITTObject)this).GetParent("HOSPITAL"); }
            set { this["HOSPITAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ResFactorySection(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ResFactorySection(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ResFactorySection(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ResFactorySection(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ResFactorySection(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RESFACTORYSECTION", dataRow) { }
        protected ResFactorySection(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RESFACTORYSECTION", dataRow, isImported) { }
        public ResFactorySection(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ResFactorySection(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ResFactorySection() : base() { }

    }
}