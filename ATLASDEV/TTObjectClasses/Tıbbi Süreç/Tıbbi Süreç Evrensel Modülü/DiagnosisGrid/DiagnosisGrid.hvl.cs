
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DiagnosisGrid")] 

    /// <summary>
    /// Tanı Gridi
    /// </summary>
    public  partial class DiagnosisGrid : TTObject, ISUTInstance
    {
        public class DiagnosisGridList : TTObjectCollection<DiagnosisGrid> { }
                    
        public class ChildDiagnosisGridCollection : TTObject.TTChildObjectCollection<DiagnosisGrid>
        {
            public ChildDiagnosisGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDiagnosisGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetDiagnosisByParent_Class : TTReportNqlObject 
        {
            public bool? Ozgecmiseekle
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OZGECMISEEKLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].AllPropertyDefs["ADDTOHISTORY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DiagnosisTypeEnum? Tanitipi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TANITIPI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].AllPropertyDefs["DIAGNOSISTYPE"].DataType;
                    return (DiagnosisTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Taniadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TANIADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Tanikodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TANIKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Serbesttani
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SERBESTTANI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].AllPropertyDefs["FREEDIAGNOSIS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetDiagnosisByParent_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDiagnosisByParent_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDiagnosisByParent_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDiagnosisByEpisode_Class : TTReportNqlObject 
        {
            public Guid? Diagnose
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DIAGNOSE"]);
                }
            }

            public DiagnosisTypeEnum? DiagnosisType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIAGNOSISTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].AllPropertyDefs["DIAGNOSISTYPE"].DataType;
                    return (DiagnosisTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string DiagnosisDefinition
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIAGNOSISDEFINITION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].AllPropertyDefs["DIAGNOSISDEFINITION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Diagnosedate
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DIAGNOSEDATE"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Freediagnosis
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["FREEDIAGNOSIS"]);
                }
            }

            public GetDiagnosisByEpisode_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDiagnosisByEpisode_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDiagnosisByEpisode_Class() : base() { }
        }

        [Serializable] 

        public partial class GetSecDiagnosisByEpisodeAction_Class : TTReportNqlObject 
        {
            public bool? AddToHistory
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADDTOHISTORY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].AllPropertyDefs["ADDTOHISTORY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? DiagnoseDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIAGNOSEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].AllPropertyDefs["DIAGNOSEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DiagnosisTypeEnum? DiagnosisType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIAGNOSISTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].AllPropertyDefs["DIAGNOSISTYPE"].DataType;
                    return (DiagnosisTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? IsMainDiagnose
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISMAINDIAGNOSE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].AllPropertyDefs["ISMAINDIAGNOSE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Diagnosename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIAGNOSENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string FreeDiagnosis
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FREEDIAGNOSIS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].AllPropertyDefs["FREEDIAGNOSIS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetSecDiagnosisByEpisodeAction_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSecDiagnosisByEpisodeAction_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSecDiagnosisByEpisodeAction_Class() : base() { }
        }

        [Serializable] 

        public partial class GetSecDiagnosisBySubactionProcedure_Class : TTReportNqlObject 
        {
            public bool? AddToHistory
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADDTOHISTORY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].AllPropertyDefs["ADDTOHISTORY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? DiagnoseDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIAGNOSEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].AllPropertyDefs["DIAGNOSEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DiagnosisTypeEnum? DiagnosisType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIAGNOSISTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].AllPropertyDefs["DIAGNOSISTYPE"].DataType;
                    return (DiagnosisTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? IsMainDiagnose
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISMAINDIAGNOSE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].AllPropertyDefs["ISMAINDIAGNOSE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Diagnosename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIAGNOSENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string FreeDiagnosis
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FREEDIAGNOSIS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].AllPropertyDefs["FREEDIAGNOSIS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetSecDiagnosisBySubactionProcedure_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSecDiagnosisBySubactionProcedure_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSecDiagnosisBySubactionProcedure_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPreDiagnosisByEpisodeAction_Class : TTReportNqlObject 
        {
            public bool? AddToHistory
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADDTOHISTORY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].AllPropertyDefs["ADDTOHISTORY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? DiagnoseDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIAGNOSEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].AllPropertyDefs["DIAGNOSEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DiagnosisTypeEnum? DiagnosisType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIAGNOSISTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].AllPropertyDefs["DIAGNOSISTYPE"].DataType;
                    return (DiagnosisTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? IsMainDiagnose
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISMAINDIAGNOSE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].AllPropertyDefs["ISMAINDIAGNOSE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Diagnosename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIAGNOSENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string FreeDiagnosis
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FREEDIAGNOSIS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].AllPropertyDefs["FREEDIAGNOSIS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetPreDiagnosisByEpisodeAction_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPreDiagnosisByEpisodeAction_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPreDiagnosisByEpisodeAction_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPreDiagnosisBySubactionProcedure_Class : TTReportNqlObject 
        {
            public bool? AddToHistory
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADDTOHISTORY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].AllPropertyDefs["ADDTOHISTORY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? DiagnoseDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIAGNOSEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].AllPropertyDefs["DIAGNOSEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DiagnosisTypeEnum? DiagnosisType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIAGNOSISTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].AllPropertyDefs["DIAGNOSISTYPE"].DataType;
                    return (DiagnosisTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? IsMainDiagnose
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISMAINDIAGNOSE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].AllPropertyDefs["ISMAINDIAGNOSE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Diagnosename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIAGNOSENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetPreDiagnosisBySubactionProcedure_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPreDiagnosisBySubactionProcedure_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPreDiagnosisBySubactionProcedure_Class() : base() { }
        }

        [Serializable] 

        public partial class getDiagnosisJustBySubepisode_Class : TTReportNqlObject 
        {
            public Object Kayit_id
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["KAYIT_ID"]);
                }
            }

            public Guid? Vizit_id
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["VIZIT_ID"]);
                }
            }

            public DateTime? Tarih
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TARIH"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].AllPropertyDefs["DIAGNOSEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Icd10_kodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ICD10_KODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Idc10_deger
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["IDC10_DEGER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? Anatanimi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ANATANIMI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].AllPropertyDefs["ISMAINDIAGNOSE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
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

            public getDiagnosisJustBySubepisode_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public getDiagnosisJustBySubepisode_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected getDiagnosisJustBySubepisode_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDiagnosisBySubEpisode_Class : TTReportNqlObject 
        {
            public Guid? Diagnose
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DIAGNOSE"]);
                }
            }

            public DiagnosisTypeEnum? DiagnosisType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIAGNOSISTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].AllPropertyDefs["DIAGNOSISTYPE"].DataType;
                    return (DiagnosisTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public Object Diagnosedate
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DIAGNOSEDATE"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Freediagnosis
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["FREEDIAGNOSIS"]);
                }
            }

            public GetDiagnosisBySubEpisode_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDiagnosisBySubEpisode_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDiagnosisBySubEpisode_Class() : base() { }
        }

        [Serializable] 

        public partial class GetInfectiousDiagnosisByDate_Class : TTReportNqlObject 
        {
            public Object Tanitarihi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TANITARIHI"]);
                }
            }

            public Object Nqlcolumn
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["NQLCOLUMN"]);
                }
            }

            public Guid? Episode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODE"]);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["CODE"].DataType;
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

            public GetInfectiousDiagnosisByDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetInfectiousDiagnosisByDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetInfectiousDiagnosisByDate_Class() : base() { }
        }

        [Serializable] 

        public partial class GetTop10DiagnosisDefinitionOfUser_Class : TTReportNqlObject 
        {
            public Guid? Diagnoseobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DIAGNOSEOBJECTID"]);
                }
            }

            public Object Diagnosename
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DIAGNOSENAME"]);
                }
            }

            public Object Nqlcolumn
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["NQLCOLUMN"]);
                }
            }

            public GetTop10DiagnosisDefinitionOfUser_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetTop10DiagnosisDefinitionOfUser_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetTop10DiagnosisDefinitionOfUser_Class() : base() { }
        }

        [Serializable] 

        public partial class GetSeconderDiagnosisByEpisode_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public DiagnosisTypeEnum? DiagnosisType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIAGNOSISTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].AllPropertyDefs["DIAGNOSISTYPE"].DataType;
                    return (DiagnosisTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public DateTime? DiagnoseDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIAGNOSEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].AllPropertyDefs["DIAGNOSEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string FreeDiagnosis
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FREEDIAGNOSIS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].AllPropertyDefs["FREEDIAGNOSIS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetSeconderDiagnosisByEpisode_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSeconderDiagnosisByEpisode_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSeconderDiagnosisByEpisode_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDiagnoseByDate_Class : TTReportNqlObject 
        {
            public Guid? Diagnoseid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DIAGNOSEID"]);
                }
            }

            public string Diagnosename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIAGNOSENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public Guid? Responsibleuserid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["RESPONSIBLEUSERID"]);
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

            public DateTime? DiagnoseDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIAGNOSEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].AllPropertyDefs["DIAGNOSEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? Masterresourceid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MASTERRESOURCEID"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public double? Fkimlikno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FKIMLIKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["FOREIGNUNIQUEREFNO"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public Object Patientphone
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTPHONE"]);
                }
            }

            public Guid? Episodeid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODEID"]);
                }
            }

            public GetDiagnoseByDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDiagnoseByDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDiagnoseByDate_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMainDiagnosisByEpisode_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public DiagnosisTypeEnum? DiagnosisType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIAGNOSISTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].AllPropertyDefs["DIAGNOSISTYPE"].DataType;
                    return (DiagnosisTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public DateTime? DiagnoseDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIAGNOSEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].AllPropertyDefs["DIAGNOSEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string FreeDiagnosis
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FREEDIAGNOSIS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].AllPropertyDefs["FREEDIAGNOSIS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetMainDiagnosisByEpisode_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMainDiagnosisByEpisode_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMainDiagnosisByEpisode_Class() : base() { }
        }

        [Serializable] 

        public partial class GetLast10DiagnosisOfPatient_Class : TTReportNqlObject 
        {
            public Guid? Diagnoseobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DIAGNOSEOBJECTID"]);
                }
            }

            public Object Diagnosename
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DIAGNOSENAME"]);
                }
            }

            public string FreeDiagnosis
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FREEDIAGNOSIS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].AllPropertyDefs["FREEDIAGNOSIS"].DataType;
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

            public GetLast10DiagnosisOfPatient_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetLast10DiagnosisOfPatient_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetLast10DiagnosisOfPatient_Class() : base() { }
        }

        [Serializable] 

        public partial class GetLast10DiagnosisOfUser_Class : TTReportNqlObject 
        {
            public Guid? Diagnoseobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DIAGNOSEOBJECTID"]);
                }
            }

            public Object Diagnosename
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DIAGNOSENAME"]);
                }
            }

            public string FreeDiagnosis
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FREEDIAGNOSIS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].AllPropertyDefs["FREEDIAGNOSIS"].DataType;
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

            public GetLast10DiagnosisOfUser_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetLast10DiagnosisOfUser_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetLast10DiagnosisOfUser_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDiagnosisByDateInterval_Class : TTReportNqlObject 
        {
            public Guid? Diagnoseid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DIAGNOSEID"]);
                }
            }

            public string Diagnosename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIAGNOSENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public Guid? Responsibleuserid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["RESPONSIBLEUSERID"]);
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

            public DateTime? DiagnoseDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIAGNOSEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].AllPropertyDefs["DIAGNOSEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? Masterresourceid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MASTERRESOURCEID"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public double? Fkimlikno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FKIMLIKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["FOREIGNUNIQUEREFNO"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public Object Patientphone
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTPHONE"]);
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

            public Guid? Episodeid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODEID"]);
                }
            }

            public GetDiagnosisByDateInterval_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDiagnosisByDateInterval_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDiagnosisByDateInterval_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDiagnoseAndPatientByEpisode_Class : TTReportNqlObject 
        {
            public Guid? Diagnose
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DIAGNOSE"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["CODE"].DataType;
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

            public double? Yabancisicilno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["YABANCISICILNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["FOREIGNUNIQUEREFNO"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public bool? Yabancimi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["YABANCIMI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["FOREIGN"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OpeningDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OPENINGDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["OPENINGDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Object Birthdate
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["BIRTHDATE"]);
                }
            }

            public Object Il
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["IL"]);
                }
            }

            public Object Ilce
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ILCE"]);
                }
            }

            public string Name1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME1"]);
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

            public PatientStatusEnum? Ayaktanyatan
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AYAKTANYATAN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["PATIENTSTATUS"].DataType;
                    return (PatientStatusEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GetDiagnoseAndPatientByEpisode_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDiagnoseAndPatientByEpisode_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDiagnoseAndPatientByEpisode_Class() : base() { }
        }

        [Serializable] 

        public partial class VEM_BASVURU_TANI_Class : TTReportNqlObject 
        {
            public Guid? Basvuru_tani_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["BASVURU_TANI_KODU"]);
                }
            }

            public Object Referans_tablo_adi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["REFERANS_TABLO_ADI"]);
                }
            }

            public Guid? Hasta_basvuru_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["HASTA_BASVURU_KODU"]);
                }
            }

            public Guid? Tani_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["TANI_KODU"]);
                }
            }

            public DiagnosisTypeEnum? Tani_tipi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TANI_TIPI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].AllPropertyDefs["DIAGNOSISTYPE"].DataType;
                    return (DiagnosisTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? Birincil_tani
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIRINCIL_TANI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].AllPropertyDefs["ISMAINDIAGNOSE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Tani_zamani
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TANI_ZAMANI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].AllPropertyDefs["DIAGNOSEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? Hekim_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["HEKIM_KODU"]);
                }
            }

            public Object Recete_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["RECETE_KODU"]);
                }
            }

            public Object Hasta_sevk_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["HASTA_SEVK_KODU"]);
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

            public VEM_BASVURU_TANI_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public VEM_BASVURU_TANI_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected VEM_BASVURU_TANI_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDiagnosisByEpisodeAndDiagnose_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? Diagnose
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DIAGNOSE"]);
                }
            }

            public GetDiagnosisByEpisodeAndDiagnose_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDiagnosisByEpisodeAndDiagnose_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDiagnosisByEpisodeAndDiagnose_Class() : base() { }
        }

        [Serializable] 

        public partial class GetOldInfoForDiagnosis_Class : TTReportNqlObject 
        {
            public Guid? Diagnoseobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DIAGNOSEOBJECTID"]);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Diagnosename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIAGNOSENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string FreeDiagnosis
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FREEDIAGNOSIS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].AllPropertyDefs["FREEDIAGNOSIS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? DiagnoseDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIAGNOSEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].AllPropertyDefs["DIAGNOSEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? IsMainDiagnose
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISMAINDIAGNOSE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].AllPropertyDefs["ISMAINDIAGNOSE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DiagnosisTypeEnum? Diagnosetype
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIAGNOSETYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].AllPropertyDefs["DIAGNOSISTYPE"].DataType;
                    return (DiagnosisTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Speciality
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPECIALITY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public ActionTypeEnum? Entrytype
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENTRYTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].AllPropertyDefs["ENTRYACTIONTYPE"].DataType;
                    return (ActionTypeEnum?)(int)dataType.ConvertValue(val);
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

            public string Username
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetOldInfoForDiagnosis_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOldInfoForDiagnosis_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOldInfoForDiagnosis_Class() : base() { }
        }

        [Serializable] 

        public partial class GetOldInfoCountForDiagnosis_Class : TTReportNqlObject 
        {
            public Object Nqlcolumn
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["NQLCOLUMN"]);
                }
            }

            public GetOldInfoCountForDiagnosis_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOldInfoCountForDiagnosis_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOldInfoCountForDiagnosis_Class() : base() { }
        }

        [Serializable] 

        public partial class dene_Class : TTReportNqlObject 
        {
            public Guid? Diagnoseobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DIAGNOSEOBJECTID"]);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Diagnosename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIAGNOSENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string FreeDiagnosis
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FREEDIAGNOSIS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].AllPropertyDefs["FREEDIAGNOSIS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? DiagnoseDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIAGNOSEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].AllPropertyDefs["DIAGNOSEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? IsMainDiagnose
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISMAINDIAGNOSE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].AllPropertyDefs["ISMAINDIAGNOSE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DiagnosisTypeEnum? Diagnosetype
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIAGNOSETYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].AllPropertyDefs["DIAGNOSISTYPE"].DataType;
                    return (DiagnosisTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Speciality
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPECIALITY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public ActionTypeEnum? Entrytype
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENTRYTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].AllPropertyDefs["ENTRYACTIONTYPE"].DataType;
                    return (ActionTypeEnum?)(int)dataType.ConvertValue(val);
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

            public string Username
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public dene_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public dene_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected dene_Class() : base() { }
        }

        [Serializable] 

        public partial class QueryFatih_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ADI
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSVAKATIPI"].AllPropertyDefs["ADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public QueryFatih_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public QueryFatih_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected QueryFatih_Class() : base() { }
        }

        [Serializable] 

        public partial class GetInfluenzaDiagByEpisode_Class : TTReportNqlObject 
        {
            public Guid? Influenza
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["INFLUENZA"]);
                }
            }

            public GetInfluenzaDiagByEpisode_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetInfluenzaDiagByEpisode_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetInfluenzaDiagByEpisode_Class() : base() { }
        }

        [Serializable] 

        public partial class GetAllJ11DiagnoseByDate_Class : TTReportNqlObject 
        {
            public string Diagnosename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIAGNOSENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public string Sex
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SEX"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSCINSIYET"].AllPropertyDefs["ADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MobilePhone
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MOBILEPHONE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTIDENTITYANDADDRESS"].AllPropertyDefs["MOBILEPHONE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? OpeningDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OPENINGDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["OPENINGDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public string Ressectionname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESSECTIONNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public SubEpisodeStatusEnum? PatientStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["PATIENTSTATUS"].DataType;
                    return (SubEpisodeStatusEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public DateTime? ClinicInpatientDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CLINICINPATIENTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["CLINICINPATIENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ClinicDischargeDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CLINICDISCHARGEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["CLINICDISCHARGEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetAllJ11DiagnoseByDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAllJ11DiagnoseByDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAllJ11DiagnoseByDate_Class() : base() { }
        }

        [Serializable] 

        public partial class GetActionByDiagnose_Class : TTReportNqlObject 
        {
            public Guid? EpisodeAction
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODEACTION"]);
                }
            }

            public GetActionByDiagnose_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetActionByDiagnose_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetActionByDiagnose_Class() : base() { }
        }

        public static BindingList<DiagnosisGrid.GetDiagnosisByParent_Class> GetDiagnosisByParent(string PARENTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].QueryDefs["GetDiagnosisByParent"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARENTOBJECTID", PARENTOBJECTID);

            return TTReportNqlObject.QueryObjects<DiagnosisGrid.GetDiagnosisByParent_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DiagnosisGrid.GetDiagnosisByParent_Class> GetDiagnosisByParent(TTObjectContext objectContext, string PARENTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].QueryDefs["GetDiagnosisByParent"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARENTOBJECTID", PARENTOBJECTID);

            return TTReportNqlObject.QueryObjects<DiagnosisGrid.GetDiagnosisByParent_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DiagnosisGrid.GetDiagnosisByEpisode_Class> GetDiagnosisByEpisode(string EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].QueryDefs["GetDiagnosisByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<DiagnosisGrid.GetDiagnosisByEpisode_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DiagnosisGrid.GetDiagnosisByEpisode_Class> GetDiagnosisByEpisode(TTObjectContext objectContext, string EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].QueryDefs["GetDiagnosisByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<DiagnosisGrid.GetDiagnosisByEpisode_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DiagnosisGrid.GetSecDiagnosisByEpisodeAction_Class> GetSecDiagnosisByEpisodeAction(string EPISODEACTIONID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].QueryDefs["GetSecDiagnosisByEpisodeAction"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEACTIONID", EPISODEACTIONID);

            return TTReportNqlObject.QueryObjects<DiagnosisGrid.GetSecDiagnosisByEpisodeAction_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DiagnosisGrid.GetSecDiagnosisByEpisodeAction_Class> GetSecDiagnosisByEpisodeAction(TTObjectContext objectContext, string EPISODEACTIONID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].QueryDefs["GetSecDiagnosisByEpisodeAction"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEACTIONID", EPISODEACTIONID);

            return TTReportNqlObject.QueryObjects<DiagnosisGrid.GetSecDiagnosisByEpisodeAction_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DiagnosisGrid.GetSecDiagnosisBySubactionProcedure_Class> GetSecDiagnosisBySubactionProcedure(string SUBACTIONPROCEDURE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].QueryDefs["GetSecDiagnosisBySubactionProcedure"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBACTIONPROCEDURE", SUBACTIONPROCEDURE);

            return TTReportNqlObject.QueryObjects<DiagnosisGrid.GetSecDiagnosisBySubactionProcedure_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DiagnosisGrid.GetSecDiagnosisBySubactionProcedure_Class> GetSecDiagnosisBySubactionProcedure(TTObjectContext objectContext, string SUBACTIONPROCEDURE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].QueryDefs["GetSecDiagnosisBySubactionProcedure"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBACTIONPROCEDURE", SUBACTIONPROCEDURE);

            return TTReportNqlObject.QueryObjects<DiagnosisGrid.GetSecDiagnosisBySubactionProcedure_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DiagnosisGrid.GetPreDiagnosisByEpisodeAction_Class> GetPreDiagnosisByEpisodeAction(string EPISODEACTIONID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].QueryDefs["GetPreDiagnosisByEpisodeAction"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEACTIONID", EPISODEACTIONID);

            return TTReportNqlObject.QueryObjects<DiagnosisGrid.GetPreDiagnosisByEpisodeAction_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DiagnosisGrid.GetPreDiagnosisByEpisodeAction_Class> GetPreDiagnosisByEpisodeAction(TTObjectContext objectContext, string EPISODEACTIONID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].QueryDefs["GetPreDiagnosisByEpisodeAction"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEACTIONID", EPISODEACTIONID);

            return TTReportNqlObject.QueryObjects<DiagnosisGrid.GetPreDiagnosisByEpisodeAction_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DiagnosisGrid.GetPreDiagnosisBySubactionProcedure_Class> GetPreDiagnosisBySubactionProcedure(string SUBACTIONPROCEDURE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].QueryDefs["GetPreDiagnosisBySubactionProcedure"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBACTIONPROCEDURE", SUBACTIONPROCEDURE);

            return TTReportNqlObject.QueryObjects<DiagnosisGrid.GetPreDiagnosisBySubactionProcedure_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DiagnosisGrid.GetPreDiagnosisBySubactionProcedure_Class> GetPreDiagnosisBySubactionProcedure(TTObjectContext objectContext, string SUBACTIONPROCEDURE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].QueryDefs["GetPreDiagnosisBySubactionProcedure"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBACTIONPROCEDURE", SUBACTIONPROCEDURE);

            return TTReportNqlObject.QueryObjects<DiagnosisGrid.GetPreDiagnosisBySubactionProcedure_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DiagnosisGrid.getDiagnosisJustBySubepisode_Class> getDiagnosisJustBySubepisode(string SUBEPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].QueryDefs["getDiagnosisJustBySubepisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);

            return TTReportNqlObject.QueryObjects<DiagnosisGrid.getDiagnosisJustBySubepisode_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DiagnosisGrid.getDiagnosisJustBySubepisode_Class> getDiagnosisJustBySubepisode(TTObjectContext objectContext, string SUBEPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].QueryDefs["getDiagnosisJustBySubepisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);

            return TTReportNqlObject.QueryObjects<DiagnosisGrid.getDiagnosisJustBySubepisode_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DiagnosisGrid.GetDiagnosisBySubEpisode_Class> GetDiagnosisBySubEpisode(string SUBEPISODE, string EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].QueryDefs["GetDiagnosisBySubEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<DiagnosisGrid.GetDiagnosisBySubEpisode_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DiagnosisGrid.GetDiagnosisBySubEpisode_Class> GetDiagnosisBySubEpisode(TTObjectContext objectContext, string SUBEPISODE, string EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].QueryDefs["GetDiagnosisBySubEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<DiagnosisGrid.GetDiagnosisBySubEpisode_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DiagnosisGrid.GetInfectiousDiagnosisByDate_Class> GetInfectiousDiagnosisByDate(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].QueryDefs["GetInfectiousDiagnosisByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<DiagnosisGrid.GetInfectiousDiagnosisByDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DiagnosisGrid.GetInfectiousDiagnosisByDate_Class> GetInfectiousDiagnosisByDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].QueryDefs["GetInfectiousDiagnosisByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<DiagnosisGrid.GetInfectiousDiagnosisByDate_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DiagnosisGrid.GetTop10DiagnosisDefinitionOfUser_Class> GetTop10DiagnosisDefinitionOfUser(string USER, DateTime STARTDATE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].QueryDefs["GetTop10DiagnosisDefinitionOfUser"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("USER", USER);
            paramList.Add("STARTDATE", STARTDATE);

            return TTReportNqlObject.QueryObjects<DiagnosisGrid.GetTop10DiagnosisDefinitionOfUser_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DiagnosisGrid.GetTop10DiagnosisDefinitionOfUser_Class> GetTop10DiagnosisDefinitionOfUser(TTObjectContext objectContext, string USER, DateTime STARTDATE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].QueryDefs["GetTop10DiagnosisDefinitionOfUser"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("USER", USER);
            paramList.Add("STARTDATE", STARTDATE);

            return TTReportNqlObject.QueryObjects<DiagnosisGrid.GetTop10DiagnosisDefinitionOfUser_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DiagnosisGrid.GetSeconderDiagnosisByEpisode_Class> GetSeconderDiagnosisByEpisode(string EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].QueryDefs["GetSeconderDiagnosisByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<DiagnosisGrid.GetSeconderDiagnosisByEpisode_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DiagnosisGrid.GetSeconderDiagnosisByEpisode_Class> GetSeconderDiagnosisByEpisode(TTObjectContext objectContext, string EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].QueryDefs["GetSeconderDiagnosisByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<DiagnosisGrid.GetSeconderDiagnosisByEpisode_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DiagnosisGrid.GetDiagnoseByDate_Class> GetDiagnoseByDate(DateTime STARTDATE, DateTime ENDDATE, Guid DIAGNOSE, Guid DOCTOR, Guid MASTERRESOURCE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].QueryDefs["GetDiagnoseByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("DIAGNOSE", DIAGNOSE);
            paramList.Add("DOCTOR", DOCTOR);
            paramList.Add("MASTERRESOURCE", MASTERRESOURCE);

            return TTReportNqlObject.QueryObjects<DiagnosisGrid.GetDiagnoseByDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DiagnosisGrid.GetDiagnoseByDate_Class> GetDiagnoseByDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, Guid DIAGNOSE, Guid DOCTOR, Guid MASTERRESOURCE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].QueryDefs["GetDiagnoseByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("DIAGNOSE", DIAGNOSE);
            paramList.Add("DOCTOR", DOCTOR);
            paramList.Add("MASTERRESOURCE", MASTERRESOURCE);

            return TTReportNqlObject.QueryObjects<DiagnosisGrid.GetDiagnoseByDate_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Episode  un ana tanılarını getirir.
    /// </summary>
        public static BindingList<DiagnosisGrid.GetMainDiagnosisByEpisode_Class> GetMainDiagnosisByEpisode(string EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].QueryDefs["GetMainDiagnosisByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<DiagnosisGrid.GetMainDiagnosisByEpisode_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Episode  un ana tanılarını getirir.
    /// </summary>
        public static BindingList<DiagnosisGrid.GetMainDiagnosisByEpisode_Class> GetMainDiagnosisByEpisode(TTObjectContext objectContext, string EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].QueryDefs["GetMainDiagnosisByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<DiagnosisGrid.GetMainDiagnosisByEpisode_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DiagnosisGrid> GetDiagnosisBySubEpisode_OQ(TTObjectContext objectContext, string SUBEPISODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].QueryDefs["GetDiagnosisBySubEpisode_OQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);

            return ((ITTQuery)objectContext).QueryObjects<DiagnosisGrid>(queryDef, paramList);
        }

        public static BindingList<DiagnosisGrid.GetLast10DiagnosisOfPatient_Class> GetLast10DiagnosisOfPatient(string PATIENT, string SPECIALITY, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].QueryDefs["GetLast10DiagnosisOfPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);
            paramList.Add("SPECIALITY", SPECIALITY);

            return TTReportNqlObject.QueryObjects<DiagnosisGrid.GetLast10DiagnosisOfPatient_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DiagnosisGrid.GetLast10DiagnosisOfPatient_Class> GetLast10DiagnosisOfPatient(TTObjectContext objectContext, string PATIENT, string SPECIALITY, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].QueryDefs["GetLast10DiagnosisOfPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);
            paramList.Add("SPECIALITY", SPECIALITY);

            return TTReportNqlObject.QueryObjects<DiagnosisGrid.GetLast10DiagnosisOfPatient_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DiagnosisGrid.GetLast10DiagnosisOfUser_Class> GetLast10DiagnosisOfUser(string USER, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].QueryDefs["GetLast10DiagnosisOfUser"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("USER", USER);

            return TTReportNqlObject.QueryObjects<DiagnosisGrid.GetLast10DiagnosisOfUser_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DiagnosisGrid.GetLast10DiagnosisOfUser_Class> GetLast10DiagnosisOfUser(TTObjectContext objectContext, string USER, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].QueryDefs["GetLast10DiagnosisOfUser"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("USER", USER);

            return TTReportNqlObject.QueryObjects<DiagnosisGrid.GetLast10DiagnosisOfUser_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DiagnosisGrid.GetDiagnosisByDateInterval_Class> GetDiagnosisByDateInterval(Guid DIAGNOSE, Guid DOCTOR, DateTime ENDDATE, Guid MASTERRESOURCE, DateTime STARTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].QueryDefs["GetDiagnosisByDateInterval"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DIAGNOSE", DIAGNOSE);
            paramList.Add("DOCTOR", DOCTOR);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("MASTERRESOURCE", MASTERRESOURCE);
            paramList.Add("STARTDATE", STARTDATE);

            return TTReportNqlObject.QueryObjects<DiagnosisGrid.GetDiagnosisByDateInterval_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DiagnosisGrid.GetDiagnosisByDateInterval_Class> GetDiagnosisByDateInterval(TTObjectContext objectContext, Guid DIAGNOSE, Guid DOCTOR, DateTime ENDDATE, Guid MASTERRESOURCE, DateTime STARTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].QueryDefs["GetDiagnosisByDateInterval"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DIAGNOSE", DIAGNOSE);
            paramList.Add("DOCTOR", DOCTOR);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("MASTERRESOURCE", MASTERRESOURCE);
            paramList.Add("STARTDATE", STARTDATE);

            return TTReportNqlObject.QueryObjects<DiagnosisGrid.GetDiagnosisByDateInterval_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DiagnosisGrid.GetDiagnoseAndPatientByEpisode_Class> GetDiagnoseAndPatientByEpisode(string EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].QueryDefs["GetDiagnoseAndPatientByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<DiagnosisGrid.GetDiagnoseAndPatientByEpisode_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DiagnosisGrid.GetDiagnoseAndPatientByEpisode_Class> GetDiagnoseAndPatientByEpisode(TTObjectContext objectContext, string EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].QueryDefs["GetDiagnoseAndPatientByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<DiagnosisGrid.GetDiagnoseAndPatientByEpisode_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DiagnosisGrid.VEM_BASVURU_TANI_Class> VEM_BASVURU_TANI(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].QueryDefs["VEM_BASVURU_TANI"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DiagnosisGrid.VEM_BASVURU_TANI_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DiagnosisGrid.VEM_BASVURU_TANI_Class> VEM_BASVURU_TANI(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].QueryDefs["VEM_BASVURU_TANI"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DiagnosisGrid.VEM_BASVURU_TANI_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DiagnosisGrid.GetDiagnosisByEpisodeAndDiagnose_Class> GetDiagnosisByEpisodeAndDiagnose(string EPISODE, string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].QueryDefs["GetDiagnosisByEpisodeAndDiagnose"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<DiagnosisGrid.GetDiagnosisByEpisodeAndDiagnose_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DiagnosisGrid.GetDiagnosisByEpisodeAndDiagnose_Class> GetDiagnosisByEpisodeAndDiagnose(TTObjectContext objectContext, string EPISODE, string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].QueryDefs["GetDiagnosisByEpisodeAndDiagnose"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<DiagnosisGrid.GetDiagnosisByEpisodeAndDiagnose_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DiagnosisGrid.GetOldInfoForDiagnosis_Class> GetOldInfoForDiagnosis(Guid PATIENT, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].QueryDefs["GetOldInfoForDiagnosis"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<DiagnosisGrid.GetOldInfoForDiagnosis_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DiagnosisGrid.GetOldInfoForDiagnosis_Class> GetOldInfoForDiagnosis(TTObjectContext objectContext, Guid PATIENT, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].QueryDefs["GetOldInfoForDiagnosis"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<DiagnosisGrid.GetOldInfoForDiagnosis_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Hasta Geçmiş Tanı Sayısı
    /// </summary>
        public static BindingList<DiagnosisGrid.GetOldInfoCountForDiagnosis_Class> GetOldInfoCountForDiagnosis(Guid PATIENT, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].QueryDefs["GetOldInfoCountForDiagnosis"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<DiagnosisGrid.GetOldInfoCountForDiagnosis_Class>(queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Hasta Geçmiş Tanı Sayısı
    /// </summary>
        public static BindingList<DiagnosisGrid.GetOldInfoCountForDiagnosis_Class> GetOldInfoCountForDiagnosis(TTObjectContext objectContext, Guid PATIENT, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].QueryDefs["GetOldInfoCountForDiagnosis"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<DiagnosisGrid.GetOldInfoCountForDiagnosis_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DiagnosisGrid.dene_Class> dene(Guid PATIENT, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].QueryDefs["dene"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<DiagnosisGrid.dene_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DiagnosisGrid.dene_Class> dene(TTObjectContext objectContext, Guid PATIENT, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].QueryDefs["dene"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<DiagnosisGrid.dene_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DiagnosisGrid.QueryFatih_Class> QueryFatih(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].QueryDefs["QueryFatih"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DiagnosisGrid.QueryFatih_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DiagnosisGrid.QueryFatih_Class> QueryFatih(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].QueryDefs["QueryFatih"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DiagnosisGrid.QueryFatih_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DiagnosisGrid> GetByObjectID(TTObjectContext objectContext, Guid OBJECTID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].QueryDefs["GetByObjectID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return ((ITTQuery)objectContext).QueryObjects<DiagnosisGrid>(queryDef, paramList);
        }

        public static BindingList<DiagnosisGrid.GetInfluenzaDiagByEpisode_Class> GetInfluenzaDiagByEpisode(Guid EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].QueryDefs["GetInfluenzaDiagByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<DiagnosisGrid.GetInfluenzaDiagByEpisode_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DiagnosisGrid.GetInfluenzaDiagByEpisode_Class> GetInfluenzaDiagByEpisode(TTObjectContext objectContext, Guid EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].QueryDefs["GetInfluenzaDiagByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<DiagnosisGrid.GetInfluenzaDiagByEpisode_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DiagnosisGrid> GetBySubEpisode(TTObjectContext objectContext, string SUBEPISODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].QueryDefs["GetBySubEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);

            return ((ITTQuery)objectContext).QueryObjects<DiagnosisGrid>(queryDef, paramList);
        }

    /// <summary>
    /// J11 tanısı girilen hasta listesi
    /// </summary>
        public static BindingList<DiagnosisGrid.GetAllJ11DiagnoseByDate_Class> GetAllJ11DiagnoseByDate(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].QueryDefs["GetAllJ11DiagnoseByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<DiagnosisGrid.GetAllJ11DiagnoseByDate_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// J11 tanısı girilen hasta listesi
    /// </summary>
        public static BindingList<DiagnosisGrid.GetAllJ11DiagnoseByDate_Class> GetAllJ11DiagnoseByDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].QueryDefs["GetAllJ11DiagnoseByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<DiagnosisGrid.GetAllJ11DiagnoseByDate_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Hastaya konulan kanser tanılarını almak için oluşturuldu.
    /// </summary>
        public static BindingList<DiagnosisGrid> GetDiagnoseCancerForOncology(TTObjectContext objectContext, Guid SUBEPISODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].QueryDefs["GetDiagnoseCancerForOncology"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);

            return ((ITTQuery)objectContext).QueryObjects<DiagnosisGrid>(queryDef, paramList);
        }

        public static BindingList<DiagnosisGrid.GetActionByDiagnose_Class> GetActionByDiagnose(Guid DIAGNOSEID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].QueryDefs["GetActionByDiagnose"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DIAGNOSEID", DIAGNOSEID);

            return TTReportNqlObject.QueryObjects<DiagnosisGrid.GetActionByDiagnose_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DiagnosisGrid.GetActionByDiagnose_Class> GetActionByDiagnose(TTObjectContext objectContext, Guid DIAGNOSEID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].QueryDefs["GetActionByDiagnose"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DIAGNOSEID", DIAGNOSEID);

            return TTReportNqlObject.QueryObjects<DiagnosisGrid.GetActionByDiagnose_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Serbest Tanı
    /// </summary>
        public string FreeDiagnosis
        {
            get { return (string)this["FREEDIAGNOSIS"]; }
            set { this["FREEDIAGNOSIS"] = value; }
        }

    /// <summary>
    /// Tanı Giriş Tarihi  
    /// </summary>
        public DateTime? DiagnoseDate
        {
            get { return (DateTime?)this["DIAGNOSEDATE"]; }
            set { this["DIAGNOSEDATE"] = value; }
        }

    /// <summary>
    /// Tanı Tipi
    /// </summary>
        public DiagnosisTypeEnum? DiagnosisType
        {
            get { return (DiagnosisTypeEnum?)(int?)this["DIAGNOSISTYPE"]; }
            set { this["DIAGNOSISTYPE"] = value; }
        }

    /// <summary>
    /// Tanın Girildiği İşlem
    /// </summary>
        public ActionTypeEnum? EntryActionType
        {
            get { return (ActionTypeEnum?)(int?)this["ENTRYACTIONTYPE"]; }
            set { this["ENTRYACTIONTYPE"] = value; }
        }

    /// <summary>
    /// Özgeçmişe Ekle
    /// </summary>
        public bool? AddToHistory
        {
            get { return (bool?)this["ADDTOHISTORY"]; }
            set { this["ADDTOHISTORY"] = value; }
        }

    /// <summary>
    /// Hastalığın Başladığı Tarih
    /// </summary>
        public DateTime? StartTimeOfInfectious
        {
            get { return (DateTime?)this["STARTTIMEOFINFECTIOUS"]; }
            set { this["STARTTIMEOFINFECTIOUS"] = value; }
        }

    /// <summary>
    /// Tanı Açıklaması
    /// </summary>
        public string DiagnosisDefinition
        {
            get { return (string)this["DIAGNOSISDEFINITION"]; }
            set { this["DIAGNOSISDEFINITION"] = value; }
        }

    /// <summary>
    /// Tüm Teşhisler
    /// </summary>
        public bool? AllDiagnosisDefTeshis
        {
            get { return (bool?)this["ALLDIAGNOSISDEFTESHIS"]; }
            set { this["ALLDIAGNOSISDEFTESHIS"] = value; }
        }

    /// <summary>
    /// Tanının ICD10 kodu
    /// </summary>
        public string taniKodu
        {
            get { return (string)this["TANIKODU"]; }
            set { this["TANIKODU"] = value; }
        }

    /// <summary>
    /// Ana Tanı
    /// </summary>
        public bool? IsMainDiagnose
        {
            get { return (bool?)this["ISMAINDIAGNOSE"]; }
            set { this["ISMAINDIAGNOSE"] = value; }
        }

    /// <summary>
    /// Veri tabanında hep false olmalı . SubEpisode relationı koparmak için kullanılan property
    /// </summary>
        public bool? RemoveSubEpisodeRelation
        {
            get { return (bool?)this["REMOVESUBEPISODERELATION"]; }
            set { this["REMOVESUBEPISODERELATION"] = value; }
        }

        public SubactionProcedureWithDiagnosis SubactionProcedure
        {
            get { return (SubactionProcedureWithDiagnosis)((ITTObject)this).GetParent("SUBACTIONPROCEDURE"); }
            set { this["SUBACTIONPROCEDURE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public EpisodeActionWithDiagnosis EpisodeAction
        {
            get { return (EpisodeActionWithDiagnosis)((ITTObject)this).GetParent("EPISODEACTION"); }
            set { this["EPISODEACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Bulaşıcı Hastalık Bildirim Vaka Tipi İlişkisi
    /// </summary>
        public SKRSVakaTipi SKRSVakaTipi
        {
            get { return (SKRSVakaTipi)((ITTObject)this).GetParent("SKRSVAKATIPI"); }
            set { this["SKRSVAKATIPI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Episode Episode
        {
            get { return (Episode)((ITTObject)this).GetParent("EPISODE"); }
            set { this["EPISODE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Önemli Tıbbi Bilgiler-Tanı Özgeçmişi
    /// </summary>
        public ImportantMedicalInformation ImportantMedicalInformation
        {
            get { return (ImportantMedicalInformation)((ITTObject)this).GetParent("IMPORTANTMEDICALINFORMATION"); }
            set { this["IMPORTANTMEDICALINFORMATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Tanı
    /// </summary>
        public DiagnosisDefinition Diagnose
        {
            get { return (DiagnosisDefinition)((ITTObject)this).GetParent("DIAGNOSE"); }
            set { this["DIAGNOSE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Tanıyı Giren Kullanıcı
    /// </summary>
        public ResUser ResponsibleUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESPONSIBLEUSER"); }
            set { this["RESPONSIBLEUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// DiagnosisGrid OzelDurum
    /// </summary>
        public OzelDurum OzelDurum
        {
            get { return (OzelDurum)((ITTObject)this).GetParent("OZELDURUM"); }
            set { this["OZELDURUM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ExaminationInfoByBrans ExaminationInfoByBrans
        {
            get { return (ExaminationInfoByBrans)((ITTObject)this).GetParent("EXAMINATIONINFOBYBRANS"); }
            set { this["EXAMINATIONINFOBYBRANS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Tanıyı Koyan Doktor
    /// </summary>
        public ResUser ResponsibleDoctor
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESPONSIBLEDOCTOR"); }
            set { this["RESPONSIBLEDOCTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İşlemin Yapan  Uzmanlık Dalı Bilgisinin Tutulduğu Alandır
    /// </summary>
        public SpecialityDefinition Speciality
        {
            get { return (SpecialityDefinition)((ITTObject)this).GetParent("SPECIALITY"); }
            set { this["SPECIALITY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateSEPDiagnosesCollection()
        {
            _SEPDiagnoses = new SEPDiagnosis.ChildSEPDiagnosisCollection(this, new Guid("f3773f63-7e79-487d-8215-75c43eadf920"));
            ((ITTChildObjectCollection)_SEPDiagnoses).GetChildren();
        }

        protected SEPDiagnosis.ChildSEPDiagnosisCollection _SEPDiagnoses = null;
    /// <summary>
    /// Child collection for Tanı Gridi
    /// </summary>
        public SEPDiagnosis.ChildSEPDiagnosisCollection SEPDiagnoses
        {
            get
            {
                if (_SEPDiagnoses == null)
                    CreateSEPDiagnosesCollection();
                return _SEPDiagnoses;
            }
        }

        virtual protected void CreateReportDiagnosisCollection()
        {
            _ReportDiagnosis = new ReportDiagnosis.ChildReportDiagnosisCollection(this, new Guid("c68f6f8a-a9a1-49c3-bd97-905c8bacbbb1"));
            ((ITTChildObjectCollection)_ReportDiagnosis).GetChildren();
        }

        protected ReportDiagnosis.ChildReportDiagnosisCollection _ReportDiagnosis = null;
        public ReportDiagnosis.ChildReportDiagnosisCollection ReportDiagnosis
        {
            get
            {
                if (_ReportDiagnosis == null)
                    CreateReportDiagnosisCollection();
                return _ReportDiagnosis;
            }
        }

        virtual protected void CreateTaniTeshisİliskisiCollection()
        {
            _TaniTeshisİliskisi = new TaniTeshisİliskisi.ChildTaniTeshisİliskisiCollection(this, new Guid("43a229d6-d153-47cb-a07f-9562c37f5fa8"));
            ((ITTChildObjectCollection)_TaniTeshisİliskisi).GetChildren();
        }

        protected TaniTeshisİliskisi.ChildTaniTeshisİliskisiCollection _TaniTeshisİliskisi = null;
        public TaniTeshisİliskisi.ChildTaniTeshisİliskisiCollection TaniTeshisİliskisi
        {
            get
            {
                if (_TaniTeshisİliskisi == null)
                    CreateTaniTeshisİliskisiCollection();
                return _TaniTeshisİliskisi;
            }
        }

        virtual protected void CreateDiagnosisSubEpisodesCollection()
        {
            _DiagnosisSubEpisodes = new DiagnosisSubEpisode.ChildDiagnosisSubEpisodeCollection(this, new Guid("2c8e9339-5e33-4442-9f14-7332c6e542df"));
            ((ITTChildObjectCollection)_DiagnosisSubEpisodes).GetChildren();
        }

        protected DiagnosisSubEpisode.ChildDiagnosisSubEpisodeCollection _DiagnosisSubEpisodes = null;
        public DiagnosisSubEpisode.ChildDiagnosisSubEpisodeCollection DiagnosisSubEpisodes
        {
            get
            {
                if (_DiagnosisSubEpisodes == null)
                    CreateDiagnosisSubEpisodesCollection();
                return _DiagnosisSubEpisodes;
            }
        }

        protected DiagnosisGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DiagnosisGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DiagnosisGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DiagnosisGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DiagnosisGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DIAGNOSISGRID", dataRow) { }
        protected DiagnosisGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DIAGNOSISGRID", dataRow, isImported) { }
        public DiagnosisGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DiagnosisGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DiagnosisGrid() : base() { }

    }
}