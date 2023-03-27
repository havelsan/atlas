
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MhSFinancialStatementItemGroup")] 

    public  partial class MhSFinancialStatementItemGroup : TTDefinitionSet
    {
        public class MhSFinancialStatementItemGroupList : TTObjectCollection<MhSFinancialStatementItemGroup> { }
                    
        public class ChildMhSFinancialStatementItemGroupCollection : TTObject.TTChildObjectCollection<MhSFinancialStatementItemGroup>
        {
            public ChildMhSFinancialStatementItemGroupCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMhSFinancialStatementItemGroupCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Grup İsmi
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public MhSFinancialStatementDefinition FinancialStatement
        {
            get { return (MhSFinancialStatementDefinition)((ITTObject)this).GetParent("FINANCIALSTATEMENT"); }
            set { this["FINANCIALSTATEMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateItemsCollection()
        {
            _Items = new MhSFinancialStatementItemDefinition.ChildMhSFinancialStatementItemDefinitionCollection(this, new Guid("c2fe9ff4-eaf0-4276-b3ec-03db5d373abf"));
            ((ITTChildObjectCollection)_Items).GetChildren();
        }

        protected MhSFinancialStatementItemDefinition.ChildMhSFinancialStatementItemDefinitionCollection _Items = null;
        public MhSFinancialStatementItemDefinition.ChildMhSFinancialStatementItemDefinitionCollection Items
        {
            get
            {
                if (_Items == null)
                    CreateItemsCollection();
                return _Items;
            }
        }

        protected MhSFinancialStatementItemGroup(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MhSFinancialStatementItemGroup(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MhSFinancialStatementItemGroup(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MhSFinancialStatementItemGroup(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MhSFinancialStatementItemGroup(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MHSFINANCIALSTATEMENTITEMGROUP", dataRow) { }
        protected MhSFinancialStatementItemGroup(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MHSFINANCIALSTATEMENTITEMGROUP", dataRow, isImported) { }
        public MhSFinancialStatementItemGroup(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MhSFinancialStatementItemGroup(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MhSFinancialStatementItemGroup() : base() { }

    }
}