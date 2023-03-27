
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HOTRaporBilgisiDVO")] 

    public  partial class HOTRaporBilgisiDVO : BaseMedulaObject
    {
        public class HOTRaporBilgisiDVOList : TTObjectCollection<HOTRaporBilgisiDVO> { }
                    
        public class ChildHOTRaporBilgisiDVOCollection : TTObject.TTChildObjectCollection<HOTRaporBilgisiDVO>
        {
            public ChildHOTRaporBilgisiDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHOTRaporBilgisiDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public int? seansGun
        {
            get { return (int?)this["SEANSGUN"]; }
            set { this["SEANSGUN"] = value; }
        }

        public int? seansSayi
        {
            get { return (int?)this["SEANSSAYI"]; }
            set { this["SEANSSAYI"] = value; }
        }

        public int? tedaviSuresi
        {
            get { return (int?)this["TEDAVISURESI"]; }
            set { this["TEDAVISURESI"] = value; }
        }

        protected HOTRaporBilgisiDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HOTRaporBilgisiDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HOTRaporBilgisiDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HOTRaporBilgisiDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HOTRaporBilgisiDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HOTRAPORBILGISIDVO", dataRow) { }
        protected HOTRaporBilgisiDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HOTRAPORBILGISIDVO", dataRow, isImported) { }
        public HOTRaporBilgisiDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HOTRaporBilgisiDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HOTRaporBilgisiDVO() : base() { }

    }
}