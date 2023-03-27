
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SendingCheckedHealthCommiteeReportCHCRGrid")] 

    public  partial class SendingCheckedHealthCommiteeReportCHCRGrid : TTObject
    {
        public class SendingCheckedHealthCommiteeReportCHCRGridList : TTObjectCollection<SendingCheckedHealthCommiteeReportCHCRGrid> { }
                    
        public class ChildSendingCheckedHealthCommiteeReportCHCRGridCollection : TTObject.TTChildObjectCollection<SendingCheckedHealthCommiteeReportCHCRGrid>
        {
            public ChildSendingCheckedHealthCommiteeReportCHCRGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSendingCheckedHealthCommiteeReportCHCRGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Rapor No
    /// </summary>
        public long? ReportNo
        {
            get { return (long?)this["REPORTNO"]; }
            set { this["REPORTNO"] = value; }
        }

    /// <summary>
    /// Gönderi No
    /// </summary>
        public long? ConsignmentNo
        {
            get { return (long?)this["CONSIGNMENTNO"]; }
            set { this["CONSIGNMENTNO"] = value; }
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
    /// Gönderilecek Makam
    /// </summary>
        public ConfirmationUnitDefinition ConfirmationUnitDefinition
        {
            get { return (ConfirmationUnitDefinition)((ITTObject)this).GetParent("CONFIRMATIONUNITDEFINITION"); }
            set { this["CONFIRMATIONUNITDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Raporlar
    /// </summary>
        public SendingCheckedHealthCommitteeReport SendingCheckedHCReport
        {
            get { return (SendingCheckedHealthCommitteeReport)((ITTObject)this).GetParent("SENDINGCHECKEDHCREPORT"); }
            set { this["SENDINGCHECKEDHCREPORT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Sonuç
    /// </summary>
        public HealthCommitteControlResultDefinition Result
        {
            get { return (HealthCommitteControlResultDefinition)((ITTObject)this).GetParent("RESULT"); }
            set { this["RESULT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected SendingCheckedHealthCommiteeReportCHCRGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SendingCheckedHealthCommiteeReportCHCRGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SendingCheckedHealthCommiteeReportCHCRGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SendingCheckedHealthCommiteeReportCHCRGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SendingCheckedHealthCommiteeReportCHCRGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SENDINGCHECKEDHEALTHCOMMITEEREPORTCHCRGRID", dataRow) { }
        protected SendingCheckedHealthCommiteeReportCHCRGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SENDINGCHECKEDHEALTHCOMMITEEREPORTCHCRGRID", dataRow, isImported) { }
        public SendingCheckedHealthCommiteeReportCHCRGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SendingCheckedHealthCommiteeReportCHCRGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SendingCheckedHealthCommiteeReportCHCRGrid() : base() { }

    }
}