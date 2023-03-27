
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ResStockControlSection")] 

    public  partial class ResStockControlSection : ResSection
    {
        public class ResStockControlSectionList : TTObjectCollection<ResStockControlSection> { }
                    
        public class ChildResStockControlSectionCollection : TTObject.TTChildObjectCollection<ResStockControlSection>
        {
            public ChildResStockControlSectionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildResStockControlSectionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public ResAccountancy Accountancy
        {
            get { return (ResAccountancy)((ITTObject)this).GetParent("ACCOUNTANCY"); }
            set { this["ACCOUNTANCY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateCardDrawersCollection()
        {
            _CardDrawers = new ResCardDrawer.ChildResCardDrawerCollection(this, new Guid("25516cc8-8e53-4d02-a1c8-7e9019136f75"));
            ((ITTChildObjectCollection)_CardDrawers).GetChildren();
        }

        protected ResCardDrawer.ChildResCardDrawerCollection _CardDrawers = null;
        public ResCardDrawer.ChildResCardDrawerCollection CardDrawers
        {
            get
            {
                if (_CardDrawers == null)
                    CreateCardDrawersCollection();
                return _CardDrawers;
            }
        }

        protected ResStockControlSection(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ResStockControlSection(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ResStockControlSection(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ResStockControlSection(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ResStockControlSection(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RESSTOCKCONTROLSECTION", dataRow) { }
        protected ResStockControlSection(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RESSTOCKCONTROLSECTION", dataRow, isImported) { }
        public ResStockControlSection(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ResStockControlSection(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ResStockControlSection() : base() { }

    }
}