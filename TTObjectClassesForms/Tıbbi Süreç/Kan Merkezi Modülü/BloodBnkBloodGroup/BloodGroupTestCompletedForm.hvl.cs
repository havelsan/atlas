
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
    /// Kan Grubu Testi Tamam
    /// </summary>
    public partial class BloodGroupTestCompleted : EpisodeActionForm
    {
    /// <summary>
    /// Kan Grubu
    /// </summary>
        protected TTObjectClasses.BloodBnkBloodGroup _BloodBnkBloodGroup
        {
            get { return (TTObjectClasses.BloodBnkBloodGroup)_ttObject; }
        }

        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel1;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTGrid ttgrid1;
        protected ITTListBoxColumn Test;
        protected ITTTextBox tttextbox1;
        protected ITTTextBox tttextbox2;
        override protected void InitializeControls()
        {
            ttlabel2 = (ITTLabel)AddControl(new Guid("1b12a9d4-ade9-4d0d-9f3a-2ec210ee2f8d"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("d95a441d-2312-49ff-b288-4ad6164502d5"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("e8fd2fd5-ff06-4676-87ed-93d9c7feab98"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("ecb675fb-cbcd-449f-8f5c-37cee90fc5a7"));
            ttgrid1 = (ITTGrid)AddControl(new Guid("4add2247-4040-4ab5-8cff-e9d7797f6b1d"));
            Test = (ITTListBoxColumn)AddControl(new Guid("5261526e-45a6-4988-a704-0f3ca26917bf"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("4d5b94b1-e163-4cd7-ba65-b1e3e6d8d2d6"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("e6fd5ded-b4c3-4e1a-a47f-e3c91f7a868a"));
            base.InitializeControls();
        }

        public BloodGroupTestCompleted() : base("BLOODBNKBLOODGROUP", "BloodGroupTestCompleted")
        {
        }

        protected BloodGroupTestCompleted(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}