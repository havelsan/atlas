
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MKYSTrx")] 

    public  partial class MKYSTrx : TTObject
    {
        public class MKYSTrxList : TTObjectCollection<MKYSTrx> { }
                    
        public class ChildMKYSTrxCollection : TTObject.TTChildObjectCollection<MKYSTrx>
        {
            public ChildMKYSTrxCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMKYSTrxCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetRestMKYSInTrxs_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public int? MkysID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYSID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MKYSTRX"].AllPropertyDefs["MKYSID"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string MkysDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYSDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MKYSTRX"].AllPropertyDefs["MKYSDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Currency? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MKYSTRX"].AllPropertyDefs["AMOUNT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Object Restamount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["RESTAMOUNT"]);
                }
            }

            public DateTime? ExpirationDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXPIRATIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MKYSTRX"].AllPropertyDefs["EXPIRATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public int? MKYS_StokHareketID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_STOKHAREKETID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MKYSTRX"].AllPropertyDefs["MKYS_STOKHAREKETID"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public BigCurrency? UnitPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNITPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MKYSTRX"].AllPropertyDefs["UNITPRICE"].DataType;
                    return (BigCurrency?)dataType.ConvertValue(val);
                }
            }

            public long? VatRate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["VATRATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MKYSTRX"].AllPropertyDefs["VATRATE"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Guid? Material
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIAL"]);
                }
            }

            public string Barcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BARCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MKYSTRX"].AllPropertyDefs["BARCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public MKYS_EButceTurEnum? MKYS_Butce
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_BUTCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MKYSTRX"].AllPropertyDefs["MKYS_BUTCE"].DataType;
                    return (MKYS_EButceTurEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GetRestMKYSInTrxs_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetRestMKYSInTrxs_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetRestMKYSInTrxs_Class() : base() { }
        }

        public static BindingList<MKYSTrx.GetRestMKYSInTrxs_Class> GetRestMKYSInTrxs(Guid STOREID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MKYSTRX"].QueryDefs["GetRestMKYSInTrxs"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);

            return TTReportNqlObject.QueryObjects<MKYSTrx.GetRestMKYSInTrxs_Class>(queryDef, paramList, pi);
        }

        public static BindingList<MKYSTrx.GetRestMKYSInTrxs_Class> GetRestMKYSInTrxs(TTObjectContext objectContext, Guid STOREID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MKYSTRX"].QueryDefs["GetRestMKYSInTrxs"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);

            return TTReportNqlObject.QueryObjects<MKYSTrx.GetRestMKYSInTrxs_Class>(objectContext, queryDef, paramList, pi);
        }

        public int? MkysID
        {
            get { return (int?)this["MKYSID"]; }
            set { this["MKYSID"] = value; }
        }

    /// <summary>
    /// Miktar
    /// </summary>
        public Currency? Amount
        {
            get { return (Currency?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

    /// <summary>
    /// Birim Fiyatı
    /// </summary>
        public BigCurrency? UnitPrice
        {
            get { return (BigCurrency?)this["UNITPRICE"]; }
            set { this["UNITPRICE"] = value; }
        }

    /// <summary>
    /// KDV
    /// </summary>
        public long? VatRate
        {
            get { return (long?)this["VATRATE"]; }
            set { this["VATRATE"] = value; }
        }

    /// <summary>
    /// MkysDescription
    /// </summary>
        public string MkysDescription
        {
            get { return (string)this["MKYSDESCRIPTION"]; }
            set { this["MKYSDESCRIPTION"] = value; }
        }

    /// <summary>
    /// NATO Stok Nu.
    /// </summary>
        public string NATOStockNO
        {
            get { return (string)this["NATOSTOCKNO"]; }
            set { this["NATOSTOCKNO"] = value; }
        }

    /// <summary>
    /// İşlem Tarihi
    /// </summary>
        public DateTime? TransactionDate
        {
            get { return (DateTime?)this["TRANSACTIONDATE"]; }
            set { this["TRANSACTIONDATE"] = value; }
        }

        public int? TransactionID
        {
            get { return (int?)this["TRANSACTIONID"]; }
            set { this["TRANSACTIONID"] = value; }
        }

        public int? MKYS_StokHareketID
        {
            get { return (int?)this["MKYS_STOKHAREKETID"]; }
            set { this["MKYS_STOKHAREKETID"] = value; }
        }

    /// <summary>
    /// Son Kullanma Tarihi
    /// </summary>
        public DateTime? ExpirationDate
        {
            get { return (DateTime?)this["EXPIRATIONDATE"]; }
            set { this["EXPIRATIONDATE"] = value; }
        }

    /// <summary>
    /// MKYS Bütce
    /// </summary>
        public MKYS_EButceTurEnum? MKYS_Butce
        {
            get { return (MKYS_EButceTurEnum?)(int?)this["MKYS_BUTCE"]; }
            set { this["MKYS_BUTCE"] = value; }
        }

    /// <summary>
    /// Barkod
    /// </summary>
        public string Barcode
        {
            get { return (string)this["BARCODE"]; }
            set { this["BARCODE"] = value; }
        }

    /// <summary>
    /// Giriş/Çıkış
    /// </summary>
        public TransactionTypeEnum? InOut
        {
            get { return (TransactionTypeEnum?)(int?)this["INOUT"]; }
            set { this["INOUT"] = value; }
        }

        public Material Material
        {
            get { return (Material)((ITTObject)this).GetParent("MATERIAL"); }
            set { this["MATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MainStoreDefinition MainStoreDefinition
        {
            get { return (MainStoreDefinition)((ITTObject)this).GetParent("MAINSTOREDEFINITION"); }
            set { this["MAINSTOREDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateMKYSTrxDetailsCollection()
        {
            _MKYSTrxDetails = new MKYSTrxDetail.ChildMKYSTrxDetailCollection(this, new Guid("24314393-0daa-4ffc-893c-d7b38cf0dd20"));
            ((ITTChildObjectCollection)_MKYSTrxDetails).GetChildren();
        }

        protected MKYSTrxDetail.ChildMKYSTrxDetailCollection _MKYSTrxDetails = null;
        public MKYSTrxDetail.ChildMKYSTrxDetailCollection MKYSTrxDetails
        {
            get
            {
                if (_MKYSTrxDetails == null)
                    CreateMKYSTrxDetailsCollection();
                return _MKYSTrxDetails;
            }
        }

        virtual protected void CreateOutMKYSTrxDetailsCollection()
        {
            _OutMKYSTrxDetails = new MKYSTrxDetail.ChildMKYSTrxDetailCollection(this, new Guid("e2509401-2082-4d36-9653-9068cec0ef58"));
            ((ITTChildObjectCollection)_OutMKYSTrxDetails).GetChildren();
        }

        protected MKYSTrxDetail.ChildMKYSTrxDetailCollection _OutMKYSTrxDetails = null;
        public MKYSTrxDetail.ChildMKYSTrxDetailCollection OutMKYSTrxDetails
        {
            get
            {
                if (_OutMKYSTrxDetails == null)
                    CreateOutMKYSTrxDetailsCollection();
                return _OutMKYSTrxDetails;
            }
        }

        protected MKYSTrx(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MKYSTrx(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MKYSTrx(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MKYSTrx(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MKYSTrx(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MKYSTRX", dataRow) { }
        protected MKYSTrx(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MKYSTRX", dataRow, isImported) { }
        public MKYSTrx(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MKYSTrx(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MKYSTrx() : base() { }

    }
}