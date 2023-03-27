
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="KvcRiskScore")] 

    /// <summary>
    /// KVC Risk Skorlama
    /// </summary>
    public  partial class KvcRiskScore : TTObject
    {
        public class KvcRiskScoreList : TTObjectCollection<KvcRiskScore> { }
                    
        public class ChildKvcRiskScoreCollection : TTObject.TTChildObjectCollection<KvcRiskScore>
        {
            public ChildKvcRiskScoreCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildKvcRiskScoreCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Geçirilmiş kardiyak operasyon
    /// </summary>
        public bool? CardiacOperation
        {
            get { return (bool?)this["CARDIACOPERATION"]; }
            set { this["CARDIACOPERATION"] = value; }
        }

    /// <summary>
    /// Böbrek fonksiyon bozukluğu
    /// </summary>
        public bool? KidneyFunction
        {
            get { return (bool?)this["KIDNEYFUNCTION"]; }
            set { this["KIDNEYFUNCTION"] = value; }
        }

    /// <summary>
    /// Böbrek yetmezliği
    /// </summary>
        public bool? KidneyFailure
        {
            get { return (bool?)this["KIDNEYFAILURE"]; }
            set { this["KIDNEYFAILURE"] = value; }
        }

    /// <summary>
    /// Aktif endokardit
    /// </summary>
        public bool? ActiveEndocarditis
        {
            get { return (bool?)this["ACTIVEENDOCARDITIS"]; }
            set { this["ACTIVEENDOCARDITIS"] = value; }
        }

    /// <summary>
    /// Kritik preoperatif durum
    /// </summary>
        public bool? CriticalPreop
        {
            get { return (bool?)this["CRITICALPREOP"]; }
            set { this["CRITICALPREOP"] = value; }
        }

    /// <summary>
    /// Diabetes Mellitus
    /// </summary>
        public bool? DiabetesMellitus
        {
            get { return (bool?)this["DIABETESMELLITUS"]; }
            set { this["DIABETESMELLITUS"] = value; }
        }

    /// <summary>
    /// EF <%30
    /// </summary>
        public bool? LVLess30
        {
            get { return (bool?)this["LVLESS30"]; }
            set { this["LVLESS30"] = value; }
        }

    /// <summary>
    /// Toplam
    /// </summary>
        public int? TotalScore
        {
            get { return (int?)this["TOTALSCORE"]; }
            set { this["TOTALSCORE"] = value; }
        }

    /// <summary>
    /// Torasik aorta cerrahisi
    /// </summary>
        public bool? ThoracicAorta
        {
            get { return (bool?)this["THORACICAORTA"]; }
            set { this["THORACICAORTA"] = value; }
        }

    /// <summary>
    /// Post MI VSD
    /// </summary>
        public bool? PostMIVSD
        {
            get { return (bool?)this["POSTMIVSD"]; }
            set { this["POSTMIVSD"] = value; }
        }

    /// <summary>
    /// EF %30-%50 arasında olması
    /// </summary>
        public bool? LV30to50
        {
            get { return (bool?)this["LV30TO50"]; }
            set { this["LV30TO50"] = value; }
        }

    /// <summary>
    /// Pulmoner hipertansiyon
    /// </summary>
        public bool? PulmonaryHypertension
        {
            get { return (bool?)this["PULMONARYHYPERTENSION"]; }
            set { this["PULMONARYHYPERTENSION"] = value; }
        }

    /// <summary>
    /// TOPLAM Risk Puanı
    /// </summary>
        public KvcResultEnum? TotalRisk
        {
            get { return (KvcResultEnum?)(int?)this["TOTALRISK"]; }
            set { this["TOTALRISK"] = value; }
        }

    /// <summary>
    /// Hasta kadın mı?
    /// </summary>
        public bool? IsWoman
        {
            get { return (bool?)this["ISWOMAN"]; }
            set { this["ISWOMAN"] = value; }
        }

    /// <summary>
    /// Yaş Puanı : 60- 65 Yaş:1,  66-70 Yaş:2,  71 Yaş ve yaş üstü:3
    /// </summary>
        public int? AgePoint
        {
            get { return (int?)this["AGEPOINT"]; }
            set { this["AGEPOINT"] = value; }
        }

    /// <summary>
    /// Kronik akciğer hastalığı
    /// </summary>
        public bool? KahRaspiration
        {
            get { return (bool?)this["KAHRASPIRATION"]; }
            set { this["KAHRASPIRATION"] = value; }
        }

    /// <summary>
    /// Kronik akciğer hastalığı
    /// </summary>
        public bool? KahLung
        {
            get { return (bool?)this["KAHLUNG"]; }
            set { this["KAHLUNG"] = value; }
        }

    /// <summary>
    /// Ekstrakardiyak arteriopati
    /// </summary>
        public bool? EkstrakardiyakArteriopati
        {
            get { return (bool?)this["EKSTRAKARDIYAKARTERIOPATI"]; }
            set { this["EKSTRAKARDIYAKARTERIOPATI"] = value; }
        }

    /// <summary>
    /// Giriş Yapılan Zaman
    /// </summary>
        public DateTime? EntryDate
        {
            get { return (DateTime?)this["ENTRYDATE"]; }
            set { this["ENTRYDATE"] = value; }
        }

        public ResUser EntryUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("ENTRYUSER"); }
            set { this["ENTRYUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Surgery Surgery
        {
            get { return (Surgery)((ITTObject)this).GetParent("SURGERY"); }
            set { this["SURGERY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected KvcRiskScore(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected KvcRiskScore(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected KvcRiskScore(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected KvcRiskScore(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected KvcRiskScore(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "KVCRISKSCORE", dataRow) { }
        protected KvcRiskScore(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "KVCRISKSCORE", dataRow, isImported) { }
        public KvcRiskScore(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public KvcRiskScore(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public KvcRiskScore() : base() { }

    }
}