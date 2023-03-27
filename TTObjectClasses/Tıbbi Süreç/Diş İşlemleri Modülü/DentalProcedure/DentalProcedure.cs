
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
    public partial class DentalProcedure : SubactionProcedureWithDiagnosis
    {
        public partial class GetDentalProceduresByEpisodeAction_Class : TTReportNqlObject
        {
        }

        public partial class GetDentalProcedureByProcedureDoctorSection_Class : TTReportNqlObject
        {
        }

        public partial class VEM_HASTA_DIS_Class : TTReportNqlObject
        {
        }

        /// <summary>
        /// Medula Sağ Alt Çene Bilgisi
        /// </summary>
        public string sagAltCene
        {
            get
            {
                try
                {
                    #region sagAltCene_GetScript                    
                    // 41, 42, 43, 44, 45, 46, 47, 48  nolu dişler Sağ Alt Çene

                    string teeth = "________";

                    switch ((int)ToothNumber)
                    {
                        case 40:
                        case 3040:
                        case 1234:
                            teeth = "EEEEEEEE";
                            break;
                        case 41:
                            teeth = "E_______";
                            break;
                        case 42:
                            teeth = "_E______";
                            break;
                        case 43:
                            teeth = "__E_____";
                            break;
                        case 44:
                            teeth = "___E____";
                            break;
                        case 45:
                            teeth = "____E___";
                            break;
                        case 46:
                            teeth = "_____E__";
                            break;
                        case 47:
                            teeth = "______E_";
                            break;
                        case 48:
                            teeth = "_______E";
                            break;
                        default:
                            break;
                    }

                    return teeth;
                    #endregion sagAltCene_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "sagAltCene") + " : " + ex.Message, ex);
                }
            }
        }

        /// <summary>
        /// Medula Sağ Ãœst Çene Bilgisi
        /// </summary>
        public string sagUstCene
        {
            get
            {
                try
                {
                    #region sagUstCene_GetScript                    
                    // 11, 12, 13, 14, 15, 16, 17, 18  nolu dişler Sağ Ãœst Çene

                    string teeth = "________";

                    switch ((int)ToothNumber)
                    {
                        case 10:
                        case 1020:
                        case 1234:
                            teeth = "EEEEEEEE";
                            break;
                        case 11:
                            teeth = "E_______";
                            break;
                        case 12:
                            teeth = "_E______";
                            break;
                        case 13:
                            teeth = "__E_____";
                            break;
                        case 14:
                            teeth = "___E____";
                            break;
                        case 15:
                            teeth = "____E___";
                            break;
                        case 16:
                            teeth = "_____E__";
                            break;
                        case 17:
                            teeth = "______E_";
                            break;
                        case 18:
                            teeth = "_______E";
                            break;
                        default:
                            break;
                    }

                    return teeth;
                    #endregion sagUstCene_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "sagUstCene") + " : " + ex.Message, ex);
                }
            }
        }

        /// <summary>
        /// Medula Sol Ãœst Çene Bilgisi
        /// </summary>
        public string solUstCene
        {
            get
            {
                try
                {
                    #region solUstCene_GetScript                    
                    // 21, 22, 23, 24, 25, 26, 27, 28  nolu dişler Sol Ãœst Çene

                    string teeth = "________";

                    switch ((int)ToothNumber)
                    {
                        case 20:
                        case 1020:
                        case 1234:
                            teeth = "EEEEEEEE";
                            break;
                        case 21:
                            teeth = "E_______";
                            break;
                        case 22:
                            teeth = "_E______";
                            break;
                        case 23:
                            teeth = "__E_____";
                            break;
                        case 24:
                            teeth = "___E____";
                            break;
                        case 25:
                            teeth = "____E___";
                            break;
                        case 26:
                            teeth = "_____E__";
                            break;
                        case 27:
                            teeth = "______E_";
                            break;
                        case 28:
                            teeth = "_______E";
                            break;
                        default:
                            break;
                    }

                    return teeth;
                    #endregion solUstCene_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "solUstCene") + " : " + ex.Message, ex);
                }
            }
        }

        /// <summary>
        /// Medula Sağ Süt Ãœst Çene Bilgisi
        /// </summary>
        public string sagSutUstCene
        {
            get
            {
                try
                {
                    #region sagSutUstCene_GetScript                    
                    // 51, 52, 53, 54, 55  nolu dişler Sağ Süt Ãœst Çene

                    string teeth = "_____";

                    switch ((int)ToothNumber)
                    {
                        case 50:
                        case 5060:
                        case 5678:
                            teeth = "EEEEE";
                            break;
                        case 51:
                            teeth = "E____";
                            break;
                        case 52:
                            teeth = "_E___";
                            break;
                        case 53:
                            teeth = "__E__";
                            break;
                        case 54:
                            teeth = "___E_";
                            break;
                        case 55:
                            teeth = "____E";
                            break;
                        default:
                            break;
                    }

                    return teeth;
                    #endregion sagSutUstCene_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "sagSutUstCene") + " : " + ex.Message, ex);
                }
            }
        }

        /// <summary>
        /// Medula Sol Alt Çene Bilgisi
        /// </summary>
        public string solAltCene
        {
            get
            {
                try
                {
                    #region solAltCene_GetScript                    
                    // 31, 32, 33, 34, 35, 36, 37, 38  nolu dişler Sol Alt Çene

                    string teeth = "________";

                    switch ((int)ToothNumber)
                    {
                        case 30:
                        case 3040:
                        case 1234:
                            teeth = "EEEEEEEE";
                            break;
                        case 31:
                            teeth = "E_______";
                            break;
                        case 32:
                            teeth = "_E______";
                            break;
                        case 33:
                            teeth = "__E_____";
                            break;
                        case 34:
                            teeth = "___E____";
                            break;
                        case 35:
                            teeth = "____E___";
                            break;
                        case 36:
                            teeth = "_____E__";
                            break;
                        case 37:
                            teeth = "______E_";
                            break;
                        case 38:
                            teeth = "_______E";
                            break;
                        default:
                            break;
                    }

                    return teeth;
                    #endregion solAltCene_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "solAltCene") + " : " + ex.Message, ex);
                }
            }
        }

        /// <summary>
        /// Medula Sağ Süt Alt Çene Bilgisi
        /// </summary>
        public string sagSutAltCene
        {
            get
            {
                try
                {
                    #region sagSutAltCene_GetScript                    
                    // 81, 82, 83, 84, 85  nolu dişler Sağ Süt Alt Çene

                    string teeth = "_____";

                    switch ((int)ToothNumber)
                    {
                        case 80:
                        case 7080:
                        case 5678:
                            teeth = "EEEEE";
                            break;
                        case 81:
                            teeth = "E____";
                            break;
                        case 82:
                            teeth = "_E___";
                            break;
                        case 83:
                            teeth = "__E__";
                            break;
                        case 84:
                            teeth = "___E_";
                            break;
                        case 85:
                            teeth = "____E";
                            break;
                        default:
                            break;
                    }

                    return teeth;
                    #endregion sagSutAltCene_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "sagSutAltCene") + " : " + ex.Message, ex);
                }
            }
        }

        /// <summary>
        /// Medula Sol Süt Alt Çene Bilgisi
        /// </summary>
        public string solSutAltCene
        {
            get
            {
                try
                {
                    #region solSutAltCene_GetScript                    
                    // 71, 72, 73, 74, 75  nolu dişler Sol Süt Alt Çene

                    string teeth = "_____";

                    switch ((int)ToothNumber)
                    {
                        case 70:
                        case 7080:
                        case 5678:
                            teeth = "EEEEE";
                            break;
                        case 71:
                            teeth = "E____";
                            break;
                        case 72:
                            teeth = "_E___";
                            break;
                        case 73:
                            teeth = "__E__";
                            break;
                        case 74:
                            teeth = "___E_";
                            break;
                        case 75:
                            teeth = "____E";
                            break;
                        default:
                            break;
                    }

                    return teeth;
                    #endregion solSutAltCene_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "solSutAltCene") + " : " + ex.Message, ex);
                }
            }
        }

        /// <summary>
        /// Medula Sol Süt Ãœst Çene Bilgisi
        /// </summary>
        public string solSutUstCene
        {
            get
            {
                try
                {
                    #region solSutUstCene_GetScript                    
                    // 61, 62, 63, 64, 65  nolu dişler Sol Süt Ãœst Çene

                    string teeth = "_____";

                    switch ((int)ToothNumber)
                    {
                        case 60:
                        case 5060:
                        case 5678:
                            teeth = "EEEEE";
                            break;
                        case 61:
                            teeth = "E____";
                            break;
                        case 62:
                            teeth = "_E___";
                            break;
                        case 63:
                            teeth = "__E__";
                            break;
                        case 64:
                            teeth = "___E_";
                            break;
                        case 65:
                            teeth = "____E";
                            break;
                        default:
                            break;
                    }

                    return teeth;
                    #endregion solSutUstCene_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "solSutUstCene") + " : " + ex.Message, ex);
                }
            }
        }

        /// <summary>
        /// Medula anomali bilgisi
        /// </summary>
        public string anomali
        {
            get
            {
                try
                {
                    #region anomali_GetScript                    
                    // Medula kullanım kılavuzunda "Daha sonra kullanım amacı tanımlanacaktır" diyor. 
                    // Zorunlu alan da değil. Bu yüzden null döndürüyoruz şimdilik.
                    return null;
                    #endregion anomali_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "anomali") + " : " + ex.Message, ex);
                }
            }
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            switch (memberName)
            {
                case "TOOTHNUMBER":
                    {
                        ToothNumberEnum? value = (ToothNumberEnum?)(int?)newValue;
                        #region TOOTHNUMBER_SetScript
                        if (value.HasValue)
                        {
                            DentalPosition = Common.SetDentalPosition((int)value);
                        }
                        #endregion TOOTHNUMBER_SetScript
                    }
                    break;

                default:
                    base.RunSetMemberValueScript(memberName, newValue);
                    break;

            }
        }

        protected override void PreInsert()
        {
            #region PreInsert
            base.PreInsert();

            #endregion PreInsert
        }

        protected override void PostInsert()
        {
            #region PostInsert
            SetPerformedDate();
            base.PostInsert();

            if (ToothNumber != null)
            {
                foreach (AccountTransaction AccTrx in AccountTransactions)
                {
                    if (AccTrx.CurrentStateDefID != AccountTransaction.States.Cancelled)
                    {
                        if (AccTrx.Description.IndexOf(" (Diş No: ") == -1) // Yeni ekleme
                            AccTrx.Description = AccTrx.Description + " (Diş No: " + Common.GetEnumValueDefOfEnumValue(ToothNumber.Value).DisplayText + ")";
                        else
                        {
                            // ToothNumber değişmişse AccTrx i de güncelleme
                            if (AccTrx.Description.IndexOf(" (Diş No: " + Common.GetEnumValueDefOfEnumValue(ToothNumber.Value).DisplayText + ")") == -1)
                                AccTrx.Description = AccTrx.Description.Substring(0, AccTrx.Description.IndexOf(" (Diş No: ")) + " (Diş No: " + Common.GetEnumValueDefOfEnumValue(ToothNumber.Value).DisplayText + ")";
                        }
                    }
                }

                ExtraDescription = "(Diş No: " + Common.GetEnumValueDefOfEnumValue(ToothNumber.Value).DisplayText + ")";
            }
            else
                ExtraDescription = null;

            #endregion PostInsert
        }

        protected override void PostUpdate()
        {
            #region PostUpdate
            SetPerformedDate();
            base.PostUpdate();

            // hasta payı check ini kaldırıp diş numarasını değiştirdikten sonra kaydete bastığında iptal edilen kurum payını yeni ye çevirirken
            // hata veriyor. Çevirme işini dentalProcedure deki TurnMyAccTrxsToPatientOrPayerShare metodu yapıyor.
            /*foreach(AccountTransaction AccTrx in this.AccountTransactions)
            {
                if (AccTrx.CurrentStateDefID != AccountTransaction.States.Cancelled && this.ToothNumber != null)
                {
                    if(AccTrx.Description.IndexOf(" (Diş No: ") == -1) // Yeni ekleme
                        AccTrx.Description = AccTrx.Description + " (Diş No: " + Common.GetEnumValueDefOfEnumValue(this.ToothNumber.Value).DisplayText + ")";
                    else
                    {
                        // ToothNumber değişmişse AccTrx i de güncelleme
                        if (AccTrx.Description.IndexOf(" (Diş No: " + Common.GetEnumValueDefOfEnumValue(this.ToothNumber.Value).DisplayText + ")") == -1)
                            AccTrx.Description = AccTrx.Description.Substring(0, AccTrx.Description.IndexOf(" (Diş No: ")) + " (Diş No: " + Common.GetEnumValueDefOfEnumValue(this.ToothNumber.Value).DisplayText + ")";
                    }
                }
            }*/

            if (ToothNumber != null)
                ExtraDescription = "(Diş No: " + Common.GetEnumValueDefOfEnumValue(ToothNumber.Value).DisplayText + ")";
            else
                ExtraDescription = null;

            #endregion PostUpdate
        }

        protected void UndoTransition_New2Completed(TTObjectStateTransitionDef transitionDef)
        {
            // From State : New   To State : Completed
            #region UndoTransition_New2Completed
            //this.CancelMyAccountTransactions();
            #endregion UndoTransition_New2Completed
        }

        #region Methods
      
        public override string GetDVOAnomali()
        {
            return Anomali == true ? "E" : "H";
        }

        //public override string GetDVOAyniFarkliKesi()
        //{
        //    return AyniFarkliKesi?.ayniFarkliKesiKodu;
        //}

        public override int? GetDVODisTaahhutNo()
        {
            return DisTaahhutNo;
        }

        public override void GetDVOSetCeneBilgisi(HizmetKayitIslemleri.disBilgisiDVO disBilgisiDVO)
        {
            List<int> listEriskin = new List<int>();
            List<int> listSut = new List<int>();
            List<int> listAnomali = new List<int>();
            List<int> listCene = new List<int>();

            if (ToothNumber != null)
            {
                if (Convert.ToInt32(ToothNumber.Value) >= 11 && Convert.ToInt32(ToothNumber.Value) <= 48)
                    listEriskin.Add(Convert.ToInt32(ToothNumber.Value));
                else if (Convert.ToInt32(ToothNumber.Value) >= 51 && Convert.ToInt32(ToothNumber.Value) <= 85)
                    listSut.Add(Convert.ToInt32(ToothNumber.Value));
                else if (Convert.ToInt32(ToothNumber.Value) >= 91 && Convert.ToInt32(ToothNumber.Value) <= 94)
                    listAnomali.Add(Convert.ToInt32(ToothNumber.Value));
                else if (Convert.ToInt32(ToothNumber.Value) >= 1 && Convert.ToInt32(ToothNumber.Value) <= 7)
                    listCene.Add(Convert.ToInt32(ToothNumber.Value));
            }

            setEriskinDisler(listEriskin.ToArray(), disBilgisiDVO);
            setSutDisler(listSut.ToArray(), disBilgisiDVO);
            setAnomaliDisler(listAnomali.ToArray(), disBilgisiDVO);
            setCeneDisler(listCene.ToArray(), disBilgisiDVO);
        }

        //Erişkin dişlerin string scheması oluşturulur.
        public void setEriskinDisler(int[] str, HizmetKayitIslemleri.disBilgisiDVO disBilgisiDVO)
        {
            String[] eDis = new String[32];
            disBilgisiDVO.sagUstCene = "";
            disBilgisiDVO.solUstCene = "";
            disBilgisiDVO.solAltCene = "";
            disBilgisiDVO.sagAltCene = "";

            for (int i = 0; i < eDis.Length; i++)
                eDis[i] = "_";

            for (int j = 0; j < str.Length; j++)
            {
                for (int k = 11, l = 0; k <= eDis.Length + 16 && l < eDis.Length; k++, l++)
                {
                    if (k == 18 || k == 28 || k == 38 || k == 48)
                    {
                        if (str[j] == k)
                        {
                            eDis[l] = "E";
                            break;
                        }
                        k = k + 2;
                    }
                    else
                    {
                        if (str[j] == k)
                        {
                            eDis[l] = "E";
                            break;
                        }
                    }
                }
            }

            for (int i = 0; i < eDis.Length; i++)
            {
                if (i >= 0 && i < 8)
                    disBilgisiDVO.sagUstCene = disBilgisiDVO.sagUstCene + eDis[i];
                if (i >= 8 && i < 16)
                    disBilgisiDVO.solUstCene = disBilgisiDVO.solUstCene + eDis[i];
                if (i >= 16 && i < 24)
                    disBilgisiDVO.solAltCene = disBilgisiDVO.solAltCene + eDis[i];
                if (i >= 24 && i < 32)
                    disBilgisiDVO.sagAltCene = disBilgisiDVO.sagAltCene + eDis[i];
            }
        }

        //Süt dişlerin string scheması oluşturulur.
        public void setSutDisler(int[] str, HizmetKayitIslemleri.disBilgisiDVO disBilgisiDVO)
        {
            String[] sDis = new String[20];
            disBilgisiDVO.sagSutUstCene = "";
            disBilgisiDVO.solSutUstCene = "";
            disBilgisiDVO.solSutAltCene = "";
            disBilgisiDVO.sagSutAltCene = "";

            for (int i = 0; i < sDis.Length; i++)
                sDis[i] = "_";

            for (int j = 0; j < str.Length; j++)
            {
                for (int k = 51, l = 0; k <= sDis.Length + 65 && l < sDis.Length; k++, l++)
                {
                    if (k == 55 || k == 65 || k == 75 || k == 85)
                    {
                        if (str[j] == k)
                        {
                            sDis[l] = "E";
                            break;
                        }
                        k = k + 5;
                    }
                    else
                    {
                        if (str[j] == k)
                        {
                            sDis[l] = "E";
                            break;
                        }
                    }
                }
            }

            for (int i = 0; i < sDis.Length; i++)
            {
                if (i >= 0 && i < 5)
                    disBilgisiDVO.sagSutUstCene = disBilgisiDVO.sagSutUstCene + sDis[i];
                if (i >= 5 && i < 10)
                    disBilgisiDVO.solSutUstCene = disBilgisiDVO.solSutUstCene + sDis[i];
                if (i >= 10 && i < 15)
                    disBilgisiDVO.solSutAltCene = disBilgisiDVO.solSutAltCene + sDis[i];
                if (i >= 15 && i < 20)
                    disBilgisiDVO.sagSutAltCene = disBilgisiDVO.sagSutAltCene + sDis[i];
            }
        }

        //Anomalili dişlerin string scheması oluşturulur.
        public void setAnomaliDisler(int[] str, HizmetKayitIslemleri.disBilgisiDVO disBilgisiDVO)
        {
            String[] aDis = new String[4];

            disBilgisiDVO.sagUstCeneAnomaliDis = "";//91
            disBilgisiDVO.solUstCeneAnomaliDis = "";//92
            disBilgisiDVO.sagAltCeneAnomaliDis = "";//93
            disBilgisiDVO.solAltCeneAnomaliDis = "";//94


            for (int i = 0; i < aDis.Length; i++)
                aDis[i] = "_";

            for (int j = 0; j < str.Length; j++)
                for (int k = 91, l = 0; k <= aDis.Length + 90 && l < aDis.Length; k++, l++)
                {
                    if (str[j] == k)
                    {
                        aDis[l] = "E";
                        Anomali = true;
                        break;
                    }
                }

            disBilgisiDVO.sagUstCeneAnomaliDis = aDis[0];
            disBilgisiDVO.solUstCeneAnomaliDis = aDis[1];
            disBilgisiDVO.sagAltCeneAnomaliDis = aDis[2];
            disBilgisiDVO.solAltCeneAnomaliDis = aDis[3];
        }



        //Tüm,sağ,sol,üst,alt çene string scheması oluşturulur.
        public void setCeneDisler(int[] str, HizmetKayitIslemleri.disBilgisiDVO disBilgisiDVO)
        {
            for (int j = 0; j < str.Length; j++)
            {
                if (str[j] == 1)
                {  //Tüm Çene
                    disBilgisiDVO.sagUstCeneAnomaliDis = "E";
                    disBilgisiDVO.solUstCeneAnomaliDis = "E";
                    disBilgisiDVO.sagAltCeneAnomaliDis = "E";
                    disBilgisiDVO.solAltCeneAnomaliDis = "E";
                    disBilgisiDVO.sagSutUstCene = "_____"; //"EEEEE";
                    disBilgisiDVO.solSutUstCene = "_____"; //"EEEEE";
                    disBilgisiDVO.solSutAltCene = "_____"; //"EEEEE";
                    disBilgisiDVO.sagSutAltCene = "_____"; //"EEEEE";
                    disBilgisiDVO.sagUstCene = "EEEEEEEE";
                    disBilgisiDVO.solUstCene = "EEEEEEEE";
                    disBilgisiDVO.solAltCene = "EEEEEEEE";
                    disBilgisiDVO.sagAltCene = "EEEEEEEE";
                }
                if (str[j] == 2)
                {  //Ãœst Çene
                    disBilgisiDVO.sagUstCeneAnomaliDis = "E";
                    disBilgisiDVO.solUstCeneAnomaliDis = "E";
                    disBilgisiDVO.sagAltCeneAnomaliDis = "_";
                    disBilgisiDVO.solAltCeneAnomaliDis = "_";
                    disBilgisiDVO.sagSutUstCene = "_____"; //"EEEEE";
                    disBilgisiDVO.solSutUstCene = "_____"; //"EEEEE";
                    disBilgisiDVO.solSutAltCene = "_____";
                    disBilgisiDVO.sagSutAltCene = "_____";
                    disBilgisiDVO.sagUstCene = "EEEEEEEE";
                    disBilgisiDVO.solUstCene = "EEEEEEEE";
                    disBilgisiDVO.solAltCene = "________";
                    disBilgisiDVO.sagAltCene = "________";
                }
                if (str[j] == 3)
                {  //Alt Çene
                    disBilgisiDVO.sagUstCeneAnomaliDis = "_";
                    disBilgisiDVO.solUstCeneAnomaliDis = "_";
                    disBilgisiDVO.sagAltCeneAnomaliDis = "E";
                    disBilgisiDVO.solAltCeneAnomaliDis = "E";
                    disBilgisiDVO.sagSutUstCene = "_____";
                    disBilgisiDVO.solSutUstCene = "_____";
                    disBilgisiDVO.solSutAltCene = "_____"; //"EEEEE";
                    disBilgisiDVO.sagSutAltCene = "_____"; //"EEEEE";
                    disBilgisiDVO.sagUstCene = "________";
                    disBilgisiDVO.solUstCene = "________";
                    disBilgisiDVO.solAltCene = "EEEEEEEE";
                    disBilgisiDVO.sagAltCene = "EEEEEEEE";
                }
                if (str[j] == 4)
                {  //Sağ Ãœst Çene
                    disBilgisiDVO.sagUstCeneAnomaliDis = "E";
                    disBilgisiDVO.solUstCeneAnomaliDis = "_";
                    disBilgisiDVO.sagAltCeneAnomaliDis = "_";
                    disBilgisiDVO.solAltCeneAnomaliDis = "_";
                    disBilgisiDVO.sagSutUstCene = "_____";  //"EEEEE";
                    disBilgisiDVO.solSutUstCene = "_____";
                    disBilgisiDVO.solSutAltCene = "_____";
                    disBilgisiDVO.sagSutAltCene = "_____";
                    disBilgisiDVO.sagUstCene = "EEEEEEEE";
                    disBilgisiDVO.solUstCene = "________";
                    disBilgisiDVO.solAltCene = "________";
                    disBilgisiDVO.sagAltCene = "________";
                }
                if (str[j] == 5)
                {  //Sol Ãœst Çene
                    disBilgisiDVO.sagUstCeneAnomaliDis = "_";
                    disBilgisiDVO.solUstCeneAnomaliDis = "E";
                    disBilgisiDVO.sagAltCeneAnomaliDis = "_";
                    disBilgisiDVO.solAltCeneAnomaliDis = "_";
                    disBilgisiDVO.sagSutUstCene = "_____";
                    disBilgisiDVO.solSutUstCene = "_____";  //"EEEEE";
                    disBilgisiDVO.solSutAltCene = "_____";
                    disBilgisiDVO.sagSutAltCene = "_____";
                    disBilgisiDVO.sagUstCene = "________";
                    disBilgisiDVO.solUstCene = "EEEEEEEE";
                    disBilgisiDVO.solAltCene = "________";
                    disBilgisiDVO.sagAltCene = "________";
                }
                if (str[j] == 6)
                {  //Sağ Alt Çene
                    disBilgisiDVO.sagUstCeneAnomaliDis = "_";
                    disBilgisiDVO.solUstCeneAnomaliDis = "_";
                    disBilgisiDVO.sagAltCeneAnomaliDis = "E";
                    disBilgisiDVO.solAltCeneAnomaliDis = "_";
                    disBilgisiDVO.sagSutUstCene = "_____";
                    disBilgisiDVO.solSutUstCene = "_____";
                    disBilgisiDVO.solSutAltCene = "_____";
                    disBilgisiDVO.sagSutAltCene = "_____";  //"EEEEE";
                    disBilgisiDVO.sagUstCene = "________";
                    disBilgisiDVO.solUstCene = "________";
                    disBilgisiDVO.solAltCene = "________";
                    disBilgisiDVO.sagAltCene = "EEEEEEEE";
                }
                if (str[j] == 7)
                {  //Sol Alt Çene
                    disBilgisiDVO.sagUstCeneAnomaliDis = "_";
                    disBilgisiDVO.solUstCeneAnomaliDis = "_";
                    disBilgisiDVO.sagAltCeneAnomaliDis = "_";
                    disBilgisiDVO.solAltCeneAnomaliDis = "E";
                    disBilgisiDVO.sagSutUstCene = "_____";
                    disBilgisiDVO.solSutUstCene = "_____";
                    disBilgisiDVO.solSutAltCene = "_____";  //"EEEEE";
                    disBilgisiDVO.sagSutAltCene = "_____";
                    disBilgisiDVO.sagUstCene = "________";
                    disBilgisiDVO.solUstCene = "________";
                    disBilgisiDVO.solAltCene = "EEEEEEEE";
                    disBilgisiDVO.sagAltCene = "________";
                }
            }
        }

        /*
        public void TurnMyAccTrxsToPatientOrPayerShare(PricingDetailDefinition pricingDetail)
        {
            bool patientPay = (PatientPay == true ? true : false);

            foreach (AccountTransaction at in AccountTransactions)
            {
                if (!at.IsCancelled && at.IsAllowedToCancel == false)
                {
                    //if ((PatientPay == true && at.AccountPayableReceivable.Type == APRTypeEnum.PAYER) ||
                    //    (PatientPay != true && at.AccountPayableReceivable.Type == APRTypeEnum.PATIENT))
                    throw new TTException("İşlem '" + at.CurrentStateDef.DisplayText + "' durumunda olduğu için ödeyen bilgisi değiştirilemez. Öncelikle ödeme/faturalama işleminin iptal edilmesi gerekmektedir!\r\n" + "Hizmet : " + at.ExternalCode + " " + at.Description);
                }
            }

            if (this.AccountTransactions.Count == 1 && (this.AccountTransactions[0].CurrentStateDefID == AccountTransaction.States.New || this.AccountTransactions[0].CurrentStateDefID == AccountTransaction.States.ToBeNew))
            {
                if (!patientPay && this.AccountTransactions[0].AccountPayableReceivable.Type == APRTypeEnum.PATIENT)
                    patientPay = true;
                else
                {
                    this.AccountTransactions[0].PricingDetail = pricingDetail;
                    this.AccountTransactions[0].ExternalCode = pricingDetail.ExternalCode;
                }

                if (patientPay)
                {
                    this.AccountTransactions[0].UnitPrice = this.PatientPrice;
                    if (this.Episode.Patient.APR.Count > 0)
                    {
                        this.AccountTransactions[0].CurrentStateDefID = AccountTransaction.States.New;
                        this.AccountTransactions[0].TurnToPatientShare();
                    }
                }
                else
                {
                    this.AccountTransactions[0].UnitPrice = pricingDetail.Price;
                    if (this.AccountTransactions[0].SubEpisodeProtocol != null)
                        this.AccountTransactions[0].TurnToPayerShare();
                }
            }
            else if (this.AccountTransactions.Count > 1)
            {
                foreach (AccountTransaction accTrx in AccountTransactions)
                {
                    if (accTrx.AccountPayableReceivable.Type == APRTypeEnum.PAYER)
                    {
                        if (patientPay && (accTrx.CurrentStateDefID == AccountTransaction.States.New || accTrx.CurrentStateDefID == AccountTransaction.States.ToBeNew))
                        {
                            accTrx.CurrentStateDefID = AccountTransaction.States.Cancelled;
                        }
                        else if (!patientPay && accTrx.CurrentStateDefID == AccountTransaction.States.Cancelled)
                        {
                            //TTObjectContext objectContext = new TTObjectContext(false);
                            //AccountTransaction acctrx = (AccountTransaction)objectContext.GetObject(accTrx.ObjectID, typeof(AccountTransaction).Name);
                            accTrx.CurrentStateDefID = AccountTransaction.States.New;
                            //objectContext.Save();
                            //objectContext.Dispose();
                        }
                    }
                    else if (accTrx.AccountPayableReceivable.Type == APRTypeEnum.PATIENT && accTrx.CurrentStateDefID == AccountTransaction.States.New)
                    {
                        accTrx.PricingDetail = pricingDetail;
                        accTrx.UnitPrice = this.PatientPrice;
                        accTrx.ExternalCode = pricingDetail.ExternalCode;
                    }
                }
            }
        }
        */

        public bool AccountingOperationNeed() //(((ITTObject)dp).IsNew || dp.HasMemberChanged("PatientPay"))
        {
            if (((ITTObject)this).IsNew) // Yeni obje ise
                return true;

            TTObjectContext objectContext = new TTObjectContext(true);
            DentalProcedure originalDP = objectContext.GetObject(ObjectID, ObjectDef, false) as DentalProcedure;

            if (originalDP == null)
                return true;

            if ((originalDP.PatientPay == true && PatientPay != true) || (originalDP.PatientPay != true && PatientPay == true)) // PatientPay değişmiş ise
                return true;

            return false;
        }

        public void AccountingOperation()
        {
            if (AccountingOperationNeed())
            {
                // Ãœcretlendirme yapılır
                if (AccountTransactions.Count == 0)
                    AccountOperation(AccountOperationTimeEnum.PREPOST);
                else
                    ChangeMyProtocol(SubEpisode.OpenSubEpisodeProtocol);

                PayerTypeEnum? payerType = SubEpisode.OpenSubEpisodeProtocol.Payer.Type.PayerType;
                if (!payerType.HasValue)
                    throw new TTException(TTUtils.CultureService.GetText("M27154", "Ãœcretlendirme sırasında hata oluştu. '")+ SubEpisode.OpenSubEpisodeProtocol.Payer.Name + "' kurumunun tip bilgisine ulaşılamıyor.");

                if (payerType == PayerTypeEnum.Paid) // Ãœcretli hasta ise çıkılır
                    return;

                if (PatientPay == true)
                {
                    // Kurum Payı hasta payına çevrilir veya fiyatı hasta payının üstüne eklenip iptal edilir
                    AccountTransaction payerAccTrx = AccountTransactions.Where(x => x.CurrentStateDefID != AccountTransaction.States.Cancelled && x.AccountPayableReceivable.Type == APRTypeEnum.PAYER).FirstOrDefault();
                    AccountTransaction patientAccTrx = AccountTransactions.Where(x => x.CurrentStateDefID != AccountTransaction.States.Cancelled && x.AccountPayableReceivable.Type == APRTypeEnum.PATIENT).FirstOrDefault();

                    if (payerAccTrx != null && patientAccTrx == null) // Sadece Kurum Payı varsa hasta payına çevrilir
                        payerAccTrx.TurnToPatientShare(true, true);
                    else if (payerAccTrx == null && patientAccTrx != null) // Belki KST fiyatı değildir diye, KST den tekrar hesaplaması için 
                        patientAccTrx.TurnToPatientShare(true, true);
                    else if (payerAccTrx != null && patientAccTrx != null) // Kurum payı ve hasta payı varsa, kurum payı iptal edilip fiyatı hasta payının üstüne eklenir
                    {
                        payerAccTrx.CurrentStateDefID = AccountTransaction.States.Cancelled;
                        patientAccTrx.TurnToPatientShare(true, true);
                    }
                }
            }
        }

        public override void SetPerformedDate()
        {
            if (CreationDate.HasValue)
            {
                PerformedDate = CreationDate.Value.AddMinutes(1);
            }
            //Geçmişe dönük hizmet girildiğinde saat - dakika farkıyla subepisode un açılış tarihinden önceye hizmet girilemesin diye eklendi.
            if (PerformedDate != null && PerformedDate <= SubEpisode.OpeningDate)
            {
                CreationDate = SubEpisode.OpeningDate.Value.AddMinutes(1);
                PerformedDate = SubEpisode.OpeningDate.Value.AddMinutes(2);
            }
        }

        #endregion Methods

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(DentalProcedure).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == DentalProcedure.States.New && toState == DentalProcedure.States.Completed)
                UndoTransition_New2Completed(transDef);
        }

        public override void AutoComplete() // Eğer Açık ise kapatır
        {
            if (CurrentStateDefID == DentalProcedure.States.New)
                CurrentStateDefID = DentalProcedure.States.Completed;
        }


    }
}