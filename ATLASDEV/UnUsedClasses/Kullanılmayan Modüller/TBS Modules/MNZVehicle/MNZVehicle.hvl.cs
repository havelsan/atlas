
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MNZVehicle")] 

    /// <summary>
    /// Araç
    /// </summary>
    public  partial class MNZVehicle : MNZActor
    {
        public class MNZVehicleList : TTObjectCollection<MNZVehicle> { }
                    
        public class ChildMNZVehicleCollection : TTObject.TTChildObjectCollection<MNZVehicle>
        {
            public ChildMNZVehicleCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMNZVehicleCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Complete { get { return new Guid("d8862a21-2d2f-4c73-88a3-572dcd8fecf1"); } }
    /// <summary>
    /// Yeni Yasaklı Araç
    /// </summary>
            public static Guid New { get { return new Guid("6f41e66b-3804-40f5-bf50-a834f832c8d9"); } }
        }

    /// <summary>
    /// Yasaklımı
    /// </summary>
        public bool? IsForbidden
        {
            get { return (bool?)this["ISFORBIDDEN"]; }
            set { this["ISFORBIDDEN"] = value; }
        }

    /// <summary>
    /// Yasaklanma Günü
    /// </summary>
        public DateTime? BannedDate
        {
            get { return (DateTime?)this["BANNEDDATE"]; }
            set { this["BANNEDDATE"] = value; }
        }

    /// <summary>
    /// PlakaNo
    /// </summary>
        public string LicencePlate
        {
            get { return (string)this["LICENCEPLATE"]; }
            set { this["LICENCEPLATE"] = value; }
        }

    /// <summary>
    /// İstihbarat Bilgileri
    /// </summary>
        public string SecretInformation
        {
            get { return (string)this["SECRETINFORMATION"]; }
            set { this["SECRETINFORMATION"] = value; }
        }

    /// <summary>
    /// Marka
    /// </summary>
        public Mark Mark
        {
            get { return (Mark)((ITTObject)this).GetParent("MARK"); }
            set { this["MARK"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Model
    /// </summary>
        public Model Model
        {
            get { return (Model)((ITTObject)this).GetParent("MODEL"); }
            set { this["MODEL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Araç Sahibi
    /// </summary>
        public MNZPerson Person
        {
            get { return (MNZPerson)((ITTObject)this).GetParent("PERSON"); }
            set { this["PERSON"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Renk
    /// </summary>
        public ColorDefinition Color
        {
            get { return (ColorDefinition)((ITTObject)this).GetParent("COLOR"); }
            set { this["COLOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MNZVehicle(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MNZVehicle(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MNZVehicle(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MNZVehicle(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MNZVehicle(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MNZVEHICLE", dataRow) { }
        protected MNZVehicle(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MNZVEHICLE", dataRow, isImported) { }
        public MNZVehicle(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MNZVehicle(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MNZVehicle() : base() { }

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