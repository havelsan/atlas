
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AnesthesiaDefinition")] 

    /// <summary>
    /// Anestezi Tanımlama
    /// </summary>
    public  partial class AnesthesiaDefinition : ProcedureDefinition
    {
        public class AnesthesiaDefinitionList : TTObjectCollection<AnesthesiaDefinition> { }
                    
        public class ChildAnesthesiaDefinitionCollection : TTObject.TTChildObjectCollection<AnesthesiaDefinition>
        {
            public ChildAnesthesiaDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAnesthesiaDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetAnesthesiaDefinition_Class : TTReportNqlObject 
        {
            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ANESTHESIADEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ANESTHESIADEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string EnglishName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENGLISHNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ANESTHESIADEFINITION"].AllPropertyDefs["ENGLISHNAME"].DataType;
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

            public GetAnesthesiaDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAnesthesiaDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAnesthesiaDefinition_Class() : base() { }
        }

        public static BindingList<AnesthesiaDefinition> GetByObjectID(TTObjectContext objectContext, string PARAMOBJID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ANESTHESIADEFINITION"].QueryDefs["GetByObjectID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJID", PARAMOBJID);

            return ((ITTQuery)objectContext).QueryObjects<AnesthesiaDefinition>(queryDef, paramList);
        }

        public static BindingList<AnesthesiaDefinition.GetAnesthesiaDefinition_Class> GetAnesthesiaDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ANESTHESIADEFINITION"].QueryDefs["GetAnesthesiaDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<AnesthesiaDefinition.GetAnesthesiaDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<AnesthesiaDefinition.GetAnesthesiaDefinition_Class> GetAnesthesiaDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ANESTHESIADEFINITION"].QueryDefs["GetAnesthesiaDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<AnesthesiaDefinition.GetAnesthesiaDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<AnesthesiaDefinition> GetAnesthesiaDefinitionByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ANESTHESIADEFINITION"].QueryDefs["GetAnesthesiaDefinitionByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<AnesthesiaDefinition>(queryDef, paramList);
        }

        protected AnesthesiaDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AnesthesiaDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AnesthesiaDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AnesthesiaDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AnesthesiaDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ANESTHESIADEFINITION", dataRow) { }
        protected AnesthesiaDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ANESTHESIADEFINITION", dataRow, isImported) { }
        public AnesthesiaDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AnesthesiaDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AnesthesiaDefinition() : base() { }

    }
}