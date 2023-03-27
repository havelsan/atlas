
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="RaporBilgisiDVO")] 

    public  partial class RaporBilgisiDVO : BaseMedulaObject
    {
        public class RaporBilgisiDVOList : TTObjectCollection<RaporBilgisiDVO> { }
                    
        public class ChildRaporBilgisiDVOCollection : TTObject.TTChildObjectCollection<RaporBilgisiDVO>
        {
            public ChildRaporBilgisiDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildRaporBilgisiDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public int? raporTesisKodu
        {
            get { return (int?)this["RAPORTESISKODU"]; }
            set { this["RAPORTESISKODU"] = value; }
        }

        public string tarih
        {
            get { return (string)this["TARIH"]; }
            set { this["TARIH"] = value; }
        }

        public string no
        {
            get { return (string)this["NO"]; }
            set { this["NO"] = value; }
        }

        protected RaporBilgisiDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected RaporBilgisiDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected RaporBilgisiDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected RaporBilgisiDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected RaporBilgisiDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RAPORBILGISIDVO", dataRow) { }
        protected RaporBilgisiDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RAPORBILGISIDVO", dataRow, isImported) { }
        public RaporBilgisiDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public RaporBilgisiDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public RaporBilgisiDVO() : base() { }

    }
}