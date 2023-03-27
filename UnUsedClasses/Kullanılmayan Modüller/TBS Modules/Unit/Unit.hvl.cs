
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="Unit")] 

    /// <summary>
    /// Birimler
    /// </summary>
    public  partial class Unit : TTDefinitionSet
    {
        public class UnitList : TTObjectCollection<Unit> { }
                    
        public class ChildUnitCollection : TTObject.TTChildObjectCollection<Unit>
        {
            public ChildUnitCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildUnitCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Kodu
    /// </summary>
        public int? Code
        {
            get { return (int?)this["CODE"]; }
            set { this["CODE"] = value; }
        }

        virtual protected void CreateBoardCollection()
        {
            _Board = new MLRBoard.ChildMLRBoardCollection(this, new Guid("ba3e813b-8675-4b75-86dc-31dd52ecf753"));
            ((ITTChildObjectCollection)_Board).GetChildren();
        }

        protected MLRBoard.ChildMLRBoardCollection _Board = null;
    /// <summary>
    /// Child collection for Tabela Birimleri
    /// </summary>
        public MLRBoard.ChildMLRBoardCollection Board
        {
            get
            {
                if (_Board == null)
                    CreateBoardCollection();
                return _Board;
            }
        }

        protected Unit(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected Unit(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected Unit(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected Unit(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected Unit(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "UNIT", dataRow) { }
        protected Unit(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "UNIT", dataRow, isImported) { }
        public Unit(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public Unit(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public Unit() : base() { }

    }
}