
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ExternalPharmacyPrescriptionTransaction")] 

    /// <summary>
    /// Diş Eczaneye Dağıtılmış Reçeteler 
    /// </summary>
    public  partial class ExternalPharmacyPrescriptionTransaction : TTObject
    {
        public class ExternalPharmacyPrescriptionTransactionList : TTObjectCollection<ExternalPharmacyPrescriptionTransaction> { }
                    
        public class ChildExternalPharmacyPrescriptionTransactionCollection : TTObject.TTChildObjectCollection<ExternalPharmacyPrescriptionTransaction>
        {
            public ChildExternalPharmacyPrescriptionTransactionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildExternalPharmacyPrescriptionTransactionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetDistributeGraphReportQuery_Class : TTReportNqlObject 
        {
            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EXTERNALPHARMACY"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ExternalPharmacy
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EXTERNALPHARMACY"]);
                }
            }

            public Object Balance
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["BALANCE"]);
                }
            }

            public GetDistributeGraphReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDistributeGraphReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDistributeGraphReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDistributePrescriptionByTransactionDate_Class : TTReportNqlObject 
        {
            public Guid? Prescription
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PRESCRIPTION"]);
                }
            }

            public GetDistributePrescriptionByTransactionDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDistributePrescriptionByTransactionDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDistributePrescriptionByTransactionDate_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPrescriptionReportQuery_Class : TTReportNqlObject 
        {
            public string Pharmacy
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PHARMACY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EXTERNALPHARMACY"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Prescription
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PRESCRIPTION"]);
                }
            }

            public string PrescriptionNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRESCRIPTIONNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTION"].AllPropertyDefs["PRESCRIPTIONNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string PatientName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTEDETAIL"].AllPropertyDefs["PATIENTNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? PatientProtocolNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTPROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTEDETAIL"].AllPropertyDefs["PATIENTPROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? PatientQuarantineNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTQUARANTINENO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTEDETAIL"].AllPropertyDefs["PATIENTQUARANTINENO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Object Price
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PRICE"]);
                }
            }

            public GetPrescriptionReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPrescriptionReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPrescriptionReportQuery_Class() : base() { }
        }

        public static BindingList<ExternalPharmacyPrescriptionTransaction.GetDistributeGraphReportQuery_Class> GetDistributeGraphReportQuery(DateTime ENDDATE, DateTime STARTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EXTERNALPHARMACYPRESCRIPTIONTRANSACTION"].QueryDefs["GetDistributeGraphReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STARTDATE", STARTDATE);

            return TTReportNqlObject.QueryObjects<ExternalPharmacyPrescriptionTransaction.GetDistributeGraphReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ExternalPharmacyPrescriptionTransaction.GetDistributeGraphReportQuery_Class> GetDistributeGraphReportQuery(TTObjectContext objectContext, DateTime ENDDATE, DateTime STARTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EXTERNALPHARMACYPRESCRIPTIONTRANSACTION"].QueryDefs["GetDistributeGraphReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STARTDATE", STARTDATE);

            return TTReportNqlObject.QueryObjects<ExternalPharmacyPrescriptionTransaction.GetDistributeGraphReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ExternalPharmacyPrescriptionTransaction.GetDistributePrescriptionByTransactionDate_Class> GetDistributePrescriptionByTransactionDate(DateTime ENDDATE, DateTime STARTDATE, Guid PHARMACY, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EXTERNALPHARMACYPRESCRIPTIONTRANSACTION"].QueryDefs["GetDistributePrescriptionByTransactionDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("PHARMACY", PHARMACY);

            return TTReportNqlObject.QueryObjects<ExternalPharmacyPrescriptionTransaction.GetDistributePrescriptionByTransactionDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ExternalPharmacyPrescriptionTransaction.GetDistributePrescriptionByTransactionDate_Class> GetDistributePrescriptionByTransactionDate(TTObjectContext objectContext, DateTime ENDDATE, DateTime STARTDATE, Guid PHARMACY, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EXTERNALPHARMACYPRESCRIPTIONTRANSACTION"].QueryDefs["GetDistributePrescriptionByTransactionDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("PHARMACY", PHARMACY);

            return TTReportNqlObject.QueryObjects<ExternalPharmacyPrescriptionTransaction.GetDistributePrescriptionByTransactionDate_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Eczane Evrensel Modülü
    /// </summary>
        public static BindingList<ExternalPharmacyPrescriptionTransaction.GetPrescriptionReportQuery_Class> GetPrescriptionReportQuery(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EXTERNALPHARMACYPRESCRIPTIONTRANSACTION"].QueryDefs["GetPrescriptionReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<ExternalPharmacyPrescriptionTransaction.GetPrescriptionReportQuery_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Eczane Evrensel Modülü
    /// </summary>
        public static BindingList<ExternalPharmacyPrescriptionTransaction.GetPrescriptionReportQuery_Class> GetPrescriptionReportQuery(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EXTERNALPHARMACYPRESCRIPTIONTRANSACTION"].QueryDefs["GetPrescriptionReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<ExternalPharmacyPrescriptionTransaction.GetPrescriptionReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// İptal
    /// </summary>
        public bool? Cancelled
        {
            get { return (bool?)this["CANCELLED"]; }
            set { this["CANCELLED"] = value; }
        }

    /// <summary>
    /// İşlem Zamanı
    /// </summary>
        public DateTime? TransactionDate
        {
            get { return (DateTime?)this["TRANSACTIONDATE"]; }
            set { this["TRANSACTIONDATE"] = value; }
        }

    /// <summary>
    /// Fiyat
    /// </summary>
        public double? Price
        {
            get { return (double?)this["PRICE"]; }
            set { this["PRICE"] = value; }
        }

        public ExternalPharmacy ExternalPharmacy
        {
            get { return (ExternalPharmacy)((ITTObject)this).GetParent("EXTERNALPHARMACY"); }
            set { this["EXTERNALPHARMACY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Prescription Prescription
        {
            get { return (Prescription)((ITTObject)this).GetParent("PRESCRIPTION"); }
            set { this["PRESCRIPTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ExternalPharmacyDistributionTerm DistributionTerm
        {
            get { return (ExternalPharmacyDistributionTerm)((ITTObject)this).GetParent("DISTRIBUTIONTERM"); }
            set { this["DISTRIBUTIONTERM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ExternalPharmacyPrescriptionTransaction(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ExternalPharmacyPrescriptionTransaction(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ExternalPharmacyPrescriptionTransaction(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ExternalPharmacyPrescriptionTransaction(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ExternalPharmacyPrescriptionTransaction(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EXTERNALPHARMACYPRESCRIPTIONTRANSACTION", dataRow) { }
        protected ExternalPharmacyPrescriptionTransaction(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EXTERNALPHARMACYPRESCRIPTIONTRANSACTION", dataRow, isImported) { }
        public ExternalPharmacyPrescriptionTransaction(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ExternalPharmacyPrescriptionTransaction(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ExternalPharmacyPrescriptionTransaction() : base() { }

    }
}