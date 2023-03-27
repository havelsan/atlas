
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BloodBankDonorBloodCropTake")] 

    /// <summary>
    /// Dönor Kan Alım
    /// </summary>
    public  partial class BloodBankDonorBloodCropTake : EpisodeAction
    {
        public class BloodBankDonorBloodCropTakeList : TTObjectCollection<BloodBankDonorBloodCropTake> { }
                    
        public class ChildBloodBankDonorBloodCropTakeCollection : TTObject.TTChildObjectCollection<BloodBankDonorBloodCropTake>
        {
            public ChildBloodBankDonorBloodCropTakeCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBloodBankDonorBloodCropTakeCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid Accept { get { return new Guid("5b74360a-3279-4786-bdf8-014359924c1a"); } }
            public static Guid DonorInquiry { get { return new Guid("077c61fa-fc0b-48cf-86fa-372d94381f83"); } }
            public static Guid Completed { get { return new Guid("999a37d6-adc1-4062-9ad7-5a843a3c7185"); } }
            public static Guid ProductDegradation { get { return new Guid("cff81580-60c1-49c7-8a8a-5bae3383ef58"); } }
            public static Guid BloodDispose { get { return new Guid("96b46f74-ecbd-4e0f-ac47-31e308137925"); } }
            public static Guid BloodImpregnable { get { return new Guid("86f22318-3eda-46e4-b082-73030fb6b968"); } }
            public static Guid SendStock { get { return new Guid("2f99fd40-9c9f-411c-b9c6-f73e3bbab717"); } }
            public static Guid BloodAppropriate { get { return new Guid("8e8c465e-7f53-4183-8961-cbd6d4ceb9a7"); } }
            public static Guid Approve { get { return new Guid("7d236aa9-3fe7-4be4-adfb-f45646b18d66"); } }
            public static Guid Reject { get { return new Guid("40d686e0-a7e2-432b-b955-d1be02fd0167"); } }
        }

    /// <summary>
    /// İstek Açıklaması
    /// </summary>
        public string RequestDescription
        {
            get { return (string)this["REQUESTDESCRIPTION"]; }
            set { this["REQUESTDESCRIPTION"] = value; }
        }

    /// <summary>
    /// DonörAnket
    /// </summary>
        public bool? DonorInquiry
        {
            get { return (bool?)this["DONORINQUIRY"]; }
            set { this["DONORINQUIRY"] = value; }
        }

        protected BloodBankDonorBloodCropTake(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BloodBankDonorBloodCropTake(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BloodBankDonorBloodCropTake(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BloodBankDonorBloodCropTake(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BloodBankDonorBloodCropTake(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BLOODBANKDONORBLOODCROPTAKE", dataRow) { }
        protected BloodBankDonorBloodCropTake(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BLOODBANKDONORBLOODCROPTAKE", dataRow, isImported) { }
        public BloodBankDonorBloodCropTake(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BloodBankDonorBloodCropTake(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BloodBankDonorBloodCropTake() : base() { }

        override protected void RunPreTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePreScript(transDef))
                base.RunPreTransition(transDef.BaseTransDef);
            this.PreTransition(transDef);
        }
        override protected void RunPostTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePostScript(transDef))
                base.RunPostTransition(transDef.BaseTransDef);
            this.PostTransition(transDef);
        }
        override protected void RunUndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBaseUndoScript(transDef))
                base.RunUndoTransition(transDef.BaseTransDef);
            this.UndoTransition(transDef);
        }
    }
}