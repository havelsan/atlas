
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MBSAssignPrice")] 

    public  partial class MBSAssignPrice : TTObject
    {
        public class MBSAssignPriceList : TTObjectCollection<MBSAssignPrice> { }
                    
        public class ChildMBSAssignPriceCollection : TTObject.TTChildObjectCollection<MBSAssignPrice>
        {
            public ChildMBSAssignPriceCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMBSAssignPriceCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Gelir Vergisi
    /// </summary>
        public double? IncomeTax
        {
            get { return (double?)this["INCOMETAX"]; }
            set { this["INCOMETAX"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Comment
        {
            get { return (string)this["COMMENT"]; }
            set { this["COMMENT"] = value; }
        }

    /// <summary>
    /// Damga Vergisi
    /// </summary>
        public double? StampTax
        {
            get { return (double?)this["STAMPTAX"]; }
            set { this["STAMPTAX"] = value; }
        }

    /// <summary>
    /// Toplam kesinti
    /// </summary>
        public double? TotalReduction
        {
            get { return (double?)this["TOTALREDUCTION"]; }
            set { this["TOTALREDUCTION"] = value; }
        }

    /// <summary>
    /// Net İta
    /// </summary>
        public double? NetIncome
        {
            get { return (double?)this["NETINCOME"]; }
            set { this["NETINCOME"] = value; }
        }

    /// <summary>
    /// Toplam
    /// </summary>
        public double? Total
        {
            get { return (double?)this["TOTAL"]; }
            set { this["TOTAL"] = value; }
        }

        public MBSPerson Person
        {
            get { return (MBSPerson)((ITTObject)this).GetParent("PERSON"); }
            set { this["PERSON"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MBSPeriod Period
        {
            get { return (MBSPeriod)((ITTObject)this).GetParent("PERIOD"); }
            set { this["PERIOD"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MBSAssignPrice(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MBSAssignPrice(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MBSAssignPrice(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MBSAssignPrice(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MBSAssignPrice(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MBSASSIGNPRICE", dataRow) { }
        protected MBSAssignPrice(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MBSASSIGNPRICE", dataRow, isImported) { }
        public MBSAssignPrice(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MBSAssignPrice(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MBSAssignPrice() : base() { }

    }
}