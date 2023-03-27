
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="GreenPrescriptionDrugList")] 

    /// <summary>
    /// Yeşil  Reçete İlaç Listesi
    /// </summary>
    public  partial class GreenPrescriptionDrugList : BaseScheduledTask
    {
        public class GreenPrescriptionDrugListList : TTObjectCollection<GreenPrescriptionDrugList> { }
                    
        public class ChildGreenPrescriptionDrugListCollection : TTObject.TTChildObjectCollection<GreenPrescriptionDrugList>
        {
            public ChildGreenPrescriptionDrugListCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildGreenPrescriptionDrugListCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Dosya Yolu
    /// </summary>
        public string FilePath
        {
            get { return (string)this["FILEPATH"]; }
            set { this["FILEPATH"] = value; }
        }

        protected GreenPrescriptionDrugList(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected GreenPrescriptionDrugList(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected GreenPrescriptionDrugList(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected GreenPrescriptionDrugList(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected GreenPrescriptionDrugList(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "GREENPRESCRIPTIONDRUGLIST", dataRow) { }
        protected GreenPrescriptionDrugList(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "GREENPRESCRIPTIONDRUGLIST", dataRow, isImported) { }
        public GreenPrescriptionDrugList(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public GreenPrescriptionDrugList(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public GreenPrescriptionDrugList() : base() { }

    }
}