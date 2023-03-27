
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PackageTemplateEtkinMadDef")] 

    /// <summary>
    /// Paket Tanımları - Etkin Madde
    /// </summary>
    public  partial class PackageTemplateEtkinMadDef : TTDefinitionSet
    {
        public class PackageTemplateEtkinMadDefList : TTObjectCollection<PackageTemplateEtkinMadDef> { }
                    
        public class ChildPackageTemplateEtkinMadDefCollection : TTObject.TTChildObjectCollection<PackageTemplateEtkinMadDef>
        {
            public ChildPackageTemplateEtkinMadDefCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPackageTemplateEtkinMadDefCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Adet
    /// </summary>
        public int? Count
        {
            get { return (int?)this["COUNT"]; }
            set { this["COUNT"] = value; }
        }

    /// <summary>
    /// Kullanım Periyodu
    /// </summary>
        public int? Day
        {
            get { return (int?)this["DAY"]; }
            set { this["DAY"] = value; }
        }

    /// <summary>
    /// Doz
    /// </summary>
        public string Dose
        {
            get { return (string)this["DOSE"]; }
            set { this["DOSE"] = value; }
        }

    /// <summary>
    /// İlaç İsmi
    /// </summary>
        public string DrugName
        {
            get { return (string)this["DRUGNAME"]; }
            set { this["DRUGNAME"] = value; }
        }

    /// <summary>
    /// Doz Aralığı
    /// </summary>
        public FrequencyEnum? Frequency
        {
            get { return (FrequencyEnum?)(int?)this["FREQUENCY"]; }
            set { this["FREQUENCY"] = value; }
        }

    /// <summary>
    /// Doz
    /// </summary>
        public double? MedulaDose
        {
            get { return (double?)this["MEDULADOSE"]; }
            set { this["MEDULADOSE"] = value; }
        }

    /// <summary>
    /// Doz
    /// </summary>
        public string MedulaDoseInteger
        {
            get { return (string)this["MEDULADOSEINTEGER"]; }
            set { this["MEDULADOSEINTEGER"] = value; }
        }

    /// <summary>
    /// Medula Kullanım Doz 2
    /// </summary>
        public double? MedulaUsageDose2
        {
            get { return (double?)this["MEDULAUSAGEDOSE2"]; }
            set { this["MEDULAUSAGEDOSE2"] = value; }
        }

    /// <summary>
    /// Kullanım Periyot Birimi
    /// </summary>
        public PeriodUnitTypeEnum? PeriodUnitType
        {
            get { return (PeriodUnitTypeEnum?)(int?)this["PERIODUNITTYPE"]; }
            set { this["PERIODUNITTYPE"] = value; }
        }

    /// <summary>
    /// Kullanım Doz Birimi
    /// </summary>
        public UsageDoseUnitTypeEnum? UsageDoseUnitType
        {
            get { return (UsageDoseUnitTypeEnum?)(int?)this["USAGEDOSEUNITTYPE"]; }
            set { this["USAGEDOSEUNITTYPE"] = value; }
        }

        public PackageTemplateDefinition PackageTemplateDefinition
        {
            get { return (PackageTemplateDefinition)((ITTObject)this).GetParent("PACKAGETEMPLATEDEFINITION"); }
            set { this["PACKAGETEMPLATEDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public EtkinMadde EtkinMadde
        {
            get { return (EtkinMadde)((ITTObject)this).GetParent("ETKINMADDE"); }
            set { this["ETKINMADDE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PackageTemplateEtkinMadDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PackageTemplateEtkinMadDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PackageTemplateEtkinMadDef(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PackageTemplateEtkinMadDef(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PackageTemplateEtkinMadDef(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PACKAGETEMPLATEETKINMADDEF", dataRow) { }
        protected PackageTemplateEtkinMadDef(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PACKAGETEMPLATEETKINMADDEF", dataRow, isImported) { }
        public PackageTemplateEtkinMadDef(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PackageTemplateEtkinMadDef(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PackageTemplateEtkinMadDef() : base() { }

    }
}