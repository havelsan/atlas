
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
    /// Eczacılık Birimleri İstek
    /// </summary>
    public partial class MagistralPreparationPrescriptionForm : EpisodeActionForm
    {
    /// <summary>
    /// Eczacılık Bilimleri İstek
    /// </summary>
        protected TTObjectClasses.MagistralPrescription _MagistralPrescription
        {
            get { return (TTObjectClasses.MagistralPrescription)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTGrid TreatmentMaterials;
        protected ITTListBoxColumn MaterialBaseTreatmentMaterial;
        protected ITTTextBoxColumn AmountBaseTreatmentMaterial;
        protected ITTTextBox tttextbox2;
        protected ITTTextBox tttextbox3;
        protected ITTTextBox PatientFullName;
        protected ITTTextBox tttextbox5;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTLabel ttlabel1;
        protected ITTDateTimePicker ttdatetimepicker1;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel5;
        protected ITTLabel ttlabel6;
        protected ITTObjectListBox FromResource;
        protected ITTLabel labelMasterResource;
        protected ITTEnumComboBox ttenumcombobox1;
        protected ITTLabel ttlabel8;
        protected ITTLabel ttlabel9;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("8bc91f10-c280-4082-9e18-59b60b2c3463"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("abd5b94b-65d5-40bb-bc98-11ba518b1b81"));
            TreatmentMaterials = (ITTGrid)AddControl(new Guid("07d5b618-00a4-4524-96c3-7414a4ab407c"));
            MaterialBaseTreatmentMaterial = (ITTListBoxColumn)AddControl(new Guid("e47fc8d1-6654-48b7-b1a5-1d318a5f37ae"));
            AmountBaseTreatmentMaterial = (ITTTextBoxColumn)AddControl(new Guid("d37e7ac5-7799-4f2a-9a7e-5ce5291bbdf7"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("bce2958e-720e-4224-b08d-4bcf75b0c834"));
            tttextbox3 = (ITTTextBox)AddControl(new Guid("85324fff-5ac7-4024-854c-95145571e87f"));
            PatientFullName = (ITTTextBox)AddControl(new Guid("aef90f1b-ba1e-495b-9731-9d8f9896151b"));
            tttextbox5 = (ITTTextBox)AddControl(new Guid("0fd24bb5-16de-4977-90d7-ce3aa303b8e5"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("65154ed9-831a-402d-91c3-fad7abb67ee5"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("e70a9039-6eb6-4850-b4d9-80d1a2bf646e"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("59c20ae4-8c1a-48bc-be97-ce11338851b9"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("f60a2ae2-1b3b-4bbf-a8f1-38ef5b596a6f"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("7d848785-9b4c-4ab6-993d-f188dd60fa6f"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("b155a281-9103-466e-afbd-c95e51089a94"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("cbe6ca5d-470b-4da3-92ea-b6b3b015ee29"));
            FromResource = (ITTObjectListBox)AddControl(new Guid("c60aae86-0c8a-40c3-a6b5-719c5928afbc"));
            labelMasterResource = (ITTLabel)AddControl(new Guid("75af0ae4-e250-4651-a6e3-8adf49c97eef"));
            ttenumcombobox1 = (ITTEnumComboBox)AddControl(new Guid("3b1aace2-8d3e-45e3-ae1c-4d024951d0a2"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("c6872e35-c937-40aa-af53-738f111ccc76"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("e8d26acc-53d5-40aa-9819-fe04aee3afd1"));
            base.InitializeControls();
        }

        public MagistralPreparationPrescriptionForm() : base("MAGISTRALPRESCRIPTION", "MagistralPreparationPrescriptionForm")
        {
        }

        protected MagistralPreparationPrescriptionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}