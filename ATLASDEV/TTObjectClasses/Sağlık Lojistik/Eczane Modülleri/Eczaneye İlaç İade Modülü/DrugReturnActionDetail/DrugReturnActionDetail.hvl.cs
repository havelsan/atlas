
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DrugReturnActionDetail")] 

    public  partial class DrugReturnActionDetail : TTObject
    {
        public class DrugReturnActionDetailList : TTObjectCollection<DrugReturnActionDetail> { }
                    
        public class ChildDrugReturnActionDetailCollection : TTObject.TTChildObjectCollection<DrugReturnActionDetail>
        {
            public ChildDrugReturnActionDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDrugReturnActionDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class DrugReturnDetailPercent_Class : TTReportNqlObject 
        {
            public Guid? Material
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIAL"]);
                }
            }

            public Object Amount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["AMOUNT"]);
                }
            }

            public Object Returnamount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["RETURNAMOUNT"]);
                }
            }

            public Guid? Storeid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOREID"]);
                }
            }

            public DrugReturnDetailPercent_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public DrugReturnDetailPercent_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected DrugReturnDetailPercent_Class() : base() { }
        }

        public static BindingList<DrugReturnActionDetail.DrugReturnDetailPercent_Class> DrugReturnDetailPercent(DateTime STARTDATE, DateTime ENDDATE, Guid MASTERRESOURCE, Guid DOCTOR, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGRETURNACTIONDETAIL"].QueryDefs["DrugReturnDetailPercent"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("MASTERRESOURCE", MASTERRESOURCE);
            paramList.Add("DOCTOR", DOCTOR);

            return TTReportNqlObject.QueryObjects<DrugReturnActionDetail.DrugReturnDetailPercent_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DrugReturnActionDetail.DrugReturnDetailPercent_Class> DrugReturnDetailPercent(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, Guid MASTERRESOURCE, Guid DOCTOR, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGRETURNACTIONDETAIL"].QueryDefs["DrugReturnDetailPercent"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("MASTERRESOURCE", MASTERRESOURCE);
            paramList.Add("DOCTOR", DOCTOR);

            return TTReportNqlObject.QueryObjects<DrugReturnActionDetail.DrugReturnDetailPercent_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Miktar
    /// </summary>
        public double? SendAmount
        {
            get { return (double?)this["SENDAMOUNT"]; }
            set { this["SENDAMOUNT"] = value; }
        }

    /// <summary>
    /// Kabul Edilen Miktar
    /// </summary>
        public double? Amount
        {
            get { return (double?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

    /// <summary>
    /// İlaç
    /// </summary>
        public string DrugName
        {
            get { return (string)this["DRUGNAME"]; }
            set { this["DRUGNAME"] = value; }
        }

        public DrugReturnAction DrugReturnAction
        {
            get { return (DrugReturnAction)((ITTObject)this).GetParent("DRUGRETURNACTION"); }
            set { this["DRUGRETURNACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DrugOrderTransaction DrugOrderTransaction
        {
            get { return (DrugOrderTransaction)((ITTObject)this).GetParent("DRUGORDERTRANSACTION"); }
            set { this["DRUGORDERTRANSACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateDrugOrderDetailsCollection()
        {
            _DrugOrderDetails = new DrugOrderDetail.ChildDrugOrderDetailCollection(this, new Guid("f02fd765-784a-4865-bb4e-298ce97a0aa4"));
            ((ITTChildObjectCollection)_DrugOrderDetails).GetChildren();
        }

        protected DrugOrderDetail.ChildDrugOrderDetailCollection _DrugOrderDetails = null;
        public DrugOrderDetail.ChildDrugOrderDetailCollection DrugOrderDetails
        {
            get
            {
                if (_DrugOrderDetails == null)
                    CreateDrugOrderDetailsCollection();
                return _DrugOrderDetails;
            }
        }

        protected DrugReturnActionDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DrugReturnActionDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DrugReturnActionDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DrugReturnActionDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DrugReturnActionDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DRUGRETURNACTIONDETAIL", dataRow) { }
        protected DrugReturnActionDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DRUGRETURNACTIONDETAIL", dataRow, isImported) { }
        public DrugReturnActionDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DrugReturnActionDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DrugReturnActionDetail() : base() { }

    }
}