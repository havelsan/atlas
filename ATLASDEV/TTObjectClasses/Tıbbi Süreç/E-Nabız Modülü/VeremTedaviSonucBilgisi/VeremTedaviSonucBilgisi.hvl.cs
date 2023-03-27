
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="VeremTedaviSonucBilgisi")] 

    public  partial class VeremTedaviSonucBilgisi : TTObject
    {
        public class VeremTedaviSonucBilgisiList : TTObjectCollection<VeremTedaviSonucBilgisi> { }
                    
        public class ChildVeremTedaviSonucBilgisiCollection : TTObject.TTChildObjectCollection<VeremTedaviSonucBilgisi>
        {
            public ChildVeremTedaviSonucBilgisiCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildVeremTedaviSonucBilgisiCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public SKRSVeremTedaviSonucu SKRSVeremTedaviSonucu
        {
            get { return (SKRSVeremTedaviSonucu)((ITTObject)this).GetParent("SKRSVEREMTEDAVISONUCU"); }
            set { this["SKRSVEREMTEDAVISONUCU"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public VeremVeriSeti VeremVeriSeti
        {
            get { return (VeremVeriSeti)((ITTObject)this).GetParent("VEREMVERISETI"); }
            set { this["VEREMVERISETI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected VeremTedaviSonucBilgisi(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected VeremTedaviSonucBilgisi(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected VeremTedaviSonucBilgisi(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected VeremTedaviSonucBilgisi(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected VeremTedaviSonucBilgisi(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "VEREMTEDAVISONUCBILGISI", dataRow) { }
        protected VeremTedaviSonucBilgisi(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "VEREMTEDAVISONUCBILGISI", dataRow, isImported) { }
        public VeremTedaviSonucBilgisi(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public VeremTedaviSonucBilgisi(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public VeremTedaviSonucBilgisi() : base() { }

    }
}