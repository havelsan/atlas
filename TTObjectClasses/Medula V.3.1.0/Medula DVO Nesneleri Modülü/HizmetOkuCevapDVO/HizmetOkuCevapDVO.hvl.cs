
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HizmetOkuCevapDVO")] 

    public  partial class HizmetOkuCevapDVO : BaseMedulaCevap
    {
        public class HizmetOkuCevapDVOList : TTObjectCollection<HizmetOkuCevapDVO> { }
                    
        public class ChildHizmetOkuCevapDVOCollection : TTObject.TTChildObjectCollection<HizmetOkuCevapDVO>
        {
            public ChildHizmetOkuCevapDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHizmetOkuCevapDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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
    /// Hizmetler
    /// </summary>
        public HizmetDVO hizmetler
        {
            get { return (HizmetDVO)((ITTObject)this).GetParent("HIZMETLER"); }
            set { this["HIZMETLER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected HizmetOkuCevapDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HizmetOkuCevapDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HizmetOkuCevapDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HizmetOkuCevapDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HizmetOkuCevapDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HIZMETOKUCEVAPDVO", dataRow) { }
        protected HizmetOkuCevapDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HIZMETOKUCEVAPDVO", dataRow, isImported) { }
        public HizmetOkuCevapDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HizmetOkuCevapDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HizmetOkuCevapDVO() : base() { }

    }
}