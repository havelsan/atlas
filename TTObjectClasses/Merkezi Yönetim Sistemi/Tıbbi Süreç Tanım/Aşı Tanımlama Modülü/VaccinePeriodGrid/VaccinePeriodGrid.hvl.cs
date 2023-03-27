
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="VaccinePeriodGrid")] 

    public  partial class VaccinePeriodGrid : TTObject
    {
        public class VaccinePeriodGridList : TTObjectCollection<VaccinePeriodGrid> { }
                    
        public class ChildVaccinePeriodGridCollection : TTObject.TTChildObjectCollection<VaccinePeriodGrid>
        {
            public ChildVaccinePeriodGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildVaccinePeriodGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Periyod Tanımı
    /// </summary>
        public string PeriodDescription
        {
            get { return (string)this["PERIODDESCRIPTION"]; }
            set { this["PERIODDESCRIPTION"] = value; }
        }

    /// <summary>
    /// Periyod Süresi
    /// </summary>
        public int? Period
        {
            get { return (int?)this["PERIOD"]; }
            set { this["PERIOD"] = value; }
        }

    /// <summary>
    /// Birim
    /// </summary>
        public PeriodUnitTypeEnum? PeriodType
        {
            get { return (PeriodUnitTypeEnum?)(int?)this["PERIODTYPE"]; }
            set { this["PERIODTYPE"] = value; }
        }

    /// <summary>
    /// Periyod Numarası
    /// </summary>
        public int? PeriodNumber
        {
            get { return (int?)this["PERIODNUMBER"]; }
            set { this["PERIODNUMBER"] = value; }
        }

        public VaccineDefinition VaccineDefinition
        {
            get { return (VaccineDefinition)((ITTObject)this).GetParent("VACCINEDEFINITION"); }
            set { this["VACCINEDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected VaccinePeriodGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected VaccinePeriodGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected VaccinePeriodGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected VaccinePeriodGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected VaccinePeriodGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "VACCINEPERIODGRID", dataRow) { }
        protected VaccinePeriodGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "VACCINEPERIODGRID", dataRow, isImported) { }
        public VaccinePeriodGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public VaccinePeriodGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public VaccinePeriodGrid() : base() { }

    }
}