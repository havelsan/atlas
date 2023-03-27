
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HealthCommitteControlResultDefinition")] 

    /// <summary>
    /// Sağlık Kurulu Kontrol Sonuç
    /// </summary>
    public  partial class HealthCommitteControlResultDefinition : TTDefinitionSet
    {
        public class HealthCommitteControlResultDefinitionList : TTObjectCollection<HealthCommitteControlResultDefinition> { }
                    
        public class ChildHealthCommitteControlResultDefinitionCollection : TTObject.TTChildObjectCollection<HealthCommitteControlResultDefinition>
        {
            public ChildHealthCommitteControlResultDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHealthCommitteControlResultDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Sonuç
    /// </summary>
        public string Result
        {
            get { return (string)this["RESULT"]; }
            set { this["RESULT"] = value; }
        }

        virtual protected void CreateSendingCheckedHealthComiteeReportCHCRGridCollection()
        {
            _SendingCheckedHealthComiteeReportCHCRGrid = new SendingCheckedHealthCommiteeReportCHCRGrid.ChildSendingCheckedHealthCommiteeReportCHCRGridCollection(this, new Guid("f631761e-3470-4c66-b7af-bf1ae2d62580"));
            ((ITTChildObjectCollection)_SendingCheckedHealthComiteeReportCHCRGrid).GetChildren();
        }

        protected SendingCheckedHealthCommiteeReportCHCRGrid.ChildSendingCheckedHealthCommiteeReportCHCRGridCollection _SendingCheckedHealthComiteeReportCHCRGrid = null;
    /// <summary>
    /// Child collection for Sonuç
    /// </summary>
        public SendingCheckedHealthCommiteeReportCHCRGrid.ChildSendingCheckedHealthCommiteeReportCHCRGridCollection SendingCheckedHealthComiteeReportCHCRGrid
        {
            get
            {
                if (_SendingCheckedHealthComiteeReportCHCRGrid == null)
                    CreateSendingCheckedHealthComiteeReportCHCRGridCollection();
                return _SendingCheckedHealthComiteeReportCHCRGrid;
            }
        }

        protected HealthCommitteControlResultDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HealthCommitteControlResultDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HealthCommitteControlResultDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HealthCommitteControlResultDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HealthCommitteControlResultDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HEALTHCOMMITTECONTROLRESULTDEFINITION", dataRow) { }
        protected HealthCommitteControlResultDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HEALTHCOMMITTECONTROLRESULTDEFINITION", dataRow, isImported) { }
        public HealthCommitteControlResultDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HealthCommitteControlResultDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HealthCommitteControlResultDefinition() : base() { }

    }
}