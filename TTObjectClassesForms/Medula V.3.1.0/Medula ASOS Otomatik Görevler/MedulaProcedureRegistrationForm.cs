
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
    /// Medula Hizmet Kayıt
    /// </summary>
    public partial class MedulaProcedureRegistrationForm : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            CANCELBUTTON.Click += new TTControlEventDelegate(CANCELBUTTON_Click);
            SAVEBUTTON.Click += new TTControlEventDelegate(SAVEBUTTON_Click);
            LISTBUTTON.Click += new TTControlEventDelegate(LISTBUTTON_Click);
            UNSELECTBUTTON.Click += new TTControlEventDelegate(UNSELECTBUTTON_Click);
            SELECTBUTTON.Click += new TTControlEventDelegate(SELECTBUTTON_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            CANCELBUTTON.Click -= new TTControlEventDelegate(CANCELBUTTON_Click);
            SAVEBUTTON.Click -= new TTControlEventDelegate(SAVEBUTTON_Click);
            LISTBUTTON.Click -= new TTControlEventDelegate(LISTBUTTON_Click);
            UNSELECTBUTTON.Click -= new TTControlEventDelegate(UNSELECTBUTTON_Click);
            SELECTBUTTON.Click -= new TTControlEventDelegate(SELECTBUTTON_Click);
            base.UnBindControlEvents();
        }

        private void CANCELBUTTON_Click()
        {
#region MedulaProcedureRegistrationForm_CANCELBUTTON_Click
   this.Close();
#endregion MedulaProcedureRegistrationForm_CANCELBUTTON_Click
        }

        private void SAVEBUTTON_Click()
        {
#region MedulaProcedureRegistrationForm_SAVEBUTTON_Click
   if (TTObjectClasses.SystemParameter.IsMedulaIntegration)
            {
                TTObjectContext context = new TTObjectContext(false);
                
                List<AccountTransaction> myAccTrxs = new List<AccountTransaction>();
                List<DiagnosisGrid> myDiagnosises = new List<DiagnosisGrid>();
                
                for (int i = 0; i < this.GRIDProcedures.Rows.Count; i++)
                {
                    
                    if (Convert.ToBoolean(this.GRIDProcedures.Rows[i].Cells["PSEND"].Value))
                    {
                        Guid AccTrxGuid = new Guid(this.GRIDProcedures.Rows[i].Cells["POBJECTID"].Value.ToString());
                        AccountTransaction AccTrx = (AccountTransaction)context.GetObject(AccTrxGuid,"ACCOUNTTRANSACTION");
                        
                        myAccTrxs.Add(AccTrx);
                    }
                }
                
                for (int i = 0; i < this.GRIDMaterials.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(this.GRIDMaterials.Rows[i].Cells["MSEND"].Value))
                    {
                        Guid AccTrxGuid = new Guid(this.GRIDMaterials.Rows[i].Cells["MOBJECTID"].Value.ToString());
                        AccountTransaction AccTrx = (AccountTransaction)context.GetObject(AccTrxGuid,"ACCOUNTTRANSACTION");
                        
                        myAccTrxs.Add(AccTrx);
                    }
                }
                
                for (int i = 0; i < this.GRIDDiagnoses.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(this.GRIDDiagnoses.Rows[i].Cells["DSEND"].Value))
                    {
                        Guid diagnoseGuid = new Guid(this.GRIDDiagnoses.Rows[i].Cells["DOBJECTID"].Value.ToString());
                        DiagnosisGrid diagnosis = (DiagnosisGrid)context.GetObject(diagnoseGuid,"DIAGNOSISGRID");
                        
                        myDiagnosises.Add(diagnosis);
                    }
                }
                
                if (myAccTrxs.Count > 0 || myDiagnosises.Count > 0)
                {
                    try
                    {
                        IList HastaKabulList = PatientMedulaHastaKabul.GetByTakipNo(context, this.TAKIPNO.Text);
                        
                        if (HastaKabulList.Count > 0)
                        {
                            PatientMedulaHastaKabul HastaKabul = (PatientMedulaHastaKabul)HastaKabulList[0];
                            HizmetKayit HK = new HizmetKayit(context);
                            HK.HealthFacilityID = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();
                            HK.CurrentStateDefID = HizmetKayit.States.New;
                            HastaKabul.CreateHizmetKayitGirisDVO(context, HK, myAccTrxs, myDiagnosises);
                            HK.Update();
                            HK.CurrentStateDefID = HizmetKayit.States.SentServer;
                            context.Save();
                            
                            this.TAKIPNO.Text = "";
                            ((TTGrid)this.GRIDProcedures).Rows.Clear();
                            ((TTGrid)this.GRIDMaterials).Rows.Clear();
                            ((TTGrid)this.GRIDDiagnoses).Rows.Clear();
                            
                            InfoBox.Show("Hizmet, İlaç/Malzeme ve Tanılar Medula'ya kaydedilmiştir.", MessageIconEnum.InformationMessage);
                        }
                        else
                            InfoBox.Show("Takip numarası bulunamadı!", MessageIconEnum.WarningMessage);
                    }
                    catch (Exception ex)
                    {
                        throw new TTException("Medula'ya Hizmet, İlaç/Malzeme ve Tanı kaydı yapılamadı! : " + ex.Message, ex);
                    }
                }
                else
                    InfoBox.Show("Medula'ya kaydedilmesi için seçilmiş Hizmet, İlaç/Malzeme ve Tanı bulunamadı.", MessageIconEnum.WarningMessage);
            }
            else
                InfoBox.Show("Medula Entegrasyon sistem parametresi kapalı durumdadır. Medula'ya Hizmet, İlaç/Malzeme ve Tanı kaydı yapılamaz!", MessageIconEnum.WarningMessage);
