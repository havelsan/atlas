
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BasvuruTakipDVO")] 

    public  partial class BasvuruTakipDVO : BaseMedulaObject
    {
        public class BasvuruTakipDVOList : TTObjectCollection<BasvuruTakipDVO> { }
                    
        public class ChildBasvuruTakipDVOCollection : TTObject.TTChildObjectCollection<BasvuruTakipDVO>
        {
            public ChildBasvuruTakipDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBasvuruTakipDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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
    /// Takibin Fatura Durumu
    /// </summary>
        public string takipFaturaDurumu
        {
            get { return (string)this["TAKIPFATURADURUMU"]; }
            set { this["TAKIPFATURADURUMU"] = value; }
        }

        public BasvuruTakipOkuCevapDVO basvuruTakipOkuCevapDVO
        {
            get { return (BasvuruTakipOkuCevapDVO)((ITTObject)this).GetParent("BASVURUTAKIPOKUCEVAPDVO"); }
            set { this["BASVURUTAKIPOKUCEVAPDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected BasvuruTakipDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BasvuruTakipDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BasvuruTakipDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BasvuruTakipDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BasvuruTakipDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BASVURUTAKIPDVO", dataRow) { }
        protected BasvuruTakipDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BASVURUTAKIPDVO", dataRow, isImported) { }
        public BasvuruTakipDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BasvuruTakipDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BasvuruTakipDVO() : base() { }

    }
}