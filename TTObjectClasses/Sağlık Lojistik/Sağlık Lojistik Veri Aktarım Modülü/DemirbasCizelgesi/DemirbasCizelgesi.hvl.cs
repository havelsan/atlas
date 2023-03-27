
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DemirbasCizelgesi")] 

    public  partial class DemirbasCizelgesi : TTObject
    {
        public class DemirbasCizelgesiList : TTObjectCollection<DemirbasCizelgesi> { }
                    
        public class ChildDemirbasCizelgesiCollection : TTObject.TTChildObjectCollection<DemirbasCizelgesi>
        {
            public ChildDemirbasCizelgesiCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDemirbasCizelgesiCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public string MalzemeNu
        {
            get { return (string)this["MALZEMENU"]; }
            set { this["MALZEMENU"] = value; }
        }

        public Guid? ResourceObjectID
        {
            get { return (Guid?)this["RESOURCEOBJECTID"]; }
            set { this["RESOURCEOBJECTID"] = value; }
        }

        public Guid? StoreObjectID
        {
            get { return (Guid?)this["STOREOBJECTID"]; }
            set { this["STOREOBJECTID"] = value; }
        }

    /// <summary>
    /// Demirbaş Nu.
    /// </summary>
        public string FixedAssetNO
        {
            get { return (string)this["FIXEDASSETNO"]; }
            set { this["FIXEDASSETNO"] = value; }
        }

        public string DemirbasAdi
        {
            get { return (string)this["DEMIRBASADI"]; }
            set { this["DEMIRBASADI"] = value; }
        }

        public string Depo
        {
            get { return (string)this["DEPO"]; }
            set { this["DEPO"] = value; }
        }

        public string Frekans
        {
            get { return (string)this["FREKANS"]; }
            set { this["FREKANS"] = value; }
        }

        public string GarantiAciklamasi
        {
            get { return (string)this["GARANTIACIKLAMASI"]; }
            set { this["GARANTIACIKLAMASI"] = value; }
        }

        public DateTime? GarantiBaslangicTarihi
        {
            get { return (DateTime?)this["GARANTIBASLANGICTARIHI"]; }
            set { this["GARANTIBASLANGICTARIHI"] = value; }
        }

        public DateTime? GarantiBitisTarihi
        {
            get { return (DateTime?)this["GARANTIBITISTARIHI"]; }
            set { this["GARANTIBITISTARIHI"] = value; }
        }

        public string Guc
        {
            get { return (string)this["GUC"]; }
            set { this["GUC"] = value; }
        }

        public DateTime? ImalTarihi
        {
            get { return (DateTime?)this["IMALTARIHI"]; }
            set { this["IMALTARIHI"] = value; }
        }

        public string Marka
        {
            get { return (string)this["MARKA"]; }
            set { this["MARKA"] = value; }
        }

        public string Model
        {
            get { return (string)this["MODEL"]; }
            set { this["MODEL"] = value; }
        }

        public string NATOStokNu
        {
            get { return (string)this["NATOSTOKNU"]; }
            set { this["NATOSTOKNU"] = value; }
        }

        public string SeriNumarasi
        {
            get { return (string)this["SERINUMARASI"]; }
            set { this["SERINUMARASI"] = value; }
        }

        public int? SiraNu
        {
            get { return (int?)this["SIRANU"]; }
            set { this["SIRANU"] = value; }
        }

        public DateTime? SonBakimTarihi
        {
            get { return (DateTime?)this["SONBAKIMTARIHI"]; }
            set { this["SONBAKIMTARIHI"] = value; }
        }

        public DateTime? SonKalibrasyonTarihi
        {
            get { return (DateTime?)this["SONKALIBRASYONTARIHI"]; }
            set { this["SONKALIBRASYONTARIHI"] = value; }
        }

        public string Voltaj
        {
            get { return (string)this["VOLTAJ"]; }
            set { this["VOLTAJ"] = value; }
        }

        public bool? SeriNumarali
        {
            get { return (bool?)this["SERINUMARALI"]; }
            set { this["SERINUMARALI"] = value; }
        }

        public SayimTartiCizelgesi SayimTartiCizelgesi
        {
            get { return (SayimTartiCizelgesi)((ITTObject)this).GetParent("SAYIMTARTICIZELGESI"); }
            set { this["SAYIMTARTICIZELGESI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DemirbasCizelgesi(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DemirbasCizelgesi(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DemirbasCizelgesi(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DemirbasCizelgesi(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DemirbasCizelgesi(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DEMIRBASCIZELGESI", dataRow) { }
        protected DemirbasCizelgesi(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DEMIRBASCIZELGESI", dataRow, isImported) { }
        public DemirbasCizelgesi(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DemirbasCizelgesi(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DemirbasCizelgesi() : base() { }

    }
}