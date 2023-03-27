
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CashOfficeDefinition")] 

    /// <summary>
    /// Sayman Mutemetliği / Vezne / Fatura Servisi Tanımı
    /// </summary>
    public  partial class CashOfficeDefinition : ResSection
    {
        public class CashOfficeDefinitionList : TTObjectCollection<CashOfficeDefinition> { }
                    
        public class ChildCashOfficeDefinitionCollection : TTObject.TTChildObjectCollection<CashOfficeDefinition>
        {
            public ChildCashOfficeDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCashOfficeDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetCashOfficeDefinitions_Class : TTReportNqlObject 
        {
            public string Qref
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QREF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CASHOFFICEDEFINITION"].AllPropertyDefs["QREF"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CASHOFFICEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public CashOfficeTypeEnum? Type
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CASHOFFICEDEFINITION"].AllPropertyDefs["TYPE"].DataType;
                    return (CashOfficeTypeEnum?)(int)dataType.ConvertValue(val);
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

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetCashOfficeDefinitions_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetCashOfficeDefinitions_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetCashOfficeDefinitions_Class() : base() { }
        }

        public static BindingList<CashOfficeDefinition.GetCashOfficeDefinitions_Class> GetCashOfficeDefinitions(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CASHOFFICEDEFINITION"].QueryDefs["GetCashOfficeDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CashOfficeDefinition.GetCashOfficeDefinitions_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<CashOfficeDefinition.GetCashOfficeDefinitions_Class> GetCashOfficeDefinitions(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CASHOFFICEDEFINITION"].QueryDefs["GetCashOfficeDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CashOfficeDefinition.GetCashOfficeDefinitions_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Kasa tipi
    /// </summary>
        public CashOfficeTypeEnum? Type
        {
            get { return (CashOfficeTypeEnum?)(int?)this["TYPE"]; }
            set { this["TYPE"] = value; }
        }

    /// <summary>
    /// Banka Hesap Numarası
    /// </summary>
        public BankAccountDefinition BankAccount
        {
            get { return (BankAccountDefinition)((ITTObject)this).GetParent("BANKACCOUNT"); }
            set { this["BANKACCOUNT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected CashOfficeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CashOfficeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CashOfficeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CashOfficeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CashOfficeDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CASHOFFICEDEFINITION", dataRow) { }
        protected CashOfficeDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CASHOFFICEDEFINITION", dataRow, isImported) { }
        protected CashOfficeDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CashOfficeDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CashOfficeDefinition() : base() { }

    }
}