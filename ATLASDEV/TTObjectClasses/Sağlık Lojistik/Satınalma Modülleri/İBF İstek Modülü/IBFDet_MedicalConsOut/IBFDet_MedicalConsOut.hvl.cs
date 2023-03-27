
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="IBFDet_MedicalConsOut")] 

    /// <summary>
    /// İBF Detay kalemi - Tıbbi sarf malzemeleri için kullanılan sınıftır. (İBF listesi harici)
    /// </summary>
    public  partial class IBFDet_MedicalConsOut : IBFDetDetailOut
    {
        public class IBFDet_MedicalConsOutList : TTObjectCollection<IBFDet_MedicalConsOut> { }
                    
        public class ChildIBFDet_MedicalConsOutCollection : TTObject.TTChildObjectCollection<IBFDet_MedicalConsOut>
        {
            public ChildIBFDet_MedicalConsOutCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildIBFDet_MedicalConsOutCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("28662ca0-6fd6-4a8f-8cd9-3dc69151b79f"); } }
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("bae6c84c-c920-41b2-9136-221e13a8b558"); } }
        }

        protected IBFDet_MedicalConsOut(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected IBFDet_MedicalConsOut(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected IBFDet_MedicalConsOut(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected IBFDet_MedicalConsOut(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected IBFDet_MedicalConsOut(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "IBFDET_MEDICALCONSOUT", dataRow) { }
        protected IBFDet_MedicalConsOut(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "IBFDET_MEDICALCONSOUT", dataRow, isImported) { }
        public IBFDet_MedicalConsOut(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public IBFDet_MedicalConsOut(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public IBFDet_MedicalConsOut() : base() { }

    }
}