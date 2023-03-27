
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DPDetail")] 

    public  partial class DPDetail : TTObject
    {
        public class DPDetailList : TTObjectCollection<DPDetail> { }
                    
        public class ChildDPDetailCollection : TTObject.TTChildObjectCollection<DPDetail>
        {
            public ChildDPDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDPDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetDistinctSUBEPISODE_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetDistinctSUBEPISODE_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDistinctSUBEPISODE_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDistinctSUBEPISODE_Class() : base() { }
        }

        [Serializable] 

        public partial class GetTotalPointOfTerm_Class : TTReportNqlObject 
        {
            public Object Totalpoint
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTALPOINT"]);
                }
            }

            public GetTotalPointOfTerm_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetTotalPointOfTerm_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetTotalPointOfTerm_Class() : base() { }
        }

        [Serializable] 

        public partial class GetGroupedTotalPointOfTerm_Class : TTReportNqlObject 
        {
            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Totalpoint
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTALPOINT"]);
                }
            }

            public GetGroupedTotalPointOfTerm_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetGroupedTotalPointOfTerm_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetGroupedTotalPointOfTerm_Class() : base() { }
        }

        public static BindingList<DPDetail.GetDistinctSUBEPISODE_Class> GetDistinctSUBEPISODE(Guid TERM, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DPDETAIL"].QueryDefs["GetDistinctSUBEPISODE"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERM", TERM);

            return TTReportNqlObject.QueryObjects<DPDetail.GetDistinctSUBEPISODE_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DPDetail.GetDistinctSUBEPISODE_Class> GetDistinctSUBEPISODE(TTObjectContext objectContext, Guid TERM, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DPDETAIL"].QueryDefs["GetDistinctSUBEPISODE"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERM", TERM);

            return TTReportNqlObject.QueryObjects<DPDetail.GetDistinctSUBEPISODE_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DPDetail> getDPDetailWithSEAndTerm(TTObjectContext objectContext, Guid TERM, Guid SUBEPISODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DPDETAIL"].QueryDefs["getDPDetailWithSEAndTerm"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERM", TERM);
            paramList.Add("SUBEPISODE", SUBEPISODE);

            return ((ITTQuery)objectContext).QueryObjects<DPDetail>(queryDef, paramList);
        }

        public static BindingList<DPDetail.GetTotalPointOfTerm_Class> GetTotalPointOfTerm(Guid TERMID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DPDETAIL"].QueryDefs["GetTotalPointOfTerm"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERMID", TERMID);

            return TTReportNqlObject.QueryObjects<DPDetail.GetTotalPointOfTerm_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DPDetail.GetTotalPointOfTerm_Class> GetTotalPointOfTerm(TTObjectContext objectContext, Guid TERMID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DPDETAIL"].QueryDefs["GetTotalPointOfTerm"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERMID", TERMID);

            return TTReportNqlObject.QueryObjects<DPDetail.GetTotalPointOfTerm_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DPDetail.GetGroupedTotalPointOfTerm_Class> GetGroupedTotalPointOfTerm(Guid TERMID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DPDETAIL"].QueryDefs["GetGroupedTotalPointOfTerm"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERMID", TERMID);

            return TTReportNqlObject.QueryObjects<DPDetail.GetGroupedTotalPointOfTerm_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DPDetail.GetGroupedTotalPointOfTerm_Class> GetGroupedTotalPointOfTerm(TTObjectContext objectContext, Guid TERMID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DPDETAIL"].QueryDefs["GetGroupedTotalPointOfTerm"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERMID", TERMID);

            return TTReportNqlObject.QueryObjects<DPDetail.GetGroupedTotalPointOfTerm_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// GİL Kodu
    /// </summary>
        public string GILCode
        {
            get { return (string)this["GILCODE"]; }
            set { this["GILCODE"] = value; }
        }

    /// <summary>
    /// GİL Adı
    /// </summary>
        public string GILName
        {
            get { return (string)this["GILNAME"]; }
            set { this["GILNAME"] = value; }
        }

    /// <summary>
    /// GİL Puanı
    /// </summary>
        public double? GILPoint
        {
            get { return (double?)this["GILPOINT"]; }
            set { this["GILPOINT"] = value; }
        }

    /// <summary>
    /// Hesaplanmış Puan
    /// </summary>
        public double? CalcPoint
        {
            get { return (double?)this["CALCPOINT"]; }
            set { this["CALCPOINT"] = value; }
        }

        public bool? IsModified
        {
            get { return (bool?)this["ISMODIFIED"]; }
            set { this["ISMODIFIED"] = value; }
        }

    /// <summary>
    /// Performans Tarihi
    /// </summary>
        public DateTime? PerformedDate
        {
            get { return (DateTime?)this["PERFORMEDDATE"]; }
            set { this["PERFORMEDDATE"] = value; }
        }

        public DPPointType? Type
        {
            get { return (DPPointType?)(int?)this["TYPE"]; }
            set { this["TYPE"] = value; }
        }

    /// <summary>
    /// Hasta Adı
    /// </summary>
        public string PateintName
        {
            get { return (string)this["PATEINTNAME"]; }
            set { this["PATEINTNAME"] = value; }
        }

    /// <summary>
    /// Hasta TC Nosu
    /// </summary>
        public string PatientUniqueRefno
        {
            get { return (string)this["PATIENTUNIQUEREFNO"]; }
            set { this["PATIENTUNIQUEREFNO"] = value; }
        }

    /// <summary>
    /// Kabul No
    /// </summary>
        public string ProtocolNo
        {
            get { return (string)this["PROTOCOLNO"]; }
            set { this["PROTOCOLNO"] = value; }
        }

    /// <summary>
    /// Hasta Doğum Tarihi
    /// </summary>
        public DateTime? PatientBirthDate
        {
            get { return (DateTime?)this["PATIENTBIRTHDATE"]; }
            set { this["PATIENTBIRTHDATE"] = value; }
        }

        public string SurgeryGroup
        {
            get { return (string)this["SURGERYGROUP"]; }
            set { this["SURGERYGROUP"] = value; }
        }

        public string RessectionName
        {
            get { return (string)this["RESSECTIONNAME"]; }
            set { this["RESSECTIONNAME"] = value; }
        }

        public string PatientStatus
        {
            get { return (string)this["PATIENTSTATUS"]; }
            set { this["PATIENTSTATUS"] = value; }
        }

    /// <summary>
    /// Kural Adı
    /// </summary>
        public string RuleName
        {
            get { return (string)this["RULENAME"]; }
            set { this["RULENAME"] = value; }
        }

    /// <summary>
    /// Kural Açıklaması
    /// </summary>
        public string RuleDescription
        {
            get { return (string)this["RULEDESCRIPTION"]; }
            set { this["RULEDESCRIPTION"] = value; }
        }

        public double? BeforeModifyPoint
        {
            get { return (double?)this["BEFOREMODIFYPOINT"]; }
            set { this["BEFOREMODIFYPOINT"] = value; }
        }

        public DPMaster DPMaster
        {
            get { return (DPMaster)((ITTObject)this).GetParent("DPMASTER"); }
            set { this["DPMASTER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SubActionProcedure SubActionProcedure
        {
            get { return (SubActionProcedure)((ITTObject)this).GetParent("SUBACTIONPROCEDURE"); }
            set { this["SUBACTIONPROCEDURE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SubEpisode SubEpisode
        {
            get { return (SubEpisode)((ITTObject)this).GetParent("SUBEPISODE"); }
            set { this["SUBEPISODE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DPDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DPDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DPDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DPDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DPDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DPDETAIL", dataRow) { }
        protected DPDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DPDETAIL", dataRow, isImported) { }
        public DPDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DPDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DPDetail() : base() { }

    }
}