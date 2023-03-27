
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MLRRationRegimeGroup")] 

    /// <summary>
    /// DLR010_Rasyon Yemek Grubu
    /// </summary>
    public  partial class MLRRationRegimeGroup : TTObject
    {
        public class MLRRationRegimeGroupList : TTObjectCollection<MLRRationRegimeGroup> { }
                    
        public class ChildMLRRationRegimeGroupCollection : TTObject.TTChildObjectCollection<MLRRationRegimeGroup>
        {
            public ChildMLRRationRegimeGroupCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMLRRationRegimeGroupCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Rejim Grubu
    /// </summary>
        public MLRRegimeGroup RegimeGroup
        {
            get { return (MLRRegimeGroup)((ITTObject)this).GetParent("REGIMEGROUP"); }
            set { this["REGIMEGROUP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Rasyon
    /// </summary>
        public MLRRation Ration
        {
            get { return (MLRRation)((ITTObject)this).GetParent("RATION"); }
            set { this["RATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateRegimeMealGroupsCollection()
        {
            _RegimeMealGroups = new MLRRegimeMealGroup.ChildMLRRegimeMealGroupCollection(this, new Guid("d206f0bd-cbde-4276-b4b8-661c9789d173"));
            ((ITTChildObjectCollection)_RegimeMealGroups).GetChildren();
        }

        protected MLRRegimeMealGroup.ChildMLRRegimeMealGroupCollection _RegimeMealGroups = null;
    /// <summary>
    /// Child collection for Rasyon Rejim Grubu
    /// </summary>
        public MLRRegimeMealGroup.ChildMLRRegimeMealGroupCollection RegimeMealGroups
        {
            get
            {
                if (_RegimeMealGroups == null)
                    CreateRegimeMealGroupsCollection();
                return _RegimeMealGroups;
            }
        }

        protected MLRRationRegimeGroup(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MLRRationRegimeGroup(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MLRRationRegimeGroup(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MLRRationRegimeGroup(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MLRRationRegimeGroup(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MLRRATIONREGIMEGROUP", dataRow) { }
        protected MLRRationRegimeGroup(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MLRRATIONREGIMEGROUP", dataRow, isImported) { }
        public MLRRationRegimeGroup(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MLRRationRegimeGroup(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MLRRationRegimeGroup() : base() { }

    }
}