
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AccountPeriodDefinition")] 

    public  partial class AccountPeriodDefinition : TerminologyManagerDef
    {
        public class AccountPeriodDefinitionList : TTObjectCollection<AccountPeriodDefinition> { }
                    
        public class ChildAccountPeriodDefinitionCollection : TTObject.TTChildObjectCollection<AccountPeriodDefinition>
        {
            public ChildAccountPeriodDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAccountPeriodDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetAccountPeridDefinition_Class : TTReportNqlObject 
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

            public Boolean? IsActive
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISACTIVE"]);
                    if (val == null)
                        return null;
                    return (Boolean)Convert.ChangeType(val, typeof(Boolean)); 
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

            public int? Year
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["YEAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTPERIODDEFINITION"].AllPropertyDefs["YEAR"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public MonthsEnum? Month
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MONTH"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTPERIODDEFINITION"].AllPropertyDefs["MONTH"].DataType;
                    return (MonthsEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public MonthsEnum? Monthname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MONTHNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTPERIODDEFINITION"].AllPropertyDefs["MONTH"].DataType;
                    return (MonthsEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GetAccountPeridDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAccountPeridDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAccountPeridDefinition_Class() : base() { }
        }

        [Serializable] 

        public partial class GetAccountPeriodOnlyYear_Class : TTReportNqlObject 
        {
            public int? Year
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["YEAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTPERIODDEFINITION"].AllPropertyDefs["YEAR"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public GetAccountPeriodOnlyYear_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAccountPeriodOnlyYear_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAccountPeriodOnlyYear_Class() : base() { }
        }

        public static BindingList<AccountPeriodDefinition> AccountPeriodDefinitionNQL(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTPERIODDEFINITION"].QueryDefs["AccountPeriodDefinitionNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<AccountPeriodDefinition>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<AccountPeriodDefinition.GetAccountPeridDefinition_Class> GetAccountPeridDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTPERIODDEFINITION"].QueryDefs["GetAccountPeridDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<AccountPeriodDefinition.GetAccountPeridDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<AccountPeriodDefinition.GetAccountPeridDefinition_Class> GetAccountPeridDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTPERIODDEFINITION"].QueryDefs["GetAccountPeridDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<AccountPeriodDefinition.GetAccountPeridDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<AccountPeriodDefinition.GetAccountPeriodOnlyYear_Class> GetAccountPeriodOnlyYear(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTPERIODDEFINITION"].QueryDefs["GetAccountPeriodOnlyYear"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<AccountPeriodDefinition.GetAccountPeriodOnlyYear_Class>(queryDef, paramList, pi);
        }

        public static BindingList<AccountPeriodDefinition.GetAccountPeriodOnlyYear_Class> GetAccountPeriodOnlyYear(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTPERIODDEFINITION"].QueryDefs["GetAccountPeriodOnlyYear"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<AccountPeriodDefinition.GetAccountPeriodOnlyYear_Class>(objectContext, queryDef, paramList, pi);
        }

        public int? Year
        {
            get { return (int?)this["YEAR"]; }
            set { this["YEAR"] = value; }
        }

        public MonthsEnum? Month
        {
            get { return (MonthsEnum?)(int?)this["MONTH"]; }
            set { this["MONTH"] = value; }
        }

        protected AccountPeriodDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AccountPeriodDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AccountPeriodDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AccountPeriodDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AccountPeriodDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ACCOUNTPERIODDEFINITION", dataRow) { }
        protected AccountPeriodDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ACCOUNTPERIODDEFINITION", dataRow, isImported) { }
        public AccountPeriodDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AccountPeriodDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AccountPeriodDefinition() : base() { }

    }
}