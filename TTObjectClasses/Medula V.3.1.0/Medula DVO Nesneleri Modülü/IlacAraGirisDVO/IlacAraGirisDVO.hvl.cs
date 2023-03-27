
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="IlacAraGirisDVO")] 

    public  partial class IlacAraGirisDVO : BaseMedulaObject
    {
        public class IlacAraGirisDVOList : TTObjectCollection<IlacAraGirisDVO> { }
                    
        public class ChildIlacAraGirisDVOCollection : TTObject.TTChildObjectCollection<IlacAraGirisDVO>
        {
            public ChildIlacAraGirisDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildIlacAraGirisDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// İlacın Barkod Numarası
    /// </summary>
        public string barkod
        {
            get { return (string)this["BARKOD"]; }
            set { this["BARKOD"] = value; }
        }

    /// <summary>
    /// İlaç Adı
    /// </summary>
        public string ilacAdi
        {
            get { return (string)this["ILACADI"]; }
            set { this["ILACADI"] = value; }
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
    /// İlaç Ara Cevap
    /// </summary>
        public IlacAraCevapDVO ilacAraCevapDVO
        {
            get { return (IlacAraCevapDVO)((ITTObject)this).GetParent("ILACARACEVAPDVO"); }
            set { this["ILACARACEVAPDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected IlacAraGirisDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected IlacAraGirisDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected IlacAraGirisDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected IlacAraGirisDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected IlacAraGirisDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ILACARAGIRISDVO", dataRow) { }
        protected IlacAraGirisDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ILACARAGIRISDVO", dataRow, isImported) { }
        public IlacAraGirisDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public IlacAraGirisDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public IlacAraGirisDVO() : base() { }

    }
}