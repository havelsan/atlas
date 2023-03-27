
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


using System.IO;

namespace TTObjectClasses
{
    public partial class SOSFarmaXXXXXX : TTObject
    {
        #region Methods


        public string FetchSOSFarma(string message)
        {
            TTObjectContext context = new TTObjectContext(false);
            TTObjectContext rContext = new TTObjectContext(true);
            string lastUpdateGuid = string.Empty;
            Guid updatedGuid = Guid.Empty;
            IList updateSOSFarmaXXXXXX = rContext.QueryObjects("SOSFARMAXXXXXX", string.Empty);
            SOSFarmaXXXXXX sosFarmaXXXXXX = null;
            if (updateSOSFarmaXXXXXX.Count > 0)
                sosFarmaXXXXXX = (SOSFarmaXXXXXX)context.GetObject(((SOSFarmaXXXXXX)updateSOSFarmaXXXXXX[0]).ObjectID, "SOSFARMAXXXXXX");

            if (sosFarmaXXXXXX != null)
                lastUpdateGuid = sosFarmaXXXXXX.LastUpdateGuid.ToString();
            else
                lastUpdateGuid = "0f97d2b2-cd45-4a16-acbb-41ab724a7775";

            DrugServis.AuditRow[] auditArray = DrugServis.WebMethods.GetLastAuditsXXXXXXSync(Sites.SiteMerkezSagKom, string.Empty, string.Empty, lastUpdateGuid);
            //DrugServis.AuditRow[] auditArray = DrugServis.WebMethods.GetLastAuditsSync(Sites.SiteMerkezSagKom, string.Empty, string.Empty, lastUpdateGuid);
            List<Guid> fiyatUpdateUrun = new List<Guid>();
            List<TTObject> updateEdilenler = new List<TTObject>();

            if (auditArray != null)
            {
                foreach (var audit in auditArray)
                {
                    if (audit.IUD == "U")
                    {
                        if (audit.ObjectName.Equals("Urun_Bilgisi"))
                        {
                            XmlDocument doc = new XmlDocument();
                            doc.LoadXml(audit.ChangeSet);
                            XmlNodeList elemlist = doc.GetElementsByTagName("Aktif");
                            foreach (XmlNode node in elemlist)
                            {
                                if (node.ParentNode.Name.Equals("Urun_Bilgisi_ID"))
                                {
                                    TTObjectContext readonlyContext = new TTObjectContext(false);
                                    IList urunler = readonlyContext.QueryObjects("SOSURUNBILGISI", "SOSID ='" + node.InnerText + "'");
                                    if (urunler.Count > 0)
                                    {
                                        SOSUrunBilgisi urun = (SOSUrunBilgisi)urunler[0];
                                        SOSUrunBilgisi updatedUrun = UpdateSOSUrunBilgisi(audit.ChangeSet, urun, urun.XXXXXXDrugDefinition);
                                        updateEdilenler.Add(updatedUrun);
                                        updateEdilenler.Add(updatedUrun.XXXXXXDrugDefinition);

                                        message = message + "\r\n " + updatedUrun.Barcode + "-" + updatedUrun.Name + " ilacı güncellendi.";
                                    }
                                    else
                                    {
                                        message = message + "\r\n " + node.InnerText + " id li ilaç bulunamadı.";
                                    }
                                }
                            }
                        }
                        if (audit.ObjectName.Equals("Urun_Fiyat"))
                        {
                            XmlDocument doc = new XmlDocument();
                            doc.LoadXml(audit.ChangeSet);
                            XmlNodeList elemlist = doc.GetElementsByTagName("Aktif");
                            foreach (XmlNode node in elemlist)
                            {
                                if (node.ParentNode.Name.Equals("Id"))
                                {
                                    TTObjectContext readonlyContext = new TTObjectContext(false);
                                    IList fiyat = readonlyContext.QueryObjects("SOSURUNFIYAT", "SOSID ='" + node.InnerText + "'");
                                    if (fiyat.Count > 0)
                                    {
                                        SOSUrunFiyat urunfiyat = (SOSUrunFiyat)fiyat[0];
                                        SOSUrunFiyat updatedUrunfiyat = UpdateSOSUrunFiyat(audit.ChangeSet, urunfiyat);
                                        updateEdilenler.Add(updatedUrunfiyat);
                                        fiyatUpdateUrun.Add(updatedUrunfiyat.SOSUrunBilgisi.ObjectID);

                                        message = message + "\r\n " + updatedUrunfiyat.SOSUrunBilgisi.Barcode + "-" + updatedUrunfiyat.SOSUrunBilgisi.Name + " ilacın fiyatı güncellendi.";
                                    }
                                    else
                                    {
                                        message = message + "\r\n " + node.InnerText + " id li ilaç fiyatı bulunamadı.";
                                    }
                                }
                            }
                        }
                        if (audit.ObjectName.Equals("RpIlacProspektus"))
                        {
                            XmlDocument doc = new XmlDocument();
                            doc.LoadXml(audit.ChangeSet);
                            XmlNodeList elemlist = doc.GetElementsByTagName("Aktif");
                            foreach (XmlNode node in elemlist)
                            {
                                if (node.ParentNode.Name.Equals("Id"))
                                {
                                    TTObjectContext readonlyContext = new TTObjectContext(false);
                                    IList pros = readonlyContext.QueryObjects("SOSRPILACPROSPEKTUS", "SOSID ='" + node.InnerText + "'");
                                    if (pros.Count > 0)
                                    {
                                        SOSRpIlacProspektus prospektus = (SOSRpIlacProspektus)pros[0];
                                        SOSRpIlacProspektus updatedProspektus = UpdateSOSRpIlacProspektus(audit.ChangeSet, prospektus);
                                        updateEdilenler.Add(updatedProspektus);

                                        message = message + "\r\n " + prospektus.SOSUrunBilgisi.Barcode + "-" + prospektus.SOSUrunBilgisi.Name + " ilacın prospektüsü güncellendi.";
                                    }
                                    else
                                    {
                                        message = message + "\r\n " + node.InnerText + " id li ilaç prospektüsü bulunamadı.";
                                    }
                                }
                            }
                        }
                    }
                    else if (audit.IUD == "I")
                    {
                        if (audit.ObjectName.Equals("Urun_Bilgisi"))
                        {
                            XmlDocument doc = new XmlDocument();
                            doc.LoadXml(audit.ChangeSet);
                            XmlNodeList elemlist = doc.GetElementsByTagName("Aktif");
                            foreach (XmlNode node in elemlist)
                            {
                                if (node.ParentNode.Name.Equals("Urun_Bilgisi_ID"))
                                {
                                    TTObjectContext readonlyContext = new TTObjectContext(false);
                                    IList urunler = readonlyContext.QueryObjects("SOSURUNBILGISI", "SOSID ='" + node.InnerText + "'");
                                    if (urunler.Count > 0)//TODO Bu kısımda count == 1 olmalı
                                    {
                                        SOSUrunBilgisi urun = (SOSUrunBilgisi)urunler[0];
                                        SOSUrunBilgisi updatedUrun = UpdateSOSUrunBilgisi(audit.ChangeSet, urun, urun.XXXXXXDrugDefinition);

                                        updatedUrun = (SOSUrunBilgisi)context.GetObject(updatedUrun.ObjectID, typeof(SOSUrunBilgisi));

                                        updateEdilenler.Add(updatedUrun);
                                        updateEdilenler.Add(updatedUrun.XXXXXXDrugDefinition);

                                        message = message + "\r\n " + updatedUrun.Barcode + "-" + updatedUrun.Name + " ilacı güncellendi.";
                                    }
                                    else
                                    {
                                        SOSUrunBilgisi createdUrun = CreateSOSUrunBilgisi(audit.ChangeSet);
                                        DrugDefinition createdDrug = CreateDrugDefinition(createdUrun);
                                        if (updateEdilenler.Contains(createdUrun) == false)
                                            updateEdilenler.Add(createdUrun);
                                        if (updateEdilenler.Contains(createdDrug) == false)
                                            updateEdilenler.Add(createdDrug);

                                        message = message + "\r\n " + createdUrun.Barcode + "-" + createdUrun.Name + " ilacı aktarıldı.";
                                    }
                                }
                            }


                        }
                        if (audit.ObjectName.Equals("Urun_Fiyat"))
                        {
                            SOSUrunFiyat createdUrunFiyat = CreateSOSUrunFiyat(audit.ChangeSet);
                            //TODO
                            //createdUrunFiyat null gelirse ne yapmak gerekli?
                            if (createdUrunFiyat != null)
                            {
                                createdUrunFiyat = (SOSUrunFiyat)context.GetObject(createdUrunFiyat.ObjectID, typeof(SOSUrunFiyat));
                            }
                            if (createdUrunFiyat != null)
                            {
                                if (updateEdilenler.Contains(createdUrunFiyat) == false)
                                    updateEdilenler.Add(createdUrunFiyat);
                                if (fiyatUpdateUrun.Contains(createdUrunFiyat.SOSUrunBilgisi.ObjectID) == false)
                                    fiyatUpdateUrun.Add(createdUrunFiyat.SOSUrunBilgisi.ObjectID);

                                message = message + "\r\n " + createdUrunFiyat.SOSUrunBilgisi.Barcode + "-" + createdUrunFiyat.SOSUrunBilgisi.Name + " ilacın fiyatı güncellendi.";
                            }
                            else
                            {
                                XmlDocument doc = new XmlDocument();
                                doc.LoadXml(audit.ChangeSet);
                                XmlNodeList elemlist = doc.GetElementsByTagName("Aktif");
                                string notification = string.Empty;

                                foreach (XmlNode node in elemlist)
                                {
                                    if (node.ParentNode.Name.Equals("Id"))
                                    {
                                        long sosid;
                                        long.TryParse(node.InnerText, out sosid);
                                        notification += " ID = " + sosid;
                                    }
                                    if (node.ParentNode.Name.Equals("Barkod"))
                                    {
                                        notification += " Barkod = " + node.InnerText;
                                    }
                                }

                                message = message + "\r\n " + notification + " ilacın fiyatı güncellenememiştir.";
                            }

                        }
                        if (audit.ObjectName.Equals("Urun_Atc"))
                        {
                            SOSUrunAtc createdUrunATC = CreateSOSUrunATC(audit.ChangeSet);
                            if (createdUrunATC != null)
                            {
                                DrugATC createdDrugATC = CreateDrugATC(createdUrunATC);
                                if (updateEdilenler.Contains(createdUrunATC) == false)
                                    updateEdilenler.Add(createdUrunATC);
                                if (updateEdilenler.Contains(createdDrugATC) == false)
                                    updateEdilenler.Add(createdDrugATC);
                            }
                            else
                            {
                                XmlDocument doc = new XmlDocument();
                                doc.LoadXml(audit.ChangeSet);
                                XmlNodeList elemlist = doc.GetElementsByTagName("Aktif");
                                string notification = string.Empty;
                                foreach (XmlNode node in elemlist)
                                {
                                    if (node.ParentNode.Name.Equals("AtcId"))
                                    {
                                        notification += " SOSID = " + node.InnerText;
                                    }
                                }

                                message = message + "\r\n " + notification + " ilacın ATC bilgisi güncellenememiştir.";
                            }
                        }
                        if (audit.ObjectName.Equals("Urun_EtkenMadde"))
                        {
                            SOSUrunEtkenMadde createdUrunEtkenMadde = CreateSOSUrunEtkenMadde(audit.ChangeSet);
                            if (createdUrunEtkenMadde != null)
                            {
                                DrugActiveIngredient createdDrugActiveIngredient = CreateDrugActiveIngredient(createdUrunEtkenMadde);
                                if (updateEdilenler.Contains(createdUrunEtkenMadde) == false)
                                    updateEdilenler.Add(createdUrunEtkenMadde);
                                if (updateEdilenler.Contains(createdDrugActiveIngredient) == false)
                                    updateEdilenler.Add(createdDrugActiveIngredient);
                            }
                            else
                            {
                                XmlDocument doc = new XmlDocument();
                                doc.LoadXml(audit.ChangeSet);
                                XmlNodeList elemlist = doc.GetElementsByTagName("Aktif");
                                string notification = string.Empty;
                                foreach (XmlNode node in elemlist)
                                {
                                    if (node.ParentNode.Name.Equals("AtcId"))
                                    {
                                        notification += " SOSID = " + node.InnerText;
                                    }
                                }

                                message = message + "\r\n " + notification + " ilacın ATC bilgisi güncellenememiştir.";
                            }
                        }
                        if (audit.ObjectName.Equals("RpIlacProspektus"))
                        {
                            SOSRpIlacProspektus createdProspektus = CreateSOSRpIlacProspektus(audit.ChangeSet);
                            if (updateEdilenler.Contains(createdProspektus) == false)
                                updateEdilenler.Add(createdProspektus);


                            message = message + "\r\n " + createdProspektus.SOSUrunBilgisi.Barcode + "-" + createdProspektus.SOSUrunBilgisi.Name + " ilacın prospektüsü eklendi.";
                        }
                    }
                    updatedGuid = new Guid(audit.Id);
                }
            }

            List<TTObject> createdPrice = CreatePricingDetailDefinition(fiyatUpdateUrun);
            foreach (TTObject obj in createdPrice)
            {
                if (updateEdilenler.Contains(obj) == false)
                    updateEdilenler.Add(obj);
            }

            if (updatedGuid != Guid.Empty)
            {
                if (sosFarmaXXXXXX == null)
                {
                    sosFarmaXXXXXX = new SOSFarmaXXXXXX(context);
                }
                sosFarmaXXXXXX.LastUpdateGuid = updatedGuid;
                sosFarmaXXXXXX.LastUpdateDate = Common.RecTime();
                context.Save();
            }
            context.Dispose();
            rContext.Dispose();

            //if (!String.IsNullOrEmpty(message))
            //{
            //    File.WriteAllText(@"C:\temp\SOSFarmaUpdateTestResult_" + auditArray[0].Id.ToString() + ".txt", message);
            //}

            if (auditArray.Length == 2000)
                FetchSOSFarma(message);

            return message;
        }


