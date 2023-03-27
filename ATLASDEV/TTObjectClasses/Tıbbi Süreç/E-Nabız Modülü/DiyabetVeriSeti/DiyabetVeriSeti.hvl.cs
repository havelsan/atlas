
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DiyabetVeriSeti")] 

    public  partial class DiyabetVeriSeti : ENabiz
    {
        public class DiyabetVeriSetiList : TTObjectCollection<DiyabetVeriSeti> { }
                    
        public class ChildDiyabetVeriSetiCollection : TTObject.TTChildObjectCollection<DiyabetVeriSeti>
        {
            public ChildDiyabetVeriSetiCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDiyabetVeriSetiCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// İlk Tanı Tarihi
    /// </summary>
        public DateTime? IlkTaniTarihi
        {
            get { return (DateTime?)this["ILKTANITARIHI"]; }
            set { this["ILKTANITARIHI"] = value; }
        }

    /// <summary>
    /// Boy
    /// </summary>
        public int? Boy
        {
            get { return (int?)this["BOY"]; }
            set { this["BOY"] = value; }
        }

    /// <summary>
    /// Kilo
    /// </summary>
        public double? Kilo
        {
            get { return (double?)this["KILO"]; }
            set { this["KILO"] = value; }
        }

        public SKRSDiyabetEgitimi SKRSDiyabetEgitimi
        {
            get { return (SKRSDiyabetEgitimi)((ITTObject)this).GetParent("SKRSDIYABETEGITIMI"); }
            set { this["SKRSDIYABETEGITIMI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateDiyabetKompBilgisiCollection()
        {
            _DiyabetKompBilgisi = new DiyabetKompBilgisi.ChildDiyabetKompBilgisiCollection(this, new Guid("cc99f039-ebad-47d2-ad61-af6bb8e11017"));
            ((ITTChildObjectCollection)_DiyabetKompBilgisi).GetChildren();
        }

        protected DiyabetKompBilgisi.ChildDiyabetKompBilgisiCollection _DiyabetKompBilgisi = null;
        public DiyabetKompBilgisi.ChildDiyabetKompBilgisiCollection DiyabetKompBilgisi
        {
            get
            {
                if (_DiyabetKompBilgisi == null)
                    CreateDiyabetKompBilgisiCollection();
                return _DiyabetKompBilgisi;
            }
        }

        protected DiyabetVeriSeti(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DiyabetVeriSeti(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DiyabetVeriSeti(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DiyabetVeriSeti(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DiyabetVeriSeti(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DIYABETVERISETI", dataRow) { }
        protected DiyabetVeriSeti(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DIYABETVERISETI", dataRow, isImported) { }
        public DiyabetVeriSeti(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DiyabetVeriSeti(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DiyabetVeriSeti() : base() { }

    }
}