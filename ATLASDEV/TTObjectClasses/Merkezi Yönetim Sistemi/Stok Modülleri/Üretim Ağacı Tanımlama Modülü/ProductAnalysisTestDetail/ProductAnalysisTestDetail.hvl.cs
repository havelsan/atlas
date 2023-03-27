
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ProductAnalysisTestDetail")] 

    public  partial class ProductAnalysisTestDetail : TTObject
    {
        public class ProductAnalysisTestDetailList : TTObjectCollection<ProductAnalysisTestDetail> { }
                    
        public class ChildProductAnalysisTestDetailCollection : TTObject.TTChildObjectCollection<ProductAnalysisTestDetail>
        {
            public ChildProductAnalysisTestDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildProductAnalysisTestDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Üretim Servisi-Testin Yapıldığı Üretim Servisleri
    /// </summary>
        public ResProductionService ProductionService
        {
            get { return (ResProductionService)((ITTObject)this).GetParent("PRODUCTIONSERVICE"); }
            set { this["PRODUCTIONSERVICE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ProductAnalysisTestDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ProductAnalysisTestDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ProductAnalysisTestDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ProductAnalysisTestDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ProductAnalysisTestDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PRODUCTANALYSISTESTDETAIL", dataRow) { }
        protected ProductAnalysisTestDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PRODUCTANALYSISTESTDETAIL", dataRow, isImported) { }
        public ProductAnalysisTestDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ProductAnalysisTestDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ProductAnalysisTestDetail() : base() { }

    }
}