
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
    /// Randevu Bilgileri
    /// </summary>
    public partial class SubactionProcedureAppointmentForm : TTForm
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
#region SubactionProcedureAppointmentForm_PreScript
    int index = 0;
            
            this.tttextboxDescription.Text = string.Empty;
            //TextBox pDescriptionBox = (TextBox)this.pnlControls.Controls["tttextboxDescription"];
            //pDescriptionBox.ScrollBars= ScrollBars.Vertical;
            
            if (this._SubactionProcedureFlowable.GetStateHistory().Count > 1)
            {
                index = this._SubactionProcedureFlowable.GetStateHistory().Count-1;
                if(this._SubactionProcedureFlowable.GetStateHistory()[index].IsUndo == true)
                {
                    this.tttextboxDescription.Text = this.GetFullCompletedAppointmentDescription(this._SubactionProcedureFlowable);
                }
                else
                {
                    this.tttextboxDescription.Text = this.GetFullAppointmentDescription(this._SubactionProcedureFlowable);
                }
            }
            else
            {
                this.tttextboxDescription.Text = this.GetFullAppointmentDescription(this._SubactionProcedureFlowable);
            }
#endregion SubactionProcedureAppointmentForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region SubactionProcedureAppointmentForm_PostScript
    if (transDef != null)
                this.CompleteMyNewAppoinments(this._SubactionProcedureFlowable);
