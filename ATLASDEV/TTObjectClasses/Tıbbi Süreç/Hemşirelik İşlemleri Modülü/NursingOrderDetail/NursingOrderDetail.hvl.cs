
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="NursingOrderDetail")] 

    /// <summary>
    /// Hemşire Takip Gözlem Uygulaması (Klinik İşlemleri)
    /// </summary>
    public  partial class NursingOrderDetail : BaseNursingOrderDetails, ITreatmentMaterialCollection
    {
        public class NursingOrderDetailList : TTObjectCollection<NursingOrderDetail> { }
                    
        public class ChildNursingOrderDetailCollection : TTObject.TTChildObjectCollection<NursingOrderDetail>
        {
            public ChildNursingOrderDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildNursingOrderDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetByNursingOrderDetail_Class : TTReportNqlObject 
        {
            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ExecutionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXECUTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["EXECUTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? ProcedureObject
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDUREOBJECT"]);
                }
            }

            public string Result
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["RESULT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Notes
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["NOTES"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetByNursingOrderDetail_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetByNursingOrderDetail_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetByNursingOrderDetail_Class() : base() { }
        }

        [Serializable] 

        public partial class GetNODByNursingApplication_RQ_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDER"].AllPropertyDefs["PERIODSTARTTIME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDER"].AllPropertyDefs["ORDERDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Procedurebyuser
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDUREBYUSER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["ELIGIBLE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["REASONOFCANCEL"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["WORKLISTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["PRICINGDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["AMOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["EMERGENCY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["ACTIVE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["OLAPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["ACCOUNTOPERATIONDONE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["ACCTRXSMULTIPLIEDBYAMOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["PATIENTPAY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["EXTRADESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["SUTRULESTATUS"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["DISCOUNTPERCENT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["PERFORMEDDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["CREATIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["ISOLDACTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["MEDULAREPORTNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["RIGHTLEFTINFORMATION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["REASONOFREJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["EXECUTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Result
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["RESULT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Notes
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["NOTES"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Result_Pulse
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULT_PULSE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["RESULT_PULSE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ResultBloodPressure
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULTBLOODPRESSURE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["RESULTBLOODPRESSURE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Result_SPO2
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULT_SPO2"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["RESULT_SPO2"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetNODByNursingApplication_RQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetNODByNursingApplication_RQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetNODByNursingApplication_RQ_Class() : base() { }
        }

        [Serializable] 

        public partial class GetNursingOrderDetailByNursingApp_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["WORKLISTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDER"].AllPropertyDefs["ORDERDESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDER"].AllPropertyDefs["FREQUENCY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDER"].AllPropertyDefs["AMOUNTFORPERIOD"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["CREATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetNursingOrderDetailByNursingApp_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetNursingOrderDetailByNursingApp_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetNursingOrderDetailByNursingApp_Class() : base() { }
        }

        [Serializable] 

        public partial class GetNODByPhysicianApplication_RQ_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDER"].AllPropertyDefs["PERIODSTARTTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["ELIGIBLE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["REASONOFCANCEL"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["WORKLISTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["PRICINGDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["AMOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["EMERGENCY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["ACTIVE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["OLAPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["ACCOUNTOPERATIONDONE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["ACCTRXSMULTIPLIEDBYAMOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["PATIENTPAY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["EXTRADESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["SUTRULESTATUS"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["DISCOUNTPERCENT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["PERFORMEDDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["CREATIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["ISOLDACTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["MEDULAREPORTNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["RIGHTLEFTINFORMATION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["REASONOFREJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["EXECUTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Result
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["RESULT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Notes
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["NOTES"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Result_Pulse
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULT_PULSE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["RESULT_PULSE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ResultBloodPressure
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULTBLOODPRESSURE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["RESULTBLOODPRESSURE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Result_SPO2
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULT_SPO2"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["RESULT_SPO2"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetNODByPhysicianApplication_RQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetNODByPhysicianApplication_RQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetNODByPhysicianApplication_RQ_Class() : base() { }
        }

        [Serializable] 

        public partial class GetUnCompletedNODByMasterResource_Class : TTReportNqlObject 
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

            public Guid? Objid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJID"]);
                }
            }

            public DateTime? PeriodStartTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PERIODSTARTTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDER"].AllPropertyDefs["PERIODSTARTTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? Episode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODE"]);
                }
            }

            public string Masterresource_name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MASTERRESOURCE_NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Patient_name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENT_NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Patient_surname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENT_SURNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SURNAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["RESULT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Notes
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["NOTES"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["WORKLISTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public GetUnCompletedNODByMasterResource_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetUnCompletedNODByMasterResource_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetUnCompletedNODByMasterResource_Class() : base() { }
        }

        [Serializable] 

        public partial class GetNODByType_Class : TTReportNqlObject 
        {
            public string Result
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["RESULT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Notes
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["NOTES"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetNODByType_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetNODByType_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetNODByType_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDistinctExecutionDates_Class : TTReportNqlObject 
        {
            public DateTime? ExecutionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXECUTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["EXECUTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Notes
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["NOTES"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ProcedureByUser
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDUREBYUSER"]);
                }
            }

            public string Hemsire
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HEMSIRE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Procedurebyuser1
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDUREBYUSER1"]);
                }
            }

            public GetDistinctExecutionDates_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDistinctExecutionDates_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDistinctExecutionDates_Class() : base() { }
        }

        [Serializable] 

        public partial class GetNODByMasterResource_Class : TTReportNqlObject 
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

            public Guid? Objid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJID"]);
                }
            }

            public DateTime? PeriodStartTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PERIODSTARTTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDER"].AllPropertyDefs["PERIODSTARTTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? Episode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODE"]);
                }
            }

            public string Masterresource_name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MASTERRESOURCE_NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Patient_name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENT_NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Patient_surname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENT_SURNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Patientid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PATIENTID"]);
                }
            }

            public string Result
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["RESULT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Result_Pulse
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULT_PULSE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["RESULT_PULSE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ResultBloodPressure
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULTBLOODPRESSURE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["RESULTBLOODPRESSURE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Notes
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["NOTES"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["WORKLISTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
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

            public string Responsiblenurse
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESPONSIBLENURSE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Bed
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESBED"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Room
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ROOM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESROOM"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? HasFallingRisk
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASFALLINGRISK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASEINPATIENTADMISSION"].AllPropertyDefs["HASFALLINGRISK"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? HasAirborneContactIsolation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASAIRBORNECONTACTISOLATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASEINPATIENTADMISSION"].AllPropertyDefs["HASAIRBORNECONTACTISOLATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? HasDropletIsolation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASDROPLETISOLATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASEINPATIENTADMISSION"].AllPropertyDefs["HASDROPLETISOLATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? HasContactIsolation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASCONTACTISOLATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASEINPATIENTADMISSION"].AllPropertyDefs["HASCONTACTISOLATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? HasTightContactIsolation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASTIGHTCONTACTISOLATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASEINPATIENTADMISSION"].AllPropertyDefs["HASTIGHTCONTACTISOLATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Proceduredoctor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDUREDOCTOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Kabulno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KABULNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Kurum
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KURUM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Comingreason
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COMINGREASON"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROVIZYONTIPI"].AllPropertyDefs["PROVIZYONTIPIADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public PatientClassTypeEnum? Hastaturu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASTATURU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].AllPropertyDefs["PATIENTCLASSGROUP"].DataType;
                    return (PatientClassTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public ApplicationReasonEnum? Basvuruturu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BASVURUTURU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].AllPropertyDefs["APPLICATIONREASON"].DataType;
                    return (ApplicationReasonEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRIORITYSTATUSDEFINITION"].AllPropertyDefs["CODE"].DataType;
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

            public string MobilePhone
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MOBILEPHONE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTIDENTITYANDADDRESS"].AllPropertyDefs["MOBILEPHONE"].DataType;
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

            public int? YUPASSNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["YUPASSNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["YUPASSNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string Procedurebyuser
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDUREBYUSER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? ExecutionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXECUTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["EXECUTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetNODByMasterResource_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetNODByMasterResource_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetNODByMasterResource_Class() : base() { }
        }

        [Serializable] 

        public partial class GetNODByPhysicianApplicationAndDate_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDER"].AllPropertyDefs["PERIODSTARTTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["ELIGIBLE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["REASONOFCANCEL"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["WORKLISTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["PRICINGDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["AMOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["EMERGENCY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["ACTIVE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["OLAPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["ACCOUNTOPERATIONDONE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["ACCTRXSMULTIPLIEDBYAMOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["PATIENTPAY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["EXTRADESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["SUTRULESTATUS"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["DISCOUNTPERCENT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["PERFORMEDDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["CREATIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["ISOLDACTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["MEDULAREPORTNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["RIGHTLEFTINFORMATION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["REASONOFREJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["EXECUTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Result
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["RESULT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Notes
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["NOTES"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Result_Pulse
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULT_PULSE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["RESULT_PULSE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ResultBloodPressure
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULTBLOODPRESSURE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["RESULTBLOODPRESSURE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Result_SPO2
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULT_SPO2"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].AllPropertyDefs["RESULT_SPO2"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetNODByPhysicianApplicationAndDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetNODByPhysicianApplicationAndDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetNODByPhysicianApplicationAndDate_Class() : base() { }
        }

        new public static class States
        {
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("61c779a2-b25c-42ea-895d-48dc61acc255"); } }
            public static Guid Execution { get { return new Guid("95d0ea09-0398-42fc-ba11-45f2583520d3"); } }
            public static Guid Cancelled { get { return new Guid("75810ba6-7fd0-4124-821b-c05df44e3ca3"); } }
        }

        public static BindingList<NursingOrderDetail.GetByNursingOrderDetail_Class> GetByNursingOrderDetail(Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].QueryDefs["GetByNursingOrderDetail"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<NursingOrderDetail.GetByNursingOrderDetail_Class>(queryDef, paramList, pi);
        }

        public static BindingList<NursingOrderDetail.GetByNursingOrderDetail_Class> GetByNursingOrderDetail(TTObjectContext objectContext, Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].QueryDefs["GetByNursingOrderDetail"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<NursingOrderDetail.GetByNursingOrderDetail_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<NursingOrderDetail.GetNODByNursingApplication_RQ_Class> GetNODByNursingApplication_RQ(string NURSINGAPPLICATION, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].QueryDefs["GetNODByNursingApplication_RQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("NURSINGAPPLICATION", NURSINGAPPLICATION);

            return TTReportNqlObject.QueryObjects<NursingOrderDetail.GetNODByNursingApplication_RQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<NursingOrderDetail.GetNODByNursingApplication_RQ_Class> GetNODByNursingApplication_RQ(TTObjectContext objectContext, string NURSINGAPPLICATION, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].QueryDefs["GetNODByNursingApplication_RQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("NURSINGAPPLICATION", NURSINGAPPLICATION);

            return TTReportNqlObject.QueryObjects<NursingOrderDetail.GetNODByNursingApplication_RQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<NursingOrderDetail.GetNursingOrderDetailByNursingApp_Class> GetNursingOrderDetailByNursingApp(string NURSINGAPP, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].QueryDefs["GetNursingOrderDetailByNursingApp"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("NURSINGAPP", NURSINGAPP);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<NursingOrderDetail.GetNursingOrderDetailByNursingApp_Class>(queryDef, paramList, pi);
        }

        public static BindingList<NursingOrderDetail.GetNursingOrderDetailByNursingApp_Class> GetNursingOrderDetailByNursingApp(TTObjectContext objectContext, string NURSINGAPP, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].QueryDefs["GetNursingOrderDetailByNursingApp"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("NURSINGAPP", NURSINGAPP);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<NursingOrderDetail.GetNursingOrderDetailByNursingApp_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<NursingOrderDetail> GetNODByInPatientPhysicianApplication(TTObjectContext objectContext, string INPATIENTPHYAPP)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].QueryDefs["GetNODByInPatientPhysicianApplication"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("INPATIENTPHYAPP", INPATIENTPHYAPP);

            return ((ITTQuery)objectContext).QueryObjects<NursingOrderDetail>(queryDef, paramList);
        }

        public static BindingList<NursingOrderDetail.GetNODByPhysicianApplication_RQ_Class> GetNODByPhysicianApplication_RQ(string INPATIENTPHYAPP, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].QueryDefs["GetNODByPhysicianApplication_RQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("INPATIENTPHYAPP", INPATIENTPHYAPP);

            return TTReportNqlObject.QueryObjects<NursingOrderDetail.GetNODByPhysicianApplication_RQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<NursingOrderDetail.GetNODByPhysicianApplication_RQ_Class> GetNODByPhysicianApplication_RQ(TTObjectContext objectContext, string INPATIENTPHYAPP, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].QueryDefs["GetNODByPhysicianApplication_RQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("INPATIENTPHYAPP", INPATIENTPHYAPP);

            return TTReportNqlObject.QueryObjects<NursingOrderDetail.GetNODByPhysicianApplication_RQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<NursingOrderDetail.GetUnCompletedNODByMasterResource_Class> GetUnCompletedNODByMasterResource(DateTime ENDDATE, DateTime STARTDATE, IList<Guid> MASTERRESOURCES, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].QueryDefs["GetUnCompletedNODByMasterResource"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("MASTERRESOURCES", MASTERRESOURCES);

            return TTReportNqlObject.QueryObjects<NursingOrderDetail.GetUnCompletedNODByMasterResource_Class>(queryDef, paramList, pi);
        }

        public static BindingList<NursingOrderDetail.GetUnCompletedNODByMasterResource_Class> GetUnCompletedNODByMasterResource(TTObjectContext objectContext, DateTime ENDDATE, DateTime STARTDATE, IList<Guid> MASTERRESOURCES, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].QueryDefs["GetUnCompletedNODByMasterResource"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("MASTERRESOURCES", MASTERRESOURCES);

            return TTReportNqlObject.QueryObjects<NursingOrderDetail.GetUnCompletedNODByMasterResource_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<NursingOrderDetail.GetNODByType_Class> GetNODByType(Guid NURSINGAPPLICATION, string TYPENAME, DateTime EXECUTIONDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].QueryDefs["GetNODByType"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("NURSINGAPPLICATION", NURSINGAPPLICATION);
            paramList.Add("TYPENAME", TYPENAME);
            paramList.Add("EXECUTIONDATE", EXECUTIONDATE);

            return TTReportNqlObject.QueryObjects<NursingOrderDetail.GetNODByType_Class>(queryDef, paramList, pi);
        }

        public static BindingList<NursingOrderDetail.GetNODByType_Class> GetNODByType(TTObjectContext objectContext, Guid NURSINGAPPLICATION, string TYPENAME, DateTime EXECUTIONDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].QueryDefs["GetNODByType"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("NURSINGAPPLICATION", NURSINGAPPLICATION);
            paramList.Add("TYPENAME", TYPENAME);
            paramList.Add("EXECUTIONDATE", EXECUTIONDATE);

            return TTReportNqlObject.QueryObjects<NursingOrderDetail.GetNODByType_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<NursingOrderDetail.GetDistinctExecutionDates_Class> GetDistinctExecutionDates(Guid NURSINGAPPLICATION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].QueryDefs["GetDistinctExecutionDates"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("NURSINGAPPLICATION", NURSINGAPPLICATION);

            return TTReportNqlObject.QueryObjects<NursingOrderDetail.GetDistinctExecutionDates_Class>(queryDef, paramList, pi);
        }

        public static BindingList<NursingOrderDetail.GetDistinctExecutionDates_Class> GetDistinctExecutionDates(TTObjectContext objectContext, Guid NURSINGAPPLICATION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].QueryDefs["GetDistinctExecutionDates"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("NURSINGAPPLICATION", NURSINGAPPLICATION);

            return TTReportNqlObject.QueryObjects<NursingOrderDetail.GetDistinctExecutionDates_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<NursingOrderDetail.GetNODByMasterResource_Class> GetNODByMasterResource(IList<Guid> MASTERRESOURCES, DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].QueryDefs["GetNODByMasterResource"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MASTERRESOURCES", MASTERRESOURCES);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<NursingOrderDetail.GetNODByMasterResource_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<NursingOrderDetail.GetNODByMasterResource_Class> GetNODByMasterResource(TTObjectContext objectContext, IList<Guid> MASTERRESOURCES, DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].QueryDefs["GetNODByMasterResource"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MASTERRESOURCES", MASTERRESOURCES);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<NursingOrderDetail.GetNODByMasterResource_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<NursingOrderDetail.GetNODByPhysicianApplicationAndDate_Class> GetNODByPhysicianApplicationAndDate(string INPATIENTPHYAPP, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].QueryDefs["GetNODByPhysicianApplicationAndDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("INPATIENTPHYAPP", INPATIENTPHYAPP);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<NursingOrderDetail.GetNODByPhysicianApplicationAndDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<NursingOrderDetail.GetNODByPhysicianApplicationAndDate_Class> GetNODByPhysicianApplicationAndDate(TTObjectContext objectContext, string INPATIENTPHYAPP, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].QueryDefs["GetNODByPhysicianApplicationAndDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("INPATIENTPHYAPP", INPATIENTPHYAPP);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<NursingOrderDetail.GetNODByPhysicianApplicationAndDate_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<NursingOrderDetail> GetNODByPeriodicOrder(TTObjectContext objectContext, string PERIODICORDER)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERDETAIL"].QueryDefs["GetNODByPeriodicOrder"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PERIODICORDER", PERIODICORDER);

            return ((ITTQuery)objectContext).QueryObjects<NursingOrderDetail>(queryDef, paramList);
        }

        public NursingApplication NursingApplication
        {
            get 
            {   
                if (EpisodeAction is NursingApplication)
                    return (NursingApplication)EpisodeAction; 
                return null;
            }            
            set { EpisodeAction = value; }
        }

        override protected void CreateTreatmentMaterialsCollectionViews()
        {
            base.CreateTreatmentMaterialsCollectionViews();
            _NursingOrderDetailTreatmentMaterials = new NursingOrderDetailTreatmentMaterial.ChildNursingOrderDetailTreatmentMaterialCollection(_TreatmentMaterials, "NursingOrderDetailTreatmentMaterials");
        }

        private NursingOrderDetailTreatmentMaterial.ChildNursingOrderDetailTreatmentMaterialCollection _NursingOrderDetailTreatmentMaterials = null;
        public NursingOrderDetailTreatmentMaterial.ChildNursingOrderDetailTreatmentMaterialCollection NursingOrderDetailTreatmentMaterials
        {
            get
            {
                if (_TreatmentMaterials == null)
                    CreateTreatmentMaterialsCollection();
                return _NursingOrderDetailTreatmentMaterials;
            }            
        }

        protected NursingOrderDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected NursingOrderDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected NursingOrderDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected NursingOrderDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected NursingOrderDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "NURSINGORDERDETAIL", dataRow) { }
        protected NursingOrderDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "NURSINGORDERDETAIL", dataRow, isImported) { }
        public NursingOrderDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public NursingOrderDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public NursingOrderDetail() : base() { }

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