
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DocumentRecordLog")] 

    public  partial class DocumentRecordLog : TTObject
    {
        public class DocumentRecordLogList : TTObjectCollection<DocumentRecordLog> { }
                    
        public class ChildDocumentRecordLogCollection : TTObject.TTChildObjectCollection<DocumentRecordLog>
        {
            public ChildDocumentRecordLogCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDocumentRecordLogCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class CensusReportNQL_DocumentRecLogByObjectDef_Class : TTReportNqlObject 
        {
            public Guid? Stockactionobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKACTIONOBJECTID"]);
                }
            }

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

            public string TakenGivenPlace_Shadow
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TAKENGIVENPLACE_SHADOW"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["TAKENGIVENPLACE_SHADOW"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Descriptions
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTIONS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["DESCRIPTIONS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? DocumentDateTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTDATETIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["DOCUMENTDATETIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? DocumentRecordLogNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTRECORDLOGNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["DOCUMENTRECORDLOGNUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DocumentTransactionTypeEnum? DocumentTransactionType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTTRANSACTIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["DOCUMENTTRANSACTIONTYPE"].DataType;
                    return (DocumentTransactionTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public int? NumberOfRows
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NUMBEROFROWS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["NUMBEROFROWS"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string Subject
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUBJECT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["SUBJECT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string TakenGivenPlace
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TAKENGIVENPLACE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["TAKENGIVENPLACE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public MKYS_EButceTurEnum? BudgeType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BUDGETYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["BUDGETYPE"].DataType;
                    return (MKYS_EButceTurEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public int? ReceiptNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RECEIPTNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["RECEIPTNUMBER"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public MKYSControlEnum? MKYSStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYSSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["MKYSSTATUS"].DataType;
                    return (MKYSControlEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public CensusReportNQL_DocumentRecLogByObjectDef_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public CensusReportNQL_DocumentRecLogByObjectDef_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected CensusReportNQL_DocumentRecLogByObjectDef_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDocumentRecordLogReportQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? DocumentRecordLogNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTRECORDLOGNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["DOCUMENTRECORDLOGNUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? DocumentDateTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTDATETIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["DOCUMENTDATETIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DocumentTransactionTypeEnum? DocumentTransactionType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTTRANSACTIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["DOCUMENTTRANSACTIONTYPE"].DataType;
                    return (DocumentTransactionTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Subject
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUBJECT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["SUBJECT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? NumberOfRows
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NUMBEROFROWS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["NUMBEROFROWS"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string TakenGivenPlace
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TAKENGIVENPLACE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["TAKENGIVENPLACE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Descriptions
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTIONS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["DESCRIPTIONS"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public Guid? AccountingTerm
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ACCOUNTINGTERM"]);
                }
            }

            public Guid? StockAction
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKACTION"]);
                }
            }

            public GetDocumentRecordLogReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDocumentRecordLogReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDocumentRecordLogReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class CensusReportNQL_DocumentRecLogAllCensusFixes_Class : TTReportNqlObject 
        {
            public Guid? Stockactionobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKACTIONOBJECTID"]);
                }
            }

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

            public string TakenGivenPlace_Shadow
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TAKENGIVENPLACE_SHADOW"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["TAKENGIVENPLACE_SHADOW"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Descriptions
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTIONS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["DESCRIPTIONS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? DocumentDateTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTDATETIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["DOCUMENTDATETIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? DocumentRecordLogNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTRECORDLOGNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["DOCUMENTRECORDLOGNUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DocumentTransactionTypeEnum? DocumentTransactionType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTTRANSACTIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["DOCUMENTTRANSACTIONTYPE"].DataType;
                    return (DocumentTransactionTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public int? NumberOfRows
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NUMBEROFROWS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["NUMBEROFROWS"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string Subject
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUBJECT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["SUBJECT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string TakenGivenPlace
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TAKENGIVENPLACE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["TAKENGIVENPLACE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public MKYS_EButceTurEnum? BudgeType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BUDGETYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["BUDGETYPE"].DataType;
                    return (MKYS_EButceTurEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public int? ReceiptNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RECEIPTNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["RECEIPTNUMBER"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public MKYSControlEnum? MKYSStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYSSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["MKYSSTATUS"].DataType;
                    return (MKYSControlEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public CensusReportNQL_DocumentRecLogAllCensusFixes_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public CensusReportNQL_DocumentRecLogAllCensusFixes_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected CensusReportNQL_DocumentRecLogAllCensusFixes_Class() : base() { }
        }

        [Serializable] 

        public partial class CensusReportNQL_DocumentRecLogAllDeleteRecords_Class : TTReportNqlObject 
        {
            public Guid? Stockactionobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKACTIONOBJECTID"]);
                }
            }

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

            public string TakenGivenPlace_Shadow
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TAKENGIVENPLACE_SHADOW"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["TAKENGIVENPLACE_SHADOW"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Descriptions
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTIONS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["DESCRIPTIONS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? DocumentDateTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTDATETIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["DOCUMENTDATETIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? DocumentRecordLogNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTRECORDLOGNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["DOCUMENTRECORDLOGNUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DocumentTransactionTypeEnum? DocumentTransactionType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTTRANSACTIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["DOCUMENTTRANSACTIONTYPE"].DataType;
                    return (DocumentTransactionTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public int? NumberOfRows
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NUMBEROFROWS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["NUMBEROFROWS"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string Subject
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUBJECT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["SUBJECT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string TakenGivenPlace
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TAKENGIVENPLACE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["TAKENGIVENPLACE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public MKYS_EButceTurEnum? BudgeType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BUDGETYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["BUDGETYPE"].DataType;
                    return (MKYS_EButceTurEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public int? ReceiptNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RECEIPTNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["RECEIPTNUMBER"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public MKYSControlEnum? MKYSStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYSSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["MKYSSTATUS"].DataType;
                    return (MKYSControlEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public CensusReportNQL_DocumentRecLogAllDeleteRecords_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public CensusReportNQL_DocumentRecLogAllDeleteRecords_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected CensusReportNQL_DocumentRecLogAllDeleteRecords_Class() : base() { }
        }

        [Serializable] 

        public partial class SearchDocumentRecordLogRQ_Class : TTReportNqlObject 
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

            public string Descriptions
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTIONS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["DESCRIPTIONS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? DocumentDateTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTDATETIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["DOCUMENTDATETIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? DocumentRecordLogNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTRECORDLOGNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["DOCUMENTRECORDLOGNUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DocumentTransactionTypeEnum? DocumentTransactionType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTTRANSACTIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["DOCUMENTTRANSACTIONTYPE"].DataType;
                    return (DocumentTransactionTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public int? NumberOfRows
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NUMBEROFROWS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["NUMBEROFROWS"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string Subject
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUBJECT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["SUBJECT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string TakenGivenPlace
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TAKENGIVENPLACE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["TAKENGIVENPLACE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ObjectDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTDEFID"]);
                }
            }

            public SearchDocumentRecordLogRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public SearchDocumentRecordLogRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected SearchDocumentRecordLogRQ_Class() : base() { }
        }

        [Serializable] 

        public partial class CensusReportNQL_DocumentRecLogAllCensusFixesInOut_Class : TTReportNqlObject 
        {
            public Guid? Stockactionobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKACTIONOBJECTID"]);
                }
            }

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

            public string TakenGivenPlace_Shadow
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TAKENGIVENPLACE_SHADOW"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["TAKENGIVENPLACE_SHADOW"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Descriptions
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTIONS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["DESCRIPTIONS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? DocumentDateTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTDATETIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["DOCUMENTDATETIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? DocumentRecordLogNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTRECORDLOGNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["DOCUMENTRECORDLOGNUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DocumentTransactionTypeEnum? DocumentTransactionType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTTRANSACTIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["DOCUMENTTRANSACTIONTYPE"].DataType;
                    return (DocumentTransactionTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public int? NumberOfRows
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NUMBEROFROWS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["NUMBEROFROWS"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string Subject
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUBJECT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["SUBJECT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string TakenGivenPlace
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TAKENGIVENPLACE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["TAKENGIVENPLACE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public MKYS_EButceTurEnum? BudgeType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BUDGETYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["BUDGETYPE"].DataType;
                    return (MKYS_EButceTurEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public int? ReceiptNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RECEIPTNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["RECEIPTNUMBER"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public MKYSControlEnum? MKYSStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYSSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["MKYSSTATUS"].DataType;
                    return (MKYSControlEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public CensusReportNQL_DocumentRecLogAllCensusFixesInOut_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public CensusReportNQL_DocumentRecLogAllCensusFixesInOut_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected CensusReportNQL_DocumentRecLogAllCensusFixesInOut_Class() : base() { }
        }

        [Serializable] 

        public partial class CensusReportNQL_DocRecLogByInOutIncludeCancels_Class : TTReportNqlObject 
        {
            public Guid? Stockactionobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKACTIONOBJECTID"]);
                }
            }

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

            public string TakenGivenPlace_Shadow
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TAKENGIVENPLACE_SHADOW"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["TAKENGIVENPLACE_SHADOW"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Descriptions
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTIONS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["DESCRIPTIONS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? DocumentDateTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTDATETIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["DOCUMENTDATETIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? DocumentRecordLogNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTRECORDLOGNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["DOCUMENTRECORDLOGNUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DocumentTransactionTypeEnum? DocumentTransactionType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTTRANSACTIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["DOCUMENTTRANSACTIONTYPE"].DataType;
                    return (DocumentTransactionTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public int? NumberOfRows
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NUMBEROFROWS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["NUMBEROFROWS"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string Subject
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUBJECT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["SUBJECT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string TakenGivenPlace
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TAKENGIVENPLACE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["TAKENGIVENPLACE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public MKYS_EButceTurEnum? BudgeType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BUDGETYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["BUDGETYPE"].DataType;
                    return (MKYS_EButceTurEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public int? ReceiptNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RECEIPTNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["RECEIPTNUMBER"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public MKYSControlEnum? MKYSStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYSSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["MKYSSTATUS"].DataType;
                    return (MKYSControlEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public CensusReportNQL_DocRecLogByInOutIncludeCancels_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public CensusReportNQL_DocRecLogByInOutIncludeCancels_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected CensusReportNQL_DocRecLogByInOutIncludeCancels_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDocumentRecordLogToMkysIntegration_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? DocumentRecordLogNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTRECORDLOGNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["DOCUMENTRECORDLOGNUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? DocumentDateTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTDATETIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["DOCUMENTDATETIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DocumentTransactionTypeEnum? DocumentTransactionType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTTRANSACTIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["DOCUMENTTRANSACTIONTYPE"].DataType;
                    return (DocumentTransactionTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Subject
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUBJECT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["SUBJECT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? NumberOfRows
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NUMBEROFROWS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["NUMBEROFROWS"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string TakenGivenPlace
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TAKENGIVENPLACE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["TAKENGIVENPLACE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Descriptions
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTIONS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["DESCRIPTIONS"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public Guid? AccountingTerm
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ACCOUNTINGTERM"]);
                }
            }

            public Guid? StockAction
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKACTION"]);
                }
            }

            public int? ReceiptNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RECEIPTNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["RECEIPTNUMBER"].DataType;
                    return (int?)dataType.ConvertValue(val);
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

            public MKYSControlEnum? MKYSStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYSSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["MKYSSTATUS"].DataType;
                    return (MKYSControlEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public MKYS_EButceTurEnum? BudgeType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BUDGETYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["BUDGETYPE"].DataType;
                    return (MKYS_EButceTurEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GetDocumentRecordLogToMkysIntegration_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDocumentRecordLogToMkysIntegration_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDocumentRecordLogToMkysIntegration_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDocumentRecordLogsByDate_Class : TTReportNqlObject 
        {
            public int? ReceiptNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RECEIPTNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["RECEIPTNUMBER"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public long? DocumentRecordLogNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTRECORDLOGNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["DOCUMENTRECORDLOGNUMBER"].DataType;
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

            public string Desciption
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["SUBJECT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DocumentTransactionTypeEnum? DocumentTransactionType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTTRANSACTIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["DOCUMENTTRANSACTIONTYPE"].DataType;
                    return (DocumentTransactionTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public Guid? Stockactionobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKACTIONOBJECTID"]);
                }
            }

            public MKYSControlEnum? MKYSStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYSSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["MKYSSTATUS"].DataType;
                    return (MKYSControlEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GetDocumentRecordLogsByDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDocumentRecordLogsByDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDocumentRecordLogsByDate_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDocumentRecordLogToMkysIntegrationComp_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? DocumentRecordLogNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTRECORDLOGNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["DOCUMENTRECORDLOGNUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? DocumentDateTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTDATETIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["DOCUMENTDATETIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DocumentTransactionTypeEnum? DocumentTransactionType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTTRANSACTIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["DOCUMENTTRANSACTIONTYPE"].DataType;
                    return (DocumentTransactionTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Subject
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUBJECT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["SUBJECT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? NumberOfRows
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NUMBEROFROWS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["NUMBEROFROWS"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string TakenGivenPlace
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TAKENGIVENPLACE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["TAKENGIVENPLACE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Descriptions
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTIONS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["DESCRIPTIONS"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public Guid? AccountingTerm
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ACCOUNTINGTERM"]);
                }
            }

            public Guid? StockAction
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKACTION"]);
                }
            }

            public int? ReceiptNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RECEIPTNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["RECEIPTNUMBER"].DataType;
                    return (int?)dataType.ConvertValue(val);
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

            public MKYSControlEnum? MKYSStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYSSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["MKYSSTATUS"].DataType;
                    return (MKYSControlEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public MKYS_EButceTurEnum? BudgeType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BUDGETYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["BUDGETYPE"].DataType;
                    return (MKYS_EButceTurEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GetDocumentRecordLogToMkysIntegrationComp_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDocumentRecordLogToMkysIntegrationComp_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDocumentRecordLogToMkysIntegrationComp_Class() : base() { }
        }

        [Serializable] 

        public partial class GetTifNumber_Class : TTReportNqlObject 
        {
            public long? DocumentRecordLogNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTRECORDLOGNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["DOCUMENTRECORDLOGNUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public GetTifNumber_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetTifNumber_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetTifNumber_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDocumentRecordLogByTrxType_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? DocumentRecordLogNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTRECORDLOGNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["DOCUMENTRECORDLOGNUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string TakenGivenPlace
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TAKENGIVENPLACE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["TAKENGIVENPLACE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Subject
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUBJECT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["SUBJECT"].DataType;
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

            public MKYSControlEnum? MKYSStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYSSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["MKYSSTATUS"].DataType;
                    return (MKYSControlEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public Guid? Stockactionid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKACTIONID"]);
                }
            }

            public Guid? Stockactiondefid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKACTIONDEFID"]);
                }
            }

            public MKYS_EButceTurEnum? BudgeType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BUDGETYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].AllPropertyDefs["BUDGETYPE"].DataType;
                    return (MKYS_EButceTurEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GetDocumentRecordLogByTrxType_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDocumentRecordLogByTrxType_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDocumentRecordLogByTrxType_Class() : base() { }
        }

        public static class States
        {
            public static Guid Cancelled { get { return new Guid("c3d9b988-6499-4b61-91a2-0ba952e85073"); } }
            public static Guid Completed { get { return new Guid("3b010539-5e37-475a-856f-c0c537f5d7dd"); } }
            public static Guid New { get { return new Guid("1bd032eb-53ac-4020-a3f9-50bb21fd24b6"); } }
        }

        public static BindingList<DocumentRecordLog.CensusReportNQL_DocumentRecLogByObjectDef_Class> CensusReportNQL_DocumentRecLogByObjectDef(string TERMID, string OBJECTDEFID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].QueryDefs["CensusReportNQL_DocumentRecLogByObjectDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERMID", TERMID);
            paramList.Add("OBJECTDEFID", OBJECTDEFID);

            return TTReportNqlObject.QueryObjects<DocumentRecordLog.CensusReportNQL_DocumentRecLogByObjectDef_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DocumentRecordLog.CensusReportNQL_DocumentRecLogByObjectDef_Class> CensusReportNQL_DocumentRecLogByObjectDef(TTObjectContext objectContext, string TERMID, string OBJECTDEFID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].QueryDefs["CensusReportNQL_DocumentRecLogByObjectDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERMID", TERMID);
            paramList.Add("OBJECTDEFID", OBJECTDEFID);

            return TTReportNqlObject.QueryObjects<DocumentRecordLog.CensusReportNQL_DocumentRecLogByObjectDef_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DocumentRecordLog.GetDocumentRecordLogReportQuery_Class> GetDocumentRecordLogReportQuery(Guid ACCOUNTINGTERMID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].QueryDefs["GetDocumentRecordLogReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ACCOUNTINGTERMID", ACCOUNTINGTERMID);

            return TTReportNqlObject.QueryObjects<DocumentRecordLog.GetDocumentRecordLogReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DocumentRecordLog.GetDocumentRecordLogReportQuery_Class> GetDocumentRecordLogReportQuery(TTObjectContext objectContext, Guid ACCOUNTINGTERMID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].QueryDefs["GetDocumentRecordLogReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ACCOUNTINGTERMID", ACCOUNTINGTERMID);

            return TTReportNqlObject.QueryObjects<DocumentRecordLog.GetDocumentRecordLogReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DocumentRecordLog.CensusReportNQL_DocumentRecLogAllCensusFixes_Class> CensusReportNQL_DocumentRecLogAllCensusFixes(string TERMID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].QueryDefs["CensusReportNQL_DocumentRecLogAllCensusFixes"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERMID", TERMID);

            return TTReportNqlObject.QueryObjects<DocumentRecordLog.CensusReportNQL_DocumentRecLogAllCensusFixes_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DocumentRecordLog.CensusReportNQL_DocumentRecLogAllCensusFixes_Class> CensusReportNQL_DocumentRecLogAllCensusFixes(TTObjectContext objectContext, string TERMID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].QueryDefs["CensusReportNQL_DocumentRecLogAllCensusFixes"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERMID", TERMID);

            return TTReportNqlObject.QueryObjects<DocumentRecordLog.CensusReportNQL_DocumentRecLogAllCensusFixes_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DocumentRecordLog.CensusReportNQL_DocumentRecLogAllDeleteRecords_Class> CensusReportNQL_DocumentRecLogAllDeleteRecords(string TERMID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].QueryDefs["CensusReportNQL_DocumentRecLogAllDeleteRecords"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERMID", TERMID);

            return TTReportNqlObject.QueryObjects<DocumentRecordLog.CensusReportNQL_DocumentRecLogAllDeleteRecords_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DocumentRecordLog.CensusReportNQL_DocumentRecLogAllDeleteRecords_Class> CensusReportNQL_DocumentRecLogAllDeleteRecords(TTObjectContext objectContext, string TERMID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].QueryDefs["CensusReportNQL_DocumentRecLogAllDeleteRecords"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERMID", TERMID);

            return TTReportNqlObject.QueryObjects<DocumentRecordLog.CensusReportNQL_DocumentRecLogAllDeleteRecords_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DocumentRecordLog.SearchDocumentRecordLogRQ_Class> SearchDocumentRecordLogRQ(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].QueryDefs["SearchDocumentRecordLogRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DocumentRecordLog.SearchDocumentRecordLogRQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DocumentRecordLog.SearchDocumentRecordLogRQ_Class> SearchDocumentRecordLogRQ(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].QueryDefs["SearchDocumentRecordLogRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DocumentRecordLog.SearchDocumentRecordLogRQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DocumentRecordLog.CensusReportNQL_DocumentRecLogAllCensusFixesInOut_Class> CensusReportNQL_DocumentRecLogAllCensusFixesInOut(string TERMID, int INOUT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].QueryDefs["CensusReportNQL_DocumentRecLogAllCensusFixesInOut"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERMID", TERMID);
            paramList.Add("INOUT", INOUT);

            return TTReportNqlObject.QueryObjects<DocumentRecordLog.CensusReportNQL_DocumentRecLogAllCensusFixesInOut_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DocumentRecordLog.CensusReportNQL_DocumentRecLogAllCensusFixesInOut_Class> CensusReportNQL_DocumentRecLogAllCensusFixesInOut(TTObjectContext objectContext, string TERMID, int INOUT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].QueryDefs["CensusReportNQL_DocumentRecLogAllCensusFixesInOut"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERMID", TERMID);
            paramList.Add("INOUT", INOUT);

            return TTReportNqlObject.QueryObjects<DocumentRecordLog.CensusReportNQL_DocumentRecLogAllCensusFixesInOut_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DocumentRecordLog.CensusReportNQL_DocRecLogByInOutIncludeCancels_Class> CensusReportNQL_DocRecLogByInOutIncludeCancels(string TERMID, string TRANSACTIONTYPE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].QueryDefs["CensusReportNQL_DocRecLogByInOutIncludeCancels"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERMID", TERMID);
            paramList.Add("TRANSACTIONTYPE", TRANSACTIONTYPE);

            return TTReportNqlObject.QueryObjects<DocumentRecordLog.CensusReportNQL_DocRecLogByInOutIncludeCancels_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DocumentRecordLog.CensusReportNQL_DocRecLogByInOutIncludeCancels_Class> CensusReportNQL_DocRecLogByInOutIncludeCancels(TTObjectContext objectContext, string TERMID, string TRANSACTIONTYPE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].QueryDefs["CensusReportNQL_DocRecLogByInOutIncludeCancels"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERMID", TERMID);
            paramList.Add("TRANSACTIONTYPE", TRANSACTIONTYPE);

            return TTReportNqlObject.QueryObjects<DocumentRecordLog.CensusReportNQL_DocRecLogByInOutIncludeCancels_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DocumentRecordLog.GetDocumentRecordLogToMkysIntegration_Class> GetDocumentRecordLogToMkysIntegration(Guid ACCOUNTINGTERMID, Guid STORE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].QueryDefs["GetDocumentRecordLogToMkysIntegration"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ACCOUNTINGTERMID", ACCOUNTINGTERMID);
            paramList.Add("STORE", STORE);

            return TTReportNqlObject.QueryObjects<DocumentRecordLog.GetDocumentRecordLogToMkysIntegration_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DocumentRecordLog.GetDocumentRecordLogToMkysIntegration_Class> GetDocumentRecordLogToMkysIntegration(TTObjectContext objectContext, Guid ACCOUNTINGTERMID, Guid STORE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].QueryDefs["GetDocumentRecordLogToMkysIntegration"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ACCOUNTINGTERMID", ACCOUNTINGTERMID);
            paramList.Add("STORE", STORE);

            return TTReportNqlObject.QueryObjects<DocumentRecordLog.GetDocumentRecordLogToMkysIntegration_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DocumentRecordLog.GetDocumentRecordLogsByDate_Class> GetDocumentRecordLogsByDate(DateTime ENDDATE, DateTime STARTDATE, string STOREID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].QueryDefs["GetDocumentRecordLogsByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("STOREID", STOREID);

            return TTReportNqlObject.QueryObjects<DocumentRecordLog.GetDocumentRecordLogsByDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DocumentRecordLog.GetDocumentRecordLogsByDate_Class> GetDocumentRecordLogsByDate(TTObjectContext objectContext, DateTime ENDDATE, DateTime STARTDATE, string STOREID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].QueryDefs["GetDocumentRecordLogsByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("STOREID", STOREID);

            return TTReportNqlObject.QueryObjects<DocumentRecordLog.GetDocumentRecordLogsByDate_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DocumentRecordLog.GetDocumentRecordLogToMkysIntegrationComp_Class> GetDocumentRecordLogToMkysIntegrationComp(Guid ACCOUNTINGTERMID, Guid STORE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].QueryDefs["GetDocumentRecordLogToMkysIntegrationComp"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ACCOUNTINGTERMID", ACCOUNTINGTERMID);
            paramList.Add("STORE", STORE);

            return TTReportNqlObject.QueryObjects<DocumentRecordLog.GetDocumentRecordLogToMkysIntegrationComp_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DocumentRecordLog.GetDocumentRecordLogToMkysIntegrationComp_Class> GetDocumentRecordLogToMkysIntegrationComp(TTObjectContext objectContext, Guid ACCOUNTINGTERMID, Guid STORE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].QueryDefs["GetDocumentRecordLogToMkysIntegrationComp"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ACCOUNTINGTERMID", ACCOUNTINGTERMID);
            paramList.Add("STORE", STORE);

            return TTReportNqlObject.QueryObjects<DocumentRecordLog.GetDocumentRecordLogToMkysIntegrationComp_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DocumentRecordLog.GetTifNumber_Class> GetTifNumber(Guid StockActionID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].QueryDefs["GetTifNumber"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKACTIONID", StockActionID);

            return TTReportNqlObject.QueryObjects<DocumentRecordLog.GetTifNumber_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DocumentRecordLog.GetTifNumber_Class> GetTifNumber(TTObjectContext objectContext, Guid StockActionID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].QueryDefs["GetTifNumber"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKACTIONID", StockActionID);

            return TTReportNqlObject.QueryObjects<DocumentRecordLog.GetTifNumber_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DocumentRecordLog.GetDocumentRecordLogByTrxType_Class> GetDocumentRecordLogByTrxType(Guid STOREID, DateTime STARTDATE, DateTime ENDDATE, long TRANSACTIONTYPE, long STARTTIFNO, long ENDTIFNO, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].QueryDefs["GetDocumentRecordLogByTrxType"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("TRANSACTIONTYPE", TRANSACTIONTYPE);
            paramList.Add("STARTTIFNO", STARTTIFNO);
            paramList.Add("ENDTIFNO", ENDTIFNO);

            return TTReportNqlObject.QueryObjects<DocumentRecordLog.GetDocumentRecordLogByTrxType_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DocumentRecordLog.GetDocumentRecordLogByTrxType_Class> GetDocumentRecordLogByTrxType(TTObjectContext objectContext, Guid STOREID, DateTime STARTDATE, DateTime ENDDATE, long TRANSACTIONTYPE, long STARTTIFNO, long ENDTIFNO, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTRECORDLOG"].QueryDefs["GetDocumentRecordLogByTrxType"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("TRANSACTIONTYPE", TRANSACTIONTYPE);
            paramList.Add("STARTTIFNO", STARTTIFNO);
            paramList.Add("ENDTIFNO", ENDTIFNO);

            return TTReportNqlObject.QueryObjects<DocumentRecordLog.GetDocumentRecordLogByTrxType_Class>(objectContext, queryDef, paramList, pi);
        }

        public string TakenGivenPlace_Shadow
        {
            get { return (string)this["TAKENGIVENPLACE_SHADOW"]; }
        }

        public string Descriptions
        {
            get { return (string)this["DESCRIPTIONS"]; }
            set { this["DESCRIPTIONS"] = value; }
        }

        public DateTime? DocumentDateTime
        {
            get { return (DateTime?)this["DOCUMENTDATETIME"]; }
            set { this["DOCUMENTDATETIME"] = value; }
        }

        public long? DocumentRecordLogNumber
        {
            get { return (long?)this["DOCUMENTRECORDLOGNUMBER"]; }
            set { this["DOCUMENTRECORDLOGNUMBER"] = value; }
        }

        public DocumentTransactionTypeEnum? DocumentTransactionType
        {
            get { return (DocumentTransactionTypeEnum?)(int?)this["DOCUMENTTRANSACTIONTYPE"]; }
            set { this["DOCUMENTTRANSACTIONTYPE"] = value; }
        }

        public int? NumberOfRows
        {
            get { return (int?)this["NUMBEROFROWS"]; }
            set { this["NUMBEROFROWS"] = value; }
        }

        public string Subject
        {
            get { return (string)this["SUBJECT"]; }
            set { this["SUBJECT"] = value; }
        }

        public string TakenGivenPlace
        {
            get { return (string)this["TAKENGIVENPLACE"]; }
            set { this["TAKENGIVENPLACE"] = value; }
        }

    /// <summary>
    /// MKYS Bütçe Türü
    /// </summary>
        public MKYS_EButceTurEnum? BudgeType
        {
            get { return (MKYS_EButceTurEnum?)(int?)this["BUDGETYPE"]; }
            set { this["BUDGETYPE"] = value; }
        }

    /// <summary>
    /// MKYS Ayniyat Numarası
    /// </summary>
        public int? ReceiptNumber
        {
            get { return (int?)this["RECEIPTNUMBER"]; }
            set { this["RECEIPTNUMBER"] = value; }
        }

        public MKYSControlEnum? MKYSStatus
        {
            get { return (MKYSControlEnum?)(int?)this["MKYSSTATUS"]; }
            set { this["MKYSSTATUS"] = value; }
        }

        public StockAction StockAction
        {
            get { return (StockAction)((ITTObject)this).GetParent("STOCKACTION"); }
            set { this["STOCKACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DocumentRecordLog(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DocumentRecordLog(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DocumentRecordLog(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DocumentRecordLog(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DocumentRecordLog(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DOCUMENTRECORDLOG", dataRow) { }
        protected DocumentRecordLog(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DOCUMENTRECORDLOG", dataRow, isImported) { }
        public DocumentRecordLog(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DocumentRecordLog(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DocumentRecordLog() : base() { }

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