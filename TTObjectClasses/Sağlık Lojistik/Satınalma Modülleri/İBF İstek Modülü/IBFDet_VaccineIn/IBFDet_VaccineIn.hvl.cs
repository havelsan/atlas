
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="IBFDet_VaccineIn")] 

    /// <summary>
    /// İBF Detay kalemi - Aşılar için kullanılan sınıftır. (İBF listesi dahili)
    /// </summary>
    public  partial class IBFDet_VaccineIn : IBFDetDetailIn
    {
        public class IBFDet_VaccineInList : TTObjectCollection<IBFDet_VaccineIn> { }
                    
        public class ChildIBFDet_VaccineInCollection : TTObject.TTChildObjectCollection<IBFDet_VaccineIn>
        {
            public ChildIBFDet_VaccineInCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildIBFDet_VaccineInCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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

        protected IBFDet_VaccineIn(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected IBFDet_VaccineIn(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected IBFDet_VaccineIn(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected IBFDet_VaccineIn(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected IBFDet_VaccineIn(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "IBFDET_VACCINEIN", dataRow) { }
        protected IBFDet_VaccineIn(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "IBFDET_VACCINEIN", dataRow, isImported) { }
        public IBFDet_VaccineIn(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public IBFDet_VaccineIn(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public IBFDet_VaccineIn() : base() { }

    }
}