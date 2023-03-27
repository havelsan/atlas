
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="NursingPatientPreAssessment")] 

    /// <summary>
    /// Hemşirelik Hizmetleri Hasta Ön Değerlendirmesi
    /// </summary>
    public  partial class NursingPatientPreAssessment : BaseNursingDataEntry
    {
        public class NursingPatientPreAssessmentList : TTObjectCollection<NursingPatientPreAssessment> { }
                    
        public class ChildNursingPatientPreAssessmentCollection : TTObject.TTChildObjectCollection<NursingPatientPreAssessment>
        {
            public ChildNursingPatientPreAssessmentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildNursingPatientPreAssessmentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Yeni { get { return new Guid("2f6b2d75-fb0e-43c9-a964-af59bb71f8b9"); } }
    /// <summary>
    /// Yanlış veriyi silmek için
    /// </summary>
            public static Guid Cancelled { get { return new Guid("c9a1ec5b-749a-4cff-9a32-d66e3b0d807b"); } }
        }

        public string PatientLanguage
        {
            get { return (string)this["PATIENTLANGUAGE"]; }
            set { this["PATIENTLANGUAGE"] = value; }
        }

        public int? ChildCount
        {
            get { return (int?)this["CHILDCOUNT"]; }
            set { this["CHILDCOUNT"] = value; }
        }

        public CauseOfInjuryEnum? CauseOfInjury
        {
            get { return (CauseOfInjuryEnum?)(int?)this["CAUSEOFINJURY"]; }
            set { this["CAUSEOFINJURY"] = value; }
        }

        public YesNoEnum? RehabHistory
        {
            get { return (YesNoEnum?)(int?)this["REHABHISTORY"]; }
            set { this["REHABHISTORY"] = value; }
        }

        public DateTime? LastRehabDate
        {
            get { return (DateTime?)this["LASTREHABDATE"]; }
            set { this["LASTREHABDATE"] = value; }
        }

        public string WhereThePatientCameFrom
        {
            get { return (string)this["WHERETHEPATIENTCAMEFROM"]; }
            set { this["WHERETHEPATIENTCAMEFROM"] = value; }
        }

    /// <summary>
    /// Birime Geliş Şekli
    /// </summary>
        public TheWayThePatientArriveEnum? TheWayThePatientArrive
        {
            get { return (TheWayThePatientArriveEnum?)(int?)this["THEWAYTHEPATIENTARRIVE"]; }
            set { this["THEWAYTHEPATIENTARRIVE"] = value; }
        }

    /// <summary>
    /// Ailesel Hastalıklar
    /// </summary>
        public string HereditaryDiseases
        {
            get { return (string)this["HEREDITARYDISEASES"]; }
            set { this["HEREDITARYDISEASES"] = value; }
        }

    /// <summary>
    /// Geçirilmiş Hastalıklar / Operasyonlar
    /// </summary>
        public string PastIllnessesAndOperations
        {
            get { return (string)this["PASTILLNESSESANDOPERATIONS"]; }
            set { this["PASTILLNESSESANDOPERATIONS"] = value; }
        }

    /// <summary>
    /// Sürekli Kullandığı Yardımcı Cihazlar
    /// </summary>
        public string AssistiveDevices
        {
            get { return (string)this["ASSISTIVEDEVICES"]; }
            set { this["ASSISTIVEDEVICES"] = value; }
        }

    /// <summary>
    /// Daha önce kan transfüzyonu uygulandı mı?
    /// </summary>
        public YesNoEnum? BloodTransfusionPracticed
        {
            get { return (YesNoEnum?)(int?)this["BLOODTRANSFUSIONPRACTICED"]; }
            set { this["BLOODTRANSFUSIONPRACTICED"] = value; }
        }

    /// <summary>
    /// Kan Transfüzyonu yapıldıysa Reaksiyon Gelişti mi?
    /// </summary>
        public string BloodTransfusionReaction
        {
            get { return (string)this["BLOODTRANSFUSIONREACTION"]; }
            set { this["BLOODTRANSFUSIONREACTION"] = value; }
        }

        public int? Height
        {
            get { return (int?)this["HEIGHT"]; }
            set { this["HEIGHT"] = value; }
        }

        public double? Weight
        {
            get { return (double?)this["WEIGHT"]; }
            set { this["WEIGHT"] = value; }
        }

        protected NursingPatientPreAssessment(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected NursingPatientPreAssessment(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected NursingPatientPreAssessment(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected NursingPatientPreAssessment(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected NursingPatientPreAssessment(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "NURSINGPATIENTPREASSESSMENT", dataRow) { }
        protected NursingPatientPreAssessment(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "NURSINGPATIENTPREASSESSMENT", dataRow, isImported) { }
        public NursingPatientPreAssessment(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public NursingPatientPreAssessment(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public NursingPatientPreAssessment() : base() { }

    }
}