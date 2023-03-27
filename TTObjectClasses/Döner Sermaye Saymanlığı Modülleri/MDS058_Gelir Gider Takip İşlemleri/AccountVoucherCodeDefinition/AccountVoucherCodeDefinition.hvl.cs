
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AccountVoucherCodeDefinition")] 

    /// <summary>
    /// Gelir Gider hesap kodu tanımlama
    /// </summary>
    public  partial class AccountVoucherCodeDefinition : TerminologyManagerDef
    {
        public class AccountVoucherCodeDefinitionList : TTObjectCollection<AccountVoucherCodeDefinition> { }
                    
        public class ChildAccountVoucherCodeDefinitionCollection : TTObject.TTChildObjectCollection<AccountVoucherCodeDefinition>
        {
            public ChildAccountVoucherCodeDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAccountVoucherCodeDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetIsCodeBe_Class : TTReportNqlObject 
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

            public bool? IsDept
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISDEPT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTVOUCHERCODEDEFINITION"].AllPropertyDefs["ISDEPT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTVOUCHERCODEDEFINITION"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTVOUCHERCODEDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetIsCodeBe_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetIsCodeBe_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetIsCodeBe_Class() : base() { }
        }

        [Serializable] 

        public partial class GetAccountVoucher_Class : TTReportNqlObject 
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

            public bool? IsDept
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISDEPT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTVOUCHERCODEDEFINITION"].AllPropertyDefs["ISDEPT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTVOUCHERCODEDEFINITION"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTVOUCHERCODEDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetAccountVoucher_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAccountVoucher_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAccountVoucher_Class() : base() { }
        }

        public static BindingList<AccountVoucherCodeDefinition.GetIsCodeBe_Class> GetIsCodeBe(string Code, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTVOUCHERCODEDEFINITION"].QueryDefs["GetIsCodeBe"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("CODE", Code);

            return TTReportNqlObject.QueryObjects<AccountVoucherCodeDefinition.GetIsCodeBe_Class>(queryDef, paramList, pi);
        }

        public static BindingList<AccountVoucherCodeDefinition.GetIsCodeBe_Class> GetIsCodeBe(TTObjectContext objectContext, string Code, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTVOUCHERCODEDEFINITION"].QueryDefs["GetIsCodeBe"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("CODE", Code);

            return TTReportNqlObject.QueryObjects<AccountVoucherCodeDefinition.GetIsCodeBe_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<AccountVoucherCodeDefinition> GetAllAccountVouchers(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTVOUCHERCODEDEFINITION"].QueryDefs["GetAllAccountVouchers"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<AccountVoucherCodeDefinition>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<AccountVoucherCodeDefinition.GetAccountVoucher_Class> GetAccountVoucher(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTVOUCHERCODEDEFINITION"].QueryDefs["GetAccountVoucher"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<AccountVoucherCodeDefinition.GetAccountVoucher_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<AccountVoucherCodeDefinition.GetAccountVoucher_Class> GetAccountVoucher(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTVOUCHERCODEDEFINITION"].QueryDefs["GetAccountVoucher"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<AccountVoucherCodeDefinition.GetAccountVoucher_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Gelir Gider
    /// </summary>
        public bool? IsDept
        {
            get { return (bool?)this["ISDEPT"]; }
            set { this["ISDEPT"] = value; }
        }

    /// <summary>
    /// Kodu
    /// </summary>
        public string Code
        {
            get { return (string)this["CODE"]; }
            set { this["CODE"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

        protected AccountVoucherCodeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AccountVoucherCodeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AccountVoucherCodeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AccountVoucherCodeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AccountVoucherCodeDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ACCOUNTVOUCHERCODEDEFINITION", dataRow) { }
        protected AccountVoucherCodeDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ACCOUNTVOUCHERCODEDEFINITION", dataRow, isImported) { }
        public AccountVoucherCodeDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AccountVoucherCodeDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AccountVoucherCodeDefinition() : base() { }

    }
}