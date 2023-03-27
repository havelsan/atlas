
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PurchaseProjectGroup")] 

    /// <summary>
    /// Mahalli Satınalmada İhale Tipi "Grup Toplam" İse, İHale Grupları İçin Kullanılan Sınıftır. Her Grup İçin Bir Adet Instance Yaratılır
    /// </summary>
    public  partial class PurchaseProjectGroup : TTObject
    {
        public class PurchaseProjectGroupList : TTObjectCollection<PurchaseProjectGroup> { }
                    
        public class ChildPurchaseProjectGroupCollection : TTObject.TTChildObjectCollection<PurchaseProjectGroup>
        {
            public ChildPurchaseProjectGroupCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPurchaseProjectGroupCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetProjectGroups_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? ObjectDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTDEFID"]);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public DateTime? LastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LASTUPDATE"]);
                    if (val == null)
                        return null;
                    return (DateTime)Convert.ChangeType(val, typeof(DateTime)); 
                }
            }

            public bool? GroupExcluded
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GROUPEXCLUDED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECTGROUP"].AllPropertyDefs["GROUPEXCLUDED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string GroupName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GROUPNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECTGROUP"].AllPropertyDefs["GROUPNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string GroupName_Shadow
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GROUPNAME_SHADOW"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECTGROUP"].AllPropertyDefs["GROUPNAME_SHADOW"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetProjectGroups_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetProjectGroups_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetProjectGroups_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("0063985e-77df-4502-bf88-0afdb2aadf09"); } }
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("7b15cd0b-9de7-42fb-9482-add7cb10a73d"); } }
        }

        public static BindingList<PurchaseProjectGroup.GetProjectGroups_Class> GetProjectGroups(string TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECTGROUP"].QueryDefs["GetProjectGroups"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<PurchaseProjectGroup.GetProjectGroups_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PurchaseProjectGroup.GetProjectGroups_Class> GetProjectGroups(TTObjectContext objectContext, string TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECTGROUP"].QueryDefs["GetProjectGroups"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<PurchaseProjectGroup.GetProjectGroups_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Grup Harici
    /// </summary>
        public bool? GroupExcluded
        {
            get { return (bool?)this["GROUPEXCLUDED"]; }
            set { this["GROUPEXCLUDED"] = value; }
        }

    /// <summary>
    /// Grup Adı
    /// </summary>
        public string GroupName
        {
            get { return (string)this["GROUPNAME"]; }
            set { this["GROUPNAME"] = value; }
        }

        public string GroupName_Shadow
        {
            get { return (string)this["GROUPNAME_SHADOW"]; }
        }

        public PurchaseProject PurchaseProject
        {
            get { return (PurchaseProject)((ITTObject)this).GetParent("PURCHASEPROJECT"); }
            set { this["PURCHASEPROJECT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Supplier BestSupplier
        {
            get { return (Supplier)((ITTObject)this).GetParent("BESTSUPPLIER"); }
            set { this["BESTSUPPLIER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Supplier SecondSupplier
        {
            get { return (Supplier)((ITTObject)this).GetParent("SECONDSUPPLIER"); }
            set { this["SECONDSUPPLIER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateGroupSumProposalsCollection()
        {
            _GroupSumProposals = new GroupSumProposal.ChildGroupSumProposalCollection(this, new Guid("5dcd7ff1-c7f8-4a63-83c3-0d1aed7b3deb"));
            ((ITTChildObjectCollection)_GroupSumProposals).GetChildren();
        }

        protected GroupSumProposal.ChildGroupSumProposalCollection _GroupSumProposals = null;
        public GroupSumProposal.ChildGroupSumProposalCollection GroupSumProposals
        {
            get
            {
                if (_GroupSumProposals == null)
                    CreateGroupSumProposalsCollection();
                return _GroupSumProposals;
            }
        }

        virtual protected void CreatePurchaseProjectDetailsCollection()
        {
            _PurchaseProjectDetails = new PurchaseProjectDetail.ChildPurchaseProjectDetailCollection(this, new Guid("04f99a21-0ca1-4716-a196-0a11a07f7415"));
            ((ITTChildObjectCollection)_PurchaseProjectDetails).GetChildren();
        }

        protected PurchaseProjectDetail.ChildPurchaseProjectDetailCollection _PurchaseProjectDetails = null;
        public PurchaseProjectDetail.ChildPurchaseProjectDetailCollection PurchaseProjectDetails
        {
            get
            {
                if (_PurchaseProjectDetails == null)
                    CreatePurchaseProjectDetailsCollection();
                return _PurchaseProjectDetails;
            }
        }

        protected PurchaseProjectGroup(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PurchaseProjectGroup(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PurchaseProjectGroup(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PurchaseProjectGroup(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PurchaseProjectGroup(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PURCHASEPROJECTGROUP", dataRow) { }
        protected PurchaseProjectGroup(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PURCHASEPROJECTGROUP", dataRow, isImported) { }
        public PurchaseProjectGroup(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PurchaseProjectGroup(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PurchaseProjectGroup() : base() { }

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