        public List<TTObject> FetchSOSFarma()
        {
            TTObjectContext context = new TTObjectContext(false);
            TTObjectContext rContext = new TTObjectContext(true);
            string lastUpdateGuid = string.Empty;
            Guid updatedGuid = Guid.Empty;
            IList updateSOSFarmaXXXXXX = rContext.QueryObjects("SOSFARMAXXXXXX", string.Empty);
            SOSFarmaXXXXXX sosFarmaXXXXXX = null;
            if (updateSOSFarmaXXXXXX.Count > 0)
                sosFarmaXXXXXX = (SOSFarmaXXXXXX)context.GetObject(((SOSFarmaXXXXXX)updateSOSFarmaXXXXXX[0]).ObjectID, "SOSFARMAXXXXXX");

            if (sosFarmaXXXXXX != null)
                lastUpdateGuid = sosFarmaXXXXXX.LastUpdateGuid.ToString();
            else
                lastUpdateGuid = "0f97d2b2-cd45-4a16-acbb-41ab724a7775";

            DrugServis.AuditRow[] auditArray = DrugServis.WebMethods.GetLastAuditsXXXXXXSync(Sites.SiteMerkezSagKom, string.Empty, string.Empty, lastUpdateGuid);
            //DrugServis.AuditRow[] auditArray = DrugServis.WebMethods.GetLastAuditsSync(Sites.SiteMerkezSagKom, string.Empty, string.Empty, lastUpdateGuid);
            List<Guid> fiyatUpdateUrun = new List<Guid>();
            List<TTObject> updateEdilenler = new List<TTObject>();
            string message = string.Empty;
            if (auditArray != null)
            {
                foreach (var audit in auditArray)
                {
                    if (audit.IUD == "U")
                    {
                        if (audit.ObjectName.Equals("Urun_Bilgisi"))
                        {
                            XmlDocument doc = new XmlDocument();
                            doc.LoadXml(audit.ChangeSet);
                            XmlNodeList elemlist = doc.GetElementsByTagName("Aktif");
                            foreach (XmlNode node in elemlist)
                            {
                                if (node.ParentNode.Name.Equals("Urun_Bilgisi_ID"))
                                {
                                    TTObjectContext readonlyContext = new TTObjectContext(false);
                                    IList urunler = readonlyContext.QueryObjects("SOSURUNBILGISI", "SOSID ='" + node.InnerText + "'");
                                    if (urunler.Count > 0)
                                    {
                                        SOSUrunBilgisi urun = (SOSUrunBilgisi)urunler[0];
                                        SOSUrunBilgisi updatedUrun = UpdateSOSUrunBilgisi(audit.ChangeSet, urun, urun.XXXXXXDrugDefinition);
                                        updateEdilenler.Add(updatedUrun);
                                        updateEdilenler.Add(updatedUrun.XXXXXXDrugDefinition);

                                        message = message + "\r\n " + updatedUrun.Barcode + "-" + updatedUrun.Name + " ilacı güncellendi.";
                                    }
                                    else
                                    {
                                        message = message + "\r\n " + node.InnerText + " id li ilaç bulunamadı.";
                                    }
                                }
                            }
                        }
                        if (audit.ObjectName.Equals("Urun_Fiyat"))
                        {
                            XmlDocument doc = new XmlDocument();
                            doc.LoadXml(audit.ChangeSet);
                            XmlNodeList elemlist = doc.GetElementsByTagName("Aktif");
                            foreach (XmlNode node in elemlist)
                            {
                                if (node.ParentNode.Name.Equals("Id"))
                                {
                                    TTObjectContext readonlyContext = new TTObjectContext(false);
                                    IList fiyat = readonlyContext.QueryObjects("SOSURUNFIYAT", "SOSID ='" + node.InnerText + "'");
                                    if (fiyat.Count > 0)
                                    {
                                        SOSUrunFiyat urunfiyat = (SOSUrunFiyat)fiyat[0];
                                        SOSUrunFiyat updatedUrunfiyat = UpdateSOSUrunFiyat(audit.ChangeSet, urunfiyat);
                                        updateEdilenler.Add(updatedUrunfiyat);
                                        fiyatUpdateUrun.Add(updatedUrunfiyat.SOSUrunBilgisi.ObjectID);

                                        message = message + "\r\n " + updatedUrunfiyat.SOSUrunBilgisi.Barcode + "-" + updatedUrunfiyat.SOSUrunBilgisi.Name + " ilacın fiyatı güncellendi.";
                                    }
                                    else
                                    {
                                        message = message + "\r\n " + node.InnerText + " id li ilaç fiyatı bulunamadı.";
                                    }
                                }
                            }
                        }
                        if (audit.ObjectName.Equals("RpIlacProspektus"))
                        {
                            XmlDocument doc = new XmlDocument();
                            doc.LoadXml(audit.ChangeSet);
                            XmlNodeList elemlist = doc.GetElementsByTagName("Aktif");
                            foreach (XmlNode node in elemlist)
                            {
                                if (node.ParentNode.Name.Equals("Id"))
                                {
                                    TTObjectContext readonlyContext = new TTObjectContext(false);
                                    IList pros = readonlyContext.QueryObjects("SOSRPILACPROSPEKTUS", "SOSID ='" + node.InnerText + "'");
                                    if (pros.Count > 0)
                                    {
                                        SOSRpIlacProspektus prospektus = (SOSRpIlacProspektus)pros[0];
                                        SOSRpIlacProspektus updatedProspektus = UpdateSOSRpIlacProspektus(audit.ChangeSet, prospektus);
                                        updateEdilenler.Add(updatedProspektus);

                                        message = message + "\r\n " + prospektus.SOSUrunBilgisi.Barcode + "-" + prospektus.SOSUrunBilgisi.Name + " ilacın prospektüsü güncellendi.";
                                    }
                                    else
                                    {
                                        message = message + "\r\n " + node.InnerText + " id li ilaç prospektüsü bulunamadı.";
                                    }
                                }
                            }
                        }
                    }
                    else if (audit.IUD == "I")
                    {
                        if (audit.ObjectName.Equals("Urun_Bilgisi"))
                        {
                            XmlDocument doc = new XmlDocument();
                            doc.LoadXml(audit.ChangeSet);
                            XmlNodeList elemlist = doc.GetElementsByTagName("Aktif");
                            foreach (XmlNode node in elemlist)
                            {
                                if (node.ParentNode.Name.Equals("Urun_Bilgisi_ID"))
                                {
                                    TTObjectContext readonlyContext = new TTObjectContext(false);
                                    IList urunler = readonlyContext.QueryObjects("SOSURUNBILGISI", "SOSID ='" + node.InnerText + "'");
                                    if (urunler.Count > 0)//TODO Bu kısımda count == 1 olmalı
                                    {
                                        SOSUrunBilgisi urun = (SOSUrunBilgisi)urunler[0];
                                        SOSUrunBilgisi updatedUrun = UpdateSOSUrunBilgisi(audit.ChangeSet, urun, urun.XXXXXXDrugDefinition);

                                        updatedUrun = (SOSUrunBilgisi)context.GetObject(updatedUrun.ObjectID, typeof(SOSUrunBilgisi));

                                        updateEdilenler.Add(updatedUrun);
                                        updateEdilenler.Add(updatedUrun.XXXXXXDrugDefinition);

                                        message = message + "\r\n " + updatedUrun.Barcode + "-" + updatedUrun.Name + " ilacı güncellendi.";
                                    }
                                    else
                                    {
                                        SOSUrunBilgisi createdUrun = CreateSOSUrunBilgisi(audit.ChangeSet);
                                        DrugDefinition createdDrug = CreateDrugDefinition(createdUrun);
                                        if (updateEdilenler.Contains(createdUrun) == false)
                                            updateEdilenler.Add(createdUrun);
                                        if (updateEdilenler.Contains(createdDrug) == false)
                                            updateEdilenler.Add(createdDrug);

                                        message = message + "\r\n " + createdUrun.Barcode + "-" + createdUrun.Name + " ilacı aktarıldı.";
                                    }
                                }
                            }


                        }
                        if (audit.ObjectName.Equals("Urun_Fiyat"))
                        {
                            SOSUrunFiyat createdUrunFiyat = CreateSOSUrunFiyat(audit.ChangeSet);
                            //TODO
                            //createdUrunFiyat null gelirse ne yapmak gerekli?
                            if (createdUrunFiyat != null)
                            {
                                createdUrunFiyat = (SOSUrunFiyat)context.GetObject(createdUrunFiyat.ObjectID, typeof(SOSUrunFiyat));
                            }
                            if (createdUrunFiyat != null)
                            {
                                if (updateEdilenler.Contains(createdUrunFiyat) == false)
                                    updateEdilenler.Add(createdUrunFiyat);
                                if (fiyatUpdateUrun.Contains(createdUrunFiyat.SOSUrunBilgisi.ObjectID) == false)
                                    fiyatUpdateUrun.Add(createdUrunFiyat.SOSUrunBilgisi.ObjectID);

                                message = message + "\r\n " + createdUrunFiyat.SOSUrunBilgisi.Barcode + "-" + createdUrunFiyat.SOSUrunBilgisi.Name + " ilacın fiyatı güncellendi.";
                            }
                            else
                            {
                                XmlDocument doc = new XmlDocument();
                                doc.LoadXml(audit.ChangeSet);
                                XmlNodeList elemlist = doc.GetElementsByTagName("Aktif");
                                string notification = string.Empty;

                                foreach (XmlNode node in elemlist)
                                {
                                    if (node.ParentNode.Name.Equals("Id"))
                                    {
                                        long sosid;
                                        long.TryParse(node.InnerText, out sosid);
                                        notification += " ID = " + sosid;
                                    }
                                    if (node.ParentNode.Name.Equals("Barkod"))
                                    {
                                        notification += " Barkod = " + node.InnerText;
                                    }
                                }

                                message = message + "\r\n " + notification + " ilacın fiyatı güncellenememiştir.";
                            }

                        }
                        if (audit.ObjectName.Equals("Urun_Atc"))
                        {
                            SOSUrunAtc createdUrunATC = CreateSOSUrunATC(audit.ChangeSet);
                            if (createdUrunATC != null)
                            {
                                DrugATC createdDrugATC = CreateDrugATC(createdUrunATC);
                                if (updateEdilenler.Contains(createdUrunATC) == false)
                                    updateEdilenler.Add(createdUrunATC);
                                if (updateEdilenler.Contains(createdDrugATC) == false)
                                    updateEdilenler.Add(createdDrugATC);
                            }
                            else
                            {
                                XmlDocument doc = new XmlDocument();
                                doc.LoadXml(audit.ChangeSet);
                                XmlNodeList elemlist = doc.GetElementsByTagName("Aktif");
                                string notification = string.Empty;
                                foreach (XmlNode node in elemlist)
                                {
                                    if (node.ParentNode.Name.Equals("AtcId"))
                                    {
                                        notification += " SOSID = " + node.InnerText;
                                    }
                                }

                                message = message + "\r\n " + notification + " ilacın ATC bilgisi güncellenememiştir.";
                            }
                        }
                        if (audit.ObjectName.Equals("Urun_EtkenMadde"))
                        {
                            SOSUrunEtkenMadde createdUrunEtkenMadde = CreateSOSUrunEtkenMadde(audit.ChangeSet);
                            if (createdUrunEtkenMadde != null)
                            {
                                DrugActiveIngredient createdDrugActiveIngredient = CreateDrugActiveIngredient(createdUrunEtkenMadde);
                                if (updateEdilenler.Contains(createdUrunEtkenMadde) == false)
                                    updateEdilenler.Add(createdUrunEtkenMadde);
                                if (updateEdilenler.Contains(createdDrugActiveIngredient) == false)
                                    updateEdilenler.Add(createdDrugActiveIngredient);
                            }
                            else
                            {
                                XmlDocument doc = new XmlDocument();
                                doc.LoadXml(audit.ChangeSet);
                                XmlNodeList elemlist = doc.GetElementsByTagName("Aktif");
                                string notification = string.Empty;
                                foreach (XmlNode node in elemlist)
                                {
                                    if (node.ParentNode.Name.Equals("AtcId"))
                                    {
                                        notification += " SOSID = " + node.InnerText;
                                    }
                                }

                                message = message + "\r\n " + notification + " ilacın ATC bilgisi güncellenememiştir.";
                            }
                        }
                        if (audit.ObjectName.Equals("RpIlacProspektus"))
                        {
                            SOSRpIlacProspektus createdProspektus = CreateSOSRpIlacProspektus(audit.ChangeSet);
                            if (updateEdilenler.Contains(createdProspektus) == false)
                                updateEdilenler.Add(createdProspektus);


                            message = message + "\r\n " + createdProspektus.SOSUrunBilgisi.Barcode + "-" + createdProspektus.SOSUrunBilgisi.Name + " ilacın prospektüsü eklendi.";
                        }
                    }
                    updatedGuid = new Guid(audit.Id);
                }
            }

            List<TTObject> createdPrice = CreatePricingDetailDefinition(fiyatUpdateUrun);
            foreach (TTObject obj in createdPrice)
            {
                if (updateEdilenler.Contains(obj) == false)
                    updateEdilenler.Add(obj);
            }

            if (updatedGuid != Guid.Empty)
            {
                if (sosFarmaXXXXXX == null)
                {
                    sosFarmaXXXXXX = new SOSFarmaXXXXXX(context);
                }
                sosFarmaXXXXXX.LastUpdateGuid = updatedGuid;
                sosFarmaXXXXXX.LastUpdateDate = Common.RecTime();
                context.Save();
            }
            context.Dispose();
            rContext.Dispose();

            //if (!String.IsNullOrEmpty(message))
            //{
            //    File.WriteAllText(@"C:\temp\SOSFarmaUpdateTestResult_" + auditArray[0].Id.ToString() + ".txt", message);
            //}

            if (auditArray.Length == 2000)
                FetchSOSFarma();

            return updateEdilenler;
        }

