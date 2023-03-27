
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="Snappe")] 

    public  partial class Snappe : BaseMultipleDataEntry
    {
        public class SnappeList : TTObjectCollection<Snappe> { }
                    
        public class ChildSnappeCollection : TTObject.TTChildObjectCollection<Snappe>
        {
            public ChildSnappeCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSnappeCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Toplam Snappe Skor
    /// </summary>
        public int? TotalScore
        {
            get { return (int?)this["TOTALSCORE"]; }
            set { this["TOTALSCORE"] = value; }
        }

    /// <summary>
    /// Apgar Skoru 5. Dakika
    /// </summary>
        public SnappeApgarEnum? Apgar
        {
            get { return (SnappeApgarEnum?)(int?)this["APGAR"]; }
            set { this["APGAR"] = value; }
        }

    /// <summary>
    /// Doğum Ağırlığı
    /// </summary>
        public SnappeBirthWeightEnum? BirthWeight
        {
            get { return (SnappeBirthWeightEnum?)(int?)this["BIRTHWEIGHT"]; }
            set { this["BIRTHWEIGHT"] = value; }
        }

    /// <summary>
    /// Diürez
    /// </summary>
        public SnappeDiuresisEnum? Diuresis
        {
            get { return (SnappeDiuresisEnum?)(int?)this["DIURESIS"]; }
            set { this["DIURESIS"] = value; }
        }

    /// <summary>
    /// En Düşük Isı
    /// </summary>
        public SnappeLowestTemperatureEnum? LowestTemperature
        {
            get { return (SnappeLowestTemperatureEnum?)(int?)this["LOWESTTEMPERATURE"]; }
            set { this["LOWESTTEMPERATURE"] = value; }
        }

    /// <summary>
    /// Ortalama Kan Basıncı (mmHg)
    /// </summary>
        public SnappeMeanBloodPressureEnum? MeanBloodPressure
        {
            get { return (SnappeMeanBloodPressureEnum?)(int?)this["MEANBLOODPRESSURE"]; }
            set { this["MEANBLOODPRESSURE"] = value; }
        }

    /// <summary>
    /// Çok Sayıda Konvülsiyon
    /// </summary>
        public SnappeMultipleConvulsionEnum? MultipleConvulsion
        {
            get { return (SnappeMultipleConvulsionEnum?)(int?)this["MULTIPLECONVULSION"]; }
            set { this["MULTIPLECONVULSION"] = value; }
        }

    /// <summary>
    /// Po2/FiO2
    /// </summary>
        public SnappePo2FiO2Enum? Po2FiO2
        {
            get { return (SnappePo2FiO2Enum?)(int?)this["PO2FIO2"]; }
            set { this["PO2FIO2"] = value; }
        }

    /// <summary>
    /// Serum PH
    /// </summary>
        public SnappeSerumPHEnum? SerumPH
        {
            get { return (SnappeSerumPHEnum?)(int?)this["SERUMPH"]; }
            set { this["SERUMPH"] = value; }
        }

    /// <summary>
    /// SGA
    /// </summary>
        public SnappeSGAEnum? SGA
        {
            get { return (SnappeSGAEnum?)(int?)this["SGA"]; }
            set { this["SGA"] = value; }
        }

    /// <summary>
    /// Toplam Snap Skor
    /// </summary>
        public int? TotalSnapScore
        {
            get { return (int?)this["TOTALSNAPSCORE"]; }
            set { this["TOTALSNAPSCORE"] = value; }
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

        protected Snappe(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected Snappe(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected Snappe(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected Snappe(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected Snappe(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SNAPPE", dataRow) { }
        protected Snappe(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SNAPPE", dataRow, isImported) { }
        public Snappe(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public Snappe(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public Snappe() : base() { }

    }
}