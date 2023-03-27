
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PriceUpdatingSubActionProcedure")] 

    /// <summary>
    /// Fiyat Güncelleme Hizmet Detayı
    /// </summary>
    public  partial class PriceUpdatingSubActionProcedure : TTObject
    {
        public class PriceUpdatingSubActionProcedureList : TTObjectCollection<PriceUpdatingSubActionProcedure> { }
                    
        public class ChildPriceUpdatingSubActionProcedureCollection : TTObject.TTChildObjectCollection<PriceUpdatingSubActionProcedure>
        {
            public ChildPriceUpdatingSubActionProcedureCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPriceUpdatingSubActionProcedureCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Hizmet fiyatı update edilecek mi ?
    /// </summary>
        public bool? UpdateProcedurePrice
        {
            get { return (bool?)this["UPDATEPROCEDUREPRICE"]; }
            set { this["UPDATEPROCEDUREPRICE"] = value; }
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
    /// Hizmet hareketi ile ilişki
    /// </summary>
        public SubActionProcedure SubActionProcedure
        {
            get { return (SubActionProcedure)((ITTObject)this).GetParent("SUBACTIONPROCEDURE"); }
            set { this["SUBACTIONPROCEDURE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PriceUpdatingSubActionProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PriceUpdatingSubActionProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PriceUpdatingSubActionProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PriceUpdatingSubActionProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PriceUpdatingSubActionProcedure(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PRICEUPDATINGSUBACTIONPROCEDURE", dataRow) { }
        protected PriceUpdatingSubActionProcedure(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PRICEUPDATINGSUBACTIONPROCEDURE", dataRow, isImported) { }
        public PriceUpdatingSubActionProcedure(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PriceUpdatingSubActionProcedure(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PriceUpdatingSubActionProcedure() : base() { }

    }
}