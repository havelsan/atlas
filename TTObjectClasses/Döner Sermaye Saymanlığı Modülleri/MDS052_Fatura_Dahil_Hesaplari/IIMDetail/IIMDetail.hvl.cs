
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="IIMDetail")] 

    public  partial class IIMDetail : TTObject
    {
        public class IIMDetailList : TTObjectCollection<IIMDetail> { }
                    
        public class ChildIIMDetailCollection : TTObject.TTChildObjectCollection<IIMDetail>
        {
            public ChildIIMDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildIIMDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public bool? Checked
        {
            get { return (bool?)this["CHECKED"]; }
            set { this["CHECKED"] = value; }
        }

    /// <summary>
    /// Kural Detay Bilgisi
    /// </summary>
        public InvoiceInclusionMaster InvoiceInclusionMaster
        {
            get { return (InvoiceInclusionMaster)((ITTObject)this).GetParent("INVOICEINCLUSIONMASTER"); }
            set { this["INVOICEINCLUSIONMASTER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Kural Detay Bilgisi
    /// </summary>
        public InvoiceInclusionDetail InvoiceInclusionDetail
        {
            get { return (InvoiceInclusionDetail)((ITTObject)this).GetParent("INVOICEINCLUSIONDETAIL"); }
            set { this["INVOICEINCLUSIONDETAIL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected IIMDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected IIMDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected IIMDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected IIMDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected IIMDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "IIMDETAIL", dataRow) { }
        protected IIMDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "IIMDETAIL", dataRow, isImported) { }
        public IIMDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public IIMDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public IIMDetail() : base() { }

    }
}