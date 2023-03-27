
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BulasiciHastalikVeriSeti")] 

    public  partial class BulasiciHastalikVeriSeti : ENabiz
    {
        public class BulasiciHastalikVeriSetiList : TTObjectCollection<BulasiciHastalikVeriSeti> { }
                    
        public class ChildBulasiciHastalikVeriSetiCollection : TTObject.TTChildObjectCollection<BulasiciHastalikVeriSeti>
        {
            public ChildBulasiciHastalikVeriSetiCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBulasiciHastalikVeriSetiCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public DeathAliveEnum? VakaDurum
        {
            get { return (DeathAliveEnum?)(int?)this["VAKADURUM"]; }
            set { this["VAKADURUM"] = value; }
        }

    /// <summary>
    /// Pakete Ait İşlem Zamanı
    /// </summary>
        public DateTime? PaketeAitIslemZamani
        {
            get { return (DateTime?)this["PAKETEAITISLEMZAMANI"]; }
            set { this["PAKETEAITISLEMZAMANI"] = value; }
        }

    /// <summary>
    /// Belirtilerin Başlama Tarihi
    /// </summary>
        public DateTime? BelirtilerinBaslamaTarihi
        {
            get { return (DateTime?)this["BELIRTILERINBASLAMATARIHI"]; }
            set { this["BELIRTILERINBASLAMATARIHI"] = value; }
        }

    /// <summary>
    /// Dış Kapı No
    /// </summary>
        public string DisKapiNoIkamet
        {
            get { return (string)this["DISKAPINOIKAMET"]; }
            set { this["DISKAPINOIKAMET"] = value; }
        }

    /// <summary>
    /// İç Kapı No
    /// </summary>
        public string IcKapiNoIkamet
        {
            get { return (string)this["ICKAPINOIKAMET"]; }
            set { this["ICKAPINOIKAMET"] = value; }
        }

    /// <summary>
    /// Dış Kapı No
    /// </summary>
        public string DisKapiNoBeyan
        {
            get { return (string)this["DISKAPINOBEYAN"]; }
            set { this["DISKAPINOBEYAN"] = value; }
        }

    /// <summary>
    /// İç Kapı No
    /// </summary>
        public string IcKapiNoBeyan
        {
            get { return (string)this["ICKAPINOBEYAN"]; }
            set { this["ICKAPINOBEYAN"] = value; }
        }

        public SKRSBucakKodlari Ikamet_Bucak
        {
            get { return (SKRSBucakKodlari)((ITTObject)this).GetParent("IKAMET_BUCAK"); }
            set { this["IKAMET_BUCAK"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSBucakKodlari Beyan_Bucak
        {
            get { return (SKRSBucakKodlari)((ITTObject)this).GetParent("BEYAN_BUCAK"); }
            set { this["BEYAN_BUCAK"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSKoyKodlari Ikamet_Koy
        {
            get { return (SKRSKoyKodlari)((ITTObject)this).GetParent("IKAMET_KOY"); }
            set { this["IKAMET_KOY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSKoyKodlari Beyan_Koy
        {
            get { return (SKRSKoyKodlari)((ITTObject)this).GetParent("BEYAN_KOY"); }
            set { this["BEYAN_KOY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSMahalleKodlari Ikamet_Mahalle
        {
            get { return (SKRSMahalleKodlari)((ITTObject)this).GetParent("IKAMET_MAHALLE"); }
            set { this["IKAMET_MAHALLE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSMahalleKodlari Beyan_Mahalle
        {
            get { return (SKRSMahalleKodlari)((ITTObject)this).GetParent("BEYAN_MAHALLE"); }
            set { this["BEYAN_MAHALLE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSCSBMTipi Ikamet_CSBM
        {
            get { return (SKRSCSBMTipi)((ITTObject)this).GetParent("IKAMET_CSBM"); }
            set { this["IKAMET_CSBM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSCSBMTipi Beyan_CSBM
        {
            get { return (SKRSCSBMTipi)((ITTObject)this).GetParent("BEYAN_CSBM"); }
            set { this["BEYAN_CSBM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSILKodlari Ikamet_Il
        {
            get { return (SKRSILKodlari)((ITTObject)this).GetParent("IKAMET_IL"); }
            set { this["IKAMET_IL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSILKodlari Beyan_Il
        {
            get { return (SKRSILKodlari)((ITTObject)this).GetParent("BEYAN_IL"); }
            set { this["BEYAN_IL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSIlceKodlari Ikamet_Ilce
        {
            get { return (SKRSIlceKodlari)((ITTObject)this).GetParent("IKAMET_ILCE"); }
            set { this["IKAMET_ILCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSIlceKodlari Beyan_Ilce
        {
            get { return (SKRSIlceKodlari)((ITTObject)this).GetParent("BEYAN_ILCE"); }
            set { this["BEYAN_ILCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSVakaTipi SKRSVakaTipi
        {
            get { return (SKRSVakaTipi)((ITTObject)this).GetParent("SKRSVAKATIPI"); }
            set { this["SKRSVAKATIPI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSICD SKRSICD
        {
            get { return (SKRSICD)((ITTObject)this).GetParent("SKRSICD"); }
            set { this["SKRSICD"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResUser ResponsibleDoctor
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESPONSIBLEDOCTOR"); }
            set { this["RESPONSIBLEDOCTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateBulasiciHastaliklarEACollection()
        {
            _BulasiciHastaliklarEA = new BulasiciHastaliklarEA.ChildBulasiciHastaliklarEACollection(this, new Guid("4bea6661-7680-44f6-8bad-d3f22076e46e"));
            ((ITTChildObjectCollection)_BulasiciHastaliklarEA).GetChildren();
        }

        protected BulasiciHastaliklarEA.ChildBulasiciHastaliklarEACollection _BulasiciHastaliklarEA = null;
        public BulasiciHastaliklarEA.ChildBulasiciHastaliklarEACollection BulasiciHastaliklarEA
        {
            get
            {
                if (_BulasiciHastaliklarEA == null)
                    CreateBulasiciHastaliklarEACollection();
                return _BulasiciHastaliklarEA;
            }
        }

        virtual protected void CreateBulasiciHastalikTelefonCollection()
        {
            _BulasiciHastalikTelefon = new BulasiciHastalikTelefon.ChildBulasiciHastalikTelefonCollection(this, new Guid("059a09c9-8a88-47a1-b797-7b09f7c72e38"));
            ((ITTChildObjectCollection)_BulasiciHastalikTelefon).GetChildren();
        }

        protected BulasiciHastalikTelefon.ChildBulasiciHastalikTelefonCollection _BulasiciHastalikTelefon = null;
        public BulasiciHastalikTelefon.ChildBulasiciHastalikTelefonCollection BulasiciHastalikTelefon
        {
            get
            {
                if (_BulasiciHastalikTelefon == null)
                    CreateBulasiciHastalikTelefonCollection();
                return _BulasiciHastalikTelefon;
            }
        }

        protected BulasiciHastalikVeriSeti(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BulasiciHastalikVeriSeti(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BulasiciHastalikVeriSeti(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BulasiciHastalikVeriSeti(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BulasiciHastalikVeriSeti(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BULASICIHASTALIKVERISETI", dataRow) { }
        protected BulasiciHastalikVeriSeti(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BULASICIHASTALIKVERISETI", dataRow, isImported) { }
        public BulasiciHastalikVeriSeti(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BulasiciHastalikVeriSeti(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BulasiciHastalikVeriSeti() : base() { }

    }
}