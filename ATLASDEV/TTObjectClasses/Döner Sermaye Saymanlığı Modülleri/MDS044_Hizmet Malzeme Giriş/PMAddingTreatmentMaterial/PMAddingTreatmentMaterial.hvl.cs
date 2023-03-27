
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PMAddingTreatmentMaterial")] 

    public  partial class PMAddingTreatmentMaterial : BaseTreatmentMaterial
    {
        public class PMAddingTreatmentMaterialList : TTObjectCollection<PMAddingTreatmentMaterial> { }
                    
        public class ChildPMAddingTreatmentMaterialCollection : TTObject.TTChildObjectCollection<PMAddingTreatmentMaterial>
        {
            public ChildPMAddingTreatmentMaterialCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPMAddingTreatmentMaterialCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("992adf01-83e6-4cfd-8b2d-b4e5ec7c6ce9"); } }
    /// <summary>
    /// Tamam
    /// </summary>
            public static Guid Completed { get { return new Guid("5b5b0e4f-bc4f-46dc-b5c8-6b64c3add14c"); } }
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("ca1c1c02-0674-47ad-ae79-e1bb1503065d"); } }
        }

    /// <summary>
    /// Hasta Fiyatı
    /// </summary>
        public Currency? PatientPrice
        {
            get { return (Currency?)this["PATIENTPRICE"]; }
            set { this["PATIENTPRICE"] = value; }
        }

    /// <summary>
    /// Kurum Fiyatı
    /// </summary>
        public Currency? PayerPrice
        {
            get { return (Currency?)this["PAYERPRICE"]; }
            set { this["PAYERPRICE"] = value; }
        }

        protected PMAddingTreatmentMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PMAddingTreatmentMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PMAddingTreatmentMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PMAddingTreatmentMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PMAddingTreatmentMaterial(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PMADDINGTREATMENTMATERIAL", dataRow) { }
        protected PMAddingTreatmentMaterial(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PMADDINGTREATMENTMATERIAL", dataRow, isImported) { }
        public PMAddingTreatmentMaterial(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PMAddingTreatmentMaterial(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PMAddingTreatmentMaterial() : base() { }

    }
}