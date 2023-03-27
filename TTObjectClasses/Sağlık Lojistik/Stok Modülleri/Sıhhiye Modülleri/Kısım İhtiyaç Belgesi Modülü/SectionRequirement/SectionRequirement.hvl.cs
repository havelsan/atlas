
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SectionRequirement")] 

    /// <summary>
    /// Kısım İhtiyaç Belgesi için kullanılan temel sınıftır
    /// </summary>
    public  partial class SectionRequirement : StockAction, IAutoDocumentNumber, IStockTransferTransaction, IStockReservation
    {
        public class SectionRequirementList : TTObjectCollection<SectionRequirement> { }
                    
        public class ChildSectionRequirementCollection : TTObject.TTChildObjectCollection<SectionRequirement>
        {
            public ChildSectionRequirementCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSectionRequirementCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSectionRequirementCensusReport_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string RegistrationNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REGISTRATIONNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SECTIONREQUIREMENT"].AllPropertyDefs["REGISTRATIONNUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetSectionRequirementCensusReport_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSectionRequirementCensusReport_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSectionRequirementCensusReport_Class() : base() { }
        }

        new public static class States
        {
            public static Guid Cancelled { get { return new Guid("1ffd2c51-febe-4204-b94a-15a751efc300"); } }
            public static Guid Completed { get { return new Guid("009f2fa1-0a5f-429e-bdce-44cec879792a"); } }
    /// <summary>
    /// Belge Kayıt
    /// </summary>
            public static Guid New { get { return new Guid("56a04890-4d60-49be-9ebd-a7d0a9abe734"); } }
    /// <summary>
    /// Onay
    /// </summary>
            public static Guid Approval { get { return new Guid("8618dfbb-7984-4dbd-a09c-5d4e2cf886b1"); } }
    /// <summary>
    /// Stok Kart Kayıt
    /// </summary>
            public static Guid StockCardRegistry { get { return new Guid("c1bcbf15-f56b-4d0f-b303-f429d943cf1a"); } }
    /// <summary>
    /// Stok Kontrol
    /// </summary>
            public static Guid Control { get { return new Guid("c342c928-a0c7-4b6c-ae94-dd0cce5a6c6d"); } }
    /// <summary>
    /// İstek
    /// </summary>
            public static Guid Request { get { return new Guid("5948059c-fa77-455b-a494-940432bc2227"); } }
        }

        public static BindingList<SectionRequirement.GetSectionRequirementCensusReport_Class> GetSectionRequirementCensusReport(string TERMID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SECTIONREQUIREMENT"].QueryDefs["GetSectionRequirementCensusReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERMID", TERMID);

            return TTReportNqlObject.QueryObjects<SectionRequirement.GetSectionRequirementCensusReport_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SectionRequirement.GetSectionRequirementCensusReport_Class> GetSectionRequirementCensusReport(TTObjectContext objectContext, string TERMID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SECTIONREQUIREMENT"].QueryDefs["GetSectionRequirementCensusReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERMID", TERMID);

            return TTReportNqlObject.QueryObjects<SectionRequirement.GetSectionRequirementCensusReport_Class>(objectContext, queryDef, paramList, pi);
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
    /// Sipariş Adı
    /// </summary>
        public string OrderName
        {
            get { return (string)this["ORDERNAME"]; }
            set { this["ORDERNAME"] = value; }
        }

    /// <summary>
    /// Sipariş Miktarı
    /// </summary>
        public Currency? OrderAmount
        {
            get { return (Currency?)this["ORDERAMOUNT"]; }
            set { this["ORDERAMOUNT"] = value; }
        }

        public CMRAction CMRAction
        {
            get { return (CMRAction)((ITTObject)this).GetParent("CMRACTION"); }
            set { this["CMRACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        override protected void CreateStockActionDetailsCollectionViews()
        {
            base.CreateStockActionDetailsCollectionViews();
            _SectionRequirementMaterials = new SectionRequirementMaterial.ChildSectionRequirementMaterialCollection(_StockActionDetails, "SectionRequirementMaterials");
        }

        private SectionRequirementMaterial.ChildSectionRequirementMaterialCollection _SectionRequirementMaterials = null;
    /// <summary>
    /// Alt İşlemler
    /// </summary>
        public SectionRequirementMaterial.ChildSectionRequirementMaterialCollection SectionRequirementMaterials
        {
            get
            {
                if (_StockActionDetails == null)
                    CreateStockActionDetailsCollection();
                return _SectionRequirementMaterials;
            }            
        }

        protected SectionRequirement(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SectionRequirement(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SectionRequirement(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SectionRequirement(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SectionRequirement(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SECTIONREQUIREMENT", dataRow) { }
        protected SectionRequirement(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SECTIONREQUIREMENT", dataRow, isImported) { }
        public SectionRequirement(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SectionRequirement(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SectionRequirement() : base() { }

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