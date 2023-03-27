
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ItemTransfer")] 

    /// <summary>
    /// Lojistik Dairenin Yaptığı Muvazene Bilgilerini Tutan Sınıftır
    /// </summary>
    public  partial class ItemTransfer : TTObject
    {
        public class ItemTransferList : TTObjectCollection<ItemTransfer> { }
                    
        public class ChildItemTransferCollection : TTObject.TTChildObjectCollection<ItemTransfer>
        {
            public ChildItemTransferCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildItemTransferCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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

            public string ReportParagraph
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTPARAGRAPH"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ITEMTRANSFER"].AllPropertyDefs["REPORTPARAGRAPH"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Need
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NEED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ITEMTRANSFER"].AllPropertyDefs["NEED"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Info
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ITEMTRANSFER"].AllPropertyDefs["INFO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DateTimeGroup
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DATETIMEGROUP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ITEMTRANSFER"].AllPropertyDefs["DATETIMEGROUP"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string PrivacyLevel
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRIVACYLEVEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ITEMTRANSFER"].AllPropertyDefs["PRIVACYLEVEL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string FileNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FILENO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ITEMTRANSFER"].AllPropertyDefs["FILENO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MsgOrder
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MSGORDER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ITEMTRANSFER"].AllPropertyDefs["MSGORDER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string GroupFrontAddition
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GROUPFRONTADDITION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ITEMTRANSFER"].AllPropertyDefs["GROUPFRONTADDITION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public TertipEmriNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public TertipEmriNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected TertipEmriNQL_Class() : base() { }
        }

        public static BindingList<ItemTransfer.TertipEmriNQL_Class> TertipEmriNQL(string TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ITEMTRANSFER"].QueryDefs["TertipEmriNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<ItemTransfer.TertipEmriNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ItemTransfer.TertipEmriNQL_Class> TertipEmriNQL(TTObjectContext objectContext, string TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ITEMTRANSFER"].QueryDefs["TertipEmriNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<ItemTransfer.TertipEmriNQL_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Rapor Metni
    /// </summary>
        public string ReportParagraph
        {
            get { return (string)this["REPORTPARAGRAPH"]; }
            set { this["REPORTPARAGRAPH"] = value; }
        }

    /// <summary>
    /// Gereği
    /// </summary>
        public string Need
        {
            get { return (string)this["NEED"]; }
            set { this["NEED"] = value; }
        }

    /// <summary>
    /// Bilgi
    /// </summary>
        public string Info
        {
            get { return (string)this["INFO"]; }
            set { this["INFO"] = value; }
        }

    /// <summary>
    /// Tarih Saat Grubu
    /// </summary>
        public string DateTimeGroup
        {
            get { return (string)this["DATETIMEGROUP"]; }
            set { this["DATETIMEGROUP"] = value; }
        }

    /// <summary>
    /// Gizlilik Derecesi
    /// </summary>
        public string PrivacyLevel
        {
            get { return (string)this["PRIVACYLEVEL"]; }
            set { this["PRIVACYLEVEL"] = value; }
        }

    /// <summary>
    /// Dosya Numarası
    /// </summary>
        public string FileNo
        {
            get { return (string)this["FILENO"]; }
            set { this["FILENO"] = value; }
        }

    /// <summary>
    /// Mesaj Talimatı
    /// </summary>
        public string MsgOrder
        {
            get { return (string)this["MSGORDER"]; }
            set { this["MSGORDER"] = value; }
        }

    /// <summary>
    /// Grup-Ön Ek
    /// </summary>
        public string GroupFrontAddition
        {
            get { return (string)this["GROUPFRONTADDITION"]; }
            set { this["GROUPFRONTADDITION"] = value; }
        }

        public PurchaseProject PurchaseProject
        {
            get { return (PurchaseProject)((ITTObject)this).GetParent("PURCHASEPROJECT"); }
            set { this["PURCHASEPROJECT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Accountancy Accountancy
        {
            get { return (Accountancy)((ITTObject)this).GetParent("ACCOUNTANCY"); }
            set { this["ACCOUNTANCY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Kaleme Alan
    /// </summary>
        public ResUser Writer
        {
            get { return (ResUser)((ITTObject)this).GetParent("WRITER"); }
            set { this["WRITER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateItemTransferDetailsCollection()
        {
            _ItemTransferDetails = new ItemTransferDetail.ChildItemTransferDetailCollection(this, new Guid("1afaef09-d17c-4b9a-9dc9-ed4f263edb75"));
            ((ITTChildObjectCollection)_ItemTransferDetails).GetChildren();
        }

        protected ItemTransferDetail.ChildItemTransferDetailCollection _ItemTransferDetails = null;
        public ItemTransferDetail.ChildItemTransferDetailCollection ItemTransferDetails
        {
            get
            {
                if (_ItemTransferDetails == null)
                    CreateItemTransferDetailsCollection();
                return _ItemTransferDetails;
            }
        }

        protected ItemTransfer(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ItemTransfer(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ItemTransfer(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ItemTransfer(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ItemTransfer(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ITEMTRANSFER", dataRow) { }
        protected ItemTransfer(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ITEMTRANSFER", dataRow, isImported) { }
        public ItemTransfer(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ItemTransfer(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ItemTransfer() : base() { }

    }
}