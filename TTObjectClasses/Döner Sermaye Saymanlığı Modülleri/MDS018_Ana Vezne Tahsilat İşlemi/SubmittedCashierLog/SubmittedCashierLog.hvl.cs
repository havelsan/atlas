
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SubmittedCashierLog")] 

    /// <summary>
    /// Teslim edilmiş Vezne açılış kapanış izi
    /// </summary>
    public  partial class SubmittedCashierLog : TTObject
    {
        public class SubmittedCashierLogList : TTObjectCollection<SubmittedCashierLog> { }
                    
        public class ChildSubmittedCashierLogCollection : TTObject.TTChildObjectCollection<SubmittedCashierLog>
        {
            public ChildSubmittedCashierLogCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSubmittedCashierLogCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Teslim
    /// </summary>
        public bool? Submit
        {
            get { return (bool?)this["SUBMIT"]; }
            set { this["SUBMIT"] = value; }
        }

    /// <summary>
    /// Teslim Edilen Tutar
    /// </summary>
        public Currency? SubmittedTotal
        {
            get { return (Currency?)this["SUBMITTEDTOTAL"]; }
            set { this["SUBMITTEDTOTAL"] = value; }
        }

    /// <summary>
    /// Vezne açılış kapanış iziyle İlişki
    /// </summary>
        public CashierLog CashierLog
        {
            get { return (CashierLog)((ITTObject)this).GetParent("CASHIERLOG"); }
            set { this["CASHIERLOG"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Vezne Tahsilat İşlemiyle İlişki
    /// </summary>
        public MainCashOfficeOperation MainCashOfficeOperation
        {
            get { return (MainCashOfficeOperation)((ITTObject)this).GetParent("MAINCASHOFFICEOPERATION"); }
            set { this["MAINCASHOFFICEOPERATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected SubmittedCashierLog(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SubmittedCashierLog(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SubmittedCashierLog(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SubmittedCashierLog(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SubmittedCashierLog(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SUBMITTEDCASHIERLOG", dataRow) { }
        protected SubmittedCashierLog(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SUBMITTEDCASHIERLOG", dataRow, isImported) { }
        public SubmittedCashierLog(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SubmittedCashierLog(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SubmittedCashierLog() : base() { }

    }
}