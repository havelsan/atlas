
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SevkBildirGirisDVO")] 

    public  partial class SevkBildirGirisDVO : BaseMedulaObject
    {
        public class SevkBildirGirisDVOList : TTObjectCollection<SevkBildirGirisDVO> { }
                    
        public class ChildSevkBildirGirisDVOCollection : TTObject.TTChildObjectCollection<SevkBildirGirisDVO>
        {
            public ChildSevkBildirGirisDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSevkBildirGirisDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Tesis Kodu
    /// </summary>
        public int? tesisKodu
        {
            get { return (int?)this["TESISKODU"]; }
            set { this["TESISKODU"] = value; }
        }

    /// <summary>
    /// Sevk Ediliş Tarihi
    /// </summary>
        public string sevkEdilisTarihi
        {
            get { return (string)this["SEVKEDILISTARIHI"]; }
            set { this["SEVKEDILISTARIHI"] = value; }
        }

    /// <summary>
    /// Takip Numarası
    /// </summary>
        public string takipNo
        {
            get { return (string)this["TAKIPNO"]; }
            set { this["TAKIPNO"] = value; }
        }

        public SevkBildirSonucDVO sevkBildirSonucDVO
        {
            get { return (SevkBildirSonucDVO)((ITTObject)this).GetParent("SEVKBILDIRSONUCDVO"); }
            set { this["SEVKBILDIRSONUCDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected SevkBildirGirisDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SevkBildirGirisDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SevkBildirGirisDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SevkBildirGirisDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SevkBildirGirisDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SEVKBILDIRGIRISDVO", dataRow) { }
        protected SevkBildirGirisDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SEVKBILDIRGIRISDVO", dataRow, isImported) { }
        public SevkBildirGirisDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SevkBildirGirisDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SevkBildirGirisDVO() : base() { }

    }
}