
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="WeightChart")] 

    public  partial class WeightChart : BaseMultipleDataEntry
    {
        public class WeightChartList : TTObjectCollection<WeightChart> { }
                    
        public class ChildWeightChartCollection : TTObject.TTChildObjectCollection<WeightChart>
        {
            public ChildWeightChartCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildWeightChartCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Ölçümü Yapan
    /// </summary>
        public string MeasuringPerson
        {
            get { return (string)this["MEASURINGPERSON"]; }
            set { this["MEASURINGPERSON"] = value; }
        }

    /// <summary>
    /// Kilo (gr)
    /// </summary>
        public int? Weight
        {
            get { return (int?)this["WEIGHT"]; }
            set { this["WEIGHT"] = value; }
        }

    /// <summary>
    /// Boy (cm)
    /// </summary>
        public int? Length
        {
            get { return (int?)this["LENGTH"]; }
            set { this["LENGTH"] = value; }
        }

    /// <summary>
    /// Baş Çevresi (cm)
    /// </summary>
        public int? HeadCircumference
        {
            get { return (int?)this["HEADCIRCUMFERENCE"]; }
            set { this["HEADCIRCUMFERENCE"] = value; }
        }

        public ResUser RequesterPerson
        {
            get { return (ResUser)((ITTObject)this).GetParent("REQUESTERPERSON"); }
            set { this["REQUESTERPERSON"] = (value==null ? null : (Guid?)value.ObjectID); }
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

        protected WeightChart(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected WeightChart(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected WeightChart(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected WeightChart(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected WeightChart(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "WEIGHTCHART", dataRow) { }
        protected WeightChart(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "WEIGHTCHART", dataRow, isImported) { }
        public WeightChart(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public WeightChart(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public WeightChart() : base() { }

    }
}