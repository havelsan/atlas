
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HealthCommitteeOfProfessorsApproval")] 

    /// <summary>
    /// Profesörler Sağlık Kurulu Onay İşlemi
    /// </summary>
    public  partial class HealthCommitteeOfProfessorsApproval : BaseHealthCommitteeExamination
    {
        public class HealthCommitteeOfProfessorsApprovalList : TTObjectCollection<HealthCommitteeOfProfessorsApproval> { }
                    
        public class ChildHealthCommitteeOfProfessorsApprovalCollection : TTObject.TTChildObjectCollection<HealthCommitteeOfProfessorsApproval>
        {
            public ChildHealthCommitteeOfProfessorsApprovalCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHealthCommitteeOfProfessorsApprovalCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Tamam
    /// </summary>
            public static Guid Completed { get { return new Guid("caa21cf1-7cdf-4b9d-879b-9bb47ba0f2e5"); } }
    /// <summary>
    /// Reddedildi
    /// </summary>
            public static Guid Rejected { get { return new Guid("cfe84046-10ba-4412-bec7-7f4d27b56a42"); } }
    /// <summary>
    /// İstek
    /// </summary>
            public static Guid Request { get { return new Guid("1703d7ae-37bf-40ba-ad00-41c9271e3c75"); } }
    /// <summary>
    /// Sekreterde
    /// </summary>
            public static Guid HCPSecretary { get { return new Guid("77372d8b-fa4c-4f20-b944-80b4b568eac4"); } }
    /// <summary>
    /// Bölüm Başkanı Onay
    /// </summary>
            public static Guid Approval { get { return new Guid("288df428-9325-4ae5-968d-83d3d8c91361"); } }
        }

    /// <summary>
    /// Onay İşlemleri için
    /// </summary>
        public HealthCommitteeOfProfessors HCPApprovalAction
        {
            get { return (HealthCommitteeOfProfessors)((ITTObject)this).GetParent("HCPAPPROVALACTION"); }
            set { this["HCPAPPROVALACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateReturnDescriptionsCollection()
        {
            _ReturnDescriptions = new HealthCommittee_ReturnDescriptionsGrid.ChildHealthCommittee_ReturnDescriptionsGridCollection(this, new Guid("537d6f15-46c2-46f2-abed-eef95b35f148"));
            ((ITTChildObjectCollection)_ReturnDescriptions).GetChildren();
        }

        protected HealthCommittee_ReturnDescriptionsGrid.ChildHealthCommittee_ReturnDescriptionsGridCollection _ReturnDescriptions = null;
        public HealthCommittee_ReturnDescriptionsGrid.ChildHealthCommittee_ReturnDescriptionsGridCollection ReturnDescriptions
        {
            get
            {
                if (_ReturnDescriptions == null)
                    CreateReturnDescriptionsCollection();
                return _ReturnDescriptions;
            }
        }

        protected HealthCommitteeOfProfessorsApproval(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HealthCommitteeOfProfessorsApproval(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HealthCommitteeOfProfessorsApproval(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HealthCommitteeOfProfessorsApproval(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HealthCommitteeOfProfessorsApproval(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HEALTHCOMMITTEEOFPROFESSORSAPPROVAL", dataRow) { }
        protected HealthCommitteeOfProfessorsApproval(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HEALTHCOMMITTEEOFPROFESSORSAPPROVAL", dataRow, isImported) { }
        public HealthCommitteeOfProfessorsApproval(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HealthCommitteeOfProfessorsApproval(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HealthCommitteeOfProfessorsApproval() : base() { }

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