
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="FaturaOkuCevapDVO")] 

    public  partial class FaturaOkuCevapDVO : BaseMedulaCevap
    {
        public class FaturaOkuCevapDVOList : TTObjectCollection<FaturaOkuCevapDVO> { }
                    
        public class ChildFaturaOkuCevapDVOCollection : TTObject.TTChildObjectCollection<FaturaOkuCevapDVO>
        {
            public ChildFaturaOkuCevapDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildFaturaOkuCevapDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Fatura Tarihi
    /// </summary>
        public string faturaTarihi
        {
            get { return (string)this["FATURATARIHI"]; }
            set { this["FATURATARIHI"] = value; }
        }

    /// <summary>
    /// Fatura tutarı
    /// </summary>
        public double? faturaTutari
        {
            get { return (double?)this["FATURATUTARI"]; }
            set { this["FATURATUTARI"] = value; }
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

        virtual protected void CreatefaturaDetaylariCollection()
        {
            _faturaDetaylari = new FaturaCevapDetayDVO.ChildFaturaCevapDetayDVOCollection(this, new Guid("6940d029-3412-41ca-ac2f-9353e6ab801b"));
            ((ITTChildObjectCollection)_faturaDetaylari).GetChildren();
        }

        protected FaturaCevapDetayDVO.ChildFaturaCevapDetayDVOCollection _faturaDetaylari = null;
    /// <summary>
    /// Child collection for Fatura Oku Cevap-faturaDetaylari
    /// </summary>
        public FaturaCevapDetayDVO.ChildFaturaCevapDetayDVOCollection faturaDetaylari
        {
            get
            {
                if (_faturaDetaylari == null)
                    CreatefaturaDetaylariCollection();
                return _faturaDetaylari;
            }
        }

        protected FaturaOkuCevapDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected FaturaOkuCevapDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected FaturaOkuCevapDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected FaturaOkuCevapDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected FaturaOkuCevapDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "FATURAOKUCEVAPDVO", dataRow) { }
        protected FaturaOkuCevapDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "FATURAOKUCEVAPDVO", dataRow, isImported) { }
        public FaturaOkuCevapDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public FaturaOkuCevapDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public FaturaOkuCevapDVO() : base() { }

    }
}