
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MhSFinancialStatementLine")] 

    /// <summary>
    /// Mali Tablo Satırı
    /// </summary>
    public  partial class MhSFinancialStatementLine : TTObject
    {
        public class MhSFinancialStatementLineList : TTObjectCollection<MhSFinancialStatementLine> { }
                    
        public class ChildMhSFinancialStatementLineCollection : TTObject.TTChildObjectCollection<MhSFinancialStatementLine>
        {
            public ChildMhSFinancialStatementLineCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMhSFinancialStatementLineCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// 2007 - 3
    /// </summary>
        public double? Current3
        {
            get { return (double?)this["CURRENT3"]; }
            set { this["CURRENT3"] = value; }
        }

    /// <summary>
    /// Sıra
    /// </summary>
        public int? Order
        {
            get { return (int?)this["ORDER"]; }
            set { this["ORDER"] = value; }
        }

    /// <summary>
    /// 2006 - 3
    /// </summary>
        public double? Previous3
        {
            get { return (double?)this["PREVIOUS3"]; }
            set { this["PREVIOUS3"] = value; }
        }

    /// <summary>
    /// Önceki Dönem
    /// </summary>
        public double? Previous
        {
            get { return (double?)this["PREVIOUS"]; }
            set { this["PREVIOUS"] = value; }
        }

    /// <summary>
    /// 2007 - 2
    /// </summary>
        public double? Current2
        {
            get { return (double?)this["CURRENT2"]; }
            set { this["CURRENT2"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Cari Dönem
    /// </summary>
        public double? Current
        {
            get { return (double?)this["CURRENT"]; }
            set { this["CURRENT"] = value; }
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
    /// 2006 - 2
    /// </summary>
        public double? Previous2
        {
            get { return (double?)this["PREVIOUS2"]; }
            set { this["PREVIOUS2"] = value; }
        }

    /// <summary>
    /// Tanımı
    /// </summary>
        public MhSFinancialStatementItemDefinition Definition
        {
            get { return (MhSFinancialStatementItemDefinition)((ITTObject)this).GetParent("DEFINITION"); }
            set { this["DEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Grup
    /// </summary>
        public MhSFinancialStatementItemGroup Group
        {
            get { return (MhSFinancialStatementItemGroup)((ITTObject)this).GetParent("GROUP"); }
            set { this["GROUP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Tablo
    /// </summary>
        public MhSFinancialStatements FinancialStatement
        {
            get { return (MhSFinancialStatements)((ITTObject)this).GetParent("FINANCIALSTATEMENT"); }
            set { this["FINANCIALSTATEMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MhSFinancialStatementLine(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MhSFinancialStatementLine(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MhSFinancialStatementLine(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MhSFinancialStatementLine(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MhSFinancialStatementLine(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MHSFINANCIALSTATEMENTLINE", dataRow) { }
        protected MhSFinancialStatementLine(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MHSFINANCIALSTATEMENTLINE", dataRow, isImported) { }
        public MhSFinancialStatementLine(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MhSFinancialStatementLine(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MhSFinancialStatementLine() : base() { }

    }
}