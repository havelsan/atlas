
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SubUnitMatGridClass")] 

    public  partial class SubUnitMatGridClass : BaseAction
    {
        public class SubUnitMatGridClassList : TTObjectCollection<SubUnitMatGridClass> { }
                    
        public class ChildSubUnitMatGridClassCollection : TTObject.TTChildObjectCollection<SubUnitMatGridClass>
        {
            public ChildSubUnitMatGridClassCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSubUnitMatGridClassCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Bağlı Birlik Mevcut
    /// </summary>
        public Currency? SubUniteMatInheld
        {
            get { return (Currency?)this["SUBUNITEMATINHELD"]; }
            set { this["SUBUNITEMATINHELD"] = value; }
        }

    /// <summary>
    /// Mevcut
    /// </summary>
        public Currency? StoreInheld
        {
            get { return (Currency?)this["STOREINHELD"]; }
            set { this["STOREINHELD"] = value; }
        }

    /// <summary>
    /// Fark
    /// </summary>
        public Currency? DifferenceInheld
        {
            get { return (Currency?)this["DIFFERENCEINHELD"]; }
            set { this["DIFFERENCEINHELD"] = value; }
        }

        public SubUnitMaterialInheld SubUnitMaterialInheld
        {
            get { return (SubUnitMaterialInheld)((ITTObject)this).GetParent("SUBUNITMATERIALINHELD"); }
            set { this["SUBUNITMATERIALINHELD"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Material Material
        {
            get { return (Material)((ITTObject)this).GetParent("MATERIAL"); }
            set { this["MATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected SubUnitMatGridClass(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SubUnitMatGridClass(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SubUnitMatGridClass(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SubUnitMatGridClass(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SubUnitMatGridClass(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SUBUNITMATGRIDCLASS", dataRow) { }
        protected SubUnitMatGridClass(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SUBUNITMATGRIDCLASS", dataRow, isImported) { }
        public SubUnitMatGridClass(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SubUnitMatGridClass(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SubUnitMatGridClass() : base() { }

    }
}