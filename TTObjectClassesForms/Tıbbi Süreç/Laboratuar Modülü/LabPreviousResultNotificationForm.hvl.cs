
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
    /// Laboratuvar Önceki Sonuçlar Bildirimi
    /// </summary>
    public partial class LabPreviousResultNotificationForm : TTUnboundForm
    {
        protected ITTTextBox tttextbox_ID;
        protected ITTTextBox tttextbox_RequestDate;
        protected ITTTextBox tttextbox_WorkListDate;
        protected ITTTextBox tttextbox_CurrentState;
        protected ITTLabel ttlabel1;
        protected ITTButton ttbutton_Cancel;
        protected ITTButton ttbutton_Proceed;
        protected ITTButton ttbutton_PrintReport;
        protected ITTButton ttbutton_OpenAction;
        protected ITTLabel ttlabel_TestName;
        protected ITTLabel ttlabel_Header;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel_ID;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel_TestHeader;
        override protected void InitializeControls()
        {
            tttextbox_ID = (ITTTextBox)AddControl(new Guid("f38010bb-ccd8-4c37-9057-b332703ad4bf"));
            tttextbox_RequestDate = (ITTTextBox)AddControl(new Guid("c6ae4ff5-c5ac-4fec-ae53-13c8d785ba53"));
            tttextbox_WorkListDate = (ITTTextBox)AddControl(new Guid("880f99cd-081e-4f14-ad37-1b92c250d7fd"));
            tttextbox_CurrentState = (ITTTextBox)AddControl(new Guid("3fb8968c-0c61-4577-88a4-229706b5e9b6"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("b1c92c7c-5589-4fac-9dfb-ccfa326d788e"));
            ttbutton_Cancel = (ITTButton)AddControl(new Guid("8456699b-da59-41ab-944d-92f05a89bb46"));
            ttbutton_Proceed = (ITTButton)AddControl(new Guid("4ea9b230-bbe2-4c19-91b3-21e8144ccc1e"));
            ttbutton_PrintReport = (ITTButton)AddControl(new Guid("6e9e7416-5c40-49db-b8f6-21be68022132"));
            ttbutton_OpenAction = (ITTButton)AddControl(new Guid("6f886fc8-9e74-4b25-92a5-7178277a53c7"));
            ttlabel_TestName = (ITTLabel)AddControl(new Guid("80dbef6a-aa28-44eb-ac5f-5f5392e4f27b"));
            ttlabel_Header = (ITTLabel)AddControl(new Guid("1a6d6876-14b6-4184-8d9a-a5130421620e"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("6c9d0cc0-fa8d-4eae-b943-5ff02b2a57bd"));
            ttlabel_ID = (ITTLabel)AddControl(new Guid("3f9efe71-5314-4588-aed4-1f255e731235"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("57af8158-38de-4360-8c29-667ee13e5f59"));
            ttlabel_TestHeader = (ITTLabel)AddControl(new Guid("93301678-b152-4823-a842-f85a1f1e4c7e"));
            base.InitializeControls();
        }

        public LabPreviousResultNotificationForm() : base("LabPreviousResultNotificationForm")
        {
        }

        protected LabPreviousResultNotificationForm(string formDefName) : base(formDefName)
        {
        }
    }
}