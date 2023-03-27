
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
using System.Threading;
using System.Net.Mail;
using System.Net;

namespace TTObjectClasses
{
    public partial class MedulaIlacAraTask : BaseScheduledTask
    {
        #region Methods
        public override void TaskScript()
        {
            string msg = string.Empty;
            TTObjectContext readonlyContext = new TTObjectContext(true);
            IBindingList drugs = readonlyContext.QueryObjects("DRUGDEFINITION", "BARCODE IS NOT NULL AND ISACTIVE=1");
            IBindingList updateDrugs = readonlyContext.QueryObjects("UPDATEMATERIALPRICE", "UPDATED=0 AND MATERIALTYPE=0");

            List<Guid> guidListMaterial = new List<Guid>();
            foreach (UpdateMaterialPrice updateMaterialPrice in updateDrugs)
            {
                if (updateMaterialPrice.Material != null)
                    guidListMaterial.Add(updateMaterialPrice.Material.ObjectID);
            }

            int countRequest = 0;
            int count = 0;
            foreach (DrugDefinition drug in drugs)
            {
                if (guidListMaterial.Contains(drug.ObjectID) == true)
                    continue;

                TTObjectContext context = new TTObjectContext(false);
                DrugDefinition drugDefinition = (DrugDefinition)context.GetObject(drug.ObjectID, typeof(DrugDefinition));


                MedulaYardimciIslemler.ilacAraGirisDVO ilacAraGirisDVO = new MedulaYardimciIslemler.ilacAraGirisDVO();
                ilacAraGirisDVO.saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();
                ilacAraGirisDVO.barkod = drugDefinition.Barcode;

                try
                {
                    if (countRequest == 20)
                    {
                        countRequest = 0;
                        Thread.Sleep(5000); //5DK Bekle
                    }
                    MedulaYardimciIslemler.ilacAraCevapDVO ilacAraCevapDVO = MedulaYardimciIslemler.WebMethods.ilacAraSync(Sites.SiteLocalHost, ilacAraGirisDVO);
                    countRequest++;
                    if (ilacAraCevapDVO.sonucKodu == "0000")
                    {

                        if (ilacAraCevapDVO.ilaclar.Length > 0)
                        {
                            //doz birimleri
                            drugDefinition.OutpatientMaxDoseOne = ilacAraCevapDVO.ilaclar[0].ayaktanMaksimumKullanimDoz1;
                            drugDefinition.OutpatientMaxDoseTwo = ilacAraCevapDVO.ilaclar[0].ayaktanMaksimumKullanimDoz2;
                            drugDefinition.InpatientMaxDoseOne = ilacAraCevapDVO.ilaclar[0].yatanMaksimumKullanimDoz1;
                            drugDefinition.InpatientMaxDoseTwo = ilacAraCevapDVO.ilaclar[0].yatanMaksimumKullanimDoz2;
                        }

                        UpdateMaterialPrice updateMaterial = new UpdateMaterialPrice(context);
                        updateMaterial.MaterialType = MaterialTypeEnum.Medicine;
                        updateMaterial.Code = ilacAraCevapDVO.ilaclar[0].barkod;
                        updateMaterial.DateStart = Common.RecTime();
                        updateMaterial.Material = drugDefinition;
                        updateMaterial.Desciption = ilacAraCevapDVO.ilaclar[0].ilacAdi;
                        updateMaterial.Updated = false;
                        updateMaterial.Price = ilacAraCevapDVO.ilaclar[0].ilacFiyatlari[0].fiyat;
                        drugDefinition.CurrentPrice = ilacAraCevapDVO.ilaclar[0].ilacFiyatlari[0].fiyat;
                        if (updateMaterial.Price >= 15.03)
                        {
                            drugDefinition.Discount = ilacAraCevapDVO.ilaclar[0].ilacIndirimleri[0].indirimOrani1 / 100;
                            updateMaterial.DiscountPercent = ilacAraCevapDVO.ilaclar[0].ilacIndirimleri[0].indirimOrani1 / 100;
                        }
                        else if (updateMaterial.Price >= 9.99 && drugDefinition.CurrentPrice <= 15.02)
                        {
                            drugDefinition.Discount = ilacAraCevapDVO.ilaclar[0].ilacIndirimleri[0].indirimOrani2 / 100;
                            updateMaterial.DiscountPercent = ilacAraCevapDVO.ilaclar[0].ilacIndirimleri[0].indirimOrani2 / 100;
                        }
                        else if (updateMaterial.Price >= 5.23 && drugDefinition.CurrentPrice <= 9.98)
                        {
                            drugDefinition.Discount = ilacAraCevapDVO.ilaclar[0].ilacIndirimleri[0].indirimOrani3 / 100;
                            updateMaterial.DiscountPercent = ilacAraCevapDVO.ilaclar[0].ilacIndirimleri[0].indirimOrani3 / 100;
                        }
                        else if (updateMaterial.Price <= 5.22)
                        {
                            drugDefinition.Discount = ilacAraCevapDVO.ilaclar[0].ilacIndirimleri[0].indirimOrani4 / 100;
                            updateMaterial.DiscountPercent = ilacAraCevapDVO.ilaclar[0].ilacIndirimleri[0].indirimOrani4 / 100;
                        }
                        context.Save();
                        context.Dispose();
                        count++;
                    }
                    else if (ilacAraCevapDVO.sonucKodu == "0625")
                    {
                        //drugDefinition.IsActive = false;
                        //context.Save();
                        context.Dispose();
                    }
                    else
                        context.Dispose();
                }
                catch
                {
                    msg = "�la� paket fiyat / indirim oran� g�ncelleme i�lemi  hatal� tamamlanm��t�r!" + "\r\n";
                }
            }
            readonlyContext.Dispose();


            if (String.IsNullOrEmpty(msg) == true)
                msg = "�la� paket fiyat / indirim oran� g�ncelleme i�lemi tamamlanm��t�r!" + "\r\n";


            if (count > 0)
            {
                string smptdAddres = SystemParameter.GetParameterValue("MAILSMTPADDRES", "smtp.gmail.com");
                string mailUserName = SystemParameter.GetParameterValue("MAILUSERNAME", "XXXXXX");
                string mailPassword = SystemParameter.GetParameterValue("MAILPASSWORD", "XXXXXX");
                foreach (MedulaIlacAraTaskUser ilacAraTaskUser in MedulaIlacAraTaskUsers)
                {
                    if (string.IsNullOrEmpty(ilacAraTaskUser.User.EMail) == false)
                    {
                        MailMessage mail = new MailMessage();
                        mail.From = new MailAddress(mailUserName, "ATLASCare");
                        mail.To.Add(ilacAraTaskUser.User.EMail);
                        mail.Subject = "�la� Fiyat G�ncelleme";
                        mail.Body = msg;

                        SmtpClient SmtpServer = new SmtpClient();
                        SmtpServer.Port = 587;
                        SmtpServer.Host = smptdAddres;
                        NetworkCredential credential = new NetworkCredential(mailUserName, mailPassword);
                        SmtpServer.Credentials = credential;
                        SmtpServer.EnableSsl = true;

                        SmtpServer.Send(mail);
                    }

                }
            }
            AddLog(msg);
        }
        public override void AddLog(string log)
        {
            base.AddLog(log);
        }

        #endregion Methods

    }
}