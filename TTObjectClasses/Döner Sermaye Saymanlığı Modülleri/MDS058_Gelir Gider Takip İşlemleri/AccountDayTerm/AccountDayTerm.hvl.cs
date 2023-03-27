
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AccountDayTerm")] 

    public  partial class AccountDayTerm : TTObject
    {
        public class AccountDayTermList : TTObjectCollection<AccountDayTerm> { }
                    
        public class ChildAccountDayTermCollection : TTObject.TTChildObjectCollection<AccountDayTerm>
        {
            public ChildAccountDayTermCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAccountDayTermCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetAllAccountDayTerms_Class : TTReportNqlObject 
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

            public Currency? Average
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AVERAGE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDAYTERM"].AllPropertyDefs["AVERAGE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? MovableAverage
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MOVABLEAVERAGE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDAYTERM"].AllPropertyDefs["MOVABLEAVERAGE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? ProcedureAverage
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDUREAVERAGE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDAYTERM"].AllPropertyDefs["PROCEDUREAVERAGE"].DataType;
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

            public GetAllAccountDayTerms_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAllAccountDayTerms_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAllAccountDayTerms_Class() : base() { }
        }

        [Serializable] 

        public partial class GetAccountDayTermsByMonthYear_Class : TTReportNqlObject 
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

            public Currency? Average
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AVERAGE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDAYTERM"].AllPropertyDefs["AVERAGE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? MovableAverage
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MOVABLEAVERAGE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDAYTERM"].AllPropertyDefs["MOVABLEAVERAGE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? ProcedureAverage
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDUREAVERAGE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDAYTERM"].AllPropertyDefs["PROCEDUREAVERAGE"].DataType;
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

            public GetAccountDayTermsByMonthYear_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAccountDayTermsByMonthYear_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAccountDayTermsByMonthYear_Class() : base() { }
        }

        public static class States
        {
            public static Guid Completed { get { return new Guid("fcd94059-bd0b-44f8-8135-a7b9a2ef7123"); } }
            public static Guid Cancelled { get { return new Guid("7e765929-8cc9-4598-a133-01ec37f8ad47"); } }
        }

        public static BindingList<AccountDayTerm.GetAllAccountDayTerms_Class> GetAllAccountDayTerms(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDAYTERM"].QueryDefs["GetAllAccountDayTerms"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<AccountDayTerm.GetAllAccountDayTerms_Class>(queryDef, paramList, pi);
        }

        public static BindingList<AccountDayTerm.GetAllAccountDayTerms_Class> GetAllAccountDayTerms(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDAYTERM"].QueryDefs["GetAllAccountDayTerms"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<AccountDayTerm.GetAllAccountDayTerms_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<AccountDayTerm.GetAccountDayTermsByMonthYear_Class> GetAccountDayTermsByMonthYear(int Month, int Year, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDAYTERM"].QueryDefs["GetAccountDayTermsByMonthYear"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MONTH", Month);
            paramList.Add("YEAR", Year);

            return TTReportNqlObject.QueryObjects<AccountDayTerm.GetAccountDayTermsByMonthYear_Class>(queryDef, paramList, pi);
        }

        public static BindingList<AccountDayTerm.GetAccountDayTermsByMonthYear_Class> GetAccountDayTermsByMonthYear(TTObjectContext objectContext, int Month, int Year, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDAYTERM"].QueryDefs["GetAccountDayTermsByMonthYear"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MONTH", Month);
            paramList.Add("YEAR", Year);

            return TTReportNqlObject.QueryObjects<AccountDayTerm.GetAccountDayTermsByMonthYear_Class>(objectContext, queryDef, paramList, pi);
        }

        public Currency? Average
        {
            get { return (Currency?)this["AVERAGE"]; }
            set { this["AVERAGE"] = value; }
        }

        public Currency? MovableAverage
        {
            get { return (Currency?)this["MOVABLEAVERAGE"]; }
            set { this["MOVABLEAVERAGE"] = value; }
        }

        public Currency? ProcedureAverage
        {
            get { return (Currency?)this["PROCEDUREAVERAGE"]; }
            set { this["PROCEDUREAVERAGE"] = value; }
        }

    /// <summary>
    /// Dönem Bilgisi
    /// </summary>
        public AccountPeriodDefinition AccountPeriod
        {
            get { return (AccountPeriodDefinition)((ITTObject)this).GetParent("ACCOUNTPERIOD"); }
            set { this["ACCOUNTPERIOD"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected AccountDayTerm(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AccountDayTerm(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AccountDayTerm(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AccountDayTerm(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AccountDayTerm(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ACCOUNTDAYTERM", dataRow) { }
        protected AccountDayTerm(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ACCOUNTDAYTERM", dataRow, isImported) { }
        public AccountDayTerm(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AccountDayTerm(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AccountDayTerm() : base() { }

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