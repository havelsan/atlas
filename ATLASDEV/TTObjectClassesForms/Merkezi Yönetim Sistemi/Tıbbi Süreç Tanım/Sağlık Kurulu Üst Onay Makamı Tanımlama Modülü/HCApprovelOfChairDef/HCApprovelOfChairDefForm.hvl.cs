
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
    /// Sağlık Kurulu Üst Onay Makamı Tanımlama
    /// </summary>
    public partial class HCApprovelOfChairDefForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Sağlık Kurulu Üst Onay Makamı Tanımlama
    /// </summary>
        protected TTObjectClasses.HCApprovelOfChairDef _HCApprovelOfChairDef
        {
            get { return (TTObjectClasses.HCApprovelOfChairDef)_ttObject; }
        }

        protected ITTObjectListBox RESOURCE;
        protected ITTObjectListBox SITE;
        protected ITTTextBox NAME;
        protected ITTTextBox CODE;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel1;
        override protected void InitializeControls()
        {
            RESOURCE = (ITTObjectListBox)AddControl(new Guid("1ad21fbe-165d-4591-bc78-2ec09bf0fb0b"));
            SITE = (ITTObjectListBox)AddControl(new Guid("692edc1a-f7d2-430d-b268-ef7ba90e9bcd"));
            NAME = (ITTTextBox)AddControl(new Guid("13a13f7d-f9ff-44ba-aa71-b1e1ab874c21"));
            CODE = (ITTTextBox)AddControl(new Guid("83f076fc-2861-44f0-bac9-0758239ad5fd"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("e4d187b5-74d3-4fe8-b940-a2a22b2f5291"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("be07ef26-cc18-4eef-bdd6-1619f0cb7c84"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("dc0885a8-6b7b-4ea4-be1f-57c5e6c036be"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("fee72c2a-f8fd-4104-b551-4cb92443e5c1"));
            base.InitializeControls();
        }

        public HCApprovelOfChairDefForm() : base("HCAPPROVELOFCHAIRDEF", "HCApprovelOfChairDefForm")
        {
        }

        protected HCApprovelOfChairDefForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}