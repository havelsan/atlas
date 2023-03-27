
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HBYSDepoDurumEkle")] 

    /// <summary>
    /// Bu methot günde 1 kere akşam saatlerinde HBYSDepoEkleGuncelle  den sonra çalıştırılmalı.
    /// </summary>
    public  partial class HBYSDepoDurumEkle : BaseScheduledTask
    {
        public class HBYSDepoDurumEkleList : TTObjectCollection<HBYSDepoDurumEkle> { }
                    
        public class ChildHBYSDepoDurumEkleCollection : TTObject.TTChildObjectCollection<HBYSDepoDurumEkle>
        {
            public ChildHBYSDepoDurumEkleCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHBYSDepoDurumEkleCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected HBYSDepoDurumEkle(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HBYSDepoDurumEkle(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HBYSDepoDurumEkle(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HBYSDepoDurumEkle(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HBYSDepoDurumEkle(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HBYSDEPODURUMEKLE", dataRow) { }
        protected HBYSDepoDurumEkle(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HBYSDEPODURUMEKLE", dataRow, isImported) { }
        public HBYSDepoDurumEkle(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HBYSDepoDurumEkle(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HBYSDepoDurumEkle() : base() { }

    }
}