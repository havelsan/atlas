
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DispatchToOtherHospital")] 

    /// <summary>
    /// XXXXXXler Arası Sevk 
    /// </summary>
    public  partial class DispatchToOtherHospital : EpisodeActionWithDiagnosis, IWorkListEpisodeAction, IAllocateSpeciality
    {
        public class DispatchToOtherHospitalList : TTObjectCollection<DispatchToOtherHospital> { }
                    
        public class ChildDispatchToOtherHospitalCollection : TTObject.TTChildObjectCollection<DispatchToOtherHospital>
        {
            public ChildDispatchToOtherHospitalCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDispatchToOtherHospitalCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetDispatchInformationOfPatientNQL_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISPATCHTOOTHERHOSPITAL"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISPATCHTOOTHERHOSPITAL"].AllPropertyDefs["REASONOFCANCEL"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISPATCHTOOTHERHOSPITAL"].AllPropertyDefs["ACTIVE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISPATCHTOOTHERHOSPITAL"].AllPropertyDefs["WORKLISTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISPATCHTOOTHERHOSPITAL"].AllPropertyDefs["REASONOFREJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISPATCHTOOTHERHOSPITAL"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISPATCHTOOTHERHOSPITAL"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISPATCHTOOTHERHOSPITAL"].AllPropertyDefs["OLAPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISPATCHTOOTHERHOSPITAL"].AllPropertyDefs["WORKLISTDESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISPATCHTOOTHERHOSPITAL"].AllPropertyDefs["ISOLDACTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISPATCHTOOTHERHOSPITAL"].AllPropertyDefs["REQUESTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISPATCHTOOTHERHOSPITAL"].AllPropertyDefs["EMERGENCY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISPATCHTOOTHERHOSPITAL"].AllPropertyDefs["PATIENTPAY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISPATCHTOOTHERHOSPITAL"].AllPropertyDefs["ORDEROBJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISPATCHTOOTHERHOSPITAL"].AllPropertyDefs["DESCRIPTIONFORWORKLIST"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISPATCHTOOTHERHOSPITAL"].AllPropertyDefs["IGNOREEPISODESTATEONUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISPATCHTOOTHERHOSPITAL"].AllPropertyDefs["ADMISSIONQUEUENUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public int? MedulaSiteCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULASITECODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISPATCHTOOTHERHOSPITAL"].AllPropertyDefs["MEDULASITECODE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string DispatcherDoctorName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISPATCHERDOCTORNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISPATCHTOOTHERHOSPITAL"].AllPropertyDefs["DISPATCHERDOCTORNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DispatcherDoctorEmploymentID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISPATCHERDOCTOREMPLOYMENTID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISPATCHTOOTHERHOSPITAL"].AllPropertyDefs["DISPATCHERDOCTOREMPLOYMENTID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DispatchedDoctorName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISPATCHEDDOCTORNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISPATCHTOOTHERHOSPITAL"].AllPropertyDefs["DISPATCHEDDOCTORNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DispatchedDoctorEmploymentID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISPATCHEDDOCTOREMPLOYMENTID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISPATCHTOOTHERHOSPITAL"].AllPropertyDefs["DISPATCHEDDOCTOREMPLOYMENTID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DispatcherDoctorDiplomaRegNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISPATCHERDOCTORDIPLOMAREGNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISPATCHTOOTHERHOSPITAL"].AllPropertyDefs["DISPATCHERDOCTORDIPLOMAREGNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DispatchedDoctorDiplomaRegNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISPATCHEDDOCTORDIPLOMAREGNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISPATCHTOOTHERHOSPITAL"].AllPropertyDefs["DISPATCHEDDOCTORDIPLOMAREGNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ReasonOfDispatch
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONOFDISPATCH"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISPATCHTOOTHERHOSPITAL"].AllPropertyDefs["REASONOFDISPATCH"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string CompanionReason
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COMPANIONREASON"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISPATCHTOOTHERHOSPITAL"].AllPropertyDefs["COMPANIONREASON"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DispatchVehicle
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISPATCHVEHICLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISPATCHTOOTHERHOSPITAL"].AllPropertyDefs["DISPATCHVEHICLE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string SourceObjectID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SOURCEOBJECTID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISPATCHTOOTHERHOSPITAL"].AllPropertyDefs["SOURCEOBJECTID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string TargetObjectID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TARGETOBJECTID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISPATCHTOOTHERHOSPITAL"].AllPropertyDefs["TARGETOBJECTID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? MedulaRefakatciDurumu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULAREFAKATCIDURUMU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISPATCHTOOTHERHOSPITAL"].AllPropertyDefs["MEDULAREFAKATCIDURUMU"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public long? MutatDisiAracRaporId
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MUTATDISIARACRAPORID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISPATCHTOOTHERHOSPITAL"].AllPropertyDefs["MUTATDISIARACRAPORID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? MutatDisiAracRaporTarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MUTATDISIARACRAPORTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISPATCHTOOTHERHOSPITAL"].AllPropertyDefs["MUTATDISIARACRAPORTARIHI"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? MutatDisiAracBitisTarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MUTATDISIARACBITISTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISPATCHTOOTHERHOSPITAL"].AllPropertyDefs["MUTATDISIARACBITISTARIHI"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? MutatDisiAracBaslangicTarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MUTATDISIARACBASLANGICTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISPATCHTOOTHERHOSPITAL"].AllPropertyDefs["MUTATDISIARACBASLANGICTARIHI"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string MutatDisiGerekcesi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MUTATDISIGEREKCESI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISPATCHTOOTHERHOSPITAL"].AllPropertyDefs["MUTATDISIGEREKCESI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MedulaSevkTakipNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULASEVKTAKIPNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISPATCHTOOTHERHOSPITAL"].AllPropertyDefs["MEDULASEVKTAKIPNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MessageID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MESSAGEID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISPATCHTOOTHERHOSPITAL"].AllPropertyDefs["MESSAGEID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISPATCHTOOTHERHOSPITAL"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? TargetEpisodeObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["TARGETEPISODEOBJECTID"]);
                }
            }

            public string GSSOwnerName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GSSOWNERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISPATCHTOOTHERHOSPITAL"].AllPropertyDefs["GSSOWNERNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? RestingStartDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESTINGSTARTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISPATCHTOOTHERHOSPITAL"].AllPropertyDefs["RESTINGSTARTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string CompanionStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COMPANIONSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISPATCHTOOTHERHOSPITAL"].AllPropertyDefs["COMPANIONSTATUS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? RestingEndDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESTINGENDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISPATCHTOOTHERHOSPITAL"].AllPropertyDefs["RESTINGENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? MutatDisiAracXXXXXXRaporID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MUTATDISIARACXXXXXXRAPORID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISPATCHTOOTHERHOSPITAL"].AllPropertyDefs["MUTATDISIARACXXXXXXRAPORID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? GSSOwnerUniquerefNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GSSOWNERUNIQUEREFNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISPATCHTOOTHERHOSPITAL"].AllPropertyDefs["GSSOWNERUNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public bool? EpicrisisDelivered
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EPICRISISDELIVERED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISPATCHTOOTHERHOSPITAL"].AllPropertyDefs["EPICRISISDELIVERED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? NeedSpecialEquipment
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NEEDSPECIALEQUIPMENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISPATCHTOOTHERHOSPITAL"].AllPropertyDefs["NEEDSPECIALEQUIPMENT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public IlSınırBilgisi? IlSinir
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ILSINIR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISPATCHTOOTHERHOSPITAL"].AllPropertyDefs["ILSINIR"].DataType;
                    return (IlSınırBilgisi?)(int)dataType.ConvertValue(val);
                }
            }

            public string Dispatchedspecialityname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISPATCHEDSPECIALITYNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Objectid1
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID1"]);
                }
            }

            public DateTime? Restingenddate1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESTINGENDDATE1"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISPATCHTOOTHERHOSPITAL"].AllPropertyDefs["RESTINGENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Restingstartdate1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESTINGSTARTDATE1"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISPATCHTOOTHERHOSPITAL"].AllPropertyDefs["RESTINGSTARTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Companionreason1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COMPANIONREASON1"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISPATCHTOOTHERHOSPITAL"].AllPropertyDefs["COMPANIONREASON"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Companionstatus1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COMPANIONSTATUS1"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISPATCHTOOTHERHOSPITAL"].AllPropertyDefs["COMPANIONSTATUS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Dispatchvehicle1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISPATCHVEHICLE1"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISPATCHTOOTHERHOSPITAL"].AllPropertyDefs["DISPATCHVEHICLE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Gssownername1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GSSOWNERNAME1"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISPATCHTOOTHERHOSPITAL"].AllPropertyDefs["GSSOWNERNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Gssowneruniquerefno1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GSSOWNERUNIQUEREFNO1"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISPATCHTOOTHERHOSPITAL"].AllPropertyDefs["GSSOWNERUNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Reasonofdispatch1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONOFDISPATCH1"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISPATCHTOOTHERHOSPITAL"].AllPropertyDefs["REASONOFDISPATCH"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Requesterhospitalname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTERHOSPITALNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESOTHERHOSPITAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Mresource
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MRESOURCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? Rdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISPATCHTOOTHERHOSPITAL"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? RequesterHospital
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["REQUESTERHOSPITAL"]);
                }
            }

            public string Dispatchcityname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISPATCHCITYNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSILKODLARI"].AllPropertyDefs["ADI"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public Object Cityofbirthname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["CITYOFBIRTHNAME"]);
                }
            }

            public Object Countryofbirthname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["COUNTRYOFBIRTHNAME"]);
                }
            }

            public long? Dosyano
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOSYANO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? Refno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REFNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["UNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
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

            public DateTime? Admissiondate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADMISSIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["HOSPITALINPATIENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Dischargedate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISCHARGEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["HOSPITALDISCHARGEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetDispatchInformationOfPatientNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDispatchInformationOfPatientNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDispatchInformationOfPatientNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDispatchedPatientsNQL_Class : TTReportNqlObject 
        {
            public long? Tckimlikno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TCKIMLIKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["UNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
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

            public string Dispatchedresource
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISPATCHEDRESOURCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EXTERNALHOSPITALDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DispatchedXXXXXXresource
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISPATCHEDXXXXXXRESOURCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SITES"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Dispatcherhospital
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISPATCHERHOSPITAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ReasonOfDispatch
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONOFDISPATCH"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISPATCHTOOTHERHOSPITAL"].AllPropertyDefs["REASONOFDISPATCH"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetDispatchedPatientsNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDispatchedPatientsNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDispatchedPatientsNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class DispatchCountQuery_Class : TTReportNqlObject 
        {
            public Object Patientgroup
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTGROUP"]);
                }
            }

            public bool? IsQuotaUsed
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISQUOTAUSED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["ISQUOTAUSED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public Object Sayi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["SAYI"]);
                }
            }

            public DispatchCountQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public DispatchCountQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected DispatchCountQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_XXXXXXlerArasiSevk_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public DateTime? OlapDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISPATCHTOOTHERHOSPITAL"].AllPropertyDefs["OLAPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public Object Patientgroup
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTGROUP"]);
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

            public Object Kabultur
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["KABULTUR"]);
                }
            }

            public Guid? Sevkeeden_birim
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SEVKEEDEN_BIRIM"]);
                }
            }

            public Guid? Sevkedilen_brans
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SEVKEDILEN_BRANS"]);
                }
            }

            public Guid? Sevkedilen_XXXXXX
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SEVKEDILEN_XXXXXX"]);
                }
            }

            public Object Sevk_turu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["SEVK_TURU"]);
                }
            }

            public OLAP_XXXXXXlerArasiSevk_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_XXXXXXlerArasiSevk_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_XXXXXXlerArasiSevk_Class() : base() { }
        }

        [Serializable] 

        public partial class VEM_HASTA_SEVK_Class : TTReportNqlObject 
        {
            public Guid? Hasta_sevk_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["HASTA_SEVK_KODU"]);
                }
            }

            public Object Referans_tablo_adi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["REFERANS_TABLO_ADI"]);
                }
            }

            public Guid? Hasta_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["HASTA_KODU"]);
                }
            }

            public Guid? Hasta_basvuru_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["HASTA_BASVURU_KODU"]);
                }
            }

            public string Sevk_takip_numarasi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SEVK_TAKIP_NUMARASI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISPATCHTOOTHERHOSPITAL"].AllPropertyDefs["MEDULASEVKTAKIPNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Sevk_sebebi_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SEVK_SEBEBI_KODU"]);
                }
            }

            public int? Sevk_edilen_brans_kodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SEVK_EDILEN_BRANS_KODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISPATCHTOOTHERHOSPITAL"].AllPropertyDefs["MEDULASITECODE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public Guid? Sevk_edilen_kurum_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SEVK_EDILEN_KURUM_KODU"]);
                }
            }

            public DateTime? Sevk_zamani
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SEVK_ZAMANI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISPATCHTOOTHERHOSPITAL"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Object Sevk_sekli
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["SEVK_SEKLI"]);
                }
            }

            public Guid? Sevk_vasitasi_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SEVK_VASITASI_KODU"]);
                }
            }

            public Guid? Sevk_tedavi_tipi
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SEVK_TEDAVI_TIPI"]);
                }
            }

            public bool? Refekatci_durumu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REFEKATCI_DURUMU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISPATCHTOOTHERHOSPITAL"].AllPropertyDefs["MEDULAREFAKATCIDURUMU"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public Object E_sevk_numarasi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["E_SEVK_NUMARASI"]);
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

            public VEM_HASTA_SEVK_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public VEM_HASTA_SEVK_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected VEM_HASTA_SEVK_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDispatchInfoForNewReport_Class : TTReportNqlObject 
        {
            public DateTime? Sevktarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SEVKTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISPATCHTOOTHERHOSPITAL"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Sevkyapanbirim
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SEVKYAPANBIRIM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public string BirthPlace
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIRTHPLACE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["BIRTHPLACE"].DataType;
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

            public long? Dosyano
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOSYANO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? Refno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REFNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["UNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
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

            public string ProtocolNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Takipno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TAKIPNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISPATCHTOOTHERHOSPITAL"].AllPropertyDefs["MEDULASEVKTAKIPNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Episodeid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODEID"]);
                }
            }

            public Guid? Subepisodeid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SUBEPISODEID"]);
                }
            }

            public string Sevkadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SEVKADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SEVKNEDENI"].AllPropertyDefs["SEVKNEDENIADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Sevkgerekcesi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SEVKGEREKCESI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISPATCHTOOTHERHOSPITAL"].AllPropertyDefs["REASONOFDISPATCH"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Dispatchedspecialityname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISPATCHEDSPECIALITYNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Gidecegisehir
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GIDECEGISEHIR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSILKODLARI"].AllPropertyDefs["ADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Sevktipi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SEVKTIPI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SEVKTEDAVITIPI"].AllPropertyDefs["SEVKTEDAVITIPIADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Sevkvasitasi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SEVKVASITASI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SEVKVASITASI"].AllPropertyDefs["SEVKVASITASIADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string XXXXXX
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["XXXXXX"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EXTERNALHOSPITALDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Refakatcigerekcesi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REFAKATCIGEREKCESI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISPATCHTOOTHERHOSPITAL"].AllPropertyDefs["COMPANIONREASON"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Doktor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOKTOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetDispatchInfoForNewReport_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDispatchInfoForNewReport_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDispatchInfoForNewReport_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDispatchesByPatient_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Sevkadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SEVKADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SEVKNEDENI"].AllPropertyDefs["SEVKNEDENIADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Sevktipi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SEVKTIPI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SEVKTEDAVITIPI"].AllPropertyDefs["SEVKTEDAVITIPIADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Sevkvasitasi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SEVKVASITASI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SEVKVASITASI"].AllPropertyDefs["SEVKVASITASIADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Il
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["IL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSILKODLARI"].AllPropertyDefs["ADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Sevkno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SEVKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISPATCHTOOTHERHOSPITAL"].AllPropertyDefs["MEDULASEVKTAKIPNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string XXXXXX
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["XXXXXX"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EXTERNALHOSPITALDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetDispatchesByPatient_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDispatchesByPatient_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDispatchesByPatient_Class() : base() { }
        }

        public static class States
        {
            public static Guid Cancel { get { return new Guid("e8c65415-7d07-4aef-b063-95ae81b914b7"); } }
    /// <summary>
    /// Medulaya Sevk Bildir
    /// </summary>
            public static Guid SendMedula { get { return new Guid("fe5b5ecb-f65a-4e37-a78c-afd76747e9ae"); } }
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("856b02a7-399e-4366-bb3f-8cd7c38c4d4e"); } }
    /// <summary>
    /// Sevk Edildi
    /// </summary>
            public static Guid Dispatched { get { return new Guid("fb6927f1-d2b8-4792-a6e0-d8cb9daa92a0"); } }
            public static Guid Completed { get { return new Guid("9238538d-b997-46c9-8f9b-c88c5ea0a5cf"); } }
            public static Guid DeleteDispatchProvision { get { return new Guid("f4455270-ddc4-4099-9662-601a38ca8b80"); } }
        }

        public static BindingList<DispatchToOtherHospital.GetDispatchInformationOfPatientNQL_Class> GetDispatchInformationOfPatientNQL(Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DISPATCHTOOTHERHOSPITAL"].QueryDefs["GetDispatchInformationOfPatientNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<DispatchToOtherHospital.GetDispatchInformationOfPatientNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DispatchToOtherHospital.GetDispatchInformationOfPatientNQL_Class> GetDispatchInformationOfPatientNQL(TTObjectContext objectContext, Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DISPATCHTOOTHERHOSPITAL"].QueryDefs["GetDispatchInformationOfPatientNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<DispatchToOtherHospital.GetDispatchInformationOfPatientNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DispatchToOtherHospital.GetDispatchedPatientsNQL_Class> GetDispatchedPatientsNQL(DateTime ACTIONSTARTDATE, DateTime ACTIONENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DISPATCHTOOTHERHOSPITAL"].QueryDefs["GetDispatchedPatientsNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ACTIONSTARTDATE", ACTIONSTARTDATE);
            paramList.Add("ACTIONENDDATE", ACTIONENDDATE);

            return TTReportNqlObject.QueryObjects<DispatchToOtherHospital.GetDispatchedPatientsNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DispatchToOtherHospital.GetDispatchedPatientsNQL_Class> GetDispatchedPatientsNQL(TTObjectContext objectContext, DateTime ACTIONSTARTDATE, DateTime ACTIONENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DISPATCHTOOTHERHOSPITAL"].QueryDefs["GetDispatchedPatientsNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ACTIONSTARTDATE", ACTIONSTARTDATE);
            paramList.Add("ACTIONENDDATE", ACTIONENDDATE);

            return TTReportNqlObject.QueryObjects<DispatchToOtherHospital.GetDispatchedPatientsNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DispatchToOtherHospital.DispatchCountQuery_Class> DispatchCountQuery(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DISPATCHTOOTHERHOSPITAL"].QueryDefs["DispatchCountQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<DispatchToOtherHospital.DispatchCountQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DispatchToOtherHospital.DispatchCountQuery_Class> DispatchCountQuery(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DISPATCHTOOTHERHOSPITAL"].QueryDefs["DispatchCountQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<DispatchToOtherHospital.DispatchCountQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DispatchToOtherHospital.OLAP_XXXXXXlerArasiSevk_Class> OLAP_XXXXXXlerArasiSevk(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DISPATCHTOOTHERHOSPITAL"].QueryDefs["OLAP_XXXXXXlerArasiSevk"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DispatchToOtherHospital.OLAP_XXXXXXlerArasiSevk_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DispatchToOtherHospital.OLAP_XXXXXXlerArasiSevk_Class> OLAP_XXXXXXlerArasiSevk(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DISPATCHTOOTHERHOSPITAL"].QueryDefs["OLAP_XXXXXXlerArasiSevk"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DispatchToOtherHospital.OLAP_XXXXXXlerArasiSevk_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DispatchToOtherHospital.VEM_HASTA_SEVK_Class> VEM_HASTA_SEVK(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DISPATCHTOOTHERHOSPITAL"].QueryDefs["VEM_HASTA_SEVK"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DispatchToOtherHospital.VEM_HASTA_SEVK_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DispatchToOtherHospital.VEM_HASTA_SEVK_Class> VEM_HASTA_SEVK(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DISPATCHTOOTHERHOSPITAL"].QueryDefs["VEM_HASTA_SEVK"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DispatchToOtherHospital.VEM_HASTA_SEVK_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DispatchToOtherHospital.GetDispatchInfoForNewReport_Class> GetDispatchInfoForNewReport(Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DISPATCHTOOTHERHOSPITAL"].QueryDefs["GetDispatchInfoForNewReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<DispatchToOtherHospital.GetDispatchInfoForNewReport_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DispatchToOtherHospital.GetDispatchInfoForNewReport_Class> GetDispatchInfoForNewReport(TTObjectContext objectContext, Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DISPATCHTOOTHERHOSPITAL"].QueryDefs["GetDispatchInfoForNewReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<DispatchToOtherHospital.GetDispatchInfoForNewReport_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DispatchToOtherHospital.GetDispatchesByPatient_Class> GetDispatchesByPatient(Guid PATIENT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DISPATCHTOOTHERHOSPITAL"].QueryDefs["GetDispatchesByPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<DispatchToOtherHospital.GetDispatchesByPatient_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DispatchToOtherHospital.GetDispatchesByPatient_Class> GetDispatchesByPatient(TTObjectContext objectContext, Guid PATIENT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DISPATCHTOOTHERHOSPITAL"].QueryDefs["GetDispatchesByPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<DispatchToOtherHospital.GetDispatchesByPatient_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Medula Tesis Kodu
    /// </summary>
        public int? MedulaSiteCode
        {
            get { return (int?)this["MEDULASITECODE"]; }
            set { this["MEDULASITECODE"] = value; }
        }

        public string DispatcherDoctorName
        {
            get { return (string)this["DISPATCHERDOCTORNAME"]; }
            set { this["DISPATCHERDOCTORNAME"] = value; }
        }

        public string DispatcherDoctorEmploymentID
        {
            get { return (string)this["DISPATCHERDOCTOREMPLOYMENTID"]; }
            set { this["DISPATCHERDOCTOREMPLOYMENTID"] = value; }
        }

        public string DispatchedDoctorName
        {
            get { return (string)this["DISPATCHEDDOCTORNAME"]; }
            set { this["DISPATCHEDDOCTORNAME"] = value; }
        }

        public string DispatchedDoctorEmploymentID
        {
            get { return (string)this["DISPATCHEDDOCTOREMPLOYMENTID"]; }
            set { this["DISPATCHEDDOCTOREMPLOYMENTID"] = value; }
        }

        public string DispatcherDoctorDiplomaRegNo
        {
            get { return (string)this["DISPATCHERDOCTORDIPLOMAREGNO"]; }
            set { this["DISPATCHERDOCTORDIPLOMAREGNO"] = value; }
        }

        public string DispatchedDoctorDiplomaRegNo
        {
            get { return (string)this["DISPATCHEDDOCTORDIPLOMAREGNO"]; }
            set { this["DISPATCHEDDOCTORDIPLOMAREGNO"] = value; }
        }

    /// <summary>
    /// Sevk Gerekçesi
    /// </summary>
        public string ReasonOfDispatch
        {
            get { return (string)this["REASONOFDISPATCH"]; }
            set { this["REASONOFDISPATCH"] = value; }
        }

    /// <summary>
    /// Refakatçi Gerekçesi
    /// </summary>
        public string CompanionReason
        {
            get { return (string)this["COMPANIONREASON"]; }
            set { this["COMPANIONREASON"] = value; }
        }

    /// <summary>
    /// Sevk Vasıtası
    /// </summary>
        public string DispatchVehicle
        {
            get { return (string)this["DISPATCHVEHICLE"]; }
            set { this["DISPATCHVEHICLE"] = value; }
        }

    /// <summary>
    /// Gönderilen XXXXXXde oluşan konsültasyon işleminin objectID sini tutar.
    /// </summary>
        public string SourceObjectID
        {
            get { return (string)this["SOURCEOBJECTID"]; }
            set { this["SOURCEOBJECTID"] = value; }
        }

    /// <summary>
    /// Gönderen XXXXXXdeki konsültasyon işleminin objectID sini tutar.
    /// </summary>
        public string TargetObjectID
        {
            get { return (string)this["TARGETOBJECTID"]; }
            set { this["TARGETOBJECTID"] = value; }
        }

    /// <summary>
    /// Medula Refakatçi Durumu
    /// </summary>
        public bool? MedulaRefakatciDurumu
        {
            get { return (bool?)this["MEDULAREFAKATCIDURUMU"]; }
            set { this["MEDULAREFAKATCIDURUMU"] = value; }
        }

    /// <summary>
    /// Meduladan dönen Mutat Dışı Araç Rapor ID
    /// </summary>
        public long? MutatDisiAracRaporId
        {
            get { return (long?)this["MUTATDISIARACRAPORID"]; }
            set { this["MUTATDISIARACRAPORID"] = value; }
        }

    /// <summary>
    /// Mutat Dışı Araç Rapor Tarihi
    /// </summary>
        public DateTime? MutatDisiAracRaporTarihi
        {
            get { return (DateTime?)this["MUTATDISIARACRAPORTARIHI"]; }
            set { this["MUTATDISIARACRAPORTARIHI"] = value; }
        }

    /// <summary>
    /// Mutat Dışı Araç Rapor Bitiş Tarihi
    /// </summary>
        public DateTime? MutatDisiAracBitisTarihi
        {
            get { return (DateTime?)this["MUTATDISIARACBITISTARIHI"]; }
            set { this["MUTATDISIARACBITISTARIHI"] = value; }
        }

    /// <summary>
    /// Mutat Dışı Araç Rapor Başlangıç Tarihi
    /// </summary>
        public DateTime? MutatDisiAracBaslangicTarihi
        {
            get { return (DateTime?)this["MUTATDISIARACBASLANGICTARIHI"]; }
            set { this["MUTATDISIARACBASLANGICTARIHI"] = value; }
        }

    /// <summary>
    /// Mutat Dışı Gerekçesi
    /// </summary>
        public string MutatDisiGerekcesi
        {
            get { return (string)this["MUTATDISIGEREKCESI"]; }
            set { this["MUTATDISIGEREKCESI"] = value; }
        }

    /// <summary>
    /// Meduladan dönen Sevk Takip No
    /// </summary>
        public string MedulaSevkTakipNo
        {
            get { return (string)this["MEDULASEVKTAKIPNO"]; }
            set { this["MEDULASEVKTAKIPNO"] = value; }
        }

        public string MessageID
        {
            get { return (string)this["MESSAGEID"]; }
            set { this["MESSAGEID"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Sevk Sonucu Oluşan Vaka 
    /// </summary>
        public Guid? TargetEpisodeObjectID
        {
            get { return (Guid?)this["TARGETEPISODEOBJECTID"]; }
            set { this["TARGETEPISODEOBJECTID"] = value; }
        }

    /// <summary>
    /// Genel Sağlık Sigortalısının Adı
    /// </summary>
        public string GSSOwnerName
        {
            get { return (string)this["GSSOWNERNAME"]; }
            set { this["GSSOWNERNAME"] = value; }
        }

        public DateTime? RestingStartDate
        {
            get { return (DateTime?)this["RESTINGSTARTDATE"]; }
            set { this["RESTINGSTARTDATE"] = value; }
        }

    /// <summary>
    /// Refakatçi Durumu
    /// </summary>
        public string CompanionStatus
        {
            get { return (string)this["COMPANIONSTATUS"]; }
            set { this["COMPANIONSTATUS"] = value; }
        }

        public DateTime? RestingEndDate
        {
            get { return (DateTime?)this["RESTINGENDDATE"]; }
            set { this["RESTINGENDDATE"] = value; }
        }

    /// <summary>
    /// Mutat Dışı Araç XXXXXX Rapor ID
    /// </summary>
        public TTSequence MutatDisiAracXXXXXXRaporID
        {
            get { return GetSequence("MUTATDISIARACXXXXXXRAPORID"); }
        }

    /// <summary>
    /// Genel Sağlık Sigortalısının TC Kimlik No
    /// </summary>
        public long? GSSOwnerUniquerefNo
        {
            get { return (long?)this["GSSOWNERUNIQUEREFNO"]; }
            set { this["GSSOWNERUNIQUEREFNO"] = value; }
        }

    /// <summary>
    /// Epikriz teslim edildi mi?
    /// </summary>
        public bool? EpicrisisDelivered
        {
            get { return (bool?)this["EPICRISISDELIVERED"]; }
            set { this["EPICRISISDELIVERED"] = value; }
        }

    /// <summary>
    /// özel bir ekip yada donanım ihtiyacı varmı 
    /// </summary>
        public bool? NeedSpecialEquipment
        {
            get { return (bool?)this["NEEDSPECIALEQUIPMENT"]; }
            set { this["NEEDSPECIALEQUIPMENT"] = value; }
        }

    /// <summary>
    /// İl Sınırları içinde/dışında
    /// </summary>
        public IlSınırBilgisi? IlSinir
        {
            get { return (IlSınırBilgisi?)(int?)this["ILSINIR"]; }
            set { this["ILSINIR"] = value; }
        }

    /// <summary>
    /// DispatcherDoctor
    /// </summary>
        public ResUser DispatcherDoctor
        {
            get { return (ResUser)((ITTObject)this).GetParent("DISPATCHERDOCTOR"); }
            set { this["DISPATCHERDOCTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Sevk Edilen XXXXXX
    /// </summary>
        public Sites RequestedSite
        {
            get { return (Sites)((ITTObject)this).GetParent("REQUESTEDSITE"); }
            set { this["REQUESTEDSITE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SpecialityDefinition DispatchedSpeciality
        {
            get { return (SpecialityDefinition)((ITTObject)this).GetParent("DISPATCHEDSPECIALITY"); }
            set { this["DISPATCHEDSPECIALITY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResUser DispatchedDoctor
        {
            get { return (ResUser)((ITTObject)this).GetParent("DISPATCHEDDOCTOR"); }
            set { this["DISPATCHEDDOCTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Sevk Edilen XXXXXX XXXXXX Birimi
    /// </summary>
        public ReferableResource RequestedReferableResource
        {
            get { return (ReferableResource)((ITTObject)this).GetParent("REQUESTEDREFERABLERESOURCE"); }
            set { this["REQUESTEDREFERABLERESOURCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Sevk Edilen XXXXXX XXXXXX
    /// </summary>
        public ReferableHospital RequestedReferableHospital
        {
            get { return (ReferableHospital)((ITTObject)this).GetParent("REQUESTEDREFERABLEHOSPITAL"); }
            set { this["REQUESTEDREFERABLEHOSPITAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İstek Yapılan Dış XXXXXX
    /// </summary>
        public ExternalHospitalDefinition RequestedExternalHospital
        {
            get { return (ExternalHospitalDefinition)((ITTObject)this).GetParent("REQUESTEDEXTERNALHOSPITAL"); }
            set { this["REQUESTEDEXTERNALHOSPITAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İstek Yapılan Dış XXXXXX Birimi
    /// </summary>
        public SpecialityDefinition RequestedExternalDepartment
        {
            get { return (SpecialityDefinition)((ITTObject)this).GetParent("REQUESTEDEXTERNALDEPARTMENT"); }
            set { this["REQUESTEDEXTERNALDEPARTMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İstek Yapan XXXXXX
    /// </summary>
        public ResOtherHospital RequesterHospital
        {
            get { return (ResOtherHospital)((ITTObject)this).GetParent("REQUESTERHOSPITAL"); }
            set { this["REQUESTERHOSPITAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Sites RequesterSite
        {
            get { return (Sites)((ITTObject)this).GetParent("REQUESTERSITE"); }
            set { this["REQUESTERSITE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SevkVasitasi SevkVasitasi
        {
            get { return (SevkVasitasi)((ITTObject)this).GetParent("SEVKVASITASI"); }
            set { this["SEVKVASITASI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SevkNedeni SevkNedeni
        {
            get { return (SevkNedeni)((ITTObject)this).GetParent("SEVKNEDENI"); }
            set { this["SEVKNEDENI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SevkTedaviTipi SevkTedaviTipi
        {
            get { return (SevkTedaviTipi)((ITTObject)this).GetParent("SEVKTEDAVITIPI"); }
            set { this["SEVKTEDAVITIPI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Gideceği Şehir
    /// </summary>
        public SKRSILKodlari DispatchCity
        {
            get { return (SKRSILKodlari)((ITTObject)this).GetParent("DISPATCHCITY"); }
            set { this["DISPATCHCITY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateDoctorsGridCollection()
        {
            _DoctorsGrid = new DoctorGrid.ChildDoctorGridCollection(this, new Guid("7446c822-68b8-40a1-bf92-539fc43a1d0d"));
            ((ITTChildObjectCollection)_DoctorsGrid).GetChildren();
        }

        protected DoctorGrid.ChildDoctorGridCollection _DoctorsGrid = null;
        public DoctorGrid.ChildDoctorGridCollection DoctorsGrid
        {
            get
            {
                if (_DoctorsGrid == null)
                    CreateDoctorsGridCollection();
                return _DoctorsGrid;
            }
        }

        protected DispatchToOtherHospital(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DispatchToOtherHospital(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DispatchToOtherHospital(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DispatchToOtherHospital(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DispatchToOtherHospital(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DISPATCHTOOTHERHOSPITAL", dataRow) { }
        protected DispatchToOtherHospital(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DISPATCHTOOTHERHOSPITAL", dataRow, isImported) { }
        public DispatchToOtherHospital(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DispatchToOtherHospital(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DispatchToOtherHospital() : base() { }

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