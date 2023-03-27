
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="NursingSpiritualEvaluation")] 

    /// <summary>
    /// Ruhsal Değerlendirme
    /// </summary>
    public  partial class NursingSpiritualEvaluation : BaseNursingDataEntry
    {
        public class NursingSpiritualEvaluationList : TTObjectCollection<NursingSpiritualEvaluation> { }
                    
        public class ChildNursingSpiritualEvaluationCollection : TTObject.TTChildObjectCollection<NursingSpiritualEvaluation>
        {
            public ChildNursingSpiritualEvaluationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildNursingSpiritualEvaluationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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
    /// Ruh hali normal
    /// </summary>
        public bool? Normal
        {
            get { return (bool?)this["NORMAL"]; }
            set { this["NORMAL"] = value; }
        }

    /// <summary>
    /// Ruh hali öfkeli
    /// </summary>
        public bool? Furious
        {
            get { return (bool?)this["FURIOUS"]; }
            set { this["FURIOUS"] = value; }
        }

    /// <summary>
    /// Ruh hali üzüntülü
    /// </summary>
        public bool? Sad
        {
            get { return (bool?)this["SAD"]; }
            set { this["SAD"] = value; }
        }

    /// <summary>
    /// Endişeli
    /// </summary>
        public bool? Nervous
        {
            get { return (bool?)this["NERVOUS"]; }
            set { this["NERVOUS"] = value; }
        }

    /// <summary>
    /// Kayıtsız
    /// </summary>
        public bool? Indifferent
        {
            get { return (bool?)this["INDIFFERENT"]; }
            set { this["INDIFFERENT"] = value; }
        }

    /// <summary>
    /// Diğer ruh halleri
    /// </summary>
        public bool? Other
        {
            get { return (bool?)this["OTHER"]; }
            set { this["OTHER"] = value; }
        }

    /// <summary>
    /// Diğer açıklama
    /// </summary>
        public string Explanation
        {
            get { return (string)this["EXPLANATION"]; }
            set { this["EXPLANATION"] = value; }
        }

        protected NursingSpiritualEvaluation(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected NursingSpiritualEvaluation(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected NursingSpiritualEvaluation(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected NursingSpiritualEvaluation(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected NursingSpiritualEvaluation(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "NURSINGSPIRITUALEVALUATION", dataRow) { }
        protected NursingSpiritualEvaluation(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "NURSINGSPIRITUALEVALUATION", dataRow, isImported) { }
        public NursingSpiritualEvaluation(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public NursingSpiritualEvaluation(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public NursingSpiritualEvaluation() : base() { }

    }
}