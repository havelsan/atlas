
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MBtSFinanceEntry")] 

    public  partial class MBtSFinanceEntry : TTObject
    {
        public class MBtSFinanceEntryList : TTObjectCollection<MBtSFinanceEntry> { }
                    
        public class ChildMBtSFinanceEntryCollection : TTObject.TTChildObjectCollection<MBtSFinanceEntry>
        {
            public ChildMBtSFinanceEntryCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMBtSFinanceEntryCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Tanım
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
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
    /// Finansman Tipi
    /// </summary>
        public int? FinanceType
        {
            get { return (int?)this["FINANCETYPE"]; }
            set { this["FINANCETYPE"] = value; }
        }

    /// <summary>
    /// Mali İşlem
    /// </summary>
        public bool? FinanceOperation
        {
            get { return (bool?)this["FINANCEOPERATION"]; }
            set { this["FINANCEOPERATION"] = value; }
        }

    /// <summary>
    /// ????????????????????????
    /// </summary>
        public MBtSAdditionalFund AdditionalFund
        {
            get { return (MBtSAdditionalFund)((ITTObject)this).GetParent("ADDITIONALFUND"); }
            set { this["ADDITIONALFUND"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MBtSAdvanceCredit AdvanceCredit
        {
            get { return (MBtSAdvanceCredit)((ITTObject)this).GetParent("ADVANCECREDIT"); }
            set { this["ADVANCECREDIT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MBtSIncomingDeductionOrder IncomingDeductionOrder
        {
            get { return (MBtSIncomingDeductionOrder)((ITTObject)this).GetParent("INCOMINGDEDUCTIONORDER"); }
            set { this["INCOMINGDEDUCTIONORDER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MBtSFinanceEntry ParentFinanceEntry
        {
            get { return (MBtSFinanceEntry)((ITTObject)this).GetParent("PARENTFINANCEENTRY"); }
            set { this["PARENTFINANCEENTRY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MBtSOperationEntry OperationEntry
        {
            get { return (MBtSOperationEntry)((ITTObject)this).GetParent("OPERATIONENTRY"); }
            set { this["OPERATIONENTRY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MBtSFinanceCenter FinanceCenter
        {
            get { return (MBtSFinanceCenter)((ITTObject)this).GetParent("FINANCECENTER"); }
            set { this["FINANCECENTER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MBtSAccountancyEntry AccountancyEntry
        {
            get { return (MBtSAccountancyEntry)((ITTObject)this).GetParent("ACCOUNTANCYENTRY"); }
            set { this["ACCOUNTANCYENTRY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateProjectsCollection()
        {
            _Projects = new MBtSProject.ChildMBtSProjectCollection(this, new Guid("21b7ba24-bc96-483a-afa1-5ed6f50cb8be"));
            ((ITTChildObjectCollection)_Projects).GetChildren();
        }

        protected MBtSProject.ChildMBtSProjectCollection _Projects = null;
        public MBtSProject.ChildMBtSProjectCollection Projects
        {
            get
            {
                if (_Projects == null)
                    CreateProjectsCollection();
                return _Projects;
            }
        }

        protected MBtSFinanceEntry(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MBtSFinanceEntry(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MBtSFinanceEntry(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MBtSFinanceEntry(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MBtSFinanceEntry(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MBTSFINANCEENTRY", dataRow) { }
        protected MBtSFinanceEntry(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MBTSFINANCEENTRY", dataRow, isImported) { }
        public MBtSFinanceEntry(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MBtSFinanceEntry(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MBtSFinanceEntry() : base() { }

    }
}