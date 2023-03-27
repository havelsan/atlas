
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PackagingDepConsMaterial")] 

    /// <summary>
    /// Ambalajlama İş İstek İstek Yapılan Malzeme Sekmesi
    /// </summary>
    public  partial class PackagingDepConsMaterial : ConsumedMaterial
    {
        public class PackagingDepConsMaterialList : TTObjectCollection<PackagingDepConsMaterial> { }
                    
        public class ChildPackagingDepConsMaterialCollection : TTObject.TTChildObjectCollection<PackagingDepConsMaterial>
        {
            public ChildPackagingDepConsMaterialCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPackagingDepConsMaterialCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public PackagingDepartmentAction PackagingDepartmentAction
        {
            get { return (PackagingDepartmentAction)((ITTObject)this).GetParent("PACKAGINGDEPARTMENTACTION"); }
            set { this["PACKAGINGDEPARTMENTACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PackagingDepConsMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PackagingDepConsMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PackagingDepConsMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PackagingDepConsMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PackagingDepConsMaterial(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PACKAGINGDEPCONSMATERIAL", dataRow) { }
        protected PackagingDepConsMaterial(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PACKAGINGDEPCONSMATERIAL", dataRow, isImported) { }
        public PackagingDepConsMaterial(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PackagingDepConsMaterial(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PackagingDepConsMaterial() : base() { }

    }
}