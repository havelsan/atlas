
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="IntiharGirisimKrizVeriSeti")] 

    public  partial class IntiharGirisimKrizVeriSeti : ENabiz
    {
        public class IntiharGirisimKrizVeriSetiList : TTObjectCollection<IntiharGirisimKrizVeriSeti> { }
                    
        public class ChildIntiharGirisimKrizVeriSetiCollection : TTObject.TTChildObjectCollection<IntiharGirisimKrizVeriSeti>
        {
            public ChildIntiharGirisimKrizVeriSetiCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildIntiharGirisimKrizVeriSetiCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public DateTime? OlayZamani
        {
            get { return (DateTime?)this["OLAYZAMANI"]; }
            set { this["OLAYZAMANI"] = value; }
        }

        public SKRSAilesindePsikiyatrikVaka SKRSAilesindePsikiyatrikVaka
        {
            get { return (SKRSAilesindePsikiyatrikVaka)((ITTObject)this).GetParent("SKRSAILESINDEPSIKIYATRIKVAKA"); }
            set { this["SKRSAILESINDEPSIKIYATRIKVAKA"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSIntiharGirisimiGecmisi SKRSIntiharGirisimiGecmisi
        {
            get { return (SKRSIntiharGirisimiGecmisi)((ITTObject)this).GetParent("SKRSINTIHARGIRISIMIGECMISI"); }
            set { this["SKRSINTIHARGIRISIMIGECMISI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSIntiharKrizVakaTuru SKRSIntiharKrizVakaTuru
        {
            get { return (SKRSIntiharKrizVakaTuru)((ITTObject)this).GetParent("SKRSINTIHARKRIZVAKATURU"); }
            set { this["SKRSINTIHARKRIZVAKATURU"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSPsikiyatrikTedaviGecmisi SKRSPsikiyatrikTedaviGecmisi
        {
            get { return (SKRSPsikiyatrikTedaviGecmisi)((ITTObject)this).GetParent("SKRSPSIKIYATRIKTEDAVIGECMISI"); }
            set { this["SKRSPSIKIYATRIKTEDAVIGECMISI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSAilesindeIntiharGirisimi SKRSAilesindeIntiharGirisimi
        {
            get { return (SKRSAilesindeIntiharGirisimi)((ITTObject)this).GetParent("SKRSAILESINDEINTIHARGIRISIMI"); }
            set { this["SKRSAILESINDEINTIHARGIRISIMI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateIntiharGirisimiKrizNedeniCollection()
        {
            _IntiharGirisimiKrizNedeni = new IntiharGirisimiKrizNedeni.ChildIntiharGirisimiKrizNedeniCollection(this, new Guid("95b2f3dd-37a1-4106-b51a-a463760b6843"));
            ((ITTChildObjectCollection)_IntiharGirisimiKrizNedeni).GetChildren();
        }

        protected IntiharGirisimiKrizNedeni.ChildIntiharGirisimiKrizNedeniCollection _IntiharGirisimiKrizNedeni = null;
        public IntiharGirisimiKrizNedeni.ChildIntiharGirisimiKrizNedeniCollection IntiharGirisimiKrizNedeni
        {
            get
            {
                if (_IntiharGirisimiKrizNedeni == null)
                    CreateIntiharGirisimiKrizNedeniCollection();
                return _IntiharGirisimiKrizNedeni;
            }
        }

        virtual protected void CreateIntiharGirisimiVakaSonucuCollection()
        {
            _IntiharGirisimiVakaSonucu = new IntiharGirisimiVakaSonucu.ChildIntiharGirisimiVakaSonucuCollection(this, new Guid("903c5115-aa87-435d-a778-910fd6025065"));
            ((ITTChildObjectCollection)_IntiharGirisimiVakaSonucu).GetChildren();
        }

        protected IntiharGirisimiVakaSonucu.ChildIntiharGirisimiVakaSonucuCollection _IntiharGirisimiVakaSonucu = null;
        public IntiharGirisimiVakaSonucu.ChildIntiharGirisimiVakaSonucuCollection IntiharGirisimiVakaSonucu
        {
            get
            {
                if (_IntiharGirisimiVakaSonucu == null)
                    CreateIntiharGirisimiVakaSonucuCollection();
                return _IntiharGirisimiVakaSonucu;
            }
        }

        virtual protected void CreateIntiharGirisimiYontemiCollection()
        {
            _IntiharGirisimiYontemi = new IntiharGirisimiYontemi.ChildIntiharGirisimiYontemiCollection(this, new Guid("d9ad475f-7149-44bf-82d8-6f5cd6454f6c"));
            ((ITTChildObjectCollection)_IntiharGirisimiYontemi).GetChildren();
        }

        protected IntiharGirisimiYontemi.ChildIntiharGirisimiYontemiCollection _IntiharGirisimiYontemi = null;
        public IntiharGirisimiYontemi.ChildIntiharGirisimiYontemiCollection IntiharGirisimiYontemi
        {
            get
            {
                if (_IntiharGirisimiYontemi == null)
                    CreateIntiharGirisimiYontemiCollection();
                return _IntiharGirisimiYontemi;
            }
        }

        virtual protected void CreateIntiharGirisimPsikiyatTaniCollection()
        {
            _IntiharGirisimPsikiyatTani = new IntiharGirisimPsikiyatTani.ChildIntiharGirisimPsikiyatTaniCollection(this, new Guid("c6eddf7f-6f1b-43c8-8955-a9eaa2fcc30a"));
            ((ITTChildObjectCollection)_IntiharGirisimPsikiyatTani).GetChildren();
        }

        protected IntiharGirisimPsikiyatTani.ChildIntiharGirisimPsikiyatTaniCollection _IntiharGirisimPsikiyatTani = null;
        public IntiharGirisimPsikiyatTani.ChildIntiharGirisimPsikiyatTaniCollection IntiharGirisimPsikiyatTani
        {
            get
            {
                if (_IntiharGirisimPsikiyatTani == null)
                    CreateIntiharGirisimPsikiyatTaniCollection();
                return _IntiharGirisimPsikiyatTani;
            }
        }

        protected IntiharGirisimKrizVeriSeti(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected IntiharGirisimKrizVeriSeti(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected IntiharGirisimKrizVeriSeti(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected IntiharGirisimKrizVeriSeti(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected IntiharGirisimKrizVeriSeti(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "INTIHARGIRISIMKRIZVERISETI", dataRow) { }
        protected IntiharGirisimKrizVeriSeti(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "INTIHARGIRISIMKRIZVERISETI", dataRow, isImported) { }
        public IntiharGirisimKrizVeriSeti(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public IntiharGirisimKrizVeriSeti(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public IntiharGirisimKrizVeriSeti() : base() { }

    }
}