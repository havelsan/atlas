
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ExteriorAmbulance")] 

    /// <summary>
    /// Dış Ambulans Modülü
    /// </summary>
    public  partial class ExteriorAmbulance : BaseAction, IWorkListBaseAction
    {
        public class ExteriorAmbulanceList : TTObjectCollection<ExteriorAmbulance> { }
                    
        public class ChildExteriorAmbulanceCollection : TTObject.TTChildObjectCollection<ExteriorAmbulance>
        {
            public ChildExteriorAmbulanceCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildExteriorAmbulanceCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid AmbulanceEntry { get { return new Guid("f03e5fbb-7caf-489e-b8f3-2b120fd0a1c3"); } }
            public static Guid Completed { get { return new Guid("f180f6d1-e2c2-4717-8e66-a8816db1b824"); } }
        }

    /// <summary>
    /// Ambulansın Plakası
    /// </summary>
        public string AmbulancePlate
        {
            get { return (string)this["AMBULANCEPLATE"]; }
            set { this["AMBULANCEPLATE"] = value; }
        }

    /// <summary>
    /// Ambulansın Adı
    /// </summary>
        public string AmbulanceName
        {
            get { return (string)this["AMBULANCENAME"]; }
            set { this["AMBULANCENAME"] = value; }
        }

    /// <summary>
    /// Geliş Saati
    /// </summary>
        public DateTime? EnteranceTime
        {
            get { return (DateTime?)this["ENTERANCETIME"]; }
            set { this["ENTERANCETIME"] = value; }
        }

    /// <summary>
    /// Ambulans Türü
    /// </summary>
        public AmbulanceTypeEnum? AmbulanceType
        {
            get { return (AmbulanceTypeEnum?)(int?)this["AMBULANCETYPE"]; }
            set { this["AMBULANCETYPE"] = value; }
        }

    /// <summary>
    /// Not
    /// </summary>
        public object Note
        {
            get { return (object)this["NOTE"]; }
            set { this["NOTE"] = value; }
        }

        protected ExteriorAmbulance(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ExteriorAmbulance(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ExteriorAmbulance(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ExteriorAmbulance(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ExteriorAmbulance(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EXTERIORAMBULANCE", dataRow) { }
        protected ExteriorAmbulance(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EXTERIORAMBULANCE", dataRow, isImported) { }
        public ExteriorAmbulance(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ExteriorAmbulance(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ExteriorAmbulance() : base() { }

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