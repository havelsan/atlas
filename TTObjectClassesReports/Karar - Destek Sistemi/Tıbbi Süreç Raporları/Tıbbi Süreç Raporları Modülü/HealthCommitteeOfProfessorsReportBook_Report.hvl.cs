
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

using TTReportTool;
using TTVisual;
namespace TTReportClasses
{
    /// <summary>
    /// Sağlık Kurulu Defteri (Profesörler Sağlık Kurulu)
    /// </summary>
    public partial class HealthCommitteeOfProfessorsReportBook : TTReport
    {
        public class ReportRuntimeParameters 
        {
        }

        public partial class CAPTIONGroup : TTReportGroup
        {
            public HealthCommitteeOfProfessorsReportBook MyParentReport
            {
                get { return (HealthCommitteeOfProfessorsReportBook)ParentReport; }
            }

            new public CAPTIONGroupHeader Header()
            {
                return (CAPTIONGroupHeader)_header;
            }

            new public CAPTIONGroupFooter Footer()
            {
                return (CAPTIONGroupFooter)_footer;
            }

            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField NewField131 { get {return Header().NewField131;} }
            public TTReportField NewField132 { get {return Header().NewField132;} }
            public TTReportField NewField133 { get {return Header().NewField133;} }
            public TTReportField NewField134 { get {return Header().NewField134;} }
            public CAPTIONGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public CAPTIONGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new CAPTIONGroupHeader(this);
                _footer = new CAPTIONGroupFooter(this);

            }

            public partial class CAPTIONGroupHeader : TTReportSection
            {
                public HealthCommitteeOfProfessorsReportBook MyParentReport
                {
                    get { return (HealthCommitteeOfProfessorsReportBook)ParentReport; }
                }
                
