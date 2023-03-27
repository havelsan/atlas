
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="LBPurchaseProjectDetailInList")] 

    /// <summary>
    /// Lojistik ikmal faaliyetlerinde kullanılan temel detay sınıfıdır(İBF listesi dahili)
    /// </summary>
    public  partial class LBPurchaseProjectDetailInList : LBPurchaseProjectDetail
    {
        public class LBPurchaseProjectDetailInListList : TTObjectCollection<LBPurchaseProjectDetailInList> { }
                    
        public class ChildLBPurchaseProjectDetailInListCollection : TTObject.TTChildObjectCollection<LBPurchaseProjectDetailInList>
        {
            public ChildLBPurchaseProjectDetailInListCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildLBPurchaseProjectDetailInListCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetLBPurchaseProjectDetailInQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string NSN
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NSN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LBPURCHASEPROJECTDETAILINLIST"].AllPropertyDefs["NSN"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Material
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEITEMDEF"].AllPropertyDefs["ITEMNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DistributionType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISTRIBUTIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONTYPEDEFINITION"].AllPropertyDefs["DISTRIBUTIONTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Currency? ApprovedAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["APPROVEDAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LBPURCHASEPROJECTDETAILINLIST"].AllPropertyDefs["APPROVEDAMOUNT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? LastIBFRequestAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LASTIBFREQUESTAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LBPURCHASEPROJECTDETAILINLIST"].AllPropertyDefs["LASTIBFREQUESTAMOUNT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? ConsumptionAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CONSUMPTIONAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LBPURCHASEPROJECTDETAILINLIST"].AllPropertyDefs["CONSUMPTIONAMOUNT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public GetLBPurchaseProjectDetailInQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetLBPurchaseProjectDetailInQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetLBPurchaseProjectDetailInQuery_Class() : base() { }
        }

        new public static class States
        {
    /// <summary>
    /// Tamam
    /// </summary>
            public static Guid Completed { get { return new Guid("222ab4a0-5000-455c-9023-3630b0c02766"); } }
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("fcfa3d5d-5780-4b74-8f6e-7b3188e52e8a"); } }
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("cccf7119-49f4-4a37-9b44-de0b674ac4ff"); } }
        }

        public static BindingList<LBPurchaseProjectDetailInList.GetLBPurchaseProjectDetailInQuery_Class> GetLBPurchaseProjectDetailInQuery(Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LBPURCHASEPROJECTDETAILINLIST"].QueryDefs["GetLBPurchaseProjectDetailInQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<LBPurchaseProjectDetailInList.GetLBPurchaseProjectDetailInQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<LBPurchaseProjectDetailInList.GetLBPurchaseProjectDetailInQuery_Class> GetLBPurchaseProjectDetailInQuery(TTObjectContext objectContext, Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LBPURCHASEPROJECTDETAILINLIST"].QueryDefs["GetLBPurchaseProjectDetailInQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<LBPurchaseProjectDetailInList.GetLBPurchaseProjectDetailInQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public LBPurchaseProject LBPurchaseProject
        {
            get { return (LBPurchaseProject)((ITTObject)this).GetParent("LBPURCHASEPROJECT"); }
            set { this["LBPURCHASEPROJECT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateAnnualRequirementDetailInListsCollection()
        {
            _AnnualRequirementDetailInLists = new AnnualRequirementDetailInList.ChildAnnualRequirementDetailInListCollection(this, new Guid("a342e883-bcb2-41dc-8ed3-945e5daf30a5"));
            ((ITTChildObjectCollection)_AnnualRequirementDetailInLists).GetChildren();
        }

        protected AnnualRequirementDetailInList.ChildAnnualRequirementDetailInListCollection _AnnualRequirementDetailInLists = null;
        public AnnualRequirementDetailInList.ChildAnnualRequirementDetailInListCollection AnnualRequirementDetailInLists
        {
            get
            {
                if (_AnnualRequirementDetailInLists == null)
                    CreateAnnualRequirementDetailInListsCollection();
                return _AnnualRequirementDetailInLists;
            }
        }

        protected LBPurchaseProjectDetailInList(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected LBPurchaseProjectDetailInList(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected LBPurchaseProjectDetailInList(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected LBPurchaseProjectDetailInList(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected LBPurchaseProjectDetailInList(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "LBPURCHASEPROJECTDETAILINLIST", dataRow) { }
        protected LBPurchaseProjectDetailInList(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "LBPURCHASEPROJECTDETAILINLIST", dataRow, isImported) { }
        public LBPurchaseProjectDetailInList(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public LBPurchaseProjectDetailInList(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public LBPurchaseProjectDetailInList() : base() { }

    }
}