
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BasvuruTakipOkuDVO")] 

    public  partial class BasvuruTakipOkuDVO : BaseMedulaObject
    {
        public class BasvuruTakipOkuDVOList : TTObjectCollection<BasvuruTakipOkuDVO> { }
                    
        public class ChildBasvuruTakipOkuDVOCollection : TTObject.TTChildObjectCollection<BasvuruTakipOkuDVO>
        {
            public ChildBasvuruTakipOkuDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBasvuruTakipOkuDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Hastanın Başvuru Numarası
    /// </summary>
        public string hastaBasvuruNo
        {
            get { return (string)this["HASTABASVURUNO"]; }
            set { this["HASTABASVURUNO"] = value; }
        }

    /// <summary>
    /// Tesis Kodu
    /// </summary>
        public int? saglikTesisKodu
        {
            get { return (int?)this["SAGLIKTESISKODU"]; }
            set { this["SAGLIKTESISKODU"] = value; }
        }

        public BasvuruTakipOkuCevapDVO basvuruTakipOkuCevapDVO
        {
            get { return (BasvuruTakipOkuCevapDVO)((ITTObject)this).GetParent("BASVURUTAKIPOKUCEVAPDVO"); }
            set { this["BASVURUTAKIPOKUCEVAPDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected BasvuruTakipOkuDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BasvuruTakipOkuDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BasvuruTakipOkuDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BasvuruTakipOkuDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BasvuruTakipOkuDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BASVURUTAKIPOKUDVO", dataRow) { }
        protected BasvuruTakipOkuDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BASVURUTAKIPOKUDVO", dataRow, isImported) { }
        public BasvuruTakipOkuDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BasvuruTakipOkuDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BasvuruTakipOkuDVO() : base() { }

    }
}