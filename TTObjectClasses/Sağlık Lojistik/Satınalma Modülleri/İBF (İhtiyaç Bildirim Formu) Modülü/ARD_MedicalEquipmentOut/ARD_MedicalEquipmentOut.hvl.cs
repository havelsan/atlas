
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ARD_MedicalEquipmentOut")] 

    public  partial class ARD_MedicalEquipmentOut : AnnualRequirementDetailOutOfList
    {
        public class ARD_MedicalEquipmentOutList : TTObjectCollection<ARD_MedicalEquipmentOut> { }
                    
        public class ChildARD_MedicalEquipmentOutCollection : TTObject.TTChildObjectCollection<ARD_MedicalEquipmentOut>
        {
            public ChildARD_MedicalEquipmentOutCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildARD_MedicalEquipmentOutCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("d9fc1811-1f02-4d91-905e-96cb589bd920"); } }
            public static Guid New { get { return new Guid("b598888e-7eef-48fb-9f95-495cae2a77ca"); } }
    /// <summary>
    /// Tamam
    /// </summary>
            public static Guid Completed { get { return new Guid("81b0c9a7-849c-4b52-b4b8-acd19a2615c8"); } }
        }

    /// <summary>
    /// Yedek Parça
    /// </summary>
        public string DependentSpare
        {
            get { return (string)this["DEPENDENTSPARE"]; }
            set { this["DEPENDENTSPARE"] = value; }
        }

    /// <summary>
    /// Tedarik Amacı
    /// </summary>
        public string Purpose
        {
            get { return (string)this["PURPOSE"]; }
            set { this["PURPOSE"] = value; }
        }

    /// <summary>
    /// xxx Yılı Sarf Miktarı
    /// </summary>
        public Currency? ConsumptionAmount1
        {
            get { return (Currency?)this["CONSUMPTIONAMOUNT1"]; }
            set { this["CONSUMPTIONAMOUNT1"] = value; }
        }

    /// <summary>
    /// xxx Yılı Sarf Miktarı
    /// </summary>
        public Currency? ConsumptionAmount2
        {
            get { return (Currency?)this["CONSUMPTIONAMOUNT2"]; }
            set { this["CONSUMPTIONAMOUNT2"] = value; }
        }

    /// <summary>
    /// xxx Yılı Sonu Depo Mevcudu
    /// </summary>
        public Currency? StoreStock
        {
            get { return (Currency?)this["STORESTOCK"]; }
            set { this["STORESTOCK"] = value; }
        }

        protected ARD_MedicalEquipmentOut(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ARD_MedicalEquipmentOut(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ARD_MedicalEquipmentOut(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ARD_MedicalEquipmentOut(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ARD_MedicalEquipmentOut(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ARD_MEDICALEQUIPMENTOUT", dataRow) { }
        protected ARD_MedicalEquipmentOut(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ARD_MEDICALEQUIPMENTOUT", dataRow, isImported) { }
        public ARD_MedicalEquipmentOut(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ARD_MedicalEquipmentOut(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ARD_MedicalEquipmentOut() : base() { }

    }
}