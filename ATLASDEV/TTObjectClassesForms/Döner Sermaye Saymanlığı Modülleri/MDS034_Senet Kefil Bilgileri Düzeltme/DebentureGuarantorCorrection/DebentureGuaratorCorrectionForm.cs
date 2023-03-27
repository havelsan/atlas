
//using System;
//using System.Xml;
//using System.Data;
//using System.Text;
//using System.Drawing;
//using System.Reflection;
//using System.Collections;
//using System.Linq;
//using System.ComponentModel;
//using System.Collections.Generic;
//using System.Runtime.Serialization;
//using System.Collections.ObjectModel;
//using System.Runtime.InteropServices;

//using TTUtils;
//using TTObjectClasses;
//using TTDataDictionary;
//using TTCoreDefinitions;
//using TTConnectionManager;
//using TTInstanceManagement;
//using TTDefinitionManagement;
//using TTStorageManager.Security;

//using SmartCardWrapper;

//using TTStorageManager;
//using System.Runtime.Versioning;
//using System.Windows.Forms;
//using TTVisual;
//namespace TTFormClasses
//{
//    /// <summary>
//    /// Kefil Bilgileri Düzeltme
//    /// </summary>
//    public partial class DebentureGuaratorCorrectionForm : TTForm
//    {
//        override protected void BindControlEvents()
//        {
//            GridDebentures.CellContentClick += new TTGridCellEventDelegate(GridDebentures_CellContentClick);
//            base.BindControlEvents();
//        }

//        override protected void UnBindControlEvents()
//        {
//            GridDebentures.CellContentClick -= new TTGridCellEventDelegate(GridDebentures_CellContentClick);
//            base.UnBindControlEvents();
//        }

//        private void GridDebentures_CellContentClick(Int32 rowIndex, Int32 columnIndex)
//        {
//#region DebentureGuaratorCorrectionForm_GridDebentures_CellContentClick
//   if (columnIndex == 4 && rowIndex != -1 )
//            {
//                if (rowIndex < this._DebentureGuarantorCorrection.PatientDebentures.Count)
                    
//                {
//                    string debentureObjectID = _DebentureGuarantorCorrection.PatientDebentures[rowIndex].DebentureObjectID.ToString();
//                    IList MyDebentureList = Debenture.GetByObjectID(_DebentureGuarantorCorrection.ObjectContext,debentureObjectID);
                    
//                    if (MyDebentureList.Count == 0)
//                        throw new Exception("Kefil Bulunamadı");
//                    else
//                    {
//                        DebentureGuarantor debentureGuarantor = null;
//                        Debenture debenture;
                        
//                        debenture = (Debenture)MyDebentureList[0];
                       
                        
//                        debentureGuarantor = (DebentureGuarantor)debenture.Guarantor;
//                        DebentureGuarantorForm frm = new DebentureGuarantorForm();
//                        DialogResult dialogresult = DialogResult.OK ;
//                        if (this._DebentureGuarantorCorrection.CurrentStateDefID == DebentureGuarantorCorrection.States.Completed)
//                            dialogresult = frm.ShowReadOnly(this.FindForm(),debentureGuarantor);
//                        else
//                            dialogresult = frm.ShowEdit(this.FindForm(),debentureGuarantor);
                        
//                        if ( dialogresult == DialogResult.OK )
//                            this._DebentureGuarantorCorrection.PatientDebentures[rowIndex].Changed = true ;
//                        else if ( dialogresult == DialogResult.Cancel && this._DebentureGuarantorCorrection.PatientDebentures[rowIndex].Changed != true )
//                            this._DebentureGuarantorCorrection.PatientDebentures[rowIndex].Changed = false ;
                        
//                    }
//                }
//            }
//#endregion DebentureGuaratorCorrectionForm_GridDebentures_CellContentClick
//        }

