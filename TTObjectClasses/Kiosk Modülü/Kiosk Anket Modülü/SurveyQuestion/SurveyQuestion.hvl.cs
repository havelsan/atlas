
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SurveyQuestion")] 

    /// <summary>
    /// Anket Sorusu
    /// </summary>
    public  partial class SurveyQuestion : TTObject
    {
        public class SurveyQuestionList : TTObjectCollection<SurveyQuestion> { }
                    
        public class ChildSurveyQuestionCollection : TTObject.TTChildObjectCollection<SurveyQuestion>
        {
            public ChildSurveyQuestionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSurveyQuestionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Soru
    /// </summary>
        public string Question
        {
            get { return (string)this["QUESTION"]; }
            set { this["QUESTION"] = value; }
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
    /// Soru Sırası
    /// </summary>
        public int? QuestionOrder
        {
            get { return (int?)this["QUESTIONORDER"]; }
            set { this["QUESTIONORDER"] = value; }
        }

        public KioskSurveyDefinition KioskSurveyDefinition
        {
            get { return (KioskSurveyDefinition)((ITTObject)this).GetParent("KIOSKSURVEYDEFINITION"); }
            set { this["KIOSKSURVEYDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateMadeOfSurveyDetailCollection()
        {
            _MadeOfSurveyDetail = new MadeOfSurveyDetail.ChildMadeOfSurveyDetailCollection(this, new Guid("a473914e-a0e9-4d2f-a9df-2fca3b8e4249"));
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

        virtual protected void CreateSurveyAnswersCollection()
        {
            _SurveyAnswers = new SurveyAnswer.ChildSurveyAnswerCollection(this, new Guid("c273c97c-d43c-44ea-a595-3096aa18b400"));
            ((ITTChildObjectCollection)_SurveyAnswers).GetChildren();
        }

        protected SurveyAnswer.ChildSurveyAnswerCollection _SurveyAnswers = null;
        public SurveyAnswer.ChildSurveyAnswerCollection SurveyAnswers
        {
            get
            {
                if (_SurveyAnswers == null)
                    CreateSurveyAnswersCollection();
                return _SurveyAnswers;
            }
        }

        protected SurveyQuestion(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SurveyQuestion(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SurveyQuestion(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SurveyQuestion(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SurveyQuestion(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SURVEYQUESTION", dataRow) { }
        protected SurveyQuestion(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SURVEYQUESTION", dataRow, isImported) { }
        public SurveyQuestion(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SurveyQuestion(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SurveyQuestion() : base() { }

    }
}