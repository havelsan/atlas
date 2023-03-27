
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
    /// İlaç Fiyat Güncelleme
    /// </summary>
    public partial class MedulaIlacAraTaskForm : ScheduledTaskBaseForm
    {
    /// <summary>
    /// Medula İlaç Fiyat Güncelleme
    /// </summary>
        protected TTObjectClasses.MedulaIlacAraTask _MedulaIlacAraTask
        {
            get { return (TTObjectClasses.MedulaIlacAraTask)_ttObject; }
        }

        protected ITTGrid MedulaIlacAraTaskUsers;
        protected ITTListBoxColumn UserMedulaIlacAraTaskUser;
        protected ITTListBoxColumn MedulaIlacAraTaskMedulaIlacAraTaskUser;
        override protected void InitializeControls()
        {
            MedulaIlacAraTaskUsers = (ITTGrid)AddControl(new Guid("abff2204-d69b-4157-9506-ff32e745fac3"));
            UserMedulaIlacAraTaskUser = (ITTListBoxColumn)AddControl(new Guid("eaf17ab3-a44b-4acc-87cf-0f4c86791ef4"));
            MedulaIlacAraTaskMedulaIlacAraTaskUser = (ITTListBoxColumn)AddControl(new Guid("95b3abbd-85a1-43b1-9495-be9b74e88a4e"));
            base.InitializeControls();
        }

        public MedulaIlacAraTaskForm() : base("MEDULAILACARATASK", "MedulaIlacAraTaskForm")
        {
        }

        protected MedulaIlacAraTaskForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}