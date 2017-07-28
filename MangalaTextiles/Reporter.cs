﻿using MaterialSkin;
using MaterialSkin.Controls;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MangalaTextiles
{
    public partial class Reporter : MaterialForm
    {
        public Reporter()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {


            PdfDocument pdf = new PdfDocument();
            pdf.Info.Title = "INVENTROTY DETAILS";
            PdfPage pdfPage = pdf.AddPage();
            XGraphics graph = XGraphics.FromPdfPage(pdfPage);
            XFont font = new XFont("Verdana", 20, XFontStyle.Bold);
            XFont font2 = new XFont("Verdana", 15, XFontStyle.Bold);
            XFont font3 = new XFont("Verdana",12,XFontStyle.Regular);
            graph.DrawString("INVENTORY DETAILS", font, XBrushes.Black, new XRect(0, 0, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.Center);
            graph.DrawString("ITEM NAME                          QUANTITY", font2, XBrushes.Black, new XRect(40, 40, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.Center);
            int[] xy = new int[2];
            xy[0] = 40;
            xy[1] = 40;


            using (var context = new MyContext())
            {

                var items = context.Items.ToList();

                foreach(var it in items){


                        xy[1] = xy[1] + 40;

                        if (it.Item_Name.Length < 3)
                        {
                            graph.DrawString("" + it.Item_Name + "                                  " + it.Quantity.ToString(), font3, XBrushes.Black, new XRect(xy[0], xy[1], pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.Center);
                
                        }
                        else {

                            graph.DrawString("" + it.Item_Name + "                               " + it.Quantity, font3, XBrushes.Black, new XRect(xy[0], xy[1], pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.Center);
                
                        
                        }
                
                
                
                }


            }
        

            string pdfFilename = "D:firstpage.pdf";
            pdf.Save(pdfFilename);
            System.Diagnostics.Process.Start(pdfFilename);
            



        }
    }
}