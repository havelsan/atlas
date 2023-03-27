
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
using System.Windows.Forms;
using TTVisual;
namespace TTFormClasses
{
    /// <summary>
    /// Resim Şablon Tanımı
    /// </summary>
    public partial class IMGTemplateForm : TTForm
    {
        protected TTObjectClasses.IMGTemplate _IMGTemplate
        {
            get { return (TTObjectClasses.IMGTemplate)_ttObject; }
        }

        protected ITTPictureBoxControl IMGContent;
        protected ITTObjectListBox TemplateGroup;
        protected ITTLabel labelRTFTemplateGroup;
        protected ITTLabel labelDescription;
        protected ITTTextBox Description;
        protected ITTLabel labelMenuCaption;
        protected ITTTextBox MenuCaption;
        override protected void InitializeControls()
        {
            IMGContent = (ITTPictureBoxControl)AddControl(new Guid("cd1d8941-4e15-4ea8-ab07-7e69eafb9b2d"));
            TemplateGroup = (ITTObjectListBox)AddControl(new Guid("4c9f34f0-2234-4279-a908-a0f064eaf666"));
            labelRTFTemplateGroup = (ITTLabel)AddControl(new Guid("ed1b16df-f373-47c7-90a9-aee27ddc2cf5"));
            labelDescription = (ITTLabel)AddControl(new Guid("9359275b-77c2-4e7b-946a-47fc99f225d2"));
            Description = (ITTTextBox)AddControl(new Guid("f224d681-efc1-420b-ab39-abec1c2c1860"));
            labelMenuCaption = (ITTLabel)AddControl(new Guid("3348d05f-305e-40a9-9f54-3f8903e08032"));
            MenuCaption = (ITTTextBox)AddControl(new Guid("45ce9ba1-bf13-4e1e-9306-d6d3d871c9fe"));
            base.InitializeControls();
        }

        public IMGTemplateForm() : base("IMGTEMPLATE", "IMGTemplateForm")
        {
        }

        protected IMGTemplateForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}