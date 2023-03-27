
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="OncekiIslemBilgisiDVO")] 

    public  partial class OncekiIslemBilgisiDVO : BaseMedulaObject
    {
        public class OncekiIslemBilgisiDVOList : TTObjectCollection<OncekiIslemBilgisiDVO> { }
                    
        public class ChildOncekiIslemBilgisiDVOCollection : TTObject.TTChildObjectCollection<OncekiIslemBilgisiDVO>
        {
            public ChildOncekiIslemBilgisiDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildOncekiIslemBilgisiDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// İşlem Adedi
    /// </summary>
        public int? islemAdedi
        {
            get { return (int?)this["ISLEMADEDI"]; }
            set { this["ISLEMADEDI"] = value; }
        }

    /// <summary>
    /// İşlem Tarihi
    /// </summary>
        public string islemTarihi
        {
            get { return (string)this["ISLEMTARIHI"]; }
            set { this["ISLEMTARIHI"] = value; }
        }

    /// <summary>
    /// Tesis Kodu
    /// </summary>
        public int? saglikTesisKodu
        {
            get { return (int?)this["SAGLIKTESISKODU"]; }
            set { this["SAGLIKTESISKODU"] = value; }
        }

    /// <summary>
    /// Tesis Adı
    /// </summary>
        public string tesisAdi
        {
            get { return (string)this["TESISADI"]; }
            set { this["TESISADI"] = value; }
        }

        protected OncekiIslemBilgisiDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected OncekiIslemBilgisiDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected OncekiIslemBilgisiDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected OncekiIslemBilgisiDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected OncekiIslemBilgisiDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ONCEKIISLEMBILGISIDVO", dataRow) { }
        protected OncekiIslemBilgisiDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ONCEKIISLEMBILGISIDVO", dataRow, isImported) { }
        public OncekiIslemBilgisiDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public OncekiIslemBilgisiDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public OncekiIslemBilgisiDVO() : base() { }

    }
}