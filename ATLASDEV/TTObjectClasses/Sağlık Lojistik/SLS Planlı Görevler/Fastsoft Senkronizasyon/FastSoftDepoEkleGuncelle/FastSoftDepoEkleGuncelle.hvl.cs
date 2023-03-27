
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="FastSoftDepoEkleGuncelle")] 

    /// <summary>
    /// Bu methot günde 1 kere akşam saatlerinde çalıştırılmalı
    /// </summary>
    public  partial class FastSoftDepoEkleGuncelle : BaseScheduledTask
    {
        public class FastSoftDepoEkleGuncelleList : TTObjectCollection<FastSoftDepoEkleGuncelle> { }
                    
        public class ChildFastSoftDepoEkleGuncelleCollection : TTObject.TTChildObjectCollection<FastSoftDepoEkleGuncelle>
        {
            public ChildFastSoftDepoEkleGuncelleCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildFastSoftDepoEkleGuncelleCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected FastSoftDepoEkleGuncelle(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected FastSoftDepoEkleGuncelle(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected FastSoftDepoEkleGuncelle(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected FastSoftDepoEkleGuncelle(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected FastSoftDepoEkleGuncelle(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "FASTSOFTDEPOEKLEGUNCELLE", dataRow) { }
        protected FastSoftDepoEkleGuncelle(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "FASTSOFTDEPOEKLEGUNCELLE", dataRow, isImported) { }
        public FastSoftDepoEkleGuncelle(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public FastSoftDepoEkleGuncelle(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public FastSoftDepoEkleGuncelle() : base() { }

    }
}