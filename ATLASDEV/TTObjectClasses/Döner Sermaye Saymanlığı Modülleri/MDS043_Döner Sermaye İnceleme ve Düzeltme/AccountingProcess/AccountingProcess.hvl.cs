
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AccountingProcess")] 

    /// <summary>
    /// Döner Sermaye İnceleme ve Düzeltme
    /// </summary>
    public  partial class AccountingProcess : EpisodeAccountAction, IWorkListEpisodeAction
    {
        public class AccountingProcessList : TTObjectCollection<AccountingProcess> { }
                    
        public class ChildAccountingProcessCollection : TTObject.TTChildObjectCollection<AccountingProcess>
        {
            public ChildAccountingProcessCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAccountingProcessCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("36c8dfcb-31ee-4b2d-89aa-d2228c0279f9"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("0e764f22-9c0c-4d5c-856f-61353a66ed75"); } }
        }

        public AccountTrnsNewCancelToBeNewStateEnum? STATUS
        {
            get { return (AccountTrnsNewCancelToBeNewStateEnum?)(int?)this["STATUS"]; }
            set { this["STATUS"] = value; }
        }

    /// <summary>
    /// Başlangıç Tarihi
    /// </summary>
        public DateTime? STARTDATE
        {
            get { return (DateTime?)this["STARTDATE"]; }
            set { this["STARTDATE"] = value; }
        }

    /// <summary>
    /// Bitiş Tarihi
    /// </summary>
        public DateTime? ENDDATE
        {
            get { return (DateTime?)this["ENDDATE"]; }
            set { this["ENDDATE"] = value; }
        }

    /// <summary>
    /// İşlem No
    /// </summary>
        public string EpisodeActionID
        {
            get { return (string)this["EPISODEACTIONID"]; }
            set { this["EPISODEACTIONID"] = value; }
        }

        public AccountTransactionShareEnum? NewShare
        {
            get { return (AccountTransactionShareEnum?)(int?)this["NEWSHARE"]; }
            set { this["NEWSHARE"] = value; }
        }

        public AccountTrnsNewCancelStateEnum? NewStatus
        {
            get { return (AccountTrnsNewCancelStateEnum?)(int?)this["NEWSTATUS"]; }
            set { this["NEWSTATUS"] = value; }
        }

        public DateTime? NewDate
        {
            get { return (DateTime?)this["NEWDATE"]; }
            set { this["NEWDATE"] = value; }
        }

    /// <summary>
    /// Hizmet
    /// </summary>
        public ProcedureDefinition Procedure
        {
            get { return (ProcedureDefinition)((ITTObject)this).GetParent("PROCEDURE"); }
            set { this["PROCEDURE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İlaç/Malzeme
    /// </summary>
        public Material Material
        {
            get { return (Material)((ITTObject)this).GetParent("MATERIAL"); }
            set { this["MATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public EpisodeProtocol EpisodeProtocol
        {
            get { return (EpisodeProtocol)((ITTObject)this).GetParent("EPISODEPROTOCOL"); }
            set { this["EPISODEPROTOCOL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Fiyat Listesi Çarpanı
    /// </summary>
        public PriceMultiplierDefinition NewPricingListMultiplier
        {
            get { return (PriceMultiplierDefinition)((ITTObject)this).GetParent("NEWPRICINGLISTMULTIPLIER"); }
            set { this["NEWPRICINGLISTMULTIPLIER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SubEpisode NewSubEpisode
        {
            get { return (SubEpisode)((ITTObject)this).GetParent("NEWSUBEPISODE"); }
            set { this["NEWSUBEPISODE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateAccountingProcessProceduresCollection()
        {
            _AccountingProcessProcedures = new AccountingProcessProcedure.ChildAccountingProcessProcedureCollection(this, new Guid("6616b531-eb01-4585-b8a4-5e1c9ea625aa"));
            ((ITTChildObjectCollection)_AccountingProcessProcedures).GetChildren();
        }

        protected AccountingProcessProcedure.ChildAccountingProcessProcedureCollection _AccountingProcessProcedures = null;
        public AccountingProcessProcedure.ChildAccountingProcessProcedureCollection AccountingProcessProcedures
        {
            get
            {
                if (_AccountingProcessProcedures == null)
                    CreateAccountingProcessProceduresCollection();
                return _AccountingProcessProcedures;
            }
        }

        virtual protected void CreateAccountingProcessMaterialsCollection()
        {
            _AccountingProcessMaterials = new AccountingProcessMaterial.ChildAccountingProcessMaterialCollection(this, new Guid("a8277941-9742-4b8b-9952-875ebc240cbb"));
            ((ITTChildObjectCollection)_AccountingProcessMaterials).GetChildren();
        }

        protected AccountingProcessMaterial.ChildAccountingProcessMaterialCollection _AccountingProcessMaterials = null;
        public AccountingProcessMaterial.ChildAccountingProcessMaterialCollection AccountingProcessMaterials
        {
            get
            {
                if (_AccountingProcessMaterials == null)
                    CreateAccountingProcessMaterialsCollection();
                return _AccountingProcessMaterials;
            }
        }

        virtual protected void CreateAccountingProcessPackagesCollection()
        {
            _AccountingProcessPackages = new AccountingProcessPackage.ChildAccountingProcessPackageCollection(this, new Guid("e074a743-249f-4c9a-b6f8-227d1f26f4fb"));
            ((ITTChildObjectCollection)_AccountingProcessPackages).GetChildren();
        }

        protected AccountingProcessPackage.ChildAccountingProcessPackageCollection _AccountingProcessPackages = null;
        public AccountingProcessPackage.ChildAccountingProcessPackageCollection AccountingProcessPackages
        {
            get
            {
                if (_AccountingProcessPackages == null)
                    CreateAccountingProcessPackagesCollection();
                return _AccountingProcessPackages;
            }
        }

        virtual protected void CreateAccountingProcessProtocolsCollection()
        {
            _AccountingProcessProtocols = new AccountingProcessProtocol.ChildAccountingProcessProtocolCollection(this, new Guid("5e7ad52f-fa9e-4431-a543-c4212ddf5078"));
            ((ITTChildObjectCollection)_AccountingProcessProtocols).GetChildren();
        }

        protected AccountingProcessProtocol.ChildAccountingProcessProtocolCollection _AccountingProcessProtocols = null;
        public AccountingProcessProtocol.ChildAccountingProcessProtocolCollection AccountingProcessProtocols
        {
            get
            {
                if (_AccountingProcessProtocols == null)
                    CreateAccountingProcessProtocolsCollection();
                return _AccountingProcessProtocols;
            }
        }

        virtual protected void CreateAccountingProcessActionsCollection()
        {
            _AccountingProcessActions = new AccountingProcessAction.ChildAccountingProcessActionCollection(this, new Guid("0e752807-426f-40a4-be13-5aec19bd4f5d"));
            ((ITTChildObjectCollection)_AccountingProcessActions).GetChildren();
        }

        protected AccountingProcessAction.ChildAccountingProcessActionCollection _AccountingProcessActions = null;
        public AccountingProcessAction.ChildAccountingProcessActionCollection AccountingProcessActions
        {
            get
            {
                if (_AccountingProcessActions == null)
                    CreateAccountingProcessActionsCollection();
                return _AccountingProcessActions;
            }
        }

        protected AccountingProcess(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AccountingProcess(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AccountingProcess(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AccountingProcess(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AccountingProcess(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ACCOUNTINGPROCESS", dataRow) { }
        protected AccountingProcess(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ACCOUNTINGPROCESS", dataRow, isImported) { }
        public AccountingProcess(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AccountingProcess(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AccountingProcess() : base() { }

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