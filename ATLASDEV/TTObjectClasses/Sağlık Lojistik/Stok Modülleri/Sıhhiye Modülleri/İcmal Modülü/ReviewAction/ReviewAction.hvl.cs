
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ReviewAction")] 

    /// <summary>
    /// İcmal 
    /// </summary>
    public  partial class ReviewAction : StockAction, IAutoDocumentNumber, IAutoDocumentRecordLog, ICheckStockActionOutDetail
    {
        public class ReviewActionList : TTObjectCollection<ReviewAction> { }
                    
        public class ChildReviewActionCollection : TTObject.TTChildObjectCollection<ReviewAction>
        {
            public ChildReviewActionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildReviewActionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Cancelled { get { return new Guid("10ac470a-1d63-4f8a-b01a-77930e116afd"); } }
            public static Guid Completed { get { return new Guid("4f1deffe-650d-4d08-9ccd-76729fb35001"); } }
            public static Guid New { get { return new Guid("9f08b3ca-eb29-43a2-8c2b-a7e6773b188f"); } }
    /// <summary>
    /// Onay
    /// </summary>
            public static Guid Approval { get { return new Guid("d3593d08-77a9-49e5-8c20-078ecb2839e4"); } }
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
    /// İcmal Tipi
    /// </summary>
        public ReviewActionTypeEnum? ReviewActionType
        {
            get { return (ReviewActionTypeEnum?)(int?)this["REVIEWACTIONTYPE"]; }
            set { this["REVIEWACTIONTYPE"] = value; }
        }

        virtual protected void CreateReviewActionPatientDetsCollection()
        {
            _ReviewActionPatientDets = new ReviewActionPatientDet.ChildReviewActionPatientDetCollection(this, new Guid("b8341b62-28a9-485d-a300-ca815653dde2"));
            ((ITTChildObjectCollection)_ReviewActionPatientDets).GetChildren();
        }

        protected ReviewActionPatientDet.ChildReviewActionPatientDetCollection _ReviewActionPatientDets = null;
        public ReviewActionPatientDet.ChildReviewActionPatientDetCollection ReviewActionPatientDets
        {
            get
            {
                if (_ReviewActionPatientDets == null)
                    CreateReviewActionPatientDetsCollection();
                return _ReviewActionPatientDets;
            }
        }

        override protected void CreateStockActionDetailsCollectionViews()
        {
            base.CreateStockActionDetailsCollectionViews();
            _ReviewActionDetails = new ReviewActionDetail.ChildReviewActionDetailCollection(_StockActionDetails, "ReviewActionDetails");
        }

        private ReviewActionDetail.ChildReviewActionDetailCollection _ReviewActionDetails = null;
    /// <summary>
    /// Alt İşlemler
    /// </summary>
        public ReviewActionDetail.ChildReviewActionDetailCollection ReviewActionDetails
        {
            get
            {
                if (_StockActionDetails == null)
                    CreateStockActionDetailsCollection();
                return _ReviewActionDetails;
            }            
        }

        protected ReviewAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ReviewAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ReviewAction(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ReviewAction(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ReviewAction(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "REVIEWACTION", dataRow) { }
        protected ReviewAction(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "REVIEWACTION", dataRow, isImported) { }
        public ReviewAction(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ReviewAction(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ReviewAction() : base() { }

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