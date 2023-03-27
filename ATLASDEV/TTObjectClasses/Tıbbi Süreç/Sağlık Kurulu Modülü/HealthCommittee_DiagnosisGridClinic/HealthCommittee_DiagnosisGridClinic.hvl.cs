
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HealthCommittee_DiagnosisGridClinic")] 

    public  partial class HealthCommittee_DiagnosisGridClinic : TTObject
    {
        public class HealthCommittee_DiagnosisGridClinicList : TTObjectCollection<HealthCommittee_DiagnosisGridClinic> { }
                    
        public class ChildHealthCommittee_DiagnosisGridClinicCollection : TTObject.TTChildObjectCollection<HealthCommittee_DiagnosisGridClinic>
        {
            public ChildHealthCommittee_DiagnosisGridClinicCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHealthCommittee_DiagnosisGridClinicCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Tanı Tipi
    /// </summary>
        public DiagnosisTypeEnum? DiagnosisType
        {
            get { return (DiagnosisTypeEnum?)(int?)this["DIAGNOSISTYPE"]; }
            set { this["DIAGNOSISTYPE"] = value; }
        }

    /// <summary>
    /// Özgeçmişe Ekle
    /// </summary>
        public bool? AddToHistory
        {
            get { return (bool?)this["ADDTOHISTORY"]; }
            set { this["ADDTOHISTORY"] = value; }
        }

    /// <summary>
    /// Tanı Giriş Tarihi
    /// </summary>
        public DateTime? DiagnoseDate
        {
            get { return (DateTime?)this["DIAGNOSEDATE"]; }
            set { this["DIAGNOSEDATE"] = value; }
        }

        public HealthCommittee HealthCommittee
        {
            get { return (HealthCommittee)((ITTObject)this).GetParent("HEALTHCOMMITTEE"); }
            set { this["HEALTHCOMMITTEE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Tanı
    /// </summary>
        public DiagnosisDefinition Diagnose
        {
            get { return (DiagnosisDefinition)((ITTObject)this).GetParent("DIAGNOSE"); }
            set { this["DIAGNOSE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected HealthCommittee_DiagnosisGridClinic(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HealthCommittee_DiagnosisGridClinic(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HealthCommittee_DiagnosisGridClinic(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HealthCommittee_DiagnosisGridClinic(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HealthCommittee_DiagnosisGridClinic(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HEALTHCOMMITTEE_DIAGNOSISGRIDCLINIC", dataRow) { }
        protected HealthCommittee_DiagnosisGridClinic(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HEALTHCOMMITTEE_DIAGNOSISGRIDCLINIC", dataRow, isImported) { }
        public HealthCommittee_DiagnosisGridClinic(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HealthCommittee_DiagnosisGridClinic(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HealthCommittee_DiagnosisGridClinic() : base() { }

    }
}