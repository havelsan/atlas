
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PlannedMedicalActionOrderDetail")] 

    /// <summary>
    /// Planlı Tıbbi İşlem Uygulama
    /// </summary>
    public  partial class PlannedMedicalActionOrderDetail : SubactionProcedureFlowable, IBaseAppointmentDef, IPatientWorkList, IReasonOfReject, ITreatmentMaterialCollection
    {
        public class PlannedMedicalActionOrderDetailList : TTObjectCollection<PlannedMedicalActionOrderDetail> { }
                    
        public class ChildPlannedMedicalActionOrderDetailCollection : TTObject.TTChildObjectCollection<PlannedMedicalActionOrderDetail>
        {
            public ChildPlannedMedicalActionOrderDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPlannedMedicalActionOrderDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetPlannedMedicalActionOrderDetails_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PLANNEDMEDICALACTIONORDERDETAIL"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PLANNEDMEDICALACTIONORDERDETAIL"].AllPropertyDefs["WORKLISTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PLANNEDMEDICALACTIONORDERDETAIL"].AllPropertyDefs["PRICINGDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PLANNEDMEDICALACTIONORDERDETAIL"].AllPropertyDefs["EMERGENCY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PLANNEDMEDICALACTIONORDER"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? Plannedmedicactionreqobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PLANNEDMEDICACTIONREQOBJECTID"]);
                }
            }

            public long? Orderobjectduration
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDEROBJECTDURATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PLANNEDMEDICALACTIONORDER"].AllPropertyDefs["DURATION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PLANNEDMEDICALACTIONORDER"].AllPropertyDefs["APPLICATIONAREA"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PLANNEDMEDICALACTIONORDER"].AllPropertyDefs["AMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string Treatmentunitname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TREATMENTUNITNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PLANNEDMEDICALACTIONORDER"].AllPropertyDefs["TREATMENTPROPERTIES"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetPlannedMedicalActionOrderDetails_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPlannedMedicalActionOrderDetails_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPlannedMedicalActionOrderDetails_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPlannedMedicalActionOrderDetailsForPatient_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PLANNEDMEDICALACTIONORDERDETAIL"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PLANNEDMEDICALACTIONORDERDETAIL"].AllPropertyDefs["WORKLISTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PLANNEDMEDICALACTIONORDERDETAIL"].AllPropertyDefs["PRICINGDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PLANNEDMEDICALACTIONORDERDETAIL"].AllPropertyDefs["EMERGENCY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PLANNEDMEDICALACTIONORDER"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? Pplannedmedicactionreqobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PPLANNEDMEDICACTIONREQOBJECTID"]);
                }
            }

            public long? Orderobjectduration
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDEROBJECTDURATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PLANNEDMEDICALACTIONORDER"].AllPropertyDefs["DURATION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PLANNEDMEDICALACTIONORDER"].AllPropertyDefs["APPLICATIONAREA"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PLANNEDMEDICALACTIONORDER"].AllPropertyDefs["AMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string Treatmentunitname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TREATMENTUNITNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PLANNEDMEDICALACTIONORDER"].AllPropertyDefs["TREATMENTPROPERTIES"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetPlannedMedicalActionOrderDetailsForPatient_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPlannedMedicalActionOrderDetailsForPatient_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPlannedMedicalActionOrderDetailsForPatient_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPlannedMedicalActionOrderDetailsByOrderObject_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PLANNEDMEDICALACTIONORDERDETAIL"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PLANNEDMEDICALACTIONORDERDETAIL"].AllPropertyDefs["WORKLISTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PLANNEDMEDICALACTIONORDERDETAIL"].AllPropertyDefs["PRICINGDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PLANNEDMEDICALACTIONORDERDETAIL"].AllPropertyDefs["EMERGENCY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PLANNEDMEDICALACTIONORDERDETAIL"].AllPropertyDefs["NOTE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PLANNEDMEDICALACTIONORDER"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? Plannedmedicactionreqobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PLANNEDMEDICACTIONREQOBJECTID"]);
                }
            }

            public long? Orderobjectduration
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDEROBJECTDURATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PLANNEDMEDICALACTIONORDER"].AllPropertyDefs["DURATION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PLANNEDMEDICALACTIONORDER"].AllPropertyDefs["APPLICATIONAREA"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PLANNEDMEDICALACTIONORDER"].AllPropertyDefs["AMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string Treatmentunitname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TREATMENTUNITNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PLANNEDMEDICALACTIONORDER"].AllPropertyDefs["TREATMENTPROPERTIES"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetPlannedMedicalActionOrderDetailsByOrderObject_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPlannedMedicalActionOrderDetailsByOrderObject_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPlannedMedicalActionOrderDetailsByOrderObject_Class() : base() { }
        }

        [Serializable] 

        public partial class PlannedMedicalActionOrderDetailEpic_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PLANNEDMEDICALACTIONORDERDETAIL"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PLANNEDMEDICALACTIONORDERDETAIL"].AllPropertyDefs["WORKLISTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PLANNEDMEDICALACTIONORDERDETAIL"].AllPropertyDefs["PRICINGDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PLANNEDMEDICALACTIONORDERDETAIL"].AllPropertyDefs["EMERGENCY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PLANNEDMEDICALACTIONORDER"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? Plannedmedicactionreqobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PLANNEDMEDICACTIONREQOBJECTID"]);
                }
            }

            public long? Orderobjectduration
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDEROBJECTDURATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PLANNEDMEDICALACTIONORDER"].AllPropertyDefs["DURATION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PLANNEDMEDICALACTIONORDER"].AllPropertyDefs["APPLICATIONAREA"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PLANNEDMEDICALACTIONORDER"].AllPropertyDefs["AMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string Treatmentunitname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TREATMENTUNITNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PLANNEDMEDICALACTIONORDER"].AllPropertyDefs["TREATMENTPROPERTIES"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public PlannedMedicalActionOrderDetailEpic_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public PlannedMedicalActionOrderDetailEpic_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected PlannedMedicalActionOrderDetailEpic_Class() : base() { }
        }

        new public static class States
        {
    /// <summary>
    /// Doktor İptal Onayı
    /// </summary>
            public static Guid ApprovalForCancel { get { return new Guid("63233421-37cb-46c1-88c2-94e38b27d88e"); } }
            public static Guid Cancelled { get { return new Guid("a162a73a-2643-4c49-8a05-b69e2615cb6b"); } }
            public static Guid Completed { get { return new Guid("3a83c701-7281-45bb-a719-616b55bccc9c"); } }
            public static Guid Execution { get { return new Guid("9ba0e940-f3a0-4f86-b6d8-43e6ea319663"); } }
        }

        public static BindingList<PlannedMedicalActionOrderDetail.GetPlannedMedicalActionOrderDetails_Class> GetPlannedMedicalActionOrderDetails(string ORDEROBJECT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PLANNEDMEDICALACTIONORDERDETAIL"].QueryDefs["GetPlannedMedicalActionOrderDetails"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ORDEROBJECT", ORDEROBJECT);

            return TTReportNqlObject.QueryObjects<PlannedMedicalActionOrderDetail.GetPlannedMedicalActionOrderDetails_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PlannedMedicalActionOrderDetail.GetPlannedMedicalActionOrderDetails_Class> GetPlannedMedicalActionOrderDetails(TTObjectContext objectContext, string ORDEROBJECT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PLANNEDMEDICALACTIONORDERDETAIL"].QueryDefs["GetPlannedMedicalActionOrderDetails"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ORDEROBJECT", ORDEROBJECT);

            return TTReportNqlObject.QueryObjects<PlannedMedicalActionOrderDetail.GetPlannedMedicalActionOrderDetails_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PlannedMedicalActionOrderDetail.GetPlannedMedicalActionOrderDetailsForPatient_Class> GetPlannedMedicalActionOrderDetailsForPatient(string ORDEROBJECT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PLANNEDMEDICALACTIONORDERDETAIL"].QueryDefs["GetPlannedMedicalActionOrderDetailsForPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ORDEROBJECT", ORDEROBJECT);

            return TTReportNqlObject.QueryObjects<PlannedMedicalActionOrderDetail.GetPlannedMedicalActionOrderDetailsForPatient_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PlannedMedicalActionOrderDetail.GetPlannedMedicalActionOrderDetailsForPatient_Class> GetPlannedMedicalActionOrderDetailsForPatient(TTObjectContext objectContext, string ORDEROBJECT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PLANNEDMEDICALACTIONORDERDETAIL"].QueryDefs["GetPlannedMedicalActionOrderDetailsForPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ORDEROBJECT", ORDEROBJECT);

            return TTReportNqlObject.QueryObjects<PlannedMedicalActionOrderDetail.GetPlannedMedicalActionOrderDetailsForPatient_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PlannedMedicalActionOrderDetail.GetPlannedMedicalActionOrderDetailsByOrderObject_Class> GetPlannedMedicalActionOrderDetailsByOrderObject(string ORDEROBJECT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PLANNEDMEDICALACTIONORDERDETAIL"].QueryDefs["GetPlannedMedicalActionOrderDetailsByOrderObject"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ORDEROBJECT", ORDEROBJECT);

            return TTReportNqlObject.QueryObjects<PlannedMedicalActionOrderDetail.GetPlannedMedicalActionOrderDetailsByOrderObject_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PlannedMedicalActionOrderDetail.GetPlannedMedicalActionOrderDetailsByOrderObject_Class> GetPlannedMedicalActionOrderDetailsByOrderObject(TTObjectContext objectContext, string ORDEROBJECT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PLANNEDMEDICALACTIONORDERDETAIL"].QueryDefs["GetPlannedMedicalActionOrderDetailsByOrderObject"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ORDEROBJECT", ORDEROBJECT);

            return TTReportNqlObject.QueryObjects<PlannedMedicalActionOrderDetail.GetPlannedMedicalActionOrderDetailsByOrderObject_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PlannedMedicalActionOrderDetail.PlannedMedicalActionOrderDetailEpic_Class> PlannedMedicalActionOrderDetailEpic(string EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PLANNEDMEDICALACTIONORDERDETAIL"].QueryDefs["PlannedMedicalActionOrderDetailEpic"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<PlannedMedicalActionOrderDetail.PlannedMedicalActionOrderDetailEpic_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PlannedMedicalActionOrderDetail.PlannedMedicalActionOrderDetailEpic_Class> PlannedMedicalActionOrderDetailEpic(TTObjectContext objectContext, string EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PLANNEDMEDICALACTIONORDERDETAIL"].QueryDefs["PlannedMedicalActionOrderDetailEpic"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<PlannedMedicalActionOrderDetail.PlannedMedicalActionOrderDetailEpic_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PlannedMedicalActionOrderDetail> GetPlannedMedicalActionOrderDetailsByEpisode(TTObjectContext objectContext, string EPISODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PLANNEDMEDICALACTIONORDERDETAIL"].QueryDefs["GetPlannedMedicalActionOrderDetailsByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return ((ITTQuery)objectContext).QueryObjects<PlannedMedicalActionOrderDetail>(queryDef, paramList);
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
    /// Doktor İade Sebebi
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
    /// Dr Anestezi Tescil No
    /// </summary>
        public string DrAnesteziTescilNo
        {
            get { return (string)this["DRANESTEZITESCILNO"]; }
            set { this["DRANESTEZITESCILNO"] = value; }
        }

    /// <summary>
    /// Rapor Takip Numarası
    /// </summary>
        public string RaporTakipNo
        {
            get { return (string)this["RAPORTAKIPNO"]; }
            set { this["RAPORTAKIPNO"] = value; }
        }

        public AyniFarkliKesi AyniFarkliKesi
        {
            get { return (AyniFarkliKesi)((ITTObject)this).GetParent("AYNIFARKLIKESI"); }
            set { this["AYNIFARKLIKESI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public OzelDurum OzelDurum
        {
            get { return (OzelDurum)((ITTObject)this).GetParent("OZELDURUM"); }
            set { this["OZELDURUM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResUser ResUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESUSER"); }
            set { this["RESUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PlannedMedicalActionRequest PlannedMedicalActionRequest
        {
            get 
            {   
                if (EpisodeAction is PlannedMedicalActionRequest)
                    return (PlannedMedicalActionRequest)EpisodeAction; 
                return null;
            }            
            set { EpisodeAction = value; }
        }

        virtual protected void CreateCokluOzelDurumCollection()
        {
            _CokluOzelDurum = new CokluOzelDurum.ChildCokluOzelDurumCollection(this, new Guid("cbad44e5-38fc-4ef7-95dd-f7aee1793529"));
            ((ITTChildObjectCollection)_CokluOzelDurum).GetChildren();
        }

        protected CokluOzelDurum.ChildCokluOzelDurumCollection _CokluOzelDurum = null;
        public CokluOzelDurum.ChildCokluOzelDurumCollection CokluOzelDurum
        {
            get
            {
                if (_CokluOzelDurum == null)
                    CreateCokluOzelDurumCollection();
                return _CokluOzelDurum;
            }
        }

        override protected void CreateTreatmentMaterialsCollectionViews()
        {
            base.CreateTreatmentMaterialsCollectionViews();
            _PlannedMedicalActionTreatmentMaterials = new PlannedMedicalActionTreatmentMaterial.ChildPlannedMedicalActionTreatmentMaterialCollection(_TreatmentMaterials, "PlannedMedicalActionTreatmentMaterials");
        }

        private PlannedMedicalActionTreatmentMaterial.ChildPlannedMedicalActionTreatmentMaterialCollection _PlannedMedicalActionTreatmentMaterials = null;
        public PlannedMedicalActionTreatmentMaterial.ChildPlannedMedicalActionTreatmentMaterialCollection PlannedMedicalActionTreatmentMaterials
        {
            get
            {
                if (_TreatmentMaterials == null)
                    CreateTreatmentMaterialsCollection();
                return _PlannedMedicalActionTreatmentMaterials;
            }            
        }

        protected PlannedMedicalActionOrderDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PlannedMedicalActionOrderDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PlannedMedicalActionOrderDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PlannedMedicalActionOrderDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PlannedMedicalActionOrderDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PLANNEDMEDICALACTIONORDERDETAIL", dataRow) { }
        protected PlannedMedicalActionOrderDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PLANNEDMEDICALACTIONORDERDETAIL", dataRow, isImported) { }
        public PlannedMedicalActionOrderDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PlannedMedicalActionOrderDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PlannedMedicalActionOrderDetail() : base() { }

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