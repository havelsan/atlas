
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MhSFinancialStatementItemDefinition")] 

    public  partial class MhSFinancialStatementItemDefinition : TTDefinitionSet
    {
        public class MhSFinancialStatementItemDefinitionList : TTObjectCollection<MhSFinancialStatementItemDefinition> { }
                    
        public class ChildMhSFinancialStatementItemDefinitionCollection : TTObject.TTChildObjectCollection<MhSFinancialStatementItemDefinition>
        {
            public ChildMhSFinancialStatementItemDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMhSFinancialStatementItemDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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
    /// Formül
    /// </summary>
        public string Formula
        {
            get { return (string)this["FORMULA"]; }
            set { this["FORMULA"] = value; }
        }

    /// <summary>
    /// Kaynak Tipi
    /// </summary>
        public MhSFinancialStatementSourceType? SourceType
        {
            get { return (MhSFinancialStatementSourceType?)(int?)this["SOURCETYPE"]; }
            set { this["SOURCETYPE"] = value; }
        }

    /// <summary>
    /// Kod
    /// </summary>
        public string Code
        {
            get { return (string)this["CODE"]; }
            set { this["CODE"] = value; }
        }

    /// <summary>
    /// Tip
    /// </summary>
        public MhSFinancialStatementItemTypeEnum? Type
        {
            get { return (MhSFinancialStatementItemTypeEnum?)(int?)this["TYPE"]; }
            set { this["TYPE"] = value; }
        }

    /// <summary>
    /// Sıra
    /// </summary>
        public int? Order
        {
            get { return (int?)this["ORDER"]; }
            set { this["ORDER"] = value; }
        }

        public MhSFinancialStatementItemGroup Group
        {
            get { return (MhSFinancialStatementItemGroup)((ITTObject)this).GetParent("GROUP"); }
            set { this["GROUP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MhSFinancialStatementDefinition FinancialStatement
        {
            get { return (MhSFinancialStatementDefinition)((ITTObject)this).GetParent("FINANCIALSTATEMENT"); }
            set { this["FINANCIALSTATEMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MhSFinancialStatementItemDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MhSFinancialStatementItemDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MhSFinancialStatementItemDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MhSFinancialStatementItemDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MhSFinancialStatementItemDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MHSFINANCIALSTATEMENTITEMDEFINITION", dataRow) { }
        protected MhSFinancialStatementItemDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MHSFINANCIALSTATEMENTITEMDEFINITION", dataRow, isImported) { }
        public MhSFinancialStatementItemDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MhSFinancialStatementItemDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MhSFinancialStatementItemDefinition() : base() { }

    }
}