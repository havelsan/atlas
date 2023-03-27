
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SurgeryDefinition")] 

    /// <summary>
    /// Ameliyat-Tıbbı Cerrahi- Ek Uygulama Tanımlama
    /// </summary>
    public  partial class SurgeryDefinition : ProcedureDefinition, IProcedureRequestDefinition
    {
        public class SurgeryDefinitionList : TTObjectCollection<SurgeryDefinition> { }
                    
        public class ChildSurgeryDefinitionCollection : TTObject.TTChildObjectCollection<SurgeryDefinition>
        {
            public ChildSurgeryDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSurgeryDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSurgeryDefinition_Class : TTReportNqlObject 
        {
            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].AllPropertyDefs["ENGLISHNAME"].DataType;
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

            public GetSurgeryDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSurgeryDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSurgeryDefinition_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetSurgeryDefinition_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].AllPropertyDefs["NAME"].DataType;
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

            public SurgeryPointGroupEnum? SurgeryPointGroup
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SURGERYPOINTGROUP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].AllPropertyDefs["SURGERYPOINTGROUP"].DataType;
                    return (SurgeryPointGroupEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public OLAP_GetSurgeryDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetSurgeryDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetSurgeryDefinition_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetSurgeryDefinition_WithDate_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].AllPropertyDefs["NAME"].DataType;
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

            public SurgeryPointGroupEnum? SurgeryPointGroup
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SURGERYPOINTGROUP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].AllPropertyDefs["SURGERYPOINTGROUP"].DataType;
                    return (SurgeryPointGroupEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public OLAP_GetSurgeryDefinition_WithDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetSurgeryDefinition_WithDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetSurgeryDefinition_WithDate_Class() : base() { }
        }

        [Serializable] 

        public partial class GetRelatedPhysiotherapyForm_Class : TTReportNqlObject 
        {
            public PhysiotherapyFormsEnum? PhysiotherapyFormName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PHYSIOTHERAPYFORMNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].AllPropertyDefs["PHYSIOTHERAPYFORMNAME"].DataType;
                    return (PhysiotherapyFormsEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GetRelatedPhysiotherapyForm_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetRelatedPhysiotherapyForm_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetRelatedPhysiotherapyForm_Class() : base() { }
        }

        [Serializable] 

        public partial class GetNeedDescription_Class : TTReportNqlObject 
        {
            public bool? IsDescriptionNeeded
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISDESCRIPTIONNEEDED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].AllPropertyDefs["ISDESCRIPTIONNEEDED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public GetNeedDescription_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetNeedDescription_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetNeedDescription_Class() : base() { }
        }

        [Serializable] 

        public partial class GetSurgeryDefinitionNQL_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Codeandname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["CODEANDNAME"]);
                }
            }

            public GetSurgeryDefinitionNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSurgeryDefinitionNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSurgeryDefinitionNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class GetAdditionalApplication_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].AllPropertyDefs["CHARGABLE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].AllPropertyDefs["ENGLISHNAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].AllPropertyDefs["QREF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].AllPropertyDefs["SUTAPPENDIX"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].AllPropertyDefs["ONAMFORMUISTE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].AllPropertyDefs["NAME_SHADOW"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].AllPropertyDefs["CREATEINMEDULADONTSENDSTATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].AllPropertyDefs["PREPROCEDUREENTRYNECESSITY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].AllPropertyDefs["MEDULAPROCEDURETYPE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].AllPropertyDefs["MEDULAREPORTNECESSITY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].AllPropertyDefs["DAILYMEDULAPROVISIONNECESSITY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].AllPropertyDefs["GILCODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].AllPropertyDefs["GILPOINT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].AllPropertyDefs["DONTBLOCKINVOICE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].AllPropertyDefs["SUTCODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].AllPropertyDefs["QUICKENTRYALLOWED"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].AllPropertyDefs["REPORTSELECTIONREQUIRED"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].AllPropertyDefs["EXTERNALID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].AllPropertyDefs["ISDESCRIPTIONNEEDED"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].AllPropertyDefs["PARTICIPATIONPROCEDURE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].AllPropertyDefs["GILNAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].AllPropertyDefs["REPETITIONQUERYNEEDED"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].AllPropertyDefs["ISRESULTNEEDED"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].AllPropertyDefs["PROCEDURETYPE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].AllPropertyDefs["RIGHTLEFTINFONEEDED"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].AllPropertyDefs["ISVISIBLE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].AllPropertyDefs["CONTROLDAYCOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].AllPropertyDefs["DAILYDAYCOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].AllPropertyDefs["EMERGENCYDAYCOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].AllPropertyDefs["EXAMINATIONDAYCOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].AllPropertyDefs["FORBIDDENFORCONTROL"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].AllPropertyDefs["FORBIDDENFORDAILY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].AllPropertyDefs["FORBIDDENFOREMERGENCY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].AllPropertyDefs["FORBIDDENFOREXAMINATION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].AllPropertyDefs["FORBIDDENFORINPATIENT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].AllPropertyDefs["HUVCODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].AllPropertyDefs["HUVPOINT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].AllPropertyDefs["SUTPOINT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].AllPropertyDefs["EXTERNALOPERATION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].AllPropertyDefs["PATHOLOGYOPERATIONNEEDED"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].AllPropertyDefs["QUALIFIEDMEDICALPROCESS"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].AllPropertyDefs["INPATIENTDAYCOUNT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public SurgeryPointGroupEnum? SurgeryPointGroup
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SURGERYPOINTGROUP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].AllPropertyDefs["SURGERYPOINTGROUP"].DataType;
                    return (SurgeryPointGroupEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public SurgeryProcedureGroup? SUTGroup
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUTGROUP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].AllPropertyDefs["SUTGROUP"].DataType;
                    return (SurgeryProcedureGroup?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? InVitroFertilizationProcess
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INVITROFERTILIZATIONPROCESS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].AllPropertyDefs["INVITROFERTILIZATIONPROCESS"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? ReportIsRequired
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTISREQUIRED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].AllPropertyDefs["REPORTISREQUIRED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public SurgeyProcedureTypeEnum? SurgeryProcedureType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SURGERYPROCEDURETYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].AllPropertyDefs["SURGERYPROCEDURETYPE"].DataType;
                    return (SurgeyProcedureTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public SurgeryProcedureGroup? GILGroup
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GILGROUP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].AllPropertyDefs["GILGROUP"].DataType;
                    return (SurgeryProcedureGroup?)(int)dataType.ConvertValue(val);
                }
            }

            public PhysiotherapyFormsEnum? PhysiotherapyFormName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PHYSIOTHERAPYFORMNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].AllPropertyDefs["PHYSIOTHERAPYFORMNAME"].DataType;
                    return (PhysiotherapyFormsEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public ManipulationFormNameEnum? ManipulationFormName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MANIPULATIONFORMNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].AllPropertyDefs["MANIPULATIONFORMNAME"].DataType;
                    return (ManipulationFormNameEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? IsDescriptionNeeded_1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISDESCRIPTIONNEEDED_1"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].AllPropertyDefs["ISDESCRIPTIONNEEDED_1"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsNeedEuroScore
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISNEEDEUROSCORE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].AllPropertyDefs["ISNEEDEUROSCORE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsNeedKvcScore
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISNEEDKVCSCORE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].AllPropertyDefs["ISNEEDKVCSCORE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public ManipulationStartStateEnum? ManipulationStartState
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MANIPULATIONSTARTSTATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].AllPropertyDefs["MANIPULATIONSTARTSTATE"].DataType;
                    return (ManipulationStartStateEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public int? SurgeryDuration
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SURGERYDURATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].AllPropertyDefs["SURGERYDURATION"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string PreInformation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PREINFORMATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].AllPropertyDefs["PREINFORMATION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsSurgery
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISSURGERY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].AllPropertyDefs["ISSURGERY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsManipulation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISMANIPULATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].AllPropertyDefs["ISMANIPULATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsAdditionalApplication
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISADDITIONALAPPLICATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].AllPropertyDefs["ISADDITIONALAPPLICATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public GetAdditionalApplication_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAdditionalApplication_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAdditionalApplication_Class() : base() { }
        }

        public static BindingList<SurgeryDefinition.GetSurgeryDefinition_Class> GetSurgeryDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].QueryDefs["GetSurgeryDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SurgeryDefinition.GetSurgeryDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SurgeryDefinition.GetSurgeryDefinition_Class> GetSurgeryDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].QueryDefs["GetSurgeryDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SurgeryDefinition.GetSurgeryDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SurgeryDefinition.OLAP_GetSurgeryDefinition_Class> OLAP_GetSurgeryDefinition(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].QueryDefs["OLAP_GetSurgeryDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SurgeryDefinition.OLAP_GetSurgeryDefinition_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SurgeryDefinition.OLAP_GetSurgeryDefinition_Class> OLAP_GetSurgeryDefinition(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].QueryDefs["OLAP_GetSurgeryDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SurgeryDefinition.OLAP_GetSurgeryDefinition_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SurgeryDefinition> GetSurgeryDefinionObjects(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].QueryDefs["GetSurgeryDefinionObjects"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<SurgeryDefinition>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<SurgeryDefinition.OLAP_GetSurgeryDefinition_WithDate_Class> OLAP_GetSurgeryDefinition_WithDate(DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].QueryDefs["OLAP_GetSurgeryDefinition_WithDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<SurgeryDefinition.OLAP_GetSurgeryDefinition_WithDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SurgeryDefinition.OLAP_GetSurgeryDefinition_WithDate_Class> OLAP_GetSurgeryDefinition_WithDate(TTObjectContext objectContext, DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].QueryDefs["OLAP_GetSurgeryDefinition_WithDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<SurgeryDefinition.OLAP_GetSurgeryDefinition_WithDate_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SurgeryDefinition> GetSurgeryProceduresByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].QueryDefs["GetSurgeryProceduresByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<SurgeryDefinition>(queryDef, paramList);
        }

        public static BindingList<SurgeryDefinition.GetRelatedPhysiotherapyForm_Class> GetRelatedPhysiotherapyForm(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].QueryDefs["GetRelatedPhysiotherapyForm"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SurgeryDefinition.GetRelatedPhysiotherapyForm_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SurgeryDefinition.GetRelatedPhysiotherapyForm_Class> GetRelatedPhysiotherapyForm(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].QueryDefs["GetRelatedPhysiotherapyForm"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SurgeryDefinition.GetRelatedPhysiotherapyForm_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SurgeryDefinition.GetNeedDescription_Class> GetNeedDescription(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].QueryDefs["GetNeedDescription"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SurgeryDefinition.GetNeedDescription_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SurgeryDefinition.GetNeedDescription_Class> GetNeedDescription(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].QueryDefs["GetNeedDescription"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SurgeryDefinition.GetNeedDescription_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SurgeryDefinition> GetSurgeryDefinitionByObjectID(TTObjectContext objectContext, Guid OBJECTID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].QueryDefs["GetSurgeryDefinitionByObjectID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return ((ITTQuery)objectContext).QueryObjects<SurgeryDefinition>(queryDef, paramList);
        }

        public static BindingList<SurgeryDefinition.GetSurgeryDefinitionNQL_Class> GetSurgeryDefinitionNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].QueryDefs["GetSurgeryDefinitionNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SurgeryDefinition.GetSurgeryDefinitionNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SurgeryDefinition.GetSurgeryDefinitionNQL_Class> GetSurgeryDefinitionNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].QueryDefs["GetSurgeryDefinitionNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SurgeryDefinition.GetSurgeryDefinitionNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SurgeryDefinition.GetAdditionalApplication_Class> GetAdditionalApplication(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].QueryDefs["GetAdditionalApplication"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SurgeryDefinition.GetAdditionalApplication_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SurgeryDefinition.GetAdditionalApplication_Class> GetAdditionalApplication(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].QueryDefs["GetAdditionalApplication"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SurgeryDefinition.GetAdditionalApplication_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Ameliyat Puan Grubu
    /// </summary>
        public SurgeryPointGroupEnum? SurgeryPointGroup
        {
            get { return (SurgeryPointGroupEnum?)(int?)this["SURGERYPOINTGROUP"]; }
            set { this["SURGERYPOINTGROUP"] = value; }
        }

    /// <summary>
    /// Ameliyat SUT Grubu
    /// </summary>
        public SurgeryProcedureGroup? SUTGroup
        {
            get { return (SurgeryProcedureGroup?)(int?)this["SUTGROUP"]; }
            set { this["SUTGROUP"] = value; }
        }

    /// <summary>
    /// Tüp Bebek İşlemi
    /// </summary>
        public bool? InVitroFertilizationProcess
        {
            get { return (bool?)this["INVITROFERTILIZATIONPROCESS"]; }
            set { this["INVITROFERTILIZATIONPROCESS"] = value; }
        }

        public bool? ReportIsRequired
        {
            get { return (bool?)this["REPORTISREQUIRED"]; }
            set { this["REPORTISREQUIRED"] = value; }
        }

    /// <summary>
    /// İşlem Tipi
    /// </summary>
        public SurgeyProcedureTypeEnum? SurgeryProcedureType
        {
            get { return (SurgeyProcedureTypeEnum?)(int?)this["SURGERYPROCEDURETYPE"]; }
            set { this["SURGERYPROCEDURETYPE"] = value; }
        }

    /// <summary>
    /// Ameliyat GIL Grubu
    /// </summary>
        public SurgeryProcedureGroup? GILGroup
        {
            get { return (SurgeryProcedureGroup?)(int?)this["GILGROUP"]; }
            set { this["GILGROUP"] = value; }
        }

        public PhysiotherapyFormsEnum? PhysiotherapyFormName
        {
            get { return (PhysiotherapyFormsEnum?)(int?)this["PHYSIOTHERAPYFORMNAME"]; }
            set { this["PHYSIOTHERAPYFORMNAME"] = value; }
        }

    /// <summary>
    /// İlgili Manipulasyon Form Adı
    /// </summary>
        public ManipulationFormNameEnum? ManipulationFormName
        {
            get { return (ManipulationFormNameEnum?)(int?)this["MANIPULATIONFORMNAME"]; }
            set { this["MANIPULATIONFORMNAME"] = value; }
        }

    /// <summary>
    /// Açıklama gerekliliği
    /// </summary>
        public bool? IsDescriptionNeeded_1
        {
            get { return (bool?)this["ISDESCRIPTIONNEEDED_1"]; }
            set { this["ISDESCRIPTIONNEEDED_1"] = value; }
        }

        public bool? IsNeedEuroScore
        {
            get { return (bool?)this["ISNEEDEUROSCORE"]; }
            set { this["ISNEEDEUROSCORE"] = value; }
        }

        public bool? IsNeedKvcScore
        {
            get { return (bool?)this["ISNEEDKVCSCORE"]; }
            set { this["ISNEEDKVCSCORE"] = value; }
        }

    /// <summary>
    /// İlgili Manipulasyon Başlangıç Adımı
    /// </summary>
        public ManipulationStartStateEnum? ManipulationStartState
        {
            get { return (ManipulationStartStateEnum?)(int?)this["MANIPULATIONSTARTSTATE"]; }
            set { this["MANIPULATIONSTARTSTATE"] = value; }
        }

    /// <summary>
    /// Tahmini Ameliyat Süresi
    /// </summary>
        public int? SurgeryDuration
        {
            get { return (int?)this["SURGERYDURATION"]; }
            set { this["SURGERYDURATION"] = value; }
        }

        public string PreInformation
        {
            get { return (string)this["PREINFORMATION"]; }
            set { this["PREINFORMATION"] = value; }
        }

    /// <summary>
    /// İşlem tipi combosu yerine
    /// </summary>
        public bool? IsSurgery
        {
            get { return (bool?)this["ISSURGERY"]; }
            set { this["ISSURGERY"] = value; }
        }

    /// <summary>
    /// İşlem tipi combosu yerine
    /// </summary>
        public bool? IsManipulation
        {
            get { return (bool?)this["ISMANIPULATION"]; }
            set { this["ISMANIPULATION"] = value; }
        }

    /// <summary>
    /// İşlem tipi combosu yerine
    /// </summary>
        public bool? IsAdditionalApplication
        {
            get { return (bool?)this["ISADDITIONALAPPLICATION"]; }
            set { this["ISADDITIONALAPPLICATION"] = value; }
        }

        public Resource Resource
        {
            get { return (Resource)((ITTObject)this).GetParent("RESOURCE"); }
            set { this["RESOURCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateDepartmentsCollection()
        {
            _Departments = new ManipulationDepartmentGrid.ChildManipulationDepartmentGridCollection(this, new Guid("898d5605-2fdd-4417-b1af-560107a6c49a"));
            ((ITTChildObjectCollection)_Departments).GetChildren();
        }

        protected ManipulationDepartmentGrid.ChildManipulationDepartmentGridCollection _Departments = null;
        public ManipulationDepartmentGrid.ChildManipulationDepartmentGridCollection Departments
        {
            get
            {
                if (_Departments == null)
                    CreateDepartmentsCollection();
                return _Departments;
            }
        }

        virtual protected void CreateSurgeryCodelessMaterialsCollection()
        {
            _SurgeryCodelessMaterials = new SurgeryCodelessMaterial.ChildSurgeryCodelessMaterialCollection(this, new Guid("a4b715c6-0682-41de-8a57-03bcd993d4bd"));
            ((ITTChildObjectCollection)_SurgeryCodelessMaterials).GetChildren();
        }

        protected SurgeryCodelessMaterial.ChildSurgeryCodelessMaterialCollection _SurgeryCodelessMaterials = null;
        public SurgeryCodelessMaterial.ChildSurgeryCodelessMaterialCollection SurgeryCodelessMaterials
        {
            get
            {
                if (_SurgeryCodelessMaterials == null)
                    CreateSurgeryCodelessMaterialsCollection();
                return _SurgeryCodelessMaterials;
            }
        }

        virtual protected void CreateBranchesCollection()
        {
            _Branches = new SurgeryBranchDefinition.ChildSurgeryBranchDefinitionCollection(this, new Guid("a8ae04b5-6558-48e2-bffe-20ff18d00a08"));
            ((ITTChildObjectCollection)_Branches).GetChildren();
        }

        protected SurgeryBranchDefinition.ChildSurgeryBranchDefinitionCollection _Branches = null;
    /// <summary>
    /// Child collection for Ameliyat Branş İlişkisi
    /// </summary>
        public SurgeryBranchDefinition.ChildSurgeryBranchDefinitionCollection Branches
        {
            get
            {
                if (_Branches == null)
                    CreateBranchesCollection();
                return _Branches;
            }
        }

        protected SurgeryDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SurgeryDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SurgeryDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SurgeryDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SurgeryDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SURGERYDEFINITION", dataRow) { }
        protected SurgeryDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SURGERYDEFINITION", dataRow, isImported) { }
        public SurgeryDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SurgeryDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SurgeryDefinition() : base() { }

    }
}