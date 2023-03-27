
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DentalTreatmentDepartmentGrid")] 

    /// <summary>
    /// Diş Tedavi Birimleri
    /// </summary>
    public  partial class DentalTreatmentDepartmentGrid : TTObject
    {
        public class DentalTreatmentDepartmentGridList : TTObjectCollection<DentalTreatmentDepartmentGrid> { }
                    
        public class ChildDentalTreatmentDepartmentGridCollection : TTObject.TTChildObjectCollection<DentalTreatmentDepartmentGrid>
        {
            public ChildDentalTreatmentDepartmentGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDentalTreatmentDepartmentGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Diş Tedavi Yapılacak Birimler
    /// </summary>
        public DentalTreatmentDefinition DentalTreatmentDefinition
        {
            get { return (DentalTreatmentDefinition)((ITTObject)this).GetParent("DENTALTREATMENTDEFINITION"); }
            set { this["DENTALTREATMENTDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Diş Tedavi Birimleri
    /// </summary>
        public ResSection Department
        {
            get { return (ResSection)((ITTObject)this).GetParent("DEPARTMENT"); }
            set { this["DEPARTMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DentalTreatmentDepartmentGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DentalTreatmentDepartmentGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DentalTreatmentDepartmentGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DentalTreatmentDepartmentGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DentalTreatmentDepartmentGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DENTALTREATMENTDEPARTMENTGRID", dataRow) { }
        protected DentalTreatmentDepartmentGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DENTALTREATMENTDEPARTMENTGRID", dataRow, isImported) { }
        protected DentalTreatmentDepartmentGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DentalTreatmentDepartmentGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DentalTreatmentDepartmentGrid() : base() { }

    }
}