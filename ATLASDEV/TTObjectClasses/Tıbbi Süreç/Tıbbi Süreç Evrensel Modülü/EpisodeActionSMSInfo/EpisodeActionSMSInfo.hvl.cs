
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="EpisodeActionSMSInfo")] 

    public  partial class EpisodeActionSMSInfo : TTObject
    {
        public class EpisodeActionSMSInfoList : TTObjectCollection<EpisodeActionSMSInfo> { }
                    
        public class ChildEpisodeActionSMSInfoCollection : TTObject.TTChildObjectCollection<EpisodeActionSMSInfo>
        {
            public ChildEpisodeActionSMSInfoCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildEpisodeActionSMSInfoCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<EpisodeActionSMSInfo> GetSendToBeSmsInfo(TTObjectContext objectContext, int DAYLIMIT, string OBJECTDEFNAME, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTIONSMSINFO"].QueryDefs["GetSendToBeSmsInfo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DAYLIMIT", DAYLIMIT);
            paramList.Add("OBJECTDEFNAME", OBJECTDEFNAME);

            return ((ITTQuery)objectContext).QueryObjects<EpisodeActionSMSInfo>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<EpisodeActionSMSInfo> GetEpisodeActionSmsInfo(TTObjectContext objectContext, Guid EPISODEACTIONID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTIONSMSINFO"].QueryDefs["GetEpisodeActionSmsInfo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEACTIONID", EPISODEACTIONID);

            return ((ITTQuery)objectContext).QueryObjects<EpisodeActionSMSInfo>(queryDef, paramList);
        }

        public Guid? ResponsibleUserID
        {
            get { return (Guid?)this["RESPONSIBLEUSERID"]; }
            set { this["RESPONSIBLEUSERID"] = value; }
        }

        public Guid? DoctorUserID
        {
            get { return (Guid?)this["DOCTORUSERID"]; }
            set { this["DOCTORUSERID"] = value; }
        }

        public Guid? ChiefUserID
        {
            get { return (Guid?)this["CHIEFUSERID"]; }
            set { this["CHIEFUSERID"] = value; }
        }

    /// <summary>
    /// Kontrol edilecek tarih
    /// </summary>
        public DateTime? EpisodeActionDate
        {
            get { return (DateTime?)this["EPISODEACTIONDATE"]; }
            set { this["EPISODEACTIONDATE"] = value; }
        }

    /// <summary>
    /// Sms gönderilecek mi?
    /// </summary>
        public bool? IsActiveFlag
        {
            get { return (bool?)this["ISACTIVEFLAG"]; }
            set { this["ISACTIVEFLAG"] = value; }
        }

    /// <summary>
    /// Action Tamamlandı mı?
    /// </summary>
        public bool? CompletedFlag
        {
            get { return (bool?)this["COMPLETEDFLAG"]; }
            set { this["COMPLETEDFLAG"] = value; }
        }

    /// <summary>
    /// Hangi Action?
    /// </summary>
        public string InternalObjectDefName
        {
            get { return (string)this["INTERNALOBJECTDEFNAME"]; }
            set { this["INTERNALOBJECTDEFNAME"] = value; }
        }

    /// <summary>
    /// İdari Sorumluya Gönderilen SMS Sayısı
    /// </summary>
        public int? SMSNumberForResponsible
        {
            get { return (int?)this["SMSNUMBERFORRESPONSIBLE"]; }
            set { this["SMSNUMBERFORRESPONSIBLE"] = value; }
        }

    /// <summary>
    /// Doktora gönderilen sms sayısı
    /// </summary>
        public int? SMSNumberForDoctor
        {
            get { return (int?)this["SMSNUMBERFORDOCTOR"]; }
            set { this["SMSNUMBERFORDOCTOR"] = value; }
        }

    /// <summary>
    /// Başhekim yardımcısına gönderilen sms sayısı
    /// </summary>
        public int? SMSNumberForChief
        {
            get { return (int?)this["SMSNUMBERFORCHIEF"]; }
            set { this["SMSNUMBERFORCHIEF"] = value; }
        }

        public EpisodeAction EpisodeAction
        {
            get { return (EpisodeAction)((ITTObject)this).GetParent("EPISODEACTION"); }
            set { this["EPISODEACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected EpisodeActionSMSInfo(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected EpisodeActionSMSInfo(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected EpisodeActionSMSInfo(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected EpisodeActionSMSInfo(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected EpisodeActionSMSInfo(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EPISODEACTIONSMSINFO", dataRow) { }
        protected EpisodeActionSMSInfo(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EPISODEACTIONSMSINFO", dataRow, isImported) { }
        public EpisodeActionSMSInfo(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public EpisodeActionSMSInfo(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public EpisodeActionSMSInfo() : base() { }

    }
}