
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="NursingApplicationTemplate")] 

    /// <summary>
    /// Hemşirelik İşlemleri Şablon
    /// </summary>
    public  partial class NursingApplicationTemplate : BaseAction, IWorkListBaseAction
    {
        public class NursingApplicationTemplateList : TTObjectCollection<NursingApplicationTemplate> { }
                    
        public class ChildNursingApplicationTemplateCollection : TTObject.TTChildObjectCollection<NursingApplicationTemplate>
        {
            public ChildNursingApplicationTemplateCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildNursingApplicationTemplateCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Şablon Oluştur
    /// </summary>
            public static Guid Create { get { return new Guid("f2363dd4-ba4e-4262-a3f1-50b4946367aa"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Complated { get { return new Guid("bae0ddc3-f465-4a78-9442-a770af066ac4"); } }
        }

    /// <summary>
    /// Şablon İsmi
    /// </summary>
        public string TemplateName
        {
            get { return (string)this["TEMPLATENAME"]; }
            set { this["TEMPLATENAME"] = value; }
        }

        virtual protected void CreateNursingAppTempDetailsCollection()
        {
            _NursingAppTempDetails = new NursingAppTemplateDet.ChildNursingAppTemplateDetCollection(this, new Guid("28848c07-2457-49a6-a39e-0e13371e89d9"));
            ((ITTChildObjectCollection)_NursingAppTempDetails).GetChildren();
        }

        protected NursingAppTemplateDet.ChildNursingAppTemplateDetCollection _NursingAppTempDetails = null;
        public NursingAppTemplateDet.ChildNursingAppTemplateDetCollection NursingAppTempDetails
        {
            get
            {
                if (_NursingAppTempDetails == null)
                    CreateNursingAppTempDetailsCollection();
                return _NursingAppTempDetails;
            }
        }

        protected NursingApplicationTemplate(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected NursingApplicationTemplate(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected NursingApplicationTemplate(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected NursingApplicationTemplate(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected NursingApplicationTemplate(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "NURSINGAPPLICATIONTEMPLATE", dataRow) { }
        protected NursingApplicationTemplate(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "NURSINGAPPLICATIONTEMPLATE", dataRow, isImported) { }
        public NursingApplicationTemplate(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public NursingApplicationTemplate(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public NursingApplicationTemplate() : base() { }

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