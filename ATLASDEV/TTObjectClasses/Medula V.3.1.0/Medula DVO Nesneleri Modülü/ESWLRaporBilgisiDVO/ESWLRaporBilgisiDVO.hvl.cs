
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ESWLRaporBilgisiDVO")] 

    public  partial class ESWLRaporBilgisiDVO : BaseMedulaObject
    {
        public class ESWLRaporBilgisiDVOList : TTObjectCollection<ESWLRaporBilgisiDVO> { }
                    
        public class ChildESWLRaporBilgisiDVOCollection : TTObject.TTChildObjectCollection<ESWLRaporBilgisiDVO>
        {
            public ChildESWLRaporBilgisiDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildESWLRaporBilgisiDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public string butKodu
        {
            get { return (string)this["BUTKODU"]; }
            set { this["BUTKODU"] = value; }
        }

        public int? eswlRaporuTasSayisi
        {
            get { return (int?)this["ESWLRAPORUTASSAYISI"]; }
            set { this["ESWLRAPORUTASSAYISI"] = value; }
        }

        public int? eswlRaporuSeansSayisi
        {
            get { return (int?)this["ESWLRAPORUSEANSSAYISI"]; }
            set { this["ESWLRAPORUSEANSSAYISI"] = value; }
        }

        public int? bobrekBilgisi
        {
            get { return (int?)this["BOBREKBILGISI"]; }
            set { this["BOBREKBILGISI"] = value; }
        }

        virtual protected void CreateeswlRaporuTasBilgileriCollection()
        {
            _eswlRaporuTasBilgileri = new ESWLTasBilgisiDVO.ChildESWLTasBilgisiDVOCollection(this, new Guid("22e09c89-df6f-4c3c-96c2-cfee712dd815"));
            ((ITTChildObjectCollection)_eswlRaporuTasBilgileri).GetChildren();
        }

        protected ESWLTasBilgisiDVO.ChildESWLTasBilgisiDVOCollection _eswlRaporuTasBilgileri = null;
        public ESWLTasBilgisiDVO.ChildESWLTasBilgisiDVOCollection eswlRaporuTasBilgileri
        {
            get
            {
                if (_eswlRaporuTasBilgileri == null)
                    CreateeswlRaporuTasBilgileriCollection();
                return _eswlRaporuTasBilgileri;
            }
        }

        protected ESWLRaporBilgisiDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ESWLRaporBilgisiDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ESWLRaporBilgisiDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ESWLRaporBilgisiDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ESWLRaporBilgisiDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ESWLRAPORBILGISIDVO", dataRow) { }
        protected ESWLRaporBilgisiDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ESWLRAPORBILGISIDVO", dataRow, isImported) { }
        public ESWLRaporBilgisiDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ESWLRaporBilgisiDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ESWLRaporBilgisiDVO() : base() { }

    }
}