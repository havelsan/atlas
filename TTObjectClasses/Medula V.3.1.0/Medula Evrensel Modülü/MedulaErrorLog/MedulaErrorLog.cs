
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
    public  partial class MedulaErrorLog : TTObject
    {
    /// <summary>
    /// İşlem
    /// </summary>
        public string ErorrApplicationName
        {
            get
            {
                try
                {
#region ErorrApplicationName_GetScript                    
                    return BaseMedulaWLAction.ObjectDef.ApplicationName;
#endregion ErorrApplicationName_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "ErorrApplicationName") + " : " + ex.Message, ex);
                }
            }
        }

        protected void PreTransition_New2Completed()
        {
            // From State : New   To State : Completed
#region PreTransition_New2Completed
            
            


            if (ResponseXML == null)
                throw new TTException("Medula Cevap boş olduğundan işlem tamamlanamaz.");

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(ResponseXML.ToString());
            XmlElement root = xmlDocument.DocumentElement;
            XmlNode node = root.SelectSingleNode("sonucKodu");

            string sonucKodu = (node == null ? string.Empty : node.InnerXml.Trim());
            if (string.IsNullOrEmpty(sonucKodu) == false && sonucKodu.Equals("0000"))
            {
                node = root.SelectSingleNode("sonucMesaji");
                string sonucMesaji = (node == null ? string.Empty : node.InnerXml.Trim());
                if (BaseMedulaWLAction is IlacAra)
                {
                    IlacAra ilacAra = (IlacAra)BaseMedulaWLAction;
                    ilacAra.ilacAraGirisDVO.ilacAraCevapDVO.sonucKodu = sonucKodu;
                    ilacAra.ilacAraGirisDVO.ilacAraCevapDVO.sonucMesaji = sonucMesaji;

                    XmlNode nodeIlaclar = root.SelectSingleNode("ilaclar");
                    if (nodeIlaclar.ChildNodes.Count > 0)
                    {
                        foreach (XmlNode nodeIlac in nodeIlaclar.ChildNodes)
                        {
                            node = nodeIlac.SelectSingleNode("barkod");
                            string barkod = (node == null ? string.Empty : node.InnerXml.Trim());
                            node = nodeIlac.SelectSingleNode("ilacAdi");
                            string ilacAdi = (node == null ? string.Empty : node.InnerXml.Trim());
                            node = nodeIlac.SelectSingleNode("kullanimBirimi");
                            double? kullanimBirimi = null;
                            string stringKullanimBirimi = (node == null ? string.Empty : node.InnerXml.Trim());
                            if (string.IsNullOrEmpty(stringKullanimBirimi) == false)
                                kullanimBirimi = double.Parse(stringKullanimBirimi);
                            IlacListDVO ilacListDVO = null;
                            if (string.IsNullOrEmpty(barkod) == false && string.IsNullOrEmpty(ilacAdi) == false)
                            {
                                ilacListDVO = ilacAra.ilacAraGirisDVO.ilacAraCevapDVO.ilaclar.AddNew();
                                ilacListDVO.barkod = barkod;
                                ilacListDVO.ilacAdi = ilacAdi;
                                ilacListDVO.kullanimBirimi = kullanimBirimi;
                            }
                            if (ilacListDVO != null)
                            {
                                XmlNode nodeFiyatlar = nodeIlac.SelectSingleNode("ilacFiyatlari");
                                if (nodeFiyatlar.ChildNodes.Count > 0)
                                {
                                    foreach (XmlNode nodeFiyat in nodeFiyatlar.ChildNodes)
                                    {
                                        node = nodeFiyat.SelectSingleNode(TTUtils.CultureService.GetText("M14352", "fiyat"));
                                        double? fiyat = null;
                                        string stringFiyat = (node == null ? string.Empty : node.InnerXml.Trim());
                                        if (string.IsNullOrEmpty(stringFiyat) == false)
                                            fiyat = double.Parse(stringFiyat);

                                        node = nodeFiyat.SelectSingleNode("gecerlilikTarihi");
                                        string gecerlilikTarihi = (node == null ? string.Empty : node.InnerXml.Trim());
                                        if (fiyat.HasValue && string.IsNullOrEmpty(gecerlilikTarihi) == false)
                                        {
                                            FiyatListDVO fiyatListDVO = ilacListDVO.ilacFiyatlari.AddNew();
                                            fiyatListDVO.fiyat = fiyat;
                                            fiyatListDVO.gecerlilikTarihi = gecerlilikTarihi;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    throw new TTException(TTUtils.CultureService.GetText("M25906", "Hatalı tip Medula Cevap işlenemedi."));
                }
            }

            //            if (BaseMedulaWLAction is BaseHastaKabul)
            //            {
            //                XmlDocument xmlDocument = new XmlDocument();
            //                xmlDocument.LoadXml(ResponseXML.ToString());
            //                XmlElement root = xmlDocument.DocumentElement;
            //
            //                ProvizyonCevapDVO provizyonCevapDVO = new ProvizyonCevapDVO(this.ObjectContext);
            //                XmlNode node = root.SelectSingleNode("sonucKodu");
            //                provizyonCevapDVO.sonucKodu = (node == null ? string.Empty : node.InnerXml.Trim());
            //                node = root.SelectSingleNode("sonucMesaji");
            //                provizyonCevapDVO.sonucMesaji = (node == null ? string.Empty : node.InnerXml.Trim());
            //                node = root.SelectSingleNode("takipNo");
            //                provizyonCevapDVO.takipNo = (node == null ? string.Empty : node.InnerXml.Trim());
            //                node = root.SelectSingleNode("hastaBasvuruNo");
            //                provizyonCevapDVO.hastaBasvuruNo = (node == null ? string.Empty : node.InnerXml.Trim());
            //
            //                ((BaseHastaKabul)BaseMedulaWLAction).provizyonGirisDVO.provizyonCevapDVO = provizyonCevapDVO;
            //            }
            //            else
            //            {
            //                throw new TTException("Hatalı tip Medula Cevap işlenemedi.");
            //            }




#endregion PreTransition_New2Completed
        }

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(MedulaErrorLog).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == MedulaErrorLog.States.New && toState == MedulaErrorLog.States.Completed)
                PreTransition_New2Completed();
        }

    }
}