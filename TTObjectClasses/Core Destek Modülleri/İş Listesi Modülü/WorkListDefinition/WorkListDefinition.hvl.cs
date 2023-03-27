
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="WorkListDefinition")] 

    public  partial class WorkListDefinition : TerminologyManagerDef
    {
        public class WorkListDefinitionList : TTObjectCollection<WorkListDefinition> { }
                    
        public class ChildWorkListDefinitionCollection : TTObject.TTChildObjectCollection<WorkListDefinition>
        {
            public ChildWorkListDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildWorkListDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetWorkListDefinitionQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string FormName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FORMNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["WORKLISTDEFINITION"].AllPropertyDefs["FORMNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Caption
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CAPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["WORKLISTDEFINITION"].AllPropertyDefs["CAPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string RoleID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ROLEID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["WORKLISTDEFINITION"].AllPropertyDefs["ROLEID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? RightDefID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RIGHTDEFID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["WORKLISTDEFINITION"].AllPropertyDefs["RIGHTDEFID"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string InterfaceDefName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INTERFACEDEFNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["WORKLISTDEFINITION"].AllPropertyDefs["INTERFACEDEFNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetWorkListDefinitionQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetWorkListDefinitionQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetWorkListDefinitionQuery_Class() : base() { }
        }

    /// <summary>
    /// Tüm tanımları getirir
    /// </summary>
        public static BindingList<WorkListDefinition> GetWorkListDefinitions(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["WORKLISTDEFINITION"].QueryDefs["GetWorkListDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<WorkListDefinition>(queryDef, paramList);
        }

        public static BindingList<WorkListDefinition> GetWorkListDefinitionByLastUpdate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["WORKLISTDEFINITION"].QueryDefs["GetWorkListDefinitionByLastUpdate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<WorkListDefinition>(queryDef, paramList);
        }

        public static BindingList<WorkListDefinition.GetWorkListDefinitionQuery_Class> GetWorkListDefinitionQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["WORKLISTDEFINITION"].QueryDefs["GetWorkListDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<WorkListDefinition.GetWorkListDefinitionQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<WorkListDefinition.GetWorkListDefinitionQuery_Class> GetWorkListDefinitionQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["WORKLISTDEFINITION"].QueryDefs["GetWorkListDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<WorkListDefinition.GetWorkListDefinitionQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public string InterfaceDefName
        {
            get { return (string)this["INTERFACEDEFNAME"]; }
            set { this["INTERFACEDEFNAME"] = value; }
        }

        public object WorkListIcon
        {
            get { return (object)this["WORKLISTICON"]; }
            set { this["WORKLISTICON"] = value; }
        }

        public int? RightDefID
        {
            get { return (int?)this["RIGHTDEFID"]; }
            set { this["RIGHTDEFID"] = value; }
        }

        public string RoleID
        {
            get { return (string)this["ROLEID"]; }
            set { this["ROLEID"] = value; }
        }

        public string FormName
        {
            get { return (string)this["FORMNAME"]; }
            set { this["FORMNAME"] = value; }
        }

        public string Caption
        {
            get { return (string)this["CAPTION"]; }
            set { this["CAPTION"] = value; }
        }

    /// <summary>
    /// İş listesinde HasRight kontrolunun yapılıp yapılmayacağı
    /// </summary>
        public bool? NoRightCheck
        {
            get { return (bool?)this["NORIGHTCHECK"]; }
            set { this["NORIGHTCHECK"] = value; }
        }

    /// <summary>
    /// Rapor Obje İsmi
    /// </summary>
        public string ReportDefName
        {
            get { return (string)this["REPORTDEFNAME"]; }
            set { this["REPORTDEFNAME"] = value; }
        }

        public SpecialPanelDefinition LastSpecialPanel
        {
            get { return (SpecialPanelDefinition)((ITTObject)this).GetParent("LASTSPECIALPANEL"); }
            set { this["LASTSPECIALPANEL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateSpecialPanelDefinitionsCollection()
        {
            _SpecialPanelDefinitions = new SpecialPanelDefinition.ChildSpecialPanelDefinitionCollection(this, new Guid("7a30e40f-8744-4f9e-bd82-2d44e6ed44f9"));
            ((ITTChildObjectCollection)_SpecialPanelDefinitions).GetChildren();
        }

        protected SpecialPanelDefinition.ChildSpecialPanelDefinitionCollection _SpecialPanelDefinitions = null;
        public SpecialPanelDefinition.ChildSpecialPanelDefinitionCollection SpecialPanelDefinitions
        {
            get
            {
                if (_SpecialPanelDefinitions == null)
                    CreateSpecialPanelDefinitionsCollection();
                return _SpecialPanelDefinitions;
            }
        }

        virtual protected void CreateCriterionCollection()
        {
            _Criterion = new CriteriaDefinition.ChildCriteriaDefinitionCollection(this, new Guid("ff304178-1452-4b56-820b-175bbd3c7059"));
            ((ITTChildObjectCollection)_Criterion).GetChildren();
        }

        protected CriteriaDefinition.ChildCriteriaDefinitionCollection _Criterion = null;
        public CriteriaDefinition.ChildCriteriaDefinitionCollection Criterion
        {
            get
            {
                if (_Criterion == null)
                    CreateCriterionCollection();
                return _Criterion;
            }
        }

        virtual protected void CreateWorklistMenuDefinitionsCollection()
        {
            _WorklistMenuDefinitions = new WorklistMenuDefinition.ChildWorklistMenuDefinitionCollection(this, new Guid("0a748740-f899-42e0-8cdc-3157dd1f65f7"));
            ((ITTChildObjectCollection)_WorklistMenuDefinitions).GetChildren();
        }

        protected WorklistMenuDefinition.ChildWorklistMenuDefinitionCollection _WorklistMenuDefinitions = null;
        public WorklistMenuDefinition.ChildWorklistMenuDefinitionCollection WorklistMenuDefinitions
        {
            get
            {
                if (_WorklistMenuDefinitions == null)
                    CreateWorklistMenuDefinitionsCollection();
                return _WorklistMenuDefinitions;
            }
        }

        virtual protected void CreateColumnDefinitionsCollection()
        {
            _ColumnDefinitions = new WorkListColumnDefinition.ChildWorkListColumnDefinitionCollection(this, new Guid("59b1270b-9e19-4d66-8b0c-f526d91e01c3"));
            ((ITTChildObjectCollection)_ColumnDefinitions).GetChildren();
        }

        protected WorkListColumnDefinition.ChildWorkListColumnDefinitionCollection _ColumnDefinitions = null;
        public WorkListColumnDefinition.ChildWorkListColumnDefinitionCollection ColumnDefinitions
        {
            get
            {
                if (_ColumnDefinitions == null)
                    CreateColumnDefinitionsCollection();
                return _ColumnDefinitions;
            }
        }

        protected WorkListDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected WorkListDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected WorkListDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected WorkListDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected WorkListDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "WORKLISTDEFINITION", dataRow) { }
        protected WorkListDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "WORKLISTDEFINITION", dataRow, isImported) { }
        public WorkListDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public WorkListDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public WorkListDefinition() : base() { }

    }
}