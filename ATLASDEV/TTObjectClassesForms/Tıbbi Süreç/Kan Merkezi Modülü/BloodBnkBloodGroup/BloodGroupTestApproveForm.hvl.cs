
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
    /// Kan Grubu Testi Onay
    /// </summary>
    public partial class BloodGroupTestApprove : EpisodeActionForm
    {
    /// <summary>
    /// Kan Grubu
    /// </summary>
        protected TTObjectClasses.BloodBnkBloodGroup _BloodBnkBloodGroup
        {
            get { return (TTObjectClasses.BloodBnkBloodGroup)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTGrid ttgrid1;
        protected ITTListBoxColumn Test;
        protected ITTGroupBox ttgroupbox1;
        protected ITTLabel ttlabel1;
        protected ITTTextBox tttextbox2;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel3;
        protected ITTDateTimePicker ttdatetimepicker1;
        protected ITTTextBox tttextbox1;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("c197bbe6-6f09-4d84-aae6-193b30e58f48"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("1eca27a2-eb8a-4276-834a-703f8ad089bb"));
            ttgrid1 = (ITTGrid)AddControl(new Guid("23f7229e-82f0-4551-8a10-04f079bc6c3b"));
            Test = (ITTListBoxColumn)AddControl(new Guid("1aa4a0c8-826c-4a93-be28-62e3761b39d8"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("3d6589ef-b084-4e8f-bb80-2601e5c51b00"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("39f20c46-1041-4855-a507-621ec3b3d6f3"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("ba841f9d-d1cc-4cc0-ab47-9d1c8da0b2fb"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("6af3986c-917d-41b9-a4d9-9dfbb6d7082d"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("90bb3735-2f47-4866-acb9-a4e52347262d"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("15dfe51d-df1e-4dcc-9dca-ba8f3c13bd6e"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("48472de0-58c5-4102-866a-07fbdfb427c9"));
            base.InitializeControls();
        }

        public BloodGroupTestApprove() : base("BLOODBNKBLOODGROUP", "BloodGroupTestApprove")
        {
        }

        protected BloodGroupTestApprove(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}