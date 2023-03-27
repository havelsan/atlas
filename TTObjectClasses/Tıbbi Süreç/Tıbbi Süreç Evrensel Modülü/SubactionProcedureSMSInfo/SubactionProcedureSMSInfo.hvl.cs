
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SubactionProcedureSMSInfo")] 

    public  partial class SubactionProcedureSMSInfo : TTObject
    {
        public class SubactionProcedureSMSInfoList : TTObjectCollection<SubactionProcedureSMSInfo> { }
                    
        public class ChildSubactionProcedureSMSInfoCollection : TTObject.TTChildObjectCollection<SubactionProcedureSMSInfo>
        {
            public ChildSubactionProcedureSMSInfoCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSubactionProcedureSMSInfoCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<SubactionProcedureSMSInfo> GetSubactionProcedureSmsInfo(TTObjectContext objectContext, Guid SUBACTIONPROCEDUREID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURESMSINFO"].QueryDefs["GetSubactionProcedureSmsInfo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBACTIONPROCEDUREID", SUBACTIONPROCEDUREID);

            return ((ITTQuery)objectContext).QueryObjects<SubactionProcedureSMSInfo>(queryDef, paramList);
        }

        public static BindingList<SubactionProcedureSMSInfo> GetSPSendToBeSMSInfo(TTObjectContext objectContext, string OBJECTDEFNAME, int DAYLIMIT, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURESMSINFO"].QueryDefs["GetSPSendToBeSMSInfo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTDEFNAME", OBJECTDEFNAME);
            paramList.Add("DAYLIMIT", DAYLIMIT);

            return ((ITTQuery)objectContext).QueryObjects<SubactionProcedureSMSInfo>(queryDef, paramList, injectionSQL);
        }

    /// <summary>
    /// Başhekim Yardımcısı 
    /// </summary>
        public Guid? ChiefUserID
        {
            get { return (Guid?)this["CHIEFUSERID"]; }
            set { this["CHIEFUSERID"] = value; }
        }

        public bool? CompletedFlag
        {
            get { return (bool?)this["COMPLETEDFLAG"]; }
            set { this["COMPLETEDFLAG"] = value; }
        }

    /// <summary>
    /// Doktor Kullanıcısı
    /// </summary>
        public Guid? DoctorUserID
        {
            get { return (Guid?)this["DOCTORUSERID"]; }
            set { this["DOCTORUSERID"] = value; }
        }

        public DateTime? ProcedureDate
        {
            get { return (DateTime?)this["PROCEDUREDATE"]; }
            set { this["PROCEDUREDATE"] = value; }
        }

        public string InternalObjectDefNAme
        {
            get { return (string)this["INTERNALOBJECTDEFNAME"]; }
            set { this["INTERNALOBJECTDEFNAME"] = value; }
        }

        public bool? IsActiveFlag
        {
            get { return (bool?)this["ISACTIVEFLAG"]; }
            set { this["ISACTIVEFLAG"] = value; }
        }

        public Guid? ResponsibleUserID
        {
            get { return (Guid?)this["RESPONSIBLEUSERID"]; }
            set { this["RESPONSIBLEUSERID"] = value; }
        }

    /// <summary>
    /// Başhekim yardımcısına gönderilen sms sayısı
    /// </summary>
        public int? SMSNumberForChief
        {
            get { return (int?)this["SMSNUMBERFORCHIEF"]; }
            set { this["SMSNUMBERFORCHIEF"] = value; }
        }

    /// <summary>
    /// Doktora gönderilen sms sayısı
    /// </summary>
        public int? SMSNumberForDoctor
        {
            get { return (int?)this["SMSNUMBERFORDOCTOR"]; }
            set { this["SMSNUMBERFORDOCTOR"] = value; }
        }

        public int? SMSNumberForResponsible
        {
            get { return (int?)this["SMSNUMBERFORRESPONSIBLE"]; }
            set { this["SMSNUMBERFORRESPONSIBLE"] = value; }
        }

        public Guid? SubactionProcedureID
        {
            get { return (Guid?)this["SUBACTIONPROCEDUREID"]; }
            set { this["SUBACTIONPROCEDUREID"] = value; }
        }

        protected SubactionProcedureSMSInfo(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SubactionProcedureSMSInfo(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SubactionProcedureSMSInfo(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SubactionProcedureSMSInfo(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SubactionProcedureSMSInfo(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SUBACTIONPROCEDURESMSINFO", dataRow) { }
        protected SubactionProcedureSMSInfo(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SUBACTIONPROCEDURESMSINFO", dataRow, isImported) { }
        public SubactionProcedureSMSInfo(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SubactionProcedureSMSInfo(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SubactionProcedureSMSInfo() : base() { }

    }
}