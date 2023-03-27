
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="GlaskowScore")] 

    /// <summary>
    /// Glaskow Skorlama
    /// </summary>
    public  partial class GlaskowScore : BaseMultipleDataEntry
    {
        public class GlaskowScoreList : TTObjectCollection<GlaskowScore> { }
                    
        public class ChildGlaskowScoreCollection : TTObject.TTChildObjectCollection<GlaskowScore>
        {
            public ChildGlaskowScoreCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildGlaskowScoreCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<GlaskowScore> GetAllGlaskowScore(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["GLASKOWSCORE"].QueryDefs["GetAllGlaskowScore"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<GlaskowScore>(queryDef, paramList);
        }

        public static BindingList<GlaskowScore> GetGlaskowByEpisodeAction(TTObjectContext objectContext, Guid EpisodeAction)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["GLASKOWSCORE"].QueryDefs["GetGlaskowByEpisodeAction"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEACTION", EpisodeAction);

            return ((ITTQuery)objectContext).QueryObjects<GlaskowScore>(queryDef, paramList);
        }

    /// <summary>
    /// Toplam Puan
    /// </summary>
        public int? Total
        {
            get { return (int?)this["TOTAL"]; }
            set { this["TOTAL"] = value; }
        }

    /// <summary>
    /// Toplam Skor
    /// </summary>
        public GlaskowComaScaleScoreEnum? TotalScore
        {
            get { return (GlaskowComaScaleScoreEnum?)(int?)this["TOTALSCORE"]; }
            set { this["TOTALSCORE"] = value; }
        }

    /// <summary>
    /// Gözler
    /// </summary>
        public GlaskowComaScaleDefinition Eyes
        {
            get { return (GlaskowComaScaleDefinition)((ITTObject)this).GetParent("EYES"); }
            set { this["EYES"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Motor Cevap
    /// </summary>
        public GlaskowComaScaleDefinition MotorAnswer
        {
            get { return (GlaskowComaScaleDefinition)((ITTObject)this).GetParent("MOTORANSWER"); }
            set { this["MOTORANSWER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Sözel Cevap
    /// </summary>
        public GlaskowComaScaleDefinition OralAnswer
        {
            get { return (GlaskowComaScaleDefinition)((ITTObject)this).GetParent("ORALANSWER"); }
            set { this["ORALANSWER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PhysicianApplication PhysicianApplication
        {
            get 
            {   
                if (EpisodeAction is PhysicianApplication)
                    return (PhysicianApplication)EpisodeAction; 
                return null;
            }            
            set { EpisodeAction = value; }
        }

        protected GlaskowScore(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected GlaskowScore(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected GlaskowScore(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected GlaskowScore(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected GlaskowScore(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "GLASKOWSCORE", dataRow) { }
        protected GlaskowScore(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "GLASKOWSCORE", dataRow, isImported) { }
        public GlaskowScore(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public GlaskowScore(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public GlaskowScore() : base() { }

    }
}