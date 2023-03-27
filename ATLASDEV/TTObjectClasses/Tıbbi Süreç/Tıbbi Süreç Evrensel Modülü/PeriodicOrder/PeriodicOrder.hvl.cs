
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PeriodicOrder")] 

    public  partial class PeriodicOrder : EpisodeAction, IAppointmentWithoutResources
    {
        public class PeriodicOrderList : TTObjectCollection<PeriodicOrder> { }
                    
        public class ChildPeriodicOrderCollection : TTObject.TTChildObjectCollection<PeriodicOrder>
        {
            public ChildPeriodicOrderCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPeriodicOrderCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Uygulama Aralığı
    /// </summary>
        public FrequencyEnum? Frequency
        {
            get { return (FrequencyEnum?)(int?)this["FREQUENCY"]; }
            set { this["FREQUENCY"] = value; }
        }

    /// <summary>
    /// Kilo
    /// </summary>
        public double? Weight
        {
            get { return (double?)this["WEIGHT"]; }
            set { this["WEIGHT"] = value; }
        }

    /// <summary>
    /// Gün
    /// </summary>
        public int? RecurrenceDayAmount
        {
            get { return (int?)this["RECURRENCEDAYAMOUNT"]; }
            set { this["RECURRENCEDAYAMOUNT"] = value; }
        }

    /// <summary>
    /// Uygulama  Miktarı
    /// </summary>
        public int? AmountForPeriod
        {
            get { return (int?)this["AMOUNTFORPERIOD"]; }
            set { this["AMOUNTFORPERIOD"] = value; }
        }

    /// <summary>
    /// Başlangıç Tarihi
    /// </summary>
        public DateTime? PeriodStartTime
        {
            get { return (DateTime?)this["PERIODSTARTTIME"]; }
            set { this["PERIODSTARTTIME"] = value; }
        }

    /// <summary>
    /// Boy
    /// </summary>
        public double? Heigth
        {
            get { return (double?)this["HEIGTH"]; }
            set { this["HEIGTH"] = value; }
        }

    /// <summary>
    /// Talimat Tarihi
    /// </summary>
        public DateTime? OrderDate
        {
            get { return (DateTime?)this["ORDERDATE"]; }
            set { this["ORDERDATE"] = value; }
        }

    /// <summary>
    /// Talimat Açıklaması
    /// </summary>
        public string OrderDescription
        {
            get { return (string)this["ORDERDESCRIPTION"]; }
            set { this["ORDERDESCRIPTION"] = value; }
        }

        public ProcedureDefinition ProcedureObject
        {
            get { return (ProcedureDefinition)((ITTObject)this).GetParent("PROCEDUREOBJECT"); }
            set { this["PROCEDUREOBJECT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateOrderDetailsCollectionViews()
        {
        }

        virtual protected void CreateOrderDetailsCollection()
        {
            _OrderDetails = new PeriodicOrderDetail.ChildPeriodicOrderDetailCollection(this, new Guid("0e0f8339-855a-47d0-baa8-cb2dbe940898"));
            CreateOrderDetailsCollectionViews();
            ((ITTChildObjectCollection)_OrderDetails).GetChildren();
        }

        protected PeriodicOrderDetail.ChildPeriodicOrderDetailCollection _OrderDetails = null;
        public PeriodicOrderDetail.ChildPeriodicOrderDetailCollection OrderDetails
        {
            get
            {
                if (_OrderDetails == null)
                    CreateOrderDetailsCollection();
                return _OrderDetails;
            }
        }

        protected PeriodicOrder(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PeriodicOrder(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PeriodicOrder(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PeriodicOrder(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PeriodicOrder(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PERIODICORDER", dataRow) { }
        protected PeriodicOrder(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PERIODICORDER", dataRow, isImported) { }
        public PeriodicOrder(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PeriodicOrder(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PeriodicOrder() : base() { }

    }
}