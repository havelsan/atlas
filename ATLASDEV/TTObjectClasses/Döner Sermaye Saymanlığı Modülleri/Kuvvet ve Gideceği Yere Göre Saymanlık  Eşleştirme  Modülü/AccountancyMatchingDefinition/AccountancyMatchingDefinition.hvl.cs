
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AccountancyMatchingDefinition")] 

    public  partial class AccountancyMatchingDefinition : TTDefinitionSet
    {
        public class AccountancyMatchingDefinitionList : TTObjectCollection<AccountancyMatchingDefinition> { }
                    
        public class ChildAccountancyMatchingDefinitionCollection : TTObject.TTChildObjectCollection<AccountancyMatchingDefinition>
        {
            public ChildAccountancyMatchingDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAccountancyMatchingDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class AccountancyMatchingDefinitionNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Forcescommand
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FORCESCOMMAND"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORCESCOMMAND"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Sendtoresource
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SENDTORESOURCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Accountancy
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCOUNTANCY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTANCY"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public AccountancyMatchingDefinitionNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public AccountancyMatchingDefinitionNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected AccountancyMatchingDefinitionNQL_Class() : base() { }
        }

        public static BindingList<AccountancyMatchingDefinition> GetAccountancyMatchingDefinitionByForcesCommand(TTObjectContext objectContext, string FORCESCOMMAND)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTANCYMATCHINGDEFINITION"].QueryDefs["GetAccountancyMatchingDefinitionByForcesCommand"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FORCESCOMMAND", FORCESCOMMAND);

            return ((ITTQuery)objectContext).QueryObjects<AccountancyMatchingDefinition>(queryDef, paramList);
        }

        public static BindingList<AccountancyMatchingDefinition> GetAccountancyMatchingDefinitionByForcesCSendTo(TTObjectContext objectContext, string SENDTORESOURCE, string FORCESCOMMAND)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTANCYMATCHINGDEFINITION"].QueryDefs["GetAccountancyMatchingDefinitionByForcesCSendTo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SENDTORESOURCE", SENDTORESOURCE);
            paramList.Add("FORCESCOMMAND", FORCESCOMMAND);

            return ((ITTQuery)objectContext).QueryObjects<AccountancyMatchingDefinition>(queryDef, paramList);
        }

        public static BindingList<AccountancyMatchingDefinition.AccountancyMatchingDefinitionNQL_Class> AccountancyMatchingDefinitionNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTANCYMATCHINGDEFINITION"].QueryDefs["AccountancyMatchingDefinitionNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<AccountancyMatchingDefinition.AccountancyMatchingDefinitionNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<AccountancyMatchingDefinition.AccountancyMatchingDefinitionNQL_Class> AccountancyMatchingDefinitionNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTANCYMATCHINGDEFINITION"].QueryDefs["AccountancyMatchingDefinitionNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<AccountancyMatchingDefinition.AccountancyMatchingDefinitionNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Gideceği Yer
    /// </summary>
        public ResSection SendToResource
        {
            get { return (ResSection)((ITTObject)this).GetParent("SENDTORESOURCE"); }
            set { this["SENDTORESOURCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Saymanlık
    /// </summary>
        public Accountancy Accountancy
        {
            get { return (Accountancy)((ITTObject)this).GetParent("ACCOUNTANCY"); }
            set { this["ACCOUNTANCY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Kuvvet
    /// </summary>
        public ForcesCommand ForcesCommand
        {
            get { return (ForcesCommand)((ITTObject)this).GetParent("FORCESCOMMAND"); }
            set { this["FORCESCOMMAND"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected AccountancyMatchingDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AccountancyMatchingDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AccountancyMatchingDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AccountancyMatchingDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AccountancyMatchingDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ACCOUNTANCYMATCHINGDEFINITION", dataRow) { }
        protected AccountancyMatchingDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ACCOUNTANCYMATCHINGDEFINITION", dataRow, isImported) { }
        public AccountancyMatchingDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AccountancyMatchingDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AccountancyMatchingDefinition() : base() { }

    }
}