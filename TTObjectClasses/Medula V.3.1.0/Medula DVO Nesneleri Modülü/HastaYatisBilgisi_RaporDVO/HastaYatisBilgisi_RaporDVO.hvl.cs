
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HastaYatisBilgisi_RaporDVO")] 

    public  partial class HastaYatisBilgisi_RaporDVO : BaseMedulaObject
    {
        public class HastaYatisBilgisi_RaporDVOList : TTObjectCollection<HastaYatisBilgisi_RaporDVO> { }
                    
        public class ChildHastaYatisBilgisi_RaporDVOCollection : TTObject.TTChildObjectCollection<HastaYatisBilgisi_RaporDVO>
        {
            public ChildHastaYatisBilgisi_RaporDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHastaYatisBilgisi_RaporDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public string yatisTarihi
        {
            get { return (string)this["YATISTARIHI"]; }
            set { this["YATISTARIHI"] = value; }
        }

        public string cikisTarihi
        {
            get { return (string)this["CIKISTARIHI"]; }
            set { this["CIKISTARIHI"] = value; }
        }

        public IsgoremezlikRaporEkDVO IsgoremezlikRaporEkDVO
        {
            get { return (IsgoremezlikRaporEkDVO)((ITTObject)this).GetParent("ISGOREMEZLIKRAPOREKDVO"); }
            set { this["ISGOREMEZLIKRAPOREKDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public IsgoremezlikRaporDVO IsgoremezlikRaporDVO
        {
            get { return (IsgoremezlikRaporDVO)((ITTObject)this).GetParent("ISGOREMEZLIKRAPORDVO"); }
            set { this["ISGOREMEZLIKRAPORDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected HastaYatisBilgisi_RaporDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HastaYatisBilgisi_RaporDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HastaYatisBilgisi_RaporDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HastaYatisBilgisi_RaporDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HastaYatisBilgisi_RaporDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HASTAYATISBILGISI_RAPORDVO", dataRow) { }
        protected HastaYatisBilgisi_RaporDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HASTAYATISBILGISI_RAPORDVO", dataRow, isImported) { }
        public HastaYatisBilgisi_RaporDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HastaYatisBilgisi_RaporDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HastaYatisBilgisi_RaporDVO() : base() { }

    }
}