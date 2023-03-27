
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BasvuruTakipOkuCevapDVO")] 

    public  partial class BasvuruTakipOkuCevapDVO : BaseMedulaCevap
    {
        public class BasvuruTakipOkuCevapDVOList : TTObjectCollection<BasvuruTakipOkuCevapDVO> { }
                    
        public class ChildBasvuruTakipOkuCevapDVOCollection : TTObject.TTChildObjectCollection<BasvuruTakipOkuCevapDVO>
        {
            public ChildBasvuruTakipOkuCevapDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBasvuruTakipOkuCevapDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Hastanın Başvuru Numarası
    /// </summary>
        public string hastaBasvuruNo
        {
            get { return (string)this["HASTABASVURUNO"]; }
            set { this["HASTABASVURUNO"] = value; }
        }

        virtual protected void CreatebasvuruTakipCollection()
        {
            _basvuruTakip = new BasvuruTakipDVO.ChildBasvuruTakipDVOCollection(this, new Guid("18b77746-2e31-41e0-920b-14bf25b666e9"));
            ((ITTChildObjectCollection)_basvuruTakip).GetChildren();
        }

        protected BasvuruTakipDVO.ChildBasvuruTakipDVOCollection _basvuruTakip = null;
        public BasvuruTakipDVO.ChildBasvuruTakipDVOCollection basvuruTakip
        {
            get
            {
                if (_basvuruTakip == null)
                    CreatebasvuruTakipCollection();
                return _basvuruTakip;
            }
        }

        protected BasvuruTakipOkuCevapDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BasvuruTakipOkuCevapDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BasvuruTakipOkuCevapDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BasvuruTakipOkuCevapDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BasvuruTakipOkuCevapDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BASVURUTAKIPOKUCEVAPDVO", dataRow) { }
        protected BasvuruTakipOkuCevapDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BASVURUTAKIPOKUCEVAPDVO", dataRow, isImported) { }
        public BasvuruTakipOkuCevapDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BasvuruTakipOkuCevapDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BasvuruTakipOkuCevapDVO() : base() { }

    }
}