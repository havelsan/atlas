
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MedulaReportResult")] 

    /// <summary>
    /// Medula Rapor Sonuçları
    /// </summary>
    public  partial class MedulaReportResult : TTObject
    {
        public class MedulaReportResultList : TTObjectCollection<MedulaReportResult> { }
                    
        public class ChildMedulaReportResultCollection : TTObject.TTChildObjectCollection<MedulaReportResult>
        {
            public ChildMedulaReportResultCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMedulaReportResultCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class MedulaRaportResultQuery_Class : TTReportNqlObject 
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

            public DateTime? SendReportDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SENDREPORTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDULAREPORTRESULT"].AllPropertyDefs["SENDREPORTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string ReportChasingNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTCHASINGNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDULAREPORTRESULT"].AllPropertyDefs["REPORTCHASINGNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ResultCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULTCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDULAREPORTRESULT"].AllPropertyDefs["RESULTCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ResultExplanation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULTEXPLANATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDULAREPORTRESULT"].AllPropertyDefs["RESULTEXPLANATION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? ReportRowNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTROWNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDULAREPORTRESULT"].AllPropertyDefs["REPORTROWNUMBER"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string ReportNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDULAREPORTRESULT"].AllPropertyDefs["REPORTNUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? StoneBreakUpRequest
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STONEBREAKUPREQUEST"]);
                }
            }

            public Guid? DialysisOrder
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DIALYSISORDER"]);
                }
            }

            public Guid? HOTOrder
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["HOTORDER"]);
                }
            }

            public Guid? Manipulation
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MANIPULATION"]);
                }
            }

            public Guid? ParticipatnFreeDrugReport
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PARTICIPATNFREEDRUGREPORT"]);
                }
            }

            public Guid? PhysiotherapyOrder
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PHYSIOTHERAPYORDER"]);
                }
            }

            public MedulaRaportResultQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public MedulaRaportResultQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected MedulaRaportResultQuery_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// Tamam
    /// </summary>
            public static Guid Completed { get { return new Guid("aef2c87f-3e58-4425-8e2c-704d41f8629c"); } }
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Canceled { get { return new Guid("9542d96f-6787-4e0c-aab7-0a40e5f5c07c"); } }
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("ab0d0be8-7275-4acd-a3bc-00596d256a18"); } }
        }

        public static BindingList<MedulaReportResult.MedulaRaportResultQuery_Class> MedulaRaportResultQuery(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDULAREPORTRESULT"].QueryDefs["MedulaRaportResultQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MedulaReportResult.MedulaRaportResultQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<MedulaReportResult.MedulaRaportResultQuery_Class> MedulaRaportResultQuery(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDULAREPORTRESULT"].QueryDefs["MedulaRaportResultQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MedulaReportResult.MedulaRaportResultQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<MedulaReportResult> GetByParticipatnFreeDrugReport(TTObjectContext objectContext, Guid PARTICIPATIONFREEDRGREP)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDULAREPORTRESULT"].QueryDefs["GetByParticipatnFreeDrugReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARTICIPATIONFREEDRGREP", PARTICIPATIONFREEDRGREP);

            return ((ITTQuery)objectContext).QueryObjects<MedulaReportResult>(queryDef, paramList);
        }

    /// <summary>
    /// Rapor Gönderim Tarihi
    /// </summary>
        public DateTime? SendReportDate
        {
            get { return (DateTime?)this["SENDREPORTDATE"]; }
            set { this["SENDREPORTDATE"] = value; }
        }

    /// <summary>
    /// Rapor Takip Nu.
    /// </summary>
        public string ReportChasingNo
        {
            get { return (string)this["REPORTCHASINGNO"]; }
            set { this["REPORTCHASINGNO"] = value; }
        }

    /// <summary>
    /// Sonuc Kodu
    /// </summary>
        public string ResultCode
        {
            get { return (string)this["RESULTCODE"]; }
            set { this["RESULTCODE"] = value; }
        }

    /// <summary>
    /// Sonuç Açıklaması
    /// </summary>
        public string ResultExplanation
        {
            get { return (string)this["RESULTEXPLANATION"]; }
            set { this["RESULTEXPLANATION"] = value; }
        }

    /// <summary>
    /// Rapor Sıra Numarası
    /// </summary>
        public int? ReportRowNumber
        {
            get { return (int?)this["REPORTROWNUMBER"]; }
            set { this["REPORTROWNUMBER"] = value; }
        }

    /// <summary>
    /// Rapor Numarası
    /// </summary>
        public string ReportNumber
        {
            get { return (string)this["REPORTNUMBER"]; }
            set { this["REPORTNUMBER"] = value; }
        }

        public StoneBreakUpRequest StoneBreakUpRequest
        {
            get { return (StoneBreakUpRequest)((ITTObject)this).GetParent("STONEBREAKUPREQUEST"); }
            set { this["STONEBREAKUPREQUEST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PhysiotherapyOrder PhysiotherapyOrder
        {
            get { return (PhysiotherapyOrder)((ITTObject)this).GetParent("PHYSIOTHERAPYORDER"); }
            set { this["PHYSIOTHERAPYORDER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public HyperbaricOxygenTreatmentOrder HOTOrder
        {
            get { return (HyperbaricOxygenTreatmentOrder)((ITTObject)this).GetParent("HOTORDER"); }
            set { this["HOTORDER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Manipulation Manipulation
        {
            get { return (Manipulation)((ITTObject)this).GetParent("MANIPULATION"); }
            set { this["MANIPULATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DialysisOrder DialysisOrder
        {
            get { return (DialysisOrder)((ITTObject)this).GetParent("DIALYSISORDER"); }
            set { this["DIALYSISORDER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ParticipatnFreeDrugReport ParticipatnFreeDrugReport
        {
            get { return (ParticipatnFreeDrugReport)((ITTObject)this).GetParent("PARTICIPATNFREEDRUGREPORT"); }
            set { this["PARTICIPATNFREEDRUGREPORT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MedulaReportResult(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MedulaReportResult(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MedulaReportResult(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MedulaReportResult(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MedulaReportResult(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MEDULAREPORTRESULT", dataRow) { }
        protected MedulaReportResult(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MEDULAREPORTRESULT", dataRow, isImported) { }
        public MedulaReportResult(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MedulaReportResult(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MedulaReportResult() : base() { }

        override protected void RunPreTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePreScript(transDef))
                base.RunPreTransition(transDef.BaseTransDef);
            this.PreTransition(transDef);
        }
        override protected void RunPostTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePostScript(transDef))
                base.RunPostTransition(transDef.BaseTransDef);
            this.PostTransition(transDef);
        }
        override protected void RunUndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBaseUndoScript(transDef))
                base.RunUndoTransition(transDef.BaseTransDef);
            this.UndoTransition(transDef);
        }
    }
}