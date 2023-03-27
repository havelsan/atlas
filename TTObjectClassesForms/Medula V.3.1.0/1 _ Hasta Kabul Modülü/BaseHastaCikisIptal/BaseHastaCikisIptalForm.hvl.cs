
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
    /// BaseHastaCikisIptalForm
    /// </summary>
    public partial class BaseHastaCikisIptalForm : BaseMedulaActionForm
    {
        protected TTObjectClasses.BaseHastaCikisIptal _BaseHastaCikisIptal
        {
            get { return (TTObjectClasses.BaseHastaCikisIptal)_ttObject; }
        }

        protected ITTLabel labelsaglikTesisKodu;
        protected ITTValueListBox saglikTesisKodu;
        protected ITTLabel labelhastaCikisTarihi;
        protected ITTTextBox hastaCikisTarihi;
        protected ITTTextBox hastaBasvuruNo;
        protected ITTLabel labelhastaBasvuruNo;
        protected ITTDateTimePicker hastaCikisTarihiDateTimePicker;
        override protected void InitializeControls()
        {
            labelsaglikTesisKodu = (ITTLabel)AddControl(new Guid("7016e571-9196-4792-8560-7d87f4de18e5"));
            saglikTesisKodu = (ITTValueListBox)AddControl(new Guid("3bab8ce4-fe79-4c67-ad91-7809a60c86f3"));
            labelhastaCikisTarihi = (ITTLabel)AddControl(new Guid("6f047ec4-e3ed-4784-b42b-c89e12cc3895"));
            hastaCikisTarihi = (ITTTextBox)AddControl(new Guid("1b0e24df-7cec-4cce-ab61-e70406d028bd"));
            hastaBasvuruNo = (ITTTextBox)AddControl(new Guid("c8cafc01-edc5-42b0-8750-7c635b672cad"));
            labelhastaBasvuruNo = (ITTLabel)AddControl(new Guid("17975b59-8a60-47b9-875d-ea2fca0392ba"));
            hastaCikisTarihiDateTimePicker = (ITTDateTimePicker)AddControl(new Guid("d47bdc19-6487-47fa-871f-7806dba1b6dc"));
            base.InitializeControls();
        }

        public BaseHastaCikisIptalForm() : base("BASEHASTACIKISIPTAL", "BaseHastaCikisIptalForm")
        {
        }

        protected BaseHastaCikisIptalForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}