
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PresInfirmaryDocument")] 

    /// <summary>
    /// El Senedi Sarf İmal İstihsal Belgesi (Reçeteler İçin)
    /// </summary>
    public  partial class PresInfirmaryDocument : StockAction, IBasePrescriptionTransaction, IProductionConsumptionInfirmaryDocument, IStockConsumptionTransaction
    {
        public class PresInfirmaryDocumentList : TTObjectCollection<PresInfirmaryDocument> { }
                    
        public class ChildPresInfirmaryDocumentCollection : TTObject.TTChildObjectCollection<PresInfirmaryDocument>
        {
            public ChildPresInfirmaryDocumentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPresInfirmaryDocumentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
    /// <summary>
    /// Belge Kayıt
    /// </summary>
            public static Guid New { get { return new Guid("775ca1c6-11e0-42b3-982f-c68da09b6259"); } }
    /// <summary>
    /// Onay
    /// </summary>
            public static Guid Approval { get { return new Guid("3d2df455-7d4b-46b6-a97a-50baa3919382"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("4765234a-0cbd-4f3b-a940-dd19f38973fa"); } }
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancel { get { return new Guid("545ab470-9f01-4280-af4a-d3ca358dc661"); } }
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
            _PresInfirmaryDocumentOutMaterials = new PresInfirmaryDocMatOut.ChildPresInfirmaryDocMatOutCollection(_StockActionDetails, "PresInfirmaryDocumentOutMaterials");
            _PresInfirmaryDocumentInMaterials = new PresInfirmaryDocMaterialIn.ChildPresInfirmaryDocMaterialInCollection(_StockActionDetails, "PresInfirmaryDocumentInMaterials");
        }

        private PresInfirmaryDocMatOut.ChildPresInfirmaryDocMatOutCollection _PresInfirmaryDocumentOutMaterials = null;
    /// <summary>
    /// Alt İşlemler
    /// </summary>
        public PresInfirmaryDocMatOut.ChildPresInfirmaryDocMatOutCollection PresInfirmaryDocumentOutMaterials
        {
            get
            {
                if (_StockActionDetails == null)
                    CreateStockActionDetailsCollection();
                return _PresInfirmaryDocumentOutMaterials;
            }            
        }

        private PresInfirmaryDocMaterialIn.ChildPresInfirmaryDocMaterialInCollection _PresInfirmaryDocumentInMaterials = null;
    /// <summary>
    /// Alt İşlemler
    /// </summary>
        public PresInfirmaryDocMaterialIn.ChildPresInfirmaryDocMaterialInCollection PresInfirmaryDocumentInMaterials
        {
            get
            {
                if (_StockActionDetails == null)
                    CreateStockActionDetailsCollection();
                return _PresInfirmaryDocumentInMaterials;
            }            
        }

        protected PresInfirmaryDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PresInfirmaryDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PresInfirmaryDocument(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PresInfirmaryDocument(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PresInfirmaryDocument(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PRESINFIRMARYDOCUMENT", dataRow) { }
        protected PresInfirmaryDocument(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PRESINFIRMARYDOCUMENT", dataRow, isImported) { }
        public PresInfirmaryDocument(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PresInfirmaryDocument(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PresInfirmaryDocument() : base() { }

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