
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="KSchedule")] 

    /// <summary>
    /// Günlük İlaç Çizelgesi
    /// </summary>
    public  partial class KSchedule : StockAction, IStockOutTransaction, ICheckStockActionOutDetail, IStockReservation
    {
        public class KScheduleList : TTObjectCollection<KSchedule> { }
                    
        public class ChildKScheduleCollection : TTObject.TTChildObjectCollection<KSchedule>
        {
            public ChildKScheduleCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildKScheduleCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetKScheduleDrugPrescriptionTotalReportQuery_Class : TTReportNqlObject 
        {
            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
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

            public Object Amount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["AMOUNT"]);
                }
            }

            public GetKScheduleDrugPrescriptionTotalReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetKScheduleDrugPrescriptionTotalReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetKScheduleDrugPrescriptionTotalReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetQuarantineNOForKScheduleQuery_Class : TTReportNqlObject 
        {
            public string QuarantinaNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QUARANTINANO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["KSCHEDULEMATERIAL"].AllPropertyDefs["QUARANTINANO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetQuarantineNOForKScheduleQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetQuarantineNOForKScheduleQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetQuarantineNOForKScheduleQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetQuaratineNOQuery_Class : TTReportNqlObject 
        {
            public string QuarantinaNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QUARANTINANO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["KSCHEDULEMATERIAL"].AllPropertyDefs["QUARANTINANO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetQuaratineNOQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetQuaratineNOQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetQuaratineNOQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetCompletedKSchedulePatienOwnDrugByEpisode_Class : TTReportNqlObject 
        {
            public long? StockActionID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STOCKACTIONID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["KSCHEDULE"].AllPropertyDefs["STOCKACTIONID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? TransactionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TRANSACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["KSCHEDULE"].AllPropertyDefs["TRANSACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Barcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BARCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["BARCODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
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

            public GetCompletedKSchedulePatienOwnDrugByEpisode_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetCompletedKSchedulePatienOwnDrugByEpisode_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetCompletedKSchedulePatienOwnDrugByEpisode_Class() : base() { }
        }

        [Serializable] 

        public partial class GetKScheduleReportQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
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

            public string Destinationstore
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESTINATIONSTORE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STORE"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? StartDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STARTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["KSCHEDULE"].AllPropertyDefs["STARTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["KSCHEDULE"].AllPropertyDefs["ENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Material
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Materialid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIALID"]);
                }
            }

            public Object Amount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["AMOUNT"]);
                }
            }

            public string Transactiondate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TRANSACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? StockActionID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STOCKACTIONID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["KSCHEDULE"].AllPropertyDefs["STOCKACTIONID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Patientname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Sex
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SEX"]);
                }
            }

            public Guid? Patientobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PATIENTOBJECTID"]);
                }
            }

            public string Surname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SURNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? UniqueRefNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNIQUEREFNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["UNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string FatherName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FATHERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["FATHERNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Sex1
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SEX1"]);
                }
            }

            public DateTime? BirthDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIRTHDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["BIRTHDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Townname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOWNNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TOWNDEFINITIONS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public PatientStatusEnum? PatientStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["PATIENTSTATUS"].DataType;
                    return (PatientStatusEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GetKScheduleReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetKScheduleReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetKScheduleReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class KScheduleMaterialBarcodeRQ_Class : TTReportNqlObject 
        {
            public string Namesurname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAMESURNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["KSCHEDULEMATERIAL"].AllPropertyDefs["PATIENTNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string PatientID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["KSCHEDULEMATERIAL"].AllPropertyDefs["PATIENTID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Quarantiano
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QUARANTIANO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["KSCHEDULEMATERIAL"].AllPropertyDefs["QUARANTINANO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Material
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Materialid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIALID"]);
                }
            }

            public long? StockActionID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STOCKACTIONID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["KSCHEDULE"].AllPropertyDefs["STOCKACTIONID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public KScheduleMaterialBarcodeRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public KScheduleMaterialBarcodeRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected KScheduleMaterialBarcodeRQ_Class() : base() { }
        }

        [Serializable] 

        public partial class GetKScheduleWithPatient_Class : TTReportNqlObject 
        {
            public Guid? Patient
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PATIENT"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Barcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BARCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["BARCODE"].DataType;
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

            public DateTime? ExpirationDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXPIRATIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].AllPropertyDefs["EXPIRATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? TransactionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TRANSACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["KSCHEDULE"].AllPropertyDefs["TRANSACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? DistributionType
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DISTRIBUTIONTYPE"]);
                }
            }

            public Object Amount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["AMOUNT"]);
                }
            }

            public GetKScheduleWithPatient_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetKScheduleWithPatient_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetKScheduleWithPatient_Class() : base() { }
        }

        [Serializable] 

        public partial class GetKScheduleDrugPrescriptionTotalMainQuery_Class : TTReportNqlObject 
        {
            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Barcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BARCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["BARCODE"].DataType;
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

            public Object Amount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["AMOUNT"]);
                }
            }

            public GetKScheduleDrugPrescriptionTotalMainQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetKScheduleDrugPrescriptionTotalMainQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetKScheduleDrugPrescriptionTotalMainQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetCompletedKScheduleMaterialByEpisode_Class : TTReportNqlObject 
        {
            public long? StockActionID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STOCKACTIONID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["KSCHEDULE"].AllPropertyDefs["STOCKACTIONID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? TransactionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TRANSACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["KSCHEDULE"].AllPropertyDefs["TRANSACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Barcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BARCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["BARCODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
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

            public GetCompletedKScheduleMaterialByEpisode_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetCompletedKScheduleMaterialByEpisode_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetCompletedKScheduleMaterialByEpisode_Class() : base() { }
        }

        [Serializable] 

        public partial class GetKscheduleMaterialsGroupByPatientAndExpDate_Class : TTReportNqlObject 
        {
            public Guid? Patient
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PATIENT"]);
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

            public string Barcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BARCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["BARCODE"].DataType;
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

            public DateTime? ExpirationDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXPIRATIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].AllPropertyDefs["EXPIRATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? DrugOrderObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DRUGORDEROBJECTID"]);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Object Amount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["AMOUNT"]);
                }
            }

            public GetKscheduleMaterialsGroupByPatientAndExpDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetKscheduleMaterialsGroupByPatientAndExpDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetKscheduleMaterialsGroupByPatientAndExpDate_Class() : base() { }
        }

        [Serializable] 

        public partial class GetKScheduleWithPatientNotComplated_Class : TTReportNqlObject 
        {
            public Guid? Patient
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PATIENT"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Barcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BARCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["BARCODE"].DataType;
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

            public DateTime? ExpirationDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXPIRATIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].AllPropertyDefs["EXPIRATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? TransactionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TRANSACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["KSCHEDULE"].AllPropertyDefs["TRANSACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? DistributionType
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DISTRIBUTIONTYPE"]);
                }
            }

            public Object Amount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["AMOUNT"]);
                }
            }

            public GetKScheduleWithPatientNotComplated_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetKScheduleWithPatientNotComplated_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetKScheduleWithPatientNotComplated_Class() : base() { }
        }

        [Serializable] 

        public partial class GetKScheduleDrugPrescriptionTotalMainQueryNotComp_Class : TTReportNqlObject 
        {
            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Barcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BARCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["BARCODE"].DataType;
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

            public Object Amount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["AMOUNT"]);
                }
            }

            public GetKScheduleDrugPrescriptionTotalMainQueryNotComp_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetKScheduleDrugPrescriptionTotalMainQueryNotComp_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetKScheduleDrugPrescriptionTotalMainQueryNotComp_Class() : base() { }
        }

        [Serializable] 

        public partial class GetOutPlace_Class : TTReportNqlObject 
        {
            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Surname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SURNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetOutPlace_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOutPlace_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOutPlace_Class() : base() { }
        }

        [Serializable] 

        public partial class GetKScheduleReportByParameter_Class : TTReportNqlObject 
        {
            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["KSCHEDULE"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Barcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BARCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["BARCODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Patientname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTNAME"]);
                }
            }

            public string Masterresource
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MASTERRESOURCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MKYS_TeslimAlan
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_TESLIMALAN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["KSCHEDULE"].AllPropertyDefs["MKYS_TESLIMALAN"].DataType;
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

            public GetKScheduleReportByParameter_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetKScheduleReportByParameter_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetKScheduleReportByParameter_Class() : base() { }
        }

        new public static class States
        {
    /// <summary>
    /// Belge Kayıt
    /// </summary>
            public static Guid New { get { return new Guid("2dc13622-ea16-4999-a45b-289d6b47bad0"); } }
    /// <summary>
    /// İstek Hazırlama
    /// </summary>
            public static Guid RequestPreparation { get { return new Guid("ea15aaaa-7a1c-43b0-a0e9-6df1c7db73b5"); } }
    /// <summary>
    /// İstek Karşılandı
    /// </summary>
            public static Guid RequestFulfilled { get { return new Guid("ca4b60ca-6051-4174-9d73-c63648b16be5"); } }
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("a3937597-6638-47b0-a6dc-b2b8ee8688c7"); } }
    /// <summary>
    /// Onay
    /// </summary>
            public static Guid Approval { get { return new Guid("2261e88b-4395-43b8-a3e5-935b61bdade4"); } }
    /// <summary>
    /// Enfeksiyon Komitesi Onay
    /// </summary>
            public static Guid InfectionApproval { get { return new Guid("fa0b4eab-f0fc-4744-ae8d-a288be0560e4"); } }
    /// <summary>
    /// MKYS
    /// </summary>
            public static Guid MKYS { get { return new Guid("cc2f6fd8-41db-4e4e-960c-8eff7cc4dffb"); } }
        }

    /// <summary>
    /// .
    /// </summary>
        public static BindingList<KSchedule.GetKScheduleDrugPrescriptionTotalReportQuery_Class> GetKScheduleDrugPrescriptionTotalReportQuery(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["KSCHEDULE"].QueryDefs["GetKScheduleDrugPrescriptionTotalReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<KSchedule.GetKScheduleDrugPrescriptionTotalReportQuery_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// .
    /// </summary>
        public static BindingList<KSchedule.GetKScheduleDrugPrescriptionTotalReportQuery_Class> GetKScheduleDrugPrescriptionTotalReportQuery(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["KSCHEDULE"].QueryDefs["GetKScheduleDrugPrescriptionTotalReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<KSchedule.GetKScheduleDrugPrescriptionTotalReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<KSchedule> GetKSchedule(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, string STORE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["KSCHEDULE"].QueryDefs["GetKSchedule"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STORE", STORE);

            return ((ITTQuery)objectContext).QueryObjects<KSchedule>(queryDef, paramList);
        }

        public static BindingList<KSchedule.GetQuarantineNOForKScheduleQuery_Class> GetQuarantineNOForKScheduleQuery(Guid TTOBJECTID, Guid MATERIALID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["KSCHEDULE"].QueryDefs["GetQuarantineNOForKScheduleQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);
            paramList.Add("MATERIALID", MATERIALID);

            return TTReportNqlObject.QueryObjects<KSchedule.GetQuarantineNOForKScheduleQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<KSchedule.GetQuarantineNOForKScheduleQuery_Class> GetQuarantineNOForKScheduleQuery(TTObjectContext objectContext, Guid TTOBJECTID, Guid MATERIALID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["KSCHEDULE"].QueryDefs["GetQuarantineNOForKScheduleQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);
            paramList.Add("MATERIALID", MATERIALID);

            return TTReportNqlObject.QueryObjects<KSchedule.GetQuarantineNOForKScheduleQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<KSchedule.GetQuaratineNOQuery_Class> GetQuaratineNOQuery(DateTime DATE, string NATOSTOCKNO, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["KSCHEDULE"].QueryDefs["GetQuaratineNOQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DATE", DATE);
            paramList.Add("NATOSTOCKNO", NATOSTOCKNO);

            return TTReportNqlObject.QueryObjects<KSchedule.GetQuaratineNOQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<KSchedule.GetQuaratineNOQuery_Class> GetQuaratineNOQuery(TTObjectContext objectContext, DateTime DATE, string NATOSTOCKNO, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["KSCHEDULE"].QueryDefs["GetQuaratineNOQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DATE", DATE);
            paramList.Add("NATOSTOCKNO", NATOSTOCKNO);

            return TTReportNqlObject.QueryObjects<KSchedule.GetQuaratineNOQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<KSchedule.GetCompletedKSchedulePatienOwnDrugByEpisode_Class> GetCompletedKSchedulePatienOwnDrugByEpisode(Guid EPISODEID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["KSCHEDULE"].QueryDefs["GetCompletedKSchedulePatienOwnDrugByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEID", EPISODEID);

            return TTReportNqlObject.QueryObjects<KSchedule.GetCompletedKSchedulePatienOwnDrugByEpisode_Class>(queryDef, paramList, pi);
        }

        public static BindingList<KSchedule.GetCompletedKSchedulePatienOwnDrugByEpisode_Class> GetCompletedKSchedulePatienOwnDrugByEpisode(TTObjectContext objectContext, Guid EPISODEID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["KSCHEDULE"].QueryDefs["GetCompletedKSchedulePatienOwnDrugByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEID", EPISODEID);

            return TTReportNqlObject.QueryObjects<KSchedule.GetCompletedKSchedulePatienOwnDrugByEpisode_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<KSchedule.GetKScheduleReportQuery_Class> GetKScheduleReportQuery(Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["KSCHEDULE"].QueryDefs["GetKScheduleReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<KSchedule.GetKScheduleReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<KSchedule.GetKScheduleReportQuery_Class> GetKScheduleReportQuery(TTObjectContext objectContext, Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["KSCHEDULE"].QueryDefs["GetKScheduleReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<KSchedule.GetKScheduleReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<KSchedule.KScheduleMaterialBarcodeRQ_Class> KScheduleMaterialBarcodeRQ(Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["KSCHEDULE"].QueryDefs["KScheduleMaterialBarcodeRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<KSchedule.KScheduleMaterialBarcodeRQ_Class>(queryDef, paramList, pi);
        }

        public static BindingList<KSchedule.KScheduleMaterialBarcodeRQ_Class> KScheduleMaterialBarcodeRQ(TTObjectContext objectContext, Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["KSCHEDULE"].QueryDefs["KScheduleMaterialBarcodeRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<KSchedule.KScheduleMaterialBarcodeRQ_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<KSchedule.GetKScheduleWithPatient_Class> GetKScheduleWithPatient(DateTime ENDDATE, DateTime STARTDATE, string STOREID, int STOREID_FLG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["KSCHEDULE"].QueryDefs["GetKScheduleWithPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("STOREID", STOREID);
            paramList.Add("STOREID_FLG", STOREID_FLG);

            return TTReportNqlObject.QueryObjects<KSchedule.GetKScheduleWithPatient_Class>(queryDef, paramList, pi);
        }

        public static BindingList<KSchedule.GetKScheduleWithPatient_Class> GetKScheduleWithPatient(TTObjectContext objectContext, DateTime ENDDATE, DateTime STARTDATE, string STOREID, int STOREID_FLG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["KSCHEDULE"].QueryDefs["GetKScheduleWithPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("STOREID", STOREID);
            paramList.Add("STOREID_FLG", STOREID_FLG);

            return TTReportNqlObject.QueryObjects<KSchedule.GetKScheduleWithPatient_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// KScheduleDrugPrescriptionTotalReport Yeni
    /// </summary>
        public static BindingList<KSchedule.GetKScheduleDrugPrescriptionTotalMainQuery_Class> GetKScheduleDrugPrescriptionTotalMainQuery(string STOREID, DateTime STARTDATE, DateTime ENDDATE, int STOREID_FLG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["KSCHEDULE"].QueryDefs["GetKScheduleDrugPrescriptionTotalMainQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STOREID_FLG", STOREID_FLG);

            return TTReportNqlObject.QueryObjects<KSchedule.GetKScheduleDrugPrescriptionTotalMainQuery_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// KScheduleDrugPrescriptionTotalReport Yeni
    /// </summary>
        public static BindingList<KSchedule.GetKScheduleDrugPrescriptionTotalMainQuery_Class> GetKScheduleDrugPrescriptionTotalMainQuery(TTObjectContext objectContext, string STOREID, DateTime STARTDATE, DateTime ENDDATE, int STOREID_FLG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["KSCHEDULE"].QueryDefs["GetKScheduleDrugPrescriptionTotalMainQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STOREID_FLG", STOREID_FLG);

            return TTReportNqlObject.QueryObjects<KSchedule.GetKScheduleDrugPrescriptionTotalMainQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<KSchedule.GetCompletedKScheduleMaterialByEpisode_Class> GetCompletedKScheduleMaterialByEpisode(Guid EPISODEID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["KSCHEDULE"].QueryDefs["GetCompletedKScheduleMaterialByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEID", EPISODEID);

            return TTReportNqlObject.QueryObjects<KSchedule.GetCompletedKScheduleMaterialByEpisode_Class>(queryDef, paramList, pi);
        }

        public static BindingList<KSchedule.GetCompletedKScheduleMaterialByEpisode_Class> GetCompletedKScheduleMaterialByEpisode(TTObjectContext objectContext, Guid EPISODEID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["KSCHEDULE"].QueryDefs["GetCompletedKScheduleMaterialByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEID", EPISODEID);

            return TTReportNqlObject.QueryObjects<KSchedule.GetCompletedKScheduleMaterialByEpisode_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Barkod için oluşturuldu
    /// </summary>
        public static BindingList<KSchedule.GetKscheduleMaterialsGroupByPatientAndExpDate_Class> GetKscheduleMaterialsGroupByPatientAndExpDate(IList<Guid> ActionIDList, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["KSCHEDULE"].QueryDefs["GetKscheduleMaterialsGroupByPatientAndExpDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ACTIONIDLIST", ActionIDList);

            return TTReportNqlObject.QueryObjects<KSchedule.GetKscheduleMaterialsGroupByPatientAndExpDate_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Barkod için oluşturuldu
    /// </summary>
        public static BindingList<KSchedule.GetKscheduleMaterialsGroupByPatientAndExpDate_Class> GetKscheduleMaterialsGroupByPatientAndExpDate(TTObjectContext objectContext, IList<Guid> ActionIDList, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["KSCHEDULE"].QueryDefs["GetKscheduleMaterialsGroupByPatientAndExpDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ACTIONIDLIST", ActionIDList);

            return TTReportNqlObject.QueryObjects<KSchedule.GetKscheduleMaterialsGroupByPatientAndExpDate_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<KSchedule.GetKScheduleWithPatientNotComplated_Class> GetKScheduleWithPatientNotComplated(DateTime ENDDATE, DateTime STARTDATE, string STOREID, int STOREID_FLG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["KSCHEDULE"].QueryDefs["GetKScheduleWithPatientNotComplated"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("STOREID", STOREID);
            paramList.Add("STOREID_FLG", STOREID_FLG);

            return TTReportNqlObject.QueryObjects<KSchedule.GetKScheduleWithPatientNotComplated_Class>(queryDef, paramList, pi);
        }

        public static BindingList<KSchedule.GetKScheduleWithPatientNotComplated_Class> GetKScheduleWithPatientNotComplated(TTObjectContext objectContext, DateTime ENDDATE, DateTime STARTDATE, string STOREID, int STOREID_FLG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["KSCHEDULE"].QueryDefs["GetKScheduleWithPatientNotComplated"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("STOREID", STOREID);
            paramList.Add("STOREID_FLG", STOREID_FLG);

            return TTReportNqlObject.QueryObjects<KSchedule.GetKScheduleWithPatientNotComplated_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<KSchedule> GetActiveKSchedule(TTObjectContext objectContext, Guid INPATIENTAPP, DateTime TRANSACTIONSTARTDATE, DateTime TRANSACTIONENDTDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["KSCHEDULE"].QueryDefs["GetActiveKSchedule"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("INPATIENTAPP", INPATIENTAPP);
            paramList.Add("TRANSACTIONSTARTDATE", TRANSACTIONSTARTDATE);
            paramList.Add("TRANSACTIONENDTDATE", TRANSACTIONENDTDATE);

            return ((ITTQuery)objectContext).QueryObjects<KSchedule>(queryDef, paramList);
        }

        public static BindingList<KSchedule.GetKScheduleDrugPrescriptionTotalMainQueryNotComp_Class> GetKScheduleDrugPrescriptionTotalMainQueryNotComp(DateTime ENDDATE, DateTime STARTDATE, string STOREID, int STOREID_FLG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["KSCHEDULE"].QueryDefs["GetKScheduleDrugPrescriptionTotalMainQueryNotComp"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("STOREID", STOREID);
            paramList.Add("STOREID_FLG", STOREID_FLG);

            return TTReportNqlObject.QueryObjects<KSchedule.GetKScheduleDrugPrescriptionTotalMainQueryNotComp_Class>(queryDef, paramList, pi);
        }

        public static BindingList<KSchedule.GetKScheduleDrugPrescriptionTotalMainQueryNotComp_Class> GetKScheduleDrugPrescriptionTotalMainQueryNotComp(TTObjectContext objectContext, DateTime ENDDATE, DateTime STARTDATE, string STOREID, int STOREID_FLG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["KSCHEDULE"].QueryDefs["GetKScheduleDrugPrescriptionTotalMainQueryNotComp"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("STOREID", STOREID);
            paramList.Add("STOREID_FLG", STOREID_FLG);

            return TTReportNqlObject.QueryObjects<KSchedule.GetKScheduleDrugPrescriptionTotalMainQueryNotComp_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<KSchedule.GetOutPlace_Class> GetOutPlace(Guid StockActionID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["KSCHEDULE"].QueryDefs["GetOutPlace"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKACTIONID", StockActionID);

            return TTReportNqlObject.QueryObjects<KSchedule.GetOutPlace_Class>(queryDef, paramList, pi);
        }

        public static BindingList<KSchedule.GetOutPlace_Class> GetOutPlace(TTObjectContext objectContext, Guid StockActionID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["KSCHEDULE"].QueryDefs["GetOutPlace"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKACTIONID", StockActionID);

            return TTReportNqlObject.QueryObjects<KSchedule.GetOutPlace_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<KSchedule.GetKScheduleReportByParameter_Class> GetKScheduleReportByParameter(DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["KSCHEDULE"].QueryDefs["GetKScheduleReportByParameter"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<KSchedule.GetKScheduleReportByParameter_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<KSchedule.GetKScheduleReportByParameter_Class> GetKScheduleReportByParameter(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["KSCHEDULE"].QueryDefs["GetKScheduleReportByParameter"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<KSchedule.GetKScheduleReportByParameter_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Bitiş Tarihi
    /// </summary>
        public DateTime? EndDate
        {
            get { return (DateTime?)this["ENDDATE"]; }
            set { this["ENDDATE"] = value; }
        }

    /// <summary>
    /// Başlangıç Tarihi
    /// </summary>
        public DateTime? StartDate
        {
            get { return (DateTime?)this["STARTDATE"]; }
            set { this["STARTDATE"] = value; }
        }

        public DailyDrugSchedule DailyDrugSchedule
        {
            get { return (DailyDrugSchedule)((ITTObject)this).GetParent("DAILYDRUGSCHEDULE"); }
            set { this["DAILYDRUGSCHEDULE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Episode Episode
        {
            get { return (Episode)((ITTObject)this).GetParent("EPISODE"); }
            set { this["EPISODE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public InPatientPhysicianApplication InPatientPhysicianApplication
        {
            get { return (InPatientPhysicianApplication)((ITTObject)this).GetParent("INPATIENTPHYSICIANAPPLICATION"); }
            set { this["INPATIENTPHYSICIANAPPLICATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateKScheduleUnListMaterialsCollection()
        {
            _KScheduleUnListMaterials = new KScheduleUnListMaterial.ChildKScheduleUnListMaterialCollection(this, new Guid("52332bb9-8ecf-45ed-b778-371cc3baaad1"));
            ((ITTChildObjectCollection)_KScheduleUnListMaterials).GetChildren();
        }

        protected KScheduleUnListMaterial.ChildKScheduleUnListMaterialCollection _KScheduleUnListMaterials = null;
        public KScheduleUnListMaterial.ChildKScheduleUnListMaterialCollection KScheduleUnListMaterials
        {
            get
            {
                if (_KScheduleUnListMaterials == null)
                    CreateKScheduleUnListMaterialsCollection();
                return _KScheduleUnListMaterials;
            }
        }

        virtual protected void CreateKSchedulePatienOwnDrugsCollection()
        {
            _KSchedulePatienOwnDrugs = new KSchedulePatienOwnDrug.ChildKSchedulePatienOwnDrugCollection(this, new Guid("b62b6684-18a9-4ade-8aae-f28da3d76a0a"));
            ((ITTChildObjectCollection)_KSchedulePatienOwnDrugs).GetChildren();
        }

        protected KSchedulePatienOwnDrug.ChildKSchedulePatienOwnDrugCollection _KSchedulePatienOwnDrugs = null;
        public KSchedulePatienOwnDrug.ChildKSchedulePatienOwnDrugCollection KSchedulePatienOwnDrugs
        {
            get
            {
                if (_KSchedulePatienOwnDrugs == null)
                    CreateKSchedulePatienOwnDrugsCollection();
                return _KSchedulePatienOwnDrugs;
            }
        }

        virtual protected void CreateKScheduleInfectionDrugsCollection()
        {
            _KScheduleInfectionDrugs = new KScheduleInfectionDrug.ChildKScheduleInfectionDrugCollection(this, new Guid("d4540c80-77bc-41e1-84ff-43339e25ba2c"));
            ((ITTChildObjectCollection)_KScheduleInfectionDrugs).GetChildren();
        }

        protected KScheduleInfectionDrug.ChildKScheduleInfectionDrugCollection _KScheduleInfectionDrugs = null;
        public KScheduleInfectionDrug.ChildKScheduleInfectionDrugCollection KScheduleInfectionDrugs
        {
            get
            {
                if (_KScheduleInfectionDrugs == null)
                    CreateKScheduleInfectionDrugsCollection();
                return _KScheduleInfectionDrugs;
            }
        }

        override protected void CreateStockActionDetailsCollectionViews()
        {
            base.CreateStockActionDetailsCollectionViews();
            _KScheduleMaterials = new KScheduleMaterial.ChildKScheduleMaterialCollection(_StockActionDetails, "KScheduleMaterials");
        }

        private KScheduleMaterial.ChildKScheduleMaterialCollection _KScheduleMaterials = null;
    /// <summary>
    /// Alt İşlemler
    /// </summary>
        public KScheduleMaterial.ChildKScheduleMaterialCollection KScheduleMaterials
        {
            get
            {
                if (_StockActionDetails == null)
                    CreateStockActionDetailsCollection();
                return _KScheduleMaterials;
            }            
        }

        protected KSchedule(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected KSchedule(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected KSchedule(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected KSchedule(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected KSchedule(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "KSCHEDULE", dataRow) { }
        protected KSchedule(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "KSCHEDULE", dataRow, isImported) { }
        public KSchedule(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public KSchedule(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public KSchedule() : base() { }

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