
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SendingCheckedHealthCommitteeReport")] 

    /// <summary>
    /// Kontrol Edilen Sağlık Kurulu Raporları Gönderme Modülü
    /// </summary>
    public  partial class SendingCheckedHealthCommitteeReport : EpisodeAction
    {
        public class SendingCheckedHealthCommitteeReportList : TTObjectCollection<SendingCheckedHealthCommitteeReport> { }
                    
        public class ChildSendingCheckedHealthCommitteeReportCollection : TTObject.TTChildObjectCollection<SendingCheckedHealthCommitteeReport>
        {
            public ChildSendingCheckedHealthCommitteeReportCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSendingCheckedHealthCommitteeReportCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid ParameterEntry { get { return new Guid("23d26ff0-6dbe-4a15-bc78-3fbaed27087e"); } }
            public static Guid ResultListConstitution { get { return new Guid("af935b77-1ec4-471a-825d-6d14f90ad9f6"); } }
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("ddd388ea-47a1-42df-9a48-ff24e556dedc"); } }
        }

    /// <summary>
    /// Başlangıç Tarihi
    /// </summary>
        public DateTime? HealthCommitteeStartDate
        {
            get { return (DateTime?)this["HEALTHCOMMITTEESTARTDATE"]; }
            set { this["HEALTHCOMMITTEESTARTDATE"] = value; }
        }

    /// <summary>
    /// Geri Gönderi No
    /// </summary>
        public long? SendBackNo
        {
            get { return (long?)this["SENDBACKNO"]; }
            set { this["SENDBACKNO"] = value; }
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
    /// Geri Gönderme Tarihi
    /// </summary>
        public DateTime? SendBackDate
        {
            get { return (DateTime?)this["SENDBACKDATE"]; }
            set { this["SENDBACKDATE"] = value; }
        }

    /// <summary>
    /// Geri Gönderi Notu
    /// </summary>
        public string SendBackNote
        {
            get { return (string)this["SENDBACKNOTE"]; }
            set { this["SENDBACKNOTE"] = value; }
        }

    /// <summary>
    /// Gönderilen Makam
    /// </summary>
        public ConfirmationUnitDefinition ChairToBeSend
        {
            get { return (ConfirmationUnitDefinition)((ITTObject)this).GetParent("CHAIRTOBESEND"); }
            set { this["CHAIRTOBESEND"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Sonuç
    /// </summary>
        public HealthCommitteControlResultDefinition Result
        {
            get { return (HealthCommitteControlResultDefinition)((ITTObject)this).GetParent("RESULT"); }
            set { this["RESULT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateReportsCollection()
        {
            _Reports = new SendingCheckedHealthCommiteeReportCHCRGrid.ChildSendingCheckedHealthCommiteeReportCHCRGridCollection(this, new Guid("26c67bf7-4e09-4734-b9f9-9688ea737aca"));
            ((ITTChildObjectCollection)_Reports).GetChildren();
        }

        protected SendingCheckedHealthCommiteeReportCHCRGrid.ChildSendingCheckedHealthCommiteeReportCHCRGridCollection _Reports = null;
    /// <summary>
    /// Child collection for Raporlar
    /// </summary>
        public SendingCheckedHealthCommiteeReportCHCRGrid.ChildSendingCheckedHealthCommiteeReportCHCRGridCollection Reports
        {
            get
            {
                if (_Reports == null)
                    CreateReportsCollection();
                return _Reports;
            }
        }

        protected SendingCheckedHealthCommitteeReport(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SendingCheckedHealthCommitteeReport(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SendingCheckedHealthCommitteeReport(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SendingCheckedHealthCommitteeReport(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SendingCheckedHealthCommitteeReport(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SENDINGCHECKEDHEALTHCOMMITTEEREPORT", dataRow) { }
        protected SendingCheckedHealthCommitteeReport(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SENDINGCHECKEDHEALTHCOMMITTEEREPORT", dataRow, isImported) { }
        public SendingCheckedHealthCommitteeReport(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SendingCheckedHealthCommitteeReport(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SendingCheckedHealthCommitteeReport() : base() { }

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