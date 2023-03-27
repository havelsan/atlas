
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MinimumWageDefinition")] 

    /// <summary>
    /// Asgari Ücret Tanım Ekranı
    /// </summary>
    public  partial class MinimumWageDefinition : TerminologyManagerDef
    {
        public class MinimumWageDefinitionList : TTObjectCollection<MinimumWageDefinition> { }
                    
        public class ChildMinimumWageDefinitionCollection : TTObject.TTChildObjectCollection<MinimumWageDefinition>
        {
            public ChildMinimumWageDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMinimumWageDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetMinimumWageDefinitions_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Currency? GrossWage
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GROSSWAGE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MINIMUMWAGEDEFINITION"].AllPropertyDefs["GROSSWAGE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Object Startdate
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["STARTDATE"]);
                }
            }

            public Object Enddate
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ENDDATE"]);
                }
            }

            public GetMinimumWageDefinitions_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMinimumWageDefinitions_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMinimumWageDefinitions_Class() : base() { }
        }

        public static BindingList<MinimumWageDefinition.GetMinimumWageDefinitions_Class> GetMinimumWageDefinitions(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MINIMUMWAGEDEFINITION"].QueryDefs["GetMinimumWageDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MinimumWageDefinition.GetMinimumWageDefinitions_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MinimumWageDefinition.GetMinimumWageDefinitions_Class> GetMinimumWageDefinitions(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MINIMUMWAGEDEFINITION"].QueryDefs["GetMinimumWageDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MinimumWageDefinition.GetMinimumWageDefinitions_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MinimumWageDefinition> GetByDate(TTObjectContext objectContext, DateTime DATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MINIMUMWAGEDEFINITION"].QueryDefs["GetByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DATE", DATE);

            return ((ITTQuery)objectContext).QueryObjects<MinimumWageDefinition>(queryDef, paramList);
        }

    /// <summary>
    /// Brüt Ücret
    /// </summary>
        public Currency? GrossWage
        {
            get { return (Currency?)this["GROSSWAGE"]; }
            set { this["GROSSWAGE"] = value; }
        }

    /// <summary>
    /// Geçerlilik Başlangıç Tarihi
    /// </summary>
        public DateTime? StartDate
        {
            get { return (DateTime?)this["STARTDATE"]; }
            set { this["STARTDATE"] = value; }
        }

    /// <summary>
    /// Geçerlilik Bitiş Tarihi
    /// </summary>
        public DateTime? EndDate
        {
            get { return (DateTime?)this["ENDDATE"]; }
            set { this["ENDDATE"] = value; }
        }

        protected MinimumWageDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MinimumWageDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MinimumWageDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MinimumWageDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MinimumWageDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MINIMUMWAGEDEFINITION", dataRow) { }
        protected MinimumWageDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MINIMUMWAGEDEFINITION", dataRow, isImported) { }
        public MinimumWageDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MinimumWageDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MinimumWageDefinition() : base() { }

    }
}