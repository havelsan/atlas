
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BasvuruYatisBilgileriDVO")] 

    public  partial class BasvuruYatisBilgileriDVO : BaseMedulaObject
    {
        public class BasvuruYatisBilgileriDVOList : TTObjectCollection<BasvuruYatisBilgileriDVO> { }
                    
        public class ChildBasvuruYatisBilgileriDVOCollection : TTObject.TTChildObjectCollection<BasvuruYatisBilgileriDVO>
        {
            public ChildBasvuruYatisBilgileriDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBasvuruYatisBilgileriDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Yatış Başlangıç Tarihi
    /// </summary>
        public string baslangicTarihi
        {
            get { return (string)this["BASLANGICTARIHI"]; }
            set { this["BASLANGICTARIHI"] = value; }
        }

    /// <summary>
    /// Yatış Bitiş Tarihi
    /// </summary>
        public string bitisTarihi
        {
            get { return (string)this["BITISTARIHI"]; }
            set { this["BITISTARIHI"] = value; }
        }

    /// <summary>
    /// Yatış Aralığının Faturalanma Durumu
    /// </summary>
        public string durum
        {
            get { return (string)this["DURUM"]; }
            set { this["DURUM"] = value; }
        }

        public HastaYatisOkuCevapDVO hastaYatisOkuCevapDVO
        {
            get { return (HastaYatisOkuCevapDVO)((ITTObject)this).GetParent("HASTAYATISOKUCEVAPDVO"); }
            set { this["HASTAYATISOKUCEVAPDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected BasvuruYatisBilgileriDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BasvuruYatisBilgileriDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BasvuruYatisBilgileriDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BasvuruYatisBilgileriDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BasvuruYatisBilgileriDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BASVURUYATISBILGILERIDVO", dataRow) { }
        protected BasvuruYatisBilgileriDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BASVURUYATISBILGILERIDVO", dataRow, isImported) { }
        public BasvuruYatisBilgileriDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BasvuruYatisBilgileriDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BasvuruYatisBilgileriDVO() : base() { }

    }
}