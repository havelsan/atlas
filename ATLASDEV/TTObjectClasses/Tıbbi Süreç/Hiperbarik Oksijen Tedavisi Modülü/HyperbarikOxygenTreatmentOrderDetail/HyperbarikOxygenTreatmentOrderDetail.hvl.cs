
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HyperbarikOxygenTreatmentOrderDetail")] 

    /// <summary>
    /// Hiperbarik Oksijen Tedavisi Emrinin  Uygulamasının Gerçekleştirildiği Nesnedir
    /// </summary>
    public  partial class HyperbarikOxygenTreatmentOrderDetail : BaseHyperbarikOxygenTreatmentOrderDetail, IBaseAppointmentDef, IPatientWorkList, IReasonOfReject, ITreatmentMaterialCollection
    {
        public class HyperbarikOxygenTreatmentOrderDetailList : TTObjectCollection<HyperbarikOxygenTreatmentOrderDetail> { }
                    
        public class ChildHyperbarikOxygenTreatmentOrderDetailCollection : TTObject.TTChildObjectCollection<HyperbarikOxygenTreatmentOrderDetail>
        {
            public ChildHyperbarikOxygenTreatmentOrderDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHyperbarikOxygenTreatmentOrderDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetHyperbaricOrderDetailsByOrderObject_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARIKOXYGENTREATMENTORDERDETAIL"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARIKOXYGENTREATMENTORDERDETAIL"].AllPropertyDefs["WORKLISTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARIKOXYGENTREATMENTORDERDETAIL"].AllPropertyDefs["PRICINGDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARIKOXYGENTREATMENTORDERDETAIL"].AllPropertyDefs["EMERGENCY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Treatmentequipmentname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TREATMENTEQUIPMENTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESEQUIPMENT"].AllPropertyDefs["NAME"].DataType;
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

            public string Note
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARIKOXYGENTREATMENTORDERDETAIL"].AllPropertyDefs["NOTE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARICOXYGENTREATMENTORDER"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? Hbarikoxygentreatreqobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["HBARIKOXYGENTREATREQOBJECTID"]);
                }
            }

            public long? Orderobjectduration
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDEROBJECTDURATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARICOXYGENTREATMENTORDER"].AllPropertyDefs["DURATION"].DataType;
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

            public double? Orderobjectamount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDEROBJECTAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARICOXYGENTREATMENTORDER"].AllPropertyDefs["AMOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARICOXYGENTREATMENTDEFINITION"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARICOXYGENTREATMENTDEFINITION"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARICOXYGENTREATMENTORDER"].AllPropertyDefs["TREATMENTPROPERTIES"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? TreatmentDepth
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TREATMENTDEPTH"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARICOXYGENTREATMENTORDER"].AllPropertyDefs["TREATMENTDEPTH"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public GetHyperbaricOrderDetailsByOrderObject_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetHyperbaricOrderDetailsByOrderObject_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetHyperbaricOrderDetailsByOrderObject_Class() : base() { }
        }

        [Serializable] 

        public partial class GetHyperbaricOrderDetailsForPatient_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARIKOXYGENTREATMENTORDERDETAIL"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARIKOXYGENTREATMENTORDERDETAIL"].AllPropertyDefs["WORKLISTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARIKOXYGENTREATMENTORDERDETAIL"].AllPropertyDefs["PRICINGDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARIKOXYGENTREATMENTORDERDETAIL"].AllPropertyDefs["EMERGENCY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Treatmentequipmentname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TREATMENTEQUIPMENTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESEQUIPMENT"].AllPropertyDefs["NAME"].DataType;
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

            public string Note
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARIKOXYGENTREATMENTORDERDETAIL"].AllPropertyDefs["NOTE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARICOXYGENTREATMENTORDER"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? Hbarikoxygentreatreqobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["HBARIKOXYGENTREATREQOBJECTID"]);
                }
            }

            public long? Orderobjectduration
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDEROBJECTDURATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARICOXYGENTREATMENTORDER"].AllPropertyDefs["DURATION"].DataType;
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

            public double? Orderobjectamount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDEROBJECTAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARICOXYGENTREATMENTORDER"].AllPropertyDefs["AMOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARICOXYGENTREATMENTDEFINITION"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARICOXYGENTREATMENTDEFINITION"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARICOXYGENTREATMENTORDER"].AllPropertyDefs["TREATMENTPROPERTIES"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? TreatmentDepth
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TREATMENTDEPTH"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARICOXYGENTREATMENTORDER"].AllPropertyDefs["TREATMENTDEPTH"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public GetHyperbaricOrderDetailsForPatient_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetHyperbaricOrderDetailsForPatient_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetHyperbaricOrderDetailsForPatient_Class() : base() { }
        }

        [Serializable] 

        public partial class GetHyperbaricOrderDetails_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARIKOXYGENTREATMENTORDERDETAIL"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARIKOXYGENTREATMENTORDERDETAIL"].AllPropertyDefs["WORKLISTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARIKOXYGENTREATMENTORDERDETAIL"].AllPropertyDefs["PRICINGDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARIKOXYGENTREATMENTORDERDETAIL"].AllPropertyDefs["EMERGENCY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Treatmentequipmentname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TREATMENTEQUIPMENTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESEQUIPMENT"].AllPropertyDefs["NAME"].DataType;
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

            public string Note
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARIKOXYGENTREATMENTORDERDETAIL"].AllPropertyDefs["NOTE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARICOXYGENTREATMENTORDER"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? Hbarikoxygentreatreqobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["HBARIKOXYGENTREATREQOBJECTID"]);
                }
            }

            public long? Orderobjectduration
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDEROBJECTDURATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARICOXYGENTREATMENTORDER"].AllPropertyDefs["DURATION"].DataType;
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

            public double? Orderobjectamount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDEROBJECTAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARICOXYGENTREATMENTORDER"].AllPropertyDefs["AMOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARICOXYGENTREATMENTDEFINITION"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARICOXYGENTREATMENTDEFINITION"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARICOXYGENTREATMENTORDER"].AllPropertyDefs["TREATMENTPROPERTIES"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? TreatmentDepth
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TREATMENTDEPTH"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARICOXYGENTREATMENTORDER"].AllPropertyDefs["TREATMENTDEPTH"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public GetHyperbaricOrderDetails_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetHyperbaricOrderDetails_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetHyperbaricOrderDetails_Class() : base() { }
        }

        new public static class States
        {
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("355838cc-2e2e-4005-a346-246d284ee874"); } }
            public static Guid Cancelled { get { return new Guid("e50f9c2f-8e66-41e6-afd8-b148f05cb73f"); } }
            public static Guid Execution { get { return new Guid("479e7431-74c8-4a83-b4ef-c9049386aa9c"); } }
        }

        public static BindingList<HyperbarikOxygenTreatmentOrderDetail.GetHyperbaricOrderDetailsByOrderObject_Class> GetHyperbaricOrderDetailsByOrderObject(string ORDEROBJECT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HYPERBARIKOXYGENTREATMENTORDERDETAIL"].QueryDefs["GetHyperbaricOrderDetailsByOrderObject"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ORDEROBJECT", ORDEROBJECT);

            return TTReportNqlObject.QueryObjects<HyperbarikOxygenTreatmentOrderDetail.GetHyperbaricOrderDetailsByOrderObject_Class>(queryDef, paramList, pi);
        }

        public static BindingList<HyperbarikOxygenTreatmentOrderDetail.GetHyperbaricOrderDetailsByOrderObject_Class> GetHyperbaricOrderDetailsByOrderObject(TTObjectContext objectContext, string ORDEROBJECT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HYPERBARIKOXYGENTREATMENTORDERDETAIL"].QueryDefs["GetHyperbaricOrderDetailsByOrderObject"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ORDEROBJECT", ORDEROBJECT);

            return TTReportNqlObject.QueryObjects<HyperbarikOxygenTreatmentOrderDetail.GetHyperbaricOrderDetailsByOrderObject_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<HyperbarikOxygenTreatmentOrderDetail.GetHyperbaricOrderDetailsForPatient_Class> GetHyperbaricOrderDetailsForPatient(string ORDEROBJECT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HYPERBARIKOXYGENTREATMENTORDERDETAIL"].QueryDefs["GetHyperbaricOrderDetailsForPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ORDEROBJECT", ORDEROBJECT);

            return TTReportNqlObject.QueryObjects<HyperbarikOxygenTreatmentOrderDetail.GetHyperbaricOrderDetailsForPatient_Class>(queryDef, paramList, pi);
        }

        public static BindingList<HyperbarikOxygenTreatmentOrderDetail.GetHyperbaricOrderDetailsForPatient_Class> GetHyperbaricOrderDetailsForPatient(TTObjectContext objectContext, string ORDEROBJECT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HYPERBARIKOXYGENTREATMENTORDERDETAIL"].QueryDefs["GetHyperbaricOrderDetailsForPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ORDEROBJECT", ORDEROBJECT);

            return TTReportNqlObject.QueryObjects<HyperbarikOxygenTreatmentOrderDetail.GetHyperbaricOrderDetailsForPatient_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<HyperbarikOxygenTreatmentOrderDetail.GetHyperbaricOrderDetails_Class> GetHyperbaricOrderDetails(string ORDEROBJECT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HYPERBARIKOXYGENTREATMENTORDERDETAIL"].QueryDefs["GetHyperbaricOrderDetails"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ORDEROBJECT", ORDEROBJECT);

            return TTReportNqlObject.QueryObjects<HyperbarikOxygenTreatmentOrderDetail.GetHyperbaricOrderDetails_Class>(queryDef, paramList, pi);
        }

        public static BindingList<HyperbarikOxygenTreatmentOrderDetail.GetHyperbaricOrderDetails_Class> GetHyperbaricOrderDetails(TTObjectContext objectContext, string ORDEROBJECT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HYPERBARIKOXYGENTREATMENTORDERDETAIL"].QueryDefs["GetHyperbaricOrderDetails"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ORDEROBJECT", ORDEROBJECT);

            return TTReportNqlObject.QueryObjects<HyperbarikOxygenTreatmentOrderDetail.GetHyperbaricOrderDetails_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Asistan Notu
    /// </summary>
        public string Note
        {
            get { return (string)this["NOTE"]; }
            set { this["NOTE"] = value; }
        }

        public DateTime? ApplicationDate
        {
            get { return (DateTime?)this["APPLICATIONDATE"]; }
            set { this["APPLICATIONDATE"] = value; }
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

    /// <summary>
    /// Tedavi Cihazı
    /// </summary>
        public ResEquipment TreatmentEquipment
        {
            get { return (ResEquipment)((ITTObject)this).GetParent("TREATMENTEQUIPMENT"); }
            set { this["TREATMENTEQUIPMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public OzelDurum OzelDurum
        {
            get { return (OzelDurum)((ITTObject)this).GetParent("OZELDURUM"); }
            set { this["OZELDURUM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public AyniFarkliKesi AyniFarkliKesi
        {
            get { return (AyniFarkliKesi)((ITTObject)this).GetParent("AYNIFARKLIKESI"); }
            set { this["AYNIFARKLIKESI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResUser ResUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESUSER"); }
            set { this["RESUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateCokluOzelDurumCollection()
        {
            _CokluOzelDurum = new CokluOzelDurum.ChildCokluOzelDurumCollection(this, new Guid("17906037-34f3-4bb9-8ae5-7b66c54e29b8"));
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
            _HyperbarikOxygenTreatmentMaterials = new HyperbarikOxygenTreatmentMaterial.ChildHyperbarikOxygenTreatmentMaterialCollection(_TreatmentMaterials, "HyperbarikOxygenTreatmentMaterials");
        }

        private HyperbarikOxygenTreatmentMaterial.ChildHyperbarikOxygenTreatmentMaterialCollection _HyperbarikOxygenTreatmentMaterials = null;
        public HyperbarikOxygenTreatmentMaterial.ChildHyperbarikOxygenTreatmentMaterialCollection HyperbarikOxygenTreatmentMaterials
        {
            get
            {
                if (_TreatmentMaterials == null)
                    CreateTreatmentMaterialsCollection();
                return _HyperbarikOxygenTreatmentMaterials;
            }            
        }

        protected HyperbarikOxygenTreatmentOrderDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HyperbarikOxygenTreatmentOrderDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HyperbarikOxygenTreatmentOrderDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HyperbarikOxygenTreatmentOrderDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HyperbarikOxygenTreatmentOrderDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HYPERBARIKOXYGENTREATMENTORDERDETAIL", dataRow) { }
        protected HyperbarikOxygenTreatmentOrderDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HYPERBARIKOXYGENTREATMENTORDERDETAIL", dataRow, isImported) { }
        public HyperbarikOxygenTreatmentOrderDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HyperbarikOxygenTreatmentOrderDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HyperbarikOxygenTreatmentOrderDetail() : base() { }

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