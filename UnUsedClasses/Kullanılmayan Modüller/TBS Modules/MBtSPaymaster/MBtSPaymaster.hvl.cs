
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MBtSPaymaster")] 

    public  partial class MBtSPaymaster : TTObject
    {
        public class MBtSPaymasterList : TTObjectCollection<MBtSPaymaster> { }
                    
        public class ChildMBtSPaymasterCollection : TTObject.TTChildObjectCollection<MBtSPaymaster>
        {
            public ChildMBtSPaymasterCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMBtSPaymasterCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Çıkış nedeni
    /// </summary>
        public string DivorceReason
        {
            get { return (string)this["DIVORCEREASON"]; }
            set { this["DIVORCEREASON"] = value; }
        }

    /// <summary>
    /// Başlangıç tarihi
    /// </summary>
        public DateTime? StartDate
        {
            get { return (DateTime?)this["STARTDATE"]; }
            set { this["STARTDATE"] = value; }
        }

    /// <summary>
    /// Ad
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Çıkış tarihi
    /// </summary>
        public DateTime? DivorceDate
        {
            get { return (DateTime?)this["DIVORCEDATE"]; }
            set { this["DIVORCEDATE"] = value; }
        }

    /// <summary>
    /// Soyad
    /// </summary>
        public string Surname
        {
            get { return (string)this["SURNAME"]; }
            set { this["SURNAME"] = value; }
        }

        public MBtSAccountancy Accountancy
        {
            get { return (MBtSAccountancy)((ITTObject)this).GetParent("ACCOUNTANCY"); }
            set { this["ACCOUNTANCY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateFinanceCentersCollection()
        {
            _FinanceCenters = new MBtSFinanceCenter.ChildMBtSFinanceCenterCollection(this, new Guid("230f4c62-46e1-4c33-ac40-be91758a4952"));
            ((ITTChildObjectCollection)_FinanceCenters).GetChildren();
        }

        protected MBtSFinanceCenter.ChildMBtSFinanceCenterCollection _FinanceCenters = null;
        public MBtSFinanceCenter.ChildMBtSFinanceCenterCollection FinanceCenters
        {
            get
            {
                if (_FinanceCenters == null)
                    CreateFinanceCentersCollection();
                return _FinanceCenters;
            }
        }

        virtual protected void CreateAccountancyReceiptsCollection()
        {
            _AccountancyReceipts = new MBtSAccountancyReceipt.ChildMBtSAccountancyReceiptCollection(this, new Guid("ae7b22f0-f866-44a0-aa71-cc1b8cfd8067"));
            ((ITTChildObjectCollection)_AccountancyReceipts).GetChildren();
        }

        protected MBtSAccountancyReceipt.ChildMBtSAccountancyReceiptCollection _AccountancyReceipts = null;
        public MBtSAccountancyReceipt.ChildMBtSAccountancyReceiptCollection AccountancyReceipts
        {
            get
            {
                if (_AccountancyReceipts == null)
                    CreateAccountancyReceiptsCollection();
                return _AccountancyReceipts;
            }
        }

        protected MBtSPaymaster(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MBtSPaymaster(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MBtSPaymaster(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MBtSPaymaster(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MBtSPaymaster(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MBTSPAYMASTER", dataRow) { }
        protected MBtSPaymaster(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MBTSPAYMASTER", dataRow, isImported) { }
        public MBtSPaymaster(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MBtSPaymaster(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MBtSPaymaster() : base() { }

    }
}