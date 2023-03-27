
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SUTRuleCheckResult")] 

    /// <summary>
    /// SUT Kural Kontrol İşlem Günlüğü
    /// </summary>
    public  partial class SUTRuleCheckResult : TTObject
    {
        public class SUTRuleCheckResultList : TTObjectCollection<SUTRuleCheckResult> { }
                    
        public class ChildSUTRuleCheckResultCollection : TTObject.TTChildObjectCollection<SUTRuleCheckResult>
        {
            public ChildSUTRuleCheckResultCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSUTRuleCheckResultCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// SUT Kural Kontrol Sonuçları
    /// </summary>
        public string CheckResults
        {
            get { return (string)this["CHECKRESULTS"]; }
            set { this["CHECKRESULTS"] = value; }
        }

    /// <summary>
    /// İşlem Tarihi
    /// </summary>
        public DateTime? ProcessDate
        {
            get { return (DateTime?)this["PROCESSDATE"]; }
            set { this["PROCESSDATE"] = value; }
        }

    /// <summary>
    /// SUT Kural Doğrulama Sonuçları
    /// </summary>
        public string Results
        {
            get { return (string)this["RESULTS"]; }
            set { this["RESULTS"] = value; }
        }

    /// <summary>
    /// İşlem Durumu
    /// </summary>
        public SUTRuleCheckResultStatus? Status
        {
            get { return (SUTRuleCheckResultStatus?)(int?)this["STATUS"]; }
            set { this["STATUS"] = value; }
        }

        public ResUser ResUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESUSER"); }
            set { this["RESUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Episode
    /// </summary>
        public Episode Episode
        {
            get { return (Episode)((ITTObject)this).GetParent("EPISODE"); }
            set { this["EPISODE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected SUTRuleCheckResult(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SUTRuleCheckResult(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SUTRuleCheckResult(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SUTRuleCheckResult(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SUTRuleCheckResult(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SUTRULECHECKRESULT", dataRow) { }
        protected SUTRuleCheckResult(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SUTRULECHECKRESULT", dataRow, isImported) { }
        public SUTRuleCheckResult(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SUTRuleCheckResult(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SUTRuleCheckResult() : base() { }

    }
}