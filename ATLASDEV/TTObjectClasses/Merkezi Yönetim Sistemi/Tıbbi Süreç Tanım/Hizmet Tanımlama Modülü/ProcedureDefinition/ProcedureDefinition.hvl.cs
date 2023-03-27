
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ProcedureDefinition")] 

    /// <summary>
    /// Hizmet Tanımı
    /// </summary>
    public  partial class ProcedureDefinition : TerminologyManagerDef, ISUTRulableProcedure
    {
        public class ProcedureDefinitionList : TTObjectCollection<ProcedureDefinition> { }
                    
        public class ChildProcedureDefinitionCollection : TTObject.TTChildObjectCollection<ProcedureDefinition>
        {
            public ChildProcedureDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildProcedureDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetProcedureDefinitionListDefinition_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["QREF"].DataType;
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

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["ENGLISHNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Proctreedesc
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCTREEDESC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDURETREEDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["QUICKENTRYALLOWED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public Object Proceduretype
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PROCEDURETYPE"]);
                }
            }

            public ProcedureDefGroupEnum? Proceduretypeid
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDURETYPEID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["PROCEDURETYPE"].DataType;
                    return (ProcedureDefGroupEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public double? SUTPoint
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUTPOINT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["SUTPOINT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string SUTCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUTCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["SUTCODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["HUVPOINT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public GetProcedureDefinitionListDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetProcedureDefinitionListDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetProcedureDefinitionListDefinition_Class() : base() { }
        }

        [Serializable] 

        public partial class GetProcedureWithNoEffectivePrice_Class : TTReportNqlObject 
        {
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

            public string Proctreecode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCTREECODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDURETREEDEFINITION"].AllPropertyDefs["EXTERNALCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Proctreedesc
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCTREEDESC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDURETREEDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetProcedureWithNoEffectivePrice_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetProcedureWithNoEffectivePrice_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetProcedureWithNoEffectivePrice_Class() : base() { }
        }

        [Serializable] 

        public partial class GetProcedureWithMultiEffectivePriceByPriceList_Class : TTReportNqlObject 
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

            public Object Pricecount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PRICECOUNT"]);
                }
            }

            public GetProcedureWithMultiEffectivePriceByPriceList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetProcedureWithMultiEffectivePriceByPriceList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetProcedureWithMultiEffectivePriceByPriceList_Class() : base() { }
        }

        [Serializable] 

        public partial class GetProcedureDefForFastProcedureAdding_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["CHARGABLE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["ENGLISHNAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["QREF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["SUTAPPENDIX"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["ONAMFORMUISTE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME_SHADOW"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["CREATEINMEDULADONTSENDSTATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["PREPROCEDUREENTRYNECESSITY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["MEDULAPROCEDURETYPE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["MEDULAREPORTNECESSITY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["DAILYMEDULAPROVISIONNECESSITY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["GILCODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["GILPOINT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["DONTBLOCKINVOICE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["SUTCODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["QUICKENTRYALLOWED"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["REPORTSELECTIONREQUIRED"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["EXTERNALID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["ISDESCRIPTIONNEEDED"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["PARTICIPATIONPROCEDURE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["GILNAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["REPETITIONQUERYNEEDED"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["ISRESULTNEEDED"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["PROCEDURETYPE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["RIGHTLEFTINFONEEDED"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["ISVISIBLE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["CONTROLDAYCOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["DAILYDAYCOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["EMERGENCYDAYCOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["EXAMINATIONDAYCOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["FORBIDDENFORCONTROL"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["FORBIDDENFORDAILY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["FORBIDDENFOREMERGENCY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["FORBIDDENFOREXAMINATION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["FORBIDDENFORINPATIENT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["HUVCODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["HUVPOINT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["SUTPOINT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["EXTERNALOPERATION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["PATHOLOGYOPERATIONNEEDED"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["QUALIFIEDMEDICALPROCESS"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["INPATIENTDAYCOUNT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public GetProcedureDefForFastProcedureAdding_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetProcedureDefForFastProcedureAdding_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetProcedureDefForFastProcedureAdding_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetProcedures_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
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

            public OLAP_GetProcedures_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetProcedures_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetProcedures_Class() : base() { }
        }

        [Serializable] 

        public partial class GetProcedureDefForProcedureRequest_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["QREF"].DataType;
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

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["ENGLISHNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Proctreedesc
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCTREEDESC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDURETREEDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetProcedureDefForProcedureRequest_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetProcedureDefForProcedureRequest_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetProcedureDefForProcedureRequest_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetProcedures_WithDate_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
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

            public OLAP_GetProcedures_WithDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetProcedures_WithDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetProcedures_WithDate_Class() : base() { }
        }

        [Serializable] 

        public partial class VEM_HIZMET_Class : TTReportNqlObject 
        {
            public Guid? Hizmet_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["HIZMET_KODU"]);
                }
            }

            public Object Referans_tablo_adi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["REFERANS_TABLO_ADI"]);
                }
            }

            public Object Islem_grubu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ISLEM_GRUBU"]);
                }
            }

            public Guid? Islem_turu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ISLEM_TURU"]);
                }
            }

            public string Sut_kodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUT_KODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Hizmet_adi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HIZMET_ADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Girisimsel_islem_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["GIRISIMSEL_ISLEM_KODU"]);
                }
            }

            public Boolean? Aktiflik_bilgisi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AKTIFLIK_BILGISI"]);
                    if (val == null)
                        return null;
                    return (Boolean)Convert.ChangeType(val, typeof(Boolean)); 
                }
            }

            public Object Ekleyen_kullanici_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["EKLEYEN_KULLANICI_KODU"]);
                }
            }

            public DateTime? Guncelleme_tarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GUNCELLEME_TARIHI"]);
                    if (val == null)
                        return null;
                    return (DateTime)Convert.ChangeType(val, typeof(DateTime)); 
                }
            }

            public Object Guncelleyen_kullanici_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["GUNCELLEYEN_KULLANICI_KODU"]);
                }
            }

            public VEM_HIZMET_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public VEM_HIZMET_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected VEM_HIZMET_Class() : base() { }
        }

        [Serializable] 

        public partial class GetAllRelatedProcedureDefCodes_Class : TTReportNqlObject 
        {
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

            public GetAllRelatedProcedureDefCodes_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAllRelatedProcedureDefCodes_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAllRelatedProcedureDefCodes_Class() : base() { }
        }

        [Serializable] 

        public partial class GetGILCodeAndName_Class : TTReportNqlObject 
        {
            public string GILCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GILCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["GILCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string GILName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GILNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["GILNAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["GILPOINT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public GetGILCodeAndName_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetGILCodeAndName_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetGILCodeAndName_Class() : base() { }
        }

        public static BindingList<ProcedureDefinition> OLAP_Procedure(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].QueryDefs["OLAP_Procedure"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<ProcedureDefinition>(queryDef, paramList);
        }

        public static BindingList<ProcedureDefinition.GetProcedureDefinitionListDefinition_Class> GetProcedureDefinitionListDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].QueryDefs["GetProcedureDefinitionListDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ProcedureDefinition.GetProcedureDefinitionListDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ProcedureDefinition.GetProcedureDefinitionListDefinition_Class> GetProcedureDefinitionListDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].QueryDefs["GetProcedureDefinitionListDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ProcedureDefinition.GetProcedureDefinitionListDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ProcedureDefinition> GetByCode(TTObjectContext objectContext, string CODE, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].QueryDefs["GetByCode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("CODE", CODE);

            return ((ITTQuery)objectContext).QueryObjects<ProcedureDefinition>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<ProcedureDefinition.GetProcedureWithNoEffectivePrice_Class> GetProcedureWithNoEffectivePrice(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].QueryDefs["GetProcedureWithNoEffectivePrice"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ProcedureDefinition.GetProcedureWithNoEffectivePrice_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ProcedureDefinition.GetProcedureWithNoEffectivePrice_Class> GetProcedureWithNoEffectivePrice(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].QueryDefs["GetProcedureWithNoEffectivePrice"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ProcedureDefinition.GetProcedureWithNoEffectivePrice_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ProcedureDefinition.GetProcedureWithMultiEffectivePriceByPriceList_Class> GetProcedureWithMultiEffectivePriceByPriceList(string PRICELIST, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].QueryDefs["GetProcedureWithMultiEffectivePriceByPriceList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PRICELIST", PRICELIST);

            return TTReportNqlObject.QueryObjects<ProcedureDefinition.GetProcedureWithMultiEffectivePriceByPriceList_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ProcedureDefinition.GetProcedureWithMultiEffectivePriceByPriceList_Class> GetProcedureWithMultiEffectivePriceByPriceList(TTObjectContext objectContext, string PRICELIST, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].QueryDefs["GetProcedureWithMultiEffectivePriceByPriceList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PRICELIST", PRICELIST);

            return TTReportNqlObject.QueryObjects<ProcedureDefinition.GetProcedureWithMultiEffectivePriceByPriceList_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ProcedureDefinition> GetAllProcedureDefinitions(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].QueryDefs["GetAllProcedureDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<ProcedureDefinition>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<ProcedureDefinition> GetProcedureDefByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].QueryDefs["GetProcedureDefByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<ProcedureDefinition>(queryDef, paramList);
        }

        public static BindingList<ProcedureDefinition.GetProcedureDefForFastProcedureAdding_Class> GetProcedureDefForFastProcedureAdding(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].QueryDefs["GetProcedureDefForFastProcedureAdding"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ProcedureDefinition.GetProcedureDefForFastProcedureAdding_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ProcedureDefinition.GetProcedureDefForFastProcedureAdding_Class> GetProcedureDefForFastProcedureAdding(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].QueryDefs["GetProcedureDefForFastProcedureAdding"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ProcedureDefinition.GetProcedureDefForFastProcedureAdding_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ProcedureDefinition.OLAP_GetProcedures_Class> OLAP_GetProcedures(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].QueryDefs["OLAP_GetProcedures"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ProcedureDefinition.OLAP_GetProcedures_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ProcedureDefinition.OLAP_GetProcedures_Class> OLAP_GetProcedures(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].QueryDefs["OLAP_GetProcedures"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ProcedureDefinition.OLAP_GetProcedures_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ProcedureDefinition.GetProcedureDefForProcedureRequest_Class> GetProcedureDefForProcedureRequest(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].QueryDefs["GetProcedureDefForProcedureRequest"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ProcedureDefinition.GetProcedureDefForProcedureRequest_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ProcedureDefinition.GetProcedureDefForProcedureRequest_Class> GetProcedureDefForProcedureRequest(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].QueryDefs["GetProcedureDefForProcedureRequest"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ProcedureDefinition.GetProcedureDefForProcedureRequest_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ProcedureDefinition.OLAP_GetProcedures_WithDate_Class> OLAP_GetProcedures_WithDate(DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].QueryDefs["OLAP_GetProcedures_WithDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<ProcedureDefinition.OLAP_GetProcedures_WithDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ProcedureDefinition.OLAP_GetProcedures_WithDate_Class> OLAP_GetProcedures_WithDate(TTObjectContext objectContext, DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].QueryDefs["OLAP_GetProcedures_WithDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<ProcedureDefinition.OLAP_GetProcedures_WithDate_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ProcedureDefinition.VEM_HIZMET_Class> VEM_HIZMET(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].QueryDefs["VEM_HIZMET"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ProcedureDefinition.VEM_HIZMET_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ProcedureDefinition.VEM_HIZMET_Class> VEM_HIZMET(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].QueryDefs["VEM_HIZMET"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ProcedureDefinition.VEM_HIZMET_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ProcedureDefinition> GetByLOINCCode(TTObjectContext objectContext, string LOINCCODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].QueryDefs["GetByLOINCCode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("LOINCCODE", LOINCCODE);

            return ((ITTQuery)objectContext).QueryObjects<ProcedureDefinition>(queryDef, paramList);
        }

        public static BindingList<ProcedureDefinition.GetAllRelatedProcedureDefCodes_Class> GetAllRelatedProcedureDefCodes(IList<string> SUTCODES, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].QueryDefs["GetAllRelatedProcedureDefCodes"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUTCODES", SUTCODES);

            return TTReportNqlObject.QueryObjects<ProcedureDefinition.GetAllRelatedProcedureDefCodes_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ProcedureDefinition.GetAllRelatedProcedureDefCodes_Class> GetAllRelatedProcedureDefCodes(TTObjectContext objectContext, IList<string> SUTCODES, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].QueryDefs["GetAllRelatedProcedureDefCodes"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUTCODES", SUTCODES);

            return TTReportNqlObject.QueryObjects<ProcedureDefinition.GetAllRelatedProcedureDefCodes_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ProcedureDefinition.GetGILCodeAndName_Class> GetGILCodeAndName(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].QueryDefs["GetGILCodeAndName"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ProcedureDefinition.GetGILCodeAndName_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ProcedureDefinition.GetGILCodeAndName_Class> GetGILCodeAndName(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].QueryDefs["GetGILCodeAndName"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ProcedureDefinition.GetGILCodeAndName_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Kodu
    /// </summary>
        public string Code
        {
            get { return (string)this["CODE"]; }
            set { this["CODE"] = value; }
        }

    /// <summary>
    /// Ücretlendirilir
    /// </summary>
        public bool? Chargable
        {
            get { return (bool?)this["CHARGABLE"]; }
            set { this["CHARGABLE"] = value; }
        }

    /// <summary>
    /// İngilizce Adı
    /// </summary>
        public string EnglishName
        {
            get { return (string)this["ENGLISHNAME"]; }
            set { this["ENGLISHNAME"] = value; }
        }

    /// <summary>
    /// ID
    /// </summary>
        public TTSequence ID
        {
            get { return GetSequence("ID"); }
        }

    /// <summary>
    /// Kısa Kodu
    /// </summary>
        public string Qref
        {
            get { return (string)this["QREF"]; }
            set { this["QREF"] = value; }
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
    /// SUT Eki
    /// </summary>
        public SUTHizmetEKEnum? SUTAppendix
        {
            get { return (SUTHizmetEKEnum?)(int?)this["SUTAPPENDIX"]; }
            set { this["SUTAPPENDIX"] = value; }
        }

    /// <summary>
    /// Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public bool? OnamFormuIste
        {
            get { return (bool?)this["ONAMFORMUISTE"]; }
            set { this["ONAMFORMUISTE"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

    /// <summary>
    /// Medulaya Gönderilmeyecek Durumunda Oluşturulur
    /// </summary>
        public bool? CreateInMedulaDontSendState
        {
            get { return (bool?)this["CREATEINMEDULADONTSENDSTATE"]; }
            set { this["CREATEINMEDULADONTSENDSTATE"] = value; }
        }

    /// <summary>
    /// Ön Hizmet Kayıt Kontrolü Gerektirir
    /// </summary>
        public bool? PreProcedureEntryNecessity
        {
            get { return (bool?)this["PREPROCEDUREENTRYNECESSITY"]; }
            set { this["PREPROCEDUREENTRYNECESSITY"] = value; }
        }

    /// <summary>
    /// Medula Hizmet Kayıt Grubu
    /// </summary>
        public MedulaSUTGroupEnum? MedulaProcedureType
        {
            get { return (MedulaSUTGroupEnum?)(int?)this["MEDULAPROCEDURETYPE"]; }
            set { this["MEDULAPROCEDURETYPE"] = value; }
        }

    /// <summary>
    /// Hizmet Kaydı İçin Rapor Numarası Gerekir mi
    /// </summary>
        public MedulaRaporZorunluluguEnum? MedulaReportNecessity
        {
            get { return (MedulaRaporZorunluluguEnum?)(int?)this["MEDULAREPORTNECESSITY"]; }
            set { this["MEDULAREPORTNECESSITY"] = value; }
        }

    /// <summary>
    /// Meduladan Günübirlik Takip Alınması Gerekir
    /// </summary>
        public bool? DailyMedulaProvisionNecessity
        {
            get { return (bool?)this["DAILYMEDULAPROVISIONNECESSITY"]; }
            set { this["DAILYMEDULAPROVISIONNECESSITY"] = value; }
        }

    /// <summary>
    /// Girişimsel İşlem Listesi Kodu
    /// </summary>
        public string GILCode
        {
            get { return (string)this["GILCODE"]; }
            set { this["GILCODE"] = value; }
        }

    /// <summary>
    /// Girişimsel İşlem Listesi Puanı
    /// </summary>
        public int? GILPoint
        {
            get { return (int?)this["GILPOINT"]; }
            set { this["GILPOINT"] = value; }
        }

    /// <summary>
    /// Fatura Engelleme
    /// </summary>
        public bool? DontBlockInvoice
        {
            get { return (bool?)this["DONTBLOCKINVOICE"]; }
            set { this["DONTBLOCKINVOICE"] = value; }
        }

    /// <summary>
    /// SUT Kodu
    /// </summary>
        public string SUTCode
        {
            get { return (string)this["SUTCODE"]; }
            set { this["SUTCODE"] = value; }
        }

    /// <summary>
    /// Hızlı işlem giriş ekranından girilmesine izin verilir.
    /// </summary>
        public bool? QuickEntryAllowed
        {
            get { return (bool?)this["QUICKENTRYALLOWED"]; }
            set { this["QUICKENTRYALLOWED"] = value; }
        }

    /// <summary>
    /// Hızlı islem girilebilen hizmetler icin rapor secimi gerektigini belirten flag
    /// </summary>
        public bool? ReportSelectionRequired
        {
            get { return (bool?)this["REPORTSELECTIONREQUIRED"]; }
            set { this["REPORTSELECTIONREQUIRED"] = value; }
        }

        public string ExternalId
        {
            get { return (string)this["EXTERNALID"]; }
            set { this["EXTERNALID"] = value; }
        }

    /// <summary>
    /// Açıklama gerekliliği
    /// </summary>
        public bool? IsDescriptionNeeded
        {
            get { return (bool?)this["ISDESCRIPTIONNEEDED"]; }
            set { this["ISDESCRIPTIONNEEDED"] = value; }
        }

    /// <summary>
    /// Katılım Payı Hizmeti
    /// </summary>
        public bool? ParticipationProcedure
        {
            get { return (bool?)this["PARTICIPATIONPROCEDURE"]; }
            set { this["PARTICIPATIONPROCEDURE"] = value; }
        }

    /// <summary>
    /// Girişimsel İşlem Listesi Adı
    /// </summary>
        public string GILName
        {
            get { return (string)this["GILNAME"]; }
            set { this["GILNAME"] = value; }
        }

    /// <summary>
    /// Mükerrerlik Sorgusu Gerektirir
    /// </summary>
        public bool? RepetitionQueryNeeded
        {
            get { return (bool?)this["REPETITIONQUERYNEEDED"]; }
            set { this["REPETITIONQUERYNEEDED"] = value; }
        }

    /// <summary>
    /// Sonuç Değeri Gerektirir
    /// </summary>
        public bool? IsResultNeeded
        {
            get { return (bool?)this["ISRESULTNEEDED"]; }
            set { this["ISRESULTNEEDED"] = value; }
        }

    /// <summary>
    /// Hizmet Türü
    /// </summary>
        public ProcedureDefGroupEnum? ProcedureType
        {
            get { return (ProcedureDefGroupEnum?)(int?)this["PROCEDURETYPE"]; }
            set { this["PROCEDURETYPE"] = value; }
        }

    /// <summary>
    /// Sag / Sol Bilgisi Gerektirir
    /// </summary>
        public bool? RightLeftInfoNeeded
        {
            get { return (bool?)this["RIGHTLEFTINFONEEDED"]; }
            set { this["RIGHTLEFTINFONEEDED"] = value; }
        }

    /// <summary>
    /// Mastersubactionprocedure dolu olan hizmetler için kullanılır
    /// </summary>
        public bool? IsVisible
        {
            get { return (bool?)this["ISVISIBLE"]; }
            set { this["ISVISIBLE"] = value; }
        }

    /// <summary>
    /// İşlem Gün Adedi Kontrol
    /// </summary>
        public int? ControlDayCount
        {
            get { return (int?)this["CONTROLDAYCOUNT"]; }
            set { this["CONTROLDAYCOUNT"] = value; }
        }

    /// <summary>
    /// İşlem Gün Adedi Günübirlik
    /// </summary>
        public int? DailyDayCount
        {
            get { return (int?)this["DAILYDAYCOUNT"]; }
            set { this["DAILYDAYCOUNT"] = value; }
        }

    /// <summary>
    /// İşlem gün Adedi Acil
    /// </summary>
        public int? EmergencyDayCount
        {
            get { return (int?)this["EMERGENCYDAYCOUNT"]; }
            set { this["EMERGENCYDAYCOUNT"] = value; }
        }

    /// <summary>
    /// İşlem Gün Adedi Muayene
    /// </summary>
        public int? ExaminationDayCount
        {
            get { return (int?)this["EXAMINATIONDAYCOUNT"]; }
            set { this["EXAMINATIONDAYCOUNT"] = value; }
        }

    /// <summary>
    /// Yasaklı Kabul Grubu Kontrol
    /// </summary>
        public bool? ForbiddenForControl
        {
            get { return (bool?)this["FORBIDDENFORCONTROL"]; }
            set { this["FORBIDDENFORCONTROL"] = value; }
        }

    /// <summary>
    /// Yasaklı Kabul Grubu Günübirlik
    /// </summary>
        public bool? ForbiddenForDaily
        {
            get { return (bool?)this["FORBIDDENFORDAILY"]; }
            set { this["FORBIDDENFORDAILY"] = value; }
        }

    /// <summary>
    /// Yasaklı Kabul Grubu Acil
    /// </summary>
        public bool? ForbiddenForEmergency
        {
            get { return (bool?)this["FORBIDDENFOREMERGENCY"]; }
            set { this["FORBIDDENFOREMERGENCY"] = value; }
        }

    /// <summary>
    /// Yasaklı Kabul Grubu Muayene
    /// </summary>
        public bool? ForbiddenForExamination
        {
            get { return (bool?)this["FORBIDDENFOREXAMINATION"]; }
            set { this["FORBIDDENFOREXAMINATION"] = value; }
        }

    /// <summary>
    /// Yasaklı Kabul Grubu Yatış
    /// </summary>
        public bool? ForbiddenForInpatient
        {
            get { return (bool?)this["FORBIDDENFORINPATIENT"]; }
            set { this["FORBIDDENFORINPATIENT"] = value; }
        }

    /// <summary>
    /// HUV Kodu
    /// </summary>
        public string HUVCode
        {
            get { return (string)this["HUVCODE"]; }
            set { this["HUVCODE"] = value; }
        }

    /// <summary>
    /// HUV Puanı
    /// </summary>
        public double? HUVPoint
        {
            get { return (double?)this["HUVPOINT"]; }
            set { this["HUVPOINT"] = value; }
        }

    /// <summary>
    /// SUT Puanı
    /// </summary>
        public double? SUTPoint
        {
            get { return (double?)this["SUTPOINT"]; }
            set { this["SUTPOINT"] = value; }
        }

    /// <summary>
    /// Dış Hizmet
    /// </summary>
        public bool? ExternalOperation
        {
            get { return (bool?)this["EXTERNALOPERATION"]; }
            set { this["EXTERNALOPERATION"] = value; }
        }

    /// <summary>
    /// Patholoji İşlemi Zorunlu
    /// </summary>
        public bool? PathologyOperationNeeded
        {
            get { return (bool?)this["PATHOLOGYOPERATIONNEEDED"]; }
            set { this["PATHOLOGYOPERATIONNEEDED"] = value; }
        }

    /// <summary>
    /// Nitelikli Tıbbi İşlem 
    /// </summary>
        public bool? QualifiedMedicalProcess
        {
            get { return (bool?)this["QUALIFIEDMEDICALPROCESS"]; }
            set { this["QUALIFIEDMEDICALPROCESS"] = value; }
        }

    /// <summary>
    /// İşlem Gün Adedi Yatış
    /// </summary>
        public int? InpatientDayCount
        {
            get { return (int?)this["INPATIENTDAYCOUNT"]; }
            set { this["INPATIENTDAYCOUNT"] = value; }
        }

    /// <summary>
    /// Yeni Alınacak Takibin Tedavi Tipi
    /// </summary>
        public TedaviTipi MedulaProvisionTedaviTipi
        {
            get { return (TedaviTipi)((ITTObject)this).GetParent("MEDULAPROVISIONTEDAVITIPI"); }
            set { this["MEDULAPROVISIONTEDAVITIPI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Muhasebe Gelir Hesap Kırınımı ile ilişki
    /// </summary>
        public RevenueSubAccountCodeDefinition RevenueSubAccountCode
        {
            get { return (RevenueSubAccountCodeDefinition)((ITTObject)this).GetParent("REVENUESUBACCOUNTCODE"); }
            set { this["REVENUESUBACCOUNTCODE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Bağlı olduğu hizmet grubu ile ilişki
    /// </summary>
        public ProcedureTreeDefinition ProcedureTree
        {
            get { return (ProcedureTreeDefinition)((ITTObject)this).GetParent("PROCEDURETREE"); }
            set { this["PROCEDURETREE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Özel Durum
    /// </summary>
        public OzelDurum OzelDurum
        {
            get { return (OzelDurum)((ITTObject)this).GetParent("OZELDURUM"); }
            set { this["OZELDURUM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Takibin Tedavi Tipi
    /// </summary>
        public TedaviTipi TedaviTipi
        {
            get { return (TedaviTipi)((ITTObject)this).GetParent("TEDAVITIPI"); }
            set { this["TEDAVITIPI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Takibin Provizyon Tipi
    /// </summary>
        public ProvizyonTipi ProvizyonTipi
        {
            get { return (ProvizyonTipi)((ITTObject)this).GetParent("PROVIZYONTIPI"); }
            set { this["PROVIZYONTIPI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Takibin Takip Tipi
    /// </summary>
        public TakipTipi TakipTipi
        {
            get { return (TakipTipi)((ITTObject)this).GetParent("TAKIPTIPI"); }
            set { this["TAKIPTIPI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Paket Hizmet
    /// </summary>
        public PackageProcedureDefinition PackageProcedure
        {
            get { return (PackageProcedureDefinition)((ITTObject)this).GetParent("PACKAGEPROCEDURE"); }
            set { this["PACKAGEPROCEDURE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Hizmet Doktoru
    /// </summary>
        public ResUser Doctor
        {
            get { return (ResUser)((ITTObject)this).GetParent("DOCTOR"); }
            set { this["DOCTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// SKRS Loinc Kodu
    /// </summary>
        public SKRSLOINC SKRSLoincKodu
        {
            get { return (SKRSLOINC)((ITTObject)this).GetParent("SKRSLOINCKODU"); }
            set { this["SKRSLOINCKODU"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public GILDefinition GILDefinition
        {
            get { return (GILDefinition)((ITTObject)this).GetParent("GILDEFINITION"); }
            set { this["GILDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateProcedureMaterialAddingCollection()
        {
            _ProcedureMaterialAdding = new ProcedureMaterialAdding.ChildProcedureMaterialAddingCollection(this, new Guid("abe83186-872d-444a-9f9d-0adc8cb6d219"));
            ((ITTChildObjectCollection)_ProcedureMaterialAdding).GetChildren();
        }

        protected ProcedureMaterialAdding.ChildProcedureMaterialAddingCollection _ProcedureMaterialAdding = null;
    /// <summary>
    /// Child collection for İki Tarih Arası Hizmet
    /// </summary>
        public ProcedureMaterialAdding.ChildProcedureMaterialAddingCollection ProcedureMaterialAdding
        {
            get
            {
                if (_ProcedureMaterialAdding == null)
                    CreateProcedureMaterialAddingCollection();
                return _ProcedureMaterialAdding;
            }
        }

        virtual protected void CreateProtocolPriceCollection()
        {
            _ProtocolPrice = new ProtocolPriceCalculation.ChildProtocolPriceCalculationCollection(this, new Guid("f47780c2-1bda-4cb6-b1e7-88d4ec03249a"));
            ((ITTChildObjectCollection)_ProtocolPrice).GetChildren();
        }

        protected ProtocolPriceCalculation.ChildProtocolPriceCalculationCollection _ProtocolPrice = null;
        public ProtocolPriceCalculation.ChildProtocolPriceCalculationCollection ProtocolPrice
        {
            get
            {
                if (_ProtocolPrice == null)
                    CreateProtocolPriceCollection();
                return _ProtocolPrice;
            }
        }

        virtual protected void CreateProcedurePriceCollection()
        {
            _ProcedurePrice = new ProcedurePriceDefinition.ChildProcedurePriceDefinitionCollection(this, new Guid("528a437f-9f57-4271-9654-afaa5ef875af"));
            ((ITTChildObjectCollection)_ProcedurePrice).GetChildren();
        }

        protected ProcedurePriceDefinition.ChildProcedurePriceDefinitionCollection _ProcedurePrice = null;
    /// <summary>
    /// Child collection for Hizmet
    /// </summary>
        public ProcedurePriceDefinition.ChildProcedurePriceDefinitionCollection ProcedurePrice
        {
            get
            {
                if (_ProcedurePrice == null)
                    CreateProcedurePriceCollection();
                return _ProcedurePrice;
            }
        }

        virtual protected void CreateProcedureExceptionsCollection()
        {
            _ProcedureExceptions = new DiscountTypeProcedureExceptionDefinition.ChildDiscountTypeProcedureExceptionDefinitionCollection(this, new Guid("d134c196-8efe-4fb7-90cc-bb92824787c8"));
            ((ITTChildObjectCollection)_ProcedureExceptions).GetChildren();
        }

        protected DiscountTypeProcedureExceptionDefinition.ChildDiscountTypeProcedureExceptionDefinitionCollection _ProcedureExceptions = null;
    /// <summary>
    /// Child collection for Hizmet ile ilişki
    /// </summary>
        public DiscountTypeProcedureExceptionDefinition.ChildDiscountTypeProcedureExceptionDefinitionCollection ProcedureExceptions
        {
            get
            {
                if (_ProcedureExceptions == null)
                    CreateProcedureExceptionsCollection();
                return _ProcedureExceptions;
            }
        }

        virtual protected void CreateProcedureRuleSetsCollection()
        {
            _ProcedureRuleSets = new ProcedureRuleSet.ChildProcedureRuleSetCollection(this, new Guid("8b3bfa92-52c9-416a-ad5d-ebe5252d8553"));
            ((ITTChildObjectCollection)_ProcedureRuleSets).GetChildren();
        }

        protected ProcedureRuleSet.ChildProcedureRuleSetCollection _ProcedureRuleSets = null;
    /// <summary>
    /// Child collection for Hizmet-Hizmet Kural Setleri
    /// </summary>
        public ProcedureRuleSet.ChildProcedureRuleSetCollection ProcedureRuleSets
        {
            get
            {
                if (_ProcedureRuleSets == null)
                    CreateProcedureRuleSetsCollection();
                return _ProcedureRuleSets;
            }
        }

        virtual protected void CreateFormDetailCollection()
        {
            _FormDetail = new ProcedureRequestFormDetailDefinition.ChildProcedureRequestFormDetailDefinitionCollection(this, new Guid("ac62c868-ae58-4398-b872-c76f4411cc59"));
            ((ITTChildObjectCollection)_FormDetail).GetChildren();
        }

        protected ProcedureRequestFormDetailDefinition.ChildProcedureRequestFormDetailDefinitionCollection _FormDetail = null;
    /// <summary>
    /// Child collection for Hizmet Bilgisi
    /// </summary>
        public ProcedureRequestFormDetailDefinition.ChildProcedureRequestFormDetailDefinitionCollection FormDetail
        {
            get
            {
                if (_FormDetail == null)
                    CreateFormDetailCollection();
                return _FormDetail;
            }
        }

        virtual protected void CreateTitleParticipationProcDefCollection()
        {
            _TitleParticipationProcDef = new TitleParticipationProcDef.ChildTitleParticipationProcDefCollection(this, new Guid("c8669332-5809-4328-9ca0-1e4beb862d89"));
            ((ITTChildObjectCollection)_TitleParticipationProcDef).GetChildren();
        }

        protected TitleParticipationProcDef.ChildTitleParticipationProcDefCollection _TitleParticipationProcDef = null;
    /// <summary>
    /// Child collection for Hizmet
    /// </summary>
        public TitleParticipationProcDef.ChildTitleParticipationProcDefCollection TitleParticipationProcDef
        {
            get
            {
                if (_TitleParticipationProcDef == null)
                    CreateTitleParticipationProcDefCollection();
                return _TitleParticipationProcDef;
            }
        }

        virtual protected void CreateGeneralReceiptProcedureCollection()
        {
            _GeneralReceiptProcedure = new GeneralReceiptProcedure.ChildGeneralReceiptProcedureCollection(this, new Guid("8e280974-0f9a-428c-8c93-2a59ef6ab929"));
            ((ITTChildObjectCollection)_GeneralReceiptProcedure).GetChildren();
        }

        protected GeneralReceiptProcedure.ChildGeneralReceiptProcedureCollection _GeneralReceiptProcedure = null;
    /// <summary>
    /// Child collection for Hizmetle ilişki
    /// </summary>
        public GeneralReceiptProcedure.ChildGeneralReceiptProcedureCollection GeneralReceiptProcedure
        {
            get
            {
                if (_GeneralReceiptProcedure == null)
                    CreateGeneralReceiptProcedureCollection();
                return _GeneralReceiptProcedure;
            }
        }

        virtual protected void CreatePriceUpdatingCollection()
        {
            _PriceUpdating = new PriceUpdating.ChildPriceUpdatingCollection(this, new Guid("a288aad9-c0ca-4885-bcff-eb6031ede2e7"));
            ((ITTChildObjectCollection)_PriceUpdating).GetChildren();
        }

        protected PriceUpdating.ChildPriceUpdatingCollection _PriceUpdating = null;
    /// <summary>
    /// Child collection for Hizmet ile ilişki
    /// </summary>
        public PriceUpdating.ChildPriceUpdatingCollection PriceUpdating
        {
            get
            {
                if (_PriceUpdating == null)
                    CreatePriceUpdatingCollection();
                return _PriceUpdating;
            }
        }

        virtual protected void CreateGeneralInvoiceProcedureCollection()
        {
            _GeneralInvoiceProcedure = new GeneralInvoiceProcedure.ChildGeneralInvoiceProcedureCollection(this, new Guid("f040875f-e733-4629-a855-ebdd940b6437"));
            ((ITTChildObjectCollection)_GeneralInvoiceProcedure).GetChildren();
        }

        protected GeneralInvoiceProcedure.ChildGeneralInvoiceProcedureCollection _GeneralInvoiceProcedure = null;
    /// <summary>
    /// Child collection for Hizmetle ilişki
    /// </summary>
        public GeneralInvoiceProcedure.ChildGeneralInvoiceProcedureCollection GeneralInvoiceProcedure
        {
            get
            {
                if (_GeneralInvoiceProcedure == null)
                    CreateGeneralInvoiceProcedureCollection();
                return _GeneralInvoiceProcedure;
            }
        }

        virtual protected void CreateSubProcedureDefinitionsCollection()
        {
            _SubProcedureDefinitions = new SubProcedureDefinition.ChildSubProcedureDefinitionCollection(this, new Guid("70a10c18-0ddf-48c3-a484-57d18f3c6a2e"));
            ((ITTChildObjectCollection)_SubProcedureDefinitions).GetChildren();
        }

        protected SubProcedureDefinition.ChildSubProcedureDefinitionCollection _SubProcedureDefinitions = null;
        public SubProcedureDefinition.ChildSubProcedureDefinitionCollection SubProcedureDefinitions
        {
            get
            {
                if (_SubProcedureDefinitions == null)
                    CreateSubProcedureDefinitionsCollection();
                return _SubProcedureDefinitions;
            }
        }

        virtual protected void CreateAccountingProcessCollection()
        {
            _AccountingProcess = new AccountingProcess.ChildAccountingProcessCollection(this, new Guid("7b742641-b99a-4c73-a7a4-62cb455a3b90"));
            ((ITTChildObjectCollection)_AccountingProcess).GetChildren();
        }

        protected AccountingProcess.ChildAccountingProcessCollection _AccountingProcess = null;
    /// <summary>
    /// Child collection for Hizmet
    /// </summary>
        public AccountingProcess.ChildAccountingProcessCollection AccountingProcess
        {
            get
            {
                if (_AccountingProcess == null)
                    CreateAccountingProcessCollection();
                return _AccountingProcess;
            }
        }

        virtual protected void CreateTransferFromPackageCollection()
        {
            _TransferFromPackage = new TransferFromPackage.ChildTransferFromPackageCollection(this, new Guid("d06d99e0-cc45-4cf1-8b85-6a2a32dee370"));
            ((ITTChildObjectCollection)_TransferFromPackage).GetChildren();
        }

        protected TransferFromPackage.ChildTransferFromPackageCollection _TransferFromPackage = null;
    /// <summary>
    /// Child collection for Hizmet
    /// </summary>
        public TransferFromPackage.ChildTransferFromPackageCollection TransferFromPackage
        {
            get
            {
                if (_TransferFromPackage == null)
                    CreateTransferFromPackageCollection();
                return _TransferFromPackage;
            }
        }

        virtual protected void CreatePackageTransferCollection()
        {
            _PackageTransfer = new PackageTransfer.ChildPackageTransferCollection(this, new Guid("d4786d7c-1637-450a-a3f9-2586705a7bae"));
            ((ITTChildObjectCollection)_PackageTransfer).GetChildren();
        }

        protected PackageTransfer.ChildPackageTransferCollection _PackageTransfer = null;
    /// <summary>
    /// Child collection for Hizmet
    /// </summary>
        public PackageTransfer.ChildPackageTransferCollection PackageTransfer
        {
            get
            {
                if (_PackageTransfer == null)
                    CreatePackageTransferCollection();
                return _PackageTransfer;
            }
        }

        virtual protected void CreateIIMNQLProcedureMaterialsCollection()
        {
            _IIMNQLProcedureMaterials = new IIMNQLProcedureMaterial.ChildIIMNQLProcedureMaterialCollection(this, new Guid("7c20b0b3-a809-4cc4-8b31-05980731c012"));
            ((ITTChildObjectCollection)_IIMNQLProcedureMaterials).GetChildren();
        }

        protected IIMNQLProcedureMaterial.ChildIIMNQLProcedureMaterialCollection _IIMNQLProcedureMaterials = null;
    /// <summary>
    /// Child collection for Kural Sonuç Hizmet Bilgisi
    /// </summary>
        public IIMNQLProcedureMaterial.ChildIIMNQLProcedureMaterialCollection IIMNQLProcedureMaterials
        {
            get
            {
                if (_IIMNQLProcedureMaterials == null)
                    CreateIIMNQLProcedureMaterialsCollection();
                return _IIMNQLProcedureMaterials;
            }
        }

        virtual protected void CreatePatientOldDebtCollection()
        {
            _PatientOldDebt = new PatientOldDebt.ChildPatientOldDebtCollection(this, new Guid("eafe7b6a-10b3-4d24-bc43-62a31d898ed0"));
            ((ITTChildObjectCollection)_PatientOldDebt).GetChildren();
        }

        protected PatientOldDebt.ChildPatientOldDebtCollection _PatientOldDebt = null;
        public PatientOldDebt.ChildPatientOldDebtCollection PatientOldDebt
        {
            get
            {
                if (_PatientOldDebt == null)
                    CreatePatientOldDebtCollection();
                return _PatientOldDebt;
            }
        }

        virtual protected void CreateSuggestionCasesCollection()
        {
            _SuggestionCases = new SuggestionCase.ChildSuggestionCaseCollection(this, new Guid("3671ffdd-ad7c-41ff-8c0d-f86478cf4a3a"));
            ((ITTChildObjectCollection)_SuggestionCases).GetChildren();
        }

        protected SuggestionCase.ChildSuggestionCaseCollection _SuggestionCases = null;
        public SuggestionCase.ChildSuggestionCaseCollection SuggestionCases
        {
            get
            {
                if (_SuggestionCases == null)
                    CreateSuggestionCasesCollection();
                return _SuggestionCases;
            }
        }

        virtual protected void CreateProcedureMaterialMatchesCollection()
        {
            _ProcedureMaterialMatches = new ProcedureMaterialMatch.ChildProcedureMaterialMatchCollection(this, new Guid("6686c697-9f6e-45ec-b8ea-a3b90e0ba74b"));
            ((ITTChildObjectCollection)_ProcedureMaterialMatches).GetChildren();
        }

        protected ProcedureMaterialMatch.ChildProcedureMaterialMatchCollection _ProcedureMaterialMatches = null;
        public ProcedureMaterialMatch.ChildProcedureMaterialMatchCollection ProcedureMaterialMatches
        {
            get
            {
                if (_ProcedureMaterialMatches == null)
                    CreateProcedureMaterialMatchesCollection();
                return _ProcedureMaterialMatches;
            }
        }

        virtual protected void CreateRequiredDiagnoseProceduresCollection()
        {
            _RequiredDiagnoseProcedures = new RequiredDiagnoseProcedure.ChildRequiredDiagnoseProcedureCollection(this, new Guid("4b021478-76e0-4232-9fc0-37391d3e3be8"));
            ((ITTChildObjectCollection)_RequiredDiagnoseProcedures).GetChildren();
        }

        protected RequiredDiagnoseProcedure.ChildRequiredDiagnoseProcedureCollection _RequiredDiagnoseProcedures = null;
        public RequiredDiagnoseProcedure.ChildRequiredDiagnoseProcedureCollection RequiredDiagnoseProcedures
        {
            get
            {
                if (_RequiredDiagnoseProcedures == null)
                    CreateRequiredDiagnoseProceduresCollection();
                return _RequiredDiagnoseProcedures;
            }
        }

        virtual protected void CreateMaterialProceduresCollection()
        {
            _MaterialProcedures = new MaterialProcedures.ChildMaterialProceduresCollection(this, new Guid("f29b4342-8221-4aa0-85f9-c4c827f7d49b"));
            ((ITTChildObjectCollection)_MaterialProcedures).GetChildren();
        }

        protected MaterialProcedures.ChildMaterialProceduresCollection _MaterialProcedures = null;
        public MaterialProcedures.ChildMaterialProceduresCollection MaterialProcedures
        {
            get
            {
                if (_MaterialProcedures == null)
                    CreateMaterialProceduresCollection();
                return _MaterialProcedures;
            }
        }

        protected ProcedureDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ProcedureDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ProcedureDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ProcedureDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ProcedureDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PROCEDUREDEFINITION", dataRow) { }
        protected ProcedureDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PROCEDUREDEFINITION", dataRow, isImported) { }
        public ProcedureDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ProcedureDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ProcedureDefinition() : base() { }

    }
}