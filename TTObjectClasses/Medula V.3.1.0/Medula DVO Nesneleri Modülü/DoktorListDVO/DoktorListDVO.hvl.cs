
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DoktorListDVO")] 

    public  partial class DoktorListDVO : BaseMedulaObject
    {
        public class DoktorListDVOList : TTObjectCollection<DoktorListDVO> { }
                    
        public class ChildDoktorListDVOCollection : TTObject.TTChildObjectCollection<DoktorListDVO>
        {
            public ChildDoktorListDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDoktorListDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Doktor Soyadı
    /// </summary>
        public string drSoyadi
        {
            get { return (string)this["DRSOYADI"]; }
            set { this["DRSOYADI"] = value; }
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
    /// Doktor Diploma No
    /// </summary>
        public string drDiplomaNo
        {
            get { return (string)this["DRDIPLOMANO"]; }
            set { this["DRDIPLOMANO"] = value; }
        }

    /// <summary>
    /// Doktor Adı
    /// </summary>
        public string drAdi
        {
            get { return (string)this["DRADI"]; }
            set { this["DRADI"] = value; }
        }

    /// <summary>
    /// Doktor Ara Cevap-Doktorlar
    /// </summary>
        public DoktorAraCevapDVO DoktorAraCevapDVO
        {
            get { return (DoktorAraCevapDVO)((ITTObject)this).GetParent("DOKTORARACEVAPDVO"); }
            set { this["DOKTORARACEVAPDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DoktorListDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DoktorListDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DoktorListDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DoktorListDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DoktorListDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DOKTORLISTDVO", dataRow) { }
        protected DoktorListDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DOKTORLISTDVO", dataRow, isImported) { }
        public DoktorListDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DoktorListDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DoktorListDVO() : base() { }

    }
}