
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ProvizyonDegistirGirisDVO")] 

    public  partial class ProvizyonDegistirGirisDVO : BaseMedulaObject
    {
        public class ProvizyonDegistirGirisDVOList : TTObjectCollection<ProvizyonDegistirGirisDVO> { }
                    
        public class ChildProvizyonDegistirGirisDVOCollection : TTObject.TTChildObjectCollection<ProvizyonDegistirGirisDVO>
        {
            public ChildProvizyonDegistirGirisDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildProvizyonDegistirGirisDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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
    /// Tesis Kodu
    /// </summary>
        public int? saglikTesisKodu
        {
            get { return (int?)this["SAGLIKTESISKODU"]; }
            set { this["SAGLIKTESISKODU"] = value; }
        }

    /// <summary>
    /// Provizyonun Tipi
    /// </summary>
        public string yeniProvizyonTipi
        {
            get { return (string)this["YENIPROVIZYONTIPI"]; }
            set { this["YENIPROVIZYONTIPI"] = value; }
        }

        public ProvizyonDegistirCevapDVO provizyonDegistirCevapDVO
        {
            get { return (ProvizyonDegistirCevapDVO)((ITTObject)this).GetParent("PROVIZYONDEGISTIRCEVAPDVO"); }
            set { this["PROVIZYONDEGISTIRCEVAPDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ProvizyonDegistirGirisDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ProvizyonDegistirGirisDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ProvizyonDegistirGirisDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ProvizyonDegistirGirisDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ProvizyonDegistirGirisDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PROVIZYONDEGISTIRGIRISDVO", dataRow) { }
        protected ProvizyonDegistirGirisDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PROVIZYONDEGISTIRGIRISDVO", dataRow, isImported) { }
        public ProvizyonDegistirGirisDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ProvizyonDegistirGirisDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ProvizyonDegistirGirisDVO() : base() { }

    }
}