
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DiagnosisDefinition")] 

    /// <summary>
    /// Tanı
    /// </summary>
    public  partial class DiagnosisDefinition : TerminologyManagerDef, ITTListTreeObject, ISUTRulableDiagnosis
    {
        public class DiagnosisDefinitionList : TTObjectCollection<DiagnosisDefinition> { }
                    
        public class ChildDiagnosisDefinitionCollection : TTObject.TTChildObjectCollection<DiagnosisDefinition>
        {
            public ChildDiagnosisDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDiagnosisDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetDiagnosisDefinition_Class : TTReportNqlObject 
        {
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

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetDiagnosisDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDiagnosisDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDiagnosisDefinition_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_DiagnosisDefinition_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ParentGroupCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PARENTGROUPCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["PARENTGROUPCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Parentgroupobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PARENTGROUPOBJECTID"]);
                }
            }

            public OLAP_DiagnosisDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_DiagnosisDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_DiagnosisDefinition_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDiagnosisDefinitionByDiagnosisCode_Class : TTReportNqlObject 
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

            public string Type
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["TYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? Level
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LEVEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["LEVEL"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public bool? SendBulasiciHastalikBildirim
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SENDBULASICIHASTALIKBILDIRIM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["SENDBULASICIHASTALIKBILDIRIM"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? CausesMotherDeath
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CAUSESMOTHERDEATH"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["CAUSESMOTHERDEATH"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public int? Precision
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRECISION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["PRECISION"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public bool? IsLeaf
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISLEAF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["ISLEAF"].DataType;
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

            public string Code_Shadow
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE_SHADOW"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["CODE_SHADOW"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string KamaStar
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KAMASTAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["KAMASTAR"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? CausesDeath
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CAUSESDEATH"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["CAUSESDEATH"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string ParentGroupCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PARENTGROUPCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["PARENTGROUPCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? DialysisReportNotMust
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIALYSISREPORTNOTMUST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["DIALYSISREPORTNOTMUST"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public InfectiousIllnesesInformationGroup? InfectiousIllnesesInfoGroup
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INFECTIOUSILLNESESINFOGROUP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["INFECTIOUSILLNESESINFOGROUP"].DataType;
                    return (InfectiousIllnesesInformationGroup?)(int)dataType.ConvertValue(val);
                }
            }

            public FTRDiagnosisGroupEnum? FtrDiagnoseGroup
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FTRDIAGNOSEGROUP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["FTRDIAGNOSEGROUP"].DataType;
                    return (FTRDiagnosisGroupEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Name_Shadow
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME_SHADOW"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["NAME_SHADOW"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsInfluenzaDiagnos
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISINFLUENZADIAGNOS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["ISINFLUENZADIAGNOS"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? HighRiskPregnancy
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HIGHRISKPREGNANCY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["HIGHRISKPREGNANCY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? PregnancyDiagnos
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PREGNANCYDIAGNOS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["PREGNANCYDIAGNOS"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? SendSms
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SENDSMS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["SENDSMS"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string SMSText
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SMSTEXT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["SMSTEXT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetDiagnosisDefinitionByDiagnosisCode_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDiagnosisDefinitionByDiagnosisCode_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDiagnosisDefinitionByDiagnosisCode_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDiagnosisDef_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["NAME"].DataType;
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

            public GetDiagnosisDef_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDiagnosisDef_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDiagnosisDef_Class() : base() { }
        }

        public static BindingList<DiagnosisDefinition.GetDiagnosisDefinition_Class> GetDiagnosisDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].QueryDefs["GetDiagnosisDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DiagnosisDefinition.GetDiagnosisDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DiagnosisDefinition.GetDiagnosisDefinition_Class> GetDiagnosisDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].QueryDefs["GetDiagnosisDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DiagnosisDefinition.GetDiagnosisDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DiagnosisDefinition.OLAP_DiagnosisDefinition_Class> OLAP_DiagnosisDefinition(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].QueryDefs["OLAP_DiagnosisDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DiagnosisDefinition.OLAP_DiagnosisDefinition_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DiagnosisDefinition.OLAP_DiagnosisDefinition_Class> OLAP_DiagnosisDefinition(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].QueryDefs["OLAP_DiagnosisDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DiagnosisDefinition.OLAP_DiagnosisDefinition_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DiagnosisDefinition> GetDiagnosisDefinitionByCode(TTObjectContext objectContext, string CODE, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].QueryDefs["GetDiagnosisDefinitionByCode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("CODE", CODE);

            return ((ITTQuery)objectContext).QueryObjects<DiagnosisDefinition>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<DiagnosisDefinition> GetDiagnosisDefinitions(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].QueryDefs["GetDiagnosisDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<DiagnosisDefinition>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<DiagnosisDefinition> GetDiagnosisDefByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].QueryDefs["GetDiagnosisDefByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<DiagnosisDefinition>(queryDef, paramList);
        }

        public static BindingList<DiagnosisDefinition.GetDiagnosisDefinitionByDiagnosisCode_Class> GetDiagnosisDefinitionByDiagnosisCode(string CODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].QueryDefs["GetDiagnosisDefinitionByDiagnosisCode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("CODE", CODE);

            return TTReportNqlObject.QueryObjects<DiagnosisDefinition.GetDiagnosisDefinitionByDiagnosisCode_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DiagnosisDefinition.GetDiagnosisDefinitionByDiagnosisCode_Class> GetDiagnosisDefinitionByDiagnosisCode(TTObjectContext objectContext, string CODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].QueryDefs["GetDiagnosisDefinitionByDiagnosisCode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("CODE", CODE);

            return TTReportNqlObject.QueryObjects<DiagnosisDefinition.GetDiagnosisDefinitionByDiagnosisCode_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DiagnosisDefinition.GetDiagnosisDef_Class> GetDiagnosisDef(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].QueryDefs["GetDiagnosisDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DiagnosisDefinition.GetDiagnosisDef_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DiagnosisDefinition.GetDiagnosisDef_Class> GetDiagnosisDef(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].QueryDefs["GetDiagnosisDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DiagnosisDefinition.GetDiagnosisDef_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Tanı Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Tanı Tipi
    /// </summary>
        public string Type
        {
            get { return (string)this["TYPE"]; }
            set { this["TYPE"] = value; }
        }

    /// <summary>
    /// Seviye
    /// </summary>
        public int? Level
        {
            get { return (int?)this["LEVEL"]; }
            set { this["LEVEL"] = value; }
        }

    /// <summary>
    /// E Nabız Bildirimi Zorunlu Hastalıklar
    /// </summary>
        public bool? SendBulasiciHastalikBildirim
        {
            get { return (bool?)this["SENDBULASICIHASTALIKBILDIRIM"]; }
            set { this["SENDBULASICIHASTALIKBILDIRIM"] = value; }
        }

    /// <summary>
    /// Anne Ölümü
    /// </summary>
        public bool? CausesMotherDeath
        {
            get { return (bool?)this["CAUSESMOTHERDEATH"]; }
            set { this["CAUSESMOTHERDEATH"] = value; }
        }

    /// <summary>
    /// Kod Hane Sayısı
    /// </summary>
        public int? Precision
        {
            get { return (int?)this["PRECISION"]; }
            set { this["PRECISION"] = value; }
        }

        public bool? IsLeaf
        {
            get { return (bool?)this["ISLEAF"]; }
            set { this["ISLEAF"] = value; }
        }

    /// <summary>
    /// Code
    /// </summary>
        public string Code
        {
            get { return (string)this["CODE"]; }
            set { this["CODE"] = value; }
        }

        public string Code_Shadow
        {
            get { return (string)this["CODE_SHADOW"]; }
        }

    /// <summary>
    /// Kama Yıldız
    /// </summary>
        public string KamaStar
        {
            get { return (string)this["KAMASTAR"]; }
            set { this["KAMASTAR"] = value; }
        }

    /// <summary>
    /// Ölüm Nedeni
    /// </summary>
        public bool? CausesDeath
        {
            get { return (bool?)this["CAUSESDEATH"]; }
            set { this["CAUSESDEATH"] = value; }
        }

    /// <summary>
    /// Üst Kodu
    /// </summary>
        public string ParentGroupCode
        {
            get { return (string)this["PARENTGROUPCODE"]; }
            set { this["PARENTGROUPCODE"] = value; }
        }

    /// <summary>
    /// Dializ Raporu Zorunlu Olmayan Tanı
    /// </summary>
        public bool? DialysisReportNotMust
        {
            get { return (bool?)this["DIALYSISREPORTNOTMUST"]; }
            set { this["DIALYSISREPORTNOTMUST"] = value; }
        }

        public InfectiousIllnesesInformationGroup? InfectiousIllnesesInfoGroup
        {
            get { return (InfectiousIllnesesInformationGroup?)(int?)this["INFECTIOUSILLNESESINFOGROUP"]; }
            set { this["INFECTIOUSILLNESESINFOGROUP"] = value; }
        }

    /// <summary>
    /// FTR Tanı Grubu
    /// </summary>
        public FTRDiagnosisGroupEnum? FtrDiagnoseGroup
        {
            get { return (FTRDiagnosisGroupEnum?)(int?)this["FTRDIAGNOSEGROUP"]; }
            set { this["FTRDIAGNOSEGROUP"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

    /// <summary>
    /// Influenza Web Servisi İçin
    /// </summary>
        public bool? IsInfluenzaDiagnos
        {
            get { return (bool?)this["ISINFLUENZADIAGNOS"]; }
            set { this["ISINFLUENZADIAGNOS"] = value; }
        }

    /// <summary>
    /// Yüksek Riskli Gebelik Tanısı
    /// </summary>
        public bool? HighRiskPregnancy
        {
            get { return (bool?)this["HIGHRISKPREGNANCY"]; }
            set { this["HIGHRISKPREGNANCY"] = value; }
        }

    /// <summary>
    /// Gebelik Tanısı
    /// </summary>
        public bool? PregnancyDiagnos
        {
            get { return (bool?)this["PREGNANCYDIAGNOS"]; }
            set { this["PREGNANCYDIAGNOS"] = value; }
        }

    /// <summary>
    /// Sms Gönderilecek
    /// </summary>
        public bool? SendSms
        {
            get { return (bool?)this["SENDSMS"]; }
            set { this["SENDSMS"] = value; }
        }

        public string SMSText
        {
            get { return (string)this["SMSTEXT"]; }
            set { this["SMSTEXT"] = value; }
        }

    /// <summary>
    /// DiagnosisDefinitionDiagnosisDefinition(Main)
    /// </summary>
        public DiagnosisDefinition ParentGroup
        {
            get { return (DiagnosisDefinition)((ITTObject)this).GetParent("PARENTGROUP"); }
            set { this["PARENTGROUP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public EmergencyClinicDecisionQuideDefinition EMClinicDecisionQuideDef
        {
            get { return (EmergencyClinicDecisionQuideDefinition)((ITTObject)this).GetParent("EMCLINICDECISIONQUIDEDEF"); }
            set { this["EMCLINICDECISIONQUIDEDEF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Teshis Teshis
        {
            get { return (Teshis)((ITTObject)this).GetParent("TESHIS"); }
            set { this["TESHIS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Geliş Sebebi
    /// </summary>
        public ProvizyonTipi AdmissionType
        {
            get { return (ProvizyonTipi)((ITTObject)this).GetParent("ADMISSIONTYPE"); }
            set { this["ADMISSIONTYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateSnomedsCollection()
        {
            _Snomeds = new SnomedDiagnosisDefinition.ChildSnomedDiagnosisDefinitionCollection(this, new Guid("87c8ea38-f318-4a7c-af38-0fd90f82c84b"));
            ((ITTChildObjectCollection)_Snomeds).GetChildren();
        }

        protected SnomedDiagnosisDefinition.ChildSnomedDiagnosisDefinitionCollection _Snomeds = null;
    /// <summary>
    /// Child collection for ICD 10 Tanısı
    /// </summary>
        public SnomedDiagnosisDefinition.ChildSnomedDiagnosisDefinitionCollection Snomeds
        {
            get
            {
                if (_Snomeds == null)
                    CreateSnomedsCollection();
                return _Snomeds;
            }
        }

        virtual protected void CreateDiagnosisDefinitionsCollection()
        {
            _DiagnosisDefinitions = new DiagnosisDefinition.ChildDiagnosisDefinitionCollection(this, new Guid("1db4c110-38a2-4faa-ab09-cb4610814841"));
            ((ITTChildObjectCollection)_DiagnosisDefinitions).GetChildren();
        }

        protected DiagnosisDefinition.ChildDiagnosisDefinitionCollection _DiagnosisDefinitions = null;
    /// <summary>
    /// Child collection for DiagnosisDefinitionDiagnosisDefinition(Main)
    /// </summary>
        public DiagnosisDefinition.ChildDiagnosisDefinitionCollection DiagnosisDefinitions
        {
            get
            {
                if (_DiagnosisDefinitions == null)
                    CreateDiagnosisDefinitionsCollection();
                return _DiagnosisDefinitions;
            }
        }

        virtual protected void CreateDiagnosisRuleSetsCollection()
        {
            _DiagnosisRuleSets = new DiagnosisRuleSet.ChildDiagnosisRuleSetCollection(this, new Guid("2900800d-66c1-4762-b7ed-5260e4c8ca35"));
            ((ITTChildObjectCollection)_DiagnosisRuleSets).GetChildren();
        }

        protected DiagnosisRuleSet.ChildDiagnosisRuleSetCollection _DiagnosisRuleSets = null;
    /// <summary>
    /// Child collection for Tanı-Tanı Kural Setleri
    /// </summary>
        public DiagnosisRuleSet.ChildDiagnosisRuleSetCollection DiagnosisRuleSets
        {
            get
            {
                if (_DiagnosisRuleSets == null)
                    CreateDiagnosisRuleSetsCollection();
                return _DiagnosisRuleSets;
            }
        }

        virtual protected void CreateSPTSMatchICDsCollection()
        {
            _SPTSMatchICDs = new SPTSMatchICD.ChildSPTSMatchICDCollection(this, new Guid("027ab950-31bc-42ad-ac0e-6122c520f01b"));
            ((ITTChildObjectCollection)_SPTSMatchICDs).GetChildren();
        }

        protected SPTSMatchICD.ChildSPTSMatchICDCollection _SPTSMatchICDs = null;
        public SPTSMatchICD.ChildSPTSMatchICDCollection SPTSMatchICDs
        {
            get
            {
                if (_SPTSMatchICDs == null)
                    CreateSPTSMatchICDsCollection();
                return _SPTSMatchICDs;
            }
        }

        virtual protected void CreateDiagnosisDefOzelDurumlarCollection()
        {
            _DiagnosisDefOzelDurumlar = new DiagnosisDefOzelDurum.ChildDiagnosisDefOzelDurumCollection(this, new Guid("dddfa39e-e72d-4297-b0f1-b02fb07cf41b"));
            ((ITTChildObjectCollection)_DiagnosisDefOzelDurumlar).GetChildren();
        }

        protected DiagnosisDefOzelDurum.ChildDiagnosisDefOzelDurumCollection _DiagnosisDefOzelDurumlar = null;
        public DiagnosisDefOzelDurum.ChildDiagnosisDefOzelDurumCollection DiagnosisDefOzelDurumlar
        {
            get
            {
                if (_DiagnosisDefOzelDurumlar == null)
                    CreateDiagnosisDefOzelDurumlarCollection();
                return _DiagnosisDefOzelDurumlar;
            }
        }

        virtual protected void CreateDiagnosisDefTeshisCollection()
        {
            _DiagnosisDefTeshis = new DiagnosisDefTeshis.ChildDiagnosisDefTeshisCollection(this, new Guid("db239cfe-9c8b-48d8-a74c-39ea08038848"));
            ((ITTChildObjectCollection)_DiagnosisDefTeshis).GetChildren();
        }

        protected DiagnosisDefTeshis.ChildDiagnosisDefTeshisCollection _DiagnosisDefTeshis = null;
        public DiagnosisDefTeshis.ChildDiagnosisDefTeshisCollection DiagnosisDefTeshis
        {
            get
            {
                if (_DiagnosisDefTeshis == null)
                    CreateDiagnosisDefTeshisCollection();
                return _DiagnosisDefTeshis;
            }
        }

        virtual protected void CreateDiagnosisActionSuggestionsCollection()
        {
            _DiagnosisActionSuggestions = new DiagnosisActionSuggestion.ChildDiagnosisActionSuggestionCollection(this, new Guid("cf6dd668-ce53-4f48-a047-4d0ee0fb3487"));
            ((ITTChildObjectCollection)_DiagnosisActionSuggestions).GetChildren();
        }

        protected DiagnosisActionSuggestion.ChildDiagnosisActionSuggestionCollection _DiagnosisActionSuggestions = null;
        public DiagnosisActionSuggestion.ChildDiagnosisActionSuggestionCollection DiagnosisActionSuggestions
        {
            get
            {
                if (_DiagnosisActionSuggestions == null)
                    CreateDiagnosisActionSuggestionsCollection();
                return _DiagnosisActionSuggestions;
            }
        }

        virtual protected void CreatePhysicianSuggestionDefsCollection()
        {
            _PhysicianSuggestionDefs = new PhysicianSuggestionDef.ChildPhysicianSuggestionDefCollection(this, new Guid("b9fb0dc6-48d3-4a31-84bc-979a6c9288b0"));
            ((ITTChildObjectCollection)_PhysicianSuggestionDefs).GetChildren();
        }

        protected PhysicianSuggestionDef.ChildPhysicianSuggestionDefCollection _PhysicianSuggestionDefs = null;
        public PhysicianSuggestionDef.ChildPhysicianSuggestionDefCollection PhysicianSuggestionDefs
        {
            get
            {
                if (_PhysicianSuggestionDefs == null)
                    CreatePhysicianSuggestionDefsCollection();
                return _PhysicianSuggestionDefs;
            }
        }

        virtual protected void CreateRequiredDiagnoseProceduresCollection()
        {
            _RequiredDiagnoseProcedures = new RequiredDiagnoseProcedure.ChildRequiredDiagnoseProcedureCollection(this, new Guid("437a3289-a275-44d6-9619-0311e72eefbf"));
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

        protected DiagnosisDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DiagnosisDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DiagnosisDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DiagnosisDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DiagnosisDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DIAGNOSISDEFINITION", dataRow) { }
        protected DiagnosisDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DIAGNOSISDEFINITION", dataRow, isImported) { }
        public DiagnosisDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DiagnosisDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DiagnosisDefinition() : base() { }

    }
}