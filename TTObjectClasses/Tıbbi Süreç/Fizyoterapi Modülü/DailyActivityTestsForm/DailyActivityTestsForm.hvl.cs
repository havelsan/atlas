
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DailyActivityTestsForm")] 

    /// <summary>
    /// Günlük Yaşam Aktiviteleri Testi
    /// </summary>
    public  partial class DailyActivityTestsForm : BaseAdditionalInfo
    {
        public class DailyActivityTestsFormList : TTObjectCollection<DailyActivityTestsForm> { }
                    
        public class ChildDailyActivityTestsFormCollection : TTObject.TTChildObjectCollection<DailyActivityTestsForm>
        {
            public ChildDailyActivityTestsFormCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDailyActivityTestsFormCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Barthel Testi
    /// </summary>
        public string BarthelTest
        {
            get { return (string)this["BARTHELTEST"]; }
            set { this["BARTHELTEST"] = value; }
        }

    /// <summary>
    /// Fonksiyonel Bağımsızlık Ölçümü (FIM)
    /// </summary>
        public string FonctionalIndependenceMeasure
        {
            get { return (string)this["FONCTIONALINDEPENDENCEMEASURE"]; }
            set { this["FONCTIONALINDEPENDENCEMEASURE"] = value; }
        }

    /// <summary>
    /// Sağlık Değerlendirme Anketi (HAQ)
    /// </summary>
        public string HealthAssessmentQuostionnarie
        {
            get { return (string)this["HEALTHASSESSMENTQUOSTIONNARIE"]; }
            set { this["HEALTHASSESSMENTQUOSTIONNARIE"] = value; }
        }

    /// <summary>
    /// Bath Fonksiyonel İndeksi (BASFI)
    /// </summary>
        public string BASFI
        {
            get { return (string)this["BASFI"]; }
            set { this["BASFI"] = value; }
        }

    /// <summary>
    /// Katz İndeksi
    /// </summary>
        public string KatzIndex
        {
            get { return (string)this["KATZINDEX"]; }
            set { this["KATZINDEX"] = value; }
        }

        protected DailyActivityTestsForm(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DailyActivityTestsForm(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DailyActivityTestsForm(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DailyActivityTestsForm(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DailyActivityTestsForm(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DAILYACTIVITYTESTSFORM", dataRow) { }
        protected DailyActivityTestsForm(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DAILYACTIVITYTESTSFORM", dataRow, isImported) { }
        public DailyActivityTestsForm(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DailyActivityTestsForm(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DailyActivityTestsForm() : base() { }

    }
}