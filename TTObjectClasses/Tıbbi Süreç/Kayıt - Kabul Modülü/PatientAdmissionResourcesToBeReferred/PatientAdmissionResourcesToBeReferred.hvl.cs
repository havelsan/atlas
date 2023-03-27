
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PatientAdmissionResourcesToBeReferred")] 

    /// <summary>
    /// Henüz fire edilmemiş ancak seçilmiş işlemler
    /// </summary>
    public  partial class PatientAdmissionResourcesToBeReferred : ResourcesToBeReferredGrid
    {
        public class PatientAdmissionResourcesToBeReferredList : TTObjectCollection<PatientAdmissionResourcesToBeReferred> { }
                    
        public class ChildPatientAdmissionResourcesToBeReferredCollection : TTObject.TTChildObjectCollection<PatientAdmissionResourcesToBeReferred>
        {
            public ChildPatientAdmissionResourcesToBeReferredCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPatientAdmissionResourcesToBeReferredCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetResorcesByAdmission_Class : TTReportNqlObject 
        {
            public Guid? Bolum
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["BOLUM"]);
                }
            }

            public Guid? Doktor
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DOKTOR"]);
                }
            }

            public GetResorcesByAdmission_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetResorcesByAdmission_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetResorcesByAdmission_Class() : base() { }
        }

        public static BindingList<PatientAdmissionResourcesToBeReferred.GetResorcesByAdmission_Class> GetResorcesByAdmission(Guid PAOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSIONRESOURCESTOBEREFERRED"].QueryDefs["GetResorcesByAdmission"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PAOBJECTID", PAOBJECTID);

            return TTReportNqlObject.QueryObjects<PatientAdmissionResourcesToBeReferred.GetResorcesByAdmission_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PatientAdmissionResourcesToBeReferred.GetResorcesByAdmission_Class> GetResorcesByAdmission(TTObjectContext objectContext, Guid PAOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSIONRESOURCESTOBEREFERRED"].QueryDefs["GetResorcesByAdmission"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PAOBJECTID", PAOBJECTID);

            return TTReportNqlObject.QueryObjects<PatientAdmissionResourcesToBeReferred.GetResorcesByAdmission_Class>(objectContext, queryDef, paramList, pi);
        }

        public string AdmissionQueueNumber
        {
            get { return (string)this["ADMISSIONQUEUENUMBER"]; }
            set { this["ADMISSIONQUEUENUMBER"] = value; }
        }

    /// <summary>
    /// Uzmanlık
    /// </summary>
        public SpecialityDefinition Speciality
        {
            get { return (SpecialityDefinition)((ITTObject)this).GetParent("SPECIALITY"); }
            set { this["SPECIALITY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Havale Edilecek Birim(ler)
    /// </summary>
        public PatientAdmission PatientAdmission
        {
            get { return (PatientAdmission)((ITTObject)this).GetParent("PATIENTADMISSION"); }
            set { this["PATIENTADMISSION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Doctor
    /// </summary>
        public ResUser ProcedureDoctorToBeReferred
        {
            get { return (ResUser)((ITTObject)this).GetParent("PROCEDUREDOCTORTOBEREFERRED"); }
            set { this["PROCEDUREDOCTORTOBEREFERRED"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PatientAdmissionResourcesToBeReferred(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PatientAdmissionResourcesToBeReferred(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PatientAdmissionResourcesToBeReferred(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PatientAdmissionResourcesToBeReferred(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PatientAdmissionResourcesToBeReferred(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PATIENTADMISSIONRESOURCESTOBEREFERRED", dataRow) { }
        protected PatientAdmissionResourcesToBeReferred(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PATIENTADMISSIONRESOURCESTOBEREFERRED", dataRow, isImported) { }
        public PatientAdmissionResourcesToBeReferred(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PatientAdmissionResourcesToBeReferred(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PatientAdmissionResourcesToBeReferred() : base() { }

    }
}