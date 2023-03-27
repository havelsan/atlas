
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SubactionProcedureFlowable")] 

    public  partial class SubactionProcedureFlowable : SubActionProcedure, IEpisodeActionResources, IAccountOperation, IEpisodeActionPermission, IEpisodeAction
    {
        public class SubactionProcedureFlowableList : TTObjectCollection<SubactionProcedureFlowable> { }
                    
        public class ChildSubactionProcedureFlowableCollection : TTObject.TTChildObjectCollection<SubactionProcedureFlowable>
        {
            public ChildSubactionProcedureFlowableCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSubactionProcedureFlowableCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetUncompletedSPFsByEpisode_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetUncompletedSPFsByEpisode_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetUncompletedSPFsByEpisode_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetUncompletedSPFsByEpisode_Class() : base() { }
        }

        [Serializable] 

        public partial class GetBySPFWorklistDateReport_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetBySPFWorklistDateReport_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetBySPFWorklistDateReport_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetBySPFWorklistDateReport_Class() : base() { }
        }

        [Serializable] 

        public partial class GetBySPFFilterExpressionReport_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Object Patientfullname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTFULLNAME"]);
                }
            }

            public string Fromresourcename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FROMRESOURCENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["WORKLISTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Masterresourcename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MASTERRESOURCENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Secmasterresourcename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SECMASTERRESOURCENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? Emergency
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EMERGENCY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["EMERGENCY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public Guid? Patientobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PATIENTOBJECTID"]);
                }
            }

            public Object Patientgroup
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTGROUP"]);
                }
            }

            public bool? Foreign
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FOREIGN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["FOREIGN"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public double? ForeignUniqueRefNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FOREIGNUNIQUEREFNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["FOREIGNUNIQUEREFNO"].DataType;
                    return (double?)dataType.ConvertValue(val);
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

            public string Proceduredoctorname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDUREDOCTORNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Descriptionforworklist
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTIONFORWORKLIST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? OrderObject
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ORDEROBJECT"]);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public GetBySPFFilterExpressionReport_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetBySPFFilterExpressionReport_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetBySPFFilterExpressionReport_Class() : base() { }
        }

        [Serializable] 

        public partial class GetSubactionProceduresByObjectIDs_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["ELIGIBLE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["REASONOFCANCEL"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["WORKLISTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["PRICINGDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["AMOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["EMERGENCY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["ACTIVE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["OLAPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["ACCOUNTOPERATIONDONE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["ACCTRXSMULTIPLIEDBYAMOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["PATIENTPAY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["EXTRADESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["SUTRULESTATUS"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["DISCOUNTPERCENT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["PERFORMEDDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["CREATIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["ISOLDACTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["MEDULAREPORTNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["RIGHTLEFTINFORMATION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["REASONOFREJECT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public GetSubactionProceduresByObjectIDs_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSubactionProceduresByObjectIDs_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSubactionProceduresByObjectIDs_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPatientFolderEpisodeSubactions_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["ELIGIBLE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["REASONOFCANCEL"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["WORKLISTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["PRICINGDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["AMOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["EMERGENCY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["ACTIVE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["OLAPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["ACCOUNTOPERATIONDONE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["ACCTRXSMULTIPLIEDBYAMOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["PATIENTPAY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["EXTRADESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["SUTRULESTATUS"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["DISCOUNTPERCENT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["PERFORMEDDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["CREATIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["ISOLDACTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["MEDULAREPORTNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["RIGHTLEFTINFORMATION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["REASONOFREJECT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public string Masterresourcename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MASTERRESOURCENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Fromresourcename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FROMRESOURCENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? EpisodeAction
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODEACTION"]);
                }
            }

            public string Descriptionforworklist
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTIONFORWORKLIST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetPatientFolderEpisodeSubactions_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPatientFolderEpisodeSubactions_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPatientFolderEpisodeSubactions_Class() : base() { }
        }

        [Serializable] 

        public partial class GetEndOfDayConsultationPoliclinicReport_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Proceduredoctorname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDUREDOCTORNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? Tcno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TCNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["UNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public double? Fno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["FOREIGNUNIQUEREFNO"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string Hastaadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASTAADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Hastasoyadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASTASOYADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Patientgroup
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTGROUP"]);
                }
            }

            public long? Hprotocolno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HPROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["HOSPITALPROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Guid? MasterResource
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MASTERRESOURCE"]);
                }
            }

            public string Masterresourcename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MASTERRESOURCENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Episode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODE"]);
                }
            }

            public DateTime? OpeningDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OPENINGDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["OPENINGDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? Patientid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PATIENTID"]);
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

            public string Sicilno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SICILNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["EMPLOYMENTRECORDID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Patient
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PATIENT"]);
                }
            }

            public UserTitleEnum? Doctitle
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCTITLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["TITLE"].DataType;
                    return (UserTitleEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Docrank
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCRANK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RANKDEFINITIONS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Docname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetEndOfDayConsultationPoliclinicReport_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetEndOfDayConsultationPoliclinicReport_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetEndOfDayConsultationPoliclinicReport_Class() : base() { }
        }

        [Serializable] 

        public partial class VEM_TETKIK_ORNEK_Class : TTReportNqlObject 
        {
            public Guid? Tetkik_ornek_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["TETKIK_ORNEK_KODU"]);
                }
            }

            public Object Referans_tablo_adi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["REFERANS_TABLO_ADI"]);
                }
            }

            public Guid? Hasta_basvuru_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["HASTA_BASVURU_KODU"]);
                }
            }

            public Object Ornek_numarasi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ORNEK_NUMARASI"]);
                }
            }

            public Guid? Birim_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["BIRIM_KODU"]);
                }
            }

            public DateTime? Ornek_alma_zamani
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORNEK_ALMA_ZAMANI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["LABREQUESTACCEPTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Kabul_zamani
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KABUL_ZAMANI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["SAMPLEACCEPTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Object Barkod_numarasi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["BARKOD_NUMARASI"]);
                }
            }

            public DateTime? Barkod_zamani
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BARKOD_ZAMANI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["SAMPLEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? Ornek_alan_kullanici_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ORNEK_ALAN_KULLANICI_KODU"]);
                }
            }

            public Guid? Kabul_eden_kullanici_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["KABUL_EDEN_KULLANICI_KODU"]);
                }
            }

            public Guid? Ret_nedeni_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["RET_NEDENI_KODU"]);
                }
            }

            public Guid? Ret_eden_kullanici_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["RET_EDEN_KULLANICI_KODU"]);
                }
            }

            public Object Ret_zamani
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["RET_ZAMANI"]);
                }
            }

            public Object Aciliyet_durumu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ACILIYET_DURUMU"]);
                }
            }

            public Object Entegrasyon_barkodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ENTEGRASYON_BARKODU"]);
                }
            }

            public Object Ekleyen_kullanici_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["EKLEYEN_KULLANICI_KODU"]);
                }
            }

            public Object Guncelleme_tarihi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["GUNCELLEME_TARIHI"]);
                }
            }

            public Object Guncelleyen_kullanici_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["GUNCELLEYEN_KULLANICI_KODU"]);
                }
            }

            public VEM_TETKIK_ORNEK_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public VEM_TETKIK_ORNEK_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected VEM_TETKIK_ORNEK_Class() : base() { }
        }

        [Serializable] 

        public partial class VEM_TETKIK_SONUC_Class : TTReportNqlObject 
        {
            public Guid? Tetkik_sonuc_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["TETKIK_SONUC_KODU"]);
                }
            }

            public Object Referans_tablo_adi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["REFERANS_TABLO_ADI"]);
                }
            }

            public Guid? Tetkik_ornek_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["TETKIK_ORNEK_KODU"]);
                }
            }

            public Object Tetkik_parametre_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TETKIK_PARAMETRE_KODU"]);
                }
            }

            public Guid? Tetkik_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["TETKIK_KODU"]);
                }
            }

            public string Tetkik_adi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TETKIK_ADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Hasta_hizmet_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["HASTA_HIZMET_KODU"]);
                }
            }

            public string Sonuc
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SONUC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["RESULT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? Sonuc_zamani
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SONUC_ZAMANI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["RESULTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Object Ret_nedeni_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["RET_NEDENI_KODU"]);
                }
            }

            public Object Ret_eden_kullanici_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["RET_EDEN_KULLANICI_KODU"]);
                }
            }

            public Object Ret_zamani
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["RET_ZAMANI"]);
                }
            }

            public Object Panik_referans
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PANIK_REFERANS"]);
                }
            }

            public DateTime? Calisma_baslama_zamani
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CALISMA_BASLAMA_ZAMANI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["LABREQUESTACCEPTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Calisma_bitis_zamani
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CALISMA_BITIS_ZAMANI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["RESULTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Onaylayan_teknisyen_kodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ONAYLAYAN_TEKNISYEN_KODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["TECHNICIANID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? Teknisyen_onay_zamani
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TEKNISYEN_ONAY_ZAMANI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["RESULTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Uzman_onay_zamani
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UZMAN_ONAY_ZAMANI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["RESULTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Object Loinc_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["LOINC_KODU"]);
                }
            }

            public Object Tekrar_calisma_durumu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TEKRAR_CALISMA_DURUMU"]);
                }
            }

            public Object Manuel_sonuc_durumu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MANUEL_SONUC_DURUMU"]);
                }
            }

            public Object Ureme_durumu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["UREME_DURUMU"]);
                }
            }

            public DateTime? Onay_tarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ONAY_TARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["RESULTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Object Cihaz_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["CIHAZ_KODU"]);
                }
            }

            public string Cihaz_sonucu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CIHAZ_SONUCU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["RESULT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Tetkik_sonucu_birimi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TETKIK_SONUCU_BIRIMI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["UNIT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Tetkik_sonucu_referans_degeri
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TETKIK_SONUCU_REFERANS_DEGERI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["REFERENCE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Tetkik_sonucu_durumu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TETKIK_SONUCU_DURUMU"]);
                }
            }

            public Object Rapor_yazan_personel_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["RAPOR_YAZAN_PERSONEL_KODU"]);
                }
            }

            public Guid? Ekleyen_kullanici_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EKLEYEN_KULLANICI_KODU"]);
                }
            }

            public Object Guncelleme_tarihi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["GUNCELLEME_TARIHI"]);
                }
            }

            public Object Guncelleyen_kullanici_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["GUNCELLEYEN_KULLANICI_KODU"]);
                }
            }

            public VEM_TETKIK_SONUC_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public VEM_TETKIK_SONUC_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected VEM_TETKIK_SONUC_Class() : base() { }
        }

        [Serializable] 

        public partial class DisTetkikIstemRaporTestsNQL_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["ELIGIBLE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["REASONOFCANCEL"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["WORKLISTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["PRICINGDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["AMOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["EMERGENCY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["ACTIVE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["OLAPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["ACCOUNTOPERATIONDONE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["ACCTRXSMULTIPLIEDBYAMOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["PATIENTPAY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["EXTRADESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["SUTRULESTATUS"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["DISCOUNTPERCENT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["PERFORMEDDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["CREATIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["ISOLDACTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["MEDULAREPORTNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["RIGHTLEFTINFORMATION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["REASONOFREJECT"].DataType;
                    return (object)dataType.ConvertValue(val);
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

            public Guid? Sex
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SEX"]);
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

            public Object Cityname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["CITYNAME"]);
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

            public string Fromres
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FROMRES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? Requestdate2
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE2"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? Protocolno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["HOSPITALPROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Object Reasonforadm
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["REASONFORADM"]);
                }
            }

            public DateTime? Actdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public long? Actionid
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Pcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Pname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Requesteduser
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["REQUESTEDUSER"]);
                }
            }

            public DisTetkikIstemRaporTestsNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public DisTetkikIstemRaporTestsNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected DisTetkikIstemRaporTestsNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class GetSPFlowablesForPatientFolder_Class : TTReportNqlObject 
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

            public String Ttobjectdefname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TTOBJECTDEFNAME"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public string Fromresourcename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FROMRESOURCENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Masterresourcename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MASTERRESOURCENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Secmasterresourcename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SECMASTERRESOURCENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Actiondate
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                }
            }

            public Object Objectdisplaytext
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["OBJECTDISPLAYTEXT"]);
                }
            }

            public String Statedisplaytext
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STATEDISPLAYTEXT"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
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

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Descriptionforworklist
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTIONFORWORKLIST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetSPFlowablesForPatientFolder_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSPFlowablesForPatientFolder_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSPFlowablesForPatientFolder_Class() : base() { }
        }

        [Serializable] 

        public partial class DisTetkikİstemRaporNQL_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["ELIGIBLE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["REASONOFCANCEL"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["WORKLISTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["PRICINGDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["AMOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["EMERGENCY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["ACTIVE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["OLAPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["ACCOUNTOPERATIONDONE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["ACCTRXSMULTIPLIEDBYAMOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["PATIENTPAY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["EXTRADESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["SUTRULESTATUS"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["DISCOUNTPERCENT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["PERFORMEDDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["CREATIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["ISOLDACTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["MEDULAREPORTNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["RIGHTLEFTINFORMATION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["REASONOFREJECT"].DataType;
                    return (object)dataType.ConvertValue(val);
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

            public Guid? Sex
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SEX"]);
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

            public Object Cityname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["CITYNAME"]);
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

            public string Fromres
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FROMRES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? Requestdate2
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE2"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? Protocolno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["HOSPITALPROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Object Reasonforadm
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["REASONFORADM"]);
                }
            }

            public DateTime? Actdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public long? Actionid
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Pcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Pname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DisTetkikİstemRaporNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public DisTetkikİstemRaporNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected DisTetkikİstemRaporNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class TestQuery2_Class : TTReportNqlObject 
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

            public Object Patientfullname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTFULLNAME"]);
                }
            }

            public string Fromresourcename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FROMRESOURCENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["WORKLISTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Masterresourcename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MASTERRESOURCENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Secmasterresourcename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SECMASTERRESOURCENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? Emergency
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EMERGENCY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["EMERGENCY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public Guid? Patientobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PATIENTOBJECTID"]);
                }
            }

            public Object Patientgroup
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTGROUP"]);
                }
            }

            public bool? Foreign
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FOREIGN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["FOREIGN"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public double? ForeignUniqueRefNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FOREIGNUNIQUEREFNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["FOREIGNUNIQUEREFNO"].DataType;
                    return (double?)dataType.ConvertValue(val);
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

            public string Proceduredoctorname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDUREDOCTORNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Object Descriptionforworklist
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DESCRIPTIONFORWORKLIST"]);
                }
            }

            public TestQuery2_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public TestQuery2_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected TestQuery2_Class() : base() { }
        }

        new public static class States
        {
            public static Guid New { get { return new Guid("1c28a828-4470-46a5-af69-701b5322df1f"); } }
            public static Guid Completed { get { return new Guid("35536bbc-e567-46c8-be88-3bc9d65bfd5f"); } }
            public static Guid Cancelled { get { return new Guid("d16bf872-a7d1-476c-806d-92fd1852dccc"); } }
        }

        public static BindingList<SubactionProcedureFlowable> GetAllConsultationProcOfPatient(TTObjectContext objectContext, string PATIENTOBJECTID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].QueryDefs["GetAllConsultationProcOfPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTOBJECTID", PATIENTOBJECTID);

            return ((ITTQuery)objectContext).QueryObjects<SubactionProcedureFlowable>(queryDef, paramList);
        }

        public static BindingList<SubactionProcedureFlowable> GetByWorklistDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, DateTime MINDATE, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].QueryDefs["GetByWorklistDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("MINDATE", MINDATE);

            return ((ITTQuery)objectContext).QueryObjects<SubactionProcedureFlowable>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<SubactionProcedureFlowable> GetAllConsultationProcOfSubEpisode(TTObjectContext objectContext, string SUBEPISODE, string EPISODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].QueryDefs["GetAllConsultationProcOfSubEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);
            paramList.Add("EPISODE", EPISODE);

            return ((ITTQuery)objectContext).QueryObjects<SubactionProcedureFlowable>(queryDef, paramList);
        }

        public static BindingList<SubactionProcedureFlowable> GetSubactionProceduresByEpisodeAction(TTObjectContext objectContext, string EPISODEACTION)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].QueryDefs["GetSubactionProceduresByEpisodeAction"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEACTION", EPISODEACTION);

            return ((ITTQuery)objectContext).QueryObjects<SubactionProcedureFlowable>(queryDef, paramList);
        }

        public static BindingList<SubactionProcedureFlowable.GetUncompletedSPFsByEpisode_Class> GetUncompletedSPFsByEpisode(Guid EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].QueryDefs["GetUncompletedSPFsByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<SubactionProcedureFlowable.GetUncompletedSPFsByEpisode_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SubactionProcedureFlowable.GetUncompletedSPFsByEpisode_Class> GetUncompletedSPFsByEpisode(TTObjectContext objectContext, Guid EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].QueryDefs["GetUncompletedSPFsByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<SubactionProcedureFlowable.GetUncompletedSPFsByEpisode_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SubactionProcedureFlowable> GetAllConsultationProceduresOfPatient(TTObjectContext objectContext, Guid PATIENT)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].QueryDefs["GetAllConsultationProceduresOfPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return ((ITTQuery)objectContext).QueryObjects<SubactionProcedureFlowable>(queryDef, paramList);
        }

        public static BindingList<SubactionProcedureFlowable> GetByFilterExpression(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].QueryDefs["GetByFilterExpression"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<SubactionProcedureFlowable>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<SubactionProcedureFlowable.GetBySPFWorklistDateReport_Class> GetBySPFWorklistDateReport(DateTime STARTDATE, DateTime ENDDATE, DateTime MINDATE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].QueryDefs["GetBySPFWorklistDateReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("MINDATE", MINDATE);

            return TTReportNqlObject.QueryObjects<SubactionProcedureFlowable.GetBySPFWorklistDateReport_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SubactionProcedureFlowable.GetBySPFWorklistDateReport_Class> GetBySPFWorklistDateReport(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, DateTime MINDATE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].QueryDefs["GetBySPFWorklistDateReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("MINDATE", MINDATE);

            return TTReportNqlObject.QueryObjects<SubactionProcedureFlowable.GetBySPFWorklistDateReport_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SubactionProcedureFlowable.GetBySPFFilterExpressionReport_Class> GetBySPFFilterExpressionReport(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].QueryDefs["GetBySPFFilterExpressionReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SubactionProcedureFlowable.GetBySPFFilterExpressionReport_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SubactionProcedureFlowable.GetBySPFFilterExpressionReport_Class> GetBySPFFilterExpressionReport(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].QueryDefs["GetBySPFFilterExpressionReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SubactionProcedureFlowable.GetBySPFFilterExpressionReport_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SubactionProcedureFlowable.GetSubactionProceduresByObjectIDs_Class> GetSubactionProceduresByObjectIDs(IList<string> OBJECTIDS, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].QueryDefs["GetSubactionProceduresByObjectIDs"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTIDS", OBJECTIDS);

            return TTReportNqlObject.QueryObjects<SubactionProcedureFlowable.GetSubactionProceduresByObjectIDs_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SubactionProcedureFlowable.GetSubactionProceduresByObjectIDs_Class> GetSubactionProceduresByObjectIDs(TTObjectContext objectContext, IList<string> OBJECTIDS, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].QueryDefs["GetSubactionProceduresByObjectIDs"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTIDS", OBJECTIDS);

            return TTReportNqlObject.QueryObjects<SubactionProcedureFlowable.GetSubactionProceduresByObjectIDs_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SubactionProcedureFlowable> GetAllConsultationProcOfEpisode(TTObjectContext objectContext, string EPISODEOBJECTID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].QueryDefs["GetAllConsultationProcOfEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEOBJECTID", EPISODEOBJECTID);

            return ((ITTQuery)objectContext).QueryObjects<SubactionProcedureFlowable>(queryDef, paramList);
        }

        public static BindingList<SubactionProcedureFlowable.GetPatientFolderEpisodeSubactions_Class> GetPatientFolderEpisodeSubactions(Guid EPISODEID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].QueryDefs["GetPatientFolderEpisodeSubactions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEID", EPISODEID);

            return TTReportNqlObject.QueryObjects<SubactionProcedureFlowable.GetPatientFolderEpisodeSubactions_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SubactionProcedureFlowable.GetPatientFolderEpisodeSubactions_Class> GetPatientFolderEpisodeSubactions(TTObjectContext objectContext, Guid EPISODEID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].QueryDefs["GetPatientFolderEpisodeSubactions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEID", EPISODEID);

            return TTReportNqlObject.QueryObjects<SubactionProcedureFlowable.GetPatientFolderEpisodeSubactions_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SubactionProcedureFlowable.GetEndOfDayConsultationPoliclinicReport_Class> GetEndOfDayConsultationPoliclinicReport(DateTime STARTDATE, DateTime ENDDATE, Guid MASTERRESOURCE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].QueryDefs["GetEndOfDayConsultationPoliclinicReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("MASTERRESOURCE", MASTERRESOURCE);

            return TTReportNqlObject.QueryObjects<SubactionProcedureFlowable.GetEndOfDayConsultationPoliclinicReport_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SubactionProcedureFlowable.GetEndOfDayConsultationPoliclinicReport_Class> GetEndOfDayConsultationPoliclinicReport(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, Guid MASTERRESOURCE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].QueryDefs["GetEndOfDayConsultationPoliclinicReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("MASTERRESOURCE", MASTERRESOURCE);

            return TTReportNqlObject.QueryObjects<SubactionProcedureFlowable.GetEndOfDayConsultationPoliclinicReport_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SubactionProcedureFlowable.VEM_TETKIK_ORNEK_Class> VEM_TETKIK_ORNEK(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].QueryDefs["VEM_TETKIK_ORNEK"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SubactionProcedureFlowable.VEM_TETKIK_ORNEK_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SubactionProcedureFlowable.VEM_TETKIK_ORNEK_Class> VEM_TETKIK_ORNEK(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].QueryDefs["VEM_TETKIK_ORNEK"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SubactionProcedureFlowable.VEM_TETKIK_ORNEK_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SubactionProcedureFlowable.VEM_TETKIK_SONUC_Class> VEM_TETKIK_SONUC(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].QueryDefs["VEM_TETKIK_SONUC"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SubactionProcedureFlowable.VEM_TETKIK_SONUC_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SubactionProcedureFlowable.VEM_TETKIK_SONUC_Class> VEM_TETKIK_SONUC(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].QueryDefs["VEM_TETKIK_SONUC"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SubactionProcedureFlowable.VEM_TETKIK_SONUC_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SubactionProcedureFlowable.DisTetkikIstemRaporTestsNQL_Class> DisTetkikIstemRaporTestsNQL(Guid PARAMOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].QueryDefs["DisTetkikIstemRaporTestsNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJID", PARAMOBJID);

            return TTReportNqlObject.QueryObjects<SubactionProcedureFlowable.DisTetkikIstemRaporTestsNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SubactionProcedureFlowable.DisTetkikIstemRaporTestsNQL_Class> DisTetkikIstemRaporTestsNQL(TTObjectContext objectContext, Guid PARAMOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].QueryDefs["DisTetkikIstemRaporTestsNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJID", PARAMOBJID);

            return TTReportNqlObject.QueryObjects<SubactionProcedureFlowable.DisTetkikIstemRaporTestsNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SubactionProcedureFlowable.GetSPFlowablesForPatientFolder_Class> GetSPFlowablesForPatientFolder(Guid SUBEPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].QueryDefs["GetSPFlowablesForPatientFolder"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);

            return TTReportNqlObject.QueryObjects<SubactionProcedureFlowable.GetSPFlowablesForPatientFolder_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SubactionProcedureFlowable.GetSPFlowablesForPatientFolder_Class> GetSPFlowablesForPatientFolder(TTObjectContext objectContext, Guid SUBEPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].QueryDefs["GetSPFlowablesForPatientFolder"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);

            return TTReportNqlObject.QueryObjects<SubactionProcedureFlowable.GetSPFlowablesForPatientFolder_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SubactionProcedureFlowable> GetBySubEpisode(TTObjectContext objectContext, Guid SUBEPISODE, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].QueryDefs["GetBySubEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);

            return ((ITTQuery)objectContext).QueryObjects<SubactionProcedureFlowable>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<SubactionProcedureFlowable.DisTetkikİstemRaporNQL_Class> DisTetkikİstemRaporNQL(Guid PARAMOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].QueryDefs["DisTetkikİstemRaporNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJID", PARAMOBJID);

            return TTReportNqlObject.QueryObjects<SubactionProcedureFlowable.DisTetkikİstemRaporNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SubactionProcedureFlowable.DisTetkikİstemRaporNQL_Class> DisTetkikİstemRaporNQL(TTObjectContext objectContext, Guid PARAMOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].QueryDefs["DisTetkikİstemRaporNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJID", PARAMOBJID);

            return TTReportNqlObject.QueryObjects<SubactionProcedureFlowable.DisTetkikİstemRaporNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SubactionProcedureFlowable.TestQuery2_Class> TestQuery2(DateTime STARTDATE, DateTime ENDDATE, DateTime MINDATE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].QueryDefs["TestQuery2"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("MINDATE", MINDATE);

            return TTReportNqlObject.QueryObjects<SubactionProcedureFlowable.TestQuery2_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SubactionProcedureFlowable.TestQuery2_Class> TestQuery2(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, DateTime MINDATE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDUREFLOWABLE"].QueryDefs["TestQuery2"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("MINDATE", MINDATE);

            return TTReportNqlObject.QueryObjects<SubactionProcedureFlowable.TestQuery2_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public object ReasonOfReject
        {
            get { return (object)this["REASONOFREJECT"]; }
            set { this["REASONOFREJECT"] = value; }
        }

    /// <summary>
    /// MasterResource
    /// </summary>
        public ResSection MasterResource
        {
            get { return (ResSection)((ITTObject)this).GetParent("MASTERRESOURCE"); }
            set { this["MASTERRESOURCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Emir Detayları
    /// </summary>
        public PlannedAction OrderObject
        {
            get { return (PlannedAction)((ITTObject)this).GetParent("ORDEROBJECT"); }
            set { this["ORDEROBJECT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResSection SecondaryMasterResource
        {
            get { return (ResSection)((ITTObject)this).GetParent("SECONDARYMASTERRESOURCE"); }
            set { this["SECONDARYMASTERRESOURCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResSection FromResource
        {
            get { return (ResSection)((ITTObject)this).GetParent("FROMRESOURCE"); }
            set { this["FROMRESOURCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateAuthorizedUsersCollection()
        {
            _AuthorizedUsers = new AuthorizedUser.ChildAuthorizedUserCollection(this, new Guid("c9e136bf-6c35-46b2-b5ed-9826c144d86c"));
            ((ITTChildObjectCollection)_AuthorizedUsers).GetChildren();
        }

        protected AuthorizedUser.ChildAuthorizedUserCollection _AuthorizedUsers = null;
        public AuthorizedUser.ChildAuthorizedUserCollection AuthorizedUsers
        {
            get
            {
                if (_AuthorizedUsers == null)
                    CreateAuthorizedUsersCollection();
                return _AuthorizedUsers;
            }
        }

        virtual protected void CreateTreatmentMaterialsCollectionViews()
        {
        }

        virtual protected void CreateTreatmentMaterialsCollection()
        {
            _TreatmentMaterials = new BaseTreatmentMaterial.ChildBaseTreatmentMaterialCollection(this, new Guid("87970048-126d-4e7c-b392-dfcb3dac2aaf"));
            CreateTreatmentMaterialsCollectionViews();
            ((ITTChildObjectCollection)_TreatmentMaterials).GetChildren();
        }

        protected BaseTreatmentMaterial.ChildBaseTreatmentMaterialCollection _TreatmentMaterials = null;
        public BaseTreatmentMaterial.ChildBaseTreatmentMaterialCollection TreatmentMaterials
        {
            get
            {
                if (_TreatmentMaterials == null)
                    CreateTreatmentMaterialsCollection();
                return _TreatmentMaterials;
            }
        }

        virtual protected void CreateQueueItemsCollection()
        {
            _QueueItems = new ExaminationQueueItem.ChildExaminationQueueItemCollection(this, new Guid("ca5c83c3-ca73-4cc5-922a-a6310f1d03ef"));
            ((ITTChildObjectCollection)_QueueItems).GetChildren();
        }

        protected ExaminationQueueItem.ChildExaminationQueueItemCollection _QueueItems = null;
        public ExaminationQueueItem.ChildExaminationQueueItemCollection QueueItems
        {
            get
            {
                if (_QueueItems == null)
                    CreateQueueItemsCollection();
                return _QueueItems;
            }
        }

        virtual protected void CreateExaminationMeasesCollection()
        {
            _ExaminationMeases = new ExaminationMeasGrid.ChildExaminationMeasGridCollection(this, new Guid("f40304d9-a1bf-474d-9106-5c0fd26fb049"));
            ((ITTChildObjectCollection)_ExaminationMeases).GetChildren();
        }

        protected ExaminationMeasGrid.ChildExaminationMeasGridCollection _ExaminationMeases = null;
        public ExaminationMeasGrid.ChildExaminationMeasGridCollection ExaminationMeases
        {
            get
            {
                if (_ExaminationMeases == null)
                    CreateExaminationMeasesCollection();
                return _ExaminationMeases;
            }
        }

        protected SubactionProcedureFlowable(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SubactionProcedureFlowable(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SubactionProcedureFlowable(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SubactionProcedureFlowable(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SubactionProcedureFlowable(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SUBACTIONPROCEDUREFLOWABLE", dataRow) { }
        protected SubactionProcedureFlowable(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SUBACTIONPROCEDUREFLOWABLE", dataRow, isImported) { }
        public SubactionProcedureFlowable(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SubactionProcedureFlowable(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SubactionProcedureFlowable() : base() { }

    }
}