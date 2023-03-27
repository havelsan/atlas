
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
    /// Ayaktan Hasta Reçetesi
    /// </summary>
    public partial class OutPatientPrescriptionForm : OutPatientPrescriptionBaseForm
    {
        override protected void BindControlEvents()
        {
            SendESignedPrescription.Click += new TTControlEventDelegate(SendESignedPrescription_Click);
            cmdAddTemplate.Click += new TTControlEventDelegate(cmdAddTemplate_Click);
            cmdGetTemplate.Click += new TTControlEventDelegate(cmdGetTemplate_Click);
            cmdGetFavoriteDrugs.Click += new TTControlEventDelegate(cmdGetFavoriteDrugs_Click);
            OutPatientDrugOrders.RowValidating += new TTGridCellCancelEventDelegate(OutPatientDrugOrders_RowValidating);
            OutPatientDrugOrders.RowLeave += new TTGridCellEventDelegate(OutPatientDrugOrders_RowLeave);
            OutPatientDrugOrders.CellContentClick += new TTGridCellEventDelegate(OutPatientDrugOrders_CellContentClick);
            OutPatientDrugOrders.CellValueChanged += new TTGridCellEventDelegate(OutPatientDrugOrders_CellValueChanged);
            cmdAddDiagnosis.Click += new TTControlEventDelegate(cmdAddDiagnosis_Click);
            cmdChangeSpeciality.Click += new TTControlEventDelegate(cmdChangeSpeciality_Click);
            PrescriptionType.SelectedIndexChanged += new TTControlEventDelegate(PrescriptionType_SelectedIndexChanged);
            FavoriteDrugListview.DoubleClick += new TTControlEventDelegate(FavoriteDrugListview_DoubleClick);
            DrugListview.DoubleClick += new TTControlEventDelegate(DrugListview_DoubleClick);
            SearchTextbox.TextChanged += new TTControlEventDelegate(SearchTextbox_TextChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            SendESignedPrescription.Click -= new TTControlEventDelegate(SendESignedPrescription_Click);
            cmdAddTemplate.Click -= new TTControlEventDelegate(cmdAddTemplate_Click);
            cmdGetTemplate.Click -= new TTControlEventDelegate(cmdGetTemplate_Click);
            cmdGetFavoriteDrugs.Click -= new TTControlEventDelegate(cmdGetFavoriteDrugs_Click);
            OutPatientDrugOrders.RowValidating -= new TTGridCellCancelEventDelegate(OutPatientDrugOrders_RowValidating);
            OutPatientDrugOrders.RowLeave -= new TTGridCellEventDelegate(OutPatientDrugOrders_RowLeave);
            OutPatientDrugOrders.CellContentClick -= new TTGridCellEventDelegate(OutPatientDrugOrders_CellContentClick);
            OutPatientDrugOrders.CellValueChanged -= new TTGridCellEventDelegate(OutPatientDrugOrders_CellValueChanged);
            cmdAddDiagnosis.Click -= new TTControlEventDelegate(cmdAddDiagnosis_Click);
            cmdChangeSpeciality.Click -= new TTControlEventDelegate(cmdChangeSpeciality_Click);
            PrescriptionType.SelectedIndexChanged -= new TTControlEventDelegate(PrescriptionType_SelectedIndexChanged);
            FavoriteDrugListview.DoubleClick -= new TTControlEventDelegate(FavoriteDrugListview_DoubleClick);
            DrugListview.DoubleClick -= new TTControlEventDelegate(DrugListview_DoubleClick);
            SearchTextbox.TextChanged -= new TTControlEventDelegate(SearchTextbox_TextChanged);
            base.UnBindControlEvents();
        }

        private void SendESignedPrescription_Click()
        {
#region OutPatientPrescriptionForm_SendESignedPrescription_Click
   //PrescriptionESignForm form = new PrescriptionESignForm();
   //         form.SetPrescriptionContent(_Prescription);
   //         form.ShowDialog();
#endregion OutPatientPrescriptionForm_SendESignedPrescription_Click
        }

        private void cmdAddTemplate_Click()
        {
#region OutPatientPrescriptionForm_cmdAddTemplate_Click
   string description = InputForm.GetText("Şablon Açıklaması");
            if (string.IsNullOrEmpty(description) == false)
            {
                IList userTemplates = Common.CurrentResource.UserTemplates.Select("TAOBJECTDEFID = " + ConnectionManager.GuidToString(_OutPatientPrescription.ObjectDef.ID) + " AND DESCRIPTION = '" + description + "'");

                if (userTemplates.Count == 0)
                {
                    UserTemplate userTemplate = new UserTemplate(_OutPatientPrescription.ObjectContext);
                    userTemplate.ResUser = (ResUser)Common.CurrentResource;
                    userTemplate.Description = description;
                    userTemplate.TAObjectID = _OutPatientPrescription.ObjectID;
                    userTemplate.TAObjectDefID = _OutPatientPrescription.ObjectDef.ID;

                    switch (_OutPatientPrescription.PrescriptionType)
                    {
                        case PrescriptionTypeEnum.NormalPrescription:
                            userTemplate.FiliterData = "NormalPrescription";
                            break;
                        case PrescriptionTypeEnum.RedPrescription:
                            userTemplate.FiliterData = "RedPrescription";
                            break;
                        case PrescriptionTypeEnum.GreenPrescription:
                            userTemplate.FiliterData = "GreenPrescription";
                            break;
                        case PrescriptionTypeEnum.OrangePrescription:
                            userTemplate.FiliterData = "OrangePrescription";
                            break;
                        case PrescriptionTypeEnum.PurplePrescription:
                            userTemplate.FiliterData = "PurplePrescription";
                            break;
                        case PrescriptionTypeEnum.ControlledPrescription:
                            userTemplate.FiliterData = "ControlledPrescription";
                            break;
                        default:
                            throw new TTException("Hatalı Reçete Tipi");
                    }
                    this.cmdAddTemplate.Enabled = false;
                }
                else
                {
                    InfoBox.Show(description + " isimli şablonunuz bulunduğu için şablon kayıt edilemedi", MessageIconEnum.ErrorMessage);
                }
            }
            else
                InfoBox.Show("Şablona isim vermeden kaydedemezsiniz.", MessageIconEnum.ErrorMessage);
#endregion OutPatientPrescriptionForm_cmdAddTemplate_Click
        }

        private void cmdGetTemplate_Click()
        {
#region OutPatientPrescriptionForm_cmdGetTemplate_Click
   string prescriptionTypeFiliter = string.Empty;
            switch (_OutPatientPrescription.PrescriptionType)
            {
                case PrescriptionTypeEnum.NormalPrescription:
                    prescriptionTypeFiliter = "NormalPrescription";
                    break;
                case PrescriptionTypeEnum.RedPrescription:
                    prescriptionTypeFiliter = "RedPrescription";
                    break;
                case PrescriptionTypeEnum.GreenPrescription:
                    prescriptionTypeFiliter = "GreenPrescription";
                    break;
                case PrescriptionTypeEnum.OrangePrescription:
                    prescriptionTypeFiliter = "OrangePrescription";
                    break;
                case PrescriptionTypeEnum.PurplePrescription:
                    prescriptionTypeFiliter = "PurplePrescription";
                    break;
                case PrescriptionTypeEnum.ControlledPrescription:
                    prescriptionTypeFiliter = "ControlledPrescription";
                    break;
                default:
                    throw new TTException("Hatalı Reçete Tipi");
            }

            IList userTemplates = _OutPatientPrescription.ObjectContext.QueryObjects("USERTEMPLATE", "RESUSER =" + ConnectionManager.GuidToString(Common.CurrentResource.ObjectID) + "AND TAOBJECTDEFID = " + ConnectionManager.GuidToString(_OutPatientPrescription.ObjectDef.ID) + " AND FILITERDATA ='" + prescriptionTypeFiliter + "'");
            //IList userTepmlates = Common.CurrentResource.UserTemplates.Select("TAOBJECTDEFID = " + ConnectionManager.GuidToString(_OutPatientPrescription.ObjectDef.ID)+ " AND FILITERDATA ='"+ prescriptionTypeFiliter+"'" );
            if (userTemplates.Count > 0)
            {
                MultiSelectForm pForm = new MultiSelectForm();
                foreach (UserTemplate userTemplate in userTemplates)
                {
                    pForm.AddMSItem(userTemplate.Description, userTemplate.ObjectID.ToString(), userTemplate);

                }
                string sKey = pForm.GetMSItem(this, "Şablon seçiniz.", false, false, false, false, true, false);
                if (!String.IsNullOrEmpty(sKey))
                {
                    UserTemplate selectedTemplate = (UserTemplate)pForm.MSSelectedItemObject;
                    OutPatientPrescription outPatientPrescription = (OutPatientPrescription)_OutPatientPrescription.ObjectContext.GetObject((Guid)selectedTemplate.TAObjectID, (Guid)selectedTemplate.TAObjectDefID);
                    foreach (OutPatientDrugOrder drugOrder in outPatientPrescription.OutPatientDrugOrders)
                    {
                        OutPatientDrugOrder newDrugOrder = new OutPatientDrugOrder(_OutPatientPrescription.ObjectContext);
                        newDrugOrder.OutPatientPrescription = _OutPatientPrescription;
                        newDrugOrder.Amount = drugOrder.Amount;
                        newDrugOrder.Day = drugOrder.Day;
                        newDrugOrder.Description = drugOrder.Description;
                        newDrugOrder.DescriptionType = drugOrder.DescriptionType;
                        newDrugOrder.DoseAmount = drugOrder.DoseAmount;
                        newDrugOrder.DrugUsageType = drugOrder.DrugUsageType;
                        newDrugOrder.Frequency = drugOrder.Frequency;
                        newDrugOrder.Material = drugOrder.Material;
                        newDrugOrder.PackageAmount = drugOrder.PackageAmount;
                        newDrugOrder.PeriodUnitType = drugOrder.PeriodUnitType;
                        newDrugOrder.PhysicianDrug = drugOrder.PhysicianDrug;
                        newDrugOrder.Price = drugOrder.Price;
                        newDrugOrder.RequiredAmount = drugOrder.RequiredAmount;
                        newDrugOrder.SelectedMaterial = drugOrder.SelectedMaterial;
                        newDrugOrder.StoreInheld = drugOrder.StoreInheld;
                        newDrugOrder.Store = drugOrder.Store;
                        newDrugOrder.UsageNote = drugOrder.UsageNote;
                        newDrugOrder.UseAmount = drugOrder.UseAmount;
                        newDrugOrder.TreatmentTime = drugOrder.TreatmentTime;
                    }
                }
            }
            else
                InfoBox.Show("Herhangibir reçete şablonunuz bulunmamaktadır", MessageIconEnum.InformationMessage);
#endregion OutPatientPrescriptionForm_cmdGetTemplate_Click
        }

        private void cmdGetFavoriteDrugs_Click()
        {
#region OutPatientPrescriptionForm_cmdGetFavoriteDrugs_Click
   /*TTVisual.TTForm favoriteDrugForm = new TTFormClasses.FavoriteDrugForm();
            favoriteDrugForm.ShowEdit(this.FindForm(), _OutPatientPrescription);*/
#endregion OutPatientPrescriptionForm_cmdGetFavoriteDrugs_Click
        }

        private void OutPatientDrugOrders_RowValidating(Int32 rowIndex, Int32 columnIndex, CancelEventArgs e)
        {
#region OutPatientPrescriptionForm_OutPatientDrugOrders_RowValidating
   //if (_OutPatientPrescription.Episode.PatientGroup == PatientGroupEnum.PrivateNonCom || _OutPatientPrescription.Episode.PatientGroup == PatientGroupEnum.Cadet)
            //         {
            //             ITTGridRow outPatientDrugOrderRow = OutPatientDrugOrders.Rows[OutPatientDrugOrders.CurrentCell.RowIndex];
            //             OutPatientDrugOrder drugOrder = ((OutPatientDrugOrder)outPatientDrugOrderRow.TTObject);
            //             drugOrder.Store = _OutPatientPrescription.MasterResource.Store;
            //             DrugDefinition drugDefinition = (DrugDefinition)_OutPatientPrescription.ObjectContext.GetObject(new Guid(outPatientDrugOrderRow.Cells["Drug"].Value.ToString()), "DRUGDEFINITION");
            //             double amount = (double)drugOrder.Amount;
            //             if (outPatientDrugOrderRow.Cells["Drug"].Value != null)
            //             {
            //                 if (outPatientDrugOrderRow.Cells["Frequency"].Value != null && outPatientDrugOrderRow.Cells["DoseAmount"].Value != null && outPatientDrugOrderRow.Cells["Day"].Value != null)
            //                 {
            //                     Material material = (Material)_OutPatientPrescription.ObjectContext.GetObject(new Guid(outPatientDrugOrderRow.Cells["Drug"].Value.ToString()), "MATERIAL");
            //                     if (material is MagistralPreparationDefinition == false)
            //                     {
            //                                     bool inheld = false;

            //                                     if (drugDefinition.StockInheld(_OutPatientPrescription.MasterResource.Store) > amount)
            //                                     {
            //                                         inheld = true;
            //                                     }
            //                                     else
            //                                     {
            //                                         inheld = false;
            //                                     }

            //                                     if (inheld == false)
            //                                     {
            //                                         List<DrugDefinition> equivalentDrugs = new List<DrugDefinition>();
            //                                         if (drugDefinition.DrugRelations.Count > 0)
            //                                         {
            //                                             foreach (DrugRelation relation in drugDefinition.DrugRelations)
            //                                             {
            //                                                 equivalentDrugs.Add(relation.RelationDrug);
            //                                             }
            //                                         }

            //                                         if (equivalentDrugs != null)
            //                                         {
            //                                             bool equInheld = false;
            //                                             foreach (DrugDefinition drug in equivalentDrugs)
            //                                             {
            //                                                 if (((Material)drug).ExistingInheld(_OutPatientPrescription.MasterResource.Store))
            //                                                 {
            //                                                     equInheld = true;
            //                                                     break;
            //                                                 }
            //                                             }
            //                                             if (equInheld)
            //                                             {

            //                                                 TTVisual.TTForm druqEquivalentForm = new TTFormClasses.DrugEquivalentForm();
            //                                                 TTFormClasses.OutPatientPrescriptionForm drugOrderForm = new TTFormClasses.OutPatientPrescriptionForm();
            //                                                 druqEquivalentForm.ShowEdit(drugOrderForm.FindForm(), drugOrder);
            //                                                 this.Refresh();
            //                                                 drugDefinition = (DrugDefinition)drugOrder.Material;
            //                                             }

            //                                         }

            //                                     }
            //                                     Hashtable unSortedBarcodeLevelList = new Hashtable();
            //                                     if (drugDefinition.MaterialBarcodeLevels.Count == 1)
            //                                     {
            //                                         outPatientDrugOrderRow.Cells["BarcodeLevel"].Value = drugDefinition.MaterialBarcodeLevels[0].Name.ToString();
            //                                         ((OutPatientDrugOrder)outPatientDrugOrderRow.TTObject).MaterialBarcodeLevel = drugDefinition.MaterialBarcodeLevels[0];
            //                                         if (amount > ((double)drugDefinition.MaterialBarcodeLevels[0].PackageAmount.Value))
            //                                         {
            //                                             outPatientDrugOrderRow.Cells["PackageAmount"].Value = amount / ((double)drugDefinition.MaterialBarcodeLevels[0].PackageAmount.Value);
            //                                             outPatientDrugOrderRow.Cells["Amount"].Value = ((double)outPatientDrugOrderRow.Cells["PackageAmount"].Value) * ((double)drugDefinition.MaterialBarcodeLevels[0].PackageAmount.Value);
            //                                         }
            //                                         else
            //                                         {
            //                                             outPatientDrugOrderRow.Cells["Amount"].Value = ((double)drugDefinition.MaterialBarcodeLevels[0].PackageAmount.Value);
            //                                             outPatientDrugOrderRow.Cells["PackageAmount"].Value = 1;
            //                                         }

            //                                     }

            //                                     if (drugDefinition.MaterialBarcodeLevels.Count > 1)
            //                                     {
            //                                         foreach (MaterialBarcodeLevel barcodeLevel in drugDefinition.MaterialBarcodeLevels)
            //                                         {
            //                                             if (barcodeLevel.PackageAmount > amount)
            //                                             {
            //                                                 Common.TTDoubleSortableList barcodLevelItem = new Common.TTDoubleSortableList();
            //                                                 barcodLevelItem.ID = barcodeLevel;
            //                                                 barcodLevelItem.Value = ((double)barcodeLevel.PackageAmount.Value);
            //                                                 unSortedBarcodeLevelList.Add(barcodLevelItem.ID, barcodLevelItem);
            //                                             }
            //                                         }
            //                                         if (unSortedBarcodeLevelList.Count > 0)
            //                                         {
            //                                             List<Common.TTDoubleSortableList> barcodeLevelList = Common.SortedDoubleItems(unSortedBarcodeLevelList);
            //                                             outPatientDrugOrderRow.Cells["BarcodeLevel"].Value = ((MaterialBarcodeLevel)barcodeLevelList[0].ID).Name.ToString();
            //                                             outPatientDrugOrderRow.Cells["Amount"].Value = ((double)barcodeLevelList[0].Value);
            //                                             outPatientDrugOrderRow.Cells["PackageAmount"].Value = ((double)barcodeLevelList[0].Value) / ((double)barcodeLevelList[0].Value);
            //                                             ((OutPatientDrugOrder)outPatientDrugOrderRow.TTObject).MaterialBarcodeLevel = ((MaterialBarcodeLevel)barcodeLevelList[0].ID);
            //                                         }
            //                                         else
            //                                         {
            //                                             //outPatientDrugOrderRow.Cells["Amount"].Value = amount ;
            //                                         }
            //                                     }
            //                                 }
            //                                 outPatientDrugOrderRow.Cells["RequiredAmount"].Value = amount;
            //                             }
            //                             else
            //                             {
            //                                 InfoBox.Show("İlaç direktifinizi tamamlamadığınız için yeni direktife geçemezsiniz", MessageIconEnum.ErrorMessage);
            //                                 //throw new TTException("İlaç direktifinizi tamamlamadığınız için yeni direktife geçemezsiniz");
            //                                 e.Cancel = true;
            //                             }
            //                         }
            //}
#endregion OutPatientPrescriptionForm_OutPatientDrugOrders_RowValidating
        }

        private void OutPatientDrugOrders_RowLeave(Int32 rowIndex, Int32 columnIndex)
        {
#region OutPatientPrescriptionForm_OutPatientDrugOrders_RowLeave
   ITTGridRow outPatientDrugOrderRow = OutPatientDrugOrders.Rows[OutPatientDrugOrders.CurrentCell.RowIndex];
            OutPatientDrugOrder drugOrder = ((OutPatientDrugOrder)outPatientDrugOrderRow.TTObject);
            drugOrder.Store = _OutPatientPrescription.MasterResource.Store;

            string drugValue = string.Empty;

            if (drugOrder.Material == null)
                drugOrder.Material = ((Material)drugOrder.PhysicianDrug);

            drugValue = drugOrder.Material.ObjectID.ToString();
            if (drugValue != null)
            {
                DrugDefinition drugDefinition = (DrugDefinition)_OutPatientPrescription.ObjectContext.GetObject(new Guid(drugValue), "DRUGDEFINITION");
                if (outPatientDrugOrderRow.Cells["Frequency"].Value != null && outPatientDrugOrderRow.Cells["DoseAmount"].Value != null && outPatientDrugOrderRow.Cells["Day"].Value != null && outPatientDrugOrderRow.Cells["TreatmentTime"].Value != null)
                {

                    double detailCount = DrugOrder.GetDetailCount((FrequencyEnum)outPatientDrugOrderRow.Cells["Frequency"].Value);
                    double detailTimePeriod = DrugOrder.GetDetailTimePeriod((FrequencyEnum)outPatientDrugOrderRow.Cells["Frequency"].Value);
                    double unitAmount = 0;
                    double amount = 0;
                    Material material = (Material)_OutPatientPrescription.ObjectContext.GetObject(new Guid(drugValue), "MATERIAL");
                    if (material is MagistralPreparationDefinition)
                    {
                        outPatientDrugOrderRow.Cells["RequiredAmount"].Value = 1;
                        unitAmount = (double)outPatientDrugOrderRow.Cells["DoseAmount"].Value;
                        amount = 1;
                    }
                    else
                    {
                        bool drugType = DrugOrder.GetDrugUsedType(drugDefinition);
                        if (drugType)
                        {
                            unitAmount = (double)outPatientDrugOrderRow.Cells["DoseAmount"].Value;
                        }
                        else
                        {
                            unitAmount = Math.Round((double)outPatientDrugOrderRow.Cells["DoseAmount"].Value * (double)drugDefinition.Dose / (double)drugDefinition.Volume, 2, MidpointRounding.AwayFromZero);
                        }

                        PeriodUnitTypeEnum periodUnit = (PeriodUnitTypeEnum)drugOrder.PeriodUnitType;
                        double day = 0;
                        day = Math.Round((double)drugOrder.TreatmentTime / (double)drugOrder.Day);

                        detailCount = detailCount * day;
                        amount = Math.Ceiling(unitAmount * ((double)detailCount));

                        bool inheld = false;
                        if (drugDefinition.StockInheld(_OutPatientPrescription.MasterResource.Store) > amount)
                        {
                            inheld = true;
                        }
                        else
                        {
                            inheld = false;
                        }
              
                        if (drugDefinition.PackageAmount != null)
                        {
                            if (amount > ((double)drugDefinition.PackageAmount.Value))
                            {
                                double pAmount = Math.Ceiling(amount / ((double)drugDefinition.PackageAmount.Value));
                                outPatientDrugOrderRow.Cells["PackageAmount"].Value = pAmount;
                                outPatientDrugOrderRow.Cells["Amount"].Value = ((double)outPatientDrugOrderRow.Cells["PackageAmount"].Value) * ((double)drugDefinition.PackageAmount.Value);
                            }
                            else
                            {
                                outPatientDrugOrderRow.Cells["Amount"].Value = ((double)drugDefinition.PackageAmount.Value);
                                outPatientDrugOrderRow.Cells["PackageAmount"].Value = 1;
                            }
                        }
                        outPatientDrugOrderRow.Cells["Amount"].Value = amount;
                        outPatientDrugOrderRow.Cells["RequiredAmount"].Value = amount;
                    }
                }
                if (outPatientDrugOrderRow.Cells["Amount"].Value == null && drugDefinition.PackageAmount != null && outPatientDrugOrderRow.Cells["PackageAmount"].Value != null)
                {
                    bool drugType = DrugOrder.GetDrugUsedType(drugDefinition);
                    if (drugType)
                        outPatientDrugOrderRow.Cells["Amount"].Value = drugDefinition.PackageAmount * (double)outPatientDrugOrderRow.Cells["PackageAmount"].Value;
                    else
                        outPatientDrugOrderRow.Cells["Amount"].Value = 1;
                }
            }
#endregion OutPatientPrescriptionForm_OutPatientDrugOrders_RowLeave
        }

        private void OutPatientDrugOrders_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region OutPatientPrescriptionForm_OutPatientDrugOrders_CellContentClick
   if (OutPatientDrugOrders.CurrentCell != null)
            {
                if (OutPatientDrugOrders.CurrentCell.OwningColumn.Name == OutPatientDrugOrders.Columns[cmdSelectBarcodeLevel.Name].Name)
                {
                    if (OutPatientDrugOrders.Rows[rowIndex].Cells["Drug"].Value != null)
                    {
                        Dictionary<Guid, MaterialBarcodeLevel> levels = new Dictionary<Guid, MaterialBarcodeLevel>();
                        DrugDefinition drugDefinition = (DrugDefinition)_OutPatientPrescription.ObjectContext.GetObject(new Guid(OutPatientDrugOrders.Rows[rowIndex].Cells["Drug"].Value.ToString()), "DRUGDEFINITION");
                        MultiSelectForm multiSelectForm = new MultiSelectForm();
                        foreach (MaterialBarcodeLevel barcodeLevel in drugDefinition.MaterialBarcodeLevels)
                        {
                            if (levels.ContainsKey(barcodeLevel.ObjectID) == false)
                                levels.Add(barcodeLevel.ObjectID, barcodeLevel);
                        }

                        foreach (KeyValuePair<Guid, MaterialBarcodeLevel> level in levels)
                        {
                            multiSelectForm.AddMSItem(level.Value.Name.ToString(), level.Value.Name.ToString(), level.Value);
                        }
                        string key = multiSelectForm.GetMSItem(ParentForm, "İlaç Formunu Seçiniz");
                        if (!string.IsNullOrEmpty(key))
                        {
                            OutPatientDrugOrders.Rows[rowIndex].Cells["BarcodeLevel"].Value = ((MaterialBarcodeLevel)multiSelectForm.MSSelectedItemObject).Name.ToString();
                        }
                    }
                }
                else if (OutPatientDrugOrders.CurrentCell.OwningColumn.Name == OutPatientDrugOrders.Columns[IlacEtkinMadde.Name].Name)
                {
                    if (OutPatientDrugOrders.Rows[rowIndex].Cells["Drug"].Value != null)
                    {
                        DrugDefinition drug = (DrugDefinition)_OutPatientPrescription.ObjectContext.GetObject(new Guid(OutPatientDrugOrders.Rows[rowIndex].Cells["Drug"].Value.ToString()), "DRUGDEFINITION");
                        DrugOrderIntroductionNewUnbound drugOrderIntroductionNewUnbound = new DrugOrderIntroductionNewUnbound((OutPatientDrugOrder)OutPatientDrugOrders.CurrentCell.OwningRow.TTObject, (PrescriptionTypeEnum)_OutPatientPrescription.PrescriptionType);
                        InfoBox.Show("drugOrderIntroductionNewUnbound.ShowDialog(this);");
                        if ((DrugDefinition)drugOrderIntroductionNewUnbound.Tag != null)
                        {
                            drug = (DrugDefinition)drugOrderIntroductionNewUnbound.Tag;
                            OutPatientDrugOrders.CurrentCell.OwningRow.Cells["Drug"].Value = drug.ObjectID;
                            OutPatientDrugOrders.CurrentCell.OwningRow.Cells["PhysicianDrug"].Value = drug.ObjectID;

                        }
                    }
                }
                else if (OutPatientDrugOrders.CurrentCell.OwningColumn.Name == OutPatientDrugOrders.Columns[SUTRules.Name].Name)
                {
                    if (OutPatientDrugOrders.CurrentCell.OwningRow.TTObject == null)
                        return;

                    OutPatientDrugOrder odo = (OutPatientDrugOrder)OutPatientDrugOrders.CurrentCell.OwningRow.TTObject;
                    if (odo.PhysicianDrug.EtkinMadde == null)
                    {
                        InfoBox.Show("Bu ilaç herhangi bir medula etkin madde tanımı ile eşleştirilmemiştir.");
                        return;
                    }

                    string filter = "ETKINMADDE = '" + odo.PhysicianDrug.EtkinMadde.ObjectID.ToString() + "'";
                    IList acts = _OutPatientPrescription.ObjectContext.QueryObjects(typeof(ActiveIngredientPrescriptionSUTRuleDef).Name, filter);
                    if (acts.Count == 0)
                    {
                        InfoBox.Show("Bu etken maddeye ait kural tanımı bulunamadı!");
                        return;
                    }
                    else
                    {
                        ActiveIngredientPrescriptionSUTRuleDef act = (ActiveIngredientPrescriptionSUTRuleDef)acts[0];
                        TTDefinitionForm frm = TTDefinitionForm.GetEditForm(TTObjectDefManager.Instance.ListDefs["ActiveIngredientPrescriptionSUTRuleDefinitionList"], filter);
                        frm.ShowReadOnly(this.FindForm(), TTObjectDefManager.Instance.ListDefs["ActiveIngredientPrescriptionSUTRuleDefinitionList"], act, filter);
                    }
                }
            }
#endregion OutPatientPrescriptionForm_OutPatientDrugOrders_CellContentClick
        }

        private void OutPatientDrugOrders_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region OutPatientPrescriptionForm_OutPatientDrugOrders_CellValueChanged
   if (OutPatientDrugOrders.CurrentCell.OwningColumn.Name == "PhysicianDrug")
            {
                if (OutPatientDrugOrders.Rows[rowIndex].Cells["PhysicianDrug"].Value != null)
                {
                    DrugDefinition drugDefinition = (DrugDefinition)_OutPatientPrescription.ObjectContext.GetObject(new Guid(OutPatientDrugOrders.Rows[rowIndex].Cells["PhysicianDrug"].Value.ToString()), "DRUGDEFINITION");
                    ITTGridRow outPatientDrugOrderRow = OutPatientDrugOrders.Rows[OutPatientDrugOrders.CurrentCell.RowIndex];
                    OutPatientDrugOrder drugOrder = ((OutPatientDrugOrder)outPatientDrugOrderRow.TTObject);
                    drugOrder.Material = drugDefinition;
                    if (drugDefinition.RouteOfAdmin != null && drugDefinition.RouteOfAdmin.DrugUsageType != null)
                        drugOrder.DrugUsageType = drugDefinition.RouteOfAdmin.DrugUsageType;
                    drugOrder.PeriodUnitType = PeriodUnitTypeEnum.DayPeriod;
                    drugOrder.Day = 1;
                    if (drugDefinition.Frequency != null)
                        drugOrder.Frequency = drugDefinition.Frequency;
                    if (drugDefinition.RoutineDose != null)
                        drugOrder.DoseAmount = drugDefinition.RoutineDose;
                }
            }
#endregion OutPatientPrescriptionForm_OutPatientDrugOrders_CellValueChanged
        }

        private void cmdAddDiagnosis_Click()
        {
#region OutPatientPrescriptionForm_cmdAddDiagnosis_Click
   /*TTVisual.TTForm addDiagnosisForm = new TTFormClasses.AddDiagnosisForm();
            addDiagnosisForm.ShowEdit(this.FindForm(), _OutPatientPrescription, true);*/
#endregion OutPatientPrescriptionForm_cmdAddDiagnosis_Click
        }

        private void cmdChangeSpeciality_Click()
        {
#region OutPatientPrescriptionForm_cmdChangeSpeciality_Click
   ResUser currentUser = Common.CurrentResource;
            List<SpecialityDefinition> specialityies = new List<SpecialityDefinition>();
            foreach (ResourceSpecialityGrid sGrid in currentUser.ResourceSpecialities)
            {
                if (sGrid.Speciality.ObjectID.Equals(_OutPatientPrescription.SpecialityDefinition.ObjectID) == false)
                {
                    if (specialityies.Contains(sGrid.Speciality) == false)
                        specialityies.Add(sGrid.Speciality);
                }
            }
            if (specialityies.Count > 0)
            {
                MultiSelectForm multiSelectForm = new MultiSelectForm();
                foreach (SpecialityDefinition speciality in specialityies)
                    multiSelectForm.AddMSItem(speciality.Code + " - " + speciality.Name, speciality.Name, speciality);

                string key = multiSelectForm.GetMSItem(ParentForm, "Uzmanlık dalı seçiniz", false, false, false, false, true, false);
                if (!string.IsNullOrEmpty(key))
                    _OutPatientPrescription.SpecialityDefinition = (SpecialityDefinition)multiSelectForm.MSSelectedItemObject;
            }
            else
                InfoBox.Show("Başka uzmanlık dalı tanımlı değil", MessageIconEnum.InformationMessage);
#endregion OutPatientPrescriptionForm_cmdChangeSpeciality_Click
        }

        private void PrescriptionType_SelectedIndexChanged()
        {
#region OutPatientPrescriptionForm_PrescriptionType_SelectedIndexChanged
   this.PrescriptionType.Enabled = false;
            int a = (int)_OutPatientPrescription.PrescriptionType.Value;
            string filiterExpration = "PRESCRIPTIONTYPE=" + a.ToString();

            if (SubEpisode.IsSGKSubEpisode(_OutPatientPrescription.SubEpisode))
            {
                filiterExpration = filiterExpration + " AND ISOLDMATERIAL = 0";
            }

            ((TTListBoxColumn)(this.OutPatientDrugOrders.Columns["PhysicianDrug"])).ListFilterExpression = filiterExpration;
#endregion OutPatientPrescriptionForm_PrescriptionType_SelectedIndexChanged
        }

        private void FavoriteDrugListview_DoubleClick()
        {
#region OutPatientPrescriptionForm_FavoriteDrugListview_DoubleClick
   Guid drugGuid = new Guid(this.FavoriteDrugListview.SelectedItems[0].SubItems[1].Text);
            _OutPatientPrescription.AddDrug(drugGuid);
#endregion OutPatientPrescriptionForm_FavoriteDrugListview_DoubleClick
        }

        private void DrugListview_DoubleClick()
        {
#region OutPatientPrescriptionForm_DrugListview_DoubleClick
   Guid drugGuid = new Guid(this.DrugListview.SelectedItems[0].SubItems[2].Text);
            _OutPatientPrescription.AddDrug(drugGuid);
#endregion OutPatientPrescriptionForm_DrugListview_DoubleClick
        }

        private void SearchTextbox_TextChanged()
        {
#region OutPatientPrescriptionForm_SearchTextbox_TextChanged
   DrugListview.Items.Clear();
            if (this.SearchTextbox.Text.Length > 2)
            {
                int a = (int)_OutPatientPrescription.PrescriptionType.Value;
                string filiterExpration = "AND PRESCRIPTIONTYPE=" + a.ToString();

                if (SubEpisode.IsSGKSubEpisode(_OutPatientPrescription.SubEpisode))
                {
                    filiterExpration = filiterExpration + " AND ISOLDMATERIAL = 0";
                }

                TTObjectContext context = new TTObjectContext(true);
                IBindingList drugs = context.QueryObjects("DRUGDEFINITION", "NAME_SHADOW like '" + this.SearchTextbox.Text + "%'" + filiterExpration);
                foreach (DrugDefinition drug in drugs)
                {
                    ITTListViewItem item = DrugListview.Items.Add(drug.Name);
                    item.SubItems.Add(drug.PharmacyInheldStatus);
                    item.SubItems.Add(drug.ObjectID.ToString());
                }
            }
#endregion OutPatientPrescriptionForm_SearchTextbox_TextChanged
        }

        protected override void PreScript()
        {
#region OutPatientPrescriptionForm_PreScript
    base.PreScript();
#endregion OutPatientPrescriptionForm_PreScript

            }
            
        protected override void ClientSidePreScript()
        {
#region OutPatientPrescriptionForm_ClientSidePreScript
    base.ClientSidePreScript();
            
            if (_OutPatientPrescription.Episode.PatientStatus == PatientStatusEnum.Discharge)
                _OutPatientPrescription.IsDischargePrescripiton = true;
            else if (_OutPatientPrescription.Episode.PatientStatus == PatientStatusEnum.Inpatient)
            {
                bool isDıschargeApp = false;
                foreach (InPatientTreatmentClinicApplication app in _OutPatientPrescription.Episode.InPatientTreatmentClinicApplications)
                {
                    if(app.CurrentStateDefID == InPatientTreatmentClinicApplication.States.Discharged)
                        isDıschargeApp = true;
                }
                if (isDıschargeApp)
                    _OutPatientPrescription.IsDischargePrescripiton = true;
                else
                {
                    if (_OutPatientPrescription.IsDischargePrescripiton.HasValue)
                    {
                        if (_OutPatientPrescription.IsDischargePrescripiton == false)
                            throw new Exception("Klinik işlemleri Taburcu durumunda olmadığı için taburcu reçetesi yazamazsınız. Klinik Taburcu işlemlerini tamamlayarak hasta çıkış bilgisini MEDULA'ya bildiriniz.");
                    }
                    else
                        throw new Exception("Klinik işlemleri Taburcu durumunda olmadığı için taburcu reçetesi yazamazsınız. Klinik Taburcu işlemlerini tamamlayarak hasta çıkış bilgisini MEDULA'ya bildiriniz.");
                }
            }


            if (SubEpisode.IsSGKSubEpisode(_OutPatientPrescription.SubEpisode))
            {

                ResUser currentUser = Common.CurrentResource;
                ((ITTObject)currentUser).Refresh();
                if (string.IsNullOrEmpty(currentUser.ErecetePassword))
                {
                   /* TTVisual.TTForm eRecetePasswordForm = new TTFormClasses.OutPatientPasswordForm();
                    eRecetePasswordForm.ShowEdit(this.FindForm(), _OutPatientPrescription, true);*/
                }
                else
                    _OutPatientPrescription.ERecetePassword = currentUser.ErecetePassword;

                if (currentUser.ResourceSpecialities.Count > 0)
                {
                    //ResourceSpecialities içerisinde MainSpeciality'i true olan Speciality'i SpecialityDefinition'a set ediyor. Eğer MainSpeciality hiçbir Speciality için true değil ise ResourceSpecialities
                    //içerisinde ilk sırada olan Speciality, SpecialityDefinition'a set ediliyor. /CKE
                    foreach (ResourceSpecialityGrid sGrid in currentUser.ResourceSpecialities)
                    {
                        if (sGrid.MainSpeciality != null && sGrid.MainSpeciality == true)
                        {
                            _OutPatientPrescription.SpecialityDefinition = sGrid.Speciality;
                        }
                        //                        else
                        //                        {
                        //                            _OutPatientPrescription.SpecialityDefinition = currentUser.ResourceSpecialities[0].Speciality;
                        //                        }
                    }
                }
                else
                    throw new Exception("Uzmanlık dalınız tanımlı olmadığı için e reçete yazamazsınız.");
            }
            else
            {
                this.SpecialityDefinition.Required = false;
                this.cmdChangeSpeciality.Enabled = false;
            }


            if (_OutPatientPrescription.PrescriptionType == null)
            {
                Array pValues = Enum.GetValues(typeof(PrescriptionTypeEnum));
                MultiSelectForm multiSelectForm = new MultiSelectForm();
                foreach (PrescriptionTypeEnum pType in pValues)
                {
                    if (pType.Equals(PrescriptionTypeEnum.NormalPrescription))
                        multiSelectForm.AddMSItem("1 Normal Reçete", "Normal Reçete", pType);
                    else if (pType.Equals(PrescriptionTypeEnum.RedPrescription))
                        multiSelectForm.AddMSItem("2 Kırmızı Reçete", "Kırmızı Reçete", pType);
                    else if (pType.Equals(PrescriptionTypeEnum.GreenPrescription))
                        multiSelectForm.AddMSItem("3 Yeşil Reçete", "Yeşil Reçete", pType);
                    else if (pType.Equals(PrescriptionTypeEnum.PurplePrescription))
                        multiSelectForm.AddMSItem("4 Mor Reçete", "Mor Reçete", pType);
                    else if (pType.Equals(PrescriptionTypeEnum.OrangePrescription))
                        multiSelectForm.AddMSItem("5 Turuncu Reçete", "Turuncu Reçete", pType);
                    else if (pType.Equals(PrescriptionTypeEnum.ControlledPrescription))
                        multiSelectForm.AddMSItem("6 Kontrollü Reçete", "Kontrollü Reçete", pType);
                }
                string key = multiSelectForm.GetMSItem(ParentForm, "Reçete Tipi seçiniz", false, false, false, false, true);
                if (!string.IsNullOrEmpty(key))
                    _OutPatientPrescription.PrescriptionType = (PrescriptionTypeEnum)multiSelectForm.MSSelectedItemObject;
                else
                    throw new TTUtils.TTException("Reçete işleminden vazgeçildi.");
            }

            IList presTypeMaterialMatch = _OutPatientPrescription.ObjectContext.QueryObjects("PRESTYPEMATERIALMATCHDEF", "PRESCRIPTIONTYPE =" + ((int)_OutPatientPrescription.PrescriptionType).ToString());
            if (presTypeMaterialMatch.Count > 0)
            {
                if (_OutPatientPrescription.MasterResource.Store == null)
                    throw new TTException(_OutPatientPrescription.MasterResource.Name + " bölümünün deposu bulunmamaktadır. Bilgi işleme haber veriniz.");
                this.PrescriptionPaper.Required = true;
                PrescriptionPaper.ListFilterExpression = "STOCK.STORE=" + ConnectionManager.GuidToString(_OutPatientPrescription.MasterResource.Store.ObjectID) + " AND STOCK.MATERIAL =" + ConnectionManager.GuidToString(((PresTypeMaterialMatchDef)presTypeMaterialMatch[0]).Material.ObjectID);
            }
            else
                this.PrescriptionPaper.ReadOnly = true;


            IBindingList drugs = FavoriteDrug.GetFavoriteDrugs(((ResUser)Common.CurrentUser.UserObject).ObjectID);

            foreach (FavoriteDrug.GetFavoriteDrugs_Class d in drugs)
            {
                ITTListViewItem item = FavoriteDrugListview.Items.Add(d.Name);
                item.SubItems.Add(d.DrugDefinition.ToString());
            }

            //IBindingList drugs = _OutPatientPrescription.ObjectContext.QueryObjects("FAVORITEDRUG", "RESUSER =" + ConnectionManager.GuidToString(((ResUser)Common.CurrentUser.UserObject).ObjectID));
            //Hashtable unSortedFavoriteDrugList = new Hashtable();
            //foreach (FavoriteDrug favoriteDrug in drugs)
            //{
            //    if (unSortedFavoriteDrugList.ContainsKey(favoriteDrug.DrugDefinition) == false)
            //    {
            //        Common.TTDoubleSortableList favoriteDrugListItem = new Common.TTDoubleSortableList();
            //        favoriteDrugListItem.ID = favoriteDrug.DrugDefinition;
            //        favoriteDrugListItem.Value = (double)favoriteDrug.Count;
            //        unSortedFavoriteDrugList.Add(favoriteDrugListItem.ID, favoriteDrugListItem);
            //    }

            //}

            //List<Common.TTDoubleSortableList> favoriteDrugList = Common.SortedDoubleItems(unSortedFavoriteDrugList);
            //favoriteDrugList.Reverse();
            //foreach (Common.TTDoubleSortableList sortList in favoriteDrugList)
            //{
            //    ITTListViewItem item = FavoriteDrugListview.Items.Add(((DrugDefinition)sortList.ID).Name);
            //    item.SubItems.Add(((DrugDefinition)sortList.ID).ObjectID.ToString());
            //}



            /*if (_OutPatientPrescription.Episode.Patient.PatientGroup == PatientGroupEnum.PrivateNonCom)
            {

                this.DropStateButton(OutPatientPrescription.States.Completed);
                this.DropStateButton(OutPatientPrescription.States.CompletedWithSign);
            }
            else
            {
                this.DropStateButton(OutPatientPrescription.States.DrugControl);
            }*/

            //            if (_OutPatientPrescription.Episode.Patient.PatientGroup == PatientGroupEnum.CivilCadetCandidate || _OutPatientPrescription.Episode.Patient.PatientGroup == PatientGroupEnum.CivilianConsignment)
            //            {
            //                this.DropStateButton(OutPatientPrescription.States.DrugControl);
            //            }
            //            else
            //            {
            //                this.DropStateButton(OutPatientPrescription.States.Completed);
            //            }

            if (_OutPatientPrescription.Episode.Diagnosis.Count == 0)
            {
                throw new TTException(SystemMessage.GetMessage(1213));
            }
            else
            {
                //Dictionary<Guid, string> diagForPres = new Dictionary<Guid, string>();
                //Dictionary<Guid, SPTSDiagnosisInfo> diagnosisInfo = new Dictionary<Guid, SPTSDiagnosisInfo>();
                List<DiagnosisDefinition> diagnosises = new List<DiagnosisDefinition>();

                //                foreach (EpisodeAction episodeAction in _OutPatientPrescription.Episode.EpisodeActions)
                //                {
                //                    if(episodeAction is PatientExamination)
                //                    {
                //                        foreach (DiagnosisGrid diag in ((PatientExamination)episodeAction).Diagnosis)
                //                        {
                //                            if (diagnosises.Contains(diag.Diagnose) == false)
                //                                diagnosises.Add(diag.Diagnose);
                //                        }
                //                    }
                //                }

                foreach (DiagnosisGrid diag in _OutPatientPrescription.Episode.Diagnosis)
                {
                    if (diagnosises.Contains(diag.Diagnose) == false)
                        diagnosises.Add(diag.Diagnose);
                }
                if (diagnosises.Count > 0)
                {
                    foreach (DiagnosisDefinition dia in diagnosises)
                    {
                        DiagnosisForPresc diagnosisForPresc = new DiagnosisForPresc(_OutPatientPrescription.ObjectContext);
                        diagnosisForPresc.Check = true;
                        diagnosisForPresc.Code = dia.Code;
                        diagnosisForPresc.Name = dia.Name;
                        diagnosisForPresc.Prescription = _OutPatientPrescription;
                    }
                }
            }

              
            IList pharmacyStore = PharmacyStoreDefinition.GetInpatientPharmacyStore(_OutPatientPrescription.ObjectContext);
            if (pharmacyStore.Count == 1)
            {
                PharmacyStoreDefinition store = (PharmacyStoreDefinition)pharmacyStore[0];
                IList pharmacyResource = Resource.GetResourceByStore(_OutPatientPrescription.ObjectContext, store.ObjectID);
                if (pharmacyResource.Count == 1)
                {
                    _OutPatientPrescription.MasterResource = (ResSection)pharmacyResource[0];
                }
                else if (pharmacyResource.Count > 1)
                {
                    throw new Exception(SystemMessage.GetMessage(1008));
                }
            }
                
     
       
#endregion OutPatientPrescriptionForm_ClientSidePreScript

        }

        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region OutPatientPrescriptionForm_PostScript
    base.PostScript(transDef);

            OutPatientPrescription outPatientPrescription = (OutPatientPrescription)this._ttObject;
            foreach (OutPatientDrugOrder outPatientDrugOrder in outPatientPrescription.OutPatientDrugOrders)
            {
                outPatientDrugOrder.CurrentStateDefID = OutPatientDrugOrder.States.New;
                outPatientDrugOrder.Episode = this._OutPatientPrescription.Episode;
                if (outPatientDrugOrder.Amount == null)
                    outPatientDrugOrder.Amount = outPatientDrugOrder.RequiredAmount;
            }
