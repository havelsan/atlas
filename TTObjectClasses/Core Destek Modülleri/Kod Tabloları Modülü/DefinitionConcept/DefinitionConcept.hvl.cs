
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DefinitionConcept")] 

    /// <summary>
    /// Tanım Kavramı
    /// </summary>
    public  partial class DefinitionConcept : TerminologyManagerDef
    {
        public class DefinitionConceptList : TTObjectCollection<DefinitionConcept> { }
                    
        public class ChildDefinitionConceptCollection : TTObject.TTChildObjectCollection<DefinitionConcept>
        {
            public ChildDefinitionConceptCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDefinitionConceptCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetEqualDefinitionConcepts_Class : TTReportNqlObject 
        {
            public string Concept
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CONCEPT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DEFINITIONCONCEPT"].AllPropertyDefs["CONCEPT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetEqualDefinitionConcepts_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetEqualDefinitionConcepts_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetEqualDefinitionConcepts_Class() : base() { }
        }

        [Serializable] 

        public partial class GetOtherDefinitionConcepts_Class : TTReportNqlObject 
        {
            public string Concept
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CONCEPT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DEFINITIONCONCEPT"].AllPropertyDefs["CONCEPT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetOtherDefinitionConcepts_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOtherDefinitionConcepts_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOtherDefinitionConcepts_Class() : base() { }
        }

        public static BindingList<DefinitionConcept.GetEqualDefinitionConcepts_Class> GetEqualDefinitionConcepts(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DEFINITIONCONCEPT"].QueryDefs["GetEqualDefinitionConcepts"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DefinitionConcept.GetEqualDefinitionConcepts_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DefinitionConcept.GetEqualDefinitionConcepts_Class> GetEqualDefinitionConcepts(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DEFINITIONCONCEPT"].QueryDefs["GetEqualDefinitionConcepts"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DefinitionConcept.GetEqualDefinitionConcepts_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DefinitionConcept.GetOtherDefinitionConcepts_Class> GetOtherDefinitionConcepts(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DEFINITIONCONCEPT"].QueryDefs["GetOtherDefinitionConcepts"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DefinitionConcept.GetOtherDefinitionConcepts_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DefinitionConcept.GetOtherDefinitionConcepts_Class> GetOtherDefinitionConcepts(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DEFINITIONCONCEPT"].QueryDefs["GetOtherDefinitionConcepts"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DefinitionConcept.GetOtherDefinitionConcepts_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DefinitionConcept> DefinitionConceptByLastUpdate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DEFINITIONCONCEPT"].QueryDefs["DefinitionConceptByLastUpdate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<DefinitionConcept>(queryDef, paramList);
        }

    /// <summary>
    /// Gölge Kavram
    /// </summary>
        public string Concept_Shadow
        {
            get { return (string)this["CONCEPT_SHADOW"]; }
        }

    /// <summary>
    /// Kavram
    /// </summary>
        public string Concept
        {
            get { return (string)this["CONCEPT"]; }
            set { this["CONCEPT"] = value; }
        }

    /// <summary>
    /// Terminology Manager Definition-Tanım Kavramları
    /// </summary>
        public TerminologyManagerDef TerminologyManagerDef
        {
            get { return (TerminologyManagerDef)((ITTObject)this).GetParent("TERMINOLOGYMANAGERDEF"); }
            set { this["TERMINOLOGYMANAGERDEF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DefinitionConcept(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DefinitionConcept(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DefinitionConcept(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DefinitionConcept(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DefinitionConcept(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DEFINITIONCONCEPT", dataRow) { }
        protected DefinitionConcept(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DEFINITIONCONCEPT", dataRow, isImported) { }
        public DefinitionConcept(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DefinitionConcept(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DefinitionConcept() : base() { }

    }
}