
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TesisStringDVO")] 

    public  partial class TesisStringDVO : BaseMedulaObject
    {
        public class TesisStringDVOList : TTObjectCollection<TesisStringDVO> { }
                    
        public class ChildTesisStringDVOCollection : TTObject.TTChildObjectCollection<TesisStringDVO>
        {
            public ChildTesisStringDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTesisStringDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public string tesis
        {
            get { return (string)this["TESIS"]; }
            set { this["TESIS"] = value; }
        }

        public EtkinMaddeSUTKuraliDVO EtkinMaddeSUTKuraliDVO
        {
            get { return (EtkinMaddeSUTKuraliDVO)((ITTObject)this).GetParent("ETKINMADDESUTKURALIDVO"); }
            set { this["ETKINMADDESUTKURALIDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected TesisStringDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TesisStringDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TesisStringDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TesisStringDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TesisStringDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TESISSTRINGDVO", dataRow) { }
        protected TesisStringDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TESISSTRINGDVO", dataRow, isImported) { }
        public TesisStringDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TesisStringDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TesisStringDVO() : base() { }

    }
}