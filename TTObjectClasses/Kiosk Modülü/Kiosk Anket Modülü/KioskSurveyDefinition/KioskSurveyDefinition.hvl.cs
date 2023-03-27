
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="KioskSurveyDefinition")] 

    /// <summary>
    /// Anket Tanımı
    /// </summary>
    public  partial class KioskSurveyDefinition : TerminologyManagerDef
    {
        public class KioskSurveyDefinitionList : TTObjectCollection<KioskSurveyDefinition> { }
                    
        public class ChildKioskSurveyDefinitionCollection : TTObject.TTChildObjectCollection<KioskSurveyDefinition>
        {
            public ChildKioskSurveyDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildKioskSurveyDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetKioskSurveyDefinitionList_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["KIOSKSURVEYDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public GetKioskSurveyDefinitionList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetKioskSurveyDefinitionList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetKioskSurveyDefinitionList_Class() : base() { }
        }

        [Serializable] 

        public partial class GetSurveyDefinitionByID_Class : TTReportNqlObject 
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

            public DateTime? StartDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STARTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["KIOSKSURVEYDEFINITION"].AllPropertyDefs["STARTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? EndDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["KIOSKSURVEYDEFINITION"].AllPropertyDefs["ENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["KIOSKSURVEYDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetSurveyDefinitionByID_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSurveyDefinitionByID_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSurveyDefinitionByID_Class() : base() { }
        }

        public static BindingList<KioskSurveyDefinition.GetKioskSurveyDefinitionList_Class> GetKioskSurveyDefinitionList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["KIOSKSURVEYDEFINITION"].QueryDefs["GetKioskSurveyDefinitionList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<KioskSurveyDefinition.GetKioskSurveyDefinitionList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<KioskSurveyDefinition.GetKioskSurveyDefinitionList_Class> GetKioskSurveyDefinitionList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["KIOSKSURVEYDEFINITION"].QueryDefs["GetKioskSurveyDefinitionList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<KioskSurveyDefinition.GetKioskSurveyDefinitionList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<KioskSurveyDefinition.GetSurveyDefinitionByID_Class> GetSurveyDefinitionByID(Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["KIOSKSURVEYDEFINITION"].QueryDefs["GetSurveyDefinitionByID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<KioskSurveyDefinition.GetSurveyDefinitionByID_Class>(queryDef, paramList, pi);
        }

        public static BindingList<KioskSurveyDefinition.GetSurveyDefinitionByID_Class> GetSurveyDefinitionByID(TTObjectContext objectContext, Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["KIOSKSURVEYDEFINITION"].QueryDefs["GetSurveyDefinitionByID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<KioskSurveyDefinition.GetSurveyDefinitionByID_Class>(objectContext, queryDef, paramList, pi);
        }

        public DateTime? StartDate
        {
            get { return (DateTime?)this["STARTDATE"]; }
            set { this["STARTDATE"] = value; }
        }

        public DateTime? EndDate
        {
            get { return (DateTime?)this["ENDDATE"]; }
            set { this["ENDDATE"] = value; }
        }

        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        virtual protected void CreateMadeOfSurveysCollection()
        {
            _MadeOfSurveys = new MadeOfSurvey.ChildMadeOfSurveyCollection(this, new Guid("59a693db-68a5-4aeb-b238-c649ee86ff56"));
            ((ITTChildObjectCollection)_MadeOfSurveys).GetChildren();
        }

        protected MadeOfSurvey.ChildMadeOfSurveyCollection _MadeOfSurveys = null;
        public MadeOfSurvey.ChildMadeOfSurveyCollection MadeOfSurveys
        {
            get
            {
                if (_MadeOfSurveys == null)
                    CreateMadeOfSurveysCollection();
                return _MadeOfSurveys;
            }
        }

        virtual protected void CreateSurveyQuestionsCollection()
        {
            _SurveyQuestions = new SurveyQuestion.ChildSurveyQuestionCollection(this, new Guid("1a0f03c8-c8cd-4a99-bab4-46cd0be88e80"));
            ((ITTChildObjectCollection)_SurveyQuestions).GetChildren();
        }

        protected SurveyQuestion.ChildSurveyQuestionCollection _SurveyQuestions = null;
        public SurveyQuestion.ChildSurveyQuestionCollection SurveyQuestions
        {
            get
            {
                if (_SurveyQuestions == null)
                    CreateSurveyQuestionsCollection();
                return _SurveyQuestions;
            }
        }

        protected KioskSurveyDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected KioskSurveyDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected KioskSurveyDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected KioskSurveyDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected KioskSurveyDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "KIOSKSURVEYDEFINITION", dataRow) { }
        protected KioskSurveyDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "KIOSKSURVEYDEFINITION", dataRow, isImported) { }
        public KioskSurveyDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public KioskSurveyDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public KioskSurveyDefinition() : base() { }

    }
}