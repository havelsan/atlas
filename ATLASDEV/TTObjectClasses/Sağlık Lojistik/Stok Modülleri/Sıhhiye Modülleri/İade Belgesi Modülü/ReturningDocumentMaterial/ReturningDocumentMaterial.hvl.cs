
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ReturningDocumentMaterial")] 

    /// <summary>
    /// İade Belgesinde malzeme detaylarını tutan sınıftır
    /// </summary>
    public  partial class ReturningDocumentMaterial : StockActionDetailOut
    {
        public class ReturningDocumentMaterialList : TTObjectCollection<ReturningDocumentMaterial> { }
                    
        public class ChildReturningDocumentMaterialCollection : TTObject.TTChildObjectCollection<ReturningDocumentMaterial>
        {
            public ChildReturningDocumentMaterialCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildReturningDocumentMaterialCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetTotalReturningByYear_Class : TTReportNqlObject 
        {
            public Object Returningamount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["RETURNINGAMOUNT"]);
                }
            }

            public Guid? StockCard
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKCARD"]);
                }
            }

            public GetTotalReturningByYear_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetTotalReturningByYear_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetTotalReturningByYear_Class() : base() { }
        }

        public static BindingList<ReturningDocumentMaterial.GetTotalReturningByYear_Class> GetTotalReturningByYear(string STOREID, string STOCKCARDCLASSID, string STOCKCARDID, int YEAR, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RETURNINGDOCUMENTMATERIAL"].QueryDefs["GetTotalReturningByYear"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);
            paramList.Add("STOCKCARDCLASSID", STOCKCARDCLASSID);
            paramList.Add("STOCKCARDID", STOCKCARDID);
            paramList.Add("YEAR", YEAR);

            return TTReportNqlObject.QueryObjects<ReturningDocumentMaterial.GetTotalReturningByYear_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ReturningDocumentMaterial.GetTotalReturningByYear_Class> GetTotalReturningByYear(TTObjectContext objectContext, string STOREID, string STOCKCARDCLASSID, string STOCKCARDID, int YEAR, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RETURNINGDOCUMENTMATERIAL"].QueryDefs["GetTotalReturningByYear"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);
            paramList.Add("STOCKCARDCLASSID", STOCKCARDCLASSID);
            paramList.Add("STOCKCARDID", STOCKCARDID);
            paramList.Add("YEAR", YEAR);

            return TTReportNqlObject.QueryObjects<ReturningDocumentMaterial.GetTotalReturningByYear_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// İade Miktarı
    /// </summary>
        public Currency? RequireAmount
        {
            get { return (Currency?)this["REQUIREAMOUNT"]; }
            set { this["REQUIREAMOUNT"] = value; }
        }

        public Guid? ReturnDepStoreMatID
        {
            get { return (Guid?)this["RETURNDEPSTOREMATID"]; }
            set { this["RETURNDEPSTOREMATID"] = value; }
        }

        protected ReturningDocumentMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ReturningDocumentMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ReturningDocumentMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ReturningDocumentMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ReturningDocumentMaterial(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RETURNINGDOCUMENTMATERIAL", dataRow) { }
        protected ReturningDocumentMaterial(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RETURNINGDOCUMENTMATERIAL", dataRow, isImported) { }
        public ReturningDocumentMaterial(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ReturningDocumentMaterial(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ReturningDocumentMaterial() : base() { }

    }
}