
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TedaviIslemBilgisiDVO")] 

    public  partial class TedaviIslemBilgisiDVO : BaseMedulaObject
    {
        public class TedaviIslemBilgisiDVOList : TTObjectCollection<TedaviIslemBilgisiDVO> { }
                    
        public class ChildTedaviIslemBilgisiDVOCollection : TTObject.TTChildObjectCollection<TedaviIslemBilgisiDVO>
        {
            public ChildTedaviIslemBilgisiDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTedaviIslemBilgisiDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public DiyalizRaporBilgisiDVO diyalizRaporBilgisi
        {
            get { return (DiyalizRaporBilgisiDVO)((ITTObject)this).GetParent("DIYALIZRAPORBILGISI"); }
            set { this["DIYALIZRAPORBILGISI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ESWLRaporBilgisiDVO eswlRaporBilgisi
        {
            get { return (ESWLRaporBilgisiDVO)((ITTObject)this).GetParent("ESWLRAPORBILGISI"); }
            set { this["ESWLRAPORBILGISI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ESWTRaporBilgisiDVO eswtRaporBilgisi
        {
            get { return (ESWTRaporBilgisiDVO)((ITTObject)this).GetParent("ESWTRAPORBILGISI"); }
            set { this["ESWTRAPORBILGISI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public FTRRaporBilgisiDVO ftrRaporBilgisi
        {
            get { return (FTRRaporBilgisiDVO)((ITTObject)this).GetParent("FTRRAPORBILGISI"); }
            set { this["FTRRAPORBILGISI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public HOTRaporBilgisiDVO hotRaporBilgisi
        {
            get { return (HOTRaporBilgisiDVO)((ITTObject)this).GetParent("HOTRAPORBILGISI"); }
            set { this["HOTRAPORBILGISI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public TupBebekRaporBilgisiDVO tupBebekRaporBilgisi
        {
            get { return (TupBebekRaporBilgisiDVO)((ITTObject)this).GetParent("TUPBEBEKRAPORBILGISI"); }
            set { this["TUPBEBEKRAPORBILGISI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public TedaviRaporDVO TedaviRaporDVO
        {
            get { return (TedaviRaporDVO)((ITTObject)this).GetParent("TEDAVIRAPORDVO"); }
            set { this["TEDAVIRAPORDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected TedaviIslemBilgisiDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TedaviIslemBilgisiDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TedaviIslemBilgisiDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TedaviIslemBilgisiDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TedaviIslemBilgisiDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TEDAVIISLEMBILGISIDVO", dataRow) { }
        protected TedaviIslemBilgisiDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TEDAVIISLEMBILGISIDVO", dataRow, isImported) { }
        public TedaviIslemBilgisiDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TedaviIslemBilgisiDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TedaviIslemBilgisiDVO() : base() { }

    }
}