
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="LBPurchaseProjectDetailOutOfList")] 

    /// <summary>
    /// Lojistik ikmal faaliyetlerinde kullanılan temel detay sınıfıdır(İBF listesi harici)
    /// </summary>
    public  partial class LBPurchaseProjectDetailOutOfList : LBPurchaseProjectDetail
    {
        public class LBPurchaseProjectDetailOutOfListList : TTObjectCollection<LBPurchaseProjectDetailOutOfList> { }
                    
        public class ChildLBPurchaseProjectDetailOutOfListCollection : TTObject.TTChildObjectCollection<LBPurchaseProjectDetailOutOfList>
        {
            public ChildLBPurchaseProjectDetailOutOfListCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildLBPurchaseProjectDetailOutOfListCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetLBPurchaseDetailOutQuery_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LBPURCHASEPROJECTDETAILOUTOFLIST"].AllPropertyDefs["NSN"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LBPURCHASEPROJECTDETAILOUTOFLIST"].AllPropertyDefs["APPROVEDAMOUNT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public GetLBPurchaseDetailOutQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetLBPurchaseDetailOutQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetLBPurchaseDetailOutQuery_Class() : base() { }
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

        public static BindingList<LBPurchaseProjectDetailOutOfList.GetLBPurchaseDetailOutQuery_Class> GetLBPurchaseDetailOutQuery(Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LBPURCHASEPROJECTDETAILOUTOFLIST"].QueryDefs["GetLBPurchaseDetailOutQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<LBPurchaseProjectDetailOutOfList.GetLBPurchaseDetailOutQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<LBPurchaseProjectDetailOutOfList.GetLBPurchaseDetailOutQuery_Class> GetLBPurchaseDetailOutQuery(TTObjectContext objectContext, Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LBPURCHASEPROJECTDETAILOUTOFLIST"].QueryDefs["GetLBPurchaseDetailOutQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<LBPurchaseProjectDetailOutOfList.GetLBPurchaseDetailOutQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public LBPurchaseProject LBPurchaseProject
        {
            get { return (LBPurchaseProject)((ITTObject)this).GetParent("LBPURCHASEPROJECT"); }
            set { this["LBPURCHASEPROJECT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateAnnualRequirementDetailOutOfListsCollection()
        {
            _AnnualRequirementDetailOutOfLists = new AnnualRequirementDetailOutOfList.ChildAnnualRequirementDetailOutOfListCollection(this, new Guid("9efc425e-dc65-44fb-abc2-ed581780c0f9"));
            ((ITTChildObjectCollection)_AnnualRequirementDetailOutOfLists).GetChildren();
        }

        protected AnnualRequirementDetailOutOfList.ChildAnnualRequirementDetailOutOfListCollection _AnnualRequirementDetailOutOfLists = null;
        public AnnualRequirementDetailOutOfList.ChildAnnualRequirementDetailOutOfListCollection AnnualRequirementDetailOutOfLists
        {
            get
            {
                if (_AnnualRequirementDetailOutOfLists == null)
                    CreateAnnualRequirementDetailOutOfListsCollection();
                return _AnnualRequirementDetailOutOfLists;
            }
        }

        protected LBPurchaseProjectDetailOutOfList(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected LBPurchaseProjectDetailOutOfList(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected LBPurchaseProjectDetailOutOfList(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected LBPurchaseProjectDetailOutOfList(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected LBPurchaseProjectDetailOutOfList(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "LBPURCHASEPROJECTDETAILOUTOFLIST", dataRow) { }
        protected LBPurchaseProjectDetailOutOfList(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "LBPURCHASEPROJECTDETAILOUTOFLIST", dataRow, isImported) { }
        public LBPurchaseProjectDetailOutOfList(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public LBPurchaseProjectDetailOutOfList(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public LBPurchaseProjectDetailOutOfList() : base() { }

    }
}