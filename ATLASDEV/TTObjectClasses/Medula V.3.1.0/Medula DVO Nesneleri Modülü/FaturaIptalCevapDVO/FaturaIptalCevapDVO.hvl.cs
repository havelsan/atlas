
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="FaturaIptalCevapDVO")] 

    public  partial class FaturaIptalCevapDVO : BaseMedulaCevap
    {
        public class FaturaIptalCevapDVOList : TTObjectCollection<FaturaIptalCevapDVO> { }
                    
        public class ChildFaturaIptalCevapDVOCollection : TTObject.TTChildObjectCollection<FaturaIptalCevapDVO>
        {
            public ChildFaturaIptalCevapDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildFaturaIptalCevapDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        virtual protected void CreatehataliKayitlarCollection()
        {
            _hataliKayitlar = new FaturaIptalHataliKayitDVO.ChildFaturaIptalHataliKayitDVOCollection(this, new Guid("e8355bf8-7f07-4b97-adae-d16f13198a3c"));
            ((ITTChildObjectCollection)_hataliKayitlar).GetChildren();
        }

        protected FaturaIptalHataliKayitDVO.ChildFaturaIptalHataliKayitDVOCollection _hataliKayitlar = null;
    /// <summary>
    /// Child collection for Fatura İptal Cevap-Hatalı Kayıtlar
    /// </summary>
        public FaturaIptalHataliKayitDVO.ChildFaturaIptalHataliKayitDVOCollection hataliKayitlar
        {
            get
            {
                if (_hataliKayitlar == null)
                    CreatehataliKayitlarCollection();
                return _hataliKayitlar;
            }
        }

        protected FaturaIptalCevapDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected FaturaIptalCevapDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected FaturaIptalCevapDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected FaturaIptalCevapDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected FaturaIptalCevapDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "FATURAIPTALCEVAPDVO", dataRow) { }
        protected FaturaIptalCevapDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "FATURAIPTALCEVAPDVO", dataRow, isImported) { }
        public FaturaIptalCevapDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public FaturaIptalCevapDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public FaturaIptalCevapDVO() : base() { }

    }
}