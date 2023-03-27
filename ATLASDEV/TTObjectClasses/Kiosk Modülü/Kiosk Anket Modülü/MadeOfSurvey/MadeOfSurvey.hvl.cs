
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MadeOfSurvey")] 

    public  partial class MadeOfSurvey : TTObject
    {
        public class MadeOfSurveyList : TTObjectCollection<MadeOfSurvey> { }
                    
        public class ChildMadeOfSurveyCollection : TTObject.TTChildObjectCollection<MadeOfSurvey>
        {
            public ChildMadeOfSurveyCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMadeOfSurveyCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetTotalParticipation_Class : TTReportNqlObject 
        {
            public Object Total
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTAL"]);
                }
            }

            public GetTotalParticipation_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetTotalParticipation_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetTotalParticipation_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDescitionByQuestion_Class : TTReportNqlObject 
        {
            public string Desciption
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MADEOFSURVEY"].AllPropertyDefs["DESCIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetDescitionByQuestion_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDescitionByQuestion_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDescitionByQuestion_Class() : base() { }
        }

        public static BindingList<MadeOfSurvey.GetTotalParticipation_Class> GetTotalParticipation(Guid SURVEYDEFID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MADEOFSURVEY"].QueryDefs["GetTotalParticipation"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SURVEYDEFID", SURVEYDEFID);

            return TTReportNqlObject.QueryObjects<MadeOfSurvey.GetTotalParticipation_Class>(queryDef, paramList, pi);
        }

        public static BindingList<MadeOfSurvey.GetTotalParticipation_Class> GetTotalParticipation(TTObjectContext objectContext, Guid SURVEYDEFID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MADEOFSURVEY"].QueryDefs["GetTotalParticipation"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SURVEYDEFID", SURVEYDEFID);

            return TTReportNqlObject.QueryObjects<MadeOfSurvey.GetTotalParticipation_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<MadeOfSurvey.GetDescitionByQuestion_Class> GetDescitionByQuestion(Guid SURVEYDEFID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MADEOFSURVEY"].QueryDefs["GetDescitionByQuestion"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SURVEYDEFID", SURVEYDEFID);

            return TTReportNqlObject.QueryObjects<MadeOfSurvey.GetDescitionByQuestion_Class>(queryDef, paramList, pi);
        }

        public static BindingList<MadeOfSurvey.GetDescitionByQuestion_Class> GetDescitionByQuestion(TTObjectContext objectContext, Guid SURVEYDEFID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MADEOFSURVEY"].QueryDefs["GetDescitionByQuestion"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SURVEYDEFID", SURVEYDEFID);

            return TTReportNqlObject.QueryObjects<MadeOfSurvey.GetDescitionByQuestion_Class>(objectContext, queryDef, paramList, pi);
        }

        public string Desciption
        {
            get { return (string)this["DESCIPTION"]; }
            set { this["DESCIPTION"] = value; }
        }

        public KioskSurveyDefinition KioskSurveyDefinition
        {
            get { return (KioskSurveyDefinition)((ITTObject)this).GetParent("KIOSKSURVEYDEFINITION"); }
            set { this["KIOSKSURVEYDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateMadeOfSurveyDetailsCollection()
        {
            _MadeOfSurveyDetails = new MadeOfSurveyDetail.ChildMadeOfSurveyDetailCollection(this, new Guid("8c3dcf0b-6ba3-4e61-9a7c-fdfa1adbf32a"));
            ((ITTChildObjectCollection)_MadeOfSurveyDetails).GetChildren();
        }

        protected MadeOfSurveyDetail.ChildMadeOfSurveyDetailCollection _MadeOfSurveyDetails = null;
        public MadeOfSurveyDetail.ChildMadeOfSurveyDetailCollection MadeOfSurveyDetails
        {
            get
            {
                if (_MadeOfSurveyDetails == null)
                    CreateMadeOfSurveyDetailsCollection();
                return _MadeOfSurveyDetails;
            }
        }

        protected MadeOfSurvey(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MadeOfSurvey(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MadeOfSurvey(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MadeOfSurvey(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MadeOfSurvey(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MADEOFSURVEY", dataRow) { }
        protected MadeOfSurvey(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MADEOFSURVEY", dataRow, isImported) { }
        public MadeOfSurvey(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MadeOfSurvey(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MadeOfSurvey() : base() { }

    }
}