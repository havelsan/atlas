
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SurveyAnswer")] 

    /// <summary>
    /// Cevap
    /// </summary>
    public  partial class SurveyAnswer : TTObject
    {
        public class SurveyAnswerList : TTObjectCollection<SurveyAnswer> { }
                    
        public class ChildSurveyAnswerCollection : TTObject.TTChildObjectCollection<SurveyAnswer>
        {
            public ChildSurveyAnswerCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSurveyAnswerCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Cevap
    /// </summary>
        public string Answer
        {
            get { return (string)this["ANSWER"]; }
            set { this["ANSWER"] = value; }
        }

    /// <summary>
    /// Cevap Puanı
    /// </summary>
        public int? Point
        {
            get { return (int?)this["POINT"]; }
            set { this["POINT"] = value; }
        }

        public SurveyQuestion SurveyQuestion
        {
            get { return (SurveyQuestion)((ITTObject)this).GetParent("SURVEYQUESTION"); }
            set { this["SURVEYQUESTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateMadeOfSurveyDetailCollection()
        {
            _MadeOfSurveyDetail = new MadeOfSurveyDetail.ChildMadeOfSurveyDetailCollection(this, new Guid("0379bd3c-b5e7-4cf2-bffa-cb064a915329"));
            ((ITTChildObjectCollection)_MadeOfSurveyDetail).GetChildren();
        }

        protected MadeOfSurveyDetail.ChildMadeOfSurveyDetailCollection _MadeOfSurveyDetail = null;
        public MadeOfSurveyDetail.ChildMadeOfSurveyDetailCollection MadeOfSurveyDetail
        {
            get
            {
                if (_MadeOfSurveyDetail == null)
                    CreateMadeOfSurveyDetailCollection();
                return _MadeOfSurveyDetail;
            }
        }

        protected SurveyAnswer(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SurveyAnswer(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SurveyAnswer(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SurveyAnswer(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SurveyAnswer(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SURVEYANSWER", dataRow) { }
        protected SurveyAnswer(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SURVEYANSWER", dataRow, isImported) { }
        public SurveyAnswer(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SurveyAnswer(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SurveyAnswer() : base() { }

    }
}