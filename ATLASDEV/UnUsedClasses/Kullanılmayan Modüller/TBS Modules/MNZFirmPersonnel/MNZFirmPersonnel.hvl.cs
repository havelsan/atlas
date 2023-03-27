
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MNZFirmPersonnel")] 

    /// <summary>
    /// Firma Personeli
    /// </summary>
    public  partial class MNZFirmPersonnel : MNZPerson
    {
        public class MNZFirmPersonnelList : TTObjectCollection<MNZFirmPersonnel> { }
                    
        public class ChildMNZFirmPersonnelCollection : TTObject.TTChildObjectCollection<MNZFirmPersonnel>
        {
            public ChildMNZFirmPersonnelCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMNZFirmPersonnelCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Yasaklı
    /// </summary>
            public static Guid Prohobited { get { return new Guid("3d0f0591-437d-4d06-9aa3-163b6e11e746"); } }
    /// <summary>
    /// Yeni Personel Yarat
    /// </summary>
            public static Guid New { get { return new Guid("5efbe1d5-7837-41e5-a19f-5ac9ea0aebdb"); } }
    /// <summary>
    /// İzinli
    /// </summary>
            public static Guid Permitted { get { return new Guid("5d3da12b-0cf7-4601-821b-891697f02887"); } }
        }

        public DateTime? EntranceDate
        {
            get { return (DateTime?)this["ENTRANCEDATE"]; }
            set { this["ENTRANCEDATE"] = value; }
        }

        public DateTime? EntranceTime
        {
            get { return (DateTime?)this["ENTRANCETIME"]; }
            set { this["ENTRANCETIME"] = value; }
        }

    /// <summary>
    /// Ünvanı
    /// </summary>
        public string Title
        {
            get { return (string)this["TITLE"]; }
            set { this["TITLE"] = value; }
        }

    /// <summary>
    /// Çıkış Saati
    /// </summary>
        public DateTime? ExitTime
        {
            get { return (DateTime?)this["EXITTIME"]; }
            set { this["EXITTIME"] = value; }
        }

    /// <summary>
    /// Girş İzni Varmı
    /// </summary>
        public bool? HasAuthorization
        {
            get { return (bool?)this["HASAUTHORIZATION"]; }
            set { this["HASAUTHORIZATION"] = value; }
        }

        public DateTime? ExitDate
        {
            get { return (DateTime?)this["EXITDATE"]; }
            set { this["EXITDATE"] = value; }
        }

    /// <summary>
    /// Plaka Numarası
    /// </summary>
        public string LisencePlate
        {
            get { return (string)this["LISENCEPLATE"]; }
            set { this["LISENCEPLATE"] = value; }
        }

    /// <summary>
    /// Çalıştığı Firma
    /// </summary>
        public MNZFirm Firm
        {
            get { return (MNZFirm)((ITTObject)this).GetParent("FIRM"); }
            set { this["FIRM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Çalıştığı Bölüm
    /// </summary>
        public WorkingUnit WorkingUnit
        {
            get { return (WorkingUnit)((ITTObject)this).GetParent("WORKINGUNIT"); }
            set { this["WORKINGUNIT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreatePersonnelVisitCollection()
        {
            _PersonnelVisit = new MNZPersonnelVisit.ChildMNZPersonnelVisitCollection(this, new Guid("9af83ac1-c43a-4605-a465-d92fabed3cd4"));
            ((ITTChildObjectCollection)_PersonnelVisit).GetChildren();
        }

        protected MNZPersonnelVisit.ChildMNZPersonnelVisitCollection _PersonnelVisit = null;
    /// <summary>
    /// Child collection for Fima Personeli İzin Tarihleri
    /// </summary>
        public MNZPersonnelVisit.ChildMNZPersonnelVisitCollection PersonnelVisit
        {
            get
            {
                if (_PersonnelVisit == null)
                    CreatePersonnelVisitCollection();
                return _PersonnelVisit;
            }
        }

        protected MNZFirmPersonnel(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MNZFirmPersonnel(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MNZFirmPersonnel(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MNZFirmPersonnel(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MNZFirmPersonnel(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MNZFIRMPERSONNEL", dataRow) { }
        protected MNZFirmPersonnel(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MNZFIRMPERSONNEL", dataRow, isImported) { }
        public MNZFirmPersonnel(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MNZFirmPersonnel(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MNZFirmPersonnel() : base() { }

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