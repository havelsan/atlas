
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PriceUpdatingSubActionMaterial")] 

    /// <summary>
    /// Fiyat Güncelleme Malzeme Detayı
    /// </summary>
    public  partial class PriceUpdatingSubActionMaterial : TTObject
    {
        public class PriceUpdatingSubActionMaterialList : TTObjectCollection<PriceUpdatingSubActionMaterial> { }
                    
        public class ChildPriceUpdatingSubActionMaterialCollection : TTObject.TTChildObjectCollection<PriceUpdatingSubActionMaterial>
        {
            public ChildPriceUpdatingSubActionMaterialCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPriceUpdatingSubActionMaterialCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Malzeme fiyatı update edilecek mi ?
    /// </summary>
        public bool? UpdateMaterialPrice
        {
            get { return (bool?)this["UPDATEMATERIALPRICE"]; }
            set { this["UPDATEMATERIALPRICE"] = value; }
        }

    /// <summary>
    /// Fiyat Güncelleme ile ilişki
    /// </summary>
        public PriceUpdating PriceUpdating
        {
            get { return (PriceUpdating)((ITTObject)this).GetParent("PRICEUPDATING"); }
            set { this["PRICEUPDATING"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Malzeme hareketi ile ilişki
    /// </summary>
        public SubActionMaterial SubActionMaterial
        {
            get { return (SubActionMaterial)((ITTObject)this).GetParent("SUBACTIONMATERIAL"); }
            set { this["SUBACTIONMATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PriceUpdatingSubActionMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PriceUpdatingSubActionMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PriceUpdatingSubActionMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PriceUpdatingSubActionMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PriceUpdatingSubActionMaterial(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PRICEUPDATINGSUBACTIONMATERIAL", dataRow) { }
        protected PriceUpdatingSubActionMaterial(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PRICEUPDATINGSUBACTIONMATERIAL", dataRow, isImported) { }
        public PriceUpdatingSubActionMaterial(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PriceUpdatingSubActionMaterial(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PriceUpdatingSubActionMaterial() : base() { }

    }
}