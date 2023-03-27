
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="IBFDetDetailOut")] 

    /// <summary>
    /// İBF Detayları ana sınıfı (İBF Listesi Harici)
    /// </summary>
    public  abstract  partial class IBFDetDetailOut : IBFBaseDemandDetail
    {
        public class IBFDetDetailOutList : TTObjectCollection<IBFDetDetailOut> { }
                    
        public class ChildIBFDetDetailOutCollection : TTObject.TTChildObjectCollection<IBFDetDetailOut>
        {
            public ChildIBFDetDetailOutCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildIBFDetDetailOutCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetIBFDemandDetailOutQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
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

            public Object Unitprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["UNITPRICE"]);
                }
            }

            public Currency? RequestAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["IBFDETDETAILOUT"].AllPropertyDefs["REQUESTAMOUNT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public string DetailDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DETAILDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["IBFDETDETAILOUT"].AllPropertyDefs["DETAILDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetIBFDemandDetailOutQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetIBFDemandDetailOutQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetIBFDemandDetailOutQuery_Class() : base() { }
        }

        new public static class States
        {
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("28662ca0-6fd6-4a8f-8cd9-3dc69151b79f"); } }
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("bae6c84c-c920-41b2-9136-221e13a8b558"); } }
        }

        public static BindingList<IBFDetDetailOut.GetIBFDemandDetailOutQuery_Class> GetIBFDemandDetailOutQuery(Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["IBFDETDETAILOUT"].QueryDefs["GetIBFDemandDetailOutQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<IBFDetDetailOut.GetIBFDemandDetailOutQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<IBFDetDetailOut.GetIBFDemandDetailOutQuery_Class> GetIBFDemandDetailOutQuery(TTObjectContext objectContext, Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["IBFDETDETAILOUT"].QueryDefs["GetIBFDemandDetailOutQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<IBFDetDetailOut.GetIBFDemandDetailOutQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        protected IBFDetDetailOut(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected IBFDetDetailOut(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected IBFDetDetailOut(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected IBFDetDetailOut(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected IBFDetDetailOut(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "IBFDETDETAILOUT", dataRow) { }
        protected IBFDetDetailOut(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "IBFDETDETAILOUT", dataRow, isImported) { }
        public IBFDetDetailOut(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public IBFDetDetailOut(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public IBFDetDetailOut() : base() { }

    }
}