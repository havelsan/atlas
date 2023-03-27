
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PackageTemplateICDDetailDefinition")] 

    /// <summary>
    /// Paket Template İstem Tanı Tanımlama
    /// </summary>
    public  partial class PackageTemplateICDDetailDefinition : TTDefinitionSet
    {
        public class PackageTemplateICDDetailDefinitionList : TTObjectCollection<PackageTemplateICDDetailDefinition> { }
                    
        public class ChildPackageTemplateICDDetailDefinitionCollection : TTObject.TTChildObjectCollection<PackageTemplateICDDetailDefinition>
        {
            public ChildPackageTemplateICDDetailDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPackageTemplateICDDetailDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Tanı Açıklaması
    /// </summary>
        public string DiagnosisDefinition
        {
            get { return (string)this["DIAGNOSISDEFINITION"]; }
            set { this["DIAGNOSISDEFINITION"] = value; }
        }

    /// <summary>
    /// Serbest Tanı
    /// </summary>
        public string FreeDiagnosis
        {
            get { return (string)this["FREEDIAGNOSIS"]; }
            set { this["FREEDIAGNOSIS"] = value; }
        }

    /// <summary>
    /// Ana Tanı
    /// </summary>
        public bool? IsMainDiagnose
        {
            get { return (bool?)this["ISMAINDIAGNOSE"]; }
            set { this["ISMAINDIAGNOSE"] = value; }
        }

    /// <summary>
    /// Tanı Tipi
    /// </summary>
        public DiagnosisTypeEnum? DiagnosisType
        {
            get { return (DiagnosisTypeEnum?)(int?)this["DIAGNOSISTYPE"]; }
            set { this["DIAGNOSISTYPE"] = value; }
        }

    /// <summary>
    /// Tanının ICD10 kodu
    /// </summary>
        public string TaniKodu
        {
            get { return (string)this["TANIKODU"]; }
            set { this["TANIKODU"] = value; }
        }

    /// <summary>
    /// Tanı
    /// </summary>
        public DiagnosisDefinition Diagnose
        {
            get { return (DiagnosisDefinition)((ITTObject)this).GetParent("DIAGNOSE"); }
            set { this["DIAGNOSE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PackageTemplateDefinition PackageTemplateDefinition
        {
            get { return (PackageTemplateDefinition)((ITTObject)this).GetParent("PACKAGETEMPLATEDEFINITION"); }
            set { this["PACKAGETEMPLATEDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PackageTemplateICDDetailDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PackageTemplateICDDetailDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PackageTemplateICDDetailDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PackageTemplateICDDetailDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PackageTemplateICDDetailDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PACKAGETEMPLATEICDDETAILDEFINITION", dataRow) { }
        protected PackageTemplateICDDetailDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PACKAGETEMPLATEICDDETAILDEFINITION", dataRow, isImported) { }
        public PackageTemplateICDDetailDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PackageTemplateICDDetailDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PackageTemplateICDDetailDefinition() : base() { }

    }
}