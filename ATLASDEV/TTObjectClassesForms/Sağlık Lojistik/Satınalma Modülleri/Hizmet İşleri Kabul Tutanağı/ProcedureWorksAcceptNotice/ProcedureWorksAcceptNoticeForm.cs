
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
    /// Hizmet İşleri Kabul Tutanağı
    /// </summary>
    public partial class ProcedureWorksAcceptNoticeForm : TTForm
    {
        override protected void BindControlEvents()
        {
            txtProjectNo.TextChanged += new TTControlEventDelegate(txtProjectNo_TextChanged);
            txtConfirmNo.TextChanged += new TTControlEventDelegate(txtConfirmNo_TextChanged);
            ContractsGrid.CellContentClick += new TTGridCellEventDelegate(ContractsGrid_CellContentClick);
            cmdFind.Click += new TTControlEventDelegate(cmdFind_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            txtProjectNo.TextChanged -= new TTControlEventDelegate(txtProjectNo_TextChanged);
            txtConfirmNo.TextChanged -= new TTControlEventDelegate(txtConfirmNo_TextChanged);
            ContractsGrid.CellContentClick -= new TTGridCellEventDelegate(ContractsGrid_CellContentClick);
            cmdFind.Click -= new TTControlEventDelegate(cmdFind_Click);
            base.UnBindControlEvents();
        }

        private void txtProjectNo_TextChanged()
        {
#region ProcedureWorksAcceptNoticeForm_txtProjectNo_TextChanged
   if(string.IsNullOrEmpty(txtProjectNo.Text))
            {
                txtProjectNo.ReadOnly = true;
                txtConfirmNo.ReadOnly = true;
            }
            else
            {
                txtConfirmNo.ReadOnly = false;
            }
#endregion ProcedureWorksAcceptNoticeForm_txtProjectNo_TextChanged
        }

        private void txtConfirmNo_TextChanged()
        {
#region ProcedureWorksAcceptNoticeForm_txtConfirmNo_TextChanged
   if(string.IsNullOrEmpty(txtConfirmNo.Text))
            {
                txtProjectNo.ReadOnly = true;
                txtConfirmNo.ReadOnly = true;
            }
            else
            {
                txtProjectNo.ReadOnly = false;
            }
#endregion ProcedureWorksAcceptNoticeForm_txtConfirmNo_TextChanged
        }

        private void ContractsGrid_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region ProcedureWorksAcceptNoticeForm_ContractsGrid_CellContentClick
   ProjectContract pc = (ProjectContract)ContractsGrid.CurrentCell.OwningRow.TTObject;
            _ProcedureWorksAcceptNotice.Contract = pc.Contract;
#endregion ProcedureWorksAcceptNoticeForm_ContractsGrid_CellContentClick
        }

        private void cmdFind_Click()
        {
#region ProcedureWorksAcceptNoticeForm_cmdFind_Click
   if(string.IsNullOrEmpty(txtProjectNo.Text) && string.IsNullOrEmpty(txtConfirmNo.Text))
                return;
            
            BindingList<PurchaseProject> project;
                
            if(string.IsNullOrEmpty(txtProjectNo.Text))
                project = PurchaseProject.GetPurchaseProjectByConfirmNo(_ProcedureWorksAcceptNotice.ObjectContext, txtConfirmNo.Text);
            else
                project = PurchaseProject.GetPurchaseProjectByProjectNo(_ProcedureWorksAcceptNotice.ObjectContext, Convert.ToInt32(txtProjectNo.Text));
            
            if(project.Count == 0)
                return;
            
            else if (project.Count > 1)
            {
                InfoBox.Show("Aynı onay numarasına sahip iki ihale bulundu. Bilgi işlemi arayınız.");
                return;
            }
            else
            {
                if(_ProcedureWorksAcceptNotice.ProjectContracts.Count > 0)
                    _ProcedureWorksAcceptNotice.ProjectContracts.Clear();

                PurchaseProject pp = (PurchaseProject)project[0];
                if(pp.PurchaseTypeMatPro != PurchaseTypeEnum_Material_Procedure.ProcedureProcurement)
                {
                    InfoBox.Show("Bu numaraya sahip proje bir hizmet alımı projesi değildir.");
                    return;
                }
                
                foreach(Contract c in pp.Contracts)
                {
                    ProjectContract pc = new ProjectContract(_ProcedureWorksAcceptNotice.ObjectContext);
                    pc.Contract = c;
                    pc.ProcedureWorksAcceptNotice = _ProcedureWorksAcceptNotice;
                }
            }
#endregion ProcedureWorksAcceptNoticeForm_cmdFind_Click
        }

        protected override void PreScript()
        {
#region ProcedureWorksAcceptNoticeForm_PreScript
    base.PreScript();
            
            if(_ProcedureWorksAcceptNotice.Contract != null)
            {
                txtConfirmNo.ReadOnly = true;
                txtProjectNo.ReadOnly = true;
            }
            
            this.DropStateButton(ProcedureWorksAcceptNotice.States.Cancelled);
#endregion ProcedureWorksAcceptNoticeForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region ProcedureWorksAcceptNoticeForm_PostScript
    base.PostScript(transDef);
#endregion ProcedureWorksAcceptNoticeForm_PostScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region ProcedureWorksAcceptNoticeForm_ClientSidePostScript
    base.ClientSidePostScript(transDef);
             bool exist = false;
            
             ProcedureWorksAcceptNotice tmpPwa = null;
            foreach(ProcedureWorksAcceptNotice pwa in _ProcedureWorksAcceptNotice.Contract.ProcedureWorksAcceptNotices)
            {
                if(_ProcedureWorksAcceptNotice.ObjectID != pwa.ObjectID)
                {
                    if(pwa.CurrentStateDefID != ProcedureWorksAcceptNotice.States.Cancelled)
                        tmpPwa = pwa;
                }
            }
            
            string result = "";
            if(tmpPwa != null)
            {
                result=ShowBox.Show(ShowBoxTypeEnum.Message,"&Evet,&Hayır", "E,H", "Uyarı","Uyarı" , "Bu projede daha önce bu firmaya düzenlenmiş " + tmpPwa.ID.ToString() + " no.lu tutanak bulunmakta. Devam etmek istiyor musunuz?", 1);
            }
            
            if(result=="H")
                throw new Exception("İşlem iptal edildi");
#endregion ProcedureWorksAcceptNoticeForm_ClientSidePostScript

        }
    }
}