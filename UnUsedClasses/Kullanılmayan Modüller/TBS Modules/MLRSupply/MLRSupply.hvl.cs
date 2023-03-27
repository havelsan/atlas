
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MLRSupply")] 

    /// <summary>
    /// DLR001_Malzeme
    /// </summary>
    public  partial class MLRSupply : TTObject
    {
        public class MLRSupplyList : TTObjectCollection<MLRSupply> { }
                    
        public class ChildMLRSupplyCollection : TTObject.TTChildObjectCollection<MLRSupply>
        {
            public ChildMLRSupplyCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMLRSupplyCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Yeni Malzeme
    /// </summary>
            public static Guid New { get { return new Guid("18038682-399e-40e7-81f6-a62745a5c52a"); } }
    /// <summary>
    /// Tamam
    /// </summary>
            public static Guid Complete { get { return new Guid("a6e1157e-c4ee-4e7c-a91d-fc9621916a6e"); } }
        }

    /// <summary>
    /// Hek Kodu
    /// </summary>
        public string HekCode
        {
            get { return (string)this["HEKCODE"]; }
            set { this["HEKCODE"] = value; }
        }

    /// <summary>
    /// Malzeme Kodu
    /// </summary>
        public string SupplyCode
        {
            get { return (string)this["SUPPLYCODE"]; }
            set { this["SUPPLYCODE"] = value; }
        }

    /// <summary>
    /// Katsayı 12
    /// </summary>
        public double? Coefficient12
        {
            get { return (double?)this["COEFFICIENT12"]; }
            set { this["COEFFICIENT12"] = value; }
        }

    /// <summary>
    /// Tanımlama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Diğer Kodu
    /// </summary>
        public string OtherCode
        {
            get { return (string)this["OTHERCODE"]; }
            set { this["OTHERCODE"] = value; }
        }

    /// <summary>
    /// Katsayı 23
    /// </summary>
        public double? Coefficient23
        {
            get { return (double?)this["COEFFICIENT23"]; }
            set { this["COEFFICIENT23"] = value; }
        }

    /// <summary>
    /// Son Fiyat
    /// </summary>
        public double? LastPrice
        {
            get { return (double?)this["LASTPRICE"]; }
            set { this["LASTPRICE"] = value; }
        }

    /// <summary>
    /// Maksimum Miktar
    /// </summary>
        public double? MaxAmount
        {
            get { return (double?)this["MAXAMOUNT"]; }
            set { this["MAXAMOUNT"] = value; }
        }

    /// <summary>
    /// Birim Kalori
    /// </summary>
        public int? CaloriePerUnit
        {
            get { return (int?)this["CALORIEPERUNIT"]; }
            set { this["CALORIEPERUNIT"] = value; }
        }

    /// <summary>
    /// Minumum Miktar
    /// </summary>
        public double? MinAmount
        {
            get { return (double?)this["MINAMOUNT"]; }
            set { this["MINAMOUNT"] = value; }
        }

    /// <summary>
    /// Birimi
    /// </summary>
        public SupplyUnit SupplyUnit
        {
            get { return (SupplyUnit)((ITTObject)this).GetParent("SUPPLYUNIT"); }
            set { this["SUPPLYUNIT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Birim1
    /// </summary>
        public SupplyUnit Unit1
        {
            get { return (SupplyUnit)((ITTObject)this).GetParent("UNIT1"); }
            set { this["UNIT1"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Birim2
    /// </summary>
        public SupplyUnit Unit2
        {
            get { return (SupplyUnit)((ITTObject)this).GetParent("UNIT2"); }
            set { this["UNIT2"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Kalori Birimi
    /// </summary>
        public SupplyUnit CalorieUnit
        {
            get { return (SupplyUnit)((ITTObject)this).GetParent("CALORIEUNIT"); }
            set { this["CALORIEUNIT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Birim3
    /// </summary>
        public SupplyUnit Unit3
        {
            get { return (SupplyUnit)((ITTObject)this).GetParent("UNIT3"); }
            set { this["UNIT3"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateMealSupplyCollection()
        {
            _MealSupply = new MLRMealSupply.ChildMLRMealSupplyCollection(this, new Guid("bea1aeb0-b404-4ba5-880d-cbf7f11e8f0d"));
            ((ITTChildObjectCollection)_MealSupply).GetChildren();
        }

        protected MLRMealSupply.ChildMLRMealSupplyCollection _MealSupply = null;
    /// <summary>
    /// Child collection for Yemek Malzeme Malzeme
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

        protected MLRSupply(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MLRSupply(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MLRSupply(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MLRSupply(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MLRSupply(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MLRSUPPLY", dataRow) { }
        protected MLRSupply(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MLRSUPPLY", dataRow, isImported) { }
        public MLRSupply(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MLRSupply(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MLRSupply() : base() { }

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