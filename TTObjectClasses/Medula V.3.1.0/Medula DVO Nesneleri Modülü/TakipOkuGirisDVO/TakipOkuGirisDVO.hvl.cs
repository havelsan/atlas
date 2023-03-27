
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TakipOkuGirisDVO")] 

    public  partial class TakipOkuGirisDVO : BaseMedulaObject
    {
        public class TakipOkuGirisDVOList : TTObjectCollection<TakipOkuGirisDVO> { }
                    
        public class ChildTakipOkuGirisDVOCollection : TTObject.TTChildObjectCollection<TakipOkuGirisDVO>
        {
            public ChildTakipOkuGirisDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTakipOkuGirisDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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
    /// Takip Numarası
    /// </summary>
        public string takipNo
        {
            get { return (string)this["TAKIPNO"]; }
            set { this["TAKIPNO"] = value; }
        }

    /// <summary>
    /// Yeni Tedavi Tipi
    /// </summary>
        public string yeniTedaviTipi
        {
            get { return (string)this["YENITEDAVITIPI"]; }
            set { this["YENITEDAVITIPI"] = value; }
        }

    /// <summary>
    /// Takip
    /// </summary>
        public TakipDVO takipDVO
        {
            get { return (TakipDVO)((ITTObject)this).GetParent("TAKIPDVO"); }
            set { this["TAKIPDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected TakipOkuGirisDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TakipOkuGirisDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TakipOkuGirisDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TakipOkuGirisDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TakipOkuGirisDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TAKIPOKUGIRISDVO", dataRow) { }
        protected TakipOkuGirisDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TAKIPOKUGIRISDVO", dataRow, isImported) { }
        public TakipOkuGirisDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TakipOkuGirisDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TakipOkuGirisDVO() : base() { }

    }
}