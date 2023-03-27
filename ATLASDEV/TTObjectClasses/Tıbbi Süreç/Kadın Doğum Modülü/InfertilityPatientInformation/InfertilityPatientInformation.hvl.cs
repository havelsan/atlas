
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="InfertilityPatientInformation")] 

    public  partial class InfertilityPatientInformation : TTObject
    {
        public class InfertilityPatientInformationList : TTObjectCollection<InfertilityPatientInformation> { }
                    
        public class ChildInfertilityPatientInformationCollection : TTObject.TTChildObjectCollection<InfertilityPatientInformation>
        {
            public ChildInfertilityPatientInformationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildInfertilityPatientInformationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Histeroskopi Açıklama
    /// </summary>
        public string HysteroscopyInformation
        {
            get { return (string)this["HYSTEROSCOPYINFORMATION"]; }
            set { this["HYSTEROSCOPYINFORMATION"] = value; }
        }

    /// <summary>
    /// Histerosalpingografi Tarihi
    /// </summary>
        public DateTime? HysterosalpingographyDate
        {
            get { return (DateTime?)this["HYSTEROSALPINGOGRAPHYDATE"]; }
            set { this["HYSTEROSALPINGOGRAPHYDATE"] = value; }
        }

    /// <summary>
    /// Laparoskopi Açıklama
    /// </summary>
        public string LaparoscopyInformation
        {
            get { return (string)this["LAPAROSCOPYINFORMATION"]; }
            set { this["LAPAROSCOPYINFORMATION"] = value; }
        }

    /// <summary>
    /// Lipiodolografi
    /// </summary>
        public string Lipiodolography
        {
            get { return (string)this["LIPIODOLOGRAPHY"]; }
            set { this["LIPIODOLOGRAPHY"] = value; }
        }

    /// <summary>
    /// Laparoskopi Tarihi
    /// </summary>
        public DateTime? LaparoscopyDate
        {
            get { return (DateTime?)this["LAPAROSCOPYDATE"]; }
            set { this["LAPAROSCOPYDATE"] = value; }
        }

    /// <summary>
    /// Histeroskopi Tarihi
    /// </summary>
        public DateTime? HysteroscopyDate
        {
            get { return (DateTime?)this["HYSTEROSCOPYDATE"]; }
            set { this["HYSTEROSCOPYDATE"] = value; }
        }

    /// <summary>
    /// Su Soluble
    /// </summary>
        public string SuSoluble
        {
            get { return (string)this["SUSOLUBLE"]; }
            set { this["SUSOLUBLE"] = value; }
        }

    /// <summary>
    /// Uterin Kavite
    /// </summary>
        public string UterineCavity
        {
            get { return (string)this["UTERINECAVITY"]; }
            set { this["UTERINECAVITY"] = value; }
        }

    /// <summary>
    /// Tubal Dolum Sağ
    /// </summary>
        public string TubalRight
        {
            get { return (string)this["TUBALRIGHT"]; }
            set { this["TUBALRIGHT"] = value; }
        }

    /// <summary>
    /// Tubal Dolum Sol
    /// </summary>
        public string TubalLeft
        {
            get { return (string)this["TUBALLEFT"]; }
            set { this["TUBALLEFT"] = value; }
        }

    /// <summary>
    /// Batına Dağılım
    /// </summary>
        public string AbdominalDistribution
        {
            get { return (string)this["ABDOMINALDISTRIBUTION"]; }
            set { this["ABDOMINALDISTRIBUTION"] = value; }
        }

    /// <summary>
    /// OFIS HS Tarih
    /// </summary>
        public DateTime? OFISHSDate
        {
            get { return (DateTime?)this["OFISHSDATE"]; }
            set { this["OFISHSDATE"] = value; }
        }

    /// <summary>
    /// OFIS HS Açıklama
    /// </summary>
        public string OFISHSInformation
        {
            get { return (string)this["OFISHSINFORMATION"]; }
            set { this["OFISHSINFORMATION"] = value; }
        }

    /// <summary>
    /// Hastanın Geçirdiği Ameliyatlar
    /// </summary>
        public string PatientsSurgeries
        {
            get { return (string)this["PATIENTSSURGERIES"]; }
            set { this["PATIENTSSURGERIES"] = value; }
        }

    /// <summary>
    /// Eşinin Geçirdiği Ameliyatlar
    /// </summary>
        public string HusbandsSurgeries
        {
            get { return (string)this["HUSBANDSSURGERIES"]; }
            set { this["HUSBANDSSURGERIES"] = value; }
        }

    /// <summary>
    /// Geçmiş Tedavi Bilgileri
    /// </summary>
        public string HistoryOfTreatment
        {
            get { return (string)this["HISTORYOFTREATMENT"]; }
            set { this["HISTORYOFTREATMENT"] = value; }
        }

        protected InfertilityPatientInformation(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected InfertilityPatientInformation(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected InfertilityPatientInformation(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected InfertilityPatientInformation(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected InfertilityPatientInformation(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "INFERTILITYPATIENTINFORMATION", dataRow) { }
        protected InfertilityPatientInformation(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "INFERTILITYPATIENTINFORMATION", dataRow, isImported) { }
        public InfertilityPatientInformation(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public InfertilityPatientInformation(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public InfertilityPatientInformation() : base() { }

    }
}