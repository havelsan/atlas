
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MaddeBagimBulasiciHastalik")] 

    /// <summary>
    /// Madde Bağımlılığı Veri Seti Bulaşıcı Hastalık Durumu Bilgisi
    /// </summary>
    public  partial class MaddeBagimBulasiciHastalik : TTObject
    {
        public class MaddeBagimBulasiciHastalikList : TTObjectCollection<MaddeBagimBulasiciHastalik> { }
                    
        public class ChildMaddeBagimBulasiciHastalikCollection : TTObject.TTChildObjectCollection<MaddeBagimBulasiciHastalik>
        {
            public ChildMaddeBagimBulasiciHastalikCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMaddeBagimBulasiciHastalikCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public SKRSBulasiciHastalikDurumu SKRSBulasiciHastalikDurumu
        {
            get { return (SKRSBulasiciHastalikDurumu)((ITTObject)this).GetParent("SKRSBULASICIHASTALIKDURUMU"); }
            set { this["SKRSBULASICIHASTALIKDURUMU"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MaddeBagimliligiVeriSeti MaddeBagimliligiVeriSeti
        {
            get { return (MaddeBagimliligiVeriSeti)((ITTObject)this).GetParent("MADDEBAGIMLILIGIVERISETI"); }
            set { this["MADDEBAGIMLILIGIVERISETI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MaddeBagimBulasiciHastalik(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MaddeBagimBulasiciHastalik(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MaddeBagimBulasiciHastalik(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MaddeBagimBulasiciHastalik(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MaddeBagimBulasiciHastalik(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MADDEBAGIMBULASICIHASTALIK", dataRow) { }
        protected MaddeBagimBulasiciHastalik(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MADDEBAGIMBULASICIHASTALIK", dataRow, isImported) { }
        public MaddeBagimBulasiciHastalik(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MaddeBagimBulasiciHastalik(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MaddeBagimBulasiciHastalik() : base() { }

    }
}