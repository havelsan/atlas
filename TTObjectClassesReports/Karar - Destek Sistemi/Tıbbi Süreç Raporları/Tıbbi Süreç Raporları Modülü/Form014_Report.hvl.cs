
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
    public partial class Form014 : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue("");
        }

        public partial class HeaderGroup : TTReportGroup
        {
            public Form014 MyParentReport
            {
                get { return (Form014)ParentReport; }
            }

            new public HeaderGroupHeader Header()
            {
                return (HeaderGroupHeader)_header;
            }

            new public HeaderGroupFooter Footer()
            {
                return (HeaderGroupFooter)_footer;
            }

            public TTReportField LOGO { get {return Header().LOGO;} }
            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public TTReportField Form014 { get {return Header().Form014;} }
            public TTReportField TARIH { get {return Header().TARIH;} }
            public TTReportField FORMINFO { get {return Header().FORMINFO;} }
            public TTReportField NewField11121 { get {return Header().NewField11121;} }
            public TTReportField NewField112221 { get {return Header().NewField112221;} }
            public TTReportField DOKTORADI { get {return Header().DOKTORADI;} }
            public TTReportField DOKTORSOYADI { get {return Header().DOKTORSOYADI;} }
            public TTReportField DOKTORUNVAN { get {return Header().DOKTORUNVAN;} }
            public TTReportField NewField112111 { get {return Header().NewField112111;} }
            public TTReportField NewField112311 { get {return Header().NewField112311;} }
            public TTReportField NewField1122211 { get {return Header().NewField1122211;} }
            public TTReportField NewField11212211 { get {return Header().NewField11212211;} }
            public TTReportField XXXXXXILI { get {return Header().XXXXXXILI;} }
            public TTReportField XXXXXXILCESI { get {return Header().XXXXXXILCESI;} }
            public TTReportField KURUMADI { get {return Header().KURUMADI;} }
            public TTReportField NewField11321 { get {return Header().NewField11321;} }
            public TTReportField NewField1122121 { get {return Header().NewField1122121;} }
            public TTReportField NewField1 { get {return Footer().NewField1;} }
            public TTReportShape NewLine1 { get {return Footer().NewLine1;} }
            public TTReportShape NewLine11115321 { get {return Footer().NewLine11115321;} }
            public HeaderGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public HeaderGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new HeaderGroupHeader(this);
                _footer = new HeaderGroupFooter(this);

            }

            public partial class HeaderGroupHeader : TTReportSection
            {
                public Form014 MyParentReport
                {
                    get { return (Form014)ParentReport; }
                }
                
                public TTReportField LOGO;
                public TTReportField XXXXXXBASLIK;
                public TTReportField Form014;
                public TTReportField TARIH;
                public TTReportField FORMINFO;
                public TTReportField NewField11121;
                public TTReportField NewField112221;
                public TTReportField DOKTORADI;
                public TTReportField DOKTORSOYADI;
                public TTReportField DOKTORUNVAN;
                public TTReportField NewField112111;
                public TTReportField NewField112311;
                public TTReportField NewField1122211;
                public TTReportField NewField11212211;
                public TTReportField XXXXXXILI;
                public TTReportField XXXXXXILCESI;
                public TTReportField KURUMADI;
                public TTReportField NewField11321;
                public TTReportField NewField1122121; 
                public HeaderGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 133;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 13, 36, 36, false);
                    LOGO.Name = "LOGO";
                    LOGO.FieldType = ReportFieldTypeEnum.ftOLE;
                    LOGO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LOGO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO.ExpandTabs = EvetHayirEnum.ehEvet;
                    LOGO.ObjectDefName = "HospitalEmblemDefinition";
                    LOGO.DataMember = "EMBLEM";
                    LOGO.TextFont.Name = "Courier New";
                    LOGO.Value = @"";

                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 14, 170, 42, false);
                    XXXXXXBASLIK.Name = "XXXXXXBASLIK";
                    XXXXXXBASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    XXXXXXBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.NoClip = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.TextFont.Name = "Arial";
                    XXXXXXBASLIK.TextFont.Size = 11;
                    XXXXXXBASLIK.TextFont.Bold = true;
                    XXXXXXBASLIK.TextFont.CharSet = 162;
                    XXXXXXBASLIK.Value = @"""(ACELE)"" + ""\r\n"" + ""\r\n"" + ""T.C."" + ""\r\n"" + ""SAĞLIK BAKANLIĞI"" + ""\r\n"" + ""Türkiye Halk Sağlığı Kurumu""";

                    Form014 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 94, 48, 119, 53, false);
                    Form014.Name = "Form014";
                    Form014.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    Form014.TextFont.Name = "Arial";
                    Form014.TextFont.Size = 12;
                    Form014.TextFont.Bold = true;
                    Form014.TextFont.CharSet = 162;
                    Form014.Value = @"Form 014";

                    TARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 14, 206, 20, false);
                    TARIH.Name = "TARIH";
                    TARIH.FieldType = ReportFieldTypeEnum.ftExpression;
                    TARIH.TextFormat = @"Short Date";
                    TARIH.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TARIH.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TARIH.MultiLine = EvetHayirEnum.ehEvet;
                    TARIH.WordBreak = EvetHayirEnum.ehEvet;
                    TARIH.TextFont.Size = 9;
                    TARIH.TextFont.Bold = true;
                    TARIH.TextFont.CharSet = 162;
                    TARIH.Value = @"TTObjectClasses.Common.RecTime().ToString()";

                    FORMINFO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 57, 171, 84, false);
                    FORMINFO.Name = "FORMINFO";
                    FORMINFO.FieldType = ReportFieldTypeEnum.ftExpression;
                    FORMINFO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    FORMINFO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FORMINFO.MultiLine = EvetHayirEnum.ehEvet;
                    FORMINFO.NoClip = EvetHayirEnum.ehEvet;
                    FORMINFO.WordBreak = EvetHayirEnum.ehEvet;
                    FORMINFO.ExpandTabs = EvetHayirEnum.ehEvet;
                    FORMINFO.TextFont.Name = "Arial";
                    FORMINFO.TextFont.Size = 12;
                    FORMINFO.TextFont.Bold = true;
                    FORMINFO.TextFont.CharSet = 162;
                    FORMINFO.Value = @"""BİLDİRİMİ ZORUNLU BULAŞICI HASTALIKLAR BİLDİRİM FORMU"" + ""\r\n"" + ""( U. Hıfzıssıhha Kanunu Mad. 57-64 )""";

                    NewField11121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 92, 187, 97, false);
                    NewField11121.Name = "NewField11121";
                    NewField11121.TextFont.Bold = true;
                    NewField11121.TextFont.CharSet = 162;
                    NewField11121.Value = @"BİLDİRİMİ YAPAN KİŞİ";

                    NewField112221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 117, 106, 141, 111, false);
                    NewField112221.Name = "NewField112221";
                    NewField112221.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField112221.Value = @"SOYADI:";

                    DOKTORADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 99, 209, 104, false);
                    DOKTORADI.Name = "DOKTORADI";
                    DOKTORADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOKTORADI.Value = @"";

                    DOKTORSOYADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 106, 209, 111, false);
                    DOKTORSOYADI.Name = "DOKTORSOYADI";
                    DOKTORSOYADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOKTORSOYADI.Value = @"";

                    DOKTORUNVAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 113, 209, 118, false);
                    DOKTORUNVAN.Name = "DOKTORUNVAN";
                    DOKTORUNVAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOKTORUNVAN.Value = @"";

                    NewField112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 92, 77, 97, false);
                    NewField112111.Name = "NewField112111";
                    NewField112111.TextFont.Bold = true;
                    NewField112111.TextFont.CharSet = 162;
                    NewField112111.Value = @"BİLDİRİMİ YAPAN KURUM";

                    NewField112311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 99, 31, 104, false);
                    NewField112311.Name = "NewField112311";
                    NewField112311.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField112311.Value = @"İLİ:";

                    NewField1122211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 106, 31, 111, false);
                    NewField1122211.Name = "NewField1122211";
                    NewField1122211.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField1122211.Value = @"İLÇESİ:";

                    NewField11212211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 113, 31, 118, false);
                    NewField11212211.Name = "NewField11212211";
                    NewField11212211.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField11212211.Value = @"KURUM ADI:";

                    XXXXXXILI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 99, 99, 104, false);
                    XXXXXXILI.Name = "XXXXXXILI";
                    XXXXXXILI.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXILI.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    XXXXXXILCESI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 106, 99, 111, false);
                    XXXXXXILCESI.Name = "XXXXXXILCESI";
                    XXXXXXILCESI.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXILCESI.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALDISTRICT"", """")";

                    KURUMADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 113, 99, 122, false);
                    KURUMADI.Name = "KURUMADI";
                    KURUMADI.FieldType = ReportFieldTypeEnum.ftExpression;
                    KURUMADI.MultiLine = EvetHayirEnum.ehEvet;
                    KURUMADI.NoClip = EvetHayirEnum.ehEvet;
                    KURUMADI.WordBreak = EvetHayirEnum.ehEvet;
                    KURUMADI.ExpandTabs = EvetHayirEnum.ehEvet;
                    KURUMADI.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALSHORTNAME"", """") ";

                    NewField11321 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 117, 99, 141, 104, false);
                    NewField11321.Name = "NewField11321";
                    NewField11321.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField11321.Value = @"ADI:";

                    NewField1122121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 117, 113, 141, 118, false);
                    NewField1122121.Name = "NewField1122121";
                    NewField1122121.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField1122121.Value = @"ÜNVANI:";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LOGO.CalcValue = @"";
                    Form014.CalcValue = Form014.Value;
                    NewField11121.CalcValue = NewField11121.Value;
                    NewField112221.CalcValue = NewField112221.Value;
                    DOKTORADI.CalcValue = @"";
                    DOKTORSOYADI.CalcValue = @"";
                    DOKTORUNVAN.CalcValue = @"";
                    NewField112111.CalcValue = NewField112111.Value;
                    NewField112311.CalcValue = NewField112311.Value;
                    NewField1122211.CalcValue = NewField1122211.Value;
                    NewField11212211.CalcValue = NewField11212211.Value;
                    NewField11321.CalcValue = NewField11321.Value;
                    NewField1122121.CalcValue = NewField1122121.Value;
                    XXXXXXBASLIK.CalcValue = "(ACELE)" + "\r\n" + "\r\n" + "T.C." + "\r\n" + "SAĞLIK BAKANLIĞI" + "\r\n" + "Türkiye Halk Sağlığı Kurumu";
                    TARIH.CalcValue = TTObjectClasses.Common.RecTime().ToString();
                    FORMINFO.CalcValue = "BİLDİRİMİ ZORUNLU BULAŞICI HASTALIKLAR BİLDİRİM FORMU" + "\r\n" + "( U. Hıfzıssıhha Kanunu Mad. 57-64 )";
                    XXXXXXILI.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    XXXXXXILCESI.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALDISTRICT", "");
                    KURUMADI.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALSHORTNAME", "") ;
                    return new TTReportObject[] { LOGO,Form014,NewField11121,NewField112221,DOKTORADI,DOKTORSOYADI,DOKTORUNVAN,NewField112111,NewField112311,NewField1122211,NewField11212211,NewField11321,NewField1122121,XXXXXXBASLIK,TARIH,FORMINFO,XXXXXXILI,XXXXXXILCESI,KURUMADI};
                }

                public override void RunScript()
                {
#region HEADER HEADER_Script
                    this.LOGO.CalcValue = TTObjectClasses.Common.GetCurrentHospitalLogo();
                    //Doktor Bilgileri
                    TTObjectContext context = new TTObjectContext(true);
                    string sObjectID = ((Form014)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
                    BulasiciHastaliklarEA bulasici = (BulasiciHastaliklarEA)context.GetObject(new Guid(sObjectID), "BulasiciHastaliklarEA");
      
                    if (bulasici.BulasiciHastalikVeriSeti.ResponsibleDoctor != null)
                    {
                        /*for(int i = bulasici.BulasiciHastalikVeriSeti.ResponsibleDoctor.Name.Length - 1; i >= 0; i--){
                            if(bulasici.BulasiciHastalikVeriSeti.ResponsibleDoctor.Name.ElementAt(i).Equals(" ")){
                               this.DOKTORSOYADI.CalcValue = bulasici.BulasiciHastalikVeriSeti.ResponsibleDoctor.Name.Substring(i);
                               this.DOKTORADI.CalcValue = bulasici.BulasiciHastalikVeriSeti.ResponsibleDoctor.Name.Substring(0, i - 1);
                               break;
                            }
                        }*/
                        
                        string[] str = bulasici.BulasiciHastalikVeriSeti.ResponsibleDoctor.Name.Split(' ');
                        this.DOKTORADI.CalcValue = str[0];
                        this.DOKTORSOYADI.CalcValue = str[str.Length - 1];
                        if (str.Length > 1)
                        {
                            for (int i = 1; i < str.Length - 2; i++)
                            {
                                this.DOKTORADI.CalcValue += str[i];
                            }
                        }
                        
                        this.DOKTORUNVAN.CalcValue = TTObjectClasses.Common.GetEnumValueDefOfEnumValue(bulasici.BulasiciHastalikVeriSeti.ResponsibleDoctor.Title).DisplayText ;
                        //this.DOKTORBRANS.CalcValue = bulasici.BulasiciHastalikVeriSeti.ResponsibleDoctor.ResourceSpecialities[0].Speciality.Name;
                    }
#endregion HEADER HEADER_Script
                }
            }
            public partial class HeaderGroupFooter : TTReportSection
            {
                public Form014 MyParentReport
                {
                    get { return (Form014)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportShape NewLine1;
                public TTReportShape NewLine11115321; 
                public HeaderGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 29;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 179, 3, 204, 8, false);
                    NewField1.Name = "NewField1";
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"İMZA";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 179, 8, 204, 8, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11115321 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 107, 0, 204, 0, false);
                    NewLine11115321.Name = "NewLine11115321";
                    NewLine11115321.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1.CalcValue = NewField1.Value;
                    return new TTReportObject[] { NewField1};
                }
            }

        }

        public HeaderGroup Header;

        public partial class MAINGroup : TTReportGroup
        {
            public Form014 MyParentReport
            {
                get { return (Form014)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportShape NewLine151 { get {return Body().NewLine151;} }
            public TTReportShape NewLine1151 { get {return Body().NewLine1151;} }
            public TTReportShape NewLine1152 { get {return Body().NewLine1152;} }
            public TTReportShape NewLine11511 { get {return Body().NewLine11511;} }
            public TTReportShape NewLine1153 { get {return Body().NewLine1153;} }
            public TTReportShape NewLine11512 { get {return Body().NewLine11512;} }
            public TTReportShape NewLine12511 { get {return Body().NewLine12511;} }
            public TTReportShape NewLine111511 { get {return Body().NewLine111511;} }
            public TTReportShape NewLine1115111 { get {return Body().NewLine1115111;} }
            public TTReportShape NewLine11115111 { get {return Body().NewLine11115111;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportShape NewLine11 { get {return Body().NewLine11;} }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TTReportField NewField2 { get {return Body().NewField2;} }
            public TTReportField NewField12 { get {return Body().NewField12;} }
            public TTReportField NewField121 { get {return Body().NewField121;} }
            public TTReportField NewField1121 { get {return Body().NewField1121;} }
            public TTReportField NewField11211 { get {return Body().NewField11211;} }
            public TTReportField NewField111211 { get {return Body().NewField111211;} }
            public TTReportField NewField1112111 { get {return Body().NewField1112111;} }
            public TTReportField NewField11112111 { get {return Body().NewField11112111;} }
            public TTReportShape NewLine1154 { get {return Body().NewLine1154;} }
            public TTReportShape NewLine11513 { get {return Body().NewLine11513;} }
            public TTReportShape NewLine12512 { get {return Body().NewLine12512;} }
            public TTReportShape NewLine111512 { get {return Body().NewLine111512;} }
            public TTReportShape NewLine13511 { get {return Body().NewLine13511;} }
            public TTReportShape NewLine121511 { get {return Body().NewLine121511;} }
            public TTReportShape NewLine111521 { get {return Body().NewLine111521;} }
            public TTReportShape NewLine1115112 { get {return Body().NewLine1115112;} }
            public TTReportShape NewLine11115112 { get {return Body().NewLine11115112;} }
            public TTReportShape NewLine111151111 { get {return Body().NewLine111151111;} }
            public TTReportShape NewLine12 { get {return Body().NewLine12;} }
            public TTReportShape NewLine111 { get {return Body().NewLine111;} }
            public TTReportField NewField11 { get {return Body().NewField11;} }
            public TTReportField NewField13 { get {return Body().NewField13;} }
            public TTReportField NewField122 { get {return Body().NewField122;} }
            public TTReportField NewField1122 { get {return Body().NewField1122;} }
            public TTReportField NewField11212 { get {return Body().NewField11212;} }
            public TTReportField NewField111212 { get {return Body().NewField111212;} }
            public TTReportField NewField1112112 { get {return Body().NewField1112112;} }
            public TTReportField NewField11112112 { get {return Body().NewField11112112;} }
            public TTReportField NewField111121111 { get {return Body().NewField111121111;} }
            public TTReportShape NewLine14511 { get {return Body().NewLine14511;} }
            public TTReportShape NewLine131511 { get {return Body().NewLine131511;} }
            public TTReportShape NewLine121521 { get {return Body().NewLine121521;} }
            public TTReportShape NewLine1215111 { get {return Body().NewLine1215111;} }
            public TTReportShape NewLine111531 { get {return Body().NewLine111531;} }
            public TTReportShape NewLine1115121 { get {return Body().NewLine1115121;} }
            public TTReportShape NewLine1125111 { get {return Body().NewLine1125111;} }
            public TTReportShape NewLine12115111 { get {return Body().NewLine12115111;} }
            public TTReportShape NewLine121151111 { get {return Body().NewLine121151111;} }
            public TTReportShape NewLine1111151111 { get {return Body().NewLine1111151111;} }
            public TTReportShape NewLine121 { get {return Body().NewLine121;} }
            public TTReportField NewField111 { get {return Body().NewField111;} }
            public TTReportField NewField131 { get {return Body().NewField131;} }
            public TTReportField NewField1221 { get {return Body().NewField1221;} }
            public TTReportField NewField12211 { get {return Body().NewField12211;} }
            public TTReportField NewField121211 { get {return Body().NewField121211;} }
            public TTReportField NewField1212111 { get {return Body().NewField1212111;} }
            public TTReportField NewField12112111 { get {return Body().NewField12112111;} }
            public TTReportField NewField121121111 { get {return Body().NewField121121111;} }
            public TTReportField NewField1111121111 { get {return Body().NewField1111121111;} }
            public TTReportShape NewLine1111 { get {return Body().NewLine1111;} }
            public TTReportShape NewLine14512 { get {return Body().NewLine14512;} }
            public TTReportShape NewLine131512 { get {return Body().NewLine131512;} }
            public TTReportShape NewLine121522 { get {return Body().NewLine121522;} }
            public TTReportShape NewLine1215112 { get {return Body().NewLine1215112;} }
            public TTReportShape NewLine111532 { get {return Body().NewLine111532;} }
            public TTReportShape NewLine1115122 { get {return Body().NewLine1115122;} }
            public TTReportShape NewLine122 { get {return Body().NewLine122;} }
            public TTReportShape NewLine1112 { get {return Body().NewLine1112;} }
            public TTReportField NewField112 { get {return Body().NewField112;} }
            public TTReportField NewField132 { get {return Body().NewField132;} }
            public TTReportField NewField1222 { get {return Body().NewField1222;} }
            public TTReportField NewField12212 { get {return Body().NewField12212;} }
            public TTReportField NewField121212 { get {return Body().NewField121212;} }
            public TTReportShape NewLine121541 { get {return Body().NewLine121541;} }
            public TTReportShape NewLine12111 { get {return Body().NewLine12111;} }
            public TTReportField IKAMETIL { get {return Body().IKAMETIL;} }
            public TTReportField IKAMETILCE { get {return Body().IKAMETILCE;} }
            public TTReportField IKAMETBUCAK { get {return Body().IKAMETBUCAK;} }
            public TTReportField IKAMETKOY { get {return Body().IKAMETKOY;} }
            public TTReportField IKAMETMAHALLE { get {return Body().IKAMETMAHALLE;} }
            public TTReportField IKAMETCSBM { get {return Body().IKAMETCSBM;} }
            public TTReportField IKAMETDISKAPINO { get {return Body().IKAMETDISKAPINO;} }
            public TTReportField IKAMETICKAPINO { get {return Body().IKAMETICKAPINO;} }
            public TTReportField TCID { get {return Body().TCID;} }
            public TTReportField ADI { get {return Body().ADI;} }
            public TTReportField SOYADI { get {return Body().SOYADI;} }
            public TTReportField BABAADI { get {return Body().BABAADI;} }
            public TTReportField CINSIYET { get {return Body().CINSIYET;} }
            public TTReportField DOGUMTARIHI { get {return Body().DOGUMTARIHI;} }
            public TTReportField DOGUMYERI { get {return Body().DOGUMYERI;} }
            public TTReportField MESLEGI { get {return Body().MESLEGI;} }
            public TTReportField HASTALIGINADI { get {return Body().HASTALIGINADI;} }
            public TTReportField HASTALIGINKODU { get {return Body().HASTALIGINKODU;} }
            public TTReportField VAKATIPI { get {return Body().VAKATIPI;} }
            public TTReportField BELIRTILERINBASLAMATARIHI { get {return Body().BELIRTILERINBASLAMATARIHI;} }
            public TTReportField BEYANIL { get {return Body().BEYANIL;} }
            public TTReportField BEYANILCE { get {return Body().BEYANILCE;} }
            public TTReportField BEYANBUCAK { get {return Body().BEYANBUCAK;} }
            public TTReportField BEYANKOY { get {return Body().BEYANKOY;} }
            public TTReportField BEYANMAHALLE { get {return Body().BEYANMAHALLE;} }
            public TTReportField BEYANCSBM { get {return Body().BEYANCSBM;} }
            public TTReportField BEYANDISKAPINO { get {return Body().BEYANDISKAPINO;} }
            public TTReportField BEYANICKAPINO { get {return Body().BEYANICKAPINO;} }
            public TTReportField NewField3 { get {return Body().NewField3;} }
            public TTReportField TELNO { get {return Body().TELNO;} }
            public TTReportField NewField4 { get {return Body().NewField4;} }
            public TTReportField VAKADURUMU { get {return Body().VAKADURUMU;} }
            public TTReportShape NewLine1145121 { get {return Body().NewLine1145121;} }
            public TTReportShape NewLine12112 { get {return Body().NewLine12112;} }
            public TTReportShape NewLine112 { get {return Body().NewLine112;} }
            public TTReportShape NewLine11111 { get {return Body().NewLine11111;} }
            public TTReportShape NewLine111111 { get {return Body().NewLine111111;} }
            public TTReportShape NewLine111541 { get {return Body().NewLine111541;} }
            public MAINGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MAINGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MAINGroupBody(this);
            }

            public partial class MAINGroupBody : TTReportSection
            {
                public Form014 MyParentReport
                {
                    get { return (Form014)ParentReport; }
                }
                
                public TTReportShape NewLine151;
                public TTReportShape NewLine1151;
                public TTReportShape NewLine1152;
                public TTReportShape NewLine11511;
                public TTReportShape NewLine1153;
                public TTReportShape NewLine11512;
                public TTReportShape NewLine12511;
                public TTReportShape NewLine111511;
                public TTReportShape NewLine1115111;
                public TTReportShape NewLine11115111;
                public TTReportShape NewLine1;
                public TTReportShape NewLine11;
                public TTReportField NewField1;
                public TTReportField NewField2;
                public TTReportField NewField12;
                public TTReportField NewField121;
                public TTReportField NewField1121;
                public TTReportField NewField11211;
                public TTReportField NewField111211;
                public TTReportField NewField1112111;
                public TTReportField NewField11112111;
                public TTReportShape NewLine1154;
                public TTReportShape NewLine11513;
                public TTReportShape NewLine12512;
                public TTReportShape NewLine111512;
                public TTReportShape NewLine13511;
                public TTReportShape NewLine121511;
                public TTReportShape NewLine111521;
                public TTReportShape NewLine1115112;
                public TTReportShape NewLine11115112;
                public TTReportShape NewLine111151111;
                public TTReportShape NewLine12;
                public TTReportShape NewLine111;
                public TTReportField NewField11;
                public TTReportField NewField13;
                public TTReportField NewField122;
                public TTReportField NewField1122;
                public TTReportField NewField11212;
                public TTReportField NewField111212;
                public TTReportField NewField1112112;
                public TTReportField NewField11112112;
                public TTReportField NewField111121111;
                public TTReportShape NewLine14511;
                public TTReportShape NewLine131511;
                public TTReportShape NewLine121521;
                public TTReportShape NewLine1215111;
                public TTReportShape NewLine111531;
                public TTReportShape NewLine1115121;
                public TTReportShape NewLine1125111;
                public TTReportShape NewLine12115111;
                public TTReportShape NewLine121151111;
                public TTReportShape NewLine1111151111;
                public TTReportShape NewLine121;
                public TTReportField NewField111;
                public TTReportField NewField131;
                public TTReportField NewField1221;
                public TTReportField NewField12211;
                public TTReportField NewField121211;
                public TTReportField NewField1212111;
                public TTReportField NewField12112111;
                public TTReportField NewField121121111;
                public TTReportField NewField1111121111;
                public TTReportShape NewLine1111;
                public TTReportShape NewLine14512;
                public TTReportShape NewLine131512;
                public TTReportShape NewLine121522;
                public TTReportShape NewLine1215112;
                public TTReportShape NewLine111532;
                public TTReportShape NewLine1115122;
                public TTReportShape NewLine122;
                public TTReportShape NewLine1112;
                public TTReportField NewField112;
                public TTReportField NewField132;
                public TTReportField NewField1222;
                public TTReportField NewField12212;
                public TTReportField NewField121212;
                public TTReportShape NewLine121541;
                public TTReportShape NewLine12111;
                public TTReportField IKAMETIL;
                public TTReportField IKAMETILCE;
                public TTReportField IKAMETBUCAK;
                public TTReportField IKAMETKOY;
                public TTReportField IKAMETMAHALLE;
                public TTReportField IKAMETCSBM;
                public TTReportField IKAMETDISKAPINO;
                public TTReportField IKAMETICKAPINO;
                public TTReportField TCID;
                public TTReportField ADI;
                public TTReportField SOYADI;
                public TTReportField BABAADI;
                public TTReportField CINSIYET;
                public TTReportField DOGUMTARIHI;
                public TTReportField DOGUMYERI;
                public TTReportField MESLEGI;
                public TTReportField HASTALIGINADI;
                public TTReportField HASTALIGINKODU;
                public TTReportField VAKATIPI;
                public TTReportField BELIRTILERINBASLAMATARIHI;
                public TTReportField BEYANIL;
                public TTReportField BEYANILCE;
                public TTReportField BEYANBUCAK;
                public TTReportField BEYANKOY;
                public TTReportField BEYANMAHALLE;
                public TTReportField BEYANCSBM;
                public TTReportField BEYANDISKAPINO;
                public TTReportField BEYANICKAPINO;
                public TTReportField NewField3;
                public TTReportField TELNO;
                public TTReportField NewField4;
                public TTReportField VAKADURUMU;
                public TTReportShape NewLine1145121;
                public TTReportShape NewLine12112;
                public TTReportShape NewLine112;
                public TTReportShape NewLine11111;
                public TTReportShape NewLine111111;
                public TTReportShape NewLine111541; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 148;
                    RepeatCount = 0;
                    
                    NewLine151 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 5, 104, 5, false);
                    NewLine151.Name = "NewLine151";
                    NewLine151.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1151 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 12, 104, 12, false);
                    NewLine1151.Name = "NewLine1151";
                    NewLine1151.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1152 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 18, 104, 18, false);
                    NewLine1152.Name = "NewLine1152";
                    NewLine1152.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11511 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 25, 104, 25, false);
                    NewLine11511.Name = "NewLine11511";
                    NewLine11511.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1153 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 32, 104, 32, false);
                    NewLine1153.Name = "NewLine1153";
                    NewLine1153.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11512 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 39, 104, 39, false);
                    NewLine11512.Name = "NewLine11512";
                    NewLine11512.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine12511 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 45, 104, 45, false);
                    NewLine12511.Name = "NewLine12511";
                    NewLine12511.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine111511 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 52, 104, 52, false);
                    NewLine111511.Name = "NewLine111511";
                    NewLine111511.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1115111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 59, 104, 59, false);
                    NewLine1115111.Name = "NewLine1115111";
                    NewLine1115111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11115111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 66, 104, 66, false);
                    NewLine11115111.Name = "NewLine11115111";
                    NewLine11115111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 5, 7, 66, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 104, 5, 104, 66, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 6, 74, 11, false);
                    NewField1.Name = "NewField1";
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"HASTANIN KİMLİK BİLGİLERİ";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 13, 48, 18, false);
                    NewField2.Name = "NewField2";
                    NewField2.Value = @"T.C. KİMLİK NO";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 19, 48, 24, false);
                    NewField12.Name = "NewField12";
                    NewField12.Value = @"ADI";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 26, 48, 31, false);
                    NewField121.Name = "NewField121";
                    NewField121.Value = @"SOYADI";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 33, 48, 38, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.Value = @"BABA ADI";

                    NewField11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 40, 48, 45, false);
                    NewField11211.Name = "NewField11211";
                    NewField11211.Value = @"CİNSİYETİ";

                    NewField111211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 46, 48, 51, false);
                    NewField111211.Name = "NewField111211";
                    NewField111211.Value = @"DOĞUM TARİHİ";

                    NewField1112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 53, 48, 58, false);
                    NewField1112111.Name = "NewField1112111";
                    NewField1112111.Value = @"DOĞUM YERİ";

                    NewField11112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 60, 48, 65, false);
                    NewField11112111.Name = "NewField11112111";
                    NewField11112111.Value = @"MESLEĞİ";

                    NewLine1154 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 108, 5, 205, 5, false);
                    NewLine1154.Name = "NewLine1154";
                    NewLine1154.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11513 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 108, 12, 205, 12, false);
                    NewLine11513.Name = "NewLine11513";
                    NewLine11513.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine12512 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 108, 18, 205, 18, false);
                    NewLine12512.Name = "NewLine12512";
                    NewLine12512.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine111512 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 108, 25, 205, 25, false);
                    NewLine111512.Name = "NewLine111512";
                    NewLine111512.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine13511 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 108, 32, 205, 32, false);
                    NewLine13511.Name = "NewLine13511";
                    NewLine13511.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine121511 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 108, 39, 205, 39, false);
                    NewLine121511.Name = "NewLine121511";
                    NewLine121511.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine111521 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 108, 45, 205, 45, false);
                    NewLine111521.Name = "NewLine111521";
                    NewLine111521.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1115112 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 108, 52, 205, 52, false);
                    NewLine1115112.Name = "NewLine1115112";
                    NewLine1115112.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11115112 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 108, 59, 205, 59, false);
                    NewLine11115112.Name = "NewLine11115112";
                    NewLine11115112.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine111151111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 108, 66, 205, 66, false);
                    NewLine111151111.Name = "NewLine111151111";
                    NewLine111151111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 108, 5, 108, 66, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 205, 5, 205, 66, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 6, 173, 11, false);
                    NewField11.Name = "NewField11";
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"KAYITLI İKAMET ADRESİ";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 13, 149, 18, false);
                    NewField13.Name = "NewField13";
                    NewField13.Value = @"İL";

                    NewField122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 19, 149, 24, false);
                    NewField122.Name = "NewField122";
                    NewField122.Value = @"İLÇE";

                    NewField1122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 26, 149, 31, false);
                    NewField1122.Name = "NewField1122";
                    NewField1122.Value = @"BUCAK";

                    NewField11212 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 33, 149, 38, false);
                    NewField11212.Name = "NewField11212";
                    NewField11212.Value = @"KÖY";

                    NewField111212 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 40, 149, 45, false);
                    NewField111212.Name = "NewField111212";
                    NewField111212.Value = @"MAHALLE";

                    NewField1112112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 46, 149, 51, false);
                    NewField1112112.Name = "NewField1112112";
                    NewField1112112.Value = @"CSBM";

                    NewField11112112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 53, 149, 58, false);
                    NewField11112112.Name = "NewField11112112";
                    NewField11112112.Value = @"DIŞ KAPI NO";

                    NewField111121111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 60, 149, 65, false);
                    NewField111121111.Name = "NewField111121111";
                    NewField111121111.Value = @"İÇ KAPI NO";

                    NewLine14511 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 108, 71, 205, 71, false);
                    NewLine14511.Name = "NewLine14511";
                    NewLine14511.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine131511 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 108, 78, 205, 78, false);
                    NewLine131511.Name = "NewLine131511";
                    NewLine131511.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine121521 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 108, 85, 205, 85, false);
                    NewLine121521.Name = "NewLine121521";
                    NewLine121521.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1215111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 108, 92, 205, 92, false);
                    NewLine1215111.Name = "NewLine1215111";
                    NewLine1215111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine111531 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 108, 99, 205, 99, false);
                    NewLine111531.Name = "NewLine111531";
                    NewLine111531.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1115121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 108, 106, 205, 106, false);
                    NewLine1115121.Name = "NewLine1115121";
                    NewLine1115121.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1125111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 108, 113, 205, 113, false);
                    NewLine1125111.Name = "NewLine1125111";
                    NewLine1125111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine12115111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 108, 120, 205, 120, false);
                    NewLine12115111.Name = "NewLine12115111";
                    NewLine12115111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine121151111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 108, 127, 205, 127, false);
                    NewLine121151111.Name = "NewLine121151111";
                    NewLine121151111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1111151111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 108, 134, 205, 134, false);
                    NewLine1111151111.Name = "NewLine1111151111";
                    NewLine1111151111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 108, 71, 108, 141, false);
                    NewLine121.Name = "NewLine121";
                    NewLine121.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 72, 174, 77, false);
                    NewField111.Name = "NewField111";
                    NewField111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"BEYAN ADRESİ";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 79, 149, 84, false);
                    NewField131.Name = "NewField131";
                    NewField131.Value = @"İL";

                    NewField1221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 86, 149, 91, false);
                    NewField1221.Name = "NewField1221";
                    NewField1221.Value = @"İLÇE";

                    NewField12211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 93, 149, 98, false);
                    NewField12211.Name = "NewField12211";
                    NewField12211.Value = @"BUCAK";

                    NewField121211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 100, 149, 105, false);
                    NewField121211.Name = "NewField121211";
                    NewField121211.Value = @"KÖY";

                    NewField1212111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 107, 149, 112, false);
                    NewField1212111.Name = "NewField1212111";
                    NewField1212111.Value = @"MAHALLE";

                    NewField12112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 114, 149, 119, false);
                    NewField12112111.Name = "NewField12112111";
                    NewField12112111.Value = @"CSBM";

                    NewField121121111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 121, 149, 126, false);
                    NewField121121111.Name = "NewField121121111";
                    NewField121121111.Value = @"DIŞ KAPI NO";

                    NewField1111121111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 128, 149, 133, false);
                    NewField1111121111.Name = "NewField1111121111";
                    NewField1111121111.Value = @"İÇ KAPI NO";

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 205, 71, 205, 141, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine14512 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 71, 104, 71, false);
                    NewLine14512.Name = "NewLine14512";
                    NewLine14512.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine131512 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 78, 104, 78, false);
                    NewLine131512.Name = "NewLine131512";
                    NewLine131512.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine121522 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 94, 104, 94, false);
                    NewLine121522.Name = "NewLine121522";
                    NewLine121522.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1215112 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 101, 104, 101, false);
                    NewLine1215112.Name = "NewLine1215112";
                    NewLine1215112.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine111532 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 108, 104, 108, false);
                    NewLine111532.Name = "NewLine111532";
                    NewLine111532.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1115122 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 119, 104, 119, false);
                    NewLine1115122.Name = "NewLine1115122";
                    NewLine1115122.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine122 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 71, 7, 127, false);
                    NewLine122.Name = "NewLine122";
                    NewLine122.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1112 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 104, 71, 104, 115, false);
                    NewLine1112.Name = "NewLine1112";
                    NewLine1112.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 72, 71, 77, false);
                    NewField112.Name = "NewField112";
                    NewField112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112.TextFont.Bold = true;
                    NewField112.TextFont.CharSet = 162;
                    NewField112.Value = @"HASTALIK DURUMU";

                    NewField132 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 79, 48, 84, false);
                    NewField132.Name = "NewField132";
                    NewField132.Value = @"HASTALIĞIN ADI";

                    NewField1222 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 95, 48, 100, false);
                    NewField1222.Name = "NewField1222";
                    NewField1222.TextFont.Size = 8;
                    NewField1222.TextFont.CharSet = 162;
                    NewField1222.Value = @"HASTALIĞIN KODU";

                    NewField12212 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 102, 48, 107, false);
                    NewField12212.Name = "NewField12212";
                    NewField12212.Value = @"VAKA TİPİ";

                    NewField121212 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 109, 48, 114, false);
                    NewField121212.Name = "NewField121212";
                    NewField121212.MultiLine = EvetHayirEnum.ehEvet;
                    NewField121212.NoClip = EvetHayirEnum.ehEvet;
                    NewField121212.WordBreak = EvetHayirEnum.ehEvet;
                    NewField121212.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField121212.Value = @"BELİRTİLERİN BAŞLAMA TARİHİ";

                    NewLine121541 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 108, 103, 108, false);
                    NewLine121541.Name = "NewLine121541";
                    NewLine121541.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine12111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 104, 115, 104, 127, false);
                    NewLine12111.Name = "NewLine12111";
                    NewLine12111.DrawStyle = DrawStyleConstants.vbSolid;

                    IKAMETIL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 13, 202, 18, false);
                    IKAMETIL.Name = "IKAMETIL";
                    IKAMETIL.FieldType = ReportFieldTypeEnum.ftVariable;
                    IKAMETIL.Value = @"";

                    IKAMETILCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 19, 202, 24, false);
                    IKAMETILCE.Name = "IKAMETILCE";
                    IKAMETILCE.FieldType = ReportFieldTypeEnum.ftVariable;
                    IKAMETILCE.Value = @"";

                    IKAMETBUCAK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 26, 202, 31, false);
                    IKAMETBUCAK.Name = "IKAMETBUCAK";
                    IKAMETBUCAK.FieldType = ReportFieldTypeEnum.ftVariable;
                    IKAMETBUCAK.Value = @"";

                    IKAMETKOY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 33, 202, 38, false);
                    IKAMETKOY.Name = "IKAMETKOY";
                    IKAMETKOY.FieldType = ReportFieldTypeEnum.ftVariable;
                    IKAMETKOY.Value = @"";

                    IKAMETMAHALLE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 40, 202, 45, false);
                    IKAMETMAHALLE.Name = "IKAMETMAHALLE";
                    IKAMETMAHALLE.FieldType = ReportFieldTypeEnum.ftVariable;
                    IKAMETMAHALLE.Value = @"";

                    IKAMETCSBM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 46, 202, 51, false);
                    IKAMETCSBM.Name = "IKAMETCSBM";
                    IKAMETCSBM.FieldType = ReportFieldTypeEnum.ftVariable;
                    IKAMETCSBM.Value = @"";

                    IKAMETDISKAPINO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 53, 202, 58, false);
                    IKAMETDISKAPINO.Name = "IKAMETDISKAPINO";
                    IKAMETDISKAPINO.FieldType = ReportFieldTypeEnum.ftVariable;
                    IKAMETDISKAPINO.Value = @"";

                    IKAMETICKAPINO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 60, 202, 65, false);
                    IKAMETICKAPINO.Name = "IKAMETICKAPINO";
                    IKAMETICKAPINO.FieldType = ReportFieldTypeEnum.ftVariable;
                    IKAMETICKAPINO.Value = @"";

                    TCID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 13, 100, 18, false);
                    TCID.Name = "TCID";
                    TCID.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCID.Value = @"";

                    ADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 19, 100, 24, false);
                    ADI.Name = "ADI";
                    ADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADI.Value = @"";

                    SOYADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 26, 100, 31, false);
                    SOYADI.Name = "SOYADI";
                    SOYADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    SOYADI.Value = @"";

                    BABAADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 33, 100, 38, false);
                    BABAADI.Name = "BABAADI";
                    BABAADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    BABAADI.Value = @"";

                    CINSIYET = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 40, 100, 45, false);
                    CINSIYET.Name = "CINSIYET";
                    CINSIYET.FieldType = ReportFieldTypeEnum.ftVariable;
                    CINSIYET.Value = @"";

                    DOGUMTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 46, 100, 51, false);
                    DOGUMTARIHI.Name = "DOGUMTARIHI";
                    DOGUMTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOGUMTARIHI.Value = @"";

                    DOGUMYERI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 53, 100, 58, false);
                    DOGUMYERI.Name = "DOGUMYERI";
                    DOGUMYERI.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOGUMYERI.Value = @"";

                    MESLEGI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 60, 100, 65, false);
                    MESLEGI.Name = "MESLEGI";
                    MESLEGI.FieldType = ReportFieldTypeEnum.ftVariable;
                    MESLEGI.Value = @"";

                    HASTALIGINADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 79, 100, 91, false);
                    HASTALIGINADI.Name = "HASTALIGINADI";
                    HASTALIGINADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTALIGINADI.MultiLine = EvetHayirEnum.ehEvet;
                    HASTALIGINADI.NoClip = EvetHayirEnum.ehEvet;
                    HASTALIGINADI.WordBreak = EvetHayirEnum.ehEvet;
                    HASTALIGINADI.ExpandTabs = EvetHayirEnum.ehEvet;
                    HASTALIGINADI.TextFont.Size = 8;
                    HASTALIGINADI.TextFont.CharSet = 162;
                    HASTALIGINADI.Value = @"";

                    HASTALIGINKODU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 95, 100, 100, false);
                    HASTALIGINKODU.Name = "HASTALIGINKODU";
                    HASTALIGINKODU.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTALIGINKODU.Value = @"";

                    VAKATIPI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 102, 100, 107, false);
                    VAKATIPI.Name = "VAKATIPI";
                    VAKATIPI.FieldType = ReportFieldTypeEnum.ftVariable;
                    VAKATIPI.Value = @"";

                    BELIRTILERINBASLAMATARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 109, 100, 114, false);
                    BELIRTILERINBASLAMATARIHI.Name = "BELIRTILERINBASLAMATARIHI";
                    BELIRTILERINBASLAMATARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    BELIRTILERINBASLAMATARIHI.Value = @"";

                    BEYANIL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 79, 202, 84, false);
                    BEYANIL.Name = "BEYANIL";
                    BEYANIL.FieldType = ReportFieldTypeEnum.ftVariable;
                    BEYANIL.Value = @"";

                    BEYANILCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 86, 202, 91, false);
                    BEYANILCE.Name = "BEYANILCE";
                    BEYANILCE.FieldType = ReportFieldTypeEnum.ftVariable;
                    BEYANILCE.Value = @"";

                    BEYANBUCAK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 93, 202, 98, false);
                    BEYANBUCAK.Name = "BEYANBUCAK";
                    BEYANBUCAK.FieldType = ReportFieldTypeEnum.ftVariable;
                    BEYANBUCAK.Value = @"";

                    BEYANKOY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 100, 202, 105, false);
                    BEYANKOY.Name = "BEYANKOY";
                    BEYANKOY.FieldType = ReportFieldTypeEnum.ftVariable;
                    BEYANKOY.Value = @"";

                    BEYANMAHALLE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 107, 202, 112, false);
                    BEYANMAHALLE.Name = "BEYANMAHALLE";
                    BEYANMAHALLE.FieldType = ReportFieldTypeEnum.ftVariable;
                    BEYANMAHALLE.Value = @"";

                    BEYANCSBM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 114, 202, 119, false);
                    BEYANCSBM.Name = "BEYANCSBM";
                    BEYANCSBM.FieldType = ReportFieldTypeEnum.ftVariable;
                    BEYANCSBM.Value = @"";

                    BEYANDISKAPINO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 121, 202, 126, false);
                    BEYANDISKAPINO.Name = "BEYANDISKAPINO";
                    BEYANDISKAPINO.FieldType = ReportFieldTypeEnum.ftVariable;
                    BEYANDISKAPINO.Value = @"";

                    BEYANICKAPINO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 128, 202, 133, false);
                    BEYANICKAPINO.Name = "BEYANICKAPINO";
                    BEYANICKAPINO.FieldType = ReportFieldTypeEnum.ftVariable;
                    BEYANICKAPINO.Value = @"";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 135, 149, 140, false);
                    NewField3.Name = "NewField3";
                    NewField3.TextFont.CharSet = 162;
                    NewField3.Value = @"İRTİBAT TELEFONU
