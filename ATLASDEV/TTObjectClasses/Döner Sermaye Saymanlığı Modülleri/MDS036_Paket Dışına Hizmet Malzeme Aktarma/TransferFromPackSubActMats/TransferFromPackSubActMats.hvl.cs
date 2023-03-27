
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TransferFromPackSubActMats")] 

    public  partial class TransferFromPackSubActMats : TTObject
    {
        public class TransferFromPackSubActMatsList : TTObjectCollection<TransferFromPackSubActMats> { }
                    
        public class ChildTransferFromPackSubActMatsCollection : TTObject.TTChildObjectCollection<TransferFromPackSubActMats>
        {
            public ChildTransferFromPackSubActMatsCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTransferFromPackSubActMatsCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public bool? TransferToProtocol
        {
            get { return (bool?)this["TRANSFERTOPROTOCOL"]; }
            set { this["TRANSFERTOPROTOCOL"] = value; }
        }

        public string PackageInfo
        {
            get { return (string)this["PACKAGEINFO"]; }
            set { this["PACKAGEINFO"] = value; }
        }

        public string Status
        {
            get { return (string)this["STATUS"]; }
            set { this["STATUS"] = value; }
        }

        public SubActionMaterial SubActionMaterial
        {
            get { return (SubActionMaterial)((ITTObject)this).GetParent("SUBACTIONMATERIAL"); }
            set { this["SUBACTIONMATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public TransferFromPackage TransferFromPackage
        {
            get { return (TransferFromPackage)((ITTObject)this).GetParent("TRANSFERFROMPACKAGE"); }
            set { this["TRANSFERFROMPACKAGE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected TransferFromPackSubActMats(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TransferFromPackSubActMats(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TransferFromPackSubActMats(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TransferFromPackSubActMats(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TransferFromPackSubActMats(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TRANSFERFROMPACKSUBACTMATS", dataRow) { }
        protected TransferFromPackSubActMats(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TRANSFERFROMPACKSUBACTMATS", dataRow, isImported) { }
        public TransferFromPackSubActMats(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TransferFromPackSubActMats(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TransferFromPackSubActMats() : base() { }

    }
}