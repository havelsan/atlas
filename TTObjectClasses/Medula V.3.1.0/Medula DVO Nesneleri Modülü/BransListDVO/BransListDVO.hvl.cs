
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BransListDVO")] 

    public  partial class BransListDVO : BaseMedulaObject
    {
        public class BransListDVOList : TTObjectCollection<BransListDVO> { }
                    
        public class ChildBransListDVOCollection : TTObject.TTChildObjectCollection<BransListDVO>
        {
            public ChildBransListDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBransListDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public string bransAdi
        {
            get { return (string)this["BRANSADI"]; }
            set { this["BRANSADI"] = value; }
        }

        public string bransKodu
        {
            get { return (string)this["BRANSKODU"]; }
            set { this["BRANSKODU"] = value; }
        }

        public EtkinMaddeSUTKuraliDVO EtkinMaddeSUTKuraliDVO
        {
            get { return (EtkinMaddeSUTKuraliDVO)((ITTObject)this).GetParent("ETKINMADDESUTKURALIDVO"); }
            set { this["ETKINMADDESUTKURALIDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected BransListDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BransListDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BransListDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BransListDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BransListDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BRANSLISTDVO", dataRow) { }
        protected BransListDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BRANSLISTDVO", dataRow, isImported) { }
        public BransListDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BransListDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BransListDVO() : base() { }

    }
}