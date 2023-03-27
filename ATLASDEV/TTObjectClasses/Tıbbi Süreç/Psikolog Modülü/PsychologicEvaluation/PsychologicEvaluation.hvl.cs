
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PsychologicEvaluation")] 

    /// <summary>
    /// Psikolojik Değerlendirme Formu
    /// </summary>
    public  partial class PsychologicEvaluation : BasePsychologyForm
    {
        public class PsychologicEvaluationList : TTObjectCollection<PsychologicEvaluation> { }
                    
        public class ChildPsychologicEvaluationCollection : TTObject.TTChildObjectCollection<PsychologicEvaluation>
        {
            public ChildPsychologicEvaluationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPsychologicEvaluationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class PsychologicEvaluationFormList_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PSYCHOLOGICEVALUATION"].AllPropertyDefs["ADDEDDATE"].DataType;
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

            public PsychologicEvaluationFormList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public PsychologicEvaluationFormList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected PsychologicEvaluationFormList_Class() : base() { }
        }

        public static BindingList<PsychologicEvaluation.PsychologicEvaluationFormList_Class> PsychologicEvaluationFormList(Guid EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PSYCHOLOGICEVALUATION"].QueryDefs["PsychologicEvaluationFormList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<PsychologicEvaluation.PsychologicEvaluationFormList_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PsychologicEvaluation.PsychologicEvaluationFormList_Class> PsychologicEvaluationFormList(TTObjectContext objectContext, Guid EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PSYCHOLOGICEVALUATION"].QueryDefs["PsychologicEvaluationFormList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<PsychologicEvaluation.PsychologicEvaluationFormList_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Psikopatolojik Sapma
    /// </summary>
        public string PsychopathologicalDeviation
        {
            get { return (string)this["PSYCHOPATHOLOGICALDEVIATION"]; }
            set { this["PSYCHOPATHOLOGICALDEVIATION"] = value; }
        }

    /// <summary>
    /// Duygu Durum Bozukluğu
    /// </summary>
        public string MoodDisorder
        {
            get { return (string)this["MOODDISORDER"]; }
            set { this["MOODDISORDER"] = value; }
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
    /// Kişilik Patolojisi ya da Sapması
    /// </summary>
        public string PersonalPathologyOrDeviation
        {
            get { return (string)this["PERSONALPATHOLOGYORDEVIATION"]; }
            set { this["PERSONALPATHOLOGYORDEVIATION"] = value; }
        }

    /// <summary>
    /// Uzun Süreli Bellek Fonksiyonu
    /// </summary>
        public string LongTermMemoryFunction
        {
            get { return (string)this["LONGTERMMEMORYFUNCTION"]; }
            set { this["LONGTERMMEMORYFUNCTION"] = value; }
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
    /// Psikopatolojik Bozukluk
    /// </summary>
        public string PsychopathologicalDisorder
        {
            get { return (string)this["PSYCHOPATHOLOGICALDISORDER"]; }
            set { this["PSYCHOPATHOLOGICALDISORDER"] = value; }
        }

    /// <summary>
    /// Mesleği
    /// </summary>
        public SKRSMeslekler PatientJob
        {
            get { return (SKRSMeslekler)((ITTObject)this).GetParent("PATIENTJOB"); }
            set { this["PATIENTJOB"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Öğrenim Durumu
    /// </summary>
        public SKRSOgrenimDurumu EducationStatus
        {
            get { return (SKRSOgrenimDurumu)((ITTObject)this).GetParent("EDUCATIONSTATUS"); }
            set { this["EDUCATIONSTATUS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PsychologicEvaluation(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PsychologicEvaluation(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PsychologicEvaluation(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PsychologicEvaluation(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PsychologicEvaluation(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PSYCHOLOGICEVALUATION", dataRow) { }
        protected PsychologicEvaluation(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PSYCHOLOGICEVALUATION", dataRow, isImported) { }
        public PsychologicEvaluation(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PsychologicEvaluation(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PsychologicEvaluation() : base() { }

    }
}