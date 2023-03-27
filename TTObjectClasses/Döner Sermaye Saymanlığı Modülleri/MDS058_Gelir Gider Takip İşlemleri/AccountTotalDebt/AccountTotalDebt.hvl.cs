
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AccountTotalDebt")] 

    public  partial class AccountTotalDebt : TTObject
    {
        public class AccountTotalDebtList : TTObjectCollection<AccountTotalDebt> { }
                    
        public class ChildAccountTotalDebtCollection : TTObject.TTChildObjectCollection<AccountTotalDebt>
        {
            public ChildAccountTotalDebtCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAccountTotalDebtCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetAllAccountTotalDebts_Class : TTReportNqlObject 
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

            public Currency? TotalDebt
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALDEBT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTOTALDEBT"].AllPropertyDefs["TOTALDEBT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
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

            public GetAllAccountTotalDebts_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAllAccountTotalDebts_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAllAccountTotalDebts_Class() : base() { }
        }

        [Serializable] 

        public partial class GetAccountTotalDebtsByMonthYear_Class : TTReportNqlObject 
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

            public Currency? TotalDebt
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALDEBT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTOTALDEBT"].AllPropertyDefs["TOTALDEBT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
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

            public GetAccountTotalDebtsByMonthYear_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAccountTotalDebtsByMonthYear_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAccountTotalDebtsByMonthYear_Class() : base() { }
        }

        public static class States
        {
            public static Guid Completed { get { return new Guid("108ae45e-f3dd-4610-bb3f-917a671f82c2"); } }
            public static Guid Cancelled { get { return new Guid("2a99158f-db64-4c63-bedb-be252cc63162"); } }
        }

        public static BindingList<AccountTotalDebt.GetAllAccountTotalDebts_Class> GetAllAccountTotalDebts(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTOTALDEBT"].QueryDefs["GetAllAccountTotalDebts"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<AccountTotalDebt.GetAllAccountTotalDebts_Class>(queryDef, paramList, pi);
        }

        public static BindingList<AccountTotalDebt.GetAllAccountTotalDebts_Class> GetAllAccountTotalDebts(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTOTALDEBT"].QueryDefs["GetAllAccountTotalDebts"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<AccountTotalDebt.GetAllAccountTotalDebts_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<AccountTotalDebt.GetAccountTotalDebtsByMonthYear_Class> GetAccountTotalDebtsByMonthYear(int Month, int Year, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTOTALDEBT"].QueryDefs["GetAccountTotalDebtsByMonthYear"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MONTH", Month);
            paramList.Add("YEAR", Year);

            return TTReportNqlObject.QueryObjects<AccountTotalDebt.GetAccountTotalDebtsByMonthYear_Class>(queryDef, paramList, pi);
        }

        public static BindingList<AccountTotalDebt.GetAccountTotalDebtsByMonthYear_Class> GetAccountTotalDebtsByMonthYear(TTObjectContext objectContext, int Month, int Year, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTOTALDEBT"].QueryDefs["GetAccountTotalDebtsByMonthYear"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MONTH", Month);
            paramList.Add("YEAR", Year);

            return TTReportNqlObject.QueryObjects<AccountTotalDebt.GetAccountTotalDebtsByMonthYear_Class>(objectContext, queryDef, paramList, pi);
        }

        public Currency? TotalDebt
        {
            get { return (Currency?)this["TOTALDEBT"]; }
            set { this["TOTALDEBT"] = value; }
        }

    /// <summary>
    /// Dönem Bilgisi
    /// </summary>
        public AccountPeriodDefinition AccountPeriod
        {
            get { return (AccountPeriodDefinition)((ITTObject)this).GetParent("ACCOUNTPERIOD"); }
            set { this["ACCOUNTPERIOD"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected AccountTotalDebt(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AccountTotalDebt(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AccountTotalDebt(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AccountTotalDebt(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AccountTotalDebt(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ACCOUNTTOTALDEBT", dataRow) { }
        protected AccountTotalDebt(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ACCOUNTTOTALDEBT", dataRow, isImported) { }
        public AccountTotalDebt(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AccountTotalDebt(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AccountTotalDebt() : base() { }

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