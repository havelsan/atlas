
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BaseDentalSubactionProcedure")] 

    public  partial class BaseDentalSubactionProcedure : SubactionProcedureWithDiagnosis
    {
        public class BaseDentalSubactionProcedureList : TTObjectCollection<BaseDentalSubactionProcedure> { }
                    
        public class ChildBaseDentalSubactionProcedureCollection : TTObject.TTChildObjectCollection<BaseDentalSubactionProcedure>
        {
            public ChildBaseDentalSubactionProcedureCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBaseDentalSubactionProcedureCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid New { get { return new Guid("1c28a828-4470-46a5-af69-701b5322df1f"); } }
            public static Guid Completed { get { return new Guid("35536bbc-e567-46c8-be88-3bc9d65bfd5f"); } }
            public static Guid Cancelled { get { return new Guid("d16bf872-a7d1-476c-806d-92fd1852dccc"); } }
        }

        public TreatmentDischarge TreatmentDischarge
        {
            get { return (TreatmentDischarge)((ITTObject)this).GetParent("TREATMENTDISCHARGE"); }
            set { this["TREATMENTDISCHARGE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        override protected void CreateDiagnosisCollection()
        {
            _Diagnosis = new DiagnosisGrid.ChildDiagnosisGridCollection(this, new Guid("f79f3bf0-2f0f-4f6f-afda-9051287ca2fa"));
            ((ITTChildObjectCollection)_Diagnosis).GetChildren();
        }

        protected BaseDentalSubactionProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BaseDentalSubactionProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BaseDentalSubactionProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BaseDentalSubactionProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BaseDentalSubactionProcedure(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BASEDENTALSUBACTIONPROCEDURE", dataRow) { }
        protected BaseDentalSubactionProcedure(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BASEDENTALSUBACTIONPROCEDURE", dataRow, isImported) { }
        public BaseDentalSubactionProcedure(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BaseDentalSubactionProcedure(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BaseDentalSubactionProcedure() : base() { }

    }
}