
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
    /// Eczacılık Bilimleri İstek
    /// </summary>
    public partial class MagistralPreparationRequestForm : EpisodeActionForm
    {
    /// <summary>
    /// Eczacılık Bilimleri İstek
    /// </summary>
        protected TTObjectClasses.MagistralPrescription _MagistralPrescription
        {
            get { return (TTObjectClasses.MagistralPrescription)_ttObject; }
        }

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
        protected ITTLabel ttlabel3;
        protected ITTEnumComboBox ttenumcombobox1;
        protected ITTLabel ttlabel8;
        protected ITTLabel ttlabel9;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTGrid TreatmentMaterials;
        protected ITTListBoxColumn MaterialBaseTreatmentMaterial;
        protected ITTTextBoxColumn UseAmountBaseTreatmentMaterial;
        protected ITTTextBoxColumn AmountBaseTreatmentMaterial;
        protected ITTTextBoxColumn Inheld;
        override protected void InitializeControls()
        {
            tttextbox2 = (ITTTextBox)AddControl(new Guid("c213db08-0686-4642-bd26-8d391da12594"));
            tttextbox3 = (ITTTextBox)AddControl(new Guid("17eab5ef-5138-4892-a6d3-e8bbbb831d38"));
            PatientFullName = (ITTTextBox)AddControl(new Guid("a735163a-d38c-461d-ad52-937b97690fbe"));
            tttextbox5 = (ITTTextBox)AddControl(new Guid("4dd76473-22d6-422c-816e-e62c6d669f8f"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("9d7b26f0-6d1a-49e5-90cc-1fd45a985373"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("0895ac88-b51d-4840-84e1-76adc5665a84"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("0fcba7e6-4b31-457b-8976-811e1e750bc2"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("6598f55a-8bac-49b3-8d87-406edfc2e7fa"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("e756f6bc-7586-45f6-9797-c267326a89d1"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("acaa4c94-7e16-4fe5-b8fb-03c43972b80f"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("d87096db-cb60-4fe9-8913-952898123d45"));
            FromResource = (ITTObjectListBox)AddControl(new Guid("32756b0f-d628-4dec-89c1-e0f3575871f6"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("5dbf5090-2872-43f3-a713-d96e943accf7"));
            ttenumcombobox1 = (ITTEnumComboBox)AddControl(new Guid("0503f779-21c8-42b5-b35a-c857d7844d20"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("634913e8-87e7-4ee7-948a-1e82a3a2e00e"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("aa776fb1-5ca1-4130-a10a-3652c8d90052"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("ca78522b-0e1f-4270-a8ce-6c9428ff5ebb"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("c906639e-16ff-4f66-81bb-92c059a8d170"));
            TreatmentMaterials = (ITTGrid)AddControl(new Guid("28cc2350-ba2f-4762-8d15-7672e7a9dbc3"));
            MaterialBaseTreatmentMaterial = (ITTListBoxColumn)AddControl(new Guid("58bb664d-7a14-49ce-a763-dfa2d415cbb2"));
            UseAmountBaseTreatmentMaterial = (ITTTextBoxColumn)AddControl(new Guid("aeffb0b2-cd6a-463d-9041-3198d1fbf222"));
            AmountBaseTreatmentMaterial = (ITTTextBoxColumn)AddControl(new Guid("43f8c3bd-f5ae-430b-94ad-77b655943bea"));
            Inheld = (ITTTextBoxColumn)AddControl(new Guid("1f26d80a-064b-462c-acee-52602d37a039"));
            base.InitializeControls();
        }

        public MagistralPreparationRequestForm() : base("MAGISTRALPRESCRIPTION", "MagistralPreparationRequestForm")
        {
        }

        protected MagistralPreparationRequestForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}