        public SOSUrunBilgisi CreateSOSUrunBilgisi(string changeSet)
        {
            TTObjectContext context = new TTObjectContext(false);
            SOSUrunBilgisi urunBilgisi = new SOSUrunBilgisi(context);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(changeSet);
            XmlNodeList elemlist = doc.GetElementsByTagName("Aktif");
            foreach (XmlNode node in elemlist)
            {
                if (node.ParentNode.Name.Equals("Urun_Bilgisi_ID"))
                {
                    long sosid;
                    long.TryParse(node.InnerText, out sosid);
                    urunBilgisi.SOSID = sosid;
                }
                if (node.ParentNode.Name.Equals("Barkod"))
                {
                    urunBilgisi.Barcode = node.InnerText;
                }
                if (node.ParentNode.Name.Equals("UrunAdi"))
                {
                    urunBilgisi.Name = node.InnerText;
                }
                if (node.ParentNode.Name.Equals("Recete_Tur"))
                {
                    IList prescriptionType = context.QueryObjects("SOSLISTELER", "SOSID='" + node.InnerText + "'");
                    if (prescriptionType.Count > 0)
                    {
                        SOSListeler prescription = (SOSListeler)prescriptionType[0];
                        urunBilgisi.PrescriptionType = prescription;
                    }
                }
                if (node.ParentNode.Name.Equals("Miktar_Ambalaj"))
                {
                    urunBilgisi.PackageAmount = Convert.ToDouble(node.InnerText);
                }

                if (node.ParentNode.Name.Equals("Birim_Ambalaj"))
                {
                    IList unitPackages = context.QueryObjects("SOSLISTELER", "NAME='" + node.InnerText + "'");
                    if (unitPackages.Count > 0)
                    {
                        SOSListeler package = (SOSListeler)unitPackages[0];
                        urunBilgisi.UnitPackage = package;
                    }
                }
                if (node.ParentNode.Name.Equals("Urun_Birim_Sayisi"))
                {
                    urunBilgisi.Volume = Convert.ToDouble(node.InnerText);
                }
                if (node.ParentNode.Name.Equals("Urun_Birim_Birimi"))
                {
                    IList units = context.QueryObjects("SOSLISTELER", "NAME='" + node.InnerText + "'");
                    if (units.Count > 0)
                    {
                        SOSListeler unit = (SOSListeler)units[0];
                        urunBilgisi.Unit = unit;
                    }
                }
                if (node.ParentNode.Name.Equals("Uygulama_Yolu_Kodu"))
                {
                    IList uygulamaKodlari = context.QueryObjects("SOSUYGULAMAKODU", "XXXXXX" + node.InnerText + "'");
                    if (uygulamaKodlari.Count > 0)
                    {
                        SOSUygulamaKodu uygulamakodu = (SOSUygulamaKodu)uygulamaKodlari[0];
                        urunBilgisi.SOSRouteOfAdmin = uygulamakodu;
                    }
                }
                if (node.ParentNode.Name.Equals("Uygulama_Sekli_Kodu"))
                {
                    IList farmasotikSekiller = context.QueryObjects("SOSFARMASOTIKSEKIL", "CODE='" + node.InnerText + "'");
                    if (farmasotikSekiller.Count > 0)
                    {
                        SOSFarmasotikSekil farmasotikSekil = (SOSFarmasotikSekil)farmasotikSekiller[0];
                        urunBilgisi.SOSNfc = farmasotikSekil;
                    }
                }
                if (node.ParentNode.Name.Equals("Esdeger_Kodu"))
                {
                    urunBilgisi.EquivalentCRC = node.InnerText;
                }

                if (node.ParentNode.Name.Equals("Hesaplama_Tur_ID"))
                {
                    IList calculetedTypes = context.QueryObjects("SOSLISTELER", "SOSID='" + node.InnerText + "'");
                    if (calculetedTypes.Count > 0)
                    {
                        SOSListeler calculetedType = (SOSListeler)calculetedTypes[0];
                        urunBilgisi.CalculateType = calculetedType;
                    }
                }


            }
            urunBilgisi.IsActive = true;
            context.Save();
            context.Dispose();
            return urunBilgisi;
        }

