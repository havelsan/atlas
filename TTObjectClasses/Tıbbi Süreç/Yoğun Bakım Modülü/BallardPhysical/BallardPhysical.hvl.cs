
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BallardPhysical")] 

    public  partial class BallardPhysical : BaseMultipleDataEntry
    {
        public class BallardPhysicalList : TTObjectCollection<BallardPhysical> { }
                    
        public class ChildBallardPhysicalCollection : TTObject.TTChildObjectCollection<BallardPhysical>
        {
            public ChildBallardPhysicalCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBallardPhysicalCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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
    /// Göz / Kulak
    /// </summary>
        public BallardPhysicalEarEnum? Ear
        {
            get { return (BallardPhysicalEarEnum?)(int?)this["EAR"]; }
            set { this["EAR"] = value; }
        }

    /// <summary>
    /// Lanugo
    /// </summary>
        public BallardPhysicalLanugoEnum? Lanugo
        {
            get { return (BallardPhysicalLanugoEnum?)(int?)this["LANUGO"]; }
            set { this["LANUGO"] = value; }
        }

    /// <summary>
    /// Meme
    /// </summary>
        public BallardPhysicalBreastEnum? Breast
        {
            get { return (BallardPhysicalBreastEnum?)(int?)this["BREAST"]; }
            set { this["BREAST"] = value; }
        }

    /// <summary>
    /// Dişi Genitalya
    /// </summary>
        public BallardPhysicalFemaleGenitaliaEnum? FemaleGenitalia
        {
            get { return (BallardPhysicalFemaleGenitaliaEnum?)(int?)this["FEMALEGENITALIA"]; }
            set { this["FEMALEGENITALIA"] = value; }
        }

    /// <summary>
    /// Ayak Tabanı Çizgileri
    /// </summary>
        public BallardPhysicalPlantarLinesEnum? PlantarLines
        {
            get { return (BallardPhysicalPlantarLinesEnum?)(int?)this["PLANTARLINES"]; }
            set { this["PLANTARLINES"] = value; }
        }

    /// <summary>
    /// Cilt
    /// </summary>
        public BallardPhysicalSkinEnum? Skin
        {
            get { return (BallardPhysicalSkinEnum?)(int?)this["SKIN"]; }
            set { this["SKIN"] = value; }
        }

    /// <summary>
    /// Erkek Genitalya
    /// </summary>
        public BallardPhysicaMaleGenitaliaEnum? MaleGenitalia
        {
            get { return (BallardPhysicaMaleGenitaliaEnum?)(int?)this["MALEGENITALIA"]; }
            set { this["MALEGENITALIA"] = value; }
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

        protected BallardPhysical(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BallardPhysical(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BallardPhysical(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BallardPhysical(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BallardPhysical(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BALLARDPHYSICAL", dataRow) { }
        protected BallardPhysical(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BALLARDPHYSICAL", dataRow, isImported) { }
        public BallardPhysical(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BallardPhysical(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BallardPhysical() : base() { }

    }
}