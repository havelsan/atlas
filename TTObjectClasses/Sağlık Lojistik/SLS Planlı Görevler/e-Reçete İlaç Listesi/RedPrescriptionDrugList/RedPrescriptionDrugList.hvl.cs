
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="RedPrescriptionDrugList")] 

    /// <summary>
    /// Kırmızı Reçete İlaç Listesi
    /// </summary>
    public  partial class RedPrescriptionDrugList : BaseScheduledTask
    {
        public class RedPrescriptionDrugListList : TTObjectCollection<RedPrescriptionDrugList> { }
                    
        public class ChildRedPrescriptionDrugListCollection : TTObject.TTChildObjectCollection<RedPrescriptionDrugList>
        {
            public ChildRedPrescriptionDrugListCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildRedPrescriptionDrugListCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Dosya Yolu
    /// </summary>
        public string FilePath
        {
            get { return (string)this["FILEPATH"]; }
            set { this["FILEPATH"] = value; }
        }

        protected RedPrescriptionDrugList(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected RedPrescriptionDrugList(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected RedPrescriptionDrugList(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected RedPrescriptionDrugList(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected RedPrescriptionDrugList(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "REDPRESCRIPTIONDRUGLIST", dataRow) { }
        protected RedPrescriptionDrugList(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "REDPRESCRIPTIONDRUGLIST", dataRow, isImported) { }
        public RedPrescriptionDrugList(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public RedPrescriptionDrugList(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public RedPrescriptionDrugList() : base() { }

    }
}