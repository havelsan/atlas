
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
    public partial class BaseDentalEpisodeActionForm : BaseNewDoctorExaminationForm
    {
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
        }

        protected override void PreScript()
        {
#region BaseDentalEpisodeActionForm_PreScript
    base.PreScript();
            
            // MT 05.07.2013 Farklı uzmanlık dallarından kaydı yapılmış hastalara diş işlemlerinin başlatılmasını önler.
//            SpecialityDefinition dentalSpeciality = this._BaseDentalEpisodeAction.MasterResource.ResourceSpecialities[0].Speciality;
//            if (dentalSpeciality != null)
//            {
//                //Guid oid = dentalSpeciality.ObjectID;
//                //Guid mainID = this._BaseDentalEpisodeAction.PatientAdmission.Episode.MainSpeciality.ObjectID;
//                if (this._BaseDentalEpisodeAction.PatientAdmission != null)
//                {
//                    if (dentalSpeciality.ObjectID != this._BaseDentalEpisodeAction.PatientAdmission.Episode.MainSpeciality.ObjectID)
//                    {
//                        throw new TTException(SystemMessage.GetMessage(90, "HATA! Bu episode için Diş İşlemleri başlatılamaz." ));  // 90: code ?
//                    }
//                }    
//            }
               
            //if (examinationSpeciality.ObjectID == episode.MainSpeciality.ObjectID && episode.ReasonForAdmission.Type != ReasonForAdmissionTypeEnum.Daily && this._PatientAdmission.Episode.ReasonForAdmission.Type != ReasonForAdmissionTypeEnum.Daily)
            //     throw new TTException(SystemMessage.GetMessage(90, "HATA! Bu episode için Diş İşlemleri başlatılamaz." ));  // 90: code ?
//                public class _DentalExaminationForm : DentalExaminationForm
//            {
//                protected override void PreScript()
//                {
               //  _DentalExamination.MasterResource.ResourceSpecialities[0];
                //examinationSpeciality = masterResource.ResourceSpecialities.Speciality[0];
            
            if (this._BaseDentalEpisodeAction.ToothNumbers != null)
            {
                foreach (string tooth in Common.ParseString(this._BaseDentalEpisodeAction.ToothNumbers.ToString(), ','))
                {
                    switch (tooth.ToString())
                    {
                        case "11":
                            this.ch11.Value = true;
                            break;
                        case "12":
                            this.ch12.Value = true;
                            break;
                        case "13":
                            this.ch13.Value = true;
                            break;
                        case "14":
                            this.ch14.Value = true;
                            break;
                        case "15":
                            this.ch15.Value = true;
                            break;
                        case "16":
                            this.ch16.Value = true;
                            break;
                        case "17":
                            this.ch17.Value = true;
                            break;
                        case "18":
                            this.ch18.Value = true;
                            break;
                        case "21":
                            this.ch21.Value = true;
                            break;
                        case "22":
                            this.ch22.Value = true;
                            break;
                        case "23":
                            this.ch23.Value = true;
                            break;
                        case "24":
                            this.ch24.Value = true;
                            break;
                        case "25":
                            this.ch25.Value = true;
                            break;
                        case "26":
                            this.ch26.Value = true;
                            break;
                        case "27":
                            this.ch27.Value = true;
                            break;
                        case "28":
                            this.ch28.Value = true;
                            break;
                        case "31":
                            this.ch31.Value = true;
                            break;
                        case "32":
                            this.ch32.Value = true;
                            break;
                        case "33":
                            this.ch33.Value = true;
                            break;
                        case "34":
                            this.ch34.Value = true;
                            break;
                        case "35":
                            this.ch35.Value = true;
                            break;
                        case "36":
                            this.ch36.Value = true;
                            break;
                        case "37":
                            this.ch37.Value = true;
                            break;
                        case "38":
                            this.ch38.Value = true;
                            break;
                        case "41":
                            this.ch41.Value = true;
                            break;
                        case "42":
                            this.ch42.Value = true;
                            break;
                        case "43":
                            this.ch43.Value = true;
                            break;
                        case "44":
                            this.ch44.Value = true;
                            break;
                        case "45":
                            this.ch45.Value = true;
                            break;
                        case "46":
                            this.ch46.Value = true;
                            break;
                        case "47":
                            this.ch47.Value = true;
                            break;
                        case "48":
                            this.ch48.Value = true;
                            break;
                        case "51":
                            this.ch51.Value = true;
                            break;
                        case "52":
                            this.ch52.Value = true;
                            break;
                        case "53":
                            this.ch53.Value = true;
                            break;
                        case "54":
                            this.ch54.Value = true;
                            break;
                        case "55":
                            this.ch55.Value = true;
                            break;
                        case "61":
                            this.ch61.Value = true;
                            break;
                        case "62":
                            this.ch62.Value = true;
                            break;
                        case "63":
                            this.ch63.Value = true;
                            break;
                        case "64":
                            this.ch64.Value = true;
                            break;
                        case "65":
                            this.ch65.Value = true;
                            break;
                        case "71":
                            this.ch71.Value = true;
                            break;
                        case "72":
                            this.ch72.Value = true;
                            break;
                        case "73":
                            this.ch73.Value = true;
                            break;
                        case "74":
                            this.ch74.Value = true;
                            break;
                        case "75":
                            this.ch75.Value = true;
                            break;
                        case "81":
                            this.ch81.Value = true;
                            break;
                        case "82":
                            this.ch82.Value = true;
                            break;
                        case "83":
                            this.ch83.Value = true;
                            break;
                        case "84":
                            this.ch84.Value = true;
                            break;
                        case "85":
                            this.ch85.Value = true;
                            break;
                        case "10":
                            this.ch11.Value = true;
                            this.ch12.Value = true;
                            this.ch13.Value = true;
                            this.ch14.Value = true;
                            this.ch15.Value = true;
                            this.ch16.Value = true;
                            this.ch17.Value = true;
                            this.ch18.Value = true;
                            break;
                        case "20":
                            this.ch21.Value = true;
                            this.ch22.Value = true;
                            this.ch23.Value = true;
                            this.ch24.Value = true;
                            this.ch25.Value = true;
                            this.ch26.Value = true;
                            this.ch27.Value = true;
                            this.ch28.Value = true;
                            break;
                        case "30":
                            this.ch31.Value = true;
                            this.ch32.Value = true;
                            this.ch33.Value = true;
                            this.ch34.Value = true;
                            this.ch35.Value = true;
                            this.ch36.Value = true;
                            this.ch37.Value = true;
                            this.ch38.Value = true;
                            break;
                        case "40":
                            this.ch41.Value = true;
                            this.ch42.Value = true;
                            this.ch43.Value = true;
                            this.ch44.Value = true;
                            this.ch45.Value = true;
                            this.ch46.Value = true;
                            this.ch47.Value = true;
                            this.ch48.Value = true;
                            break;
                        case "50":
                            this.ch51.Value = true;
                            this.ch52.Value = true;
                            this.ch53.Value = true;
                            this.ch54.Value = true;
                            this.ch55.Value = true;
                            break;
                        case "60":
                            this.ch61.Value = true;
                            this.ch62.Value = true;
                            this.ch63.Value = true;
                            this.ch64.Value = true;
                            this.ch65.Value = true;
                            break;
                        case "70":
                            this.ch71.Value = true;
                            this.ch72.Value = true;
                            this.ch73.Value = true;
                            this.ch74.Value = true;
                            this.ch75.Value = true;
                            break;
                        case "80":
                            this.ch81.Value = true;
                            this.ch82.Value = true;
                            this.ch83.Value = true;
                            this.ch84.Value = true;
                            this.ch85.Value = true;
                            break;
                        case "1020":
                            this.ch11.Value = true;
                            this.ch12.Value = true;
                            this.ch13.Value = true;
                            this.ch14.Value = true;
                            this.ch15.Value = true;
                            this.ch16.Value = true;
                            this.ch17.Value = true;
                            this.ch18.Value = true;
                            this.ch21.Value = true;
                            this.ch22.Value = true;
                            this.ch23.Value = true;
                            this.ch24.Value = true;
                            this.ch25.Value = true;
                            this.ch26.Value = true;
                            this.ch27.Value = true;
                            this.ch28.Value = true;
                            break;
                        case "3040":
                            this.ch31.Value = true;
                            this.ch32.Value = true;
                            this.ch33.Value = true;
                            this.ch34.Value = true;
                            this.ch35.Value = true;
                            this.ch36.Value = true;
                            this.ch37.Value = true;
                            this.ch38.Value = true;
                            this.ch41.Value = true;
                            this.ch42.Value = true;
                            this.ch43.Value = true;
                            this.ch44.Value = true;
                            this.ch45.Value = true;
                            this.ch46.Value = true;
                            this.ch47.Value = true;
                            this.ch48.Value = true;
                            break;
                        case "5060":
                            this.ch51.Value = true;
                            this.ch52.Value = true;
                            this.ch53.Value = true;
                            this.ch54.Value = true;
                            this.ch55.Value = true;
                            this.ch61.Value = true;
                            this.ch62.Value = true;
                            this.ch63.Value = true;
                            this.ch64.Value = true;
                            this.ch65.Value = true;
                            break;
                        case "7080":
                            this.ch71.Value = true;
                            this.ch72.Value = true;
                            this.ch73.Value = true;
                            this.ch74.Value = true;
                            this.ch75.Value = true;
                            this.ch81.Value = true;
                            this.ch82.Value = true;
                            this.ch83.Value = true;
                            this.ch84.Value = true;
                            this.ch85.Value = true;
                            break;
                        case "1234":
                            this.ch11.Value = true;
                            this.ch12.Value = true;
                            this.ch13.Value = true;
                            this.ch14.Value = true;
                            this.ch15.Value = true;
                            this.ch16.Value = true;
                            this.ch17.Value = true;
                            this.ch18.Value = true;
                            this.ch21.Value = true;
                            this.ch22.Value = true;
                            this.ch23.Value = true;
                            this.ch24.Value = true;
                            this.ch25.Value = true;
                            this.ch26.Value = true;
                            this.ch27.Value = true;
                            this.ch28.Value = true;
                            this.ch31.Value = true;
                            this.ch32.Value = true;
                            this.ch33.Value = true;
                            this.ch34.Value = true;
                            this.ch35.Value = true;
                            this.ch36.Value = true;
                            this.ch37.Value = true;
                            this.ch38.Value = true;
                            this.ch41.Value = true;
                            this.ch42.Value = true;
                            this.ch43.Value = true;
                            this.ch44.Value = true;
                            this.ch45.Value = true;
                            this.ch46.Value = true;
                            this.ch47.Value = true;
                            this.ch48.Value = true;
                            break;
                        case "5678":
                            this.ch51.Value = true;
                            this.ch52.Value = true;
                            this.ch53.Value = true;
                            this.ch54.Value = true;
                            this.ch55.Value = true;
                            this.ch61.Value = true;
                            this.ch62.Value = true;
                            this.ch63.Value = true;
                            this.ch64.Value = true;
                            this.ch65.Value = true;
                            this.ch71.Value = true;
                            this.ch72.Value = true;
                            this.ch73.Value = true;
                            this.ch74.Value = true;
                            this.ch75.Value = true;
                            this.ch81.Value = true;
                            this.ch82.Value = true;
                            this.ch83.Value = true;
                            this.ch84.Value = true;
                            this.ch85.Value = true;
                            break;
                    }
                }
            }
#endregion BaseDentalEpisodeActionForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region BaseDentalEpisodeActionForm_PostScript
    base.PostScript(transDef);
            this._BaseDentalEpisodeAction.ToothNumbers = "";
            if (this.ch11.Value == true)
                this._BaseDentalEpisodeAction.ToothNumbers += "11,";
            if (this.ch12.Value == true)
                this._BaseDentalEpisodeAction.ToothNumbers += "12,";
            if (this.ch13.Value == true)
                this._BaseDentalEpisodeAction.ToothNumbers += "13,";
            if (this.ch14.Value == true)
                this._BaseDentalEpisodeAction.ToothNumbers += "14,";
            if (this.ch15.Value == true)
                this._BaseDentalEpisodeAction.ToothNumbers += "15,";
            if (this.ch16.Value == true)
                this._BaseDentalEpisodeAction.ToothNumbers += "16,";
            if (this.ch17.Value == true)
                this._BaseDentalEpisodeAction.ToothNumbers += "17,";
            if (this.ch18.Value == true)
                this._BaseDentalEpisodeAction.ToothNumbers += "18,";
            if (this.ch21.Value == true)
                this._BaseDentalEpisodeAction.ToothNumbers += "21,";
            if (this.ch22.Value == true)
                this._BaseDentalEpisodeAction.ToothNumbers += "22,";
            if (this.ch23.Value == true)
                this._BaseDentalEpisodeAction.ToothNumbers += "23,";
            if (this.ch24.Value == true)
                this._BaseDentalEpisodeAction.ToothNumbers += "24,";
            if (this.ch25.Value == true)
                this._BaseDentalEpisodeAction.ToothNumbers += "25,";
            if (this.ch26.Value == true)
                this._BaseDentalEpisodeAction.ToothNumbers += "26,";
            if (this.ch27.Value == true)
                this._BaseDentalEpisodeAction.ToothNumbers += "27,";
            if (this.ch28.Value == true)
                this._BaseDentalEpisodeAction.ToothNumbers += "28,";
            if (this.ch31.Value == true)
                this._BaseDentalEpisodeAction.ToothNumbers += "31,";
            if (this.ch32.Value == true)
                this._BaseDentalEpisodeAction.ToothNumbers += "32,";
            if (this.ch33.Value == true)
                this._BaseDentalEpisodeAction.ToothNumbers += "33,";
            if (this.ch34.Value == true)
                this._BaseDentalEpisodeAction.ToothNumbers += "34,";
            if (this.ch35.Value == true)
                this._BaseDentalEpisodeAction.ToothNumbers += "35,";
            if (this.ch36.Value == true)
                this._BaseDentalEpisodeAction.ToothNumbers += "36,";
            if (this.ch37.Value == true)
                this._BaseDentalEpisodeAction.ToothNumbers += "37,";
            if (this.ch38.Value == true)
                this._BaseDentalEpisodeAction.ToothNumbers += "38,";
            if (this.ch41.Value == true)
                this._BaseDentalEpisodeAction.ToothNumbers += "41,";
            if (this.ch42.Value == true)
                this._BaseDentalEpisodeAction.ToothNumbers += "42,";
            if (this.ch43.Value == true)
                this._BaseDentalEpisodeAction.ToothNumbers += "43,";
            if (this.ch44.Value == true)
                this._BaseDentalEpisodeAction.ToothNumbers += "44,";
            if (this.ch45.Value == true)
                this._BaseDentalEpisodeAction.ToothNumbers += "45,";
            if (this.ch46.Value == true)
                this._BaseDentalEpisodeAction.ToothNumbers += "46,";
            if (this.ch47.Value == true)
                this._BaseDentalEpisodeAction.ToothNumbers += "47,";
            if (this.ch48.Value == true)
                this._BaseDentalEpisodeAction.ToothNumbers += "48,";
            if (this.ch51.Value == true)
                this._BaseDentalEpisodeAction.ToothNumbers += "51,";
            if (this.ch52.Value == true)
                this._BaseDentalEpisodeAction.ToothNumbers += "52,";
            if (this.ch53.Value == true)
                this._BaseDentalEpisodeAction.ToothNumbers += "53,";
            if (this.ch54.Value == true)
                this._BaseDentalEpisodeAction.ToothNumbers += "54,";
            if (this.ch55.Value == true)
                this._BaseDentalEpisodeAction.ToothNumbers += "55,";
            if (this.ch61.Value == true)
                this._BaseDentalEpisodeAction.ToothNumbers += "61,";
            if (this.ch62.Value == true)
                this._BaseDentalEpisodeAction.ToothNumbers += "62,";
            if (this.ch63.Value == true)
                this._BaseDentalEpisodeAction.ToothNumbers += "63,";
            if (this.ch64.Value == true)
                this._BaseDentalEpisodeAction.ToothNumbers += "64,";
            if (this.ch65.Value == true)
                this._BaseDentalEpisodeAction.ToothNumbers += "65,";
            if (this.ch71.Value == true)
                this._BaseDentalEpisodeAction.ToothNumbers += "71,";
            if (this.ch72.Value == true)
                this._BaseDentalEpisodeAction.ToothNumbers += "72,";
            if (this.ch73.Value == true)
                this._BaseDentalEpisodeAction.ToothNumbers += "73,";
            if (this.ch74.Value == true)
                this._BaseDentalEpisodeAction.ToothNumbers += "74,";
            if (this.ch75.Value == true)
                this._BaseDentalEpisodeAction.ToothNumbers += "75,";
            if (this.ch81.Value == true)
                this._BaseDentalEpisodeAction.ToothNumbers += "81,";
            if (this.ch82.Value == true)
                this._BaseDentalEpisodeAction.ToothNumbers += "82,";
            if (this.ch83.Value == true)
                this._BaseDentalEpisodeAction.ToothNumbers += "83,";
            if (this.ch84.Value == true)
                this._BaseDentalEpisodeAction.ToothNumbers += "84,";
            if (this.ch85.Value == true)
                this._BaseDentalEpisodeAction.ToothNumbers += "85,";
#endregion BaseDentalEpisodeActionForm_PostScript

            }
                }
}