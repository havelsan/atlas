
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="VeremHastalikTutumYeri")] 

    /// <summary>
    /// Verem Veri Seti
    /// </summary>
    public  partial class VeremHastalikTutumYeri : TTObject
    {
        public class VeremHastalikTutumYeriList : TTObjectCollection<VeremHastalikTutumYeri> { }
                    
        public class ChildVeremHastalikTutumYeriCollection : TTObject.TTChildObjectCollection<VeremHastalikTutumYeri>
        {
            public ChildVeremHastalikTutumYeriCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildVeremHastalikTutumYeriCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public SKRSVeremHastaligininTutulumYeri SKRSVeremHastaligiTutulumYeri
        {
            get { return (SKRSVeremHastaligininTutulumYeri)((ITTObject)this).GetParent("SKRSVEREMHASTALIGITUTULUMYERI"); }
            set { this["SKRSVEREMHASTALIGITUTULUMYERI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public VeremVeriSeti VeremVeriSeti
        {
            get { return (VeremVeriSeti)((ITTObject)this).GetParent("VEREMVERISETI"); }
            set { this["VEREMVERISETI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected VeremHastalikTutumYeri(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected VeremHastalikTutumYeri(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected VeremHastalikTutumYeri(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected VeremHastalikTutumYeri(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected VeremHastalikTutumYeri(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "VEREMHASTALIKTUTUMYERI", dataRow) { }
        protected VeremHastalikTutumYeri(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "VEREMHASTALIKTUTUMYERI", dataRow, isImported) { }
        public VeremHastalikTutumYeri(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public VeremHastalikTutumYeri(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public VeremHastalikTutumYeri() : base() { }

    }
}