
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MedulaSampledProvisionDetail")] 

    /// <summary>
    /// Medula Örneklenmiş Takip Detay
    /// </summary>
    public  partial class MedulaSampledProvisionDetail : TTObject
    {
        public class MedulaSampledProvisionDetailList : TTObjectCollection<MedulaSampledProvisionDetail> { }
                    
        public class ChildMedulaSampledProvisionDetailCollection : TTObject.TTChildObjectCollection<MedulaSampledProvisionDetail>
        {
            public ChildMedulaSampledProvisionDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMedulaSampledProvisionDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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
    /// Medula Örneklenmiş Takip
    /// </summary>
        public MedulaSampledProvision MedulaSampledProvision
        {
            get { return (MedulaSampledProvision)((ITTObject)this).GetParent("MEDULASAMPLEDPROVISION"); }
            set { this["MEDULASAMPLEDPROVISION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MedulaSampledProvisionDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MedulaSampledProvisionDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MedulaSampledProvisionDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MedulaSampledProvisionDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MedulaSampledProvisionDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MEDULASAMPLEDPROVISIONDETAIL", dataRow) { }
        protected MedulaSampledProvisionDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MEDULASAMPLEDPROVISIONDETAIL", dataRow, isImported) { }
        public MedulaSampledProvisionDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MedulaSampledProvisionDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MedulaSampledProvisionDetail() : base() { }

    }
}