
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BaseNursingOrderDetails")] 

    /// <summary>
    /// Vital tipleri olmayan Hemşire Orderlarının uygulanması sırasında kullanılacak Form
    /// </summary>
    public  partial class BaseNursingOrderDetails : PeriodicOrderDetail
    {
        public class BaseNursingOrderDetailsList : TTObjectCollection<BaseNursingOrderDetails> { }
                    
        public class ChildBaseNursingOrderDetailsCollection : TTObject.TTChildObjectCollection<BaseNursingOrderDetails>
        {
            public ChildBaseNursingOrderDetailsCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBaseNursingOrderDetailsCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid New { get { return new Guid("1c28a828-4470-46a5-af69-701b5322df1f"); } }
            public static Guid Completed { get { return new Guid("35536bbc-e567-46c8-be88-3bc9d65bfd5f"); } }
            public static Guid Cancelled { get { return new Guid("d16bf872-a7d1-476c-806d-92fd1852dccc"); } }
        }

    /// <summary>
    /// Sonuç
    /// </summary>
        public string Result
        {
            get { return (string)this["RESULT"]; }
            set { this["RESULT"] = value; }
        }

    /// <summary>
    /// Hemşire Notu
    /// </summary>
        public string Notes
        {
            get { return (string)this["NOTES"]; }
            set { this["NOTES"] = value; }
        }

    /// <summary>
    /// Nabız (ANT için)
    /// </summary>
        public string Result_Pulse
        {
            get { return (string)this["RESULT_PULSE"]; }
            set { this["RESULT_PULSE"] = value; }
        }

    /// <summary>
    /// Tansiyon (ANT için)
    /// </summary>
        public string ResultBloodPressure
        {
            get { return (string)this["RESULTBLOODPRESSURE"]; }
            set { this["RESULTBLOODPRESSURE"] = value; }
        }

    /// <summary>
    /// SPO2(ANT için)
    /// </summary>
        public string Result_SPO2
        {
            get { return (string)this["RESULT_SPO2"]; }
            set { this["RESULT_SPO2"] = value; }
        }

        public VitalSignAndNursingValueDefinition ResultBySelection
        {
            get { return (VitalSignAndNursingValueDefinition)((ITTObject)this).GetParent("RESULTBYSELECTION"); }
            set { this["RESULTBYSELECTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public VitalSign VitalSign
        {
            get { return (VitalSign)((ITTObject)this).GetParent("VITALSIGN"); }
            set { this["VITALSIGN"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected BaseNursingOrderDetails(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BaseNursingOrderDetails(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BaseNursingOrderDetails(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BaseNursingOrderDetails(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BaseNursingOrderDetails(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BASENURSINGORDERDETAILS", dataRow) { }
        protected BaseNursingOrderDetails(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BASENURSINGORDERDETAILS", dataRow, isImported) { }
        public BaseNursingOrderDetails(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BaseNursingOrderDetails(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BaseNursingOrderDetails() : base() { }

    }
}