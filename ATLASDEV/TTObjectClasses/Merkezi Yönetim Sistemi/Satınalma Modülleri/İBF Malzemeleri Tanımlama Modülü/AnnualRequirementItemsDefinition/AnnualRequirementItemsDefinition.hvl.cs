
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AnnualRequirementItemsDefinition")] 

    /// <summary>
    /// İBF Malzemeleri
    /// </summary>
    public  partial class AnnualRequirementItemsDefinition : TerminologyManagerDef
    {
        public class AnnualRequirementItemsDefinitionList : TTObjectCollection<AnnualRequirementItemsDefinition> { }
                    
        public class ChildAnnualRequirementItemsDefinitionCollection : TTObject.TTChildObjectCollection<AnnualRequirementItemsDefinition>
        {
            public ChildAnnualRequirementItemsDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAnnualRequirementItemsDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class ARItemsDefinitonFormNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? Year
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["YEAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ANNUALREQUIREMENTITEMSDEFINITION"].AllPropertyDefs["YEAR"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public IBFTypeEnum? IBFType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["IBFTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ANNUALREQUIREMENTITEMSDEFINITION"].AllPropertyDefs["IBFTYPE"].DataType;
                    return (IBFTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public ARItemsDefinitonFormNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public ARItemsDefinitonFormNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected ARItemsDefinitonFormNQL_Class() : base() { }
        }

        public static BindingList<AnnualRequirementItemsDefinition> GetAnnualRequirementsDefByYearNQL(TTObjectContext objectContext, int YEAR, int IBFTYPE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ANNUALREQUIREMENTITEMSDEFINITION"].QueryDefs["GetAnnualRequirementsDefByYearNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("YEAR", YEAR);
            paramList.Add("IBFTYPE", IBFTYPE);

            return ((ITTQuery)objectContext).QueryObjects<AnnualRequirementItemsDefinition>(queryDef, paramList);
        }

        public static BindingList<AnnualRequirementItemsDefinition.ARItemsDefinitonFormNQL_Class> ARItemsDefinitonFormNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ANNUALREQUIREMENTITEMSDEFINITION"].QueryDefs["ARItemsDefinitonFormNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<AnnualRequirementItemsDefinition.ARItemsDefinitonFormNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<AnnualRequirementItemsDefinition.ARItemsDefinitonFormNQL_Class> ARItemsDefinitonFormNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ANNUALREQUIREMENTITEMSDEFINITION"].QueryDefs["ARItemsDefinitonFormNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<AnnualRequirementItemsDefinition.ARItemsDefinitonFormNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<AnnualRequirementItemsDefinition> GetAnnualRequirementItemsDefByLastUpdate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ANNUALREQUIREMENTITEMSDEFINITION"].QueryDefs["GetAnnualRequirementItemsDefByLastUpdate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<AnnualRequirementItemsDefinition>(queryDef, paramList);
        }

    /// <summary>
    /// İBF Türü
    /// </summary>
        public IBFTypeEnum? IBFType
        {
            get { return (IBFTypeEnum?)(int?)this["IBFTYPE"]; }
            set { this["IBFTYPE"] = value; }
        }

    /// <summary>
    /// Yıl
    /// </summary>
        public long? Year
        {
            get { return (long?)this["YEAR"]; }
            set { this["YEAR"] = value; }
        }

        virtual protected void CreateAnnualRequirementItemsCollection()
        {
            _AnnualRequirementItems = new AnnualRequirementItem.ChildAnnualRequirementItemCollection(this, new Guid("6b54c0a8-df85-4737-ab12-3d04859db5b9"));
            ((ITTChildObjectCollection)_AnnualRequirementItems).GetChildren();
        }

        protected AnnualRequirementItem.ChildAnnualRequirementItemCollection _AnnualRequirementItems = null;
        public AnnualRequirementItem.ChildAnnualRequirementItemCollection AnnualRequirementItems
        {
            get
            {
                if (_AnnualRequirementItems == null)
                    CreateAnnualRequirementItemsCollection();
                return _AnnualRequirementItems;
            }
        }

        protected AnnualRequirementItemsDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AnnualRequirementItemsDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AnnualRequirementItemsDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AnnualRequirementItemsDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AnnualRequirementItemsDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ANNUALREQUIREMENTITEMSDEFINITION", dataRow) { }
        protected AnnualRequirementItemsDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ANNUALREQUIREMENTITEMSDEFINITION", dataRow, isImported) { }
        public AnnualRequirementItemsDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AnnualRequirementItemsDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AnnualRequirementItemsDefinition() : base() { }

    }
}