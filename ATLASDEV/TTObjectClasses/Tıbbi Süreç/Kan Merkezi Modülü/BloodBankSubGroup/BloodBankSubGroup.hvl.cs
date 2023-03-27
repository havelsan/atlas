
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BloodBankSubGroup")] 

    /// <summary>
    /// Alt Grup
    /// </summary>
    public  partial class BloodBankSubGroup : EpisodeAction
    {
        public class BloodBankSubGroupList : TTObjectCollection<BloodBankSubGroup> { }
                    
        public class ChildBloodBankSubGroupCollection : TTObject.TTChildObjectCollection<BloodBankSubGroup>
        {
            public ChildBloodBankSubGroupCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBloodBankSubGroupCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid Request { get { return new Guid("cae7da99-e89a-4c82-bb06-18e339158599"); } }
            public static Guid Reject { get { return new Guid("937966db-1585-499d-9c53-390b65136de1"); } }
            public static Guid MakeRequest { get { return new Guid("0c6520b8-e62f-45a2-9281-6fc2d5c03140"); } }
            public static Guid Completed { get { return new Guid("82116d0c-2ec8-48f7-a592-9059547e2a3f"); } }
            public static Guid Approve { get { return new Guid("f73474ef-740c-493b-9117-faa4731b6bc6"); } }
            public static Guid Procedure { get { return new Guid("43696382-f31b-4c43-b868-d0f877661302"); } }
        }

    /// <summary>
    /// Örnek No
    /// </summary>
        public long? SampleId
        {
            get { return (long?)this["SAMPLEID"]; }
            set { this["SAMPLEID"] = value; }
        }

    /// <summary>
    /// Uygun İstem Sayısı
    /// </summary>
        public int? SuitableRequestNumber
        {
            get { return (int?)this["SUITABLEREQUESTNUMBER"]; }
            set { this["SUITABLEREQUESTNUMBER"] = value; }
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
    /// Çalışılan Test Sayısı
    /// </summary>
        public int? WorkingTestNumber
        {
            get { return (int?)this["WORKINGTESTNUMBER"]; }
            set { this["WORKINGTESTNUMBER"] = value; }
        }

    /// <summary>
    /// İsteyen Doktor
    /// </summary>
        public ResUser RequestDoctor
        {
            get { return (ResUser)((ITTObject)this).GetParent("REQUESTDOCTOR"); }
            set { this["REQUESTDOCTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateBloodBankSubGroupTestsCollection()
        {
            _BloodBankSubGroupTests = new BloodBankSubGroupTest.ChildBloodBankSubGroupTestCollection(this, new Guid("ec94e7b0-aed4-4ba7-b09a-8ae76f71a792"));
            ((ITTChildObjectCollection)_BloodBankSubGroupTests).GetChildren();
        }

        protected BloodBankSubGroupTest.ChildBloodBankSubGroupTestCollection _BloodBankSubGroupTests = null;
        public BloodBankSubGroupTest.ChildBloodBankSubGroupTestCollection BloodBankSubGroupTests
        {
            get
            {
                if (_BloodBankSubGroupTests == null)
                    CreateBloodBankSubGroupTestsCollection();
                return _BloodBankSubGroupTests;
            }
        }

        protected BloodBankSubGroup(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BloodBankSubGroup(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BloodBankSubGroup(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BloodBankSubGroup(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BloodBankSubGroup(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BLOODBANKSUBGROUP", dataRow) { }
        protected BloodBankSubGroup(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BLOODBANKSUBGROUP", dataRow, isImported) { }
        public BloodBankSubGroup(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BloodBankSubGroup(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BloodBankSubGroup() : base() { }

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