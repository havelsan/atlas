
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DateCorrectionDetail")] 

    public  partial class DateCorrectionDetail : TTObject
    {
        public class DateCorrectionDetailList : TTObjectCollection<DateCorrectionDetail> { }
                    
        public class ChildDateCorrectionDetailCollection : TTObject.TTChildObjectCollection<DateCorrectionDetail>
        {
            public ChildDateCorrectionDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDateCorrectionDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Miktar
    /// </summary>
        public Currency? Amount
        {
            get { return (Currency?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

    /// <summary>
    /// Degiştir
    /// </summary>
        public bool? ChangeTransaction
        {
            get { return (bool?)this["CHANGETRANSACTION"]; }
            set { this["CHANGETRANSACTION"] = value; }
        }

    /// <summary>
    /// İşlem Numarası
    /// </summary>
        public long? ChangeStockActionID
        {
            get { return (long?)this["CHANGESTOCKACTIONID"]; }
            set { this["CHANGESTOCKACTIONID"] = value; }
        }

    /// <summary>
    /// Mevcut
    /// </summary>
        public Currency? ChangeInheld
        {
            get { return (Currency?)this["CHANGEINHELD"]; }
            set { this["CHANGEINHELD"] = value; }
        }

    /// <summary>
    /// Muvakkat
    /// </summary>
        public Currency? ChangeConsigned
        {
            get { return (Currency?)this["CHANGECONSIGNED"]; }
            set { this["CHANGECONSIGNED"] = value; }
        }

        public StockActionDateCorrection StockActionDateCorrection
        {
            get { return (StockActionDateCorrection)((ITTObject)this).GetParent("STOCKACTIONDATECORRECTION"); }
            set { this["STOCKACTIONDATECORRECTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public StockTransaction StockTransaction
        {
            get { return (StockTransaction)((ITTObject)this).GetParent("STOCKTRANSACTION"); }
            set { this["STOCKTRANSACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DateCorrectionDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DateCorrectionDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DateCorrectionDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DateCorrectionDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DateCorrectionDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DATECORRECTIONDETAIL", dataRow) { }
        protected DateCorrectionDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DATECORRECTIONDETAIL", dataRow, isImported) { }
        public DateCorrectionDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DateCorrectionDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DateCorrectionDetail() : base() { }

    }
}