
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
    /// Ambulans İşlemleri
    /// </summary>
    public partial class Ambulans : ActionForm
    {
        override protected void BindControlEvents()
        {
            AmbulancePersonnels.CellValueChanged += new TTGridCellEventDelegate(AmbulancePersonnels_CellValueChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            AmbulancePersonnels.CellValueChanged -= new TTGridCellEventDelegate(AmbulancePersonnels_CellValueChanged);
            base.UnBindControlEvents();
        }

        private void AmbulancePersonnels_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region Ambulans_AmbulancePersonnels_CellValueChanged
   if (this.AmbulancePersonnels.CurrentCell.OwningColumn.DataMember == "PERSONNEL")
            {
                string objectID = this.AmbulancePersonnels.CurrentCell.Value.ToString();
                if(!String.IsNullOrEmpty(objectID))
                {
                    ResUser personel = (ResUser)this._Ambulance.ObjectContext.GetObject(new Guid(objectID),"ResUser");
                    this.AmbulancePersonnels.Rows[rowIndex].Cells["Work"].Value = personel.Work;
                }
            }
#endregion Ambulans_AmbulancePersonnels_CellValueChanged
        }

        protected override void PreScript()
        {
#region Ambulans_PreScript
    base.PreScript();
            if(this._Ambulance.CurrentStateDefID == Ambulance.States.Request)
            {
                if (this._Ambulance.ExitTime == null)
                    this.ExitTime.Text = Common.RecTime().ToString();
                
                if (this._Ambulance.EstimatedReturnTime == null)
                    this.EstimatedReturnTime.Text = Common.RecTime().ToString();
                /*if(this._Ambulance.ReturnTime == null)
                    this.ReturnTime.Text = Common.RecTime().ToString();*/
            }
#endregion Ambulans_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region Ambulans_PostScript
    base.PostScript(transDef);
            
            if(transDef != null)
            {
                if (this.ExitTime.ControlValue == null)
                {
                    string[] hataParamList = new string[] { "'Çıkış Tarih Saati'" };
                    throw new TTUtils.TTException(SystemMessage.GetMessageV3(95, hataParamList));
                    //throw new TTException("'Çıkış Tarih Saati' boş olamaz.");
                }
                if (this.EstimatedReturnTime.ControlValue == null)
                {
                    string[] hataParamList = new string[] { "'Tahmini Dönüş Tarih Saati'" };
                    throw new TTUtils.TTException(SystemMessage.GetMessageV3(95, hataParamList));
                    //throw new TTException("'Tahmini Dönüş Tarih Saati' boş olamaz.");
                }
                if (transDef.ToStateDefID == Ambulance.States.Completed)
                {
                    if (this.ReturnTime.ControlValue == null)
                    {
                        string[] hataParamList = new string[] { "'Dönüş Tarih Saati'" };
                        throw new TTUtils.TTException(SystemMessage.GetMessageV3(95, hataParamList));
                        //throw new TTException("'Dönüş Tarih Saati' boş olamaz.");
                    }
                }
            }
            
            if(this.EstimatedReturnTime.ControlValue != null)
            {
                if (Convert.ToDateTime(this.EstimatedReturnTime.Text) <= Convert.ToDateTime(this.ExitTime.Text))
                {
                    string[] hataParamList = new string[] { "'Tahmini Dönüş Tarih Saati'","'Çıkış Tarih Saati'" };
                    throw new TTUtils.TTException(SystemMessage.GetMessageV3(202, hataParamList));
                    //throw new TTException("'Tahmini Dönüş Tarih Saati', 'Çıkış Tarih Saati' ne eşit veya ondan küçük olamaz.");
                }
            }
            
            if(this.ReturnTime.ControlValue != null)
            {
                if (Convert.ToDateTime(this.ReturnTime.Text) <= Convert.ToDateTime(this.ExitTime.Text))
                {
                    string[] hataParamList = new string[] { "'Dönüş Tarih Saati'", "'Çıkış Tarih Saati'" };
                    throw new TTUtils.TTException(SystemMessage.GetMessageV3(202, hataParamList));
                    //throw new TTException("'Dönüş Tarih Saati', 'Çıkış Tarih Saati' ne eşit veya ondan küçük olamaz.");
                }
            }
            
            if(this._Ambulance.ProtocolNo==null)
            {
                this._Ambulance.ProtocolNo.GetNextValue();
            }
            this._Ambulance.WorkListDate = Convert.ToDateTime(this.EstimatedReturnTime.Text);
#endregion Ambulans_PostScript

            }
                }
}