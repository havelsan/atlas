
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
    /// Yeni Tabela Formu
    /// </summary>
    public partial class NewBoardForm : TTForm
    {
    /// <summary>
    /// MLR003_Tabela
    /// </summary>
        protected TTObjectClasses.MLRBoard _MLRBoard
        {
            get { return (TTObjectClasses.MLRBoard)_ttObject; }
        }

        protected ITTLabel ttlabel3;
        protected ITTListDefComboBox ttlistdefcombobox4;
        protected ITTListDefComboBox ttlistdefcombobox3;
        protected ITTLabel ttlabel7;
        protected ITTListDefComboBox ttlistdefcombobox2;
        protected ITTLabel ttlabel4;
        protected ITTGroupBox ttgroupbox1;
        protected ITTGrid ttgrid1;
        protected ITTLabel ttlabel6;
        protected ITTDateTimePicker ttdatetimepicker2;
        protected ITTListDefComboBox ttlistdefcombobox1;
        protected ITTLabel ttlabel1;
        protected ITTDateTimePicker ttdatetimepicker1;
        protected ITTLabel ttlabel2;
        override protected void InitializeControls()
        {
            ttlabel3 = (ITTLabel)AddControl(new Guid("585f8220-a2e0-49cb-8af2-09134658f851"));
            ttlistdefcombobox4 = (ITTListDefComboBox)AddControl(new Guid("35159703-effb-47c5-aac1-2c2a697fb9a4"));
            ttlistdefcombobox3 = (ITTListDefComboBox)AddControl(new Guid("ea58328a-d045-44b4-a5cb-2b480d7d56f2"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("86bf4b4b-27e2-4259-ac91-44ef493082c5"));
            ttlistdefcombobox2 = (ITTListDefComboBox)AddControl(new Guid("e8bce85d-c4ac-44f5-b73f-3baf0a044671"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("6b7a472d-e583-4ecf-98c2-7551a5f97ad5"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("3a901bb2-887d-409d-857e-5643b451afea"));
            ttgrid1 = (ITTGrid)AddControl(new Guid("942e43ca-b30b-4b41-8f3a-6f78d9246799"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("8593c7be-d169-4be9-939d-7dd994743b76"));
            ttdatetimepicker2 = (ITTDateTimePicker)AddControl(new Guid("1f0f6dc1-abbc-4b33-82be-b853e16c50f3"));
            ttlistdefcombobox1 = (ITTListDefComboBox)AddControl(new Guid("c4f6b3c8-0ed1-44ba-8941-b556b8bbe6b9"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("129104a5-2f89-4801-aaa1-9fe949f1391a"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("44da8443-b092-46cc-b869-de195918a394"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("f0621caf-143a-449e-9677-bd7f97441883"));
            base.InitializeControls();
        }

        public NewBoardForm() : base("MLRBOARD", "NewBoardForm")
        {
        }

        protected NewBoardForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}