
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HCSummaryPrevious")] 

    public  partial class HCSummaryPrevious : TTObject
    {
        public class HCSummaryPreviousList : TTObjectCollection<HCSummaryPrevious> { }
                    
        public class ChildHCSummaryPreviousCollection : TTObject.TTChildObjectCollection<HCSummaryPrevious>
        {
            public ChildHCSummaryPreviousCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHCSummaryPreviousCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetByHealthCommittee_RQ_Class : TTReportNqlObject 
        {
            public DateTime? ReportDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HCSUMMARYPREVIOUS"].AllPropertyDefs["REPORTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string ReportNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HCSUMMARYPREVIOUS"].AllPropertyDefs["REPORTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Site
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SITE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SITES"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Reasonforexamination
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONFOREXAMINATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REASONFOREXAMINATIONDEFINITION"].AllPropertyDefs["REASON"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Decision
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DECISION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HCSUMMARYPREVIOUS"].AllPropertyDefs["DECISION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MatterSliceAnectode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATTERSLICEANECTODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HCSUMMARYPREVIOUS"].AllPropertyDefs["MATTERSLICEANECTODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Diagnosis
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIAGNOSIS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HCSUMMARYPREVIOUS"].AllPropertyDefs["DIAGNOSIS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetByHealthCommittee_RQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetByHealthCommittee_RQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetByHealthCommittee_RQ_Class() : base() { }
        }

        public static BindingList<HCSummaryPrevious.GetByHealthCommittee_RQ_Class> GetByHealthCommittee_RQ(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HCSUMMARYPREVIOUS"].QueryDefs["GetByHealthCommittee_RQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<HCSummaryPrevious.GetByHealthCommittee_RQ_Class>(queryDef, paramList, pi);
        }

        public static BindingList<HCSummaryPrevious.GetByHealthCommittee_RQ_Class> GetByHealthCommittee_RQ(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HCSUMMARYPREVIOUS"].QueryDefs["GetByHealthCommittee_RQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<HCSummaryPrevious.GetByHealthCommittee_RQ_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<HCSummaryPrevious> GetByHealthCommittee(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HCSUMMARYPREVIOUS"].QueryDefs["GetByHealthCommittee"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<HCSummaryPrevious>(queryDef, paramList);
        }

    /// <summary>
    /// Rapor No
    /// </summary>
        public string ReportNo
        {
            get { return (string)this["REPORTNO"]; }
            set { this["REPORTNO"] = value; }
        }

    /// <summary>
    /// Rapor Tarihi
    /// </summary>
        public DateTime? ReportDate
        {
            get { return (DateTime?)this["REPORTDATE"]; }
            set { this["REPORTDATE"] = value; }
        }

    /// <summary>
    /// Karar
    /// </summary>
        public string Decision
        {
            get { return (string)this["DECISION"]; }
            set { this["DECISION"] = value; }
        }

    /// <summary>
    /// Tanılar
    /// </summary>
        public string Diagnosis
        {
            get { return (string)this["DIAGNOSIS"]; }
            set { this["DIAGNOSIS"] = value; }
        }

    /// <summary>
    /// Madde Dilim Fıkra
    /// </summary>
        public string MatterSliceAnectode
        {
            get { return (string)this["MATTERSLICEANECTODE"]; }
            set { this["MATTERSLICEANECTODE"] = value; }
        }

    /// <summary>
    /// Ne Maksatla Muayene Edildiği
    /// </summary>
        public ReasonForExaminationDefinition ReasonForExamination
        {
            get { return (ReasonForExaminationDefinition)((ITTObject)this).GetParent("REASONFOREXAMINATION"); }
            set { this["REASONFOREXAMINATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Saha
    /// </summary>
        public Sites Site
        {
            get { return (Sites)((ITTObject)this).GetParent("SITE"); }
            set { this["SITE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected HCSummaryPrevious(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HCSummaryPrevious(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HCSummaryPrevious(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HCSummaryPrevious(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HCSummaryPrevious(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HCSUMMARYPREVIOUS", dataRow) { }
        protected HCSummaryPrevious(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HCSUMMARYPREVIOUS", dataRow, isImported) { }
        public HCSummaryPrevious(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HCSummaryPrevious(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HCSummaryPrevious() : base() { }

    }
}