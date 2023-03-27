
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PhysiotherapyOrder")] 

    /// <summary>
    /// F.T.R. Emrinin Veridiği Nesnedir
    /// </summary>
    public  partial class PhysiotherapyOrder : BasePhysiotherapyOrder, ICreateSubEpisode, IOldActions, IReasonOfReject, IPlanPlannedAction
    {
        public class PhysiotherapyOrderList : TTObjectCollection<PhysiotherapyOrder> { }
                    
        public class ChildPhysiotherapyOrderCollection : TTObject.TTChildObjectCollection<PhysiotherapyOrder>
        {
            public ChildPhysiotherapyOrderCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPhysiotherapyOrderCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetPhysiotherapyOrders_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? Objectid1
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID1"]);
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

            public string ApplicationArea
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["APPLICATIONAREA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["APPLICATIONAREA"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["AMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESTREATMENTDIAGNOSISUNIT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Name1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME1"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetPhysiotherapyOrders_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPhysiotherapyOrders_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPhysiotherapyOrders_Class() : base() { }
        }

        [Serializable] 

        public partial class PhysiotherapyAcceptionReportNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
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

            public string Cinsiyet
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CINSIYET"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSCINSIYET"].AllPropertyDefs["ADI"].DataType;
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

            public Object Cityname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["CITYNAME"]);
                }
            }

            public string Townname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOWNNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TOWNDEFINITIONS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public Object Reasonforadm
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["REASONFORADM"]);
                }
            }

            public Guid? Episodeobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODEOBJECTID"]);
                }
            }

            public string Fromres
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FROMRES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["PROTOCOLNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? Actionid
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["ID"].DataType;
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

            public long? Physiotherapyrequestprotocolno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PHYSIOTHERAPYREQUESTPROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYREQUEST"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Docdiplomano
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCDIPLOMANO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["DIPLOMANO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Docemploymentrecordid
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCEMPLOYMENTRECORDID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["EMPLOYMENTRECORDID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public UserTitleEnum? Doctitle
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCTITLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["TITLE"].DataType;
                    return (UserTitleEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Dokrank
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOKRANK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RANKDEFINITIONS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Docmilitaryclass
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCMILITARYCLASS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MILITARYCLASSDEFINITIONS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Docwork
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCWORK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["WORK"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public string Docspeciality
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCSPECIALITY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public PhysiotherapyAcceptionReportNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public PhysiotherapyAcceptionReportNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected PhysiotherapyAcceptionReportNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDistinctTreatmentDiagnosisUnitsByRequest_Class : TTReportNqlObject 
        {
            public Guid? TreatmentDiagnosisUnit
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["TREATMENTDIAGNOSISUNIT"]);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public GetDistinctTreatmentDiagnosisUnitsByRequest_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDistinctTreatmentDiagnosisUnitsByRequest_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDistinctTreatmentDiagnosisUnitsByRequest_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPhysiotherapyOrderList_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? Requestid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["REQUESTID"]);
                }
            }

            public Guid? TreatmentDiagnosisUnit
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["TREATMENTDIAGNOSISUNIT"]);
                }
            }

            public Guid? FTRApplicationAreaDef
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["FTRAPPLICATIONAREADEF"]);
                }
            }

            public Guid? TreatmentRoom
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["TREATMENTROOM"]);
                }
            }

            public Guid? ProcedureObject
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDUREOBJECT"]);
                }
            }

            public Guid? ProcedureDoctor
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDUREDOCTOR"]);
                }
            }

            public string ApplicationArea
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["APPLICATIONAREA"]);
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

            public int? FinishSession
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FINISHSESSION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["FINISHSESSION"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public bool? IncludeMonday
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INCLUDEMONDAY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["INCLUDEMONDAY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IncludeTuesday
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INCLUDETUESDAY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["INCLUDETUESDAY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IncludeWednesday
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INCLUDEWEDNESDAY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["INCLUDEWEDNESDAY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IncludeThursday
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INCLUDETHURSDAY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["INCLUDETHURSDAY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IncludeFriday
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INCLUDEFRIDAY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["INCLUDEFRIDAY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IncludeSaturday
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INCLUDESATURDAY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["INCLUDESATURDAY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IncludeSunday
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INCLUDESUNDAY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["INCLUDESUNDAY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? PhysiotherapyStartDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PHYSIOTHERAPYSTARTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["PHYSIOTHERAPYSTARTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? ProtocolNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string raporTakipNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RAPORTAKIPNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["RAPORTAKIPNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? SeansGunSayisi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SEANSGUNSAYISI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["SEANSGUNSAYISI"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? StartSession
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STARTSESSION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["STARTSESSION"].DataType;
                    return (int?)dataType.ConvertValue(val);
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

            public DateTime? TreatmentStartDateTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TREATMENTSTARTDATETIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["TREATMENTSTARTDATETIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string DescriptionForWorkList
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTIONFORWORKLIST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["DESCRIPTIONFORWORKLIST"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetPhysiotherapyOrderList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPhysiotherapyOrderList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPhysiotherapyOrderList_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPhysiotherapyOrderInfo_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Ftrapplicationareadef
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FTRAPPLICATIONAREADEF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FTRVUCUTBOLGESI"].AllPropertyDefs["FTRVUCUTBOLGESIADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ApplicationArea
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["APPLICATIONAREA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["APPLICATIONAREA"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? SessionCount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SESSIONCOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["SESSIONCOUNT"].DataType;
                    return (int?)dataType.ConvertValue(val);
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

            public GetPhysiotherapyOrderInfo_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPhysiotherapyOrderInfo_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPhysiotherapyOrderInfo_Class() : base() { }
        }

        [Serializable] 

        public partial class GetExistingPhysiotherapyUnits_Class : TTReportNqlObject 
        {
            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESTREATMENTDIAGNOSISUNIT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? TreatmentDiagnosisUnit
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["TREATMENTDIAGNOSISUNIT"]);
                }
            }

            public GetExistingPhysiotherapyUnits_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetExistingPhysiotherapyUnits_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetExistingPhysiotherapyUnits_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPhysiotherapyOrdersByUnitAndRequest_Class : TTReportNqlObject 
        {
            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYDEFINITION"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Uygulananbolge
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UYGULANANBOLGE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FTRVUCUTBOLGESI"].AllPropertyDefs["FTRVUCUTBOLGESIADI"].DataType;
                    return (string)dataType.ConvertValue(val);
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["REASONOFCANCEL"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["ACTIVE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["WORKLISTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["REASONOFREJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["OLAPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["WORKLISTDESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["ISOLDACTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["REQUESTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["EMERGENCY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["PATIENTPAY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["ORDEROBJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["DESCRIPTIONFORWORKLIST"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["IGNOREEPISODESTATEONUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["ADMISSIONQUEUENUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public object DoctorReturnDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCTORRETURNDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["DOCTORRETURNDESCRIPTION"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object AbortRequestDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ABORTREQUESTDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["ABORTREQUESTDESCRIPTION"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public double? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["AMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public DateTime? TreatmentStartDateTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TREATMENTSTARTDATETIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["TREATMENTSTARTDATETIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public string ApplicationArea
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["APPLICATIONAREA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["APPLICATIONAREA"].DataType;
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

            public int? SeansGunSayisi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SEANSGUNSAYISI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["SEANSGUNSAYISI"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string drAnesteziTescilNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DRANESTEZITESCILNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["DRANESTEZITESCILNO"].DataType;
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

            public int? StartSession
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STARTSESSION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["STARTSESSION"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? FinishSession
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FINISHSESSION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["FINISHSESSION"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public bool? IncludeSaturday
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INCLUDESATURDAY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["INCLUDESATURDAY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IncludeSunday
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INCLUDESUNDAY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["INCLUDESUNDAY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
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

            public bool? IsChangedAutomatically
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISCHANGEDAUTOMATICALLY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["ISCHANGEDAUTOMATICALLY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IncludeTuesday
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INCLUDETUESDAY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["INCLUDETUESDAY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IncludeMonday
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INCLUDEMONDAY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["INCLUDEMONDAY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IncludeWednesday
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INCLUDEWEDNESDAY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["INCLUDEWEDNESDAY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IncludeThursday
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INCLUDETHURSDAY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["INCLUDETHURSDAY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IncludeFriday
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INCLUDEFRIDAY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["INCLUDEFRIDAY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsPaidTreatment
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISPAIDTREATMENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["ISPAIDTREATMENT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string raporTakipNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RAPORTAKIPNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["RAPORTAKIPNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
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

            public int? SessionCount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SESSIONCOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["SESSIONCOUNT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public DateTime? PhysiotherapyStartDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PHYSIOTHERAPYSTARTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].AllPropertyDefs["PHYSIOTHERAPYSTARTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetPhysiotherapyOrdersByUnitAndRequest_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPhysiotherapyOrdersByUnitAndRequest_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPhysiotherapyOrdersByUnitAndRequest_Class() : base() { }
        }

        [Serializable] 

        public partial class GetNotReportedPhysiotherapyOrderByRequestObject_Class : TTReportNqlObject 
        {
            public Object Cnt
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["CNT"]);
                }
            }

            public GetNotReportedPhysiotherapyOrderByRequestObject_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetNotReportedPhysiotherapyOrderByRequestObject_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetNotReportedPhysiotherapyOrderByRequestObject_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPhysiotherapyOrderForWorkList_Class : TTReportNqlObject 
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

            public GetPhysiotherapyOrderForWorkList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPhysiotherapyOrderForWorkList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPhysiotherapyOrderForWorkList_Class() : base() { }
        }

        public static class States
        {
            public static Guid Rejected { get { return new Guid("bee715bd-2835-4582-ba46-6f93eb675c3e"); } }
            public static Guid Aborted { get { return new Guid("ba9e8ef9-3783-432e-a937-a84d112679c0"); } }
            public static Guid RequestAcception { get { return new Guid("16b54535-aacc-414b-ab69-b06759532cd7"); } }
            public static Guid Cancelled { get { return new Guid("6c7501fa-59cc-4c8a-bd93-bfe6928ba033"); } }
            public static Guid Completed { get { return new Guid("7e5d16c3-f766-4b63-bedf-d536ca91b077"); } }
        }

        public static BindingList<PhysiotherapyOrder.GetPhysiotherapyOrders_Class> GetPhysiotherapyOrders(string PHYSIOTHERAPYREQUEST, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].QueryDefs["GetPhysiotherapyOrders"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PHYSIOTHERAPYREQUEST", PHYSIOTHERAPYREQUEST);

            return TTReportNqlObject.QueryObjects<PhysiotherapyOrder.GetPhysiotherapyOrders_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PhysiotherapyOrder.GetPhysiotherapyOrders_Class> GetPhysiotherapyOrders(TTObjectContext objectContext, string PHYSIOTHERAPYREQUEST, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].QueryDefs["GetPhysiotherapyOrders"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PHYSIOTHERAPYREQUEST", PHYSIOTHERAPYREQUEST);

            return TTReportNqlObject.QueryObjects<PhysiotherapyOrder.GetPhysiotherapyOrders_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PhysiotherapyOrder> GetMySiblingObjectsForAppointment(TTObjectContext objectContext, string PARAMEPISODE, string PARAMCURRENTOBJECT)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].QueryDefs["GetMySiblingObjectsForAppointment"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMEPISODE", PARAMEPISODE);
            paramList.Add("PARAMCURRENTOBJECT", PARAMCURRENTOBJECT);

            return ((ITTQuery)objectContext).QueryObjects<PhysiotherapyOrder>(queryDef, paramList);
        }

        public static BindingList<PhysiotherapyOrder.PhysiotherapyAcceptionReportNQL_Class> PhysiotherapyAcceptionReportNQL(string PHYSIOTHERAPYORDER, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].QueryDefs["PhysiotherapyAcceptionReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PHYSIOTHERAPYORDER", PHYSIOTHERAPYORDER);

            return TTReportNqlObject.QueryObjects<PhysiotherapyOrder.PhysiotherapyAcceptionReportNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PhysiotherapyOrder.PhysiotherapyAcceptionReportNQL_Class> PhysiotherapyAcceptionReportNQL(TTObjectContext objectContext, string PHYSIOTHERAPYORDER, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].QueryDefs["PhysiotherapyAcceptionReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PHYSIOTHERAPYORDER", PHYSIOTHERAPYORDER);

            return TTReportNqlObject.QueryObjects<PhysiotherapyOrder.PhysiotherapyAcceptionReportNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PhysiotherapyOrder.GetDistinctTreatmentDiagnosisUnitsByRequest_Class> GetDistinctTreatmentDiagnosisUnitsByRequest(Guid PHYSIOTHERAPYREQUEST, IList<Guid> USERUNITS, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].QueryDefs["GetDistinctTreatmentDiagnosisUnitsByRequest"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PHYSIOTHERAPYREQUEST", PHYSIOTHERAPYREQUEST);
            paramList.Add("USERUNITS", USERUNITS);

            return TTReportNqlObject.QueryObjects<PhysiotherapyOrder.GetDistinctTreatmentDiagnosisUnitsByRequest_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PhysiotherapyOrder.GetDistinctTreatmentDiagnosisUnitsByRequest_Class> GetDistinctTreatmentDiagnosisUnitsByRequest(TTObjectContext objectContext, Guid PHYSIOTHERAPYREQUEST, IList<Guid> USERUNITS, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].QueryDefs["GetDistinctTreatmentDiagnosisUnitsByRequest"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PHYSIOTHERAPYREQUEST", PHYSIOTHERAPYREQUEST);
            paramList.Add("USERUNITS", USERUNITS);

            return TTReportNqlObject.QueryObjects<PhysiotherapyOrder.GetDistinctTreatmentDiagnosisUnitsByRequest_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Bir PhysiotherapyPlanningForm İçinde Eklenen Order Listesi
    /// </summary>
        public static BindingList<PhysiotherapyOrder.GetPhysiotherapyOrderList_Class> GetPhysiotherapyOrderList(Guid PHYSIOTHERAPYREQUEST, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].QueryDefs["GetPhysiotherapyOrderList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PHYSIOTHERAPYREQUEST", PHYSIOTHERAPYREQUEST);

            return TTReportNqlObject.QueryObjects<PhysiotherapyOrder.GetPhysiotherapyOrderList_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Bir PhysiotherapyPlanningForm İçinde Eklenen Order Listesi
    /// </summary>
        public static BindingList<PhysiotherapyOrder.GetPhysiotherapyOrderList_Class> GetPhysiotherapyOrderList(TTObjectContext objectContext, Guid PHYSIOTHERAPYREQUEST, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].QueryDefs["GetPhysiotherapyOrderList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PHYSIOTHERAPYREQUEST", PHYSIOTHERAPYREQUEST);

            return TTReportNqlObject.QueryObjects<PhysiotherapyOrder.GetPhysiotherapyOrderList_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Request'e göre order sorgusu 
    /// </summary>
        public static BindingList<PhysiotherapyOrder.GetPhysiotherapyOrderInfo_Class> GetPhysiotherapyOrderInfo(Guid PHYSIOTHERAPYREQUEST, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].QueryDefs["GetPhysiotherapyOrderInfo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PHYSIOTHERAPYREQUEST", PHYSIOTHERAPYREQUEST);

            return TTReportNqlObject.QueryObjects<PhysiotherapyOrder.GetPhysiotherapyOrderInfo_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Request'e göre order sorgusu 
    /// </summary>
        public static BindingList<PhysiotherapyOrder.GetPhysiotherapyOrderInfo_Class> GetPhysiotherapyOrderInfo(TTObjectContext objectContext, Guid PHYSIOTHERAPYREQUEST, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].QueryDefs["GetPhysiotherapyOrderInfo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PHYSIOTHERAPYREQUEST", PHYSIOTHERAPYREQUEST);

            return TTReportNqlObject.QueryObjects<PhysiotherapyOrder.GetPhysiotherapyOrderInfo_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Fizyoterapi isteklerinin order nesneleri
    /// </summary>
        public static BindingList<PhysiotherapyOrder> GetPhysiotherapyOrderByRequest(TTObjectContext objectContext, Guid PHYSIOTHERAPYREQUEST)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].QueryDefs["GetPhysiotherapyOrderByRequest"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PHYSIOTHERAPYREQUEST", PHYSIOTHERAPYREQUEST);

            return ((ITTQuery)objectContext).QueryObjects<PhysiotherapyOrder>(queryDef, paramList);
        }

        public static BindingList<PhysiotherapyOrder.GetExistingPhysiotherapyUnits_Class> GetExistingPhysiotherapyUnits(Guid PHYSIOTHERAPYREQUEST, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].QueryDefs["GetExistingPhysiotherapyUnits"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PHYSIOTHERAPYREQUEST", PHYSIOTHERAPYREQUEST);

            return TTReportNqlObject.QueryObjects<PhysiotherapyOrder.GetExistingPhysiotherapyUnits_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PhysiotherapyOrder.GetExistingPhysiotherapyUnits_Class> GetExistingPhysiotherapyUnits(TTObjectContext objectContext, Guid PHYSIOTHERAPYREQUEST, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].QueryDefs["GetExistingPhysiotherapyUnits"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PHYSIOTHERAPYREQUEST", PHYSIOTHERAPYREQUEST);

            return TTReportNqlObject.QueryObjects<PhysiotherapyOrder.GetExistingPhysiotherapyUnits_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PhysiotherapyOrder.GetPhysiotherapyOrdersByUnitAndRequest_Class> GetPhysiotherapyOrdersByUnitAndRequest(Guid PHYSIOTHERAPYREQUEST, Guid TREATMENTDIAGNOSISUNIT, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].QueryDefs["GetPhysiotherapyOrdersByUnitAndRequest"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PHYSIOTHERAPYREQUEST", PHYSIOTHERAPYREQUEST);
            paramList.Add("TREATMENTDIAGNOSISUNIT", TREATMENTDIAGNOSISUNIT);

            return TTReportNqlObject.QueryObjects<PhysiotherapyOrder.GetPhysiotherapyOrdersByUnitAndRequest_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PhysiotherapyOrder.GetPhysiotherapyOrdersByUnitAndRequest_Class> GetPhysiotherapyOrdersByUnitAndRequest(TTObjectContext objectContext, Guid PHYSIOTHERAPYREQUEST, Guid TREATMENTDIAGNOSISUNIT, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].QueryDefs["GetPhysiotherapyOrdersByUnitAndRequest"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PHYSIOTHERAPYREQUEST", PHYSIOTHERAPYREQUEST);
            paramList.Add("TREATMENTDIAGNOSISUNIT", TREATMENTDIAGNOSISUNIT);

            return TTReportNqlObject.QueryObjects<PhysiotherapyOrder.GetPhysiotherapyOrdersByUnitAndRequest_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PhysiotherapyOrder.GetNotReportedPhysiotherapyOrderByRequestObject_Class> GetNotReportedPhysiotherapyOrderByRequestObject(string REQUESTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].QueryDefs["GetNotReportedPhysiotherapyOrderByRequestObject"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("REQUESTOBJECTID", REQUESTOBJECTID);

            return TTReportNqlObject.QueryObjects<PhysiotherapyOrder.GetNotReportedPhysiotherapyOrderByRequestObject_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PhysiotherapyOrder.GetNotReportedPhysiotherapyOrderByRequestObject_Class> GetNotReportedPhysiotherapyOrderByRequestObject(TTObjectContext objectContext, string REQUESTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].QueryDefs["GetNotReportedPhysiotherapyOrderByRequestObject"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("REQUESTOBJECTID", REQUESTOBJECTID);

            return TTReportNqlObject.QueryObjects<PhysiotherapyOrder.GetNotReportedPhysiotherapyOrderByRequestObject_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PhysiotherapyOrder.GetPhysiotherapyOrderForWorkList_Class> GetPhysiotherapyOrderForWorkList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].QueryDefs["GetPhysiotherapyOrderForWorkList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PhysiotherapyOrder.GetPhysiotherapyOrderForWorkList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PhysiotherapyOrder.GetPhysiotherapyOrderForWorkList_Class> GetPhysiotherapyOrderForWorkList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHYSIOTHERAPYORDER"].QueryDefs["GetPhysiotherapyOrderForWorkList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PhysiotherapyOrder.GetPhysiotherapyOrderForWorkList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string TreatmentProperties
        {
            get { return (string)this["TREATMENTPROPERTIES"]; }
            set { this["TREATMENTPROPERTIES"] = value; }
        }

    /// <summary>
    /// Vücut Bölgesi Açıklama
    /// </summary>
        public string ApplicationArea
        {
            get { return (string)this["APPLICATIONAREA"]; }
            set { this["APPLICATIONAREA"] = value; }
        }

    /// <summary>
    /// Süre/dk
    /// </summary>
        public long? Duration
        {
            get { return (long?)this["DURATION"]; }
            set { this["DURATION"] = value; }
        }

    /// <summary>
    /// Seans Gün Sayısı
    /// </summary>
        public int? SeansGunSayisi
        {
            get { return (int?)this["SEANSGUNSAYISI"]; }
            set { this["SEANSGUNSAYISI"] = value; }
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
    /// Doz
    /// </summary>
        public string Dose
        {
            get { return (string)this["DOSE"]; }
            set { this["DOSE"] = value; }
        }

    /// <summary>
    /// Başlangıç Seansı
    /// </summary>
        public int? StartSession
        {
            get { return (int?)this["STARTSESSION"]; }
            set { this["STARTSESSION"] = value; }
        }

    /// <summary>
    /// Bitiş Seansı
    /// </summary>
        public int? FinishSession
        {
            get { return (int?)this["FINISHSESSION"]; }
            set { this["FINISHSESSION"] = value; }
        }

    /// <summary>
    /// Cumartesi Dahil
    /// </summary>
        public bool? IncludeSaturday
        {
            get { return (bool?)this["INCLUDESATURDAY"]; }
            set { this["INCLUDESATURDAY"] = value; }
        }

    /// <summary>
    /// Pazar Dahil
    /// </summary>
        public bool? IncludeSunday
        {
            get { return (bool?)this["INCLUDESUNDAY"]; }
            set { this["INCLUDESUNDAY"] = value; }
        }

    /// <summary>
    /// Ek Tedavi(Seans bitimi sonrası eklenen tedavi)
    /// </summary>
        public bool? IsAdditionalTreatment
        {
            get { return (bool?)this["ISADDITIONALTREATMENT"]; }
            set { this["ISADDITIONALTREATMENT"] = value; }
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
    /// Salı
    /// </summary>
        public bool? IncludeTuesday
        {
            get { return (bool?)this["INCLUDETUESDAY"]; }
            set { this["INCLUDETUESDAY"] = value; }
        }

    /// <summary>
    /// Pazartesi
    /// </summary>
        public bool? IncludeMonday
        {
            get { return (bool?)this["INCLUDEMONDAY"]; }
            set { this["INCLUDEMONDAY"] = value; }
        }

    /// <summary>
    /// Çarşamba
    /// </summary>
        public bool? IncludeWednesday
        {
            get { return (bool?)this["INCLUDEWEDNESDAY"]; }
            set { this["INCLUDEWEDNESDAY"] = value; }
        }

    /// <summary>
    /// Perşembe
    /// </summary>
        public bool? IncludeThursday
        {
            get { return (bool?)this["INCLUDETHURSDAY"]; }
            set { this["INCLUDETHURSDAY"] = value; }
        }

    /// <summary>
    /// Cuma
    /// </summary>
        public bool? IncludeFriday
        {
            get { return (bool?)this["INCLUDEFRIDAY"]; }
            set { this["INCLUDEFRIDAY"] = value; }
        }

    /// <summary>
    /// Ücretli Tedavi
    /// </summary>
        public bool? IsPaidTreatment
        {
            get { return (bool?)this["ISPAIDTREATMENT"]; }
            set { this["ISPAIDTREATMENT"] = value; }
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
    /// Protokol No
    /// </summary>
        public TTSequence ProtocolNo
        {
            get { return GetSequence("PROTOCOLNO"); }
        }

    /// <summary>
    /// Süre/Doz Açıklama
    /// </summary>
        public string DoseDurationInfo
        {
            get { return (string)this["DOSEDURATIONINFO"]; }
            set { this["DOSEDURATIONINFO"] = value; }
        }

    /// <summary>
    /// Seans Sayısı
    /// </summary>
        public int? SessionCount
        {
            get { return (int?)this["SESSIONCOUNT"]; }
            set { this["SESSIONCOUNT"] = value; }
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
    /// Fizyoterapi Raporları
    /// </summary>
        public PhysiotherapyReports PhysiotherapyReports
        {
            get { return (PhysiotherapyReports)((ITTObject)this).GetParent("PHYSIOTHERAPYREPORTS"); }
            set { this["PHYSIOTHERAPYREPORTS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Fizyoterapi Emirleri
    /// </summary>
        public PhysiotherapyRequest PhysiotherapyRequest
        {
            get { return (PhysiotherapyRequest)((ITTObject)this).GetParent("PHYSIOTHERAPYREQUEST"); }
            set { this["PHYSIOTHERAPYREQUEST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Tanı Tedavi Ünitesi
    /// </summary>
        public ResTreatmentDiagnosisUnit TreatmentDiagnosisUnit
        {
            get { return (ResTreatmentDiagnosisUnit)((ITTObject)this).GetParent("TREATMENTDIAGNOSISUNIT"); }
            set { this["TREATMENTDIAGNOSISUNIT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// PhysiotherapyOrder OzelDurum
    /// </summary>
        public OzelDurum OzelDurum
        {
            get { return (OzelDurum)((ITTObject)this).GetParent("OZELDURUM"); }
            set { this["OZELDURUM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// FTR Vücut Bölgesi Tanımları
    /// </summary>
        public FTRVucutBolgesi FTRApplicationAreaDef
        {
            get { return (FTRVucutBolgesi)((ITTObject)this).GetParent("FTRAPPLICATIONAREADEF"); }
            set { this["FTRAPPLICATIONAREADEF"] = (value==null ? null : (Guid?)value.ObjectID); }
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
    /// Fizyoterapist
    /// </summary>
        public ResUser ResUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESUSER"); }
            set { this["RESUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// PhysiotherapyOrder AyniFarkliKesi
    /// </summary>
        public AyniFarkliKesi AyniFarkliKesi
        {
            get { return (AyniFarkliKesi)((ITTObject)this).GetParent("AYNIFARKLIKESI"); }
            set { this["AYNIFARKLIKESI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Paket Hizmet
    /// </summary>
        public PackageProcedureDefinition PackageProcedure
        {
            get { return (PackageProcedureDefinition)((ITTObject)this).GetParent("PACKAGEPROCEDURE"); }
            set { this["PACKAGEPROCEDURE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateMedulaReportResultsCollection()
        {
            _MedulaReportResults = new MedulaReportResult.ChildMedulaReportResultCollection(this, new Guid("e2fe412b-d3e8-4b2b-af57-1f975b7a1dea"));
            ((ITTChildObjectCollection)_MedulaReportResults).GetChildren();
        }

        protected MedulaReportResult.ChildMedulaReportResultCollection _MedulaReportResults = null;
        public MedulaReportResult.ChildMedulaReportResultCollection MedulaReportResults
        {
            get
            {
                if (_MedulaReportResults == null)
                    CreateMedulaReportResultsCollection();
                return _MedulaReportResults;
            }
        }

        virtual protected void CreateCokluOzelDurumCollection()
        {
            _CokluOzelDurum = new CokluOzelDurum.ChildCokluOzelDurumCollection(this, new Guid("d16314db-1eb5-4265-948d-bce097bbd103"));
            ((ITTChildObjectCollection)_CokluOzelDurum).GetChildren();
        }

        protected CokluOzelDurum.ChildCokluOzelDurumCollection _CokluOzelDurum = null;
    /// <summary>
    /// Child collection for PhysiotherapyOrder Çoklu Özel Durum
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

        override protected void CreateOrderDetailsCollectionViews()
        {
            base.CreateOrderDetailsCollectionViews();
            _PhysiotherapyOrderDetails = new PhysiotherapyOrderDetail.ChildPhysiotherapyOrderDetailCollection(_OrderDetails, "PhysiotherapyOrderDetails");
        }

        private PhysiotherapyOrderDetail.ChildPhysiotherapyOrderDetailCollection _PhysiotherapyOrderDetails = null;
        public PhysiotherapyOrderDetail.ChildPhysiotherapyOrderDetailCollection PhysiotherapyOrderDetails
        {
            get
            {
                if (_OrderDetails == null)
                    CreateOrderDetailsCollection();
                return _PhysiotherapyOrderDetails;
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

        protected PhysiotherapyOrder(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PhysiotherapyOrder(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PhysiotherapyOrder(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PhysiotherapyOrder(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PhysiotherapyOrder(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PHYSIOTHERAPYORDER", dataRow) { }
        protected PhysiotherapyOrder(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PHYSIOTHERAPYORDER", dataRow, isImported) { }
        public PhysiotherapyOrder(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PhysiotherapyOrder(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PhysiotherapyOrder() : base() { }

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