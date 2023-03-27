
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PathologyTestDefinition")] 

    /// <summary>
    /// Patoloji Test Tanımı
    /// </summary>
    public  partial class PathologyTestDefinition : ProcedureDefinition, IProcedureRequestDefinition
    {
        public class PathologyTestDefinitionList : TTObjectCollection<PathologyTestDefinition> { }
                    
        public class ChildPathologyTestDefinitionCollection : TTObject.TTChildObjectCollection<PathologyTestDefinition>
        {
            public ChildPathologyTestDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPathologyTestDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class PathologyTestDefFormNQL_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTDEFINITION"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Qref
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QREF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTDEFINITION"].AllPropertyDefs["QREF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string EnglishName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENGLISHNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTDEFINITION"].AllPropertyDefs["ENGLISHNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Categoryname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CATEGORYNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTCATEGORYDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public PathologyTestDefFormNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public PathologyTestDefFormNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected PathologyTestDefFormNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPathologyTestDefinitionNQL_Class : TTReportNqlObject 
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

            public Boolean? IsActive
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISACTIVE"]);
                    if (val == null)
                        return null;
                    return (Boolean)Convert.ChangeType(val, typeof(Boolean)); 
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

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? Chargable
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CHARGABLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTDEFINITION"].AllPropertyDefs["CHARGABLE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string EnglishName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENGLISHNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTDEFINITION"].AllPropertyDefs["ENGLISHNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTDEFINITION"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Qref
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QREF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTDEFINITION"].AllPropertyDefs["QREF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public SUTHizmetEKEnum? SUTAppendix
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUTAPPENDIX"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTDEFINITION"].AllPropertyDefs["SUTAPPENDIX"].DataType;
                    return (SUTHizmetEKEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? OnamFormuIste
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ONAMFORMUISTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTDEFINITION"].AllPropertyDefs["ONAMFORMUISTE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Name_Shadow
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME_SHADOW"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTDEFINITION"].AllPropertyDefs["NAME_SHADOW"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? CreateInMedulaDontSendState
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CREATEINMEDULADONTSENDSTATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTDEFINITION"].AllPropertyDefs["CREATEINMEDULADONTSENDSTATE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? PreProcedureEntryNecessity
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PREPROCEDUREENTRYNECESSITY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTDEFINITION"].AllPropertyDefs["PREPROCEDUREENTRYNECESSITY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public MedulaSUTGroupEnum? MedulaProcedureType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULAPROCEDURETYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTDEFINITION"].AllPropertyDefs["MEDULAPROCEDURETYPE"].DataType;
                    return (MedulaSUTGroupEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public MedulaRaporZorunluluguEnum? MedulaReportNecessity
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULAREPORTNECESSITY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTDEFINITION"].AllPropertyDefs["MEDULAREPORTNECESSITY"].DataType;
                    return (MedulaRaporZorunluluguEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? DailyMedulaProvisionNecessity
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DAILYMEDULAPROVISIONNECESSITY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTDEFINITION"].AllPropertyDefs["DAILYMEDULAPROVISIONNECESSITY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string GILCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GILCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTDEFINITION"].AllPropertyDefs["GILCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? GILPoint
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GILPOINT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTDEFINITION"].AllPropertyDefs["GILPOINT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public bool? DontBlockInvoice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DONTBLOCKINVOICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTDEFINITION"].AllPropertyDefs["DONTBLOCKINVOICE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string SUTCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUTCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTDEFINITION"].AllPropertyDefs["SUTCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? QuickEntryAllowed
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QUICKENTRYALLOWED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTDEFINITION"].AllPropertyDefs["QUICKENTRYALLOWED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? ReportSelectionRequired
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTSELECTIONREQUIRED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTDEFINITION"].AllPropertyDefs["REPORTSELECTIONREQUIRED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string ExternalId
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXTERNALID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTDEFINITION"].AllPropertyDefs["EXTERNALID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsDescriptionNeeded
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISDESCRIPTIONNEEDED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTDEFINITION"].AllPropertyDefs["ISDESCRIPTIONNEEDED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? ParticipationProcedure
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PARTICIPATIONPROCEDURE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTDEFINITION"].AllPropertyDefs["PARTICIPATIONPROCEDURE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string GILName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GILNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTDEFINITION"].AllPropertyDefs["GILNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? RepetitionQueryNeeded
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPETITIONQUERYNEEDED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTDEFINITION"].AllPropertyDefs["REPETITIONQUERYNEEDED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsResultNeeded
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISRESULTNEEDED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTDEFINITION"].AllPropertyDefs["ISRESULTNEEDED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public ProcedureDefGroupEnum? ProcedureType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDURETYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTDEFINITION"].AllPropertyDefs["PROCEDURETYPE"].DataType;
                    return (ProcedureDefGroupEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? RightLeftInfoNeeded
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RIGHTLEFTINFONEEDED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTDEFINITION"].AllPropertyDefs["RIGHTLEFTINFONEEDED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsVisible
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISVISIBLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTDEFINITION"].AllPropertyDefs["ISVISIBLE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public int? ControlDayCount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CONTROLDAYCOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTDEFINITION"].AllPropertyDefs["CONTROLDAYCOUNT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? DailyDayCount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DAILYDAYCOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTDEFINITION"].AllPropertyDefs["DAILYDAYCOUNT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? EmergencyDayCount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EMERGENCYDAYCOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTDEFINITION"].AllPropertyDefs["EMERGENCYDAYCOUNT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? ExaminationDayCount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXAMINATIONDAYCOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTDEFINITION"].AllPropertyDefs["EXAMINATIONDAYCOUNT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public bool? ForbiddenForControl
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FORBIDDENFORCONTROL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTDEFINITION"].AllPropertyDefs["FORBIDDENFORCONTROL"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? ForbiddenForDaily
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FORBIDDENFORDAILY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTDEFINITION"].AllPropertyDefs["FORBIDDENFORDAILY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? ForbiddenForEmergency
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FORBIDDENFOREMERGENCY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTDEFINITION"].AllPropertyDefs["FORBIDDENFOREMERGENCY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? ForbiddenForExamination
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FORBIDDENFOREXAMINATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTDEFINITION"].AllPropertyDefs["FORBIDDENFOREXAMINATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? ForbiddenForInpatient
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FORBIDDENFORINPATIENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTDEFINITION"].AllPropertyDefs["FORBIDDENFORINPATIENT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string HUVCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HUVCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTDEFINITION"].AllPropertyDefs["HUVCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? HUVPoint
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HUVPOINT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTDEFINITION"].AllPropertyDefs["HUVPOINT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? SUTPoint
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUTPOINT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTDEFINITION"].AllPropertyDefs["SUTPOINT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public bool? ExternalOperation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXTERNALOPERATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTDEFINITION"].AllPropertyDefs["EXTERNALOPERATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? PathologyOperationNeeded
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATHOLOGYOPERATIONNEEDED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTDEFINITION"].AllPropertyDefs["PATHOLOGYOPERATIONNEEDED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? QualifiedMedicalProcess
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QUALIFIEDMEDICALPROCESS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTDEFINITION"].AllPropertyDefs["QUALIFIEDMEDICALPROCESS"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public int? InpatientDayCount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INPATIENTDAYCOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTDEFINITION"].AllPropertyDefs["INPATIENTDAYCOUNT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public long? TestCount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TESTCOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTDEFINITION"].AllPropertyDefs["TESTCOUNT"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public bool? RequestApprove
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTAPPROVE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTDEFINITION"].AllPropertyDefs["REQUESTAPPROVE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string IntegrationCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INTEGRATIONCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTDEFINITION"].AllPropertyDefs["INTEGRATIONCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? ResultTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULTTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTDEFINITION"].AllPropertyDefs["RESULTTIME"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public GetPathologyTestDefinitionNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPathologyTestDefinitionNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPathologyTestDefinitionNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetPathologyTestDef_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ProcedureTree
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDURETREE"]);
                }
            }

            public string Testcategory
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TESTCATEGORY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTCATEGORYDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public OLAP_GetPathologyTestDef_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetPathologyTestDef_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetPathologyTestDef_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetpathologyTestDef_WithDate_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ProcedureTree
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDURETREE"]);
                }
            }

            public string Testcategory
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TESTCATEGORY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTCATEGORYDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public OLAP_GetpathologyTestDef_WithDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetpathologyTestDef_WithDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetpathologyTestDef_WithDate_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetpathologyTestDef_WithDate2_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ProcedureTree
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDURETREE"]);
                }
            }

            public string Testcategory
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TESTCATEGORY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTCATEGORYDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public OLAP_GetpathologyTestDef_WithDate2_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetpathologyTestDef_WithDate2_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetpathologyTestDef_WithDate2_Class() : base() { }
        }

        public static BindingList<PathologyTestDefinition> GetByObjectID(TTObjectContext objectContext, string PARAMOBJECTID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTDEFINITION"].QueryDefs["GetByObjectID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJECTID", PARAMOBJECTID);

            return ((ITTQuery)objectContext).QueryObjects<PathologyTestDefinition>(queryDef, paramList);
        }

        public static BindingList<PathologyTestDefinition.PathologyTestDefFormNQL_Class> PathologyTestDefFormNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTDEFINITION"].QueryDefs["PathologyTestDefFormNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PathologyTestDefinition.PathologyTestDefFormNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PathologyTestDefinition.PathologyTestDefFormNQL_Class> PathologyTestDefFormNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTDEFINITION"].QueryDefs["PathologyTestDefFormNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PathologyTestDefinition.PathologyTestDefFormNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PathologyTestDefinition.GetPathologyTestDefinitionNQL_Class> GetPathologyTestDefinitionNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTDEFINITION"].QueryDefs["GetPathologyTestDefinitionNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PathologyTestDefinition.GetPathologyTestDefinitionNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PathologyTestDefinition.GetPathologyTestDefinitionNQL_Class> GetPathologyTestDefinitionNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTDEFINITION"].QueryDefs["GetPathologyTestDefinitionNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PathologyTestDefinition.GetPathologyTestDefinitionNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PathologyTestDefinition.OLAP_GetPathologyTestDef_Class> OLAP_GetPathologyTestDef(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTDEFINITION"].QueryDefs["OLAP_GetPathologyTestDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PathologyTestDefinition.OLAP_GetPathologyTestDef_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PathologyTestDefinition.OLAP_GetPathologyTestDef_Class> OLAP_GetPathologyTestDef(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTDEFINITION"].QueryDefs["OLAP_GetPathologyTestDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PathologyTestDefinition.OLAP_GetPathologyTestDef_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PathologyTestDefinition.OLAP_GetpathologyTestDef_WithDate_Class> OLAP_GetpathologyTestDef_WithDate(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTDEFINITION"].QueryDefs["OLAP_GetpathologyTestDef_WithDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PathologyTestDefinition.OLAP_GetpathologyTestDef_WithDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PathologyTestDefinition.OLAP_GetpathologyTestDef_WithDate_Class> OLAP_GetpathologyTestDef_WithDate(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTDEFINITION"].QueryDefs["OLAP_GetpathologyTestDef_WithDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PathologyTestDefinition.OLAP_GetpathologyTestDef_WithDate_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PathologyTestDefinition.OLAP_GetpathologyTestDef_WithDate2_Class> OLAP_GetpathologyTestDef_WithDate2(DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTDEFINITION"].QueryDefs["OLAP_GetpathologyTestDef_WithDate2"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<PathologyTestDefinition.OLAP_GetpathologyTestDef_WithDate2_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PathologyTestDefinition.OLAP_GetpathologyTestDef_WithDate2_Class> OLAP_GetpathologyTestDef_WithDate2(TTObjectContext objectContext, DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTDEFINITION"].QueryDefs["OLAP_GetpathologyTestDef_WithDate2"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<PathologyTestDefinition.OLAP_GetpathologyTestDef_WithDate2_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Fiyat Çarpanı
    /// </summary>
        public long? TestCount
        {
            get { return (long?)this["TESTCOUNT"]; }
            set { this["TESTCOUNT"] = value; }
        }

    /// <summary>
    /// Baştabip Onay
    /// </summary>
        public bool? RequestApprove
        {
            get { return (bool?)this["REQUESTAPPROVE"]; }
            set { this["REQUESTAPPROVE"] = value; }
        }

    /// <summary>
    /// Entegrasyon Kodu
    /// </summary>
        public string IntegrationCode
        {
            get { return (string)this["INTEGRATIONCODE"]; }
            set { this["INTEGRATIONCODE"] = value; }
        }

    /// <summary>
    /// Sonuçlanma Zamanı
    /// </summary>
        public int? ResultTime
        {
            get { return (int?)this["RESULTTIME"]; }
            set { this["RESULTTIME"] = value; }
        }

    /// <summary>
    /// Patoloji Test Kategori Tanım İlişkisi
    /// </summary>
        public PathologyTestCategoryDefinition TestCategory
        {
            get { return (PathologyTestCategoryDefinition)((ITTObject)this).GetParent("TESTCATEGORY"); }
            set { this["TESTCATEGORY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public TahlilTipi TahlilTipi
        {
            get { return (TahlilTipi)((ITTObject)this).GetParent("TAHLILTIPI"); }
            set { this["TAHLILTIPI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateMaterialsCollection()
        {
            _Materials = new PathologyGridMaterialDefinition.ChildPathologyGridMaterialDefinitionCollection(this, new Guid("257d6ed6-3d76-4a54-bdd1-060ce86cbf71"));
            ((ITTChildObjectCollection)_Materials).GetChildren();
        }

        protected PathologyGridMaterialDefinition.ChildPathologyGridMaterialDefinitionCollection _Materials = null;
    /// <summary>
    /// Child collection for Patoloji Test Tanım İlişkisi
    /// </summary>
        public PathologyGridMaterialDefinition.ChildPathologyGridMaterialDefinitionCollection Materials
        {
            get
            {
                if (_Materials == null)
                    CreateMaterialsCollection();
                return _Materials;
            }
        }

        virtual protected void CreatePathologyTestDescriptionCollection()
        {
            _PathologyTestDescription = new PathologyGridDescriptionDefinition.ChildPathologyGridDescriptionDefinitionCollection(this, new Guid("ff8af4b5-d188-4d35-bfd4-eec0cfb766c8"));
            ((ITTChildObjectCollection)_PathologyTestDescription).GetChildren();
        }

        protected PathologyGridDescriptionDefinition.ChildPathologyGridDescriptionDefinitionCollection _PathologyTestDescription = null;
    /// <summary>
    /// Child collection for Patoloji Test Tanım İlişkisi
    /// </summary>
        public PathologyGridDescriptionDefinition.ChildPathologyGridDescriptionDefinitionCollection PathologyTestDescription
        {
            get
            {
                if (_PathologyTestDescription == null)
                    CreatePathologyTestDescriptionCollection();
                return _PathologyTestDescription;
            }
        }

        protected PathologyTestDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PathologyTestDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PathologyTestDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PathologyTestDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PathologyTestDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PATHOLOGYTESTDEFINITION", dataRow) { }
        protected PathologyTestDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PATHOLOGYTESTDEFINITION", dataRow, isImported) { }
        public PathologyTestDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PathologyTestDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PathologyTestDefinition() : base() { }

    }
}