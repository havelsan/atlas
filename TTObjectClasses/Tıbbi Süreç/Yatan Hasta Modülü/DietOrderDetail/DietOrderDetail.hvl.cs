
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DietOrderDetail")] 

    /// <summary>
    /// Yatan Hasta Diyet
    /// </summary>
    public  partial class DietOrderDetail : BaseDietOrderDetail, ITreatmentMaterialCollection, IWorkListEpisodeAction, IWorkListInpatient
    {
        public class DietOrderDetailList : TTObjectCollection<DietOrderDetail> { }
                    
        public class ChildDietOrderDetailCollection : TTObject.TTChildObjectCollection<DietOrderDetail>
        {
            public ChildDietOrderDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDietOrderDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetDODByPhysicianApplicationAndDate_Class : TTReportNqlObject 
        {
            public Object Statusname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["STATUSNAME"]);
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

            public Guid? Typeid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["TYPEID"]);
                }
            }

            public DateTime? PeriodStartTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PERIODSTARTTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDER"].AllPropertyDefs["PERIODSTARTTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? Breakfast
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BREAKFAST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEALTYPES"].AllPropertyDefs["BREAKFAST"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Dinner
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DINNER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEALTYPES"].AllPropertyDefs["DINNER"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Lunch
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LUNCH"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEALTYPES"].AllPropertyDefs["LUNCH"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? NightBreakfast
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NIGHTBREAKFAST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEALTYPES"].AllPropertyDefs["NIGHTBREAKFAST"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Snack1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SNACK1"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEALTYPES"].AllPropertyDefs["SNACK1"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Snack2
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SNACK2"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEALTYPES"].AllPropertyDefs["SNACK2"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Snack3
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SNACK3"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEALTYPES"].AllPropertyDefs["SNACK3"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDERDETAIL"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDERDETAIL"].AllPropertyDefs["ELIGIBLE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDERDETAIL"].AllPropertyDefs["REASONOFCANCEL"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDERDETAIL"].AllPropertyDefs["WORKLISTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDERDETAIL"].AllPropertyDefs["PRICINGDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDERDETAIL"].AllPropertyDefs["AMOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDERDETAIL"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDERDETAIL"].AllPropertyDefs["EMERGENCY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDERDETAIL"].AllPropertyDefs["ACTIVE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDERDETAIL"].AllPropertyDefs["OLAPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDERDETAIL"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDERDETAIL"].AllPropertyDefs["ACCOUNTOPERATIONDONE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDERDETAIL"].AllPropertyDefs["ACCTRXSMULTIPLIEDBYAMOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDERDETAIL"].AllPropertyDefs["PATIENTPAY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDERDETAIL"].AllPropertyDefs["EXTRADESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDERDETAIL"].AllPropertyDefs["SUTRULESTATUS"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDERDETAIL"].AllPropertyDefs["DISCOUNTPERCENT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDERDETAIL"].AllPropertyDefs["PERFORMEDDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDERDETAIL"].AllPropertyDefs["CREATIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDERDETAIL"].AllPropertyDefs["ISOLDACTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDERDETAIL"].AllPropertyDefs["MEDULAREPORTNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDERDETAIL"].AllPropertyDefs["RIGHTLEFTINFORMATION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDERDETAIL"].AllPropertyDefs["REASONOFREJECT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public DateTime? ExecutionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXECUTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDERDETAIL"].AllPropertyDefs["EXECUTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? IsReported
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISREPORTED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDERDETAIL"].AllPropertyDefs["ISREPORTED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? AdditionalRation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADDITIONALRATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDERDETAIL"].AllPropertyDefs["ADDITIONALRATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ReportDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDERDETAIL"].AllPropertyDefs["REPORTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetDODByPhysicianApplicationAndDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDODByPhysicianApplicationAndDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDODByPhysicianApplicationAndDate_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDODByPhysicianApplication_RQ_Class : TTReportNqlObject 
        {
            public Object Statusname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["STATUSNAME"]);
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

            public Guid? Typeid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["TYPEID"]);
                }
            }

            public DateTime? PeriodStartTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PERIODSTARTTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDER"].AllPropertyDefs["PERIODSTARTTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? Breakfast
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BREAKFAST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEALTYPES"].AllPropertyDefs["BREAKFAST"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Dinner
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DINNER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEALTYPES"].AllPropertyDefs["DINNER"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Lunch
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LUNCH"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEALTYPES"].AllPropertyDefs["LUNCH"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? NightBreakfast
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NIGHTBREAKFAST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEALTYPES"].AllPropertyDefs["NIGHTBREAKFAST"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Snack1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SNACK1"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEALTYPES"].AllPropertyDefs["SNACK1"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Snack2
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SNACK2"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEALTYPES"].AllPropertyDefs["SNACK2"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Snack3
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SNACK3"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEALTYPES"].AllPropertyDefs["SNACK3"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDERDETAIL"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDERDETAIL"].AllPropertyDefs["ELIGIBLE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDERDETAIL"].AllPropertyDefs["REASONOFCANCEL"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDERDETAIL"].AllPropertyDefs["WORKLISTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDERDETAIL"].AllPropertyDefs["PRICINGDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDERDETAIL"].AllPropertyDefs["AMOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDERDETAIL"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDERDETAIL"].AllPropertyDefs["EMERGENCY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDERDETAIL"].AllPropertyDefs["ACTIVE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDERDETAIL"].AllPropertyDefs["OLAPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDERDETAIL"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDERDETAIL"].AllPropertyDefs["ACCOUNTOPERATIONDONE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDERDETAIL"].AllPropertyDefs["ACCTRXSMULTIPLIEDBYAMOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDERDETAIL"].AllPropertyDefs["PATIENTPAY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDERDETAIL"].AllPropertyDefs["EXTRADESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDERDETAIL"].AllPropertyDefs["SUTRULESTATUS"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDERDETAIL"].AllPropertyDefs["DISCOUNTPERCENT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDERDETAIL"].AllPropertyDefs["PERFORMEDDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDERDETAIL"].AllPropertyDefs["CREATIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDERDETAIL"].AllPropertyDefs["ISOLDACTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDERDETAIL"].AllPropertyDefs["MEDULAREPORTNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDERDETAIL"].AllPropertyDefs["RIGHTLEFTINFORMATION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDERDETAIL"].AllPropertyDefs["REASONOFREJECT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public DateTime? ExecutionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXECUTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDERDETAIL"].AllPropertyDefs["EXECUTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? IsReported
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISREPORTED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDERDETAIL"].AllPropertyDefs["ISREPORTED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? AdditionalRation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADDITIONALRATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDERDETAIL"].AllPropertyDefs["ADDITIONALRATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ReportDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDERDETAIL"].AllPropertyDefs["REPORTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetDODByPhysicianApplication_RQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDODByPhysicianApplication_RQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDODByPhysicianApplication_RQ_Class() : base() { }
        }

        [Serializable] 

        public partial class GetOldInfoForDietOrder_Class : TTReportNqlObject 
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

            public Object Objectdefname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["OBJECTDEFNAME"]);
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

            public bool? Breakfast
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BREAKFAST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEALTYPES"].AllPropertyDefs["BREAKFAST"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Lunch
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LUNCH"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEALTYPES"].AllPropertyDefs["LUNCH"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Dinner
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DINNER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEALTYPES"].AllPropertyDefs["DINNER"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? NightBreakfast
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NIGHTBREAKFAST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEALTYPES"].AllPropertyDefs["NIGHTBREAKFAST"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Snack1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SNACK1"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEALTYPES"].AllPropertyDefs["SNACK1"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Snack2
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SNACK2"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEALTYPES"].AllPropertyDefs["SNACK2"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Snack3
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SNACK3"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEALTYPES"].AllPropertyDefs["SNACK3"].DataType;
                    return (bool?)dataType.ConvertValue(val);
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

            public string Tedaviklinikadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TEDAVIKLINIKADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Yattigiklinikadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["YATTIGIKLINIKADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESWARD"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Sorumludoktoradi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SORUMLUDOKTORADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Odagrupadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ODAGRUPADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESROOMGROUP"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Odaadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ODAADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESROOM"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Yatakadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["YATAKADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESBED"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDERDETAIL"].AllPropertyDefs["WORKLISTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string OrderDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDER"].AllPropertyDefs["ORDERDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Currentstatename
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["CURRENTSTATENAME"]);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
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

            public DateTime? PeriodStartTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PERIODSTARTTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDER"].AllPropertyDefs["PERIODSTARTTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? PeriodEndTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PERIODENDTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDER"].AllPropertyDefs["PERIODENDTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetOldInfoForDietOrder_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOldInfoForDietOrder_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOldInfoForDietOrder_Class() : base() { }
        }

        [Serializable] 

        public partial class GetOldInfoCountForDietOrder_Class : TTReportNqlObject 
        {
            public Object Nqlcolumn
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["NQLCOLUMN"]);
                }
            }

            public GetOldInfoCountForDietOrder_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOldInfoCountForDietOrder_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOldInfoCountForDietOrder_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDietOrderDetailRationCount_Class : TTReportNqlObject 
        {
            public Object Count
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["COUNT"]);
                }
            }

            public Object Type
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TYPE"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetDietOrderDetailRationCount_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDietOrderDetailRationCount_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDietOrderDetailRationCount_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDietOrderDetailForWorkList_Class : TTReportNqlObject 
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

            public Object Objectdefname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["OBJECTDEFNAME"]);
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

            public bool? Breakfast
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BREAKFAST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEALTYPES"].AllPropertyDefs["BREAKFAST"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Lunch
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LUNCH"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEALTYPES"].AllPropertyDefs["LUNCH"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Dinner
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DINNER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEALTYPES"].AllPropertyDefs["DINNER"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? NightBreakfast
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NIGHTBREAKFAST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEALTYPES"].AllPropertyDefs["NIGHTBREAKFAST"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Snack1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SNACK1"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEALTYPES"].AllPropertyDefs["SNACK1"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Snack2
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SNACK2"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEALTYPES"].AllPropertyDefs["SNACK2"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Snack3
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SNACK3"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEALTYPES"].AllPropertyDefs["SNACK3"].DataType;
                    return (bool?)dataType.ConvertValue(val);
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

            public string Tedaviklinikadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TEDAVIKLINIKADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Yattigiklinikadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["YATTIGIKLINIKADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESWARD"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Sorumludoktoradi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SORUMLUDOKTORADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Odagrupadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ODAGRUPADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESROOMGROUP"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Odaadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ODAADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESROOM"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Yatakadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["YATAKADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESBED"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDERDETAIL"].AllPropertyDefs["WORKLISTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string OrderDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDER"].AllPropertyDefs["ORDERDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Currentstatename
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["CURRENTSTATENAME"]);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public GetDietOrderDetailForWorkList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDietOrderDetailForWorkList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDietOrderDetailForWorkList_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDODByNursingApp_Class : TTReportNqlObject 
        {
            public Guid? Orderobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ORDEROBJECTID"]);
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

            public Object Orderturu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ORDERTURU"]);
                }
            }

            public DateTime? Uygulama_tarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UYGULAMA_TARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDERDETAIL"].AllPropertyDefs["WORKLISTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Tedavi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TEDAVI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Tedavi_objectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["TEDAVI_OBJECTID"]);
                }
            }

            public String Durumu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DURUMU"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public string Aciklama
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACIKLAMA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDER"].AllPropertyDefs["ORDERDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public FrequencyEnum? Doz_araligi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOZ_ARALIGI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDER"].AllPropertyDefs["FREQUENCY"].DataType;
                    return (FrequencyEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public int? Doz_miktari
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOZ_MIKTARI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDER"].AllPropertyDefs["AMOUNTFORPERIOD"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Olusturma_tarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLUSTURMA_TARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETORDERDETAIL"].AllPropertyDefs["CREATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetDODByNursingApp_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDODByNursingApp_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDODByNursingApp_Class() : base() { }
        }

        [Serializable] 

        public partial class GetInpatientDietList_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Yatak
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["YATAK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESBED"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Oda
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ODA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESROOM"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Odagrup
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ODAGRUP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESROOMGROUP"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Servis
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SERVIS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESWARD"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public string Diyetturu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIYETTURU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? Kahvalti
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KAHVALTI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEALTYPES"].AllPropertyDefs["BREAKFAST"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Oglen
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OGLEN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEALTYPES"].AllPropertyDefs["LUNCH"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Aksam
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AKSAM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEALTYPES"].AllPropertyDefs["DINNER"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Gecekahvalti
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GECEKAHVALTI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEALTYPES"].AllPropertyDefs["NIGHTBREAKFAST"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Araogun1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ARAOGUN1"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEALTYPES"].AllPropertyDefs["SNACK1"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Araogun2
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ARAOGUN2"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEALTYPES"].AllPropertyDefs["SNACK2"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Araogun3
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ARAOGUN3"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEALTYPES"].AllPropertyDefs["SNACK3"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public GetInpatientDietList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetInpatientDietList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetInpatientDietList_Class() : base() { }
        }

        new public static class States
        {
            public static Guid Cancelled { get { return new Guid("57f8e667-16ff-450c-935d-9fc29c6faa0c"); } }
    /// <summary>
    /// Diyetisyen Onayladı
    /// </summary>
            public static Guid Completed { get { return new Guid("ff5d03cc-cf42-4715-8eb6-98ec97342009"); } }
            public static Guid Execution { get { return new Guid("37611801-c62d-434b-98d0-ed28e2f77ebb"); } }
            public static Guid Approval { get { return new Guid("257c52f9-ff28-4c5b-aaa5-90857e9501fc"); } }
        }

        public static BindingList<DietOrderDetail.GetDODByPhysicianApplicationAndDate_Class> GetDODByPhysicianApplicationAndDate(string INPATIENTPHYAPP, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIETORDERDETAIL"].QueryDefs["GetDODByPhysicianApplicationAndDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("INPATIENTPHYAPP", INPATIENTPHYAPP);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<DietOrderDetail.GetDODByPhysicianApplicationAndDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DietOrderDetail.GetDODByPhysicianApplicationAndDate_Class> GetDODByPhysicianApplicationAndDate(TTObjectContext objectContext, string INPATIENTPHYAPP, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIETORDERDETAIL"].QueryDefs["GetDODByPhysicianApplicationAndDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("INPATIENTPHYAPP", INPATIENTPHYAPP);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<DietOrderDetail.GetDODByPhysicianApplicationAndDate_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DietOrderDetail> GetDODByInpaitentPhysicianApp(TTObjectContext objectContext, string INPATIENTPHYAPP)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIETORDERDETAIL"].QueryDefs["GetDODByInpaitentPhysicianApp"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("INPATIENTPHYAPP", INPATIENTPHYAPP);

            return ((ITTQuery)objectContext).QueryObjects<DietOrderDetail>(queryDef, paramList);
        }

        public static BindingList<DietOrderDetail.GetDODByPhysicianApplication_RQ_Class> GetDODByPhysicianApplication_RQ(string INPATIENTPHYAPP, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIETORDERDETAIL"].QueryDefs["GetDODByPhysicianApplication_RQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("INPATIENTPHYAPP", INPATIENTPHYAPP);

            return TTReportNqlObject.QueryObjects<DietOrderDetail.GetDODByPhysicianApplication_RQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DietOrderDetail.GetDODByPhysicianApplication_RQ_Class> GetDODByPhysicianApplication_RQ(TTObjectContext objectContext, string INPATIENTPHYAPP, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIETORDERDETAIL"].QueryDefs["GetDODByPhysicianApplication_RQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("INPATIENTPHYAPP", INPATIENTPHYAPP);

            return TTReportNqlObject.QueryObjects<DietOrderDetail.GetDODByPhysicianApplication_RQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Yatan Hasta Diyet Geçmişi
    /// </summary>
        public static BindingList<DietOrderDetail.GetOldInfoForDietOrder_Class> GetOldInfoForDietOrder(Guid PATIENT, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIETORDERDETAIL"].QueryDefs["GetOldInfoForDietOrder"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<DietOrderDetail.GetOldInfoForDietOrder_Class>(queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Yatan Hasta Diyet Geçmişi
    /// </summary>
        public static BindingList<DietOrderDetail.GetOldInfoForDietOrder_Class> GetOldInfoForDietOrder(TTObjectContext objectContext, Guid PATIENT, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIETORDERDETAIL"].QueryDefs["GetOldInfoForDietOrder"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<DietOrderDetail.GetOldInfoForDietOrder_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Hasta Geçmişi Diet Sayısı
    /// </summary>
        public static BindingList<DietOrderDetail.GetOldInfoCountForDietOrder_Class> GetOldInfoCountForDietOrder(Guid PATIENT, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIETORDERDETAIL"].QueryDefs["GetOldInfoCountForDietOrder"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<DietOrderDetail.GetOldInfoCountForDietOrder_Class>(queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Hasta Geçmişi Diet Sayısı
    /// </summary>
        public static BindingList<DietOrderDetail.GetOldInfoCountForDietOrder_Class> GetOldInfoCountForDietOrder(TTObjectContext objectContext, Guid PATIENT, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIETORDERDETAIL"].QueryDefs["GetOldInfoCountForDietOrder"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<DietOrderDetail.GetOldInfoCountForDietOrder_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DietOrderDetail.GetDietOrderDetailRationCount_Class> GetDietOrderDetailRationCount(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIETORDERDETAIL"].QueryDefs["GetDietOrderDetailRationCount"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DietOrderDetail.GetDietOrderDetailRationCount_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DietOrderDetail.GetDietOrderDetailRationCount_Class> GetDietOrderDetailRationCount(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIETORDERDETAIL"].QueryDefs["GetDietOrderDetailRationCount"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DietOrderDetail.GetDietOrderDetailRationCount_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Raporu basılacakların listesi
    /// </summary>
        public static BindingList<DietOrderDetail> GetDietOrderDetaillistForReport(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIETORDERDETAIL"].QueryDefs["GetDietOrderDetaillistForReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<DietOrderDetail>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<DietOrderDetail.GetDietOrderDetailForWorkList_Class> GetDietOrderDetailForWorkList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIETORDERDETAIL"].QueryDefs["GetDietOrderDetailForWorkList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DietOrderDetail.GetDietOrderDetailForWorkList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DietOrderDetail.GetDietOrderDetailForWorkList_Class> GetDietOrderDetailForWorkList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIETORDERDETAIL"].QueryDefs["GetDietOrderDetailForWorkList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DietOrderDetail.GetDietOrderDetailForWorkList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DietOrderDetail.GetDODByNursingApp_Class> GetDODByNursingApp(string NURSINGAPP, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIETORDERDETAIL"].QueryDefs["GetDODByNursingApp"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("NURSINGAPP", NURSINGAPP);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<DietOrderDetail.GetDODByNursingApp_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DietOrderDetail.GetDODByNursingApp_Class> GetDODByNursingApp(TTObjectContext objectContext, string NURSINGAPP, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIETORDERDETAIL"].QueryDefs["GetDODByNursingApp"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("NURSINGAPP", NURSINGAPP);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<DietOrderDetail.GetDODByNursingApp_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DietOrderDetail.GetInpatientDietList_Class> GetInpatientDietList(DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIETORDERDETAIL"].QueryDefs["GetInpatientDietList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<DietOrderDetail.GetInpatientDietList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DietOrderDetail.GetInpatientDietList_Class> GetInpatientDietList(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIETORDERDETAIL"].QueryDefs["GetInpatientDietList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<DietOrderDetail.GetInpatientDietList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Rasyon Raporu Alındı mı
    /// </summary>
        public bool? IsReported
        {
            get { return (bool?)this["ISREPORTED"]; }
            set { this["ISREPORTED"] = value; }
        }

    /// <summary>
    /// Ek rasyon raporu ile alındı
    /// </summary>
        public bool? AdditionalRation
        {
            get { return (bool?)this["ADDITIONALRATION"]; }
            set { this["ADDITIONALRATION"] = value; }
        }

    /// <summary>
    /// Rapor Alma Tarihi
    /// </summary>
        public DateTime? ReportDate
        {
            get { return (DateTime?)this["REPORTDATE"]; }
            set { this["REPORTDATE"] = value; }
        }

        public InPatientPhysicianApplication InPatientPhysicianApplication
        {
            get 
            {   
                if (EpisodeAction is InPatientPhysicianApplication)
                    return (InPatientPhysicianApplication)EpisodeAction; 
                return null;
            }            
            set { EpisodeAction = value; }
        }

        protected DietOrderDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DietOrderDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DietOrderDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DietOrderDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DietOrderDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DIETORDERDETAIL", dataRow) { }
        protected DietOrderDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DIETORDERDETAIL", dataRow, isImported) { }
        public DietOrderDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DietOrderDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DietOrderDetail() : base() { }

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