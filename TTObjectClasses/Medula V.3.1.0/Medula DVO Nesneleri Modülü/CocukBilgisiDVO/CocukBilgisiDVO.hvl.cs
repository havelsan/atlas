
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CocukBilgisiDVO")] 

    public  partial class CocukBilgisiDVO : BaseMedulaObject
    {
        public class CocukBilgisiDVOList : TTObjectCollection<CocukBilgisiDVO> { }
                    
        public class ChildCocukBilgisiDVOCollection : TTObject.TTChildObjectCollection<CocukBilgisiDVO>
        {
            public ChildCocukBilgisiDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCocukBilgisiDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public string cinsiyet
        {
            get { return (string)this["CINSIYET"]; }
            set { this["CINSIYET"] = value; }
        }

        public string kilo
        {
            get { return (string)this["KILO"]; }
            set { this["KILO"] = value; }
        }

        public string dogumSaati
        {
            get { return (string)this["DOGUMSAATI"]; }
            set { this["DOGUMSAATI"] = value; }
        }

        public DogumRaporDVO DogumRaporDVO
        {
            get { return (DogumRaporDVO)((ITTObject)this).GetParent("DOGUMRAPORDVO"); }
            set { this["DOGUMRAPORDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected CocukBilgisiDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CocukBilgisiDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CocukBilgisiDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CocukBilgisiDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CocukBilgisiDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "COCUKBILGISIDVO", dataRow) { }
        protected CocukBilgisiDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "COCUKBILGISIDVO", dataRow, isImported) { }
        public CocukBilgisiDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CocukBilgisiDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CocukBilgisiDVO() : base() { }

    }
}