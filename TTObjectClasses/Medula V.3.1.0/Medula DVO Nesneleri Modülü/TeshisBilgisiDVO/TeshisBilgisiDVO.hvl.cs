
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TeshisBilgisiDVO")] 

    public  partial class TeshisBilgisiDVO : BaseMedulaObject
    {
        public class TeshisBilgisiDVOList : TTObjectCollection<TeshisBilgisiDVO> { }
                    
        public class ChildTeshisBilgisiDVOCollection : TTObject.TTChildObjectCollection<TeshisBilgisiDVO>
        {
            public ChildTeshisBilgisiDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTeshisBilgisiDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public string baslangicTarihi
        {
            get { return (string)this["BASLANGICTARIHI"]; }
            set { this["BASLANGICTARIHI"] = value; }
        }

        public string bitisTarihi
        {
            get { return (string)this["BITISTARIHI"]; }
            set { this["BITISTARIHI"] = value; }
        }

        public int? teshisKodu
        {
            get { return (int?)this["TESHISKODU"]; }
            set { this["TESHISKODU"] = value; }
        }

        public RaporDVO RaporDVO
        {
            get { return (RaporDVO)((ITTObject)this).GetParent("RAPORDVO"); }
            set { this["RAPORDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected TeshisBilgisiDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TeshisBilgisiDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TeshisBilgisiDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TeshisBilgisiDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TeshisBilgisiDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TESHISBILGISIDVO", dataRow) { }
        protected TeshisBilgisiDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TESHISBILGISIDVO", dataRow, isImported) { }
        public TeshisBilgisiDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TeshisBilgisiDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TeshisBilgisiDVO() : base() { }

    }
}