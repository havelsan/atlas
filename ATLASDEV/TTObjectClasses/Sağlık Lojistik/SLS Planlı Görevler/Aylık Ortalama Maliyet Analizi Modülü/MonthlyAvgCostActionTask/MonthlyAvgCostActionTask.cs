
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
    /// Aylık Ortalama Maliyet Analizi
    /// </summary>
    public partial class MonthlyAvgCostActionTask : BaseScheduledTask
    {
        public override void TaskScript()
        {
            TTObjectContext objectContextReadOnly = new TTObjectContext(true);
            Dictionary<MainStoreDefinition, string> dictionaryStoreMessage = new Dictionary<MainStoreDefinition, string>();
            if (Common.RecTime().Day >= DayOfMonthly)
            {
                BindingList<MainStoreDefinition> mainStores = MainStoreDefinition.GetAllMainStores(objectContextReadOnly);
                foreach (MainStoreDefinition store in mainStores)
                {
                    string message = string.Empty;
                    AccountingTerm openAccountingTerm = store.Accountancy.GetOpenAccountingTerm();
                    if (store.GoodsAccountant != null)
                    {
                        for (int i = ((DateTime)openAccountingTerm.StartDate).Month; i < Common.RecTime().Month; i++)
                        {
                            int year = Common.RecTime().Year;
                            DateTime currentDate = new DateTime(year, i, 01);
                            BindingList<CostAction.GetCostActionTaskByStoreAndDate_Class> costAction = CostAction.GetCostActionTaskByStoreAndDate(currentDate, store.ObjectID);
                            if (costAction.Count == 0)
                            {
                                string ayIsmi = AyIsmi(i);
                                message += ayIsmi + " Ayı için Aylık Ortalama Maliyet Analizi İşlemini Başlatmanız Gerekmektedir.";
                            }

                        }
                        dictionaryStoreMessage.Add(store, message);
                    }
                }
            }
            else
            {
                AddLog("Ayın " + DayOfMonthly.ToString() + ".dan küçük olduğu için çalıştırılmadı.");
            }

            TTObjectContext objectContext = new TTObjectContext(false);
            foreach (KeyValuePair<MainStoreDefinition, string> mes in dictionaryStoreMessage)
            {
                if (String.IsNullOrEmpty(mes.Value) == false)
                {
                    List<ResUser> resUsers = new List<ResUser> { };
                    UserMessage newMessage = new UserMessage(objectContext);
                    newMessage.InitializeSentMessage();
                    newMessage.ToUser = ((MainStoreDefinition)mes.Key).GoodsAccountant;
                    newMessage.Subject = "Aylık Ortalama Maliyet Analizi Bildirimi";
                    newMessage.MessageBody = mes.Value;
                    newMessage.IsSystemMessage = true;
                    newMessage.IsSplashMessage = false;
                    newMessage.MessageFeedback = true;
                    AddLog(mes.Value);
                }
            }
            objectContext.Save();
            objectContext.Dispose();

        }

        public override void AddLog(string log)
        {
            base.AddLog(log);
        }

        public static string AyIsmi(int ay)
        {
            string sonuc = TTUtils.CultureService.GetText("M26621", "Ocak");
            switch (ay)
            {
                case 1:
                    sonuc = TTUtils.CultureService.GetText("M26621", "Ocak");
                    break;
                case 2:
                    sonuc = TTUtils.CultureService.GetText("M26965", "Şubat");
                    break;
                case 3:
                    sonuc = TTUtils.CultureService.GetText("M26418", "Mart");
                    break;
                case 4:
                    sonuc = TTUtils.CultureService.GetText("M26570", "Nisan");
                    break;
                case 5:
                    sonuc = TTUtils.CultureService.GetText("M26422", "Mayıs");
                    break;
                case 6:
                    sonuc = TTUtils.CultureService.GetText("M25910", "Haziran");
                    break;
                case 7:
                    sonuc = TTUtils.CultureService.GetText("M27091", "Temmuz");
                    break;
                case 8:
                    sonuc = TTUtils.CultureService.GetText("M25141", "Ağustos");
                    break;
                case 9:
                    sonuc = TTUtils.CultureService.GetText("M25625", "Eylül");
                    break;
                case 10:
                    sonuc = TTUtils.CultureService.GetText("M25576", "Ekim");
                    break;
                case 11:
                    sonuc = TTUtils.CultureService.GetText("M26274", "Kasım");
                    break;
                case 12:
                    sonuc = TTUtils.CultureService.GetText("M25191", "Aralık");
                    break;
            }
            return sonuc;
        }
    }
}