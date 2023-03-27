
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BloodBankCoombs")] 

    /// <summary>
    /// Coombs Testi
    /// </summary>
    public  partial class BloodBankCoombs : EpisodeAction
    {
        public class BloodBankCoombsList : TTObjectCollection<BloodBankCoombs> { }
                    
        public class ChildBloodBankCoombsCollection : TTObject.TTChildObjectCollection<BloodBankCoombs>
        {
            public ChildBloodBankCoombsCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBloodBankCoombsCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid Approve { get { return new Guid("73bbccd1-d218-480c-a371-0e75aee874f6"); } }
            public static Guid MakeRequest { get { return new Guid("95874382-ad5f-4b15-b325-5687dbd53228"); } }
            public static Guid ProcedureRepeat { get { return new Guid("72a2131f-e709-431b-86b1-26afb8b44ee4"); } }
            public static Guid Procedure { get { return new Guid("35979b6e-5fe7-4511-a7cf-2d1839681425"); } }
            public static Guid Reject { get { return new Guid("7dcfcca8-7385-40a8-95ea-8762909d3400"); } }
            public static Guid Completed { get { return new Guid("6ab1bda3-5b99-46b7-8a12-5d18af2084c3"); } }
            public static Guid Request { get { return new Guid("80b06204-992c-451f-86e3-fd973d9dcdc9"); } }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
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
    /// CoombsIstek
    /// </summary>
        public bool? IsdirectCoombs
        {
            get { return (bool?)this["ISDIRECTCOOMBS"]; }
            set { this["ISDIRECTCOOMBS"] = value; }
        }

    /// <summary>
    /// CoombsSonuc
    /// </summary>
        public bool? IsdirectCoombspos
        {
            get { return (bool?)this["ISDIRECTCOOMBSPOS"]; }
            set { this["ISDIRECTCOOMBSPOS"] = value; }
        }

    /// <summary>
    /// İsteyenDoktor
    /// </summary>
        public ResUser RequestDoctor
        {
            get { return (ResUser)((ITTObject)this).GetParent("REQUESTDOCTOR"); }
            set { this["REQUESTDOCTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateBloodBankCoombsTestCollection()
        {
            _BloodBankCoombsTest = new BloodBankCoombsTest.ChildBloodBankCoombsTestCollection(this, new Guid("a66d6584-1bf5-4258-a342-35e0d8c1ef0f"));
            ((ITTChildObjectCollection)_BloodBankCoombsTest).GetChildren();
        }

        protected BloodBankCoombsTest.ChildBloodBankCoombsTestCollection _BloodBankCoombsTest = null;
        public BloodBankCoombsTest.ChildBloodBankCoombsTestCollection BloodBankCoombsTest
        {
            get
            {
                if (_BloodBankCoombsTest == null)
                    CreateBloodBankCoombsTestCollection();
                return _BloodBankCoombsTest;
            }
        }

        protected BloodBankCoombs(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BloodBankCoombs(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BloodBankCoombs(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BloodBankCoombs(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BloodBankCoombs(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BLOODBANKCOOMBS", dataRow) { }
        protected BloodBankCoombs(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BLOODBANKCOOMBS", dataRow, isImported) { }
        public BloodBankCoombs(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BloodBankCoombs(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BloodBankCoombs() : base() { }

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