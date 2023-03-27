
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HCReportToBeSentItemsDefinition")] 

    /// <summary>
    /// Sağlık Kurulu Rapor Çıkış Gönderilecek Yer Tanımlama
    /// </summary>
    public  partial class HCReportToBeSentItemsDefinition : TerminologyManagerDef
    {
        public class HCReportToBeSentItemsDefinitionList : TTObjectCollection<HCReportToBeSentItemsDefinition> { }
                    
        public class ChildHCReportToBeSentItemsDefinitionCollection : TTObject.TTChildObjectCollection<HCReportToBeSentItemsDefinition>
        {
            public ChildHCReportToBeSentItemsDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHCReportToBeSentItemsDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetHCReportToBeSentItemsDefinition_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string HCReportToBeSentItem
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HCREPORTTOBESENTITEM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HCREPORTTOBESENTITEMSDEFINITION"].AllPropertyDefs["HCREPORTTOBESENTITEM"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetHCReportToBeSentItemsDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetHCReportToBeSentItemsDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetHCReportToBeSentItemsDefinition_Class() : base() { }
        }

        public static BindingList<HCReportToBeSentItemsDefinition.GetHCReportToBeSentItemsDefinition_Class> GetHCReportToBeSentItemsDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HCREPORTTOBESENTITEMSDEFINITION"].QueryDefs["GetHCReportToBeSentItemsDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<HCReportToBeSentItemsDefinition.GetHCReportToBeSentItemsDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<HCReportToBeSentItemsDefinition.GetHCReportToBeSentItemsDefinition_Class> GetHCReportToBeSentItemsDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HCREPORTTOBESENTITEMSDEFINITION"].QueryDefs["GetHCReportToBeSentItemsDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<HCReportToBeSentItemsDefinition.GetHCReportToBeSentItemsDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<HCReportToBeSentItemsDefinition> GetHCReportToBeSentDefByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HCREPORTTOBESENTITEMSDEFINITION"].QueryDefs["GetHCReportToBeSentDefByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<HCReportToBeSentItemsDefinition>(queryDef, paramList);
        }

    /// <summary>
    /// Gönderilecek Yer
    /// </summary>
        public string HCReportToBeSentItem
        {
            get { return (string)this["HCREPORTTOBESENTITEM"]; }
            set { this["HCREPORTTOBESENTITEM"] = value; }
        }

        protected HCReportToBeSentItemsDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HCReportToBeSentItemsDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HCReportToBeSentItemsDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HCReportToBeSentItemsDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HCReportToBeSentItemsDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HCREPORTTOBESENTITEMSDEFINITION", dataRow) { }
        protected HCReportToBeSentItemsDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HCREPORTTOBESENTITEMSDEFINITION", dataRow, isImported) { }
        public HCReportToBeSentItemsDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HCReportToBeSentItemsDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HCReportToBeSentItemsDefinition() : base() { }

    }
}