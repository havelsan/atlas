
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ARD_VaccineOut")] 

    public  partial class ARD_VaccineOut : AnnualRequirementDetailOutOfList
    {
        public class ARD_VaccineOutList : TTObjectCollection<ARD_VaccineOut> { }
                    
        public class ChildARD_VaccineOutCollection : TTObject.TTChildObjectCollection<ARD_VaccineOut>
        {
            public ChildARD_VaccineOutCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildARD_VaccineOutCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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

        protected ARD_VaccineOut(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ARD_VaccineOut(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ARD_VaccineOut(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ARD_VaccineOut(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ARD_VaccineOut(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ARD_VACCINEOUT", dataRow) { }
        protected ARD_VaccineOut(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ARD_VACCINEOUT", dataRow, isImported) { }
        public ARD_VaccineOut(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ARD_VaccineOut(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ARD_VaccineOut() : base() { }

    }
}