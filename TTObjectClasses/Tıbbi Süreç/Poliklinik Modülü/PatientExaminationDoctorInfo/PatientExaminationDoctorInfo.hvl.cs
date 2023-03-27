
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PatientExaminationDoctorInfo")] 

    /// <summary>
    /// Poliklinik Hizmetleri SMS için İlgili Hekim Bilgisi
    /// </summary>
    public  partial class PatientExaminationDoctorInfo : TTObject
    {
        public class PatientExaminationDoctorInfoList : TTObjectCollection<PatientExaminationDoctorInfo> { }
                    
        public class ChildPatientExaminationDoctorInfoCollection : TTObject.TTChildObjectCollection<PatientExaminationDoctorInfo>
        {
            public ChildPatientExaminationDoctorInfoCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPatientExaminationDoctorInfoCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Bugün içinde Doktora Ait Kayıt Bilgisi
    /// </summary>
        public static BindingList<PatientExaminationDoctorInfo> GetDoctorRecordForToday(TTObjectContext objectContext, Guid DOCTOR)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATIONDOCTORINFO"].QueryDefs["GetDoctorRecordForToday"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DOCTOR", DOCTOR);

            return ((ITTQuery)objectContext).QueryObjects<PatientExaminationDoctorInfo>(queryDef, paramList);
        }

    /// <summary>
    ///  IsSMSsendForDoctor=false olan aktif işlemler
    /// </summary>
        public static BindingList<PatientExaminationDoctorInfo> GetNotSMSsendDoctorList(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATIONDOCTORINFO"].QueryDefs["GetNotSMSsendDoctorList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<PatientExaminationDoctorInfo>(queryDef, paramList);
        }

    /// <summary>
    /// IsSMSsendForChief =false olan aktif işlemler
    /// </summary>
        public static BindingList<PatientExaminationDoctorInfo> GetNotSMSsendChiefList(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATIONDOCTORINFO"].QueryDefs["GetNotSMSsendChiefList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<PatientExaminationDoctorInfo>(queryDef, paramList);
        }

    /// <summary>
    ///  IsSMSsendForResponsible=false olan aktif işlemler
    /// </summary>
        public static BindingList<PatientExaminationDoctorInfo> GetNotSMSsendResponsibleList(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATIONDOCTORINFO"].QueryDefs["GetNotSMSsendResponsibleList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<PatientExaminationDoctorInfo>(queryDef, paramList);
        }

    /// <summary>
    /// Muayene İstek Tarihi
    /// </summary>
        public DateTime? ExaminationDate
        {
            get { return (DateTime?)this["EXAMINATIONDATE"]; }
            set { this["EXAMINATIONDATE"] = value; }
        }

    /// <summary>
    /// Muayene Başladı mı?true:başladı,false:başlamadı
    /// </summary>
        public bool? ExaminationFlag
        {
            get { return (bool?)this["EXAMINATIONFLAG"]; }
            set { this["EXAMINATIONFLAG"] = value; }
        }

    /// <summary>
    /// Doktora SMS gönderildi mi?
    /// </summary>
        public bool? IsSMSsendForDoctor
        {
            get { return (bool?)this["ISSMSSENDFORDOCTOR"]; }
            set { this["ISSMSSENDFORDOCTOR"] = value; }
        }

    /// <summary>
    /// Başhekim Yardımcısına SMS gönderildi mi?
    /// </summary>
        public bool? IsSMSsendForChief
        {
            get { return (bool?)this["ISSMSSENDFORCHIEF"]; }
            set { this["ISSMSSENDFORCHIEF"] = value; }
        }

    /// <summary>
    /// İdari Sorumluya SMS gönderildi mi?
    /// </summary>
        public bool? IsSMSsendForResponsible
        {
            get { return (bool?)this["ISSMSSENDFORRESPONSIBLE"]; }
            set { this["ISSMSSENDFORRESPONSIBLE"] = value; }
        }

    /// <summary>
    /// Sms işlemlerine dahil edilecek mi? true ise aktif
    /// </summary>
        public bool? IsActiveFlag
        {
            get { return (bool?)this["ISACTIVEFLAG"]; }
            set { this["ISACTIVEFLAG"] = value; }
        }

        public ResUser ResUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESUSER"); }
            set { this["RESUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PatientExamination PatientExamination
        {
            get { return (PatientExamination)((ITTObject)this).GetParent("PATIENTEXAMINATION"); }
            set { this["PATIENTEXAMINATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PatientExaminationDoctorInfo(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PatientExaminationDoctorInfo(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PatientExaminationDoctorInfo(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PatientExaminationDoctorInfo(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PatientExaminationDoctorInfo(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PATIENTEXAMINATIONDOCTORINFO", dataRow) { }
        protected PatientExaminationDoctorInfo(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PATIENTEXAMINATIONDOCTORINFO", dataRow, isImported) { }
        public PatientExaminationDoctorInfo(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PatientExaminationDoctorInfo(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PatientExaminationDoctorInfo() : base() { }

    }
}