                public TTReportField NewField11;
                public TTReportField NewField1;
                public TTReportField NewField12;
                public TTReportField NewField13;
                public TTReportField NewField131;
                public TTReportField NewField132;
                public TTReportField NewField133;
                public TTReportField NewField134; 
                public CAPTIONGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 28;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 2, 192, 10, false);
                    NewField11.Name = "NewField11";
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.TextFont.Size = 14;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"SAĞLIK KURULU DEFTERİ";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 3, 17, 18, 28, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Rapor Nu ve Tarihi";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 17, 54, 28, false);
                    NewField12.Name = "NewField12";
                    NewField12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.MultiLine = EvetHayirEnum.ehEvet;
                    NewField12.WordBreak = EvetHayirEnum.ehEvet;
                    NewField12.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"Muayeneye Gönderen Makam Tarih ve Nu";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 17, 103, 28, false);
                    NewField13.Name = "NewField13";
                    NewField13.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13.CaseFormat = CaseFormatEnum.fcUpperCase;
                    NewField13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13.MultiLine = EvetHayirEnum.ehEvet;
                    NewField13.WordBreak = EvetHayirEnum.ehEvet;
                    NewField13.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"AÇIK KÜNYESİ";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 17, 163, 28, false);
                    NewField131.Name = "NewField131";
                    NewField131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField131.CaseFormat = CaseFormatEnum.fcUpperCase;
                    NewField131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField131.MultiLine = EvetHayirEnum.ehEvet;
                    NewField131.WordBreak = EvetHayirEnum.ehEvet;
                    NewField131.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField131.TextFont.Bold = true;
                    NewField131.TextFont.CharSet = 162;
                    NewField131.Value = @"GÖNDERİLEN MAKAM";

                    NewField132 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 163, 17, 211, 28, false);
                    NewField132.Name = "NewField132";
                    NewField132.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField132.CaseFormat = CaseFormatEnum.fcUpperCase;
                    NewField132.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField132.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField132.MultiLine = EvetHayirEnum.ehEvet;
                    NewField132.WordBreak = EvetHayirEnum.ehEvet;
                    NewField132.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField132.TextFont.Bold = true;
                    NewField132.TextFont.CharSet = 162;
                    NewField132.Value = @"TEŞHİS";

                    NewField133 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 17, 256, 28, false);
                    NewField133.Name = "NewField133";
                    NewField133.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField133.CaseFormat = CaseFormatEnum.fcUpperCase;
                    NewField133.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField133.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField133.MultiLine = EvetHayirEnum.ehEvet;
                    NewField133.WordBreak = EvetHayirEnum.ehEvet;
                    NewField133.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField133.TextFont.Bold = true;
                    NewField133.TextFont.CharSet = 162;
                    NewField133.Value = @"KARAR";

                    NewField134 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 256, 17, 291, 28, false);
                    NewField134.Name = "NewField134";
                    NewField134.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField134.CaseFormat = CaseFormatEnum.fcUpperCase;
                    NewField134.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField134.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField134.MultiLine = EvetHayirEnum.ehEvet;
                    NewField134.WordBreak = EvetHayirEnum.ehEvet;
                    NewField134.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField134.TextFont.Bold = true;
                    NewField134.TextFont.CharSet = 162;
                    NewField134.Value = @"FOTOĞRAF";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11.CalcValue = NewField11.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField131.CalcValue = NewField131.Value;
                    NewField132.CalcValue = NewField132.Value;
                    NewField133.CalcValue = NewField133.Value;
                    NewField134.CalcValue = NewField134.Value;
                    return new TTReportObject[] { NewField11,NewField1,NewField12,NewField13,NewField131,NewField132,NewField133,NewField134};
                }
            }
            public partial class CAPTIONGroupFooter : TTReportSection
            {
                public HealthCommitteeOfProfessorsReportBook MyParentReport
                {
                    get { return (HealthCommitteeOfProfessorsReportBook)ParentReport; }
                }
                 
                public CAPTIONGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public CAPTIONGroup CAPTION;

        public partial class MAINGroup : TTReportGroup
        {
            public HealthCommitteeOfProfessorsReportBook MyParentReport
            {
                get { return (HealthCommitteeOfProfessorsReportBook)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField REPORTNODATE { get {return Body().REPORTNODATE;} }
            public TTReportField SENDERDATENO { get {return Body().SENDERDATENO;} }
            public TTReportField INFOS { get {return Body().INFOS;} }
            public TTReportField NewField11 { get {return Body().NewField11;} }
            public TTReportField NewField111 { get {return Body().NewField111;} }
            public TTReportField NewField112 { get {return Body().NewField112;} }
            public TTReportField NewField113 { get {return Body().NewField113;} }
            public TTReportField BOY { get {return Body().BOY;} }
            public TTReportField AGIRLIK { get {return Body().AGIRLIK;} }
            public TTReportField CEVRE { get {return Body().CEVRE;} }
            public TTReportField FARK { get {return Body().FARK;} }
            public TTReportField GONDERILEN { get {return Body().GONDERILEN;} }
            public TTReportField TESHIS { get {return Body().TESHIS;} }
            public TTReportField KARAR { get {return Body().KARAR;} }
            public TTReportField FOTO { get {return Body().FOTO;} }
            public TTReportField OBJECTID { get {return Body().OBJECTID;} }
            public MAINGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MAINGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<HealthCommitteeOfProfessors.GetAllHealthCommitteeOfProfessors_Class>("GetAllHealthCommitteeOfProfessors", HealthCommitteeOfProfessors.GetAllHealthCommitteeOfProfessors());
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MAINGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class MAINGroupBody : TTReportSection
            {
                public HealthCommitteeOfProfessorsReportBook MyParentReport
                {
                    get { return (HealthCommitteeOfProfessorsReportBook)ParentReport; }
                }
                
                public TTReportField REPORTNODATE;
                public TTReportField SENDERDATENO;
                public TTReportField INFOS;
                public TTReportField NewField11;
                public TTReportField NewField111;
                public TTReportField NewField112;
                public TTReportField NewField113;
                public TTReportField BOY;
                public TTReportField AGIRLIK;
                public TTReportField CEVRE;
                public TTReportField FARK;
                public TTReportField GONDERILEN;
                public TTReportField TESHIS;
                public TTReportField KARAR;
                public TTReportField FOTO;
                public TTReportField OBJECTID; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 52;
                    RepeatCount = 0;
                    
                    REPORTNODATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 2, 0, 18, 52, false);
                    REPORTNODATE.Name = "REPORTNODATE";
                    REPORTNODATE.DrawStyle = DrawStyleConstants.vbSolid;
                    REPORTNODATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    REPORTNODATE.TextFont.Size = 9;
                    REPORTNODATE.TextFont.CharSet = 162;
                    REPORTNODATE.Value = @"{#RAPORNO#} - {#RAPORTARIHI#}";

                    SENDERDATENO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 0, 54, 52, false);
                    SENDERDATENO.Name = "SENDERDATENO";
                    SENDERDATENO.DrawStyle = DrawStyleConstants.vbSolid;
                    SENDERDATENO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SENDERDATENO.TextFont.Size = 9;
                    SENDERDATENO.TextFont.CharSet = 162;
                    SENDERDATENO.Value = @"{#MAKAM#}";

                    INFOS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 0, 103, 40, false);
                    INFOS.Name = "INFOS";
                    INFOS.DrawStyle = DrawStyleConstants.vbSolid;
                    INFOS.FieldType = ReportFieldTypeEnum.ftVariable;
                    INFOS.TextFont.Size = 9;
                    INFOS.TextFont.CharSet = 162;
                    INFOS.Value = @"{#PNAME#} {#PSURNAME#} T.C. No: {#TCNO#} Baba Adı: {#FATHERNAME#}";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 40, 65, 45, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11.TextFont.Size = 9;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"Boy";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 40, 76, 45, false);
                    NewField111.Name = "NewField111";
                    NewField111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField111.TextFont.Size = 9;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"Ağırlık";

                    NewField112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 76, 40, 95, 45, false);
                    NewField112.Name = "NewField112";
                    NewField112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112.WordBreak = EvetHayirEnum.ehEvet;
                    NewField112.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField112.TextFont.Size = 9;
                    NewField112.TextFont.Bold = true;
                    NewField112.TextFont.CharSet = 162;
                    NewField112.Value = @"Göğüs Çevresi";

                    NewField113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 40, 103, 45, false);
                    NewField113.Name = "NewField113";
                    NewField113.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField113.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField113.MultiLine = EvetHayirEnum.ehEvet;
                    NewField113.WordBreak = EvetHayirEnum.ehEvet;
                    NewField113.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField113.TextFont.Size = 9;
                    NewField113.TextFont.Bold = true;
                    NewField113.TextFont.CharSet = 162;
                    NewField113.Value = @"Fark";

                    BOY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 45, 65, 52, false);
                    BOY.Name = "BOY";
                    BOY.DrawStyle = DrawStyleConstants.vbSolid;
                    BOY.FieldType = ReportFieldTypeEnum.ftVariable;
                    BOY.TextFont.Size = 9;
                    BOY.TextFont.CharSet = 162;
                    BOY.Value = @"{#BOY#}";

                    AGIRLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 45, 76, 52, false);
                    AGIRLIK.Name = "AGIRLIK";
                    AGIRLIK.DrawStyle = DrawStyleConstants.vbSolid;
                    AGIRLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    AGIRLIK.TextFont.Size = 9;
                    AGIRLIK.TextFont.CharSet = 162;
                    AGIRLIK.Value = @"{#KILO#}";

                    CEVRE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 76, 45, 95, 52, false);
                    CEVRE.Name = "CEVRE";
                    CEVRE.DrawStyle = DrawStyleConstants.vbSolid;
                    CEVRE.FieldType = ReportFieldTypeEnum.ftVariable;
                    CEVRE.TextFont.Size = 9;
                    CEVRE.TextFont.CharSet = 162;
                    CEVRE.Value = @"";

                    FARK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 45, 103, 52, false);
                    FARK.Name = "FARK";
                    FARK.DrawStyle = DrawStyleConstants.vbSolid;
                    FARK.FieldType = ReportFieldTypeEnum.ftVariable;
                    FARK.TextFont.Size = 9;
                    FARK.TextFont.CharSet = 162;
                    FARK.Value = @"";

                    GONDERILEN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 0, 163, 52, false);
                    GONDERILEN.Name = "GONDERILEN";
                    GONDERILEN.DrawStyle = DrawStyleConstants.vbSolid;
                    GONDERILEN.FieldType = ReportFieldTypeEnum.ftVariable;
                    GONDERILEN.TextFont.Size = 9;
                    GONDERILEN.TextFont.CharSet = 162;
                    GONDERILEN.Value = @"";

                    TESHIS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 163, 0, 211, 52, false);
                    TESHIS.Name = "TESHIS";
                    TESHIS.DrawStyle = DrawStyleConstants.vbSolid;
                    TESHIS.FieldType = ReportFieldTypeEnum.ftVariable;
                    TESHIS.TextFont.Size = 9;
                    TESHIS.TextFont.CharSet = 162;
                    TESHIS.Value = @"";

                    KARAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 0, 256, 52, false);
                    KARAR.Name = "KARAR";
                    KARAR.DrawStyle = DrawStyleConstants.vbSolid;
                    KARAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    KARAR.TextFont.Size = 9;
                    KARAR.TextFont.CharSet = 162;
                    KARAR.Value = @"";

                    FOTO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 256, 0, 291, 52, false);
                    FOTO.Name = "FOTO";
                    FOTO.DrawStyle = DrawStyleConstants.vbSolid;
                    FOTO.FieldType = ReportFieldTypeEnum.ftVariable;
                    FOTO.TextFont.Size = 9;
                    FOTO.TextFont.CharSet = 162;
                    FOTO.Value = @"";

                    OBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 321, 11, 346, 16, false);
                    OBJECTID.Name = "OBJECTID";
                    OBJECTID.Visible = EvetHayirEnum.ehHayir;
                    OBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID.Value = @"{#TTOBJECTID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HealthCommitteeOfProfessors.GetAllHealthCommitteeOfProfessors_Class dataset_GetAllHealthCommitteeOfProfessors = ParentGroup.rsGroup.GetCurrentRecord<HealthCommitteeOfProfessors.GetAllHealthCommitteeOfProfessors_Class>(0);
                    REPORTNODATE.CalcValue = (dataset_GetAllHealthCommitteeOfProfessors != null ? Globals.ToStringCore(dataset_GetAllHealthCommitteeOfProfessors.Raporno) : "") + @" - " + (dataset_GetAllHealthCommitteeOfProfessors != null ? Globals.ToStringCore(dataset_GetAllHealthCommitteeOfProfessors.Raportarihi) : "");
                    SENDERDATENO.CalcValue = (dataset_GetAllHealthCommitteeOfProfessors != null ? Globals.ToStringCore(dataset_GetAllHealthCommitteeOfProfessors.Makam) : "");
                    INFOS.CalcValue = (dataset_GetAllHealthCommitteeOfProfessors != null ? Globals.ToStringCore(dataset_GetAllHealthCommitteeOfProfessors.Pname) : "") + @" " + (dataset_GetAllHealthCommitteeOfProfessors != null ? Globals.ToStringCore(dataset_GetAllHealthCommitteeOfProfessors.Psurname) : "") + @" T.C. No: " + (dataset_GetAllHealthCommitteeOfProfessors != null ? Globals.ToStringCore(dataset_GetAllHealthCommitteeOfProfessors.Tcno) : "") + @" Baba Adı: " + (dataset_GetAllHealthCommitteeOfProfessors != null ? Globals.ToStringCore(dataset_GetAllHealthCommitteeOfProfessors.FatherName) : "");
                    NewField11.CalcValue = NewField11.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField112.CalcValue = NewField112.Value;
                    NewField113.CalcValue = NewField113.Value;
                    BOY.CalcValue = (dataset_GetAllHealthCommitteeOfProfessors != null ? Globals.ToStringCore(dataset_GetAllHealthCommitteeOfProfessors.Boy) : "");
                    AGIRLIK.CalcValue = (dataset_GetAllHealthCommitteeOfProfessors != null ? Globals.ToStringCore(dataset_GetAllHealthCommitteeOfProfessors.Kilo) : "");
                    CEVRE.CalcValue = @"";
                    FARK.CalcValue = @"";
                    GONDERILEN.CalcValue = @"";
                    TESHIS.CalcValue = @"";
                    KARAR.CalcValue = @"";
                    FOTO.CalcValue = @"";
                    OBJECTID.CalcValue = (dataset_GetAllHealthCommitteeOfProfessors != null ? Globals.ToStringCore(dataset_GetAllHealthCommitteeOfProfessors.Ttobjectid) : "");
                    return new TTReportObject[] { REPORTNODATE,SENDERDATENO,INFOS,NewField11,NewField111,NewField112,NewField113,BOY,AGIRLIK,CEVRE,FARK,GONDERILEN,TESHIS,KARAR,FOTO,OBJECTID};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    string sObjectID = this.OBJECTID.CalcValue.ToString();
            TTObjectContext context = new TTObjectContext(true);
            HealthCommitteeOfProfessors hcp = (HealthCommitteeOfProfessors)context.GetObject(new Guid(sObjectID),"HealthCommitteeOfProfessors");
            
            if(hcp == null)
                throw new Exception("Rapor Profesörler Sağlık Kurulu işlemi üzerinden alınmalıdır.\r\nReason: HealthCommitteeOfProfessors is null");

            //Tanı
            int nCount = 1;
            this.TESHIS.CalcValue = "";
            BindingList<HealthCommitteeOfProfessors_DiagnosisGrid.GetDiagnosisByParent_Class> pDiagnosis = HealthCommitteeOfProfessors_DiagnosisGrid.GetDiagnosisByParent(sObjectID);
            foreach(HealthCommitteeOfProfessors_DiagnosisGrid.GetDiagnosisByParent_Class pGrid in pDiagnosis)
            {
                this.TESHIS.CalcValue += nCount.ToString() + "- " + pGrid.Tanikodu + " " + pGrid.Taniadi;
                this.TESHIS.CalcValue += "\r\n";
                nCount++;
            }
            
            if(hcp.Decision != null)
                this.KARAR.CalcValue = TTObjectClasses.Common.GetTextOfRTFString(hcp.Decision.ToString());
