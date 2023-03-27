
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="RiskWarningLastSeenInfo")] 

    public  partial class RiskWarningLastSeenInfo : TTObject
    {
        public class RiskWarningLastSeenInfoList : TTObjectCollection<RiskWarningLastSeenInfo> { }
                    
        public class ChildRiskWarningLastSeenInfoCollection : TTObject.TTChildObjectCollection<RiskWarningLastSeenInfo>
        {
            public ChildRiskWarningLastSeenInfoCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildRiskWarningLastSeenInfoCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetRiskWarningLastSeenDate_Class : TTReportNqlObject 
        {
            public DateTime? Date
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RISKWARNINGLASTSEENINFO"].AllPropertyDefs["DATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetRiskWarningLastSeenDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetRiskWarningLastSeenDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetRiskWarningLastSeenDate_Class() : base() { }
        }

        public static BindingList<RiskWarningLastSeenInfo.GetRiskWarningLastSeenDate_Class> GetRiskWarningLastSeenDate(Guid User, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RISKWARNINGLASTSEENINFO"].QueryDefs["GetRiskWarningLastSeenDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("USER", User);

            return TTReportNqlObject.QueryObjects<RiskWarningLastSeenInfo.GetRiskWarningLastSeenDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<RiskWarningLastSeenInfo.GetRiskWarningLastSeenDate_Class> GetRiskWarningLastSeenDate(TTObjectContext objectContext, Guid User, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RISKWARNINGLASTSEENINFO"].QueryDefs["GetRiskWarningLastSeenDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("USER", User);

            return TTReportNqlObject.QueryObjects<RiskWarningLastSeenInfo.GetRiskWarningLastSeenDate_Class>(objectContext, queryDef, paramList, pi);
        }

        public DateTime? Date
        {
            get { return (DateTime?)this["DATE"]; }
            set { this["DATE"] = value; }
        }

    /// <summary>
    /// Kullanıcı
    /// </summary>
        public ResUser User
        {
            get { return (ResUser)((ITTObject)this).GetParent("USER"); }
            set { this["USER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public BaseInpatientAdmission BaseInpatientAdmission
        {
            get { return (BaseInpatientAdmission)((ITTObject)this).GetParent("BASEINPATIENTADMISSION"); }
            set { this["BASEINPATIENTADMISSION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected RiskWarningLastSeenInfo(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected RiskWarningLastSeenInfo(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected RiskWarningLastSeenInfo(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected RiskWarningLastSeenInfo(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected RiskWarningLastSeenInfo(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RISKWARNINGLASTSEENINFO", dataRow) { }
        protected RiskWarningLastSeenInfo(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RISKWARNINGLASTSEENINFO", dataRow, isImported) { }
        public RiskWarningLastSeenInfo(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public RiskWarningLastSeenInfo(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public RiskWarningLastSeenInfo() : base() { }

    }
}