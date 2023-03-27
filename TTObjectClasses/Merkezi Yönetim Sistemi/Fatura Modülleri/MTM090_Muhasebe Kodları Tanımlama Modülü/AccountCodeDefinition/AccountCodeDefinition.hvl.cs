
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AccountCodeDefinition")] 

    /// <summary>
    /// Muhasebe Kodları Tanımlama Modülü
    /// </summary>
    public  partial class AccountCodeDefinition : TerminologyManagerDef
    {
        public class AccountCodeDefinitionList : TTObjectCollection<AccountCodeDefinition> { }
                    
        public class ChildAccountCodeDefinitionCollection : TTObject.TTChildObjectCollection<AccountCodeDefinition>
        {
            public ChildAccountCodeDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAccountCodeDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetAccountCodeDefinitions_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public AccountEntegrationAccountTypeEnum? AccountType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCOUNTTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTCODEDEFINITION"].AllPropertyDefs["ACCOUNTTYPE"].DataType;
                    return (AccountEntegrationAccountTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string AccountCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCOUNTCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTCODEDEFINITION"].AllPropertyDefs["ACCOUNTCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetAccountCodeDefinitions_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAccountCodeDefinitions_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAccountCodeDefinitions_Class() : base() { }
        }

        public static BindingList<AccountCodeDefinition> GetAccountCodeDefByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTCODEDEFINITION"].QueryDefs["GetAccountCodeDefByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<AccountCodeDefinition>(queryDef, paramList);
        }

        public static BindingList<AccountCodeDefinition.GetAccountCodeDefinitions_Class> GetAccountCodeDefinitions(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTCODEDEFINITION"].QueryDefs["GetAccountCodeDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<AccountCodeDefinition.GetAccountCodeDefinitions_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<AccountCodeDefinition.GetAccountCodeDefinitions_Class> GetAccountCodeDefinitions(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTCODEDEFINITION"].QueryDefs["GetAccountCodeDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<AccountCodeDefinition.GetAccountCodeDefinitions_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<AccountCodeDefinition> GetByAccountType(TTObjectContext objectContext, AccountEntegrationAccountTypeEnum PARAMACCOUNTTYPE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTCODEDEFINITION"].QueryDefs["GetByAccountType"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMACCOUNTTYPE", (int)PARAMACCOUNTTYPE);

            return ((ITTQuery)objectContext).QueryObjects<AccountCodeDefinition>(queryDef, paramList);
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
    /// Hesap Kodu
    /// </summary>
        public string AccountCode
        {
            get { return (string)this["ACCOUNTCODE"]; }
            set { this["ACCOUNTCODE"] = value; }
        }

        protected AccountCodeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AccountCodeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AccountCodeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AccountCodeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AccountCodeDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ACCOUNTCODEDEFINITION", dataRow) { }
        protected AccountCodeDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ACCOUNTCODEDEFINITION", dataRow, isImported) { }
        protected AccountCodeDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AccountCodeDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AccountCodeDefinition() : base() { }

    }
}