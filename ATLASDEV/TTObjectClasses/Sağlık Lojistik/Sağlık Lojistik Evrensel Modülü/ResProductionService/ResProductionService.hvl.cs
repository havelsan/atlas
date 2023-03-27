
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ResProductionService")] 

    /// <summary>
    /// Üretim Servisi Tanımı
    /// </summary>
    public  partial class ResProductionService : ResSection
    {
        public class ResProductionServiceList : TTObjectCollection<ResProductionService> { }
                    
        public class ChildResProductionServiceCollection : TTObject.TTChildObjectCollection<ResProductionService>
        {
            public ChildResProductionServiceCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildResProductionServiceCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Üretim Merkezi-Üretim Servisleri
    /// </summary>
        public ResProductionCenter ProductionCenter
        {
            get { return (ResProductionCenter)((ITTObject)this).GetParent("PRODUCTIONCENTER"); }
            set { this["PRODUCTIONCENTER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateProductTreeDefinitionsCollection()
        {
            _ProductTreeDefinitions = new ProductTreeDefinition.ChildProductTreeDefinitionCollection(this, new Guid("fc6d403a-2a3a-4973-8763-0d86876668b1"));
            ((ITTChildObjectCollection)_ProductTreeDefinitions).GetChildren();
        }

        protected ProductTreeDefinition.ChildProductTreeDefinitionCollection _ProductTreeDefinitions = null;
    /// <summary>
    /// Child collection for Üretim Servisi-Ürünler
    /// </summary>
        public ProductTreeDefinition.ChildProductTreeDefinitionCollection ProductTreeDefinitions
        {
            get
            {
                if (_ProductTreeDefinitions == null)
                    CreateProductTreeDefinitionsCollection();
                return _ProductTreeDefinitions;
            }
        }

        virtual protected void CreateProductAnalysisTestDetailsCollection()
        {
            _ProductAnalysisTestDetails = new ProductAnalysisTestDetail.ChildProductAnalysisTestDetailCollection(this, new Guid("55064104-ba12-49d9-96b6-6774538cd6c8"));
            ((ITTChildObjectCollection)_ProductAnalysisTestDetails).GetChildren();
        }

        protected ProductAnalysisTestDetail.ChildProductAnalysisTestDetailCollection _ProductAnalysisTestDetails = null;
    /// <summary>
    /// Child collection for Üretim Servisi-Testin Yapıldığı Üretim Servisleri
    /// </summary>
        public ProductAnalysisTestDetail.ChildProductAnalysisTestDetailCollection ProductAnalysisTestDetails
        {
            get
            {
                if (_ProductAnalysisTestDetails == null)
                    CreateProductAnalysisTestDetailsCollection();
                return _ProductAnalysisTestDetails;
            }
        }

        protected ResProductionService(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ResProductionService(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ResProductionService(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ResProductionService(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ResProductionService(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RESPRODUCTIONSERVICE", dataRow) { }
        protected ResProductionService(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RESPRODUCTIONSERVICE", dataRow, isImported) { }
        public ResProductionService(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ResProductionService(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ResProductionService() : base() { }

    }
}