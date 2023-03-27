
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="RaporOkuDVO")] 

    public  partial class RaporOkuDVO : BaseMedulaObject
    {
        public class RaporOkuDVOList : TTObjectCollection<RaporOkuDVO> { }
                    
        public class ChildRaporOkuDVOCollection : TTObject.TTChildObjectCollection<RaporOkuDVO>
        {
            public ChildRaporOkuDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildRaporOkuDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public int? raporTesisKodu
        {
            get { return (int?)this["RAPORTESISKODU"]; }
            set { this["RAPORTESISKODU"] = value; }
        }

        public string no
        {
            get { return (string)this["NO"]; }
            set { this["NO"] = value; }
        }

        public string tarih
        {
            get { return (string)this["TARIH"]; }
            set { this["TARIH"] = value; }
        }

        public string turu
        {
            get { return (string)this["TURU"]; }
            set { this["TURU"] = value; }
        }

        protected RaporOkuDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected RaporOkuDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected RaporOkuDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected RaporOkuDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected RaporOkuDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RAPOROKUDVO", dataRow) { }
        protected RaporOkuDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RAPOROKUDVO", dataRow, isImported) { }
        public RaporOkuDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public RaporOkuDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public RaporOkuDVO() : base() { }

    }
}