
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PassiveDrugList")] 

    /// <summary>
    /// Geri ödeme kapsamında olmayan ilaç listesi
    /// </summary>
    public  partial class PassiveDrugList : BaseScheduledTask
    {
        public class PassiveDrugListList : TTObjectCollection<PassiveDrugList> { }
                    
        public class ChildPassiveDrugListCollection : TTObject.TTChildObjectCollection<PassiveDrugList>
        {
            public ChildPassiveDrugListCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPassiveDrugListCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Dosya Yolu
    /// </summary>
        public string FilePath
        {
            get { return (string)this["FILEPATH"]; }
            set { this["FILEPATH"] = value; }
        }

        protected PassiveDrugList(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PassiveDrugList(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PassiveDrugList(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PassiveDrugList(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PassiveDrugList(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PASSIVEDRUGLIST", dataRow) { }
        protected PassiveDrugList(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PASSIVEDRUGLIST", dataRow, isImported) { }
        public PassiveDrugList(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PassiveDrugList(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PassiveDrugList() : base() { }

    }
}