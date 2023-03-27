
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MainCashOfficeBackTypeDefinition")] 

    /// <summary>
    /// Vezne İade Türü Tanımı
    /// </summary>
    public  partial class MainCashOfficeBackTypeDefinition : TerminologyManagerDef
    {
        public class MainCashOfficeBackTypeDefinitionList : TTObjectCollection<MainCashOfficeBackTypeDefinition> { }
                    
        public class ChildMainCashOfficeBackTypeDefinitionCollection : TTObject.TTChildObjectCollection<MainCashOfficeBackTypeDefinition>
        {
            public ChildMainCashOfficeBackTypeDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMainCashOfficeBackTypeDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetMainCashOfficeBackTypeDefinitions_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINCASHOFFICEBACKTYPEDEFINITION"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINCASHOFFICEBACKTYPEDEFINITION"].AllPropertyDefs["NAME"].DataType;
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

            public GetMainCashOfficeBackTypeDefinitions_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMainCashOfficeBackTypeDefinitions_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMainCashOfficeBackTypeDefinitions_Class() : base() { }
        }

        public static BindingList<MainCashOfficeBackTypeDefinition.GetMainCashOfficeBackTypeDefinitions_Class> GetMainCashOfficeBackTypeDefinitions(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINCASHOFFICEBACKTYPEDEFINITION"].QueryDefs["GetMainCashOfficeBackTypeDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MainCashOfficeBackTypeDefinition.GetMainCashOfficeBackTypeDefinitions_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MainCashOfficeBackTypeDefinition.GetMainCashOfficeBackTypeDefinitions_Class> GetMainCashOfficeBackTypeDefinitions(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINCASHOFFICEBACKTYPEDEFINITION"].QueryDefs["GetMainCashOfficeBackTypeDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MainCashOfficeBackTypeDefinition.GetMainCashOfficeBackTypeDefinitions_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MainCashOfficeBackTypeDefinition> GetMainCashOffcBackTypeDefByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINCASHOFFICEBACKTYPEDEFINITION"].QueryDefs["GetMainCashOffcBackTypeDefByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<MainCashOfficeBackTypeDefinition>(queryDef, paramList);
        }

    /// <summary>
    /// Kod
    /// </summary>
        public string Code
        {
            get { return (string)this["CODE"]; }
            set { this["CODE"] = value; }
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
    /// Borç Hesap Kodu
    /// </summary>
        public string DebtAccountCode
        {
            get { return (string)this["DEBTACCOUNTCODE"]; }
            set { this["DEBTACCOUNTCODE"] = value; }
        }

    /// <summary>
    /// Alacak Hesap Kodu
    /// </summary>
        public string AccountCode
        {
            get { return (string)this["ACCOUNTCODE"]; }
            set { this["ACCOUNTCODE"] = value; }
        }

    /// <summary>
    /// Muhasebeye Hareket Gönder/Gönderme
    /// </summary>
        public bool? AccountEntegration
        {
            get { return (bool?)this["ACCOUNTENTEGRATION"]; }
            set { this["ACCOUNTENTEGRATION"] = value; }
        }

    /// <summary>
    /// Bankadan Para Transferi mi ?
    /// </summary>
        public bool? IsBankOperation
        {
            get { return (bool?)this["ISBANKOPERATION"]; }
            set { this["ISBANKOPERATION"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

        protected MainCashOfficeBackTypeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MainCashOfficeBackTypeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MainCashOfficeBackTypeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MainCashOfficeBackTypeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MainCashOfficeBackTypeDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MAINCASHOFFICEBACKTYPEDEFINITION", dataRow) { }
        protected MainCashOfficeBackTypeDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MAINCASHOFFICEBACKTYPEDEFINITION", dataRow, isImported) { }
        protected MainCashOfficeBackTypeDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MainCashOfficeBackTypeDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MainCashOfficeBackTypeDefinition() : base() { }

    }
}