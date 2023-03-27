
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SystemForDisabledReportDefinition")] 

    /// <summary>
    /// Engelli Raporu için Sistem Tanımlama
    /// </summary>
    public  partial class SystemForDisabledReportDefinition : TerminologyManagerDef
    {
        public class SystemForDisabledReportDefinitionList : TTObjectCollection<SystemForDisabledReportDefinition> { }
                    
        public class ChildSystemForDisabledReportDefinitionCollection : TTObject.TTChildObjectCollection<SystemForDisabledReportDefinition>
        {
            public ChildSystemForDisabledReportDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSystemForDisabledReportDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSystemForDisabledReportDef_Class : TTReportNqlObject 
        {
            public long? Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SYSTEMFORDISABLEDREPORTDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SYSTEMFORDISABLEDREPORTDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetSystemForDisabledReportDef_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSystemForDisabledReportDef_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSystemForDisabledReportDef_Class() : base() { }
        }

        public static BindingList<SystemForDisabledReportDefinition> GetAllSystemForDisabledReportDef(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SYSTEMFORDISABLEDREPORTDEFINITION"].QueryDefs["GetAllSystemForDisabledReportDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<SystemForDisabledReportDefinition>(queryDef, paramList);
        }

        public static BindingList<SystemForDisabledReportDefinition.GetSystemForDisabledReportDef_Class> GetSystemForDisabledReportDef(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SYSTEMFORDISABLEDREPORTDEFINITION"].QueryDefs["GetSystemForDisabledReportDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SystemForDisabledReportDefinition.GetSystemForDisabledReportDef_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SystemForDisabledReportDefinition.GetSystemForDisabledReportDef_Class> GetSystemForDisabledReportDef(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SYSTEMFORDISABLEDREPORTDEFINITION"].QueryDefs["GetSystemForDisabledReportDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SystemForDisabledReportDefinition.GetSystemForDisabledReportDef_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Kodu
    /// </summary>
        public long? Code
        {
            get { return (long?)this["CODE"]; }
            set { this["CODE"] = value; }
        }

    /// <summary>
    /// Sistem Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        virtual protected void CreateDisabledReportCollection()
        {
            _DisabledReport = new DisabledReportSpecialGrid.ChildDisabledReportSpecialGridCollection(this, new Guid("13066217-cb5a-4e50-b829-1dbad691d09c"));
            ((ITTChildObjectCollection)_DisabledReport).GetChildren();
        }

        protected DisabledReportSpecialGrid.ChildDisabledReportSpecialGridCollection _DisabledReport = null;
        public DisabledReportSpecialGrid.ChildDisabledReportSpecialGridCollection DisabledReport
        {
            get
            {
                if (_DisabledReport == null)
                    CreateDisabledReportCollection();
                return _DisabledReport;
            }
        }

        protected SystemForDisabledReportDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SystemForDisabledReportDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SystemForDisabledReportDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SystemForDisabledReportDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SystemForDisabledReportDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SYSTEMFORDISABLEDREPORTDEFINITION", dataRow) { }
        protected SystemForDisabledReportDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SYSTEMFORDISABLEDREPORTDEFINITION", dataRow, isImported) { }
        public SystemForDisabledReportDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SystemForDisabledReportDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SystemForDisabledReportDefinition() : base() { }

    }
}