
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="RaporOkuRaporTakipNodanDVO")] 

    public  partial class RaporOkuRaporTakipNodanDVO : BaseMedulaRaporObject
    {
        public class RaporOkuRaporTakipNodanDVOList : TTObjectCollection<RaporOkuRaporTakipNodanDVO> { }
                    
        public class ChildRaporOkuRaporTakipNodanDVOCollection : TTObject.TTChildObjectCollection<RaporOkuRaporTakipNodanDVO>
        {
            public ChildRaporOkuRaporTakipNodanDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildRaporOkuRaporTakipNodanDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public string raporTakipNo
        {
            get { return (string)this["RAPORTAKIPNO"]; }
            set { this["RAPORTAKIPNO"] = value; }
        }

    /// <summary>
    /// Rapor Cevap
    /// </summary>
        public RaporCevapDVO raporCevapDVO
        {
            get { return (RaporCevapDVO)((ITTObject)this).GetParent("RAPORCEVAPDVO"); }
            set { this["RAPORCEVAPDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected RaporOkuRaporTakipNodanDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected RaporOkuRaporTakipNodanDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected RaporOkuRaporTakipNodanDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected RaporOkuRaporTakipNodanDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected RaporOkuRaporTakipNodanDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RAPOROKURAPORTAKIPNODANDVO", dataRow) { }
        protected RaporOkuRaporTakipNodanDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RAPOROKURAPORTAKIPNODANDVO", dataRow, isImported) { }
        public RaporOkuRaporTakipNodanDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public RaporOkuRaporTakipNodanDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public RaporOkuRaporTakipNodanDVO() : base() { }

    }
}