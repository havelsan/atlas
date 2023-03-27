
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MaddeBagimliligiVeriSeti")] 

    /// <summary>
    /// Madde Bağımlılığı Bildirim Veri Seti
    /// </summary>
    public  partial class MaddeBagimliligiVeriSeti : ENabiz
    {
        public class MaddeBagimliligiVeriSetiList : TTObjectCollection<MaddeBagimliligiVeriSeti> { }
                    
        public class ChildMaddeBagimliligiVeriSetiCollection : TTObject.TTChildObjectCollection<MaddeBagimliligiVeriSeti>
        {
            public ChildMaddeBagimliligiVeriSetiCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMaddeBagimliligiVeriSetiCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Enjeksiyon ile İlk Madde Kullanım Yaşı
    /// </summary>
        public int? EnjeksiyonIleIlkMaddeKulYas
        {
            get { return (int?)this["ENJEKSIYONILEILKMADDEKULYAS"]; }
            set { this["ENJEKSIYONILEILKMADDEKULYAS"] = value; }
        }

        public string HastaKodu
        {
            get { return (string)this["HASTAKODU"]; }
            set { this["HASTAKODU"] = value; }
        }

        public int? SigaraAdedi
        {
            get { return (int?)this["SIGARAADEDI"]; }
            set { this["SIGARAADEDI"] = value; }
        }

        public SKRSAlkolKullanimi SKRSAlkolKullanimi
        {
            get { return (SKRSAlkolKullanimi)((ITTObject)this).GetParent("SKRSALKOLKULLANIMI"); }
            set { this["SKRSALKOLKULLANIMI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSEnjektorPaylasimDurumu SKRSEnjektorPaylasimDurumu
        {
            get { return (SKRSEnjektorPaylasimDurumu)((ITTObject)this).GetParent("SKRSENJEKTORPAYLASIMDURUMU"); }
            set { this["SKRSENJEKTORPAYLASIMDURUMU"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSGonderenBirim SKRSGonderenBirim
        {
            get { return (SKRSGonderenBirim)((ITTObject)this).GetParent("SKRSGONDERENBIRIM"); }
            set { this["SKRSGONDERENBIRIM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSIsDurumu SKRSIsDurumu
        {
            get { return (SKRSIsDurumu)((ITTObject)this).GetParent("SKRSISDURUMU"); }
            set { this["SKRSISDURUMU"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Veri Seti - Kullanılan Esas Madde
    /// </summary>
        public SKRSKullanilanMadde SKRSKullanilanMadde
        {
            get { return (SKRSKullanilanMadde)((ITTObject)this).GetParent("SKRSKULLANILANMADDE"); }
            set { this["SKRSKULLANILANMADDE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSOgrenimDurumu SKRSOgrenimDurumu
        {
            get { return (SKRSOgrenimDurumu)((ITTObject)this).GetParent("SKRSOGRENIMDURUMU"); }
            set { this["SKRSOGRENIMDURUMU"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSSigaraKullanimi SKRSSigaraKullanimi
        {
            get { return (SKRSSigaraKullanimi)((ITTObject)this).GetParent("SKRSSIGARAKULLANIMI"); }
            set { this["SKRSSIGARAKULLANIMI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSTedaviMerkeziTipi SKRSTedaviMerkeziTipi
        {
            get { return (SKRSTedaviMerkeziTipi)((ITTObject)this).GetParent("SKRSTEDAVIMERKEZITIPI"); }
            set { this["SKRSTEDAVIMERKEZITIPI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSTedaviSonucuMaddeBagimliligi SKRSTedaviSonucuMaddeBagim
        {
            get { return (SKRSTedaviSonucuMaddeBagimliligi)((ITTObject)this).GetParent("SKRSTEDAVISONUCUMADDEBAGIM"); }
            set { this["SKRSTEDAVISONUCUMADDEBAGIM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSUygulananTedaviTuruMaddeBagimliligi SKRSUygulananTedaviMaddeBagim
        {
            get { return (SKRSUygulananTedaviTuruMaddeBagimliligi)((ITTObject)this).GetParent("SKRSUYGULANANTEDAVIMADDEBAGIM"); }
            set { this["SKRSUYGULANANTEDAVIMADDEBAGIM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSYasadigiBolge SKRSYasadigiBolge
        {
            get { return (SKRSYasadigiBolge)((ITTObject)this).GetParent("SKRSYASADIGIBOLGE"); }
            set { this["SKRSYASADIGIBOLGE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Yaşamında Enjeksiyon Yolu ile Madde Kullanım Durumu
    /// </summary>
        public SKRSYasamindaEnjeksiyonYoluileMaddeKullanimDurumu SKRSEnjeksiyonMaddeKullanimi
        {
            get { return (SKRSYasamindaEnjeksiyonYoluileMaddeKullanimDurumu)((ITTObject)this).GetParent("SKRSENJEKSIYONMADDEKULLANIMI"); }
            set { this["SKRSENJEKSIYONMADDEKULLANIMI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSYasamBicimi SKRSYasamBicimi
        {
            get { return (SKRSYasamBicimi)((ITTObject)this).GetParent("SKRSYASAMBICIMI"); }
            set { this["SKRSYASAMBICIMI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateMaddeBagimBulasiciHastalikCollection()
        {
            _MaddeBagimBulasiciHastalik = new MaddeBagimBulasiciHastalik.ChildMaddeBagimBulasiciHastalikCollection(this, new Guid("2c4a4422-5330-476b-baef-36f9e8c8e486"));
            ((ITTChildObjectCollection)_MaddeBagimBulasiciHastalik).GetChildren();
        }

        protected MaddeBagimBulasiciHastalik.ChildMaddeBagimBulasiciHastalikCollection _MaddeBagimBulasiciHastalik = null;
        public MaddeBagimBulasiciHastalik.ChildMaddeBagimBulasiciHastalikCollection MaddeBagimBulasiciHastalik
        {
            get
            {
                if (_MaddeBagimBulasiciHastalik == null)
                    CreateMaddeBagimBulasiciHastalikCollection();
                return _MaddeBagimBulasiciHastalik;
            }
        }

        virtual protected void CreateMaddeBagimliligiKulMaddeCollection()
        {
            _MaddeBagimliligiKulMadde = new MaddeBagimliligiKulMadde.ChildMaddeBagimliligiKulMaddeCollection(this, new Guid("d568d290-1972-4101-be50-c433d6de22d1"));
            ((ITTChildObjectCollection)_MaddeBagimliligiKulMadde).GetChildren();
        }

        protected MaddeBagimliligiKulMadde.ChildMaddeBagimliligiKulMaddeCollection _MaddeBagimliligiKulMadde = null;
        public MaddeBagimliligiKulMadde.ChildMaddeBagimliligiKulMaddeCollection MaddeBagimliligiKulMadde
        {
            get
            {
                if (_MaddeBagimliligiKulMadde == null)
                    CreateMaddeBagimliligiKulMaddeCollection();
                return _MaddeBagimliligiKulMadde;
            }
        }

        protected MaddeBagimliligiVeriSeti(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MaddeBagimliligiVeriSeti(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MaddeBagimliligiVeriSeti(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MaddeBagimliligiVeriSeti(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MaddeBagimliligiVeriSeti(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MADDEBAGIMLILIGIVERISETI", dataRow) { }
        protected MaddeBagimliligiVeriSeti(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MADDEBAGIMLILIGIVERISETI", dataRow, isImported) { }
        public MaddeBagimliligiVeriSeti(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MaddeBagimliligiVeriSeti(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MaddeBagimliligiVeriSeti() : base() { }

    }
}