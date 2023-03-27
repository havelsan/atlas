
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ehrBaseDrugOrder")] 

    /// <summary>
    /// ehrBaseDrugOrder
    /// </summary>
    public  partial class ehrBaseDrugOrder : ehrSubactionMaterial
    {
        public class ehrBaseDrugOrderList : TTObjectCollection<ehrBaseDrugOrder> { }
                    
        public class ChildehrBaseDrugOrderCollection : TTObject.TTChildObjectCollection<ehrBaseDrugOrder>
        {
            public ChildehrBaseDrugOrderCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildehrBaseDrugOrderCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Active { get { return new Guid("b86c3e17-bf34-414c-b60c-182925abc911"); } }
            public static Guid Inactive { get { return new Guid("749387be-ff99-45ed-b18a-fb2b6a7a1190"); } }
        }

    /// <summary>
    /// Kullanma Açıklaması
    /// </summary>
        public string UsageNote
        {
            get { return (string)this["USAGENOTE"]; }
            set { this["USAGENOTE"] = value; }
        }

    /// <summary>
    /// Doz Aralığı
    /// </summary>
        public FrequencyEnum? Frequency
        {
            get { return (FrequencyEnum?)(int?)this["FREQUENCY"]; }
            set { this["FREQUENCY"] = value; }
        }

    /// <summary>
    /// Doz Miktarı
    /// </summary>
        public double? DoseAmount
        {
            get { return (double?)this["DOSEAMOUNT"]; }
            set { this["DOSEAMOUNT"] = value; }
        }

    /// <summary>
    /// Uygulama Başlangıç Zamanı
    /// </summary>
        public DateTime? PlannedStartTime
        {
            get { return (DateTime?)this["PLANNEDSTARTTIME"]; }
            set { this["PLANNEDSTARTTIME"] = value; }
        }

    /// <summary>
    /// Gün
    /// </summary>
        public int? Day
        {
            get { return (int?)this["DAY"]; }
            set { this["DAY"] = value; }
        }

        public SpecialityDefinition ProcedureSpeciality
        {
            get { return (SpecialityDefinition)((ITTObject)this).GetParent("PROCEDURESPECIALITY"); }
            set { this["PROCEDURESPECIALITY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ehrBaseDrugOrder(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ehrBaseDrugOrder(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ehrBaseDrugOrder(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ehrBaseDrugOrder(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ehrBaseDrugOrder(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EHRBASEDRUGORDER", dataRow) { }
        protected ehrBaseDrugOrder(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EHRBASEDRUGORDER", dataRow, isImported) { }
        public ehrBaseDrugOrder(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ehrBaseDrugOrder(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ehrBaseDrugOrder() : base() { }

    }
}