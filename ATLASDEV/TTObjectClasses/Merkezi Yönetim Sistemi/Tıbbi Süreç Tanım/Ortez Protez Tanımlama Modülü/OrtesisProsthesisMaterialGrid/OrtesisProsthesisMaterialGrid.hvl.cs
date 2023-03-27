
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="OrtesisProsthesisMaterialGrid")] 

    public  partial class OrtesisProsthesisMaterialGrid : TTObject
    {
        public class OrtesisProsthesisMaterialGridList : TTObjectCollection<OrtesisProsthesisMaterialGrid> { }
                    
        public class ChildOrtesisProsthesisMaterialGridCollection : TTObject.TTChildObjectCollection<OrtesisProsthesisMaterialGrid>
        {
            public ChildOrtesisProsthesisMaterialGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildOrtesisProsthesisMaterialGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public int? Amount
        {
            get { return (int?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

        public OrtesisProsthesisDefinition OrtesisProsthesisDefinition
        {
            get { return (OrtesisProsthesisDefinition)((ITTObject)this).GetParent("ORTESISPROSTHESISDEFINITION"); }
            set { this["ORTESISPROSTHESISDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Material Material
        {
            get { return (Material)((ITTObject)this).GetParent("MATERIAL"); }
            set { this["MATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected OrtesisProsthesisMaterialGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected OrtesisProsthesisMaterialGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected OrtesisProsthesisMaterialGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected OrtesisProsthesisMaterialGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected OrtesisProsthesisMaterialGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ORTESISPROSTHESISMATERIALGRID", dataRow) { }
        protected OrtesisProsthesisMaterialGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ORTESISPROSTHESISMATERIALGRID", dataRow, isImported) { }
        public OrtesisProsthesisMaterialGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public OrtesisProsthesisMaterialGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public OrtesisProsthesisMaterialGrid() : base() { }

    }
}