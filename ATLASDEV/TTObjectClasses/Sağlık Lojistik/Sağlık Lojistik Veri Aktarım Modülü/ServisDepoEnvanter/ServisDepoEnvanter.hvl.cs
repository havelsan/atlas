
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ServisDepoEnvanter")] 

    /// <summary>
    /// ServisDepoEnvanter
    /// </summary>
    public  partial class ServisDepoEnvanter : TTObject
    {
        public class ServisDepoEnvanterList : TTObjectCollection<ServisDepoEnvanter> { }
                    
        public class ChildServisDepoEnvanterCollection : TTObject.TTChildObjectCollection<ServisDepoEnvanter>
        {
            public ChildServisDepoEnvanterCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildServisDepoEnvanterCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// DepoTip
    /// </summary>
        public string DepoTip
        {
            get { return (string)this["DEPOTIP"]; }
            set { this["DEPOTIP"] = value; }
        }

    /// <summary>
    /// StokID
    /// </summary>
        public int? StokID
        {
            get { return (int?)this["STOKID"]; }
            set { this["STOKID"] = value; }
        }

    /// <summary>
    /// BarkodNO
    /// </summary>
        public int? BarkodNO
        {
            get { return (int?)this["BARKODNO"]; }
            set { this["BARKODNO"] = value; }
        }

    /// <summary>
    /// MalzemeAdi
    /// </summary>
        public string MalzemeAdi
        {
            get { return (string)this["MALZEMEADI"]; }
            set { this["MALZEMEADI"] = value; }
        }

    /// <summary>
    /// TasinirKOD
    /// </summary>
        public string TasinirKOD
        {
            get { return (string)this["TASINIRKOD"]; }
            set { this["TASINIRKOD"] = value; }
        }

    /// <summary>
    /// MalzemeTurID
    /// </summary>
        public int? MalzemeTurID
        {
            get { return (int?)this["MALZEMETURID"]; }
            set { this["MALZEMETURID"] = value; }
        }

    /// <summary>
    /// DepoID
    /// </summary>
        public int? DepoID
        {
            get { return (int?)this["DEPOID"]; }
            set { this["DEPOID"] = value; }
        }

    /// <summary>
    /// DepoAdi
    /// </summary>
        public string DepoAdi
        {
            get { return (string)this["DEPOADI"]; }
            set { this["DEPOADI"] = value; }
        }

    /// <summary>
    /// Giren
    /// </summary>
        public double? Giren
        {
            get { return (double?)this["GIREN"]; }
            set { this["GIREN"] = value; }
        }

    /// <summary>
    /// Cikan
    /// </summary>
        public double? Cikan
        {
            get { return (double?)this["CIKAN"]; }
            set { this["CIKAN"] = value; }
        }

    /// <summary>
    /// Kalan
    /// </summary>
        public double? Kalan
        {
            get { return (double?)this["KALAN"]; }
            set { this["KALAN"] = value; }
        }

    /// <summary>
    /// ButceTipi
    /// </summary>
        public string ButceTipi
        {
            get { return (string)this["BUTCETIPI"]; }
            set { this["BUTCETIPI"] = value; }
        }

    /// <summary>
    /// Fiyat
    /// </summary>
        public BigCurrency? Fiyat
        {
            get { return (BigCurrency?)this["FIYAT"]; }
            set { this["FIYAT"] = value; }
        }

    /// <summary>
    /// MkysStokHareketID
    /// </summary>
        public int? MkysStokHareketID
        {
            get { return (int?)this["MKYSSTOKHAREKETID"]; }
            set { this["MKYSSTOKHAREKETID"] = value; }
        }

    /// <summary>
    /// SonKullTarihi
    /// </summary>
        public DateTime? SonKullTarihi
        {
            get { return (DateTime?)this["SONKULLTARIHI"]; }
            set { this["SONKULLTARIHI"] = value; }
        }

    /// <summary>
    /// Malzeme
    /// </summary>
        public Material Material
        {
            get { return (Material)((ITTObject)this).GetParent("MATERIAL"); }
            set { this["MATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Depo
    /// </summary>
        public Store Store
        {
            get { return (Store)((ITTObject)this).GetParent("STORE"); }
            set { this["STORE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ServisDepoEnvanter(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ServisDepoEnvanter(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ServisDepoEnvanter(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ServisDepoEnvanter(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ServisDepoEnvanter(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SERVISDEPOENVANTER", dataRow) { }
        protected ServisDepoEnvanter(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SERVISDEPOENVANTER", dataRow, isImported) { }
        public ServisDepoEnvanter(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ServisDepoEnvanter(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ServisDepoEnvanter() : base() { }

    }
}