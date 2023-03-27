
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="IndustrialAccidentReport")] 

    public  partial class IndustrialAccidentReport : TTObject
    {
        public class IndustrialAccidentReportList : TTObjectCollection<IndustrialAccidentReport> { }
                    
        public class ChildIndustrialAccidentReportCollection : TTObject.TTChildObjectCollection<IndustrialAccidentReport>
        {
            public ChildIndustrialAccidentReportCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildIndustrialAccidentReportCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetIndustrialAccidentReportBySubepisode_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetIndustrialAccidentReportBySubepisode_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetIndustrialAccidentReportBySubepisode_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetIndustrialAccidentReportBySubepisode_Class() : base() { }
        }

        public static BindingList<IndustrialAccidentReport.GetIndustrialAccidentReportBySubepisode_Class> GetIndustrialAccidentReportBySubepisode(Guid SUBEPISODEID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INDUSTRIALACCIDENTREPORT"].QueryDefs["GetIndustrialAccidentReportBySubepisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODEID", SUBEPISODEID);

            return TTReportNqlObject.QueryObjects<IndustrialAccidentReport.GetIndustrialAccidentReportBySubepisode_Class>(queryDef, paramList, pi);
        }

        public static BindingList<IndustrialAccidentReport.GetIndustrialAccidentReportBySubepisode_Class> GetIndustrialAccidentReportBySubepisode(TTObjectContext objectContext, Guid SUBEPISODEID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INDUSTRIALACCIDENTREPORT"].QueryDefs["GetIndustrialAccidentReportBySubepisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODEID", SUBEPISODEID);

            return TTReportNqlObject.QueryObjects<IndustrialAccidentReport.GetIndustrialAccidentReportBySubepisode_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// İş Yeri No
    /// </summary>
        public string WorkPlaceNo
        {
            get { return (string)this["WORKPLACENO"]; }
            set { this["WORKPLACENO"] = value; }
        }

    /// <summary>
    /// Bağlı Bulunduğu Ünite
    /// </summary>
        public string Unit
        {
            get { return (string)this["UNIT"]; }
            set { this["UNIT"] = value; }
        }

    /// <summary>
    /// Görevi
    /// </summary>
        public string Position
        {
            get { return (string)this["POSITION"]; }
            set { this["POSITION"] = value; }
        }

    /// <summary>
    /// İş Yeri Adresi
    /// </summary>
        public string WorkAddress
        {
            get { return (string)this["WORKADDRESS"]; }
            set { this["WORKADDRESS"] = value; }
        }

    /// <summary>
    /// İş Yeri Ünvan
    /// </summary>
        public string WorkTitle
        {
            get { return (string)this["WORKTITLE"]; }
            set { this["WORKTITLE"] = value; }
        }

    /// <summary>
    /// Tel No
    /// </summary>
        public string PhoneNumber
        {
            get { return (string)this["PHONENUMBER"]; }
            set { this["PHONENUMBER"] = value; }
        }

    /// <summary>
    /// Yaranın Türü
    /// </summary>
        public string WoundType
        {
            get { return (string)this["WOUNDTYPE"]; }
            set { this["WOUNDTYPE"] = value; }
        }

    /// <summary>
    /// Yaranın Vücuttaki Yeri
    /// </summary>
        public string WoundLocation
        {
            get { return (string)this["WOUNDLOCATION"]; }
            set { this["WOUNDLOCATION"] = value; }
        }

    /// <summary>
    /// Yaralanmaya Neden Olan Araç
    /// </summary>
        public string WoundCause
        {
            get { return (string)this["WOUNDCAUSE"]; }
            set { this["WOUNDCAUSE"] = value; }
        }

    /// <summary>
    /// Bildirim Tarihi
    /// </summary>
        public DateTime? NoticeDate
        {
            get { return (DateTime?)this["NOTICEDATE"]; }
            set { this["NOTICEDATE"] = value; }
        }

    /// <summary>
    /// Çalışılan Ortam
    /// </summary>
        public string WorkEnvironment
        {
            get { return (string)this["WORKENVIRONMENT"]; }
            set { this["WORKENVIRONMENT"] = value; }
        }

    /// <summary>
    /// Saptama Şekli
    /// </summary>
        public string DeterminationWay
        {
            get { return (string)this["DETERMINATIONWAY"]; }
            set { this["DETERMINATIONWAY"] = value; }
        }

    /// <summary>
    /// Meslek Hastalığı Etkeni
    /// </summary>
        public string DiseaseFactor
        {
            get { return (string)this["DISEASEFACTOR"]; }
            set { this["DISEASEFACTOR"] = value; }
        }

    /// <summary>
    /// Meslek Hastalığı Etken Süresi
    /// </summary>
        public string DiseaseActiveTime
        {
            get { return (string)this["DISEASEACTIVETIME"]; }
            set { this["DISEASEACTIVETIME"] = value; }
        }

    /// <summary>
    /// İş Göremezlik Seviyesi
    /// </summary>
        public string IncapacityLevel
        {
            get { return (string)this["INCAPACITYLEVEL"]; }
            set { this["INCAPACITYLEVEL"] = value; }
        }

    /// <summary>
    /// Bildirim Tarihi
    /// </summary>
        public DateTime? NoticeDate2
        {
            get { return (DateTime?)this["NOTICEDATE2"]; }
            set { this["NOTICEDATE2"] = value; }
        }

    /// <summary>
    /// İş Yeri Bağlı Bulunduğu İl
    /// </summary>
        public string City
        {
            get { return (string)this["CITY"]; }
            set { this["CITY"] = value; }
        }

        public SubEpisode SubEpisode
        {
            get { return (SubEpisode)((ITTObject)this).GetParent("SUBEPISODE"); }
            set { this["SUBEPISODE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected IndustrialAccidentReport(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected IndustrialAccidentReport(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected IndustrialAccidentReport(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected IndustrialAccidentReport(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected IndustrialAccidentReport(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "INDUSTRIALACCIDENTREPORT", dataRow) { }
        protected IndustrialAccidentReport(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "INDUSTRIALACCIDENTREPORT", dataRow, isImported) { }
        public IndustrialAccidentReport(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public IndustrialAccidentReport(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public IndustrialAccidentReport() : base() { }

    }
}