
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PhysiotherapyOrderDetail")] 

    /// <summary>
    /// F.T.R. Emrinin  Uygulamasının Gerçekleştirildiği NEsnedir
    /// </summary>
    public  partial class PhysiotherapyOrderDetail : BasePhysiotherapyOrderDetail, IBaseAppointmentDef, IReasonOfReject, ITreatmentMaterialCollection
    {
        public class PhysiotherapyOrderDetailList : TTObjectCollection<PhysiotherapyOrderDetail> { }
                    
        public class ChildPhysiotherapyOrderDetailCollection : TTObject.TTChildObjectCollection<PhysiotherapyOrderDetail>
        {
            public ChildPhysiotherapyOrderDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPhysiotherapyOrderDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetPhysiotherapyOrderDetails_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDERDETAIL"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? WorkListDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKLISTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDERDETAIL"].AllPropertyDefs["WORKLISTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDERDETAIL"].AllPropertyDefs["PRICINGDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDERDETAIL"].AllPropertyDefs["EMERGENCY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Treatmentroomname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TREATMENTROOMNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESTREATMENTDIAGNOSISROOM"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public Guid? Orderobjectobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ORDEROBJECTOBJECTID"]);
                }
            }

            public DateTime? Orderobjectactiondate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDEROBJECTACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? Physiotherapyrequestobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PHYSIOTHERAPYREQUESTOBJECTID"]);
                }
            }

            public long? Orderobjectduration
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDEROBJECTDURATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["DURATION"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Orderobjectproceduredoctor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDEROBJECTPROCEDUREDOCTOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Orderobjectapplicationarea
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDEROBJECTAPPLICATIONAREA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["APPLICATIONAREA"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? Orderobjectamount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDEROBJECTAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["AMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string Treatmentdiagnosisunitname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TREATMENTDIAGNOSISUNITNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESTREATMENTDIAGNOSISUNIT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Procedureobjectcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDUREOBJECTCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Procedureobjectname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDUREOBJECTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Orderobjecttreatmentproperties
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDEROBJECTTREATMENTPROPERTIES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["TREATMENTPROPERTIES"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetPhysiotherapyOrderDetails_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPhysiotherapyOrderDetails_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPhysiotherapyOrderDetails_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPhysiotherapyOrderDetailsForPatient_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDERDETAIL"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? WorkListDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKLISTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDERDETAIL"].AllPropertyDefs["WORKLISTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDERDETAIL"].AllPropertyDefs["PRICINGDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDERDETAIL"].AllPropertyDefs["EMERGENCY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Treatmentroomname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TREATMENTROOMNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESTREATMENTDIAGNOSISROOM"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public Guid? Orderobjectobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ORDEROBJECTOBJECTID"]);
                }
            }

            public DateTime? Orderobjectactiondate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDEROBJECTACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? Physiotherapyrequestobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PHYSIOTHERAPYREQUESTOBJECTID"]);
                }
            }

            public long? Orderobjectduration
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDEROBJECTDURATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["DURATION"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Orderobjectproceduredoctor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDEROBJECTPROCEDUREDOCTOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Orderobjectapplicationarea
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDEROBJECTAPPLICATIONAREA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["APPLICATIONAREA"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? Orderobjectamount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDEROBJECTAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["AMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string Treatmentdiagnosisunitname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TREATMENTDIAGNOSISUNITNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESTREATMENTDIAGNOSISUNIT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Procedureobjectcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDUREOBJECTCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Procedureobjectname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDUREOBJECTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Orderobjecttreatmentproperties
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDEROBJECTTREATMENTPROPERTIES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["TREATMENTPROPERTIES"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetPhysiotherapyOrderDetailsForPatient_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPhysiotherapyOrderDetailsForPatient_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPhysiotherapyOrderDetailsForPatient_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPhysiotherapyOrderDetailsByOrderObject_Class : TTReportNqlObject 
        {
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

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDERDETAIL"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? WorkListDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKLISTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDERDETAIL"].AllPropertyDefs["WORKLISTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDERDETAIL"].AllPropertyDefs["PRICINGDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDERDETAIL"].AllPropertyDefs["EMERGENCY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Treatmentroomname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TREATMENTROOMNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESTREATMENTDIAGNOSISROOM"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public object Note
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDERDETAIL"].AllPropertyDefs["NOTE"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public Guid? Orderobjectobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ORDEROBJECTOBJECTID"]);
                }
            }

            public DateTime? Orderobjectactiondate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDEROBJECTACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? Physiotherapyrequestobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PHYSIOTHERAPYREQUESTOBJECTID"]);
                }
            }

            public long? Orderobjectduration
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDEROBJECTDURATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["DURATION"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Orderobjectproceduredoctor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDEROBJECTPROCEDUREDOCTOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Orderobjectapplicationarea
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDEROBJECTAPPLICATIONAREA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["APPLICATIONAREA"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? Orderobjectamount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDEROBJECTAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["AMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string Treatmentdiagnosisunitname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TREATMENTDIAGNOSISUNITNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESTREATMENTDIAGNOSISUNIT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Procedureobjectcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDUREOBJECTCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Procedureobjectname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDUREOBJECTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Orderobjecttreatmentproperties
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDEROBJECTTREATMENTPROPERTIES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["TREATMENTPROPERTIES"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetPhysiotherapyOrderDetailsByOrderObject_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPhysiotherapyOrderDetailsByOrderObject_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPhysiotherapyOrderDetailsByOrderObject_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPhysiotherapyOrderDetailForWorkList_Class : TTReportNqlObject 
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

            public String Defname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DEFNAME"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
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

            public string Patientsurname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTSURNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? PlannedDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PLANNEDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDERDETAIL"].AllPropertyDefs["PLANNEDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Reportno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDERDETAIL"].AllPropertyDefs["RAPORTAKIPNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Treatmentroomname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TREATMENTROOMNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESTREATMENTDIAGNOSISROOM"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Treatmentdiagnosisunitname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TREATMENTDIAGNOSISUNITNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESTREATMENTDIAGNOSISUNIT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Procedureobjectname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDUREOBJECTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Dose
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOSE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["DOSE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Duration
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DURATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["DURATION"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public int? SessionNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SESSIONNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDERDETAIL"].AllPropertyDefs["SESSIONNUMBER"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public object DoctorReturnDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCTORRETURNDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDERDETAIL"].AllPropertyDefs["DOCTORRETURNDESCRIPTION"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object Note
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDERDETAIL"].AllPropertyDefs["NOTE"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public PhysiotherapyStateEnum? PhysiotherapyState
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PHYSIOTHERAPYSTATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDERDETAIL"].AllPropertyDefs["PHYSIOTHERAPYSTATE"].DataType;
                    return (PhysiotherapyStateEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string TreatmentProcessType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TREATMENTPROCESSTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREPORTS"].AllPropertyDefs["TREATMENTPROCESSTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Starterresusername
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STARTERRESUSERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Finisherresusername
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FINISHERRESUSERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
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

            public GetPhysiotherapyOrderDetailForWorkList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPhysiotherapyOrderDetailForWorkList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPhysiotherapyOrderDetailForWorkList_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPhysiotherapyOrderDetailByRequestObject_Class : TTReportNqlObject 
        {
            public Guid? EpisodeAction
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODEACTION"]);
                }
            }

            public Object Startdate
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["STARTDATE"]);
                }
            }

            public Object Finishdate
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["FINISHDATE"]);
                }
            }

            public GetPhysiotherapyOrderDetailByRequestObject_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPhysiotherapyOrderDetailByRequestObject_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPhysiotherapyOrderDetailByRequestObject_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPhysiotherapyOrderDetailByDate_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetPhysiotherapyOrderDetailByDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPhysiotherapyOrderDetailByDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPhysiotherapyOrderDetailByDate_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPhysiotherapyTreeList_Class : TTReportNqlObject 
        {
            public Guid? Orderdetailobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ORDERDETAILOBJECTID"]);
                }
            }

            public String Orderdetailobjectdef
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERDETAILOBJECTDEF"]);
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

            public string Applicationareadef
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["APPLICATIONAREADEF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FTRVUCUTBOLGESI"].AllPropertyDefs["FTRVUCUTBOLGESIADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Applicationareainfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["APPLICATIONAREAINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["APPLICATIONAREA"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Dose
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOSE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["DOSE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Duration
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DURATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["DURATION"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public bool? IsAdditionalProcess
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISADDITIONALPROCESS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDERDETAIL"].AllPropertyDefs["ISADDITIONALPROCESS"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Orderdetailplanneddate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERDETAILPLANNEDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDERDETAIL"].AllPropertyDefs["PLANNEDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? Orderobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ORDEROBJECTID"]);
                }
            }

            public string Physiotherapist
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PHYSIOTHERAPIST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public PhysiotherapyStateEnum? PhysiotherapyState
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PHYSIOTHERAPYSTATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDERDETAIL"].AllPropertyDefs["PHYSIOTHERAPYSTATE"].DataType;
                    return (PhysiotherapyStateEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public int? SessionNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SESSIONNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDERDETAIL"].AllPropertyDefs["SESSIONNUMBER"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string Treatmentdiagnosisunit
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TREATMENTDIAGNOSISUNIT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESTREATMENTDIAGNOSISUNIT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Procedureobject
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDUREOBJECT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Package
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PACKAGE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PACKAGEPROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string TreatmentProperties
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TREATMENTPROPERTIES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["TREATMENTPROPERTIES"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DoseDurationInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOSEDURATIONINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["DOSEDURATIONINFO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsAdditionalTreatment
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISADDITIONALTREATMENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["ISADDITIONALTREATMENT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Physessionplanneddate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PHYSESSIONPLANNEDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYSESSIONINFO"].AllPropertyDefs["PLANNEDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? Physiotherapysessionid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PHYSIOTHERAPYSESSIONID"]);
                }
            }

            public String Physiotherapysessiondef
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PHYSIOTHERAPYSESSIONDEF"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public GetPhysiotherapyTreeList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPhysiotherapyTreeList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPhysiotherapyTreeList_Class() : base() { }
        }

        new public static class States
        {
            public static Guid Completed { get { return new Guid("373a3889-a45a-4798-8c08-2f40d1a4d114"); } }
            public static Guid Cancelled { get { return new Guid("3a95ac76-226b-49a0-a647-7311e448dd1e"); } }
            public static Guid Execution { get { return new Guid("aefe43d7-28c7-4d7d-893c-3c44460f7f66"); } }
            public static Guid Aborted { get { return new Guid("9a48689c-fe08-4fb6-9c7b-42d1aba05519"); } }
    /// <summary>
    /// Doktor İptal Onayı
    /// </summary>
            public static Guid ApprovalForCancel { get { return new Guid("4e7cbada-e776-4007-9c6c-ab831698b184"); } }
        }

        public static BindingList<PhysiotherapyOrderDetail.GetPhysiotherapyOrderDetails_Class> GetPhysiotherapyOrderDetails(string ORDEROBJECT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDERDETAIL"].QueryDefs["GetPhysiotherapyOrderDetails"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ORDEROBJECT", ORDEROBJECT);

            return TTReportNqlObject.QueryObjects<PhysiotherapyOrderDetail.GetPhysiotherapyOrderDetails_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PhysiotherapyOrderDetail.GetPhysiotherapyOrderDetails_Class> GetPhysiotherapyOrderDetails(TTObjectContext objectContext, string ORDEROBJECT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDERDETAIL"].QueryDefs["GetPhysiotherapyOrderDetails"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ORDEROBJECT", ORDEROBJECT);

            return TTReportNqlObject.QueryObjects<PhysiotherapyOrderDetail.GetPhysiotherapyOrderDetails_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PhysiotherapyOrderDetail.GetPhysiotherapyOrderDetailsForPatient_Class> GetPhysiotherapyOrderDetailsForPatient(string ORDEROBJECT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDERDETAIL"].QueryDefs["GetPhysiotherapyOrderDetailsForPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ORDEROBJECT", ORDEROBJECT);

            return TTReportNqlObject.QueryObjects<PhysiotherapyOrderDetail.GetPhysiotherapyOrderDetailsForPatient_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PhysiotherapyOrderDetail.GetPhysiotherapyOrderDetailsForPatient_Class> GetPhysiotherapyOrderDetailsForPatient(TTObjectContext objectContext, string ORDEROBJECT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDERDETAIL"].QueryDefs["GetPhysiotherapyOrderDetailsForPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ORDEROBJECT", ORDEROBJECT);

            return TTReportNqlObject.QueryObjects<PhysiotherapyOrderDetail.GetPhysiotherapyOrderDetailsForPatient_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PhysiotherapyOrderDetail.GetPhysiotherapyOrderDetailsByOrderObject_Class> GetPhysiotherapyOrderDetailsByOrderObject(string ORDEROBJECT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDERDETAIL"].QueryDefs["GetPhysiotherapyOrderDetailsByOrderObject"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ORDEROBJECT", ORDEROBJECT);

            return TTReportNqlObject.QueryObjects<PhysiotherapyOrderDetail.GetPhysiotherapyOrderDetailsByOrderObject_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PhysiotherapyOrderDetail.GetPhysiotherapyOrderDetailsByOrderObject_Class> GetPhysiotherapyOrderDetailsByOrderObject(TTObjectContext objectContext, string ORDEROBJECT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDERDETAIL"].QueryDefs["GetPhysiotherapyOrderDetailsByOrderObject"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ORDEROBJECT", ORDEROBJECT);

            return TTReportNqlObject.QueryObjects<PhysiotherapyOrderDetail.GetPhysiotherapyOrderDetailsByOrderObject_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PhysiotherapyOrderDetail> GetPhyOrderDetsForPatientByOrderObject(TTObjectContext objectContext, string ORDEROBJECT, string PATIENT)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDERDETAIL"].QueryDefs["GetPhyOrderDetsForPatientByOrderObject"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ORDEROBJECT", ORDEROBJECT);
            paramList.Add("PATIENT", PATIENT);

            return ((ITTQuery)objectContext).QueryObjects<PhysiotherapyOrderDetail>(queryDef, paramList);
        }

    /// <summary>
    /// Fizyoterapi Detayları
    /// </summary>
        public static BindingList<PhysiotherapyOrderDetail.GetPhysiotherapyOrderDetailForWorkList_Class> GetPhysiotherapyOrderDetailForWorkList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDERDETAIL"].QueryDefs["GetPhysiotherapyOrderDetailForWorkList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PhysiotherapyOrderDetail.GetPhysiotherapyOrderDetailForWorkList_Class>(queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Fizyoterapi Detayları
    /// </summary>
        public static BindingList<PhysiotherapyOrderDetail.GetPhysiotherapyOrderDetailForWorkList_Class> GetPhysiotherapyOrderDetailForWorkList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDERDETAIL"].QueryDefs["GetPhysiotherapyOrderDetailForWorkList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PhysiotherapyOrderDetail.GetPhysiotherapyOrderDetailForWorkList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PhysiotherapyOrderDetail.GetPhysiotherapyOrderDetailByRequestObject_Class> GetPhysiotherapyOrderDetailByRequestObject(string REQUESTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDERDETAIL"].QueryDefs["GetPhysiotherapyOrderDetailByRequestObject"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("REQUESTOBJECTID", REQUESTOBJECTID);

            return TTReportNqlObject.QueryObjects<PhysiotherapyOrderDetail.GetPhysiotherapyOrderDetailByRequestObject_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PhysiotherapyOrderDetail.GetPhysiotherapyOrderDetailByRequestObject_Class> GetPhysiotherapyOrderDetailByRequestObject(TTObjectContext objectContext, string REQUESTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDERDETAIL"].QueryDefs["GetPhysiotherapyOrderDetailByRequestObject"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("REQUESTOBJECTID", REQUESTOBJECTID);

            return TTReportNqlObject.QueryObjects<PhysiotherapyOrderDetail.GetPhysiotherapyOrderDetailByRequestObject_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Planlama Tarihine Göre OrderDetail
    /// </summary>
        public static BindingList<PhysiotherapyOrderDetail.GetPhysiotherapyOrderDetailByDate_Class> GetPhysiotherapyOrderDetailByDate(DateTime PlannedDate, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDERDETAIL"].QueryDefs["GetPhysiotherapyOrderDetailByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PLANNEDDATE", PlannedDate);

            return TTReportNqlObject.QueryObjects<PhysiotherapyOrderDetail.GetPhysiotherapyOrderDetailByDate_Class>(queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Planlama Tarihine Göre OrderDetail
    /// </summary>
        public static BindingList<PhysiotherapyOrderDetail.GetPhysiotherapyOrderDetailByDate_Class> GetPhysiotherapyOrderDetailByDate(TTObjectContext objectContext, DateTime PlannedDate, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDERDETAIL"].QueryDefs["GetPhysiotherapyOrderDetailByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PLANNEDDATE", PlannedDate);

            return TTReportNqlObject.QueryObjects<PhysiotherapyOrderDetail.GetPhysiotherapyOrderDetailByDate_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PhysiotherapyOrderDetail.GetPhysiotherapyTreeList_Class> GetPhysiotherapyTreeList(string PHYSIOTHERAPYREQUEST, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDERDETAIL"].QueryDefs["GetPhysiotherapyTreeList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PHYSIOTHERAPYREQUEST", PHYSIOTHERAPYREQUEST);

            return TTReportNqlObject.QueryObjects<PhysiotherapyOrderDetail.GetPhysiotherapyTreeList_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PhysiotherapyOrderDetail.GetPhysiotherapyTreeList_Class> GetPhysiotherapyTreeList(TTObjectContext objectContext, string PHYSIOTHERAPYREQUEST, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDERDETAIL"].QueryDefs["GetPhysiotherapyTreeList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PHYSIOTHERAPYREQUEST", PHYSIOTHERAPYREQUEST);

            return TTReportNqlObject.QueryObjects<PhysiotherapyOrderDetail.GetPhysiotherapyTreeList_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// İptal Sebebi
    /// </summary>
        public object DoctorReturnDescription
        {
            get { return (object)this["DOCTORRETURNDESCRIPTION"]; }
            set { this["DOCTORRETURNDESCRIPTION"] = value; }
        }

    /// <summary>
    /// Fizyoterapist Notu
    /// </summary>
        public object Note
        {
            get { return (object)this["NOTE"]; }
            set { this["NOTE"] = value; }
        }

    /// <summary>
    /// İptal İsteği
    /// </summary>
        public object CancelRequestDescription
        {
            get { return (object)this["CANCELREQUESTDESCRIPTION"]; }
            set { this["CANCELREQUESTDESCRIPTION"] = value; }
        }

    /// <summary>
    /// Anestezi yapan doktorun diploma tescil numarası
    /// </summary>
        public string drAnesteziTescilNo
        {
            get { return (string)this["DRANESTEZITESCILNO"]; }
            set { this["DRANESTEZITESCILNO"] = value; }
        }

    /// <summary>
    /// Medula Kayıt Numarası
    /// </summary>
        public string raporTakipNo
        {
            get { return (string)this["RAPORTAKIPNO"]; }
            set { this["RAPORTAKIPNO"] = value; }
        }

    /// <summary>
    /// Hasta/İşlem Durumu
    /// </summary>
        public PhysiotherapyStateEnum? PhysiotherapyState
        {
            get { return (PhysiotherapyStateEnum?)(int?)this["PHYSIOTHERAPYSTATE"]; }
            set { this["PHYSIOTHERAPYSTATE"] = value; }
        }

    /// <summary>
    /// Ek İşlem
    /// </summary>
        public bool? IsAdditionalProcess
        {
            get { return (bool?)this["ISADDITIONALPROCESS"]; }
            set { this["ISADDITIONALPROCESS"] = value; }
        }

    /// <summary>
    /// Planlanan Tarih
    /// </summary>
        public DateTime? PlannedDate
        {
            get { return (DateTime?)this["PLANNEDDATE"]; }
            set { this["PLANNEDDATE"] = value; }
        }

    /// <summary>
    /// Otomatik olarak işlem gördü mü
    /// </summary>
        public bool? IsChangedAutomatically
        {
            get { return (bool?)this["ISCHANGEDAUTOMATICALLY"]; }
            set { this["ISCHANGEDAUTOMATICALLY"] = value; }
        }

    /// <summary>
    /// Seans Numarası
    /// </summary>
        public int? SessionNumber
        {
            get { return (int?)this["SESSIONNUMBER"]; }
            set { this["SESSIONNUMBER"] = value; }
        }

    /// <summary>
    /// Başlangıç Saati
    /// </summary>
        public DateTime? StartDate
        {
            get { return (DateTime?)this["STARTDATE"]; }
            set { this["STARTDATE"] = value; }
        }

    /// <summary>
    /// Başlangıç Saati
    /// </summary>
        public DateTime? FinishDate
        {
            get { return (DateTime?)this["FINISHDATE"]; }
            set { this["FINISHDATE"] = value; }
        }

    /// <summary>
    /// Başlatan Fizyoterapist
    /// </summary>
        public ResUser StarterResUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("STARTERRESUSER"); }
            set { this["STARTERRESUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Bitiren Fizyoterapist
    /// </summary>
        public ResUser FinisherResUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("FINISHERRESUSER"); }
            set { this["FINISHERRESUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Tedavi Odası
    /// </summary>
        public ResTreatmentDiagnosisRoom TreatmentRoom
        {
            get { return (ResTreatmentDiagnosisRoom)((ITTObject)this).GetParent("TREATMENTROOM"); }
            set { this["TREATMENTROOM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// silinecek!
    /// </summary>
        public ResUser ResUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESUSER"); }
            set { this["RESUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// PhysiotherapyOrderDetail OzelDurum
    /// </summary>
        public OzelDurum OzelDurum
        {
            get { return (OzelDurum)((ITTObject)this).GetParent("OZELDURUM"); }
            set { this["OZELDURUM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// PhysiotherapyOrderDetail AyniFarkliKesi
    /// </summary>
        public AyniFarkliKesi AyniFarkliKesi
        {
            get { return (AyniFarkliKesi)((ITTObject)this).GetParent("AYNIFARKLIKESI"); }
            set { this["AYNIFARKLIKESI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Fizyoterapi Seansları
    /// </summary>
        public PhysiotherapySessionInfo PhysiotherapySession
        {
            get { return (PhysiotherapySessionInfo)((ITTObject)this).GetParent("PHYSIOTHERAPYSESSION"); }
            set { this["PHYSIOTHERAPYSESSION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PhysiotherapyRequest PhysiotherapyRequest
        {
            get 
            {   
                if (EpisodeAction is PhysiotherapyRequest)
                    return (PhysiotherapyRequest)EpisodeAction; 
                return null;
            }            
            set { EpisodeAction = value; }
        }

    /// <summary>
    /// Emir Detayları
    /// </summary>
        public PhysiotherapyOrder PhysiotherapyOrder
        {
            get 
            {   
                if (OrderObject is PhysiotherapyOrder)
                    return (PhysiotherapyOrder)OrderObject; 
                return null;
            }            
            set { OrderObject = value; }
        }

        virtual protected void CreateCokluOzelDurumCollection()
        {
            _CokluOzelDurum = new CokluOzelDurum.ChildCokluOzelDurumCollection(this, new Guid("038cbabc-08eb-478a-b3e4-fb8baf83f6ea"));
            ((ITTChildObjectCollection)_CokluOzelDurum).GetChildren();
        }

        protected CokluOzelDurum.ChildCokluOzelDurumCollection _CokluOzelDurum = null;
    /// <summary>
    /// Child collection for PhysiotherapyOrderDetail CokluOzelDurum
    /// </summary>
        public CokluOzelDurum.ChildCokluOzelDurumCollection CokluOzelDurum
        {
            get
            {
                if (_CokluOzelDurum == null)
                    CreateCokluOzelDurumCollection();
                return _CokluOzelDurum;
            }
        }

        virtual protected void CreateFTRPackageProcedureCollection()
        {
            _FTRPackageProcedure = new FTRPackageProcedure.ChildFTRPackageProcedureCollection(this, new Guid("b8e695f2-ce20-437c-8d25-26f3c3410fae"));
            ((ITTChildObjectCollection)_FTRPackageProcedure).GetChildren();
        }

        protected FTRPackageProcedure.ChildFTRPackageProcedureCollection _FTRPackageProcedure = null;
        public FTRPackageProcedure.ChildFTRPackageProcedureCollection FTRPackageProcedure
        {
            get
            {
                if (_FTRPackageProcedure == null)
                    CreateFTRPackageProcedureCollection();
                return _FTRPackageProcedure;
            }
        }

        override protected void CreateTreatmentMaterialsCollectionViews()
        {
            base.CreateTreatmentMaterialsCollectionViews();
            _PhysiotherapyTreatmentMaterials = new PhysiotherapyTreatmentMaterial.ChildPhysiotherapyTreatmentMaterialCollection(_TreatmentMaterials, "PhysiotherapyTreatmentMaterials");
        }

        private PhysiotherapyTreatmentMaterial.ChildPhysiotherapyTreatmentMaterialCollection _PhysiotherapyTreatmentMaterials = null;
        public PhysiotherapyTreatmentMaterial.ChildPhysiotherapyTreatmentMaterialCollection PhysiotherapyTreatmentMaterials
        {
            get
            {
                if (_TreatmentMaterials == null)
                    CreateTreatmentMaterialsCollection();
                return _PhysiotherapyTreatmentMaterials;
            }            
        }

        protected PhysiotherapyOrderDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PhysiotherapyOrderDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PhysiotherapyOrderDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PhysiotherapyOrderDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PhysiotherapyOrderDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PHYSIOTHERAPYORDERDETAIL", dataRow) { }
        protected PhysiotherapyOrderDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PHYSIOTHERAPYORDERDETAIL", dataRow, isImported) { }
        public PhysiotherapyOrderDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PhysiotherapyOrderDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PhysiotherapyOrderDetail() : base() { }

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