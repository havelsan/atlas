
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="Gynecology")] 

    public  partial class Gynecology : TTObject
    {
        public class GynecologyList : TTObjectCollection<Gynecology> { }
                    
        public class ChildGynecologyCollection : TTObject.TTChildObjectCollection<Gynecology>
        {
            public ChildGynecologyCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildGynecologyCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Menstural Siklus Anomalisi
    /// </summary>
        public MenstrualCycleAbnormalitiesEnum? MenstrualCycleAbnormalities
        {
            get { return (MenstrualCycleAbnormalitiesEnum?)(int?)this["MENSTRUALCYCLEABNORMALITIES"]; }
            set { this["MENSTRUALCYCLEABNORMALITIES"] = value; }
        }

    /// <summary>
    /// Menstural Siklus Açıklama
    /// </summary>
        public string MenstrualCycleInformation
        {
            get { return (string)this["MENSTRUALCYCLEINFORMATION"]; }
            set { this["MENSTRUALCYCLEINFORMATION"] = value; }
        }

    /// <summary>
    /// Genital Bölge Muayene
    /// </summary>
        public string GenitalExamination
        {
            get { return (string)this["GENITALEXAMINATION"]; }
            set { this["GENITALEXAMINATION"] = value; }
        }

    /// <summary>
    /// Pelvik Muayene
    /// </summary>
        public string PelvicExamination
        {
            get { return (string)this["PELVICEXAMINATION"]; }
            set { this["PELVICEXAMINATION"] = value; }
        }

    /// <summary>
    /// Vulva Vagen
    /// </summary>
        public string VulvaVagen
        {
            get { return (string)this["VULVAVAGEN"]; }
            set { this["VULVAVAGEN"] = value; }
        }

    /// <summary>
    /// Serviks
    /// </summary>
        public string Cervix
        {
            get { return (string)this["CERVIX"]; }
            set { this["CERVIX"] = value; }
        }

    /// <summary>
    /// Uterus
    /// </summary>
        public string Uterus
        {
            get { return (string)this["UTERUS"]; }
            set { this["UTERUS"] = value; }
        }

    /// <summary>
    /// Üreme Organı Anomalileri Açıklama
    /// </summary>
        public string ReproductiveAbnormalitiesInfo
        {
            get { return (string)this["REPRODUCTIVEABNORMALITIESINFO"]; }
            set { this["REPRODUCTIVEABNORMALITIESINFO"] = value; }
        }

    /// <summary>
    /// Jinekolojik Anamnez
    /// </summary>
        public string GynecologicalHistory
        {
            get { return (string)this["GYNECOLOGICALHISTORY"]; }
            set { this["GYNECOLOGICALHISTORY"] = value; }
        }

    /// <summary>
    /// Bazal Ultrason
    /// </summary>
        public string BasalUltrasound
        {
            get { return (string)this["BASALULTRASOUND"]; }
            set { this["BASALULTRASOUND"] = value; }
        }

    /// <summary>
    /// Tümör Belirleyiciler
    /// </summary>
        public string TumorMarkers
        {
            get { return (string)this["TUMORMARKERS"]; }
            set { this["TUMORMARKERS"] = value; }
        }

    /// <summary>
    /// Son Jinekolojik Muayene Tarihi
    /// </summary>
        public DateTime? LastExaminationDate
        {
            get { return (DateTime?)this["LASTEXAMINATIONDATE"]; }
            set { this["LASTEXAMINATIONDATE"] = value; }
        }

    /// <summary>
    /// Son Smear Tarihi
    /// </summary>
        public DateTime? LastSmearDate
        {
            get { return (DateTime?)this["LASTSMEARDATE"]; }
            set { this["LASTSMEARDATE"] = value; }
        }

    /// <summary>
    /// Önceki Doğum Kontrol Yöntemi
    /// </summary>
        public BirthControlMethodEnum? PreviousBirthControlMethod
        {
            get { return (BirthControlMethodEnum?)(int?)this["PREVIOUSBIRTHCONTROLMETHOD"]; }
            set { this["PREVIOUSBIRTHCONTROLMETHOD"] = value; }
        }

    /// <summary>
    /// Güncel Doğum Kontrol Yöntemi
    /// </summary>
        public BirthControlMethodEnum? CurrentBirthControlMethod
        {
            get { return (BirthControlMethodEnum?)(int?)this["CURRENTBIRTHCONTROLMETHOD"]; }
            set { this["CURRENTBIRTHCONTROLMETHOD"] = value; }
        }

    /// <summary>
    /// Vajinal Akıntı
    /// </summary>
        public bool? VaginalDischarge
        {
            get { return (bool?)this["VAGINALDISCHARGE"]; }
            set { this["VAGINALDISCHARGE"] = value; }
        }

    /// <summary>
    /// Genital Bölge Anomalisi
    /// </summary>
        public GenitalAbnormalitiesEnum? GenitalAbnormalities
        {
            get { return (GenitalAbnormalitiesEnum?)(int?)this["GENITALABNORMALITIES"]; }
            set { this["GENITALABNORMALITIES"] = value; }
        }

    /// <summary>
    /// Genital Bölge Anomalisi Açıklama
    /// </summary>
        public string GenitalAbnormalitiesInfo
        {
            get { return (string)this["GENITALABNORMALITIESINFO"]; }
            set { this["GENITALABNORMALITIESINFO"] = value; }
        }

    /// <summary>
    /// İdrar Yaparken Ağrı/Yanma
    /// </summary>
        public bool? Dysuria
        {
            get { return (bool?)this["DYSURIA"]; }
            set { this["DYSURIA"] = value; }
        }

    /// <summary>
    /// İdrar Yaparken Ağrı/Yanma Açıklama
    /// </summary>
        public string DysuriaInformation
        {
            get { return (string)this["DYSURIAINFORMATION"]; }
            set { this["DYSURIAINFORMATION"] = value; }
        }

    /// <summary>
    /// Cinsel İlişki Sırasında Ağrı,Kanama
    /// </summary>
        public bool? Dyspareunia
        {
            get { return (bool?)this["DYSPAREUNIA"]; }
            set { this["DYSPAREUNIA"] = value; }
        }

    /// <summary>
    /// Cinsel İlişki Sırasında Ağrı,Kanama Açıklama
    /// </summary>
        public string DyspareuniaInformation
        {
            get { return (string)this["DYSPAREUNIAINFORMATION"]; }
            set { this["DYSPAREUNIAINFORMATION"] = value; }
        }

    /// <summary>
    /// Tüylenme
    /// </summary>
        public bool? Hirsutism
        {
            get { return (bool?)this["HIRSUTISM"]; }
            set { this["HIRSUTISM"] = value; }
        }

    /// <summary>
    /// Tüylenme Açıklama
    /// </summary>
        public string HirsutismInformation
        {
            get { return (string)this["HIRSUTISMINFORMATION"]; }
            set { this["HIRSUTISMINFORMATION"] = value; }
        }

    /// <summary>
    /// Vajinal Akıntı Açıklama
    /// </summary>
        public string VaginalDischargeInformation
        {
            get { return (string)this["VAGINALDISCHARGEINFORMATION"]; }
            set { this["VAGINALDISCHARGEINFORMATION"] = value; }
        }

        public ReproductiveAbnormalityDefinition ReproductiveAbnormality
        {
            get { return (ReproductiveAbnormalityDefinition)((ITTObject)this).GetParent("REPRODUCTIVEABNORMALITY"); }
            set { this["REPRODUCTIVEABNORMALITY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateWomanSpecialityObjectCollection()
        {
            _WomanSpecialityObject = new WomanSpecialityObject.ChildWomanSpecialityObjectCollection(this, new Guid("d91f4c55-3b79-4563-9e82-a76730246e33"));
            ((ITTChildObjectCollection)_WomanSpecialityObject).GetChildren();
        }

        protected WomanSpecialityObject.ChildWomanSpecialityObjectCollection _WomanSpecialityObject = null;
        public WomanSpecialityObject.ChildWomanSpecialityObjectCollection WomanSpecialityObject
        {
            get
            {
                if (_WomanSpecialityObject == null)
                    CreateWomanSpecialityObjectCollection();
                return _WomanSpecialityObject;
            }
        }

        protected Gynecology(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected Gynecology(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected Gynecology(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected Gynecology(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected Gynecology(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "GYNECOLOGY", dataRow) { }
        protected Gynecology(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "GYNECOLOGY", dataRow, isImported) { }
        public Gynecology(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public Gynecology(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public Gynecology() : base() { }

    }
}