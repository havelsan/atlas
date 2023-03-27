
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
    /// Kan Grubu Testi İstek
    /// </summary>
    public partial class BloodGroupTestRequest : EpisodeActionForm
    {
    /// <summary>
    /// Kan Grubu
    /// </summary>
        protected TTObjectClasses.BloodBnkBloodGroup _BloodBnkBloodGroup
        {
            get { return (TTObjectClasses.BloodBnkBloodGroup)_ttObject; }
        }

        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTLabel ttlabel2;
        protected ITTTextBox tttextbox1;
        protected ITTLabel ttlabel1;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTGrid ttgrid1;
        protected ITTListBoxColumn Urun;
        override protected void InitializeControls()
        {
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("875a0bde-aea5-4956-8e87-83f7b868cb8a"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("782fbb58-0bdc-4e01-b27d-f46c5806e991"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("23e9a48f-84c7-44ce-8402-5ae3e2515dcf"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("3dd72896-f749-4c65-9b52-8f022d42ed8b"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("8dfe345e-cefc-4135-906b-521fd37771f3"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("6c19faf6-2b83-4d9e-9487-1a61e0a578f7"));
            ttgrid1 = (ITTGrid)AddControl(new Guid("17cd377f-9e9a-4c83-a5c4-17e6146f6d39"));
            Urun = (ITTListBoxColumn)AddControl(new Guid("7c315623-ef19-47c4-8edc-60a03129702c"));
            base.InitializeControls();
        }

        public BloodGroupTestRequest() : base("BLOODBNKBLOODGROUP", "BloodGroupTestRequest")
        {
        }

        protected BloodGroupTestRequest(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}