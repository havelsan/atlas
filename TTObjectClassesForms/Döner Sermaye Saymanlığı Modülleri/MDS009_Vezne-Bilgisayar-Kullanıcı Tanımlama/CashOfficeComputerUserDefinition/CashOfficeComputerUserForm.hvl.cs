
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
    /// Vezne / Fatura Servisi Bilgisayar Kullanıcı Tanımı
    /// </summary>
    public partial class CashOfficeComputerUserForm : TTDefinitionForm
    {
    /// <summary>
    /// Sayman Mutemetliği / Vezne / Fatura Servisi Bilgisayar Kullanıcı Tanımı
    /// </summary>
        protected TTObjectClasses.CashOfficeComputerUserDefinition _CashOfficeComputerUserDefinition
        {
            get { return (TTObjectClasses.CashOfficeComputerUserDefinition)_ttObject; }
        }

        protected ITTCheckBox cbxUserActive;
        protected ITTMaskedTextBox COMPUTERNAME;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel2;
        protected ITTObjectListBox CASHOFFICENAME;
        protected ITTObjectListBox USERNAME;
        override protected void InitializeControls()
        {
            cbxUserActive = (ITTCheckBox)AddControl(new Guid("9ce744bd-ba92-4cc6-986f-8be2920c60d1"));
            COMPUTERNAME = (ITTMaskedTextBox)AddControl(new Guid("07de8c4f-4def-411e-a5ea-85afa33db6cd"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("826b01ad-4027-48e9-8bc6-2f19693070de"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("6d9497ff-bbda-47b9-8aba-44322af2633e"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("207accbf-4d54-470f-a609-44d0e9f1b231"));
            CASHOFFICENAME = (ITTObjectListBox)AddControl(new Guid("b1c80dbc-e773-4258-a233-4ff9765805e4"));
            USERNAME = (ITTObjectListBox)AddControl(new Guid("bc94855c-4165-4498-a587-886dc2050840"));
            base.InitializeControls();
        }

        public CashOfficeComputerUserForm() : base("CASHOFFICECOMPUTERUSERDEFINITION", "CashOfficeComputerUserForm")
        {
        }

        protected CashOfficeComputerUserForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}