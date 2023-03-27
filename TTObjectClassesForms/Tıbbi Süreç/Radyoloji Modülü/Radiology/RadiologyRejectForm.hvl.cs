
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
    /// Red
    /// </summary>
    public partial class RadiologyRejectForm : EpisodeActionForm
    {
    /// <summary>
    /// Radyoloji
    /// </summary>
        protected TTObjectClasses.Radiology _Radiology
        {
            get { return (TTObjectClasses.Radiology)_ttObject; }
        }

        protected ITTLabel labelProcessTime;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage2;
        protected ITTGrid ttgrid2;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn Amount;
        protected ITTTextBoxColumn DistributionType;
        protected ITTTextBoxColumn Notes;
        protected ITTTabPage tttabpage1;
        protected ITTGrid GridRadiologyTests;
        protected ITTListBoxColumn ProcedureObject;
        protected ITTEnumComboBoxColumn BodySite;
        protected ITTEnumComboBoxColumn BodyPosition;
        protected ITTTextBoxColumn Description;
        protected ITTTextBox tttextbox3;
        protected ITTTextBox tttextbox1;
        protected ITTTextBox tttextbox2;
        protected ITTLabel ttlabel2;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTLabel ttlabel3;
        protected ITTLabel labelPreInformation;
        protected ITTLabel ttlabel4;
        protected ITTValueListBox ttvaluelistbox1;
        protected ITTLabel ttlabel1;
        protected ITTDateTimePicker ActionDate;
        override protected void InitializeControls()
        {
            labelProcessTime = (ITTLabel)AddControl(new Guid("22bd6e1e-048f-4cec-b148-143d2f477180"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("81fab985-7178-4ccd-aaeb-3123c5646407"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("bfdf3779-3f45-427a-8352-0f8770b56b6d"));
            ttgrid2 = (ITTGrid)AddControl(new Guid("e921ab5a-a9ef-44a8-87f6-b53d7b56db27"));
            Material = (ITTListBoxColumn)AddControl(new Guid("806cf961-f71f-479f-8da8-3032873e3725"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("34eed488-746c-4ebd-a9d6-02b9bbf2c639"));
            DistributionType = (ITTTextBoxColumn)AddControl(new Guid("d4aa9b38-acc6-4359-9036-541d65c2b497"));
            Notes = (ITTTextBoxColumn)AddControl(new Guid("9e19d8bd-7a69-4ff1-aff4-f6b33cddd232"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("102d7c4d-a3c9-4ef8-b086-19af81505d7f"));
            GridRadiologyTests = (ITTGrid)AddControl(new Guid("4fda8d1e-7765-4125-a250-ed629b6268e7"));
            ProcedureObject = (ITTListBoxColumn)AddControl(new Guid("5bd81ace-eb8c-475a-848c-d2cc6c2bc80d"));
            BodySite = (ITTEnumComboBoxColumn)AddControl(new Guid("9db74461-0650-4f2f-a728-eaea97882144"));
            BodyPosition = (ITTEnumComboBoxColumn)AddControl(new Guid("71402710-401c-49f4-b44d-0186cf5ca113"));
            Description = (ITTTextBoxColumn)AddControl(new Guid("42e52b5d-a026-40b5-b0fc-2178ed838a3b"));
            tttextbox3 = (ITTTextBox)AddControl(new Guid("5c54eac7-3a7a-46fb-9225-a9b827276495"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("e8034cde-2eb7-4088-ae50-b8a75e3b6382"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("5d3c0507-f8af-4f72-aa3a-f4b54ae551c3"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("22598784-8d68-41ad-a4ec-4fbb11d9719f"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("7f00be45-cff3-44c9-95ee-9ae0f9d70da3"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("a5a14ca7-ddaf-4843-88fd-a81c08328bde"));
            labelPreInformation = (ITTLabel)AddControl(new Guid("be6383d5-0ee7-408f-ba57-ac44527a969f"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("5443c7f0-aa02-4a05-824a-bc36c4e91fe0"));
            ttvaluelistbox1 = (ITTValueListBox)AddControl(new Guid("5c5b9c5e-5fcd-41c7-91fd-c244e86424a3"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("0e17507f-6bb6-40c1-897b-d7117e46c67e"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("40159236-4eec-47eb-b957-dd2eb8edab1c"));
            base.InitializeControls();
        }

        public RadiologyRejectForm() : base("RADIOLOGY", "RadiologyRejectForm")
        {
        }

        protected RadiologyRejectForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}