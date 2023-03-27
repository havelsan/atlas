
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HastaYatisOkuDVO")] 

    public  partial class HastaYatisOkuDVO : BaseMedulaObject
    {
        public class HastaYatisOkuDVOList : TTObjectCollection<HastaYatisOkuDVO> { }
                    
        public class ChildHastaYatisOkuDVOCollection : TTObject.TTChildObjectCollection<HastaYatisOkuDVO>
        {
            public ChildHastaYatisOkuDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHastaYatisOkuDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Hastanın Başvuru Numarası
    /// </summary>
        public string hastaBasvuruNo
        {
            get { return (string)this["HASTABASVURUNO"]; }
            set { this["HASTABASVURUNO"] = value; }
        }

    /// <summary>
    /// Tesis Kodu
    /// </summary>
        public int? saglikTesisKodu
        {
            get { return (int?)this["SAGLIKTESISKODU"]; }
            set { this["SAGLIKTESISKODU"] = value; }
        }

        public HastaYatisOkuCevapDVO hastaYatisOkuCevapDVO
        {
            get { return (HastaYatisOkuCevapDVO)((ITTObject)this).GetParent("HASTAYATISOKUCEVAPDVO"); }
            set { this["HASTAYATISOKUCEVAPDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected HastaYatisOkuDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HastaYatisOkuDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HastaYatisOkuDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HastaYatisOkuDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HastaYatisOkuDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HASTAYATISOKUDVO", dataRow) { }
        protected HastaYatisOkuDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HASTAYATISOKUDVO", dataRow, isImported) { }
        public HastaYatisOkuDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HastaYatisOkuDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HastaYatisOkuDVO() : base() { }

    }
}