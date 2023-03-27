
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
    /// Tamam
    /// </summary>
    public partial class CompletedForm_Maintenance : MaintenanceBaseForm
    {
    /// <summary>
    /// Bakım
    /// </summary>
        protected TTObjectClasses.Maintenance _Maintenance
        {
            get { return (TTObjectClasses.Maintenance)_ttObject; }
        }

        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTLabel ttlabel1;
        protected ITTDateTimePicker EndDate;
        protected ITTLabel labelStartDate;
        protected ITTObjectListBox ResponsibleResource;
        protected ITTLabel labelRequestNO;
        protected ITTObjectListBox FixedAsset;
        protected ITTLabel labelToResource;
        protected ITTDateTimePicker StartDate;
        protected ITTLabel labelEndDate;
        protected ITTLabel labelDescription;
        protected ITTTextBox Description;
        protected ITTTextBox RequestNO;
        protected ITTObjectListBox ToResource;
        protected ITTLabel labelRequestDate;
        protected ITTDateTimePicker RequestDate;
        protected ITTObjectListBox FromResource;
        protected ITTLabel labelFixedAsset;
        protected ITTLabel labelResponsibleResource;
        protected ITTLabel labelFromResource;
        protected ITTRichTextBoxControl Result;
        protected ITTGrid MaintenanceParameter;
        protected ITTListBoxColumn MaintenanceParameterDefinition;
        protected ITTCheckBoxColumn Check;
        protected ITTLabel ttlabel9;
        override protected void InitializeControls()
        {
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("c871037a-0454-4631-ae46-11f195da5b13"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("92042cb9-e197-4442-9595-0142ce2acb44"));
            EndDate = (ITTDateTimePicker)AddControl(new Guid("38bb07a8-8bd9-43c8-9921-deee7f92405f"));
            labelStartDate = (ITTLabel)AddControl(new Guid("a89d4ee6-69fa-43b0-8cc6-dd4196422e59"));
            ResponsibleResource = (ITTObjectListBox)AddControl(new Guid("188c83d4-cfa6-41b8-ab82-48f12760a73e"));
            labelRequestNO = (ITTLabel)AddControl(new Guid("af2577dc-c60a-4403-8fc1-053f81790fbe"));
            FixedAsset = (ITTObjectListBox)AddControl(new Guid("ca3d6ebb-8f5e-4597-9a49-00c3295bc6ca"));
            labelToResource = (ITTLabel)AddControl(new Guid("dc1cc8e5-3a47-41fe-9776-464ba05d4df4"));
            StartDate = (ITTDateTimePicker)AddControl(new Guid("1ae6b72b-94d8-41c3-beed-9ebbcc34c042"));
            labelEndDate = (ITTLabel)AddControl(new Guid("3a802ec7-1795-49c2-8304-55485d10a138"));
            labelDescription = (ITTLabel)AddControl(new Guid("bdaaafab-e080-4630-a6a9-e89c8dc03317"));
            Description = (ITTTextBox)AddControl(new Guid("4abad676-d097-437b-82f9-4d87735551f1"));
            RequestNO = (ITTTextBox)AddControl(new Guid("290003cc-368e-43e9-abee-754865087f55"));
            ToResource = (ITTObjectListBox)AddControl(new Guid("f5403f9b-bc36-4eeb-a4ec-03966cb66603"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("29e65cf8-ac74-4408-af1e-9c194d18935c"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("6a6ad92f-8f3c-414f-be5e-d7ce48858186"));
            FromResource = (ITTObjectListBox)AddControl(new Guid("7bb911f9-e936-4436-a7b7-30a09dbaef2b"));
            labelFixedAsset = (ITTLabel)AddControl(new Guid("be267574-3e21-466a-a98e-a7fa990afd6a"));
            labelResponsibleResource = (ITTLabel)AddControl(new Guid("44d63d5d-9e87-4830-8bb3-64915562b437"));
            labelFromResource = (ITTLabel)AddControl(new Guid("deec0478-cb3f-441a-a52f-6e1b04978f45"));
            Result = (ITTRichTextBoxControl)AddControl(new Guid("bd95a10b-d93d-4082-8ebc-bde450f6a5fe"));
            MaintenanceParameter = (ITTGrid)AddControl(new Guid("2553488a-88c0-4f83-8f3d-8151238af154"));
            MaintenanceParameterDefinition = (ITTListBoxColumn)AddControl(new Guid("fda97f53-864e-4423-b8fd-018e2d091e27"));
            Check = (ITTCheckBoxColumn)AddControl(new Guid("ebd3083b-d883-4aec-b94e-f16c9b5b5474"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("7e71b24c-f8ea-4203-906b-06c8ddb894b7"));
            base.InitializeControls();
        }

        public CompletedForm_Maintenance() : base("MAINTENANCE", "CompletedForm_Maintenance")
        {
        }

        protected CompletedForm_Maintenance(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}