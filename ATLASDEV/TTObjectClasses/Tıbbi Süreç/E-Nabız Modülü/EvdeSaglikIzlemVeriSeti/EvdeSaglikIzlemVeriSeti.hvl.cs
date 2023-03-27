
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="EvdeSaglikIzlemVeriSeti")] 

    /// <summary>
    /// Evde Sağlık İzlem Veri Seti
    /// </summary>
    public  partial class EvdeSaglikIzlemVeriSeti : ENabiz
    {
        public class EvdeSaglikIzlemVeriSetiList : TTObjectCollection<EvdeSaglikIzlemVeriSeti> { }
                    
        public class ChildEvdeSaglikIzlemVeriSetiCollection : TTObject.TTChildObjectCollection<EvdeSaglikIzlemVeriSeti>
        {
            public ChildEvdeSaglikIzlemVeriSetiCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildEvdeSaglikIzlemVeriSetiCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public SKRSAgri SKRSAgri
        {
            get { return (SKRSAgri)((ITTObject)this).GetParent("SKRSAGRI"); }
            set { this["SKRSAGRI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSBasiDegerlendirmesi SKRSBasiDegerlendirmesi
        {
            get { return (SKRSBasiDegerlendirmesi)((ITTObject)this).GetParent("SKRSBASIDEGERLENDIRMESI"); }
            set { this["SKRSBASIDEGERLENDIRMESI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSBeslenme SKRSBeslenme
        {
            get { return (SKRSBeslenme)((ITTObject)this).GetParent("SKRSBESLENME"); }
            set { this["SKRSBESLENME"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSEvdeSaglikHizmetininSonlandirilmasi SKRSHizmetinSonlandirilmasi
        {
            get { return (SKRSEvdeSaglikHizmetininSonlandirilmasi)((ITTObject)this).GetParent("SKRSHIZMETINSONLANDIRILMASI"); }
            set { this["SKRSHIZMETINSONLANDIRILMASI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSEvdeSaglikHizmetleriHastaNakli SKRSHastaNakli
        {
            get { return (SKRSEvdeSaglikHizmetleriHastaNakli)((ITTObject)this).GetParent("SKRSHASTANAKLI"); }
            set { this["SKRSHASTANAKLI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSILKodlari SKRSIl
        {
            get { return (SKRSILKodlari)((ITTObject)this).GetParent("SKRSIL"); }
            set { this["SKRSIL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreatePsikolojikDurumCollection()
        {
            _PsikolojikDurum = new PsikolojikDurum.ChildPsikolojikDurumCollection(this, new Guid("a7d33b0c-b0d1-4692-86ad-14ba7130fb2c"));
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
            _VerilenEgitimler = new VerilenEgitimler.ChildVerilenEgitimlerCollection(this, new Guid("c9d010d7-e715-40f6-9258-53f617b697cd"));
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

        virtual protected void CreateBirSonrakiHizmetIhtiyaciCollection()
        {
            _BirSonrakiHizmetIhtiyaci = new BirSonrakiHizmetIhtiyaci.ChildBirSonrakiHizmetIhtiyaciCollection(this, new Guid("f3c4d67d-4358-4276-ab6e-c1bd9f31d6d7"));
            ((ITTChildObjectCollection)_BirSonrakiHizmetIhtiyaci).GetChildren();
        }

        protected BirSonrakiHizmetIhtiyaci.ChildBirSonrakiHizmetIhtiyaciCollection _BirSonrakiHizmetIhtiyaci = null;
        public BirSonrakiHizmetIhtiyaci.ChildBirSonrakiHizmetIhtiyaciCollection BirSonrakiHizmetIhtiyaci
        {
            get
            {
                if (_BirSonrakiHizmetIhtiyaci == null)
                    CreateBirSonrakiHizmetIhtiyaciCollection();
                return _BirSonrakiHizmetIhtiyaci;
            }
        }

        protected EvdeSaglikIzlemVeriSeti(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected EvdeSaglikIzlemVeriSeti(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected EvdeSaglikIzlemVeriSeti(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected EvdeSaglikIzlemVeriSeti(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected EvdeSaglikIzlemVeriSeti(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EVDESAGLIKIZLEMVERISETI", dataRow) { }
        protected EvdeSaglikIzlemVeriSeti(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EVDESAGLIKIZLEMVERISETI", dataRow, isImported) { }
        public EvdeSaglikIzlemVeriSeti(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public EvdeSaglikIzlemVeriSeti(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public EvdeSaglikIzlemVeriSeti() : base() { }

    }
}