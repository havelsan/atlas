
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TedaviRaporDVO")] 

    public  partial class TedaviRaporDVO : BaseMedulaObject
    {
        public class TedaviRaporDVOList : TTObjectCollection<TedaviRaporDVO> { }
                    
        public class ChildTedaviRaporDVOCollection : TTObject.TTChildObjectCollection<TedaviRaporDVO>
        {
            public ChildTedaviRaporDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTedaviRaporDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public int? tedaviRaporTuru
        {
            get { return (int?)this["TEDAVIRAPORTURU"]; }
            set { this["TEDAVIRAPORTURU"] = value; }
        }

        public RaporDVO raporDVO
        {
            get { return (RaporDVO)((ITTObject)this).GetParent("RAPORDVO"); }
            set { this["RAPORDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateislemlerCollection()
        {
            _islemler = new TedaviIslemBilgisiDVO.ChildTedaviIslemBilgisiDVOCollection(this, new Guid("c1baa3b2-bedb-48ff-ad5e-6e284ae6f05a"));
            ((ITTChildObjectCollection)_islemler).GetChildren();
        }

        protected TedaviIslemBilgisiDVO.ChildTedaviIslemBilgisiDVOCollection _islemler = null;
        public TedaviIslemBilgisiDVO.ChildTedaviIslemBilgisiDVOCollection islemler
        {
            get
            {
                if (_islemler == null)
                    CreateislemlerCollection();
                return _islemler;
            }
        }

        protected TedaviRaporDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TedaviRaporDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TedaviRaporDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TedaviRaporDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TedaviRaporDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TEDAVIRAPORDVO", dataRow) { }
        protected TedaviRaporDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TEDAVIRAPORDVO", dataRow, isImported) { }
        public TedaviRaporDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TedaviRaporDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TedaviRaporDVO() : base() { }

    }
}