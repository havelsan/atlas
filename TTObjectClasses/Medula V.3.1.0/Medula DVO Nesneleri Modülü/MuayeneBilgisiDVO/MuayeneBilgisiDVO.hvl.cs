
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MuayeneBilgisiDVO")] 

    public  partial class MuayeneBilgisiDVO : BaseHizmetKayitDVO
    {
        public class MuayeneBilgisiDVOList : TTObjectCollection<MuayeneBilgisiDVO> { }
                    
        public class ChildMuayeneBilgisiDVOCollection : TTObject.TTChildObjectCollection<MuayeneBilgisiDVO>
        {
            public ChildMuayeneBilgisiDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMuayeneBilgisiDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Doktor Tescil No
    /// </summary>
        public string drTescilNo
        {
            get { return (string)this["DRTESCILNO"]; }
            set { this["DRTESCILNO"] = value; }
        }

    /// <summary>
    /// SUT Kodu
    /// </summary>
        public string sutKodu
        {
            get { return (string)this["SUTKODU"]; }
            set { this["SUTKODU"] = value; }
        }

    /// <summary>
    /// Muayene Tarihi
    /// </summary>
        public string muayeneTarihi
        {
            get { return (string)this["MUAYENETARIHI"]; }
            set { this["MUAYENETARIHI"] = value; }
        }

    /// <summary>
    /// Branş Kodu
    /// </summary>
        public string bransKodu
        {
            get { return (string)this["BRANSKODU"]; }
            set { this["BRANSKODU"] = value; }
        }

        protected MuayeneBilgisiDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MuayeneBilgisiDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MuayeneBilgisiDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MuayeneBilgisiDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MuayeneBilgisiDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MUAYENEBILGISIDVO", dataRow) { }
        protected MuayeneBilgisiDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MUAYENEBILGISIDVO", dataRow, isImported) { }
        public MuayeneBilgisiDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MuayeneBilgisiDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MuayeneBilgisiDVO() : base() { }

    }
}