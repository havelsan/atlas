
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MaddeBagimliligiKulMadde")] 

    /// <summary>
    /// Madde Bağımlılığı Veri Seti Kullanılan Madde
    /// </summary>
    public  partial class MaddeBagimliligiKulMadde : TTObject
    {
        public class MaddeBagimliligiKulMaddeList : TTObjectCollection<MaddeBagimliligiKulMadde> { }
                    
        public class ChildMaddeBagimliligiKulMaddeCollection : TTObject.TTChildObjectCollection<MaddeBagimliligiKulMadde>
        {
            public ChildMaddeBagimliligiKulMaddeCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMaddeBagimliligiKulMaddeCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public int? MaddeIlkKullanimYasi
        {
            get { return (int?)this["MADDEILKKULLANIMYASI"]; }
            set { this["MADDEILKKULLANIMYASI"] = value; }
        }

        public int? DuzenliMaddeKullanimSuresi
        {
            get { return (int?)this["DUZENLIMADDEKULLANIMSURESI"]; }
            set { this["DUZENLIMADDEKULLANIMSURESI"] = value; }
        }

    /// <summary>
    /// Kullanılan Diğer Madde
    /// </summary>
        public SKRSKullanilanMadde SKRSKullanilanMadde
        {
            get { return (SKRSKullanilanMadde)((ITTObject)this).GetParent("SKRSKULLANILANMADDE"); }
            set { this["SKRSKULLANILANMADDE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSMaddeKullanimSikligi SKRSMaddeKullanimSikligi
        {
            get { return (SKRSMaddeKullanimSikligi)((ITTObject)this).GetParent("SKRSMADDEKULLANIMSIKLIGI"); }
            set { this["SKRSMADDEKULLANIMSIKLIGI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSMaddeKullanimYolu SKRSMaddeKullanimYolu
        {
            get { return (SKRSMaddeKullanimYolu)((ITTObject)this).GetParent("SKRSMADDEKULLANIMYOLU"); }
            set { this["SKRSMADDEKULLANIMYOLU"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MaddeBagimliligiVeriSeti MaddeBagimliligiVeriSeti
        {
            get { return (MaddeBagimliligiVeriSeti)((ITTObject)this).GetParent("MADDEBAGIMLILIGIVERISETI"); }
            set { this["MADDEBAGIMLILIGIVERISETI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MaddeBagimliligiKulMadde(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MaddeBagimliligiKulMadde(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MaddeBagimliligiKulMadde(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MaddeBagimliligiKulMadde(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MaddeBagimliligiKulMadde(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MADDEBAGIMLILIGIKULMADDE", dataRow) { }
        protected MaddeBagimliligiKulMadde(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MADDEBAGIMLILIGIKULMADDE", dataRow, isImported) { }
        public MaddeBagimliligiKulMadde(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MaddeBagimliligiKulMadde(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MaddeBagimliligiKulMadde() : base() { }

    }
}