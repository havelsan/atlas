
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="GeneralInformation")] 

    public  partial class GeneralInformation : BaseMultipleDataEntry
    {
        public class GeneralInformationList : TTObjectCollection<GeneralInformation> { }
                    
        public class ChildGeneralInformationCollection : TTObject.TTChildObjectCollection<GeneralInformation>
        {
            public ChildGeneralInformationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildGeneralInformationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Doğum Öncesi (Prenatal)
    /// </summary>
        public string Prenatal
        {
            get { return (string)this["PRENATAL"]; }
            set { this["PRENATAL"] = value; }
        }

    /// <summary>
    /// Doğum (Natal)
    /// </summary>
        public string Natal
        {
            get { return (string)this["NATAL"]; }
            set { this["NATAL"] = value; }
        }

    /// <summary>
    /// Doğum Sonrası (Postnatal)
    /// </summary>
        public string Postnatal
        {
            get { return (string)this["POSTNATAL"]; }
            set { this["POSTNATAL"] = value; }
        }

    /// <summary>
    /// Göbek Düşmesi
    /// </summary>
        public string NavelCord
        {
            get { return (string)this["NAVELCORD"]; }
            set { this["NAVELCORD"] = value; }
        }

    /// <summary>
    /// Emme Refleksi
    /// </summary>
        public string SuckingReflex
        {
            get { return (string)this["SUCKINGREFLEX"]; }
            set { this["SUCKINGREFLEX"] = value; }
        }

    /// <summary>
    /// Üfürüm
    /// </summary>
        public string Murmur
        {
            get { return (string)this["MURMUR"]; }
            set { this["MURMUR"] = value; }
        }

    /// <summary>
    /// Cilt
    /// </summary>
        public string Skin
        {
            get { return (string)this["SKIN"]; }
            set { this["SKIN"] = value; }
        }

    /// <summary>
    /// Göbek
    /// </summary>
        public string Navel
        {
            get { return (string)this["NAVEL"]; }
            set { this["NAVEL"] = value; }
        }

    /// <summary>
    /// Anal Bölge
    /// </summary>
        public string AnalRegion
        {
            get { return (string)this["ANALREGION"]; }
            set { this["ANALREGION"] = value; }
        }

    /// <summary>
    /// Tedavi Planı
    /// </summary>
        public string TreatmentPlan
        {
            get { return (string)this["TREATMENTPLAN"]; }
            set { this["TREATMENTPLAN"] = value; }
        }

        public PhysicianApplication PhysicianApplication
        {
            get 
            {   
                if (EpisodeAction is PhysicianApplication)
                    return (PhysicianApplication)EpisodeAction; 
                return null;
            }            
            set { EpisodeAction = value; }
        }

        protected GeneralInformation(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected GeneralInformation(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected GeneralInformation(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected GeneralInformation(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected GeneralInformation(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "GENERALINFORMATION", dataRow) { }
        protected GeneralInformation(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "GENERALINFORMATION", dataRow, isImported) { }
        public GeneralInformation(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public GeneralInformation(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public GeneralInformation() : base() { }

    }
}