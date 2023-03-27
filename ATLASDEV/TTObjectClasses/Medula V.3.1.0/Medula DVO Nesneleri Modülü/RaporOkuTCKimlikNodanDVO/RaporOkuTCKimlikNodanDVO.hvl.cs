
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="RaporOkuTCKimlikNodanDVO")] 

    public  partial class RaporOkuTCKimlikNodanDVO : BaseMedulaRaporObject
    {
        public class RaporOkuTCKimlikNodanDVOList : TTObjectCollection<RaporOkuTCKimlikNodanDVO> { }
                    
        public class ChildRaporOkuTCKimlikNodanDVOCollection : TTObject.TTChildObjectCollection<RaporOkuTCKimlikNodanDVO>
        {
            public ChildRaporOkuTCKimlikNodanDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildRaporOkuTCKimlikNodanDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public string tckimlikNo
        {
            get { return (string)this["TCKIMLIKNO"]; }
            set { this["TCKIMLIKNO"] = value; }
        }

        public string turu
        {
            get { return (string)this["TURU"]; }
            set { this["TURU"] = value; }
        }

    /// <summary>
    /// Rapor Cevap TC Kimlik Numarasından
    /// </summary>
        public RaporCevapTCKimlikNodanDVO raporCevapTCKimlikNodanDVO
        {
            get { return (RaporCevapTCKimlikNodanDVO)((ITTObject)this).GetParent("RAPORCEVAPTCKIMLIKNODANDVO"); }
            set { this["RAPORCEVAPTCKIMLIKNODANDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected RaporOkuTCKimlikNodanDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected RaporOkuTCKimlikNodanDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected RaporOkuTCKimlikNodanDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected RaporOkuTCKimlikNodanDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected RaporOkuTCKimlikNodanDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RAPOROKUTCKIMLIKNODANDVO", dataRow) { }
        protected RaporOkuTCKimlikNodanDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RAPOROKUTCKIMLIKNODANDVO", dataRow, isImported) { }
        public RaporOkuTCKimlikNodanDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public RaporOkuTCKimlikNodanDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public RaporOkuTCKimlikNodanDVO() : base() { }

    }
}