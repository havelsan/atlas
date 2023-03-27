
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
    public partial class PostureAnalysisForm : BaseAdditionalInfoForm
    {
    /// <summary>
    /// Postur Analizi
    /// </summary>
        protected TTObjectClasses.PostureAnalysisForm _PostureAnalysisForm
        {
            get { return (TTObjectClasses.PostureAnalysisForm)_ttObject; }
        }

        protected ITTLabel labelLegsLength;
        protected ITTEnumComboBox LegsLength;
        protected ITTLabel labelFeetPosture;
        protected ITTEnumComboBox FeetPosture;
        protected ITTLabel labelLegPosture;
        protected ITTEnumComboBox LegPosture;
        protected ITTLabel labelSpinePosture;
        protected ITTEnumComboBox SpinePosture;
        protected ITTLabel labelScapulaPosture;
        protected ITTEnumComboBox ScapulaPosture;
        protected ITTLabel labelShoulderPosture;
        protected ITTEnumComboBox ShoulderPosture;
        protected ITTLabel labelChestPosture;
        protected ITTEnumComboBox ChestPosture;
        protected ITTLabel labelHeadPosture;
        protected ITTEnumComboBox HeadPosture;
        protected ITTLabel labelCreationDate;
        protected ITTDateTimePicker CreationDate;
        protected ITTLabel labelCode;
        protected ITTTextBox Code;
        override protected void InitializeControls()
        {
            labelLegsLength = (ITTLabel)AddControl(new Guid("bdd340e0-92e3-4947-8b4a-80964dbaea11"));
            LegsLength = (ITTEnumComboBox)AddControl(new Guid("3102cc19-c757-44e7-886b-c47d3e459958"));
            labelFeetPosture = (ITTLabel)AddControl(new Guid("aacc2e6b-b5ec-404d-80c7-c8cda5d0a803"));
            FeetPosture = (ITTEnumComboBox)AddControl(new Guid("b364bbd2-6cb5-4681-ae9a-ed5fc3c3d282"));
            labelLegPosture = (ITTLabel)AddControl(new Guid("52a97be9-9090-46e7-b080-2fa7ced93f47"));
            LegPosture = (ITTEnumComboBox)AddControl(new Guid("8a314b51-6885-4c68-979b-c0475abffb9e"));
            labelSpinePosture = (ITTLabel)AddControl(new Guid("ea56538c-b629-4ba7-8725-73298f9eba04"));
            SpinePosture = (ITTEnumComboBox)AddControl(new Guid("6a4cd666-fddf-4f22-a7fd-b084abe835c6"));
            labelScapulaPosture = (ITTLabel)AddControl(new Guid("d14811eb-3ef8-4b79-bd9e-1d3dd3fad544"));
            ScapulaPosture = (ITTEnumComboBox)AddControl(new Guid("743fcd19-520c-4619-8455-d64bb6cdcd0f"));
            labelShoulderPosture = (ITTLabel)AddControl(new Guid("0a4e6954-b091-4fae-9bf4-0f9344d5efed"));
            ShoulderPosture = (ITTEnumComboBox)AddControl(new Guid("a4844b73-3e9d-4b34-a087-85780cc05d5c"));
            labelChestPosture = (ITTLabel)AddControl(new Guid("2a8625af-199d-4887-9c19-72a9aa139628"));
            ChestPosture = (ITTEnumComboBox)AddControl(new Guid("ef08490c-8e15-40c4-912f-93a8f6be0f32"));
            labelHeadPosture = (ITTLabel)AddControl(new Guid("daab249f-3dc5-496d-b443-880c83796654"));
            HeadPosture = (ITTEnumComboBox)AddControl(new Guid("7cc1887c-45b6-41c5-9bab-451fafa97136"));
            labelCreationDate = (ITTLabel)AddControl(new Guid("555d1055-ad14-44f5-9d71-d3435eb4ffef"));
            CreationDate = (ITTDateTimePicker)AddControl(new Guid("bbdbf326-03b7-4f02-938c-70c73a7e1547"));
            labelCode = (ITTLabel)AddControl(new Guid("4ca57297-2412-4f49-a55b-facda5bd017e"));
            Code = (ITTTextBox)AddControl(new Guid("2b2ca820-5375-4950-b20e-beb2a9c58b47"));
            base.InitializeControls();
        }

        public PostureAnalysisForm() : base("POSTUREANALYSISFORM", "PostureAnalysisForm")
        {
        }

        protected PostureAnalysisForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}