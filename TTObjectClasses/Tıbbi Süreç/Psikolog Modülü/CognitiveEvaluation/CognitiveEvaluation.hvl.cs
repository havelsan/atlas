
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CognitiveEvaluation")] 

    /// <summary>
    /// Kognitif Değerlendirme
    /// </summary>
    public  partial class CognitiveEvaluation : BasePsychologyForm
    {
        public class CognitiveEvaluationList : TTObjectCollection<CognitiveEvaluation> { }
                    
        public class ChildCognitiveEvaluationCollection : TTObject.TTChildObjectCollection<CognitiveEvaluation>
        {
            public ChildCognitiveEvaluationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCognitiveEvaluationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class CognitiveEvaluationFormList_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public DateTime? AddedDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADDEDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COGNITIVEEVALUATION"].AllPropertyDefs["ADDEDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Addeduser
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADDEDUSER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
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

            public CognitiveEvaluationFormList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public CognitiveEvaluationFormList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected CognitiveEvaluationFormList_Class() : base() { }
        }

        public static BindingList<CognitiveEvaluation.CognitiveEvaluationFormList_Class> CognitiveEvaluationFormList(Guid EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COGNITIVEEVALUATION"].QueryDefs["CognitiveEvaluationFormList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<CognitiveEvaluation.CognitiveEvaluationFormList_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CognitiveEvaluation.CognitiveEvaluationFormList_Class> CognitiveEvaluationFormList(TTObjectContext objectContext, Guid EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COGNITIVEEVALUATION"].QueryDefs["CognitiveEvaluationFormList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<CognitiveEvaluation.CognitiveEvaluationFormList_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Algılama İşlevi
    /// </summary>
        public string DetectionFunction
        {
            get { return (string)this["DETECTIONFUNCTION"]; }
            set { this["DETECTIONFUNCTION"] = value; }
        }

    /// <summary>
    /// Yargı İşlevi
    /// </summary>
        public string JudgmentFunction
        {
            get { return (string)this["JUDGMENTFUNCTION"]; }
            set { this["JUDGMENTFUNCTION"] = value; }
        }

    /// <summary>
    /// Kısa Süreli Bellek Fonksiyonu
    /// </summary>
        public string ShortTermMemoryFunction
        {
            get { return (string)this["SHORTTERMMEMORYFUNCTION"]; }
            set { this["SHORTTERMMEMORYFUNCTION"] = value; }
        }

    /// <summary>
    /// Uzun Süreli Bellek Fonskiyonu
    /// </summary>
        public string LongTermMemoryFunction
        {
            get { return (string)this["LONGTERMMEMORYFUNCTION"]; }
            set { this["LONGTERMMEMORYFUNCTION"] = value; }
        }

    /// <summary>
    /// IQ Zeka Düzeyi
    /// </summary>
        public string IQIntelligenceLevel
        {
            get { return (string)this["IQINTELLIGENCELEVEL"]; }
            set { this["IQINTELLIGENCELEVEL"] = value; }
        }

    /// <summary>
    /// Sosyal Eğitimsel Retardasyon Durumu
    /// </summary>
        public string SocialEducationRetardationSit
        {
            get { return (string)this["SOCIALEDUCATIONRETARDATIONSIT"]; }
            set { this["SOCIALEDUCATIONRETARDATIONSIT"] = value; }
        }

    /// <summary>
    /// Diğer
    /// </summary>
        public string Other
        {
            get { return (string)this["OTHER"]; }
            set { this["OTHER"] = value; }
        }

    /// <summary>
    /// Oryantasyon
    /// </summary>
        public double? Orientation
        {
            get { return (double?)this["ORIENTATION"]; }
            set { this["ORIENTATION"] = value; }
        }

    /// <summary>
    /// Kayıt Hafıza
    /// </summary>
        public double? RecordingMemory
        {
            get { return (double?)this["RECORDINGMEMORY"]; }
            set { this["RECORDINGMEMORY"] = value; }
        }

    /// <summary>
    /// Dikkat ve Hesap Yapma
    /// </summary>
        public double? AttentionAndCalculation
        {
            get { return (double?)this["ATTENTIONANDCALCULATION"]; }
            set { this["ATTENTIONANDCALCULATION"] = value; }
        }

    /// <summary>
    /// Hatırlama
    /// </summary>
        public double? Remembrance
        {
            get { return (double?)this["REMEMBRANCE"]; }
            set { this["REMEMBRANCE"] = value; }
        }

    /// <summary>
    /// Dil
    /// </summary>
        public double? Language
        {
            get { return (double?)this["LANGUAGE"]; }
            set { this["LANGUAGE"] = value; }
        }

    /// <summary>
    /// Gözlem Görüşmeye ve Değerlendirmeye Ait Not
    /// </summary>
        public string ObservationDiscussionEvalNote
        {
            get { return (string)this["OBSERVATIONDISCUSSIONEVALNOTE"]; }
            set { this["OBSERVATIONDISCUSSIONEVALNOTE"] = value; }
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
    /// Muhakeme İşlevi
    /// </summary>
        public string ReasoningFunction
        {
            get { return (string)this["REASONINGFUNCTION"]; }
            set { this["REASONINGFUNCTION"] = value; }
        }

    /// <summary>
    /// Öğrenim Durumu
    /// </summary>
        public SKRSOgrenimDurumu EducationStatus
        {
            get { return (SKRSOgrenimDurumu)((ITTObject)this).GetParent("EDUCATIONSTATUS"); }
            set { this["EDUCATIONSTATUS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Mesleği
    /// </summary>
        public SKRSMeslekler PatientJob
        {
            get { return (SKRSMeslekler)((ITTObject)this).GetParent("PATIENTJOB"); }
            set { this["PATIENTJOB"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected CognitiveEvaluation(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CognitiveEvaluation(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CognitiveEvaluation(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CognitiveEvaluation(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CognitiveEvaluation(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "COGNITIVEEVALUATION", dataRow) { }
        protected CognitiveEvaluation(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "COGNITIVEEVALUATION", dataRow, isImported) { }
        public CognitiveEvaluation(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CognitiveEvaluation(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CognitiveEvaluation() : base() { }

    }
}