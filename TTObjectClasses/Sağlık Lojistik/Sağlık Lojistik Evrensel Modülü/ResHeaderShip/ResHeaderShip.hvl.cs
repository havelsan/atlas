
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ResHeaderShip")] 

    /// <summary>
    /// Müdürlük Tanımı
    /// </summary>
    public  partial class ResHeaderShip : ResSection
    {
        public class ResHeaderShipList : TTObjectCollection<ResHeaderShip> { }
                    
        public class ChildResHeaderShipCollection : TTObject.TTChildObjectCollection<ResHeaderShip>
        {
            public ChildResHeaderShipCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildResHeaderShipCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// XXXXXX-Müdürlük
    /// </summary>
        public ResHospital Hospital
        {
            get { return (ResHospital)((ITTObject)this).GetParent("HOSPITAL"); }
            set { this["HOSPITAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateDivisionsCollection()
        {
            _Divisions = new ResDivision.ChildResDivisionCollection(this, new Guid("726ac324-96c8-4276-859f-7c4a850afbf0"));
            ((ITTChildObjectCollection)_Divisions).GetChildren();
        }

        protected ResDivision.ChildResDivisionCollection _Divisions = null;
    /// <summary>
    /// Child collection for Müdürlük-Bölüm
    /// </summary>
        public ResDivision.ChildResDivisionCollection Divisions
        {
            get
            {
                if (_Divisions == null)
                    CreateDivisionsCollection();
                return _Divisions;
            }
        }

        protected ResHeaderShip(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ResHeaderShip(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ResHeaderShip(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ResHeaderShip(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ResHeaderShip(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RESHEADERSHIP", dataRow) { }
        protected ResHeaderShip(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RESHEADERSHIP", dataRow, isImported) { }
        public ResHeaderShip(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ResHeaderShip(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ResHeaderShip() : base() { }

    }
}