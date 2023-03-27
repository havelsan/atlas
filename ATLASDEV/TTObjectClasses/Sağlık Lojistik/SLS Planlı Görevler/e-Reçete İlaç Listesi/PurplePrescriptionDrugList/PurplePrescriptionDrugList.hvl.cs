
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PurplePrescriptionDrugList")] 

    /// <summary>
    /// Mor Reçete İlaç Listesi
    /// </summary>
    public  partial class PurplePrescriptionDrugList : BaseScheduledTask
    {
        public class PurplePrescriptionDrugListList : TTObjectCollection<PurplePrescriptionDrugList> { }
                    
        public class ChildPurplePrescriptionDrugListCollection : TTObject.TTChildObjectCollection<PurplePrescriptionDrugList>
        {
            public ChildPurplePrescriptionDrugListCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPurplePrescriptionDrugListCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Dosya Yolu
    /// </summary>
        public string FilePath
        {
            get { return (string)this["FILEPATH"]; }
            set { this["FILEPATH"] = value; }
        }

        protected PurplePrescriptionDrugList(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PurplePrescriptionDrugList(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PurplePrescriptionDrugList(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PurplePrescriptionDrugList(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PurplePrescriptionDrugList(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PURPLEPRESCRIPTIONDRUGLIST", dataRow) { }
        protected PurplePrescriptionDrugList(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PURPLEPRESCRIPTIONDRUGLIST", dataRow, isImported) { }
        public PurplePrescriptionDrugList(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PurplePrescriptionDrugList(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PurplePrescriptionDrugList() : base() { }

    }
}