#endregion OutPatientPrescriptionForm_PostScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region OutPatientPrescriptionForm_ClientSidePostScript
    base.ClientSidePostScript(transDef);
            
            
            if (transDef != null )
            {
                if (transDef.FromStateDefID == OutPatientPrescription.States.Request && transDef.ToStateDefID == OutPatientPrescription.States.CompletedWithSign)
                {
                    if (SubEpisode.IsSGKSubEpisode(_OutPatientPrescription.SubEpisode) && this.EReceteNo == null)
                    {
                        if (_OutPatientPrescription.SubEpisode.SGKSEP != null && !string.IsNullOrEmpty(_OutPatientPrescription.SubEpisode.SGKSEP.MedulaTakipNo))
                        {
                            if (string.IsNullOrEmpty(_Prescription.ERecetePassword))
                                throw new TTException("E Reçete şifrenizi giriniz");

//                            EReceteIslemleri.imzaliEreceteGirisCevapDVO response = EReceteIslemleri.WebMethods.imzaliEreceteGirisSync(Sites.SiteLocalHost, Common.CurrentResource.UniqueNo.ToString(), _OutPatientPrescription.ERecetePassword.ToString(), PrescriptionBaseForm.GetEReceteSignedInputRequest(_OutPatientPrescription));
//                            if (response != null)
//                            {
//                                if (response.sonucKodu.Equals("0000"))
//                                {
//                                    InfoBox.Alert(response.ereceteDVO.ereceteNo.ToString() + " e reçete numarası ile reçete kaydedilmiştir.", MessageIconEnum.InformationMessage);
//                                    _OutPatientPrescription.EReceteNo = response.ereceteDVO.ereceteNo;
//                                    _OutPatientPrescription.EReceteDescription = " E Reçete başarılı bir şekilde kaydedilmiştir.";
//
//                                    if (_Prescription.SubEpisode.SGKSEP.MedulaTedaviTuru.tedaviTuruAdi == "Günübirlik Tedavi")
//                                    {
//                                        ResUser currentUser = (ResUser)Common.CurrentUser.UserObject;
//                                       SendEreceteSignedDailyPresApproval(currentUser);
//                                    }
//                                }
//                                else
//                                {
//                                    if (!string.IsNullOrEmpty(response.uyariMesaji))
//                                        throw new TTException("e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji + "\n\r e-Reçete ServisindenGelen Uyarı Mesajı :" + response.uyariMesaji);
//                                    else
//                                        throw new TTException("e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji);
//
//                                }
//                            }
                        }
                        else
                            throw new TTException("Hastaya Medula Provizyon Alınmadığında Dolayı e-Reçete Kaydı Yapılamamıştır.");
                    }
                }
            }
