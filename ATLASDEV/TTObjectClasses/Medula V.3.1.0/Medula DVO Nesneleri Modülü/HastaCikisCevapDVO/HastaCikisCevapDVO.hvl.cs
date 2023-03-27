
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HastaCikisCevapDVO")] 

    public  partial class HastaCikisCevapDVO : BaseMedulaCevap
    {
        public class HastaCikisCevapDVOList : TTObjectCollection<HastaCikisCevapDVO> { }
                    
        public class ChildHastaCikisCevapDVOCollection : TTObject.TTChildObjectCollection<HastaCikisCevapDVO>
        {
            public ChildHastaCikisCevapDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHastaCikisCevapDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Yatış Başlangıç Tarihi
    /// </summary>
        public string yatisBaslangicTarihi
        {
            get { return (string)this["YATISBASLANGICTARIHI"]; }
            set { this["YATISBASLANGICTARIHI"] = value; }
        }

    /// <summary>
    /// Yatış Bitiş Tarihi
    /// </summary>
        public string yatisBitisTarihi
        {
            get { return (string)this["YATISBITISTARIHI"]; }
            set { this["YATISBITISTARIHI"] = value; }
        }

        protected HastaCikisCevapDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HastaCikisCevapDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HastaCikisCevapDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HastaCikisCevapDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HastaCikisCevapDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HASTACIKISCEVAPDVO", dataRow) { }
        protected HastaCikisCevapDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HASTACIKISCEVAPDVO", dataRow, isImported) { }
        public HastaCikisCevapDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HastaCikisCevapDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HastaCikisCevapDVO() : base() { }

    }
}