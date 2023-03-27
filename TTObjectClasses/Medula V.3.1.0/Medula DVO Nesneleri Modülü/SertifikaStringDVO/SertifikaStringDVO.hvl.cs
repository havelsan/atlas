
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SertifikaStringDVO")] 

    public  partial class SertifikaStringDVO : BaseMedulaObject
    {
        public class SertifikaStringDVOList : TTObjectCollection<SertifikaStringDVO> { }
                    
        public class ChildSertifikaStringDVOCollection : TTObject.TTChildObjectCollection<SertifikaStringDVO>
        {
            public ChildSertifikaStringDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSertifikaStringDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public string sertifika
        {
            get { return (string)this["SERTIFIKA"]; }
            set { this["SERTIFIKA"] = value; }
        }

        public EtkinMaddeSUTKuraliDVO EtkinMaddeSUTKuraliDVO
        {
            get { return (EtkinMaddeSUTKuraliDVO)((ITTObject)this).GetParent("ETKINMADDESUTKURALIDVO"); }
            set { this["ETKINMADDESUTKURALIDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected SertifikaStringDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SertifikaStringDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SertifikaStringDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SertifikaStringDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SertifikaStringDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SERTIFIKASTRINGDVO", dataRow) { }
        protected SertifikaStringDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SERTIFIKASTRINGDVO", dataRow, isImported) { }
        public SertifikaStringDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SertifikaStringDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SertifikaStringDVO() : base() { }

    }
}