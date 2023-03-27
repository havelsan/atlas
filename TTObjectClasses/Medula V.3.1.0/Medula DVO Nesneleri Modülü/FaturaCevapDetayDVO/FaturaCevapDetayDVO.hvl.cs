
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="FaturaCevapDetayDVO")] 

    public  partial class FaturaCevapDetayDVO : BaseMedulaObject
    {
        public class FaturaCevapDetayDVOList : TTObjectCollection<FaturaCevapDetayDVO> { }
                    
        public class ChildFaturaCevapDetayDVOCollection : TTObject.TTChildObjectCollection<FaturaCevapDetayDVO>
        {
            public ChildFaturaCevapDetayDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildFaturaCevapDetayDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Taburcu Kodu
    /// </summary>
        public string taburcuKodu
        {
            get { return (string)this["TABURCUKODU"]; }
            set { this["TABURCUKODU"] = value; }
        }

    /// <summary>
    /// Takip Numarası
    /// </summary>
        public string takipNo
        {
            get { return (string)this["TAKIPNO"]; }
            set { this["TAKIPNO"] = value; }
        }

    /// <summary>
    /// Takip Toplam Tutarı
    /// </summary>
        public double? takipToplamTutar
        {
            get { return (double?)this["TAKIPTOPLAMTUTAR"]; }
            set { this["TAKIPTOPLAMTUTAR"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string aciklama
        {
            get { return (string)this["ACIKLAMA"]; }
            set { this["ACIKLAMA"] = value; }
        }

    /// <summary>
    /// Protokol Numarası
    /// </summary>
        public string protokolNo
        {
            get { return (string)this["PROTOKOLNO"]; }
            set { this["PROTOKOLNO"] = value; }
        }

    /// <summary>
    /// Fatura Oku Cevap-faturaDetaylari
    /// </summary>
        public FaturaOkuCevapDVO FaturaOkuCevapDVO
        {
            get { return (FaturaOkuCevapDVO)((ITTObject)this).GetParent("FATURAOKUCEVAPDVO"); }
            set { this["FATURAOKUCEVAPDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateislemDetaylariCollection()
        {
            _islemDetaylari = new IslemDetayDVO.ChildIslemDetayDVOCollection(this, new Guid("6a9b5f1d-2390-4ee6-8526-2486a5ebe54d"));
            ((ITTChildObjectCollection)_islemDetaylari).GetChildren();
        }

        protected IslemDetayDVO.ChildIslemDetayDVOCollection _islemDetaylari = null;
    /// <summary>
    /// Child collection for Fatura Cevap Detay-İşlem Detayları
    /// </summary>
        public IslemDetayDVO.ChildIslemDetayDVOCollection islemDetaylari
        {
            get
            {
                if (_islemDetaylari == null)
                    CreateislemDetaylariCollection();
                return _islemDetaylari;
            }
        }

        protected FaturaCevapDetayDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected FaturaCevapDetayDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected FaturaCevapDetayDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected FaturaCevapDetayDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected FaturaCevapDetayDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "FATURACEVAPDETAYDVO", dataRow) { }
        protected FaturaCevapDetayDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "FATURACEVAPDETAYDVO", dataRow, isImported) { }
        public FaturaCevapDetayDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public FaturaCevapDetayDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public FaturaCevapDetayDVO() : base() { }

    }
}