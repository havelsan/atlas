
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="OrthesisProsthesisHospitalsUnitsGrid")] 

    /// <summary>
    /// Havale Edilen Birimler XXXXXXler
    /// </summary>
    public  partial class OrthesisProsthesisHospitalsUnitsGrid : HospitalsUnitsGrid
    {
        public class OrthesisProsthesisHospitalsUnitsGridList : TTObjectCollection<OrthesisProsthesisHospitalsUnitsGrid> { }
                    
        public class ChildOrthesisProsthesisHospitalsUnitsGridCollection : TTObject.TTChildObjectCollection<OrthesisProsthesisHospitalsUnitsGrid>
        {
            public ChildOrthesisProsthesisHospitalsUnitsGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildOrthesisProsthesisHospitalsUnitsGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Birimler/XXXXXXler
    /// </summary>
        public OrthesisProsthesisRequest OrthesisProsthesisProcedure
        {
            get { return (OrthesisProsthesisRequest)((ITTObject)this).GetParent("ORTHESISPROSTHESISPROCEDURE"); }
            set { this["ORTHESISPROSTHESISPROCEDURE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected OrthesisProsthesisHospitalsUnitsGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected OrthesisProsthesisHospitalsUnitsGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected OrthesisProsthesisHospitalsUnitsGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected OrthesisProsthesisHospitalsUnitsGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected OrthesisProsthesisHospitalsUnitsGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ORTHESISPROSTHESISHOSPITALSUNITSGRID", dataRow) { }
        protected OrthesisProsthesisHospitalsUnitsGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ORTHESISPROSTHESISHOSPITALSUNITSGRID", dataRow, isImported) { }
        public OrthesisProsthesisHospitalsUnitsGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public OrthesisProsthesisHospitalsUnitsGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public OrthesisProsthesisHospitalsUnitsGrid() : base() { }

    }
}