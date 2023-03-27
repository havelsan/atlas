
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
    /// yeni ziyaretçi giriş formu
    /// </summary>
    public partial class NewVisitorEntryForm : TTForm
    {
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
        }

        protected override void PreScript()
        {
#region NewVisitorEntryForm_PreScript
    Guid? currentState;
            
            currentState = this._MNZVisitor.getCurrentState();
            if(!currentState.HasValue)
                 throw new TTException("State bulunamadı.");
            if(currentState.Value.Equals(MNZVisitor.States.New))
            {
                this.ExitTime.Enabled = false;
            }
            else if(currentState.Value.Equals(MNZVisitor.States.Exit))
            {
                this.ExitTime.Enabled = true;
                this.Name.Enabled =  false;
                this.Surname.Enabled = false;
                this.NationalIdentity.Enabled = false;
                this.FatherName.Enabled = false;
                this.MotherName.Enabled = false;
                this.LisencePlate.Enabled = false;
                this.HomePhone.Enabled = false;
                this.CellPhone.Enabled = false;
                this.BirthDate.Enabled = false;
                this.Description.Enabled = false;
                this.VisitDate.Enabled = false;
                this.VisitTime.Enabled = false;
                this.VisitorType.Enabled = false;
                this.VisitReason.Enabled = false;
                this.Patient.Enabled = false;
            }
#endregion NewVisitorEntryForm_PreScript

            }
                }
}