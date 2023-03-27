
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ItemTransferDetail")] 

    /// <summary>
    /// Lojistik Dairenin Yaptığı Muvazene Detay Bilgilerini Tutan Sınıftır
    /// </summary>
    public  partial class ItemTransferDetail : TTObject
    {
        public class ItemTransferDetailList : TTObjectCollection<ItemTransferDetail> { }
                    
        public class ChildItemTransferDetailCollection : TTObject.TTChildObjectCollection<ItemTransferDetail>
        {
            public ChildItemTransferDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildItemTransferDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class TertipEmriNQL_Class : TTReportNqlObject 
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

            public double? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ITEMTRANSFERDETAIL"].AllPropertyDefs["AMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string Purchaseitemdef
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PURCHASEITEMDEF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEITEMDEF"].AllPropertyDefs["ITEMNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Purchaseitemunittype
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PURCHASEITEMUNITTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONTYPEDEFINITION"].AllPropertyDefs["DISTRIBUTIONTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Targetmilitaryunit
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TARGETMILITARYUNIT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MILITARYUNIT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public TertipEmriNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public TertipEmriNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected TertipEmriNQL_Class() : base() { }
        }

        public static BindingList<ItemTransferDetail.TertipEmriNQL_Class> TertipEmriNQL(string TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ITEMTRANSFERDETAIL"].QueryDefs["TertipEmriNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<ItemTransferDetail.TertipEmriNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ItemTransferDetail.TertipEmriNQL_Class> TertipEmriNQL(TTObjectContext objectContext, string TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ITEMTRANSFERDETAIL"].QueryDefs["TertipEmriNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<ItemTransferDetail.TertipEmriNQL_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Miktar
    /// </summary>
        public double? Amount
        {
            get { return (double?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

        public ItemTransfer ItemTransfer
        {
            get { return (ItemTransfer)((ITTObject)this).GetParent("ITEMTRANSFER"); }
            set { this["ITEMTRANSFER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PurchaseItemDef PurchaseItemDef
        {
            get { return (PurchaseItemDef)((ITTObject)this).GetParent("PURCHASEITEMDEF"); }
            set { this["PURCHASEITEMDEF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ItemTransferDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ItemTransferDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ItemTransferDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ItemTransferDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ItemTransferDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ITEMTRANSFERDETAIL", dataRow) { }
        protected ItemTransferDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ITEMTRANSFERDETAIL", dataRow, isImported) { }
        public ItemTransferDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ItemTransferDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ItemTransferDetail() : base() { }

    }
}