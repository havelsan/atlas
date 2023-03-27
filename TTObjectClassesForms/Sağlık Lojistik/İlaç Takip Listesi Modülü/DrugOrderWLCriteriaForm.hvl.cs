
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
    /// Filtre
    /// </summary>
    public partial class DrugOrderWLCriteriaForm : BaseCriteriaForm
    {
        protected ITTTextBox ActionID;
        protected ITTTextBox PatientBox;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel2;
        protected ITTComboBox StatusBox;
        protected ITTLabel lblPatient;
        protected ITTButton SelectButton;
        protected ITTButton ttbutton1;
        override protected void InitializeControls()
        {
            ActionID = (ITTTextBox)AddControl(new Guid("d13435c1-6e61-402c-9b77-a70106fd8312"));
            PatientBox = (ITTTextBox)AddControl(new Guid("a0f0963b-adb2-4f60-bdad-dcb9fe9fba87"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("8293c980-79ee-487b-a9c6-6ba251a31475"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("6cb354f1-d37c-4ea0-9f99-afadc1848892"));
            StatusBox = (ITTComboBox)AddControl(new Guid("6e6f1706-c107-4a0e-add4-6ff739ecd4ad"));
            lblPatient = (ITTLabel)AddControl(new Guid("62f45898-4294-4ac7-a088-2b4eb8bc0350"));
            SelectButton = (ITTButton)AddControl(new Guid("eda55bdc-1e49-4915-84ec-6f0dcd7eca86"));
            ttbutton1 = (ITTButton)AddControl(new Guid("da72c00d-684f-4452-b791-f125f2e302c4"));
            base.InitializeControls();
        }

        public DrugOrderWLCriteriaForm() : base("DrugOrderWLCriteriaForm")
        {
        }

        protected DrugOrderWLCriteriaForm(string formDefName) : base(formDefName)
        {
        }
    }
}