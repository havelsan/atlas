
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="RevenueSubAccountCodeDefinition")] 

    /// <summary>
    /// Muhasebe Satış Hesabı Kırınım Tanımlama Modülü
    /// </summary>
    public  partial class RevenueSubAccountCodeDefinition : TerminologyManagerDef
    {
        public class RevenueSubAccountCodeDefinitionList : TTObjectCollection<RevenueSubAccountCodeDefinition> { }
                    
        public class ChildRevenueSubAccountCodeDefinitionCollection : TTObject.TTChildObjectCollection<RevenueSubAccountCodeDefinition>
        {
            public ChildRevenueSubAccountCodeDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildRevenueSubAccountCodeDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetRevenueSubAccountCodeDefinitions_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string AccountCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCOUNTCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REVENUESUBACCOUNTCODEDEFINITION"].AllPropertyDefs["ACCOUNTCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REVENUESUBACCOUNTCODEDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Masteraccount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MASTERACCOUNT"]);
                }
            }

            public Object Relatedaccount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["RELATEDACCOUNT"]);
                }
            }

            public RevenueSubAccountTypeEnum? SubAccountType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUBACCOUNTTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REVENUESUBACCOUNTCODEDEFINITION"].AllPropertyDefs["SUBACCOUNTTYPE"].DataType;
                    return (RevenueSubAccountTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public AccountEntegrationAccountTypeEnum? AccountType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCOUNTTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REVENUESUBACCOUNTCODEDEFINITION"].AllPropertyDefs["ACCOUNTTYPE"].DataType;
                    return (AccountEntegrationAccountTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GetRevenueSubAccountCodeDefinitions_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetRevenueSubAccountCodeDefinitions_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetRevenueSubAccountCodeDefinitions_Class() : base() { }
        }

        public static BindingList<RevenueSubAccountCodeDefinition.GetRevenueSubAccountCodeDefinitions_Class> GetRevenueSubAccountCodeDefinitions(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REVENUESUBACCOUNTCODEDEFINITION"].QueryDefs["GetRevenueSubAccountCodeDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<RevenueSubAccountCodeDefinition.GetRevenueSubAccountCodeDefinitions_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<RevenueSubAccountCodeDefinition.GetRevenueSubAccountCodeDefinitions_Class> GetRevenueSubAccountCodeDefinitions(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REVENUESUBACCOUNTCODEDEFINITION"].QueryDefs["GetRevenueSubAccountCodeDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<RevenueSubAccountCodeDefinition.GetRevenueSubAccountCodeDefinitions_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<RevenueSubAccountCodeDefinition> GetRevenueSubAccountCodeDefByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REVENUESUBACCOUNTCODEDEFINITION"].QueryDefs["GetRevenueSubAccountCodeDefByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<RevenueSubAccountCodeDefinition>(queryDef, paramList);
        }

    /// <summary>
    /// Hesap Kodu
    /// </summary>
        public string AccountCode
        {
            get { return (string)this["ACCOUNTCODE"]; }
            set { this["ACCOUNTCODE"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

        public string Description_Shadow
        {
            get { return (string)this["DESCRIPTION_SHADOW"]; }
        }

    /// <summary>
    /// Hesap Tipi
    /// </summary>
        public AccountEntegrationAccountTypeEnum? AccountType
        {
            get { return (AccountEntegrationAccountTypeEnum?)(int?)this["ACCOUNTTYPE"]; }
            set { this["ACCOUNTTYPE"] = value; }
        }

    /// <summary>
    /// Tip
    /// </summary>
        public RevenueSubAccountTypeEnum? SubAccountType
        {
            get { return (RevenueSubAccountTypeEnum?)(int?)this["SUBACCOUNTTYPE"]; }
            set { this["SUBACCOUNTTYPE"] = value; }
        }

    /// <summary>
    /// Bağlı Hesap Kodu
    /// </summary>
        public RevenueSubAccountCodeDefinition MasterRevenueSubAccount
        {
            get { return (RevenueSubAccountCodeDefinition)((ITTObject)this).GetParent("MASTERREVENUESUBACCOUNT"); }
            set { this["MASTERREVENUESUBACCOUNT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İlişkili Hesap Kodu
    /// </summary>
        public RevenueSubAccountCodeDefinition RelatedRevenueSubAccount
        {
            get { return (RevenueSubAccountCodeDefinition)((ITTObject)this).GetParent("RELATEDREVENUESUBACCOUNT"); }
            set { this["RELATEDREVENUESUBACCOUNT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected RevenueSubAccountCodeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected RevenueSubAccountCodeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected RevenueSubAccountCodeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected RevenueSubAccountCodeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected RevenueSubAccountCodeDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "REVENUESUBACCOUNTCODEDEFINITION", dataRow) { }
        protected RevenueSubAccountCodeDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "REVENUESUBACCOUNTCODEDEFINITION", dataRow, isImported) { }
        protected RevenueSubAccountCodeDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public RevenueSubAccountCodeDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public RevenueSubAccountCodeDefinition() : base() { }

    }
}