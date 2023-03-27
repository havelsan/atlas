
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
    /// Bakımevi
    /// </summary>
    public partial class DispensaryRequestForm : EpisodeActionForm
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
#region DispensaryRequestForm_PreScript
    base.PreScript();
            if (this._Dispensary.CurrentStateDefID == Dispensary.States.Request)
            {
                int numberOfLastStayDays = 0;
                string vukaat="";
//                foreach (Episode episode in this._Dispensary.Episode.Patient.Episodes)
//                {
//                    foreach( Dispensary dispensary in episode.Dispensaries)
//                    {
//                        //Geçmişte Kalınan Gün Sayısı bulmak için
//                        //if (dispensary.NumberOfStayDays != null && this._Dispensary!=dispensary)
//                        if (dispensary.StayingDate != null && dispensary.DepartureDate != null && this._Dispensary!=dispensary)
//                        {
//                            TimeSpan ts = dispensary.DepartureDate.Value.Subtract(dispensary.StayingDate.Value);
//                            numberOfLastStayDays = Convert.ToInt32(numberOfLastStayDays) + Convert.ToInt32(ts.Days);
//                            //numberOfLastStayDays = Convert.ToInt16(numberOfLastStayDays) + Convert.ToInt16(dispensary.NumberOfStayDays);
//                        }
//                        //Geçmişteki vukaatlarını bulmak için
//                        if(dispensary.Events != null )
//                        {
//                            if (dispensary.Events != "")
//                            {
//                                vukaat= vukaat + " \n" + dispensary.ActionDate + " tarihli vukuat : " + dispensary.Events;
//                            }
//                        }
//                    }
//                }
                
                if (vukaat != "")
                {
                    if (this._Dispensary.LastEvents != null)
                        this._Dispensary.LastEvents = vukaat;
                    //ShowBox.Show(ShowBoxTypeEnum.Message,"&Tamam","T","Vukuatlar","Vukuatlar",vukaat,0);
                    //MessageBox.Show(this,vukaat, "Vukuatlar",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                if (this._Dispensary.NumberOfLastStayDays== null)
                {
                    this._Dispensary.NumberOfLastStayDays= numberOfLastStayDays;
                }
            }
            else if (this._Dispensary.CurrentStateDefID == Dispensary.States.RequestAcception)
            {
                this.GhaziDiagnosis.ReadOnly = true;
                this.ReasonForStay.ReadOnly = true;
                this.NumberOfStayDays.ReadOnly = true;
                this.IsCompanionNeeded.ReadOnly = true;
            }
#endregion DispensaryRequestForm_PreScript

            }
                }
}