
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BedClassDefinition")] 

    /// <summary>
    /// Yatak Sınıf TanımlamaSİLL
    /// </summary>
    public  partial class BedClassDefinition : TTDefinitionSet
    {
        public class BedClassDefinitionList : TTObjectCollection<BedClassDefinition> { }
                    
        public class ChildBedClassDefinitionCollection : TTObject.TTChildObjectCollection<BedClassDefinition>
        {
            public ChildBedClassDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBedClassDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Yatak
    /// </summary>
        public string Bed
        {
            get { return (string)this["BED"]; }
            set { this["BED"] = value; }
        }

    /// <summary>
    /// Koğuş
    /// </summary>
        public string ResourceType
        {
            get { return (string)this["RESOURCETYPE"]; }
            set { this["RESOURCETYPE"] = value; }
        }

    /// <summary>
    /// Oda Grubu
    /// </summary>
        public string RoomGroup
        {
            get { return (string)this["ROOMGROUP"]; }
            set { this["ROOMGROUP"] = value; }
        }

        virtual protected void CreatePackageDefinitionCollection()
        {
            _PackageDefinition = new PackageDefinition.ChildPackageDefinitionCollection(this, new Guid("32bbfd17-6de3-4ba4-bc40-eb34cfb21917"));
            ((ITTChildObjectCollection)_PackageDefinition).GetChildren();
        }

        protected PackageDefinition.ChildPackageDefinitionCollection _PackageDefinition = null;
    /// <summary>
    /// Child collection for Yatak Sınıfı
    /// </summary>
        public PackageDefinition.ChildPackageDefinitionCollection PackageDefinition
        {
            get
            {
                if (_PackageDefinition == null)
                    CreatePackageDefinitionCollection();
                return _PackageDefinition;
            }
        }

        protected BedClassDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BedClassDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BedClassDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BedClassDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BedClassDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BEDCLASSDEFINITION", dataRow) { }
        protected BedClassDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BEDCLASSDEFINITION", dataRow, isImported) { }
        public BedClassDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BedClassDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BedClassDefinition() : base() { }

    }
}