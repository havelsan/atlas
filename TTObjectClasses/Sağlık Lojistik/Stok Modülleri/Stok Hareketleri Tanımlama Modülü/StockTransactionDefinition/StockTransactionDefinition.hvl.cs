
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="StockTransactionDefinition")] 

    /// <summary>
    /// Stok Hareket Tipi Tanımı
    /// </summary>
    public  partial class StockTransactionDefinition : TerminologyManagerDef
    {
        public class StockTransactionDefinitionList : TTObjectCollection<StockTransactionDefinition> { }
                    
        public class ChildStockTransactionDefinitionCollection : TTObject.TTChildObjectCollection<StockTransactionDefinition>
        {
            public ChildStockTransactionDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildStockTransactionDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetStockTransactionDefinition_Class : TTReportNqlObject 
        {
            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTIONDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ShortDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SHORTDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTIONDEFINITION"].AllPropertyDefs["SHORTDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public TransactionTypeEnum? TransactionType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TRANSACTIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTIONDEFINITION"].AllPropertyDefs["TRANSACTIONTYPE"].DataType;
                    return (TransactionTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public MaintainLevelCodeEnum? MaintainLevelCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MAINTAINLEVELCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTIONDEFINITION"].AllPropertyDefs["MAINTAINLEVELCODE"].DataType;
                    return (MaintainLevelCodeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public MaintainLevelCodeEnum? DestinationMaintainLevelCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESTINATIONMAINTAINLEVELCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTIONDEFINITION"].AllPropertyDefs["DESTINATIONMAINTAINLEVELCODE"].DataType;
                    return (MaintainLevelCodeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string RegistrationPrefix
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REGISTRATIONPREFIX"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTIONDEFINITION"].AllPropertyDefs["REGISTRATIONPREFIX"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string StartDateTimeFormat
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STARTDATETIMEFORMAT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTIONDEFINITION"].AllPropertyDefs["STARTDATETIMEFORMAT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string EndDateTimeFormat
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENDDATETIMEFORMAT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTIONDEFINITION"].AllPropertyDefs["ENDDATETIMEFORMAT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsFixedAsset
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISFIXEDASSET"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTIONDEFINITION"].AllPropertyDefs["ISFIXEDASSET"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? AskForDateTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ASKFORDATETIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTIONDEFINITION"].AllPropertyDefs["ASKFORDATETIME"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetStockTransactionDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetStockTransactionDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetStockTransactionDefinition_Class() : base() { }
        }

        public static BindingList<StockTransactionDefinition> GetAllStockTransactionDefinitions(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTIONDEFINITION"].QueryDefs["GetAllStockTransactionDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<StockTransactionDefinition>(queryDef, paramList);
        }

        public static BindingList<StockTransactionDefinition.GetStockTransactionDefinition_Class> GetStockTransactionDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTIONDEFINITION"].QueryDefs["GetStockTransactionDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<StockTransactionDefinition.GetStockTransactionDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<StockTransactionDefinition.GetStockTransactionDefinition_Class> GetStockTransactionDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTIONDEFINITION"].QueryDefs["GetStockTransactionDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<StockTransactionDefinition.GetStockTransactionDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<StockTransactionDefinition> GetStockTransactionDefinitionByLastUpdate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTIONDEFINITION"].QueryDefs["GetStockTransactionDefinitionByLastUpdate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<StockTransactionDefinition>(queryDef, paramList);
        }

    /// <summary>
    /// Kısa Açıklama
    /// </summary>
        public string ShortDescription
        {
            get { return (string)this["SHORTDESCRIPTION"]; }
            set { this["SHORTDESCRIPTION"] = value; }
        }

    /// <summary>
    /// Referans Harf
    /// </summary>
        public ReferenceLetterEnum? ReferenceLetter
        {
            get { return (ReferenceLetterEnum?)(int?)this["REFERENCELETTER"]; }
            set { this["REFERENCELETTER"] = value; }
        }

    /// <summary>
    /// Hedef İşlem Kodu
    /// </summary>
        public MaintainLevelCodeEnum? DestinationMaintainLevelCode
        {
            get { return (MaintainLevelCodeEnum?)(int?)this["DESTINATIONMAINTAINLEVELCODE"]; }
            set { this["DESTINATIONMAINTAINLEVELCODE"] = value; }
        }

    /// <summary>
    /// Stokdan düşer/düşmez
    /// </summary>
        public bool? IsStockDown
        {
            get { return (bool?)this["ISSTOCKDOWN"]; }
            set { this["ISSTOCKDOWN"] = value; }
        }

    /// <summary>
    /// Ön Ek
    /// </summary>
        public string RegistrationPrefix
        {
            get { return (string)this["REGISTRATIONPREFIX"]; }
            set { this["REGISTRATIONPREFIX"] = value; }
        }

    /// <summary>
    /// Başlangıç Zaman Formatı
    /// </summary>
        public string StartDateTimeFormat
        {
            get { return (string)this["STARTDATETIMEFORMAT"]; }
            set { this["STARTDATETIMEFORMAT"] = value; }
        }

    /// <summary>
    /// Demirbaş mı?
    /// </summary>
        public bool? IsFixedAsset
        {
            get { return (bool?)this["ISFIXEDASSET"]; }
            set { this["ISFIXEDASSET"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Hareket Tipi
    /// </summary>
        public TransactionTypeEnum? TransactionType
        {
            get { return (TransactionTypeEnum?)(int?)this["TRANSACTIONTYPE"]; }
            set { this["TRANSACTIONTYPE"] = value; }
        }

    /// <summary>
    /// Tarih Sor
    /// </summary>
        public bool? AskForDateTime
        {
            get { return (bool?)this["ASKFORDATETIME"]; }
            set { this["ASKFORDATETIME"] = value; }
        }

        public string Description_Shadow
        {
            get { return (string)this["DESCRIPTION_SHADOW"]; }
        }

    /// <summary>
    /// İşlem Kodu
    /// </summary>
        public MaintainLevelCodeEnum? MaintainLevelCode
        {
            get { return (MaintainLevelCodeEnum?)(int?)this["MAINTAINLEVELCODE"]; }
            set { this["MAINTAINLEVELCODE"] = value; }
        }

    /// <summary>
    /// Saymanlık Toplam Sarf Raporunda Göster / Gösterme
    /// </summary>
        public bool? IsTotalReport
        {
            get { return (bool?)this["ISTOTALREPORT"]; }
            set { this["ISTOTALREPORT"] = value; }
        }

    /// <summary>
    /// Bitiş Zaman Formatı
    /// </summary>
        public string EndDateTimeFormat
        {
            get { return (string)this["ENDDATETIMEFORMAT"]; }
            set { this["ENDDATETIMEFORMAT"] = value; }
        }

    /// <summary>
    /// Min / Max Seviye Hesaplamada Kullanılır
    /// </summary>
        public bool? IsMinMaxLevelCalc
        {
            get { return (bool?)this["ISMINMAXLEVELCALC"]; }
            set { this["ISMINMAXLEVELCALC"] = value; }
        }

    /// <summary>
    /// Tüketim Malzeme Çıkış Raporunda Göster
    /// </summary>
        public bool? IsConsumedMaterialReport
        {
            get { return (bool?)this["ISCONSUMEDMATERIALREPORT"]; }
            set { this["ISCONSUMEDMATERIALREPORT"] = value; }
        }

    /// <summary>
    /// Çıkış Raporlarında Göster
    /// </summary>
        public bool? IsMovableTrxOutVoucher
        {
            get { return (bool?)this["ISMOVABLETRXOUTVOUCHER"]; }
            set { this["ISMOVABLETRXOUTVOUCHER"] = value; }
        }

    /// <summary>
    /// Toplam Çıkış Raporunda Göster
    /// </summary>
        public bool? IsTotalStockOutReport
        {
            get { return (bool?)this["ISTOTALSTOCKOUTREPORT"]; }
            set { this["ISTOTALSTOCKOUTREPORT"] = value; }
        }

    /// <summary>
    /// Toplam Giriş Raporunda Göster
    /// </summary>
        public bool? IsTotalStockInReport
        {
            get { return (bool?)this["ISTOTALSTOCKINREPORT"]; }
            set { this["ISTOTALSTOCKINREPORT"] = value; }
        }

        public StockLevelType ChangedStockLevelType
        {
            get { return (StockLevelType)((ITTObject)this).GetParent("CHANGEDSTOCKLEVELTYPE"); }
            set { this["CHANGEDSTOCKLEVELTYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateStockTransactionCollectedDefinitionsCollection()
        {
            _StockTransactionCollectedDefinitions = new StockTransactionCollectedDefinition.ChildStockTransactionCollectedDefinitionCollection(this, new Guid("1d6e20dc-d3df-4ee9-b655-9f20360c7038"));
            ((ITTChildObjectCollection)_StockTransactionCollectedDefinitions).GetChildren();
        }

        protected StockTransactionCollectedDefinition.ChildStockTransactionCollectedDefinitionCollection _StockTransactionCollectedDefinitions = null;
        public StockTransactionCollectedDefinition.ChildStockTransactionCollectedDefinitionCollection StockTransactionCollectedDefinitions
        {
            get
            {
                if (_StockTransactionCollectedDefinitions == null)
                    CreateStockTransactionCollectedDefinitionsCollection();
                return _StockTransactionCollectedDefinitions;
            }
        }

        protected StockTransactionDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected StockTransactionDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected StockTransactionDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected StockTransactionDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected StockTransactionDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "STOCKTRANSACTIONDEFINITION", dataRow) { }
        protected StockTransactionDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "STOCKTRANSACTIONDEFINITION", dataRow, isImported) { }
        public StockTransactionDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public StockTransactionDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public StockTransactionDefinition() : base() { }

    }
}