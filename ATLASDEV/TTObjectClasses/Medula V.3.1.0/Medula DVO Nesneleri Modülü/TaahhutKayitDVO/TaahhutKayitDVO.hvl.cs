
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TaahhutKayitDVO")] 

    public  partial class TaahhutKayitDVO : BaseMedulaObject
    {
        public class TaahhutKayitDVOList : TTObjectCollection<TaahhutKayitDVO> { }
                    
        public class ChildTaahhutKayitDVOCollection : TTObject.TTChildObjectCollection<TaahhutKayitDVO>
        {
            public ChildTaahhutKayitDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTaahhutKayitDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public int? saglikTesisKodu
        {
            get { return (int?)this["SAGLIKTESISKODU"]; }
            set { this["SAGLIKTESISKODU"] = value; }
        }

        public string takipNo
        {
            get { return (string)this["TAKIPNO"]; }
            set { this["TAKIPNO"] = value; }
        }

        public TaahhutCevapDVO taahhutCevapDVO
        {
            get { return (TaahhutCevapDVO)((ITTObject)this).GetParent("TAAHHUTCEVAPDVO"); }
            set { this["TAAHHUTCEVAPDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public TaahhutDVO taahhut
        {
            get { return (TaahhutDVO)((ITTObject)this).GetParent("TAAHHUT"); }
            set { this["TAAHHUT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreatetaahhutDissCollection()
        {
            _taahhutDiss = new TaahhutDisDVO.ChildTaahhutDisDVOCollection(this, new Guid("11212615-ddaa-41e9-a390-3a53665a4f8d"));
            ((ITTChildObjectCollection)_taahhutDiss).GetChildren();
        }

        protected TaahhutDisDVO.ChildTaahhutDisDVOCollection _taahhutDiss = null;
        public TaahhutDisDVO.ChildTaahhutDisDVOCollection taahhutDiss
        {
            get
            {
                if (_taahhutDiss == null)
                    CreatetaahhutDissCollection();
                return _taahhutDiss;
            }
        }

        protected TaahhutKayitDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TaahhutKayitDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TaahhutKayitDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TaahhutKayitDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TaahhutKayitDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TAAHHUTKAYITDVO", dataRow) { }
        protected TaahhutKayitDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TAAHHUTKAYITDVO", dataRow, isImported) { }
        public TaahhutKayitDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TaahhutKayitDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TaahhutKayitDVO() : base() { }

    }
}