
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AppointmentWithoutResource")] 

    /// <summary>
    /// Sadece Zamanı Geldiğinde İşlemin İş Listesine Gelmesi İçin Kullanılan Kaynağa Verilmeyen Randevu
    /// </summary>
    public  partial class AppointmentWithoutResource : TTObject
    {
        public class AppointmentWithoutResourceList : TTObjectCollection<AppointmentWithoutResource> { }
                    
        public class ChildAppointmentWithoutResourceCollection : TTObject.TTChildObjectCollection<AppointmentWithoutResource>
        {
            public ChildAppointmentWithoutResourceCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAppointmentWithoutResourceCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid Cancelled { get { return new Guid("ae3f8d20-2dae-4519-8549-328e41c62c6e"); } }
            public static Guid New { get { return new Guid("c65ee03d-a24b-401e-9818-af5351a3eeab"); } }
            public static Guid Completed { get { return new Guid("276362e3-cd32-4660-b81b-ea106d2d82ec"); } }
        }

        public DateTime? AppDateTime
        {
            get { return (DateTime?)this["APPDATETIME"]; }
            set { this["APPDATETIME"] = value; }
        }

        public BaseAction Action
        {
            get { return (BaseAction)((ITTObject)this).GetParent("ACTION"); }
            set { this["ACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SubActionProcedure SubActionProcedure
        {
            get { return (SubActionProcedure)((ITTObject)this).GetParent("SUBACTIONPROCEDURE"); }
            set { this["SUBACTIONPROCEDURE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected AppointmentWithoutResource(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AppointmentWithoutResource(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AppointmentWithoutResource(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AppointmentWithoutResource(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AppointmentWithoutResource(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "APPOINTMENTWITHOUTRESOURCE", dataRow) { }
        protected AppointmentWithoutResource(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "APPOINTMENTWITHOUTRESOURCE", dataRow, isImported) { }
        public AppointmentWithoutResource(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AppointmentWithoutResource(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AppointmentWithoutResource() : base() { }

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