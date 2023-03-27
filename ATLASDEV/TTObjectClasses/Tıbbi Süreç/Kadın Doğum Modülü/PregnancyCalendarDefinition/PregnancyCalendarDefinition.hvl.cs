
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PregnancyCalendarDefinition")] 

    public  partial class PregnancyCalendarDefinition : TTDefinitionSet
    {
        public class PregnancyCalendarDefinitionList : TTObjectCollection<PregnancyCalendarDefinition> { }
                    
        public class ChildPregnancyCalendarDefinitionCollection : TTObject.TTChildObjectCollection<PregnancyCalendarDefinition>
        {
            public ChildPregnancyCalendarDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPregnancyCalendarDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class PregnancyCalendarDefinitionNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string PeriodName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PERIODNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PREGNANCYCALENDARDEFINITION"].AllPropertyDefs["PERIODNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? StartDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STARTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PREGNANCYCALENDARDEFINITION"].AllPropertyDefs["STARTDATE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? FinishDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FINISHDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PREGNANCYCALENDARDEFINITION"].AllPropertyDefs["FINISHDATE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public PregnancyTypeEnum? PregnancyType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PREGNANCYTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PREGNANCYCALENDARDEFINITION"].AllPropertyDefs["PREGNANCYTYPE"].DataType;
                    return (PregnancyTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public PregnancyCalendarDefinitionNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public PregnancyCalendarDefinitionNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected PregnancyCalendarDefinitionNQL_Class() : base() { }
        }

        public static BindingList<PregnancyCalendarDefinition.PregnancyCalendarDefinitionNQL_Class> PregnancyCalendarDefinitionNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PREGNANCYCALENDARDEFINITION"].QueryDefs["PregnancyCalendarDefinitionNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PregnancyCalendarDefinition.PregnancyCalendarDefinitionNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PregnancyCalendarDefinition.PregnancyCalendarDefinitionNQL_Class> PregnancyCalendarDefinitionNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PREGNANCYCALENDARDEFINITION"].QueryDefs["PregnancyCalendarDefinitionNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PregnancyCalendarDefinition.PregnancyCalendarDefinitionNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PregnancyCalendarDefinition> GetAllNQL(TTObjectContext objectContext, PregnancyTypeEnum PTYPE, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PREGNANCYCALENDARDEFINITION"].QueryDefs["GetAllNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PTYPE", (int)PTYPE);

            return ((ITTQuery)objectContext).QueryObjects<PregnancyCalendarDefinition>(queryDef, paramList, injectionSQL);
        }

    /// <summary>
    /// Periyod Adı
    /// </summary>
        public string PeriodName
        {
            get { return (string)this["PERIODNAME"]; }
            set { this["PERIODNAME"] = value; }
        }

    /// <summary>
    /// Gebelik Tipi
    /// </summary>
        public PregnancyTypeEnum? PregnancyType
        {
            get { return (PregnancyTypeEnum?)(int?)this["PREGNANCYTYPE"]; }
            set { this["PREGNANCYTYPE"] = value; }
        }

    /// <summary>
    /// Başlangıç Haftası
    /// </summary>
        public int? StartDate
        {
            get { return (int?)this["STARTDATE"]; }
            set { this["STARTDATE"] = value; }
        }

    /// <summary>
    /// Bitiş Haftası
    /// </summary>
        public int? FinishDate
        {
            get { return (int?)this["FINISHDATE"]; }
            set { this["FINISHDATE"] = value; }
        }

        protected PregnancyCalendarDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PregnancyCalendarDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PregnancyCalendarDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PregnancyCalendarDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PregnancyCalendarDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PREGNANCYCALENDARDEFINITION", dataRow) { }
        protected PregnancyCalendarDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PREGNANCYCALENDARDEFINITION", dataRow, isImported) { }
        public PregnancyCalendarDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PregnancyCalendarDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PregnancyCalendarDefinition() : base() { }

    }
}