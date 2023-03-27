
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="EuroScore")] 

    /// <summary>
    /// Euro Score Soru Tanımları
    /// </summary>
    public  partial class EuroScore : BaseMedulaDefinition
    {
        public class EuroScoreList : TTObjectCollection<EuroScore> { }
                    
        public class ChildEuroScoreCollection : TTObject.TTChildObjectCollection<EuroScore>
        {
            public ChildEuroScoreCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildEuroScoreCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetEuroScoreDefinitionQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? ObjectDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTDEFID"]);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public Boolean? IsActive
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISACTIVE"]);
                    if (val == null)
                        return null;
                    return (Boolean)Convert.ChangeType(val, typeof(Boolean)); 
                }
            }

            public DateTime? LastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LASTUPDATE"]);
                    if (val == null)
                        return null;
                    return (DateTime)Convert.ChangeType(val, typeof(DateTime)); 
                }
            }

            public string EuroScoreQuestion
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EUROSCOREQUESTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EUROSCORE"].AllPropertyDefs["EUROSCOREQUESTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? Score
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SCORE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EUROSCORE"].AllPropertyDefs["SCORE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public double? LogisticScore
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LOGISTICSCORE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EUROSCORE"].AllPropertyDefs["LOGISTICSCORE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string SelectionCaption
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SELECTIONCAPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EUROSCORE"].AllPropertyDefs["SELECTIONCAPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? ScreenOrder
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SCREENORDER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EUROSCORE"].AllPropertyDefs["SCREENORDER"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public GetEuroScoreDefinitionQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetEuroScoreDefinitionQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetEuroScoreDefinitionQuery_Class() : base() { }
        }

        public static BindingList<EuroScore.GetEuroScoreDefinitionQuery_Class> GetEuroScoreDefinitionQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EUROSCORE"].QueryDefs["GetEuroScoreDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<EuroScore.GetEuroScoreDefinitionQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<EuroScore.GetEuroScoreDefinitionQuery_Class> GetEuroScoreDefinitionQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EUROSCORE"].QueryDefs["GetEuroScoreDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<EuroScore.GetEuroScoreDefinitionQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public string EuroScoreQuestion
        {
            get { return (string)this["EUROSCOREQUESTION"]; }
            set { this["EUROSCOREQUESTION"] = value; }
        }

        public int? Score
        {
            get { return (int?)this["SCORE"]; }
            set { this["SCORE"] = value; }
        }

        public double? LogisticScore
        {
            get { return (double?)this["LOGISTICSCORE"]; }
            set { this["LOGISTICSCORE"] = value; }
        }

        public string SelectionCaption
        {
            get { return (string)this["SELECTIONCAPTION"]; }
            set { this["SELECTIONCAPTION"] = value; }
        }

        public int? ScreenOrder
        {
            get { return (int?)this["SCREENORDER"]; }
            set { this["SCREENORDER"] = value; }
        }

        protected EuroScore(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected EuroScore(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected EuroScore(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected EuroScore(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected EuroScore(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EUROSCORE", dataRow) { }
        protected EuroScore(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EUROSCORE", dataRow, isImported) { }
        public EuroScore(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public EuroScore(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public EuroScore() : base() { }

    }
}