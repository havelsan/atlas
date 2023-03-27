
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
    /// Fiyat Güncelleme
    /// </summary>
    public partial class PriceUpdatingForm : TTForm
    {
        override protected void BindControlEvents()
        {
            UNSELECTALL.Click += new TTControlEventDelegate(UNSELECTALL_Click);
            SELECTALL.Click += new TTControlEventDelegate(SELECTALL_Click);
            LISTBUTTON.Click += new TTControlEventDelegate(LISTBUTTON_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            UNSELECTALL.Click -= new TTControlEventDelegate(UNSELECTALL_Click);
            SELECTALL.Click -= new TTControlEventDelegate(SELECTALL_Click);
            LISTBUTTON.Click -= new TTControlEventDelegate(LISTBUTTON_Click);
            base.UnBindControlEvents();
        }

        private void UNSELECTALL_Click()
        {
#region PriceUpdatingForm_UNSELECTALL_Click
   if(this._PriceUpdating.CurrentStateDefID == PriceUpdating.States.New)
            {
                foreach(PriceUpdatingSubActionProcedure subActProc in this._PriceUpdating.PriceUpdatingProcedures)
                {
                    subActProc.UpdateProcedurePrice = false ;
                }
                foreach (PriceUpdatingSubActionMaterial subActMats in this._PriceUpdating.PriceUpdatingMaterials)
                {
                    subActMats.UpdateMaterialPrice = false ;
                }
            }
#endregion PriceUpdatingForm_UNSELECTALL_Click
        }

        private void SELECTALL_Click()
        {
#region PriceUpdatingForm_SELECTALL_Click
   if(this._PriceUpdating.CurrentStateDefID == PriceUpdating.States.New)
            {
                foreach(PriceUpdatingSubActionProcedure subActProc in this._PriceUpdating.PriceUpdatingProcedures)
                {
                    subActProc.UpdateProcedurePrice = true ;
                }
                foreach (PriceUpdatingSubActionMaterial subActMats in this._PriceUpdating.PriceUpdatingMaterials)
                {
                    subActMats.UpdateMaterialPrice = true ;
                }
            }
#endregion PriceUpdatingForm_SELECTALL_Click
        }

        private void LISTBUTTON_Click()
        {
#region PriceUpdatingForm_LISTBUTTON_Click
   if(this._PriceUpdating.CurrentStateDefID == PriceUpdating.States.New)
            {
                DateTime sDate ;
                DateTime eDate ;
                if (this._PriceUpdating.StartDate == null || this._PriceUpdating.EndDate == null)
                    TTVisual.InfoBox.Show(SystemMessage.GetMessage(470), MessageIconEnum.ErrorMessage);
                else
                {
                    this._PriceUpdating.PriceUpdatingProcedures.DeleteChildren();
                    this._PriceUpdating.PriceUpdatingMaterials.DeleteChildren();
                    sDate = Convert.ToDateTime(this._PriceUpdating.StartDate.Value.ToString("yyyy-MM-dd 00:00:00")) ;
                    eDate = Convert.ToDateTime(this._PriceUpdating.EndDate.Value.ToString("yyyy-MM-dd 23:59:59")) ;
                    bool isFound = false ;
                    string TempSubActProcObjId = null ;
                    string TempSubActMatObjId = null ;
                    IList accTrxProcsList ;
                    IList accTrxMatsList ;
                    // Hizmetler Listeleniyor
                    if (this._PriceUpdating.ProcedureObject == null)
                        accTrxProcsList = AccountTransaction.GetProcTrxsByDate(_PriceUpdating.ObjectContext,sDate,eDate,AccountTransaction.States.New);
                    else
                        accTrxProcsList = AccountTransaction.GetProcTrxsByDateAndProc(_PriceUpdating.ObjectContext,sDate,eDate,AccountTransaction.States.New,_PriceUpdating.ProcedureObject.ObjectID);
                    
                    foreach (AccountTransaction atx in accTrxProcsList)
                    {
                        if (TempSubActProcObjId != atx.SubActionProcedure.ObjectID.ToString())
                        {
                            PriceUpdatingSubActionProcedure priceUpdatingSubActProcs = new PriceUpdatingSubActionProcedure(_PriceUpdating.ObjectContext);
                            priceUpdatingSubActProcs.SubActionProcedure = atx.SubActionProcedure;
                            priceUpdatingSubActProcs.UpdateProcedurePrice = false;
                            //priceUpdatingSubActProcs.EpisodeProtocol = atx.EpisodeProtocol ;
                            _PriceUpdating.PriceUpdatingProcedures.Add(priceUpdatingSubActProcs);
                            TempSubActProcObjId = atx.SubActionProcedure.ObjectID.ToString();
                        }
                    }
                    
                    // Malzemeler Listeleniyor
                    if(this._PriceUpdating.Material == null)
                        accTrxMatsList = AccountTransaction.GetMatTrxsByDate(_PriceUpdating.ObjectContext,sDate,eDate,AccountTransaction.States.New);
                    else
                        accTrxMatsList = AccountTransaction.GetMatTrxsByDateAndMat(_PriceUpdating.ObjectContext,sDate,eDate,AccountTransaction.States.New,_PriceUpdating.Material.ObjectID);
                    
                    foreach (AccountTransaction at in accTrxMatsList)
                    {
                        if (TempSubActMatObjId != at.SubActionMaterial.ObjectID.ToString())
                        {
                            PriceUpdatingSubActionMaterial priceUpdatingSubActMats = new PriceUpdatingSubActionMaterial(_PriceUpdating.ObjectContext);
                            priceUpdatingSubActMats.SubActionMaterial = at.SubActionMaterial;
                            priceUpdatingSubActMats.UpdateMaterialPrice = false;
                            //priceUpdatingSubActMats.EpisodeProtocol = at.EpisodeProtocol;
                            _PriceUpdating.PriceUpdatingMaterials.Add(priceUpdatingSubActMats);
                            TempSubActMatObjId = at.SubActionMaterial.ObjectID.ToString();
                        }
                        
                    }
                    
                }
                
            }
#endregion PriceUpdatingForm_LISTBUTTON_Click
        }

        protected override void PreScript()
        {
#region PriceUpdatingForm_PreScript
    base.PreScript();
            if(this._PriceUpdating.CurrentStateDefID == PriceUpdating.States.New)
            {
                this.cmdOK.Visible = false;
                this._PriceUpdating.StartDate = DateTime.Now;
                this._PriceUpdating.EndDate = DateTime.Now;
            }
#endregion PriceUpdatingForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region PriceUpdatingForm_PostScript
    base.PostScript(transDef);
            int procedureCount = 0;
            int materialCount = 0;
            string msg = string.Empty;
            
            foreach(PriceUpdatingSubActionProcedure subActProc in this._PriceUpdating.PriceUpdatingProcedures)
            {
                if(subActProc.UpdateProcedurePrice == true)
                    procedureCount ++ ;
            }
            
            foreach(PriceUpdatingSubActionMaterial subActMat in this._PriceUpdating.PriceUpdatingMaterials)
            {
                if(subActMat.UpdateMaterialPrice == true)
                    materialCount ++ ;
            }
            
            if (procedureCount == 0 && materialCount == 0)
                throw new TTException(SystemMessage.GetMessage(469));
            
            msg = procedureCount.ToString() + " tane Hizmet Fiyatı, " + materialCount.ToString() + " tane Malzeme/İlaç Fiyatı Güncellendi.";
            this._PriceUpdating.ResultData = msg;
            TTVisual.InfoBox.Alert(this._PriceUpdating.ResultData, MessageIconEnum.InformationMessage);
#endregion PriceUpdatingForm_PostScript

            }
                }
}