
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="LaboratoryTripleTestInfo")] 

    public  partial class LaboratoryTripleTestInfo : TTObject
    {
        public class LaboratoryTripleTestInfoList : TTObjectCollection<LaboratoryTripleTestInfo> { }
                    
        public class ChildLaboratoryTripleTestInfoCollection : TTObject.TTChildObjectCollection<LaboratoryTripleTestInfo>
        {
            public ChildLaboratoryTripleTestInfoCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildLaboratoryTripleTestInfoCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Hasta Adı
    /// </summary>
        public string PatientName
        {
            get { return (string)this["PATIENTNAME"]; }
            set { this["PATIENTNAME"] = value; }
        }

    /// <summary>
    /// Hasta Soyadı
    /// </summary>
        public string PatientSurname
        {
            get { return (string)this["PATIENTSURNAME"]; }
            set { this["PATIENTSURNAME"] = value; }
        }

    /// <summary>
    /// Hastanın Doğum Yeri
    /// </summary>
        public string PatientBirthPlace
        {
            get { return (string)this["PATIENTBIRTHPLACE"]; }
            set { this["PATIENTBIRTHPLACE"] = value; }
        }

    /// <summary>
    /// Hastanın Doğum Tarihi
    /// </summary>
        public DateTime? PatientBirthDate
        {
            get { return (DateTime?)this["PATIENTBIRTHDATE"]; }
            set { this["PATIENTBIRTHDATE"] = value; }
        }

    /// <summary>
    /// Hastanın Telefon Numarası
    /// </summary>
        public string PatientPhoneNumber
        {
            get { return (string)this["PATIENTPHONENUMBER"]; }
            set { this["PATIENTPHONENUMBER"] = value; }
        }

    /// <summary>
    /// Hasta Ağırlık
    /// </summary>
        public int? PatientWeight
        {
            get { return (int?)this["PATIENTWEIGHT"]; }
            set { this["PATIENTWEIGHT"] = value; }
        }

    /// <summary>
    /// Diyabeti var mı
    /// </summary>
        public bool? IsHaveDiabetes
        {
            get { return (bool?)this["ISHAVEDIABETES"]; }
            set { this["ISHAVEDIABETES"] = value; }
        }

    /// <summary>
    /// Sigara Kullanımı
    /// </summary>
        public bool? Smoking
        {
            get { return (bool?)this["SMOKING"]; }
            set { this["SMOKING"] = value; }
        }

    /// <summary>
    /// Günde içilen sigara sayısı
    /// </summary>
        public int? SmokingNumberPerADay
        {
            get { return (int?)this["SMOKINGNUMBERPERADAY"]; }
            set { this["SMOKINGNUMBERPERADAY"] = value; }
        }

    /// <summary>
    /// Son Adet Zamanı
    /// </summary>
        public DateTime? LastMenstrualDate
        {
            get { return (DateTime?)this["LASTMENSTRUALDATE"]; }
            set { this["LASTMENSTRUALDATE"] = value; }
        }

    /// <summary>
    /// Siklus Uzunluğu
    /// </summary>
        public int? CycleLength
        {
            get { return (int?)this["CYCLELENGTH"]; }
            set { this["CYCLELENGTH"] = value; }
        }

    /// <summary>
    /// Ultrasound Tarihi
    /// </summary>
        public DateTime? UltrasoundDate
        {
            get { return (DateTime?)this["ULTRASOUNDDATE"]; }
            set { this["ULTRASOUNDDATE"] = value; }
        }

    /// <summary>
    /// US Sırasındaki Gebelik Yaşı(hafta)
    /// </summary>
        public int? GestationalAge
        {
            get { return (int?)this["GESTATIONALAGE"]; }
            set { this["GESTATIONALAGE"] = value; }
        }

    /// <summary>
    /// BPD
    /// </summary>
        public int? BiparietalDiameter
        {
            get { return (int?)this["BIPARIETALDIAMETER"]; }
            set { this["BIPARIETALDIAMETER"] = value; }
        }

        protected LaboratoryTripleTestInfo(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected LaboratoryTripleTestInfo(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected LaboratoryTripleTestInfo(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected LaboratoryTripleTestInfo(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected LaboratoryTripleTestInfo(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "LABORATORYTRIPLETESTINFO", dataRow) { }
        protected LaboratoryTripleTestInfo(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "LABORATORYTRIPLETESTINFO", dataRow, isImported) { }
        public LaboratoryTripleTestInfo(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public LaboratoryTripleTestInfo(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public LaboratoryTripleTestInfo() : base() { }

    }
}