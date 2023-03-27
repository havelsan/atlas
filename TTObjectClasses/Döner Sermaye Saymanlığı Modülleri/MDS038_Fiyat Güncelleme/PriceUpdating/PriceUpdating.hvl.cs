
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PriceUpdating")] 

    /// <summary>
    /// Fiyat Güncelleme
    /// </summary>
    public  partial class PriceUpdating : AccountAction, IWorkListBaseAction
    {
        public class PriceUpdatingList : TTObjectCollection<PriceUpdating> { }
                    
        public class ChildPriceUpdatingCollection : TTObject.TTChildObjectCollection<PriceUpdating>
        {
            public ChildPriceUpdatingCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPriceUpdatingCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("41638415-2716-44fc-8abf-350107f450cd"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("c42ead50-1210-4e74-b002-aa2c6e6353df"); } }
        }

    /// <summary>
    /// Başlangıç Tarihi
    /// </summary>
        public DateTime? StartDate
        {
            get { return (DateTime?)this["STARTDATE"]; }
            set { this["STARTDATE"] = value; }
        }

    /// <summary>
    /// Bitiş Tarihi
    /// </summary>
        public DateTime? EndDate
        {
            get { return (DateTime?)this["ENDDATE"]; }
            set { this["ENDDATE"] = value; }
        }

    /// <summary>
    /// Sonuç Bilgisi
    /// </summary>
        public string ResultData
        {
            get { return (string)this["RESULTDATA"]; }
            set { this["RESULTDATA"] = value; }
        }

    /// <summary>
    /// Fiyat listesi ile ilişki
    /// </summary>
        public PricingListDefinition PricingList
        {
            get { return (PricingListDefinition)((ITTObject)this).GetParent("PRICINGLIST"); }
            set { this["PRICINGLIST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Hizmet ile ilişki
    /// </summary>
        public ProcedureDefinition ProcedureObject
        {
            get { return (ProcedureDefinition)((ITTObject)this).GetParent("PROCEDUREOBJECT"); }
            set { this["PROCEDUREOBJECT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Malzeme ile ilişki
    /// </summary>
        public Material Material
        {
            get { return (Material)((ITTObject)this).GetParent("MATERIAL"); }
            set { this["MATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreatePriceUpdatingMaterialsCollection()
        {
            _PriceUpdatingMaterials = new PriceUpdatingSubActionMaterial.ChildPriceUpdatingSubActionMaterialCollection(this, new Guid("89178953-2c47-4f13-babf-66f4c4bfa86b"));
            ((ITTChildObjectCollection)_PriceUpdatingMaterials).GetChildren();
        }

        protected PriceUpdatingSubActionMaterial.ChildPriceUpdatingSubActionMaterialCollection _PriceUpdatingMaterials = null;
    /// <summary>
    /// Child collection for Fiyat Güncelleme ile ilişki
    /// </summary>
        public PriceUpdatingSubActionMaterial.ChildPriceUpdatingSubActionMaterialCollection PriceUpdatingMaterials
        {
            get
            {
                if (_PriceUpdatingMaterials == null)
                    CreatePriceUpdatingMaterialsCollection();
                return _PriceUpdatingMaterials;
            }
        }

        virtual protected void CreatePriceUpdatingProceduresCollection()
        {
            _PriceUpdatingProcedures = new PriceUpdatingSubActionProcedure.ChildPriceUpdatingSubActionProcedureCollection(this, new Guid("0e7d00f1-cb4a-4ca3-a118-549f0d113587"));
            ((ITTChildObjectCollection)_PriceUpdatingProcedures).GetChildren();
        }

        protected PriceUpdatingSubActionProcedure.ChildPriceUpdatingSubActionProcedureCollection _PriceUpdatingProcedures = null;
    /// <summary>
    /// Child collection for Fiyat Güncelleme ile ilişki
    /// </summary>
        public PriceUpdatingSubActionProcedure.ChildPriceUpdatingSubActionProcedureCollection PriceUpdatingProcedures
        {
            get
            {
                if (_PriceUpdatingProcedures == null)
                    CreatePriceUpdatingProceduresCollection();
                return _PriceUpdatingProcedures;
            }
        }

        protected PriceUpdating(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PriceUpdating(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PriceUpdating(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PriceUpdating(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PriceUpdating(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PRICEUPDATING", dataRow) { }
        protected PriceUpdating(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PRICEUPDATING", dataRow, isImported) { }
        public PriceUpdating(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PriceUpdating(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PriceUpdating() : base() { }

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