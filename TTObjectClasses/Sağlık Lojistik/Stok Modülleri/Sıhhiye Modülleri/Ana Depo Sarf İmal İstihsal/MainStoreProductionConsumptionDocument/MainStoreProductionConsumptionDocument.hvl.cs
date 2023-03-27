
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MainStoreProductionConsumptionDocument")] 

    /// <summary>
    /// Ana Depodan Sarf İmal İstihsal Belgesi için kullanılan temel sınıftır
    /// </summary>
    public  partial class MainStoreProductionConsumptionDocument : StockAction, IStockOutTransaction, IAutoDocumentNumber
    {
        public class MainStoreProductionConsumptionDocumentList : TTObjectCollection<MainStoreProductionConsumptionDocument> { }
                    
        public class ChildMainStoreProductionConsumptionDocumentCollection : TTObject.TTChildObjectCollection<MainStoreProductionConsumptionDocument>
        {
            public ChildMainStoreProductionConsumptionDocumentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMainStoreProductionConsumptionDocumentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
    /// <summary>
    /// Belge Kayıt
    /// </summary>
            public static Guid New { get { return new Guid("17e1517f-6388-45bc-82ed-4f9f133dedbd"); } }
    /// <summary>
    /// Saymanlık Onayı
    /// </summary>
            public static Guid Approval { get { return new Guid("26c68c90-5830-4d90-8b25-5add622df5a2"); } }
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("a53af228-22ba-425a-8cc4-86353be3fbf8"); } }
    /// <summary>
    /// Stok Kart Kayıt
    /// </summary>
            public static Guid StockCardRegistry { get { return new Guid("d41b49cb-0bcf-489f-a418-d477a934b4dd"); } }
    /// <summary>
    /// Tamam
    /// </summary>
            public static Guid Completed { get { return new Guid("435a7286-3ef8-4c97-aa64-d58ac5c129c2"); } }
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
    /// Doldurma Tarihi
    /// </summary>
        public DateTime? FillingDate
        {
            get { return (DateTime?)this["FILLINGDATE"]; }
            set { this["FILLINGDATE"] = value; }
        }

    /// <summary>
    /// Başlangıç Tarihi
    /// </summary>
        public DateTime? StartDate
        {
            get { return (DateTime?)this["STARTDATE"]; }
            set { this["STARTDATE"] = value; }
        }

        override protected void CreateStockActionDetailsCollectionViews()
        {
            base.CreateStockActionDetailsCollectionViews();
            _MainStoreProductionConsumptionDocumentOutMaterials = new MainStoreProductionConsumptionDocumentMaterial.ChildMainStoreProductionConsumptionDocumentMaterialCollection(_StockActionDetails, "MainStoreProductionConsumptionDocumentOutMaterials");
        }

        private MainStoreProductionConsumptionDocumentMaterial.ChildMainStoreProductionConsumptionDocumentMaterialCollection _MainStoreProductionConsumptionDocumentOutMaterials = null;
    /// <summary>
    /// Alt İşlemler
    /// </summary>
        public MainStoreProductionConsumptionDocumentMaterial.ChildMainStoreProductionConsumptionDocumentMaterialCollection MainStoreProductionConsumptionDocumentOutMaterials
        {
            get
            {
                if (_StockActionDetails == null)
                    CreateStockActionDetailsCollection();
                return _MainStoreProductionConsumptionDocumentOutMaterials;
            }            
        }

        protected MainStoreProductionConsumptionDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MainStoreProductionConsumptionDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MainStoreProductionConsumptionDocument(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MainStoreProductionConsumptionDocument(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MainStoreProductionConsumptionDocument(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MAINSTOREPRODUCTIONCONSUMPTIONDOCUMENT", dataRow) { }
        protected MainStoreProductionConsumptionDocument(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MAINSTOREPRODUCTIONCONSUMPTIONDOCUMENT", dataRow, isImported) { }
        public MainStoreProductionConsumptionDocument(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MainStoreProductionConsumptionDocument(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MainStoreProductionConsumptionDocument() : base() { }

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