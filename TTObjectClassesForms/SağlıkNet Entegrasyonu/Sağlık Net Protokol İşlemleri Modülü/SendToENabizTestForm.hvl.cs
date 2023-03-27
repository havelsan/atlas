
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
    public partial class SendToENabizTestForm : TTUnboundForm
    {
        protected ITTLabel ttlabel2;
        protected ITTGrid resultGrid;
        protected ITTTextBoxColumn InternalObjectID;
        protected ITTTextBoxColumn InternalObjectDefName;
        protected ITTTextBoxColumn PackageCode;
        protected ITTTextBoxColumn SendXML;
        protected ITTTextBoxColumn ResponceXML;
        protected ITTTextBoxColumn SysTakipNo;
        protected ITTTextBoxColumn Exception;
        protected ITTTextBoxColumn Time;
        protected ITTTextBox packageCount;
        protected ITTLabel ttlabel1;
        protected ITTButton getAndSend;
        protected ITTButton send102;
        protected ITTButton send103;
        protected ITTButton send105;
        protected ITTButton send252;
        protected ITTButton send104;
        protected ITTButton send106;
        protected ITTButton send901;
        protected ITTButton Send_201;
        protected ITTButton testST101;
        override protected void InitializeControls()
        {
            ttlabel2 = (ITTLabel)AddControl(new Guid("fee4cf11-9131-430c-a5f3-83b109deaa74"));
            resultGrid = (ITTGrid)AddControl(new Guid("394d5389-60d6-4e2f-a8cc-a340ec654a10"));
            InternalObjectID = (ITTTextBoxColumn)AddControl(new Guid("ef589e98-83c0-4436-bdea-d5a734cf801b"));
            InternalObjectDefName = (ITTTextBoxColumn)AddControl(new Guid("5edc46eb-f3f3-4377-b340-fbf85298b09f"));
            PackageCode = (ITTTextBoxColumn)AddControl(new Guid("5bbf7fb4-991d-4494-99e0-f3465363515d"));
            SendXML = (ITTTextBoxColumn)AddControl(new Guid("dec47364-3bda-47c1-986f-698ec82b4786"));
            ResponceXML = (ITTTextBoxColumn)AddControl(new Guid("35444957-a799-4018-9296-f9195f5f0c72"));
            SysTakipNo = (ITTTextBoxColumn)AddControl(new Guid("36c38eaa-2d31-4109-8445-e9cb94f53227"));
            Exception = (ITTTextBoxColumn)AddControl(new Guid("a807f54f-23a0-415b-941e-f04916ca39d6"));
            Time = (ITTTextBoxColumn)AddControl(new Guid("261b3d7a-0ae5-4e95-aaab-0027640c2bc8"));
            packageCount = (ITTTextBox)AddControl(new Guid("f42e8601-5532-4ca7-9224-cdc0d597c31c"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("9be55c88-c96e-46c6-91a3-14cc4f355425"));
            getAndSend = (ITTButton)AddControl(new Guid("09a5eb50-aebe-41a8-a4e2-324b5a714565"));
            send102 = (ITTButton)AddControl(new Guid("e3eb1df1-55c2-4722-975a-2e0bae33d357"));
            send103 = (ITTButton)AddControl(new Guid("62855e77-c37f-4619-a9cc-3950b00edbf5"));
            send105 = (ITTButton)AddControl(new Guid("9153ceef-8abb-476d-89ea-d259bb91dc0a"));
            send252 = (ITTButton)AddControl(new Guid("7fb9a3e6-a1f8-457d-8780-fde337e90004"));
            send104 = (ITTButton)AddControl(new Guid("e6ba6cb4-f646-4cdf-91b0-2d39325ad08b"));
            send106 = (ITTButton)AddControl(new Guid("881a0581-2887-4ac4-93ea-8a2fd0eae3aa"));
            send901 = (ITTButton)AddControl(new Guid("fa870ea9-30cf-4aa7-9549-caf8132c1c85"));
            Send_201 = (ITTButton)AddControl(new Guid("46f4cb3c-58d8-4e4a-b531-fe828d7c7576"));
            testST101 = (ITTButton)AddControl(new Guid("9da9455b-9d42-43d7-8847-20ed731aee92"));
            base.InitializeControls();
        }

        public SendToENabizTestForm() : base("SendToENabizTestForm")
        {
        }

        protected SendToENabizTestForm(string formDefName) : base(formDefName)
        {
        }
    }
}