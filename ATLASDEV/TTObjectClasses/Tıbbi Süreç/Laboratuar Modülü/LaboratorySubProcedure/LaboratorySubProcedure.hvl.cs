
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="LaboratorySubProcedure")] 

    /// <summary>
    /// Laboratuvar Alt Test
    /// </summary>
    public  partial class LaboratorySubProcedure : SubactionProcedureFlowable
    {
        public class LaboratorySubProcedureList : TTObjectCollection<LaboratorySubProcedure> { }
                    
        public class ChildLaboratorySubProcedureCollection : TTObject.TTChildObjectCollection<LaboratorySubProcedure>
        {
            public ChildLaboratorySubProcedureCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildLaboratorySubProcedureCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class LabSubProcedureReportNQL_Class : TTReportNqlObject 
        {
            public string Result
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].AllPropertyDefs["RESULT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Reference
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REFERENCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].AllPropertyDefs["REFERENCE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Unit
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNIT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].AllPropertyDefs["UNIT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public HighLowEnum? Warning
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WARNING"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].AllPropertyDefs["WARNING"].DataType;
                    return (HighLowEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ProcedureObject
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDUREOBJECT"]);
                }
            }

            public LabSubProcedureReportNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public LabSubProcedureReportNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected LabSubProcedureReportNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class GetLabSubProcedureByTestAndRequest_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Result
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].AllPropertyDefs["RESULT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object LongReport
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LONGREPORT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].AllPropertyDefs["LONGREPORT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public string Reference
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REFERENCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].AllPropertyDefs["REFERENCE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object SpecialReference
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPECIALREFERENCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].AllPropertyDefs["SPECIALREFERENCE"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public string Unit
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNIT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].AllPropertyDefs["UNIT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public HighLowEnum? Warning
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WARNING"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].AllPropertyDefs["WARNING"].DataType;
                    return (HighLowEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GetLabSubProcedureByTestAndRequest_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetLabSubProcedureByTestAndRequest_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetLabSubProcedureByTestAndRequest_Class() : base() { }
        }

        [Serializable] 

        public partial class GetLabSubProcByTestDef_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Result
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].AllPropertyDefs["RESULT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Reference
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REFERENCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].AllPropertyDefs["REFERENCE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Unit
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNIT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].AllPropertyDefs["UNIT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public HighLowEnum? Warning
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WARNING"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].AllPropertyDefs["WARNING"].DataType;
                    return (HighLowEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ProcedureObject
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDUREOBJECT"]);
                }
            }

            public object LongReport
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LONGREPORT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].AllPropertyDefs["LONGREPORT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public GetLabSubProcByTestDef_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetLabSubProcByTestDef_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetLabSubProcByTestDef_Class() : base() { }
        }

        [Serializable] 

        public partial class GetByLaboratoryProcedure_Class : TTReportNqlObject 
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

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public bool? Eligible
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ELIGIBLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].AllPropertyDefs["ELIGIBLE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string ReasonOfCancel
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONOFCANCEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].AllPropertyDefs["REASONOFCANCEL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? WorkListDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKLISTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].AllPropertyDefs["WORKLISTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? PricingDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRICINGDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].AllPropertyDefs["PRICINGDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].AllPropertyDefs["AMOUNT"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? Emergency
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EMERGENCY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].AllPropertyDefs["EMERGENCY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Active
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIVE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].AllPropertyDefs["ACTIVE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OlapDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].AllPropertyDefs["OLAPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OlapLastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAPLASTUPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? AccountOperationDone
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCOUNTOPERATIONDONE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].AllPropertyDefs["ACCOUNTOPERATIONDONE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? AccTrxsMultipliedByAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCTRXSMULTIPLIEDBYAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].AllPropertyDefs["ACCTRXSMULTIPLIEDBYAMOUNT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? PatientPay
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTPAY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].AllPropertyDefs["PATIENTPAY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string ExtraDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXTRADESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].AllPropertyDefs["EXTRADESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public SutRuleEngineStatus? SUTRuleStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUTRULESTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].AllPropertyDefs["SUTRULESTATUS"].DataType;
                    return (SutRuleEngineStatus?)(int)dataType.ConvertValue(val);
                }
            }

            public double? DiscountPercent
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISCOUNTPERCENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].AllPropertyDefs["DISCOUNTPERCENT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public DateTime? PerformedDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PERFORMEDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].AllPropertyDefs["PERFORMEDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? CreationDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CREATIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].AllPropertyDefs["CREATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? IsOldAction
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISOLDACTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].AllPropertyDefs["ISOLDACTION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string MedulaReportNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULAREPORTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].AllPropertyDefs["MEDULAREPORTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public RightLeftEnum? RightLeftInformation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RIGHTLEFTINFORMATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].AllPropertyDefs["RIGHTLEFTINFORMATION"].DataType;
                    return (RightLeftEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public object ReasonOfReject
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONOFREJECT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].AllPropertyDefs["REASONOFREJECT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public string Result
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].AllPropertyDefs["RESULT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? Check
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CHECK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].AllPropertyDefs["CHECK"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Unit
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNIT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].AllPropertyDefs["UNIT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Reference
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REFERENCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].AllPropertyDefs["REFERENCE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public HighLowEnum? Warning
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WARNING"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].AllPropertyDefs["WARNING"].DataType;
                    return (HighLowEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public Guid? LabProcedureID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["LABPROCEDUREID"]);
                }
            }

            public bool? MicrobiologyPanicNotification
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MICROBIOLOGYPANICNOTIFICATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].AllPropertyDefs["MICROBIOLOGYPANICNOTIFICATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public LaboratoryAbnormalFlagsEnum? Panic
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PANIC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].AllPropertyDefs["PANIC"].DataType;
                    return (LaboratoryAbnormalFlagsEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public DateTime? AcceptDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCEPTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].AllPropertyDefs["ACCEPTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ApproveDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["APPROVEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].AllPropertyDefs["APPROVEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ProcedureDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDUREDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].AllPropertyDefs["PROCEDUREDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public object LongReport
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LONGREPORT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].AllPropertyDefs["LONGREPORT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public string ResultDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULTDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].AllPropertyDefs["RESULTDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ProcessNote
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCESSNOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].AllPropertyDefs["PROCESSNOTE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object Report
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].AllPropertyDefs["REPORT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string RequestNote
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTNOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].AllPropertyDefs["REQUESTNOTE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? SampleAcceptionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SAMPLEACCEPTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].AllPropertyDefs["SAMPLEACCEPTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? SampleDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SAMPLEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].AllPropertyDefs["SAMPLEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public object SpecialReference
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPECIALREFERENCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].AllPropertyDefs["SPECIALREFERENCE"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public string Techniciannote
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TECHNICIANNOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].AllPropertyDefs["TECHNICIANNOTE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? TestDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["TESTDEFID"]);
                }
            }

            public GetByLaboratoryProcedure_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetByLaboratoryProcedure_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetByLaboratoryProcedure_Class() : base() { }
        }

        [Serializable] 

        public partial class GetLabSubProcedureByFilter_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public LaboratoryAbnormalFlagsEnum? Panic
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PANIC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].AllPropertyDefs["PANIC"].DataType;
                    return (LaboratoryAbnormalFlagsEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Reference
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REFERENCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].AllPropertyDefs["REFERENCE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Result
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].AllPropertyDefs["RESULT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Unit
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNIT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].AllPropertyDefs["UNIT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public HighLowEnum? Warning
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WARNING"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].AllPropertyDefs["WARNING"].DataType;
                    return (HighLowEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public GetLabSubProcedureByFilter_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetLabSubProcedureByFilter_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetLabSubProcedureByFilter_Class() : base() { }
        }

        [Serializable] 

        public partial class GunSonu_GS36HemogramBagliTetkikSayisi_Class : TTReportNqlObject 
        {
            public Object Alttekiksayisi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ALTTEKIKSAYISI"]);
                }
            }

            public GunSonu_GS36HemogramBagliTetkikSayisi_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GunSonu_GS36HemogramBagliTetkikSayisi_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GunSonu_GS36HemogramBagliTetkikSayisi_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPatientLabResultsByLaboratoryProcedure_Class : TTReportNqlObject 
        {
            public Guid? Procedureobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDUREOBJECTID"]);
                }
            }

            public string Procedurename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDURENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Result
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].AllPropertyDefs["RESULT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Unit
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNIT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].AllPropertyDefs["UNIT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Reference
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REFERENCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].AllPropertyDefs["REFERENCE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetPatientLabResultsByLaboratoryProcedure_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPatientLabResultsByLaboratoryProcedure_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPatientLabResultsByLaboratoryProcedure_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPatientLabResultDetailsByTestByDate_Class : TTReportNqlObject 
        {
            public Guid? Procedureobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDUREOBJECTID"]);
                }
            }

            public string Procedurename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDURENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Result
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].AllPropertyDefs["RESULT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Unit
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNIT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].AllPropertyDefs["UNIT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Reference
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REFERENCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].AllPropertyDefs["REFERENCE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetPatientLabResultDetailsByTestByDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPatientLabResultDetailsByTestByDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPatientLabResultDetailsByTestByDate_Class() : base() { }
        }

        new public static class States
        {
    /// <summary>
    /// Laboratuvarda
    /// </summary>
            public static Guid Procedure { get { return new Guid("d76068d2-4b8c-4288-af4b-2cdda74a78d1"); } }
    /// <summary>
    /// Sonuçlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("ea90f65c-304e-417e-8d0a-d8996a2fb102"); } }
        }

        public static BindingList<LaboratorySubProcedure.LabSubProcedureReportNQL_Class> LabSubProcedureReportNQL(string PARAMOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].QueryDefs["LabSubProcedureReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJID", PARAMOBJID);

            return TTReportNqlObject.QueryObjects<LaboratorySubProcedure.LabSubProcedureReportNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<LaboratorySubProcedure.LabSubProcedureReportNQL_Class> LabSubProcedureReportNQL(TTObjectContext objectContext, string PARAMOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].QueryDefs["LabSubProcedureReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJID", PARAMOBJID);

            return TTReportNqlObject.QueryObjects<LaboratorySubProcedure.LabSubProcedureReportNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<LaboratorySubProcedure.GetLabSubProcedureByTestAndRequest_Class> GetLabSubProcedureByTestAndRequest(Guid PARAMOBJID, Guid TEST, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].QueryDefs["GetLabSubProcedureByTestAndRequest"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJID", PARAMOBJID);
            paramList.Add("TEST", TEST);

            return TTReportNqlObject.QueryObjects<LaboratorySubProcedure.GetLabSubProcedureByTestAndRequest_Class>(queryDef, paramList, pi);
        }

        public static BindingList<LaboratorySubProcedure.GetLabSubProcedureByTestAndRequest_Class> GetLabSubProcedureByTestAndRequest(TTObjectContext objectContext, Guid PARAMOBJID, Guid TEST, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].QueryDefs["GetLabSubProcedureByTestAndRequest"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJID", PARAMOBJID);
            paramList.Add("TEST", TEST);

            return TTReportNqlObject.QueryObjects<LaboratorySubProcedure.GetLabSubProcedureByTestAndRequest_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<LaboratorySubProcedure.GetLabSubProcByTestDef_Class> GetLabSubProcByTestDef(Guid PARAMOBJID, Guid TESTDEFID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].QueryDefs["GetLabSubProcByTestDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJID", PARAMOBJID);
            paramList.Add("TESTDEFID", TESTDEFID);

            return TTReportNqlObject.QueryObjects<LaboratorySubProcedure.GetLabSubProcByTestDef_Class>(queryDef, paramList, pi);
        }

        public static BindingList<LaboratorySubProcedure.GetLabSubProcByTestDef_Class> GetLabSubProcByTestDef(TTObjectContext objectContext, Guid PARAMOBJID, Guid TESTDEFID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].QueryDefs["GetLabSubProcByTestDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJID", PARAMOBJID);
            paramList.Add("TESTDEFID", TESTDEFID);

            return TTReportNqlObject.QueryObjects<LaboratorySubProcedure.GetLabSubProcByTestDef_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<LaboratorySubProcedure.GetByLaboratoryProcedure_Class> GetByLaboratoryProcedure(Guid LABORATORYPROCEDURE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].QueryDefs["GetByLaboratoryProcedure"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("LABORATORYPROCEDURE", LABORATORYPROCEDURE);

            return TTReportNqlObject.QueryObjects<LaboratorySubProcedure.GetByLaboratoryProcedure_Class>(queryDef, paramList, pi);
        }

        public static BindingList<LaboratorySubProcedure.GetByLaboratoryProcedure_Class> GetByLaboratoryProcedure(TTObjectContext objectContext, Guid LABORATORYPROCEDURE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].QueryDefs["GetByLaboratoryProcedure"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("LABORATORYPROCEDURE", LABORATORYPROCEDURE);

            return TTReportNqlObject.QueryObjects<LaboratorySubProcedure.GetByLaboratoryProcedure_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<LaboratorySubProcedure.GetLabSubProcedureByFilter_Class> GetLabSubProcedureByFilter(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].QueryDefs["GetLabSubProcedureByFilter"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<LaboratorySubProcedure.GetLabSubProcedureByFilter_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<LaboratorySubProcedure.GetLabSubProcedureByFilter_Class> GetLabSubProcedureByFilter(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].QueryDefs["GetLabSubProcedureByFilter"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<LaboratorySubProcedure.GetLabSubProcedureByFilter_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<LaboratorySubProcedure.GunSonu_GS36HemogramBagliTetkikSayisi_Class> GunSonu_GS36HemogramBagliTetkikSayisi(IList<string> SUTKODU, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].QueryDefs["GunSonu_GS36HemogramBagliTetkikSayisi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUTKODU", SUTKODU);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<LaboratorySubProcedure.GunSonu_GS36HemogramBagliTetkikSayisi_Class>(queryDef, paramList, pi);
        }

        public static BindingList<LaboratorySubProcedure.GunSonu_GS36HemogramBagliTetkikSayisi_Class> GunSonu_GS36HemogramBagliTetkikSayisi(TTObjectContext objectContext, IList<string> SUTKODU, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].QueryDefs["GunSonu_GS36HemogramBagliTetkikSayisi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUTKODU", SUTKODU);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<LaboratorySubProcedure.GunSonu_GS36HemogramBagliTetkikSayisi_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<LaboratorySubProcedure.GetPatientLabResultsByLaboratoryProcedure_Class> GetPatientLabResultsByLaboratoryProcedure(string LABORATORYPROCEDURE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].QueryDefs["GetPatientLabResultsByLaboratoryProcedure"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("LABORATORYPROCEDURE", LABORATORYPROCEDURE);

            return TTReportNqlObject.QueryObjects<LaboratorySubProcedure.GetPatientLabResultsByLaboratoryProcedure_Class>(queryDef, paramList, pi);
        }

        public static BindingList<LaboratorySubProcedure.GetPatientLabResultsByLaboratoryProcedure_Class> GetPatientLabResultsByLaboratoryProcedure(TTObjectContext objectContext, string LABORATORYPROCEDURE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].QueryDefs["GetPatientLabResultsByLaboratoryProcedure"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("LABORATORYPROCEDURE", LABORATORYPROCEDURE);

            return TTReportNqlObject.QueryObjects<LaboratorySubProcedure.GetPatientLabResultsByLaboratoryProcedure_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<LaboratorySubProcedure.GetPatientLabResultDetailsByTestByDate_Class> GetPatientLabResultDetailsByTestByDate(string PATIENTID, string SUBEPISODEID, string TESTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].QueryDefs["GetPatientLabResultDetailsByTestByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTID", PATIENTID);
            paramList.Add("SUBEPISODEID", SUBEPISODEID);
            paramList.Add("TESTID", TESTID);

            return TTReportNqlObject.QueryObjects<LaboratorySubProcedure.GetPatientLabResultDetailsByTestByDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<LaboratorySubProcedure.GetPatientLabResultDetailsByTestByDate_Class> GetPatientLabResultDetailsByTestByDate(TTObjectContext objectContext, string PATIENTID, string SUBEPISODEID, string TESTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYSUBPROCEDURE"].QueryDefs["GetPatientLabResultDetailsByTestByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTID", PATIENTID);
            paramList.Add("SUBEPISODEID", SUBEPISODEID);
            paramList.Add("TESTID", TESTID);

            return TTReportNqlObject.QueryObjects<LaboratorySubProcedure.GetPatientLabResultDetailsByTestByDate_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Sonuç
    /// </summary>
        public string Result
        {
            get { return (string)this["RESULT"]; }
            set { this["RESULT"] = value; }
        }

    /// <summary>
    /// Seç
    /// </summary>
        public bool? Check
        {
            get { return (bool?)this["CHECK"]; }
            set { this["CHECK"] = value; }
        }

    /// <summary>
    /// Açıklama Girilecek Alan
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Birim
    /// </summary>
        public string Unit
        {
            get { return (string)this["UNIT"]; }
            set { this["UNIT"] = value; }
        }

    /// <summary>
    /// Referans Değerler
    /// </summary>
        public string Reference
        {
            get { return (string)this["REFERENCE"]; }
            set { this["REFERENCE"] = value; }
        }

    /// <summary>
    /// Sapma
    /// </summary>
        public HighLowEnum? Warning
        {
            get { return (HighLowEnum?)(int?)this["WARNING"]; }
            set { this["WARNING"] = value; }
        }

    /// <summary>
    /// Panel Tetkiğin ObjectID'si saklanır
    /// </summary>
        public Guid? LabProcedureID
        {
            get { return (Guid?)this["LABPROCEDUREID"]; }
            set { this["LABPROCEDUREID"] = value; }
        }

    /// <summary>
    /// Microbiology Panic Notification
    /// </summary>
        public bool? MicrobiologyPanicNotification
        {
            get { return (bool?)this["MICROBIOLOGYPANICNOTIFICATION"]; }
            set { this["MICROBIOLOGYPANICNOTIFICATION"] = value; }
        }

    /// <summary>
    /// Panik Değer Uyarısı
    /// </summary>
        public LaboratoryAbnormalFlagsEnum? Panic
        {
            get { return (LaboratoryAbnormalFlagsEnum?)(int?)this["PANIC"]; }
            set { this["PANIC"] = value; }
        }

    /// <summary>
    /// Laboratuvara İlk Kabul Tarihi Alanıdır
    /// </summary>
        public DateTime? AcceptDate
        {
            get { return (DateTime?)this["ACCEPTDATE"]; }
            set { this["ACCEPTDATE"] = value; }
        }

    /// <summary>
    /// Test Sonucunun Onay Tarihi
    /// </summary>
        public DateTime? ApproveDate
        {
            get { return (DateTime?)this["APPROVEDATE"]; }
            set { this["APPROVEDATE"] = value; }
        }

    /// <summary>
    /// Test İşleminin Tarihi
    /// </summary>
        public DateTime? ProcedureDate
        {
            get { return (DateTime?)this["PROCEDUREDATE"]; }
            set { this["PROCEDUREDATE"] = value; }
        }

    /// <summary>
    /// Uzun Rapor
    /// </summary>
        public object LongReport
        {
            get { return (object)this["LONGREPORT"]; }
            set { this["LONGREPORT"] = value; }
        }

    /// <summary>
    /// Sonuç Açıklaması
    /// </summary>
        public string ResultDescription
        {
            get { return (string)this["RESULTDESCRIPTION"]; }
            set { this["RESULTDESCRIPTION"] = value; }
        }

    /// <summary>
    /// İşlem Notu Alanıdır
    /// </summary>
        public string ProcessNote
        {
            get { return (string)this["PROCESSNOTE"]; }
            set { this["PROCESSNOTE"] = value; }
        }

    /// <summary>
    /// Rapor
    /// </summary>
        public object Report
        {
            get { return (object)this["REPORT"]; }
            set { this["REPORT"] = value; }
        }

    /// <summary>
    /// İsteğin Yapıldığı Tarihi Alanı
    /// </summary>
        public DateTime? RequestDate
        {
            get { return (DateTime?)this["REQUESTDATE"]; }
            set { this["REQUESTDATE"] = value; }
        }

    /// <summary>
    /// İstek Yapılırken Gerekli Bilgiler İçin Not Alanı
    /// </summary>
        public string RequestNote
        {
            get { return (string)this["REQUESTNOTE"]; }
            set { this["REQUESTNOTE"] = value; }
        }

    /// <summary>
    /// Numune Kabul Tarihi
    /// </summary>
        public DateTime? SampleAcceptionDate
        {
            get { return (DateTime?)this["SAMPLEACCEPTIONDATE"]; }
            set { this["SAMPLEACCEPTIONDATE"] = value; }
        }

    /// <summary>
    /// Numunenin Alınma Tarihi Girilir
    /// </summary>
        public DateTime? SampleDate
        {
            get { return (DateTime?)this["SAMPLEDATE"]; }
            set { this["SAMPLEDATE"] = value; }
        }

    /// <summary>
    /// Referans Aralığı
    /// </summary>
        public object SpecialReference
        {
            get { return (object)this["SPECIALREFERENCE"]; }
            set { this["SPECIALREFERENCE"] = value; }
        }

    /// <summary>
    /// Teknisyenin Not Gireceği Alandır
    /// </summary>
        public string Techniciannote
        {
            get { return (string)this["TECHNICIANNOTE"]; }
            set { this["TECHNICIANNOTE"] = value; }
        }

    /// <summary>
    /// Remote Gönderilen Test'in ID'sini Saklar
    /// </summary>
        public Guid? TestDefID
        {
            get { return (Guid?)this["TESTDEFID"]; }
            set { this["TESTDEFID"] = value; }
        }

    /// <summary>
    /// Testin Çalışılacağı Bölüm İlişkisi
    /// </summary>
        public ResLaboratoryDepartment Department
        {
            get { return (ResLaboratoryDepartment)((ITTObject)this).GetParent("DEPARTMENT"); }
            set { this["DEPARTMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Testin Çalışılacağı Cihaz ile olan İlişkisi
    /// </summary>
        public ResLaboratoryEquipment Equipment
        {
            get { return (ResLaboratoryEquipment)((ITTObject)this).GetParent("EQUIPMENT"); }
            set { this["EQUIPMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Numuneyi Test İçin Kabul Eden Kaynak İlişkisi
    /// </summary>
        public ResUser AcceptResource
        {
            get { return (ResUser)((ITTObject)this).GetParent("ACCEPTRESOURCE"); }
            set { this["ACCEPTRESOURCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Numuneyi Kabul Eden Kullanıcı Bilgisinin İlişkisi
    /// </summary>
        public ResUser AcceptUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("ACCEPTUSER"); }
            set { this["ACCEPTUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İşlemin Bölümü İlişkisi
    /// </summary>
        public Resource ProcedureDepartment
        {
            get { return (Resource)((ITTObject)this).GetParent("PROCEDUREDEPARTMENT"); }
            set { this["PROCEDUREDEPARTMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Test İşlemini Yapan Kullanıcı İlişkisi
    /// </summary>
        public ResUser ProcedureUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("PROCEDUREUSER"); }
            set { this["PROCEDUREUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Test İsteğini Yapan Kaynak İlişkisi
    /// </summary>
        public Resource RequestResource
        {
            get { return (Resource)((ITTObject)this).GetParent("REQUESTRESOURCE"); }
            set { this["REQUESTRESOURCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İstek Yapan Kullanıcı İlişkisi
    /// </summary>
        public ResUser RequestUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("REQUESTUSER"); }
            set { this["REQUESTUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Örnek Kaynak İlişkisi
    /// </summary>
        public Resource SampleResource
        {
            get { return (Resource)((ITTObject)this).GetParent("SAMPLERESOURCE"); }
            set { this["SAMPLERESOURCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Örnek Alan Kullanıcı İlişkisi
    /// </summary>
        public ResUser SampleUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("SAMPLEUSER"); }
            set { this["SAMPLEUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public LaboratoryProcedure LaboratoryProcedure
        {
            get 
            {   
                if (MasterSubActionProcedure is LaboratoryProcedure)
                    return (LaboratoryProcedure)MasterSubActionProcedure; 
                return null;
            }            
            set { MasterSubActionProcedure = value; }
        }

        protected LaboratorySubProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected LaboratorySubProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected LaboratorySubProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected LaboratorySubProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected LaboratorySubProcedure(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "LABORATORYSUBPROCEDURE", dataRow) { }
        protected LaboratorySubProcedure(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "LABORATORYSUBPROCEDURE", dataRow, isImported) { }
        public LaboratorySubProcedure(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public LaboratorySubProcedure(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public LaboratorySubProcedure() : base() { }

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