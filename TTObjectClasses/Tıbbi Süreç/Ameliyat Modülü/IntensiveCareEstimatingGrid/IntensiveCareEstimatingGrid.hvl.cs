
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="IntensiveCareEstimatingGrid")] 

    /// <summary>
    /// Anestezi Sonrası Değerlendirme
    /// </summary>
    public  partial class IntensiveCareEstimatingGrid : TTObject
    {
        public class IntensiveCareEstimatingGridList : TTObjectCollection<IntensiveCareEstimatingGrid> { }
                    
        public class ChildIntensiveCareEstimatingGridCollection : TTObject.TTChildObjectCollection<IntensiveCareEstimatingGrid>
        {
            public ChildIntensiveCareEstimatingGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildIntensiveCareEstimatingGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Activite
    /// </summary>
        public AnesthesiaEstimateEnum? Activite
        {
            get { return (AnesthesiaEstimateEnum?)(int?)this["ACTIVITE"]; }
            set { this["ACTIVITE"] = value; }
        }

    /// <summary>
    /// Solunum
    /// </summary>
        public AnesthesiaEstimateEnum? Respiration
        {
            get { return (AnesthesiaEstimateEnum?)(int?)this["RESPIRATION"]; }
            set { this["RESPIRATION"] = value; }
        }

    /// <summary>
    /// Dolaşım
    /// </summary>
        public AnesthesiaEstimateEnum? Circulation
        {
            get { return (AnesthesiaEstimateEnum?)(int?)this["CIRCULATION"]; }
            set { this["CIRCULATION"] = value; }
        }

    /// <summary>
    /// Uyanıklık
    /// </summary>
        public AnesthesiaEstimateEnum? Wakefulness
        {
            get { return (AnesthesiaEstimateEnum?)(int?)this["WAKEFULNESS"]; }
            set { this["WAKEFULNESS"] = value; }
        }

    /// <summary>
    /// Renk
    /// </summary>
        public AnesthesiaEstimateEnum? Color
        {
            get { return (AnesthesiaEstimateEnum?)(int?)this["COLOR"]; }
            set { this["COLOR"] = value; }
        }

    /// <summary>
    /// Tarih/Saat
    /// </summary>
        public DateTime? DateTime
        {
            get { return (DateTime?)this["DATETIME"]; }
            set { this["DATETIME"] = value; }
        }

    /// <summary>
    /// Toplam Puan
    /// </summary>
        public int? TotalScore
        {
            get { return (int?)this["TOTALSCORE"]; }
            set { this["TOTALSCORE"] = value; }
        }

    /// <summary>
    /// Anestezi Derleme-Anestezi Sonrası Değerlendirme
    /// </summary>
        public IntensiveCareAfterSurgery IntensiveCareAfterSurgery
        {
            get { return (IntensiveCareAfterSurgery)((ITTObject)this).GetParent("INTENSIVECAREAFTERSURGERY"); }
            set { this["INTENSIVECAREAFTERSURGERY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected IntensiveCareEstimatingGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected IntensiveCareEstimatingGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected IntensiveCareEstimatingGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected IntensiveCareEstimatingGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected IntensiveCareEstimatingGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "INTENSIVECAREESTIMATINGGRID", dataRow) { }
        protected IntensiveCareEstimatingGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "INTENSIVECAREESTIMATINGGRID", dataRow, isImported) { }
        public IntensiveCareEstimatingGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public IntensiveCareEstimatingGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public IntensiveCareEstimatingGrid() : base() { }

    }
}