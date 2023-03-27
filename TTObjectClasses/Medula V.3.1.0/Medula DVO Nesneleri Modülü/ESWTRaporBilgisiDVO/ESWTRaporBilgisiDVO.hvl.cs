
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ESWTRaporBilgisiDVO")] 

    public  partial class ESWTRaporBilgisiDVO : BaseMedulaObject
    {
        public class ESWTRaporBilgisiDVOList : TTObjectCollection<ESWTRaporBilgisiDVO> { }
                    
        public class ChildESWTRaporBilgisiDVOCollection : TTObject.TTChildObjectCollection<ESWTRaporBilgisiDVO>
        {
            public ChildESWTRaporBilgisiDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildESWTRaporBilgisiDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public int? seansSayi
        {
            get { return (int?)this["SEANSSAYI"]; }
            set { this["SEANSSAYI"] = value; }
        }

        public int? eswtVucutBolgesiKodu
        {
            get { return (int?)this["ESWTVUCUTBOLGESIKODU"]; }
            set { this["ESWTVUCUTBOLGESIKODU"] = value; }
        }

        public int? seansGun
        {
            get { return (int?)this["SEANSGUN"]; }
            set { this["SEANSGUN"] = value; }
        }

        public string butKodu
        {
            get { return (string)this["BUTKODU"]; }
            set { this["BUTKODU"] = value; }
        }

        protected ESWTRaporBilgisiDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ESWTRaporBilgisiDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ESWTRaporBilgisiDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ESWTRaporBilgisiDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ESWTRaporBilgisiDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ESWTRAPORBILGISIDVO", dataRow) { }
        protected ESWTRaporBilgisiDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ESWTRAPORBILGISIDVO", dataRow, isImported) { }
        public ESWTRaporBilgisiDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ESWTRaporBilgisiDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ESWTRaporBilgisiDVO() : base() { }

    }
}