
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PathologyAcceptTemplateDetail")] 

    /// <summary>
    /// Patoloji Paket Tanım Detayı
    /// </summary>
    public  partial class PathologyAcceptTemplateDetail : TTObject
    {
        public class PathologyAcceptTemplateDetailList : TTObjectCollection<PathologyAcceptTemplateDetail> { }
                    
        public class ChildPathologyAcceptTemplateDetailCollection : TTObject.TTChildObjectCollection<PathologyAcceptTemplateDetail>
        {
            public ChildPathologyAcceptTemplateDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPathologyAcceptTemplateDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Adet
    /// </summary>
        public int? Amount
        {
            get { return (int?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

    /// <summary>
    /// Patoloji Paket Detay Tanımı İlişkisi
    /// </summary>
        public PathologyAcceptTemplateDefinition PathologyAcceptTemplateDef
        {
            get { return (PathologyAcceptTemplateDefinition)((ITTObject)this).GetParent("PATHOLOGYACCEPTTEMPLATEDEF"); }
            set { this["PATHOLOGYACCEPTTEMPLATEDEF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Patoloji Test Tanım İlişkisi
    /// </summary>
        public PathologyTestDefinition PathologyTestDefinition
        {
            get { return (PathologyTestDefinition)((ITTObject)this).GetParent("PATHOLOGYTESTDEFINITION"); }
            set { this["PATHOLOGYTESTDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PathologyAcceptTemplateDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PathologyAcceptTemplateDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PathologyAcceptTemplateDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PathologyAcceptTemplateDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PathologyAcceptTemplateDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PATHOLOGYACCEPTTEMPLATEDETAIL", dataRow) { }
        protected PathologyAcceptTemplateDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PATHOLOGYACCEPTTEMPLATEDETAIL", dataRow, isImported) { }
        public PathologyAcceptTemplateDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PathologyAcceptTemplateDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PathologyAcceptTemplateDetail() : base() { }

    }
}