        public SOSUrunBilgisi UpdateSOSUrunBilgisi(string changeSet, SOSUrunBilgisi updateUrunBilgisi, DrugDefinition updateDrugDefinition)
        {
            TTObjectContext context = new TTObjectContext(false);
            SOSUrunBilgisi urunBilgisi = (SOSUrunBilgisi)context.GetObject(updateUrunBilgisi.ObjectID, "SOSURUNBILGISI");
            DrugDefinition drugDefinition = (DrugDefinition)context.GetObject(updateDrugDefinition.ObjectID, "DRUGDEFINITION");
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(changeSet);
            XmlNodeList elemlist = doc.GetElementsByTagName("Aktif");
            foreach (XmlNode node in elemlist)
            {
                if (node.ParentNode.Name.Equals("Barkod"))
                {
                    urunBilgisi.Barcode = node.InnerText;
                    drugDefinition.Barcode = node.InnerText;
                }
                if (node.ParentNode.Name.Equals("UrunAdi"))
                {
                    urunBilgisi.Name = node.InnerText;
                    drugDefinition.Name = node.InnerText;
                    drugDefinition.BarcodeName = node.InnerText;
                    drugDefinition.OriginalName = node.InnerText;
                }
                if (node.ParentNode.Name.Equals("Recete_Tur"))
                {
                    IList prescriptionType = context.QueryObjects("SOSLISTELER", "SOSID='" + node.InnerText + "'");
                    if (prescriptionType.Count > 0)
                    {
                        SOSListeler prescription = (SOSListeler)prescriptionType[0];
                        urunBilgisi.PrescriptionType = prescription;

                        if (prescription.Name.Equals("TURUNCU REÇETE"))
                            drugDefinition.PrescriptionType = PrescriptionTypeEnum.OrangePrescription;
                        else if (prescription.Name.Equals("KONTROLE TABİ"))
                            drugDefinition.PrescriptionType = PrescriptionTypeEnum.ControlledPrescription;
                        else if (prescription.Name.Equals("KIRMIZI REÇETE"))
                            drugDefinition.PrescriptionType = PrescriptionTypeEnum.RedPrescription;
                        else if (prescription.Name.Equals("YEŞİL REÇETE"))
                            drugDefinition.PrescriptionType = PrescriptionTypeEnum.GreenPrescription;
                        else if (prescription.Name.Equals("MOR REÇETE"))
                            drugDefinition.PrescriptionType = PrescriptionTypeEnum.PurplePrescription;
                        else
                            drugDefinition.PrescriptionType = PrescriptionTypeEnum.NormalPrescription;
                    }
                }
                if (node.ParentNode.Name.Equals("Miktar_Ambalaj"))
                {
                    urunBilgisi.PackageAmount = Convert.ToDouble(node.InnerText);
                    drugDefinition.PackageAmount = Convert.ToDouble(node.InnerText);
                }

                if (node.ParentNode.Name.Equals("Birim_Ambalaj"))
                {
                    IList unitPackages = context.QueryObjects("SOSLISTELER", "NAME='" + node.InnerText + "'");
                    if (unitPackages.Count > 0)
                    {
                        SOSListeler package = (SOSListeler)unitPackages[0];
                        urunBilgisi.UnitPackage = package;
                    }
                }
                if (node.ParentNode.Name.Equals("Urun_Birim_Sayisi"))
                {
                    urunBilgisi.Volume = Convert.ToDouble(node.InnerText);
                    drugDefinition.Volume = Convert.ToDouble(node.InnerText);
                }
                if (node.ParentNode.Name.Equals("Urun_Birim_Birimi"))
                {
                    IList units = context.QueryObjects("SOSLISTELER", "NAME='" + node.InnerText + "'");
                    if (units.Count > 0)
                    {
                        SOSListeler unit = (SOSListeler)units[0];
                        urunBilgisi.Unit = unit;
                        drugDefinition.Unit = unit.XXXXXXUnitDefinition;
                    }
                }
                if (node.ParentNode.Name.Equals("Uygulama_Yolu_Kodu"))
                {
                    IList uygulamaKodlari = context.QueryObjects("SOSUYGULAMAKODU", "XXXXXX" + node.InnerText + "'");
                    if (uygulamaKodlari.Count > 0)
                    {
                        SOSUygulamaKodu uygulamakodu = (SOSUygulamaKodu)uygulamaKodlari[0];
                        urunBilgisi.SOSRouteOfAdmin = uygulamakodu;
                        drugDefinition.RouteOfAdmin = uygulamakodu.XXXXXXRouteOfAdmin;
                    }
                }
                if (node.ParentNode.Name.Equals("Uygulama_Sekli_Kodu"))
                {
                    IList farmasotikSekiller = context.QueryObjects("SOSFARMASOTIKSEKIL", "CODE='" + node.InnerText + "'");
                    if (farmasotikSekiller.Count > 0)
                    {
                        SOSFarmasotikSekil farmasotikSekil = (SOSFarmasotikSekil)farmasotikSekiller[0];
                        urunBilgisi.SOSNfc = farmasotikSekil;
                        drugDefinition.NFC = farmasotikSekil.XXXXXXNfc;
                    }
                }
                if (node.ParentNode.Name.Equals("Esdeger_Kodu"))
                {
                    urunBilgisi.EquivalentCRC = node.InnerText;
                    drugDefinition.EquivalentCRC = node.InnerText;
                }

                if (node.ParentNode.Name.Equals("Hesaplama_Tur_ID"))
                {
                    IList calculetedTypes = context.QueryObjects("SOSLISTELER", "SOSID='" + node.InnerText + "'");
                    if (calculetedTypes.Count > 0)
                    {
                        SOSListeler calculetedType = (SOSListeler)calculetedTypes[0];
                        urunBilgisi.CalculateType = calculetedType;
                        double bolen = 0;

                        if (calculetedType.Value != null)
                            bolen = Convert.ToDouble(calculetedType.Value);

                        if (bolen == 0)
                        {
                            drugDefinition.NoDoseCounting = true;
                        }
                        else if (bolen == -1)
                        {
                            drugDefinition.NoDoseCounting = false;
                            bolen = ((double)urunBilgisi.Volume);
                        }
                        else
                        {
                            drugDefinition.NoDoseCounting = false;
                        }

                        drugDefinition.Dose = bolen;
                    }
                }
            }
            urunBilgisi.IsActive = true;
            urunBilgisi.XXXXXXDrugDefinition = drugDefinition;//Bu kısım yoktu sonradan eklendi.Çağrıldığı yerde hata aldığı için(16.01.2018)
            drugDefinition.LastUpdate = Common.RecTime();
            context.Save();
            context.Dispose();
            return urunBilgisi;
        }

