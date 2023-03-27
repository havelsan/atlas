
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="FaturaOkuGirisDVO")] 

    public  partial class FaturaOkuGirisDVO : BaseMedulaObject
    {
        public class FaturaOkuGirisDVOList : TTObjectCollection<FaturaOkuGirisDVO> { }
                    
        public class ChildFaturaOkuGirisDVOCollection : TTObject.TTChildObjectCollection<FaturaOkuGirisDVO>
        {
            public ChildFaturaOkuGirisDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildFaturaOkuGirisDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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
    /// Faturanın Referans No
    /// </summary>
        public string faturaRefNo
        {
            get { return (string)this["FATURAREFNO"]; }
            set { this["FATURAREFNO"] = value; }
        }

    /// <summary>
    /// Fatura Tarihi
    /// </summary>
        public string faturaTarihi
        {
            get { return (string)this["FATURATARIHI"]; }
            set { this["FATURATARIHI"] = value; }
        }

    /// <summary>
    /// Fatura Teslim Numarası
    /// </summary>
        public string faturaTeslimNo
        {
            get { return (string)this["FATURATESLIMNO"]; }
            set { this["FATURATESLIMNO"] = value; }
        }

    /// <summary>
    /// Fatura Oku Cevap
    /// </summary>
        public FaturaOkuCevapDVO faturaOkuCevapDVO
        {
            get { return (FaturaOkuCevapDVO)((ITTObject)this).GetParent("FATURAOKUCEVAPDVO"); }
            set { this["FATURAOKUCEVAPDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected FaturaOkuGirisDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected FaturaOkuGirisDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected FaturaOkuGirisDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected FaturaOkuGirisDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected FaturaOkuGirisDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "FATURAOKUGIRISDVO", dataRow) { }
        protected FaturaOkuGirisDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "FATURAOKUGIRISDVO", dataRow, isImported) { }
        public FaturaOkuGirisDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public FaturaOkuGirisDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public FaturaOkuGirisDVO() : base() { }

    }
}