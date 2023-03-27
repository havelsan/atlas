
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="IntiharIzlemVeriSeti")] 

    public  partial class IntiharIzlemVeriSeti : ENabiz
    {
        public class IntiharIzlemVeriSetiList : TTObjectCollection<IntiharIzlemVeriSeti> { }
                    
        public class ChildIntiharIzlemVeriSetiCollection : TTObject.TTChildObjectCollection<IntiharIzlemVeriSeti>
        {
            public ChildIntiharIzlemVeriSetiCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildIntiharIzlemVeriSetiCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public SKRSIntiharKrizVakaTuru SKRSIntiharKrizVakaTuru
        {
            get { return (SKRSIntiharKrizVakaTuru)((ITTObject)this).GetParent("SKRSINTIHARKRIZVAKATURU"); }
            set { this["SKRSINTIHARKRIZVAKATURU"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateIntiharIzlemNedeniCollection()
        {
            _IntiharIzlemNedeni = new IntiharIzlemNedeni.ChildIntiharIzlemNedeniCollection(this, new Guid("fab9a4a6-a213-4cd4-9d00-ad56e33ba504"));
            ((ITTChildObjectCollection)_IntiharIzlemNedeni).GetChildren();
        }

        protected IntiharIzlemNedeni.ChildIntiharIzlemNedeniCollection _IntiharIzlemNedeni = null;
        public IntiharIzlemNedeni.ChildIntiharIzlemNedeniCollection IntiharIzlemNedeni
        {
            get
            {
                if (_IntiharIzlemNedeni == null)
                    CreateIntiharIzlemNedeniCollection();
                return _IntiharIzlemNedeni;
            }
        }

        virtual protected void CreateIntiharIzlemYontemiCollection()
        {
            _IntiharIzlemYontemi = new IntiharIzlemYontemi.ChildIntiharIzlemYontemiCollection(this, new Guid("2e5d44db-8387-412a-bce8-3bdf3875a850"));
            ((ITTChildObjectCollection)_IntiharIzlemYontemi).GetChildren();
        }

        protected IntiharIzlemYontemi.ChildIntiharIzlemYontemiCollection _IntiharIzlemYontemi = null;
        public IntiharIzlemYontemi.ChildIntiharIzlemYontemiCollection IntiharIzlemYontemi
        {
            get
            {
                if (_IntiharIzlemYontemi == null)
                    CreateIntiharIzlemYontemiCollection();
                return _IntiharIzlemYontemi;
            }
        }

        virtual protected void CreateIntiharIzlemVakaSonucuCollection()
        {
            _IntiharIzlemVakaSonucu = new IntiharIzlemVakaSonucu.ChildIntiharIzlemVakaSonucuCollection(this, new Guid("48b90c3e-a4f8-4b4b-88a2-f97251b1ba27"));
            ((ITTChildObjectCollection)_IntiharIzlemVakaSonucu).GetChildren();
        }

        protected IntiharIzlemVakaSonucu.ChildIntiharIzlemVakaSonucuCollection _IntiharIzlemVakaSonucu = null;
        public IntiharIzlemVakaSonucu.ChildIntiharIzlemVakaSonucuCollection IntiharIzlemVakaSonucu
        {
            get
            {
                if (_IntiharIzlemVakaSonucu == null)
                    CreateIntiharIzlemVakaSonucuCollection();
                return _IntiharIzlemVakaSonucu;
            }
        }

        protected IntiharIzlemVeriSeti(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected IntiharIzlemVeriSeti(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected IntiharIzlemVeriSeti(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected IntiharIzlemVeriSeti(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected IntiharIzlemVeriSeti(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "INTIHARIZLEMVERISETI", dataRow) { }
        protected IntiharIzlemVeriSeti(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "INTIHARIZLEMVERISETI", dataRow, isImported) { }
        public IntiharIzlemVeriSeti(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public IntiharIzlemVeriSeti(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public IntiharIzlemVeriSeti() : base() { }

    }
}