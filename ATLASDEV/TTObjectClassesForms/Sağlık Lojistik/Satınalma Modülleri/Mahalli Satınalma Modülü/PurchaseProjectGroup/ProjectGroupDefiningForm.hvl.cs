
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
    /// Proje Grubu Tanımlama
    /// </summary>
    public partial class ProjectGroupDefiningForm : TTForm
    {
    /// <summary>
    /// Mahalli Satınalmada İhale Tipi "Grup Toplam" İse, İHale Grupları İçin Kullanılan Sınıftır. Her Grup İçin Bir Adet Instance Yaratılır
    /// </summary>
        protected TTObjectClasses.PurchaseProjectGroup _PurchaseProjectGroup
        {
            get { return (TTObjectClasses.PurchaseProjectGroup)_ttObject; }
        }

        protected ITTTextBox GroupName;
        protected ITTLabel labelGroupName;
        override protected void InitializeControls()
        {
            GroupName = (ITTTextBox)AddControl(new Guid("2550965b-6ef8-4f56-9a85-588cd803b083"));
            labelGroupName = (ITTLabel)AddControl(new Guid("4ebead51-f70e-4108-a6ce-a44033d8a927"));
            base.InitializeControls();
        }

        public ProjectGroupDefiningForm() : base("PURCHASEPROJECTGROUP", "ProjectGroupDefiningForm")
        {
        }

        protected ProjectGroupDefiningForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}