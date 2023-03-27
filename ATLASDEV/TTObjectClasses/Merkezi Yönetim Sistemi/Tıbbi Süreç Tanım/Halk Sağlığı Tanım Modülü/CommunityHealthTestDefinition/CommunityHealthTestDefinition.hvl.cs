
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CommunityHealthTestDefinition")] 

    /// <summary>
    /// Halk Sağlığı Tetkik Tanım
    /// </summary>
    public  partial class CommunityHealthTestDefinition : ProcedureDefinition
    {
        public class CommunityHealthTestDefinitionList : TTObjectCollection<CommunityHealthTestDefinition> { }
                    
        public class ChildCommunityHealthTestDefinitionCollection : TTObject.TTChildObjectCollection<CommunityHealthTestDefinition>
        {
            public ChildCommunityHealthTestDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCommunityHealthTestDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class CommunityHealthTestDefFormNQL_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYHEALTHTESTDEFINITION"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYHEALTHTESTDEFINITION"].AllPropertyDefs["CHARGABLE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYHEALTHTESTDEFINITION"].AllPropertyDefs["ENGLISHNAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYHEALTHTESTDEFINITION"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYHEALTHTESTDEFINITION"].AllPropertyDefs["QREF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYHEALTHTESTDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYHEALTHTESTDEFINITION"].AllPropertyDefs["SUTAPPENDIX"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYHEALTHTESTDEFINITION"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYHEALTHTESTDEFINITION"].AllPropertyDefs["ONAMFORMUISTE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYHEALTHTESTDEFINITION"].AllPropertyDefs["NAME_SHADOW"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYHEALTHTESTDEFINITION"].AllPropertyDefs["CREATEINMEDULADONTSENDSTATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYHEALTHTESTDEFINITION"].AllPropertyDefs["PREPROCEDUREENTRYNECESSITY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYHEALTHTESTDEFINITION"].AllPropertyDefs["MEDULAPROCEDURETYPE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYHEALTHTESTDEFINITION"].AllPropertyDefs["MEDULAREPORTNECESSITY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYHEALTHTESTDEFINITION"].AllPropertyDefs["DAILYMEDULAPROVISIONNECESSITY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYHEALTHTESTDEFINITION"].AllPropertyDefs["GILCODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYHEALTHTESTDEFINITION"].AllPropertyDefs["GILPOINT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYHEALTHTESTDEFINITION"].AllPropertyDefs["DONTBLOCKINVOICE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYHEALTHTESTDEFINITION"].AllPropertyDefs["SUTCODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYHEALTHTESTDEFINITION"].AllPropertyDefs["QUICKENTRYALLOWED"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYHEALTHTESTDEFINITION"].AllPropertyDefs["REPORTSELECTIONREQUIRED"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYHEALTHTESTDEFINITION"].AllPropertyDefs["EXTERNALID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYHEALTHTESTDEFINITION"].AllPropertyDefs["ISDESCRIPTIONNEEDED"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYHEALTHTESTDEFINITION"].AllPropertyDefs["PARTICIPATIONPROCEDURE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYHEALTHTESTDEFINITION"].AllPropertyDefs["GILNAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYHEALTHTESTDEFINITION"].AllPropertyDefs["REPETITIONQUERYNEEDED"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYHEALTHTESTDEFINITION"].AllPropertyDefs["ISRESULTNEEDED"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYHEALTHTESTDEFINITION"].AllPropertyDefs["PROCEDURETYPE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYHEALTHTESTDEFINITION"].AllPropertyDefs["RIGHTLEFTINFONEEDED"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYHEALTHTESTDEFINITION"].AllPropertyDefs["ISVISIBLE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYHEALTHTESTDEFINITION"].AllPropertyDefs["CONTROLDAYCOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYHEALTHTESTDEFINITION"].AllPropertyDefs["DAILYDAYCOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYHEALTHTESTDEFINITION"].AllPropertyDefs["EMERGENCYDAYCOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYHEALTHTESTDEFINITION"].AllPropertyDefs["EXAMINATIONDAYCOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYHEALTHTESTDEFINITION"].AllPropertyDefs["FORBIDDENFORCONTROL"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYHEALTHTESTDEFINITION"].AllPropertyDefs["FORBIDDENFORDAILY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYHEALTHTESTDEFINITION"].AllPropertyDefs["FORBIDDENFOREMERGENCY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYHEALTHTESTDEFINITION"].AllPropertyDefs["FORBIDDENFOREXAMINATION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYHEALTHTESTDEFINITION"].AllPropertyDefs["FORBIDDENFORINPATIENT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYHEALTHTESTDEFINITION"].AllPropertyDefs["HUVCODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYHEALTHTESTDEFINITION"].AllPropertyDefs["HUVPOINT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYHEALTHTESTDEFINITION"].AllPropertyDefs["SUTPOINT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYHEALTHTESTDEFINITION"].AllPropertyDefs["EXTERNALOPERATION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYHEALTHTESTDEFINITION"].AllPropertyDefs["PATHOLOGYOPERATIONNEEDED"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYHEALTHTESTDEFINITION"].AllPropertyDefs["QUALIFIEDMEDICALPROCESS"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYHEALTHTESTDEFINITION"].AllPropertyDefs["INPATIENTDAYCOUNT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? ScreenOrder
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SCREENORDER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYHEALTHTESTDEFINITION"].AllPropertyDefs["SCREENORDER"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public double? Weight
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WEIGHT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYHEALTHTESTDEFINITION"].AllPropertyDefs["WEIGHT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? StandartValue
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STANDARTVALUE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYHEALTHTESTDEFINITION"].AllPropertyDefs["STANDARTVALUE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string SampleDoseandType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SAMPLEDOSEANDTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYHEALTHTESTDEFINITION"].AllPropertyDefs["SAMPLEDOSEANDTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? TestTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TESTTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYHEALTHTESTDEFINITION"].AllPropertyDefs["TESTTIME"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string Unit
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNIT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYHEALTHTESTDEFINITION"].AllPropertyDefs["UNIT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public CommunityHealthTestDefFormNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public CommunityHealthTestDefFormNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected CommunityHealthTestDefFormNQL_Class() : base() { }
        }

        public static BindingList<CommunityHealthTestDefinition> GetByTestCategory(TTObjectContext objectContext, Guid TESTCATEGORY)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYHEALTHTESTDEFINITION"].QueryDefs["GetByTestCategory"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TESTCATEGORY", TESTCATEGORY);

            return ((ITTQuery)objectContext).QueryObjects<CommunityHealthTestDefinition>(queryDef, paramList);
        }

        public static BindingList<CommunityHealthTestDefinition> GetByObjectID(TTObjectContext objectContext, Guid OBJECTID, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYHEALTHTESTDEFINITION"].QueryDefs["GetByObjectID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return ((ITTQuery)objectContext).QueryObjects<CommunityHealthTestDefinition>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<CommunityHealthTestDefinition.CommunityHealthTestDefFormNQL_Class> CommunityHealthTestDefFormNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYHEALTHTESTDEFINITION"].QueryDefs["CommunityHealthTestDefFormNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CommunityHealthTestDefinition.CommunityHealthTestDefFormNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<CommunityHealthTestDefinition.CommunityHealthTestDefFormNQL_Class> CommunityHealthTestDefFormNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYHEALTHTESTDEFINITION"].QueryDefs["CommunityHealthTestDefFormNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CommunityHealthTestDefinition.CommunityHealthTestDefFormNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public int? ScreenOrder
        {
            get { return (int?)this["SCREENORDER"]; }
            set { this["SCREENORDER"] = value; }
        }

        public double? Weight
        {
            get { return (double?)this["WEIGHT"]; }
            set { this["WEIGHT"] = value; }
        }

        public double? StandartValue
        {
            get { return (double?)this["STANDARTVALUE"]; }
            set { this["STANDARTVALUE"] = value; }
        }

    /// <summary>
    /// Numune Miktarı/Tipi
    /// </summary>
        public string SampleDoseandType
        {
            get { return (string)this["SAMPLEDOSEANDTYPE"]; }
            set { this["SAMPLEDOSEANDTYPE"] = value; }
        }

        public int? TestTime
        {
            get { return (int?)this["TESTTIME"]; }
            set { this["TESTTIME"] = value; }
        }

        public string Unit
        {
            get { return (string)this["UNIT"]; }
            set { this["UNIT"] = value; }
        }

        public CommunityHealthTestCategoryDefinition TestCategory
        {
            get { return (CommunityHealthTestCategoryDefinition)((ITTObject)this).GetParent("TESTCATEGORY"); }
            set { this["TESTCATEGORY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected CommunityHealthTestDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CommunityHealthTestDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CommunityHealthTestDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CommunityHealthTestDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CommunityHealthTestDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "COMMUNITYHEALTHTESTDEFINITION", dataRow) { }
        protected CommunityHealthTestDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "COMMUNITYHEALTHTESTDEFINITION", dataRow, isImported) { }
        public CommunityHealthTestDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CommunityHealthTestDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CommunityHealthTestDefinition() : base() { }

    }
}