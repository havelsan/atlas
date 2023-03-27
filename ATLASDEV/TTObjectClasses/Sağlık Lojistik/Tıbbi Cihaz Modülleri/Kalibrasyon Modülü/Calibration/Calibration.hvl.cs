
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="Calibration")] 

    /// <summary>
    /// Kalibrasyon
    /// </summary>
    public  partial class Calibration : CMRAction
    {
        public class CalibrationList : TTObjectCollection<Calibration> { }
                    
        public class ChildCalibrationCollection : TTObject.TTChildObjectCollection<Calibration>
        {
            public ChildCalibrationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCalibrationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class CalibrationCertificateNQL_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["REASONOFCANCEL"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["ACTIVE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["WORKLISTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["REASONOFREJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["OLAPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["WORKLISTDESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["ISOLDACTION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Result
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["RESULT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? StartDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STARTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["STARTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? EndDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["ENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string RequestNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["REQUESTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? RequestNoSeq
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTNOSEQ"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["REQUESTNOSEQ"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string MaintenanceOrderObjectID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MAINTENANCEORDEROBJECTID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["MAINTENANCEORDEROBJECTID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public int? HumidityDeviation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HUMIDITYDEVIATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["HUMIDITYDEVIATION"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string CertificateDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CERTIFICATEDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["CERTIFICATEDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string AvailablityAnnounce
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AVAILABLITYANNOUNCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["AVAILABLITYANNOUNCE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? RelativeHumidity
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RELATIVEHUMIDITY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["RELATIVEHUMIDITY"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string NotCalibreReasonDesc
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTCALIBREREASONDESC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["NOTCALIBREREASONDESC"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? NotCalibreReason3
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTCALIBREREASON3"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["NOTCALIBREREASON3"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? NotCalibreReason4
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTCALIBREREASON4"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["NOTCALIBREREASON4"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? NotCalibreReason5
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTCALIBREREASON5"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["NOTCALIBREREASON5"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? DeliveryToFirmDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DELIVERYTOFIRMDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["DELIVERYTOFIRMDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ReceiveDateFromFirm
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RECEIVEDATEFROMFIRM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["RECEIVEDATEFROMFIRM"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string DetailDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DETAILDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["DETAILDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string PreControlNotes
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRECONTROLNOTES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["PRECONTROLNOTES"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string PlaceOfCalibrationLabel
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PLACEOFCALIBRATIONLABEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["PLACEOFCALIBRATIONLABEL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string CalibrationStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CALIBRATIONSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["CALIBRATIONSTATUS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? Temperature
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TEMPERATURE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["TEMPERATURE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public bool? NotCalibration
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTCALIBRATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["NOTCALIBRATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public int? TemperatureDeviation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TEMPERATUREDEVIATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["TEMPERATUREDEVIATION"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string CalibrationUncertainty
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CALIBRATIONUNCERTAINTY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["CALIBRATIONUNCERTAINTY"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string RULObjectID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RULOBJECTID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["RULOBJECTID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? NotCalibreReason1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTCALIBREREASON1"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["NOTCALIBREREASON1"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? NotCalibreReason2
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTCALIBREREASON2"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["NOTCALIBREREASON2"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string TechniqueAndProcedure
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TECHNIQUEANDPROCEDURE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["TECHNIQUEANDPROCEDURE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? FullCalibration
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FULLCALIBRATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["FULLCALIBRATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? NoNeedCalibration
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NONEEDCALIBRATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["NONEEDCALIBRATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? LimitedCalibration
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LIMITEDCALIBRATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["LIMITEDCALIBRATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? CalibrationPeriod
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CALIBRATIONPERIOD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDEFINITION"].AllPropertyDefs["CALIBRATIONPERIOD"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string Mark
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MARK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["MARK"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Model
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MODEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["MODEL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string SerialNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SERIALNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["SERIALNUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string FixedAssetNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FIXEDASSETNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["FIXEDASSETNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Labrespname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LABRESPNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Sectionname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SECTIONNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESDIVISIONSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Workshopname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKSHOPNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESDIVISIONSUBSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Respworkshopuser
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESPWORKSHOPUSER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Stagemilitaryunit
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STAGEMILITARYUNIT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MILITARYUNIT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Sendersection
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SENDERSECTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public CalibrationCertificateNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public CalibrationCertificateNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected CalibrationCertificateNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class GetNotCalibratedReportQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Materialname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string SerialNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SERIALNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["SERIALNUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string NATOStockNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NATOSTOCKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NATOSTOCKNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Model
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MODEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["MODEL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Militaryunit
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MILITARYUNIT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MILITARYUNIT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? NotCalibreReason1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTCALIBREREASON1"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["NOTCALIBREREASON1"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? NotCalibreReason2
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTCALIBREREASON2"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["NOTCALIBREREASON2"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? NotCalibreReason3
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTCALIBREREASON3"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["NOTCALIBREREASON3"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? NotCalibreReason4
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTCALIBREREASON4"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["NOTCALIBREREASON4"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? NotCalibreReason5
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTCALIBREREASON5"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["NOTCALIBREREASON5"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string NotCalibreReasonDesc
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTCALIBREREASONDESC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["NOTCALIBREREASONDESC"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetNotCalibratedReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetNotCalibratedReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetNotCalibratedReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class CalibrationReportQuery_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["REASONOFCANCEL"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["ACTIVE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["WORKLISTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["REASONOFREJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["OLAPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["WORKLISTDESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["ISOLDACTION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Result
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["RESULT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? StartDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STARTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["STARTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? EndDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["ENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string RequestNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["REQUESTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? RequestNoSeq
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTNOSEQ"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["REQUESTNOSEQ"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string MaintenanceOrderObjectID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MAINTENANCEORDEROBJECTID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["MAINTENANCEORDEROBJECTID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public int? HumidityDeviation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HUMIDITYDEVIATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["HUMIDITYDEVIATION"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string CertificateDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CERTIFICATEDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["CERTIFICATEDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string AvailablityAnnounce
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AVAILABLITYANNOUNCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["AVAILABLITYANNOUNCE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? RelativeHumidity
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RELATIVEHUMIDITY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["RELATIVEHUMIDITY"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string NotCalibreReasonDesc
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTCALIBREREASONDESC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["NOTCALIBREREASONDESC"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? NotCalibreReason3
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTCALIBREREASON3"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["NOTCALIBREREASON3"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? NotCalibreReason4
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTCALIBREREASON4"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["NOTCALIBREREASON4"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? NotCalibreReason5
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTCALIBREREASON5"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["NOTCALIBREREASON5"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? DeliveryToFirmDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DELIVERYTOFIRMDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["DELIVERYTOFIRMDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ReceiveDateFromFirm
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RECEIVEDATEFROMFIRM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["RECEIVEDATEFROMFIRM"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string DetailDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DETAILDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["DETAILDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string PreControlNotes
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRECONTROLNOTES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["PRECONTROLNOTES"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string PlaceOfCalibrationLabel
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PLACEOFCALIBRATIONLABEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["PLACEOFCALIBRATIONLABEL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string CalibrationStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CALIBRATIONSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["CALIBRATIONSTATUS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? Temperature
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TEMPERATURE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["TEMPERATURE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public bool? NotCalibration
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTCALIBRATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["NOTCALIBRATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public int? TemperatureDeviation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TEMPERATUREDEVIATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["TEMPERATUREDEVIATION"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string CalibrationUncertainty
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CALIBRATIONUNCERTAINTY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["CALIBRATIONUNCERTAINTY"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string RULObjectID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RULOBJECTID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["RULOBJECTID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? NotCalibreReason1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTCALIBREREASON1"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["NOTCALIBREREASON1"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? NotCalibreReason2
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTCALIBREREASON2"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["NOTCALIBREREASON2"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string TechniqueAndProcedure
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TECHNIQUEANDPROCEDURE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["TECHNIQUEANDPROCEDURE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? FullCalibration
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FULLCALIBRATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["FULLCALIBRATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? NoNeedCalibration
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NONEEDCALIBRATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["NONEEDCALIBRATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? LimitedCalibration
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LIMITEDCALIBRATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].AllPropertyDefs["LIMITEDCALIBRATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public CalibrationReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public CalibrationReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected CalibrationReportQuery_Class() : base() { }
        }

        new public static class States
        {
    /// <summary>
    /// Kalibrasyon
    /// </summary>
            public static Guid Calibration { get { return new Guid("423b16a7-83ad-4b8c-841a-4b085a5f45f3"); } }
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("05fdc23d-1bd6-4ee9-b4b1-a04217f96f24"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("5f95a755-33ee-478c-ac26-af6e5b74a44d"); } }
    /// <summary>
    /// Hizmet Alımı
    /// </summary>
            public static Guid FirmCalibration { get { return new Guid("674234ad-4403-4a7e-a9a6-409f869812ec"); } }
    /// <summary>
    /// Amir Onayı
    /// </summary>
            public static Guid ChiefApproval { get { return new Guid("4423ba4d-df63-4ce4-820b-8e88d2fe2471"); } }
    /// <summary>
    /// İstek Onay
    /// </summary>
            public static Guid ForkNew { get { return new Guid("ff1384ce-bd9e-411b-9883-ca11411959b5"); } }
    /// <summary>
    /// Onarıma Gönderildi
    /// </summary>
            public static Guid ToRepair { get { return new Guid("10002ef5-6715-4755-b7f6-81ca432d09bc"); } }
    /// <summary>
    /// Malzeme Temin
    /// </summary>
            public static Guid SupplyOfMaterials { get { return new Guid("ae5f5cc7-fcaf-4c40-bd0e-b0c35e5e793f"); } }
        }

        public static BindingList<Calibration.CalibrationCertificateNQL_Class> CalibrationCertificateNQL(string TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].QueryDefs["CalibrationCertificateNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<Calibration.CalibrationCertificateNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Calibration.CalibrationCertificateNQL_Class> CalibrationCertificateNQL(TTObjectContext objectContext, string TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].QueryDefs["CalibrationCertificateNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<Calibration.CalibrationCertificateNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Calibration.GetNotCalibratedReportQuery_Class> GetNotCalibratedReportQuery(Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].QueryDefs["GetNotCalibratedReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<Calibration.GetNotCalibratedReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Calibration.GetNotCalibratedReportQuery_Class> GetNotCalibratedReportQuery(TTObjectContext objectContext, Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].QueryDefs["GetNotCalibratedReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<Calibration.GetNotCalibratedReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Calibration> GetCalibrationStateByMaintenanceOrderObjectID(TTObjectContext objectContext, string MAINTENANCEORDEROBJECTID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].QueryDefs["GetCalibrationStateByMaintenanceOrderObjectID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MAINTENANCEORDEROBJECTID", MAINTENANCEORDEROBJECTID);

            return ((ITTQuery)objectContext).QueryObjects<Calibration>(queryDef, paramList);
        }

        public static BindingList<Calibration.CalibrationReportQuery_Class> CalibrationReportQuery(DateTime ENDDATE, DateTime STARTDATE, Guid PERSONNEL, int PERSONNELFLAG, Guid STORE, int STOREFLAG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].QueryDefs["CalibrationReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("PERSONNEL", PERSONNEL);
            paramList.Add("PERSONNELFLAG", PERSONNELFLAG);
            paramList.Add("STORE", STORE);
            paramList.Add("STOREFLAG", STOREFLAG);

            return TTReportNqlObject.QueryObjects<Calibration.CalibrationReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Calibration.CalibrationReportQuery_Class> CalibrationReportQuery(TTObjectContext objectContext, DateTime ENDDATE, DateTime STARTDATE, Guid PERSONNEL, int PERSONNELFLAG, Guid STORE, int STOREFLAG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].QueryDefs["CalibrationReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("PERSONNEL", PERSONNEL);
            paramList.Add("PERSONNELFLAG", PERSONNELFLAG);
            paramList.Add("STORE", STORE);
            paramList.Add("STOREFLAG", STOREFLAG);

            return TTReportNqlObject.QueryObjects<Calibration.CalibrationReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Calibration> CalibrationObjectQuery(TTObjectContext objectContext, int DATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].QueryDefs["CalibrationObjectQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DATE", DATE);

            return ((ITTQuery)objectContext).QueryObjects<Calibration>(queryDef, paramList);
        }

        public static BindingList<Calibration> GetCalibrationCount(TTObjectContext objectContext, DateTime STARDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CALIBRATION"].QueryDefs["GetCalibrationCount"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARDATE", STARDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<Calibration>(queryDef, paramList);
        }

    /// <summary>
    /// Bakım Md.Sipariş ID
    /// </summary>
        public string MaintenanceOrderObjectID
        {
            get { return (string)this["MAINTENANCEORDEROBJECTID"]; }
            set { this["MAINTENANCEORDEROBJECTID"] = value; }
        }

    /// <summary>
    /// İstek Tarihi
    /// </summary>
        public DateTime? RequestDate
        {
            get { return (DateTime?)this["REQUESTDATE"]; }
            set { this["REQUESTDATE"] = value; }
        }

    /// <summary>
    /// Bağıl Nem Sapması
    /// </summary>
        public int? HumidityDeviation
        {
            get { return (int?)this["HUMIDITYDEVIATION"]; }
            set { this["HUMIDITYDEVIATION"] = value; }
        }

    /// <summary>
    /// Açıklamalar
    /// </summary>
        public string CertificateDescription
        {
            get { return (string)this["CERTIFICATEDESCRIPTION"]; }
            set { this["CERTIFICATEDESCRIPTION"] = value; }
        }

    /// <summary>
    /// Uygunluk Beyanı
    /// </summary>
        public string AvailablityAnnounce
        {
            get { return (string)this["AVAILABLITYANNOUNCE"]; }
            set { this["AVAILABLITYANNOUNCE"] = value; }
        }

    /// <summary>
    /// Bağıl Nem
    /// </summary>
        public double? RelativeHumidity
        {
            get { return (double?)this["RELATIVEHUMIDITY"]; }
            set { this["RELATIVEHUMIDITY"] = value; }
        }

    /// <summary>
    /// Açıklama ve Öneriler
    /// </summary>
        public string NotCalibreReasonDesc
        {
            get { return (string)this["NOTCALIBREREASONDESC"]; }
            set { this["NOTCALIBREREASONDESC"] = value; }
        }

    /// <summary>
    /// Neden 3
    /// </summary>
        public bool? NotCalibreReason3
        {
            get { return (bool?)this["NOTCALIBREREASON3"]; }
            set { this["NOTCALIBREREASON3"] = value; }
        }

    /// <summary>
    /// Neden 4
    /// </summary>
        public bool? NotCalibreReason4
        {
            get { return (bool?)this["NOTCALIBREREASON4"]; }
            set { this["NOTCALIBREREASON4"] = value; }
        }

    /// <summary>
    /// Neden 5
    /// </summary>
        public bool? NotCalibreReason5
        {
            get { return (bool?)this["NOTCALIBREREASON5"]; }
            set { this["NOTCALIBREREASON5"] = value; }
        }

    /// <summary>
    /// Firmaya Teslim Tarihi
    /// </summary>
        public DateTime? DeliveryToFirmDate
        {
            get { return (DateTime?)this["DELIVERYTOFIRMDATE"]; }
            set { this["DELIVERYTOFIRMDATE"] = value; }
        }

    /// <summary>
    /// Firmadan Tesellüm Tarihi
    /// </summary>
        public DateTime? ReceiveDateFromFirm
        {
            get { return (DateTime?)this["RECEIVEDATEFROMFIRM"]; }
            set { this["RECEIVEDATEFROMFIRM"] = value; }
        }

    /// <summary>
    /// Hizmet Alım Açıklaması
    /// </summary>
        public string DetailDescription
        {
            get { return (string)this["DETAILDESCRIPTION"]; }
            set { this["DETAILDESCRIPTION"] = value; }
        }

    /// <summary>
    /// Ön Kontrol Notları
    /// </summary>
        public string PreControlNotes
        {
            get { return (string)this["PRECONTROLNOTES"]; }
            set { this["PRECONTROLNOTES"] = value; }
        }

    /// <summary>
    /// Kalibrasyon Etiketinin Yeri
    /// </summary>
        public string PlaceOfCalibrationLabel
        {
            get { return (string)this["PLACEOFCALIBRATIONLABEL"]; }
            set { this["PLACEOFCALIBRATIONLABEL"] = value; }
        }

    /// <summary>
    /// Cihazın Kalibrasyon Durumu
    /// </summary>
        public string CalibrationStatus
        {
            get { return (string)this["CALIBRATIONSTATUS"]; }
            set { this["CALIBRATIONSTATUS"] = value; }
        }

    /// <summary>
    /// Sıcaklık
    /// </summary>
        public double? Temperature
        {
            get { return (double?)this["TEMPERATURE"]; }
            set { this["TEMPERATURE"] = value; }
        }

    /// <summary>
    /// Kalibrasyon Yapılamadı
    /// </summary>
        public bool? NotCalibration
        {
            get { return (bool?)this["NOTCALIBRATION"]; }
            set { this["NOTCALIBRATION"] = value; }
        }

    /// <summary>
    /// Sıcaklık Sapması
    /// </summary>
        public int? TemperatureDeviation
        {
            get { return (int?)this["TEMPERATUREDEVIATION"]; }
            set { this["TEMPERATUREDEVIATION"] = value; }
        }

    /// <summary>
    /// Kalibrasyon Belirsizliği
    /// </summary>
        public string CalibrationUncertainty
        {
            get { return (string)this["CALIBRATIONUNCERTAINTY"]; }
            set { this["CALIBRATIONUNCERTAINTY"] = value; }
        }

        public string RULObjectID
        {
            get { return (string)this["RULOBJECTID"]; }
            set { this["RULOBJECTID"] = value; }
        }

    /// <summary>
    /// Neden 1
    /// </summary>
        public bool? NotCalibreReason1
        {
            get { return (bool?)this["NOTCALIBREREASON1"]; }
            set { this["NOTCALIBREREASON1"] = value; }
        }

    /// <summary>
    /// Neden 2
    /// </summary>
        public bool? NotCalibreReason2
        {
            get { return (bool?)this["NOTCALIBREREASON2"]; }
            set { this["NOTCALIBREREASON2"] = value; }
        }

    /// <summary>
    /// Yöntem ve Prosedür
    /// </summary>
        public string TechniqueAndProcedure
        {
            get { return (string)this["TECHNIQUEANDPROCEDURE"]; }
            set { this["TECHNIQUEANDPROCEDURE"] = value; }
        }

    /// <summary>
    /// Tam Kalibrasyon
    /// </summary>
        public bool? FullCalibration
        {
            get { return (bool?)this["FULLCALIBRATION"]; }
            set { this["FULLCALIBRATION"] = value; }
        }

    /// <summary>
    /// Peryodik Kalibrasyon Gerektirmez
    /// </summary>
        public bool? NoNeedCalibration
        {
            get { return (bool?)this["NONEEDCALIBRATION"]; }
            set { this["NONEEDCALIBRATION"] = value; }
        }

    /// <summary>
    /// Sınırlı Kalibrasyon
    /// </summary>
        public bool? LimitedCalibration
        {
            get { return (bool?)this["LIMITEDCALIBRATION"]; }
            set { this["LIMITEDCALIBRATION"] = value; }
        }

        public ResUser LabResponsible
        {
            get { return (ResUser)((ITTObject)this).GetParent("LABRESPONSIBLE"); }
            set { this["LABRESPONSIBLE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Supplier Supplier
        {
            get { return (Supplier)((ITTObject)this).GetParent("SUPPLIER"); }
            set { this["SUPPLIER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateCalibratorFixedAssetMaterialsCollection()
        {
            _CalibratorFixedAssetMaterials = new CalibratorFixedAssetMaterial.ChildCalibratorFixedAssetMaterialCollection(this, new Guid("fa45af9f-705a-469a-824a-45f3ed1a19e9"));
            ((ITTChildObjectCollection)_CalibratorFixedAssetMaterials).GetChildren();
        }

        protected CalibratorFixedAssetMaterial.ChildCalibratorFixedAssetMaterialCollection _CalibratorFixedAssetMaterials = null;
        public CalibratorFixedAssetMaterial.ChildCalibratorFixedAssetMaterialCollection CalibratorFixedAssetMaterials
        {
            get
            {
                if (_CalibratorFixedAssetMaterials == null)
                    CreateCalibratorFixedAssetMaterialsCollection();
                return _CalibratorFixedAssetMaterials;
            }
        }

        virtual protected void CreateCalibration_ItemEquipmentsCollection()
        {
            _Calibration_ItemEquipments = new Calibration_ItemEquipment.ChildCalibration_ItemEquipmentCollection(this, new Guid("0d45f2cd-8fb5-411b-a0c7-a8a0fbd2d93e"));
            ((ITTChildObjectCollection)_Calibration_ItemEquipments).GetChildren();
        }

        protected Calibration_ItemEquipment.ChildCalibration_ItemEquipmentCollection _Calibration_ItemEquipments = null;
        public Calibration_ItemEquipment.ChildCalibration_ItemEquipmentCollection Calibration_ItemEquipments
        {
            get
            {
                if (_Calibration_ItemEquipments == null)
                    CreateCalibration_ItemEquipmentsCollection();
                return _Calibration_ItemEquipments;
            }
        }

        virtual protected void CreateCalibrationTestsCollection()
        {
            _CalibrationTests = new CalibrationTest.ChildCalibrationTestCollection(this, new Guid("c15a28f1-b099-40be-b8e9-8a8f21b1a4b4"));
            ((ITTChildObjectCollection)_CalibrationTests).GetChildren();
        }

        protected CalibrationTest.ChildCalibrationTestCollection _CalibrationTests = null;
        public CalibrationTest.ChildCalibrationTestCollection CalibrationTests
        {
            get
            {
                if (_CalibrationTests == null)
                    CreateCalibrationTestsCollection();
                return _CalibrationTests;
            }
        }

        virtual protected void CreateCalibrationConsumedMaterialsCollection()
        {
            _CalibrationConsumedMaterials = new CalibrationConsumedMat.ChildCalibrationConsumedMatCollection(this, new Guid("c2d8abba-65dd-4bf7-853c-d57a64076b3f"));
            ((ITTChildObjectCollection)_CalibrationConsumedMaterials).GetChildren();
        }

        protected CalibrationConsumedMat.ChildCalibrationConsumedMatCollection _CalibrationConsumedMaterials = null;
        public CalibrationConsumedMat.ChildCalibrationConsumedMatCollection CalibrationConsumedMaterials
        {
            get
            {
                if (_CalibrationConsumedMaterials == null)
                    CreateCalibrationConsumedMaterialsCollection();
                return _CalibrationConsumedMaterials;
            }
        }

        virtual protected void CreateUsedConsumedMaterailsCollection()
        {
            _UsedConsumedMaterails = new UsedConsumedMaterail.ChildUsedConsumedMaterailCollection(this, new Guid("cfc55015-efc7-4990-b063-c987efe0d829"));
            ((ITTChildObjectCollection)_UsedConsumedMaterails).GetChildren();
        }

        protected UsedConsumedMaterail.ChildUsedConsumedMaterailCollection _UsedConsumedMaterails = null;
        public UsedConsumedMaterail.ChildUsedConsumedMaterailCollection UsedConsumedMaterails
        {
            get
            {
                if (_UsedConsumedMaterails == null)
                    CreateUsedConsumedMaterailsCollection();
                return _UsedConsumedMaterails;
            }
        }

        protected Calibration(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected Calibration(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected Calibration(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected Calibration(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected Calibration(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CALIBRATION", dataRow) { }
        protected Calibration(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CALIBRATION", dataRow, isImported) { }
        public Calibration(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public Calibration(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public Calibration() : base() { }

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