
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
    /// İlaç Bilgilerini Güncelleme Görevi
    /// </summary>
    public partial class DrugUpdateFromAuditsTaskForm : ScheduledTaskBaseForm
    {
    /// <summary>
    /// İlaç Fiyat Güncelleme
    /// </summary>
        protected TTObjectClasses.DrugUpdateFromAuditsTask _DrugUpdateFromAuditsTask
        {
            get { return (TTObjectClasses.DrugUpdateFromAuditsTask)_ttObject; }
        }

        protected ITTGrid TaskUsers;
        protected ITTListBoxColumn UserDrugUpdateTaskUser;
        override protected void InitializeControls()
        {
            TaskUsers = (ITTGrid)AddControl(new Guid("deb23520-5356-49d0-bbb6-67600fbde811"));
            UserDrugUpdateTaskUser = (ITTListBoxColumn)AddControl(new Guid("7765ee7a-a3e3-4046-b4cb-72ddd7bd0ba9"));
            base.InitializeControls();
        }

        public DrugUpdateFromAuditsTaskForm() : base("DRUGUPDATEFROMAUDITSTASK", "DrugUpdateFromAuditsTaskForm")
        {
        }

        protected DrugUpdateFromAuditsTaskForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}