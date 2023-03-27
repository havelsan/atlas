
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

using SmartCardWrapper;

using TTStorageManager;
using System.Runtime.Versioning;
using System.Windows.Forms;
using TTVisual;
namespace TTFormClasses
{
    /// <summary>
    /// MPI
    /// </summary>
    public partial class MPI : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            Button.Click += new TTControlEventDelegate(Button_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            Button.Click -= new TTControlEventDelegate(Button_Click);
            base.UnBindControlEvents();
        }

        private void Button_Click()
        {
#region MPI_Button_Click
   List<Patient> retval = new List<Patient>();
            System.Diagnostics.Debugger.Break();
            //retval = Patient.RemoteMethods.PatientSearch(Sites.SiteMerkezSagKom,"1","2","3","4",SexEnum.Female, Convert.ToDouble(this.UniqueRefNo.Text.ToString())  ,Convert.ToDouble("22"),Common.RecTime()  )     ;
            //foreach (Patient p in retval)
            //{
            //    MessageBox.Show(p.Name.ToString() );
            //}
#endregion MPI_Button_Click
        }
    }
}