#endregion MAIN BODY_Script
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public HealthCommitteeOfProfessorsReportBook()
        {
            CAPTION = new CAPTIONGroup(this,"CAPTION");
            MAIN = new MAINGroup(CAPTION,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            Name = "HEALTHCOMMITTEEOFPROFESSORSREPORTBOOK";
            Caption = "Sağlık Kurulu Defteri (Profesörler Sağlık Kurulu)";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
            DontUseWatermark = EvetHayirEnum.ehEvet;
        }

        protected TTReportField SetFieldDefaultProperties()
        {
            TTReportField fd = new TTReportField();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbInvisible;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;

            fd.FieldType = ReportFieldTypeEnum.ftConstant;
            fd.CaseFormat = CaseFormatEnum.fcNoChange;
            fd.TextFormat = "";
            fd.TextColor = System.Drawing.Color.Black;
            fd.FontAngle = 0;
            fd.HorzAlign = HorizontalAlignmentEnum.haleft;
            fd.VertAlign = VerticalAlignmentEnum.vaTop;
            fd.MultiLine = EvetHayirEnum.ehHayir;
            fd.NoClip = EvetHayirEnum.ehHayir;
            fd.WordBreak = EvetHayirEnum.ehHayir;
            fd.ExpandTabs = EvetHayirEnum.ehHayir;
            fd.CrossTabRole = CrosstabRoleEnum.ctrNone;
            fd.CrossTabValues = "";
            fd.ExcelCol = 0;
            fd.ObjectDefName = "";
            fd.DataMember = "";
            fd.TextFont.Name = "Arial Narrow";
            fd.TextFont.Size = 10;
            fd.TextFont.Bold = false;
            fd.TextFont.Italic = false;
            fd.TextFont.Underline = false;
            fd.TextFont.Strikethrough = false;
            fd.TextFont.CharSet = 1;
            return fd;
        }

        protected TTReportRTF SetRTFDefaultProperties()
        {
            TTReportRTF fd = new TTReportRTF();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbInvisible;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;

            fd.CanExpand = EvetHayirEnum.ehEvet;
            fd.CanShrink = EvetHayirEnum.ehEvet;
            fd.CanSplit = EvetHayirEnum.ehEvet;
            fd.EvaluateValue = EvetHayirEnum.ehHayir;
            return fd;
        }

        protected TTReportHTML SetHTMLDefaultProperties()
        {
            TTReportHTML fd = new TTReportHTML();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbInvisible;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;

            fd.CanExpand = EvetHayirEnum.ehEvet;
            fd.CanShrink = EvetHayirEnum.ehEvet;
            fd.CanSplit = EvetHayirEnum.ehEvet;
            fd.EvaluateValue = EvetHayirEnum.ehHayir;
            return fd;
        }

        protected TTReportShape SetShapeDefaultProperties()
        {
            TTReportShape fd = new TTReportShape();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbSolid;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;
            return fd;
        }

    }
}