
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="VemRelation")] 

    /// <summary>
    /// Vem Aktarımlarının Ara Tablosu
    /// </summary>
    public  partial class VemRelation : TTObject
    {
        public class VemRelationList : TTObjectCollection<VemRelation> { }
                    
        public class ChildVemRelationCollection : TTObject.TTChildObjectCollection<VemRelation>
        {
            public ChildVemRelationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildVemRelationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetAllByReportQuery_Class : TTReportNqlObject 
        {
            public int? VemID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["VEMID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["VEMRELATION"].AllPropertyDefs["VEMID"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string VemObjectID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["VEMOBJECTID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["VEMRELATION"].AllPropertyDefs["VEMOBJECTID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string VemTableName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["VEMTABLENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["VEMRELATION"].AllPropertyDefs["VEMTABLENAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? HvlObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["HVLOBJECTID"]);
                }
            }

            public GetAllByReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAllByReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAllByReportQuery_Class() : base() { }
        }

        public static BindingList<VemRelation> GetAll(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["VEMRELATION"].QueryDefs["GetAll"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<VemRelation>(queryDef, paramList);
        }

        public static BindingList<VemRelation> GetByVemProperties(TTObjectContext objectContext, int VemID, string VemObjectID, string TableName)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["VEMRELATION"].QueryDefs["GetByVemProperties"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("VEMID", VemID);
            paramList.Add("VEMOBJECTID", VemObjectID);
            paramList.Add("TABLENAME", TableName);

            return ((ITTQuery)objectContext).QueryObjects<VemRelation>(queryDef, paramList);
        }

        public static BindingList<VemRelation> GetVemRelationWithTableNames(TTObjectContext objectContext, int VemID, string TableNames)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["VEMRELATION"].QueryDefs["GetVemRelationWithTableNames"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("VEMID", VemID);
            paramList.Add("TABLENAMES", TableNames);

            return ((ITTQuery)objectContext).QueryObjects<VemRelation>(queryDef, paramList);
        }

        public static BindingList<VemRelation.GetAllByReportQuery_Class> GetAllByReportQuery(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["VEMRELATION"].QueryDefs["GetAllByReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<VemRelation.GetAllByReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<VemRelation.GetAllByReportQuery_Class> GetAllByReportQuery(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["VEMRELATION"].QueryDefs["GetAllByReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<VemRelation.GetAllByReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public string VemTableName
        {
            get { return (string)this["VEMTABLENAME"]; }
            set { this["VEMTABLENAME"] = value; }
        }

        public Guid? HvlObjectID
        {
            get { return (Guid?)this["HVLOBJECTID"]; }
            set { this["HVLOBJECTID"] = value; }
        }

        public string VemObjectID
        {
            get { return (string)this["VEMOBJECTID"]; }
            set { this["VEMOBJECTID"] = value; }
        }

        public int? VemID
        {
            get { return (int?)this["VEMID"]; }
            set { this["VEMID"] = value; }
        }

        protected VemRelation(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected VemRelation(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected VemRelation(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected VemRelation(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected VemRelation(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "VEMRELATION", dataRow) { }
        protected VemRelation(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "VEMRELATION", dataRow, isImported) { }
        public VemRelation(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public VemRelation(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public VemRelation() : base() { }

    }
}