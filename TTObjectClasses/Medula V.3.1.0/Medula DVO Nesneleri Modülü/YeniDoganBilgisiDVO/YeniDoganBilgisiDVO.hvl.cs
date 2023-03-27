
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="YeniDoganBilgisiDVO")] 

    public  partial class YeniDoganBilgisiDVO : BaseMedulaObject
    {
        public class YeniDoganBilgisiDVOList : TTObjectCollection<YeniDoganBilgisiDVO> { }
                    
        public class ChildYeniDoganBilgisiDVOCollection : TTObject.TTChildObjectCollection<YeniDoganBilgisiDVO>
        {
            public ChildYeniDoganBilgisiDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildYeniDoganBilgisiDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Bebeğin Doğum Tarihi
    /// </summary>
        public string dogumTarihi
        {
            get { return (string)this["DOGUMTARIHI"]; }
            set { this["DOGUMTARIHI"] = value; }
        }

    /// <summary>
    /// Bebeğin sıra numarası
    /// </summary>
        public int? cocukSira
        {
            get { return (int?)this["COCUKSIRA"]; }
            set { this["COCUKSIRA"] = value; }
        }

        protected YeniDoganBilgisiDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected YeniDoganBilgisiDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected YeniDoganBilgisiDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected YeniDoganBilgisiDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected YeniDoganBilgisiDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "YENIDOGANBILGISIDVO", dataRow) { }
        protected YeniDoganBilgisiDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "YENIDOGANBILGISIDVO", dataRow, isImported) { }
        public YeniDoganBilgisiDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public YeniDoganBilgisiDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public YeniDoganBilgisiDVO() : base() { }

    }
}