
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ehrHyperbaricOxygenTreatmentOrder")] 

    /// <summary>
    /// Hiperbarik Oksijen Tedavi Emri
    /// </summary>
    public  partial class ehrHyperbaricOxygenTreatmentOrder : ehrEpisodeAction
    {
        public class ehrHyperbaricOxygenTreatmentOrderList : TTObjectCollection<ehrHyperbaricOxygenTreatmentOrder> { }
                    
        public class ChildehrHyperbaricOxygenTreatmentOrderCollection : TTObject.TTChildObjectCollection<ehrHyperbaricOxygenTreatmentOrder>
        {
            public ChildehrHyperbaricOxygenTreatmentOrderCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildehrHyperbaricOxygenTreatmentOrderCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Active { get { return new Guid("d82caca1-a08a-43fa-b009-be70b816c5ec"); } }
            public static Guid UnActive { get { return new Guid("8abe0000-7e19-46e0-a07f-e69109e6aa4c"); } }
        }

    /// <summary>
    /// Hasta Takip Formu
    /// </summary>
        public object PatientFollowUpForm
        {
            get { return (object)this["PATIENTFOLLOWUPFORM"]; }
            set { this["PATIENTFOLLOWUPFORM"] = value; }
        }

    /// <summary>
    /// Tedavi Derinliği (m)
    /// </summary>
        public int? TreatmentDepth
        {
            get { return (int?)this["TREATMENTDEPTH"]; }
            set { this["TREATMENTDEPTH"] = value; }
        }

    /// <summary>
    /// Sure/dk
    /// </summary>
        public long? Duration
        {
            get { return (long?)this["DURATION"]; }
            set { this["DURATION"] = value; }
        }

    /// <summary>
    /// Kür
    /// </summary>
        public double? Amount
        {
            get { return (double?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

    /// <summary>
    /// Hiperbarik Oksijen Tedavi İşlemi
    /// </summary>
        public ProcedureDefinition ProcedureObject
        {
            get { return (ProcedureDefinition)((ITTObject)this).GetParent("PROCEDUREOBJECT"); }
            set { this["PROCEDUREOBJECT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ehrHyperbaricOxygenTreatmentOrder(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ehrHyperbaricOxygenTreatmentOrder(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ehrHyperbaricOxygenTreatmentOrder(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ehrHyperbaricOxygenTreatmentOrder(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ehrHyperbaricOxygenTreatmentOrder(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EHRHYPERBARICOXYGENTREATMENTORDER", dataRow) { }
        protected ehrHyperbaricOxygenTreatmentOrder(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EHRHYPERBARICOXYGENTREATMENTORDER", dataRow, isImported) { }
        public ehrHyperbaricOxygenTreatmentOrder(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ehrHyperbaricOxygenTreatmentOrder(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ehrHyperbaricOxygenTreatmentOrder() : base() { }

    }
}