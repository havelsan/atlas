
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="Appointment")] 

    /// <summary>
    /// Randevu
    /// </summary>
    public  partial class Appointment : TTObject, IAppointmentPermission
    {
        public class AppointmentList : TTObjectCollection<Appointment> { }
                    
        public class ChildAppointmentCollection : TTObject.TTChildObjectCollection<Appointment>
        {
            public ChildAppointmentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAppointmentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetAppointmentListReportNQL_Class : TTReportNqlObject 
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

            public string StateID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STATEID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["STATEID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? AppointmentID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["APPOINTMENTID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["APPOINTMENTID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Notes
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["NOTES"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? EndTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENDTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["ENDTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? StartTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STARTTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["STARTTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? AppDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["APPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["APPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? BreakAppointment
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BREAKAPPOINTMENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["BREAKAPPOINTMENT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public AppointmentTypeEnum? AppointmentType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["APPOINTMENTTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["APPOINTMENTTYPE"].DataType;
                    return (AppointmentTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? GivingType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GIVINGTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["GIVINGTYPE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsNumarator
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISNUMARATOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["ISNUMARATOR"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string MHRSRandevuHrn
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MHRSRANDEVUHRN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["MHRSRANDEVUHRN"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsCancelledByMHRSIstisna
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISCANCELLEDBYMHRSISTISNA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["ISCANCELLEDBYMHRSISTISNA"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? AppointmentUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["APPOINTMENTUPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["APPOINTMENTUPDATE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? MHRSHastaGeldi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MHRSHASTAGELDI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["MHRSHASTAGELDI"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? CancelledMHRS
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CANCELLEDMHRS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["CANCELLEDMHRS"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string AppViewerState
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["APPVIEWERSTATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["APPVIEWERSTATE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string InitialObjectID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INITIALOBJECTID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["INITIALOBJECTID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ExternalAppointmentID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXTERNALAPPOINTMENTID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["EXTERNALAPPOINTMENTID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetAppointmentListReportNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAppointmentListReportNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAppointmentListReportNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class GetAppointmentByPatientExaminationID_Class : TTReportNqlObject 
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

            public string StateID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STATEID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["STATEID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? AppointmentID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["APPOINTMENTID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["APPOINTMENTID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Notes
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["NOTES"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? EndTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENDTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["ENDTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? StartTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STARTTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["STARTTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? AppDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["APPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["APPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? BreakAppointment
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BREAKAPPOINTMENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["BREAKAPPOINTMENT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public AppointmentTypeEnum? AppointmentType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["APPOINTMENTTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["APPOINTMENTTYPE"].DataType;
                    return (AppointmentTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? GivingType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GIVINGTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["GIVINGTYPE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsNumarator
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISNUMARATOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["ISNUMARATOR"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string MHRSRandevuHrn
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MHRSRANDEVUHRN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["MHRSRANDEVUHRN"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsCancelledByMHRSIstisna
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISCANCELLEDBYMHRSISTISNA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["ISCANCELLEDBYMHRSISTISNA"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? AppointmentUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["APPOINTMENTUPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["APPOINTMENTUPDATE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? MHRSHastaGeldi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MHRSHASTAGELDI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["MHRSHASTAGELDI"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? CancelledMHRS
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CANCELLEDMHRS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["CANCELLEDMHRS"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string AppViewerState
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["APPVIEWERSTATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["APPVIEWERSTATE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string InitialObjectID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INITIALOBJECTID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["INITIALOBJECTID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ExternalAppointmentID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXTERNALAPPOINTMENTID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["EXTERNALAPPOINTMENTID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetAppointmentByPatientExaminationID_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAppointmentByPatientExaminationID_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAppointmentByPatientExaminationID_Class() : base() { }
        }

        [Serializable] 

        public partial class GetAppointmentsForAppViewer_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public DateTime? StartTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STARTTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["STARTTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? MasterResource
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MASTERRESOURCE"]);
                }
            }

            public Guid? Resource
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["RESOURCE"]);
                }
            }

            public Guid? Patient
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PATIENT"]);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public GetAppointmentsForAppViewer_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAppointmentsForAppViewer_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAppointmentsForAppViewer_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMinNumaratorAppointmentResource_Class : TTReportNqlObject 
        {
            public Guid? Resource
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["RESOURCE"]);
                }
            }

            public GetMinNumaratorAppointmentResource_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMinNumaratorAppointmentResource_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMinNumaratorAppointmentResource_Class() : base() { }
        }

        [Serializable] 

        public partial class GetAppointmentByResourceAndPatient_Class : TTReportNqlObject 
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

            public string StateID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STATEID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["STATEID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? AppointmentID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["APPOINTMENTID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["APPOINTMENTID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Notes
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["NOTES"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? EndTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENDTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["ENDTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? StartTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STARTTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["STARTTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? AppDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["APPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["APPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? BreakAppointment
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BREAKAPPOINTMENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["BREAKAPPOINTMENT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public AppointmentTypeEnum? AppointmentType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["APPOINTMENTTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["APPOINTMENTTYPE"].DataType;
                    return (AppointmentTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? GivingType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GIVINGTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["GIVINGTYPE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsNumarator
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISNUMARATOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["ISNUMARATOR"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string MHRSRandevuHrn
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MHRSRANDEVUHRN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["MHRSRANDEVUHRN"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsCancelledByMHRSIstisna
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISCANCELLEDBYMHRSISTISNA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["ISCANCELLEDBYMHRSISTISNA"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? AppointmentUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["APPOINTMENTUPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["APPOINTMENTUPDATE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? MHRSHastaGeldi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MHRSHASTAGELDI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["MHRSHASTAGELDI"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? CancelledMHRS
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CANCELLEDMHRS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["CANCELLEDMHRS"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string AppViewerState
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["APPVIEWERSTATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["APPVIEWERSTATE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string InitialObjectID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INITIALOBJECTID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["INITIALOBJECTID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ExternalAppointmentID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXTERNALAPPOINTMENTID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["EXTERNALAPPOINTMENTID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetAppointmentByResourceAndPatient_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAppointmentByResourceAndPatient_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAppointmentByResourceAndPatient_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMHRSAppointment_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? MasterResource
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MASTERRESOURCE"]);
                }
            }

            public Guid? Resource
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["RESOURCE"]);
                }
            }

            public DateTime? StartTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STARTTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["STARTTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? EndTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENDTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["ENDTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? AppDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["APPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["APPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? CancelledMHRS
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CANCELLEDMHRS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["CANCELLEDMHRS"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsCancelledByMHRSIstisna
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISCANCELLEDBYMHRSISTISNA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["ISCANCELLEDBYMHRSISTISNA"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public string MHRSRandevuHrn
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MHRSRANDEVUHRN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["MHRSRANDEVUHRN"].DataType;
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

            public Guid? Action
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ACTION"]);
                }
            }

            public GetMHRSAppointment_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMHRSAppointment_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMHRSAppointment_Class() : base() { }
        }

        [Serializable] 

        public partial class GetBreakAppointmentListReportNQL_Class : TTReportNqlObject 
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

            public string StateID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STATEID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["STATEID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? AppointmentID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["APPOINTMENTID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["APPOINTMENTID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Notes
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["NOTES"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? EndTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENDTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["ENDTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? StartTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STARTTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["STARTTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? AppDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["APPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["APPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? BreakAppointment
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BREAKAPPOINTMENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["BREAKAPPOINTMENT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public AppointmentTypeEnum? AppointmentType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["APPOINTMENTTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["APPOINTMENTTYPE"].DataType;
                    return (AppointmentTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? GivingType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GIVINGTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["GIVINGTYPE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsNumarator
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISNUMARATOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["ISNUMARATOR"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string MHRSRandevuHrn
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MHRSRANDEVUHRN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["MHRSRANDEVUHRN"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsCancelledByMHRSIstisna
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISCANCELLEDBYMHRSISTISNA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["ISCANCELLEDBYMHRSISTISNA"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? AppointmentUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["APPOINTMENTUPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["APPOINTMENTUPDATE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? MHRSHastaGeldi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MHRSHASTAGELDI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["MHRSHASTAGELDI"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? CancelledMHRS
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CANCELLEDMHRS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["CANCELLEDMHRS"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string AppViewerState
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["APPVIEWERSTATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["APPVIEWERSTATE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string InitialObjectID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INITIALOBJECTID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["INITIALOBJECTID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ExternalAppointmentID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXTERNALAPPOINTMENTID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["EXTERNALAPPOINTMENTID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetBreakAppointmentListReportNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetBreakAppointmentListReportNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetBreakAppointmentListReportNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class GetAppointmentBySchedule_Class : TTReportNqlObject 
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

            public string StateID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STATEID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["STATEID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? AppointmentID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["APPOINTMENTID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["APPOINTMENTID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Notes
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["NOTES"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? EndTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENDTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["ENDTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? StartTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STARTTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["STARTTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? AppDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["APPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["APPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? BreakAppointment
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BREAKAPPOINTMENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["BREAKAPPOINTMENT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public AppointmentTypeEnum? AppointmentType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["APPOINTMENTTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["APPOINTMENTTYPE"].DataType;
                    return (AppointmentTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? GivingType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GIVINGTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["GIVINGTYPE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsNumarator
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISNUMARATOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["ISNUMARATOR"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string MHRSRandevuHrn
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MHRSRANDEVUHRN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["MHRSRANDEVUHRN"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsCancelledByMHRSIstisna
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISCANCELLEDBYMHRSISTISNA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["ISCANCELLEDBYMHRSISTISNA"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? AppointmentUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["APPOINTMENTUPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["APPOINTMENTUPDATE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? MHRSHastaGeldi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MHRSHASTAGELDI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["MHRSHASTAGELDI"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? CancelledMHRS
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CANCELLEDMHRS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["CANCELLEDMHRS"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string AppViewerState
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["APPVIEWERSTATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["APPVIEWERSTATE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string InitialObjectID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INITIALOBJECTID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["INITIALOBJECTID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ExternalAppointmentID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXTERNALAPPOINTMENTID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["EXTERNALAPPOINTMENTID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetAppointmentBySchedule_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAppointmentBySchedule_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAppointmentBySchedule_Class() : base() { }
        }

        [Serializable] 

        public partial class VEM_RANDEVU_Class : TTReportNqlObject 
        {
            public Guid? Randevu_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["RANDEVU_KODU"]);
                }
            }

            public Object Referans_tablo_adi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["REFERANS_TABLO_ADI"]);
                }
            }

            public AppointmentTypeEnum? Randevu_turu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RANDEVU_TURU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["APPOINTMENTTYPE"].DataType;
                    return (AppointmentTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public DateTime? Randevu_zamani
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RANDEVU_ZAMANI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["STARTTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Randevu_kayit_zamani
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RANDEVU_KAYIT_ZAMANI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["APPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? Hasta_basvuru_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["HASTA_BASVURU_KODU"]);
                }
            }

            public Guid? Hasta_hizmet_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["HASTA_HIZMET_KODU"]);
                }
            }

            public Guid? Birim_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["BIRIM_KODU"]);
                }
            }

            public Guid? Hekim_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["HEKIM_KODU"]);
                }
            }

            public string Mhrs_hrn_kodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MHRS_HRN_KODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["MHRSRANDEVUHRN"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Boolean? Durum
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DURUM"]);
                    if (val == null)
                        return null;
                    return (Boolean)Convert.ChangeType(val, typeof(Boolean)); 
                }
            }

            public Guid? Cihaz_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CIHAZ_KODU"]);
                }
            }

            public long? Tc_kimlik_numarasi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TC_KIMLIK_NUMARASI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["UNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Ad
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Soyad
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SOYAD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Cinsiyet
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CINSIYET"]);
                }
            }

            public Object Telefon
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TELEFON"]);
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

            public Guid? SubEpisode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SUBEPISODE"]);
                }
            }

            public Guid? Episode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODE"]);
                }
            }

            public VEM_RANDEVU_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public VEM_RANDEVU_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected VEM_RANDEVU_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMHRSAppointmentTimeIsPast_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Masterresource
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MASTERRESOURCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESOURCE"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Resource
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESOURCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESOURCE"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? StartTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STARTTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["STARTTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? EndTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENDTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["ENDTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? AppDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["APPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["APPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? CancelledMHRS
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CANCELLEDMHRS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["CANCELLEDMHRS"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsCancelledByMHRSIstisna
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISCANCELLEDBYMHRSISTISNA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["ISCANCELLEDBYMHRSISTISNA"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public string MHRSRandevuHrn
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MHRSRANDEVUHRN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["MHRSRANDEVUHRN"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public Guid? Action
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ACTION"]);
                }
            }

            public GetMHRSAppointmentTimeIsPast_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMHRSAppointmentTimeIsPast_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMHRSAppointmentTimeIsPast_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPatientAppointmentByID_Class : TTReportNqlObject 
        {
            public Guid? Patient
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PATIENT"]);
                }
            }

            public GetPatientAppointmentByID_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPatientAppointmentByID_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPatientAppointmentByID_Class() : base() { }
        }

        [Serializable] 

        public partial class GetAppointmentByDateAndPatient_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? Patient
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PATIENT"]);
                }
            }

            public string Notes
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["NOTES"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? AppDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["APPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].AllPropertyDefs["APPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESOURCE"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetAppointmentByDateAndPatient_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAppointmentByDateAndPatient_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAppointmentByDateAndPatient_Class() : base() { }
        }

        [Serializable] 

        public partial class GetUserAppointmentsByDateTime_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetUserAppointmentsByDateTime_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetUserAppointmentsByDateTime_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetUserAppointmentsByDateTime_Class() : base() { }
        }

        public static class States
        {
            public static Guid Completed { get { return new Guid("a313ce36-9f81-4e06-924b-1604a67e9246"); } }
            public static Guid New { get { return new Guid("e2a72bcb-86d8-4e8a-b9e7-379bdc87f8e2"); } }
            public static Guid Cancelled { get { return new Guid("90b08ccf-ccb4-4c06-abb3-ba4a9d4c41d9"); } }
            public static Guid NotApproved { get { return new Guid("998cf5ce-d1cc-4114-89d0-611853b3de6b"); } }
        }

        public static BindingList<Appointment.GetAppointmentListReportNQL_Class> GetAppointmentListReportNQL(IList<string> OBJECTIDS, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].QueryDefs["GetAppointmentListReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTIDS", OBJECTIDS);

            return TTReportNqlObject.QueryObjects<Appointment.GetAppointmentListReportNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Appointment.GetAppointmentListReportNQL_Class> GetAppointmentListReportNQL(TTObjectContext objectContext, IList<string> OBJECTIDS, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].QueryDefs["GetAppointmentListReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTIDS", OBJECTIDS);

            return TTReportNqlObject.QueryObjects<Appointment.GetAppointmentListReportNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Appointment> GetByPatientAndAppDate(TTObjectContext objectContext, DateTime STARTTIME, DateTime ENDTIME, string PATIENT, DateTime APPDATE, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].QueryDefs["GetByPatientAndAppDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTTIME", STARTTIME);
            paramList.Add("ENDTIME", ENDTIME);
            paramList.Add("PATIENT", PATIENT);
            paramList.Add("APPDATE", APPDATE);

            return ((ITTQuery)objectContext).QueryObjects<Appointment>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<Appointment> GetBySubActionProcedureAndState(TTObjectContext objectContext, string SUBACTIONPROCEDURE, string STATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].QueryDefs["GetBySubActionProcedureAndState"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBACTIONPROCEDURE", SUBACTIONPROCEDURE);
            paramList.Add("STATE", STATE);

            return ((ITTQuery)objectContext).QueryObjects<Appointment>(queryDef, paramList);
        }

        public static BindingList<Appointment> GetByStartTimeAndResource(TTObjectContext objectContext, DateTime APPDATE, DateTime STARTTIME, string RESOURCE, DateTime ENDTIME, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].QueryDefs["GetByStartTimeAndResource"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("APPDATE", APPDATE);
            paramList.Add("STARTTIME", STARTTIME);
            paramList.Add("RESOURCE", RESOURCE);
            paramList.Add("ENDTIME", ENDTIME);

            return ((ITTQuery)objectContext).QueryObjects<Appointment>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<Appointment> GetByInjection(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].QueryDefs["GetByInjection"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<Appointment>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<Appointment> GetByActionAndState(TTObjectContext objectContext, string ACTION, string STATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].QueryDefs["GetByActionAndState"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ACTION", ACTION);
            paramList.Add("STATE", STATE);

            return ((ITTQuery)objectContext).QueryObjects<Appointment>(queryDef, paramList);
        }

        public static BindingList<Appointment> GetByPatientByDateByResource(TTObjectContext objectContext, string PATIENT, DateTime APPDATE, string MASTERRESOURCE, string RESOURCE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].QueryDefs["GetByPatientByDateByResource"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);
            paramList.Add("APPDATE", APPDATE);
            paramList.Add("MASTERRESOURCE", MASTERRESOURCE);
            paramList.Add("RESOURCE", RESOURCE);

            return ((ITTQuery)objectContext).QueryObjects<Appointment>(queryDef, paramList);
        }

        public static BindingList<Appointment> GetByAppDateAndResource(TTObjectContext objectContext, DateTime STARTTIME, DateTime ENDTIME, string RESOURCE, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].QueryDefs["GetByAppDateAndResource"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTTIME", STARTTIME);
            paramList.Add("ENDTIME", ENDTIME);
            paramList.Add("RESOURCE", RESOURCE);

            return ((ITTQuery)objectContext).QueryObjects<Appointment>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<Appointment.GetAppointmentByPatientExaminationID_Class> GetAppointmentByPatientExaminationID(string PATIENTEXAMINATIONOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].QueryDefs["GetAppointmentByPatientExaminationID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTEXAMINATIONOBJECTID", PATIENTEXAMINATIONOBJECTID);

            return TTReportNqlObject.QueryObjects<Appointment.GetAppointmentByPatientExaminationID_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Appointment.GetAppointmentByPatientExaminationID_Class> GetAppointmentByPatientExaminationID(TTObjectContext objectContext, string PATIENTEXAMINATIONOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].QueryDefs["GetAppointmentByPatientExaminationID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTEXAMINATIONOBJECTID", PATIENTEXAMINATIONOBJECTID);

            return TTReportNqlObject.QueryObjects<Appointment.GetAppointmentByPatientExaminationID_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Appointment.GetAppointmentsForAppViewer_Class> GetAppointmentsForAppViewer(DateTime STARTDATE, DateTime ENDDATE, IList<string> MASTERRESOURCEOBJECTIDS, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].QueryDefs["GetAppointmentsForAppViewer"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("MASTERRESOURCEOBJECTIDS", MASTERRESOURCEOBJECTIDS);

            return TTReportNqlObject.QueryObjects<Appointment.GetAppointmentsForAppViewer_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Appointment.GetAppointmentsForAppViewer_Class> GetAppointmentsForAppViewer(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, IList<string> MASTERRESOURCEOBJECTIDS, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].QueryDefs["GetAppointmentsForAppViewer"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("MASTERRESOURCEOBJECTIDS", MASTERRESOURCEOBJECTIDS);

            return TTReportNqlObject.QueryObjects<Appointment.GetAppointmentsForAppViewer_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Appointment> GetPatientAppointmentsByDate(TTObjectContext objectContext, Guid PATIENT, DateTime APPSTARTDATE, DateTime APPENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].QueryDefs["GetPatientAppointmentsByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);
            paramList.Add("APPSTARTDATE", APPSTARTDATE);
            paramList.Add("APPENDDATE", APPENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<Appointment>(queryDef, paramList);
        }

        public static BindingList<Appointment.GetMinNumaratorAppointmentResource_Class> GetMinNumaratorAppointmentResource(Guid MASTERRESOURCE, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].QueryDefs["GetMinNumaratorAppointmentResource"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MASTERRESOURCE", MASTERRESOURCE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<Appointment.GetMinNumaratorAppointmentResource_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Appointment.GetMinNumaratorAppointmentResource_Class> GetMinNumaratorAppointmentResource(TTObjectContext objectContext, Guid MASTERRESOURCE, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].QueryDefs["GetMinNumaratorAppointmentResource"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MASTERRESOURCE", MASTERRESOURCE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<Appointment.GetMinNumaratorAppointmentResource_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Appointment.GetAppointmentByResourceAndPatient_Class> GetAppointmentByResourceAndPatient(DateTime STARTTIME, DateTime ENDTIME, Guid RESOURCE, Guid PATIENT, Guid MASTERRESOURCE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].QueryDefs["GetAppointmentByResourceAndPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTTIME", STARTTIME);
            paramList.Add("ENDTIME", ENDTIME);
            paramList.Add("RESOURCE", RESOURCE);
            paramList.Add("PATIENT", PATIENT);
            paramList.Add("MASTERRESOURCE", MASTERRESOURCE);

            return TTReportNqlObject.QueryObjects<Appointment.GetAppointmentByResourceAndPatient_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Appointment.GetAppointmentByResourceAndPatient_Class> GetAppointmentByResourceAndPatient(TTObjectContext objectContext, DateTime STARTTIME, DateTime ENDTIME, Guid RESOURCE, Guid PATIENT, Guid MASTERRESOURCE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].QueryDefs["GetAppointmentByResourceAndPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTTIME", STARTTIME);
            paramList.Add("ENDTIME", ENDTIME);
            paramList.Add("RESOURCE", RESOURCE);
            paramList.Add("PATIENT", PATIENT);
            paramList.Add("MASTERRESOURCE", MASTERRESOURCE);

            return TTReportNqlObject.QueryObjects<Appointment.GetAppointmentByResourceAndPatient_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Appointment> GetByMHRSRandevuHrn(TTObjectContext objectContext, string MHRSRANDEVUHRN)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].QueryDefs["GetByMHRSRandevuHrn"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MHRSRANDEVUHRN", MHRSRANDEVUHRN);

            return ((ITTQuery)objectContext).QueryObjects<Appointment>(queryDef, paramList);
        }

        public static BindingList<Appointment> GetPatientComeToMHRSAppointment(TTObjectContext objectContext, DateTime STARTTIME)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].QueryDefs["GetPatientComeToMHRSAppointment"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTTIME", STARTTIME);

            return ((ITTQuery)objectContext).QueryObjects<Appointment>(queryDef, paramList);
        }

        public static BindingList<Appointment> GetBySchedule(TTObjectContext objectContext, string SCHEDULE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].QueryDefs["GetBySchedule"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SCHEDULE", SCHEDULE);

            return ((ITTQuery)objectContext).QueryObjects<Appointment>(queryDef, paramList);
        }

        public static BindingList<Appointment.GetMHRSAppointment_Class> GetMHRSAppointment(DateTime STARTTIME, DateTime ENDTIME, Guid RESOURCE, Guid MASTERRESOURCE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].QueryDefs["GetMHRSAppointment"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTTIME", STARTTIME);
            paramList.Add("ENDTIME", ENDTIME);
            paramList.Add("RESOURCE", RESOURCE);
            paramList.Add("MASTERRESOURCE", MASTERRESOURCE);

            return TTReportNqlObject.QueryObjects<Appointment.GetMHRSAppointment_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Appointment.GetMHRSAppointment_Class> GetMHRSAppointment(TTObjectContext objectContext, DateTime STARTTIME, DateTime ENDTIME, Guid RESOURCE, Guid MASTERRESOURCE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].QueryDefs["GetMHRSAppointment"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTTIME", STARTTIME);
            paramList.Add("ENDTIME", ENDTIME);
            paramList.Add("RESOURCE", RESOURCE);
            paramList.Add("MASTERRESOURCE", MASTERRESOURCE);

            return TTReportNqlObject.QueryObjects<Appointment.GetMHRSAppointment_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Appointment.GetBreakAppointmentListReportNQL_Class> GetBreakAppointmentListReportNQL(IList<string> OBJECTIDS, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].QueryDefs["GetBreakAppointmentListReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTIDS", OBJECTIDS);

            return TTReportNqlObject.QueryObjects<Appointment.GetBreakAppointmentListReportNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Appointment.GetBreakAppointmentListReportNQL_Class> GetBreakAppointmentListReportNQL(TTObjectContext objectContext, IList<string> OBJECTIDS, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].QueryDefs["GetBreakAppointmentListReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTIDS", OBJECTIDS);

            return TTReportNqlObject.QueryObjects<Appointment.GetBreakAppointmentListReportNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Appointment> GetByFirstAvailableAppoinmentResource(TTObjectContext objectContext, DateTime STARTTIME, string RESOURCE, DateTime ENDTIME, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].QueryDefs["GetByFirstAvailableAppoinmentResource"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTTIME", STARTTIME);
            paramList.Add("RESOURCE", RESOURCE);
            paramList.Add("ENDTIME", ENDTIME);

            return ((ITTQuery)objectContext).QueryObjects<Appointment>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<Appointment.GetAppointmentBySchedule_Class> GetAppointmentBySchedule(Guid SCHEDULE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].QueryDefs["GetAppointmentBySchedule"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SCHEDULE", SCHEDULE);

            return TTReportNqlObject.QueryObjects<Appointment.GetAppointmentBySchedule_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Appointment.GetAppointmentBySchedule_Class> GetAppointmentBySchedule(TTObjectContext objectContext, Guid SCHEDULE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].QueryDefs["GetAppointmentBySchedule"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SCHEDULE", SCHEDULE);

            return TTReportNqlObject.QueryObjects<Appointment.GetAppointmentBySchedule_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Appointment> GetByEpisodeActionAndState(TTObjectContext objectContext, string EPISODEACTION, string STATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].QueryDefs["GetByEpisodeActionAndState"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEACTION", EPISODEACTION);
            paramList.Add("STATE", STATE);

            return ((ITTQuery)objectContext).QueryObjects<Appointment>(queryDef, paramList);
        }

        public static BindingList<Appointment> GetAppointmentByDatePatient(TTObjectContext objectContext, DateTime APPENDDATE, DateTime APPSTARTDATE, Guid PATIENT)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].QueryDefs["GetAppointmentByDatePatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("APPENDDATE", APPENDDATE);
            paramList.Add("APPSTARTDATE", APPSTARTDATE);
            paramList.Add("PATIENT", PATIENT);

            return ((ITTQuery)objectContext).QueryObjects<Appointment>(queryDef, paramList);
        }

        public static BindingList<Appointment> GetByMHRSApp(TTObjectContext objectContext, Guid ACTION, DateTime APPSTARTDATE, DateTime APPENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].QueryDefs["GetByMHRSApp"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ACTION", ACTION);
            paramList.Add("APPSTARTDATE", APPSTARTDATE);
            paramList.Add("APPENDDATE", APPENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<Appointment>(queryDef, paramList);
        }

        public static BindingList<Appointment.VEM_RANDEVU_Class> VEM_RANDEVU(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].QueryDefs["VEM_RANDEVU"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Appointment.VEM_RANDEVU_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Appointment.VEM_RANDEVU_Class> VEM_RANDEVU(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].QueryDefs["VEM_RANDEVU"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Appointment.VEM_RANDEVU_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Appointment> GetByPatientAndDate(TTObjectContext objectContext, DateTime APPSTARTDATE, DateTime APPENDDATE, string Patient)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].QueryDefs["GetByPatientAndDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("APPSTARTDATE", APPSTARTDATE);
            paramList.Add("APPENDDATE", APPENDDATE);
            paramList.Add("PATIENT", Patient);

            return ((ITTQuery)objectContext).QueryObjects<Appointment>(queryDef, paramList);
        }

        public static BindingList<Appointment> GetPatientComeToMHRSApp(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].QueryDefs["GetPatientComeToMHRSApp"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<Appointment>(queryDef, paramList);
        }

        public static BindingList<Appointment.GetMHRSAppointmentTimeIsPast_Class> GetMHRSAppointmentTimeIsPast(DateTime STARTTIME, DateTime ENDTIME, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].QueryDefs["GetMHRSAppointmentTimeIsPast"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTTIME", STARTTIME);
            paramList.Add("ENDTIME", ENDTIME);

            return TTReportNqlObject.QueryObjects<Appointment.GetMHRSAppointmentTimeIsPast_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Appointment.GetMHRSAppointmentTimeIsPast_Class> GetMHRSAppointmentTimeIsPast(TTObjectContext objectContext, DateTime STARTTIME, DateTime ENDTIME, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].QueryDefs["GetMHRSAppointmentTimeIsPast"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTTIME", STARTTIME);
            paramList.Add("ENDTIME", ENDTIME);

            return TTReportNqlObject.QueryObjects<Appointment.GetMHRSAppointmentTimeIsPast_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Appointment> GetPatientAdmissionAppointmentsByID(TTObjectContext objectContext, DateTime APPENDDATE, DateTime APPSTARTDATE, Guid OBJECTID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].QueryDefs["GetPatientAdmissionAppointmentsByID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("APPENDDATE", APPENDDATE);
            paramList.Add("APPSTARTDATE", APPSTARTDATE);
            paramList.Add("OBJECTID", OBJECTID);

            return ((ITTQuery)objectContext).QueryObjects<Appointment>(queryDef, paramList);
        }

        public static BindingList<Appointment.GetPatientAppointmentByID_Class> GetPatientAppointmentByID(Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].QueryDefs["GetPatientAppointmentByID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<Appointment.GetPatientAppointmentByID_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Appointment.GetPatientAppointmentByID_Class> GetPatientAppointmentByID(TTObjectContext objectContext, Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].QueryDefs["GetPatientAppointmentByID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<Appointment.GetPatientAppointmentByID_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Appointment.GetAppointmentByDateAndPatient_Class> GetAppointmentByDateAndPatient(Guid PATIENT, DateTime APPSTARTDATE, DateTime APPENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].QueryDefs["GetAppointmentByDateAndPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);
            paramList.Add("APPSTARTDATE", APPSTARTDATE);
            paramList.Add("APPENDDATE", APPENDDATE);

            return TTReportNqlObject.QueryObjects<Appointment.GetAppointmentByDateAndPatient_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Appointment.GetAppointmentByDateAndPatient_Class> GetAppointmentByDateAndPatient(TTObjectContext objectContext, Guid PATIENT, DateTime APPSTARTDATE, DateTime APPENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].QueryDefs["GetAppointmentByDateAndPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);
            paramList.Add("APPSTARTDATE", APPSTARTDATE);
            paramList.Add("APPENDDATE", APPENDDATE);

            return TTReportNqlObject.QueryObjects<Appointment.GetAppointmentByDateAndPatient_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Appointment> GetPatientAdmissionAppointmentsByDate(TTObjectContext objectContext, Guid PATIENT, DateTime APPSTARTDATE, DateTime APPENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].QueryDefs["GetPatientAdmissionAppointmentsByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);
            paramList.Add("APPSTARTDATE", APPSTARTDATE);
            paramList.Add("APPENDDATE", APPENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<Appointment>(queryDef, paramList);
        }

        public static BindingList<Appointment> GetByAppDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].QueryDefs["GetByAppDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<Appointment>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<Appointment.GetUserAppointmentsByDateTime_Class> GetUserAppointmentsByDateTime(DateTime STARTTIME, DateTime ENDTIME, Guid USER, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].QueryDefs["GetUserAppointmentsByDateTime"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTTIME", STARTTIME);
            paramList.Add("ENDTIME", ENDTIME);
            paramList.Add("USER", USER);

            return TTReportNqlObject.QueryObjects<Appointment.GetUserAppointmentsByDateTime_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Appointment.GetUserAppointmentsByDateTime_Class> GetUserAppointmentsByDateTime(TTObjectContext objectContext, DateTime STARTTIME, DateTime ENDTIME, Guid USER, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].QueryDefs["GetUserAppointmentsByDateTime"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTTIME", STARTTIME);
            paramList.Add("ENDTIME", ENDTIME);
            paramList.Add("USER", USER);

            return TTReportNqlObject.QueryObjects<Appointment.GetUserAppointmentsByDateTime_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Appointment> GetBySubActionProcedureId(TTObjectContext objectContext, Guid SUBACTIONPROCEDURE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].QueryDefs["GetBySubActionProcedureId"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBACTIONPROCEDURE", SUBACTIONPROCEDURE);

            return ((ITTQuery)objectContext).QueryObjects<Appointment>(queryDef, paramList);
        }

        public static BindingList<Appointment> GetActiveMHRSAppointmentsByDate(TTObjectContext objectContext, DateTime APPDATE, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["APPOINTMENT"].QueryDefs["GetActiveMHRSAppointmentsByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("APPDATE", APPDATE);

            return ((ITTQuery)objectContext).QueryObjects<Appointment>(queryDef, paramList, injectionSQL);
        }

    /// <summary>
    /// Appointmentın verildiği StateId
    /// </summary>
        public string StateID
        {
            get { return (string)this["STATEID"]; }
            set { this["STATEID"] = value; }
        }

    /// <summary>
    /// Referans Numarası
    /// </summary>
        public TTSequence AppointmentID
        {
            get { return GetSequence("APPOINTMENTID"); }
        }

        public string Notes
        {
            get { return (string)this["NOTES"]; }
            set { this["NOTES"] = value; }
        }

    /// <summary>
    /// Bitiş Tarihi
    /// </summary>
        public DateTime? EndTime
        {
            get { return (DateTime?)this["ENDTIME"]; }
            set { this["ENDTIME"] = value; }
        }

    /// <summary>
    /// Başlangıç Saati
    /// </summary>
        public DateTime? StartTime
        {
            get { return (DateTime?)this["STARTTIME"]; }
            set { this["STARTTIME"] = value; }
        }

    /// <summary>
    /// Randevu Tarihi
    /// </summary>
        public DateTime? AppDate
        {
            get { return (DateTime?)this["APPDATE"]; }
            set { this["APPDATE"] = value; }
        }

    /// <summary>
    /// Saatsiz Randevu
    /// </summary>
        public bool? BreakAppointment
        {
            get { return (bool?)this["BREAKAPPOINTMENT"]; }
            set { this["BREAKAPPOINTMENT"] = value; }
        }

        public AppointmentTypeEnum? AppointmentType
        {
            get { return (AppointmentTypeEnum?)(int?)this["APPOINTMENTTYPE"]; }
            set { this["APPOINTMENTTYPE"] = value; }
        }

    /// <summary>
    /// Veriş Tipi
    /// </summary>
        public bool? GivingType
        {
            get { return (bool?)this["GIVINGTYPE"]; }
            set { this["GIVINGTYPE"] = value; }
        }

    /// <summary>
    /// Numaratör
    /// </summary>
        public bool? IsNumarator
        {
            get { return (bool?)this["ISNUMARATOR"]; }
            set { this["ISNUMARATOR"] = value; }
        }

    /// <summary>
    /// MHRS Randevu No
    /// </summary>
        public string MHRSRandevuHrn
        {
            get { return (string)this["MHRSRANDEVUHRN"]; }
            set { this["MHRSRANDEVUHRN"] = value; }
        }

    /// <summary>
    /// Hekimin İstisnası Onaylandığı için İptal
    /// </summary>
        public bool? IsCancelledByMHRSIstisna
        {
            get { return (bool?)this["ISCANCELLEDBYMHRSISTISNA"]; }
            set { this["ISCANCELLEDBYMHRSISTISNA"] = value; }
        }

    /// <summary>
    /// Randevu Güncelleme
    /// </summary>
        public bool? AppointmentUpdate
        {
            get { return (bool?)this["APPOINTMENTUPDATE"]; }
            set { this["APPOINTMENTUPDATE"] = value; }
        }

    /// <summary>
    /// MHRS Hasta Geldi
    /// </summary>
        public bool? MHRSHastaGeldi
        {
            get { return (bool?)this["MHRSHASTAGELDI"]; }
            set { this["MHRSHASTAGELDI"] = value; }
        }

    /// <summary>
    /// MHRS tarafından iptal edilmiş randevular
    /// </summary>
        public bool? CancelledMHRS
        {
            get { return (bool?)this["CANCELLEDMHRS"]; }
            set { this["CANCELLEDMHRS"] = value; }
        }

    /// <summary>
    /// Randevu Görüntüleme Ekranı Durumu
    /// </summary>
        public string AppViewerState
        {
            get { return (string)this["APPVIEWERSTATE"]; }
            set { this["APPVIEWERSTATE"] = value; }
        }

    /// <summary>
    /// Kabul randevusuna döndüğünde ilk istenen işlemin nesne ID'sini saklar
    /// </summary>
        public string InitialObjectID
        {
            get { return (string)this["INITIALOBJECTID"]; }
            set { this["INITIALOBJECTID"] = value; }
        }

    /// <summary>
    /// Dış firmadan verilen randevunun unique ID sini tutar.
    /// </summary>
        public string ExternalAppointmentID
        {
            get { return (string)this["EXTERNALAPPOINTMENTID"]; }
            set { this["EXTERNALAPPOINTMENTID"] = value; }
        }

        public SubActionProcedure SubActionProcedure
        {
            get { return (SubActionProcedure)((ITTObject)this).GetParent("SUBACTIONPROCEDURE"); }
            set { this["SUBACTIONPROCEDURE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public AppointmentDefinition AppointmentDefinition
        {
            get { return (AppointmentDefinition)((ITTObject)this).GetParent("APPOINTMENTDEFINITION"); }
            set { this["APPOINTMENTDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public AppointmentCarrier AppointmentCarrier
        {
            get { return (AppointmentCarrier)((ITTObject)this).GetParent("APPOINTMENTCARRIER"); }
            set { this["APPOINTMENTCARRIER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public BaseAction Action
        {
            get { return (BaseAction)((ITTObject)this).GetParent("ACTION"); }
            set { this["ACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Resource MasterResource
        {
            get { return (Resource)((ITTObject)this).GetParent("MASTERRESOURCE"); }
            set { this["MASTERRESOURCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Appointment MasterAppointments
        {
            get { return (Appointment)((ITTObject)this).GetParent("MASTERAPPOINTMENTS"); }
            set { this["MASTERAPPOINTMENTS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Schedule Schedule
        {
            get { return (Schedule)((ITTObject)this).GetParent("SCHEDULE"); }
            set { this["SCHEDULE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResUser GivenBy
        {
            get { return (ResUser)((ITTObject)this).GetParent("GIVENBY"); }
            set { this["GIVENBY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Hasta
    /// </summary>
        public Patient Patient
        {
            get { return (Patient)((ITTObject)this).GetParent("PATIENT"); }
            set { this["PATIENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Resource Resource
        {
            get { return (Resource)((ITTObject)this).GetParent("RESOURCE"); }
            set { this["RESOURCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Numaratör sistemi için kullanılan appointmentlar ile  ilgili Episode Action bağlantısı
    /// </summary>
        public EpisodeAction EpisodeAction
        {
            get { return (EpisodeAction)((ITTObject)this).GetParent("EPISODEACTION"); }
            set { this["EPISODEACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Cihaz Bakım Entegrasyonu için kullanılacak.
    /// </summary>
        public ResEquipmentAppointment ResEquipmentAppointment
        {
            get { return (ResEquipmentAppointment)((ITTObject)this).GetParent("RESEQUIPMENTAPPOINTMENT"); }
            set { this["RESEQUIPMENTAPPOINTMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateChildAppointmentsCollection()
        {
            _ChildAppointments = new Appointment.ChildAppointmentCollection(this, new Guid("0150f39d-fd6e-442a-9d06-85d013cf5276"));
            ((ITTChildObjectCollection)_ChildAppointments).GetChildren();
        }

        protected Appointment.ChildAppointmentCollection _ChildAppointments = null;
        public Appointment.ChildAppointmentCollection ChildAppointments
        {
            get
            {
                if (_ChildAppointments == null)
                    CreateChildAppointmentsCollection();
                return _ChildAppointments;
            }
        }

        virtual protected void CreateExaminationQueueHistoryCollection()
        {
            _ExaminationQueueHistory = new ExaminationQueueHistory.ChildExaminationQueueHistoryCollection(this, new Guid("af7fcd8e-fc35-400a-a5ff-4761df8a28de"));
            ((ITTChildObjectCollection)_ExaminationQueueHistory).GetChildren();
        }

        protected ExaminationQueueHistory.ChildExaminationQueueHistoryCollection _ExaminationQueueHistory = null;
        public ExaminationQueueHistory.ChildExaminationQueueHistoryCollection ExaminationQueueHistory
        {
            get
            {
                if (_ExaminationQueueHistory == null)
                    CreateExaminationQueueHistoryCollection();
                return _ExaminationQueueHistory;
            }
        }

        virtual protected void CreateExaminationQueueItemCollection()
        {
            _ExaminationQueueItem = new ExaminationQueueItem.ChildExaminationQueueItemCollection(this, new Guid("2e57d5e6-c56b-48eb-ac46-a5be98267c1d"));
            ((ITTChildObjectCollection)_ExaminationQueueItem).GetChildren();
        }

        protected ExaminationQueueItem.ChildExaminationQueueItemCollection _ExaminationQueueItem = null;
        public ExaminationQueueItem.ChildExaminationQueueItemCollection ExaminationQueueItem
        {
            get
            {
                if (_ExaminationQueueItem == null)
                    CreateExaminationQueueItemCollection();
                return _ExaminationQueueItem;
            }
        }

        protected Appointment(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected Appointment(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected Appointment(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected Appointment(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected Appointment(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "APPOINTMENT", dataRow) { }
        protected Appointment(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "APPOINTMENT", dataRow, isImported) { }
        public Appointment(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public Appointment(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public Appointment() : base() { }

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