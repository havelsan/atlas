
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ReceiptCashOfficeDefinition")] 

    /// <summary>
    /// Sayman Mutemetliği / Vezne Alındı Numarası Tanımlama
    /// </summary>
    public  partial class ReceiptCashOfficeDefinition : TTDefinitionSet
    {
        public class ReceiptCashOfficeDefinitionList : TTObjectCollection<ReceiptCashOfficeDefinition> { }
                    
        public class ChildReceiptCashOfficeDefinitionCollection : TTObject.TTChildObjectCollection<ReceiptCashOfficeDefinition>
        {
            public ChildReceiptCashOfficeDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildReceiptCashOfficeDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetReceiptCashOfficeDefinitions_Class : TTReportNqlObject 
        {
            public long? CreditCardEndNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CREDITCARDENDNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RECEIPTCASHOFFICEDEFINITION"].AllPropertyDefs["CREDITCARDENDNUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string CreditCardSeriesNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CREDITCARDSERIESNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RECEIPTCASHOFFICEDEFINITION"].AllPropertyDefs["CREDITCARDSERIESNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? CreditCardStartNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CREDITCARDSTARTNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RECEIPTCASHOFFICEDEFINITION"].AllPropertyDefs["CREDITCARDSTARTNUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? CurrentCreditCardNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CURRENTCREDITCARDNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RECEIPTCASHOFFICEDEFINITION"].AllPropertyDefs["CURRENTCREDITCARDNUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? CurrentReceiptNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CURRENTRECEIPTNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RECEIPTCASHOFFICEDEFINITION"].AllPropertyDefs["CURRENTRECEIPTNUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? ReceiptEndNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RECEIPTENDNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RECEIPTCASHOFFICEDEFINITION"].AllPropertyDefs["RECEIPTENDNUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string ReceiptSeriesNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RECEIPTSERIESNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RECEIPTCASHOFFICEDEFINITION"].AllPropertyDefs["RECEIPTSERIESNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? ReceiptStartNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RECEIPTSTARTNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RECEIPTCASHOFFICEDEFINITION"].AllPropertyDefs["RECEIPTSTARTNUMBER"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CASHOFFICEDEFINITION"].AllPropertyDefs["NAME"].DataType;
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

            public bool? UseDifferentNumberForCC
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USEDIFFERENTNUMBERFORCC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RECEIPTCASHOFFICEDEFINITION"].AllPropertyDefs["USEDIFFERENTNUMBERFORCC"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public long? OrderNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RECEIPTCASHOFFICEDEFINITION"].AllPropertyDefs["ORDERNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetReceiptCashOfficeDefinitions_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetReceiptCashOfficeDefinitions_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetReceiptCashOfficeDefinitions_Class() : base() { }
        }

        public static BindingList<ReceiptCashOfficeDefinition.GetReceiptCashOfficeDefinitions_Class> GetReceiptCashOfficeDefinitions(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RECEIPTCASHOFFICEDEFINITION"].QueryDefs["GetReceiptCashOfficeDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ReceiptCashOfficeDefinition.GetReceiptCashOfficeDefinitions_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ReceiptCashOfficeDefinition.GetReceiptCashOfficeDefinitions_Class> GetReceiptCashOfficeDefinitions(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RECEIPTCASHOFFICEDEFINITION"].QueryDefs["GetReceiptCashOfficeDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ReceiptCashOfficeDefinition.GetReceiptCashOfficeDefinitions_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// CashOffice param ile ReceiptCashOfficeDef döndürür.
    /// </summary>
        public static BindingList<ReceiptCashOfficeDefinition> GetByCashOffice(TTObjectContext objectContext, string PARAMCASHOFFICE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RECEIPTCASHOFFICEDEFINITION"].QueryDefs["GetByCashOffice"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMCASHOFFICE", PARAMCASHOFFICE);

            return ((ITTQuery)objectContext).QueryObjects<ReceiptCashOfficeDefinition>(queryDef, paramList);
        }

    /// <summary>
    /// Makbuz başlangıç numarası
    /// </summary>
        public long? ReceiptStartNumber
        {
            get { return (long?)this["RECEIPTSTARTNUMBER"]; }
            set { this["RECEIPTSTARTNUMBER"] = value; }
        }

    /// <summary>
    /// Kredi kartı makbuzu bitiş numarası
    /// </summary>
        public long? CreditCardEndNumber
        {
            get { return (long?)this["CREDITCARDENDNUMBER"]; }
            set { this["CREDITCARDENDNUMBER"] = value; }
        }

    /// <summary>
    /// Sıradaki kredi kartı makbuz numarası
    /// </summary>
        public long? CurrentCreditCardNumber
        {
            get { return (long?)this["CURRENTCREDITCARDNUMBER"]; }
            set { this["CURRENTCREDITCARDNUMBER"] = value; }
        }

    /// <summary>
    /// Makbuz seri numarası
    /// </summary>
        public string ReceiptSeriesNo
        {
            get { return (string)this["RECEIPTSERIESNO"]; }
            set { this["RECEIPTSERIESNO"] = value; }
        }

    /// <summary>
    /// Kredi kartı alındısı için ayrı numara takip et
    /// </summary>
        public bool? UseDifferentNumberForCC
        {
            get { return (bool?)this["USEDIFFERENTNUMBERFORCC"]; }
            set { this["USEDIFFERENTNUMBERFORCC"] = value; }
        }

    /// <summary>
    /// Makbuz bitiş numarası
    /// </summary>
        public long? ReceiptEndNumber
        {
            get { return (long?)this["RECEIPTENDNUMBER"]; }
            set { this["RECEIPTENDNUMBER"] = value; }
        }

    /// <summary>
    /// Sıradaki makbuz numarası
    /// </summary>
        public long? CurrentReceiptNumber
        {
            get { return (long?)this["CURRENTRECEIPTNUMBER"]; }
            set { this["CURRENTRECEIPTNUMBER"] = value; }
        }

    /// <summary>
    /// Kredi kartı makbuzu başlangıç numarası
    /// </summary>
        public long? CreditCardStartNumber
        {
            get { return (long?)this["CREDITCARDSTARTNUMBER"]; }
            set { this["CREDITCARDSTARTNUMBER"] = value; }
        }

    /// <summary>
    /// Kredi kartı makbuzu seri numarası
    /// </summary>
        public string CreditCardSeriesNo
        {
            get { return (string)this["CREDITCARDSERIESNO"]; }
            set { this["CREDITCARDSERIESNO"] = value; }
        }

        public TTSequence OrderNo
        {
            get { return GetSequence("ORDERNO"); }
        }

    /// <summary>
    /// Vezne ile ilişki
    /// </summary>
        public CashOfficeDefinition CashOffice
        {
            get { return (CashOfficeDefinition)((ITTObject)this).GetParent("CASHOFFICE"); }
            set { this["CASHOFFICE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateUnusedReceiptNoDefCollection()
        {
            _UnusedReceiptNoDef = new UnusedReceiptNoDefinition.ChildUnusedReceiptNoDefinitionCollection(this, new Guid("695925e1-540b-4ca5-92b6-346d35251158"));
            ((ITTChildObjectCollection)_UnusedReceiptNoDef).GetChildren();
        }

        protected UnusedReceiptNoDefinition.ChildUnusedReceiptNoDefinitionCollection _UnusedReceiptNoDef = null;
        public UnusedReceiptNoDefinition.ChildUnusedReceiptNoDefinitionCollection UnusedReceiptNoDef
        {
            get
            {
                if (_UnusedReceiptNoDef == null)
                    CreateUnusedReceiptNoDefCollection();
                return _UnusedReceiptNoDef;
            }
        }

        protected ReceiptCashOfficeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ReceiptCashOfficeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ReceiptCashOfficeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ReceiptCashOfficeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ReceiptCashOfficeDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RECEIPTCASHOFFICEDEFINITION", dataRow) { }
        protected ReceiptCashOfficeDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RECEIPTCASHOFFICEDEFINITION", dataRow, isImported) { }
        protected ReceiptCashOfficeDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ReceiptCashOfficeDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ReceiptCashOfficeDefinition() : base() { }

    }
}