        public SOSUrunFiyat CreateSOSUrunFiyat(string changeSet)
        {
            TTObjectContext context = new TTObjectContext(false);
            SOSUrunFiyat urunFiyat = new SOSUrunFiyat(context);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(changeSet);
            XmlNodeList elemlist = doc.GetElementsByTagName("Aktif");
            foreach (XmlNode node in elemlist)
            {
                if (node.ParentNode.Name.Equals("Id"))
                {
                    long sosid;
                    long.TryParse(node.InnerText, out sosid);
                    urunFiyat.SOSID = sosid;
                }
                if (node.ParentNode.Name.Equals("Barkod"))
                {
                    IList urun = context.QueryObjects("SOSURUNBILGISI", "BARCODE='" + node.InnerText + "'");
                    if (urun.Count > 0)
                        urunFiyat.SOSUrunBilgisi = (SOSUrunBilgisi)urun[0];
                }
                if (node.ParentNode.Name.Equals("Baslangic_Trh"))
                {
                    DateTime startDate;
                    DateTime.TryParse(node.InnerText, out startDate);
                    urunFiyat.StartDate = startDate;
                }
                if (node.ParentNode.Name.Equals("Bitis_Trh"))
                {
                    DateTime endDate;
                    DateTime.TryParse(node.InnerText, out endDate);
                    urunFiyat.EndDate = endDate;
                }
                if (node.ParentNode.Name.Equals("Fiyat"))
                {
                    urunFiyat.Price = Convert.ToDouble(node.InnerText);
                }
                if (node.ParentNode.Name.Equals("Fiyat_Tur_ID"))
                {
                    if (node.InnerText.Equals("1"))
                        urunFiyat.PriceType = SOSFiyatTurEnum.Price;
                    else if (node.InnerText.Equals("2"))
                        urunFiyat.PriceType = SOSFiyatTurEnum.KDV;
                    else if (node.InnerText.Equals("3"))
                        urunFiyat.PriceType = SOSFiyatTurEnum.Discount;
                    else if (node.InnerText.Equals("4"))
                        urunFiyat.PriceType = SOSFiyatTurEnum.Chemical;
                    else if (node.InnerText.Equals("5"))
                        urunFiyat.PriceType = SOSFiyatTurEnum.PublicEquivalentPrice;
                }

                if (node.ParentNode.Name.Equals("AnlasmaTarihi"))
                {
                    DateTime dealDate;
                    DateTime.TryParse(node.InnerText, out dealDate);
                    urunFiyat.DealDate = dealDate;
                }
            }


            if (urunFiyat.SOSUrunBilgisi != null)
                context.Save();
            else
                urunFiyat = null;

            context.Dispose();
            return urunFiyat;
        }

