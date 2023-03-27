
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MBtSOperation")] 

    /// <summary>
    /// İşlem
    /// </summary>
    public  partial class MBtSOperation : TTObject
    {
        public class MBtSOperationList : TTObjectCollection<MBtSOperation> { }
                    
        public class ChildMBtSOperationCollection : TTObject.TTChildObjectCollection<MBtSOperation>
        {
            public ChildMBtSOperationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMBtSOperationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// İşlem Tarihi
    /// </summary>
        public DateTime? OperationDate
        {
            get { return (DateTime?)this["OPERATIONDATE"]; }
            set { this["OPERATIONDATE"] = value; }
        }

    /// <summary>
    /// Ceza
    /// </summary>
        public double? Retribution
        {
            get { return (double?)this["RETRIBUTION"]; }
            set { this["RETRIBUTION"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Comment
        {
            get { return (string)this["COMMENT"]; }
            set { this["COMMENT"] = value; }
        }

    /// <summary>
    /// İşlem Türü
    /// </summary>
        public string OperationType
        {
            get { return (string)this["OPERATIONTYPE"]; }
            set { this["OPERATIONTYPE"] = value; }
        }

    /// <summary>
    /// İşlem No
    /// </summary>
        public string OperationNo
        {
            get { return (string)this["OPERATIONNO"]; }
            set { this["OPERATIONNO"] = value; }
        }

    /// <summary>
    /// Toplam Tutar
    /// </summary>
        public double? Total
        {
            get { return (double?)this["TOTAL"]; }
            set { this["TOTAL"] = value; }
        }

    /// <summary>
    /// Ek Bilgiler
    /// </summary>
        public string Attachments
        {
            get { return (string)this["ATTACHMENTS"]; }
            set { this["ATTACHMENTS"] = value; }
        }

        public MBtSAccountancy Accountancy
        {
            get { return (MBtSAccountancy)((ITTObject)this).GetParent("ACCOUNTANCY"); }
            set { this["ACCOUNTANCY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MBtSConcerned Concerned
        {
            get { return (MBtSConcerned)((ITTObject)this).GetParent("CONCERNED"); }
            set { this["CONCERNED"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateBudgetYearCollection()
        {
            _BudgetYear = new MBtSBudgetYear.ChildMBtSBudgetYearCollection(this, new Guid("277c652d-2545-46f5-9b09-106eedb85df6"));
            ((ITTChildObjectCollection)_BudgetYear).GetChildren();
        }

        protected MBtSBudgetYear.ChildMBtSBudgetYearCollection _BudgetYear = null;
        public MBtSBudgetYear.ChildMBtSBudgetYearCollection BudgetYear
        {
            get
            {
                if (_BudgetYear == null)
                    CreateBudgetYearCollection();
                return _BudgetYear;
            }
        }

        protected MBtSOperation(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MBtSOperation(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MBtSOperation(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MBtSOperation(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MBtSOperation(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MBTSOPERATION", dataRow) { }
        protected MBtSOperation(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MBTSOPERATION", dataRow, isImported) { }
        public MBtSOperation(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MBtSOperation(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MBtSOperation() : base() { }

    }
}