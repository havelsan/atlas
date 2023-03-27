
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MhSFinancialStatementDefinition")] 

    public  partial class MhSFinancialStatementDefinition : TTDefinitionSet
    {
        public class MhSFinancialStatementDefinitionList : TTObjectCollection<MhSFinancialStatementDefinition> { }
                    
        public class ChildMhSFinancialStatementDefinitionCollection : TTObject.TTChildObjectCollection<MhSFinancialStatementDefinition>
        {
            public ChildMhSFinancialStatementDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMhSFinancialStatementDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Tablo Tipi
    /// </summary>
        public MhSFinancialStatementTypeEnum? StatementType
        {
            get { return (MhSFinancialStatementTypeEnum?)(int?)this["STATEMENTTYPE"]; }
            set { this["STATEMENTTYPE"] = value; }
        }

    /// <summary>
    /// Ad
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Dipnot
    /// </summary>
        public string Footnote
        {
            get { return (string)this["FOOTNOTE"]; }
            set { this["FOOTNOTE"] = value; }
        }

        virtual protected void CreateItemsCollection()
        {
            _Items = new MhSFinancialStatementItemDefinition.ChildMhSFinancialStatementItemDefinitionCollection(this, new Guid("153ef630-8eb1-4fed-b76c-0cf008b29eb6"));
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

        virtual protected void CreateGroupsCollection()
        {
            _Groups = new MhSFinancialStatementItemGroup.ChildMhSFinancialStatementItemGroupCollection(this, new Guid("388256fe-908f-4847-9d52-5581b61792d7"));
            ((ITTChildObjectCollection)_Groups).GetChildren();
        }

        protected MhSFinancialStatementItemGroup.ChildMhSFinancialStatementItemGroupCollection _Groups = null;
        public MhSFinancialStatementItemGroup.ChildMhSFinancialStatementItemGroupCollection Groups
        {
            get
            {
                if (_Groups == null)
                    CreateGroupsCollection();
                return _Groups;
            }
        }

        protected MhSFinancialStatementDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MhSFinancialStatementDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MhSFinancialStatementDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MhSFinancialStatementDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MhSFinancialStatementDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MHSFINANCIALSTATEMENTDEFINITION", dataRow) { }
        protected MhSFinancialStatementDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MHSFINANCIALSTATEMENTDEFINITION", dataRow, isImported) { }
        public MhSFinancialStatementDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MhSFinancialStatementDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MhSFinancialStatementDefinition() : base() { }

    }
}