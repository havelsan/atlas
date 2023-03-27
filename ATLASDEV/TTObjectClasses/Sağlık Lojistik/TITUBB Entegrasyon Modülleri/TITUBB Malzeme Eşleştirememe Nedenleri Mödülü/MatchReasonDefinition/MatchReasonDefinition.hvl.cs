
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MatchReasonDefinition")] 

    /// <summary>
    /// TITUBB Malzeme Eşleştirememe Nedenleri
    /// </summary>
    public  partial class MatchReasonDefinition : TerminologyManagerDef
    {
        public class MatchReasonDefinitionList : TTObjectCollection<MatchReasonDefinition> { }
                    
        public class ChildMatchReasonDefinitionCollection : TTObject.TTChildObjectCollection<MatchReasonDefinition>
        {
            public ChildMatchReasonDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMatchReasonDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetMatchReasonDefinitionList_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Reason
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASON"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATCHREASONDEFINITION"].AllPropertyDefs["REASON"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? WithBarcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WITHBARCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATCHREASONDEFINITION"].AllPropertyDefs["WITHBARCODE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public GetMatchReasonDefinitionList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMatchReasonDefinitionList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMatchReasonDefinitionList_Class() : base() { }
        }

        public static BindingList<MatchReasonDefinition.GetMatchReasonDefinitionList_Class> GetMatchReasonDefinitionList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATCHREASONDEFINITION"].QueryDefs["GetMatchReasonDefinitionList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MatchReasonDefinition.GetMatchReasonDefinitionList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MatchReasonDefinition.GetMatchReasonDefinitionList_Class> GetMatchReasonDefinitionList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATCHREASONDEFINITION"].QueryDefs["GetMatchReasonDefinitionList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MatchReasonDefinition.GetMatchReasonDefinitionList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public string Reason
        {
            get { return (string)this["REASON"]; }
            set { this["REASON"] = value; }
        }

        public bool? WithBarcode
        {
            get { return (bool?)this["WITHBARCODE"]; }
            set { this["WITHBARCODE"] = value; }
        }

        protected MatchReasonDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MatchReasonDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MatchReasonDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MatchReasonDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MatchReasonDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MATCHREASONDEFINITION", dataRow) { }
        protected MatchReasonDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MATCHREASONDEFINITION", dataRow, isImported) { }
        public MatchReasonDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MatchReasonDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MatchReasonDefinition() : base() { }

    }
}