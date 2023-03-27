
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BankDefinition")] 

    /// <summary>
    /// Banka Tanımı
    /// </summary>
    public  partial class BankDefinition : TerminologyManagerDef
    {
        public class BankDefinitionList : TTObjectCollection<BankDefinition> { }
                    
        public class ChildBankDefinitionCollection : TTObject.TTChildObjectCollection<BankDefinition>
        {
            public ChildBankDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBankDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetBankDefinitions_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BANKDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BANKDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetBankDefinitions_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetBankDefinitions_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetBankDefinitions_Class() : base() { }
        }

        public static BindingList<BankDefinition> GetBankDefinitionByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BANKDEFINITION"].QueryDefs["GetBankDefinitionByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<BankDefinition>(queryDef, paramList);
        }

        public static BindingList<BankDefinition.GetBankDefinitions_Class> GetBankDefinitions(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BANKDEFINITION"].QueryDefs["GetBankDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<BankDefinition.GetBankDefinitions_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<BankDefinition.GetBankDefinitions_Class> GetBankDefinitions(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BANKDEFINITION"].QueryDefs["GetBankDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<BankDefinition.GetBankDefinitions_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Ad
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Kod
    /// </summary>
        public long? Code
        {
            get { return (long?)this["CODE"]; }
            set { this["CODE"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

        virtual protected void CreateBankBranchsCollection()
        {
            _BankBranchs = new BankBranchDefinition.ChildBankBranchDefinitionCollection(this, new Guid("9f0c4629-0ea7-4eee-8799-155e64c26010"));
            ((ITTChildObjectCollection)_BankBranchs).GetChildren();
        }

        protected BankBranchDefinition.ChildBankBranchDefinitionCollection _BankBranchs = null;
    /// <summary>
    /// Child collection for Banka Şube İlişkisi
    /// </summary>
        public BankBranchDefinition.ChildBankBranchDefinitionCollection BankBranchs
        {
            get
            {
                if (_BankBranchs == null)
                    CreateBankBranchsCollection();
                return _BankBranchs;
            }
        }

        protected BankDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BankDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BankDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BankDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BankDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BANKDEFINITION", dataRow) { }
        protected BankDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BANKDEFINITION", dataRow, isImported) { }
        protected BankDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BankDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BankDefinition() : base() { }

    }
}