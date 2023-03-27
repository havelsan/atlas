
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="FaturaCevapDVO")] 

    public  partial class FaturaCevapDVO : BaseMedulaCevap
    {
        public class FaturaCevapDVOList : TTObjectCollection<FaturaCevapDVO> { }
                    
        public class ChildFaturaCevapDVOCollection : TTObject.TTChildObjectCollection<FaturaCevapDVO>
        {
            public ChildFaturaCevapDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildFaturaCevapDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Faturanın Referans No
    /// </summary>
        public string faturaRefNo
        {
            get { return (string)this["FATURAREFNO"]; }
            set { this["FATURAREFNO"] = value; }
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
    /// Fatura Tutarı
    /// </summary>
        public double? faturaTutari
        {
            get { return (double?)this["FATURATUTARI"]; }
            set { this["FATURATUTARI"] = value; }
        }

    /// <summary>
    /// Hastanın Başvuru Numarası
    /// </summary>
        public string hastaBasvuruNo
        {
            get { return (string)this["HASTABASVURUNO"]; }
            set { this["HASTABASVURUNO"] = value; }
        }

        virtual protected void CreatehataliKayitlarCollection()
        {
            _hataliKayitlar = new FaturaHataDVO.ChildFaturaHataDVOCollection(this, new Guid("b80d27b3-e9a2-4af8-964c-889dfdd91951"));
            ((ITTChildObjectCollection)_hataliKayitlar).GetChildren();
        }

        protected FaturaHataDVO.ChildFaturaHataDVOCollection _hataliKayitlar = null;
    /// <summary>
    /// Child collection for Fatura Cevap-Hatalı Kayıtlar
    /// </summary>
        public FaturaHataDVO.ChildFaturaHataDVOCollection hataliKayitlar
        {
            get
            {
                if (_hataliKayitlar == null)
                    CreatehataliKayitlarCollection();
                return _hataliKayitlar;
            }
        }

        virtual protected void CreatefaturaDetaylariCollection()
        {
            _faturaDetaylari = new FaturaDetayDVO.ChildFaturaDetayDVOCollection(this, new Guid("8e6152fd-6735-442a-a915-39ba8b671ffd"));
            ((ITTChildObjectCollection)_faturaDetaylari).GetChildren();
        }

        protected FaturaDetayDVO.ChildFaturaDetayDVOCollection _faturaDetaylari = null;
    /// <summary>
    /// Child collection for Fatura Cevap-Fatura Detayları
    /// </summary>
        public FaturaDetayDVO.ChildFaturaDetayDVOCollection faturaDetaylari
        {
            get
            {
                if (_faturaDetaylari == null)
                    CreatefaturaDetaylariCollection();
                return _faturaDetaylari;
            }
        }

        protected FaturaCevapDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected FaturaCevapDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected FaturaCevapDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected FaturaCevapDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected FaturaCevapDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "FATURACEVAPDVO", dataRow) { }
        protected FaturaCevapDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "FATURACEVAPDVO", dataRow, isImported) { }
        public FaturaCevapDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public FaturaCevapDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public FaturaCevapDVO() : base() { }

    }
}