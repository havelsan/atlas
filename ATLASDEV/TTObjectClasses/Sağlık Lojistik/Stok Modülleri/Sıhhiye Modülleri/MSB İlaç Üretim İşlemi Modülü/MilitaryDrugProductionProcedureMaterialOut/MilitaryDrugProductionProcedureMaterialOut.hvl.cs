
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MilitaryDrugProductionProcedureMaterialOut")] 

    /// <summary>
    /// XXXXXX İlaç Üretim İşlemi Sarf Edilen malzeme detaylarını tutan sınıftır
    /// </summary>
    public  partial class MilitaryDrugProductionProcedureMaterialOut : StockActionDetailOut
    {
        public class MilitaryDrugProductionProcedureMaterialOutList : TTObjectCollection<MilitaryDrugProductionProcedureMaterialOut> { }
                    
        public class ChildMilitaryDrugProductionProcedureMaterialOutCollection : TTObject.TTChildObjectCollection<MilitaryDrugProductionProcedureMaterialOut>
        {
            public ChildMilitaryDrugProductionProcedureMaterialOutCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMilitaryDrugProductionProcedureMaterialOutCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Seri Nu.
    /// </summary>
        public string SerialNumber
        {
            get { return (string)this["SERIALNUMBER"]; }
            set { this["SERIALNUMBER"] = value; }
        }

        protected MilitaryDrugProductionProcedureMaterialOut(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MilitaryDrugProductionProcedureMaterialOut(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MilitaryDrugProductionProcedureMaterialOut(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MilitaryDrugProductionProcedureMaterialOut(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MilitaryDrugProductionProcedureMaterialOut(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MILITARYDRUGPRODUCTIONPROCEDUREMATERIALOUT", dataRow) { }
        protected MilitaryDrugProductionProcedureMaterialOut(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MILITARYDRUGPRODUCTIONPROCEDUREMATERIALOUT", dataRow, isImported) { }
        public MilitaryDrugProductionProcedureMaterialOut(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MilitaryDrugProductionProcedureMaterialOut(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MilitaryDrugProductionProcedureMaterialOut() : base() { }

    }
}