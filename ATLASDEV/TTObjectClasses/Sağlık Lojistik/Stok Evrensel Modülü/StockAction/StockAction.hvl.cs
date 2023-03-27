
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="StockAction")] 

    /// <summary>
    /// Tüm Stok İşlemlerinin Temel sınıfıdır. Stok modüllerinin ana sınıfları bu sınıftan türer.
    /// </summary>
    public  abstract  partial class StockAction : BaseAction, IStockAction, IAutoDocumentNumber, IStockWorkList
    {
        public class StockActionList : TTObjectCollection<StockAction> { }
                    
        public class ChildStockActionCollection : TTObject.TTChildObjectCollection<StockAction>
        {
            public ChildStockActionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildStockActionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetDocumentNumbersForMaterialClassReportQuery_Class : TTReportNqlObject 
        {
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

            public GetDocumentNumbersForMaterialClassReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDocumentNumbersForMaterialClassReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDocumentNumbersForMaterialClassReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class UnitPriceStockActionOutDetailsReportQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? Detailid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DETAILID"]);
                }
            }

            public Guid? Materialid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIALID"]);
                }
            }

            public Guid? Transactionid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["TRANSACTIONID"]);
                }
            }

            public string Stockleveltype
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STOCKLEVELTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKLEVELTYPE"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Materialname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
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

            public Object Amount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["AMOUNT"]);
                }
            }

            public Object Unitprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["UNITPRICE"]);
                }
            }

            public Object Totalprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTALPRICE"]);
                }
            }

            public UnitPriceStockActionOutDetailsReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public UnitPriceStockActionOutDetailsReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected UnitPriceStockActionOutDetailsReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class StockActionInDetailsReportQuery_Class : TTReportNqlObject 
        {
            public Guid? Stockactionobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKACTIONOBJECTID"]);
                }
            }

            public Guid? Stockactiondetailobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKACTIONDETAILOBJECTID"]);
                }
            }

            public string Stockleveltype
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STOCKLEVELTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKLEVELTYPE"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Materialobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIALOBJECTID"]);
                }
            }

            public string Materialname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
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

            public Currency? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTIONDETAILIN"].AllPropertyDefs["AMOUNT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
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

            public DateTime? ExpirationDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXPIRATIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTIONDETAILIN"].AllPropertyDefs["EXPIRATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public BigCurrency? UnitPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNITPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTIONDETAILIN"].AllPropertyDefs["UNITPRICE"].DataType;
                    return (BigCurrency?)dataType.ConvertValue(val);
                }
            }

            public StockActionInDetailsReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public StockActionInDetailsReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected StockActionInDetailsReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDocumentSavingRegisterReportQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public DateTime? TransactionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TRANSACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["TRANSACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public long? RegistrationNumberSeq
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REGISTRATIONNUMBERSEQ"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["REGISTRATIONNUMBERSEQ"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string SequenceNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SEQUENCENUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["SEQUENCENUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? SequenceNumberSeq
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SEQUENCENUMBERSEQ"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["SEQUENCENUMBERSEQ"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? StockActionID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STOCKACTIONID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["STOCKACTIONID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Guid? Destinationstoreobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DESTINATIONSTOREOBJECTID"]);
                }
            }

            public string Destinationstorename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESTINATIONSTORENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STORE"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Storeobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOREOBJECTID"]);
                }
            }

            public string Storename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STORENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STORE"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Accountancy
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ACCOUNTANCY"]);
                }
            }

            public DateTime? StartDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STARTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTINGTERM"].AllPropertyDefs["STARTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? EndDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTINGTERM"].AllPropertyDefs["ENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Object Controlcount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["CONTROLCOUNT"]);
                }
            }

            public GetDocumentSavingRegisterReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDocumentSavingRegisterReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDocumentSavingRegisterReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetStockCardPresentationReportQuery_Class : TTReportNqlObject 
        {
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

            public string Cardname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CARDNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["CODE"].DataType;
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

            public string Mainmaterialname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MAINMATERIALNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIALTREEDEFINITION"].AllPropertyDefs["NAME"].DataType;
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

            public GetStockCardPresentationReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetStockCardPresentationReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetStockCardPresentationReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class StockActionOutDetailsReportQuery_Class : TTReportNqlObject 
        {
            public Guid? Stockactionobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKACTIONOBJECTID"]);
                }
            }

            public Guid? Stockactiondetailobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKACTIONDETAILOBJECTID"]);
                }
            }

            public string Stockleveltype
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STOCKLEVELTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKLEVELTYPE"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Materialobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIALOBJECTID"]);
                }
            }

            public string Materialname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
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

            public Currency? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTIONDETAILOUT"].AllPropertyDefs["AMOUNT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
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

            public Guid? StockReservation
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKRESERVATION"]);
                }
            }

            public StockActionOutDetailsReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public StockActionOutDetailsReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected StockActionOutDetailsReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class CensusReportNQL_AllDocuments_Class : TTReportNqlObject 
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

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string ReasonOfCancel
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONOFCANCEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["REASONOFCANCEL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? Active
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIVE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["ACTIVE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? WorkListDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKLISTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["WORKLISTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public object ReasonOfReject
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONOFREJECT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["REASONOFREJECT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OlapLastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAPLASTUPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OlapDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["OLAPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? ClonedObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CLONEDOBJECTID"]);
                }
            }

            public string WorkListDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKLISTDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["WORKLISTDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsOldAction
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISOLDACTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["ISOLDACTION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public DateTime? TransactionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TRANSACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["TRANSACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? RegistrationNumberSeq
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REGISTRATIONNUMBERSEQ"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["REGISTRATIONNUMBERSEQ"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? StockActionID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STOCKACTIONID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["STOCKACTIONID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string SequenceNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SEQUENCENUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["SEQUENCENUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? SequenceNumberSeq
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SEQUENCENUMBERSEQ"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["SEQUENCENUMBERSEQ"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public int? AdditionalDocumentCount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADDITIONALDOCUMENTCOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["ADDITIONALDOCUMENTCOUNT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public bool? IsEntryOldMaterial
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISENTRYOLDMATERIAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["ISENTRYOLDMATERIAL"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public Currency? GrandTotal
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GRANDTOTAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["GRANDTOTAL"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public object InvoicePicture
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INVOICEPICTURE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["INVOICEPICTURE"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public Currency? TotalPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["TOTALPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public int? MKYS_Yil
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_YIL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["MKYS_YIL"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string MKYS_GelenVeri
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_GELENVERI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["MKYS_GELENVERI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? MKYS_AyniyatMakbuzID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_AYNIYATMAKBUZID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["MKYS_AYNIYATMAKBUZID"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public MKYS_EAlimYontemiEnum? MKYS_EAlimYontemi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_EALIMYONTEMI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["MKYS_EALIMYONTEMI"].DataType;
                    return (MKYS_EAlimYontemiEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public MKYS_EButceTurEnum? MKYS_EButceTur
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_EBUTCETUR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["MKYS_EBUTCETUR"].DataType;
                    return (MKYS_EButceTurEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public MKYS_ETedarikTurEnum? MKYS_ETedarikTuru
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_ETEDARIKTURU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["MKYS_ETEDARIKTURU"].DataType;
                    return (MKYS_ETedarikTurEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string MKYS_TeslimEden
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_TESLIMEDEN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["MKYS_TESLIMEDEN"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public MKYS_EMalzemeGrupEnum? MKYS_EMalzemeGrup
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_EMALZEMEGRUP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["MKYS_EMALZEMEGRUP"].DataType;
                    return (MKYS_EMalzemeGrupEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string MKYS_TeslimAlan
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_TESLIMALAN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["MKYS_TESLIMALAN"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? MKYS_MakbuzTarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_MAKBUZTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["MKYS_MAKBUZTARIHI"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public int? MKYS_DepoKayitNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_DEPOKAYITNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["MKYS_DEPOKAYITNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public MKYS_ECikisIslemTuruEnum? MKYS_CikisIslemTuru
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_CIKISISLEMTURU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["MKYS_CIKISISLEMTURU"].DataType;
                    return (MKYS_ECikisIslemTuruEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public MKYS_ECikisStokHareketTurEnum? MKYS_CikisStokHareketTuru
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_CIKISSTOKHAREKETTURU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["MKYS_CIKISSTOKHAREKETTURU"].DataType;
                    return (MKYS_ECikisStokHareketTurEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public int? MKYS_CikisYapilanDepoKayitNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_CIKISYAPILANDEPOKAYITNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["MKYS_CIKISYAPILANDEPOKAYITNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string MKYS_CikisYapilanKisiTCNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_CIKISYAPILANKISITCNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["MKYS_CIKISYAPILANKISITCNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? MKYS_GonderimTarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_GONDERIMTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["MKYS_GONDERIMTARIHI"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string MKYS_GidenVeri
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_GIDENVERI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["MKYS_GIDENVERI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MKYS_GeldigiYer
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_GELDIGIYER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["MKYS_GELDIGIYER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? MKYS_KarsiBirimKayitNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_KARSIBIRIMKAYITNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["MKYS_KARSIBIRIMKAYITNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? MKYS_MakbuzNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_MAKBUZNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["MKYS_MAKBUZNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string MKYS_MuayeneNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_MUAYENENO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["MKYS_MUAYENENO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? MKYS_MuayeneTarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_MUAYENETARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["MKYS_MUAYENETARIHI"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? MKYSControl
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYSCONTROL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["MKYSCONTROL"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public Guid? MKYS_TeslimAlanObjID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MKYS_TESLIMALANOBJID"]);
                }
            }

            public Guid? MKYS_TeslimEdenObjID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MKYS_TESLIMEDENOBJID"]);
                }
            }

            public bool? IsEmergencyMaterial
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISEMERGENCYMATERIAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["ISEMERGENCYMATERIAL"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsPTSAction
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISPTSACTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["ISPTSACTION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string PTSNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PTSNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["PTSNUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public CensusReportNQL_AllDocuments_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public CensusReportNQL_AllDocuments_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected CensusReportNQL_AllDocuments_Class() : base() { }
        }

        [Serializable] 

        public partial class CensusReportNQL_StockActionInDetailsReportQuery_Class : TTReportNqlObject 
        {
            public Guid? Stockactionobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKACTIONOBJECTID"]);
                }
            }

            public Guid? Stockactiondetailobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKACTIONDETAILOBJECTID"]);
                }
            }

            public string Stockleveltype
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STOCKLEVELTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKLEVELTYPE"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Materialobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIALOBJECTID"]);
                }
            }

            public string Materialname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
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

            public Currency? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTIONDETAILIN"].AllPropertyDefs["AMOUNT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
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

            public DateTime? ExpirationDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXPIRATIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTIONDETAILIN"].AllPropertyDefs["EXPIRATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public BigCurrency? UnitPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNITPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTIONDETAILIN"].AllPropertyDefs["UNITPRICE"].DataType;
                    return (BigCurrency?)dataType.ConvertValue(val);
                }
            }

            public CensusReportNQL_StockActionInDetailsReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public CensusReportNQL_StockActionInDetailsReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected CensusReportNQL_StockActionInDetailsReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class SearchDocumentRegistryReportQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public DateTime? TransactionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TRANSACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["TRANSACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public long? RegistrationNumberSeq
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REGISTRATIONNUMBERSEQ"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["REGISTRATIONNUMBERSEQ"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string SequenceNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SEQUENCENUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["SEQUENCENUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? SequenceNumberSeq
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SEQUENCENUMBERSEQ"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["SEQUENCENUMBERSEQ"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? StockActionID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STOCKACTIONID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["STOCKACTIONID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Destinationstorename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESTINATIONSTORENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STORE"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Storename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STORENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STORE"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Accountancy
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ACCOUNTANCY"]);
                }
            }

            public DateTime? StartDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STARTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTINGTERM"].AllPropertyDefs["STARTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? EndDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTINGTERM"].AllPropertyDefs["ENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Object Controlcount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["CONTROLCOUNT"]);
                }
            }

            public Object Firstmaterialname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["FIRSTMATERIALNAME"]);
                }
            }

            public SearchDocumentRegistryReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public SearchDocumentRegistryReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected SearchDocumentRegistryReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetStockActionsCount_Class : TTReportNqlObject 
        {
            public Guid? ObjectDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTDEFID"]);
                }
            }

            public String ObjectDefName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OBJECTDEFNAME"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public Object Sayi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["SAYI"]);
                }
            }

            public GetStockActionsCount_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetStockActionsCount_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetStockActionsCount_Class() : base() { }
        }

        [Serializable] 

        public partial class MKYSControlGetQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? StockActionID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STOCKACTIONID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["STOCKACTIONID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public String Objectdefdisplaytext
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OBJECTDEFDISPLAYTEXT"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public String Status
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STATUS"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public int? MKYS_AyniyatMakbuzID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_AYNIYATMAKBUZID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["MKYS_AYNIYATMAKBUZID"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public DateTime? WorkListDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKLISTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["WORKLISTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public MKYSControlGetQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public MKYSControlGetQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected MKYSControlGetQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMaxMKYS_MakbuzNo_Class : TTReportNqlObject 
        {
            public Object Makbuzno
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MAKBUZNO"]);
                }
            }

            public GetMaxMKYS_MakbuzNo_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMaxMKYS_MakbuzNo_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMaxMKYS_MakbuzNo_Class() : base() { }
        }

        [Serializable] 

        public partial class GetSubStoreWaitingWorks_Class : TTReportNqlObject 
        {
            public string Storename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STORENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STORE"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Destinationstorename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESTINATIONSTORENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STORE"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? StockActionID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STOCKACTIONID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["STOCKACTIONID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? WorkListDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKLISTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["WORKLISTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public String Objtext
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OBJTEXT"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public String DisplayText
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISPLAYTEXT"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public GetSubStoreWaitingWorks_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSubStoreWaitingWorks_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSubStoreWaitingWorks_Class() : base() { }
        }

        [Serializable] 

        public partial class GetActiveStockActionBetweenDate_Class : TTReportNqlObject 
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

            public String DisplayText
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISPLAYTEXT"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public long? StockActionID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STOCKACTIONID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["STOCKACTIONID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public GetActiveStockActionBetweenDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetActiveStockActionBetweenDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetActiveStockActionBetweenDate_Class() : base() { }
        }

        [Serializable] 

        public partial class GetClonedStockAction_Class : TTReportNqlObject 
        {
            public long? StockActionID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STOCKACTIONID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["STOCKACTIONID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public GetClonedStockAction_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetClonedStockAction_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetClonedStockAction_Class() : base() { }
        }

        public static class States
        {
            public static Guid Cancelled { get { return new Guid("887b7ee9-ebfa-43df-8145-aac2f3c4a1a7"); } }
            public static Guid New { get { return new Guid("96777208-ca89-40f7-b71d-6affa44acc11"); } }
            public static Guid Completed { get { return new Guid("b959800b-5382-4411-beb9-acdea28be1fa"); } }
        }

        public static BindingList<StockAction.GetDocumentNumbersForMaterialClassReportQuery_Class> GetDocumentNumbersForMaterialClassReportQuery(Guid STOREID, Guid ACCOUNTINGTERM, Guid MAINCLASSID, string REFERENCELETTER, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].QueryDefs["GetDocumentNumbersForMaterialClassReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);
            paramList.Add("ACCOUNTINGTERM", ACCOUNTINGTERM);
            paramList.Add("MAINCLASSID", MAINCLASSID);
            paramList.Add("REFERENCELETTER", REFERENCELETTER);

            return TTReportNqlObject.QueryObjects<StockAction.GetDocumentNumbersForMaterialClassReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockAction.GetDocumentNumbersForMaterialClassReportQuery_Class> GetDocumentNumbersForMaterialClassReportQuery(TTObjectContext objectContext, Guid STOREID, Guid ACCOUNTINGTERM, Guid MAINCLASSID, string REFERENCELETTER, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].QueryDefs["GetDocumentNumbersForMaterialClassReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);
            paramList.Add("ACCOUNTINGTERM", ACCOUNTINGTERM);
            paramList.Add("MAINCLASSID", MAINCLASSID);
            paramList.Add("REFERENCELETTER", REFERENCELETTER);

            return TTReportNqlObject.QueryObjects<StockAction.GetDocumentNumbersForMaterialClassReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockAction> StockActionWorkListNQL(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, Guid STOREID, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].QueryDefs["StockActionWorkListNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STOREID", STOREID);

            return ((ITTQuery)objectContext).QueryObjects<StockAction>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<StockAction.UnitPriceStockActionOutDetailsReportQuery_Class> UnitPriceStockActionOutDetailsReportQuery(string TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].QueryDefs["UnitPriceStockActionOutDetailsReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<StockAction.UnitPriceStockActionOutDetailsReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockAction.UnitPriceStockActionOutDetailsReportQuery_Class> UnitPriceStockActionOutDetailsReportQuery(TTObjectContext objectContext, string TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].QueryDefs["UnitPriceStockActionOutDetailsReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<StockAction.UnitPriceStockActionOutDetailsReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockAction.StockActionInDetailsReportQuery_Class> StockActionInDetailsReportQuery(Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].QueryDefs["StockActionInDetailsReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<StockAction.StockActionInDetailsReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockAction.StockActionInDetailsReportQuery_Class> StockActionInDetailsReportQuery(TTObjectContext objectContext, Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].QueryDefs["StockActionInDetailsReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<StockAction.StockActionInDetailsReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockAction.GetDocumentSavingRegisterReportQuery_Class> GetDocumentSavingRegisterReportQuery(Guid ACCOUNTINGTERMID, long REGISTRATIONNO, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].QueryDefs["GetDocumentSavingRegisterReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ACCOUNTINGTERMID", ACCOUNTINGTERMID);
            paramList.Add("REGISTRATIONNO", REGISTRATIONNO);

            return TTReportNqlObject.QueryObjects<StockAction.GetDocumentSavingRegisterReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockAction.GetDocumentSavingRegisterReportQuery_Class> GetDocumentSavingRegisterReportQuery(TTObjectContext objectContext, Guid ACCOUNTINGTERMID, long REGISTRATIONNO, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].QueryDefs["GetDocumentSavingRegisterReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ACCOUNTINGTERMID", ACCOUNTINGTERMID);
            paramList.Add("REGISTRATIONNO", REGISTRATIONNO);

            return TTReportNqlObject.QueryObjects<StockAction.GetDocumentSavingRegisterReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockAction.GetStockCardPresentationReportQuery_Class> GetStockCardPresentationReportQuery(string STOCKCARDID, string STOREID, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].QueryDefs["GetStockCardPresentationReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKCARDID", STOCKCARDID);
            paramList.Add("STOREID", STOREID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<StockAction.GetStockCardPresentationReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockAction.GetStockCardPresentationReportQuery_Class> GetStockCardPresentationReportQuery(TTObjectContext objectContext, string STOCKCARDID, string STOREID, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].QueryDefs["GetStockCardPresentationReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKCARDID", STOCKCARDID);
            paramList.Add("STOREID", STOREID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<StockAction.GetStockCardPresentationReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockAction.StockActionOutDetailsReportQuery_Class> StockActionOutDetailsReportQuery(Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].QueryDefs["StockActionOutDetailsReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<StockAction.StockActionOutDetailsReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockAction.StockActionOutDetailsReportQuery_Class> StockActionOutDetailsReportQuery(TTObjectContext objectContext, Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].QueryDefs["StockActionOutDetailsReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<StockAction.StockActionOutDetailsReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockAction.CensusReportNQL_AllDocuments_Class> CensusReportNQL_AllDocuments(string TERMID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].QueryDefs["CensusReportNQL_AllDocuments"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERMID", TERMID);

            return TTReportNqlObject.QueryObjects<StockAction.CensusReportNQL_AllDocuments_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockAction.CensusReportNQL_AllDocuments_Class> CensusReportNQL_AllDocuments(TTObjectContext objectContext, string TERMID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].QueryDefs["CensusReportNQL_AllDocuments"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERMID", TERMID);

            return TTReportNqlObject.QueryObjects<StockAction.CensusReportNQL_AllDocuments_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockAction> GetStockActionByTerm(TTObjectContext objectContext, Guid TERMID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].QueryDefs["GetStockActionByTerm"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERMID", TERMID);

            return ((ITTQuery)objectContext).QueryObjects<StockAction>(queryDef, paramList);
        }

        public static BindingList<StockAction.CensusReportNQL_StockActionInDetailsReportQuery_Class> CensusReportNQL_StockActionInDetailsReportQuery(string TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].QueryDefs["CensusReportNQL_StockActionInDetailsReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<StockAction.CensusReportNQL_StockActionInDetailsReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockAction.CensusReportNQL_StockActionInDetailsReportQuery_Class> CensusReportNQL_StockActionInDetailsReportQuery(TTObjectContext objectContext, string TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].QueryDefs["CensusReportNQL_StockActionInDetailsReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<StockAction.CensusReportNQL_StockActionInDetailsReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockAction.SearchDocumentRegistryReportQuery_Class> SearchDocumentRegistryReportQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].QueryDefs["SearchDocumentRegistryReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<StockAction.SearchDocumentRegistryReportQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<StockAction.SearchDocumentRegistryReportQuery_Class> SearchDocumentRegistryReportQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].QueryDefs["SearchDocumentRegistryReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<StockAction.SearchDocumentRegistryReportQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<StockAction> StockActionWorkListNQLNoDate(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].QueryDefs["StockActionWorkListNQLNoDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<StockAction>(queryDef, paramList, injectionSQL);
        }

    /// <summary>
    /// İşlem Sayıları
    /// </summary>
        public static BindingList<StockAction.GetStockActionsCount_Class> GetStockActionsCount(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].QueryDefs["GetStockActionsCount"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<StockAction.GetStockActionsCount_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// İşlem Sayıları
    /// </summary>
        public static BindingList<StockAction.GetStockActionsCount_Class> GetStockActionsCount(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].QueryDefs["GetStockActionsCount"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<StockAction.GetStockActionsCount_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockAction> GetTenderUpdateNQL(TTObjectContext objectContext, string ACTIONID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].QueryDefs["GetTenderUpdateNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ACTIONID", ACTIONID);

            return ((ITTQuery)objectContext).QueryObjects<StockAction>(queryDef, paramList);
        }

        public static BindingList<StockAction.MKYSControlGetQuery_Class> MKYSControlGetQuery(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].QueryDefs["MKYSControlGetQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<StockAction.MKYSControlGetQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockAction.MKYSControlGetQuery_Class> MKYSControlGetQuery(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].QueryDefs["MKYSControlGetQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<StockAction.MKYSControlGetQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockAction.GetMaxMKYS_MakbuzNo_Class> GetMaxMKYS_MakbuzNo(int DEPOKAYITNO, MKYS_EButceTurEnum BUTCE, int YIL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].QueryDefs["GetMaxMKYS_MakbuzNo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DEPOKAYITNO", DEPOKAYITNO);
            paramList.Add("BUTCE", (int)BUTCE);
            paramList.Add("YIL", YIL);

            return TTReportNqlObject.QueryObjects<StockAction.GetMaxMKYS_MakbuzNo_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockAction.GetMaxMKYS_MakbuzNo_Class> GetMaxMKYS_MakbuzNo(TTObjectContext objectContext, int DEPOKAYITNO, MKYS_EButceTurEnum BUTCE, int YIL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].QueryDefs["GetMaxMKYS_MakbuzNo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DEPOKAYITNO", DEPOKAYITNO);
            paramList.Add("BUTCE", (int)BUTCE);
            paramList.Add("YIL", YIL);

            return TTReportNqlObject.QueryObjects<StockAction.GetMaxMKYS_MakbuzNo_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Çıkış Raporlarının kontrolü için query
    /// </summary>
        public static BindingList<StockAction> GetMovableTransactionOutVouchers(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, Guid STOREID, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].QueryDefs["GetMovableTransactionOutVouchers"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STOREID", STOREID);

            return ((ITTQuery)objectContext).QueryObjects<StockAction>(queryDef, paramList, injectionSQL);
        }

    /// <summary>
    /// MKYS Stok Hareket ID ile giriş fişi Sorgulama
    /// </summary>
        public static BindingList<StockAction> GetMovTransInputVoucStockTransID(TTObjectContext objectContext, string STOKHAREKETID, Guid STOREID, DateTime ENDDATE, DateTime STARTDATE, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].QueryDefs["GetMovTransInputVoucStockTransID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOKHAREKETID", STOKHAREKETID);
            paramList.Add("STOREID", STOREID);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STARTDATE", STARTDATE);

            return ((ITTQuery)objectContext).QueryObjects<StockAction>(queryDef, paramList, injectionSQL);
        }

    /// <summary>
    /// Taşınır mal ve satın alma yoluyla girişler için query
    /// </summary>
        public static BindingList<StockAction> GetMovableTransactionInputVouchers(TTObjectContext objectContext, DateTime ENDDATE, DateTime STARTDATE, Guid STOREID, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].QueryDefs["GetMovableTransactionInputVouchers"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("STOREID", STOREID);

            return ((ITTQuery)objectContext).QueryObjects<StockAction>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<StockAction.GetSubStoreWaitingWorks_Class> GetSubStoreWaitingWorks(DateTime STARTDATE, DateTime ENDDATE, int ALL, string STOREID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].QueryDefs["GetSubStoreWaitingWorks"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("ALL", ALL);
            paramList.Add("STOREID", STOREID);

            return TTReportNqlObject.QueryObjects<StockAction.GetSubStoreWaitingWorks_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockAction.GetSubStoreWaitingWorks_Class> GetSubStoreWaitingWorks(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, int ALL, string STOREID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].QueryDefs["GetSubStoreWaitingWorks"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("ALL", ALL);
            paramList.Add("STOREID", STOREID);

            return TTReportNqlObject.QueryObjects<StockAction.GetSubStoreWaitingWorks_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockAction.GetActiveStockActionBetweenDate_Class> GetActiveStockActionBetweenDate(DateTime STARTDATE, DateTime ENDDATE, Guid STOREID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].QueryDefs["GetActiveStockActionBetweenDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STOREID", STOREID);

            return TTReportNqlObject.QueryObjects<StockAction.GetActiveStockActionBetweenDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockAction.GetActiveStockActionBetweenDate_Class> GetActiveStockActionBetweenDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, Guid STOREID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].QueryDefs["GetActiveStockActionBetweenDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STOREID", STOREID);

            return TTReportNqlObject.QueryObjects<StockAction.GetActiveStockActionBetweenDate_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockAction.GetClonedStockAction_Class> GetClonedStockAction(Guid STOCKACTIONID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].QueryDefs["GetClonedStockAction"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKACTIONID", STOCKACTIONID);

            return TTReportNqlObject.QueryObjects<StockAction.GetClonedStockAction_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockAction.GetClonedStockAction_Class> GetClonedStockAction(TTObjectContext objectContext, Guid STOCKACTIONID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].QueryDefs["GetClonedStockAction"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKACTIONID", STOCKACTIONID);

            return TTReportNqlObject.QueryObjects<StockAction.GetClonedStockAction_Class>(objectContext, queryDef, paramList, pi);
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
    /// Belge Kayıt No
    /// </summary>
        public string RegistrationNumber
        {
            get { return (string)this["REGISTRATIONNUMBER"]; }
            set { this["REGISTRATIONNUMBER"] = value; }
        }

    /// <summary>
    /// İşlem Tarihi
    /// </summary>
        public DateTime? TransactionDate
        {
            get { return (DateTime?)this["TRANSACTIONDATE"]; }
            set { this["TRANSACTIONDATE"] = value; }
        }

    /// <summary>
    /// Belge Kayıt No
    /// </summary>
        public TTSequence RegistrationNumberSeq
        {
            get { return GetSequence("REGISTRATIONNUMBERSEQ"); }
        }

    /// <summary>
    /// İşlem No
    /// </summary>
        public TTSequence StockActionID
        {
            get { return GetSequence("STOCKACTIONID"); }
        }

    /// <summary>
    /// Belge Sıra No
    /// </summary>
        public string SequenceNumber
        {
            get { return (string)this["SEQUENCENUMBER"]; }
            set { this["SEQUENCENUMBER"] = value; }
        }

    /// <summary>
    /// Belge Sıra No
    /// </summary>
        public TTSequence SequenceNumberSeq
        {
            get { return GetSequence("SEQUENCENUMBERSEQ"); }
        }

    /// <summary>
    /// Ek Belge Sayısı
    /// </summary>
        public int? AdditionalDocumentCount
        {
            get { return (int?)this["ADDITIONALDOCUMENTCOUNT"]; }
            set { this["ADDITIONALDOCUMENTCOUNT"] = value; }
        }

    /// <summary>
    /// Eski Malzeme Girebilir
    /// </summary>
        public bool? IsEntryOldMaterial
        {
            get { return (bool?)this["ISENTRYOLDMATERIAL"]; }
            set { this["ISENTRYOLDMATERIAL"] = value; }
        }

        public Currency? GrandTotal
        {
            get { return (Currency?)this["GRANDTOTAL"]; }
            set { this["GRANDTOTAL"] = value; }
        }

    /// <summary>
    /// Fatura Fotografı
    /// </summary>
        public object InvoicePicture
        {
            get { return (object)this["INVOICEPICTURE"]; }
            set { this["INVOICEPICTURE"] = value; }
        }

        public Currency? TotalPrice
        {
            get { return (Currency?)this["TOTALPRICE"]; }
            set { this["TOTALPRICE"] = value; }
        }

        public int? MKYS_Yil
        {
            get { return (int?)this["MKYS_YIL"]; }
            set { this["MKYS_YIL"] = value; }
        }

        public string MKYS_GelenVeri
        {
            get { return (string)this["MKYS_GELENVERI"]; }
            set { this["MKYS_GELENVERI"] = value; }
        }

        public int? MKYS_AyniyatMakbuzID
        {
            get { return (int?)this["MKYS_AYNIYATMAKBUZID"]; }
            set { this["MKYS_AYNIYATMAKBUZID"] = value; }
        }

        public MKYS_EAlimYontemiEnum? MKYS_EAlimYontemi
        {
            get { return (MKYS_EAlimYontemiEnum?)(int?)this["MKYS_EALIMYONTEMI"]; }
            set { this["MKYS_EALIMYONTEMI"] = value; }
        }

        public MKYS_EButceTurEnum? MKYS_EButceTur
        {
            get { return (MKYS_EButceTurEnum?)(int?)this["MKYS_EBUTCETUR"]; }
            set { this["MKYS_EBUTCETUR"] = value; }
        }

        public MKYS_ETedarikTurEnum? MKYS_ETedarikTuru
        {
            get { return (MKYS_ETedarikTurEnum?)(int?)this["MKYS_ETEDARIKTURU"]; }
            set { this["MKYS_ETEDARIKTURU"] = value; }
        }

        public string MKYS_TeslimEden
        {
            get { return (string)this["MKYS_TESLIMEDEN"]; }
            set { this["MKYS_TESLIMEDEN"] = value; }
        }

        public MKYS_EMalzemeGrupEnum? MKYS_EMalzemeGrup
        {
            get { return (MKYS_EMalzemeGrupEnum?)(int?)this["MKYS_EMALZEMEGRUP"]; }
            set { this["MKYS_EMALZEMEGRUP"] = value; }
        }

        public string MKYS_TeslimAlan
        {
            get { return (string)this["MKYS_TESLIMALAN"]; }
            set { this["MKYS_TESLIMALAN"] = value; }
        }

        public DateTime? MKYS_MakbuzTarihi
        {
            get { return (DateTime?)this["MKYS_MAKBUZTARIHI"]; }
            set { this["MKYS_MAKBUZTARIHI"] = value; }
        }

        public int? MKYS_DepoKayitNo
        {
            get { return (int?)this["MKYS_DEPOKAYITNO"]; }
            set { this["MKYS_DEPOKAYITNO"] = value; }
        }

        public MKYS_ECikisIslemTuruEnum? MKYS_CikisIslemTuru
        {
            get { return (MKYS_ECikisIslemTuruEnum?)(int?)this["MKYS_CIKISISLEMTURU"]; }
            set { this["MKYS_CIKISISLEMTURU"] = value; }
        }

        public MKYS_ECikisStokHareketTurEnum? MKYS_CikisStokHareketTuru
        {
            get { return (MKYS_ECikisStokHareketTurEnum?)(int?)this["MKYS_CIKISSTOKHAREKETTURU"]; }
            set { this["MKYS_CIKISSTOKHAREKETTURU"] = value; }
        }

        public int? MKYS_CikisYapilanDepoKayitNo
        {
            get { return (int?)this["MKYS_CIKISYAPILANDEPOKAYITNO"]; }
            set { this["MKYS_CIKISYAPILANDEPOKAYITNO"] = value; }
        }

        public string MKYS_CikisYapilanKisiTCNo
        {
            get { return (string)this["MKYS_CIKISYAPILANKISITCNO"]; }
            set { this["MKYS_CIKISYAPILANKISITCNO"] = value; }
        }

        public DateTime? MKYS_GonderimTarihi
        {
            get { return (DateTime?)this["MKYS_GONDERIMTARIHI"]; }
            set { this["MKYS_GONDERIMTARIHI"] = value; }
        }

        public string MKYS_GidenVeri
        {
            get { return (string)this["MKYS_GIDENVERI"]; }
            set { this["MKYS_GIDENVERI"] = value; }
        }

        public string MKYS_GeldigiYer
        {
            get { return (string)this["MKYS_GELDIGIYER"]; }
            set { this["MKYS_GELDIGIYER"] = value; }
        }

        public int? MKYS_KarsiBirimKayitNo
        {
            get { return (int?)this["MKYS_KARSIBIRIMKAYITNO"]; }
            set { this["MKYS_KARSIBIRIMKAYITNO"] = value; }
        }

        public int? MKYS_MakbuzNo
        {
            get { return (int?)this["MKYS_MAKBUZNO"]; }
            set { this["MKYS_MAKBUZNO"] = value; }
        }

        public string MKYS_MuayeneNo
        {
            get { return (string)this["MKYS_MUAYENENO"]; }
            set { this["MKYS_MUAYENENO"] = value; }
        }

        public DateTime? MKYS_MuayeneTarihi
        {
            get { return (DateTime?)this["MKYS_MUAYENETARIHI"]; }
            set { this["MKYS_MUAYENETARIHI"] = value; }
        }

    /// <summary>
    /// MKYS Kontrol
    /// </summary>
        public bool? MKYSControl
        {
            get { return (bool?)this["MKYSCONTROL"]; }
            set { this["MKYSCONTROL"] = value; }
        }

        public Guid? MKYS_TeslimAlanObjID
        {
            get { return (Guid?)this["MKYS_TESLIMALANOBJID"]; }
            set { this["MKYS_TESLIMALANOBJID"] = value; }
        }

        public Guid? MKYS_TeslimEdenObjID
        {
            get { return (Guid?)this["MKYS_TESLIMEDENOBJID"]; }
            set { this["MKYS_TESLIMEDENOBJID"] = value; }
        }

    /// <summary>
    /// Acil Malzeme İstemi
    /// </summary>
        public bool? IsEmergencyMaterial
        {
            get { return (bool?)this["ISEMERGENCYMATERIAL"]; }
            set { this["ISEMERGENCYMATERIAL"] = value; }
        }

    /// <summary>
    /// PTS İşlemi
    /// </summary>
        public bool? IsPTSAction
        {
            get { return (bool?)this["ISPTSACTION"]; }
            set { this["ISPTSACTION"] = value; }
        }

    /// <summary>
    /// Paket Numarası
    /// </summary>
        public string PTSNumber
        {
            get { return (string)this["PTSNUMBER"]; }
            set { this["PTSNUMBER"] = value; }
        }

    /// <summary>
    /// Hesap Dönemi
    /// </summary>
        public AccountingTerm AccountingTerm
        {
            get { return (AccountingTerm)((ITTObject)this).GetParent("ACCOUNTINGTERM"); }
            set { this["ACCOUNTINGTERM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Alan Depo
    /// </summary>
        public Store DestinationStore
        {
            get { return (Store)((ITTObject)this).GetParent("DESTINATIONSTORE"); }
            set { this["DESTINATIONSTORE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Gönderen Depo
    /// </summary>
        public Store Store
        {
            get { return (Store)((ITTObject)this).GetParent("STORE"); }
            set { this["STORE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Muayene
    /// </summary>
        public StockActionInspection StockActionInspection
        {
            get { return (StockActionInspection)((ITTObject)this).GetParent("STOCKACTIONINSPECTION"); }
            set { this["STOCKACTIONINSPECTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public BudgetTypeDefinition BudgetTypeDefinition
        {
            get { return (BudgetTypeDefinition)((ITTObject)this).GetParent("BUDGETTYPEDEFINITION"); }
            set { this["BUDGETTYPEDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateStockActionDetailsCollectionViews()
        {
            _StockFirstInDetails = new StockFirstInDetail.ChildStockFirstInDetailCollection(_StockActionDetails, "StockFirstInDetails");
            _StockActionOutDetails = new StockActionDetailOut.ChildStockActionDetailOutCollection(_StockActionDetails, "StockActionOutDetails");
            _E2Materials = new E2Material.ChildE2MaterialCollection(_StockActionDetails, "E2Materials");
            _E1Materials = new E1Material.ChildE1MaterialCollection(_StockActionDetails, "E1Materials");
            _StockActionInDetails = new StockActionDetailIn.ChildStockActionDetailInCollection(_StockActionDetails, "StockActionInDetails");
        }

        virtual protected void CreateStockActionDetailsCollection()
        {
            _StockActionDetails = new StockActionDetail.ChildStockActionDetailCollection(this, new Guid("a87266b9-aa21-4f55-bbae-1e139dc341b3"));
            CreateStockActionDetailsCollectionViews();
            ((ITTChildObjectCollection)_StockActionDetails).GetChildren();
        }

        protected StockActionDetail.ChildStockActionDetailCollection _StockActionDetails = null;
    /// <summary>
    /// Child collection for Ana İşlem-Alt İşlemler
    /// </summary>
        public StockActionDetail.ChildStockActionDetailCollection StockActionDetails
        {
            get
            {
                if (_StockActionDetails == null)
                    CreateStockActionDetailsCollection();
                return _StockActionDetails;
            }
        }

        private StockFirstInDetail.ChildStockFirstInDetailCollection _StockFirstInDetails = null;
    /// <summary>
    /// Alt İşlemler
    /// </summary>
        public StockFirstInDetail.ChildStockFirstInDetailCollection StockFirstInDetails
        {
            get
            {
                if (_StockActionDetails == null)
                    CreateStockActionDetailsCollection();
                return _StockFirstInDetails;
            }            
        }

        private StockActionDetailOut.ChildStockActionDetailOutCollection _StockActionOutDetails = null;
    /// <summary>
    /// Alt İşlemler
    /// </summary>
        public StockActionDetailOut.ChildStockActionDetailOutCollection StockActionOutDetails
        {
            get
            {
                if (_StockActionDetails == null)
                    CreateStockActionDetailsCollection();
                return _StockActionOutDetails;
            }            
        }

        private E2Material.ChildE2MaterialCollection _E2Materials = null;
    /// <summary>
    /// Alt İşlemler
    /// </summary>
        public E2Material.ChildE2MaterialCollection E2Materials
        {
            get
            {
                if (_StockActionDetails == null)
                    CreateStockActionDetailsCollection();
                return _E2Materials;
            }            
        }

        private E1Material.ChildE1MaterialCollection _E1Materials = null;
    /// <summary>
    /// Alt İşlemler
    /// </summary>
        public E1Material.ChildE1MaterialCollection E1Materials
        {
            get
            {
                if (_StockActionDetails == null)
                    CreateStockActionDetailsCollection();
                return _E1Materials;
            }            
        }

        private StockActionDetailIn.ChildStockActionDetailInCollection _StockActionInDetails = null;
    /// <summary>
    /// Alt İşlemler
    /// </summary>
        public StockActionDetailIn.ChildStockActionDetailInCollection StockActionInDetails
        {
            get
            {
                if (_StockActionDetails == null)
                    CreateStockActionDetailsCollection();
                return _StockActionInDetails;
            }            
        }

        virtual protected void CreateLoadSummariesCollection()
        {
            _LoadSummaries = new LoadSummary.ChildLoadSummaryCollection(this, new Guid("704ea0f0-7c71-48b8-ad17-9c86055b1b45"));
            ((ITTChildObjectCollection)_LoadSummaries).GetChildren();
        }

        protected LoadSummary.ChildLoadSummaryCollection _LoadSummaries = null;
        public LoadSummary.ChildLoadSummaryCollection LoadSummaries
        {
            get
            {
                if (_LoadSummaries == null)
                    CreateLoadSummariesCollection();
                return _LoadSummaries;
            }
        }

        virtual protected void CreateStockActionSignDetailsCollection()
        {
            _StockActionSignDetails = new StockActionSignDetail.ChildStockActionSignDetailCollection(this, new Guid("e6cd5d71-dace-4507-8fc4-ac4c6686c9a3"));
            ((ITTChildObjectCollection)_StockActionSignDetails).GetChildren();
        }

        protected StockActionSignDetail.ChildStockActionSignDetailCollection _StockActionSignDetails = null;
        public StockActionSignDetail.ChildStockActionSignDetailCollection StockActionSignDetails
        {
            get
            {
                if (_StockActionSignDetails == null)
                    CreateStockActionSignDetailsCollection();
                return _StockActionSignDetails;
            }
        }

        virtual protected void CreateDocumentRecordLogsCollection()
        {
            _DocumentRecordLogs = new DocumentRecordLog.ChildDocumentRecordLogCollection(this, new Guid("cf766ea9-e739-4d3e-9ef4-104debea682f"));
            ((ITTChildObjectCollection)_DocumentRecordLogs).GetChildren();
        }

        protected DocumentRecordLog.ChildDocumentRecordLogCollection _DocumentRecordLogs = null;
        public DocumentRecordLog.ChildDocumentRecordLogCollection DocumentRecordLogs
        {
            get
            {
                if (_DocumentRecordLogs == null)
                    CreateDocumentRecordLogsCollection();
                return _DocumentRecordLogs;
            }
        }

        virtual protected void CreateStockActionVatRatesCollection()
        {
            _StockActionVatRates = new StockActionVatRate.ChildStockActionVatRateCollection(this, new Guid("5b5e6b87-0247-4ad8-9254-f9cfbaba4b95"));
            ((ITTChildObjectCollection)_StockActionVatRates).GetChildren();
        }

        protected StockActionVatRate.ChildStockActionVatRateCollection _StockActionVatRates = null;
        public StockActionVatRate.ChildStockActionVatRateCollection StockActionVatRates
        {
            get
            {
                if (_StockActionVatRates == null)
                    CreateStockActionVatRatesCollection();
                return _StockActionVatRates;
            }
        }

        virtual protected void CreatePTSStockActionDetailsCollection()
        {
            _PTSStockActionDetails = new PTSStockActionDetail.ChildPTSStockActionDetailCollection(this, new Guid("57cd9029-c261-4d73-a191-ac792dc6b742"));
            ((ITTChildObjectCollection)_PTSStockActionDetails).GetChildren();
        }

        protected PTSStockActionDetail.ChildPTSStockActionDetailCollection _PTSStockActionDetails = null;
        public PTSStockActionDetail.ChildPTSStockActionDetailCollection PTSStockActionDetails
        {
            get
            {
                if (_PTSStockActionDetails == null)
                    CreatePTSStockActionDetailsCollection();
                return _PTSStockActionDetails;
            }
        }

        protected StockAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected StockAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected StockAction(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected StockAction(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected StockAction(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "STOCKACTION", dataRow) { }
        protected StockAction(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "STOCKACTION", dataRow, isImported) { }
        protected StockAction(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public StockAction(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public StockAction() : base() { }

        override protected void RunPreTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePreScript(transDef))
                base.RunPreTransition(transDef.BaseTransDef);
            this.PreTransition(transDef);
        }
        override protected void RunPostTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePostScript(transDef))
                base.RunPostTransition(transDef.BaseTransDef);
            this.PostTransition(transDef);
        }
        override protected void RunUndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBaseUndoScript(transDef))
                base.RunUndoTransition(transDef.BaseTransDef);
            this.UndoTransition(transDef);
        }
    }
}