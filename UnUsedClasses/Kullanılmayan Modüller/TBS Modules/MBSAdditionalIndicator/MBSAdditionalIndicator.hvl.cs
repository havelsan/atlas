
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MBSAdditionalIndicator")] 

    public  partial class MBSAdditionalIndicator : TTObject
    {
        public class MBSAdditionalIndicatorList : TTObjectCollection<MBSAdditionalIndicator> { }
                    
        public class ChildMBSAdditionalIndicatorCollection : TTObject.TTChildObjectCollection<MBSAdditionalIndicator>
        {
            public ChildMBSAdditionalIndicatorCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMBSAdditionalIndicatorCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Rütbe / Branş
    /// </summary>
        public string RankBranch
        {
            get { return (string)this["RANKBRANCH"]; }
            set { this["RANKBRANCH"] = value; }
        }

    /// <summary>
    /// Ek gösterge
    /// </summary>
        public int? AdditionalIndicator
        {
            get { return (int?)this["ADDITIONALINDICATOR"]; }
            set { this["ADDITIONALINDICATOR"] = value; }
        }

    /// <summary>
    /// Özel hizmet yüzdesi
    /// </summary>
        public int? PrivateDutyPercent
        {
            get { return (int?)this["PRIVATEDUTYPERCENT"]; }
            set { this["PRIVATEDUTYPERCENT"] = value; }
        }

    /// <summary>
    /// Yan ödeme puanı
    /// </summary>
        public double? AuxiliaryPaymentPoint
        {
            get { return (double?)this["AUXILIARYPAYMENTPOINT"]; }
            set { this["AUXILIARYPAYMENTPOINT"] = value; }
        }

    /// <summary>
    /// Yan ödeme kodu
    /// </summary>
        public string AuxiliaryPaymentCode
        {
            get { return (string)this["AUXILIARYPAYMENTCODE"]; }
            set { this["AUXILIARYPAYMENTCODE"] = value; }
        }

    /// <summary>
    /// Ek özel hizmet yüzdesi
    /// </summary>
        public double? AdditionalPrivateDutyPercent
        {
            get { return (double?)this["ADDITIONALPRIVATEDUTYPERCENT"]; }
            set { this["ADDITIONALPRIVATEDUTYPERCENT"] = value; }
        }

    /// <summary>
    /// Derece
    /// </summary>
        public int? Degree
        {
            get { return (int?)this["DEGREE"]; }
            set { this["DEGREE"] = value; }
        }

        public MBSPeriod Period
        {
            get { return (MBSPeriod)((ITTObject)this).GetParent("PERIOD"); }
            set { this["PERIOD"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MBSAdditionalIndicator(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MBSAdditionalIndicator(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MBSAdditionalIndicator(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MBSAdditionalIndicator(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MBSAdditionalIndicator(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MBSADDITIONALINDICATOR", dataRow) { }
        protected MBSAdditionalIndicator(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MBSADDITIONALINDICATOR", dataRow, isImported) { }
        public MBSAdditionalIndicator(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MBSAdditionalIndicator(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MBSAdditionalIndicator() : base() { }

    }
}