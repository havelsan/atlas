
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MBSTravel")] 

    /// <summary>
    /// Seyahat
    /// </summary>
    public  partial class MBSTravel : TTObject
    {
        public class MBSTravelList : TTObjectCollection<MBSTravel> { }
                    
        public class ChildMBSTravelCollection : TTObject.TTChildObjectCollection<MBSTravel>
        {
            public ChildMBSTravelCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMBSTravelCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Geliş Saati
    /// </summary>
        public string ArrivalTime
        {
            get { return (string)this["ARRIVALTIME"]; }
            set { this["ARRIVALTIME"] = value; }
        }

    /// <summary>
    /// Mesafe
    /// </summary>
        public double? Distance
        {
            get { return (double?)this["DISTANCE"]; }
            set { this["DISTANCE"] = value; }
        }

    /// <summary>
    /// Ayrıldığı yer
    /// </summary>
        public string DeparturePlace
        {
            get { return (string)this["DEPARTUREPLACE"]; }
            set { this["DEPARTUREPLACE"] = value; }
        }

    /// <summary>
    /// Geliş Tarihi
    /// </summary>
        public DateTime? ArrivalDate
        {
            get { return (DateTime?)this["ARRIVALDATE"]; }
            set { this["ARRIVALDATE"] = value; }
        }

    /// <summary>
    /// Gidilen yer
    /// </summary>
        public string ArrivalPlace
        {
            get { return (string)this["ARRIVALPLACE"]; }
            set { this["ARRIVALPLACE"] = value; }
        }

    /// <summary>
    /// Gidiş Saati
    /// </summary>
        public string DepartureTime
        {
            get { return (string)this["DEPARTURETIME"]; }
            set { this["DEPARTURETIME"] = value; }
        }

    /// <summary>
    /// Mesafe tutarı
    /// </summary>
        public double? PriceForDistance
        {
            get { return (double?)this["PRICEFORDISTANCE"]; }
            set { this["PRICEFORDISTANCE"] = value; }
        }

    /// <summary>
    /// Gidiş tarih
    /// </summary>
        public DateTime? DepartureDate
        {
            get { return (DateTime?)this["DEPARTUREDATE"]; }
            set { this["DEPARTUREDATE"] = value; }
        }

        public MBSTravelExpense TravelExpense
        {
            get { return (MBSTravelExpense)((ITTObject)this).GetParent("TRAVELEXPENSE"); }
            set { this["TRAVELEXPENSE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MBSTravel(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MBSTravel(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MBSTravel(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MBSTravel(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MBSTravel(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MBSTRAVEL", dataRow) { }
        protected MBSTravel(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MBSTRAVEL", dataRow, isImported) { }
        public MBSTravel(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MBSTravel(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MBSTravel() : base() { }

    }
}