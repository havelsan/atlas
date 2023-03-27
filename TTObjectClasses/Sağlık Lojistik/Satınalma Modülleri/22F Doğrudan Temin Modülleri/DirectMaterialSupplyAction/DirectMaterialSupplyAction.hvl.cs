
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DirectMaterialSupplyAction")] 

    /// <summary>
    /// Doğrudan Malzeme Tedarik 22f
    /// </summary>
    public  partial class DirectMaterialSupplyAction : EpisodeAction
    {
        public class DirectMaterialSupplyActionList : TTObjectCollection<DirectMaterialSupplyAction> { }
                    
        public class ChildDirectMaterialSupplyActionCollection : TTObject.TTChildObjectCollection<DirectMaterialSupplyAction>
        {
            public ChildDirectMaterialSupplyActionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDirectMaterialSupplyActionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("043259e7-1cd5-49de-8fbe-f919b88b79ab"); } }
    /// <summary>
    /// İstek
    /// </summary>
            public static Guid Request { get { return new Guid("a9f5a477-a3f9-4574-964f-4fccf786d305"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("91f5a7b4-8100-4082-b6a5-9df3662f929d"); } }
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("07845ce7-7667-46bd-b427-374153efb69b"); } }
        }

    /// <summary>
    /// XXXXXX Kayıt ID ile Talep Sorgulama
    /// </summary>
        public static BindingList<DirectMaterialSupplyAction> GetDirectMatSupplyByXXXXXXId(TTObjectContext objectContext, int XXXXXXID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIRECTMATERIALSUPPLYACTION"].QueryDefs["GetDirectMatSupplyByXXXXXXId"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("XXXXXXID", XXXXXXID);

            return ((ITTQuery)objectContext).QueryObjects<DirectMaterialSupplyAction>(queryDef, paramList);
        }

    /// <summary>
    /// Karşılanma Tarihi
    /// </summary>
        public DateTime? DateOfSupply
        {
            get { return (DateTime?)this["DATEOFSUPPLY"]; }
            set { this["DATEOFSUPPLY"] = value; }
        }

    /// <summary>
    /// Acil
    /// </summary>
        public bool? IsImmediate
        {
            get { return (bool?)this["ISIMMEDIATE"]; }
            set { this["ISIMMEDIATE"] = value; }
        }

    /// <summary>
    /// Alım Türü
    /// </summary>
        public SupplyRequestTypeEnum? RequestType
        {
            get { return (SupplyRequestTypeEnum?)(int?)this["REQUESTTYPE"]; }
            set { this["REQUESTTYPE"] = value; }
        }

    /// <summary>
    /// XXXXXXEtkilenenAdet
    /// </summary>
        public int? XXXXXXEtkilenenAdet
        {
            get { return (int?)this["XXXXXXETKILENENADET"]; }
            set { this["XXXXXXETKILENENADET"] = value; }
        }

    /// <summary>
    /// XXXXXXIslemBasarili
    /// </summary>
        public bool? XXXXXXIslemBasarili
        {
            get { return (bool?)this["XXXXXXISLEMBASARILI"]; }
            set { this["XXXXXXISLEMBASARILI"] = value; }
        }

    /// <summary>
    /// XXXXXXKayitId
    /// </summary>
        public int? XXXXXXKayitId
        {
            get { return (int?)this["XXXXXXKAYITID"]; }
            set { this["XXXXXXKAYITID"] = value; }
        }

    /// <summary>
    /// XXXXXXMesaj
    /// </summary>
        public string XXXXXXMesaj
        {
            get { return (string)this["XXXXXXMESAJ"]; }
            set { this["XXXXXXMESAJ"] = value; }
        }

    /// <summary>
    /// Ameliyat Tarihi
    /// </summary>
        public DateTime? DateOfSurgery
        {
            get { return (DateTime?)this["DATEOFSURGERY"]; }
            set { this["DATEOFSURGERY"] = value; }
        }

    /// <summary>
    /// Gönderen Depo
    /// </summary>
        public Store Store
        {
            get { return (Store)((ITTObject)this).GetParent("STORE"); }
            set { this["STORE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Alan Depo
    /// </summary>
        public Store DestinationStore
        {
            get { return (Store)((ITTObject)this).GetParent("DESTINATIONSTORE"); }
            set { this["DESTINATIONSTORE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateDirectPurchaseSupplyGridsCollection()
        {
            _DirectPurchaseSupplyGrids = new DirectPurchaseGrid.ChildDirectPurchaseGridCollection(this, new Guid("8227f7e4-4684-44df-8823-e8d5e89c331d"));
            ((ITTChildObjectCollection)_DirectPurchaseSupplyGrids).GetChildren();
        }

        protected DirectPurchaseGrid.ChildDirectPurchaseGridCollection _DirectPurchaseSupplyGrids = null;
        public DirectPurchaseGrid.ChildDirectPurchaseGridCollection DirectPurchaseSupplyGrids
        {
            get
            {
                if (_DirectPurchaseSupplyGrids == null)
                    CreateDirectPurchaseSupplyGridsCollection();
                return _DirectPurchaseSupplyGrids;
            }
        }

        protected DirectMaterialSupplyAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DirectMaterialSupplyAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DirectMaterialSupplyAction(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DirectMaterialSupplyAction(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DirectMaterialSupplyAction(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DIRECTMATERIALSUPPLYACTION", dataRow) { }
        protected DirectMaterialSupplyAction(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DIRECTMATERIALSUPPLYACTION", dataRow, isImported) { }
        public DirectMaterialSupplyAction(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DirectMaterialSupplyAction(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DirectMaterialSupplyAction() : base() { }

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