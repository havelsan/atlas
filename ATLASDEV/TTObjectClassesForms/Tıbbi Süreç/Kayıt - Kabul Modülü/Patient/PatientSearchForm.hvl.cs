
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
    /// Hasta Arama Formu
    /// </summary>
    public partial class PatientSearchForm : TTListForm
    {
        protected ITTLabel labelNoPatientFound;
        protected ITTPanel ttpanel1;
        protected ITTTextBox txtID;
        protected ITTTextBox txtPatientSurname;
        protected ITTLabel lblPatientName;
        protected ITTTextBox txtPatientName;
        protected ITTTextBox txtUniqueRefNo;
        protected ITTLabel lblPatientSurname;
        protected ITTLabel labelUniqueRefNo;
        protected ITTLabel labelID;
        protected ITTPanel pnlError;
        protected ITTPanel pnlDetails;
        protected ITTObjectListBox TownOfBirth;
        protected ITTCheckBox Foreign;
        protected ITTLabel ttlabel3;
        protected ITTLabel lblYuPassNo;
        protected ITTLabel ttlabel2;
        protected ITTTextBox txtYuPassNo;
        protected ITTLabel labelFatherName;
        protected ITTTextBox ForeignUniqueNo;
        protected ITTCheckBox UnIdentified;
        protected ITTLabel ttlabel1;
        protected ITTTextBox txtFatherName;
        protected ITTLabel lblCinsiyet;
        protected ITTObjectListBox CityOfBirth;
        protected ITTLabel ttlabel13;
        protected ITTDateTimePicker dateBirthDate;
        protected ITTEnumComboBox cbCinsiyet;
        protected ITTObjectListBox CountryOfBirth;
        protected ITTLabel labelBirthDate;
        protected ITTTextBox txtMotherName;
        protected ITTLabel labelMotherName;
        override protected void InitializeControls()
        {
            labelNoPatientFound = (ITTLabel)AddControl(new Guid("c495e910-6aa1-44f2-b5e9-ddb6e64a7df4"));
            ttpanel1 = (ITTPanel)AddControl(new Guid("f69111b3-5e6a-4a54-8645-1282d49caee5"));
            txtID = (ITTTextBox)AddControl(new Guid("249ee5ac-c9be-444e-9ae0-c5c9f89a1927"));
            txtPatientSurname = (ITTTextBox)AddControl(new Guid("54cc6996-5867-4631-a368-be263d2b2767"));
            lblPatientName = (ITTLabel)AddControl(new Guid("83c9797b-a0c8-4cea-95c8-c7f7c28f070e"));
            txtPatientName = (ITTTextBox)AddControl(new Guid("3ea59f55-2f57-4dfd-8027-18bc6288286a"));
            txtUniqueRefNo = (ITTTextBox)AddControl(new Guid("dfd0d9f6-4d43-413e-93d3-3fe6efd20a53"));
            lblPatientSurname = (ITTLabel)AddControl(new Guid("67b18d2b-ab5f-44ab-8df2-dc5e2d96d26c"));
            labelUniqueRefNo = (ITTLabel)AddControl(new Guid("6d348fab-3508-4c0f-9e7a-ce35f9b02fbc"));
            labelID = (ITTLabel)AddControl(new Guid("71247e02-18c7-4ea1-b885-da444657f69c"));
            pnlError = (ITTPanel)AddControl(new Guid("b9c1760a-1f60-4739-a0fc-981b26036ae3"));
            pnlDetails = (ITTPanel)AddControl(new Guid("347b31fe-aa99-43bc-acac-fc18bf947c7f"));
            TownOfBirth = (ITTObjectListBox)AddControl(new Guid("8ad66315-228f-48c5-8bd6-de19f9b53ddc"));
            Foreign = (ITTCheckBox)AddControl(new Guid("5f999960-aeef-4751-9b68-4c03fc2b2ed2"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("55ca0c71-05cb-47e1-9d09-dca5ca87cda3"));
            lblYuPassNo = (ITTLabel)AddControl(new Guid("9c948e79-8895-4dc1-8b62-da549d37bb1c"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("2f8bb83b-d355-428a-b577-6aa59326f762"));
            txtYuPassNo = (ITTTextBox)AddControl(new Guid("98d5d124-8f9c-42e0-82ba-3bda10dc8333"));
            labelFatherName = (ITTLabel)AddControl(new Guid("f76135ef-8681-47f3-9bb2-6fe28eaac435"));
            ForeignUniqueNo = (ITTTextBox)AddControl(new Guid("271156a5-524c-449e-8c74-5f56ddc3e993"));
            UnIdentified = (ITTCheckBox)AddControl(new Guid("16fd16a1-f030-4d2a-8788-7ce1c4706885"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("529d388a-b9d0-4812-b67f-d736c4710a6a"));
            txtFatherName = (ITTTextBox)AddControl(new Guid("3e349915-703e-4ece-9f37-6382ba9f1c4d"));
            lblCinsiyet = (ITTLabel)AddControl(new Guid("5574ecf2-df25-4c13-bd44-ef5c59eca259"));
            CityOfBirth = (ITTObjectListBox)AddControl(new Guid("38409710-3f34-46b0-855e-ce55b3084dd8"));
            ttlabel13 = (ITTLabel)AddControl(new Guid("b985bb8e-75a6-42e8-8358-e59121a31130"));
            dateBirthDate = (ITTDateTimePicker)AddControl(new Guid("7ea02575-9260-4bed-8adf-b3b250ae3ab3"));
            cbCinsiyet = (ITTEnumComboBox)AddControl(new Guid("25d139c1-e1b8-41b6-b6c9-20dec98a0891"));
            CountryOfBirth = (ITTObjectListBox)AddControl(new Guid("f24d3f33-5a9f-46e1-8115-f706be276857"));
            labelBirthDate = (ITTLabel)AddControl(new Guid("152ed1b0-2f47-4d95-bba8-7d6b12eee32a"));
            txtMotherName = (ITTTextBox)AddControl(new Guid("4b76a38b-9860-4f2a-97e2-81d64fcca0c3"));
            labelMotherName = (ITTLabel)AddControl(new Guid("6875e52b-f7b6-4a82-9d48-00f29a6845b1"));
            base.InitializeControls();
        }

        public PatientSearchForm(TTList ttList) : base(ttList, "PATIENT", "PatientSearchForm")
        {
        }
    }
}