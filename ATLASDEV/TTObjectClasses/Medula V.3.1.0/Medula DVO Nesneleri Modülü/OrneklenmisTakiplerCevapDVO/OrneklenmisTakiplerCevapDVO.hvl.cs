
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="OrneklenmisTakiplerCevapDVO")] 

    public  partial class OrneklenmisTakiplerCevapDVO : BaseMedulaCevap
    {
        public class OrneklenmisTakiplerCevapDVOList : TTObjectCollection<OrneklenmisTakiplerCevapDVO> { }
                    
        public class ChildOrneklenmisTakiplerCevapDVOCollection : TTObject.TTChildObjectCollection<OrneklenmisTakiplerCevapDVO>
        {
            public ChildOrneklenmisTakiplerCevapDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildOrneklenmisTakiplerCevapDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Tesis kodu
    /// </summary>
        public int? tesisKodu
        {
            get { return (int?)this["TESISKODU"]; }
            set { this["TESISKODU"] = value; }
        }

        virtual protected void CreatetakiplerCollection()
        {
            _takipler = new TakipNoDVO.ChildTakipNoDVOCollection(this, new Guid("b6ffc6ff-efd0-4083-a7e3-8a1fbeaa612d"));
            ((ITTChildObjectCollection)_takipler).GetChildren();
        }

        protected TakipNoDVO.ChildTakipNoDVOCollection _takipler = null;
        public TakipNoDVO.ChildTakipNoDVOCollection takipler
        {
            get
            {
                if (_takipler == null)
                    CreatetakiplerCollection();
                return _takipler;
            }
        }

        protected OrneklenmisTakiplerCevapDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected OrneklenmisTakiplerCevapDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected OrneklenmisTakiplerCevapDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected OrneklenmisTakiplerCevapDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected OrneklenmisTakiplerCevapDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ORNEKLENMISTAKIPLERCEVAPDVO", dataRow) { }
        protected OrneklenmisTakiplerCevapDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ORNEKLENMISTAKIPLERCEVAPDVO", dataRow, isImported) { }
        public OrneklenmisTakiplerCevapDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public OrneklenmisTakiplerCevapDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public OrneklenmisTakiplerCevapDVO() : base() { }

    }
}