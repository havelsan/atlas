
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DentalProsthesisDepartmentGrid")] 

    /// <summary>
    /// Diş Protez Birimleri
    /// </summary>
    public  partial class DentalProsthesisDepartmentGrid : TTObject
    {
        public class DentalProsthesisDepartmentGridList : TTObjectCollection<DentalProsthesisDepartmentGrid> { }
                    
        public class ChildDentalProsthesisDepartmentGridCollection : TTObject.TTChildObjectCollection<DentalProsthesisDepartmentGrid>
        {
            public ChildDentalProsthesisDepartmentGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDentalProsthesisDepartmentGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public ResSection Department
        {
            get { return (ResSection)((ITTObject)this).GetParent("DEPARTMENT"); }
            set { this["DEPARTMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Diş Protez Birimleri
    /// </summary>
        public DentalProsthesisDefinition DentalProsthesisDefinition
        {
            get { return (DentalProsthesisDefinition)((ITTObject)this).GetParent("DENTALPROSTHESISDEFINITION"); }
            set { this["DENTALPROSTHESISDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DentalProsthesisDepartmentGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DentalProsthesisDepartmentGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DentalProsthesisDepartmentGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DentalProsthesisDepartmentGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DentalProsthesisDepartmentGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DENTALPROSTHESISDEPARTMENTGRID", dataRow) { }
        protected DentalProsthesisDepartmentGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DENTALPROSTHESISDEPARTMENTGRID", dataRow, isImported) { }
        public DentalProsthesisDepartmentGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DentalProsthesisDepartmentGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DentalProsthesisDepartmentGrid() : base() { }

    }
}