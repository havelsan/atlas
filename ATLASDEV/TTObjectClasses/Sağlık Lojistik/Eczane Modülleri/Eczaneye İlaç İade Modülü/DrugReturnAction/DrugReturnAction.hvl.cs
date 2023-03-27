
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DrugReturnAction")] 

    /// <summary>
    /// Eczaneye İlaç İade
    /// </summary>
    public  partial class DrugReturnAction : EpisodeAction
    {
        public class DrugReturnActionList : TTObjectCollection<DrugReturnAction> { }
                    
        public class ChildDrugReturnActionCollection : TTObject.TTChildObjectCollection<DrugReturnAction>
        {
            public ChildDrugReturnActionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDrugReturnActionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetDrugReturnReportQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
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

            public Guid? Drugname
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DRUGNAME"]);
                }
            }

            public double? Resdose
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESDOSE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGRETURNACTIONDETAIL"].AllPropertyDefs["AMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string Clinic
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CLINIC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DrugReturnReason
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DRUGRETURNREASON"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGRETURNACTION"].AllPropertyDefs["DRUGRETURNREASON"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetDrugReturnReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDrugReturnReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDrugReturnReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDrugReturnList_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? Patientid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PATIENTID"]);
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

            public DateTime? Returndate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RETURNDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGRETURNACTION"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Servis
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SERVIS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DrugReturnReason
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DRUGRETURNREASON"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGRETURNACTION"].AllPropertyDefs["DRUGRETURNREASON"].DataType;
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

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public GetDrugReturnList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDrugReturnList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDrugReturnList_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDrugReturnActionByPatient_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGRETURNACTION"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGRETURNACTION"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public String DisplayText
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISPLAYTEXT"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public GetDrugReturnActionByPatient_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDrugReturnActionByPatient_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDrugReturnActionByPatient_Class() : base() { }
        }

        [Serializable] 

        public partial class GetWaitingPharmcyByEpisode_Class : TTReportNqlObject 
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

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGRETURNACTION"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string ReasonOfCancel
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONOFCANCEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGRETURNACTION"].AllPropertyDefs["REASONOFCANCEL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? Active
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIVE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGRETURNACTION"].AllPropertyDefs["ACTIVE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? WorkListDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKLISTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGRETURNACTION"].AllPropertyDefs["WORKLISTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public object ReasonOfReject
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONOFREJECT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGRETURNACTION"].AllPropertyDefs["REASONOFREJECT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGRETURNACTION"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OlapLastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAPLASTUPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGRETURNACTION"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OlapDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGRETURNACTION"].AllPropertyDefs["OLAPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? ClonedObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CLONEDOBJECTID"]);
                }
            }

            public string WorkListDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKLISTDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGRETURNACTION"].AllPropertyDefs["WORKLISTDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsOldAction
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISOLDACTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGRETURNACTION"].AllPropertyDefs["ISOLDACTION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGRETURNACTION"].AllPropertyDefs["REQUESTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGRETURNACTION"].AllPropertyDefs["EMERGENCY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGRETURNACTION"].AllPropertyDefs["PATIENTPAY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string OrderObject
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDEROBJECT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGRETURNACTION"].AllPropertyDefs["ORDEROBJECT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DescriptionForWorkList
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTIONFORWORKLIST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGRETURNACTION"].AllPropertyDefs["DESCRIPTIONFORWORKLIST"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IgnoreEpisodeStateOnUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["IGNOREEPISODESTATEONUPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGRETURNACTION"].AllPropertyDefs["IGNOREEPISODESTATEONUPDATE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public long? AdmissionQueueNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADMISSIONQUEUENUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGRETURNACTION"].AllPropertyDefs["ADMISSIONQUEUENUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string DrugReturnReason
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DRUGRETURNREASON"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGRETURNACTION"].AllPropertyDefs["DRUGRETURNREASON"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetWaitingPharmcyByEpisode_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetWaitingPharmcyByEpisode_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetWaitingPharmcyByEpisode_Class() : base() { }
        }

        [Serializable] 

        public partial class GetComplatedPharmcyByEpisode_Class : TTReportNqlObject 
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

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGRETURNACTION"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string ReasonOfCancel
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONOFCANCEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGRETURNACTION"].AllPropertyDefs["REASONOFCANCEL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? Active
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIVE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGRETURNACTION"].AllPropertyDefs["ACTIVE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? WorkListDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKLISTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGRETURNACTION"].AllPropertyDefs["WORKLISTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public object ReasonOfReject
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONOFREJECT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGRETURNACTION"].AllPropertyDefs["REASONOFREJECT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGRETURNACTION"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OlapLastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAPLASTUPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGRETURNACTION"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OlapDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGRETURNACTION"].AllPropertyDefs["OLAPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? ClonedObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CLONEDOBJECTID"]);
                }
            }

            public string WorkListDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKLISTDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGRETURNACTION"].AllPropertyDefs["WORKLISTDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsOldAction
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISOLDACTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGRETURNACTION"].AllPropertyDefs["ISOLDACTION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGRETURNACTION"].AllPropertyDefs["REQUESTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGRETURNACTION"].AllPropertyDefs["EMERGENCY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGRETURNACTION"].AllPropertyDefs["PATIENTPAY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string OrderObject
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDEROBJECT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGRETURNACTION"].AllPropertyDefs["ORDEROBJECT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DescriptionForWorkList
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTIONFORWORKLIST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGRETURNACTION"].AllPropertyDefs["DESCRIPTIONFORWORKLIST"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IgnoreEpisodeStateOnUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["IGNOREEPISODESTATEONUPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGRETURNACTION"].AllPropertyDefs["IGNOREEPISODESTATEONUPDATE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public long? AdmissionQueueNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADMISSIONQUEUENUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGRETURNACTION"].AllPropertyDefs["ADMISSIONQUEUENUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string DrugReturnReason
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DRUGRETURNREASON"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGRETURNACTION"].AllPropertyDefs["DRUGRETURNREASON"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetComplatedPharmcyByEpisode_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetComplatedPharmcyByEpisode_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetComplatedPharmcyByEpisode_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("37baa2cb-6259-44b2-b604-89d519038eb1"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("0e80ccda-50ca-4376-891f-7ed97a4c3700"); } }
    /// <summary>
    /// Eczane Onay
    /// </summary>
            public static Guid Approval { get { return new Guid("8495261b-4985-4799-886c-44663c359fbc"); } }
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("a3b9f936-e351-4bfd-831c-ef9e8975b0f2"); } }
        }

    /// <summary>
    /// .
    /// </summary>
        public static BindingList<DrugReturnAction.GetDrugReturnReportQuery_Class> GetDrugReturnReportQuery(Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGRETURNACTION"].QueryDefs["GetDrugReturnReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<DrugReturnAction.GetDrugReturnReportQuery_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// .
    /// </summary>
        public static BindingList<DrugReturnAction.GetDrugReturnReportQuery_Class> GetDrugReturnReportQuery(TTObjectContext objectContext, Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGRETURNACTION"].QueryDefs["GetDrugReturnReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<DrugReturnAction.GetDrugReturnReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DrugReturnAction.GetDrugReturnList_Class> GetDrugReturnList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGRETURNACTION"].QueryDefs["GetDrugReturnList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DrugReturnAction.GetDrugReturnList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DrugReturnAction.GetDrugReturnList_Class> GetDrugReturnList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGRETURNACTION"].QueryDefs["GetDrugReturnList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DrugReturnAction.GetDrugReturnList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DrugReturnAction.GetDrugReturnActionByPatient_Class> GetDrugReturnActionByPatient(Guid EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGRETURNACTION"].QueryDefs["GetDrugReturnActionByPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<DrugReturnAction.GetDrugReturnActionByPatient_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DrugReturnAction.GetDrugReturnActionByPatient_Class> GetDrugReturnActionByPatient(TTObjectContext objectContext, Guid EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGRETURNACTION"].QueryDefs["GetDrugReturnActionByPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<DrugReturnAction.GetDrugReturnActionByPatient_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DrugReturnAction.GetWaitingPharmcyByEpisode_Class> GetWaitingPharmcyByEpisode(Guid SUBEPISODE, Guid EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGRETURNACTION"].QueryDefs["GetWaitingPharmcyByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<DrugReturnAction.GetWaitingPharmcyByEpisode_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DrugReturnAction.GetWaitingPharmcyByEpisode_Class> GetWaitingPharmcyByEpisode(TTObjectContext objectContext, Guid SUBEPISODE, Guid EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGRETURNACTION"].QueryDefs["GetWaitingPharmcyByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<DrugReturnAction.GetWaitingPharmcyByEpisode_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DrugReturnAction.GetComplatedPharmcyByEpisode_Class> GetComplatedPharmcyByEpisode(Guid EPISODE, Guid SUBEPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGRETURNACTION"].QueryDefs["GetComplatedPharmcyByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);
            paramList.Add("SUBEPISODE", SUBEPISODE);

            return TTReportNqlObject.QueryObjects<DrugReturnAction.GetComplatedPharmcyByEpisode_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DrugReturnAction.GetComplatedPharmcyByEpisode_Class> GetComplatedPharmcyByEpisode(TTObjectContext objectContext, Guid EPISODE, Guid SUBEPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGRETURNACTION"].QueryDefs["GetComplatedPharmcyByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);
            paramList.Add("SUBEPISODE", SUBEPISODE);

            return TTReportNqlObject.QueryObjects<DrugReturnAction.GetComplatedPharmcyByEpisode_Class>(objectContext, queryDef, paramList, pi);
        }

        public string DrugReturnReason
        {
            get { return (string)this["DRUGRETURNREASON"]; }
            set { this["DRUGRETURNREASON"] = value; }
        }

        public Store PharmacyStoreDefinition
        {
            get { return (Store)((ITTObject)this).GetParent("PHARMACYSTOREDEFINITION"); }
            set { this["PHARMACYSTOREDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateDrugReturnActionDetailsCollection()
        {
            _DrugReturnActionDetails = new DrugReturnActionDetail.ChildDrugReturnActionDetailCollection(this, new Guid("9d38e8d5-0c71-4e2e-a903-d4a5e7525b5a"));
            ((ITTChildObjectCollection)_DrugReturnActionDetails).GetChildren();
        }

        protected DrugReturnActionDetail.ChildDrugReturnActionDetailCollection _DrugReturnActionDetails = null;
        public DrugReturnActionDetail.ChildDrugReturnActionDetailCollection DrugReturnActionDetails
        {
            get
            {
                if (_DrugReturnActionDetails == null)
                    CreateDrugReturnActionDetailsCollection();
                return _DrugReturnActionDetails;
            }
        }

        virtual protected void CreateStockInActionsCollection()
        {
            _StockInActions = new StockIn.ChildStockInCollection(this, new Guid("02a47397-ed03-43e3-9b4f-96c33fed77ff"));
            ((ITTChildObjectCollection)_StockInActions).GetChildren();
        }

        protected StockIn.ChildStockInCollection _StockInActions = null;
        public StockIn.ChildStockInCollection StockInActions
        {
            get
            {
                if (_StockInActions == null)
                    CreateStockInActionsCollection();
                return _StockInActions;
            }
        }

        protected DrugReturnAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DrugReturnAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DrugReturnAction(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DrugReturnAction(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DrugReturnAction(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DRUGRETURNACTION", dataRow) { }
        protected DrugReturnAction(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DRUGRETURNACTION", dataRow, isImported) { }
        public DrugReturnAction(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DrugReturnAction(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DrugReturnAction() : base() { }

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