
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="KuduzProfilaksiVeriSeti")] 

    /// <summary>
    /// Kuduz Profilaksi İzlem Veri Seti
    /// </summary>
    public  partial class KuduzProfilaksiVeriSeti : ENabiz
    {
        public class KuduzProfilaksiVeriSetiList : TTObjectCollection<KuduzProfilaksiVeriSeti> { }
                    
        public class ChildKuduzProfilaksiVeriSetiCollection : TTObject.TTChildObjectCollection<KuduzProfilaksiVeriSeti>
        {
            public ChildKuduzProfilaksiVeriSetiCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildKuduzProfilaksiVeriSetiCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Kilo
    /// </summary>
        public int? Kilo
        {
            get { return (int?)this["KILO"]; }
            set { this["KILO"] = value; }
        }

        public string ImmunglobulinMiktari
        {
            get { return (string)this["IMMUNGLOBULINMIKTARI"]; }
            set { this["IMMUNGLOBULINMIKTARI"] = value; }
        }

        public SKRSKuduzProfilaksisiTamamlanmaDurumu SKRSKuduzProfilaksiTamamlanma
        {
            get { return (SKRSKuduzProfilaksisiTamamlanmaDurumu)((ITTObject)this).GetParent("SKRSKUDUZPROFILAKSITAMAMLANMA"); }
            set { this["SKRSKUDUZPROFILAKSITAMAMLANMA"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSImmunglobulinTuru SKRSImmunglobulinTuru
        {
            get { return (SKRSImmunglobulinTuru)((ITTObject)this).GetParent("SKRSIMMUNGLOBULINTURU"); }
            set { this["SKRSIMMUNGLOBULINTURU"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateKuduzProfilaksiTelefonCollection()
        {
            _KuduzProfilaksiTelefon = new KuduzProfilaksiTelefon.ChildKuduzProfilaksiTelefonCollection(this, new Guid("348c8239-3e12-4a7f-8c28-2511aa342a4b"));
            ((ITTChildObjectCollection)_KuduzProfilaksiTelefon).GetChildren();
        }

        protected KuduzProfilaksiTelefon.ChildKuduzProfilaksiTelefonCollection _KuduzProfilaksiTelefon = null;
        public KuduzProfilaksiTelefon.ChildKuduzProfilaksiTelefonCollection KuduzProfilaksiTelefon
        {
            get
            {
                if (_KuduzProfilaksiTelefon == null)
                    CreateKuduzProfilaksiTelefonCollection();
                return _KuduzProfilaksiTelefon;
            }
        }

        virtual protected void CreateKuduzProfilaksiUygProfilakCollection()
        {
            _KuduzProfilaksiUygProfilak = new KuduzProfilaksiUygProfilak.ChildKuduzProfilaksiUygProfilakCollection(this, new Guid("bf22264f-8524-48fb-a4c5-78f889b4daf0"));
            ((ITTChildObjectCollection)_KuduzProfilaksiUygProfilak).GetChildren();
        }

        protected KuduzProfilaksiUygProfilak.ChildKuduzProfilaksiUygProfilakCollection _KuduzProfilaksiUygProfilak = null;
        public KuduzProfilaksiUygProfilak.ChildKuduzProfilaksiUygProfilakCollection KuduzProfilaksiUygProfilak
        {
            get
            {
                if (_KuduzProfilaksiUygProfilak == null)
                    CreateKuduzProfilaksiUygProfilakCollection();
                return _KuduzProfilaksiUygProfilak;
            }
        }

        virtual protected void CreateKuduzProfilaksiAdresCollection()
        {
            _KuduzProfilaksiAdres = new KuduzProfilaksiAdres.ChildKuduzProfilaksiAdresCollection(this, new Guid("e9320fa8-b611-40d4-a4c9-33ee9abd0f20"));
            ((ITTChildObjectCollection)_KuduzProfilaksiAdres).GetChildren();
        }

        protected KuduzProfilaksiAdres.ChildKuduzProfilaksiAdresCollection _KuduzProfilaksiAdres = null;
        public KuduzProfilaksiAdres.ChildKuduzProfilaksiAdresCollection KuduzProfilaksiAdres
        {
            get
            {
                if (_KuduzProfilaksiAdres == null)
                    CreateKuduzProfilaksiAdresCollection();
                return _KuduzProfilaksiAdres;
            }
        }

        protected KuduzProfilaksiVeriSeti(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected KuduzProfilaksiVeriSeti(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected KuduzProfilaksiVeriSeti(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected KuduzProfilaksiVeriSeti(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected KuduzProfilaksiVeriSeti(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "KUDUZPROFILAKSIVERISETI", dataRow) { }
        protected KuduzProfilaksiVeriSeti(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "KUDUZPROFILAKSIVERISETI", dataRow, isImported) { }
        public KuduzProfilaksiVeriSeti(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public KuduzProfilaksiVeriSeti(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public KuduzProfilaksiVeriSeti() : base() { }

    }
}