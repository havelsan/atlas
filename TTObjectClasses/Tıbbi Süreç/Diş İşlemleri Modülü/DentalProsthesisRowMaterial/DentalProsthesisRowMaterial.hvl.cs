
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DentalProsthesisRowMaterial")] 

    /// <summary>
    /// Diş protez hammadde(gram) sekmesi
    /// </summary>
    public  partial class DentalProsthesisRowMaterial : TTObject
    {
        public class DentalProsthesisRowMaterialList : TTObjectCollection<DentalProsthesisRowMaterial> { }
                    
        public class ChildDentalProsthesisRowMaterialCollection : TTObject.TTChildObjectCollection<DentalProsthesisRowMaterial>
        {
            public ChildDentalProsthesisRowMaterialCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDentalProsthesisRowMaterialCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Alınan
    /// </summary>
        public double? TakenRowMaterial
        {
            get { return (double?)this["TAKENROWMATERIAL"]; }
            set { this["TAKENROWMATERIAL"] = value; }
        }

    /// <summary>
    /// Fire verilen
    /// </summary>
        public double? LossRowMaterial
        {
            get { return (double?)this["LOSSROWMATERIAL"]; }
            set { this["LOSSROWMATERIAL"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Definition
        {
            get { return (string)this["DEFINITION"]; }
            set { this["DEFINITION"] = value; }
        }

    /// <summary>
    /// İade
    /// </summary>
        public double? ReturnedRowMaterial
        {
            get { return (double?)this["RETURNEDROWMATERIAL"]; }
            set { this["RETURNEDROWMATERIAL"] = value; }
        }

    /// <summary>
    /// Sarf Edilen
    /// </summary>
        public double? ExpendRowMaterial
        {
            get { return (double?)this["EXPENDROWMATERIAL"]; }
            set { this["EXPENDROWMATERIAL"] = value; }
        }

    /// <summary>
    /// DentalProsthesis_ DentalProsthesisRowMaterial
    /// </summary>
        public DentalProsthesisProcedure DentalProsthesis
        {
            get { return (DentalProsthesisProcedure)((ITTObject)this).GetParent("DENTALPROSTHESIS"); }
            set { this["DENTALPROSTHESIS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DentalProsthesisRowMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DentalProsthesisRowMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DentalProsthesisRowMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DentalProsthesisRowMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DentalProsthesisRowMaterial(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DENTALPROSTHESISROWMATERIAL", dataRow) { }
        protected DentalProsthesisRowMaterial(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DENTALPROSTHESISROWMATERIAL", dataRow, isImported) { }
        public DentalProsthesisRowMaterial(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DentalProsthesisRowMaterial(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DentalProsthesisRowMaterial() : base() { }

    }
}