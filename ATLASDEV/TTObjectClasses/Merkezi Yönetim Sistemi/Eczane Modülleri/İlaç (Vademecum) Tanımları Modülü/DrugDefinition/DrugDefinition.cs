
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



using TTStorageManager;
using System.Runtime.Versioning;


namespace TTObjectClasses
{
    /// <summary>
    /// İlaç Tanımı
    /// </summary>
    public partial class DrugDefinition : Material
    {
        public partial class GetDrugsHavingEquivalentReportQuery_Class : TTReportNqlObject
        {
        }

        public partial class GetDrugNonDependBarcodeReportQuery_Class : TTReportNqlObject
        {
        }

        public partial class GetPharmacyStoreInheldReportQuery_Class : TTReportNqlObject
        {
        }

        public partial class GetDrugsHavingNoEquivalentReportQuery_Class : TTReportNqlObject
        {
        }

        public partial class GetDrugListVademecumReportQuery_Class : TTReportNqlObject
        {
        }

        public partial class GetDrugDefinitions_Class : TTReportNqlObject
        {
        }

        public partial class GetDrugDefinitionByEquivalentReportQuery_Class : TTReportNqlObject
        {
        }

        public partial class GetDrugDefByEtkinMaddeKodu_Class : TTReportNqlObject
        {
        }



        public static string GetSgkReturnPayText(bool? SgkReturnPayNullableValue)
        {
            if (SgkReturnPayNullableValue == null)
            {
                return TTUtils.CultureService.GetText("M30016", "Belirsiz");
            }
            else if (SgkReturnPayNullableValue == true)
            {
                return TTUtils.CultureService.GetText("M30014", "Sgk Karşılıyor");
            }
            else
            {
                return TTUtils.CultureService.GetText("M30015", "Sgk Karşılamıyor");
            }
        }

        public string PharmacyInheldStatus
        {
            get
            {
                try
                {
                    bool showPharmacyStockInHeld = Boolean.Parse(TTObjectClasses.SystemParameter.GetParameterValue("SHOWPHARMACYSTOCKINHELD", "FALSE"));

                    #region PharmacyInheldStatus_GetScript                    
                    if (TTObjectClasses.SystemParameter.IsWorkWithOutStock == false)
                    {
                        string inheldStatus = TTUtils.CultureService.GetText("M24703", "Yok");
                        double inheld = 0;
                        Store pharmacy = Store.GetPharmacyStore(ObjectContext);

                        if (pharmacy != null)
                        {
                            foreach (Stock stock in Stocks.Select("STORE='" + pharmacy.ObjectID.ToString() + "'"))
                            {
                                inheld += stock.Inheld.Value;
                            }
                        }
                        else
                        {
                            throw new Exception(SystemMessage.GetMessage(582));
                        }

                        if (showPharmacyStockInHeld)
                        {
                            inheldStatus = inheld.ToString();
                        }
                        else if (inheld > 0)
                        {
                            inheldStatus = "Var";
                        }

                        if (ShowZeroOnDrugOrder != null && ShowZeroOnDrugOrder.Value)
                        {
                            inheldStatus = "0";
                            if (!showPharmacyStockInHeld)
                                inheldStatus = TTUtils.CultureService.GetText("M24703", "Yok");
                        }

                        return inheldStatus;
                    }
                    else
                    {
                        string inheldStatus = TTUtils.CultureService.GetText("M24703", "Yok");
                        if ((bool)WithOutStockInheld.HasValue)
                        {
                            if ((bool)WithOutStockInheld)
                            {
                                inheldStatus = "Var";
                            }
                            else
                            {
                                inheldStatus = TTUtils.CultureService.GetText("M24703", "Yok");
                            }
                        }
                        else
                        {
                            inheldStatus = TTUtils.CultureService.GetText("M24703", "Yok");
                        }

                        return inheldStatus;
                    }
                    #endregion PharmacyInheldStatus_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "PharmacyInheldStatus") + " : " + ex.Message, ex);
                }
            }
        }

        public string IlacTuru
        {
            get
            {
                try
                {
                    #region IlacTuru_GetScript                    
                    if (this is MagistralPreparationDefinition)
                        return "2";
                    else
                        return "1";
                    #endregion IlacTuru_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "IlacTuru") + " : " + ex.Message, ex);
                }
            }
        }

