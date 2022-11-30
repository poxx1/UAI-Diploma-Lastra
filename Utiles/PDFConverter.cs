using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;

namespace Utiles
{
    public class PDFConverter
    {
        public bool ConvertToPdf(DataGridView data)
        {
            if (data.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                string fecha = DateTime.Now.ToString("dd-MM-yy_hhmmss");
                sfd.FileName = "Informe.pdf"+"_"+fecha;
                bool fileError = false;

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                            return true;
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("No se pudo escribir en el disco, revise sus permisos" + ex.Message);
                            return false;
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            PdfPTable pdfTable = new PdfPTable(data.Columns.Count);
                            Document pdfDoc = new Document(PageSize.A4, 10f, 20f, 20f, 10f);
                            pdfTable.DefaultCell.Padding = 3;
                            pdfTable.WidthPercentage = 100;
                            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            PdfPTable pdfTable1 = new PdfPTable(1);
                            pdfTable1.DefaultCell.Padding = 3;
                            pdfTable1.WidthPercentage = 100;
                            pdfTable1.HorizontalAlignment = Element.ALIGN_CENTER;

                            pdfTable1.DefaultCell.BackgroundColor = new iTextSharp.text.BaseColor(240,1, 1);
                            
                            //Fecha
                            PdfPCell cell1 = new PdfPCell();
                            PdfPCell cell2 = new PdfPCell();

                            cell1.BackgroundColor = new iTextSharp.text.BaseColor(240, 1, 1);
                            cell2.BackgroundColor = new iTextSharp.text.BaseColor(240, 1, 1);

                            cell1.BorderColor = new iTextSharp.text.BaseColor(60, 1, 240);
                            //Titulo
                            

                            cell2 = new PdfPCell(new Phrase("\nInforme del listado de maquinas actuales por reparar", new Font(Font.FontFamily.TIMES_ROMAN, 20)));
                            cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell2.VerticalAlignment = Element.ALIGN_JUSTIFIED_ALL;
                            cell2.Colspan = 2;
                            cell2.BorderColor = new iTextSharp.text.BaseColor(240, 1, 1);
                            pdfTable1.AddCell(cell2);

                            cell1 = new PdfPCell(new Phrase($"\n Fecha del informe: {DateTime.Now.ToString("dd/MM/yy hh:mm:ss")}", new Font(Font.FontFamily.TIMES_ROMAN, 14)));
                            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell1.VerticalAlignment = Element.ALIGN_JUSTIFIED_ALL;
                            cell1.Colspan = 2;
                            pdfTable1.AddCell(cell1);
                            pdfTable1.AddCell(new PdfPCell(new Phrase($"\n", new Font(Font.FontFamily.COURIER, 14))));

                            foreach (DataGridViewColumn column in data.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, new Font(Font.FontFamily.HELVETICA, 14)));
                                cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                                cell1.VerticalAlignment = Element.ALIGN_JUSTIFIED_ALL;
                                cell1.Colspan = 2;
                                pdfTable.AddCell(cell);
                            }

                            foreach (DataGridViewRow row in data.Rows)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    if (cell.Value != null)
                                    {
                                        PdfPCell cell0 = new PdfPCell(new Phrase(cell.Value.ToString(), new Font(Font.FontFamily.HELVETICA, 10)));

                                        pdfTable.AddCell(cell0);
                                    }
                                    else
                                        pdfTable.AddCell("S/D");
                                }
                            }

                            //using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                            //{
                            FileStream fs = new FileStream(sfd.FileName, FileMode.Create);
                           
                            //pdfDoc.AddAuthor("Informe del Gerente");
                            //pdfDoc.AddTitle("");
                            //pdfDoc.AddSubject(fecha);
                            pdfDoc.AddCreationDate();
                            PdfWriter.GetInstance(pdfDoc, fs);
                            pdfDoc.Open();
                            pdfDoc.Add(pdfTable1);
                            pdfDoc.Add(pdfTable);
                            pdfDoc.Close();
                            fs.Close();
                            //}

                            MessageBox.Show("Se exporto el PDF en la ruta que usted eligio", "Info");

                            return true;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error :" + ex.Message);
                            return false;
                        }
                    }
                }
                return true;
            }
            else
            {
                MessageBox.Show("No hay nada para exportar", "Info");
                return false;
            }
        }
    }
}
