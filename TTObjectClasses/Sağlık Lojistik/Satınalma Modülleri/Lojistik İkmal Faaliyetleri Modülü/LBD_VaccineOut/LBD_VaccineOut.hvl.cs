
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="LBD_VaccineOut")] 

    /// <summary>
    /// Lojistik İkmal Faaliyetleri Detay kalemi - Aşılar için kullanılan sınıftır. (Lojistik İkmal Faaliyetleri listesi harici)
    /// </summary>
    public  partial class LBD_VaccineOut : LBPurchaseProjectDetailOutOfList
    {
        public class LBD_VaccineOutList : TTObjectCollection<LBD_VaccineOut> { }
                    
        public class ChildLBD_VaccineOutCollection : TTObject.TTChildObjectCollection<LBD_VaccineOut>
        {
            public ChildLBD_VaccineOutCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildLBD_VaccineOutCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
    /// <summary>
    /// Tamam
    /// </summary>
            public static Guid Completed { get { return new Guid("222ab4a0-5000-455c-9023-3630b0c02766"); } }
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("fcfa3d5d-5780-4b74-8f6e-7b3188e52e8a"); } }
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("cccf7119-49f4-4a37-9b44-de0b674ac4ff"); } }
        }

    /// <summary>
    /// Klinik/Bağlı Birlik
    /// </summary>
        public string Clinic
        {
            get { return (string)this["CLINIC"]; }
            set { this["CLINIC"] = value; }
        }

    /// <summary>
    /// Dağıtım Yeri
    /// </summary>
        public string DistributionPlace
        {
            get { return (string)this["DISTRIBUTIONPLACE"]; }
            set { this["DISTRIBUTIONPLACE"] = value; }
        }

    /// <summary>
    /// MKS
    /// </summary>
        public string MKS
        {
            get { return (string)this["MKS"]; }
            set { this["MKS"] = value; }
        }

    /// <summary>
    /// Kaynak Türü
    /// </summary>
        public string ResourceType
        {
            get { return (string)this["RESOURCETYPE"]; }
            set { this["RESOURCETYPE"] = value; }
        }

    /// <summary>
    /// Tedarik Makamı
    /// </summary>
        public string SupportingPlace
        {
            get { return (string)this["SUPPORTINGPLACE"]; }
            set { this["SUPPORTINGPLACE"] = value; }
        }

        protected LBD_VaccineOut(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected LBD_VaccineOut(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected LBD_VaccineOut(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected LBD_VaccineOut(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected LBD_VaccineOut(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "LBD_VACCINEOUT", dataRow) { }
        protected LBD_VaccineOut(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "LBD_VACCINEOUT", dataRow, isImported) { }
        public LBD_VaccineOut(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public LBD_VaccineOut(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public LBD_VaccineOut() : base() { }

    }
}