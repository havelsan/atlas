
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PatientRestDose")] 

    public  partial class PatientRestDose : TTObject
    {
        public class PatientRestDoseList : TTObjectCollection<PatientRestDose> { }
                    
        public class ChildPatientRestDoseCollection : TTObject.TTChildObjectCollection<PatientRestDose>
        {
            public ChildPatientRestDoseCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPatientRestDoseCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Toplam Miktar
    /// </summary>
        public double? Amount
        {
            get { return (double?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

    /// <summary>
    /// Toplam Doz
    /// </summary>
        public double? TotalDose
        {
            get { return (double?)this["TOTALDOSE"]; }
            set { this["TOTALDOSE"] = value; }
        }

        public DrugOrder DrugOrder
        {
            get { return (DrugOrder)((ITTObject)this).GetParent("DRUGORDER"); }
            set { this["DRUGORDER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public KScheduleMaterial KScheduleMaterial
        {
            get { return (KScheduleMaterial)((ITTObject)this).GetParent("KSCHEDULEMATERIAL"); }
            set { this["KSCHEDULEMATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreatePatientRestDoseDetailsCollection()
        {
            _PatientRestDoseDetails = new PatientRestDoseDetail.ChildPatientRestDoseDetailCollection(this, new Guid("c36d911c-247b-4d13-ae9f-0e0bc436914a"));
            ((ITTChildObjectCollection)_PatientRestDoseDetails).GetChildren();
        }

        protected PatientRestDoseDetail.ChildPatientRestDoseDetailCollection _PatientRestDoseDetails = null;
        public PatientRestDoseDetail.ChildPatientRestDoseDetailCollection PatientRestDoseDetails
        {
            get
            {
                if (_PatientRestDoseDetails == null)
                    CreatePatientRestDoseDetailsCollection();
                return _PatientRestDoseDetails;
            }
        }

        protected PatientRestDose(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PatientRestDose(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PatientRestDose(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PatientRestDose(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PatientRestDose(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PATIENTRESTDOSE", dataRow) { }
        protected PatientRestDose(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PATIENTRESTDOSE", dataRow, isImported) { }
        public PatientRestDose(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PatientRestDose(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PatientRestDose() : base() { }

    }
}