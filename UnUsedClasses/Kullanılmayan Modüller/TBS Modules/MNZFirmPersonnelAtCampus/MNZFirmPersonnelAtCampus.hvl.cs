
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MNZFirmPersonnelAtCampus")] 

    public  partial class MNZFirmPersonnelAtCampus : TTObject
    {
        public class MNZFirmPersonnelAtCampusList : TTObjectCollection<MNZFirmPersonnelAtCampus> { }
                    
        public class ChildMNZFirmPersonnelAtCampusCollection : TTObject.TTChildObjectCollection<MNZFirmPersonnelAtCampus>
        {
            public ChildMNZFirmPersonnelAtCampusCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMNZFirmPersonnelAtCampusCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid New { get { return new Guid("4ae8fee6-961a-482f-bd26-2d43768c0bf9"); } }
    /// <summary>
    /// Personel Çıkışı
    /// </summary>
            public static Guid Exit { get { return new Guid("773c077a-a865-4662-b683-745eeec4e4f8"); } }
    /// <summary>
    /// Veriyi Kaydet
    /// </summary>
            public static Guid Finish { get { return new Guid("6397dd1d-e7c0-47b8-9bfd-add7e7c2a040"); } }
        }

    /// <summary>
    /// Plaka No
    /// </summary>
        public string LisencePlate
        {
            get { return (string)this["LISENCEPLATE"]; }
            set { this["LISENCEPLATE"] = value; }
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
    /// Ziyaret Günü
    /// </summary>
        public DateTime? VisitDate
        {
            get { return (DateTime?)this["VISITDATE"]; }
            set { this["VISITDATE"] = value; }
        }

    /// <summary>
    /// Giriş Saati
    /// </summary>
        public DateTime? EntranceTime
        {
            get { return (DateTime?)this["ENTRANCETIME"]; }
            set { this["ENTRANCETIME"] = value; }
        }

    /// <summary>
    /// Firma Personelinin Giriş-Çıkış Saatleri
    /// </summary>
        public MNZFirmPersonnel FirmPersonnel
        {
            get { return (MNZFirmPersonnel)((ITTObject)this).GetParent("FIRMPERSONNEL"); }
            set { this["FIRMPERSONNEL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MNZFirmPersonnelAtCampus(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MNZFirmPersonnelAtCampus(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MNZFirmPersonnelAtCampus(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MNZFirmPersonnelAtCampus(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MNZFirmPersonnelAtCampus(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MNZFIRMPERSONNELATCAMPUS", dataRow) { }
        protected MNZFirmPersonnelAtCampus(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MNZFIRMPERSONNELATCAMPUS", dataRow, isImported) { }
        public MNZFirmPersonnelAtCampus(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MNZFirmPersonnelAtCampus(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MNZFirmPersonnelAtCampus() : base() { }

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