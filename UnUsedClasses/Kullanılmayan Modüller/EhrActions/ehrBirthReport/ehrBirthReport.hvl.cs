
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ehrBirthReport")] 

    /// <summary>
    /// Doğum Raporu
    /// </summary>
    public  partial class ehrBirthReport : ehrEpisodeAction
    {
        public class ehrBirthReportList : TTObjectCollection<ehrBirthReport> { }
                    
        public class ChildehrBirthReportCollection : TTObject.TTChildObjectCollection<ehrBirthReport>
        {
            public ChildehrBirthReportCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildehrBirthReportCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Active { get { return new Guid("d82caca1-a08a-43fa-b009-be70b816c5ec"); } }
            public static Guid UnActive { get { return new Guid("8abe0000-7e19-46e0-a07f-e69109e6aa4c"); } }
        }

    /// <summary>
    /// Bebeğin Durumu
    /// </summary>
        public BirthReportBabyStatus? BabyStatus
        {
            get { return (BirthReportBabyStatus?)(int?)this["BABYSTATUS"]; }
            set { this["BABYSTATUS"] = value; }
        }

    /// <summary>
    /// Doğum Saati
    /// </summary>
        public DateTime? BirthTime
        {
            get { return (DateTime?)this["BIRTHTIME"]; }
            set { this["BIRTHTIME"] = value; }
        }

    /// <summary>
    /// Boy
    /// </summary>
        public double? Height
        {
            get { return (double?)this["HEIGHT"]; }
            set { this["HEIGHT"] = value; }
        }

    /// <summary>
    /// Rapor
    /// </summary>
        public string Report
        {
            get { return (string)this["REPORT"]; }
            set { this["REPORT"] = value; }
        }

    /// <summary>
    /// Cinsiyet
    /// </summary>
        public SexEnum? Sex
        {
            get { return (SexEnum?)(int?)this["SEX"]; }
            set { this["SEX"] = value; }
        }

    /// <summary>
    /// Ağırlık
    /// </summary>
        public double? Weight
        {
            get { return (double?)this["WEIGHT"]; }
            set { this["WEIGHT"] = value; }
        }

    /// <summary>
    /// Epizyotemi
    /// </summary>
        public YesNoEnum? Episiotomy
        {
            get { return (YesNoEnum?)(int?)this["EPISIOTOMY"]; }
            set { this["EPISIOTOMY"] = value; }
        }

    /// <summary>
    /// Bebek Doğum Tarihi
    /// </summary>
        public DateTime? BabyBirthDate
        {
            get { return (DateTime?)this["BABYBIRTHDATE"]; }
            set { this["BABYBIRTHDATE"] = value; }
        }

    /// <summary>
    /// Doğum Şekli
    /// </summary>
        public BornType BornType
        {
            get { return (BornType)((ITTObject)this).GetParent("BORNTYPE"); }
            set { this["BORNTYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ehrBirthReport(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ehrBirthReport(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ehrBirthReport(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ehrBirthReport(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ehrBirthReport(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EHRBIRTHREPORT", dataRow) { }
        protected ehrBirthReport(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EHRBIRTHREPORT", dataRow, isImported) { }
        public ehrBirthReport(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ehrBirthReport(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ehrBirthReport() : base() { }

    }
}