//        protected override void PreScript()
//        {
//#region DebentureGuaratorCorrectionForm_PreScript
//    base.PreScript();
//            if (this._DebentureGuarantorCorrection.PatientDebentures.Count == 0)
//            {
//                if  (this._DebentureGuarantorCorrection.CurrentStateDefID == DebentureGuarantorCorrection.States.New)
//                {
//                    if (_DebentureGuarantorCorrection.Episode.PatientStatus.Value == 0)
//                    {
//                        Episode myEpisode = _DebentureGuarantorCorrection.Episode;
//                        IList MyEmergencyInterventionList = EmergencyIntervention.GetByEpisode(_DebentureGuarantorCorrection.ObjectContext,myEpisode.ObjectID.ToString());
//                        if (MyEmergencyInterventionList.Count != 0)
//                        {
//                            EmergencyIntervention emInt = (EmergencyIntervention) MyEmergencyInterventionList[0];
//                            this._DebentureGuarantorCorrection.Department = emInt.MasterResource.Name.ToString();
//                        }
//                    }
//                    else if (_DebentureGuarantorCorrection.Episode.TreatmentClinic != null)
//                        this._DebentureGuarantorCorrection.Department = _DebentureGuarantorCorrection.Episode.TreatmentClinic.Name.ToString();
                    
                    
                    
                    
//                    foreach (EpisodeAction ea in this._DebentureGuarantorCorrection.Episode.EpisodeActions)
//                    {
//                        if (ea.Cancelled == false)
//                        {
//                            Receipt myReceipt = ea as Receipt ;
//                            if (myReceipt != null)
//                            {
//                                if (myReceipt.CurrentStateDefID == Receipt.States.Paid)
//                                {
//                                    foreach (Debenture db in myReceipt.ReceiptDocument.DebenturePayments)
//                                    {
//                                        if (db.CurrentStateDefID != Debenture.States.Cancelled)
//                                        {
//                                            DebentureGuarantorCorrectionPatientDebentures pDebs = new DebentureGuarantorCorrectionPatientDebentures(_DebentureGuarantorCorrection.ObjectContext);
//                                            pDebs.No = db.No.Value.ToString();
//                                            pDebs.DueDate = db.DueDate;
//                                            pDebs.Status = db.CurrentStateDef.DisplayText.ToString();
//                                            pDebs.Price = db.Price;
//                                            pDebs.DebentureObjectID = db.ObjectID.ToString();
//                                            pDebs.Debenture = db;
//                                            pDebs.Changed = false ;
//                                            _DebentureGuarantorCorrection.PatientDebentures.Add(pDebs);
//                                        }
//                                    }
//                                }
//                            }
//                        }
//                    }
                    
//                    foreach (EpisodeAction ea in this._DebentureGuarantorCorrection.Episode.EpisodeActions)
//                    {
//                        if (ea.Cancelled == false)
//                        {
//                            Advance myAdvance = ea as Advance;
//                            if (myAdvance != null)
//                            {
//                                if (myAdvance.CurrentStateDefID == Advance.States.Paid)
//                                {
//                                    foreach (Debenture db in myAdvance.AdvanceDocument.DebenturePayments)
//                                    {
//                                        if (db.CurrentStateDefID != Debenture.States.Cancelled)
//                                        {
//                                            DebentureGuarantorCorrectionPatientDebentures pDebsAdv = new DebentureGuarantorCorrectionPatientDebentures(_DebentureGuarantorCorrection.ObjectContext);
//                                            pDebsAdv.No = db.No.Value.ToString();
//                                            pDebsAdv.DueDate = db.DueDate;
//                                            pDebsAdv.Status = db.CurrentStateDef.DisplayText.ToString();
//                                            pDebsAdv.Price = db.Price;
//                                            pDebsAdv.DebentureObjectID = db.ObjectID.ToString();
//                                            pDebsAdv.Debenture = db;
//                                            pDebsAdv.Changed = false ;
//                                            _DebentureGuarantorCorrection.PatientDebentures.Add(pDebsAdv);
//                                        }
//                                    }
//                                }
//                            }
//                        }
//                    }
//                }
//            }
//#endregion DebentureGuaratorCorrectionForm_PreScript

//            }
            
//        protected override void PostScript(TTObjectStateTransitionDef transDef)
//        {
//#region DebentureGuaratorCorrectionForm_PostScript
//    base.PostScript(transDef);
//            if (this._DebentureGuarantorCorrection.PatientDebentures.Count == 0)
//                throw new TTException(SystemMessage.GetMessage(438));
            
//            bool cancelFound = false;
//            foreach (DebentureGuarantorCorrectionPatientDebentures pDbs in this._DebentureGuarantorCorrection.PatientDebentures)
//            {
//                if (pDbs.Changed == true)
//                {
//                    cancelFound = true ;
//                    break;
//                }
//            }
//            if (cancelFound == false)
//                throw new TTException(SystemMessage.GetMessage(440));
            
//            // int patientCount = this._DebentureGuarantorCorrection.PatientDebentures.Count;
//            //            for(int i = 0 ; i < this._DebentureGuarantorCorrection.PatientDebentures.Count ; i++)
//            //            {
//            //                if (this._DebentureGuarantorCorrection.PatientDebentures[i].Changed == false)
//            //
//            //                {
//            //                    this._DebentureGuarantorCorrection.PatientDebentures.Remove(this._DebentureGuarantorCorrection.PatientDebentures[i]);
//            //                    i = i - 1 ;
//            //                }
//            //            }
//#endregion DebentureGuaratorCorrectionForm_PostScript

//            }
//                }
//}