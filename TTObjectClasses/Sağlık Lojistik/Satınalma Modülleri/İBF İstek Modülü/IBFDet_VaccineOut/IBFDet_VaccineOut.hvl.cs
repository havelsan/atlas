
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="IBFDet_VaccineOut")] 

    /// <summary>
    /// İBF Detay kalemi - Aşılar için kullanılan sınıftır. (İBF listesi harici)
    /// </summary>
    public  partial class IBFDet_VaccineOut : IBFDetDetailOut
    {
        public class IBFDet_VaccineOutList : TTObjectCollection<IBFDet_VaccineOut> { }
                    
        public class ChildIBFDet_VaccineOutCollection : TTObject.TTChildObjectCollection<IBFDet_VaccineOut>
        {
            public ChildIBFDet_VaccineOutCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildIBFDet_VaccineOutCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("28662ca0-6fd6-4a8f-8cd9-3dc69151b79f"); } }
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("bae6c84c-c920-41b2-9136-221e13a8b558"); } }
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
    /// Tedarik Makamı
    /// </summary>
        public string SupportingPlace
        {
            get { return (string)this["SUPPORTINGPLACE"]; }
            set { this["SUPPORTINGPLACE"] = value; }
        }

    /// <summary>
    /// Dağıtım Yeri
    /// </summary>
        public string DistributingPlace
        {
            get { return (string)this["DISTRIBUTINGPLACE"]; }
            set { this["DISTRIBUTINGPLACE"] = value; }
        }

    /// <summary>
    /// Klinik / Bağlı Birlik
    /// </summary>
        public string Clinic
        {
            get { return (string)this["CLINIC"]; }
            set { this["CLINIC"] = value; }
        }

    /// <summary>
    /// Kaynak Türü
    /// </summary>
        public string ResourceType
        {
            get { return (string)this["RESOURCETYPE"]; }
            set { this["RESOURCETYPE"] = value; }
        }

        protected IBFDet_VaccineOut(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected IBFDet_VaccineOut(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected IBFDet_VaccineOut(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected IBFDet_VaccineOut(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected IBFDet_VaccineOut(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "IBFDET_VACCINEOUT", dataRow) { }
        protected IBFDet_VaccineOut(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "IBFDET_VACCINEOUT", dataRow, isImported) { }
        public IBFDet_VaccineOut(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public IBFDet_VaccineOut(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public IBFDet_VaccineOut() : base() { }

    }
}