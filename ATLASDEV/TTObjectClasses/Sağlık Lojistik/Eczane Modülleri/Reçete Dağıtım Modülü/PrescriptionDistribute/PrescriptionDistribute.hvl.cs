
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PrescriptionDistribute")] 

    /// <summary>
    /// Reçete Dağıtım
    /// </summary>
    public  partial class PrescriptionDistribute : BaseAction, IWorkListBaseAction
    {
        public class PrescriptionDistributeList : TTObjectCollection<PrescriptionDistribute> { }
                    
        public class ChildPrescriptionDistributeCollection : TTObject.TTChildObjectCollection<PrescriptionDistribute>
        {
            public ChildPrescriptionDistributeCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPrescriptionDistributeCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetPrescriptionDistributeReportQuery_Class : TTReportNqlObject 
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

            public string PrescriptionType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRESCRIPTIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTIONDETAIL"].AllPropertyDefs["PRESCRIPTIONTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public BigCurrency? Price
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTEDETAIL"].AllPropertyDefs["PRICE"].DataType;
                    return (BigCurrency?)dataType.ConvertValue(val);
                }
            }

            public GetPrescriptionDistributeReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPrescriptionDistributeReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPrescriptionDistributeReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetInpatientPrescriptionOrderForDailyNoReportQuery_Class : TTReportNqlObject 
        {
            public string Dailyno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DAILYNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTION"].AllPropertyDefs["PRESCRIPTIONNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DistributionNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISTRIBUTIONNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTION"].AllPropertyDefs["DISTRIBUTIONNO"].DataType;
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

            public string Pharmacyname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PHARMACYNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EXTERNALPHARMACY"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTIONDISTRIBUTE"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Clinicname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CLINICNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetInpatientPrescriptionOrderForDailyNoReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetInpatientPrescriptionOrderForDailyNoReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetInpatientPrescriptionOrderForDailyNoReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetInpatientPrescriptionOrderByPharmacyReportQuery_Class : TTReportNqlObject 
        {
            public string Dailyno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DAILYNO"]);
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

            public string Clinicname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CLINICNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Doctorname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCTORNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public string Pharmacyname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PHARMACYNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EXTERNALPHARMACY"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DistributionNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISTRIBUTIONNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTION"].AllPropertyDefs["DISTRIBUTIONNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetInpatientPrescriptionOrderByPharmacyReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetInpatientPrescriptionOrderByPharmacyReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetInpatientPrescriptionOrderByPharmacyReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetExternalPharmacyBalance_Class : TTReportNqlObject 
        {
            public Guid? ExternalPharmacy
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EXTERNALPHARMACY"]);
                }
            }

            public Object Prescriptioncount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PRESCRIPTIONCOUNT"]);
                }
            }

            public Object Balance
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["BALANCE"]);
                }
            }

            public GetExternalPharmacyBalance_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetExternalPharmacyBalance_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetExternalPharmacyBalance_Class() : base() { }
        }

        [Serializable] 

        public partial class GetInpatientPrescriptionNotDistributedReportQuery_Class : TTReportNqlObject 
        {
            public string Dailyno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DAILYNO"]);
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

            public string Clinicname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CLINICNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public BigCurrency? Price
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTEDETAIL"].AllPropertyDefs["PRICE"].DataType;
                    return (BigCurrency?)dataType.ConvertValue(val);
                }
            }

            public GetInpatientPrescriptionNotDistributedReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetInpatientPrescriptionNotDistributedReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetInpatientPrescriptionNotDistributedReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetInpatientPrescriptionOutScheduleQuery_Class : TTReportNqlObject 
        {
            public Guid? ExternalPharmacy
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EXTERNALPHARMACY"]);
                }
            }

            public Object Prescriptioncount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PRESCRIPTIONCOUNT"]);
                }
            }

            public Object Balance
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["BALANCE"]);
                }
            }

            public GetInpatientPrescriptionOutScheduleQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetInpatientPrescriptionOutScheduleQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetInpatientPrescriptionOutScheduleQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetInpatientPrescriptionOfSelectedPharmacyQuery_Class : TTReportNqlObject 
        {
            public Guid? Prescriptionid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PRESCRIPTIONID"]);
                }
            }

            public string Dailyno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DAILYNO"]);
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

            public string Clinicname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CLINICNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Doctorname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCTORNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public BigCurrency? Price
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTEDETAIL"].AllPropertyDefs["PRICE"].DataType;
                    return (BigCurrency?)dataType.ConvertValue(val);
                }
            }

            public GetInpatientPrescriptionOfSelectedPharmacyQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetInpatientPrescriptionOfSelectedPharmacyQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetInpatientPrescriptionOfSelectedPharmacyQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class YatanHastaReceteQuery_Class : TTReportNqlObject 
        {
            public string Pharmacy
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PHARMACY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHARMACYDETAIL"].AllPropertyDefs["PHARMACY"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Averaj
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["AVERAJ"]);
                }
            }

            public YatanHastaReceteQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public YatanHastaReceteQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected YatanHastaReceteQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetInpatientPrescriptionOrderByClinicReportQuery_Class : TTReportNqlObject 
        {
            public string Dailyno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DAILYNO"]);
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

            public string Clinicname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CLINICNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Doctorname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCTORNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public string Pharmacyname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PHARMACYNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EXTERNALPHARMACY"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetInpatientPrescriptionOrderByClinicReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetInpatientPrescriptionOrderByClinicReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetInpatientPrescriptionOrderByClinicReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class ReceteParaQuery_Class : TTReportNqlObject 
        {
            public Guid? Pharmacy
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PHARMACY"]);
                }
            }

            public Object Prescriptioncount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PRESCRIPTIONCOUNT"]);
                }
            }

            public Object Balance
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["BALANCE"]);
                }
            }

            public ReceteParaQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public ReceteParaQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected ReceteParaQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetSivilEczaneQuery_Class : TTReportNqlObject 
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

            public Object Actionyear
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ACTIONYEAR"]);
                }
            }

            public Object Actionmonth
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ACTIONMONTH"]);
                }
            }

            public Object Actionday
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ACTIONDAY"]);
                }
            }

            public Object Prescriptioncount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PRESCRIPTIONCOUNT"]);
                }
            }

            public Object Balance
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["BALANCE"]);
                }
            }

            public GetSivilEczaneQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSivilEczaneQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSivilEczaneQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPrescriptionDistributeForERecete_Class : TTReportNqlObject 
        {
            public Guid? Prescriptionid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PRESCRIPTIONID"]);
                }
            }

            public string Dailyno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DAILYNO"]);
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

            public string Clinicname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CLINICNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Doctorname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCTORNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public BigCurrency? Price
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTEDETAIL"].AllPropertyDefs["PRICE"].DataType;
                    return (BigCurrency?)dataType.ConvertValue(val);
                }
            }

            public string EReceteNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ERECETENO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTION"].AllPropertyDefs["ERECETENO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetPrescriptionDistributeForERecete_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPrescriptionDistributeForERecete_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPrescriptionDistributeForERecete_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("ad682cd5-a246-4278-adfc-12f34fbad59a"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("fcbd5630-55d0-4256-a9f7-170c76c22a1b"); } }
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("3c1cb2c2-6378-4d53-9c65-455ffa4aff18"); } }
    /// <summary>
    /// Onay
    /// </summary>
            public static Guid Approval { get { return new Guid("3e5a6a90-d378-4399-b870-d46b747f64a9"); } }
        }

        public static BindingList<PrescriptionDistribute.GetPrescriptionDistributeReportQuery_Class> GetPrescriptionDistributeReportQuery(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTIONDISTRIBUTE"].QueryDefs["GetPrescriptionDistributeReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<PrescriptionDistribute.GetPrescriptionDistributeReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PrescriptionDistribute.GetPrescriptionDistributeReportQuery_Class> GetPrescriptionDistributeReportQuery(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTIONDISTRIBUTE"].QueryDefs["GetPrescriptionDistributeReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<PrescriptionDistribute.GetPrescriptionDistributeReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PrescriptionDistribute.GetInpatientPrescriptionOrderForDailyNoReportQuery_Class> GetInpatientPrescriptionOrderForDailyNoReportQuery(DateTime DATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTIONDISTRIBUTE"].QueryDefs["GetInpatientPrescriptionOrderForDailyNoReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DATE", DATE);

            return TTReportNqlObject.QueryObjects<PrescriptionDistribute.GetInpatientPrescriptionOrderForDailyNoReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PrescriptionDistribute.GetInpatientPrescriptionOrderForDailyNoReportQuery_Class> GetInpatientPrescriptionOrderForDailyNoReportQuery(TTObjectContext objectContext, DateTime DATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTIONDISTRIBUTE"].QueryDefs["GetInpatientPrescriptionOrderForDailyNoReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DATE", DATE);

            return TTReportNqlObject.QueryObjects<PrescriptionDistribute.GetInpatientPrescriptionOrderForDailyNoReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PrescriptionDistribute.GetInpatientPrescriptionOrderByPharmacyReportQuery_Class> GetInpatientPrescriptionOrderByPharmacyReportQuery(DateTime DATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTIONDISTRIBUTE"].QueryDefs["GetInpatientPrescriptionOrderByPharmacyReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DATE", DATE);

            return TTReportNqlObject.QueryObjects<PrescriptionDistribute.GetInpatientPrescriptionOrderByPharmacyReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PrescriptionDistribute.GetInpatientPrescriptionOrderByPharmacyReportQuery_Class> GetInpatientPrescriptionOrderByPharmacyReportQuery(TTObjectContext objectContext, DateTime DATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTIONDISTRIBUTE"].QueryDefs["GetInpatientPrescriptionOrderByPharmacyReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DATE", DATE);

            return TTReportNqlObject.QueryObjects<PrescriptionDistribute.GetInpatientPrescriptionOrderByPharmacyReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PrescriptionDistribute.GetExternalPharmacyBalance_Class> GetExternalPharmacyBalance(DateTime DATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTIONDISTRIBUTE"].QueryDefs["GetExternalPharmacyBalance"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DATE", DATE);

            return TTReportNqlObject.QueryObjects<PrescriptionDistribute.GetExternalPharmacyBalance_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PrescriptionDistribute.GetExternalPharmacyBalance_Class> GetExternalPharmacyBalance(TTObjectContext objectContext, DateTime DATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTIONDISTRIBUTE"].QueryDefs["GetExternalPharmacyBalance"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DATE", DATE);

            return TTReportNqlObject.QueryObjects<PrescriptionDistribute.GetExternalPharmacyBalance_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PrescriptionDistribute.GetInpatientPrescriptionNotDistributedReportQuery_Class> GetInpatientPrescriptionNotDistributedReportQuery(DateTime DATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTIONDISTRIBUTE"].QueryDefs["GetInpatientPrescriptionNotDistributedReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DATE", DATE);

            return TTReportNqlObject.QueryObjects<PrescriptionDistribute.GetInpatientPrescriptionNotDistributedReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PrescriptionDistribute.GetInpatientPrescriptionNotDistributedReportQuery_Class> GetInpatientPrescriptionNotDistributedReportQuery(TTObjectContext objectContext, DateTime DATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTIONDISTRIBUTE"].QueryDefs["GetInpatientPrescriptionNotDistributedReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DATE", DATE);

            return TTReportNqlObject.QueryObjects<PrescriptionDistribute.GetInpatientPrescriptionNotDistributedReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PrescriptionDistribute.GetInpatientPrescriptionOutScheduleQuery_Class> GetInpatientPrescriptionOutScheduleQuery(DateTime DATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTIONDISTRIBUTE"].QueryDefs["GetInpatientPrescriptionOutScheduleQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DATE", DATE);

            return TTReportNqlObject.QueryObjects<PrescriptionDistribute.GetInpatientPrescriptionOutScheduleQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PrescriptionDistribute.GetInpatientPrescriptionOutScheduleQuery_Class> GetInpatientPrescriptionOutScheduleQuery(TTObjectContext objectContext, DateTime DATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTIONDISTRIBUTE"].QueryDefs["GetInpatientPrescriptionOutScheduleQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DATE", DATE);

            return TTReportNqlObject.QueryObjects<PrescriptionDistribute.GetInpatientPrescriptionOutScheduleQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PrescriptionDistribute.GetInpatientPrescriptionOfSelectedPharmacyQuery_Class> GetInpatientPrescriptionOfSelectedPharmacyQuery(Guid PHARMACYID, DateTime DATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTIONDISTRIBUTE"].QueryDefs["GetInpatientPrescriptionOfSelectedPharmacyQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PHARMACYID", PHARMACYID);
            paramList.Add("DATE", DATE);

            return TTReportNqlObject.QueryObjects<PrescriptionDistribute.GetInpatientPrescriptionOfSelectedPharmacyQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PrescriptionDistribute.GetInpatientPrescriptionOfSelectedPharmacyQuery_Class> GetInpatientPrescriptionOfSelectedPharmacyQuery(TTObjectContext objectContext, Guid PHARMACYID, DateTime DATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTIONDISTRIBUTE"].QueryDefs["GetInpatientPrescriptionOfSelectedPharmacyQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PHARMACYID", PHARMACYID);
            paramList.Add("DATE", DATE);

            return TTReportNqlObject.QueryObjects<PrescriptionDistribute.GetInpatientPrescriptionOfSelectedPharmacyQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PrescriptionDistribute.YatanHastaReceteQuery_Class> YatanHastaReceteQuery(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTIONDISTRIBUTE"].QueryDefs["YatanHastaReceteQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PrescriptionDistribute.YatanHastaReceteQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PrescriptionDistribute.YatanHastaReceteQuery_Class> YatanHastaReceteQuery(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTIONDISTRIBUTE"].QueryDefs["YatanHastaReceteQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PrescriptionDistribute.YatanHastaReceteQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PrescriptionDistribute.GetInpatientPrescriptionOrderByClinicReportQuery_Class> GetInpatientPrescriptionOrderByClinicReportQuery(DateTime DATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTIONDISTRIBUTE"].QueryDefs["GetInpatientPrescriptionOrderByClinicReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DATE", DATE);

            return TTReportNqlObject.QueryObjects<PrescriptionDistribute.GetInpatientPrescriptionOrderByClinicReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PrescriptionDistribute.GetInpatientPrescriptionOrderByClinicReportQuery_Class> GetInpatientPrescriptionOrderByClinicReportQuery(TTObjectContext objectContext, DateTime DATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTIONDISTRIBUTE"].QueryDefs["GetInpatientPrescriptionOrderByClinicReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DATE", DATE);

            return TTReportNqlObject.QueryObjects<PrescriptionDistribute.GetInpatientPrescriptionOrderByClinicReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PrescriptionDistribute.ReceteParaQuery_Class> ReceteParaQuery(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTIONDISTRIBUTE"].QueryDefs["ReceteParaQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<PrescriptionDistribute.ReceteParaQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PrescriptionDistribute.ReceteParaQuery_Class> ReceteParaQuery(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTIONDISTRIBUTE"].QueryDefs["ReceteParaQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<PrescriptionDistribute.ReceteParaQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PrescriptionDistribute.GetSivilEczaneQuery_Class> GetSivilEczaneQuery(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTIONDISTRIBUTE"].QueryDefs["GetSivilEczaneQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<PrescriptionDistribute.GetSivilEczaneQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PrescriptionDistribute.GetSivilEczaneQuery_Class> GetSivilEczaneQuery(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTIONDISTRIBUTE"].QueryDefs["GetSivilEczaneQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<PrescriptionDistribute.GetSivilEczaneQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PrescriptionDistribute.GetPrescriptionDistributeForERecete_Class> GetPrescriptionDistributeForERecete(Guid PHARMACYID, Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTIONDISTRIBUTE"].QueryDefs["GetPrescriptionDistributeForERecete"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PHARMACYID", PHARMACYID);
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<PrescriptionDistribute.GetPrescriptionDistributeForERecete_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PrescriptionDistribute.GetPrescriptionDistributeForERecete_Class> GetPrescriptionDistributeForERecete(TTObjectContext objectContext, Guid PHARMACYID, Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTIONDISTRIBUTE"].QueryDefs["GetPrescriptionDistributeForERecete"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PHARMACYID", PHARMACYID);
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<PrescriptionDistribute.GetPrescriptionDistributeForERecete_Class>(objectContext, queryDef, paramList, pi);
        }

        virtual protected void CreatePrescriptionDetailsCollection()
        {
            _PrescriptionDetails = new PrescriptionDetail.ChildPrescriptionDetailCollection(this, new Guid("04eafc2b-4786-406f-b3cb-592bb7febf4c"));
            ((ITTChildObjectCollection)_PrescriptionDetails).GetChildren();
        }

        protected PrescriptionDetail.ChildPrescriptionDetailCollection _PrescriptionDetails = null;
        public PrescriptionDetail.ChildPrescriptionDetailCollection PrescriptionDetails
        {
            get
            {
                if (_PrescriptionDetails == null)
                    CreatePrescriptionDetailsCollection();
                return _PrescriptionDetails;
            }
        }

        virtual protected void CreatePharmacyDetailsCollection()
        {
            _PharmacyDetails = new PharmacyDetail.ChildPharmacyDetailCollection(this, new Guid("e61cae07-e13c-4423-bd93-d5ac99a813c1"));
            ((ITTChildObjectCollection)_PharmacyDetails).GetChildren();
        }

        protected PharmacyDetail.ChildPharmacyDetailCollection _PharmacyDetails = null;
        public PharmacyDetail.ChildPharmacyDetailCollection PharmacyDetails
        {
            get
            {
                if (_PharmacyDetails == null)
                    CreatePharmacyDetailsCollection();
                return _PharmacyDetails;
            }
        }

        virtual protected void CreateDistributeDetailsCollection()
        {
            _DistributeDetails = new DistributeDetail.ChildDistributeDetailCollection(this, new Guid("38dbe422-1889-4b3f-b6d6-ee96630075e4"));
            ((ITTChildObjectCollection)_DistributeDetails).GetChildren();
        }

        protected DistributeDetail.ChildDistributeDetailCollection _DistributeDetails = null;
        public DistributeDetail.ChildDistributeDetailCollection DistributeDetails
        {
            get
            {
                if (_DistributeDetails == null)
                    CreateDistributeDetailsCollection();
                return _DistributeDetails;
            }
        }

        protected PrescriptionDistribute(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PrescriptionDistribute(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PrescriptionDistribute(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PrescriptionDistribute(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PrescriptionDistribute(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PRESCRIPTIONDISTRIBUTE", dataRow) { }
        protected PrescriptionDistribute(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PRESCRIPTIONDISTRIBUTE", dataRow, isImported) { }
        public PrescriptionDistribute(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PrescriptionDistribute(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PrescriptionDistribute() : base() { }

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