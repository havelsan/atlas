
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MadeOfSurveyDetail")] 

    public  partial class MadeOfSurveyDetail : TTObject
    {
        public class MadeOfSurveyDetailList : TTObjectCollection<MadeOfSurveyDetail> { }
                    
        public class ChildMadeOfSurveyDetailCollection : TTObject.TTChildObjectCollection<MadeOfSurveyDetail>
        {
            public ChildMadeOfSurveyDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMadeOfSurveyDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetMadeOfAnswersByQuestion_Class : TTReportNqlObject 
        {
            public Object Totalselect
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTALSELECT"]);
                }
            }

            public string Answer
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ANSWER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURVEYANSWER"].AllPropertyDefs["ANSWER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Answerid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ANSWERID"]);
                }
            }

            public int? Point
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["POINT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURVEYANSWER"].AllPropertyDefs["POINT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public GetMadeOfAnswersByQuestion_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMadeOfAnswersByQuestion_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMadeOfAnswersByQuestion_Class() : base() { }
        }

        public static BindingList<MadeOfSurveyDetail.GetMadeOfAnswersByQuestion_Class> GetMadeOfAnswersByQuestion(Guid QUESTIONID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MADEOFSURVEYDETAIL"].QueryDefs["GetMadeOfAnswersByQuestion"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("QUESTIONID", QUESTIONID);

            return TTReportNqlObject.QueryObjects<MadeOfSurveyDetail.GetMadeOfAnswersByQuestion_Class>(queryDef, paramList, pi);
        }

        public static BindingList<MadeOfSurveyDetail.GetMadeOfAnswersByQuestion_Class> GetMadeOfAnswersByQuestion(TTObjectContext objectContext, Guid QUESTIONID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MADEOFSURVEYDETAIL"].QueryDefs["GetMadeOfAnswersByQuestion"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("QUESTIONID", QUESTIONID);

            return TTReportNqlObject.QueryObjects<MadeOfSurveyDetail.GetMadeOfAnswersByQuestion_Class>(objectContext, queryDef, paramList, pi);
        }

        public SurveyQuestion SurveyQuestion
        {
            get { return (SurveyQuestion)((ITTObject)this).GetParent("SURVEYQUESTION"); }
            set { this["SURVEYQUESTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SurveyAnswer SurveyAnswer
        {
            get { return (SurveyAnswer)((ITTObject)this).GetParent("SURVEYANSWER"); }
            set { this["SURVEYANSWER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MadeOfSurvey MadeOfSurvey
        {
            get { return (MadeOfSurvey)((ITTObject)this).GetParent("MADEOFSURVEY"); }
            set { this["MADEOFSURVEY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MadeOfSurveyDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MadeOfSurveyDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MadeOfSurveyDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MadeOfSurveyDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MadeOfSurveyDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MADEOFSURVEYDETAIL", dataRow) { }
        protected MadeOfSurveyDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MADEOFSURVEYDETAIL", dataRow, isImported) { }
        public MadeOfSurveyDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MadeOfSurveyDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MadeOfSurveyDetail() : base() { }

    }
}