
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="EpisodeProtocolDayLimitChangeDetail")] 

    /// <summary>
    /// Sevk Süresi Uzatma Detayları
    /// </summary>
    public  partial class EpisodeProtocolDayLimitChangeDetail : TTObject
    {
        public class EpisodeProtocolDayLimitChangeDetailList : TTObjectCollection<EpisodeProtocolDayLimitChangeDetail> { }
                    
        public class ChildEpisodeProtocolDayLimitChangeDetailCollection : TTObject.TTChildObjectCollection<EpisodeProtocolDayLimitChangeDetail>
        {
            public ChildEpisodeProtocolDayLimitChangeDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildEpisodeProtocolDayLimitChangeDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Kurum Adı
    /// </summary>
        public string PAYERNAME
        {
            get { return (string)this["PAYERNAME"]; }
            set { this["PAYERNAME"] = value; }
        }

    /// <summary>
    /// Uzatma Sebebi
    /// </summary>
        public string REASONOFCHANGE
        {
            get { return (string)this["REASONOFCHANGE"]; }
            set { this["REASONOFCHANGE"] = value; }
        }

    /// <summary>
    /// Anlaşma ID si
    /// </summary>
        public string EPOBJECTID
        {
            get { return (string)this["EPOBJECTID"]; }
            set { this["EPOBJECTID"] = value; }
        }

    /// <summary>
    /// Erteleme Tarihi
    /// </summary>
        public DateTime? POSTPONEDATE
        {
            get { return (DateTime?)this["POSTPONEDATE"]; }
            set { this["POSTPONEDATE"] = value; }
        }

    /// <summary>
    /// Anlaşma Durumu
    /// </summary>
        public string PROTOCOLSTATUS
        {
            get { return (string)this["PROTOCOLSTATUS"]; }
            set { this["PROTOCOLSTATUS"] = value; }
        }

    /// <summary>
    /// Anlaşma Adı
    /// </summary>
        public string PROTOCOLNAME
        {
            get { return (string)this["PROTOCOLNAME"]; }
            set { this["PROTOCOLNAME"] = value; }
        }

    /// <summary>
    /// Gün Limiti
    /// </summary>
        public int? DAYLIMIT
        {
            get { return (int?)this["DAYLIMIT"]; }
            set { this["DAYLIMIT"] = value; }
        }

    /// <summary>
    /// Sevk Süresi Uzatma ile ilişki
    /// </summary>
        public EpisodeProtocolDayLimitChange EpisodeProtocolDayLimitChange
        {
            get { return (EpisodeProtocolDayLimitChange)((ITTObject)this).GetParent("EPISODEPROTOCOLDAYLIMITCHANGE"); }
            set { this["EPISODEPROTOCOLDAYLIMITCHANGE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected EpisodeProtocolDayLimitChangeDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected EpisodeProtocolDayLimitChangeDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected EpisodeProtocolDayLimitChangeDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected EpisodeProtocolDayLimitChangeDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected EpisodeProtocolDayLimitChangeDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EPISODEPROTOCOLDAYLIMITCHANGEDETAIL", dataRow) { }
        protected EpisodeProtocolDayLimitChangeDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EPISODEPROTOCOLDAYLIMITCHANGEDETAIL", dataRow, isImported) { }
        public EpisodeProtocolDayLimitChangeDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public EpisodeProtocolDayLimitChangeDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public EpisodeProtocolDayLimitChangeDetail() : base() { }

    }
}