
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PsychologyBasedObject")] 

    public  partial class PsychologyBasedObject : SpecialityBasedObject
    {
        public class PsychologyBasedObjectList : TTObjectCollection<PsychologyBasedObject> { }
                    
        public class ChildPsychologyBasedObjectCollection : TTObject.TTChildObjectCollection<PsychologyBasedObject>
        {
            public ChildPsychologyBasedObjectCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPsychologyBasedObjectCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<PsychologyBasedObject> GetPsychologyBasedObjectByExamination(TTObjectContext objectContext, string PSYCHOLOGICEXAMINATION)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PSYCHOLOGYBASEDOBJECT"].QueryDefs["GetPsychologyBasedObjectByExamination"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PSYCHOLOGICEXAMINATION", PSYCHOLOGICEXAMINATION);

            return ((ITTQuery)objectContext).QueryObjects<PsychologyBasedObject>(queryDef, paramList);
        }

    /// <summary>
    /// Doktor Açıklaması
    /// </summary>
        public string DoctorStatement
        {
            get { return (string)this["DOCTORSTATEMENT"]; }
            set { this["DOCTORSTATEMENT"] = value; }
        }

    /// <summary>
    /// Terapi Raporu
    /// </summary>
        public object TherapyReport
        {
            get { return (object)this["THERAPYREPORT"]; }
            set { this["THERAPYREPORT"] = value; }
        }

    /// <summary>
    /// Form Yetkisi - Sadece İşlemi Yapan Psikolog Görebilir
    /// </summary>
        public bool? VisibleForProcedureDoctor
        {
            get { return (bool?)this["VISIBLEFORPROCEDUREDOCTOR"]; }
            set { this["VISIBLEFORPROCEDUREDOCTOR"] = value; }
        }

    /// <summary>
    /// Form Yetkisi - Sadece İşlemi Yapan Psikolog ve İstemi Yapan Hekim Görebilir
    /// </summary>
        public bool? VisibleForProcAndRequestDoc
        {
            get { return (bool?)this["VISIBLEFORPROCANDREQUESTDOC"]; }
            set { this["VISIBLEFORPROCANDREQUESTDOC"] = value; }
        }

    /// <summary>
    /// Form Yetkisi - Sadece Psikiyatri Branşı ve Psikologlar Görebilir
    /// </summary>
        public bool? VisibleForPsychologyUnit
        {
            get { return (bool?)this["VISIBLEFORPSYCHOLOGYUNIT"]; }
            set { this["VISIBLEFORPSYCHOLOGYUNIT"] = value; }
        }

    /// <summary>
    /// Form Yetkisi - Sadece Seçilen Kullanıcılar Görebilirir
    /// </summary>
        public bool? VisibleForSelectedUsers
        {
            get { return (bool?)this["VISIBLEFORSELECTEDUSERS"]; }
            set { this["VISIBLEFORSELECTEDUSERS"] = value; }
        }

    /// <summary>
    /// Binet Terman Testi
    /// </summary>
        public bool? BinetTermanTest
        {
            get { return (bool?)this["BINETTERMANTEST"]; }
            set { this["BINETTERMANTEST"] = value; }
        }

    /// <summary>
    /// Cattel Zeka Testi
    /// </summary>
        public bool? CattelIntelligenceTest
        {
            get { return (bool?)this["CATTELINTELLIGENCETEST"]; }
            set { this["CATTELINTELLIGENCETEST"] = value; }
        }

    /// <summary>
    /// Good Enough Harris Adam Çizme Testi
    /// </summary>
        public bool? GoodEnoughHarrisDrawingTest
        {
            get { return (bool?)this["GOODENOUGHHARRISDRAWINGTEST"]; }
            set { this["GOODENOUGHHARRISDRAWINGTEST"] = value; }
        }

    /// <summary>
    /// Kent EGY Testi
    /// </summary>
        public bool? KentEGYTest
        {
            get { return (bool?)this["KENTEGYTEST"]; }
            set { this["KENTEGYTEST"] = value; }
        }

    /// <summary>
    /// Öğrenme Güçlüğü Seviye Tespit Formu
    /// </summary>
        public bool? LearnDifficultyDetermination
        {
            get { return (bool?)this["LEARNDIFFICULTYDETERMINATION"]; }
            set { this["LEARNDIFFICULTYDETERMINATION"] = value; }
        }

    /// <summary>
    /// Peabody Resim Kelime Testi
    /// </summary>
        public bool? PeabodyPictureVocabularyTest
        {
            get { return (bool?)this["PEABODYPICTUREVOCABULARYTEST"]; }
            set { this["PEABODYPICTUREVOCABULARYTEST"] = value; }
        }

    /// <summary>
    /// Proteus Labirent Testi
    /// </summary>
        public bool? ProteusMazeTest
        {
            get { return (bool?)this["PROTEUSMAZETEST"]; }
            set { this["PROTEUSMAZETEST"] = value; }
        }

    /// <summary>
    /// WISCR
    /// </summary>
        public bool? WISCR
        {
            get { return (bool?)this["WISCR"]; }
            set { this["WISCR"] = value; }
        }

    /// <summary>
    /// Uygulamaya Dair Önemli Not
    /// </summary>
        public ImportantNoteAboutApplicationEnum? ImportantNoteAboutApplication
        {
            get { return (ImportantNoteAboutApplicationEnum?)(int?)this["IMPORTANTNOTEABOUTAPPLICATION"]; }
            set { this["IMPORTANTNOTEABOUTAPPLICATION"] = value; }
        }

    /// <summary>
    /// Veliden Alınan Bilgi
    /// </summary>
        public string InformationTakenFromParent
        {
            get { return (string)this["INFORMATIONTAKENFROMPARENT"]; }
            set { this["INFORMATIONTAKENFROMPARENT"] = value; }
        }

    /// <summary>
    /// IQ Testi Nesnel Sonucu ve IQ Seviyesi
    /// </summary>
        public IQTestResultsAndIQLevelEnum? IQTestObjectiveResultIQLevel
        {
            get { return (IQTestResultsAndIQLevelEnum?)(int?)this["IQTESTOBJECTIVERESULTIQLEVEL"]; }
            set { this["IQTESTOBJECTIVERESULTIQLEVEL"] = value; }
        }

    /// <summary>
    /// İstekte Bulunan Doktor
    /// </summary>
        public ResUser RequestDoctor
        {
            get { return (ResUser)((ITTObject)this).GetParent("REQUESTDOCTOR"); }
            set { this["REQUESTDOCTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PsychologicExamination PsychologicExamination
        {
            get { return (PsychologicExamination)((ITTObject)this).GetParent("PSYCHOLOGICEXAMINATION"); }
            set { this["PSYCHOLOGICEXAMINATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreatePsychologicFormsCollectionViews()
        {
            _PsychologicEvaluation = new PsychologicEvaluation.ChildPsychologicEvaluationCollection(_PsychologicForms, "PsychologicEvaluation");
            _VerbalAndPerformanceTests = new VerbalAndPerformanceTests.ChildVerbalAndPerformanceTestsCollection(_PsychologicForms, "VerbalAndPerformanceTests");
            _CognitiveEvaluation = new CognitiveEvaluation.ChildCognitiveEvaluationCollection(_PsychologicForms, "CognitiveEvaluation");
            _EarlyChildGrowthEvaluation = new EarlyChildGrowthEvaluation.ChildEarlyChildGrowthEvaluationCollection(_PsychologicForms, "EarlyChildGrowthEvaluation");
            _IQIntelligenceTestReport = new IQIntelligenceTestReport.ChildIQIntelligenceTestReportCollection(_PsychologicForms, "IQIntelligenceTestReport");
        }

        virtual protected void CreatePsychologicFormsCollection()
        {
            _PsychologicForms = new BasePsychologyForm.ChildBasePsychologyFormCollection(this, new Guid("f07f6137-c08b-447d-bb89-af50017024bf"));
            CreatePsychologicFormsCollectionViews();
            ((ITTChildObjectCollection)_PsychologicForms).GetChildren();
        }

        protected BasePsychologyForm.ChildBasePsychologyFormCollection _PsychologicForms = null;
        public BasePsychologyForm.ChildBasePsychologyFormCollection PsychologicForms
        {
            get
            {
                if (_PsychologicForms == null)
                    CreatePsychologicFormsCollection();
                return _PsychologicForms;
            }
        }

        private PsychologicEvaluation.ChildPsychologicEvaluationCollection _PsychologicEvaluation = null;
        public PsychologicEvaluation.ChildPsychologicEvaluationCollection PsychologicEvaluation
        {
            get
            {
                if (_PsychologicForms == null)
                    CreatePsychologicFormsCollection();
                return _PsychologicEvaluation;
            }            
        }

        private VerbalAndPerformanceTests.ChildVerbalAndPerformanceTestsCollection _VerbalAndPerformanceTests = null;
        public VerbalAndPerformanceTests.ChildVerbalAndPerformanceTestsCollection VerbalAndPerformanceTests
        {
            get
            {
                if (_PsychologicForms == null)
                    CreatePsychologicFormsCollection();
                return _VerbalAndPerformanceTests;
            }            
        }

        private CognitiveEvaluation.ChildCognitiveEvaluationCollection _CognitiveEvaluation = null;
        public CognitiveEvaluation.ChildCognitiveEvaluationCollection CognitiveEvaluation
        {
            get
            {
                if (_PsychologicForms == null)
                    CreatePsychologicFormsCollection();
                return _CognitiveEvaluation;
            }            
        }

        private EarlyChildGrowthEvaluation.ChildEarlyChildGrowthEvaluationCollection _EarlyChildGrowthEvaluation = null;
        public EarlyChildGrowthEvaluation.ChildEarlyChildGrowthEvaluationCollection EarlyChildGrowthEvaluation
        {
            get
            {
                if (_PsychologicForms == null)
                    CreatePsychologicFormsCollection();
                return _EarlyChildGrowthEvaluation;
            }            
        }

        private IQIntelligenceTestReport.ChildIQIntelligenceTestReportCollection _IQIntelligenceTestReport = null;
        public IQIntelligenceTestReport.ChildIQIntelligenceTestReportCollection IQIntelligenceTestReport
        {
            get
            {
                if (_PsychologicForms == null)
                    CreatePsychologicFormsCollection();
                return _IQIntelligenceTestReport;
            }            
        }

        virtual protected void CreatePsychologyAuthorizedUsersCollection()
        {
            _PsychologyAuthorizedUsers = new PsychologyAuthorizedUser.ChildPsychologyAuthorizedUserCollection(this, new Guid("66ac4ea8-608f-4863-a672-2b5a35e61925"));
            ((ITTChildObjectCollection)_PsychologyAuthorizedUsers).GetChildren();
        }

        protected PsychologyAuthorizedUser.ChildPsychologyAuthorizedUserCollection _PsychologyAuthorizedUsers = null;
        public PsychologyAuthorizedUser.ChildPsychologyAuthorizedUserCollection PsychologyAuthorizedUsers
        {
            get
            {
                if (_PsychologyAuthorizedUsers == null)
                    CreatePsychologyAuthorizedUsersCollection();
                return _PsychologyAuthorizedUsers;
            }
        }

        protected PsychologyBasedObject(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PsychologyBasedObject(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PsychologyBasedObject(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PsychologyBasedObject(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PsychologyBasedObject(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PSYCHOLOGYBASEDOBJECT", dataRow) { }
        protected PsychologyBasedObject(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PSYCHOLOGYBASEDOBJECT", dataRow, isImported) { }
        public PsychologyBasedObject(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PsychologyBasedObject(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PsychologyBasedObject() : base() { }

    }
}