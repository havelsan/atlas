
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PaymentAccountancy")] 

    /// <summary>
    /// Ödeme Yapan Saymanlık Makamı
    /// </summary>
    public  partial class PaymentAccountancy : TTDefinitionSet
    {
        public class PaymentAccountancyList : TTObjectCollection<PaymentAccountancy> { }
                    
        public class ChildPaymentAccountancyCollection : TTObject.TTChildObjectCollection<PaymentAccountancy>
        {
            public ChildPaymentAccountancyCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPaymentAccountancyCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class PaymentAccountancyDefFormNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? ObjectDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTDEFID"]);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public Boolean? IsActive
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISACTIVE"]);
                    if (val == null)
                        return null;
                    return (Boolean)Convert.ChangeType(val, typeof(Boolean)); 
                }
            }

            public DateTime? LastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LASTUPDATE"]);
                    if (val == null)
                        return null;
                    return (DateTime)Convert.ChangeType(val, typeof(DateTime)); 
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYMENTACCOUNTANCY"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public PaymentAccountancyDefFormNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public PaymentAccountancyDefFormNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected PaymentAccountancyDefFormNQL_Class() : base() { }
        }

        public static BindingList<PaymentAccountancy.PaymentAccountancyDefFormNQL_Class> PaymentAccountancyDefFormNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYMENTACCOUNTANCY"].QueryDefs["PaymentAccountancyDefFormNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PaymentAccountancy.PaymentAccountancyDefFormNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PaymentAccountancy.PaymentAccountancyDefFormNQL_Class> PaymentAccountancyDefFormNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYMENTACCOUNTANCY"].QueryDefs["PaymentAccountancyDefFormNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PaymentAccountancy.PaymentAccountancyDefFormNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Makam Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        protected PaymentAccountancy(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PaymentAccountancy(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PaymentAccountancy(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PaymentAccountancy(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PaymentAccountancy(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PAYMENTACCOUNTANCY", dataRow) { }
        protected PaymentAccountancy(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PAYMENTACCOUNTANCY", dataRow, isImported) { }
        public PaymentAccountancy(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PaymentAccountancy(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PaymentAccountancy() : base() { }

    }
}