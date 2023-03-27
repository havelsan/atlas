
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="Apgar")] 

    public  partial class Apgar : BaseMultipleDataEntry
    {
        public class ApgarList : TTObjectCollection<Apgar> { }
                    
        public class ChildApgarCollection : TTObject.TTChildObjectCollection<Apgar>
        {
            public ChildApgarCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildApgarCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Toplam Skor
    /// </summary>
        public int? TotalScore
        {
            get { return (int?)this["TOTALSCORE"]; }
            set { this["TOTALSCORE"] = value; }
        }

    /// <summary>
    /// Kalp Hızı
    /// </summary>
        public ApgarHeartRateEnum? HeartRate
        {
            get { return (ApgarHeartRateEnum?)(int?)this["HEARTRATE"]; }
            set { this["HEARTRATE"] = value; }
        }

    /// <summary>
    /// Kas Tonusu
    /// </summary>
        public ApgarMuscularTonusEnum? MuscularTonus
        {
            get { return (ApgarMuscularTonusEnum?)(int?)this["MUSCULARTONUS"]; }
            set { this["MUSCULARTONUS"] = value; }
        }

    /// <summary>
    /// Solunum
    /// </summary>
        public ApgarRespirationEnum? Respiration
        {
            get { return (ApgarRespirationEnum?)(int?)this["RESPIRATION"]; }
            set { this["RESPIRATION"] = value; }
        }

    /// <summary>
    /// Cilt Rengi
    /// </summary>
        public ApgarSkinColorEnum? SkinColor
        {
            get { return (ApgarSkinColorEnum?)(int?)this["SKINCOLOR"]; }
            set { this["SKINCOLOR"] = value; }
        }

    /// <summary>
    /// Uyarılara Cevap
    /// </summary>
        public ApgarStimulusResponseEnum? StimulusResponse
        {
            get { return (ApgarStimulusResponseEnum?)(int?)this["STIMULUSRESPONSE"]; }
            set { this["STIMULUSRESPONSE"] = value; }
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

        protected Apgar(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected Apgar(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected Apgar(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected Apgar(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected Apgar(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "APGAR", dataRow) { }
        protected Apgar(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "APGAR", dataRow, isImported) { }
        public Apgar(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public Apgar(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public Apgar() : base() { }

    }
}