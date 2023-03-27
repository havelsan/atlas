
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ResProductionCenter")] 

    /// <summary>
    /// Üretim Merkezi Tanımı
    /// </summary>
    public  partial class ResProductionCenter : ResSection
    {
        public class ResProductionCenterList : TTObjectCollection<ResProductionCenter> { }
                    
        public class ChildResProductionCenterCollection : TTObject.TTChildObjectCollection<ResProductionCenter>
        {
            public ChildResProductionCenterCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildResProductionCenterCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// XXXXXX-Üretim Merkezleri
    /// </summary>
        public ResHospital Hospital
        {
            get { return (ResHospital)((ITTObject)this).GetParent("HOSPITAL"); }
            set { this["HOSPITAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateProductionServicesCollection()
        {
            _ProductionServices = new ResProductionService.ChildResProductionServiceCollection(this, new Guid("1f85422c-4645-436f-ab67-e99848d30457"));
            ((ITTChildObjectCollection)_ProductionServices).GetChildren();
        }

        protected ResProductionService.ChildResProductionServiceCollection _ProductionServices = null;
    /// <summary>
    /// Child collection for Üretim Merkezi-Üretim Servisleri
    /// </summary>
        public ResProductionService.ChildResProductionServiceCollection ProductionServices
        {
            get
            {
                if (_ProductionServices == null)
                    CreateProductionServicesCollection();
                return _ProductionServices;
            }
        }

        protected ResProductionCenter(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ResProductionCenter(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ResProductionCenter(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ResProductionCenter(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ResProductionCenter(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RESPRODUCTIONCENTER", dataRow) { }
        protected ResProductionCenter(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RESPRODUCTIONCENTER", dataRow, isImported) { }
        public ResProductionCenter(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ResProductionCenter(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ResProductionCenter() : base() { }

    }
}