#endregion MedulaProcedureRegistrationForm_SAVEBUTTON_Click
        }

        private void LISTBUTTON_Click()
        {
#region MedulaProcedureRegistrationForm_LISTBUTTON_Click
   if (TTObjectClasses.SystemParameter.IsMedulaIntegration)
            {
                TTObjectContext context = new TTObjectContext(true);
                
                ((TTGrid)this.GRIDProcedures).Rows.Clear();
                ((TTGrid)this.GRIDMaterials).Rows.Clear();
                ((TTGrid)this.GRIDDiagnoses).Rows.Clear();

                if (this.TAKIPNO.Text != "")
                {
                    IList HastaKabulList = PatientMedulaHastaKabul.GetByTakipNo(context, this.TAKIPNO.Text);
                    
                    if (HastaKabulList.Count > 0)
                    {
                        PatientMedulaHastaKabul HastaKabul = (PatientMedulaHastaKabul)HastaKabulList[0];
                        
                        if (HastaKabul != null)
                        {
                            if (HastaKabul.CurrentStateDefID != PatientMedulaHastaKabul.States.Cancelled)
                            {
                                /*
                                foreach (SubActionProcedure sp in HastaKabul.SubActionProcedures)
                                {
                                    foreach(AccountTransaction AccTrx in sp.AccountTransactions)
                                    {
                                        if (AccTrx.IsMedulaAccountTransaction())
                                        {
                                            ITTGridRow procedure = this.GRIDProcedures.Rows.Add();
                                            procedure.Cells["PACTIONDATE"].Value = AccTrx.MedulaTransactionDate;
                                            procedure.Cells["PEXTERNALCODE"].Value = AccTrx.MedulaProcedureCode;
                                            procedure.Cells["PDESCRIPTION"].Value = AccTrx.Description;
                                            procedure.Cells["PAMOUNT"].Value = AccTrx.Amount.ToString();
                                            procedure.Cells["POBJECTID"].Value = AccTrx.ObjectID.ToString();
                                            procedure.Cells["PSTATUS"].Value = AccTrx.CurrentStateDef.DisplayText.ToUpper();
                                            
                                            if (AccTrx.CanBeRegisteredToMedula())
                                            {
                                                procedure.Cells["PSENDABLE"].Value = "1";
                                                procedure.Cells["PSEND"].Value = 1;
                                                procedure.ReadOnly = false;
                                            }
                                            else
                                            {
                                                procedure.Cells["PSENDABLE"].Value = "0";
                                                procedure.Cells["PSEND"].Value = 0;
                                                procedure.ReadOnly = true;
                                                
                                                if (AccTrx.MedulaSuccessfulResult != null)
                                                    procedure.Cells["PMEDULASIRANO"].Value = AccTrx.MedulaSuccessfulResult.islemSiraNo;
                                                else
                                                {
                                                    if(AccTrx.CurrentStateDefID == AccountTransaction.States.New)
                                                        procedure.Cells["PMEDULASIRANO"].Value = "Cevap Bekleniyor";
                                                }
                                            }
                                        }
                                    }
                                }
                                
                                foreach (SubActionMaterial sm in HastaKabul.SubActionMaterials)
                                {
                                    foreach(AccountTransaction AccTrx in sm.AccountTransactions)
                                    {
                                        if (AccTrx.IsMedulaAccountTransaction())
                                        {
                                            ITTGridRow material = this.GRIDMaterials.Rows.Add();
                                            material.Cells["MACTIONDATE"].Value = AccTrx.MedulaTransactionDate;
                                            material.Cells["MEXTERNALCODE"].Value = AccTrx.MedulaMaterialCode;
                                            material.Cells["MDESCRIPTION"].Value = AccTrx.Description;
                                            material.Cells["MAMOUNT"].Value = AccTrx.Amount.ToString();
                                            material.Cells["MOBJECTID"].Value = AccTrx.ObjectID.ToString();
                                            material.Cells["MSTATUS"].Value = AccTrx.CurrentStateDef.DisplayText.ToUpper();
                                            
                                            if (AccTrx.CanBeRegisteredToMedula())
                                            {
                                                material.Cells["MSENDABLE"].Value = "1";
                                                material.Cells["MSEND"].Value = 1;
                                                material.ReadOnly = false;
                                            }
                                            else
                                            {
                                                material.Cells["MSENDABLE"].Value = "0";
                                                material.Cells["MSEND"].Value = 0;
                                                material.ReadOnly = true;
                                                
                                                if (AccTrx.MedulaSuccessfulResult != null)
                                                    material.Cells["MMEDULASIRANO"].Value = AccTrx.MedulaSuccessfulResult.islemSiraNo;
                                                else
                                                {
                                                    if(AccTrx.CurrentStateDefID == AccountTransaction.States.New)
                                                        material.Cells["MMEDULASIRANO"].Value = "Cevap Bekleniyor";
                                                }
                                            }
                                        }
                                    }
                                }
                                
                                foreach (DiagnosisGrid diagnosis in HastaKabul.DiagnosisGrids)
                                {
                                    ITTGridRow diagnose = this.GRIDDiagnoses.Rows.Add();
                                    diagnose.Cells["DIAGNOSECODE"].Value = diagnosis.DiagnoseCode;
                                    diagnose.Cells["DIAGNOSENAME"].Value = diagnosis.Diagnose.Name;
                                    diagnose.Cells["DOBJECTID"].Value = diagnosis.ObjectID.ToString();
                                    
                                    if (diagnosis.CanBeRegisteredToMedula())
                                    {
                                        diagnose.Cells["DSENDABLE"].Value = "1";
                                        diagnose.Cells["DSEND"].Value = 1;
                                        diagnose.ReadOnly = false;
                                    }
                                    else
                                    {
                                        diagnose.Cells["DSENDABLE"].Value = "0";
                                        diagnose.Cells["DSEND"].Value = 0;
                                        diagnose.ReadOnly = true;

                                        if (diagnosis.MedulaSuccessfulResult != null)
                                            diagnose.Cells["DMEDULASIRANO"].Value = diagnosis.MedulaSuccessfulResult.islemSiraNo;
                                    }
                                }
                                */
                            }
                            else
                                InfoBox.Show("Takip iptal durumda!", MessageIconEnum.WarningMessage);
                        }
                        else
                            InfoBox.Show("Takip numarası bulunamadı!", MessageIconEnum.WarningMessage);
                    }
                    else
                        InfoBox.Show("Takip numarası bulunamadı!", MessageIconEnum.WarningMessage);
                }
                else
                    InfoBox.Show("Takip numarası boş!", MessageIconEnum.WarningMessage);
            }
            else
                InfoBox.Show("Medula Entegrasyon sistem parametresi kapalı durumdadır. Medula'ya Hizmet, İlaç/Malzeme ve Tanı kaydı yapılamaz!", MessageIconEnum.WarningMessage);
#endregion MedulaProcedureRegistrationForm_LISTBUTTON_Click
        }

        private void UNSELECTBUTTON_Click()
        {
#region MedulaProcedureRegistrationForm_UNSELECTBUTTON_Click
   for (int i = 0; i < this.GRIDProcedures.Rows.Count; i++)
            {
                this.GRIDProcedures.Rows[i].Cells["PSEND"].Value = 0;
            }
            
            for (int i = 0; i < this.GRIDMaterials.Rows.Count; i++)
            {
                this.GRIDMaterials.Rows[i].Cells["MSEND"].Value = 0;
            }
            
            for (int i = 0; i < this.GRIDDiagnoses.Rows.Count; i++)
            {
                this.GRIDDiagnoses.Rows[i].Cells["DSEND"].Value = 0;
            }
#endregion MedulaProcedureRegistrationForm_UNSELECTBUTTON_Click
        }

        private void SELECTBUTTON_Click()
        {
#region MedulaProcedureRegistrationForm_SELECTBUTTON_Click
   for (int i = 0; i < this.GRIDProcedures.Rows.Count; i++)
            {
                if ((string)this.GRIDProcedures.Rows[i].Cells["PSENDABLE"].Value == "1")
                    this.GRIDProcedures.Rows[i].Cells["PSEND"].Value = 1;
            }
            
            for (int i = 0; i < this.GRIDMaterials.Rows.Count; i++)
            {
                if ((string)this.GRIDMaterials.Rows[i].Cells["MSENDABLE"].Value == "1")
                    this.GRIDMaterials.Rows[i].Cells["MSEND"].Value = 1;
            }
            
            for (int i = 0; i < this.GRIDDiagnoses.Rows.Count; i++)
            {
                if ((string)this.GRIDDiagnoses.Rows[i].Cells["DSENDABLE"].Value == "1")
                    this.GRIDDiagnoses.Rows[i].Cells["DSEND"].Value = 1;
            }
#endregion MedulaProcedureRegistrationForm_SELECTBUTTON_Click
        }
    }
}