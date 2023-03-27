
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="FaturaDetayDVO")] 

    public  partial class FaturaDetayDVO : BaseMedulaObject
    {
        public class FaturaDetayDVOList : TTObjectCollection<FaturaDetayDVO> { }
                    
        public class ChildFaturaDetayDVOCollection : TTObject.TTChildObjectCollection<FaturaDetayDVO>
        {
            public ChildFaturaDetayDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildFaturaDetayDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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
    /// Takip Toplam Tutar
    /// </summary>
        public double? takipToplamTutar
        {
            get { return (double?)this["TAKIPTOPLAMTUTAR"]; }
            set { this["TAKIPTOPLAMTUTAR"] = value; }
        }

    /// <summary>
    /// Fatura Cevap-Fatura Detayları
    /// </summary>
        public FaturaCevapDVO FaturaCevapDVO
        {
            get { return (FaturaCevapDVO)((ITTObject)this).GetParent("FATURACEVAPDVO"); }
            set { this["FATURACEVAPDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateislemDetaylariCollection()
        {
            _islemDetaylari = new IslemDetayDVO.ChildIslemDetayDVOCollection(this, new Guid("0b14fe50-f9dd-47b8-868d-ee627391b91e"));
            ((ITTChildObjectCollection)_islemDetaylari).GetChildren();
        }

        protected IslemDetayDVO.ChildIslemDetayDVOCollection _islemDetaylari = null;
    /// <summary>
    /// Child collection for Fatura Detay-İşlem Detayları
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

        protected FaturaDetayDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected FaturaDetayDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected FaturaDetayDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected FaturaDetayDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected FaturaDetayDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "FATURADETAYDVO", dataRow) { }
        protected FaturaDetayDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "FATURADETAYDVO", dataRow, isImported) { }
        public FaturaDetayDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public FaturaDetayDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public FaturaDetayDVO() : base() { }

    }
}