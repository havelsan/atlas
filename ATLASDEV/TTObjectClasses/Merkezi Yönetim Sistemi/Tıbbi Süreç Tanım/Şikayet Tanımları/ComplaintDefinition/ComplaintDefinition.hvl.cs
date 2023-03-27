
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ComplaintDefinition")] 

    public  partial class ComplaintDefinition : TerminologyManagerDef
    {
        public class ComplaintDefinitionList : TTObjectCollection<ComplaintDefinition> { }
                    
        public class ChildComplaintDefinitionCollection : TTObject.TTChildObjectCollection<ComplaintDefinition>
        {
            public ChildComplaintDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildComplaintDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetComplaintDefinitionList_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMPLAINTDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetComplaintDefinitionList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetComplaintDefinitionList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetComplaintDefinitionList_Class() : base() { }
        }

        public static BindingList<ComplaintDefinition.GetComplaintDefinitionList_Class> GetComplaintDefinitionList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMPLAINTDEFINITION"].QueryDefs["GetComplaintDefinitionList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ComplaintDefinition.GetComplaintDefinitionList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ComplaintDefinition.GetComplaintDefinitionList_Class> GetComplaintDefinitionList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMPLAINTDEFINITION"].QueryDefs["GetComplaintDefinitionList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ComplaintDefinition.GetComplaintDefinitionList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

        public SpecialityDefinition SpecialityDefinition
        {
            get { return (SpecialityDefinition)((ITTObject)this).GetParent("SPECIALITYDEFINITION"); }
            set { this["SPECIALITYDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ComplaintDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ComplaintDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ComplaintDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ComplaintDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ComplaintDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "COMPLAINTDEFINITION", dataRow) { }
        protected ComplaintDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "COMPLAINTDEFINITION", dataRow, isImported) { }
        public ComplaintDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ComplaintDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ComplaintDefinition() : base() { }

    }
}