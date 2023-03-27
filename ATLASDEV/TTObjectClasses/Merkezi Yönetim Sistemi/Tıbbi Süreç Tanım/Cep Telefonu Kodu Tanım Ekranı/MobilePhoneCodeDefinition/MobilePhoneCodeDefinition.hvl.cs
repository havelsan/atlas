
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MobilePhoneCodeDefinition")] 

    /// <summary>
    /// Cep Telefonu Kodu Tanımı
    /// </summary>
    public  partial class MobilePhoneCodeDefinition : TerminologyManagerDef
    {
        public class MobilePhoneCodeDefinitionList : TTObjectCollection<MobilePhoneCodeDefinition> { }
                    
        public class ChildMobilePhoneCodeDefinitionCollection : TTObject.TTChildObjectCollection<MobilePhoneCodeDefinition>
        {
            public ChildMobilePhoneCodeDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMobilePhoneCodeDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetMobilePhoneCodeDefinitions_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MOBILEPHONECODEDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string OperatorName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OPERATORNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MOBILEPHONECODEDEFINITION"].AllPropertyDefs["OPERATORNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public GetMobilePhoneCodeDefinitions_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMobilePhoneCodeDefinitions_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMobilePhoneCodeDefinitions_Class() : base() { }
        }

        public static BindingList<MobilePhoneCodeDefinition.GetMobilePhoneCodeDefinitions_Class> GetMobilePhoneCodeDefinitions(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MOBILEPHONECODEDEFINITION"].QueryDefs["GetMobilePhoneCodeDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MobilePhoneCodeDefinition.GetMobilePhoneCodeDefinitions_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MobilePhoneCodeDefinition.GetMobilePhoneCodeDefinitions_Class> GetMobilePhoneCodeDefinitions(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MOBILEPHONECODEDEFINITION"].QueryDefs["GetMobilePhoneCodeDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MobilePhoneCodeDefinition.GetMobilePhoneCodeDefinitions_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MobilePhoneCodeDefinition> MobilePhoneCodeDefByCode(TTObjectContext objectContext, string CODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MOBILEPHONECODEDEFINITION"].QueryDefs["MobilePhoneCodeDefByCode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("CODE", CODE);

            return ((ITTQuery)objectContext).QueryObjects<MobilePhoneCodeDefinition>(queryDef, paramList);
        }

    /// <summary>
    /// Cep Telefonu Kodu
    /// </summary>
        public string Code
        {
            get { return (string)this["CODE"]; }
            set { this["CODE"] = value; }
        }

    /// <summary>
    /// Operatör Adı
    /// </summary>
        public string OperatorName
        {
            get { return (string)this["OPERATORNAME"]; }
            set { this["OPERATORNAME"] = value; }
        }

        protected MobilePhoneCodeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MobilePhoneCodeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MobilePhoneCodeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MobilePhoneCodeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MobilePhoneCodeDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MOBILEPHONECODEDEFINITION", dataRow) { }
        protected MobilePhoneCodeDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MOBILEPHONECODEDEFINITION", dataRow, isImported) { }
        public MobilePhoneCodeDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MobilePhoneCodeDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MobilePhoneCodeDefinition() : base() { }

    }
}