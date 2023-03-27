
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="OrangePrescriptionDrugList")] 

    /// <summary>
    /// Turuncu Reçete İlaç Listesi
    /// </summary>
    public  partial class OrangePrescriptionDrugList : BaseScheduledTask
    {
        public class OrangePrescriptionDrugListList : TTObjectCollection<OrangePrescriptionDrugList> { }
                    
        public class ChildOrangePrescriptionDrugListCollection : TTObject.TTChildObjectCollection<OrangePrescriptionDrugList>
        {
            public ChildOrangePrescriptionDrugListCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildOrangePrescriptionDrugListCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Dosya Yolu
    /// </summary>
        public string FilePath
        {
            get { return (string)this["FILEPATH"]; }
            set { this["FILEPATH"] = value; }
        }

        protected OrangePrescriptionDrugList(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected OrangePrescriptionDrugList(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected OrangePrescriptionDrugList(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected OrangePrescriptionDrugList(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected OrangePrescriptionDrugList(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ORANGEPRESCRIPTIONDRUGLIST", dataRow) { }
        protected OrangePrescriptionDrugList(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ORANGEPRESCRIPTIONDRUGLIST", dataRow, isImported) { }
        public OrangePrescriptionDrugList(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public OrangePrescriptionDrugList(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public OrangePrescriptionDrugList() : base() { }

    }
}