
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="OrthesisProsthesis_ReturnDescriptionsGrid")] 

    public  partial class OrthesisProsthesis_ReturnDescriptionsGrid : ReturnDescriptionsGrid
    {
        public class OrthesisProsthesis_ReturnDescriptionsGridList : TTObjectCollection<OrthesisProsthesis_ReturnDescriptionsGrid> { }
                    
        public class ChildOrthesisProsthesis_ReturnDescriptionsGridCollection : TTObject.TTChildObjectCollection<OrthesisProsthesis_ReturnDescriptionsGrid>
        {
            public ChildOrthesisProsthesis_ReturnDescriptionsGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildOrthesisProsthesis_ReturnDescriptionsGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Ortez Protez İade Sebepleri
    /// </summary>
        public OrthesisProsthesisRequest OrthesisProsthesisRequest
        {
            get { return (OrthesisProsthesisRequest)((ITTObject)this).GetParent("ORTHESISPROSTHESISREQUEST"); }
            set { this["ORTHESISPROSTHESISREQUEST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected OrthesisProsthesis_ReturnDescriptionsGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected OrthesisProsthesis_ReturnDescriptionsGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected OrthesisProsthesis_ReturnDescriptionsGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected OrthesisProsthesis_ReturnDescriptionsGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected OrthesisProsthesis_ReturnDescriptionsGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ORTHESISPROSTHESIS_RETURNDESCRIPTIONSGRID", dataRow) { }
        protected OrthesisProsthesis_ReturnDescriptionsGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ORTHESISPROSTHESIS_RETURNDESCRIPTIONSGRID", dataRow, isImported) { }
        public OrthesisProsthesis_ReturnDescriptionsGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public OrthesisProsthesis_ReturnDescriptionsGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public OrthesisProsthesis_ReturnDescriptionsGrid() : base() { }

    }
}