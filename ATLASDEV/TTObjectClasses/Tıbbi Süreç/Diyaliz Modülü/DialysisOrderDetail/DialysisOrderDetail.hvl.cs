
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DialysisOrderDetail")] 

    /// <summary>
    /// Diyaliz Emrinin  Uygulanmasını Sağlayan Nesnedir
    /// </summary>
    public  partial class DialysisOrderDetail : BaseDialysisOrderDetail, IBaseAppointmentDef, IPatientWorkList, IReasonOfReject, ITreatmentMaterialCollection
    {
        public class DialysisOrderDetailList : TTObjectCollection<DialysisOrderDetail> { }
                    
        public class ChildDialysisOrderDetailCollection : TTObject.TTChildObjectCollection<DialysisOrderDetail>
        {
            public ChildDialysisOrderDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDialysisOrderDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetDialysisOrderDetailsForPatient_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIALYSISORDERDETAIL"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIALYSISORDERDETAIL"].AllPropertyDefs["WORKLISTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIALYSISORDERDETAIL"].AllPropertyDefs["PRICINGDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIALYSISORDERDETAIL"].AllPropertyDefs["EMERGENCY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIALYSISORDER"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? Dialysisrequestobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DIALYSISREQUESTOBJECTID"]);
                }
            }

            public long? Orderobjectduration
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDEROBJECTDURATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIALYSISORDER"].AllPropertyDefs["DURATION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIALYSISORDER"].AllPropertyDefs["AMOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIALYSISDEFINITION"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIALYSISDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string OrderNote
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERNOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIALYSISORDER"].AllPropertyDefs["ORDERNOTE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetDialysisOrderDetailsForPatient_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDialysisOrderDetailsForPatient_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDialysisOrderDetailsForPatient_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDialysisOrderDetails_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIALYSISORDERDETAIL"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIALYSISORDERDETAIL"].AllPropertyDefs["WORKLISTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIALYSISORDERDETAIL"].AllPropertyDefs["PRICINGDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIALYSISORDERDETAIL"].AllPropertyDefs["EMERGENCY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIALYSISORDER"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? Dialysisrequestobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DIALYSISREQUESTOBJECTID"]);
                }
            }

            public long? Orderobjectduration
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDEROBJECTDURATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIALYSISORDER"].AllPropertyDefs["DURATION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIALYSISORDER"].AllPropertyDefs["AMOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIALYSISDEFINITION"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIALYSISDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Orderobjectordernote
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDEROBJECTORDERNOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIALYSISORDER"].AllPropertyDefs["ORDERNOTE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetDialysisOrderDetails_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDialysisOrderDetails_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDialysisOrderDetails_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDialysisOrderDetailsByOrderObject_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIALYSISORDERDETAIL"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIALYSISORDERDETAIL"].AllPropertyDefs["WORKLISTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIALYSISORDERDETAIL"].AllPropertyDefs["PRICINGDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIALYSISORDERDETAIL"].AllPropertyDefs["EMERGENCY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIALYSISORDERDETAIL"].AllPropertyDefs["NOTE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIALYSISORDER"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? Dialysisrequestobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DIALYSISREQUESTOBJECTID"]);
                }
            }

            public long? Orderobjectduration
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDEROBJECTDURATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIALYSISORDER"].AllPropertyDefs["DURATION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIALYSISORDER"].AllPropertyDefs["AMOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIALYSISDEFINITION"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIALYSISDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Orderobjectordernote
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDEROBJECTORDERNOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIALYSISORDER"].AllPropertyDefs["ORDERNOTE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetDialysisOrderDetailsByOrderObject_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDialysisOrderDetailsByOrderObject_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDialysisOrderDetailsByOrderObject_Class() : base() { }
        }

        new public static class States
        {
    /// <summary>
    /// Doktor İptal Onayı
    /// </summary>
            public static Guid ApprovalForCancel { get { return new Guid("69e80418-da8e-4869-b9dd-1663685bd1d5"); } }
            public static Guid Completed { get { return new Guid("344ca372-c87a-448f-8cce-59f4c5cb7bc8"); } }
            public static Guid Execution { get { return new Guid("28e876c7-5f1b-46be-893f-2538e379316d"); } }
            public static Guid Cancelled { get { return new Guid("2fe6c3ba-a668-4e1e-875a-d765dc007521"); } }
        }

        public static BindingList<DialysisOrderDetail.GetDialysisOrderDetailsForPatient_Class> GetDialysisOrderDetailsForPatient(string ORDEROBJECT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIALYSISORDERDETAIL"].QueryDefs["GetDialysisOrderDetailsForPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ORDEROBJECT", ORDEROBJECT);

            return TTReportNqlObject.QueryObjects<DialysisOrderDetail.GetDialysisOrderDetailsForPatient_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DialysisOrderDetail.GetDialysisOrderDetailsForPatient_Class> GetDialysisOrderDetailsForPatient(TTObjectContext objectContext, string ORDEROBJECT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIALYSISORDERDETAIL"].QueryDefs["GetDialysisOrderDetailsForPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ORDEROBJECT", ORDEROBJECT);

            return TTReportNqlObject.QueryObjects<DialysisOrderDetail.GetDialysisOrderDetailsForPatient_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DialysisOrderDetail.GetDialysisOrderDetails_Class> GetDialysisOrderDetails(string ORDEROBJECT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIALYSISORDERDETAIL"].QueryDefs["GetDialysisOrderDetails"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ORDEROBJECT", ORDEROBJECT);

            return TTReportNqlObject.QueryObjects<DialysisOrderDetail.GetDialysisOrderDetails_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DialysisOrderDetail.GetDialysisOrderDetails_Class> GetDialysisOrderDetails(TTObjectContext objectContext, string ORDEROBJECT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIALYSISORDERDETAIL"].QueryDefs["GetDialysisOrderDetails"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ORDEROBJECT", ORDEROBJECT);

            return TTReportNqlObject.QueryObjects<DialysisOrderDetail.GetDialysisOrderDetails_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DialysisOrderDetail.GetDialysisOrderDetailsByOrderObject_Class> GetDialysisOrderDetailsByOrderObject(string ORDEROBJECT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIALYSISORDERDETAIL"].QueryDefs["GetDialysisOrderDetailsByOrderObject"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ORDEROBJECT", ORDEROBJECT);

            return TTReportNqlObject.QueryObjects<DialysisOrderDetail.GetDialysisOrderDetailsByOrderObject_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DialysisOrderDetail.GetDialysisOrderDetailsByOrderObject_Class> GetDialysisOrderDetailsByOrderObject(TTObjectContext objectContext, string ORDEROBJECT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIALYSISORDERDETAIL"].QueryDefs["GetDialysisOrderDetailsByOrderObject"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ORDEROBJECT", ORDEROBJECT);

            return TTReportNqlObject.QueryObjects<DialysisOrderDetail.GetDialysisOrderDetailsByOrderObject_Class>(objectContext, queryDef, paramList, pi);
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
    /// Hemşire Notu
    /// </summary>
        public string Note
        {
            get { return (string)this["NOTE"]; }
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

        public ProvisionRequest ProvisionRequest
        {
            get { return (ProvisionRequest)((ITTObject)this).GetParent("PROVISIONREQUEST"); }
            set { this["PROVISIONREQUEST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResUser ResUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESUSER"); }
            set { this["RESUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateCokluOzelDurumCollection()
        {
            _CokluOzelDurum = new CokluOzelDurum.ChildCokluOzelDurumCollection(this, new Guid("b1a98ca7-c15d-4f96-90f1-0934624ff45d"));
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
            _DialysisTreatmentMaterials = new DialysisTreatmentMaterial.ChildDialysisTreatmentMaterialCollection(_TreatmentMaterials, "DialysisTreatmentMaterials");
        }

        private DialysisTreatmentMaterial.ChildDialysisTreatmentMaterialCollection _DialysisTreatmentMaterials = null;
        public DialysisTreatmentMaterial.ChildDialysisTreatmentMaterialCollection DialysisTreatmentMaterials
        {
            get
            {
                if (_TreatmentMaterials == null)
                    CreateTreatmentMaterialsCollection();
                return _DialysisTreatmentMaterials;
            }            
        }

        protected DialysisOrderDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DialysisOrderDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DialysisOrderDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DialysisOrderDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DialysisOrderDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DIALYSISORDERDETAIL", dataRow) { }
        protected DialysisOrderDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DIALYSISORDERDETAIL", dataRow, isImported) { }
        public DialysisOrderDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DialysisOrderDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DialysisOrderDetail() : base() { }

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