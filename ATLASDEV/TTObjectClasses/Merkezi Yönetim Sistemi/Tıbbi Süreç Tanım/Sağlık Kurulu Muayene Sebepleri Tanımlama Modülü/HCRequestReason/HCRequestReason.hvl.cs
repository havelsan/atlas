
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HCRequestReason")] 

    /// <summary>
    /// Sağlık Kurulu İstek Sebebi
    /// </summary>
    public  partial class HCRequestReason : TerminologyManagerDef
    {
        public class HCRequestReasonList : TTObjectCollection<HCRequestReason> { }
                    
        public class ChildHCRequestReasonCollection : TTObject.TTChildObjectCollection<HCRequestReason>
        {
            public ChildHCRequestReasonCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHCRequestReasonCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<HCRequestReason> GetHCRequestReason(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HCREQUESTREASON"].QueryDefs["GetHCRequestReason"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<HCRequestReason>(queryDef, paramList);
        }

    /// <summary>
    /// İstek Nedeni
    /// </summary>
        public string ReasonName
        {
            get { return (string)this["REASONNAME"]; }
            set { this["REASONNAME"] = value; }
        }

    /// <summary>
    /// Dinamik(Ek alan raporları)
    /// </summary>
        public HCEDynamicReportTypeEnum? HCEReportType
        {
            get { return (HCEDynamicReportTypeEnum?)(int?)this["HCEREPORTTYPE"]; }
            set { this["HCEREPORTTYPE"] = value; }
        }

    /// <summary>
    /// İstek Nedeni
    /// </summary>
        public string ReasonName_Shadow
        {
            get { return (string)this["REASONNAME_SHADOW"]; }
        }

        public ReasonForExaminationDefinition ReasonForExamination
        {
            get { return (ReasonForExaminationDefinition)((ITTObject)this).GetParent("REASONFOREXAMINATION"); }
            set { this["REASONFOREXAMINATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected HCRequestReason(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HCRequestReason(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HCRequestReason(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HCRequestReason(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HCRequestReason(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HCREQUESTREASON", dataRow) { }
        protected HCRequestReason(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HCREQUESTREASON", dataRow, isImported) { }
        public HCRequestReason(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HCRequestReason(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HCRequestReason() : base() { }

    }
}