
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TaniBilgisi_RaporDVO")] 

    public  partial class TaniBilgisi_RaporDVO : BaseMedulaObject
    {
        public class TaniBilgisi_RaporDVOList : TTObjectCollection<TaniBilgisi_RaporDVO> { }
                    
        public class ChildTaniBilgisi_RaporDVOCollection : TTObject.TTChildObjectCollection<TaniBilgisi_RaporDVO>
        {
            public ChildTaniBilgisi_RaporDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTaniBilgisi_RaporDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public string taniKodu
        {
            get { return (string)this["TANIKODU"]; }
            set { this["TANIKODU"] = value; }
        }

        public IsgoremezlikRaporEkDVO IsgoremezlikRaporEkDVO
        {
            get { return (IsgoremezlikRaporEkDVO)((ITTObject)this).GetParent("ISGOREMEZLIKRAPOREKDVO"); }
            set { this["ISGOREMEZLIKRAPOREKDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public RaporDVO RaporDVO
        {
            get { return (RaporDVO)((ITTObject)this).GetParent("RAPORDVO"); }
            set { this["RAPORDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public IlacRaporDuzeltDVO IlacRaporDuzeltDVO
        {
            get { return (IlacRaporDuzeltDVO)((ITTObject)this).GetParent("ILACRAPORDUZELTDVO"); }
            set { this["ILACRAPORDUZELTDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected TaniBilgisi_RaporDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TaniBilgisi_RaporDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TaniBilgisi_RaporDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TaniBilgisi_RaporDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TaniBilgisi_RaporDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TANIBILGISI_RAPORDVO", dataRow) { }
        protected TaniBilgisi_RaporDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TANIBILGISI_RAPORDVO", dataRow, isImported) { }
        public TaniBilgisi_RaporDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TaniBilgisi_RaporDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TaniBilgisi_RaporDVO() : base() { }

    }
}