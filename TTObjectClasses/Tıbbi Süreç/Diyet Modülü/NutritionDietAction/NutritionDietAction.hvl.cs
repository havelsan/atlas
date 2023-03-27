
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="NutritionDietAction")] 

    public  partial class NutritionDietAction : EpisodeAction, IWorkListEpisodeAction
    {
        public class NutritionDietActionList : TTObjectCollection<NutritionDietAction> { }
                    
        public class ChildNutritionDietActionCollection : TTObject.TTChildObjectCollection<NutritionDietAction>
        {
            public ChildNutritionDietActionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildNutritionDietActionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid New { get { return new Guid("d90be2c9-324f-4307-b590-f1d0cbe362f2"); } }
            public static Guid Complete { get { return new Guid("fe4b4d74-546a-4785-9d87-003d38976cd9"); } }
        }

    /// <summary>
    /// Yapılan Diyet Uygulamaları
    /// </summary>
        public object Application
        {
            get { return (object)this["APPLICATION"]; }
            set { this["APPLICATION"] = value; }
        }

    /// <summary>
    /// Diyet Özeti
    /// </summary>
        public string NutritionDietBrief
        {
            get { return (string)this["NUTRITIONDIETBRIEF"]; }
            set { this["NUTRITIONDIETBRIEF"] = value; }
        }

    /// <summary>
    /// Bazal Metabolizma Hızı
    /// </summary>
        public double? BasalMetabolism
        {
            get { return (double?)this["BASALMETABOLISM"]; }
            set { this["BASALMETABOLISM"] = value; }
        }

    /// <summary>
    /// Vücut Kitle İndeksi (BMI)
    /// </summary>
        public double? BodyMassIndex
        {
            get { return (double?)this["BODYMASSINDEX"]; }
            set { this["BODYMASSINDEX"] = value; }
        }

    /// <summary>
    /// Vücut Yüzey Alanı
    /// </summary>
        public double? BodySurfaceArea
        {
            get { return (double?)this["BODYSURFACEAREA"]; }
            set { this["BODYSURFACEAREA"] = value; }
        }

    /// <summary>
    /// Kontrol Tarihi
    /// </summary>
        public DateTime? ControlDate
        {
            get { return (DateTime?)this["CONTROLDATE"]; }
            set { this["CONTROLDATE"] = value; }
        }

    /// <summary>
    /// Boy(cm)
    /// </summary>
        public int? Height
        {
            get { return (int?)this["HEIGHT"]; }
            set { this["HEIGHT"] = value; }
        }

    /// <summary>
    /// İdeal Kilo
    /// </summary>
        public double? IdealBodyWeight
        {
            get { return (double?)this["IDEALBODYWEIGHT"]; }
            set { this["IDEALBODYWEIGHT"] = value; }
        }

    /// <summary>
    /// Elde Edilen Değer
    /// </summary>
        public InterpretingBodyMassIndexEnum? InterpretingBodyMassIndex
        {
            get { return (InterpretingBodyMassIndexEnum?)(int?)this["INTERPRETINGBODYMASSINDEX"]; }
            set { this["INTERPRETINGBODYMASSINDEX"] = value; }
        }

    /// <summary>
    /// Yağsız Vücut Ağırlığı
    /// </summary>
        public double? LeanBodyMass
        {
            get { return (double?)this["LEANBODYMASS"]; }
            set { this["LEANBODYMASS"] = value; }
        }

    /// <summary>
    /// Kilo(kg)
    /// </summary>
        public double? Weight
        {
            get { return (double?)this["WEIGHT"]; }
            set { this["WEIGHT"] = value; }
        }

    /// <summary>
    /// Tarih
    /// </summary>
        public DateTime? Date
        {
            get { return (DateTime?)this["DATE"]; }
            set { this["DATE"] = value; }
        }

        public ResUser ResUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESUSER"); }
            set { this["RESUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DietDefinition DietDefinition
        {
            get { return (DietDefinition)((ITTObject)this).GetParent("DIETDEFINITION"); }
            set { this["DIETDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateNutritionDietProceduresCollection()
        {
            _NutritionDietProcedures = new BaseNutritionDiet.ChildBaseNutritionDietCollection(this, new Guid("ec098848-84c1-4158-8048-1cc584eff621"));
            ((ITTChildObjectCollection)_NutritionDietProcedures).GetChildren();
        }

        protected BaseNutritionDiet.ChildBaseNutritionDietCollection _NutritionDietProcedures = null;
        public BaseNutritionDiet.ChildBaseNutritionDietCollection NutritionDietProcedures
        {
            get
            {
                if (_NutritionDietProcedures == null)
                    CreateNutritionDietProceduresCollection();
                return _NutritionDietProcedures;
            }
        }

        protected NutritionDietAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected NutritionDietAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected NutritionDietAction(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected NutritionDietAction(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected NutritionDietAction(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "NUTRITIONDIETACTION", dataRow) { }
        protected NutritionDietAction(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "NUTRITIONDIETACTION", dataRow, isImported) { }
        public NutritionDietAction(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public NutritionDietAction(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public NutritionDietAction() : base() { }

        override protected void RunPreTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePreScript(transDef))
                base.RunPreTransition(transDef.BaseTransDef);
            this.PreTransition(transDef);
        }
        override protected void RunPostTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePostScript(transDef))
                base.RunPostTransition(transDef.BaseTransDef);
            this.PostTransition(transDef);
        }
        override protected void RunUndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBaseUndoScript(transDef))
                base.RunUndoTransition(transDef.BaseTransDef);
            this.UndoTransition(transDef);
        }
    }
}