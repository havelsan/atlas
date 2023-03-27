
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="NormalPrescriptionDrugList")] 

    /// <summary>
    /// Normal Reçete İlaç Listesi
    /// </summary>
    public  partial class NormalPrescriptionDrugList : BaseScheduledTask
    {
        public class NormalPrescriptionDrugListList : TTObjectCollection<NormalPrescriptionDrugList> { }
                    
        public class ChildNormalPrescriptionDrugListCollection : TTObject.TTChildObjectCollection<NormalPrescriptionDrugList>
        {
            public ChildNormalPrescriptionDrugListCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildNormalPrescriptionDrugListCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Dosya Yolu
    /// </summary>
        public string FilePath
        {
            get { return (string)this["FILEPATH"]; }
            set { this["FILEPATH"] = value; }
        }

        protected NormalPrescriptionDrugList(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected NormalPrescriptionDrugList(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected NormalPrescriptionDrugList(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected NormalPrescriptionDrugList(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected NormalPrescriptionDrugList(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "NORMALPRESCRIPTIONDRUGLIST", dataRow) { }
        protected NormalPrescriptionDrugList(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "NORMALPRESCRIPTIONDRUGLIST", dataRow, isImported) { }
        public NormalPrescriptionDrugList(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public NormalPrescriptionDrugList(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public NormalPrescriptionDrugList() : base() { }

    }
}