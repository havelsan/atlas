
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="FaturaIptalHataliKayitDVO")] 

    public  partial class FaturaIptalHataliKayitDVO : BaseMedulaObject
    {
        public class FaturaIptalHataliKayitDVOList : TTObjectCollection<FaturaIptalHataliKayitDVO> { }
                    
        public class ChildFaturaIptalHataliKayitDVOCollection : TTObject.TTChildObjectCollection<FaturaIptalHataliKayitDVO>
        {
            public ChildFaturaIptalHataliKayitDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildFaturaIptalHataliKayitDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Fatura Teslim Numarası
    /// </summary>
        public string faturaTeslimNo
        {
            get { return (string)this["FATURATESLIMNO"]; }
            set { this["FATURATESLIMNO"] = value; }
        }

    /// <summary>
    /// Hata Mesajı
    /// </summary>
        public string hataMesaji
        {
            get { return (string)this["HATAMESAJI"]; }
            set { this["HATAMESAJI"] = value; }
        }

    /// <summary>
    /// Hata Kodu
    /// </summary>
        public string hataKodu
        {
            get { return (string)this["HATAKODU"]; }
            set { this["HATAKODU"] = value; }
        }

    /// <summary>
    /// Fatura İptal Cevap-Hatalı Kayıtlar
    /// </summary>
        public FaturaIptalCevapDVO FaturaIptalCevapDVO
        {
            get { return (FaturaIptalCevapDVO)((ITTObject)this).GetParent("FATURAIPTALCEVAPDVO"); }
            set { this["FATURAIPTALCEVAPDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected FaturaIptalHataliKayitDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected FaturaIptalHataliKayitDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected FaturaIptalHataliKayitDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected FaturaIptalHataliKayitDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected FaturaIptalHataliKayitDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "FATURAIPTALHATALIKAYITDVO", dataRow) { }
        protected FaturaIptalHataliKayitDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "FATURAIPTALHATALIKAYITDVO", dataRow, isImported) { }
        public FaturaIptalHataliKayitDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public FaturaIptalHataliKayitDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public FaturaIptalHataliKayitDVO() : base() { }

    }
}