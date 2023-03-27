
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PA_DischargedCadet")] 

    /// <summary>
    /// Özel Statülü XXXXXX Öğrenci
    /// </summary>
    public  partial class PA_DischargedCadet : PatientAdmission
    {
        public class PA_DischargedCadetList : TTObjectCollection<PA_DischargedCadet> { }
                    
        public class ChildPA_DischargedCadetCollection : TTObject.TTChildObjectCollection<PA_DischargedCadet>
        {
            public ChildPA_DischargedCadetCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPA_DischargedCadetCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
    /// <summary>
    /// Açık
    /// </summary>
            public static Guid Open { get { return new Guid("2a43b5c5-e070-4e5f-a792-63e6cdf9e97c"); } }
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("fe3624fd-600f-44e6-a59b-87ff7a9d2532"); } }
        }

    /// <summary>
    /// Sağlık Fişi No
    /// </summary>
        public string HealtSlipNumber
        {
            get { return (string)this["HEALTSLIPNUMBER"]; }
            set { this["HEALTSLIPNUMBER"] = value; }
        }

    /// <summary>
    /// Kurum Sicil No
    /// </summary>
        public string RetirementFundID
        {
            get { return (string)this["RETIREMENTFUNDID"]; }
            set { this["RETIREMENTFUNDID"] = value; }
        }

    /// <summary>
    /// Kurum İli
    /// </summary>
        public City PayerCity
        {
            get { return (City)((ITTObject)this).GetParent("PAYERCITY"); }
            set { this["PAYERCITY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PA_DischargedCadet(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PA_DischargedCadet(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PA_DischargedCadet(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PA_DischargedCadet(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PA_DischargedCadet(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PA_DISCHARGEDCADET", dataRow) { }
        protected PA_DischargedCadet(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PA_DISCHARGEDCADET", dataRow, isImported) { }
        public PA_DischargedCadet(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PA_DischargedCadet(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PA_DischargedCadet() : base() { }

    }
}