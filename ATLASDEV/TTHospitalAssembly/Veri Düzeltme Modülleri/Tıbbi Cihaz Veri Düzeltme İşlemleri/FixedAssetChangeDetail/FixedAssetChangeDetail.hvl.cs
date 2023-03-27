
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="FixedAssetChangeDetail")] 

    public  partial class FixedAssetChangeDetail : TTObject
    {
        public class FixedAssetChangeDetailList : TTObjectCollection<FixedAssetChangeDetail> { }
                    
        public class ChildFixedAssetChangeDetailCollection : TTObject.TTChildObjectCollection<FixedAssetChangeDetail>
        {
            public ChildFixedAssetChangeDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildFixedAssetChangeDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// ChangeActionObjectID
    /// </summary>
        public Guid? ChangeActionObjectID
        {
            get { return (Guid?)this["CHANGEACTIONOBJECTID"]; }
            set { this["CHANGEACTIONOBJECTID"] = value; }
        }

    /// <summary>
    /// Tarih
    /// </summary>
        public DateTime? Date
        {
            get { return (DateTime?)this["DATE"]; }
            set { this["DATE"] = value; }
        }

    /// <summary>
    /// Güncelle
    /// </summary>
        public bool? DetailUpdate
        {
            get { return (bool?)this["DETAILUPDATE"]; }
            set { this["DETAILUPDATE"] = value; }
        }

        public FixedAssetChangeUpdate FixedAssetChangeUpdate
        {
            get { return (FixedAssetChangeUpdate)((ITTObject)this).GetParent("FIXEDASSETCHANGEUPDATE"); }
            set { this["FIXEDASSETCHANGEUPDATE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Sites Site
        {
            get { return (Sites)((ITTObject)this).GetParent("SITE"); }
            set { this["SITE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected FixedAssetChangeDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected FixedAssetChangeDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected FixedAssetChangeDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected FixedAssetChangeDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected FixedAssetChangeDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "FIXEDASSETCHANGEDETAIL", dataRow) { }
        protected FixedAssetChangeDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "FIXEDASSETCHANGEDETAIL", dataRow, isImported) { }
        public FixedAssetChangeDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public FixedAssetChangeDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public FixedAssetChangeDetail() : base() { }

    }
}