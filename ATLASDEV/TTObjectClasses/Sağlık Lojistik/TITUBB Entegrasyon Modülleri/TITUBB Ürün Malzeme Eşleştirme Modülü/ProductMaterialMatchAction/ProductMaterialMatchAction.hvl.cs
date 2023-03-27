
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ProductMaterialMatchAction")] 

    /// <summary>
    /// TITUBB Ürün Malzeme Eşleştirme
    /// </summary>
    public  partial class ProductMaterialMatchAction : BaseAction, IWorkListBaseAction
    {
        public class ProductMaterialMatchActionList : TTObjectCollection<ProductMaterialMatchAction> { }
                    
        public class ChildProductMaterialMatchActionCollection : TTObject.TTChildObjectCollection<ProductMaterialMatchAction>
        {
            public ChildProductMaterialMatchActionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildProductMaterialMatchActionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("08f269a2-014a-45e9-b1c3-bfc4c636869c"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("d866d1f7-5255-4975-a8af-e6319ef798b6"); } }
        }

    /// <summary>
    /// Barkodsuz Malzeme
    /// </summary>
        public bool? WithOutBarcode
        {
            get { return (bool?)this["WITHOUTBARCODE"]; }
            set { this["WITHOUTBARCODE"] = value; }
        }

        public ProductDefinition Product
        {
            get { return (ProductDefinition)((ITTObject)this).GetParent("PRODUCT"); }
            set { this["PRODUCT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Material Material
        {
            get { return (Material)((ITTObject)this).GetParent("MATERIAL"); }
            set { this["MATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MatchReasonDefinition MatchReasonWithBarcode
        {
            get { return (MatchReasonDefinition)((ITTObject)this).GetParent("MATCHREASONWITHBARCODE"); }
            set { this["MATCHREASONWITHBARCODE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Store Store
        {
            get { return (Store)((ITTObject)this).GetParent("STORE"); }
            set { this["STORE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateProductMaterialMatchDetailsCollection()
        {
            _ProductMaterialMatchDetails = new ProductMaterialMatchDetail.ChildProductMaterialMatchDetailCollection(this, new Guid("25bec190-2200-4850-ab38-e322863d4a3b"));
            ((ITTChildObjectCollection)_ProductMaterialMatchDetails).GetChildren();
        }

        protected ProductMaterialMatchDetail.ChildProductMaterialMatchDetailCollection _ProductMaterialMatchDetails = null;
        public ProductMaterialMatchDetail.ChildProductMaterialMatchDetailCollection ProductMaterialMatchDetails
        {
            get
            {
                if (_ProductMaterialMatchDetails == null)
                    CreateProductMaterialMatchDetailsCollection();
                return _ProductMaterialMatchDetails;
            }
        }

        protected ProductMaterialMatchAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ProductMaterialMatchAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ProductMaterialMatchAction(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ProductMaterialMatchAction(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ProductMaterialMatchAction(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PRODUCTMATERIALMATCHACTION", dataRow) { }
        protected ProductMaterialMatchAction(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PRODUCTMATERIALMATCHACTION", dataRow, isImported) { }
        public ProductMaterialMatchAction(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ProductMaterialMatchAction(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ProductMaterialMatchAction() : base() { }

        override protected void RunPreTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePreScript(transDef))
                base.RunPreTransition(transDef.BaseTransDef);
            this.PreTransition(transDef);
        }
        override protected void RunPostTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePostScript(transDef))
                base.RunPostTransition(transDef.BaseTransDef);
            this.PostTransition(transDef);
        }
        override protected void RunUndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBaseUndoScript(transDef))
                base.RunUndoTransition(transDef.BaseTransDef);
            this.UndoTransition(transDef);
        }
    }
}