        public SOSUrunFiyat UpdateSOSUrunFiyat(string changeSet, SOSUrunFiyat sosUrunFiyat)
        {
            TTObjectContext context = new TTObjectContext(false);
            SOSUrunFiyat urunFiyat = (SOSUrunFiyat)context.GetObject(sosUrunFiyat.ObjectID, "SOSURUNFIYAT");
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(changeSet);
            XmlNodeList elemlist = doc.GetElementsByTagName("Aktif");
            foreach (XmlNode node in elemlist)
            {
                if (node.ParentNode.Name.Equals("Fiyat"))
                {
                    urunFiyat.Price = Convert.ToDouble(node.InnerText);
                }
                if (node.ParentNode.Name.Equals("Fiyat_Tur_ID"))
                {
                    if (node.InnerText.Equals("1"))
                        urunFiyat.PriceType = SOSFiyatTurEnum.Price;
                    else if (node.InnerText.Equals("2"))
                        urunFiyat.PriceType = SOSFiyatTurEnum.KDV;
                    else if (node.InnerText.Equals("3"))
                        urunFiyat.PriceType = SOSFiyatTurEnum.Discount;
                    else if (node.InnerText.Equals("4"))
                        urunFiyat.PriceType = SOSFiyatTurEnum.Chemical;
                    else if (node.InnerText.Equals("5"))
                        urunFiyat.PriceType = SOSFiyatTurEnum.PublicEquivalentPrice;
                }
                if (node.ParentNode.Name.Equals("AnlasmaTarihi"))
                {
                    DateTime dealDate;
                    DateTime.TryParse(node.InnerText, out dealDate);
                    urunFiyat.DealDate = dealDate;

                    DateTime endDate;
                    DateTime.TryParse(node.InnerText, out endDate);
                    urunFiyat.EndDate = endDate;
                }
            }
            if (urunFiyat.SOSUrunBilgisi != null)
                context.Save();
            else
                urunFiyat = null;

            context.Dispose();
            return urunFiyat;
        }

        public SOSUrunAtc CreateSOSUrunATC(string changeSet)
        {
            TTObjectContext context = new TTObjectContext(false);
            SOSUrunAtc urunATC = new SOSUrunAtc(context);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(changeSet);
            XmlNodeList elemlist = doc.GetElementsByTagName("Aktif");
            foreach (XmlNode node in elemlist)
            {
                if (node.ParentNode.Name.Equals("AtcId"))
                {
                    IList atc = context.QueryObjects("SOSATC", "SOSID='" + node.InnerText + "'");
                    if (atc.Count > 0)
                        urunATC.SOSAtc = (SOSAtc)atc[0];
                }
                if (node.ParentNode.Name.Equals("UrunId"))
                {
                    IList urun = context.QueryObjects("SOSURUNBILGISI", "SOSID='" + node.InnerText + "'");
                    if (urun.Count > 0)
                        urunATC.SOSUrunBilgisi = (SOSUrunBilgisi)urun[0];
                }
            }
            if (urunATC.SOSUrunBilgisi != null && urunATC.SOSAtc != null)
                context.Save();
            else
                urunATC = null;

            context.Dispose();
            return urunATC;
        }

        public SOSUrunEtkenMadde CreateSOSUrunEtkenMadde(string changeSet)
        {
            TTObjectContext context = new TTObjectContext(false);
            SOSUrunEtkenMadde urunEtkenMadde = new SOSUrunEtkenMadde(context);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(changeSet);
            XmlNodeList elemlist = doc.GetElementsByTagName("Aktif");
            foreach (XmlNode node in elemlist)
            {
                if (node.ParentNode.Name.Equals("Id"))
                {
                    long sosid;
                    long.TryParse(node.InnerText, out sosid);
                    urunEtkenMadde.SOSID = sosid;
                }
                if (node.ParentNode.Name.Equals("Urun_Bilgisi_ID"))
                {
                    if (node.InnerText != "null")
                    {
                        IList urun = context.QueryObjects("SOSURUNBILGISI", "SOSID='" + node.InnerText + "'");
                        if (urun.Count > 0)
                            urunEtkenMadde.SOSUrunBilgisi = (SOSUrunBilgisi)urun[0];
                    }
                }
                if (node.ParentNode.Name.Equals("Etken_Madde_ID"))
                {
                    if (node.InnerText != "null")
                    {
                        IList etkenMaddeler = context.QueryObjects("SOSETKENMADDE", "SOSID='" + node.InnerText + "'");
                        if (etkenMaddeler.Count > 0)
                            urunEtkenMadde.SOSEtkenMadde = (SOSEtkenMadde)etkenMaddeler[0];
                    }
                }
                if (node.ParentNode.Name.Equals("Urun_Madde_Miktari"))
                {
                    double value;
                    double.TryParse(node.InnerText, out value);
                    urunEtkenMadde.Value = value;
                }
                if (node.ParentNode.Name.Equals("Urun_Madde_Miktari_Birimi_ID"))
                {
                    if (node.InnerText != "null")
                    {
                        IList birimler = context.QueryObjects("SOSLISTELER", "SOSID='" + node.InnerText + "'");
                        if (birimler.Count > 0)
                            urunEtkenMadde.Unit = (SOSListeler)birimler[0];
                    }
                }
                if (node.ParentNode.Name.Equals("Urun_Madde_Max_Doz"))
                {
                    double maxDose;
                    double.TryParse(node.InnerText, out maxDose);
                    urunEtkenMadde.MaxDose = maxDose;
                }
                if (node.ParentNode.Name.Equals("Etken_Madde_Unit_ID"))
                {
                    if (!String.IsNullOrEmpty(node.InnerText) && node.InnerText != "null")
                    {
                        IList maxBirimler = context.QueryObjects("SOSLISTELER", "SOSID='" + node.InnerText + "'");
                        if (maxBirimler.Count > 0)
                            urunEtkenMadde.MaxDoseUnit = (SOSListeler)maxBirimler[0];
                    }
                }

            }
            if (urunEtkenMadde.SOSUrunBilgisi != null && urunEtkenMadde.SOSEtkenMadde != null)
                context.Save();
            else
                urunEtkenMadde = null;

            context.Dispose();
            return urunEtkenMadde;
        }

