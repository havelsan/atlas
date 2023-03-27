
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PsikolojikDurum")] 

    /// <summary>
    /// Psikolojik Durum Değerlendirmesi Bilgisi
    /// </summary>
    public  partial class PsikolojikDurum : TTObject
    {
        public class PsikolojikDurumList : TTObjectCollection<PsikolojikDurum> { }
                    
        public class ChildPsikolojikDurumCollection : TTObject.TTChildObjectCollection<PsikolojikDurum>
        {
            public ChildPsikolojikDurumCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPsikolojikDurumCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public EvdeSaglikIzlemVeriSeti EvdeSaglikIzlemVeriSeti
        {
            get { return (EvdeSaglikIzlemVeriSeti)((ITTObject)this).GetParent("EVDESAGLIKIZLEMVERISETI"); }
            set { this["EVDESAGLIKIZLEMVERISETI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public EvdeSaglikIlkIzlemVeriSeti EvdeSaglikIlkIzlemVeriSeti
        {
            get { return (EvdeSaglikIlkIzlemVeriSeti)((ITTObject)this).GetParent("EVDESAGLIKILKIZLEMVERISETI"); }
            set { this["EVDESAGLIKILKIZLEMVERISETI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSPsikolojikDurumDegerlendirmesi SKRSPsikolojikDurum
        {
            get { return (SKRSPsikolojikDurumDegerlendirmesi)((ITTObject)this).GetParent("SKRSPSIKOLOJIKDURUM"); }
            set { this["SKRSPSIKOLOJIKDURUM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PsikolojikDurum(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PsikolojikDurum(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PsikolojikDurum(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PsikolojikDurum(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PsikolojikDurum(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PSIKOLOJIKDURUM", dataRow) { }
        protected PsikolojikDurum(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PSIKOLOJIKDURUM", dataRow, isImported) { }
        public PsikolojikDurum(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PsikolojikDurum(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PsikolojikDurum() : base() { }

    }
}