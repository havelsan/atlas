
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TakipSilGirisDVO")] 

    public  partial class TakipSilGirisDVO : BaseMedulaObject
    {
        public class TakipSilGirisDVOList : TTObjectCollection<TakipSilGirisDVO> { }
                    
        public class ChildTakipSilGirisDVOCollection : TTObject.TTChildObjectCollection<TakipSilGirisDVO>
        {
            public ChildTakipSilGirisDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTakipSilGirisDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Tesis kodu
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
    /// Takip Sil Cevap
    /// </summary>
        public TakipSilCevapDVO takipSilCevapDVO
        {
            get { return (TakipSilCevapDVO)((ITTObject)this).GetParent("TAKIPSILCEVAPDVO"); }
            set { this["TAKIPSILCEVAPDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected TakipSilGirisDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TakipSilGirisDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TakipSilGirisDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TakipSilGirisDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TakipSilGirisDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TAKIPSILGIRISDVO", dataRow) { }
        protected TakipSilGirisDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TAKIPSILGIRISDVO", dataRow, isImported) { }
        public TakipSilGirisDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TakipSilGirisDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TakipSilGirisDVO() : base() { }

    }
}