        public DrugDefinition CreateDrugDefinition(SOSUrunBilgisi urunBilgisi)
        {
            TTObjectContext context = new TTObjectContext(false);
            DrugDefinition drugDefinition = new DrugDefinition(context);
            SOSUrunBilgisi sosUrunBilgisi = (SOSUrunBilgisi)context.GetObject(urunBilgisi.ObjectID, "SOSURUNBILGISI");
            drugDefinition.Barcode = sosUrunBilgisi.Barcode;
            drugDefinition.Name = sosUrunBilgisi.Name;
            drugDefinition.BarcodeName = sosUrunBilgisi.Name;
            drugDefinition.PackageAmount = sosUrunBilgisi.PackageAmount;



            //Sites merkezSite = (Sites)context.GetObject(Sites.SiteMerkezSagKom, "SITES");
            //drugDefinition.CreatedSite = merkezSite;
            drugDefinition.IsOldMaterial = false;
            drugDefinition.OriginalName = sosUrunBilgisi.Name;
            drugDefinition.StockCard = null;

            drugDefinition.EquivalentCRC = sosUrunBilgisi.EquivalentCRC;
            drugDefinition.Chargable = true;
            drugDefinition.AllowToGivePatient = true;

            MaterialTreeDefinition materialTreeDefinition = context.GetObject(new Guid("04e3ebd9-a329-469e-adae-fa040d487d15"), typeof(MaterialTreeDefinition)) as MaterialTreeDefinition;
            if (materialTreeDefinition != null)
                drugDefinition.MaterialTree = materialTreeDefinition;

            if (sosUrunBilgisi.PrescriptionType != null)
            {
                if (sosUrunBilgisi.PrescriptionType.Name.Equals("TURUNCU REÇETE"))
                    drugDefinition.PrescriptionType = PrescriptionTypeEnum.OrangePrescription;
                else if (sosUrunBilgisi.PrescriptionType.Name.Equals("KONTROLE TABİ"))
                    drugDefinition.PrescriptionType = PrescriptionTypeEnum.ControlledPrescription;
                else if (sosUrunBilgisi.PrescriptionType.Name.Equals("KIRMIZI REÇETE"))
                    drugDefinition.PrescriptionType = PrescriptionTypeEnum.RedPrescription;
                else if (sosUrunBilgisi.PrescriptionType.Name.Equals("YEŞİL REÇETE"))
                    drugDefinition.PrescriptionType = PrescriptionTypeEnum.GreenPrescription;
                else if (sosUrunBilgisi.PrescriptionType.Name.Equals("MOR REÇETE"))
                    drugDefinition.PrescriptionType = PrescriptionTypeEnum.PurplePrescription;
                else
                    drugDefinition.PrescriptionType = PrescriptionTypeEnum.NormalPrescription;
            }
            else
                drugDefinition.PrescriptionType = PrescriptionTypeEnum.NormalPrescription;

            double bolen = 0;

            if (sosUrunBilgisi.CalculateType != null)
                bolen = Convert.ToDouble(sosUrunBilgisi.CalculateType.Value);

            if (bolen == 0)
            {
                drugDefinition.NoDoseCounting = true;
            }
            else if (bolen == -1)
            {
                drugDefinition.NoDoseCounting = false;
                bolen = ((double)sosUrunBilgisi.Volume);
            }
            else
            {
                drugDefinition.NoDoseCounting = false;
            }

            drugDefinition.Dose = bolen;

            drugDefinition.Volume = sosUrunBilgisi.Volume;
            drugDefinition.IsActive = true;
            drugDefinition.LastUpdate = Common.RecTime();
            drugDefinition.MkysMalzemeKodu = 0;

            if (sosUrunBilgisi.SOSRouteOfAdmin != null)
                drugDefinition.RouteOfAdmin = sosUrunBilgisi.SOSRouteOfAdmin.XXXXXXRouteOfAdmin;
            if (sosUrunBilgisi.SOSNfc != null)
                drugDefinition.NFC = sosUrunBilgisi.SOSNfc.XXXXXXNfc;
            if (sosUrunBilgisi.Unit != null)
                drugDefinition.Unit = sosUrunBilgisi.Unit.XXXXXXUnitDefinition;

            sosUrunBilgisi.XXXXXXDrugDefinition = drugDefinition;

            context.Save();
            context.Dispose();
            return drugDefinition;
        }

        public DrugATC CreateDrugATC(SOSUrunAtc urunATC)
        {
            TTObjectContext context = new TTObjectContext(false);
            DrugATC drugATC = null;

            IList urunATCList = context.QueryObjects("SOSURUNATC", "OBJECTID='" + urunATC.ObjectID.ToString() + "'");
            if (urunATCList.Count > 0)
                urunATC = (SOSUrunAtc)urunATCList[0];

            if (urunATC.SOSUrunBilgisi.XXXXXXDrugDefinition != null)
            {
                DrugDefinition drugDefinition = (DrugDefinition)context.GetObject(urunATC.SOSUrunBilgisi.XXXXXXDrugDefinition.ObjectID, "DRUGDEFINITION");
                drugATC = new DrugATC(context);
                drugATC.ATC = urunATC.SOSAtc.XXXXXXAtc;
                drugDefinition.DrugATCs.Add(drugATC);
                context.Save();
            }
            context.Dispose();
            return drugATC;
        }

        public DrugActiveIngredient CreateDrugActiveIngredient(SOSUrunEtkenMadde urunEtkenMadde)
        {
            TTObjectContext context = new TTObjectContext(false);
            DrugActiveIngredient drugActiveIngredient = null;

            IList uurunEtkenMaddeList = context.QueryObjects("SOSURUNETKENMADDE", "OBJECTID='" + urunEtkenMadde.ObjectID.ToString() + "'");
            if (uurunEtkenMaddeList.Count > 0)
                urunEtkenMadde = (SOSUrunEtkenMadde)uurunEtkenMaddeList[0];

            if (urunEtkenMadde.SOSUrunBilgisi.XXXXXXDrugDefinition != null)
            {
                DrugDefinition drugDefinition = (DrugDefinition)context.GetObject(urunEtkenMadde.SOSUrunBilgisi.XXXXXXDrugDefinition.ObjectID, "DRUGDEFINITION");
                drugActiveIngredient = new DrugActiveIngredient(context);
                drugActiveIngredient.MaxDose = urunEtkenMadde.MaxDose;
                drugActiveIngredient.Value = urunEtkenMadde.Value;

                if (urunEtkenMadde.Unit != null)
                    drugActiveIngredient.Unit = urunEtkenMadde.Unit.XXXXXXUnitDefinition;
                if (urunEtkenMadde.MaxDoseUnit != null)
                    drugActiveIngredient.MaxDoseUnit = urunEtkenMadde.MaxDoseUnit.XXXXXXUnitDefinition;

                drugActiveIngredient.ActiveIngredient = urunEtkenMadde.SOSEtkenMadde.XXXXXXActiveIngredient;
                drugDefinition.DrugActiveIngredients.Add(drugActiveIngredient);
                context.Save();
            }
            context.Dispose();
            return drugActiveIngredient;
        }

