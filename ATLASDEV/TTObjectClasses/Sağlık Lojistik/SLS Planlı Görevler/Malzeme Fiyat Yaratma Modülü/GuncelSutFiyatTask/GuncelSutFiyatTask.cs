
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
using System.Net.Mail;
using System.Net;

namespace TTObjectClasses
{
    public partial class GuncelSutFiyatTask : BaseScheduledTask
    {
        #region Methods
        public override void TaskScript()
        {
            string msg = string.Empty;
            int count = 0;
            try
            {
                MedulaYardimciIslemler.guncelSutSorguGirisDVO guncelSutSorguGirisDVO = new MedulaYardimciIslemler.guncelSutSorguGirisDVO();
                guncelSutSorguGirisDVO.saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu(); // Pursaklar : 11060019 , Gaziler : 11069941
                guncelSutSorguGirisDVO.tarih = null;

                MedulaYardimciIslemler.guncelSutSorguCevapDVO guncelSutSorguCevapDVO = MedulaYardimciIslemler.WebMethods.guncelSutKodlariSync(Sites.SiteLocalHost, guncelSutSorguGirisDVO);
                if (guncelSutSorguCevapDVO.sonucKodu == "0000")
                {
                    MedulaYardimciIslemler.sutFiyatDVO[] sutKodlariList = guncelSutSorguCevapDVO.sutKodlari.Where(x => x.turu == 5).ToArray();
                    foreach (MedulaYardimciIslemler.sutFiyatDVO item in sutKodlariList)
                    {
                        TTObjectContext context = new TTObjectContext(false);
                        IBindingList updateMaterialPriceList = context.QueryObjects(typeof(UpdateMaterialPrice).Name, "UPDATED = 0 AND MATERIALTYPE = 1 AND CODE = '" + item.sutKodu + "'");
                        if (updateMaterialPriceList.Count > 0)
                        {
                            context.Dispose();
                        }
                        else
                        {
                            UpdateMaterialPrice updateMaterial = new UpdateMaterialPrice(context);
                            updateMaterial.MaterialType = MaterialTypeEnum.Material;
                            updateMaterial.Updated = false;
                            updateMaterial.Price = item.fiyat;
                            updateMaterial.Desciption = item.adi;
                            updateMaterial.DateStart = Common.RecTime();
                            updateMaterial.Code = item.sutKodu;
                            context.Save();
                            context.Dispose();
                            count++;
                        }
                    }
                }

            }
            catch
            {
                msg = "Malzeme sut kodu g�ncelleme i�lemi hatal� tamamlanm��t�r" + "\r\n";
            }

            if (String.IsNullOrEmpty(msg) == true)
                msg = "Malzeme sut kodu g�ncelleme i�lemi tamamlanm��t�r" + "\r\n";

            if (count > 0)
            {
                string smptdAddres = SystemParameter.GetParameterValue("MAILSMTPADDRES", "smtp.gmail.com");
                string mailUserName = SystemParameter.GetParameterValue("MAILUSERNAME", "XXXXXX");
                string mailPassword = SystemParameter.GetParameterValue("MAILPASSWORD", "XXXXXX");
                foreach (GuncelSutFiyatUser ilacAraTaskUser in GuncelSutFiyatUsers)
                {
                    if (string.IsNullOrEmpty(ilacAraTaskUser.User.EMail) == false)
                    {
                        MailMessage mail = new MailMessage();
                        mail.From = new MailAddress(mailUserName, "ATLASCare");
                        mail.To.Add(ilacAraTaskUser.User.EMail);
                        mail.Subject = "SUT Fiyat G�ncelleme";
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