";

                    TELNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 135, 202, 140, false);
                    TELNO.Name = "TELNO";
                    TELNO.TextFont.Bold = true;
                    TELNO.TextFont.CharSet = 162;
                    TELNO.Value = @"";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 121, 48, 126, false);
                    NewField4.Name = "NewField4";
                    NewField4.Value = @"VAKA DURUMU";

                    VAKADURUMU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 121, 100, 126, false);
                    VAKADURUMU.Name = "VAKADURUMU";
                    VAKADURUMU.MultiLine = EvetHayirEnum.ehEvet;
                    VAKADURUMU.NoClip = EvetHayirEnum.ehEvet;
                    VAKADURUMU.WordBreak = EvetHayirEnum.ehEvet;
                    VAKADURUMU.ExpandTabs = EvetHayirEnum.ehEvet;
                    VAKADURUMU.Value = @"";

                    NewLine1145121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 127, 104, 127, false);
                    NewLine1145121.Name = "NewLine1145121";
                    NewLine1145121.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine12112 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 49, 78, 49, 127, false);
                    NewLine12112.Name = "NewLine12112";
                    NewLine12112.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine112 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 49, 12, 49, 66, false);
                    NewLine112.Name = "NewLine112";
                    NewLine112.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 150, 78, 150, 141, false);
                    NewLine11111.Name = "NewLine11111";
                    NewLine11111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 150, 12, 150, 66, false);
                    NewLine111111.Name = "NewLine111111";
                    NewLine111111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine111541 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 109, 141, 205, 141, false);
                    NewLine111541.Name = "NewLine111541";
                    NewLine111541.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1.CalcValue = NewField1.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    NewField11211.CalcValue = NewField11211.Value;
                    NewField111211.CalcValue = NewField111211.Value;
                    NewField1112111.CalcValue = NewField1112111.Value;
                    NewField11112111.CalcValue = NewField11112111.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField122.CalcValue = NewField122.Value;
                    NewField1122.CalcValue = NewField1122.Value;
                    NewField11212.CalcValue = NewField11212.Value;
                    NewField111212.CalcValue = NewField111212.Value;
                    NewField1112112.CalcValue = NewField1112112.Value;
                    NewField11112112.CalcValue = NewField11112112.Value;
                    NewField111121111.CalcValue = NewField111121111.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField131.CalcValue = NewField131.Value;
                    NewField1221.CalcValue = NewField1221.Value;
                    NewField12211.CalcValue = NewField12211.Value;
                    NewField121211.CalcValue = NewField121211.Value;
                    NewField1212111.CalcValue = NewField1212111.Value;
                    NewField12112111.CalcValue = NewField12112111.Value;
                    NewField121121111.CalcValue = NewField121121111.Value;
                    NewField1111121111.CalcValue = NewField1111121111.Value;
                    NewField112.CalcValue = NewField112.Value;
                    NewField132.CalcValue = NewField132.Value;
                    NewField1222.CalcValue = NewField1222.Value;
                    NewField12212.CalcValue = NewField12212.Value;
                    NewField121212.CalcValue = NewField121212.Value;
                    IKAMETIL.CalcValue = @"";
                    IKAMETILCE.CalcValue = @"";
                    IKAMETBUCAK.CalcValue = @"";
                    IKAMETKOY.CalcValue = @"";
                    IKAMETMAHALLE.CalcValue = @"";
                    IKAMETCSBM.CalcValue = @"";
                    IKAMETDISKAPINO.CalcValue = @"";
                    IKAMETICKAPINO.CalcValue = @"";
                    TCID.CalcValue = @"";
                    ADI.CalcValue = @"";
                    SOYADI.CalcValue = @"";
                    BABAADI.CalcValue = @"";
                    CINSIYET.CalcValue = @"";
                    DOGUMTARIHI.CalcValue = @"";
                    DOGUMYERI.CalcValue = @"";
                    MESLEGI.CalcValue = @"";
                    HASTALIGINADI.CalcValue = @"";
                    HASTALIGINKODU.CalcValue = @"";
                    VAKATIPI.CalcValue = @"";
                    BELIRTILERINBASLAMATARIHI.CalcValue = @"";
                    BEYANIL.CalcValue = @"";
                    BEYANILCE.CalcValue = @"";
                    BEYANBUCAK.CalcValue = @"";
                    BEYANKOY.CalcValue = @"";
                    BEYANMAHALLE.CalcValue = @"";
                    BEYANCSBM.CalcValue = @"";
                    BEYANDISKAPINO.CalcValue = @"";
                    BEYANICKAPINO.CalcValue = @"";
                    NewField3.CalcValue = NewField3.Value;
                    TELNO.CalcValue = TELNO.Value;
                    NewField4.CalcValue = NewField4.Value;
                    VAKADURUMU.CalcValue = VAKADURUMU.Value;
                    return new TTReportObject[] { NewField1,NewField2,NewField12,NewField121,NewField1121,NewField11211,NewField111211,NewField1112111,NewField11112111,NewField11,NewField13,NewField122,NewField1122,NewField11212,NewField111212,NewField1112112,NewField11112112,NewField111121111,NewField111,NewField131,NewField1221,NewField12211,NewField121211,NewField1212111,NewField12112111,NewField121121111,NewField1111121111,NewField112,NewField132,NewField1222,NewField12212,NewField121212,IKAMETIL,IKAMETILCE,IKAMETBUCAK,IKAMETKOY,IKAMETMAHALLE,IKAMETCSBM,IKAMETDISKAPINO,IKAMETICKAPINO,TCID,ADI,SOYADI,BABAADI,CINSIYET,DOGUMTARIHI,DOGUMYERI,MESLEGI,HASTALIGINADI,HASTALIGINKODU,VAKATIPI,BELIRTILERINBASLAMATARIHI,BEYANIL,BEYANILCE,BEYANBUCAK,BEYANKOY,BEYANMAHALLE,BEYANCSBM,BEYANDISKAPINO,BEYANICKAPINO,NewField3,TELNO,NewField4,VAKADURUMU};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
                    string sObjectID = ((Form014)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
                    BulasiciHastaliklarEA bulasici = (BulasiciHastaliklarEA)context.GetObject(new Guid(sObjectID), "BulasiciHastaliklarEA");
                    Patient patient = bulasici.Episode.Patient;

                    //Kimlik Bilgileri
                    if (patient.UniqueRefNo != null)
                        this.TCID.CalcValue = patient.UniqueRefNo.ToString();
                    if (patient.Name != null)
                        this.ADI.CalcValue = patient.Name.ToString();
                    if (patient.Surname != null)
                        this.SOYADI.CalcValue = patient.Surname.ToString();
                    if (patient.FatherName != null)
                        this.BABAADI.CalcValue = patient.FatherName.ToString();
                    if (patient.Sex != null)
                        this.CINSIYET.CalcValue = patient.Sex.ADI;
                    if (patient.BirthDate != null)
                        this.DOGUMTARIHI.CalcValue = Convert.ToDateTime(patient.BirthDate).ToString("dd.MM.yyyy");
                    if (patient.BirthPlace != null)
                        this.DOGUMYERI.CalcValue = patient.BirthPlace;

                    //Hastalık Bilgileri

                    if (bulasici.BulasiciHastalikVeriSeti.SKRSICD != null)
                        this.HASTALIGINADI.CalcValue = bulasici.BulasiciHastalikVeriSeti.SKRSICD.ADI;
                    if (bulasici.BulasiciHastalikVeriSeti.SKRSICD != null)
                        this.HASTALIGINKODU.CalcValue = bulasici.BulasiciHastalikVeriSeti.SKRSICD.KODU;
                    if (bulasici.BulasiciHastalikVeriSeti.SKRSVakaTipi != null)
                        this.VAKATIPI.CalcValue = bulasici.BulasiciHastalikVeriSeti.SKRSVakaTipi.ADI;
                    if (bulasici.BulasiciHastalikVeriSeti.BelirtilerinBaslamaTarihi != null)
                        this.BELIRTILERINBASLAMATARIHI.CalcValue = Convert.ToDateTime(bulasici.BulasiciHastalikVeriSeti.BelirtilerinBaslamaTarihi).ToString("dd.MM.yyyy");
                    if(bulasici.BulasiciHastalikVeriSeti.VakaDurum != null)
                        this.VAKADURUMU.CalcValue = TTObjectClasses.Common.GetEnumValueDefOfEnumValue(bulasici.BulasiciHastalikVeriSeti.VakaDurum).DisplayText;
                    

                    //Ikametgah
                    if (bulasici.BulasiciHastalikVeriSeti.Ikamet_Il != null)
                        this.IKAMETIL.CalcValue = bulasici.BulasiciHastalikVeriSeti.Ikamet_Il.ADI;
                    if(bulasici.BulasiciHastalikVeriSeti.Ikamet_Ilce != null)
                        this.IKAMETILCE.CalcValue = bulasici.BulasiciHastalikVeriSeti.Ikamet_Ilce.ADI;
                    if (bulasici.BulasiciHastalikVeriSeti.Ikamet_Bucak != null)
                        this.IKAMETBUCAK.CalcValue = bulasici.BulasiciHastalikVeriSeti.Ikamet_Bucak.ADI;
                    if (bulasici.BulasiciHastalikVeriSeti.Ikamet_Koy != null)
                        this.IKAMETKOY.CalcValue = bulasici.BulasiciHastalikVeriSeti.Ikamet_Koy.ADI;
                    if (bulasici.BulasiciHastalikVeriSeti.Ikamet_Mahalle != null)
                        this.IKAMETMAHALLE.CalcValue = bulasici.BulasiciHastalikVeriSeti.Ikamet_Mahalle.ADI;
                    if (bulasici.BulasiciHastalikVeriSeti.Ikamet_CSBM != null)
                        this.IKAMETCSBM.CalcValue = bulasici.BulasiciHastalikVeriSeti.Ikamet_CSBM.ADI;
                    if (bulasici.BulasiciHastalikVeriSeti.DisKapiNoIkamet != null)
                        this.IKAMETDISKAPINO.CalcValue = bulasici.BulasiciHastalikVeriSeti.DisKapiNoIkamet;
                    if (bulasici.BulasiciHastalikVeriSeti.IcKapiNoIkamet != null)
                        this.IKAMETICKAPINO.CalcValue = bulasici.BulasiciHastalikVeriSeti.IcKapiNoIkamet;

                    //Beyan
                   if (bulasici.BulasiciHastalikVeriSeti.Beyan_Il != null)
                        this.BEYANIL.CalcValue = bulasici.BulasiciHastalikVeriSeti.Beyan_Il.ADI;
                    if (bulasici.BulasiciHastalikVeriSeti.Beyan_Ilce != null)
                        this.BEYANILCE.CalcValue = bulasici.BulasiciHastalikVeriSeti.Beyan_Ilce.ADI;
                    if (bulasici.BulasiciHastalikVeriSeti.Beyan_Bucak != null)
                        this.BEYANBUCAK.CalcValue = bulasici.BulasiciHastalikVeriSeti.Beyan_Bucak.ADI;
                    if (bulasici.BulasiciHastalikVeriSeti.Beyan_Koy != null)
                        this.BEYANKOY.CalcValue = bulasici.BulasiciHastalikVeriSeti.Beyan_Koy.ADI;
                    if (bulasici.BulasiciHastalikVeriSeti.Beyan_Mahalle != null)
                        this.BEYANMAHALLE.CalcValue = bulasici.BulasiciHastalikVeriSeti.Beyan_Mahalle.ADI;
                    if (bulasici.BulasiciHastalikVeriSeti.Beyan_CSBM != null)
                        this.BEYANCSBM.CalcValue = bulasici.BulasiciHastalikVeriSeti.Beyan_CSBM.ADI;
                    if (bulasici.BulasiciHastalikVeriSeti.DisKapiNoBeyan != null)
                        this.BEYANDISKAPINO.CalcValue = bulasici.BulasiciHastalikVeriSeti.DisKapiNoBeyan;
                    if (bulasici.BulasiciHastalikVeriSeti.IcKapiNoBeyan != null)
                        this.BEYANICKAPINO.CalcValue = bulasici.BulasiciHastalikVeriSeti.IcKapiNoBeyan;
                    
                    //İrtibat Telefonu Bilgileri
                    if(bulasici.BulasiciHastalikVeriSeti.BulasiciHastalikTelefon.Count > 0){
                        this.TELNO.CalcValue = bulasici.BulasiciHastalikVeriSeti.BulasiciHastalikTelefon[0].TelefonNumarasi;
                    }
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

        public Form014()
        {
            Header = new HeaderGroup(this,"Header");
            MAIN = new MAINGroup(Header,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "TTOBJECTID", @"", true, true, false, new Guid("53c9e989-dad5-4f3f-b973-d0bda68f0942"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "FORM014";
            Caption = "Form 014";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
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