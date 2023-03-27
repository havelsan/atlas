
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="EvdeSaglikIlkIzlemVeriSeti")] 

    /// <summary>
    /// Evde Sağlık İlk İzlem Veri Seti
    /// </summary>
    public  partial class EvdeSaglikIlkIzlemVeriSeti : ENabiz
    {
        public class EvdeSaglikIlkIzlemVeriSetiList : TTObjectCollection<EvdeSaglikIlkIzlemVeriSeti> { }
                    
        public class ChildEvdeSaglikIlkIzlemVeriSetiCollection : TTObject.TTChildObjectCollection<EvdeSaglikIlkIzlemVeriSeti>
        {
            public ChildEvdeSaglikIlkIzlemVeriSetiCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildEvdeSaglikIlkIzlemVeriSetiCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public SKRSAgri SKRSAgri
        {
            get { return (SKRSAgri)((ITTObject)this).GetParent("SKRSAGRI"); }
            set { this["SKRSAGRI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSAydinlatma SKRSAydinlatma
        {
            get { return (SKRSAydinlatma)((ITTObject)this).GetParent("SKRSAYDINLATMA"); }
            set { this["SKRSAYDINLATMA"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSBakimveDestekIhtiyaci SKRSBakimveDestekIhtiyaci
        {
            get { return (SKRSBakimveDestekIhtiyaci)((ITTObject)this).GetParent("SKRSBAKIMVEDESTEKIHTIYACI"); }
            set { this["SKRSBAKIMVEDESTEKIHTIYACI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSBasiDegerlendirmesi SKRSBasiDegerlendirmesi
        {
            get { return (SKRSBasiDegerlendirmesi)((ITTObject)this).GetParent("SKRSBASIDEGERLENDIRMESI"); }
            set { this["SKRSBASIDEGERLENDIRMESI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSBasvuruTuru SKRSBasvuruTuru
        {
            get { return (SKRSBasvuruTuru)((ITTObject)this).GetParent("SKRSBASVURUTURU"); }
            set { this["SKRSBASVURUTURU"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSBeslenme SKRSBeslenme
        {
            get { return (SKRSBeslenme)((ITTObject)this).GetParent("SKRSBESLENME"); }
            set { this["SKRSBESLENME"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSBirSonrakiHizmetIhtiyaci SKRSBirSonrakiHizmetIhtiyaci
        {
            get { return (SKRSBirSonrakiHizmetIhtiyaci)((ITTObject)this).GetParent("SKRSBIRSONRAKIHIZMETIHTIYACI"); }
            set { this["SKRSBIRSONRAKIHIZMETIHTIYACI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSICD SKRSICD
        {
            get { return (SKRSICD)((ITTObject)this).GetParent("SKRSICD"); }
            set { this["SKRSICD"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSEvHijyeni SKRSEvHijyeni
        {
            get { return (SKRSEvHijyeni)((ITTObject)this).GetParent("SKRSEVHIJYENI"); }
            set { this["SKRSEVHIJYENI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSGuvenlik SKRSGuvenlik
        {
            get { return (SKRSGuvenlik)((ITTObject)this).GetParent("SKRSGUVENLIK"); }
            set { this["SKRSGUVENLIK"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSIsinma SKRSIsinma
        {
            get { return (SKRSIsinma)((ITTObject)this).GetParent("SKRSISINMA"); }
            set { this["SKRSISINMA"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSKisiselBakim SKRSKisiselBakim
        {
            get { return (SKRSKisiselBakim)((ITTObject)this).GetParent("SKRSKISISELBAKIM"); }
            set { this["SKRSKISISELBAKIM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSKisiselHijyen SKRSKisiselHijyen
        {
            get { return (SKRSKisiselHijyen)((ITTObject)this).GetParent("SKRSKISISELHIJYEN"); }
            set { this["SKRSKISISELHIJYEN"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSKonutTipi SKRSKonutTipi
        {
            get { return (SKRSKonutTipi)((ITTObject)this).GetParent("SKRSKONUTTIPI"); }
            set { this["SKRSKONUTTIPI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSKullanilanHelaTipi SKRSKullanilanHelaTipi
        {
            get { return (SKRSKullanilanHelaTipi)((ITTObject)this).GetParent("SKRSKULLANILANHELATIPI"); }
            set { this["SKRSKULLANILANHELATIPI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSYatagaBagimlilik SKRSYatagaBagimlilik
        {
            get { return (SKRSYatagaBagimlilik)((ITTObject)this).GetParent("SKRSYATAGABAGIMLILIK"); }
            set { this["SKRSYATAGABAGIMLILIK"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateKullandigiYardimciAraclarCollection()
        {
            _KullandigiYardimciAraclar = new KullandigiYardimciAraclar.ChildKullandigiYardimciAraclarCollection(this, new Guid("60a9a404-18a8-49c7-9670-a5dfbeeecb88"));
            ((ITTChildObjectCollection)_KullandigiYardimciAraclar).GetChildren();
        }

        protected KullandigiYardimciAraclar.ChildKullandigiYardimciAraclarCollection _KullandigiYardimciAraclar = null;
        public KullandigiYardimciAraclar.ChildKullandigiYardimciAraclarCollection KullandigiYardimciAraclar
        {
            get
            {
                if (_KullandigiYardimciAraclar == null)
                    CreateKullandigiYardimciAraclarCollection();
                return _KullandigiYardimciAraclar;
            }
        }

        virtual protected void CreatePsikolojikDurumCollection()
        {
            _PsikolojikDurum = new PsikolojikDurum.ChildPsikolojikDurumCollection(this, new Guid("9b377665-def5-4c68-9864-dbb8a2626814"));
            ((ITTChildObjectCollection)_PsikolojikDurum).GetChildren();
        }

        protected PsikolojikDurum.ChildPsikolojikDurumCollection _PsikolojikDurum = null;
        public PsikolojikDurum.ChildPsikolojikDurumCollection PsikolojikDurum
        {
            get
            {
                if (_PsikolojikDurum == null)
                    CreatePsikolojikDurumCollection();
                return _PsikolojikDurum;
            }
        }

        virtual protected void CreateVerilenEgitimlerCollection()
        {
            _VerilenEgitimler = new VerilenEgitimler.ChildVerilenEgitimlerCollection(this, new Guid("90cf37a8-d3d6-4fe0-afec-15da7d2a0673"));
            ((ITTChildObjectCollection)_VerilenEgitimler).GetChildren();
        }

        protected VerilenEgitimler.ChildVerilenEgitimlerCollection _VerilenEgitimler = null;
        public VerilenEgitimler.ChildVerilenEgitimlerCollection VerilenEgitimler
        {
            get
            {
                if (_VerilenEgitimler == null)
                    CreateVerilenEgitimlerCollection();
                return _VerilenEgitimler;
            }
        }

        protected EvdeSaglikIlkIzlemVeriSeti(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected EvdeSaglikIlkIzlemVeriSeti(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected EvdeSaglikIlkIzlemVeriSeti(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected EvdeSaglikIlkIzlemVeriSeti(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected EvdeSaglikIlkIzlemVeriSeti(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EVDESAGLIKILKIZLEMVERISETI", dataRow) { }
        protected EvdeSaglikIlkIzlemVeriSeti(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EVDESAGLIKILKIZLEMVERISETI", dataRow, isImported) { }
        public EvdeSaglikIlkIzlemVeriSeti(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public EvdeSaglikIlkIzlemVeriSeti(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public EvdeSaglikIlkIzlemVeriSeti() : base() { }

    }
}