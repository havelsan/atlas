
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
    /// Morg İşlemleri
    /// </summary>
    public partial class MorgueDeliveryForm : EpisodeActionForm
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
#region MorgueDeliveryForm_PreScript
    base.PreScript();
//            bool outMorgue= true; 
//            foreach(TTObjectState objectState in _Morgue.GetStateHistory())
//            {
//                if(objectState.StateDefID == Morgue.States.OutRequestAcception)
//                {
//                    externalDoctFixed.Visible= true;
//                    DoctorFixed.Visible= false;
//                    outMorgue= false;
//                    break;
//                }
//                
//            }
//            if(outMorgue)
//            {
//                externalDoctFixed.Visible= false;
//                DoctorFixed.Visible= true;
//            }
            this.DropStateButton(Morgue.States.Cancelled); 
            
            
            
            // this.PatientName.Text = this._Morgue.FullPatientName;
#endregion MorgueDeliveryForm_PreScript

            }
                }
}