
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="NursingWoundAssessmentScale")] 

    /// <summary>
    /// Bası Yarası Değerlendirme Skalası Formu
    /// </summary>
    public  partial class NursingWoundAssessmentScale : BaseNursingDataEntry
    {
        public class NursingWoundAssessmentScaleList : TTObjectCollection<NursingWoundAssessmentScale> { }
                    
        public class ChildNursingWoundAssessmentScaleCollection : TTObject.TTChildObjectCollection<NursingWoundAssessmentScale>
        {
            public ChildNursingWoundAssessmentScaleCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildNursingWoundAssessmentScaleCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Yeni { get { return new Guid("2f6b2d75-fb0e-43c9-a964-af59bb71f8b9"); } }
    /// <summary>
    /// Yanlış veriyi silmek için
    /// </summary>
            public static Guid Cancelled { get { return new Guid("c9a1ec5b-749a-4cff-9a32-d66e3b0d807b"); } }
        }

    /// <summary>
    /// Hemşirelik Girişimleri Uygulandı Mı
    /// </summary>
        public DateTime? NursingAppDoneDate
        {
            get { return (DateTime?)this["NURSINGAPPDONEDATE"]; }
            set { this["NURSINGAPPDONEDATE"] = value; }
        }

    /// <summary>
    /// Tarih
    /// </summary>
        public DateTime? ActionDate
        {
            get { return (DateTime?)this["ACTIONDATE"]; }
            set { this["ACTIONDATE"] = value; }
        }

    /// <summary>
    /// Toplam Risk
    /// </summary>
        public int? TotalRisk
        {
            get { return (int?)this["TOTALRISK"]; }
            set { this["TOTALRISK"] = value; }
        }

    /// <summary>
    /// Boyuna oranla vücut yapısı
    /// </summary>
        public BodyTypeEnum? BodyType
        {
            get { return (BodyTypeEnum?)(int?)this["BODYTYPE"]; }
            set { this["BODYTYPE"] = value; }
        }

    /// <summary>
    /// Kontinans
    /// </summary>
        public ContinenceEnum? Continence
        {
            get { return (ContinenceEnum?)(int?)this["CONTINENCE"]; }
            set { this["CONTINENCE"] = value; }
        }

    /// <summary>
    /// Mobilite
    /// </summary>
        public MobilityEnum? Mobility
        {
            get { return (MobilityEnum?)(int?)this["MOBILITY"]; }
            set { this["MOBILITY"] = value; }
        }

    /// <summary>
    /// Nörolojik bozukluklar(diyabet,MS,SVO,motor/duyu kaybı, parapleji, tetrapleji)
    /// </summary>
        public NeurologicalDisordersEnum? NeurologicalDisorders
        {
            get { return (NeurologicalDisordersEnum?)(int?)this["NEUROLOGICALDISORDERS"]; }
            set { this["NEUROLOGICALDISORDERS"] = value; }
        }

    /// <summary>
    /// Sağlıklı
    /// </summary>
        public bool? SkinHealthy
        {
            get { return (bool?)this["SKINHEALTHY"]; }
            set { this["SKINHEALTHY"] = value; }
        }

    /// <summary>
    /// İnce çizilmeye yatkın
    /// </summary>
        public bool? SkinThin
        {
            get { return (bool?)this["SKINTHIN"]; }
            set { this["SKINTHIN"] = value; }
        }

    /// <summary>
    /// kuru cilt tipi
    /// </summary>
        public bool? SkinDry
        {
            get { return (bool?)this["SKINDRY"]; }
            set { this["SKINDRY"] = value; }
        }

    /// <summary>
    /// ödemli
    /// </summary>
        public bool? SkinDropsy
        {
            get { return (bool?)this["SKINDROPSY"]; }
            set { this["SKINDROPSY"] = value; }
        }

    /// <summary>
    /// Soğuk ve nemli cilt
    /// </summary>
        public bool? SkinColdAndMoist
        {
            get { return (bool?)this["SKINCOLDANDMOIST"]; }
            set { this["SKINCOLDANDMOIST"] = value; }
        }

    /// <summary>
    /// Renk bozukluğu
    /// </summary>
        public bool? SkinDiscolored
        {
            get { return (bool?)this["SKINDISCOLORED"]; }
            set { this["SKINDISCOLORED"] = value; }
        }

    /// <summary>
    /// cilt bütünlüğü bozuk
    /// </summary>
        public bool? SkinIntegrityBroken
        {
            get { return (bool?)this["SKININTEGRITYBROKEN"]; }
            set { this["SKININTEGRITYBROKEN"] = value; }
        }

    /// <summary>
    /// İlaçlar
    /// </summary>
        public bool? MedicineUsage
        {
            get { return (bool?)this["MEDICINEUSAGE"]; }
            set { this["MEDICINEUSAGE"] = value; }
        }

    /// <summary>
    /// orta iştah
    /// </summary>
        public bool? AppetiteAverage
        {
            get { return (bool?)this["APPETITEAVERAGE"]; }
            set { this["APPETITEAVERAGE"] = value; }
        }

    /// <summary>
    /// Sadece sıvı (iştah)
    /// </summary>
        public bool? AppetiteOnlyLiquid
        {
            get { return (bool?)this["APPETITEONLYLIQUID"]; }
            set { this["APPETITEONLYLIQUID"] = value; }
        }

    /// <summary>
    /// Zayıf iştah
    /// </summary>
        public bool? AppetitePoor
        {
            get { return (bool?)this["APPETITEPOOR"]; }
            set { this["APPETITEPOOR"] = value; }
        }

    /// <summary>
    /// Ng (iştah)
    /// </summary>
        public bool? AppetiteNg
        {
            get { return (bool?)this["APPETITENG"]; }
            set { this["APPETITENG"] = value; }
        }

    /// <summary>
    /// Anoraksi, oral alım yok
    /// </summary>
        public bool? AppetiteAnorexia
        {
            get { return (bool?)this["APPETITEANOREXIA"]; }
            set { this["APPETITEANOREXIA"] = value; }
        }

    /// <summary>
    /// Terminal kaşeksi
    /// </summary>
        public bool? DMTerminalCachexia
        {
            get { return (bool?)this["DMTERMINALCACHEXIA"]; }
            set { this["DMTERMINALCACHEXIA"] = value; }
        }

    /// <summary>
    /// Kalp yetmezliği
    /// </summary>
        public bool? DMHeartFailure
        {
            get { return (bool?)this["DMHEARTFAILURE"]; }
            set { this["DMHEARTFAILURE"] = value; }
        }

    /// <summary>
    /// Periferik vasküler rahatsızlık
    /// </summary>
        public bool? DMPeripheralVascularDisease
        {
            get { return (bool?)this["DMPERIPHERALVASCULARDISEASE"]; }
            set { this["DMPERIPHERALVASCULARDISEASE"] = value; }
        }

    /// <summary>
    /// Anemi
    /// </summary>
        public bool? DMAnemia
        {
            get { return (bool?)this["DMANEMIA"]; }
            set { this["DMANEMIA"] = value; }
        }

    /// <summary>
    /// Sigara
    /// </summary>
        public bool? DMCigaretteUsage
        {
            get { return (bool?)this["DMCIGARETTEUSAGE"]; }
            set { this["DMCIGARETTEUSAGE"] = value; }
        }

    /// <summary>
    /// Ortopedik, belden aşağı veya spinal ameliyat/travma
    /// </summary>
        public bool? SurgeryOrthopedic
        {
            get { return (bool?)this["SURGERYORTHOPEDIC"]; }
            set { this["SURGERYORTHOPEDIC"] = value; }
        }

    /// <summary>
    /// Ameliyat masasında 2 saatten fazla kalma
    /// </summary>
        public bool? SurgeryLongerThan2Hours
        {
            get { return (bool?)this["SURGERYLONGERTHAN2HOURS"]; }
            set { this["SURGERYLONGERTHAN2HOURS"] = value; }
        }

    /// <summary>
    /// Bası Yarası Oluşma Zamanı
    /// </summary>
        public PressureWoundTimeEnum? NursingWoundTime
        {
            get { return (PressureWoundTimeEnum?)(int?)this["NURSINGWOUNDTIME"]; }
            set { this["NURSINGWOUNDTIME"] = value; }
        }

        public GradeDistributionEnum? GradeDistribution
        {
            get { return (GradeDistributionEnum?)(int?)this["GRADEDISTRIBUTION"]; }
            set { this["GRADEDISTRIBUTION"] = value; }
        }

        protected NursingWoundAssessmentScale(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected NursingWoundAssessmentScale(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected NursingWoundAssessmentScale(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected NursingWoundAssessmentScale(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected NursingWoundAssessmentScale(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "NURSINGWOUNDASSESSMENTSCALE", dataRow) { }
        protected NursingWoundAssessmentScale(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "NURSINGWOUNDASSESSMENTSCALE", dataRow, isImported) { }
        public NursingWoundAssessmentScale(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public NursingWoundAssessmentScale(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public NursingWoundAssessmentScale() : base() { }

    }
}