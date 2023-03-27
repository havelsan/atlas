
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AccountingProcessAction")] 

    /// <summary>
    /// DS İnceleme ve Düzeltme İşlemleri
    /// </summary>
    public  partial class AccountingProcessAction : TTObject
    {
        public class AccountingProcessActionList : TTObjectCollection<AccountingProcessAction> { }
                    
        public class ChildAccountingProcessActionCollection : TTObject.TTChildObjectCollection<AccountingProcessAction>
        {
            public ChildAccountingProcessActionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAccountingProcessActionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// İşlem Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public string OldSubEpisode
        {
            get { return (string)this["OLDSUBEPISODE"]; }
            set { this["OLDSUBEPISODE"] = value; }
        }

        public SubEpisode NewSubEpisode
        {
            get { return (SubEpisode)((ITTObject)this).GetParent("NEWSUBEPISODE"); }
            set { this["NEWSUBEPISODE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public EpisodeAction EpisodeAction
        {
            get { return (EpisodeAction)((ITTObject)this).GetParent("EPISODEACTION"); }
            set { this["EPISODEACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public AccountingProcess AccountingProcess
        {
            get { return (AccountingProcess)((ITTObject)this).GetParent("ACCOUNTINGPROCESS"); }
            set { this["ACCOUNTINGPROCESS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected AccountingProcessAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AccountingProcessAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AccountingProcessAction(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AccountingProcessAction(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AccountingProcessAction(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ACCOUNTINGPROCESSACTION", dataRow) { }
        protected AccountingProcessAction(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ACCOUNTINGPROCESSACTION", dataRow, isImported) { }
        public AccountingProcessAction(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AccountingProcessAction(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AccountingProcessAction() : base() { }

    }
}