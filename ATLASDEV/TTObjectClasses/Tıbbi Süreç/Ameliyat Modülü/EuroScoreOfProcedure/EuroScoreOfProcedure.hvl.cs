
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="EuroScoreOfProcedure")] 

    public  partial class EuroScoreOfProcedure : TTObject
    {
        public class EuroScoreOfProcedureList : TTObjectCollection<EuroScoreOfProcedure> { }
                    
        public class ChildEuroScoreOfProcedureCollection : TTObject.TTChildObjectCollection<EuroScoreOfProcedure>
        {
            public ChildEuroScoreOfProcedureCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildEuroScoreOfProcedureCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public EuroScoreAgeEnum? EuroScoreAge
        {
            get { return (EuroScoreAgeEnum?)(int?)this["EUROSCOREAGE"]; }
            set { this["EUROSCOREAGE"] = value; }
        }

        public SexEnum? Sex
        {
            get { return (SexEnum?)(int?)this["SEX"]; }
            set { this["SEX"] = value; }
        }

        public bool? ChronicPulmonaryDisease
        {
            get { return (bool?)this["CHRONICPULMONARYDISEASE"]; }
            set { this["CHRONICPULMONARYDISEASE"] = value; }
        }

        public bool? ExtracardiacArteriopathy
        {
            get { return (bool?)this["EXTRACARDIACARTERIOPATHY"]; }
            set { this["EXTRACARDIACARTERIOPATHY"] = value; }
        }

        public bool? PreviousCardiacSurgery
        {
            get { return (bool?)this["PREVIOUSCARDIACSURGERY"]; }
            set { this["PREVIOUSCARDIACSURGERY"] = value; }
        }

        public bool? NeurologicalDysfunction
        {
            get { return (bool?)this["NEUROLOGICALDYSFUNCTION"]; }
            set { this["NEUROLOGICALDYSFUNCTION"] = value; }
        }

        public bool? HemodiyalizPatient
        {
            get { return (bool?)this["HEMODIYALIZPATIENT"]; }
            set { this["HEMODIYALIZPATIENT"] = value; }
        }

        public bool? ActiveEndokardit
        {
            get { return (bool?)this["ACTIVEENDOKARDIT"]; }
            set { this["ACTIVEENDOKARDIT"] = value; }
        }

        public bool? CriticalPreoperativeState
        {
            get { return (bool?)this["CRITICALPREOPERATIVESTATE"]; }
            set { this["CRITICALPREOPERATIVESTATE"] = value; }
        }

        public bool? DiabetesMellitus
        {
            get { return (bool?)this["DIABETESMELLITUS"]; }
            set { this["DIABETESMELLITUS"] = value; }
        }

        public bool? PulmonerHipertansiyon
        {
            get { return (bool?)this["PULMONERHIPERTANSIYON"]; }
            set { this["PULMONERHIPERTANSIYON"] = value; }
        }

        public bool? TorasikAortaSurgery
        {
            get { return (bool?)this["TORASIKAORTASURGERY"]; }
            set { this["TORASIKAORTASURGERY"] = value; }
        }

        public bool? PostMI_VSD
        {
            get { return (bool?)this["POSTMI_VSD"]; }
            set { this["POSTMI_VSD"] = value; }
        }

        public EuroScoreLvDysfunctionEnum? LvDysfunction
        {
            get { return (EuroScoreLvDysfunctionEnum?)(int?)this["LVDYSFUNCTION"]; }
            set { this["LVDYSFUNCTION"] = value; }
        }

        public int? Score
        {
            get { return (int?)this["SCORE"]; }
            set { this["SCORE"] = value; }
        }

        public MedulaEuroScoreEnum? MedulaEuroScoreRisk
        {
            get { return (MedulaEuroScoreEnum?)(int?)this["MEDULAEUROSCORERISK"]; }
            set { this["MEDULAEUROSCORERISK"] = value; }
        }

        protected EuroScoreOfProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected EuroScoreOfProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected EuroScoreOfProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected EuroScoreOfProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected EuroScoreOfProcedure(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EUROSCOREOFPROCEDURE", dataRow) { }
        protected EuroScoreOfProcedure(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EUROSCOREOFPROCEDURE", dataRow, isImported) { }
        public EuroScoreOfProcedure(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public EuroScoreOfProcedure(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public EuroScoreOfProcedure() : base() { }

    }
}