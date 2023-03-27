
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DoktorBilgisiDVO")] 

    public  partial class DoktorBilgisiDVO : BaseMedulaObject
    {
        public class DoktorBilgisiDVOList : TTObjectCollection<DoktorBilgisiDVO> { }
                    
        public class ChildDoktorBilgisiDVOCollection : TTObject.TTChildObjectCollection<DoktorBilgisiDVO>
        {
            public ChildDoktorBilgisiDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDoktorBilgisiDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public string drTescilNo
        {
            get { return (string)this["DRTESCILNO"]; }
            set { this["DRTESCILNO"] = value; }
        }

        public string drAdi
        {
            get { return (string)this["DRADI"]; }
            set { this["DRADI"] = value; }
        }

        public string drSoyadi
        {
            get { return (string)this["DRSOYADI"]; }
            set { this["DRSOYADI"] = value; }
        }

        public string drBransKodu
        {
            get { return (string)this["DRBRANSKODU"]; }
            set { this["DRBRANSKODU"] = value; }
        }

        public string tipi
        {
            get { return (string)this["TIPI"]; }
            set { this["TIPI"] = value; }
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

        protected DoktorBilgisiDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DoktorBilgisiDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DoktorBilgisiDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DoktorBilgisiDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DoktorBilgisiDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DOKTORBILGISIDVO", dataRow) { }
        protected DoktorBilgisiDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DOKTORBILGISIDVO", dataRow, isImported) { }
        public DoktorBilgisiDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DoktorBilgisiDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DoktorBilgisiDVO() : base() { }

    }
}