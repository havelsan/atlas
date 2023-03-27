
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ehrAllergy")] 

    /// <summary>
    /// Alerji Bilgileri
    /// </summary>
    public  partial class ehrAllergy : BaseEhr
    {
        public class ehrAllergyList : TTObjectCollection<ehrAllergy> { }
                    
        public class ChildehrAllergyCollection : TTObject.TTChildObjectCollection<ehrAllergy>
        {
            public ChildehrAllergyCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildehrAllergyCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Active { get { return new Guid("b86c3e17-bf34-414c-b60c-182925abc911"); } }
            public static Guid Inactive { get { return new Guid("749387be-ff99-45ed-b18a-fb2b6a7a1190"); } }
        }

    /// <summary>
    /// Allerji
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Reaksiyon
    /// </summary>
        public string Reaction
        {
            get { return (string)this["REACTION"]; }
            set { this["REACTION"] = value; }
        }

        public RiskEnum? Risk
        {
            get { return (RiskEnum?)(int?)this["RISK"]; }
            set { this["RISK"] = value; }
        }

    /// <summary>
    /// Önemli Tıbbi Bilgiler-Allerji Bilgileri
    /// </summary>
        public ehrImportantMedicalInformation ehrImportantMedicalInfo
        {
            get { return (ehrImportantMedicalInformation)((ITTObject)this).GetParent("EHRIMPORTANTMEDICALINFO"); }
            set { this["EHRIMPORTANTMEDICALINFO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ehrAllergy(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ehrAllergy(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ehrAllergy(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ehrAllergy(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ehrAllergy(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EHRALLERGY", dataRow) { }
        protected ehrAllergy(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EHRALLERGY", dataRow, isImported) { }
        public ehrAllergy(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ehrAllergy(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ehrAllergy() : base() { }

    }
}