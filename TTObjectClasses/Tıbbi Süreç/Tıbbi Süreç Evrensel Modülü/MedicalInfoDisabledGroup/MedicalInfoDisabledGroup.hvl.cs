
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MedicalInfoDisabledGroup")] 

    /// <summary>
    /// Engel Grubu
    /// </summary>
    public  partial class MedicalInfoDisabledGroup : TTObject
    {
        public class MedicalInfoDisabledGroupList : TTObjectCollection<MedicalInfoDisabledGroup> { }
                    
        public class ChildMedicalInfoDisabledGroupCollection : TTObject.TTChildObjectCollection<MedicalInfoDisabledGroup>
        {
            public ChildMedicalInfoDisabledGroupCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMedicalInfoDisabledGroupCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Ortopedik
    /// </summary>
        public bool? Orthopedic
        {
            get { return (bool?)this["ORTHOPEDIC"]; }
            set { this["ORTHOPEDIC"] = value; }
        }

    /// <summary>
    /// Görme
    /// </summary>
        public bool? Vision
        {
            get { return (bool?)this["VISION"]; }
            set { this["VISION"] = value; }
        }

    /// <summary>
    /// İşitme
    /// </summary>
        public bool? Hearing
        {
            get { return (bool?)this["HEARING"]; }
            set { this["HEARING"] = value; }
        }

    /// <summary>
    /// Dil ve Konuşma
    /// </summary>
        public bool? SpeechAndLanguage
        {
            get { return (bool?)this["SPEECHANDLANGUAGE"]; }
            set { this["SPEECHANDLANGUAGE"] = value; }
        }

    /// <summary>
    /// Zihinsel
    /// </summary>
        public bool? Mental
        {
            get { return (bool?)this["MENTAL"]; }
            set { this["MENTAL"] = value; }
        }

    /// <summary>
    /// Ruhsal ve Duygusal
    /// </summary>
        public bool? PsychicAndEmotional
        {
            get { return (bool?)this["PSYCHICANDEMOTIONAL"]; }
            set { this["PSYCHICANDEMOTIONAL"] = value; }
        }

    /// <summary>
    /// Süreğen(Kronik)
    /// </summary>
        public bool? Chronic
        {
            get { return (bool?)this["CHRONIC"]; }
            set { this["CHRONIC"] = value; }
        }

    /// <summary>
    /// Sınıflanmayan
    /// </summary>
        public bool? Unclassified
        {
            get { return (bool?)this["UNCLASSIFIED"]; }
            set { this["UNCLASSIFIED"] = value; }
        }

    /// <summary>
    /// Yok
    /// </summary>
        public bool? Nonexistence
        {
            get { return (bool?)this["NONEXISTENCE"]; }
            set { this["NONEXISTENCE"] = value; }
        }

        protected MedicalInfoDisabledGroup(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MedicalInfoDisabledGroup(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MedicalInfoDisabledGroup(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MedicalInfoDisabledGroup(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MedicalInfoDisabledGroup(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MEDICALINFODISABLEDGROUP", dataRow) { }
        protected MedicalInfoDisabledGroup(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MEDICALINFODISABLEDGROUP", dataRow, isImported) { }
        public MedicalInfoDisabledGroup(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MedicalInfoDisabledGroup(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MedicalInfoDisabledGroup() : base() { }

    }
}