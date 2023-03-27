
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MedulaTreatmentReport")] 

    /// <summary>
    /// Medula Tedavi Raporları
    /// </summary>
    public  partial class MedulaTreatmentReport : EpisodeActionWithDiagnosis, IWorkListEpisodeAction
    {
        public class MedulaTreatmentReportList : TTObjectCollection<MedulaTreatmentReport> { }
                    
        public class ChildMedulaTreatmentReportCollection : TTObject.TTChildObjectCollection<MedulaTreatmentReport>
        {
            public ChildMedulaTreatmentReportCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMedulaTreatmentReportCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetFtrMedulaReportInfoByPatient_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public TedaviRaporTuruEnum? Treatmenttype
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TREATMENTTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDULATREATMENTREPORT"].AllPropertyDefs["TEDAVIRAPORTURU"].DataType;
                    return (TedaviRaporTuruEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? Reporttype
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDULATREATMENTREPORT"].AllPropertyDefs["COMMITTEEREPORT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public Guid? Ftrapplicationareadef
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["FTRAPPLICATIONAREADEF"]);
                }
            }

            public int? Sessionlimit
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SESSIONLIMIT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FTRREPORTDETAILGRID"].AllPropertyDefs["NUMBEROFSESSIONS"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string Packageprocedureinfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PACKAGEPROCEDUREINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TEDAVIRAPORIISLEMKODLARI"].AllPropertyDefs["TEDAVIRAPORUISLEMKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Treatmentprocesstype
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TREATMENTPROCESSTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TEDAVITURU"].AllPropertyDefs["TEDAVITURUKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDULATREATMENTREPORT"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public string ReportNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDULATREATMENTREPORT"].AllPropertyDefs["REPORTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? RaporGonderimTarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RAPORGONDERIMTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDULATREATMENTREPORT"].AllPropertyDefs["RAPORGONDERIMTARIHI"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? StartDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STARTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDULATREATMENTREPORT"].AllPropertyDefs["STARTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? EndDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDULATREATMENTREPORT"].AllPropertyDefs["ENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Diagnosecode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIAGNOSECODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetFtrMedulaReportInfoByPatient_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetFtrMedulaReportInfoByPatient_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetFtrMedulaReportInfoByPatient_Class() : base() { }
        }

        [Serializable] 

        public partial class GetEswtMedulaReportInfoByPatient_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public TedaviRaporTuruEnum? Treatmenttype
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TREATMENTTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDULATREATMENTREPORT"].AllPropertyDefs["TEDAVIRAPORTURU"].DataType;
                    return (TedaviRaporTuruEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? Reporttype
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDULATREATMENTREPORT"].AllPropertyDefs["COMMITTEEREPORT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public Guid? Ftrapplicationareadef
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["FTRAPPLICATIONAREADEF"]);
                }
            }

            public int? Sessionlimit
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SESSIONLIMIT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ESWTREPORTDETAILGRID"].AllPropertyDefs["NUMBEROFSESSIONS"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string Packageprocedureinfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PACKAGEPROCEDUREINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TEDAVIRAPORIISLEMKODLARI"].AllPropertyDefs["TEDAVIRAPORUISLEMKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDULATREATMENTREPORT"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public string ReportNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDULATREATMENTREPORT"].AllPropertyDefs["REPORTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? RaporGonderimTarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RAPORGONDERIMTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDULATREATMENTREPORT"].AllPropertyDefs["RAPORGONDERIMTARIHI"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? StartDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STARTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDULATREATMENTREPORT"].AllPropertyDefs["STARTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? EndDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDULATREATMENTREPORT"].AllPropertyDefs["ENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Diagnosecode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIAGNOSECODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetEswtMedulaReportInfoByPatient_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetEswtMedulaReportInfoByPatient_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetEswtMedulaReportInfoByPatient_Class() : base() { }
        }

        [Serializable] 

        public partial class GetFtrReportInfoByPatient_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public TedaviRaporTuruEnum? Treatmenttype
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TREATMENTTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDULATREATMENTREPORT"].AllPropertyDefs["TEDAVIRAPORTURU"].DataType;
                    return (TedaviRaporTuruEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? Reporttype
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDULATREATMENTREPORT"].AllPropertyDefs["COMMITTEEREPORT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public Guid? Ftrapplicationareadef
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["FTRAPPLICATIONAREADEF"]);
                }
            }

            public int? Sessionlimit
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SESSIONLIMIT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FTRREPORTDETAILGRID"].AllPropertyDefs["NUMBEROFSESSIONS"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string Packageprocedureinfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PACKAGEPROCEDUREINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TEDAVIRAPORIISLEMKODLARI"].AllPropertyDefs["TEDAVIRAPORUISLEMKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Treatmentprocesstype
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TREATMENTPROCESSTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TEDAVITURU"].AllPropertyDefs["TEDAVITURUKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDULATREATMENTREPORT"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public string ReportNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDULATREATMENTREPORT"].AllPropertyDefs["REPORTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? RaporGonderimTarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RAPORGONDERIMTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDULATREATMENTREPORT"].AllPropertyDefs["RAPORGONDERIMTARIHI"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? StartDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STARTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDULATREATMENTREPORT"].AllPropertyDefs["STARTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? EndDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDULATREATMENTREPORT"].AllPropertyDefs["ENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Diagnosecode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIAGNOSECODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetFtrReportInfoByPatient_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetFtrReportInfoByPatient_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetFtrReportInfoByPatient_Class() : base() { }
        }

        [Serializable] 

        public partial class GetEswtReportInfoByPatient_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public TedaviRaporTuruEnum? Treatmenttype
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TREATMENTTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDULATREATMENTREPORT"].AllPropertyDefs["TEDAVIRAPORTURU"].DataType;
                    return (TedaviRaporTuruEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? Reporttype
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDULATREATMENTREPORT"].AllPropertyDefs["COMMITTEEREPORT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public Guid? Ftrapplicationareadef
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["FTRAPPLICATIONAREADEF"]);
                }
            }

            public int? Sessionlimit
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SESSIONLIMIT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ESWTREPORTDETAILGRID"].AllPropertyDefs["NUMBEROFSESSIONS"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string Packageprocedureinfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PACKAGEPROCEDUREINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TEDAVIRAPORIISLEMKODLARI"].AllPropertyDefs["TEDAVIRAPORUISLEMKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDULATREATMENTREPORT"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public string ReportNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDULATREATMENTREPORT"].AllPropertyDefs["REPORTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? RaporGonderimTarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RAPORGONDERIMTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDULATREATMENTREPORT"].AllPropertyDefs["RAPORGONDERIMTARIHI"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? StartDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STARTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDULATREATMENTREPORT"].AllPropertyDefs["STARTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? EndDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDULATREATMENTREPORT"].AllPropertyDefs["ENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Diagnosecode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIAGNOSECODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetEswtReportInfoByPatient_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetEswtReportInfoByPatient_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetEswtReportInfoByPatient_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMedulaTreatmentReportForWL_Class : TTReportNqlObject 
        {
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

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public bool? Isemergency
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISEMERGENCY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDULATREATMENTREPORT"].AllPropertyDefs["EMERGENCY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Prioritystatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRIORITYSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRIORITYSTATUSDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? Date
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDULATREATMENTREPORT"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Object Patientnamesurname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTNAMESURNAME"]);
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

            public Object Episodeactionname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["EPISODEACTIONNAME"]);
                }
            }

            public String Statename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STATENAME"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public string Masterresource
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MASTERRESOURCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public string Admissiontype
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADMISSIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROVIZYONTIPI"].AllPropertyDefs["PROVIZYONTIPIADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Payername
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].AllPropertyDefs["NAME"].DataType;
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

            public string Telno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TELNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTIDENTITYANDADDRESS"].AllPropertyDefs["MOBILEPHONE"].DataType;
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

            public GetMedulaTreatmentReportForWL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMedulaTreatmentReportForWL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMedulaTreatmentReportForWL_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// Rapor Kaydedildi
    /// </summary>
            public static Guid Saved { get { return new Guid("9b34ccd9-126a-45cf-af75-5df658564858"); } }
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("2c0e43f4-b22a-4d79-b152-4ccfb197231c"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("a4c13d4c-c194-4ab0-93b5-801cde9a15a6"); } }
    /// <summary>
    /// Medulaya Gönderildi
    /// </summary>
            public static Guid SendMedula { get { return new Guid("62f6cb43-4908-4be3-a218-c514bdc79eac"); } }
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("074d65db-4779-4fc0-8ab5-a063742c8320"); } }
        }

    /// <summary>
    /// Hasta bazlı medula raporları sorgulama
    /// </summary>
        public static BindingList<MedulaTreatmentReport.GetFtrMedulaReportInfoByPatient_Class> GetFtrMedulaReportInfoByPatient(Guid PATIENT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDULATREATMENTREPORT"].QueryDefs["GetFtrMedulaReportInfoByPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<MedulaTreatmentReport.GetFtrMedulaReportInfoByPatient_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Hasta bazlı medula raporları sorgulama
    /// </summary>
        public static BindingList<MedulaTreatmentReport.GetFtrMedulaReportInfoByPatient_Class> GetFtrMedulaReportInfoByPatient(TTObjectContext objectContext, Guid PATIENT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDULATREATMENTREPORT"].QueryDefs["GetFtrMedulaReportInfoByPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<MedulaTreatmentReport.GetFtrMedulaReportInfoByPatient_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<MedulaTreatmentReport.GetEswtMedulaReportInfoByPatient_Class> GetEswtMedulaReportInfoByPatient(Guid PATIENT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDULATREATMENTREPORT"].QueryDefs["GetEswtMedulaReportInfoByPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<MedulaTreatmentReport.GetEswtMedulaReportInfoByPatient_Class>(queryDef, paramList, pi);
        }

        public static BindingList<MedulaTreatmentReport.GetEswtMedulaReportInfoByPatient_Class> GetEswtMedulaReportInfoByPatient(TTObjectContext objectContext, Guid PATIENT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDULATREATMENTREPORT"].QueryDefs["GetEswtMedulaReportInfoByPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<MedulaTreatmentReport.GetEswtMedulaReportInfoByPatient_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Hasta bazlı kurum raporu sorgulama
    /// </summary>
        public static BindingList<MedulaTreatmentReport.GetFtrReportInfoByPatient_Class> GetFtrReportInfoByPatient(Guid PATIENT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDULATREATMENTREPORT"].QueryDefs["GetFtrReportInfoByPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<MedulaTreatmentReport.GetFtrReportInfoByPatient_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Hasta bazlı kurum raporu sorgulama
    /// </summary>
        public static BindingList<MedulaTreatmentReport.GetFtrReportInfoByPatient_Class> GetFtrReportInfoByPatient(TTObjectContext objectContext, Guid PATIENT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDULATREATMENTREPORT"].QueryDefs["GetFtrReportInfoByPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<MedulaTreatmentReport.GetFtrReportInfoByPatient_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<MedulaTreatmentReport.GetEswtReportInfoByPatient_Class> GetEswtReportInfoByPatient(Guid PATIENT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDULATREATMENTREPORT"].QueryDefs["GetEswtReportInfoByPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<MedulaTreatmentReport.GetEswtReportInfoByPatient_Class>(queryDef, paramList, pi);
        }

        public static BindingList<MedulaTreatmentReport.GetEswtReportInfoByPatient_Class> GetEswtReportInfoByPatient(TTObjectContext objectContext, Guid PATIENT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDULATREATMENTREPORT"].QueryDefs["GetEswtReportInfoByPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<MedulaTreatmentReport.GetEswtReportInfoByPatient_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<MedulaTreatmentReport.GetMedulaTreatmentReportForWL_Class> GetMedulaTreatmentReportForWL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDULATREATMENTREPORT"].QueryDefs["GetMedulaTreatmentReportForWL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MedulaTreatmentReport.GetMedulaTreatmentReportForWL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MedulaTreatmentReport.GetMedulaTreatmentReportForWL_Class> GetMedulaTreatmentReportForWL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDULATREATMENTREPORT"].QueryDefs["GetMedulaTreatmentReportForWL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MedulaTreatmentReport.GetMedulaTreatmentReportForWL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Medula Rapor Takip No
    /// </summary>
        public string RaporTakipNo
        {
            get { return (string)this["RAPORTAKIPNO"]; }
            set { this["RAPORTAKIPNO"] = value; }
        }

    /// <summary>
    /// Sonuç Açıklaması
    /// </summary>
        public string SonucAciklamasi
        {
            get { return (string)this["SONUCACIKLAMASI"]; }
            set { this["SONUCACIKLAMASI"] = value; }
        }

    /// <summary>
    /// Rapor Gönderim Tarihi
    /// </summary>
        public DateTime? RaporGonderimTarihi
        {
            get { return (DateTime?)this["RAPORGONDERIMTARIHI"]; }
            set { this["RAPORGONDERIMTARIHI"] = value; }
        }

    /// <summary>
    /// Sonuç Kodu
    /// </summary>
        public string SonucKodu
        {
            get { return (string)this["SONUCKODU"]; }
            set { this["SONUCKODU"] = value; }
        }

    /// <summary>
    /// Tedavi Rapor Türü
    /// </summary>
        public TedaviRaporTuruEnum? TedaviRaporTuru
        {
            get { return (TedaviRaporTuruEnum?)(int?)this["TEDAVIRAPORTURU"]; }
            set { this["TEDAVIRAPORTURU"] = value; }
        }

    /// <summary>
    /// Giden Rapor Bilgileri
    /// </summary>
        public string RaporGidenXML
        {
            get { return (string)this["RAPORGIDENXML"]; }
            set { this["RAPORGIDENXML"] = value; }
        }

    /// <summary>
    /// Gelen Rapor Bilgileri
    /// </summary>
        public string RaporGelenXML
        {
            get { return (string)this["RAPORGELENXML"]; }
            set { this["RAPORGELENXML"] = value; }
        }

        public Guid? PatientObjectID
        {
            get { return (Guid?)this["PATIENTOBJECTID"]; }
            set { this["PATIENTOBJECTID"] = value; }
        }

    /// <summary>
    /// Bağlı Olduğu Medula Takibi
    /// </summary>
        public Guid? SEPObjectID
        {
            get { return (Guid?)this["SEPOBJECTID"]; }
            set { this["SEPOBJECTID"] = value; }
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
    /// Başlangıç Tarihi
    /// </summary>
        public DateTime? StartDate
        {
            get { return (DateTime?)this["STARTDATE"]; }
            set { this["STARTDATE"] = value; }
        }

    /// <summary>
    /// Bitiş Tarihi
    /// </summary>
        public DateTime? EndDate
        {
            get { return (DateTime?)this["ENDDATE"]; }
            set { this["ENDDATE"] = value; }
        }

    /// <summary>
    /// Süre
    /// </summary>
        public int? Duration
        {
            get { return (int?)this["DURATION"]; }
            set { this["DURATION"] = value; }
        }

    /// <summary>
    /// Süre Türü
    /// </summary>
        public PeriodUnitTypeEnum? DurationType
        {
            get { return (PeriodUnitTypeEnum?)(int?)this["DURATIONTYPE"]; }
            set { this["DURATIONTYPE"] = value; }
        }

    /// <summary>
    /// Heyet Raporu
    /// </summary>
        public bool? CommitteeReport
        {
            get { return (bool?)this["COMMITTEEREPORT"]; }
            set { this["COMMITTEEREPORT"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public object Description
        {
            get { return (object)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Medulaya Gönderildi
    /// </summary>
        public bool? IsSendedMedula
        {
            get { return (bool?)this["ISSENDEDMEDULA"]; }
            set { this["ISSENDEDMEDULA"] = value; }
        }

    /// <summary>
    /// 2.Doktor
    /// </summary>
        public ResUser SecondDoctor
        {
            get { return (ResUser)((ITTObject)this).GetParent("SECONDDOCTOR"); }
            set { this["SECONDDOCTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// 3.Doktor
    /// </summary>
        public ResUser ThirdDoctor
        {
            get { return (ResUser)((ITTObject)this).GetParent("THIRDDOCTOR"); }
            set { this["THIRDDOCTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public FTRReport FTRReport
        {
            get { return (FTRReport)((ITTObject)this).GetParent("FTRREPORT"); }
            set { this["FTRREPORT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ESWTReport ESWTReport
        {
            get { return (ESWTReport)((ITTObject)this).GetParent("ESWTREPORT"); }
            set { this["ESWTREPORT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ESWLReport ESWLReport
        {
            get { return (ESWLReport)((ITTObject)this).GetParent("ESWLREPORT"); }
            set { this["ESWLREPORT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public HBTReport HBTReport
        {
            get { return (HBTReport)((ITTObject)this).GetParent("HBTREPORT"); }
            set { this["HBTREPORT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DialysisReport DialysisReport
        {
            get { return (DialysisReport)((ITTObject)this).GetParent("DIALYSISREPORT"); }
            set { this["DIALYSISREPORT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public HomeHemodialysisReport HomeHemodialysisReport
        {
            get { return (HomeHemodialysisReport)((ITTObject)this).GetParent("HOMEHEMODIALYSISREPORT"); }
            set { this["HOMEHEMODIALYSISREPORT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public TubeBabyReport TubeBabyReport
        {
            get { return (TubeBabyReport)((ITTObject)this).GetParent("TUBEBABYREPORT"); }
            set { this["TUBEBABYREPORT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MedulaTreatmentReport(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MedulaTreatmentReport(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MedulaTreatmentReport(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MedulaTreatmentReport(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MedulaTreatmentReport(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MEDULATREATMENTREPORT", dataRow) { }
        protected MedulaTreatmentReport(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MEDULATREATMENTREPORT", dataRow, isImported) { }
        public MedulaTreatmentReport(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MedulaTreatmentReport(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MedulaTreatmentReport() : base() { }

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