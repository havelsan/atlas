
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PatientAdmissionCount")] 

    /// <summary>
    /// Doktor-birim bazlı alınan kabul sayısı
    /// </summary>
    public  partial class PatientAdmissionCount : TTObject
    {
        public class PatientAdmissionCountList : TTObjectCollection<PatientAdmissionCount> { }
                    
        public class ChildPatientAdmissionCountCollection : TTObject.TTChildObjectCollection<PatientAdmissionCount>
        {
            public ChildPatientAdmissionCountCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPatientAdmissionCountCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<PatientAdmissionCount> GetByDoctorPoliclinic(TTObjectContext objectContext, Guid RESUSER, Guid RESPOLICLINIC, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSIONCOUNT"].QueryDefs["GetByDoctorPoliclinic"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("RESUSER", RESUSER);
            paramList.Add("RESPOLICLINIC", RESPOLICLINIC);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<PatientAdmissionCount>(queryDef, paramList);
        }

        public static BindingList<PatientAdmissionCount> GetPaCountByPoliclinic(TTObjectContext objectContext, Guid RESPOLICLINIC, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSIONCOUNT"].QueryDefs["GetPaCountByPoliclinic"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("RESPOLICLINIC", RESPOLICLINIC);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<PatientAdmissionCount>(queryDef, paramList);
        }

    /// <summary>
    /// Alınan kabul sayısı
    /// </summary>
        public int? Counter
        {
            get { return (int?)this["COUNTER"]; }
            set { this["COUNTER"] = value; }
        }

        public DateTime? PatientAdmissionDate
        {
            get { return (DateTime?)this["PATIENTADMISSIONDATE"]; }
            set { this["PATIENTADMISSIONDATE"] = value; }
        }

        public ResPoliclinic Policlinic
        {
            get { return (ResPoliclinic)((ITTObject)this).GetParent("POLICLINIC"); }
            set { this["POLICLINIC"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResUser Doctor
        {
            get { return (ResUser)((ITTObject)this).GetParent("DOCTOR"); }
            set { this["DOCTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PatientAdmissionCount(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PatientAdmissionCount(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PatientAdmissionCount(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PatientAdmissionCount(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PatientAdmissionCount(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PATIENTADMISSIONCOUNT", dataRow) { }
        protected PatientAdmissionCount(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PATIENTADMISSIONCOUNT", dataRow, isImported) { }
        public PatientAdmissionCount(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PatientAdmissionCount(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PatientAdmissionCount() : base() { }

    }
}