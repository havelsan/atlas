
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PhysiotherapyRequest")] 

    /// <summary>
    /// F.T.R. İstek İşlemlerinin Gerçekleştirildiği  Nesnedir
    /// </summary>
    public  partial class PhysiotherapyRequest : EpisodeActionWithDiagnosis, IReasonOfReject, IAllocateSpeciality, IWorkListEpisodeAction, ICreateSubEpisode
    {
        public class PhysiotherapyRequestList : TTObjectCollection<PhysiotherapyRequest> { }
                    
        public class ChildPhysiotherapyRequestCollection : TTObject.TTChildObjectCollection<PhysiotherapyRequest>
        {
            public ChildPhysiotherapyRequestCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPhysiotherapyRequestCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetPhysiotheraphyHealthReport_Class : TTReportNqlObject 
        {
            public Guid? ProcedureDoctor
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDUREDOCTOR"]);
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

            public Guid? SecondProcedureDoctor
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SECONDPROCEDUREDOCTOR"]);
                }
            }

            public string Secondproceduredoctorname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SECONDPROCEDUREDOCTORNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ThirdProcedureDoctor
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["THIRDPROCEDUREDOCTOR"]);
                }
            }

            public string Thirdproceduredoctorname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["THIRDPROCEDUREDOCTORNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? ProtocolNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREQUEST"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREQUEST"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public Object Cityofbirth
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["CITYOFBIRTH"]);
                }
            }

            public Object Townofbirth
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOWNOFBIRTH"]);
                }
            }

            public Object Birthdate
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["BIRTHDATE"]);
                }
            }

            public Object Homeaddress
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["HOMEADDRESS"]);
                }
            }

            public Object Homecountry
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["HOMECOUNTRY"]);
                }
            }

            public Object Homecity
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["HOMECITY"]);
                }
            }

            public Object Hometown
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["HOMETOWN"]);
                }
            }

            public Object Homephone
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["HOMEPHONE"]);
                }
            }

            public Guid? Episode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODE"]);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string ClinicInformation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CLINICINFORMATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREQUEST"].AllPropertyDefs["CLINICINFORMATION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object ClinicInformationRTF
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CLINICINFORMATIONRTF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREQUEST"].AllPropertyDefs["CLINICINFORMATIONRTF"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public GetPhysiotheraphyHealthReport_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPhysiotheraphyHealthReport_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPhysiotheraphyHealthReport_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPhysiotherapyReport_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREQUEST"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREQUEST"].AllPropertyDefs["REASONOFCANCEL"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREQUEST"].AllPropertyDefs["ACTIVE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREQUEST"].AllPropertyDefs["WORKLISTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREQUEST"].AllPropertyDefs["REASONOFREJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREQUEST"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREQUEST"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREQUEST"].AllPropertyDefs["OLAPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREQUEST"].AllPropertyDefs["WORKLISTDESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREQUEST"].AllPropertyDefs["ISOLDACTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREQUEST"].AllPropertyDefs["REQUESTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREQUEST"].AllPropertyDefs["EMERGENCY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREQUEST"].AllPropertyDefs["PATIENTPAY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREQUEST"].AllPropertyDefs["ORDEROBJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREQUEST"].AllPropertyDefs["DESCRIPTIONFORWORKLIST"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREQUEST"].AllPropertyDefs["IGNOREEPISODESTATEONUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREQUEST"].AllPropertyDefs["ADMISSIONQUEUENUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string NoteToPhysiotherapist
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTETOPHYSIOTHERAPIST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREQUEST"].AllPropertyDefs["NOTETOPHYSIOTHERAPIST"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? ProtocolNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREQUEST"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string DiagnosisGroup
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIAGNOSISGROUP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREQUEST"].AllPropertyDefs["DIAGNOSISGROUP"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? InPatientsBed
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INPATIENTSBED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREQUEST"].AllPropertyDefs["INPATIENTSBED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public object ClinicInformationRTF
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CLINICINFORMATIONRTF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREQUEST"].AllPropertyDefs["CLINICINFORMATIONRTF"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public string MedulaRaporTakipNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULARAPORTAKIPNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREQUEST"].AllPropertyDefs["MEDULARAPORTAKIPNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? ReportEndDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTENDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREQUEST"].AllPropertyDefs["REPORTENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ReportStartDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTSTARTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREQUEST"].AllPropertyDefs["REPORTSTARTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string ReportNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREQUEST"].AllPropertyDefs["REPORTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ClinicInformation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CLINICINFORMATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREQUEST"].AllPropertyDefs["CLINICINFORMATION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? PhysiotherapyRequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PHYSIOTHERAPYREQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREQUEST"].AllPropertyDefs["PHYSIOTHERAPYREQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? PhysiotherapyStartDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PHYSIOTHERAPYSTARTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREQUEST"].AllPropertyDefs["PHYSIOTHERAPYSTARTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetPhysiotherapyReport_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPhysiotherapyReport_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPhysiotherapyReport_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPatientInfoByTreatmentRequest_Class : TTReportNqlObject 
        {
            public Guid? Patient
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PATIENT"]);
                }
            }

            public Guid? Episode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODE"]);
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

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREQUEST"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREQUEST"].AllPropertyDefs["REASONOFCANCEL"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREQUEST"].AllPropertyDefs["ACTIVE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREQUEST"].AllPropertyDefs["WORKLISTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREQUEST"].AllPropertyDefs["REASONOFREJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREQUEST"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREQUEST"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREQUEST"].AllPropertyDefs["OLAPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREQUEST"].AllPropertyDefs["WORKLISTDESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREQUEST"].AllPropertyDefs["ISOLDACTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREQUEST"].AllPropertyDefs["REQUESTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREQUEST"].AllPropertyDefs["EMERGENCY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREQUEST"].AllPropertyDefs["PATIENTPAY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREQUEST"].AllPropertyDefs["ORDEROBJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREQUEST"].AllPropertyDefs["DESCRIPTIONFORWORKLIST"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREQUEST"].AllPropertyDefs["IGNOREEPISODESTATEONUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREQUEST"].AllPropertyDefs["ADMISSIONQUEUENUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string NoteToPhysiotherapist
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTETOPHYSIOTHERAPIST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREQUEST"].AllPropertyDefs["NOTETOPHYSIOTHERAPIST"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? ProtocolNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREQUEST"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string DiagnosisGroup
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIAGNOSISGROUP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREQUEST"].AllPropertyDefs["DIAGNOSISGROUP"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? InPatientsBed
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INPATIENTSBED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREQUEST"].AllPropertyDefs["INPATIENTSBED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public object ClinicInformationRTF
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CLINICINFORMATIONRTF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREQUEST"].AllPropertyDefs["CLINICINFORMATIONRTF"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public string MedulaRaporTakipNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULARAPORTAKIPNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREQUEST"].AllPropertyDefs["MEDULARAPORTAKIPNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? ReportEndDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTENDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREQUEST"].AllPropertyDefs["REPORTENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ReportStartDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTSTARTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREQUEST"].AllPropertyDefs["REPORTSTARTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string ReportNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREQUEST"].AllPropertyDefs["REPORTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ClinicInformation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CLINICINFORMATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREQUEST"].AllPropertyDefs["CLINICINFORMATION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? PhysiotherapyRequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PHYSIOTHERAPYREQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREQUEST"].AllPropertyDefs["PHYSIOTHERAPYREQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? PhysiotherapyStartDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PHYSIOTHERAPYSTARTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREQUEST"].AllPropertyDefs["PHYSIOTHERAPYSTARTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetPatientInfoByTreatmentRequest_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPatientInfoByTreatmentRequest_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPatientInfoByTreatmentRequest_Class() : base() { }
        }

        [Serializable] 

        public partial class GetOldInfoForPhysiotherapyRequest_Class : TTReportNqlObject 
        {
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

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public DateTime? PhysiotherapyRequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PHYSIOTHERAPYREQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREQUEST"].AllPropertyDefs["PHYSIOTHERAPYREQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Fromresource
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FROMRESOURCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Doctor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCTOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetOldInfoForPhysiotherapyRequest_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOldInfoForPhysiotherapyRequest_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOldInfoForPhysiotherapyRequest_Class() : base() { }
        }

        [Serializable] 

        public partial class GetOldPopupInfoForPhysiotherapyRequest_Class : TTReportNqlObject 
        {
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

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public DateTime? PhysiotherapyRequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PHYSIOTHERAPYREQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREQUEST"].AllPropertyDefs["PHYSIOTHERAPYREQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Fromresource
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FROMRESOURCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Doctor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCTOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public GetOldPopupInfoForPhysiotherapyRequest_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOldPopupInfoForPhysiotherapyRequest_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOldPopupInfoForPhysiotherapyRequest_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPhysiotherapyRequestForWorkList_Class : TTReportNqlObject 
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

            public String Currentstate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CURRENTSTATE"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public string Admissionnumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADMISSIONNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetPhysiotherapyRequestForWorkList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPhysiotherapyRequestForWorkList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPhysiotherapyRequestForWorkList_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPhysiotherapyRequestForPhysiotherapyWorkList_Class : TTReportNqlObject 
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

            public String Currentstate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CURRENTSTATE"]);
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

            public string Admissionnumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADMISSIONNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public PatientStatusEnum? Ispatientdischarged
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISPATIENTDISCHARGED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["PATIENTSTATUS"].DataType;
                    return (PatientStatusEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Fromresource
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FROMRESOURCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
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

            public DateTime? PhysiotherapyRequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PHYSIOTHERAPYREQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREQUEST"].AllPropertyDefs["PHYSIOTHERAPYREQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetPhysiotherapyRequestForPhysiotherapyWorkList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPhysiotherapyRequestForPhysiotherapyWorkList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPhysiotherapyRequestForPhysiotherapyWorkList_Class() : base() { }
        }

        public static class States
        {
            public static Guid Planned { get { return new Guid("c20c10b5-1bbe-4ee1-af92-1f7a3fee5ff1"); } }
            public static Guid Cancelled { get { return new Guid("b9a324ce-eb67-4d0c-917b-6ca5dbd2966e"); } }
            public static Guid RequestAcceptionByDoctor { get { return new Guid("efe2cd24-4e82-49d1-9c8e-f63afb60c804"); } }
            public static Guid RequestAcception { get { return new Guid("ca426dd0-e1e8-48c1-bc3c-80e4244a366a"); } }
            public static Guid Completed { get { return new Guid("0afb8b5a-3c30-463a-b767-f7f2fadef76c"); } }
        }

        public static BindingList<PhysiotherapyRequest.GetPhysiotheraphyHealthReport_Class> GetPhysiotheraphyHealthReport(string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREQUEST"].QueryDefs["GetPhysiotheraphyHealthReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<PhysiotherapyRequest.GetPhysiotheraphyHealthReport_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PhysiotherapyRequest.GetPhysiotheraphyHealthReport_Class> GetPhysiotheraphyHealthReport(TTObjectContext objectContext, string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREQUEST"].QueryDefs["GetPhysiotheraphyHealthReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<PhysiotherapyRequest.GetPhysiotheraphyHealthReport_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PhysiotherapyRequest.GetPhysiotherapyReport_Class> GetPhysiotherapyReport(string REPORTNO, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREQUEST"].QueryDefs["GetPhysiotherapyReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("REPORTNO", REPORTNO);

            return TTReportNqlObject.QueryObjects<PhysiotherapyRequest.GetPhysiotherapyReport_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PhysiotherapyRequest.GetPhysiotherapyReport_Class> GetPhysiotherapyReport(TTObjectContext objectContext, string REPORTNO, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREQUEST"].QueryDefs["GetPhysiotherapyReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("REPORTNO", REPORTNO);

            return TTReportNqlObject.QueryObjects<PhysiotherapyRequest.GetPhysiotherapyReport_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PhysiotherapyRequest.GetPatientInfoByTreatmentRequest_Class> GetPatientInfoByTreatmentRequest(Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREQUEST"].QueryDefs["GetPatientInfoByTreatmentRequest"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<PhysiotherapyRequest.GetPatientInfoByTreatmentRequest_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PhysiotherapyRequest.GetPatientInfoByTreatmentRequest_Class> GetPatientInfoByTreatmentRequest(TTObjectContext objectContext, Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREQUEST"].QueryDefs["GetPatientInfoByTreatmentRequest"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<PhysiotherapyRequest.GetPatientInfoByTreatmentRequest_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Hasta geçmişi fizyoterapi istek
    /// </summary>
        public static BindingList<PhysiotherapyRequest.GetOldInfoForPhysiotherapyRequest_Class> GetOldInfoForPhysiotherapyRequest(Guid PATIENT, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREQUEST"].QueryDefs["GetOldInfoForPhysiotherapyRequest"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<PhysiotherapyRequest.GetOldInfoForPhysiotherapyRequest_Class>(queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Hasta geçmişi fizyoterapi istek
    /// </summary>
        public static BindingList<PhysiotherapyRequest.GetOldInfoForPhysiotherapyRequest_Class> GetOldInfoForPhysiotherapyRequest(TTObjectContext objectContext, Guid PATIENT, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREQUEST"].QueryDefs["GetOldInfoForPhysiotherapyRequest"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<PhysiotherapyRequest.GetOldInfoForPhysiotherapyRequest_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// popup hasta geçmişi için sorgu
    /// </summary>
        public static BindingList<PhysiotherapyRequest.GetOldPopupInfoForPhysiotherapyRequest_Class> GetOldPopupInfoForPhysiotherapyRequest(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREQUEST"].QueryDefs["GetOldPopupInfoForPhysiotherapyRequest"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PhysiotherapyRequest.GetOldPopupInfoForPhysiotherapyRequest_Class>(queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// popup hasta geçmişi için sorgu
    /// </summary>
        public static BindingList<PhysiotherapyRequest.GetOldPopupInfoForPhysiotherapyRequest_Class> GetOldPopupInfoForPhysiotherapyRequest(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREQUEST"].QueryDefs["GetOldPopupInfoForPhysiotherapyRequest"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PhysiotherapyRequest.GetOldPopupInfoForPhysiotherapyRequest_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PhysiotherapyRequest.GetPhysiotherapyRequestForWorkList_Class> GetPhysiotherapyRequestForWorkList(DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREQUEST"].QueryDefs["GetPhysiotherapyRequestForWorkList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<PhysiotherapyRequest.GetPhysiotherapyRequestForWorkList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PhysiotherapyRequest.GetPhysiotherapyRequestForWorkList_Class> GetPhysiotherapyRequestForWorkList(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREQUEST"].QueryDefs["GetPhysiotherapyRequestForWorkList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<PhysiotherapyRequest.GetPhysiotherapyRequestForWorkList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PhysiotherapyRequest.GetPhysiotherapyRequestForPhysiotherapyWorkList_Class> GetPhysiotherapyRequestForPhysiotherapyWorkList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREQUEST"].QueryDefs["GetPhysiotherapyRequestForPhysiotherapyWorkList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PhysiotherapyRequest.GetPhysiotherapyRequestForPhysiotherapyWorkList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PhysiotherapyRequest.GetPhysiotherapyRequestForPhysiotherapyWorkList_Class> GetPhysiotherapyRequestForPhysiotherapyWorkList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREQUEST"].QueryDefs["GetPhysiotherapyRequestForPhysiotherapyWorkList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PhysiotherapyRequest.GetPhysiotherapyRequestForPhysiotherapyWorkList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PhysiotherapyRequest> GetPhysiotherapyRequestList(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREQUEST"].QueryDefs["GetPhysiotherapyRequestList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<PhysiotherapyRequest>(queryDef, paramList);
        }

        public static BindingList<PhysiotherapyRequest> GetPhysiotherapyRequestListByDate(TTObjectContext objectContext, DateTime StartDate, DateTime EndDate)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREQUEST"].QueryDefs["GetPhysiotherapyRequestListByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", StartDate);
            paramList.Add("ENDDATE", EndDate);

            return ((ITTQuery)objectContext).QueryObjects<PhysiotherapyRequest>(queryDef, paramList);
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string NoteToPhysiotherapist
        {
            get { return (string)this["NOTETOPHYSIOTHERAPIST"]; }
            set { this["NOTETOPHYSIOTHERAPIST"] = value; }
        }

    /// <summary>
    /// Protokol No
    /// </summary>
        public TTSequence ProtocolNo
        {
            get { return GetSequence("PROTOCOLNO"); }
        }

    /// <summary>
    /// Tanı Grubu
    /// </summary>
        public string DiagnosisGroup
        {
            get { return (string)this["DIAGNOSISGROUP"]; }
            set { this["DIAGNOSISGROUP"] = value; }
        }

    /// <summary>
    /// Yatağında
    /// </summary>
        public bool? InPatientsBed
        {
            get { return (bool?)this["INPATIENTSBED"]; }
            set { this["INPATIENTSBED"] = value; }
        }

    /// <summary>
    /// Klinik Bulgular
    /// </summary>
        public object ClinicInformationRTF
        {
            get { return (object)this["CLINICINFORMATIONRTF"]; }
            set { this["CLINICINFORMATIONRTF"] = value; }
        }

    /// <summary>
    /// Medula Rapor Takip Numarası
    /// </summary>
        public string MedulaRaporTakipNo
        {
            get { return (string)this["MEDULARAPORTAKIPNO"]; }
            set { this["MEDULARAPORTAKIPNO"] = value; }
        }

    /// <summary>
    /// Medula Rapor Bitiş Tarihi
    /// </summary>
        public DateTime? ReportEndDate
        {
            get { return (DateTime?)this["REPORTENDDATE"]; }
            set { this["REPORTENDDATE"] = value; }
        }

    /// <summary>
    /// Medula Rapor Başlangıç Tarihi
    /// </summary>
        public DateTime? ReportStartDate
        {
            get { return (DateTime?)this["REPORTSTARTDATE"]; }
            set { this["REPORTSTARTDATE"] = value; }
        }

    /// <summary>
    /// Rapor Numarası
    /// </summary>
        public string ReportNo
        {
            get { return (string)this["REPORTNO"]; }
            set { this["REPORTNO"] = value; }
        }

    /// <summary>
    /// Klinik Bilgileri
    /// </summary>
        public string ClinicInformation
        {
            get { return (string)this["CLINICINFORMATION"]; }
            set { this["CLINICINFORMATION"] = value; }
        }

    /// <summary>
    /// F.T.R. İstek Tarihi
    /// </summary>
        public DateTime? PhysiotherapyRequestDate
        {
            get { return (DateTime?)this["PHYSIOTHERAPYREQUESTDATE"]; }
            set { this["PHYSIOTHERAPYREQUESTDATE"] = value; }
        }

    /// <summary>
    /// Randevu Başlangıç Tarihi
    /// </summary>
        public DateTime? PhysiotherapyStartDate
        {
            get { return (DateTime?)this["PHYSIOTHERAPYSTARTDATE"]; }
            set { this["PHYSIOTHERAPYSTARTDATE"] = value; }
        }

    /// <summary>
    /// Fizyoterapi Sağlık Raporu için 2. Tabip
    /// </summary>
        public ResUser SecondProcedureDoctor
        {
            get { return (ResUser)((ITTObject)this).GetParent("SECONDPROCEDUREDOCTOR"); }
            set { this["SECONDPROCEDUREDOCTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Fizyoterapi Sağlık Raporu için 3. Tabip
    /// </summary>
        public ResUser ThirdProcedureDoctor
        {
            get { return (ResUser)((ITTObject)this).GetParent("THIRDPROCEDUREDOCTOR"); }
            set { this["THIRDPROCEDUREDOCTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Yatan hastalarda yatağında check i işaretli olduğunda hastanın yattığı yatak set edilir.
    /// </summary>
        public ResBed InpatientBed
        {
            get { return (ResBed)((ITTObject)this).GetParent("INPATIENTBED"); }
            set { this["INPATIENTBED"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResUser RequesterDoctor
        {
            get { return (ResUser)((ITTObject)this).GetParent("REQUESTERDOCTOR"); }
            set { this["REQUESTERDOCTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreatePhysiotherapyOrdersCollection()
        {
            _PhysiotherapyOrders = new PhysiotherapyOrder.ChildPhysiotherapyOrderCollection(this, new Guid("2d46a090-0f74-4fc3-9290-7d5003f09bb7"));
            ((ITTChildObjectCollection)_PhysiotherapyOrders).GetChildren();
        }

        protected PhysiotherapyOrder.ChildPhysiotherapyOrderCollection _PhysiotherapyOrders = null;
    /// <summary>
    /// Child collection for Fizyoterapi Emirleri
    /// </summary>
        public PhysiotherapyOrder.ChildPhysiotherapyOrderCollection PhysiotherapyOrders
        {
            get
            {
                if (_PhysiotherapyOrders == null)
                    CreatePhysiotherapyOrdersCollection();
                return _PhysiotherapyOrders;
            }
        }

        virtual protected void CreatePhysiotherapySessionsCollection()
        {
            _PhysiotherapySessions = new PhysiotherapySessionInfo.ChildPhysiotherapySessionInfoCollection(this, new Guid("f0bead15-dbc0-41c5-be03-5bae6281ebf5"));
            ((ITTChildObjectCollection)_PhysiotherapySessions).GetChildren();
        }

        protected PhysiotherapySessionInfo.ChildPhysiotherapySessionInfoCollection _PhysiotherapySessions = null;
    /// <summary>
    /// Child collection for Fizyoterapi Emirleri
    /// </summary>
        public PhysiotherapySessionInfo.ChildPhysiotherapySessionInfoCollection PhysiotherapySessions
        {
            get
            {
                if (_PhysiotherapySessions == null)
                    CreatePhysiotherapySessionsCollection();
                return _PhysiotherapySessions;
            }
        }

        override protected void CreateSubactionProceduresCollectionViews()
        {
            base.CreateSubactionProceduresCollectionViews();
            _FTRPackageProcedures = new FTRPackageProcedure.ChildFTRPackageProcedureCollection(_SubactionProcedures, "FTRPackageProcedures");
            _PhysiotherapyOrderDetails = new PhysiotherapyOrderDetail.ChildPhysiotherapyOrderDetailCollection(_SubactionProcedures, "PhysiotherapyOrderDetails");
        }

        private FTRPackageProcedure.ChildFTRPackageProcedureCollection _FTRPackageProcedures = null;
        public FTRPackageProcedure.ChildFTRPackageProcedureCollection FTRPackageProcedures
        {
            get
            {
                if (_SubactionProcedures == null)
                    CreateSubactionProceduresCollection();
                return _FTRPackageProcedures;
            }            
        }

        private PhysiotherapyOrderDetail.ChildPhysiotherapyOrderDetailCollection _PhysiotherapyOrderDetails = null;
        public PhysiotherapyOrderDetail.ChildPhysiotherapyOrderDetailCollection PhysiotherapyOrderDetails
        {
            get
            {
                if (_SubactionProcedures == null)
                    CreateSubactionProceduresCollection();
                return _PhysiotherapyOrderDetails;
            }            
        }

        override protected void CreateTreatmentMaterialsCollectionViews()
        {
            base.CreateTreatmentMaterialsCollectionViews();
            _PhysiotherapyRequestTreatmentMaterials = new PhysiotherapyTreatmentMaterial.ChildPhysiotherapyTreatmentMaterialCollection(_TreatmentMaterials, "PhysiotherapyRequestTreatmentMaterials");
        }

        private PhysiotherapyTreatmentMaterial.ChildPhysiotherapyTreatmentMaterialCollection _PhysiotherapyRequestTreatmentMaterials = null;
        public PhysiotherapyTreatmentMaterial.ChildPhysiotherapyTreatmentMaterialCollection PhysiotherapyRequestTreatmentMaterials
        {
            get
            {
                if (_TreatmentMaterials == null)
                    CreateTreatmentMaterialsCollection();
                return _PhysiotherapyRequestTreatmentMaterials;
            }            
        }

        protected PhysiotherapyRequest(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PhysiotherapyRequest(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PhysiotherapyRequest(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PhysiotherapyRequest(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PhysiotherapyRequest(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PHYSIOTHERAPYREQUEST", dataRow) { }
        protected PhysiotherapyRequest(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PHYSIOTHERAPYREQUEST", dataRow, isImported) { }
        public PhysiotherapyRequest(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PhysiotherapyRequest(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PhysiotherapyRequest() : base() { }

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