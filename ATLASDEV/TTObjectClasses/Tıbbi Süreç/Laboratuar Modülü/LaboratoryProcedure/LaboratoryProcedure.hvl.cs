
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="LaboratoryProcedure")] 

    /// <summary>
    /// Laboratuvar Test
    /// </summary>
    public  partial class LaboratoryProcedure : SubactionProcedureFlowable
    {
        public class LaboratoryProcedureList : TTObjectCollection<LaboratoryProcedure> { }
                    
        public class ChildLaboratoryProcedureCollection : TTObject.TTChildObjectCollection<LaboratoryProcedure>
        {
            public ChildLaboratoryProcedureCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildLaboratoryProcedureCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class OLAP_GetLabProcedure_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public DateTime? ResultDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["RESULTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? Proceduredepartment
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDUREDEPARTMENT"]);
                }
            }

            public Guid? ProcedureObject
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDUREOBJECT"]);
                }
            }

            public Guid? RequestDoctor
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["REQUESTDOCTOR"]);
                }
            }

            public Guid? FromResource
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["FROMRESOURCE"]);
                }
            }

            public Guid? Sex
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SEX"]);
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

            public Object Statestatus
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["STATESTATUS"]);
                }
            }

            public Guid? Tabname
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["TABNAME"]);
                }
            }

            public OLAP_GetLabProcedure_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetLabProcedure_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetLabProcedure_Class() : base() { }
        }

        [Serializable] 

        public partial class LaboratoryProcedureReportNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Result
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["RESULT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object LongReport
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LONGREPORT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["LONGREPORT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public string Reference
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REFERENCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["REFERENCE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object SpecialReference
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPECIALREFERENCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["SPECIALREFERENCE"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public string Unit
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNIT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["UNIT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public HighLowEnum? Warning
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WARNING"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["WARNING"].DataType;
                    return (HighLowEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ProcedureObject
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDUREOBJECT"]);
                }
            }

            public Guid? RequestedTab
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["REQUESTEDTAB"]);
                }
            }

            public string TestGroup
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TESTGROUP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["TESTGROUP"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Environment
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENVIRONMENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["ENVIRONMENT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public LaboratoryProcedureReportNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public LaboratoryProcedureReportNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected LaboratoryProcedureReportNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class GetLabProcedureByBarcodeId_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Result
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["RESULT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object LongReport
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LONGREPORT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["LONGREPORT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public string Reference
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REFERENCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["REFERENCE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object SpecialReference
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPECIALREFERENCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["SPECIALREFERENCE"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public string Unit
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNIT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["UNIT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public HighLowEnum? Warning
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WARNING"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["WARNING"].DataType;
                    return (HighLowEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetLabProcedureByBarcodeId_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetLabProcedureByBarcodeId_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetLabProcedureByBarcodeId_Class() : base() { }
        }

        [Serializable] 

        public partial class GetProcedureSuggestionsByEpisode_Class : TTReportNqlObject 
        {
            public string Message
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MESSAGE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREACTIONSUGGESTION"].AllPropertyDefs["MESSAGE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Procedureactionsuggestion
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDUREACTIONSUGGESTION"]);
                }
            }

            public Guid? SuggestedProcedureDefinition
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SUGGESTEDPROCEDUREDEFINITION"]);
                }
            }

            public Guid? SuggestedMasterResource
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SUGGESTEDMASTERRESOURCE"]);
                }
            }

            public ActionTypeEnum? ActionType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREACTIONSUGGESTION"].AllPropertyDefs["ACTIONTYPE"].DataType;
                    return (ActionTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string MinResult
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MINRESULT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUGGESTIONCASE"].AllPropertyDefs["MINRESULT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MaxResult
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MAXRESULT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUGGESTIONCASE"].AllPropertyDefs["MAXRESULT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Procedureobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDUREOBJECTID"]);
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

            public string Result
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["RESULT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetProcedureSuggestionsByEpisode_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetProcedureSuggestionsByEpisode_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetProcedureSuggestionsByEpisode_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetCancelledLabProcedure_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Object Statestatus
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["STATESTATUS"]);
                }
            }

            public DateTime? ResultDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["RESULTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public OLAP_GetCancelledLabProcedure_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetCancelledLabProcedure_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetCancelledLabProcedure_Class() : base() { }
        }

        [Serializable] 

        public partial class GetLaboratoryResultsBySubepisodeId_Class : TTReportNqlObject 
        {
            public string Testadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TESTADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Loinc_kodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LOINC_KODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSLOINC"].AllPropertyDefs["LOINCNUMARASI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Islem_referans_numarasi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISLEM_REFERANS_NUMARASI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? Tetkik_ornek_numarasi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TETKIK_ORNEK_NUMARASI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["SPECIMENID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Tetkik_ornegin_alindigi_zmn
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TETKIK_ORNEGIN_ALINDIGI_ZMN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["CREATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Tetkik_orneginin_kabul_zamani
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TETKIK_ORNEGININ_KABUL_ZAMANI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Tetkik_sonuc_tarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TETKIK_SONUC_TARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Tetkik_sonuc_onay_tarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TETKIK_SONUC_ONAY_TARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Object Sonuc_dis_erisim_bilgisi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["SONUC_DIS_ERISIM_BILGISI"]);
                }
            }

            public Object Sonuc_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["SONUC_KODU"]);
                }
            }

            public Object Sonuc_mesaji
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["SONUC_MESAJI"]);
                }
            }

            public string Sonuc
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SONUC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["RESULT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Referans_degerler
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REFERANS_DEGERLER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["REFERENCE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Birim
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIRIM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["UNIT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetLaboratoryResultsBySubepisodeId_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetLaboratoryResultsBySubepisodeId_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetLaboratoryResultsBySubepisodeId_Class() : base() { }
        }

        [Serializable] 

        public partial class GetLaboratoryProcedureByEpisode_Class : TTReportNqlObject 
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

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public bool? Eligible
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ELIGIBLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["ELIGIBLE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string ReasonOfCancel
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONOFCANCEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["REASONOFCANCEL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? WorkListDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKLISTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["WORKLISTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["PRICINGDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["AMOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["EMERGENCY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Active
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIVE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["ACTIVE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OlapDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["OLAPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OlapLastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAPLASTUPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? AccountOperationDone
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCOUNTOPERATIONDONE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["ACCOUNTOPERATIONDONE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? AccTrxsMultipliedByAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCTRXSMULTIPLIEDBYAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["ACCTRXSMULTIPLIEDBYAMOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["PATIENTPAY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string ExtraDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXTRADESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["EXTRADESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public SutRuleEngineStatus? SUTRuleStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUTRULESTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["SUTRULESTATUS"].DataType;
                    return (SutRuleEngineStatus?)(int)dataType.ConvertValue(val);
                }
            }

            public double? DiscountPercent
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISCOUNTPERCENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["DISCOUNTPERCENT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public DateTime? PerformedDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PERFORMEDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["PERFORMEDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? CreationDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CREATIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["CREATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? IsOldAction
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISOLDACTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["ISOLDACTION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string MedulaReportNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULAREPORTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["MEDULAREPORTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public RightLeftEnum? RightLeftInformation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RIGHTLEFTINFORMATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["RIGHTLEFTINFORMATION"].DataType;
                    return (RightLeftEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public object ReasonOfReject
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONOFREJECT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["REASONOFREJECT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public DateTime? TechnicianApproveDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TECHNICIANAPPROVEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["TECHNICIANAPPROVEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Reference
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REFERENCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["REFERENCE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public HighLowEnum? Warning
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WARNING"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["WARNING"].DataType;
                    return (HighLowEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Result
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["RESULT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? Check
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CHECK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["CHECK"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string TechnicianID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TECHNICIANID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["TECHNICIANID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string OwnerType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OWNERTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["OWNERTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Unit
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNIT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["UNIT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? BarcodeId
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BARCODEID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["BARCODEID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public bool? IsAntibiogram
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISANTIBIOGRAM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["ISANTIBIOGRAM"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ResultDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["RESULTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public object LongReport
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LONGREPORT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["LONGREPORT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public bool? MicrobiologyPanicNotification
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MICROBIOLOGYPANICNOTIFICATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["MICROBIOLOGYPANICNOTIFICATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public LaboratoryAbnormalFlagsEnum? Panic
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PANIC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["PANIC"].DataType;
                    return (LaboratoryAbnormalFlagsEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string TestGroup
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TESTGROUP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["TESTGROUP"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Environment
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENVIRONMENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["ENVIRONMENT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string drAnesteziTescilNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DRANESTEZITESCILNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["DRANESTEZITESCILNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? AcceptDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCEPTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["ACCEPTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ApproveDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["APPROVEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["APPROVEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ProcedureDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDUREDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["PROCEDUREDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string ResultDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULTDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["RESULTDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ProcessNote
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCESSNOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["PROCESSNOTE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object Report
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["REPORT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string RequestNote
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTNOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["REQUESTNOTE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? SampleAcceptionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SAMPLEACCEPTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["SAMPLEACCEPTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? SampleDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SAMPLEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["SAMPLEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public object SpecialReference
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPECIALREFERENCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["SPECIALREFERENCE"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public string Techniciannote
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TECHNICIANNOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["TECHNICIANNOTE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? TestDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["TESTDEFID"]);
                }
            }

            public bool? IsResultSeen
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISRESULTSEEN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["ISRESULTSEEN"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public long? SpecimenId
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPECIMENID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["SPECIMENID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? BarcodePrintDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BARCODEPRINTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["BARCODEPRINTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetLaboratoryProcedureByEpisode_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetLaboratoryProcedureByEpisode_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetLaboratoryProcedureByEpisode_Class() : base() { }
        }

        [Serializable] 

        public partial class GetLabProcByPatientByTestByDate_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public DateTime? ResultDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["RESULTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ProcedureDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDUREDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["PROCEDUREDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetLabProcByPatientByTestByDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetLabProcByPatientByTestByDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetLabProcByPatientByTestByDate_Class() : base() { }
        }

        [Serializable] 

        public partial class GetLaboratoryProcedureBySubEpisode_Class : TTReportNqlObject 
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

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public bool? Eligible
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ELIGIBLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["ELIGIBLE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string ReasonOfCancel
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONOFCANCEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["REASONOFCANCEL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? WorkListDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKLISTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["WORKLISTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["PRICINGDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["AMOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["EMERGENCY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Active
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIVE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["ACTIVE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OlapDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["OLAPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OlapLastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAPLASTUPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? AccountOperationDone
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCOUNTOPERATIONDONE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["ACCOUNTOPERATIONDONE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? AccTrxsMultipliedByAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCTRXSMULTIPLIEDBYAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["ACCTRXSMULTIPLIEDBYAMOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["PATIENTPAY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string ExtraDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXTRADESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["EXTRADESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public SutRuleEngineStatus? SUTRuleStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUTRULESTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["SUTRULESTATUS"].DataType;
                    return (SutRuleEngineStatus?)(int)dataType.ConvertValue(val);
                }
            }

            public double? DiscountPercent
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISCOUNTPERCENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["DISCOUNTPERCENT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public DateTime? PerformedDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PERFORMEDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["PERFORMEDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? CreationDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CREATIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["CREATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? IsOldAction
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISOLDACTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["ISOLDACTION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string MedulaReportNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULAREPORTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["MEDULAREPORTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public RightLeftEnum? RightLeftInformation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RIGHTLEFTINFORMATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["RIGHTLEFTINFORMATION"].DataType;
                    return (RightLeftEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public object ReasonOfReject
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONOFREJECT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["REASONOFREJECT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public DateTime? TechnicianApproveDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TECHNICIANAPPROVEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["TECHNICIANAPPROVEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Reference
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REFERENCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["REFERENCE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public HighLowEnum? Warning
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WARNING"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["WARNING"].DataType;
                    return (HighLowEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Result
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["RESULT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? Check
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CHECK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["CHECK"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string TechnicianID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TECHNICIANID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["TECHNICIANID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string OwnerType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OWNERTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["OWNERTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Unit
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNIT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["UNIT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? BarcodeId
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BARCODEID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["BARCODEID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public bool? IsAntibiogram
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISANTIBIOGRAM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["ISANTIBIOGRAM"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ResultDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["RESULTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public object LongReport
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LONGREPORT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["LONGREPORT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public bool? MicrobiologyPanicNotification
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MICROBIOLOGYPANICNOTIFICATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["MICROBIOLOGYPANICNOTIFICATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public LaboratoryAbnormalFlagsEnum? Panic
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PANIC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["PANIC"].DataType;
                    return (LaboratoryAbnormalFlagsEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string TestGroup
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TESTGROUP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["TESTGROUP"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Environment
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENVIRONMENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["ENVIRONMENT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string drAnesteziTescilNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DRANESTEZITESCILNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["DRANESTEZITESCILNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? AcceptDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCEPTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["ACCEPTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ApproveDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["APPROVEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["APPROVEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ProcedureDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDUREDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["PROCEDUREDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string ResultDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULTDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["RESULTDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ProcessNote
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCESSNOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["PROCESSNOTE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object Report
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["REPORT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string RequestNote
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTNOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["REQUESTNOTE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? SampleAcceptionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SAMPLEACCEPTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["SAMPLEACCEPTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? SampleDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SAMPLEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["SAMPLEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public object SpecialReference
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPECIALREFERENCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["SPECIALREFERENCE"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public string Techniciannote
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TECHNICIANNOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["TECHNICIANNOTE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? TestDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["TESTDEFID"]);
                }
            }

            public bool? IsResultSeen
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISRESULTSEEN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["ISRESULTSEEN"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public long? SpecimenId
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPECIMENID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["SPECIMENID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? BarcodePrintDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BARCODEPRINTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["BARCODEPRINTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetLaboratoryProcedureBySubEpisode_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetLaboratoryProcedureBySubEpisode_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetLaboratoryProcedureBySubEpisode_Class() : base() { }
        }

        [Serializable] 

        public partial class GetLabProcedureByTestAndRequest_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Result
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["RESULT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object LongReport
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LONGREPORT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["LONGREPORT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public string Reference
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REFERENCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["REFERENCE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object SpecialReference
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPECIALREFERENCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["SPECIALREFERENCE"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public string Unit
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNIT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["UNIT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public HighLowEnum? Warning
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WARNING"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["WARNING"].DataType;
                    return (HighLowEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string ResultDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULTDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["RESULTDESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ProcedureObject
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDUREOBJECT"]);
                }
            }

            public Guid? RequestedTab
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["REQUESTEDTAB"]);
                }
            }

            public string TestGroup
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TESTGROUP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["TESTGROUP"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Environment
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENVIRONMENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["ENVIRONMENT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetLabProcedureByTestAndRequest_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetLabProcedureByTestAndRequest_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetLabProcedureByTestAndRequest_Class() : base() { }
        }

        [Serializable] 

        public partial class GetLabProcedureByTabAndRequest_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Result
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["RESULT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object LongReport
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LONGREPORT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["LONGREPORT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public string Reference
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REFERENCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["REFERENCE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object SpecialReference
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPECIALREFERENCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["SPECIALREFERENCE"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public string Unit
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNIT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["UNIT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public HighLowEnum? Warning
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WARNING"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["WARNING"].DataType;
                    return (HighLowEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string ResultDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULTDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["RESULTDESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ProcedureObject
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDUREOBJECT"]);
                }
            }

            public Guid? RequestedTab
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["REQUESTEDTAB"]);
                }
            }

            public string TestGroup
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TESTGROUP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["TESTGROUP"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Environment
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENVIRONMENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["ENVIRONMENT"].DataType;
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

            public GetLabProcedureByTabAndRequest_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetLabProcedureByTabAndRequest_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetLabProcedureByTabAndRequest_Class() : base() { }
        }

        [Serializable] 

        public partial class GetRejectedLaboratoryProceduresByDate_Class : TTReportNqlObject 
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

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public bool? Eligible
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ELIGIBLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["ELIGIBLE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string ReasonOfCancel
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONOFCANCEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["REASONOFCANCEL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? WorkListDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKLISTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["WORKLISTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["PRICINGDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["AMOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["EMERGENCY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Active
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIVE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["ACTIVE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OlapDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["OLAPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OlapLastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAPLASTUPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? AccountOperationDone
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCOUNTOPERATIONDONE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["ACCOUNTOPERATIONDONE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? AccTrxsMultipliedByAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCTRXSMULTIPLIEDBYAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["ACCTRXSMULTIPLIEDBYAMOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["PATIENTPAY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string ExtraDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXTRADESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["EXTRADESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public SutRuleEngineStatus? SUTRuleStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUTRULESTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["SUTRULESTATUS"].DataType;
                    return (SutRuleEngineStatus?)(int)dataType.ConvertValue(val);
                }
            }

            public double? DiscountPercent
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISCOUNTPERCENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["DISCOUNTPERCENT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public DateTime? PerformedDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PERFORMEDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["PERFORMEDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? CreationDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CREATIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["CREATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? IsOldAction
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISOLDACTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["ISOLDACTION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string MedulaReportNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULAREPORTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["MEDULAREPORTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public RightLeftEnum? RightLeftInformation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RIGHTLEFTINFORMATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["RIGHTLEFTINFORMATION"].DataType;
                    return (RightLeftEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public object ReasonOfReject
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONOFREJECT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["REASONOFREJECT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public DateTime? TechnicianApproveDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TECHNICIANAPPROVEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["TECHNICIANAPPROVEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Reference
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REFERENCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["REFERENCE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public HighLowEnum? Warning
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WARNING"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["WARNING"].DataType;
                    return (HighLowEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Result
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["RESULT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? Check
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CHECK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["CHECK"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string TechnicianID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TECHNICIANID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["TECHNICIANID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string OwnerType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OWNERTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["OWNERTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Unit
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNIT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["UNIT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? BarcodeId
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BARCODEID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["BARCODEID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public bool? IsAntibiogram
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISANTIBIOGRAM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["ISANTIBIOGRAM"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ResultDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["RESULTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public object LongReport
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LONGREPORT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["LONGREPORT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public bool? MicrobiologyPanicNotification
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MICROBIOLOGYPANICNOTIFICATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["MICROBIOLOGYPANICNOTIFICATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public LaboratoryAbnormalFlagsEnum? Panic
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PANIC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["PANIC"].DataType;
                    return (LaboratoryAbnormalFlagsEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string TestGroup
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TESTGROUP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["TESTGROUP"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Environment
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENVIRONMENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["ENVIRONMENT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string drAnesteziTescilNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DRANESTEZITESCILNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["DRANESTEZITESCILNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? AcceptDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCEPTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["ACCEPTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ApproveDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["APPROVEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["APPROVEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ProcedureDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDUREDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["PROCEDUREDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string ResultDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULTDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["RESULTDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ProcessNote
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCESSNOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["PROCESSNOTE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object Report
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["REPORT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string RequestNote
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTNOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["REQUESTNOTE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? SampleAcceptionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SAMPLEACCEPTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["SAMPLEACCEPTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? SampleDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SAMPLEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["SAMPLEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public object SpecialReference
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPECIALREFERENCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["SPECIALREFERENCE"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public string Techniciannote
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TECHNICIANNOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["TECHNICIANNOTE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? TestDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["TESTDEFID"]);
                }
            }

            public bool? IsResultSeen
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISRESULTSEEN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["ISRESULTSEEN"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public long? SpecimenId
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPECIMENID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["SPECIMENID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? BarcodePrintDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BARCODEPRINTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["BARCODEPRINTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetRejectedLaboratoryProceduresByDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetRejectedLaboratoryProceduresByDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetRejectedLaboratoryProceduresByDate_Class() : base() { }
        }

        [Serializable] 

        public partial class GetLabProcedureByFilter_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public LaboratoryAbnormalFlagsEnum? Panic
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PANIC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["PANIC"].DataType;
                    return (LaboratoryAbnormalFlagsEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Reference
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REFERENCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["REFERENCE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Result
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["RESULT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Unit
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNIT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["UNIT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public HighLowEnum? Warning
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WARNING"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["WARNING"].DataType;
                    return (HighLowEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
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

            public GetLabProcedureByFilter_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetLabProcedureByFilter_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetLabProcedureByFilter_Class() : base() { }
        }

        [Serializable] 

        public partial class GetOnlyApprovedProcedures_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Result
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["RESULT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object LongReport
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LONGREPORT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["LONGREPORT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public string Reference
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REFERENCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["REFERENCE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object SpecialReference
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPECIALREFERENCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["SPECIALREFERENCE"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public string Unit
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNIT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["UNIT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public HighLowEnum? Warning
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WARNING"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["WARNING"].DataType;
                    return (HighLowEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetOnlyApprovedProcedures_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOnlyApprovedProcedures_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOnlyApprovedProcedures_Class() : base() { }
        }

        [Serializable] 

        public partial class GetLabProcedureByRequestTab_Class : TTReportNqlObject 
        {
            public Object Ttobjectid
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TTOBJECTID"]);
                }
            }

            public DateTime? WorkListDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKLISTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["WORKLISTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetLabProcedureByRequestTab_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetLabProcedureByRequestTab_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetLabProcedureByRequestTab_Class() : base() { }
        }

        [Serializable] 

        public partial class GunSonu_GS31DegeriDusukIslemler_Class : TTReportNqlObject 
        {
            public string Result
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["RESULT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GunSonu_GS31DegeriDusukIslemler_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GunSonu_GS31DegeriDusukIslemler_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GunSonu_GS31DegeriDusukIslemler_Class() : base() { }
        }

        [Serializable] 

        public partial class GetOldInfoForLaboratory_Class : TTReportNqlObject 
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

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public bool? Eligible
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ELIGIBLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["ELIGIBLE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string ReasonOfCancel
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONOFCANCEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["REASONOFCANCEL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? WorkListDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKLISTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["WORKLISTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["PRICINGDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["AMOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["EMERGENCY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Active
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIVE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["ACTIVE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OlapDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["OLAPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OlapLastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAPLASTUPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? AccountOperationDone
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCOUNTOPERATIONDONE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["ACCOUNTOPERATIONDONE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? AccTrxsMultipliedByAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCTRXSMULTIPLIEDBYAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["ACCTRXSMULTIPLIEDBYAMOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["PATIENTPAY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string ExtraDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXTRADESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["EXTRADESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public SutRuleEngineStatus? SUTRuleStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUTRULESTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["SUTRULESTATUS"].DataType;
                    return (SutRuleEngineStatus?)(int)dataType.ConvertValue(val);
                }
            }

            public double? DiscountPercent
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISCOUNTPERCENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["DISCOUNTPERCENT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public DateTime? PerformedDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PERFORMEDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["PERFORMEDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? CreationDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CREATIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["CREATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? IsOldAction
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISOLDACTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["ISOLDACTION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string MedulaReportNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULAREPORTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["MEDULAREPORTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public RightLeftEnum? RightLeftInformation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RIGHTLEFTINFORMATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["RIGHTLEFTINFORMATION"].DataType;
                    return (RightLeftEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public object ReasonOfReject
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONOFREJECT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["REASONOFREJECT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public DateTime? TechnicianApproveDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TECHNICIANAPPROVEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["TECHNICIANAPPROVEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Reference
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REFERENCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["REFERENCE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public HighLowEnum? Warning
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WARNING"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["WARNING"].DataType;
                    return (HighLowEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Result
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["RESULT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? Check
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CHECK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["CHECK"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string TechnicianID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TECHNICIANID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["TECHNICIANID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string OwnerType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OWNERTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["OWNERTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Unit
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNIT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["UNIT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? BarcodeId
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BARCODEID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["BARCODEID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public bool? IsAntibiogram
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISANTIBIOGRAM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["ISANTIBIOGRAM"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ResultDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["RESULTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public object LongReport
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LONGREPORT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["LONGREPORT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public bool? MicrobiologyPanicNotification
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MICROBIOLOGYPANICNOTIFICATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["MICROBIOLOGYPANICNOTIFICATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public LaboratoryAbnormalFlagsEnum? Panic
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PANIC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["PANIC"].DataType;
                    return (LaboratoryAbnormalFlagsEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string TestGroup
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TESTGROUP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["TESTGROUP"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Environment
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENVIRONMENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["ENVIRONMENT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string drAnesteziTescilNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DRANESTEZITESCILNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["DRANESTEZITESCILNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? AcceptDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCEPTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["ACCEPTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ApproveDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["APPROVEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["APPROVEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ProcedureDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDUREDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["PROCEDUREDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string ResultDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULTDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["RESULTDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ProcessNote
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCESSNOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["PROCESSNOTE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object Report
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["REPORT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string RequestNote
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTNOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["REQUESTNOTE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? SampleAcceptionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SAMPLEACCEPTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["SAMPLEACCEPTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? SampleDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SAMPLEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["SAMPLEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public object SpecialReference
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPECIALREFERENCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["SPECIALREFERENCE"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public string Techniciannote
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TECHNICIANNOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["TECHNICIANNOTE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? TestDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["TESTDEFID"]);
                }
            }

            public bool? IsResultSeen
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISRESULTSEEN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["ISRESULTSEEN"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public long? SpecimenId
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPECIMENID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["SPECIMENID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? BarcodePrintDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BARCODEPRINTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["BARCODEPRINTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
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

            public string Requestedbyuser
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTEDBYUSER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetOldInfoForLaboratory_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOldInfoForLaboratory_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOldInfoForLaboratory_Class() : base() { }
        }

        [Serializable] 

        public partial class GetOldInfoCountLaboratory_Class : TTReportNqlObject 
        {
            public Object Nqlcolumn
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["NQLCOLUMN"]);
                }
            }

            public GetOldInfoCountLaboratory_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOldInfoCountLaboratory_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOldInfoCountLaboratory_Class() : base() { }
        }

        [Serializable] 

        public partial class GetLabProcedureByWorklistDate_Class : TTReportNqlObject 
        {
            public Guid? Episode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODE"]);
                }
            }

            public Object Nqlcolumn
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["NQLCOLUMN"]);
                }
            }

            public GetLabProcedureByWorklistDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetLabProcedureByWorklistDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetLabProcedureByWorklistDate_Class() : base() { }
        }

        [Serializable] 

        public partial class GetLabProcedureForDietByEpisodeId_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYTESTDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Reference
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REFERENCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["REFERENCE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Result
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["RESULT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? ResultDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["RESULTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ApproveDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["APPROVEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["APPROVEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetLabProcedureForDietByEpisodeId_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetLabProcedureForDietByEpisodeId_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetLabProcedureForDietByEpisodeId_Class() : base() { }
        }

        [Serializable] 

        public partial class GetLaboratoryProcedureByEpisodeByWorkListDate_Class : TTReportNqlObject 
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

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public bool? Eligible
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ELIGIBLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["ELIGIBLE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string ReasonOfCancel
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONOFCANCEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["REASONOFCANCEL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? WorkListDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKLISTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["WORKLISTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["PRICINGDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["AMOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["EMERGENCY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Active
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIVE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["ACTIVE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OlapDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["OLAPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OlapLastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAPLASTUPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? AccountOperationDone
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCOUNTOPERATIONDONE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["ACCOUNTOPERATIONDONE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? AccTrxsMultipliedByAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCTRXSMULTIPLIEDBYAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["ACCTRXSMULTIPLIEDBYAMOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["PATIENTPAY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string ExtraDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXTRADESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["EXTRADESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public SutRuleEngineStatus? SUTRuleStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUTRULESTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["SUTRULESTATUS"].DataType;
                    return (SutRuleEngineStatus?)(int)dataType.ConvertValue(val);
                }
            }

            public double? DiscountPercent
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISCOUNTPERCENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["DISCOUNTPERCENT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public DateTime? PerformedDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PERFORMEDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["PERFORMEDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? CreationDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CREATIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["CREATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? IsOldAction
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISOLDACTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["ISOLDACTION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string MedulaReportNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULAREPORTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["MEDULAREPORTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public RightLeftEnum? RightLeftInformation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RIGHTLEFTINFORMATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["RIGHTLEFTINFORMATION"].DataType;
                    return (RightLeftEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public object ReasonOfReject
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONOFREJECT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["REASONOFREJECT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public DateTime? TechnicianApproveDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TECHNICIANAPPROVEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["TECHNICIANAPPROVEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Reference
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REFERENCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["REFERENCE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public HighLowEnum? Warning
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WARNING"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["WARNING"].DataType;
                    return (HighLowEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Result
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["RESULT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? Check
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CHECK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["CHECK"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string TechnicianID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TECHNICIANID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["TECHNICIANID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string OwnerType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OWNERTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["OWNERTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Unit
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNIT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["UNIT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? BarcodeId
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BARCODEID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["BARCODEID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public bool? IsAntibiogram
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISANTIBIOGRAM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["ISANTIBIOGRAM"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ResultDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["RESULTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public object LongReport
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LONGREPORT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["LONGREPORT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public bool? MicrobiologyPanicNotification
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MICROBIOLOGYPANICNOTIFICATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["MICROBIOLOGYPANICNOTIFICATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public LaboratoryAbnormalFlagsEnum? Panic
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PANIC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["PANIC"].DataType;
                    return (LaboratoryAbnormalFlagsEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string TestGroup
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TESTGROUP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["TESTGROUP"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Environment
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENVIRONMENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["ENVIRONMENT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string drAnesteziTescilNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DRANESTEZITESCILNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["DRANESTEZITESCILNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? AcceptDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCEPTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["ACCEPTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ApproveDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["APPROVEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["APPROVEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ProcedureDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDUREDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["PROCEDUREDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string ResultDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULTDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["RESULTDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ProcessNote
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCESSNOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["PROCESSNOTE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object Report
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["REPORT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string RequestNote
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTNOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["REQUESTNOTE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? SampleAcceptionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SAMPLEACCEPTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["SAMPLEACCEPTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? SampleDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SAMPLEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["SAMPLEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public object SpecialReference
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPECIALREFERENCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["SPECIALREFERENCE"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public string Techniciannote
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TECHNICIANNOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["TECHNICIANNOTE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? TestDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["TESTDEFID"]);
                }
            }

            public bool? IsResultSeen
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISRESULTSEEN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["ISRESULTSEEN"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public long? SpecimenId
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPECIMENID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["SPECIMENID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? BarcodePrintDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BARCODEPRINTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["BARCODEPRINTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? Actionid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ACTIONID"]);
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

            public GetLaboratoryProcedureByEpisodeByWorkListDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetLaboratoryProcedureByEpisodeByWorkListDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetLaboratoryProcedureByEpisodeByWorkListDate_Class() : base() { }
        }

        [Serializable] 

        public partial class GetLabResultByEpisodeByTestByDate_Class : TTReportNqlObject 
        {
            public Guid? ProcedureObject
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDUREOBJECT"]);
                }
            }

            public string Result
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["RESULT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Unit
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNIT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["UNIT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Nqlcolumn
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["NQLCOLUMN"]);
                }
            }

            public GetLabResultByEpisodeByTestByDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetLabResultByEpisodeByTestByDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetLabResultByEpisodeByTestByDate_Class() : base() { }
        }

        [Serializable] 

        public partial class GetLabProcedureGroupBySpecimenId_Class : TTReportNqlObject 
        {
            public long? SpecimenId
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPECIMENID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["SPECIMENID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Object Nqlcolumn
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["NQLCOLUMN"]);
                }
            }

            public GetLabProcedureGroupBySpecimenId_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetLabProcedureGroupBySpecimenId_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetLabProcedureGroupBySpecimenId_Class() : base() { }
        }

        [Serializable] 

        public partial class GunSonu_GS53SonuclanmisLaboratuvarSayisi_Class : TTReportNqlObject 
        {
            public Object Count
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["COUNT"]);
                }
            }

            public GunSonu_GS53SonuclanmisLaboratuvarSayisi_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GunSonu_GS53SonuclanmisLaboratuvarSayisi_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GunSonu_GS53SonuclanmisLaboratuvarSayisi_Class() : base() { }
        }

        [Serializable] 

        public partial class GunSonu_GS67PSADegeriYuksekHastaSayisi_Class : TTReportNqlObject 
        {
            public Guid? Patient
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PATIENT"]);
                }
            }

            public string Result
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["RESULT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GunSonu_GS67PSADegeriYuksekHastaSayisi_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GunSonu_GS67PSADegeriYuksekHastaSayisi_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GunSonu_GS67PSADegeriYuksekHastaSayisi_Class() : base() { }
        }

        [Serializable] 

        public partial class GunSonu_GS25HbA1cSonucDegerineGoreIslemSayisi_Class : TTReportNqlObject 
        {
            public Object Islemsayisi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ISLEMSAYISI"]);
                }
            }

            public GunSonu_GS25HbA1cSonucDegerineGoreIslemSayisi_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GunSonu_GS25HbA1cSonucDegerineGoreIslemSayisi_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GunSonu_GS25HbA1cSonucDegerineGoreIslemSayisi_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPatientSubEpisodesByPatient_Class : TTReportNqlObject 
        {
            public Guid? Subepisodeid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SUBEPISODEID"]);
                }
            }

            public Guid? Doctorid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DOCTORID"]);
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

            public DateTime? Admissiondate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADMISSIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["OPENINGDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Admissiondepartment
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADMISSIONDEPARTMENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESDEPARTMENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetPatientSubEpisodesByPatient_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPatientSubEpisodesByPatient_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPatientSubEpisodesByPatient_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPatientLabResultDetailsByPatientBySubEpisode_Class : TTReportNqlObject 
        {
            public Guid? Labprocobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["LABPROCOBJECTID"]);
                }
            }

            public Guid? Procedureobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDUREOBJECTID"]);
                }
            }

            public string Procedurename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDURENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? ResultDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["RESULTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Result
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["RESULT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Unit
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNIT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["UNIT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Reference
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REFERENCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["REFERENCE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public LaboratoryAbnormalFlagsEnum? Panic
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PANIC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["PANIC"].DataType;
                    return (LaboratoryAbnormalFlagsEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GetPatientLabResultDetailsByPatientBySubEpisode_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPatientLabResultDetailsByPatientBySubEpisode_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPatientLabResultDetailsByPatientBySubEpisode_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPatientLabResultDetailsByTestByDate_Class : TTReportNqlObject 
        {
            public Guid? Labprocobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["LABPROCOBJECTID"]);
                }
            }

            public Guid? Procedureobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDUREOBJECTID"]);
                }
            }

            public string Procedurename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDURENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? ResultDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["RESULTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Result
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["RESULT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Unit
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNIT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["UNIT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Reference
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REFERENCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["REFERENCE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public LaboratoryAbnormalFlagsEnum? Panic
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PANIC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["PANIC"].DataType;
                    return (LaboratoryAbnormalFlagsEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GetPatientLabResultDetailsByTestByDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPatientLabResultDetailsByTestByDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPatientLabResultDetailsByTestByDate_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPatientLabResults_Class : TTReportNqlObject 
        {
            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public Guid? Doctorid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DOCTORID"]);
                }
            }

            public string Departmanname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DEPARTMANNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public String Status
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STATUS"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public Guid? Resultid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["RESULTID"]);
                }
            }

            public bool? IsResultSeen
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISRESULTSEEN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["ISRESULTSEEN"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public GetPatientLabResults_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPatientLabResults_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPatientLabResults_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPatientLabResultsDetail_Class : TTReportNqlObject 
        {
            public DateTime? ResultDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["RESULTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Value
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["VALUE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["RESULT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Unit
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNIT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["UNIT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Minmaxvalue
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MINMAXVALUE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["REFERENCE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetPatientLabResultsDetail_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPatientLabResultsDetail_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPatientLabResultsDetail_Class() : base() { }
        }

        [Serializable] 

        public partial class Get_HumanAlbuminTestAndResultBySubepisode_Class : TTReportNqlObject 
        {
            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public string Result
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["RESULT"].DataType;
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

            public Get_HumanAlbuminTestAndResultBySubepisode_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public Get_HumanAlbuminTestAndResultBySubepisode_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected Get_HumanAlbuminTestAndResultBySubepisode_Class() : base() { }
        }

        [Serializable] 

        public partial class GetCountLabProcedureBySampleTakingStateByDate_Class : TTReportNqlObject 
        {
            public Object Sampletakingtestcount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["SAMPLETAKINGTESTCOUNT"]);
                }
            }

            public GetCountLabProcedureBySampleTakingStateByDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetCountLabProcedureBySampleTakingStateByDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetCountLabProcedureBySampleTakingStateByDate_Class() : base() { }
        }

        [Serializable] 

        public partial class GetCountLabProcedureByCreationDate_Class : TTReportNqlObject 
        {
            public Object Requestedtestcount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["REQUESTEDTESTCOUNT"]);
                }
            }

            public GetCountLabProcedureByCreationDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetCountLabProcedureByCreationDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetCountLabProcedureByCreationDate_Class() : base() { }
        }

        [Serializable] 

        public partial class GetLabProcedureByPatientByWorklistDate_Class : TTReportNqlObject 
        {
            public Guid? Patient
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PATIENT"]);
                }
            }

            public Object Nqlcolumn
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["NQLCOLUMN"]);
                }
            }

            public GetLabProcedureByPatientByWorklistDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetLabProcedureByPatientByWorklistDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetLabProcedureByPatientByWorklistDate_Class() : base() { }
        }

        [Serializable] 

        public partial class GetCompletedLabResultsByPatient_Class : TTReportNqlObject 
        {
            public Guid? Labprocobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["LABPROCOBJECTID"]);
                }
            }

            public Guid? Procedureobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDUREOBJECTID"]);
                }
            }

            public string Procedurename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDURENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? ResultDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["RESULTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Result
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["RESULT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Unit
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNIT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["UNIT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Reference
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REFERENCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["REFERENCE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public LaboratoryAbnormalFlagsEnum? Panic
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PANIC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["PANIC"].DataType;
                    return (LaboratoryAbnormalFlagsEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? IsResultSeen
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISRESULTSEEN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["ISRESULTSEEN"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public GetCompletedLabResultsByPatient_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetCompletedLabResultsByPatient_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetCompletedLabResultsByPatient_Class() : base() { }
        }

        [Serializable] 

        public partial class GetAntibiogramTestResultByEpisode_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? ResultDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["RESULTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Result
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["RESULT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ResultDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULTDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].AllPropertyDefs["RESULTDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetAntibiogramTestResultByEpisode_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAntibiogramTestResultByEpisode_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAntibiogramTestResultByEpisode_Class() : base() { }
        }

        new public static class States
        {
            public static Guid Cancelled { get { return new Guid("fc30e081-5b67-4564-99fd-17f75e57a1b2"); } }
            public static Guid SampleAccept { get { return new Guid("5eaf4c46-c99e-491c-a880-37d07484437e"); } }
            public static Guid Procedure { get { return new Guid("481dd196-b418-4114-b4f7-becd7e7703c4"); } }
            public static Guid SampleLaboratoryAccept { get { return new Guid("e3b32262-fba4-4255-9a0f-c34c1ad78973"); } }
    /// <summary>
    /// Sonuçlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("a52a30e0-6ac7-4224-aa58-a994397c22f6"); } }
            public static Guid New { get { return new Guid("39f72a84-86a8-469f-89f7-fc99300daf78"); } }
    /// <summary>
    /// Uzman Onayı Bekliyor
    /// </summary>
            public static Guid Approve { get { return new Guid("4ec1ba21-422f-4b75-9769-cf46961171eb"); } }
            public static Guid PendingCancel { get { return new Guid("63ecd567-19fc-4e0b-b790-9e3802a93ed7"); } }
            public static Guid SampleReject { get { return new Guid("71d49852-7f5d-440e-af57-7e70522fb867"); } }
    /// <summary>
    /// Numune Alma
    /// </summary>
            public static Guid SampleTaking { get { return new Guid("5b6b040c-cea8-4d4f-96d7-f394c9b28f87"); } }
        }

        public static BindingList<LaboratoryProcedure> GetLabTestsByPatientByDate(TTObjectContext objectContext, string PATIENTID, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GetLabTestsByPatientByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTID", PATIENTID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<LaboratoryProcedure>(queryDef, paramList);
        }

        public static BindingList<LaboratoryProcedure.OLAP_GetLabProcedure_Class> OLAP_GetLabProcedure(DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["OLAP_GetLabProcedure"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<LaboratoryProcedure.OLAP_GetLabProcedure_Class>(queryDef, paramList, pi);
        }

        public static BindingList<LaboratoryProcedure.OLAP_GetLabProcedure_Class> OLAP_GetLabProcedure(TTObjectContext objectContext, DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["OLAP_GetLabProcedure"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<LaboratoryProcedure.OLAP_GetLabProcedure_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<LaboratoryProcedure> GetLabTestByPatient(TTObjectContext objectContext, string PATIENTID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GetLabTestByPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTID", PATIENTID);

            return ((ITTQuery)objectContext).QueryObjects<LaboratoryProcedure>(queryDef, paramList);
        }

        public static BindingList<LaboratoryProcedure> GetLabTestByPatientByTestByDate(TTObjectContext objectContext, string PATIENTID, string TESTID, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GetLabTestByPatientByTestByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTID", PATIENTID);
            paramList.Add("TESTID", TESTID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<LaboratoryProcedure>(queryDef, paramList);
        }

        public static BindingList<LaboratoryProcedure.LaboratoryProcedureReportNQL_Class> LaboratoryProcedureReportNQL(string PARAMOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["LaboratoryProcedureReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJID", PARAMOBJID);

            return TTReportNqlObject.QueryObjects<LaboratoryProcedure.LaboratoryProcedureReportNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<LaboratoryProcedure.LaboratoryProcedureReportNQL_Class> LaboratoryProcedureReportNQL(TTObjectContext objectContext, string PARAMOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["LaboratoryProcedureReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJID", PARAMOBJID);

            return TTReportNqlObject.QueryObjects<LaboratoryProcedure.LaboratoryProcedureReportNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<LaboratoryProcedure> GetLaboratoryProcedureForLaboratoryAccept(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GetLaboratoryProcedureForLaboratoryAccept"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<LaboratoryProcedure>(queryDef, paramList);
        }

        public static BindingList<LaboratoryProcedure.GetLabProcedureByBarcodeId_Class> GetLabProcedureByBarcodeId(long BARCODEID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GetLabProcedureByBarcodeId"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("BARCODEID", BARCODEID);

            return TTReportNqlObject.QueryObjects<LaboratoryProcedure.GetLabProcedureByBarcodeId_Class>(queryDef, paramList, pi);
        }

        public static BindingList<LaboratoryProcedure.GetLabProcedureByBarcodeId_Class> GetLabProcedureByBarcodeId(TTObjectContext objectContext, long BARCODEID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GetLabProcedureByBarcodeId"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("BARCODEID", BARCODEID);

            return TTReportNqlObject.QueryObjects<LaboratoryProcedure.GetLabProcedureByBarcodeId_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<LaboratoryProcedure> GetLabResults(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GetLabResults"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<LaboratoryProcedure>(queryDef, paramList, injectionSQL);
        }

    /// <summary>
    /// KKDS için kullanılıyor Order By değeri önemli
    /// </summary>
        public static BindingList<LaboratoryProcedure.GetProcedureSuggestionsByEpisode_Class> GetProcedureSuggestionsByEpisode(Guid EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GetProcedureSuggestionsByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<LaboratoryProcedure.GetProcedureSuggestionsByEpisode_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// KKDS için kullanılıyor Order By değeri önemli
    /// </summary>
        public static BindingList<LaboratoryProcedure.GetProcedureSuggestionsByEpisode_Class> GetProcedureSuggestionsByEpisode(TTObjectContext objectContext, Guid EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GetProcedureSuggestionsByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<LaboratoryProcedure.GetProcedureSuggestionsByEpisode_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<LaboratoryProcedure.OLAP_GetCancelledLabProcedure_Class> OLAP_GetCancelledLabProcedure(DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["OLAP_GetCancelledLabProcedure"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<LaboratoryProcedure.OLAP_GetCancelledLabProcedure_Class>(queryDef, paramList, pi);
        }

        public static BindingList<LaboratoryProcedure.OLAP_GetCancelledLabProcedure_Class> OLAP_GetCancelledLabProcedure(TTObjectContext objectContext, DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["OLAP_GetCancelledLabProcedure"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<LaboratoryProcedure.OLAP_GetCancelledLabProcedure_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<LaboratoryProcedure.GetLaboratoryResultsBySubepisodeId_Class> GetLaboratoryResultsBySubepisodeId(string SUBEPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GetLaboratoryResultsBySubepisodeId"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);

            return TTReportNqlObject.QueryObjects<LaboratoryProcedure.GetLaboratoryResultsBySubepisodeId_Class>(queryDef, paramList, pi);
        }

        public static BindingList<LaboratoryProcedure.GetLaboratoryResultsBySubepisodeId_Class> GetLaboratoryResultsBySubepisodeId(TTObjectContext objectContext, string SUBEPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GetLaboratoryResultsBySubepisodeId"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);

            return TTReportNqlObject.QueryObjects<LaboratoryProcedure.GetLaboratoryResultsBySubepisodeId_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<LaboratoryProcedure.GetLaboratoryProcedureByEpisode_Class> GetLaboratoryProcedureByEpisode(Guid EPISODE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GetLaboratoryProcedureByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<LaboratoryProcedure.GetLaboratoryProcedureByEpisode_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<LaboratoryProcedure.GetLaboratoryProcedureByEpisode_Class> GetLaboratoryProcedureByEpisode(TTObjectContext objectContext, Guid EPISODE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GetLaboratoryProcedureByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<LaboratoryProcedure.GetLaboratoryProcedureByEpisode_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<LaboratoryProcedure.GetLabProcByPatientByTestByDate_Class> GetLabProcByPatientByTestByDate(string PATIENTID, string TESTID, DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GetLabProcByPatientByTestByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTID", PATIENTID);
            paramList.Add("TESTID", TESTID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<LaboratoryProcedure.GetLabProcByPatientByTestByDate_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<LaboratoryProcedure.GetLabProcByPatientByTestByDate_Class> GetLabProcByPatientByTestByDate(TTObjectContext objectContext, string PATIENTID, string TESTID, DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GetLabProcByPatientByTestByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTID", PATIENTID);
            paramList.Add("TESTID", TESTID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<LaboratoryProcedure.GetLabProcByPatientByTestByDate_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<LaboratoryProcedure> GetLabProceduresBySubEpisode(TTObjectContext objectContext, Guid SUBEPISODE, Guid EPISODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GetLabProceduresBySubEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);
            paramList.Add("EPISODE", EPISODE);

            return ((ITTQuery)objectContext).QueryObjects<LaboratoryProcedure>(queryDef, paramList);
        }

        public static BindingList<LaboratoryProcedure.GetLaboratoryProcedureBySubEpisode_Class> GetLaboratoryProcedureBySubEpisode(string SUBEPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GetLaboratoryProcedureBySubEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);

            return TTReportNqlObject.QueryObjects<LaboratoryProcedure.GetLaboratoryProcedureBySubEpisode_Class>(queryDef, paramList, pi);
        }

        public static BindingList<LaboratoryProcedure.GetLaboratoryProcedureBySubEpisode_Class> GetLaboratoryProcedureBySubEpisode(TTObjectContext objectContext, string SUBEPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GetLaboratoryProcedureBySubEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);

            return TTReportNqlObject.QueryObjects<LaboratoryProcedure.GetLaboratoryProcedureBySubEpisode_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<LaboratoryProcedure.GetLabProcedureByTestAndRequest_Class> GetLabProcedureByTestAndRequest(Guid PARAMOBJID, Guid TEST, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GetLabProcedureByTestAndRequest"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJID", PARAMOBJID);
            paramList.Add("TEST", TEST);

            return TTReportNqlObject.QueryObjects<LaboratoryProcedure.GetLabProcedureByTestAndRequest_Class>(queryDef, paramList, pi);
        }

        public static BindingList<LaboratoryProcedure.GetLabProcedureByTestAndRequest_Class> GetLabProcedureByTestAndRequest(TTObjectContext objectContext, Guid PARAMOBJID, Guid TEST, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GetLabProcedureByTestAndRequest"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJID", PARAMOBJID);
            paramList.Add("TEST", TEST);

            return TTReportNqlObject.QueryObjects<LaboratoryProcedure.GetLabProcedureByTestAndRequest_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<LaboratoryProcedure> GetLabProceduresByEpisode(TTObjectContext objectContext, Guid EPISODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GetLabProceduresByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return ((ITTQuery)objectContext).QueryObjects<LaboratoryProcedure>(queryDef, paramList);
        }

        public static BindingList<LaboratoryProcedure.GetLabProcedureByTabAndRequest_Class> GetLabProcedureByTabAndRequest(Guid PARAMOBJID, Guid TAB, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GetLabProcedureByTabAndRequest"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJID", PARAMOBJID);
            paramList.Add("TAB", TAB);

            return TTReportNqlObject.QueryObjects<LaboratoryProcedure.GetLabProcedureByTabAndRequest_Class>(queryDef, paramList, pi);
        }

        public static BindingList<LaboratoryProcedure.GetLabProcedureByTabAndRequest_Class> GetLabProcedureByTabAndRequest(TTObjectContext objectContext, Guid PARAMOBJID, Guid TAB, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GetLabProcedureByTabAndRequest"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJID", PARAMOBJID);
            paramList.Add("TAB", TAB);

            return TTReportNqlObject.QueryObjects<LaboratoryProcedure.GetLabProcedureByTabAndRequest_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<LaboratoryProcedure.GetRejectedLaboratoryProceduresByDate_Class> GetRejectedLaboratoryProceduresByDate(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GetRejectedLaboratoryProceduresByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<LaboratoryProcedure.GetRejectedLaboratoryProceduresByDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<LaboratoryProcedure.GetRejectedLaboratoryProceduresByDate_Class> GetRejectedLaboratoryProceduresByDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GetRejectedLaboratoryProceduresByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<LaboratoryProcedure.GetRejectedLaboratoryProceduresByDate_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<LaboratoryProcedure.GetLabProcedureByFilter_Class> GetLabProcedureByFilter(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GetLabProcedureByFilter"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<LaboratoryProcedure.GetLabProcedureByFilter_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<LaboratoryProcedure.GetLabProcedureByFilter_Class> GetLabProcedureByFilter(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GetLabProcedureByFilter"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<LaboratoryProcedure.GetLabProcedureByFilter_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<LaboratoryProcedure> GetLabTestsByPatientForGraph(TTObjectContext objectContext, Guid PATIENT, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GetLabTestsByPatientForGraph"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<LaboratoryProcedure>(queryDef, paramList);
        }

        public static BindingList<LaboratoryProcedure.GetOnlyApprovedProcedures_Class> GetOnlyApprovedProcedures(string PARAMOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GetOnlyApprovedProcedures"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJID", PARAMOBJID);

            return TTReportNqlObject.QueryObjects<LaboratoryProcedure.GetOnlyApprovedProcedures_Class>(queryDef, paramList, pi);
        }

        public static BindingList<LaboratoryProcedure.GetOnlyApprovedProcedures_Class> GetOnlyApprovedProcedures(TTObjectContext objectContext, string PARAMOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GetOnlyApprovedProcedures"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJID", PARAMOBJID);

            return TTReportNqlObject.QueryObjects<LaboratoryProcedure.GetOnlyApprovedProcedures_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<LaboratoryProcedure.GetLabProcedureByRequestTab_Class> GetLabProcedureByRequestTab(Guid REQUESTTAB, Guid PATIENT, DateTime WORKLISTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GetLabProcedureByRequestTab"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("REQUESTTAB", REQUESTTAB);
            paramList.Add("PATIENT", PATIENT);
            paramList.Add("WORKLISTDATE", WORKLISTDATE);

            return TTReportNqlObject.QueryObjects<LaboratoryProcedure.GetLabProcedureByRequestTab_Class>(queryDef, paramList, pi);
        }

        public static BindingList<LaboratoryProcedure.GetLabProcedureByRequestTab_Class> GetLabProcedureByRequestTab(TTObjectContext objectContext, Guid REQUESTTAB, Guid PATIENT, DateTime WORKLISTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GetLabProcedureByRequestTab"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("REQUESTTAB", REQUESTTAB);
            paramList.Add("PATIENT", PATIENT);
            paramList.Add("WORKLISTDATE", WORKLISTDATE);

            return TTReportNqlObject.QueryObjects<LaboratoryProcedure.GetLabProcedureByRequestTab_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<LaboratoryProcedure.GunSonu_GS31DegeriDusukIslemler_Class> GunSonu_GS31DegeriDusukIslemler(IList<string> SUTKODU, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GunSonu_GS31DegeriDusukIslemler"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUTKODU", SUTKODU);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<LaboratoryProcedure.GunSonu_GS31DegeriDusukIslemler_Class>(queryDef, paramList, pi);
        }

        public static BindingList<LaboratoryProcedure.GunSonu_GS31DegeriDusukIslemler_Class> GunSonu_GS31DegeriDusukIslemler(TTObjectContext objectContext, IList<string> SUTKODU, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GunSonu_GS31DegeriDusukIslemler"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUTKODU", SUTKODU);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<LaboratoryProcedure.GunSonu_GS31DegeriDusukIslemler_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Hasta Geçmişi laboratuar Sonuçları
    /// </summary>
        public static BindingList<LaboratoryProcedure.GetOldInfoForLaboratory_Class> GetOldInfoForLaboratory(Guid PATIENTID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GetOldInfoForLaboratory"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTID", PATIENTID);

            return TTReportNqlObject.QueryObjects<LaboratoryProcedure.GetOldInfoForLaboratory_Class>(queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Hasta Geçmişi laboratuar Sonuçları
    /// </summary>
        public static BindingList<LaboratoryProcedure.GetOldInfoForLaboratory_Class> GetOldInfoForLaboratory(TTObjectContext objectContext, Guid PATIENTID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GetOldInfoForLaboratory"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTID", PATIENTID);

            return TTReportNqlObject.QueryObjects<LaboratoryProcedure.GetOldInfoForLaboratory_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Hasta Geçmişi Laboratuvar Sonuç Sayısı
    /// </summary>
        public static BindingList<LaboratoryProcedure.GetOldInfoCountLaboratory_Class> GetOldInfoCountLaboratory(Guid PATIENTID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GetOldInfoCountLaboratory"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTID", PATIENTID);

            return TTReportNqlObject.QueryObjects<LaboratoryProcedure.GetOldInfoCountLaboratory_Class>(queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Hasta Geçmişi Laboratuvar Sonuç Sayısı
    /// </summary>
        public static BindingList<LaboratoryProcedure.GetOldInfoCountLaboratory_Class> GetOldInfoCountLaboratory(TTObjectContext objectContext, Guid PATIENTID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GetOldInfoCountLaboratory"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTID", PATIENTID);

            return TTReportNqlObject.QueryObjects<LaboratoryProcedure.GetOldInfoCountLaboratory_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<LaboratoryProcedure.GetLabProcedureByWorklistDate_Class> GetLabProcedureByWorklistDate(DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GetLabProcedureByWorklistDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<LaboratoryProcedure.GetLabProcedureByWorklistDate_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<LaboratoryProcedure.GetLabProcedureByWorklistDate_Class> GetLabProcedureByWorklistDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GetLabProcedureByWorklistDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<LaboratoryProcedure.GetLabProcedureByWorklistDate_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<LaboratoryProcedure.GetLabProcedureForDietByEpisodeId_Class> GetLabProcedureForDietByEpisodeId(Guid EPISODE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GetLabProcedureForDietByEpisodeId"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<LaboratoryProcedure.GetLabProcedureForDietByEpisodeId_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<LaboratoryProcedure.GetLabProcedureForDietByEpisodeId_Class> GetLabProcedureForDietByEpisodeId(TTObjectContext objectContext, Guid EPISODE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GetLabProcedureForDietByEpisodeId"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<LaboratoryProcedure.GetLabProcedureForDietByEpisodeId_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<LaboratoryProcedure.GetLaboratoryProcedureByEpisodeByWorkListDate_Class> GetLaboratoryProcedureByEpisodeByWorkListDate(Guid EPISODE, DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GetLaboratoryProcedureByEpisodeByWorkListDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<LaboratoryProcedure.GetLaboratoryProcedureByEpisodeByWorkListDate_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<LaboratoryProcedure.GetLaboratoryProcedureByEpisodeByWorkListDate_Class> GetLaboratoryProcedureByEpisodeByWorkListDate(TTObjectContext objectContext, Guid EPISODE, DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GetLaboratoryProcedureByEpisodeByWorkListDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<LaboratoryProcedure.GetLaboratoryProcedureByEpisodeByWorkListDate_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<LaboratoryProcedure.GetLabResultByEpisodeByTestByDate_Class> GetLabResultByEpisodeByTestByDate(DateTime STARTDATE, DateTime ENDDATE, string TESTID, string EPISODEID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GetLabResultByEpisodeByTestByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("TESTID", TESTID);
            paramList.Add("EPISODEID", EPISODEID);

            return TTReportNqlObject.QueryObjects<LaboratoryProcedure.GetLabResultByEpisodeByTestByDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<LaboratoryProcedure.GetLabResultByEpisodeByTestByDate_Class> GetLabResultByEpisodeByTestByDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, string TESTID, string EPISODEID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GetLabResultByEpisodeByTestByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("TESTID", TESTID);
            paramList.Add("EPISODEID", EPISODEID);

            return TTReportNqlObject.QueryObjects<LaboratoryProcedure.GetLabResultByEpisodeByTestByDate_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<LaboratoryProcedure> GetLaboratoryProcedureByEpisodeNQL(TTObjectContext objectContext, Guid EPISODE, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GetLaboratoryProcedureByEpisodeNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return ((ITTQuery)objectContext).QueryObjects<LaboratoryProcedure>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<LaboratoryProcedure> GetLaboratoryProcedureByEpisodeByWorkListDateNQL(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, Guid EPISODE, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GetLaboratoryProcedureByEpisodeByWorkListDateNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("EPISODE", EPISODE);

            return ((ITTQuery)objectContext).QueryObjects<LaboratoryProcedure>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<LaboratoryProcedure.GetLabProcedureGroupBySpecimenId_Class> GetLabProcedureGroupBySpecimenId(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GetLabProcedureGroupBySpecimenId"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<LaboratoryProcedure.GetLabProcedureGroupBySpecimenId_Class>(queryDef, paramList, pi);
        }

        public static BindingList<LaboratoryProcedure.GetLabProcedureGroupBySpecimenId_Class> GetLabProcedureGroupBySpecimenId(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GetLabProcedureGroupBySpecimenId"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<LaboratoryProcedure.GetLabProcedureGroupBySpecimenId_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<LaboratoryProcedure.GunSonu_GS53SonuclanmisLaboratuvarSayisi_Class> GunSonu_GS53SonuclanmisLaboratuvarSayisi(DateTime STARTDATE, DateTime ENDDATE, IList<string> SUTKODU, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GunSonu_GS53SonuclanmisLaboratuvarSayisi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("SUTKODU", SUTKODU);

            return TTReportNqlObject.QueryObjects<LaboratoryProcedure.GunSonu_GS53SonuclanmisLaboratuvarSayisi_Class>(queryDef, paramList, pi);
        }

        public static BindingList<LaboratoryProcedure.GunSonu_GS53SonuclanmisLaboratuvarSayisi_Class> GunSonu_GS53SonuclanmisLaboratuvarSayisi(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, IList<string> SUTKODU, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GunSonu_GS53SonuclanmisLaboratuvarSayisi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("SUTKODU", SUTKODU);

            return TTReportNqlObject.QueryObjects<LaboratoryProcedure.GunSonu_GS53SonuclanmisLaboratuvarSayisi_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<LaboratoryProcedure.GunSonu_GS67PSADegeriYuksekHastaSayisi_Class> GunSonu_GS67PSADegeriYuksekHastaSayisi(DateTime STARTDATE, DateTime ENDDATE, IList<string> SUTKODU, IList<string> ICDKODU, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GunSonu_GS67PSADegeriYuksekHastaSayisi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("SUTKODU", SUTKODU);
            paramList.Add("ICDKODU", ICDKODU);

            return TTReportNqlObject.QueryObjects<LaboratoryProcedure.GunSonu_GS67PSADegeriYuksekHastaSayisi_Class>(queryDef, paramList, pi);
        }

        public static BindingList<LaboratoryProcedure.GunSonu_GS67PSADegeriYuksekHastaSayisi_Class> GunSonu_GS67PSADegeriYuksekHastaSayisi(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, IList<string> SUTKODU, IList<string> ICDKODU, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GunSonu_GS67PSADegeriYuksekHastaSayisi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("SUTKODU", SUTKODU);
            paramList.Add("ICDKODU", ICDKODU);

            return TTReportNqlObject.QueryObjects<LaboratoryProcedure.GunSonu_GS67PSADegeriYuksekHastaSayisi_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<LaboratoryProcedure.GunSonu_GS25HbA1cSonucDegerineGoreIslemSayisi_Class> GunSonu_GS25HbA1cSonucDegerineGoreIslemSayisi(IList<string> SUTKODU, DateTime STARTDATE, DateTime ENDDATE, string SUBTESTSUTKODU, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GunSonu_GS25HbA1cSonucDegerineGoreIslemSayisi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUTKODU", SUTKODU);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("SUBTESTSUTKODU", SUBTESTSUTKODU);

            return TTReportNqlObject.QueryObjects<LaboratoryProcedure.GunSonu_GS25HbA1cSonucDegerineGoreIslemSayisi_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<LaboratoryProcedure.GunSonu_GS25HbA1cSonucDegerineGoreIslemSayisi_Class> GunSonu_GS25HbA1cSonucDegerineGoreIslemSayisi(TTObjectContext objectContext, IList<string> SUTKODU, DateTime STARTDATE, DateTime ENDDATE, string SUBTESTSUTKODU, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GunSonu_GS25HbA1cSonucDegerineGoreIslemSayisi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUTKODU", SUTKODU);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("SUBTESTSUTKODU", SUBTESTSUTKODU);

            return TTReportNqlObject.QueryObjects<LaboratoryProcedure.GunSonu_GS25HbA1cSonucDegerineGoreIslemSayisi_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<LaboratoryProcedure.GetPatientSubEpisodesByPatient_Class> GetPatientSubEpisodesByPatient(string PATIENTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GetPatientSubEpisodesByPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTID", PATIENTID);

            return TTReportNqlObject.QueryObjects<LaboratoryProcedure.GetPatientSubEpisodesByPatient_Class>(queryDef, paramList, pi);
        }

        public static BindingList<LaboratoryProcedure.GetPatientSubEpisodesByPatient_Class> GetPatientSubEpisodesByPatient(TTObjectContext objectContext, string PATIENTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GetPatientSubEpisodesByPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTID", PATIENTID);

            return TTReportNqlObject.QueryObjects<LaboratoryProcedure.GetPatientSubEpisodesByPatient_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<LaboratoryProcedure.GetPatientLabResultDetailsByPatientBySubEpisode_Class> GetPatientLabResultDetailsByPatientBySubEpisode(string SUBEPISODEID, string PATIENTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GetPatientLabResultDetailsByPatientBySubEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODEID", SUBEPISODEID);
            paramList.Add("PATIENTID", PATIENTID);

            return TTReportNqlObject.QueryObjects<LaboratoryProcedure.GetPatientLabResultDetailsByPatientBySubEpisode_Class>(queryDef, paramList, pi);
        }

        public static BindingList<LaboratoryProcedure.GetPatientLabResultDetailsByPatientBySubEpisode_Class> GetPatientLabResultDetailsByPatientBySubEpisode(TTObjectContext objectContext, string SUBEPISODEID, string PATIENTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GetPatientLabResultDetailsByPatientBySubEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODEID", SUBEPISODEID);
            paramList.Add("PATIENTID", PATIENTID);

            return TTReportNqlObject.QueryObjects<LaboratoryProcedure.GetPatientLabResultDetailsByPatientBySubEpisode_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<LaboratoryProcedure.GetPatientLabResultDetailsByTestByDate_Class> GetPatientLabResultDetailsByTestByDate(string SUBEPISODEID, string TESTID, DateTime ENDDATE, string PATIENTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GetPatientLabResultDetailsByTestByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODEID", SUBEPISODEID);
            paramList.Add("TESTID", TESTID);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PATIENTID", PATIENTID);

            return TTReportNqlObject.QueryObjects<LaboratoryProcedure.GetPatientLabResultDetailsByTestByDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<LaboratoryProcedure.GetPatientLabResultDetailsByTestByDate_Class> GetPatientLabResultDetailsByTestByDate(TTObjectContext objectContext, string SUBEPISODEID, string TESTID, DateTime ENDDATE, string PATIENTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GetPatientLabResultDetailsByTestByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODEID", SUBEPISODEID);
            paramList.Add("TESTID", TESTID);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PATIENTID", PATIENTID);

            return TTReportNqlObject.QueryObjects<LaboratoryProcedure.GetPatientLabResultDetailsByTestByDate_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<LaboratoryProcedure> GetLabProcedureBySpecimenId(TTObjectContext objectContext, long SPECIMENID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GetLabProcedureBySpecimenId"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SPECIMENID", SPECIMENID);

            return ((ITTQuery)objectContext).QueryObjects<LaboratoryProcedure>(queryDef, paramList);
        }

        public static BindingList<LaboratoryProcedure> GetLaboratoryProcedureBySpecimenIdForWorkList(TTObjectContext objectContext, string SPECIMENID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GetLaboratoryProcedureBySpecimenIdForWorkList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SPECIMENID", SPECIMENID);

            return ((ITTQuery)objectContext).QueryObjects<LaboratoryProcedure>(queryDef, paramList);
        }

        public static BindingList<LaboratoryProcedure.GetPatientLabResults_Class> GetPatientLabResults(string PATIENTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GetPatientLabResults"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTID", PATIENTID);

            return TTReportNqlObject.QueryObjects<LaboratoryProcedure.GetPatientLabResults_Class>(queryDef, paramList, pi);
        }

        public static BindingList<LaboratoryProcedure.GetPatientLabResults_Class> GetPatientLabResults(TTObjectContext objectContext, string PATIENTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GetPatientLabResults"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTID", PATIENTID);

            return TTReportNqlObject.QueryObjects<LaboratoryProcedure.GetPatientLabResults_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<LaboratoryProcedure.GetPatientLabResultsDetail_Class> GetPatientLabResultsDetail(string RESULTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GetPatientLabResultsDetail"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("RESULTID", RESULTID);

            return TTReportNqlObject.QueryObjects<LaboratoryProcedure.GetPatientLabResultsDetail_Class>(queryDef, paramList, pi);
        }

        public static BindingList<LaboratoryProcedure.GetPatientLabResultsDetail_Class> GetPatientLabResultsDetail(TTObjectContext objectContext, string RESULTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GetPatientLabResultsDetail"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("RESULTID", RESULTID);

            return TTReportNqlObject.QueryObjects<LaboratoryProcedure.GetPatientLabResultsDetail_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<LaboratoryProcedure> GetOldInfoForLaboratoryByPatient(TTObjectContext objectContext, string PATIENTID, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GetOldInfoForLaboratoryByPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTID", PATIENTID);

            return ((ITTQuery)objectContext).QueryObjects<LaboratoryProcedure>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<LaboratoryProcedure.Get_HumanAlbuminTestAndResultBySubepisode_Class> Get_HumanAlbuminTestAndResultBySubepisode(string SUBEPISODE, string SUTCODE, int DAY, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["Get_HumanAlbuminTestAndResultBySubepisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);
            paramList.Add("SUTCODE", SUTCODE);
            paramList.Add("DAY", DAY);

            return TTReportNqlObject.QueryObjects<LaboratoryProcedure.Get_HumanAlbuminTestAndResultBySubepisode_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<LaboratoryProcedure.Get_HumanAlbuminTestAndResultBySubepisode_Class> Get_HumanAlbuminTestAndResultBySubepisode(TTObjectContext objectContext, string SUBEPISODE, string SUTCODE, int DAY, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["Get_HumanAlbuminTestAndResultBySubepisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);
            paramList.Add("SUTCODE", SUTCODE);
            paramList.Add("DAY", DAY);

            return TTReportNqlObject.QueryObjects<LaboratoryProcedure.Get_HumanAlbuminTestAndResultBySubepisode_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<LaboratoryProcedure.GetCountLabProcedureBySampleTakingStateByDate_Class> GetCountLabProcedureBySampleTakingStateByDate(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GetCountLabProcedureBySampleTakingStateByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<LaboratoryProcedure.GetCountLabProcedureBySampleTakingStateByDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<LaboratoryProcedure.GetCountLabProcedureBySampleTakingStateByDate_Class> GetCountLabProcedureBySampleTakingStateByDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GetCountLabProcedureBySampleTakingStateByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<LaboratoryProcedure.GetCountLabProcedureBySampleTakingStateByDate_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<LaboratoryProcedure.GetCountLabProcedureByCreationDate_Class> GetCountLabProcedureByCreationDate(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GetCountLabProcedureByCreationDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<LaboratoryProcedure.GetCountLabProcedureByCreationDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<LaboratoryProcedure.GetCountLabProcedureByCreationDate_Class> GetCountLabProcedureByCreationDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GetCountLabProcedureByCreationDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<LaboratoryProcedure.GetCountLabProcedureByCreationDate_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<LaboratoryProcedure.GetLabProcedureByPatientByWorklistDate_Class> GetLabProcedureByPatientByWorklistDate(DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GetLabProcedureByPatientByWorklistDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<LaboratoryProcedure.GetLabProcedureByPatientByWorklistDate_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<LaboratoryProcedure.GetLabProcedureByPatientByWorklistDate_Class> GetLabProcedureByPatientByWorklistDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GetLabProcedureByPatientByWorklistDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<LaboratoryProcedure.GetLabProcedureByPatientByWorklistDate_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<LaboratoryProcedure> GetLaboratoryProcedureByPatientByWorkListDateNQL(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, string PATIENTID, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GetLaboratoryProcedureByPatientByWorkListDateNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PATIENTID", PATIENTID);

            return ((ITTQuery)objectContext).QueryObjects<LaboratoryProcedure>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<LaboratoryProcedure> GetLaboratoryProcedureByPatientNQL(TTObjectContext objectContext, string PATIENTOBJID, DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GetLaboratoryProcedureByPatientNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTOBJID", PATIENTOBJID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<LaboratoryProcedure>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<LaboratoryProcedure> GetLaboratoryProcedureByEpisodeAction(TTObjectContext objectContext, Guid EPISODEACTION)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GetLaboratoryProcedureByEpisodeAction"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEACTION", EPISODEACTION);

            return ((ITTQuery)objectContext).QueryObjects<LaboratoryProcedure>(queryDef, paramList);
        }

        public static BindingList<LaboratoryProcedure.GetCompletedLabResultsByPatient_Class> GetCompletedLabResultsByPatient(string PATIENTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GetCompletedLabResultsByPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTID", PATIENTID);

            return TTReportNqlObject.QueryObjects<LaboratoryProcedure.GetCompletedLabResultsByPatient_Class>(queryDef, paramList, pi);
        }

        public static BindingList<LaboratoryProcedure.GetCompletedLabResultsByPatient_Class> GetCompletedLabResultsByPatient(TTObjectContext objectContext, string PATIENTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GetCompletedLabResultsByPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTID", PATIENTID);

            return TTReportNqlObject.QueryObjects<LaboratoryProcedure.GetCompletedLabResultsByPatient_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<LaboratoryProcedure> GetLabProcedureByBarcodeId_OQ(TTObjectContext objectContext, string BARCODEID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GetLabProcedureByBarcodeId_OQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("BARCODEID", BARCODEID);

            return ((ITTQuery)objectContext).QueryObjects<LaboratoryProcedure>(queryDef, paramList);
        }
        
        public static BindingList<LaboratoryProcedure.GetAntibiogramTestResultByEpisode_Class> GetAntibiogramTestResultByEpisode(string EPISODE, string SUTCODE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GetAntibiogramTestResultByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);
            paramList.Add("SUTCODE", SUTCODE);

            return TTReportNqlObject.QueryObjects<LaboratoryProcedure.GetAntibiogramTestResultByEpisode_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<LaboratoryProcedure.GetAntibiogramTestResultByEpisode_Class> GetAntibiogramTestResultByEpisode(TTObjectContext objectContext, string EPISODE, string SUTCODE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURE"].QueryDefs["GetAntibiogramTestResultByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);
            paramList.Add("SUTCODE", SUTCODE);

            return TTReportNqlObject.QueryObjects<LaboratoryProcedure.GetAntibiogramTestResultByEpisode_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Teknisyen Onay Tarihi
    /// </summary>
        public DateTime? TechnicianApproveDate
        {
            get { return (DateTime?)this["TECHNICIANAPPROVEDATE"]; }
            set { this["TECHNICIANAPPROVEDATE"] = value; }
        }

    /// <summary>
    /// Referans
    /// </summary>
        public string Reference
        {
            get { return (string)this["REFERENCE"]; }
            set { this["REFERENCE"] = value; }
        }

    /// <summary>
    /// Sapma Uyarısı
    /// </summary>
        public HighLowEnum? Warning
        {
            get { return (HighLowEnum?)(int?)this["WARNING"]; }
            set { this["WARNING"] = value; }
        }

    /// <summary>
    /// Sonuç
    /// </summary>
        public string Result
        {
            get { return (string)this["RESULT"]; }
            set { this["RESULT"] = value; }
        }

    /// <summary>
    /// Seç
    /// </summary>
        public bool? Check
        {
            get { return (bool?)this["CHECK"]; }
            set { this["CHECK"] = value; }
        }

    /// <summary>
    /// Açıklama Girilecek Alan
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Teknisyen ID
    /// </summary>
        public string TechnicianID
        {
            get { return (string)this["TECHNICIANID"]; }
            set { this["TECHNICIANID"] = value; }
        }

        public string OwnerType
        {
            get { return (string)this["OWNERTYPE"]; }
            set { this["OWNERTYPE"] = value; }
        }

    /// <summary>
    /// Birim
    /// </summary>
        public string Unit
        {
            get { return (string)this["UNIT"]; }
            set { this["UNIT"] = value; }
        }

    /// <summary>
    /// Barkod Numarası
    /// </summary>
        public long? BarcodeId
        {
            get { return (long?)this["BARCODEID"]; }
            set { this["BARCODEID"] = value; }
        }

    /// <summary>
    /// Antibiyogram
    /// </summary>
        public bool? IsAntibiogram
        {
            get { return (bool?)this["ISANTIBIOGRAM"]; }
            set { this["ISANTIBIOGRAM"] = value; }
        }

    /// <summary>
    /// Sonuç Tarihi
    /// </summary>
        public DateTime? ResultDate
        {
            get { return (DateTime?)this["RESULTDATE"]; }
            set { this["RESULTDATE"] = value; }
        }

    /// <summary>
    /// Uzun Rapor
    /// </summary>
        public object LongReport
        {
            get { return (object)this["LONGREPORT"]; }
            set { this["LONGREPORT"] = value; }
        }

    /// <summary>
    /// Microbiology Panic Notification
    /// </summary>
        public bool? MicrobiologyPanicNotification
        {
            get { return (bool?)this["MICROBIOLOGYPANICNOTIFICATION"]; }
            set { this["MICROBIOLOGYPANICNOTIFICATION"] = value; }
        }

    /// <summary>
    /// Panik Değer Uyarısı
    /// </summary>
        public LaboratoryAbnormalFlagsEnum? Panic
        {
            get { return (LaboratoryAbnormalFlagsEnum?)(int?)this["PANIC"]; }
            set { this["PANIC"] = value; }
        }

        public string TestGroup
        {
            get { return (string)this["TESTGROUP"]; }
            set { this["TESTGROUP"] = value; }
        }

        public string Environment
        {
            get { return (string)this["ENVIRONMENT"]; }
            set { this["ENVIRONMENT"] = value; }
        }

    /// <summary>
    /// Anestezi yapan doktorun diploma tescil numarası.
    /// </summary>
        public string drAnesteziTescilNo
        {
            get { return (string)this["DRANESTEZITESCILNO"]; }
            set { this["DRANESTEZITESCILNO"] = value; }
        }

    /// <summary>
    /// Laboratuvara İlk Kabul Tarihi Alanıdır
    /// </summary>
        public DateTime? AcceptDate
        {
            get { return (DateTime?)this["ACCEPTDATE"]; }
            set { this["ACCEPTDATE"] = value; }
        }

    /// <summary>
    /// Test Sonucunun Onay Tarihi
    /// </summary>
        public DateTime? ApproveDate
        {
            get { return (DateTime?)this["APPROVEDATE"]; }
            set { this["APPROVEDATE"] = value; }
        }

    /// <summary>
    /// Test İşleminin Tarihi
    /// </summary>
        public DateTime? ProcedureDate
        {
            get { return (DateTime?)this["PROCEDUREDATE"]; }
            set { this["PROCEDUREDATE"] = value; }
        }

    /// <summary>
    /// Sonuç Açıklaması
    /// </summary>
        public string ResultDescription
        {
            get { return (string)this["RESULTDESCRIPTION"]; }
            set { this["RESULTDESCRIPTION"] = value; }
        }

    /// <summary>
    /// İşlem Notu Alanıdır
    /// </summary>
        public string ProcessNote
        {
            get { return (string)this["PROCESSNOTE"]; }
            set { this["PROCESSNOTE"] = value; }
        }

    /// <summary>
    /// Rapor
    /// </summary>
        public object Report
        {
            get { return (object)this["REPORT"]; }
            set { this["REPORT"] = value; }
        }

    /// <summary>
    /// İsteğin Yapıldığı Tarihi Alanı
    /// </summary>
        public DateTime? RequestDate
        {
            get { return (DateTime?)this["REQUESTDATE"]; }
            set { this["REQUESTDATE"] = value; }
        }

    /// <summary>
    /// İstek Yapılırken Gerekli Bilgiler İçin Not Alanı
    /// </summary>
        public string RequestNote
        {
            get { return (string)this["REQUESTNOTE"]; }
            set { this["REQUESTNOTE"] = value; }
        }

    /// <summary>
    /// Numune Kabul Tarihi
    /// </summary>
        public DateTime? SampleAcceptionDate
        {
            get { return (DateTime?)this["SAMPLEACCEPTIONDATE"]; }
            set { this["SAMPLEACCEPTIONDATE"] = value; }
        }

    /// <summary>
    /// Numunenin Alınma Tarihi Girilir
    /// </summary>
        public DateTime? SampleDate
        {
            get { return (DateTime?)this["SAMPLEDATE"]; }
            set { this["SAMPLEDATE"] = value; }
        }

    /// <summary>
    /// Referans Aralığı
    /// </summary>
        public object SpecialReference
        {
            get { return (object)this["SPECIALREFERENCE"]; }
            set { this["SPECIALREFERENCE"] = value; }
        }

    /// <summary>
    /// Teknisyenin Not Gireceği Alandır
    /// </summary>
        public string Techniciannote
        {
            get { return (string)this["TECHNICIANNOTE"]; }
            set { this["TECHNICIANNOTE"] = value; }
        }

    /// <summary>
    /// Remote Gönderilen Test'in ID'sini Saklar
    /// </summary>
        public Guid? TestDefID
        {
            get { return (Guid?)this["TESTDEFID"]; }
            set { this["TESTDEFID"] = value; }
        }

    /// <summary>
    /// Sonuç görüntülendi ise True olacak.
    /// </summary>
        public bool? IsResultSeen
        {
            get { return (bool?)this["ISRESULTSEEN"]; }
            set { this["ISRESULTSEEN"] = value; }
        }

    /// <summary>
    /// Örnek Numarası
    /// </summary>
        public long? SpecimenId
        {
            get { return (long?)this["SPECIMENID"]; }
            set { this["SPECIMENID"] = value; }
        }

    /// <summary>
    /// Barkod Basma Tarihi
    /// </summary>
        public DateTime? BarcodePrintDate
        {
            get { return (DateTime?)this["BARCODEPRINTDATE"]; }
            set { this["BARCODEPRINTDATE"] = value; }
        }

    /// <summary>
    /// Testin Çalışılacağı Bölüm İlişkisi
    /// </summary>
        public ResLaboratoryDepartment Department
        {
            get { return (ResLaboratoryDepartment)((ITTObject)this).GetParent("DEPARTMENT"); }
            set { this["DEPARTMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Ana Test Tanımı İlişkisi
    /// </summary>
        public LaboratoryTestDefinition MasterTestDef
        {
            get { return (LaboratoryTestDefinition)((ITTObject)this).GetParent("MASTERTESTDEF"); }
            set { this["MASTERTESTDEF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public LaboratoryProcedureTubeInfo TubeInformation
        {
            get { return (LaboratoryProcedureTubeInfo)((ITTObject)this).GetParent("TUBEINFORMATION"); }
            set { this["TUBEINFORMATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Numuneyi Kabul Eden Kullanıcı Bilgisinin İlişkisi
    /// </summary>
        public ResUser AcceptUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("ACCEPTUSER"); }
            set { this["ACCEPTUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İşlemin Bölümü İlişkisi
    /// </summary>
        public Resource ProcedureDepartment
        {
            get { return (Resource)((ITTObject)this).GetParent("PROCEDUREDEPARTMENT"); }
            set { this["PROCEDUREDEPARTMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Test İşlemini Yapan Kullanıcı İlişkisi
    /// </summary>
        public ResUser ProcedureUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("PROCEDUREUSER"); }
            set { this["PROCEDUREUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Numuneyi Test İçin Kabul Eden Kaynak İlişkisi
    /// </summary>
        public Resource AcceptResource
        {
            get { return (Resource)((ITTObject)this).GetParent("ACCEPTRESOURCE"); }
            set { this["ACCEPTRESOURCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Testin Çalışılacağı Cihaz ile olan İlişkisi
    /// </summary>
        public ResLaboratoryEquipment Equipment
        {
            get { return (ResLaboratoryEquipment)((ITTObject)this).GetParent("EQUIPMENT"); }
            set { this["EQUIPMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public LaboratoryRequestFormTabDefinition RequestedTab
        {
            get { return (LaboratoryRequestFormTabDefinition)((ITTObject)this).GetParent("REQUESTEDTAB"); }
            set { this["REQUESTEDTAB"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// LabProcedure AyniFarkliKesi
    /// </summary>
        public AyniFarkliKesi AyniFarkliKesi
        {
            get { return (AyniFarkliKesi)((ITTObject)this).GetParent("AYNIFARKLIKESI"); }
            set { this["AYNIFARKLIKESI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// LabProcedure SagSol
    /// </summary>
        public SagSol SagSol
        {
            get { return (SagSol)((ITTObject)this).GetParent("SAGSOL"); }
            set { this["SAGSOL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Örnek Red Nedenlerini Tutar
    /// </summary>
        public LaboratoryRejectReasonDefinition SampleRejectionReason
        {
            get { return (LaboratoryRejectReasonDefinition)((ITTObject)this).GetParent("SAMPLEREJECTIONREASON"); }
            set { this["SAMPLEREJECTIONREASON"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResUser AnesteziDoktor
        {
            get { return (ResUser)((ITTObject)this).GetParent("ANESTEZIDOKTOR"); }
            set { this["ANESTEZIDOKTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// LaboratoryProcedure OzelDurum
    /// </summary>
        public OzelDurum OzelDurum
        {
            get { return (OzelDurum)((ITTObject)this).GetParent("OZELDURUM"); }
            set { this["OZELDURUM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// NumuneyiReddedenKullanıcı
    /// </summary>
        public ResUser UserOfSampleRejection
        {
            get { return (ResUser)((ITTObject)this).GetParent("USEROFSAMPLEREJECTION"); }
            set { this["USEROFSAMPLEREJECTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Test İsteğini Yapan Kaynak İlişkisi
    /// </summary>
        public Resource RequestResource
        {
            get { return (Resource)((ITTObject)this).GetParent("REQUESTRESOURCE"); }
            set { this["REQUESTRESOURCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İstek Yapan Kullanıcı İlişkisi
    /// </summary>
        public ResUser RequestUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("REQUESTUSER"); }
            set { this["REQUESTUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Örnek Kaynak İlişkisi
    /// </summary>
        public Resource SampleResource
        {
            get { return (Resource)((ITTObject)this).GetParent("SAMPLERESOURCE"); }
            set { this["SAMPLERESOURCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Örnek Alan Kullanıcı İlişkisi
    /// </summary>
        public ResUser SampleUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("SAMPLEUSER"); }
            set { this["SAMPLEUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Testi Onaylayan Kullanıcı Bilgisi
    /// </summary>
        public ResUser ApproveUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("APPROVEUSER"); }
            set { this["APPROVEUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// MasterResource
    /// </summary>
        public ResObservationUnit ResObservationUnit
        {
            get 
            {   
                if (MasterResource is ResObservationUnit)
                    return (ResObservationUnit)MasterResource; 
                return null;
            }            
            set { MasterResource = value; }
        }

        public LaboratoryRequest Laboratory
        {
            get 
            {   
                if (EpisodeAction is LaboratoryRequest)
                    return (LaboratoryRequest)EpisodeAction; 
                return null;
            }            
            set { EpisodeAction = value; }
        }

    /// <summary>
    /// İşlem
    /// </summary>
        public LaboratoryTestDefinition LaboratoryTestProcedureObject
        {
            get 
            {   
                if (ProcedureObject is LaboratoryTestDefinition)
                    return (LaboratoryTestDefinition)ProcedureObject; 
                return null;
            }            
            set { ProcedureObject = value; }
        }

        virtual protected void CreateLaboratoryProcedureResultsCollection()
        {
            _LaboratoryProcedureResults = new LaboratoryProcedureResult.ChildLaboratoryProcedureResultCollection(this, new Guid("a1c06758-c317-47ed-b4b6-0c10ef866cf5"));
            ((ITTChildObjectCollection)_LaboratoryProcedureResults).GetChildren();
        }

        protected LaboratoryProcedureResult.ChildLaboratoryProcedureResultCollection _LaboratoryProcedureResults = null;
        public LaboratoryProcedureResult.ChildLaboratoryProcedureResultCollection LaboratoryProcedureResults
        {
            get
            {
                if (_LaboratoryProcedureResults == null)
                    CreateLaboratoryProcedureResultsCollection();
                return _LaboratoryProcedureResults;
            }
        }

        virtual protected void CreateMaterialsCollection()
        {
            _Materials = new LaboratoryMaterial.ChildLaboratoryMaterialCollection(this, new Guid("f77ddc6c-0a40-4df6-a800-552aec700ae4"));
            ((ITTChildObjectCollection)_Materials).GetChildren();
        }

        protected LaboratoryMaterial.ChildLaboratoryMaterialCollection _Materials = null;
    /// <summary>
    /// Child collection for Laboratuvar İşlemi İlişkisi
    /// </summary>
        public LaboratoryMaterial.ChildLaboratoryMaterialCollection Materials
        {
            get
            {
                if (_Materials == null)
                    CreateMaterialsCollection();
                return _Materials;
            }
        }

        virtual protected void CreateCokluOzelDurumCollection()
        {
            _CokluOzelDurum = new CokluOzelDurum.ChildCokluOzelDurumCollection(this, new Guid("4527b0e4-c6ca-48a1-b860-d91a1a46052a"));
            ((ITTChildObjectCollection)_CokluOzelDurum).GetChildren();
        }

        protected CokluOzelDurum.ChildCokluOzelDurumCollection _CokluOzelDurum = null;
    /// <summary>
    /// Child collection for Laboratory Procedure Çoklu Özel Durum
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

        override protected void CreateChildSubActionProcedureCollectionViews()
        {
            base.CreateChildSubActionProcedureCollectionViews();
            _LaboratorySubProcedures = new LaboratorySubProcedure.ChildLaboratorySubProcedureCollection(_ChildSubActionProcedure, "LaboratorySubProcedures");
        }

        private LaboratorySubProcedure.ChildLaboratorySubProcedureCollection _LaboratorySubProcedures = null;
        public LaboratorySubProcedure.ChildLaboratorySubProcedureCollection LaboratorySubProcedures
        {
            get
            {
                if (_ChildSubActionProcedure == null)
                    CreateChildSubActionProcedureCollection();
                return _LaboratorySubProcedures;
            }            
        }

        protected LaboratoryProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected LaboratoryProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected LaboratoryProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected LaboratoryProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected LaboratoryProcedure(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "LABORATORYPROCEDURE", dataRow) { }
        protected LaboratoryProcedure(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "LABORATORYPROCEDURE", dataRow, isImported) { }
        public LaboratoryProcedure(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public LaboratoryProcedure(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public LaboratoryProcedure() : base() { }

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