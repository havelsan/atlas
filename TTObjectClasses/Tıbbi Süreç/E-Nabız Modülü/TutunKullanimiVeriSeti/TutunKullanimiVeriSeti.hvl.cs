
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TutunKullanimiVeriSeti")] 

    public  partial class TutunKullanimiVeriSeti : ENabiz
    {
        public class TutunKullanimiVeriSetiList : TTObjectCollection<TutunKullanimiVeriSeti> { }
                    
        public class ChildTutunKullanimiVeriSetiCollection : TTObject.TTChildObjectCollection<TutunKullanimiVeriSeti>
        {
            public ChildTutunKullanimiVeriSetiCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTutunKullanimiVeriSetiCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public int? SigaraAdedi
        {
            get { return (int?)this["SIGARAADEDI"]; }
            set { this["SIGARAADEDI"] = value; }
        }

        public SKRSSigaraKullanimi SKRSSigaraKullanimi
        {
            get { return (SKRSSigaraKullanimi)((ITTObject)this).GetParent("SKRSSIGARAKULLANIMI"); }
            set { this["SKRSSIGARAKULLANIMI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSTutunDumaninaMaruzKalmaPasificicilik SKRSTutunDumaninaMaruzKalma
        {
            get { return (SKRSTutunDumaninaMaruzKalmaPasificicilik)((ITTObject)this).GetParent("SKRSTUTUNDUMANINAMARUZKALMA"); }
            set { this["SKRSTUTUNDUMANINAMARUZKALMA"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateTutunKullanimiBagimOldUrunCollection()
        {
            _TutunKullanimiBagimOldUrun = new TutunKullanimiBagimOldUrun.ChildTutunKullanimiBagimOldUrunCollection(this, new Guid("6fb94585-343e-4ea8-a482-a28d97b79ae5"));
            ((ITTChildObjectCollection)_TutunKullanimiBagimOldUrun).GetChildren();
        }

        protected TutunKullanimiBagimOldUrun.ChildTutunKullanimiBagimOldUrunCollection _TutunKullanimiBagimOldUrun = null;
        public TutunKullanimiBagimOldUrun.ChildTutunKullanimiBagimOldUrunCollection TutunKullanimiBagimOldUrun
        {
            get
            {
                if (_TutunKullanimiBagimOldUrun == null)
                    CreateTutunKullanimiBagimOldUrunCollection();
                return _TutunKullanimiBagimOldUrun;
            }
        }

        virtual protected void CreateTutunKullanimiTedaviSekliCollection()
        {
            _TutunKullanimiTedaviSekli = new TutunKullanimiTedaviSekli.ChildTutunKullanimiTedaviSekliCollection(this, new Guid("933061c2-5b20-421f-9291-bb74d0a9f285"));
            ((ITTChildObjectCollection)_TutunKullanimiTedaviSekli).GetChildren();
        }

        protected TutunKullanimiTedaviSekli.ChildTutunKullanimiTedaviSekliCollection _TutunKullanimiTedaviSekli = null;
        public TutunKullanimiTedaviSekli.ChildTutunKullanimiTedaviSekliCollection TutunKullanimiTedaviSekli
        {
            get
            {
                if (_TutunKullanimiTedaviSekli == null)
                    CreateTutunKullanimiTedaviSekliCollection();
                return _TutunKullanimiTedaviSekli;
            }
        }

        virtual protected void CreateTutunKullanimiTedaviSonucuCollection()
        {
            _TutunKullanimiTedaviSonucu = new TutunKullanimiTedaviSonucu.ChildTutunKullanimiTedaviSonucuCollection(this, new Guid("b8d3be62-4bb0-4eb9-a750-10cadbef203b"));
            ((ITTChildObjectCollection)_TutunKullanimiTedaviSonucu).GetChildren();
        }

        protected TutunKullanimiTedaviSonucu.ChildTutunKullanimiTedaviSonucuCollection _TutunKullanimiTedaviSonucu = null;
        public TutunKullanimiTedaviSonucu.ChildTutunKullanimiTedaviSonucuCollection TutunKullanimiTedaviSonucu
        {
            get
            {
                if (_TutunKullanimiTedaviSonucu == null)
                    CreateTutunKullanimiTedaviSonucuCollection();
                return _TutunKullanimiTedaviSonucu;
            }
        }

        protected TutunKullanimiVeriSeti(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TutunKullanimiVeriSeti(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TutunKullanimiVeriSeti(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TutunKullanimiVeriSeti(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TutunKullanimiVeriSeti(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TUTUNKULLANIMIVERISETI", dataRow) { }
        protected TutunKullanimiVeriSeti(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TUTUNKULLANIMIVERISETI", dataRow, isImported) { }
        public TutunKullanimiVeriSeti(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TutunKullanimiVeriSeti(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TutunKullanimiVeriSeti() : base() { }

    }
}