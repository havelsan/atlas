
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SevkBildirSonucDVO")] 

    public  partial class SevkBildirSonucDVO : BaseMedulaCevap
    {
        public class SevkBildirSonucDVOList : TTObjectCollection<SevkBildirSonucDVO> { }
                    
        public class ChildSevkBildirSonucDVOCollection : TTObject.TTChildObjectCollection<SevkBildirSonucDVO>
        {
            public ChildSevkBildirSonucDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSevkBildirSonucDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Takip Numarası
    /// </summary>
        public string takipNo
        {
            get { return (string)this["TAKIPNO"]; }
            set { this["TAKIPNO"] = value; }
        }

    /// <summary>
    /// Sevk Ediliş Tarihi
    /// </summary>
        public string sevkEdilisTarihi
        {
            get { return (string)this["SEVKEDILISTARIHI"]; }
            set { this["SEVKEDILISTARIHI"] = value; }
        }

        protected SevkBildirSonucDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SevkBildirSonucDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SevkBildirSonucDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SevkBildirSonucDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SevkBildirSonucDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SEVKBILDIRSONUCDVO", dataRow) { }
        protected SevkBildirSonucDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SEVKBILDIRSONUCDVO", dataRow, isImported) { }
        public SevkBildirSonucDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SevkBildirSonucDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SevkBildirSonucDVO() : base() { }

    }
}