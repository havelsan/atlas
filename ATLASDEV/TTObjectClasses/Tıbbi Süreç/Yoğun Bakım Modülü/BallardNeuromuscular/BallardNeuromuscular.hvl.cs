
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BallardNeuromuscular")] 

    public  partial class BallardNeuromuscular : BaseMultipleDataEntry
    {
        public class BallardNeuromuscularList : TTObjectCollection<BallardNeuromuscular> { }
                    
        public class ChildBallardNeuromuscularCollection : TTObject.TTChildObjectCollection<BallardNeuromuscular>
        {
            public ChildBallardNeuromuscularCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBallardNeuromuscularCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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
    /// Kolun Geriye Kıvrılması
    /// </summary>
        public BallardNeuroArmEnum? Arm
        {
            get { return (BallardNeuroArmEnum?)(int?)this["ARM"]; }
            set { this["ARM"] = value; }
        }

    /// <summary>
    /// Topuktan Kulağa
    /// </summary>
        public BallardNeuroHeelEnum? Heel
        {
            get { return (BallardNeuroHeelEnum?)(int?)this["HEEL"]; }
            set { this["HEEL"] = value; }
        }

    /// <summary>
    /// Popliteal Açı
    /// </summary>
        public BallardNeuroPoplitealEnum? Popliteal
        {
            get { return (BallardNeuroPoplitealEnum?)(int?)this["POPLITEAL"]; }
            set { this["POPLITEAL"] = value; }
        }

    /// <summary>
    /// Postur
    /// </summary>
        public BallardNeuroPostureEnum? Posture
        {
            get { return (BallardNeuroPostureEnum?)(int?)this["POSTURE"]; }
            set { this["POSTURE"] = value; }
        }

    /// <summary>
    /// Eşarp Belirtisi
    /// </summary>
        public BallardNeuroScarfEnum? Scarf
        {
            get { return (BallardNeuroScarfEnum?)(int?)this["SCARF"]; }
            set { this["SCARF"] = value; }
        }

    /// <summary>
    /// Dörtgen Pencere
    /// </summary>
        public BallardNeuroSquareEnum? Square
        {
            get { return (BallardNeuroSquareEnum?)(int?)this["SQUARE"]; }
            set { this["SQUARE"] = value; }
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

        protected BallardNeuromuscular(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BallardNeuromuscular(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BallardNeuromuscular(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BallardNeuromuscular(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BallardNeuromuscular(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BALLARDNEUROMUSCULAR", dataRow) { }
        protected BallardNeuromuscular(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BALLARDNEUROMUSCULAR", dataRow, isImported) { }
        public BallardNeuromuscular(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BallardNeuromuscular(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BallardNeuromuscular() : base() { }

    }
}