
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="VeremVeriSeti")] 

    public  partial class VeremVeriSeti : ENabiz
    {
        public class VeremVeriSetiList : TTObjectCollection<VeremVeriSeti> { }
                    
        public class ChildVeremVeriSetiCollection : TTObject.TTChildObjectCollection<VeremVeriSeti>
        {
            public ChildVeremVeriSetiCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildVeremVeriSetiCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public string BcgSkarSayisi
        {
            get { return (string)this["BCGSKARSAYISI"]; }
            set { this["BCGSKARSAYISI"] = value; }
        }

    /// <summary>
    /// Tüberkülin Deri Testi Sonucu
    /// </summary>
        public int? TuberkulinDeriTestiSonuc
        {
            get { return (int?)this["TUBERKULINDERITESTISONUC"]; }
            set { this["TUBERKULINDERITESTISONUC"] = value; }
        }

        public SKRSDGTUygulamaYeri SKRSDGTUygulamaYeri
        {
            get { return (SKRSDGTUygulamaYeri)((ITTObject)this).GetParent("SKRSDGTUYGULAMAYERI"); }
            set { this["SKRSDGTUYGULAMAYERI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSDGTUygulamasiniYapanKisi SKRSDGTUygulamasiniYapanKisi
        {
            get { return (SKRSDGTUygulamasiniYapanKisi)((ITTObject)this).GetParent("SKRSDGTUYGULAMASINIYAPANKISI"); }
            set { this["SKRSDGTUYGULAMASINIYAPANKISI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSHastaninTedaviyeUyumu SKRSHastaninTedaviyeUyumu
        {
            get { return (SKRSHastaninTedaviyeUyumu)((ITTObject)this).GetParent("SKRSHASTANINTEDAVIYEUYUMU"); }
            set { this["SKRSHASTANINTEDAVIYEUYUMU"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSKulturSonucu SKRSKulturSonucu
        {
            get { return (SKRSKulturSonucu)((ITTObject)this).GetParent("SKRSKULTURSONUCU"); }
            set { this["SKRSKULTURSONUCU"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSVeremHastasiTedaviYontemi SKRSVeremHastasiTedaviYontemi
        {
            get { return (SKRSVeremHastasiTedaviYontemi)((ITTObject)this).GetParent("SKRSVEREMHASTASITEDAVIYONTEMI"); }
            set { this["SKRSVEREMHASTASITEDAVIYONTEMI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSVeremOlguTanimi SKRSVeremOlguTanimi
        {
            get { return (SKRSVeremOlguTanimi)((ITTObject)this).GetParent("SKRSVEREMOLGUTANIMI"); }
            set { this["SKRSVEREMOLGUTANIMI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSYaymaSonucu SKRSYaymaSonucu
        {
            get { return (SKRSYaymaSonucu)((ITTObject)this).GetParent("SKRSYAYMASONUCU"); }
            set { this["SKRSYAYMASONUCU"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateVeremHastalikTutumYeriCollection()
        {
            _VeremHastalikTutumYeri = new VeremHastalikTutumYeri.ChildVeremHastalikTutumYeriCollection(this, new Guid("986a0ac4-01f9-4da6-8be6-a0fd69e85836"));
            ((ITTChildObjectCollection)_VeremHastalikTutumYeri).GetChildren();
        }

        protected VeremHastalikTutumYeri.ChildVeremHastalikTutumYeriCollection _VeremHastalikTutumYeri = null;
        public VeremHastalikTutumYeri.ChildVeremHastalikTutumYeriCollection VeremHastalikTutumYeri
        {
            get
            {
                if (_VeremHastalikTutumYeri == null)
                    CreateVeremHastalikTutumYeriCollection();
                return _VeremHastalikTutumYeri;
            }
        }

        virtual protected void CreateVeremKlinikOrnegiCollection()
        {
            _VeremKlinikOrnegi = new VeremKlinikOrnegi.ChildVeremKlinikOrnegiCollection(this, new Guid("d1fa2cd2-0918-4048-a49c-e740e68a41d8"));
            ((ITTChildObjectCollection)_VeremKlinikOrnegi).GetChildren();
        }

        protected VeremKlinikOrnegi.ChildVeremKlinikOrnegiCollection _VeremKlinikOrnegi = null;
        public VeremKlinikOrnegi.ChildVeremKlinikOrnegiCollection VeremKlinikOrnegi
        {
            get
            {
                if (_VeremKlinikOrnegi == null)
                    CreateVeremKlinikOrnegiCollection();
                return _VeremKlinikOrnegi;
            }
        }

        virtual protected void CreateVeremIlacBilgisiCollection()
        {
            _VeremIlacBilgisi = new VeremIlacBilgisi.ChildVeremIlacBilgisiCollection(this, new Guid("ef0ebf95-3652-4e12-86c6-34a9afe88742"));
            ((ITTChildObjectCollection)_VeremIlacBilgisi).GetChildren();
        }

        protected VeremIlacBilgisi.ChildVeremIlacBilgisiCollection _VeremIlacBilgisi = null;
        public VeremIlacBilgisi.ChildVeremIlacBilgisiCollection VeremIlacBilgisi
        {
            get
            {
                if (_VeremIlacBilgisi == null)
                    CreateVeremIlacBilgisiCollection();
                return _VeremIlacBilgisi;
            }
        }

        virtual protected void CreateVeremTedaviSonucBilgisiCollection()
        {
            _VeremTedaviSonucBilgisi = new VeremTedaviSonucBilgisi.ChildVeremTedaviSonucBilgisiCollection(this, new Guid("d227b9ac-8bd5-4b7d-83c4-523b672c7b42"));
            ((ITTChildObjectCollection)_VeremTedaviSonucBilgisi).GetChildren();
        }

        protected VeremTedaviSonucBilgisi.ChildVeremTedaviSonucBilgisiCollection _VeremTedaviSonucBilgisi = null;
        public VeremTedaviSonucBilgisi.ChildVeremTedaviSonucBilgisiCollection VeremTedaviSonucBilgisi
        {
            get
            {
                if (_VeremTedaviSonucBilgisi == null)
                    CreateVeremTedaviSonucBilgisiCollection();
                return _VeremTedaviSonucBilgisi;
            }
        }

        protected VeremVeriSeti(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected VeremVeriSeti(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected VeremVeriSeti(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected VeremVeriSeti(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected VeremVeriSeti(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "VEREMVERISETI", dataRow) { }
        protected VeremVeriSeti(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "VEREMVERISETI", dataRow, isImported) { }
        public VeremVeriSeti(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public VeremVeriSeti(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public VeremVeriSeti() : base() { }

    }
}