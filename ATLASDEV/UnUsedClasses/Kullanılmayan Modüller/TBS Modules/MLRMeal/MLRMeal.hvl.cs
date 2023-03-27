
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MLRMeal")] 

    /// <summary>
    /// DLR004_Yemek
    /// </summary>
    public  partial class MLRMeal : TTObject
    {
        public class MLRMealList : TTObjectCollection<MLRMeal> { }
                    
        public class ChildMLRMealCollection : TTObject.TTChildObjectCollection<MLRMeal>
        {
            public ChildMLRMealCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMLRMealCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Yeni Yemek Girişi
    /// </summary>
            public static Guid New { get { return new Guid("4476ff2a-f2ee-485e-b0cc-1eb4a6f5e978"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Complete { get { return new Guid("5196d377-d6d0-4766-867b-9e337de33162"); } }
        }

    /// <summary>
    /// Yemek Kodu
    /// </summary>
        public string MealCode
        {
            get { return (string)this["MEALCODE"]; }
            set { this["MEALCODE"] = value; }
        }

    /// <summary>
    /// SıralamaYeri
    /// </summary>
        public string SiralamaYeri
        {
            get { return (string)this["SIRALAMAYERI"]; }
            set { this["SIRALAMAYERI"] = value; }
        }

    /// <summary>
    /// Yemek Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Çıktığı Tarih
    /// </summary>
        public DateTime? Date
        {
            get { return (DateTime?)this["DATE"]; }
            set { this["DATE"] = value; }
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
    /// Aylık Çıkış Miktarı
    /// </summary>
        public double? MonthAmount
        {
            get { return (double?)this["MONTHAMOUNT"]; }
            set { this["MONTHAMOUNT"] = value; }
        }

    /// <summary>
    /// İstenebilir Miktar
    /// </summary>
        public double? RequestAmount
        {
            get { return (double?)this["REQUESTAMOUNT"]; }
            set { this["REQUESTAMOUNT"] = value; }
        }

    /// <summary>
    /// Toplam Kalori
    /// </summary>
        public int? TotalMealCalorie
        {
            get { return (int?)this["TOTALMEALCALORIE"]; }
            set { this["TOTALMEALCALORIE"] = value; }
        }

    /// <summary>
    /// Kendisi yemek mi
    /// </summary>
        public YesNoEnum? IsMeal
        {
            get { return (YesNoEnum?)(int?)this["ISMEAL"]; }
            set { this["ISMEAL"] = value; }
        }

    /// <summary>
    /// Yemek Grubu
    /// </summary>
        public MLRMealGroup MealGroup
        {
            get { return (MLRMealGroup)((ITTObject)this).GetParent("MEALGROUP"); }
            set { this["MEALGROUP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Birimi
    /// </summary>
        public MealUnit MealUnit
        {
            get { return (MealUnit)((ITTObject)this).GetParent("MEALUNIT"); }
            set { this["MEALUNIT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Rejim Grubu
    /// </summary>
        public MLRRegimeGroup RegimeGroup
        {
            get { return (MLRRegimeGroup)((ITTObject)this).GetParent("REGIMEGROUP"); }
            set { this["REGIMEGROUP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateMealSupplyCollection()
        {
            _MealSupply = new MLRMealSupply.ChildMLRMealSupplyCollection(this, new Guid("af2c32eb-9735-4bf2-b1a3-295be4a50e75"));
            ((ITTChildObjectCollection)_MealSupply).GetChildren();
        }

        protected MLRMealSupply.ChildMLRMealSupplyCollection _MealSupply = null;
    /// <summary>
    /// Child collection for Yemek Bileşenleri
    /// </summary>
        public MLRMealSupply.ChildMLRMealSupplyCollection MealSupply
        {
            get
            {
                if (_MealSupply == null)
                    CreateMealSupplyCollection();
                return _MealSupply;
            }
        }

        virtual protected void CreateRegimeMealsCollection()
        {
            _RegimeMeals = new MLRRegimeMeal.ChildMLRRegimeMealCollection(this, new Guid("d56ab44e-af23-44db-a88d-bd7989b10def"));
            ((ITTChildObjectCollection)_RegimeMeals).GetChildren();
        }

        protected MLRRegimeMeal.ChildMLRRegimeMealCollection _RegimeMeals = null;
    /// <summary>
    /// Child collection for Yemek
    /// </summary>
        public MLRRegimeMeal.ChildMLRRegimeMealCollection RegimeMeals
        {
            get
            {
                if (_RegimeMeals == null)
                    CreateRegimeMealsCollection();
                return _RegimeMeals;
            }
        }

        protected MLRMeal(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MLRMeal(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MLRMeal(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MLRMeal(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MLRMeal(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MLRMEAL", dataRow) { }
        protected MLRMeal(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MLRMEAL", dataRow, isImported) { }
        public MLRMeal(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MLRMeal(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MLRMeal() : base() { }

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