        public List<TTObject> CreatePricingDetailDefinition(List<Guid> urunler)
        {
            List<TTObject> createdObjects = new List<TTObject>();

            string errorText = string.Empty;

            foreach (Guid urunID in urunler)
            {
                TTObjectContext context = new TTObjectContext(false);
                SOSUrunBilgisi urun = (SOSUrunBilgisi)context.GetObject(urunID, "SOSURUNBILGISI");
                DrugDefinition drugDefinition = (DrugDefinition)context.GetObject(urun.XXXXXXDrugDefinition.ObjectID, "DRUGDEFINITION");
                Currency currentP = 0;
                double discount = 0;
                double kdv = 8;
                double packageAmount = 1;


                BindingList<SOSUrunFiyat.GetLastPriceNQL_Class> prices = SOSUrunFiyat.GetLastPriceNQL(urunID);
                foreach (SOSUrunFiyat.GetLastPriceNQL_Class price in prices)
                    currentP = (Currency)price.Price;

                BindingList<SOSUrunFiyat.GetLastKDVNQL_Class> kdvs = SOSUrunFiyat.GetLastKDVNQL(urunID);
                foreach (SOSUrunFiyat.GetLastKDVNQL_Class k in kdvs)
                    kdv = Convert.ToDouble(k.Price);

                BindingList<SOSUrunFiyat.GetLasDiscountNQL_Class> discounts = SOSUrunFiyat.GetLasDiscountNQL(urunID);
                foreach (SOSUrunFiyat.GetLasDiscountNQL_Class d in discounts)
                    discount = Convert.ToDouble(d.Price);

                //IList currentPrice = context.QueryObjects("SOSURUNFIYAT", "SOSURUNBILGISI=" + TTConnectionManager.ConnectionManager.GuidToString(urunID));
                //foreach (SOSUrunFiyat urunFiyat in currentPrice)
                //{
                //    if (urunFiyat.PriceType == SOSFiyatTurEnum.Price)
                //        currentP = (Currency)urunFiyat.Price;

                //    if (urunFiyat.PriceType == SOSFiyatTurEnum.Discount)
                //        discount = Convert.ToDouble(urunFiyat.Price);

                //    if (urunFiyat.PriceType == SOSFiyatTurEnum.KDV)
                //        kdv = Convert.ToDouble(urunFiyat.Price);
                //}

                if (drugDefinition.PackageAmount > 0)
                    packageAmount = (double)drugDefinition.PackageAmount;

                Currency UnitPrice = (currentP - (currentP * discount)) / packageAmount;

                Currency PriceWithOutDiscount = currentP / packageAmount;

                drugDefinition.Discount = discount;
                drugDefinition.CurrentPrice = currentP;

                foreach (MaterialPrice price in drugDefinition.MaterialPrices)
                {
                    if (price.PricingDetail.DateEnd >= DateTime.Now)
                    {
                        price.PricingDetail.DateEnd = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
                        if (createdObjects.Contains(price.PricingDetail) == false)
                            createdObjects.Add(price.PricingDetail);
                    }
                }

                if (drugDefinition.StockCard == null)
                {
                    IList stockCardList = context.QueryObjects("STOCKCARD", "NATOSTOCKNO  LIKE '%" + drugDefinition.Barcode + "'");
                    if (stockCardList.Count == 1)
                    {
                        drugDefinition.StockCard = (StockCard)stockCardList[0];
                    }
                }
                //errorText = errorText + "\r\n " + drugDefinition.ObjectID + "  " + drugDefinition.Barcode + "  " + drugDefinition.Name + " stok kartı bulunamamıştır.";

                PricingDetailDefinition pdd = new PricingDetailDefinition(context);
                pdd.DateStart = DateTime.Now.AddDays(1).Date;
                pdd.DateEnd = new DateTime(2050, 12, 31, 23, 59, 59);
                pdd.Description = drugDefinition.Name;
                pdd.CurrencyType = (CurrencyTypeDefinition)context.GetObject(new Guid("e3a4f2d5-4f74-406c-8258-37316ea8e9d1"), typeof(CurrencyTypeDefinition).Name);
                pdd.PricingList = (PricingListDefinition)context.GetObject(new Guid("57c5a43f-2083-433a-9f05-94c49c284436"), typeof(PricingListDefinition).Name);
                pdd.PricingListGroup = (PricingListGroupDefinition)context.GetObject(new Guid("b3e200fb-9caa-405d-9d92-01f75948b452"), typeof(PricingListGroupDefinition).Name);
                pdd.Price = UnitPrice;
                pdd.ExternalCode = drugDefinition.Barcode;
                pdd.DiscountPercent = discount;
                pdd.PriceWithOutDiscount = PriceWithOutDiscount;
                createdObjects.Add(pdd);

                MaterialPrice materialPrice = new MaterialPrice(context);
                materialPrice.Material = drugDefinition;
                materialPrice.PricingDetail = pdd;
                createdObjects.Add(materialPrice);

                createdObjects.Add(urun);
                createdObjects.Add(drugDefinition);

                context.Save();


            }
            //if (!String.IsNullOrEmpty(errorText))
            //{
            //    File.WriteAllText(@"C:\temp\StokKartıOlmayanlar_" + DateTime.Now.ToString().Replace(':', '_').Replace('.', '_').Replace(' ', '_') + ".txt", errorText.ToString());
            //}
            return createdObjects;
        }

        public SOSRpIlacProspektus CreateSOSRpIlacProspektus(string changeSet)
        {
            TTObjectContext context = new TTObjectContext(false);
            SOSRpIlacProspektus prospektus = new SOSRpIlacProspektus(context);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(changeSet);
            XmlNodeList elemlist = doc.GetElementsByTagName("Aktif");
            foreach (XmlNode node in elemlist)
            {
                if (node.ParentNode.Name.Equals("Id"))
                {
                    long sosid;
                    long.TryParse(node.InnerText, out sosid);
                    prospektus.SOSID = sosid;
                }

                if (node.ParentNode.Name.Equals("ProsBaslikId"))
                {
                    IList prosbaslik = context.QueryObjects("SOSRPPROSPEKTUSBASLIK", "SOSID ='" + node.InnerText + "'");
                    if (prosbaslik.Count > 0)
                        prospektus.SOSRpProspektusBaslik = (SOSRpProspektusBaslik)prosbaslik[0];

                }

                if (node.ParentNode.Name.Equals("ProsDetay"))
                {
                    prospektus.ProspektusDetay = node.InnerText;
                }

                if (node.ParentNode.Name.Equals("Barkod"))
                {
                    IList sosUrunBilgileri = context.QueryObjects("SOSURUNBILGISI", "BARCODE ='" + node.InnerText + "'");
                    if (sosUrunBilgileri.Count > 0)
                        prospektus.SOSUrunBilgisi = (SOSUrunBilgisi)sosUrunBilgileri[0];
                }
            }
            prospektus.IsActive = true;
            if (prospektus.SOSUrunBilgisi != null)
                context.Save();
            context.Dispose();
            return prospektus;
        }

        public SOSRpIlacProspektus UpdateSOSRpIlacProspektus(string changeSet, SOSRpIlacProspektus updateProspektus)
        {
            TTObjectContext context = new TTObjectContext(false);
            SOSRpIlacProspektus prospektus = (SOSRpIlacProspektus)context.GetObject(updateProspektus.ObjectID, "SOSRPILACPROSPEKTUS");
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(changeSet);
            XmlNodeList elemlist = doc.GetElementsByTagName("Aktif");
            foreach (XmlNode node in elemlist)
            {
                if (node.ParentNode.Name.Equals("ProsBaslikId"))
                {
                    IList prosbaslik = context.QueryObjects("SOSRPPROSPEKTUSBASLIK", "SOSID ='" + node.InnerText + "'");
                    if (prosbaslik.Count > 0)
                        prospektus.SOSRpProspektusBaslik = (SOSRpProspektusBaslik)prosbaslik[0];
                }

                if (node.ParentNode.Name.Equals("ProsDetay"))
                {
                    prospektus.ProspektusDetay = node.InnerText;
                }

            }
            prospektus.IsActive = true;
            context.Save();
            context.Dispose();
            return prospektus;
        }

        #endregion Methods

    }
}