
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="IIMProtocol")] 

    public  partial class IIMProtocol : TTObject
    {
        public class IIMProtocolList : TTObjectCollection<IIMProtocol> { }
                    
        public class ChildIIMProtocolCollection : TTObject.TTChildObjectCollection<IIMProtocol>
        {
            public ChildIIMProtocolCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildIIMProtocolCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public bool? Checked
        {
            get { return (bool?)this["CHECKED"]; }
            set { this["CHECKED"] = value; }
        }

    /// <summary>
    /// Kural Protokol bilgisi
    /// </summary>
        public InvoiceInclusionMaster InvoiceInclusionMaster
        {
            get { return (InvoiceInclusionMaster)((ITTObject)this).GetParent("INVOICEINCLUSIONMASTER"); }
            set { this["INVOICEINCLUSIONMASTER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Kural Protokol bilgisi
    /// </summary>
        public ProtocolDefinition ProtocolDefinition
        {
            get { return (ProtocolDefinition)((ITTObject)this).GetParent("PROTOCOLDEFINITION"); }
            set { this["PROTOCOLDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected IIMProtocol(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected IIMProtocol(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected IIMProtocol(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected IIMProtocol(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected IIMProtocol(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "IIMPROTOCOL", dataRow) { }
        protected IIMProtocol(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "IIMPROTOCOL", dataRow, isImported) { }
        public IIMProtocol(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public IIMProtocol(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public IIMProtocol() : base() { }

    }
}