
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
    /// Hasta Dosyası
    /// </summary>
    public partial class PatientFolderForm : TTUnboundForm
    {
        protected ITTListView lvwEpisodes;
        protected ITTListView lvwActions;
        protected ITTPanel ttpanel1;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel2;
        protected ITTToolStrip tlbActions;
        override protected void InitializeControls()
        {
            lvwEpisodes = (ITTListView)AddControl(new Guid("3cc8eff8-5114-4769-b39e-147cfef4f2c7"));
            lvwActions = (ITTListView)AddControl(new Guid("1b1b28c5-13cf-4012-858b-505d454e018e"));
            ttpanel1 = (ITTPanel)AddControl(new Guid("166c7a7b-9560-4c75-a540-8d0ccfc7a031"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("8c0218a2-42c3-4684-9020-a0a51f81ee45"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("a3011c5c-d669-457b-9d3c-b8527d5cae99"));
            tlbActions = (ITTToolStrip)AddControl(new Guid("cb61f042-6d1b-41d3-8075-d7b3ceec322c"));
            base.InitializeControls();
        }

        public PatientFolderForm() : base("PatientFolderForm")
        {
        }

        protected PatientFolderForm(string formDefName) : base(formDefName)
        {
        }
    }
}