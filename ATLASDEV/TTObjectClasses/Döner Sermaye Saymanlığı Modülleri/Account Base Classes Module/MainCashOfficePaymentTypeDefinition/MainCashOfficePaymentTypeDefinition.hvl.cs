
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MainCashOfficePaymentTypeDefinition")] 

    /// <summary>
    /// Vezne Tahsilat Türü Tanımı
    /// </summary>
    public  partial class MainCashOfficePaymentTypeDefinition : TerminologyManagerDef
    {
        public class MainCashOfficePaymentTypeDefinitionList : TTObjectCollection<MainCashOfficePaymentTypeDefinition> { }
                    
        public class ChildMainCashOfficePaymentTypeDefinitionCollection : TTObject.TTChildObjectCollection<MainCashOfficePaymentTypeDefinition>
        {
            public ChildMainCashOfficePaymentTypeDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMainCashOfficePaymentTypeDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetMainCashOfficePaymentTypeDefinitions_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINCASHOFFICEPAYMENTTYPEDEFINITION"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINCASHOFFICEPAYMENTTYPEDEFINITION"].AllPropertyDefs["NAME"].DataType;
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

            public GetMainCashOfficePaymentTypeDefinitions_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMainCashOfficePaymentTypeDefinitions_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMainCashOfficePaymentTypeDefinitions_Class() : base() { }
        }

        public static BindingList<MainCashOfficePaymentTypeDefinition.GetMainCashOfficePaymentTypeDefinitions_Class> GetMainCashOfficePaymentTypeDefinitions(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINCASHOFFICEPAYMENTTYPEDEFINITION"].QueryDefs["GetMainCashOfficePaymentTypeDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MainCashOfficePaymentTypeDefinition.GetMainCashOfficePaymentTypeDefinitions_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MainCashOfficePaymentTypeDefinition.GetMainCashOfficePaymentTypeDefinitions_Class> GetMainCashOfficePaymentTypeDefinitions(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINCASHOFFICEPAYMENTTYPEDEFINITION"].QueryDefs["GetMainCashOfficePaymentTypeDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MainCashOfficePaymentTypeDefinition.GetMainCashOfficePaymentTypeDefinitions_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MainCashOfficePaymentTypeDefinition> GetMainCashOffcPaymntTypDefByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINCASHOFFICEPAYMENTTYPEDEFINITION"].QueryDefs["GetMainCashOffcPaymntTypDefByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<MainCashOfficePaymentTypeDefinition>(queryDef, paramList);
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
        public string Code
        {
            get { return (string)this["CODE"]; }
            set { this["CODE"] = value; }
        }

    /// <summary>
    /// Muhasebe Mutemedi Yetkilisi Para Teslimatı mı ?
    /// </summary>
        public bool? IsSubCashOfficePayment
        {
            get { return (bool?)this["ISSUBCASHOFFICEPAYMENT"]; }
            set { this["ISSUBCASHOFFICEPAYMENT"] = value; }
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

    /// <summary>
    /// Muhasebe Yetkilisi Mutemedi de Yapabilir
    /// </summary>
        public bool? SubCashierCanDo
        {
            get { return (bool?)this["SUBCASHIERCANDO"]; }
            set { this["SUBCASHIERCANDO"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

    /// <summary>
    /// Menkul Kıymetler Alındısı tipinde mi ?
    /// </summary>
        public bool? IsChattel
        {
            get { return (bool?)this["ISCHATTEL"]; }
            set { this["ISCHATTEL"] = value; }
        }

    /// <summary>
    /// Muhasebe Gelir Hesap Kırınımı ile ilişki
    /// </summary>
        public RevenueSubAccountCodeDefinition RevenueSubAccountCode
        {
            get { return (RevenueSubAccountCodeDefinition)((ITTObject)this).GetParent("REVENUESUBACCOUNTCODE"); }
            set { this["REVENUESUBACCOUNTCODE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MainCashOfficePaymentTypeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MainCashOfficePaymentTypeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MainCashOfficePaymentTypeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MainCashOfficePaymentTypeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MainCashOfficePaymentTypeDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MAINCASHOFFICEPAYMENTTYPEDEFINITION", dataRow) { }
        protected MainCashOfficePaymentTypeDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MAINCASHOFFICEPAYMENTTYPEDEFINITION", dataRow, isImported) { }
        protected MainCashOfficePaymentTypeDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MainCashOfficePaymentTypeDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MainCashOfficePaymentTypeDefinition() : base() { }

    }
}