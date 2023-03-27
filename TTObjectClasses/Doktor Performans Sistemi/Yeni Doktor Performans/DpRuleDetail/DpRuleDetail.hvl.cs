
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DpRuleDetail")] 

    public  partial class DpRuleDetail : TTDefinitionSet
    {
        public class DpRuleDetailList : TTObjectCollection<DpRuleDetail> { }
                    
        public class ChildDpRuleDetailCollection : TTObject.TTChildObjectCollection<DpRuleDetail>
        {
            public ChildDpRuleDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDpRuleDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Cinsiyet
    /// </summary>
        public int? Sex
        {
            get { return (int?)this["SEX"]; }
            set { this["SEX"] = value; }
        }

    /// <summary>
    /// Tedavi Türü
    /// </summary>
        public string TedaviTuru
        {
            get { return (string)this["TEDAVITURU"]; }
            set { this["TEDAVITURU"] = value; }
        }

    /// <summary>
    /// Kesi Hesabı Yapılsın mı
    /// </summary>
        public int? Kesi
        {
            get { return (int?)this["KESI"]; }
            set { this["KESI"] = value; }
        }

    /// <summary>
    /// Rapor 
    /// </summary>
        public int? Report
        {
            get { return (int?)this["REPORT"]; }
            set { this["REPORT"] = value; }
        }

    /// <summary>
    /// Yaş
    /// </summary>
        public int? Age
        {
            get { return (int?)this["AGE"]; }
            set { this["AGE"] = value; }
        }

    /// <summary>
    /// Yaş Tipi
    /// </summary>
        public int? AgeType
        {
            get { return (int?)this["AGETYPE"]; }
            set { this["AGETYPE"] = value; }
        }

    /// <summary>
    /// Sağlık Tesisi
    /// </summary>
        public int? HospitalType
        {
            get { return (int?)this["HOSPITALTYPE"]; }
            set { this["HOSPITALTYPE"] = value; }
        }

    /// <summary>
    /// Kapsam
    /// </summary>
        public int? PeriodScope
        {
            get { return (int?)this["PERIODSCOPE"]; }
            set { this["PERIODSCOPE"] = value; }
        }

    /// <summary>
    /// Adet
    /// </summary>
        public int? PeriodAmount
        {
            get { return (int?)this["PERIODAMOUNT"]; }
            set { this["PERIODAMOUNT"] = value; }
        }

    /// <summary>
    /// Peryot
    /// </summary>
        public int? Period
        {
            get { return (int?)this["PERIOD"]; }
            set { this["PERIOD"] = value; }
        }

    /// <summary>
    /// Peryot Zaman Tipi
    /// </summary>
        public int? PeriodTimeType
        {
            get { return (int?)this["PERIODTIMETYPE"]; }
            set { this["PERIODTIMETYPE"] = value; }
        }

    /// <summary>
    /// Gil Kodu
    /// </summary>
        public string Master
        {
            get { return (string)this["MASTER"]; }
            set { this["MASTER"] = value; }
        }

        public DPRuleMaster DPRuleMaster
        {
            get { return (DPRuleMaster)((ITTObject)this).GetParent("DPRULEMASTER"); }
            set { this["DPRULEMASTER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DpRuleDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DpRuleDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DpRuleDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DpRuleDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DpRuleDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DPRULEDETAIL", dataRow) { }
        protected DpRuleDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DPRULEDETAIL", dataRow, isImported) { }
        public DpRuleDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DpRuleDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DpRuleDetail() : base() { }

    }
}