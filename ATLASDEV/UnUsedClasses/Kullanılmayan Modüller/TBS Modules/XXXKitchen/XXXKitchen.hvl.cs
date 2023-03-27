
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="XXXKitchen")] 

    /// <summary>
    /// Mutfak
    /// </summary>
    public  partial class XXXKitchen : TTDefinitionSet
    {
        public class XXXKitchenList : TTObjectCollection<XXXKitchen> { }
                    
        public class ChildXXXKitchenCollection : TTObject.TTChildObjectCollection<XXXKitchen>
        {
            public ChildXXXKitchenCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildXXXKitchenCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        virtual protected void CreateBoardCollection()
        {
            _Board = new MLRBoard.ChildMLRBoardCollection(this, new Guid("2c732f88-009a-4711-b8b2-6ca8731020c4"));
            ((ITTChildObjectCollection)_Board).GetChildren();
        }

        protected MLRBoard.ChildMLRBoardCollection _Board = null;
    /// <summary>
    /// Child collection for Tabelanın Mutfağı
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

        protected XXXKitchen(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected XXXKitchen(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected XXXKitchen(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected XXXKitchen(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected XXXKitchen(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "XXXKITCHEN", dataRow) { }
        protected XXXKitchen(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "XXXKITCHEN", dataRow, isImported) { }
        public XXXKitchen(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public XXXKitchen(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public XXXKitchen() : base() { }

    }
}