
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MhSStampTaxInfo")] 

    /// <summary>
    /// Damga Vergisi Bilgileri
    /// </summary>
    public  partial class MhSStampTaxInfo : TTObject
    {
        public class MhSStampTaxInfoList : TTObjectCollection<MhSStampTaxInfo> { }
                    
        public class ChildMhSStampTaxInfoCollection : TTObject.TTChildObjectCollection<MhSStampTaxInfo>
        {
            public ChildMhSStampTaxInfoCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMhSStampTaxInfoCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Adresi
    /// </summary>
        public string Address
        {
            get { return (string)this["ADDRESS"]; }
            set { this["ADDRESS"] = value; }
        }

    /// <summary>
    /// Kime
    /// </summary>
        public string ToWhom
        {
            get { return (string)this["TOWHOM"]; }
            set { this["TOWHOM"] = value; }
        }

    /// <summary>
    /// Vergi Numarası
    /// </summary>
        public string TaxNumber
        {
            get { return (string)this["TAXNUMBER"]; }
            set { this["TAXNUMBER"] = value; }
        }

    /// <summary>
    /// Vergi Dairesi
    /// </summary>
        public string TaxDepartment
        {
            get { return (string)this["TAXDEPARTMENT"]; }
            set { this["TAXDEPARTMENT"] = value; }
        }

    /// <summary>
    /// Çalışma Yılı
    /// </summary>
        public MhSPeriod Period
        {
            get { return (MhSPeriod)((ITTObject)this).GetParent("PERIOD"); }
            set { this["PERIOD"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Fiş
    /// </summary>
        public MhSSlip Slip
        {
            get { return (MhSSlip)((ITTObject)this).GetParent("SLIP"); }
            set { this["SLIP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MhSStampTaxInfo(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MhSStampTaxInfo(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MhSStampTaxInfo(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MhSStampTaxInfo(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MhSStampTaxInfo(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MHSSTAMPTAXINFO", dataRow) { }
        protected MhSStampTaxInfo(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MHSSTAMPTAXINFO", dataRow, isImported) { }
        public MhSStampTaxInfo(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MhSStampTaxInfo(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MhSStampTaxInfo() : base() { }

    }
}