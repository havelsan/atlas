
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="EmergencyInterventionNutritionDiet")] 

    /// <summary>
    /// Acil Müdahale Beslenme ve Diyet Sekmesi
    /// </summary>
    public  partial class EmergencyInterventionNutritionDiet : BaseNutritionDiet
    {
        public class EmergencyInterventionNutritionDietList : TTObjectCollection<EmergencyInterventionNutritionDiet> { }
                    
        public class ChildEmergencyInterventionNutritionDietCollection : TTObject.TTChildObjectCollection<EmergencyInterventionNutritionDiet>
        {
            public ChildEmergencyInterventionNutritionDietCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildEmergencyInterventionNutritionDietCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid New { get { return new Guid("1c28a828-4470-46a5-af69-701b5322df1f"); } }
            public static Guid Completed { get { return new Guid("35536bbc-e567-46c8-be88-3bc9d65bfd5f"); } }
            public static Guid Cancelled { get { return new Guid("d16bf872-a7d1-476c-806d-92fd1852dccc"); } }
        }

        public string Nutrition
        {
            get { return (string)this["NUTRITION"]; }
            set { this["NUTRITION"] = value; }
        }

    /// <summary>
    /// Tarih/Saat
    /// </summary>
        public DateTime? AcionDate
        {
            get { return (DateTime?)this["ACIONDATE"]; }
            set { this["ACIONDATE"] = value; }
        }

    /// <summary>
    /// Yeme Yeri
    /// </summary>
        public NutritionDietPlaceDefinition Place
        {
            get { return (NutritionDietPlaceDefinition)((ITTObject)this).GetParent("PLACE"); }
            set { this["PLACE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public EmergencyIntervention EmergencyIntervention
        {
            get 
            {   
                if (EpisodeAction is EmergencyIntervention)
                    return (EmergencyIntervention)EpisodeAction; 
                return null;
            }            
            set { EpisodeAction = value; }
        }

        protected EmergencyInterventionNutritionDiet(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected EmergencyInterventionNutritionDiet(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected EmergencyInterventionNutritionDiet(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected EmergencyInterventionNutritionDiet(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected EmergencyInterventionNutritionDiet(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EMERGENCYINTERVENTIONNUTRITIONDIET", dataRow) { }
        protected EmergencyInterventionNutritionDiet(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EMERGENCYINTERVENTIONNUTRITIONDIET", dataRow, isImported) { }
        public EmergencyInterventionNutritionDiet(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public EmergencyInterventionNutritionDiet(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public EmergencyInterventionNutritionDiet() : base() { }

    }
}