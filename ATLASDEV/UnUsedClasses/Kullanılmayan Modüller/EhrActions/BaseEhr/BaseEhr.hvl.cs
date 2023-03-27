
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BaseEhr")] 

    /// <summary>
    /// EHR Base Class
    /// </summary>
    public  partial class BaseEhr : TTObject
    {
        public class BaseEhrList : TTObjectCollection<BaseEhr> { }
                    
        public class ChildBaseEhrCollection : TTObject.TTChildObjectCollection<BaseEhr>
        {
            public ChildBaseEhrCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBaseEhrCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetEHRPricesByPatient_Class : TTReportNqlObject 
        {
            public Object Islem
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ISLEM"]);
                }
            }

            public Guid? Islemo
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ISLEMO"]);
                }
            }

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EHRSUBACTIONPROCEDURE"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? Po
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PO"]);
                }
            }

            public Object Name
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["NAME"]);
                }
            }

            public Object Surname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["SURNAME"]);
                }
            }

            public Object Sitename
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["SITENAME"]);
                }
            }

            public DateTime? TransactionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TRANSACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EHRACCOUNTTRANSACTION"].AllPropertyDefs["TRANSACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public double? UnitPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNITPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EHRACCOUNTTRANSACTION"].AllPropertyDefs["UNITPRICE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public double? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EHRACCOUNTTRANSACTION"].AllPropertyDefs["AMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string Acctrxdesc
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCTRXDESC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EHRACCOUNTTRANSACTION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public ehrAccountTransactionStateEnum? State
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EHRACCOUNTTRANSACTION"].AllPropertyDefs["STATE"].DataType;
                    return (ehrAccountTransactionStateEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GetEHRPricesByPatient_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetEHRPricesByPatient_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetEHRPricesByPatient_Class() : base() { }
        }

        public static class States
        {
            public static Guid Active { get { return new Guid("b86c3e17-bf34-414c-b60c-182925abc911"); } }
            public static Guid Inactive { get { return new Guid("749387be-ff99-45ed-b18a-fb2b6a7a1190"); } }
        }

        public static BindingList<BaseEhr.GetEHRPricesByPatient_Class> GetEHRPricesByPatient(Guid PATIENT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASEEHR"].QueryDefs["GetEHRPricesByPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<BaseEhr.GetEHRPricesByPatient_Class>(queryDef, paramList, pi);
        }

        public static BindingList<BaseEhr.GetEHRPricesByPatient_Class> GetEHRPricesByPatient(TTObjectContext objectContext, Guid PATIENT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASEEHR"].QueryDefs["GetEHRPricesByPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<BaseEhr.GetEHRPricesByPatient_Class>(objectContext, queryDef, paramList, pi);
        }

        protected BaseEhr(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BaseEhr(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BaseEhr(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BaseEhr(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BaseEhr(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BASEEHR", dataRow) { }
        protected BaseEhr(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BASEEHR", dataRow, isImported) { }
        public BaseEhr(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BaseEhr(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BaseEhr() : base() { }

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