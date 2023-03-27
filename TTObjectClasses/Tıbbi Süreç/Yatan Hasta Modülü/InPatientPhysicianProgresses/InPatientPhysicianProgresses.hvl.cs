
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="InPatientPhysicianProgresses")] 

    /// <summary>
    /// Yatan Hasta Hastanın Güncesi Sekmesi
    /// </summary>
    public  partial class InPatientPhysicianProgresses : TTObject
    {
        public class InPatientPhysicianProgressesList : TTObjectCollection<InPatientPhysicianProgresses> { }
                    
        public class ChildInPatientPhysicianProgressesCollection : TTObject.TTChildObjectCollection<InPatientPhysicianProgresses>
        {
            public ChildInPatientPhysicianProgressesCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildInPatientPhysicianProgressesCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetInpatienPhProgressesBySubEpisode_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? ObjectDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTDEFID"]);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public DateTime? LastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LASTUPDATE"]);
                    if (val == null)
                        return null;
                    return (DateTime)Convert.ChangeType(val, typeof(DateTime)); 
                }
            }

            public DateTime? ProgressDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROGRESSDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTPHYSICIANPROGRESSES"].AllPropertyDefs["PROGRESSDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public object Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTPHYSICIANPROGRESSES"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public GetInpatienPhProgressesBySubEpisode_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetInpatienPhProgressesBySubEpisode_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetInpatienPhProgressesBySubEpisode_Class() : base() { }
        }

        [Serializable] 

        public partial class GetInpatienPhProgressesByEpisode_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? ObjectDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTDEFID"]);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public DateTime? LastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LASTUPDATE"]);
                    if (val == null)
                        return null;
                    return (DateTime)Convert.ChangeType(val, typeof(DateTime)); 
                }
            }

            public DateTime? ProgressDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROGRESSDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTPHYSICIANPROGRESSES"].AllPropertyDefs["PROGRESSDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public object Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTPHYSICIANPROGRESSES"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public GetInpatienPhProgressesByEpisode_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetInpatienPhProgressesByEpisode_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetInpatienPhProgressesByEpisode_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMaxProgressDateByDate_Class : TTReportNqlObject 
        {
            public Object Maxprogressdate
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MAXPROGRESSDATE"]);
                }
            }

            public GetMaxProgressDateByDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMaxProgressDateByDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMaxProgressDateByDate_Class() : base() { }
        }

        public static BindingList<InPatientPhysicianProgresses.GetInpatienPhProgressesBySubEpisode_Class> GetInpatienPhProgressesBySubEpisode(string SUBEPISODE, string EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTPHYSICIANPROGRESSES"].QueryDefs["GetInpatienPhProgressesBySubEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<InPatientPhysicianProgresses.GetInpatienPhProgressesBySubEpisode_Class>(queryDef, paramList, pi);
        }

        public static BindingList<InPatientPhysicianProgresses.GetInpatienPhProgressesBySubEpisode_Class> GetInpatienPhProgressesBySubEpisode(TTObjectContext objectContext, string SUBEPISODE, string EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTPHYSICIANPROGRESSES"].QueryDefs["GetInpatienPhProgressesBySubEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<InPatientPhysicianProgresses.GetInpatienPhProgressesBySubEpisode_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<InPatientPhysicianProgresses.GetInpatienPhProgressesByEpisode_Class> GetInpatienPhProgressesByEpisode(Guid EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTPHYSICIANPROGRESSES"].QueryDefs["GetInpatienPhProgressesByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<InPatientPhysicianProgresses.GetInpatienPhProgressesByEpisode_Class>(queryDef, paramList, pi);
        }

        public static BindingList<InPatientPhysicianProgresses.GetInpatienPhProgressesByEpisode_Class> GetInpatienPhProgressesByEpisode(TTObjectContext objectContext, Guid EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTPHYSICIANPROGRESSES"].QueryDefs["GetInpatienPhProgressesByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<InPatientPhysicianProgresses.GetInpatienPhProgressesByEpisode_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<InPatientPhysicianProgresses> GetByObjectId(TTObjectContext objectContext, Guid OBJECTID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTPHYSICIANPROGRESSES"].QueryDefs["GetByObjectId"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return ((ITTQuery)objectContext).QueryObjects<InPatientPhysicianProgresses>(queryDef, paramList);
        }

        public static BindingList<InPatientPhysicianProgresses.GetMaxProgressDateByDate_Class> GetMaxProgressDateByDate(string INPATIENTPHYAPP, DateTime STARTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTPHYSICIANPROGRESSES"].QueryDefs["GetMaxProgressDateByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("INPATIENTPHYAPP", INPATIENTPHYAPP);
            paramList.Add("STARTDATE", STARTDATE);

            return TTReportNqlObject.QueryObjects<InPatientPhysicianProgresses.GetMaxProgressDateByDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<InPatientPhysicianProgresses.GetMaxProgressDateByDate_Class> GetMaxProgressDateByDate(TTObjectContext objectContext, string INPATIENTPHYAPP, DateTime STARTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTPHYSICIANPROGRESSES"].QueryDefs["GetMaxProgressDateByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("INPATIENTPHYAPP", INPATIENTPHYAPP);
            paramList.Add("STARTDATE", STARTDATE);

            return TTReportNqlObject.QueryObjects<InPatientPhysicianProgresses.GetMaxProgressDateByDate_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<InPatientPhysicianProgresses> GetByInpatientPhysicianAndDate(TTObjectContext objectContext, string INPATIENTPHYAPP, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTPHYSICIANPROGRESSES"].QueryDefs["GetByInpatientPhysicianAndDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("INPATIENTPHYAPP", INPATIENTPHYAPP);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<InPatientPhysicianProgresses>(queryDef, paramList);
        }

    /// <summary>
    /// Tarih/Saat
    /// </summary>
        public DateTime? ProgressDate
        {
            get { return (DateTime?)this["PROGRESSDATE"]; }
            set { this["PROGRESSDATE"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public object Description
        {
            get { return (object)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Giriş yapıldığı episodeAction (Kilinik doktor işlemleri yada  Epikriz olabilir )
    /// </summary>
        public EpisodeAction EntryEpisodeAction
        {
            get { return (EpisodeAction)((ITTObject)this).GetParent("ENTRYEPISODEACTION"); }
            set { this["ENTRYEPISODEACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İşlemi Gerçekleştiren Doktor Nesnesini Taşıyan Alandır
    /// </summary>
        public ResUser ProcedureDoctor
        {
            get { return (ResUser)((ITTObject)this).GetParent("PROCEDUREDOCTOR"); }
            set { this["PROCEDUREDOCTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SubEpisode SubEpisode
        {
            get { return (SubEpisode)((ITTObject)this).GetParent("SUBEPISODE"); }
            set { this["SUBEPISODE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateOzellikliIzlemVeriSetiCollection()
        {
            _OzellikliIzlemVeriSeti = new OzellikliIzlemVeriSeti.ChildOzellikliIzlemVeriSetiCollection(this, new Guid("05d3ad8e-16a1-4e61-b789-bc157ecdfdb2"));
            ((ITTChildObjectCollection)_OzellikliIzlemVeriSeti).GetChildren();
        }

        protected OzellikliIzlemVeriSeti.ChildOzellikliIzlemVeriSetiCollection _OzellikliIzlemVeriSeti = null;
    /// <summary>
    /// Child collection for Klinik İzlem Notu
    /// </summary>
        public OzellikliIzlemVeriSeti.ChildOzellikliIzlemVeriSetiCollection OzellikliIzlemVeriSeti
        {
            get
            {
                if (_OzellikliIzlemVeriSeti == null)
                    CreateOzellikliIzlemVeriSetiCollection();
                return _OzellikliIzlemVeriSeti;
            }
        }

        protected InPatientPhysicianProgresses(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected InPatientPhysicianProgresses(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected InPatientPhysicianProgresses(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected InPatientPhysicianProgresses(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected InPatientPhysicianProgresses(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "INPATIENTPHYSICIANPROGRESSES", dataRow) { }
        protected InPatientPhysicianProgresses(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "INPATIENTPHYSICIANPROGRESSES", dataRow, isImported) { }
        public InPatientPhysicianProgresses(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public InPatientPhysicianProgresses(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public InPatientPhysicianProgresses() : base() { }

    }
}