
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BloodBankCrossmatch")] 

    /// <summary>
    /// Crossmatch Testi
    /// </summary>
    public  partial class BloodBankCrossmatch : EpisodeAction
    {
        public class BloodBankCrossmatchList : TTObjectCollection<BloodBankCrossmatch> { }
                    
        public class ChildBloodBankCrossmatchCollection : TTObject.TTChildObjectCollection<BloodBankCrossmatch>
        {
            public ChildBloodBankCrossmatchCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBloodBankCrossmatchCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid Request { get { return new Guid("f947bead-45f1-433c-b988-4d7e7ee74be2"); } }
            public static Guid Reject { get { return new Guid("8394ecef-8b85-42f0-868d-47b2502ebf49"); } }
            public static Guid Completed { get { return new Guid("bdab7c95-64b1-4630-85e6-b39a4fad0e8b"); } }
            public static Guid Accept { get { return new Guid("6eb62272-a23b-4018-bc81-f1f81430aaf3"); } }
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
    /// İstek Açıklaması
    /// </summary>
        public string RequestDescription
        {
            get { return (string)this["REQUESTDESCRIPTION"]; }
            set { this["REQUESTDESCRIPTION"] = value; }
        }

    /// <summary>
    /// Protokol No
    /// </summary>
        public int? ProtocolNo
        {
            get { return (int?)this["PROTOCOLNO"]; }
            set { this["PROTOCOLNO"] = value; }
        }

        virtual protected void CreateBloodBankCrossmatchTestsCollection()
        {
            _BloodBankCrossmatchTests = new BloodBankCrossmatchTest.ChildBloodBankCrossmatchTestCollection(this, new Guid("ec277fb8-bb07-43b4-b6f2-2a4e78df74a5"));
            ((ITTChildObjectCollection)_BloodBankCrossmatchTests).GetChildren();
        }

        protected BloodBankCrossmatchTest.ChildBloodBankCrossmatchTestCollection _BloodBankCrossmatchTests = null;
        public BloodBankCrossmatchTest.ChildBloodBankCrossmatchTestCollection BloodBankCrossmatchTests
        {
            get
            {
                if (_BloodBankCrossmatchTests == null)
                    CreateBloodBankCrossmatchTestsCollection();
                return _BloodBankCrossmatchTests;
            }
        }

        protected BloodBankCrossmatch(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BloodBankCrossmatch(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BloodBankCrossmatch(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BloodBankCrossmatch(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BloodBankCrossmatch(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BLOODBANKCROSSMATCH", dataRow) { }
        protected BloodBankCrossmatch(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BLOODBANKCROSSMATCH", dataRow, isImported) { }
        public BloodBankCrossmatch(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BloodBankCrossmatch(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BloodBankCrossmatch() : base() { }

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