#endregion SubactionProcedureAppointmentForm_PostScript

            }

        public BindingList<Appointment> MyNewAppointments(Guid objectID)
        {

            TTObjectContext objContext = new TTObjectContext(true);
           
                BindingList<Appointment> retList = (BindingList<Appointment>)objContext.QueryObjects<Appointment>("SUBACTIONPROCEDURE = " + ConnectionManager.GuidToString(objectID) + " AND CURRENTSTATEDEFID = " + ConnectionManager.GuidToString(Appointment.States.New), "APPDATE");
                foreach (Appointment app in objContext.LocalQuery("APPOINTMENT", "SUBACTIONPROCEDURE = " + ConnectionManager.GuidToString(objectID) + " AND CURRENTSTATEDEFID = " + ConnectionManager.GuidToString(Appointment.States.New), "APPDATE"))
                    if (retList.Contains(app) == false)
                        retList.Add(app);
                return retList;
            
        }

        public string GetFullAppointmentDescription(SubActionProcedure subactionProcedure)
        {
            StringBuilder builder = new StringBuilder();
            foreach (Appointment app in SubActionProcedure.GetMyNewAppointments(subactionProcedure.ObjectID))
            {
                builder.Append("Açýklama : " + app.Notes + "\r\n");
                if (app.BreakAppointment == true)
                    builder.Append("Zaman  : Saatsiz Randevu \r\n");
                else
                    builder.Append("Zaman  : " + app.AppDate.Value.ToLongDateString() + " " + app.StartTime.Value.ToShortTimeString() + " - " + app.EndTime.Value.ToShortTimeString() + "\r\n");
                if (app.Resource.ObjectDef.Description == null)
                {
                    builder.Append(app.Resource.ObjectDef.Name.ToString() + " : " + app.Resource.Name + "\r\n");
                }
                else
                {
                    builder.Append(app.Resource.ObjectDef.Description.ToString() + " : " + app.Resource.Name + "\r\n");
                }
                builder.Append(app.ObjectDef.Description + " : " + (app.MasterResource != null ? app.MasterResource.Name : "") + "\r\n");
                builder.Append("Durum  : " + app.CurrentStateDef.ToString() + "\r\n");

                TimeSpan dtDiff = app.AppDate.Value.Subtract(DateTime.Now.Date);
                if (dtDiff.TotalDays > -1)// Randevu ayný günde yada ilerdeyse
                {
                    if (dtDiff.TotalDays == 0)//ayný gündeyse
                    {
                        dtDiff = app.StartTime.Value.TimeOfDay.Subtract(DateTime.Now.TimeOfDay);
                        if (dtDiff.TotalMinutes > -1)// ayný günde ilerde ise
                        {
                            if (dtDiff.TotalMinutes < 60)
                                builder.Append("Zamanlama : Randevu " + Math.Round(dtDiff.TotalMinutes) + " dakika sonra.\r\n");
                            else
                                builder.Append("Zamanlama : Randevu " + Math.Round(dtDiff.TotalHours) + " saat sonra.\r\n");
                        }
                        else
                        {
                            //double nDuration = app.EndTime.Value.Subtract(app.StartTime.Value).TotalHours;
                            //if(nDuration < Math.Abs(dtDiff.TotalHours))
                            if (app.EndTime.Value.TimeOfDay.Subtract(DateTime.Now.TimeOfDay).TotalMinutes > 0)
                                builder.Append("Zamanlama : süresi geçiyor\r\n");
                            else
                                builder.Append("Zamanlama : süresi geçmiþ\r\n");
                        }
                    }
                    else
                        builder.Append("Zamanlama : Randevu " + Math.Round(dtDiff.TotalDays) + " gün sonra.\r\n");
                }
                else
                {
                    builder.Append("Zamanlama : süresi geçmiþ\r\n");
                }
                builder.Append("Referans No :" + (app.AppointmentID == null ? "" : (app.AppointmentID.Value == null ? "" : app.AppointmentID.Value.ToString())));
                builder.Append("\r\n");
                builder.Append("\r\n");
            }
            return builder.ToString();
        }

        public string GetFullCompletedAppointmentDescription(SubActionProcedure subactionProcedure)
        {
            StringBuilder builder = new StringBuilder();
            foreach (Appointment app in SubActionProcedure.GetMyCompletedAppointments(subactionProcedure.ObjectID))
            {
                builder.Append("Açýklama : " + app.Notes + "\r\n");
                if (app.BreakAppointment == true)
                    builder.Append("Zaman  : Saatsiz Randevu \r\n");
                else
                    builder.Append("Zaman  : " + app.AppDate.Value.ToLongDateString() + " " + app.StartTime.Value.ToShortTimeString() + " - " + app.EndTime.Value.ToShortTimeString() + "\r\n");
                if (app.Resource.ObjectDef.Description == null)
                {
                    builder.Append(app.Resource.ObjectDef.Name + " :" + app.Resource.Name + "\r\n");
                }
                else
                {
                    builder.Append(app.Resource.ObjectDef.Description + " :" + app.Resource.Name + "\r\n");
                }
                builder.Append(app.ObjectDef.Description + " :" + (app.MasterResource != null ? app.MasterResource.Name : "") + "\r\n");
                builder.Append("Durum  :" + app.CurrentStateDef.ToString() + "\r\n");
                builder.Append("Referans No :" + (app.AppointmentID == null ? "" : (app.AppointmentID.Value == null ? "" : app.AppointmentID.Value.ToString())));
                builder.Append("\r\n");
                builder.Append("\r\n");
            }

            foreach (Appointment app in SubActionProcedure.GetMyCancelledAppointments(subactionProcedure.ObjectID))
            {
                builder.Append("Açýklama : " + app.Notes + "\r\n");
                if (app.BreakAppointment == true)
                    builder.Append("Zaman  : Saatsiz Randevu \r\n");
                else
                    builder.Append("Zaman  : " + app.AppDate.Value.ToLongDateString() + " " + app.StartTime.Value.ToShortTimeString() + " - " + app.EndTime.Value.ToShortTimeString() + "\r\n");
                if (app.Resource.ObjectDef.Description == null)
                {
                    builder.Append(app.Resource.ObjectDef.Name + " :" + app.Resource.Name + "\r\n");
                }
                else
                {
                    builder.Append(app.Resource.ObjectDef.Description + " :" + app.Resource.Name + "\r\n");
                }
                builder.Append(app.ObjectDef.Description + " :" + (app.MasterResource != null ? app.MasterResource.Name : "") + "\r\n");
                builder.Append("Durum  :" + app.CurrentStateDef.ToString() + "\r\n");
                builder.Append("Referans No :" + (app.AppointmentID == null ? "" : (app.AppointmentID.Value == null ? "" : app.AppointmentID.Value.ToString())) + "\r\n");
                builder.Append("Ýptal Sebebi :" + subactionProcedure.ReasonOfCancel);
                builder.Append("\r\n");
                builder.Append("\r\n");
            }
            return builder.ToString();
        }

        public void CompleteMyNewAppoinments(SubActionProcedure subactionProcedure)
        {
            foreach (Appointment app in this.MyNewAppointments(subactionProcedure.ObjectID))
            {
                app.CurrentStateDefID = Appointment.States.Completed;
            }
        }


    }
}