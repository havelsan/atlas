
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="EvrakKesintiCevapDVO")] 

    public  partial class EvrakKesintiCevapDVO : BaseMedulaCevap
    {
        public class EvrakKesintiCevapDVOList : TTObjectCollection<EvrakKesintiCevapDVO> { }
                    
        public class ChildEvrakKesintiCevapDVOCollection : TTObject.TTChildObjectCollection<EvrakKesintiCevapDVO>
        {
            public ChildEvrakKesintiCevapDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildEvrakKesintiCevapDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public int? evrakRefNo
        {
            get { return (int?)this["EVRAKREFNO"]; }
            set { this["EVRAKREFNO"] = value; }
        }

        public double? malzemeKatilimTutari
        {
            get { return (double?)this["MALZEMEKATILIMTUTARI"]; }
            set { this["MALZEMEKATILIMTUTARI"] = value; }
        }

        public double? muayeneKatilimTutari
        {
            get { return (double?)this["MUAYENEKATILIMTUTARI"]; }
            set { this["MUAYENEKATILIMTUTARI"] = value; }
        }

        public double? tupBebekKatilimTutari
        {
            get { return (double?)this["TUPBEBEKKATILIMTUTARI"]; }
            set { this["TUPBEBEKKATILIMTUTARI"] = value; }
        }

        virtual protected void CreateevrakKesintiIslemCollection()
        {
            _evrakKesintiIslem = new EvrakKesintiIslemDVO.ChildEvrakKesintiIslemDVOCollection(this, new Guid("89f82c7b-e0e7-4fca-93c3-3bf460b87b24"));
            ((ITTChildObjectCollection)_evrakKesintiIslem).GetChildren();
        }

        protected EvrakKesintiIslemDVO.ChildEvrakKesintiIslemDVOCollection _evrakKesintiIslem = null;
        public EvrakKesintiIslemDVO.ChildEvrakKesintiIslemDVOCollection evrakKesintiIslem
        {
            get
            {
                if (_evrakKesintiIslem == null)
                    CreateevrakKesintiIslemCollection();
                return _evrakKesintiIslem;
            }
        }

        protected EvrakKesintiCevapDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected EvrakKesintiCevapDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected EvrakKesintiCevapDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected EvrakKesintiCevapDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected EvrakKesintiCevapDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EVRAKKESINTICEVAPDVO", dataRow) { }
        protected EvrakKesintiCevapDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EVRAKKESINTICEVAPDVO", dataRow, isImported) { }
        public EvrakKesintiCevapDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public EvrakKesintiCevapDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public EvrakKesintiCevapDVO() : base() { }

    }
}