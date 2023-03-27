
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="NursingGlaskowComaScale")] 

    /// <summary>
    /// Glaskow Koma Skalası
    /// </summary>
    public  partial class NursingGlaskowComaScale : BaseNursingDataEntry
    {
        public class NursingGlaskowComaScaleList : TTObjectCollection<NursingGlaskowComaScale> { }
                    
        public class ChildNursingGlaskowComaScaleCollection : TTObject.TTChildObjectCollection<NursingGlaskowComaScale>
        {
            public ChildNursingGlaskowComaScaleCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildNursingGlaskowComaScaleCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Yeni { get { return new Guid("2f6b2d75-fb0e-43c9-a964-af59bb71f8b9"); } }
    /// <summary>
    /// Yanlış veriyi silmek için
    /// </summary>
            public static Guid Cancelled { get { return new Guid("c9a1ec5b-749a-4cff-9a32-d66e3b0d807b"); } }
        }

    /// <summary>
    /// Toplam Puan
    /// </summary>
        public GlaskowComaScaleScoreEnum? TotalScore
        {
            get { return (GlaskowComaScaleScoreEnum?)(int?)this["TOTALSCORE"]; }
            set { this["TOTALSCORE"] = value; }
        }

    /// <summary>
    /// Tarih
    /// </summary>
        public DateTime? ActionDate
        {
            get { return (DateTime?)this["ACTIONDATE"]; }
            set { this["ACTIONDATE"] = value; }
        }

    /// <summary>
    /// Not
    /// </summary>
        public object Note
        {
            get { return (object)this["NOTE"]; }
            set { this["NOTE"] = value; }
        }

    /// <summary>
    /// Sözel Cevap
    /// </summary>
        public GlaskowComaScaleDefinition OralAnswer
        {
            get { return (GlaskowComaScaleDefinition)((ITTObject)this).GetParent("ORALANSWER"); }
            set { this["ORALANSWER"] = (value==null ? null : (Guid?)value.ObjectID); }
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

        protected NursingGlaskowComaScale(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected NursingGlaskowComaScale(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected NursingGlaskowComaScale(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected NursingGlaskowComaScale(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected NursingGlaskowComaScale(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "NURSINGGLASKOWCOMASCALE", dataRow) { }
        protected NursingGlaskowComaScale(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "NURSINGGLASKOWCOMASCALE", dataRow, isImported) { }
        public NursingGlaskowComaScale(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public NursingGlaskowComaScale(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public NursingGlaskowComaScale() : base() { }

    }
}