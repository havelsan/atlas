
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BedProcedureDefinition")] 

    /// <summary>
    /// Yatak Türleri Listesi
    /// </summary>
    public  partial class BedProcedureDefinition : ProcedureDefinition
    {
        public class BedProcedureDefinitionList : TTObjectCollection<BedProcedureDefinition> { }
                    
        public class ChildBedProcedureDefinitionCollection : TTObject.TTChildObjectCollection<BedProcedureDefinition>
        {
            public ChildBedProcedureDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBedProcedureDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetBedProcedureDefinition_Class : TTReportNqlObject 
        {
            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BEDPROCEDUREDEFINITION"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BEDPROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BEDPROCEDUREDEFINITION"].AllPropertyDefs["ENGLISHNAME"].DataType;
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

            public GetBedProcedureDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetBedProcedureDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetBedProcedureDefinition_Class() : base() { }
        }

        public static BindingList<BedProcedureDefinition.GetBedProcedureDefinition_Class> GetBedProcedureDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BEDPROCEDUREDEFINITION"].QueryDefs["GetBedProcedureDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<BedProcedureDefinition.GetBedProcedureDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<BedProcedureDefinition.GetBedProcedureDefinition_Class> GetBedProcedureDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BEDPROCEDUREDEFINITION"].QueryDefs["GetBedProcedureDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<BedProcedureDefinition.GetBedProcedureDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<BedProcedureDefinition> GetBedProcedureDefByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BEDPROCEDUREDEFINITION"].QueryDefs["GetBedProcedureDefByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<BedProcedureDefinition>(queryDef, paramList);
        }

        public ProcedureDefinition PandemicProcedure
        {
            get { return (ProcedureDefinition)((ITTObject)this).GetParent("PANDEMICPROCEDURE"); }
            set { this["PANDEMICPROCEDURE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected BedProcedureDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BedProcedureDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BedProcedureDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BedProcedureDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BedProcedureDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BEDPROCEDUREDEFINITION", dataRow) { }
        protected BedProcedureDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BEDPROCEDUREDEFINITION", dataRow, isImported) { }
        protected BedProcedureDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BedProcedureDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BedProcedureDefinition() : base() { }

    }
}