#endregion OutPatientPrescriptionForm_ClientSidePostScript

        }

#region OutPatientPrescriptionForm_ClientSideMethods
        public void SendEreceteSignedDailyPresApproval(ResUser currentUser)
        {
            long uniqueNo = (long)Convert.ToDouble(currentUser.UniqueNo);
//            EReceteIslemleri.imzaliEreceteOnayCevapDVO dailyPresOnay = EReceteIslemleri.WebMethods.imzaliEreceteOnaySync(Sites.SiteLocalHost, currentUser.UniqueNo.ToString(), _OutPatientPrescription.ERecetePassword.ToString(), PrescriptionBaseForm.GetEreceteSignedDailyPresApprovalRequest(_OutPatientPrescription, uniqueNo));
//            if (dailyPresOnay != null)
//            {
//                if (dailyPresOnay.sonucKodu.Equals("0000"))
//                {
//                    InfoBox.Alert(_OutPatientPrescription.EReceteNo.ToString() + " e reçete numarası ile reçete Günübirlik Hasta onayı alınmıştır.", MessageIconEnum.InformationMessage);
//                    _OutPatientPrescription.EReceteDescription = " E Reçete başarılı bir şekilde Günübirlik Hasta onayı almıştır.";
//                }
//                else
//                {
//                    if (!string.IsNullOrEmpty(dailyPresOnay.uyariMesaji))
//                        throw new TTException("e-Reçete Servisinden Gelen Sonuç Mesajı : " + dailyPresOnay.sonucMesaji + "\n\r e-Reçete ServisindenGelen Uyarı Mesajı :" + dailyPresOnay.uyariMesaji);
//                    else
//                        throw new TTException("e-Reçete Servisinden Gelen Sonuç Mesajı : " + dailyPresOnay.sonucMesaji);
//                }
//            }
        }
        
#endregion OutPatientPrescriptionForm_ClientSideMethods
    }
}