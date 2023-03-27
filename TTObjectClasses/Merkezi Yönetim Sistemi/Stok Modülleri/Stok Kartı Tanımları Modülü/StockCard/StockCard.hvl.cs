
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="StockCard")] 

    /// <summary>
    /// Stok Kart Tanımları
    /// </summary>
    public  partial class StockCard : TerminologyManagerDef
    {
        public class StockCardList : TTObjectCollection<StockCard> { }
                    
        public class ChildStockCardCollection : TTObject.TTChildObjectCollection<StockCard>
        {
            public ChildStockCardCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildStockCardCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetStockCardForGuideCard_Class : TTReportNqlObject 
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

            public bool? RepairCheckbox
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPAIRCHECKBOX"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["REPAIRCHECKBOX"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public long? CardOrderNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CARDORDERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["CARDORDERNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? CreationDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CREATIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["CREATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string EnglishName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENGLISHNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["ENGLISHNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public StockCardStatusEnum? Status
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["STATUS"].DataType;
                    return (StockCardStatusEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public long? CardAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CARDAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["CARDAMOUNT"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["DESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object CardPicture
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CARDPICTURE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["CARDPICTURE"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public bool? ProductionCheckbox
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRODUCTIONCHECKBOX"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["PRODUCTIONCHECKBOX"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string NATOStockNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NATOSTOCKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NATOSTOCKNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ETKMDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ETKMDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["ETKMDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string OffereeName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OFFEREENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["OFFEREENAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public StockMethodEnum? StockMethod
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STOCKMETHOD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["STOCKMETHOD"].DataType;
                    return (StockMethodEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? MainStoreCheckbox
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MAINSTORECHECKBOX"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["MAINSTORECHECKBOX"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Name_Shadow
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME_SHADOW"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NAME_SHADOW"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string NATOStockNO_Shadow
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NATOSTOCKNO_SHADOW"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NATOSTOCKNO_SHADOW"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? AllowLevelUpdateInSubStores
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ALLOWLEVELUPDATEINSUBSTORES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["ALLOWLEVELUPDATEINSUBSTORES"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public GetStockCardForGuideCard_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetStockCardForGuideCard_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetStockCardForGuideCard_Class() : base() { }
        }

        [Serializable] 

        public partial class UndefinedStockCardForStore_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? CardOrderNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CARDORDERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["CARDORDERNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string NATOStockNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NATOSTOCKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NATOSTOCKNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Stockcardclassname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STOCKCARDCLASSNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARDCLASS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? DistributionType
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DISTRIBUTIONTYPE"]);
                }
            }

            public StockCardStatusEnum? Status
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["STATUS"].DataType;
                    return (StockCardStatusEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public UndefinedStockCardForStore_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public UndefinedStockCardForStore_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected UndefinedStockCardForStore_Class() : base() { }
        }

        [Serializable] 

        public partial class DoubleZeroCardQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? CardOrderNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CARDORDERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["CARDORDERNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string NATOStockNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NATOSTOCKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NATOSTOCKNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public StockCardStatusEnum? Status
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["STATUS"].DataType;
                    return (StockCardStatusEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public Guid? StockCardClass
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKCARDCLASS"]);
                }
            }

            public string Stockcardclasscode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STOCKCARDCLASSCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARDCLASS"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Stockcardclassname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STOCKCARDCLASSNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARDCLASS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ParentStockCardClass
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PARENTSTOCKCARDCLASS"]);
                }
            }

            public string Parentcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PARENTCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARDCLASS"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Parentname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PARENTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARDCLASS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DoubleZeroCardQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public DoubleZeroCardQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected DoubleZeroCardQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_StockCard_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string NATOStockNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NATOSTOCKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NATOSTOCKNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Distid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DISTID"]);
                }
            }

            public string Distname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONTYPEDEFINITION"].AllPropertyDefs["DISTRIBUTIONTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? CardOrderNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CARDORDERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["CARDORDERNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? CardAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CARDAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["CARDAMOUNT"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Guid? StockCardClass
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKCARDCLASS"]);
                }
            }

            public OLAP_StockCard_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_StockCard_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_StockCard_Class() : base() { }
        }

        [Serializable] 

        public partial class GetStockCard_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
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

            public long? CardOrderNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CARDORDERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["CARDORDERNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string NATOStockNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NATOSTOCKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NATOSTOCKNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string EnglishName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENGLISHNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["ENGLISHNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public StockCardStatusEnum? Status
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["STATUS"].DataType;
                    return (StockCardStatusEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public DateTime? CreationDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CREATIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["CREATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? CardAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CARDAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["CARDAMOUNT"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Stockcardclassname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STOCKCARDCLASSNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARDCLASS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DistributionType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISTRIBUTIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONTYPEDEFINITION"].AllPropertyDefs["DISTRIBUTIONTYPE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Carddrawername
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CARDDRAWERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCARDDRAWER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public StockMethodEnum? StockMethod
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STOCKMETHOD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["STOCKMETHOD"].DataType;
                    return (StockMethodEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GetStockCard_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetStockCard_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetStockCard_Class() : base() { }
        }

        [Serializable] 

        public partial class GetStockCardInfoQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string NATOStockNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NATOSTOCKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NATOSTOCKNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Stockcardname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STOCKCARDNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Mainclassname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MAINCLASSNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARDCLASS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Classname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CLASSNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARDCLASS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DistributionType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISTRIBUTIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONTYPEDEFINITION"].AllPropertyDefs["DISTRIBUTIONTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Oldorderno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLDORDERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["CARDORDERNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public StockCardStatusEnum? Status
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["STATUS"].DataType;
                    return (StockCardStatusEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GetStockCardInfoQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetStockCardInfoQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetStockCardInfoQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetStockCardPreReportQuery_Class : TTReportNqlObject 
        {
            public DateTime? TransactionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TRANSACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].AllPropertyDefs["TRANSACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Currency? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].AllPropertyDefs["AMOUNT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public string RegistrationNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REGISTRATIONNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["REGISTRATIONNUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Stockaction
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKACTION"]);
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

            public string Store
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STORE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STORE"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public TransactionTypeEnum? InOut
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INOUT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].AllPropertyDefs["INOUT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].AllPropertyDefs["MAINTAINLEVELCODE"].DataType;
                    return (MaintainLevelCodeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public StockLevelTypeEnum? StockLevelTypeStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STOCKLEVELTYPESTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKLEVELTYPE"].AllPropertyDefs["STOCKLEVELTYPESTATUS"].DataType;
                    return (StockLevelTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public Currency? Inheld
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INHELD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCENSUSDETAIL"].AllPropertyDefs["INHELD"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? Used
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCENSUSDETAIL"].AllPropertyDefs["USED"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? Consigned
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CONSIGNED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCENSUSDETAIL"].AllPropertyDefs["CONSIGNED"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public bool? IsFirstTerm
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISFIRSTTERM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTINGTERM"].AllPropertyDefs["ISFIRSTTERM"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public Guid? AccountingTerm
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ACCOUNTINGTERM"]);
                }
            }

            public GetStockCardPreReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetStockCardPreReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetStockCardPreReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_Stockcard_WithDate_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string NATOStockNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NATOSTOCKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NATOSTOCKNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Distid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DISTID"]);
                }
            }

            public string Distname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONTYPEDEFINITION"].AllPropertyDefs["DISTRIBUTIONTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? CardOrderNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CARDORDERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["CARDORDERNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? CardAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CARDAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["CARDAMOUNT"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Guid? StockCardClass
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKCARDCLASS"]);
                }
            }

            public OLAP_Stockcard_WithDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_Stockcard_WithDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_Stockcard_WithDate_Class() : base() { }
        }

        [Serializable] 

        public partial class GetStockCardNSNObjectID_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string NATOStockNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NATOSTOCKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NATOSTOCKNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetStockCardNSNObjectID_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetStockCardNSNObjectID_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetStockCardNSNObjectID_Class() : base() { }
        }

        [Serializable] 

        public partial class GetStockCardStock_Class : TTReportNqlObject 
        {
            public Object Sumofinheld
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["SUMOFINHELD"]);
                }
            }

            public Object Sumofconsigned
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["SUMOFCONSIGNED"]);
                }
            }

            public GetStockCardStock_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetStockCardStock_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetStockCardStock_Class() : base() { }
        }

        [Serializable] 

        public partial class GetOldOrderNoQuery_Class : TTReportNqlObject 
        {
            public long? CardOrderNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CARDORDERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCENSUSDETAIL"].AllPropertyDefs["CARDORDERNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public GetOldOrderNoQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOldOrderNoQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOldOrderNoQuery_Class() : base() { }
        }

        public static BindingList<StockCard.GetStockCardForGuideCard_Class> GetStockCardForGuideCard(string GUIDEOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].QueryDefs["GetStockCardForGuideCard"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("GUIDEOBJECTID", GUIDEOBJECTID);

            return TTReportNqlObject.QueryObjects<StockCard.GetStockCardForGuideCard_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockCard.GetStockCardForGuideCard_Class> GetStockCardForGuideCard(TTObjectContext objectContext, string GUIDEOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].QueryDefs["GetStockCardForGuideCard"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("GUIDEOBJECTID", GUIDEOBJECTID);

            return TTReportNqlObject.QueryObjects<StockCard.GetStockCardForGuideCard_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockCard.UndefinedStockCardForStore_Class> UndefinedStockCardForStore(string STOREID, string STOCKCARDCLASSOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].QueryDefs["UndefinedStockCardForStore"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);
            paramList.Add("STOCKCARDCLASSOBJECTID", STOCKCARDCLASSOBJECTID);

            return TTReportNqlObject.QueryObjects<StockCard.UndefinedStockCardForStore_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockCard.UndefinedStockCardForStore_Class> UndefinedStockCardForStore(TTObjectContext objectContext, string STOREID, string STOCKCARDCLASSOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].QueryDefs["UndefinedStockCardForStore"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);
            paramList.Add("STOCKCARDCLASSOBJECTID", STOCKCARDCLASSOBJECTID);

            return TTReportNqlObject.QueryObjects<StockCard.UndefinedStockCardForStore_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockCard.DoubleZeroCardQuery_Class> DoubleZeroCardQuery(string PARENTID, int DEFAULTYEAR, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].QueryDefs["DoubleZeroCardQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARENTID", PARENTID);
            paramList.Add("DEFAULTYEAR", DEFAULTYEAR);

            return TTReportNqlObject.QueryObjects<StockCard.DoubleZeroCardQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockCard.DoubleZeroCardQuery_Class> DoubleZeroCardQuery(TTObjectContext objectContext, string PARENTID, int DEFAULTYEAR, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].QueryDefs["DoubleZeroCardQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARENTID", PARENTID);
            paramList.Add("DEFAULTYEAR", DEFAULTYEAR);

            return TTReportNqlObject.QueryObjects<StockCard.DoubleZeroCardQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockCard> GetComposeMaterials(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].QueryDefs["GetComposeMaterials"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<StockCard>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<StockCard> GetStockCardByStockCardClass(TTObjectContext objectContext, IList<string> CLASSES)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].QueryDefs["GetStockCardByStockCardClass"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("CLASSES", CLASSES);

            return ((ITTQuery)objectContext).QueryObjects<StockCard>(queryDef, paramList);
        }

        public static BindingList<StockCard> GetStockCardInfo(TTObjectContext objectContext, string OBJECTID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].QueryDefs["GetStockCardInfo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return ((ITTQuery)objectContext).QueryObjects<StockCard>(queryDef, paramList);
        }

        public static BindingList<StockCard.OLAP_StockCard_Class> OLAP_StockCard(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].QueryDefs["OLAP_StockCard"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<StockCard.OLAP_StockCard_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockCard.OLAP_StockCard_Class> OLAP_StockCard(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].QueryDefs["OLAP_StockCard"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<StockCard.OLAP_StockCard_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockCard.GetStockCard_Class> GetStockCard(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].QueryDefs["GetStockCard"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<StockCard.GetStockCard_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<StockCard.GetStockCard_Class> GetStockCard(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].QueryDefs["GetStockCard"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<StockCard.GetStockCard_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<StockCard.GetStockCardInfoQuery_Class> GetStockCardInfoQuery(Guid STOCKCARDID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].QueryDefs["GetStockCardInfoQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKCARDID", STOCKCARDID);

            return TTReportNqlObject.QueryObjects<StockCard.GetStockCardInfoQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockCard.GetStockCardInfoQuery_Class> GetStockCardInfoQuery(TTObjectContext objectContext, Guid STOCKCARDID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].QueryDefs["GetStockCardInfoQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKCARDID", STOCKCARDID);

            return TTReportNqlObject.QueryObjects<StockCard.GetStockCardInfoQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockCard.GetStockCardPreReportQuery_Class> GetStockCardPreReportQuery(Guid STOCKCARDID, Guid STOREID, Guid TERMID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].QueryDefs["GetStockCardPreReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKCARDID", STOCKCARDID);
            paramList.Add("STOREID", STOREID);
            paramList.Add("TERMID", TERMID);

            return TTReportNqlObject.QueryObjects<StockCard.GetStockCardPreReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockCard.GetStockCardPreReportQuery_Class> GetStockCardPreReportQuery(TTObjectContext objectContext, Guid STOCKCARDID, Guid STOREID, Guid TERMID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].QueryDefs["GetStockCardPreReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKCARDID", STOCKCARDID);
            paramList.Add("STOREID", STOREID);
            paramList.Add("TERMID", TERMID);

            return TTReportNqlObject.QueryObjects<StockCard.GetStockCardPreReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockCard> GetStockCardByNATOStockNo(TTObjectContext objectContext, string NATOSTOCKNO)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].QueryDefs["GetStockCardByNATOStockNo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("NATOSTOCKNO", NATOSTOCKNO);

            return ((ITTQuery)objectContext).QueryObjects<StockCard>(queryDef, paramList);
        }

        public static BindingList<StockCard> GetStockCardDefinitionByLastUpdate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].QueryDefs["GetStockCardDefinitionByLastUpdate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<StockCard>(queryDef, paramList);
        }

        public static BindingList<StockCard.OLAP_Stockcard_WithDate_Class> OLAP_Stockcard_WithDate(DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].QueryDefs["OLAP_Stockcard_WithDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<StockCard.OLAP_Stockcard_WithDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockCard.OLAP_Stockcard_WithDate_Class> OLAP_Stockcard_WithDate(TTObjectContext objectContext, DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].QueryDefs["OLAP_Stockcard_WithDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<StockCard.OLAP_Stockcard_WithDate_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockCard.GetStockCardNSNObjectID_Class> GetStockCardNSNObjectID(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].QueryDefs["GetStockCardNSNObjectID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<StockCard.GetStockCardNSNObjectID_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockCard.GetStockCardNSNObjectID_Class> GetStockCardNSNObjectID(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].QueryDefs["GetStockCardNSNObjectID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<StockCard.GetStockCardNSNObjectID_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockCard.GetStockCardStock_Class> GetStockCardStock(Guid STOCKCARD, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].QueryDefs["GetStockCardStock"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKCARD", STOCKCARD);

            return TTReportNqlObject.QueryObjects<StockCard.GetStockCardStock_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockCard.GetStockCardStock_Class> GetStockCardStock(TTObjectContext objectContext, Guid STOCKCARD, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].QueryDefs["GetStockCardStock"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKCARD", STOCKCARD);

            return TTReportNqlObject.QueryObjects<StockCard.GetStockCardStock_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockCard.GetOldOrderNoQuery_Class> GetOldOrderNoQuery(Guid STOCKCARDID, Guid STOREID, Guid TERMID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].QueryDefs["GetOldOrderNoQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKCARDID", STOCKCARDID);
            paramList.Add("STOREID", STOREID);
            paramList.Add("TERMID", TERMID);

            return TTReportNqlObject.QueryObjects<StockCard.GetOldOrderNoQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockCard.GetOldOrderNoQuery_Class> GetOldOrderNoQuery(TTObjectContext objectContext, Guid STOCKCARDID, Guid STOREID, Guid TERMID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].QueryDefs["GetOldOrderNoQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKCARDID", STOCKCARDID);
            paramList.Add("STOREID", STOREID);
            paramList.Add("TERMID", TERMID);

            return TTReportNqlObject.QueryObjects<StockCard.GetOldOrderNoQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockCard> GetStockCardForZeroCensus(TTObjectContext objectContext, string CARDDRAWER, string STORE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].QueryDefs["GetStockCardForZeroCensus"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("CARDDRAWER", CARDDRAWER);
            paramList.Add("STORE", STORE);

            return ((ITTQuery)objectContext).QueryObjects<StockCard>(queryDef, paramList);
        }

        public bool? RepairCheckbox
        {
            get { return (bool?)this["REPAIRCHECKBOX"]; }
            set { this["REPAIRCHECKBOX"] = value; }
        }

    /// <summary>
    /// Sıra Nu.
    /// </summary>
        public long? CardOrderNO
        {
            get { return (long?)this["CARDORDERNO"]; }
            set { this["CARDORDERNO"] = value; }
        }

    /// <summary>
    /// Açılış Tarihi
    /// </summary>
        public DateTime? CreationDate
        {
            get { return (DateTime?)this["CREATIONDATE"]; }
            set { this["CREATIONDATE"] = value; }
        }

    /// <summary>
    /// Yabancı Adı
    /// </summary>
        public string EnglishName
        {
            get { return (string)this["ENGLISHNAME"]; }
            set { this["ENGLISHNAME"] = value; }
        }

    /// <summary>
    /// Kart Durumu
    /// </summary>
        public StockCardStatusEnum? Status
        {
            get { return (StockCardStatusEnum?)(int?)this["STATUS"]; }
            set { this["STATUS"] = value; }
        }

    /// <summary>
    /// Kart Adedi
    /// </summary>
        public long? CardAmount
        {
            get { return (long?)this["CARDAMOUNT"]; }
            set { this["CARDAMOUNT"] = value; }
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
    /// Türkçe Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Stok Kart Fotoğraf
    /// </summary>
        public object CardPicture
        {
            get { return (object)this["CARDPICTURE"]; }
            set { this["CARDPICTURE"] = value; }
        }

        public bool? ProductionCheckbox
        {
            get { return (bool?)this["PRODUCTIONCHECKBOX"]; }
            set { this["PRODUCTIONCHECKBOX"] = value; }
        }

    /// <summary>
    /// NATO Stok Nu.
    /// </summary>
        public string NATOStockNO
        {
            get { return (string)this["NATOSTOCKNO"]; }
            set { this["NATOSTOCKNO"] = value; }
        }

    /// <summary>
    /// ETKM Açıklama
    /// </summary>
        public string ETKMDescription
        {
            get { return (string)this["ETKMDESCRIPTION"]; }
            set { this["ETKMDESCRIPTION"] = value; }
        }

    /// <summary>
    /// Teklif Edilen Adı
    /// </summary>
        public string OffereeName
        {
            get { return (string)this["OFFEREENAME"]; }
            set { this["OFFEREENAME"] = value; }
        }

    /// <summary>
    /// Stok Yöntemi
    /// </summary>
        public StockMethodEnum? StockMethod
        {
            get { return (StockMethodEnum?)(int?)this["STOCKMETHOD"]; }
            set { this["STOCKMETHOD"] = value; }
        }

        public bool? MainStoreCheckbox
        {
            get { return (bool?)this["MAINSTORECHECKBOX"]; }
            set { this["MAINSTORECHECKBOX"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

        public string NATOStockNO_Shadow
        {
            get { return (string)this["NATOSTOCKNO_SHADOW"]; }
        }

    /// <summary>
    /// Substore'larda durum yeniden kullanılmışa çevrilebilir mi?
    /// </summary>
        public bool? AllowLevelUpdateInSubStores
        {
            get { return (bool?)this["ALLOWLEVELUPDATEINSUBSTORES"]; }
            set { this["ALLOWLEVELUPDATEINSUBSTORES"] = value; }
        }

        public StockCardClass StockCardClass
        {
            get { return (StockCardClass)((ITTObject)this).GetParent("STOCKCARDCLASS"); }
            set { this["STOCKCARDCLASS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DistributionTypeDefinition DistributionType
        {
            get { return (DistributionTypeDefinition)((ITTObject)this).GetParent("DISTRIBUTIONTYPE"); }
            set { this["DISTRIBUTIONTYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Masa-Stok Kartları
    /// </summary>
        public ResCardDrawer CardDrawer
        {
            get { return (ResCardDrawer)((ITTObject)this).GetParent("CARDDRAWER"); }
            set { this["CARDDRAWER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// NSN Grup Kodu
    /// </summary>
        public NATOGroupCode NATOGroupCode
        {
            get { return (NATOGroupCode)((ITTObject)this).GetParent("NATOGROUPCODE"); }
            set { this["NATOGROUPCODE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// GMDN Kodu
    /// </summary>
        public GMDNDefinition GMDNCode
        {
            get { return (GMDNDefinition)((ITTObject)this).GetParent("GMDNCODE"); }
            set { this["GMDNCODE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public StockCard JoinedStockCard
        {
            get { return (StockCard)((ITTObject)this).GetParent("JOINEDSTOCKCARD"); }
            set { this["JOINEDSTOCKCARD"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Sites CreatedSite
        {
            get { return (Sites)((ITTObject)this).GetParent("CREATEDSITE"); }
            set { this["CREATEDSITE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Satınalma Kalemi
    /// </summary>
        public PurchaseGroup PurchaseGroup
        {
            get { return (PurchaseGroup)((ITTObject)this).GetParent("PURCHASEGROUP"); }
            set { this["PURCHASEGROUP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MalzemeGetData MalzemeGetData
        {
            get { return (MalzemeGetData)((ITTObject)this).GetParent("MALZEMEGETDATA"); }
            set { this["MALZEMEGETDATA"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateStockCensusDetailsCollection()
        {
            _StockCensusDetails = new StockCensusDetail.ChildStockCensusDetailCollection(this, new Guid("360dbc14-8982-47c3-ac3d-27d3fa92bb1d"));
            ((ITTChildObjectCollection)_StockCensusDetails).GetChildren();
        }

        protected StockCensusDetail.ChildStockCensusDetailCollection _StockCensusDetails = null;
        public StockCensusDetail.ChildStockCensusDetailCollection StockCensusDetails
        {
            get
            {
                if (_StockCensusDetails == null)
                    CreateStockCensusDetailsCollection();
                return _StockCensusDetails;
            }
        }

        virtual protected void CreateDoubleZeroCardEpochMaterialsCollection()
        {
            _DoubleZeroCardEpochMaterials = new DoubleZeroCardEpochMaterial.ChildDoubleZeroCardEpochMaterialCollection(this, new Guid("777cb094-da94-4171-98e7-7d72ab57e373"));
            ((ITTChildObjectCollection)_DoubleZeroCardEpochMaterials).GetChildren();
        }

        protected DoubleZeroCardEpochMaterial.ChildDoubleZeroCardEpochMaterialCollection _DoubleZeroCardEpochMaterials = null;
        public DoubleZeroCardEpochMaterial.ChildDoubleZeroCardEpochMaterialCollection DoubleZeroCardEpochMaterials
        {
            get
            {
                if (_DoubleZeroCardEpochMaterials == null)
                    CreateDoubleZeroCardEpochMaterialsCollection();
                return _DoubleZeroCardEpochMaterials;
            }
        }

        virtual protected void CreateMaterialsCollection()
        {
            _Materials = new Material.ChildMaterialCollection(this, new Guid("1d61613b-b9b4-4dfe-8dfb-6f6bac77daaf"));
            ((ITTChildObjectCollection)_Materials).GetChildren();
        }

        protected Material.ChildMaterialCollection _Materials = null;
        public Material.ChildMaterialCollection Materials
        {
            get
            {
                if (_Materials == null)
                    CreateMaterialsCollection();
                return _Materials;
            }
        }

        virtual protected void CreateAccountancyStockCardsCollection()
        {
            _AccountancyStockCards = new AccountancyStockCard.ChildAccountancyStockCardCollection(this, new Guid("e4858113-5525-4059-b5d5-2baee5e2fab8"));
            ((ITTChildObjectCollection)_AccountancyStockCards).GetChildren();
        }

        protected AccountancyStockCard.ChildAccountancyStockCardCollection _AccountancyStockCards = null;
    /// <summary>
    /// Child collection for Stok Kart - Saymanlık Stok Kartları
    /// </summary>
        public AccountancyStockCard.ChildAccountancyStockCardCollection AccountancyStockCards
        {
            get
            {
                if (_AccountancyStockCards == null)
                    CreateAccountancyStockCardsCollection();
                return _AccountancyStockCards;
            }
        }

        protected StockCard(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected StockCard(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected StockCard(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected StockCard(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected StockCard(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "STOCKCARD", dataRow) { }
        protected StockCard(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "STOCKCARD", dataRow, isImported) { }
        public StockCard(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public StockCard(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public StockCard() : base() { }

    }
}