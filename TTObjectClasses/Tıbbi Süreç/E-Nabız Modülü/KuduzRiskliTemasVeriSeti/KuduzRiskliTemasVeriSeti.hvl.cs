
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="KuduzRiskliTemasVeriSeti")] 

    public  partial class KuduzRiskliTemasVeriSeti : ENabiz
    {
        public class KuduzRiskliTemasVeriSetiList : TTObjectCollection<KuduzRiskliTemasVeriSeti> { }
                    
        public class ChildKuduzRiskliTemasVeriSetiCollection : TTObject.TTChildObjectCollection<KuduzRiskliTemasVeriSeti>
        {
            public ChildKuduzRiskliTemasVeriSetiCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildKuduzRiskliTemasVeriSetiCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
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

        public DateTime? RiskliTemasTarihi
        {
            get { return (DateTime?)this["RISKLITEMASTARIHI"]; }
            set { this["RISKLITEMASTARIHI"] = value; }
        }

        public SKRSHayvaninSahiplikDurumu SKRSHayvaninSahiplikDurumu
        {
            get { return (SKRSHayvaninSahiplikDurumu)((ITTObject)this).GetParent("SKRSHAYVANINSAHIPLIKDURUMU"); }
            set { this["SKRSHAYVANINSAHIPLIKDURUMU"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSHayvaninMevcutDurumu SKRSHayvaninMevcutDurumu
        {
            get { return (SKRSHayvaninMevcutDurumu)((ITTObject)this).GetParent("SKRSHAYVANINMEVCUTDURUMU"); }
            set { this["SKRSHAYVANINMEVCUTDURUMU"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSImmunglobulinTuru SKRSImmunglobulinTuru
        {
            get { return (SKRSImmunglobulinTuru)((ITTObject)this).GetParent("SKRSIMMUNGLOBULINTURU"); }
            set { this["SKRSIMMUNGLOBULINTURU"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSKategorizasyon SKRSKategorizasyon
        {
            get { return (SKRSKategorizasyon)((ITTObject)this).GetParent("SKRSKATEGORIZASYON"); }
            set { this["SKRSKATEGORIZASYON"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// SKRS Kuduz Riskli Temas Değerlendirme Durumu
    /// </summary>
        public SKRSKuduzRiskliTemasDegerlendirmeDurumu SKRSKuduzRiskliTemasDegDurumu
        {
            get { return (SKRSKuduzRiskliTemasDegerlendirmeDurumu)((ITTObject)this).GetParent("SKRSKUDUZRISKLITEMASDEGDURUMU"); }
            set { this["SKRSKUDUZRISKLITEMASDEGDURUMU"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// SKRS Riskli Temasa Sebep Olan Hayvan
    /// </summary>
        public SKRSRiskliTemasaSebepOlanHayvan SKRSRiskliTemasSebepOlHayvan
        {
            get { return (SKRSRiskliTemasaSebepOlanHayvan)((ITTObject)this).GetParent("SKRSRISKLITEMASSEBEPOLHAYVAN"); }
            set { this["SKRSRISKLITEMASSEBEPOLHAYVAN"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateKuduzRiskliTemasAdresCollection()
        {
            _KuduzRiskliTemasAdres = new KuduzRiskliTemasAdres.ChildKuduzRiskliTemasAdresCollection(this, new Guid("59b2d26e-6576-4fb3-90ac-19f3ceadac40"));
            ((ITTChildObjectCollection)_KuduzRiskliTemasAdres).GetChildren();
        }

        protected KuduzRiskliTemasAdres.ChildKuduzRiskliTemasAdresCollection _KuduzRiskliTemasAdres = null;
        public KuduzRiskliTemasAdres.ChildKuduzRiskliTemasAdresCollection KuduzRiskliTemasAdres
        {
            get
            {
                if (_KuduzRiskliTemasAdres == null)
                    CreateKuduzRiskliTemasAdresCollection();
                return _KuduzRiskliTemasAdres;
            }
        }

        virtual protected void CreateKuduzRiskliTemasPlanProfBiCollection()
        {
            _KuduzRiskliTemasPlanProfBi = new KuduzRiskliTemasPlanProfBi.ChildKuduzRiskliTemasPlanProfBiCollection(this, new Guid("17346e93-3c77-45db-ac2d-4780a44f51fa"));
            ((ITTChildObjectCollection)_KuduzRiskliTemasPlanProfBi).GetChildren();
        }

        protected KuduzRiskliTemasPlanProfBi.ChildKuduzRiskliTemasPlanProfBiCollection _KuduzRiskliTemasPlanProfBi = null;
        public KuduzRiskliTemasPlanProfBi.ChildKuduzRiskliTemasPlanProfBiCollection KuduzRiskliTemasPlanProfBi
        {
            get
            {
                if (_KuduzRiskliTemasPlanProfBi == null)
                    CreateKuduzRiskliTemasPlanProfBiCollection();
                return _KuduzRiskliTemasPlanProfBi;
            }
        }

        virtual protected void CreateKuduzRiskliTemasRiskTemTipCollection()
        {
            _KuduzRiskliTemasRiskTemTip = new KuduzRiskliTemasRiskTemTip.ChildKuduzRiskliTemasRiskTemTipCollection(this, new Guid("2999f0f4-99f9-4789-bc98-e3e80ad593fc"));
            ((ITTChildObjectCollection)_KuduzRiskliTemasRiskTemTip).GetChildren();
        }

        protected KuduzRiskliTemasRiskTemTip.ChildKuduzRiskliTemasRiskTemTipCollection _KuduzRiskliTemasRiskTemTip = null;
        public KuduzRiskliTemasRiskTemTip.ChildKuduzRiskliTemasRiskTemTipCollection KuduzRiskliTemasRiskTemTip
        {
            get
            {
                if (_KuduzRiskliTemasRiskTemTip == null)
                    CreateKuduzRiskliTemasRiskTemTipCollection();
                return _KuduzRiskliTemasRiskTemTip;
            }
        }

        virtual protected void CreateKuduzRiskliTemasTelefonCollection()
        {
            _KuduzRiskliTemasTelefon = new KuduzRiskliTemasTelefon.ChildKuduzRiskliTemasTelefonCollection(this, new Guid("f120a70e-0bbb-4381-8dbc-a8b83dce49f3"));
            ((ITTChildObjectCollection)_KuduzRiskliTemasTelefon).GetChildren();
        }

        protected KuduzRiskliTemasTelefon.ChildKuduzRiskliTemasTelefonCollection _KuduzRiskliTemasTelefon = null;
        public KuduzRiskliTemasTelefon.ChildKuduzRiskliTemasTelefonCollection KuduzRiskliTemasTelefon
        {
            get
            {
                if (_KuduzRiskliTemasTelefon == null)
                    CreateKuduzRiskliTemasTelefonCollection();
                return _KuduzRiskliTemasTelefon;
            }
        }

        protected KuduzRiskliTemasVeriSeti(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected KuduzRiskliTemasVeriSeti(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected KuduzRiskliTemasVeriSeti(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected KuduzRiskliTemasVeriSeti(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected KuduzRiskliTemasVeriSeti(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "KUDUZRISKLITEMASVERISETI", dataRow) { }
        protected KuduzRiskliTemasVeriSeti(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "KUDUZRISKLITEMASVERISETI", dataRow, isImported) { }
        public KuduzRiskliTemasVeriSeti(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public KuduzRiskliTemasVeriSeti(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public KuduzRiskliTemasVeriSeti() : base() { }

    }
}