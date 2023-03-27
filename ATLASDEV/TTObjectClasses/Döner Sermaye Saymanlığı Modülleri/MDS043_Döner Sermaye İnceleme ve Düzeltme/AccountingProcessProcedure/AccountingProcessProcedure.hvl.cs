
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AccountingProcessProcedure")] 

    /// <summary>
    /// DS İnceleme ve Düzeltme Hizmetleri
    /// </summary>
    public  partial class AccountingProcessProcedure : TTObject
    {
        public class AccountingProcessProcedureList : TTObjectCollection<AccountingProcessProcedure> { }
                    
        public class ChildAccountingProcessProcedureCollection : TTObject.TTChildObjectCollection<AccountingProcessProcedure>
        {
            public ChildAccountingProcessProcedureCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAccountingProcessProcedureCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public string ActionId
        {
            get { return (string)this["ACTIONID"]; }
            set { this["ACTIONID"] = value; }
        }

    /// <summary>
    /// Hasta/Kurum Payı
    /// </summary>
        public string OldShare
        {
            get { return (string)this["OLDSHARE"]; }
            set { this["OLDSHARE"] = value; }
        }

        public AccountTransactionShareEnum? NewShare
        {
            get { return (AccountTransactionShareEnum?)(int?)this["NEWSHARE"]; }
            set { this["NEWSHARE"] = value; }
        }

        public DateTime? OldDate
        {
            get { return (DateTime?)this["OLDDATE"]; }
            set { this["OLDDATE"] = value; }
        }

        public DateTime? NewDate
        {
            get { return (DateTime?)this["NEWDATE"]; }
            set { this["NEWDATE"] = value; }
        }

        public double? OldAmount
        {
            get { return (double?)this["OLDAMOUNT"]; }
            set { this["OLDAMOUNT"] = value; }
        }

        public int? NewAmount
        {
            get { return (int?)this["NEWAMOUNT"]; }
            set { this["NEWAMOUNT"] = value; }
        }

        public double? OldUnitPrice
        {
            get { return (double?)this["OLDUNITPRICE"]; }
            set { this["OLDUNITPRICE"] = value; }
        }

        public double? NewUnitPrice
        {
            get { return (double?)this["NEWUNITPRICE"]; }
            set { this["NEWUNITPRICE"] = value; }
        }

        public AccountTransactionStateEnum? OldStatus
        {
            get { return (AccountTransactionStateEnum?)(int?)this["OLDSTATUS"]; }
            set { this["OLDSTATUS"] = value; }
        }

        public AccountTrnsNewCancelStateEnum? NewStatus
        {
            get { return (AccountTrnsNewCancelStateEnum?)(int?)this["NEWSTATUS"]; }
            set { this["NEWSTATUS"] = value; }
        }

        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

        public string PackageInfo
        {
            get { return (string)this["PACKAGEINFO"]; }
            set { this["PACKAGEINFO"] = value; }
        }

        public string ExternalCode
        {
            get { return (string)this["EXTERNALCODE"]; }
            set { this["EXTERNALCODE"] = value; }
        }

        public string NewExternalCode
        {
            get { return (string)this["NEWEXTERNALCODE"]; }
            set { this["NEWEXTERNALCODE"] = value; }
        }

        public string NewDescription
        {
            get { return (string)this["NEWDESCRIPTION"]; }
            set { this["NEWDESCRIPTION"] = value; }
        }

        public string OldSubEpisode
        {
            get { return (string)this["OLDSUBEPISODE"]; }
            set { this["OLDSUBEPISODE"] = value; }
        }

        public AccountingProcess AccountingProcess
        {
            get { return (AccountingProcess)((ITTObject)this).GetParent("ACCOUNTINGPROCESS"); }
            set { this["ACCOUNTINGPROCESS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public AccountTransaction AccountTransaction
        {
            get { return (AccountTransaction)((ITTObject)this).GetParent("ACCOUNTTRANSACTION"); }
            set { this["ACCOUNTTRANSACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SubEpisode NewSubEpisode
        {
            get { return (SubEpisode)((ITTObject)this).GetParent("NEWSUBEPISODE"); }
            set { this["NEWSUBEPISODE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Fiyat Listesi Çarpanı
    /// </summary>
        public PriceMultiplierDefinition PricingListMultiplier
        {
            get { return (PriceMultiplierDefinition)((ITTObject)this).GetParent("PRICINGLISTMULTIPLIER"); }
            set { this["PRICINGLISTMULTIPLIER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected AccountingProcessProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AccountingProcessProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AccountingProcessProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AccountingProcessProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AccountingProcessProcedure(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ACCOUNTINGPROCESSPROCEDURE", dataRow) { }
        protected AccountingProcessProcedure(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ACCOUNTINGPROCESSPROCEDURE", dataRow, isImported) { }
        public AccountingProcessProcedure(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AccountingProcessProcedure(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AccountingProcessProcedure() : base() { }

    }
}