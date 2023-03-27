
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BasePatientDataCorrection")] 

    public  abstract  partial class BasePatientDataCorrection : BaseDataCorrection
    {
        public class BasePatientDataCorrectionList : TTObjectCollection<BasePatientDataCorrection> { }
                    
        public class ChildBasePatientDataCorrectionCollection : TTObject.TTChildObjectCollection<BasePatientDataCorrection>
        {
            public ChildBasePatientDataCorrectionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBasePatientDataCorrectionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid New { get { return new Guid("34897a19-9fa2-4dff-a783-83131c222bbc"); } }
            public static Guid Cancelled { get { return new Guid("d9a4cfca-0c12-4913-bf60-35e811619787"); } }
            public static Guid Completed { get { return new Guid("f00f14e0-e935-4391-b052-6218ca0e612e"); } }
        }

        public Patient Patient
        {
            get { return (Patient)((ITTObject)this).GetParent("PATIENT"); }
            set { this["PATIENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected BasePatientDataCorrection(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BasePatientDataCorrection(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BasePatientDataCorrection(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BasePatientDataCorrection(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BasePatientDataCorrection(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BASEPATIENTDATACORRECTION", dataRow) { }
        protected BasePatientDataCorrection(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BASEPATIENTDATACORRECTION", dataRow, isImported) { }
        public BasePatientDataCorrection(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BasePatientDataCorrection(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BasePatientDataCorrection() : base() { }

    }
}