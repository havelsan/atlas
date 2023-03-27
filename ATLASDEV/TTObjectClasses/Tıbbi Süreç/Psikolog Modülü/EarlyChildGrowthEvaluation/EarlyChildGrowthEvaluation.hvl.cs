
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="EarlyChildGrowthEvaluation")] 

    /// <summary>
    /// Erken Çocuk Gelişimi Değerlendirme Formu
    /// </summary>
    public  partial class EarlyChildGrowthEvaluation : BasePsychologyForm
    {
        public class EarlyChildGrowthEvaluationList : TTObjectCollection<EarlyChildGrowthEvaluation> { }
                    
        public class ChildEarlyChildGrowthEvaluationCollection : TTObject.TTChildObjectCollection<EarlyChildGrowthEvaluation>
        {
            public ChildEarlyChildGrowthEvaluationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildEarlyChildGrowthEvaluationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class EarlyChildGrovthEvaluationFormList_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public DateTime? AddedDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADDEDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EARLYCHILDGROWTHEVALUATION"].AllPropertyDefs["ADDEDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Addeduser
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADDEDUSER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Proceduredoctor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDUREDOCTOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public EarlyChildGrovthEvaluationFormList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public EarlyChildGrovthEvaluationFormList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected EarlyChildGrovthEvaluationFormList_Class() : base() { }
        }

        public static BindingList<EarlyChildGrowthEvaluation.EarlyChildGrovthEvaluationFormList_Class> EarlyChildGrovthEvaluationFormList(Guid EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EARLYCHILDGROWTHEVALUATION"].QueryDefs["EarlyChildGrovthEvaluationFormList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<EarlyChildGrowthEvaluation.EarlyChildGrovthEvaluationFormList_Class>(queryDef, paramList, pi);
        }

        public static BindingList<EarlyChildGrowthEvaluation.EarlyChildGrovthEvaluationFormList_Class> EarlyChildGrovthEvaluationFormList(TTObjectContext objectContext, Guid EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EARLYCHILDGROWTHEVALUATION"].QueryDefs["EarlyChildGrovthEvaluationFormList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<EarlyChildGrowthEvaluation.EarlyChildGrovthEvaluationFormList_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Psikomotor Gelişimi
    /// </summary>
        public string PsychomotorEvolution
        {
            get { return (string)this["PSYCHOMOTOREVOLUTION"]; }
            set { this["PSYCHOMOTOREVOLUTION"] = value; }
        }

    /// <summary>
    /// İnce Motor Gelişimi
    /// </summary>
        public string ThinMotorEvolution
        {
            get { return (string)this["THINMOTOREVOLUTION"]; }
            set { this["THINMOTOREVOLUTION"] = value; }
        }

    /// <summary>
    /// Genel Gelişim Düzeyi
    /// </summary>
        public string GeneralEvolutionLevel
        {
            get { return (string)this["GENERALEVOLUTIONLEVEL"]; }
            set { this["GENERALEVOLUTIONLEVEL"] = value; }
        }

    /// <summary>
    /// Kaba Motor Gelişimi
    /// </summary>
        public string MajorMotorEvolution
        {
            get { return (string)this["MAJORMOTOREVOLUTION"]; }
            set { this["MAJORMOTOREVOLUTION"] = value; }
        }

    /// <summary>
    /// Bilişsel Gelişimi
    /// </summary>
        public string CognitiveEvolution
        {
            get { return (string)this["COGNITIVEEVOLUTION"]; }
            set { this["COGNITIVEEVOLUTION"] = value; }
        }

    /// <summary>
    /// Dil / Bilişsel Gelişim Düzeyi
    /// </summary>
        public string TongueCognitiveEvolutionLevel
        {
            get { return (string)this["TONGUECOGNITIVEEVOLUTIONLEVEL"]; }
            set { this["TONGUECOGNITIVEEVOLUTIONLEVEL"] = value; }
        }

    /// <summary>
    /// Sosyal Beceri / Özbakım Gelişim Düzeyi
    /// </summary>
        public string SocialSkillSelfCareEvolLevel
        {
            get { return (string)this["SOCIALSKILLSELFCAREEVOLLEVEL"]; }
            set { this["SOCIALSKILLSELFCAREEVOLLEVEL"] = value; }
        }

    /// <summary>
    /// Sonuç
    /// </summary>
        public string Result
        {
            get { return (string)this["RESULT"]; }
            set { this["RESULT"] = value; }
        }

        protected EarlyChildGrowthEvaluation(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected EarlyChildGrowthEvaluation(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected EarlyChildGrowthEvaluation(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected EarlyChildGrowthEvaluation(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected EarlyChildGrowthEvaluation(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EARLYCHILDGROWTHEVALUATION", dataRow) { }
        protected EarlyChildGrowthEvaluation(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EARLYCHILDGROWTHEVALUATION", dataRow, isImported) { }
        public EarlyChildGrowthEvaluation(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public EarlyChildGrowthEvaluation(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public EarlyChildGrowthEvaluation() : base() { }

    }
}