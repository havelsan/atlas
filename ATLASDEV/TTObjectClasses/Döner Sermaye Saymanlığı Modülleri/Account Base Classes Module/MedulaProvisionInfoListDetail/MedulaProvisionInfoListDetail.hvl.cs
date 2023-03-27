
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MedulaProvisionInfoListDetail")] 

    /// <summary>
    /// Medula Takip Bilgileri Listesi Detay
    /// </summary>
    public  partial class MedulaProvisionInfoListDetail : TTObject
    {
        public class MedulaProvisionInfoListDetailList : TTObjectCollection<MedulaProvisionInfoListDetail> { }
                    
        public class ChildMedulaProvisionInfoListDetailCollection : TTObject.TTChildObjectCollection<MedulaProvisionInfoListDetail>
        {
            public ChildMedulaProvisionInfoListDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMedulaProvisionInfoListDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Medula Takip No
    /// </summary>
        public string ProvisionNo
        {
            get { return (string)this["PROVISIONNO"]; }
            set { this["PROVISIONNO"] = value; }
        }

    /// <summary>
    /// Toplam Tutar
    /// </summary>
        public double? TotalPrice
        {
            get { return (double?)this["TOTALPRICE"]; }
            set { this["TOTALPRICE"] = value; }
        }

    /// <summary>
    /// Medula Takip Bilgileri Listesi
    /// </summary>
        public MedulaProvisionInfoList MedulaProvisionInfoList
        {
            get { return (MedulaProvisionInfoList)((ITTObject)this).GetParent("MEDULAPROVISIONINFOLIST"); }
            set { this["MEDULAPROVISIONINFOLIST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MedulaProvisionInfoListDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MedulaProvisionInfoListDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MedulaProvisionInfoListDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MedulaProvisionInfoListDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MedulaProvisionInfoListDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MEDULAPROVISIONINFOLISTDETAIL", dataRow) { }
        protected MedulaProvisionInfoListDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MEDULAPROVISIONINFOLISTDETAIL", dataRow, isImported) { }
        public MedulaProvisionInfoListDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MedulaProvisionInfoListDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MedulaProvisionInfoListDetail() : base() { }

    }
}