
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ObeziteIzlemVeriSeti")] 

    public  partial class ObeziteIzlemVeriSeti : ENabiz
    {
        public class ObeziteIzlemVeriSetiList : TTObjectCollection<ObeziteIzlemVeriSeti> { }
                    
        public class ChildObeziteIzlemVeriSetiCollection : TTObject.TTChildObjectCollection<ObeziteIzlemVeriSeti>
        {
            public ChildObeziteIzlemVeriSetiCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildObeziteIzlemVeriSetiCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public double? KalcaCevresi
        {
            get { return (double?)this["KALCACEVRESI"]; }
            set { this["KALCACEVRESI"] = value; }
        }

        public int? Boy
        {
            get { return (int?)this["BOY"]; }
            set { this["BOY"] = value; }
        }

        public double? BelCevresi
        {
            get { return (double?)this["BELCEVRESI"]; }
            set { this["BELCEVRESI"] = value; }
        }

        public DateTime? IlkTaniTarihi
        {
            get { return (DateTime?)this["ILKTANITARIHI"]; }
            set { this["ILKTANITARIHI"] = value; }
        }

        public double? Kilo
        {
            get { return (double?)this["KILO"]; }
            set { this["KILO"] = value; }
        }

        public SKRSDiyetTedavisiTibbiBeslenmeTedavisi DiyetTibbiBeslenmeTedavisi
        {
            get { return (SKRSDiyetTedavisiTibbiBeslenmeTedavisi)((ITTObject)this).GetParent("DIYETTIBBIBESLENMETEDAVISI"); }
            set { this["DIYETTIBBIBESLENMETEDAVISI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSMorbidObezHastaLenfatikOdemVarligi OdemVarligi
        {
            get { return (SKRSMorbidObezHastaLenfatikOdemVarligi)((ITTObject)this).GetParent("ODEMVARLIGI"); }
            set { this["ODEMVARLIGI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSObeziteIlacTedavisi SKRSObeziteIlacTedavisi
        {
            get { return (SKRSObeziteIlacTedavisi)((ITTObject)this).GetParent("SKRSOBEZITEILACTEDAVISI"); }
            set { this["SKRSOBEZITEILACTEDAVISI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSPsikolojikTedavi SKRSPsikolojikTedavi
        {
            get { return (SKRSPsikolojikTedavi)((ITTObject)this).GetParent("SKRSPSIKOLOJIKTEDAVI"); }
            set { this["SKRSPSIKOLOJIKTEDAVI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateObeziteEkHastalikCollection()
        {
            _ObeziteEkHastalik = new ObeziteEkHastalik.ChildObeziteEkHastalikCollection(this, new Guid("0f05303b-dc5f-4372-9fcb-f6f688ba7cec"));
            ((ITTChildObjectCollection)_ObeziteEkHastalik).GetChildren();
        }

        protected ObeziteEkHastalik.ChildObeziteEkHastalikCollection _ObeziteEkHastalik = null;
        public ObeziteEkHastalik.ChildObeziteEkHastalikCollection ObeziteEkHastalik
        {
            get
            {
                if (_ObeziteEkHastalik == null)
                    CreateObeziteEkHastalikCollection();
                return _ObeziteEkHastalik;
            }
        }

        virtual protected void CreateObeziteEgzersizCollection()
        {
            _ObeziteEgzersiz = new ObeziteEgzersiz.ChildObeziteEgzersizCollection(this, new Guid("0f627330-a3d2-4821-b126-2c0ed840aeb7"));
            ((ITTChildObjectCollection)_ObeziteEgzersiz).GetChildren();
        }

        protected ObeziteEgzersiz.ChildObeziteEgzersizCollection _ObeziteEgzersiz = null;
        public ObeziteEgzersiz.ChildObeziteEgzersizCollection ObeziteEgzersiz
        {
            get
            {
                if (_ObeziteEgzersiz == null)
                    CreateObeziteEgzersizCollection();
                return _ObeziteEgzersiz;
            }
        }

        protected ObeziteIzlemVeriSeti(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ObeziteIzlemVeriSeti(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ObeziteIzlemVeriSeti(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ObeziteIzlemVeriSeti(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ObeziteIzlemVeriSeti(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "OBEZITEIZLEMVERISETI", dataRow) { }
        protected ObeziteIzlemVeriSeti(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "OBEZITEIZLEMVERISETI", dataRow, isImported) { }
        public ObeziteIzlemVeriSeti(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ObeziteIzlemVeriSeti(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ObeziteIzlemVeriSeti() : base() { }

    }
}