        public string OutPatientPharInheldStatus
        {
            get
            {
                try
                {
                    #region OutPatientPharInheldStatus_GetScript                    
                    if (TTObjectClasses.SystemParameter.IsWorkWithOutStock == false)
                    {
                        string inheldStatus = TTUtils.CultureService.GetText("M24703", "Yok");
                        IList pharmacy = PharmacyStoreDefinition.GetOutpatientPharmacyStore(ObjectContext);
                        if (pharmacy.Count > 0)
                        {
                            foreach (Stock stock in Stocks.Select("STORE='" + ((PharmacyStoreDefinition)pharmacy[0]).ObjectID.ToString() + "'"))
                            {
                                if (stock.Inheld > 0)
                                {
                                    inheldStatus = "Var";
                                    break;
                                }
                            }
                            return inheldStatus;
                        }
                        else
                        {
                            Store inpharmacy = Store.GetPharmacyStore(ObjectContext);
                            if (inpharmacy!= null)
                            {
                                foreach (Stock stock in Stocks.Select("STORE='" + inpharmacy.ObjectID.ToString() + "'"))
                                {
                                    if (stock.Inheld > 0)
                                    {
                                        inheldStatus = "Var";
                                        break;
                                    }
                                }
                                return inheldStatus;
                            }
                            else
                            {
                                throw new Exception(SystemMessage.GetMessage(583));
                                //return inheldStatus;
                            }
                        }
                    }
                    else
                    {
                        string inheldStatus = TTUtils.CultureService.GetText("M24703", "Yok");
                        if ((bool)WithOutStockInheld.HasValue)
                        {
                            if ((bool)WithOutStockInheld)
                            {
                                inheldStatus = "Var";
                            }
                            else
                            {
                                inheldStatus = TTUtils.CultureService.GetText("M24703", "Yok");
                            }
                        }
                        else
                        {
                            inheldStatus = TTUtils.CultureService.GetText("M24703", "Yok");
                        }

                        return inheldStatus;
                    }
                    #endregion OutPatientPharInheldStatus_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "OutPatientPharInheldStatus") + " : " + ex.Message, ex);
                }
            }
        }

        protected override void PreInsert()
        {
            #region PreInsert

            base.PreInsert();



            #endregion PreInsert
        }

        protected override void PreUpdate()
        {
            #region PreUpdate


            base.PreUpdate();

            //            foreach (ManuelEquivalentDrug equivalentDrug in this.ManuelEquivalentDrugs)
            //            {
            //                ITTObject ttObject = (ITTObject)equivalentDrug;
            //                if (ttObject.IsNew)
            //                {
            //
            //                }
            //            }


            #endregion PreUpdate
        }

        #region Methods
        public override SendDataTypesEnum? GetMySendDataTypesEnum()
        {
            return SendDataTypesEnum.DrugDefinitionInfo;
        }

        public override List<string> GetMyLocalPropertyNamesList()
        {
            List<string> localPropertyNamesList = base.GetMyLocalPropertyNamesList();
            if (localPropertyNamesList == null)
                localPropertyNamesList = new List<string>();
            localPropertyNamesList.Add("PURCHASEDATE");
            return localPropertyNamesList;
        }

        public IList EquivalentDrugs
        {
            get
            {
                IList retvalue = new List<DrugDefinition>();
                TTObjectContext context = new TTObjectContext(true);
                foreach (DrugDefinition drugDefinition in DrugDefinition.GetDrugDefinitionByEquivalentCRC(context, EquivalentCRC))
                {
                    if (drugDefinition.ObjectID.Equals(ObjectID) == false)
                        retvalue.Add(drugDefinition);
                }
                return retvalue;
            }
        }

        public IList GetEquivalentDrugs()
        {
            IList equivalentDrugs = new List<DrugDefinition>();
            string equivalentMode = SystemParameter.GetParameterValue("DRUGEQUIVALENTMODE", "NORMAL");
            if (equivalentMode == "NORMAL")
            {
                equivalentDrugs = EquivalentDrugs;
            }
            else
            {
                foreach (DrugRelation equivalent in DrugRelations)
                    equivalentDrugs.Add(equivalent.DrugDefinition);
            }

            foreach (ManuelEquivalentDrug manuel in ManuelEquivalentDrugs)
                equivalentDrugs.Add(manuel.EquivalentDrug);

            return equivalentDrugs;
        }

        public override BaseSKRSDefinition GetSKRSDefinition()
        {
            BindingList<SKRSIlac> SKRSIlacList = SKRSIlac.GetByBarkodu(ObjectContext, Barcode);
            if (SKRSIlacList.Count > 0)
                return SKRSIlacList[0];
            return null;
        }

        #endregion Methods

    }
}