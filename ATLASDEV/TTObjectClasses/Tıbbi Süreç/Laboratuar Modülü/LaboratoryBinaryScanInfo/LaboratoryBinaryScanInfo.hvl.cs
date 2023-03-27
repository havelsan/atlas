
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="LaboratoryBinaryScanInfo")] 

    public  partial class LaboratoryBinaryScanInfo : TTObject
    {
        public class LaboratoryBinaryScanInfoList : TTObjectCollection<LaboratoryBinaryScanInfo> { }
                    
        public class ChildLaboratoryBinaryScanInfoCollection : TTObject.TTChildObjectCollection<LaboratoryBinaryScanInfo>
        {
            public ChildLaboratoryBinaryScanInfoCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildLaboratoryBinaryScanInfoCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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
    /// Serum Alınış Tarihi
    /// </summary>
        public DateTime? SerumReceiptDate
        {
            get { return (DateTime?)this["SERUMRECEIPTDATE"]; }
            set { this["SERUMRECEIPTDATE"] = value; }
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
    /// Ultrasound Tarihi
    /// </summary>
        public DateTime? UltrasoundDate
        {
            get { return (DateTime?)this["ULTRASOUNDDATE"]; }
            set { this["ULTRASOUNDDATE"] = value; }
        }

    /// <summary>
    /// CRL Ölçümü
    /// </summary>
        public int? CrlMeasurement
        {
            get { return (int?)this["CRLMEASUREMENT"]; }
            set { this["CRLMEASUREMENT"] = value; }
        }

    /// <summary>
    /// Nuchal Translucency Ölçümü
    /// </summary>
        public double? NuchalTranslucencyMeasurement
        {
            get { return (double?)this["NUCHALTRANSLUCENCYMEASUREMENT"]; }
            set { this["NUCHALTRANSLUCENCYMEASUREMENT"] = value; }
        }

    /// <summary>
    /// Ultrasoundda anomali
    /// </summary>
        public bool? AbnormalitiesOnUltrasound
        {
            get { return (bool?)this["ABNORMALITIESONULTRASOUND"]; }
            set { this["ABNORMALITIESONULTRASOUND"] = value; }
        }

    /// <summary>
    /// Nazal Kemik
    /// </summary>
        public bool? NasalBone
        {
            get { return (bool?)this["NASALBONE"]; }
            set { this["NASALBONE"] = value; }
        }

    /// <summary>
    /// Maternal Kilo
    /// </summary>
        public int? MaternalWeight
        {
            get { return (int?)this["MATERNALWEIGHT"]; }
            set { this["MATERNALWEIGHT"] = value; }
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
    /// İnsüline Bağlı Diyabet
    /// </summary>
        public bool? InsulinDependentDiabetes
        {
            get { return (bool?)this["INSULINDEPENDENTDIABETES"]; }
            set { this["INSULINDEPENDENTDIABETES"] = value; }
        }

    /// <summary>
    /// Ivf
    /// </summary>
        public bool? Ivf
        {
            get { return (bool?)this["IVF"]; }
            set { this["IVF"] = value; }
        }

    /// <summary>
    /// İkiz Gebelik
    /// </summary>
        public bool? TwinPregnancy
        {
            get { return (bool?)this["TWINPREGNANCY"]; }
            set { this["TWINPREGNANCY"] = value; }
        }

        protected LaboratoryBinaryScanInfo(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected LaboratoryBinaryScanInfo(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected LaboratoryBinaryScanInfo(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected LaboratoryBinaryScanInfo(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected LaboratoryBinaryScanInfo(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "LABORATORYBINARYSCANINFO", dataRow) { }
        protected LaboratoryBinaryScanInfo(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "LABORATORYBINARYSCANINFO", dataRow, isImported) { }
        public LaboratoryBinaryScanInfo(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public LaboratoryBinaryScanInfo(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public LaboratoryBinaryScanInfo() : base() { }

    }
}