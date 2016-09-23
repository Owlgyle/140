using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using IDAutomation_FontEncoder;

using System.Configuration;
using System.Data.OleDb;
//using Excel = Microsoft.Office.Interop.Excel;

namespace WindowsFormsApplication1
{

    public struct label_layout
    {
        public bool landScapeMode;
        public float startX, startY, endX, endY;
        public float upcX, upcY, upcSize;
        public float bcodeX, bcodeY, bcodeSize;
        public float skuX, skuY, skuSize;
        public float descripX, descripY, descripSize, descripLineLength, descripLineHeight;
        public float boxX, boxY, boxSize;
        public float internalX, internalY, internalSize;
        public float labelWidth, labelHeight;
        public float labelLineX, labelLineY, labelLineLength;
        public float labelBoxX, labelBoxY, labelBoxWidth, labelBoxHeigth;
    };


    public static class util_functions
    {
        public static bool printedTotal = false;
        public static byte numberLabels = 0, curLabel = 0, labelID = 0;
        public static byte[] buffer;
        public static string str1, pText, bText, curPrinterName, printNumber, quoteNum, orderNumber;
        public static string[] ar1, str2, str3;
        public static int bitmapScaleY, userID = 0, invAmt, spacing = 0, itemsX = 0, itemsY = 0, itemsPerPage = 0, globalX = 0, globalY = 0, pgNumX = 0, pgNumY = 0;
        public static int captionX = 0, captionY = 0, dateX = 0, dateY = 0, ordernoX = 0, ordernoY = 0, soldtoX = 0, soldtoY = 0, shiptoX = 0, shiptoY = 0, termsX = 0, termsY = 0, shippedX = 0, shippedY = 0, viaX = 0, viaY = 0, col1X = 0, col1Y = 0, col2X = 0, col2Y = 0, col3X = 0, col3Y = 0, col4X = 0, col4Y = 0, col5X = 0, col5Y = 0, headerX = 0, headerY = 0, skuX = 0, quoteTotalX = 0, dcPercX = 0, customerNameX = 0, customerNameY = 0, jobX = 0, jobY = 0;
        public static int printNotesCurLine = 0, curItemToPrint = 14, qtyX = 0, tallyX = 0, descX = 0, priceX = 0, errX = 0, amtX = 0, cubesX = 0, curBox = 0, curQty = 0, curPage = 0, palletsPerBox = 0, curPallets = 0, itemsPrinted = 0, discountX = 0, discountY = 0, directCostX = 0, directCostY = 0, customerX = 0, customerY = 0, quoteNameX = 0, quoteNameY = 0, newPriceX = 0, newPriceExtX = 0, dcX = 0, dcExtX = 0;
        public static float bitmapScale, cubes = 0.0f, curWeight;
        public static float priceTotal, newpricetotal, costtotal, dcExtTotal, cost;

        public static label_layout[] labels;


        public static string urlEncoded(string str1)
        {
            int x, y;
            string outStr, tempStr;
            char[] c;

            outStr = "";

            for (x = 0; x < str1.Length; x++)
            {
                c = str1.Substring(x, 1).ToCharArray();
                y = (int)c[0];
                if ((y >= 48 && y <= 57) || (y >= 65 && y <= 90) || (y >= 97 && y <= 122))
                {
                    outStr = outStr + str1.Substring(x, 1);
                }
                else
                {
                    tempStr = String.Format("{0:X}", Convert.ToInt32(c[0]));
                    if (tempStr.Length < 2)
                        tempStr = "0" + tempStr;
                    outStr = outStr + "%" + tempStr;
                }
            }

            return outStr;
        }

        public static string Get_Web_Page(string url)
        {
            WebRequest Socket1;
            WebResponse socketData;
            StreamReader s1;

            try
            {

                url = url + "?f_username=" + Form1.un.Trim() + "&f_password=" + Form1.pw.Trim();
                if (Form1.cfid.Trim() != "" && Form1.cftoken.Trim() != "")
                    url = url + "&cfid=" + Form1.cfid + "&cftoken=" + Form1.cftoken;

                Socket1 = WebRequest.Create("http://" + Form1.serverUrl + url);
                socketData = Socket1.GetResponse();
                s1 = new StreamReader(socketData.GetResponseStream());
                url = s1.ReadToEnd();
                socketData.Close();

                return url;

            }
            catch (Exception e1)
            {
                MessageBox.Show("An error has occured.\n\n" + e1.Message + "\n\nAn Error Occured while loading a web page.");
                return "Error";
            }
        }

        public static string Get_Web_Page(string url, string urlParams)
        {
            WebRequest Socket1;
            WebResponse socketData;
            StreamReader s1;

            try
            {

                url = url + "?f_username=" + Form1.un.Trim() + "&f_password=" + Form1.pw.Trim();
                if (Form1.cfid.Trim() != "" && Form1.cftoken.Trim() != "")
                    url = url + "&cfid=" + Form1.cfid + "&cftoken=" + Form1.cftoken;

                if (urlParams.Trim() != "")
                    url = url + "&" + urlParams;

                Socket1 = WebRequest.Create("http://" + Form1.serverUrl + url);
                socketData = Socket1.GetResponse();
                s1 = new StreamReader(socketData.GetResponseStream());
                url = s1.ReadToEnd();
                socketData.Close();

                return url;

            }
            catch (Exception e1)
            {
                MessageBox.Show("An error has occured.\n\n" + e1.Message + "\n\nAn Error Occured while loading a web page.");
                return "Error";
            }
        }

        public static string Get_Web_Page(string url, string urlParams, bool show)
        {
            WebRequest Socket1;
            WebResponse socketData;
            StreamReader s1;

            try
            {

                url = url + "?f_username=" + Form1.un.Trim() + "&f_password=" + Form1.pw.Trim();
                if (Form1.cfid.Trim() != "" && Form1.cftoken.Trim() != "")
                    url = url + "&cfid=" + Form1.cfid + "&cftoken=" + Form1.cftoken;

                if (urlParams.Trim() != "")
                    url = url + "&" + urlParams;

                Socket1 = WebRequest.Create("http://" + Form1.serverUrl + url);
                socketData = Socket1.GetResponse();
                s1 = new StreamReader(socketData.GetResponseStream());
                url = s1.ReadToEnd();
                socketData.Close();

                return url;

            }
            catch (Exception e1)
            {
                MessageBox.Show("An error has occured.\n\n" + e1.Message + "\n\nAn Error Occured while loading a web page.");
                return "Error";
            }
        }

        public static string Post_Web_Form(string url, string strData)
        {
            WebRequest Socket1;
            WebResponse socketData;
            StreamReader s1;

            try
            {

                url = url + "?f_username=" + Form1.un.Trim() + "&f_password=" + Form1.pw.Trim();
                if (Form1.cfid.Trim() != "" && Form1.cftoken.Trim() != "")
                    url = url + "&cfid=" + Form1.cfid + "&cftoken=" + Form1.cftoken;

                Socket1 = WebRequest.Create("http://" + Form1.serverUrl + url);
                Socket1.Method = "POST";
                Socket1.ContentType = "application/x-www-form-urlencoded";
                Socket1.ContentLength = strData.Length;
                StreamWriter sw = new StreamWriter(Socket1.GetRequestStream());
                sw.Write(strData);
                sw.Close();
                socketData = Socket1.GetResponse();
                s1 = new StreamReader(socketData.GetResponseStream());
                url = s1.ReadToEnd();
                socketData.Close();

                return url;

            }
            catch (Exception e1)
            {
                MessageBox.Show("An error has occured.\n\n" + e1.Message + "\n\nAn Error Occured while sending data to the server.");
                return "Error";
            }
        }

        public static bool isnumeric(string number)
        {
            float x;

            if (float.TryParse(number, out x))
                return true;

            return false;
        }

        /// <summary>
        /// numCopies - 2
        /// </summary>
        public static void Print_Order(string orderID, string printerName, short numCopies)
        {
            int x, y;
            string printResults;

            FileStream fp;
            ASCIIEncoding enc = new System.Text.ASCIIEncoding();
            PrintDocument printDocument1 = new PrintDocument();

            try
            {

                printResults = util_functions.Get_Web_Page("/admin/vb_Print_Order12.cfm", "f_id=" + orderID.Trim());

                x = printResults.IndexOf("<>");
                if (x >= 0 && printResults.Length > x + 2)
                {
                    Form1.cfid = printResults.Substring(0, x);
                    y = Form1.cfid.IndexOf(":");
                    if (y >= 0)
                    {
                        Form1.cftoken = Form1.cfid.Substring(y + 1, Form1.cfid.Length - y - 1);
                        Form1.cfid = Form1.cfid.Substring(0, y);
                    }
                    printResults = printResults.Substring(x + 4, printResults.Length - x - 4);
                }
                else
                {
                    MessageBox.Show("Error: The order was not found.");
                    return;
                }

                globalX = 0;
                globalY = 0;

                ar1 = printResults.Split(new string[] { "\r\n" }, StringSplitOptions.None);

                try
                {
                    fp = File.Open(Application.StartupPath + "\\print.txt", FileMode.Open, FileAccess.Read);
                    buffer = new byte[fp.Length];

                    fp.Read(buffer, 0, buffer.Length);
                    str1 = enc.GetString(buffer, 0, buffer.Length);
                    str2 = str1.Split(new string[] { "\r\n" }, StringSplitOptions.None);

                    fp.Close();
                }
                catch
                {
                    MessageBox.Show("Error trying to read file " + Application.StartupPath + "\\print.txt");
                    return;
                }

                for (x = 0; x < str2.Length; x++)
                {
                    str3 = str2[x].Split(new char[] { ',' });
                    if (str3.Length == 3)
                    {
                        if (String.Compare(str3[0].Trim(), "i", true) == 0)
                        {
                            itemsX = Convert.ToInt32(str3[1]) + globalX;
                            itemsY = Convert.ToInt32(str3[2]) + globalY;
                        }
                        else if (String.Compare(str3[0].Trim(), "s", true) == 0)
                        {
                            spacing = Convert.ToInt32(str3[2]);
                        }
                        else if (String.Compare(str3[0].Trim(), "qty", true) == 0)
                        {
                            qtyX = Convert.ToInt32(str3[1]) + globalX;
                        }
                        else if (String.Compare(str3[0].Trim(), "tally", true) == 0)
                        {
                            tallyX = Convert.ToInt32(str3[1]) + globalX;
                        }
                        else if (String.Compare(str3[0].Trim(), "desc", true) == 0)
                        {
                            descX = Convert.ToInt32(str3[1]) + globalX;
                        }
                        else if (String.Compare(str3[0].Trim(), "price", true) == 0)
                        {
                            priceX = Convert.ToInt32(str3[1]) + globalX;
                        }
                        else if (String.Compare(str3[0].Trim(), "amt", true) == 0)
                        {
                            amtX = Convert.ToInt32(str3[1]) + globalX;
                        }
                        else if (String.Compare(str3[0].Trim(), "cubes", true) == 0)
                        {
                            cubesX = Convert.ToInt32(str3[1]) + globalX;
                        }
                        else if (String.Compare(str3[0].Trim(), "p", true) == 0)
                        {
                            itemsPerPage = Convert.ToInt32(str3[1]);
                        }
                        else if (String.Compare(str3[0].Trim(), "g", true) == 0)
                        {
                            globalX = Convert.ToInt32(str3[1]);
                            globalY = Convert.ToInt32(str3[2]);
                        }
                        else if (String.Compare(str3[0].Trim(), "pgnum", true) == 0)
                        {
                            pgNumX = Convert.ToInt32(str3[1]) + globalX;
                            pgNumY = Convert.ToInt32(str3[2]) + globalY;
                        }
                    }
                }

                ar1[11] = ar1[11].Replace("<p>", "\n");
                curPrinterName = printerName;
                curItemToPrint = 15;
                itemsPrinted = 0;
                cubes = 0;
                curWeight = 0.0f;
                curPage = 0;
                printedTotal = false;
                printNotesCurLine = 0;

                printDocument1.PrintPage += new PrintPageEventHandler(Print_Order_Page);
                printDocument1.PrinterSettings.Copies = numCopies;
                printDocument1.PrinterSettings.PrinterName = printerName;
                printDocument1.Print();
            }
            catch (Exception e1)
            {
                MessageBox.Show("An error occured while printing order id " + orderID + "\n\n" + e1.Message);
            }
        }

        public static void Print_Order_Page(object sender, PrintPageEventArgs e)
        {
            int a, w, x, y = 0, z = 0;
            float f1, f2;
            string eachString;
            
            Font printFont = new Font(Form1.fName, Convert.ToSingle(Form1.fSize)), barCodeFont = new Font(Form1.fName3, Convert.ToSingle(Form1.fSize3));
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            try
            {
                curPage = curPage + 1;
                for (x = 0; x < str2.Length; x++)
                {
                    str3 = str2[x].Split(new char[] { ',' });
                    if (str3.Length == 3)
                    {
                        if (util_functions.isnumeric(str3[0]) && util_functions.isnumeric(str3[1]) && util_functions.isnumeric(str3[2]))
                        {
                            if ( Convert.ToInt32(str3[0]) != 15 )
                                e.Graphics.DrawString(ar1[Convert.ToInt32(str3[0]) - 1], printFont, drawBrush, Convert.ToInt32(str3[1]) + globalX, Convert.ToInt32(str3[2]) + globalY, new StringFormat());
                            else
                                // Print the barcode with asterisks around it
                                e.Graphics.DrawString("*" + ar1[Convert.ToInt32(str3[0]) - 1] + "*", barCodeFont, drawBrush, Convert.ToInt32(str3[1]) + globalX, Convert.ToInt32(str3[2]) + globalY, new StringFormat());
                        }
                    }
                }

                e.Graphics.DrawString(curPage.ToString(), printFont, drawBrush, pgNumX, pgNumY, new StringFormat());
                z = itemsY;
                y = 1;


                a = ar1.Length - 1;     // The string split funtion returns an empty string at the end so down count the amount of items by one
                for (x = curItemToPrint; x < a; x += 10)
                {
                    curItemToPrint += 10;

                    if (util_functions.isnumeric(ar1[x + 9]))
                        curWeight += Convert.ToSingle(ar1[x + 9]);

                    if (ar1[x + 8].IndexOf("bb", 0, StringComparison.OrdinalIgnoreCase) > -1)
                        eachString = " ea";
                    else
                        eachString = "";


                    if (String.Compare(ar1[x + 6], "0", true) != 0)
                        bText = "Bdls.";
                    else
                        bText = "Boxes";

                    pText = ar1[x + 7];

                    e.Graphics.DrawString(ar1[x], printFont, drawBrush, qtyX, z, new StringFormat());
                    curQty = Convert.ToInt32(ar1[x]);

                    if (util_functions.isnumeric(ar1[x + 1]))
                    {
                        curBox = Convert.ToInt32(ar1[x + 1]);
                        palletsPerBox = Convert.ToInt32(ar1[x + 4]);
                    }
                    else
                    {
                        curBox = 0;
                        palletsPerBox = 0;
                    }


                    e.Graphics.DrawString(ar1[x + 2], printFont, drawBrush, descX, z, new StringFormat());

                    if (curBox > 0)
                        cubes = cubes + ((curQty / curBox) * Convert.ToSingle(ar1[x + 3]));


                    if (curBox == 0)
                    {
                        e.Graphics.DrawString("0" + eachString, printFont, drawBrush, priceX, z, new StringFormat());
                    }
                    else if ((int)(curQty / curBox) != (float)curQty / (float)curBox)
                    {
                        e.Graphics.DrawString("0" + eachString, printFont, drawBrush, priceX, z, new StringFormat());
                    }
                    else
                    {
                        if (palletsPerBox < 1 || (curQty / curBox) < palletsPerBox)
                        {
                            f1 = (float)curQty / (float)curBox;
                            e.Graphics.DrawString(f1.ToString() + eachString, printFont, drawBrush, priceX, z, new StringFormat());
                        }
                        else
                        {
                            curPallets = (int)((curQty / curBox) / palletsPerBox);
                            cubes = cubes + (curPallets * Convert.ToSingle(ar1[x + 5]));

                            f1 = (float)curQty / (float)curBox;
                            f2 = f1 / (float)palletsPerBox;
                            if (curPallets == f2)
                            {
                                e.Graphics.DrawString(f1.ToString() + eachString + " " + f2.ToString() + " " + pText + "(s)", printFont, drawBrush, priceX, z, new StringFormat());
                            }
                            else
                            {
                                f2 = f1 - (float)(curPallets * palletsPerBox);
                                e.Graphics.DrawString(f1.ToString() + eachString + "(" + curPallets.ToString() + " " + pText + "(s) + " + f2.ToString() + " " + bText + ")", printFont, drawBrush, priceX, z, new StringFormat());
                            }
                        }
                    }

                    z += spacing;
                    itemsPrinted++;

                    y++;
                    if (y > itemsPerPage)
                    {
                        e.HasMorePages = true;
                        return;
                    }

                }


                if (!printedTotal)
                {
                    printedTotal = true;
                    if (String.Compare(curPrinterName, Form1.p1, true) != 0)
                    {
                        x = itemsPerPage - y;
                        if (x > 2)
                            x = 2;
                        z += (x * spacing);
                    }

                    e.Graphics.DrawString("CUBIC FEET TOTAL", printFont, drawBrush, descX, z, new StringFormat());
                    e.Graphics.DrawString(cubes.ToString(), printFont, drawBrush, priceX, z, new StringFormat());
                    e.Graphics.DrawString("Count: " + itemsPrinted.ToString(), printFont, drawBrush, qtyX, z, new StringFormat());
                    z += spacing;
                    e.Graphics.DrawString("WEIGHT TOTAL", printFont, drawBrush, descX, z, new StringFormat());
                    e.Graphics.DrawString(curWeight.ToString("0.00") + " lbs.", printFont, drawBrush, priceX, z, new StringFormat());
                    z += spacing;
                    y = y + 3;
                }

                if (ar1[11].Trim() != "")
                {
                    for (; printNotesCurLine < 4; printNotesCurLine++, z += spacing)
                    {
                        // Don't print another page if we're just printing the trailing asterisks.  Make sure there are more notes.
                        if (y > itemsPerPage && printNotesCurLine < 5)
                        {
                            e.HasMorePages = true;
                            return;
                        }

                        if (printNotesCurLine == 0)
                        {
                            e.Graphics.DrawString("************************************************************************************************************************", printFont, drawBrush, qtyX, z, new StringFormat());
                            y++;
                        }
                        else if (printNotesCurLine < 4)
                        {
                            w = ar1[11].IndexOf("\r\n");
                            if (w < 0)
                            {
                                if (ar1[11].Length > 120)
                                {
                                    e.Graphics.DrawString(ar1[11].Substring(0, 120), printFont, drawBrush, qtyX, z, new StringFormat());
                                    ar1[11] = ar1[11].Substring(120);
                                }
                                else
                                {
                                    e.Graphics.DrawString(ar1[11], printFont, drawBrush, qtyX, z, new StringFormat());
                                    ar1[11] = "";
                                }
                            }
                            else
                            {
                                e.Graphics.DrawString(ar1[11].Substring(0, w - 1), printFont, drawBrush, qtyX, z, new StringFormat());
                                if (ar1[11].Length > w + 2)
                                    ar1[11] = ar1[11].Substring(w + 2);
                                else
                                    ar1[11] = "";
                            }

                            y++;

                            //if (printNotesCurLine == 4 && y <= itemsPerPage)
                            //{
                            //    e.Graphics.DrawString("************************************************************************************************************************", printFont, drawBrush, qtyX, z, new StringFormat());
                            //    y++;
                            //}
                        }
                    }
                }
                e.HasMorePages = false;
            }
            catch (Exception e1)
            {
                MessageBox.Show("Error printing order.\n\n" + e1.Message);
                e.HasMorePages = false;
            }
        }

        public static void Print_Labels()
        {
            int x, y, printerIndex;

            FileStream fp;
            ASCIIEncoding enc = new System.Text.ASCIIEncoding();
            PrintDocument printDocument1 = new PrintDocument();
            SqlConnection conn = new SqlConnection("Data Source=Romeo;Initial Catalog=Royal;User ID=royal;password=wkjwuq");
            SqlCommand cmd;
            SqlDataReader rdr = null;

            try
            {
                try
                {
                    fp = File.Open(Application.StartupPath + "\\print_labels.txt", FileMode.Open, FileAccess.Read);
                    buffer = new byte[fp.Length];

                    fp.Read(buffer, 0, buffer.Length);
                    str1 = enc.GetString(buffer, 0, buffer.Length);
                    str2 = str1.Split(new string[] { "\r\n" }, StringSplitOptions.None);

                    fp.Close();
                }
                catch
                {
                    MessageBox.Show("Error trying to read file " + Application.StartupPath + "\\print_labels.txt");
                    return;
                }

                curLabel = 0;
                for (x = 0; x < str2.Length; x++)
                {
                    str3 = str2[x].Split(new char[] { ',' });
                    if (str3.Length > 0 )
                    { 
                        if (String.Compare(str3[0].Trim(), "numberLabels", true) == 0)
                        {
                            numberLabels = Convert.ToByte(str3[1]);
                            labels = new label_layout[numberLabels];
                            for (y = 0; y < numberLabels; ++y)
                            {
                                labels[y].landScapeMode = false;
                                labels[y].labelLineLength = 0.0f;
                                labels[y].labelBoxWidth = 0.0f;
                                labels[y].internalSize = 0;
                            }
                        }
                        else if (String.Compare(str3[0].Trim(), "label", true) == 0)
                        {
                            curLabel = Convert.ToByte(str3[1]);
                        }
                        else if (String.Compare(str3[0].Trim(), "topLeft", true) == 0)
                        {
                            labels[curLabel].startX = Convert.ToSingle(str3[1]);
                            labels[curLabel].startY = Convert.ToSingle(str3[2]);
                        }
                        else if (String.Compare(str3[0].Trim(), "bottomRight", true) == 0)
                        {
                            labels[curLabel].endX = Convert.ToSingle(str3[1]);
                            labels[curLabel].endY = Convert.ToSingle(str3[2]);
                        }
                        else if (String.Compare(str3[0].Trim(), "bcode", true) == 0)
                        {
                            labels[curLabel].bcodeX = Convert.ToSingle(str3[1]);
                            labels[curLabel].bcodeY = Convert.ToSingle(str3[2]);
                            labels[curLabel].bcodeSize = Convert.ToSingle(str3[3]);
                        }
                        else if (String.Compare(str3[0].Trim(), "upc", true) == 0)
                        {
                            labels[curLabel].upcX = Convert.ToSingle(str3[1]);
                            labels[curLabel].upcY = Convert.ToSingle(str3[2]);
                            labels[curLabel].upcSize = Convert.ToSingle(str3[3]);
                        }
                        else if (String.Compare(str3[0].Trim(), "sku", true) == 0)
                        {
                            labels[curLabel].skuX = Convert.ToSingle(str3[1]);
                            labels[curLabel].skuY = Convert.ToSingle(str3[2]);
                            labels[curLabel].skuSize = Convert.ToSingle(str3[3]);
                        }
                        else if (String.Compare(str3[0].Trim(), "descrip", true) == 0)
                        {
                            labels[curLabel].descripX = Convert.ToSingle(str3[1]);
                            labels[curLabel].descripY = Convert.ToSingle(str3[2]);
                            labels[curLabel].descripSize = Convert.ToSingle(str3[3]);
                            labels[curLabel].descripLineLength = Convert.ToSingle(str3[4]);
                            labels[curLabel].descripLineHeight = Convert.ToSingle(str3[5]);
                        }
                        else if (String.Compare(str3[0].Trim(), "box", true) == 0)
                        {
                            labels[curLabel].boxX = Convert.ToSingle(str3[1]);
                            labels[curLabel].boxY = Convert.ToSingle(str3[2]);
                            labels[curLabel].boxSize = Convert.ToSingle(str3[3]);
                        }
                        else if (String.Compare(str3[0].Trim(), "internal", true) == 0)
                        {
                            labels[curLabel].internalX = Convert.ToSingle(str3[1]);
                            labels[curLabel].internalY = Convert.ToSingle(str3[2]);
                            labels[curLabel].internalSize = Convert.ToSingle(str3[3]);
                        }
                        else if (String.Compare(str3[0].Trim(), "landscape", true) == 0)
                        {
                            labels[curLabel].landScapeMode = true;
                        }
                        else if (String.Compare(str3[0].Trim(), "size", true) == 0)
                        {
                            labels[curLabel].labelWidth = Convert.ToSingle(str3[1]);
                            labels[curLabel].labelHeight = Convert.ToSingle(str3[2]);
                        }
                        else if (String.Compare(str3[0].Trim(), "line", true) == 0)
                        {
                            labels[curLabel].labelLineX = Convert.ToSingle(str3[1]);
                            labels[curLabel].labelLineY = Convert.ToSingle(str3[2]);
                            labels[curLabel].labelLineLength = Convert.ToSingle(str3[3]);
                        }
                        else if (String.Compare(str3[0].Trim(), "boxarea", true) == 0)
                        {
                            labels[curLabel].labelBoxX = Convert.ToSingle(str3[1]);
                            labels[curLabel].labelBoxY = Convert.ToSingle(str3[2]);
                            labels[curLabel].labelBoxWidth = Convert.ToSingle(str3[3]);
                            labels[curLabel].labelBoxHeigth = Convert.ToSingle(str3[4]);
                        }
                        else if (String.Compare(str3[0].Trim(), "bitmap", true) == 0)
                        {
                            bitmapScale = Convert.ToSingle(str3[1]);
                        }

                    }
                }


                conn.Open();
                cmd = new SqlCommand("select ct from users where active=1 and username = '" + Form1.un.Trim() + "' and password = '" + Form1.pw.Trim() + "'", conn);
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows && rdr.Read())
                    userID = Convert.ToInt32(rdr["ct"].ToString());
                else
                {
                    userID = 0;
                    MessageBox.Show("Error: The current user was not found. Labels may not print until the logged in user can be found in the users table.");
                }
                if ( rdr != null )
                    rdr.Close();

                orderNumber = "";
                labelID = 0;
                for (curLabel = 0, printerIndex = 0; curLabel < numberLabels; ++curLabel,++printerIndex)
                {
                    cmd = new SqlCommand("select * from Scheduling_Skus_To_Print where userID = " + userID.ToString() + " and qty > 0 and labelFormat = " + curLabel.ToString() + " order by orderID", conn);
                    rdr = cmd.ExecuteReader();

                    if (rdr.HasRows && rdr.Read())
                    {
                        if (printerIndex >= Form1.numLabelPrinters) // If we've defined more labels in the system than the app is designed to use, default to the last label's printer
                            printerIndex = Form1.numLabelPrinters - 1;
                        printDocument1.DefaultPageSettings.Landscape = labels[curLabel].landScapeMode;
                        printDocument1.PrintPage += new PrintPageEventHandler(Print_Label);
                        printDocument1.PrinterSettings.Copies = 1;
                        printDocument1.PrinterSettings.PrinterName = Form1.labelPrinter[printerIndex];
                        printDocument1.Print();
                    }

                    if (rdr != null)
                        rdr.Close();
                }

                if (conn != null)
                    conn.Close();
            }
            catch (Exception e1)
            {
                MessageBox.Show("An error occured while printing sku" + "\n\n" + e1.Message);
            }
        }

        public static void Print_Label(object sender, PrintPageEventArgs e)
        {
            byte x=0;
            bool isNonStock = false;
            float bmWidth, bmHeight;
            string curSku = "(none)", unitID, serializedNum;
            clsBarCode barCodeEncoder = new clsBarCode();
            Pen newPen;
            SizeF stringWidth, stringWidth2, barcodeWidth, descripWidth, internalStringWidth = new SizeF(), cskuSize,orderIDSize;

            SqlConnection conn = new SqlConnection("Data Source=Romeo;Initial Catalog=Royal;User ID=royal;password=wkjwuq");
            SqlCommand cmd;
            SqlDataReader rdr = null;

            SolidBrush drawBrush = new SolidBrush(Color.Black);
            Font fontDescrip, fontSku, fontBox, barCodeFont, upcBarCodeFont, internalFont = new Font(Form1.fName, 1), fontOrderID;

            e.Graphics.PageUnit = GraphicsUnit.Inch;


            try
            {
                conn.Open();

                if (orderNumber.Trim() != "")
                {
                    #region Print Company Label and Exit

                    cmd = new SqlCommand("select \"order\".shipTo, company.name as coname from \"order\" left join company on \"order\".companyID = company.ct  where \"order\".ct = '" + orderNumber + "'", conn);
                    rdr = cmd.ExecuteReader();

                    if (rdr.HasRows && rdr.Read())
                    {
                        byte longestString;
                        float f1, f2, f3, f4;

                        newPen = new Pen(Color.Black, 0.05f);
                        e.Graphics.DrawRectangle(newPen, labels[labelID].startX, labels[labelID].startY, labels[labelID].labelWidth, labels[labelID].labelHeight);

                        fontDescrip = new Font(Form1.fName, labels[labelID].descripSize,FontStyle.Bold);
                        f1 = labels[labelID].labelWidth * 0.9f;
                        stringWidth = e.Graphics.MeasureString(rdr["coname"].ToString(), fontDescrip);
                        longestString = 0;
                        f2 = stringWidth.Width;
                        stringWidth = e.Graphics.MeasureString(rdr["shipTo"].ToString(), fontDescrip);
                        if (stringWidth.Width > f2)
                        {
                            f2 = stringWidth.Width;
                            longestString = 1;
                        }
                        stringWidth = e.Graphics.MeasureString("Order #" + orderNumber, fontDescrip);
                        if (stringWidth.Width > f2)
                        {
                            f2 = stringWidth.Width;
                            longestString = 2;
                        }
                        x = 0;
                        while (f2 > f1 && labels[labelID].skuSize - x > 1)
                        {
                            fontDescrip = new Font(Form1.fName, labels[labelID].descripSize - ++x, FontStyle.Bold);
                            switch (longestString)
                            {
                                case 0:
                                    stringWidth = e.Graphics.MeasureString(rdr["coname"].ToString(), fontDescrip);
                                    break;
                                case 1:
                                    stringWidth = e.Graphics.MeasureString(rdr["shipTo"].ToString(), fontDescrip);
                                    break;
                                case 2:
                                    stringWidth = e.Graphics.MeasureString("Order #" + orderNumber, fontDescrip);
                                    break;
                            }
                            f2 = stringWidth.Width;
                        }

                        f3 = f2 / 2.0f;
                        f2 = stringWidth.Height * 1.25f;
                        f4 = labels[labelID].startY + labels[labelID].labelHeight / 2.0f - f2;

                        stringWidth = e.Graphics.MeasureString(rdr["coname"].ToString(), fontDescrip);
                        f3 = stringWidth.Width / 2.0f;
                        e.Graphics.DrawString(rdr["coname"].ToString(), fontDescrip, drawBrush, labels[labelID].startX + labels[labelID].labelWidth / 2.0f - f3, f4, new StringFormat());

                        stringWidth = e.Graphics.MeasureString(rdr["shipTo"].ToString(), fontDescrip);
                        f3 = stringWidth.Width / 2.0f;
                        f1 = f2;
                        e.Graphics.DrawString(rdr["shipTo"].ToString(), fontDescrip, drawBrush, labels[labelID].startX + labels[labelID].labelWidth / 2.0f - f3, f4 + f1, new StringFormat());

                        stringWidth = e.Graphics.MeasureString("Order #" + orderNumber, fontDescrip);
                        f3 = stringWidth.Width / 2.0f;
                        f1 += f2;
                        e.Graphics.DrawString("Order #" + orderNumber, fontDescrip, drawBrush, labels[labelID].startX + labels[labelID].labelWidth / 2.0f - f3, f4 + f1, new StringFormat());
                    }

                    rdr.Close();

                    cmd = new SqlCommand("select * from Scheduling_Skus_To_Print where userID = " + userID.ToString() + " and qty > 0", conn);
                    rdr = cmd.ExecuteReader();

                    if (rdr.HasRows)
                        e.HasMorePages = true;
                    else
                        e.HasMorePages = false;

                    if (conn != null)
                        conn.Close();

                    orderNumber = "";

                    #endregion

                    return;
                }

                cmd = new SqlCommand("select * from Scheduling_Skus_To_Print where userID = " + userID.ToString() + " and qty > 0 and labelFormat = " + curLabel.ToString(), conn);
                rdr = cmd.ExecuteReader();

                if (rdr.HasRows && rdr.Read())
                {
                    isNonStock = Convert.ToBoolean(rdr["nonStock"].ToString());
                    labelID = Convert.ToByte(rdr["labelFormat"].ToString());
                    orderNumber = rdr["orderID"].ToString();
                    serializedNum = rdr["sequenceNum"].ToString();
                    while( serializedNum.Length < 7 )
                        serializedNum = "0" + serializedNum;
                    curSku = rdr["sku"].ToString();

                    fontSku = new Font(Form1.fName, labels[labelID].skuSize);
                    fontOrderID = new Font(Form1.fName, labels[labelID].skuSize);
                    fontBox = new Font(Form1.fName, labels[labelID].boxSize);
                    barCodeFont = new Font(Form1.fontBCode1, labels[labelID].bcodeSize);
                    upcBarCodeFont = new Font(Form1.fontBCode2, labels[labelID].upcSize);
                    if (labels[labelID].internalSize > 0)
                        internalFont = new Font(Form1.fName, labels[labelID].internalSize);

                    stringWidth = e.Graphics.MeasureString(barCodeEncoder.UPCA(rdr["upc"].ToString()), upcBarCodeFont);
                    stringWidth2 = e.Graphics.MeasureString(rdr["csku"].ToString(), fontSku);
                    if (labels[labelID].internalSize > 0)
                        internalStringWidth = e.Graphics.MeasureString("INTERNAL USE ONLY", internalFont);
                    barcodeWidth = e.Graphics.MeasureString("(" + rdr["bcode"].ToString() + serializedNum + ")", barCodeFont);
                    cskuSize = e.Graphics.MeasureString(rdr["csku"].ToString(), fontSku);
                    orderIDSize = e.Graphics.MeasureString(rdr["shipTo"].ToString(), fontOrderID);
                    if (labels[labelID].labelBoxWidth > 0.0f)
                    {
                        x = 0;
                        while (orderIDSize.Width >= labels[labelID].labelBoxWidth && labels[labelID].skuSize - x > 1)
                        {
                            fontOrderID = new Font(Form1.fName, labels[labelID].skuSize - ++x);
                            orderIDSize = e.Graphics.MeasureString(rdr["shipTo"].ToString(), fontOrderID);
                        }
                    }

                    // Draw this first since the bitmap's white area can cover up other parts of the printed label if it comes later
                    #region Draw Sku Descrip

                    fontDescrip = new Font(Form1.fName, labels[labelID].descripSize);
                    bmWidth = bitmapScale * labels[labelID].descripLineLength;
                    bmHeight = bitmapScale * labels[labelID].descripLineHeight;

                    Bitmap bm = new Bitmap((int)bmWidth, (int)bitmapScale);

                    using (Graphics g = Graphics.FromImage(bm))
                    {
                        float scaleX = 1.0f, scaleY = 1.0f, maxScaleX;

                        descripWidth = g.MeasureString(rdr["descrip"].ToString(), fontDescrip);
                        x = 0;
                        // If the description is too long, lower the font size until it fits
                        while (descripWidth.Width > bmWidth && labels[labelID].descripSize - x > 1)
                        {
                            fontDescrip = new Font(Form1.fName, labels[labelID].descripSize - ++x);
                            descripWidth = g.MeasureString(rdr["descrip"].ToString(), fontDescrip);
                        }

                        maxScaleX = bmWidth / descripWidth.Width;
                        if (descripWidth.Width > bmWidth)
                            scaleX = bmWidth / descripWidth.Width;
                        scaleY = bmHeight / descripWidth.Height;  // Force height to take up full space
                        if (maxScaleX > 1.0f && scaleX < scaleY)    // If the string can be scaled UP in the x direction AND the y scaling is larger than the default x scaling, scale the X up as close as it can to match the y scaling. This minimizes the font distortion from the y scaling.
                            scaleX = Math.Min(scaleY, maxScaleX);

                        g.ScaleTransform(scaleX, scaleY);
                        g.Clear(Color.White);
                        g.DrawString(rdr["descrip"].ToString(), fontDescrip, Brushes.Black, new PointF(0, 0), new StringFormat(StringFormatFlags.NoWrap | StringFormatFlags.NoClip));
                    }
                    e.Graphics.DrawImage(bm, labels[labelID].startX + labels[labelID].descripX, labels[labelID].startY + labels[labelID].descripY);

                    //e.Graphics.DrawString(rdr["descrip"].ToString(), fontDescip, drawBrush, labels[labelID].startX + labels[labelID].descripX, labels[labelID].startY + labels[labelID].descripY, new StringFormat());

                    #endregion


                    newPen = new Pen(Color.Black,0.05f);
                    e.Graphics.DrawRectangle(newPen, labels[labelID].startX, labels[labelID].startY, labels[labelID].labelWidth,labels[labelID].labelHeight);
                    if (labels[labelID].labelLineLength > 0.0f)
                    {
                        newPen = new Pen(Color.Black, 0.025f);
                        e.Graphics.DrawLine(newPen, labels[labelID].startX + labels[labelID].labelLineX, labels[labelID].startY + labels[labelID].labelLineY, labels[labelID].startX + labels[labelID].labelLineX + labels[labelID].labelLineLength, labels[labelID].startY + labels[labelID].labelLineY);
                    }
                    if (labels[labelID].labelBoxWidth > 0.0f)
                    {
                        newPen = new Pen(Color.Black, 0.0125f);
                        e.Graphics.DrawRectangle(newPen, labels[labelID].startX + labels[labelID].labelBoxX, labels[labelID].startY + labels[labelID].labelBoxY, labels[labelID].labelBoxWidth, labels[labelID].labelBoxHeigth);
                    }

                    if (labels[labelID].labelBoxWidth > 0.0f)
                    {
                        e.Graphics.DrawString(rdr["csku"].ToString(), fontSku, drawBrush, labels[labelID].startX + labels[labelID].skuX - (stringWidth2.Width / 2.0f), labels[labelID].startY + labels[labelID].skuY, new StringFormat());
                        e.Graphics.DrawString(rdr["orderID"].ToString() + "\n" + rdr["shipTo"].ToString(), fontOrderID, drawBrush, labels[labelID].startX + labels[labelID].skuX - (orderIDSize.Width / 2.0f), labels[labelID].startY + labels[labelID].skuY + cskuSize.Height, new StringFormat());
                    }

                    e.Graphics.DrawString(rdr["box"].ToString() + "EA.", fontBox, drawBrush, labels[labelID].startX + labels[labelID].boxX, labels[labelID].startY + labels[labelID].boxY, new StringFormat());

                    // "(" & ")" are start/stop characters for the barcode printing
                    e.Graphics.DrawString("(" + rdr["bcode"].ToString() + serializedNum + ")", barCodeFont, drawBrush, labels[labelID].startX + labels[labelID].bcodeX - ( barcodeWidth.Width / 2.0f), labels[labelID].startY + labels[labelID].bcodeY, new StringFormat());

                    e.Graphics.DrawString(barCodeEncoder.UPCA(rdr["upc"].ToString()), upcBarCodeFont, drawBrush, labels[labelID].startX + labels[labelID].upcX - (stringWidth.Width / 2.0f), labels[labelID].startY + labels[labelID].upcY, new StringFormat());

                    if ( labels[labelID].internalSize > 0 )
                        e.Graphics.DrawString("INTERNAL USE ONLY", internalFont, drawBrush, labels[labelID].startX + labels[labelID].internalX - (internalStringWidth.Width / 2.0f), labels[labelID].startY + labels[labelID].internalY, new StringFormat());


                    unitID = rdr["unitID"].ToString();
                    cmd = new SqlCommand("update Scheduling_Skus_To_Print set sequenceNum = sequenceNum + 1, qty = qty -1 where ct = " + rdr["ct"].ToString(), conn);
                    rdr.Close();
                    rdr = cmd.ExecuteReader();
                    rdr.Close();

                    cmd = new SqlCommand("update units set barCodeSerializedNum = barCodeSerializedNum + 1  where ct = " + unitID, conn);
                    rdr.Close();
                    rdr = cmd.ExecuteReader();
                    rdr.Close();

                }


                if (rdr != null)
                    rdr.Close();

                if (!util_functions.isnumeric(orderNumber) || !isNonStock )
                {
                    // Don't need to print a company label

                    orderNumber = "";   // If the order number is numeric but this is a stock item, clear the order number so a label doesn't print

                    cmd = new SqlCommand("select * from Scheduling_Skus_To_Print where userID = " + userID.ToString() + " and qty > 0", conn);
                    rdr = cmd.ExecuteReader();

                    if (rdr.HasRows)
                        e.HasMorePages = true;
                    else
                        e.HasMorePages = false;
                }
                else
                    e.HasMorePages = true;

                if (conn != null)
                    conn.Close();
            }
            catch (Exception e1)
            {
                MessageBox.Show("Error printing order.\n\n" + e1.Message);
                e.HasMorePages = false;

                if (rdr != null)
                    rdr.Close();

                if (conn != null)
                    conn.Close();
            }
        }

        /// <summary>
        /// numCopies - 1 setRegistery - false
        /// </summary>
        public static void Print_Invoice(string orderID, string printerName, short numCopies, bool setRegistry)
        {
            int x, y;
            string printResults, tempStr;

            FileStream fp;
            ASCIIEncoding enc = new System.Text.ASCIIEncoding();
            PrintDocument printDocument1 = new PrintDocument();
            DateTime newDate;

            try
            {
                printResults = util_functions.Get_Web_Page("/admin/vb_Print_Invoice5.cfm", "f_id=" + orderID.Trim() );

                x = printResults.IndexOf("<>");

                if (x >= 0 && printResults.Length > x + 2)
                {
                    Form1.cfid = printResults.Substring(0, x);
                    y = Form1.cfid.IndexOf(":");
                    if (y >= 0)
                    {
                        Form1.cftoken = Form1.cfid.Substring(y + 1, Form1.cfid.Length - y - 1);
                        Form1.cfid = Form1.cfid.Substring(0, y);
                    }
                    printResults = printResults.Substring(x + 4, printResults.Length - x - 4);
                }
                else
                {
                    MessageBox.Show("Error: The invoice was not found.");
                    return;
                }

                globalX = 0;
                globalY = 0;

                ar1 = printResults.Split(new string[] { "\r\n" }, StringSplitOptions.None);

                try
                {
                    fp = File.Open(Application.StartupPath + "\\print_inv.txt", FileMode.Open, FileAccess.Read);
                    buffer = new byte[fp.Length];

                    fp.Read(buffer, 0, buffer.Length);
                    str1 = enc.GetString(buffer, 0, buffer.Length);
                    str2 = str1.Split(new string[] { "\r\n" }, StringSplitOptions.None);

                    fp.Close();
                }
                catch
                {
                    MessageBox.Show("Error trying to read file " + Application.StartupPath + "\\print_inv.txt. This file is required for printing.");
                    return;
                }

                if (setRegistry)
                {
                    tempStr = ar1[11].Replace("\r", "");
                    Set_Registry_Key("DocName", tempStr, "");
                    Set_Registry_Key("Invoice #", tempStr, "\\FieldValues");

                    tempStr = ar1[2].Trim() + "\\" + ar1[13].Trim();
                    tempStr = tempStr.Replace("\r", "");
                    Set_Registry_Key("LfFolder", "Main\\Accounts Receivable\\Customers\\" + tempStr + "\\Invoices", "");

                    tempStr = ar1[10].Replace("\r", "");
                    Set_Registry_Key("PO #", tempStr, "\\FieldValues");

                    tempStr = ar1[8].Replace("\r", "");
                    Set_Registry_Key("Order Date", tempStr, "\\FieldValues");

                    tempStr = ar1[9].Replace("\r", "");
                    Set_Registry_Key("Ship Date", tempStr, "\\FieldValues");

                    tempStr = ar1[12].Replace("\r", "");
                    Set_Registry_Key("Customer #", tempStr, "\\FieldValues");

                    tempStr = ar1[13].Replace("\r", "");
                    Set_Registry_Key("Customer Name", tempStr, "\\FieldValues");

                    tempStr = ar1[14].Replace("\r", "");
                    Set_Registry_Key("Customer Location", tempStr, "\\FieldValues");

                    newDate = DateTime.Now;
                    Set_Registry_Key("CurrentOn", newDate.ToShortDateString(), "");
                    Set_Registry_Key("Scan Date", newDate.ToShortDateString(), "\\FieldValues");

                }

                for (x = 0; x < str2.Length; x++)
                {
                    str3 = str2[x].Split(new char[] { ',' });
                    if (str3.Length == 3)
                    {
                        if (String.Compare(str3[0].Trim(), "i", true) == 0)
                        {
                            itemsX = Convert.ToInt32(str3[1]) + globalX;
                            itemsY = Convert.ToInt32(str3[2]) + globalY;
                        }
                        else if (String.Compare(str3[0].Trim(), "s", true) == 0)
                        {
                            spacing = Convert.ToInt32(str3[2]);
                        }
                        else if (String.Compare(str3[0].Trim(), "qty", true) == 0)
                        {
                            qtyX = Convert.ToInt32(str3[1]) + globalX;
                        }
                        else if (String.Compare(str3[0].Trim(), "tally", true) == 0)
                        {
                            tallyX = Convert.ToInt32(str3[1]) + globalX;
                        }
                        else if (String.Compare(str3[0].Trim(), "desc", true) == 0)
                        {
                            descX = Convert.ToInt32(str3[1]) + globalX;
                        }
                        else if (String.Compare(str3[0].Trim(), "price", true) == 0)
                        {
                            priceX = Convert.ToInt32(str3[1]) + globalX;
                        }
                        else if (String.Compare(str3[0].Trim(), "amt", true) == 0)
                        {
                            amtX = Convert.ToInt32(str3[1]) + globalX;
                        }
                        else if (String.Compare(str3[0].Trim(), "p", true) == 0)
                        {
                            itemsPerPage = Convert.ToInt32(str3[1]);
                        }
                        else if (String.Compare(str3[0].Trim(), "g", true) == 0)
                        {
                            globalX = Convert.ToInt32(str3[1]);
                            globalY = Convert.ToInt32(str3[2]);
                        }
                        else if (String.Compare(str3[0].Trim(), "pgnum", true) == 0)
                        {
                            pgNumX = Convert.ToInt32(str3[1]) + globalX;
                            pgNumY = Convert.ToInt32(str3[2]) + globalY;
                        }
                        else if (String.Compare(str3[0].Trim(), "caption", true) == 0)
                        {
                            captionX = Convert.ToInt32(str3[1]) + globalX;
                            captionY = Convert.ToInt32(str3[2]) + globalY;
                        }
                        else if (String.Compare(str3[0].Trim(), "date", true) == 0)
                        {
                            dateX = Convert.ToInt32(str3[1]) + globalX;
                            dateY = Convert.ToInt32(str3[2]) + globalY;
                        }
                        else if (String.Compare(str3[0].Trim(), "orderno", true) == 0)
                        {
                            ordernoX = Convert.ToInt32(str3[1]) + globalX;
                            ordernoY = Convert.ToInt32(str3[2]) + globalY;
                        }
                        else if (String.Compare(str3[0].Trim(), "soldto", true) == 0)
                        {
                            soldtoX = Convert.ToInt32(str3[1]) + globalX;
                            soldtoY = Convert.ToInt32(str3[2]) + globalY;
                        }
                        else if (String.Compare(str3[0].Trim(), "shipto", true) == 0)
                        {
                            shiptoX = Convert.ToInt32(str3[1]) + globalX;
                            shiptoY = Convert.ToInt32(str3[2]) + globalY;
                        }
                        else if (String.Compare(str3[0].Trim(), "terms", true) == 0)
                        {
                            termsX = Convert.ToInt32(str3[1]) + globalX;
                            termsY = Convert.ToInt32(str3[2]) + globalY;
                        }
                        else if (String.Compare(str3[0].Trim(), "shipped", true) == 0)
                        {
                            shippedX = Convert.ToInt32(str3[1]) + globalX;
                            shippedY = Convert.ToInt32(str3[2]) + globalY;
                        }
                        else if (String.Compare(str3[0].Trim(), "via", true) == 0)
                        {
                            viaX = Convert.ToInt32(str3[1]) + globalX;
                            viaY = Convert.ToInt32(str3[2]) + globalY;
                        }
                        else if (String.Compare(str3[0].Trim(), "col1", true) == 0)
                        {
                            col1X = Convert.ToInt32(str3[1]) + globalX;
                            col1Y = Convert.ToInt32(str3[2]) + globalY;
                        }
                        else if (String.Compare(str3[0].Trim(), "col2", true) == 0)
                        {
                            col2X = Convert.ToInt32(str3[1]) + globalX;
                            col2Y = Convert.ToInt32(str3[2]) + globalY;
                        }
                        else if (String.Compare(str3[0].Trim(), "col3", true) == 0)
                        {
                            col3X = Convert.ToInt32(str3[1]) + globalX;
                            col3Y = Convert.ToInt32(str3[2]) + globalY;
                        }
                        else if (String.Compare(str3[0].Trim(), "col4", true) == 0)
                        {
                            col4X = Convert.ToInt32(str3[1]) + globalX;
                            col4Y = Convert.ToInt32(str3[2]) + globalY;
                        }
                        else if (String.Compare(str3[0].Trim(), "col5", true) == 0)
                        {
                            col5X = Convert.ToInt32(str3[1]) + globalX;
                            col5Y = Convert.ToInt32(str3[2]) + globalY;
                        }
                    }
                }

                curPrinterName = printerName;
                curItemToPrint = 17;
                itemsPrinted = 0;
                curPage = 0;
                invAmt = 0;

                printDocument1.PrintPage += new PrintPageEventHandler(Print_Invoice_Page);
                printDocument1.PrinterSettings.Copies = numCopies;
                printDocument1.PrinterSettings.PrinterName = printerName;
                printDocument1.Print();
            }
            catch (Exception e1)
            {
                MessageBox.Show("An error occured while printing invoice id " + str3[0] + "\n\n" + orderID + "\n\n" + e1.Message);
            }
        }

        public static void Print_Invoice_Page(object sender, PrintPageEventArgs e)
        {
            int a, x, y = 0, z = 0;
            float curAmt, f1;
            string str1,str4;

            Font printFont = new Font(Form1.fName, Convert.ToSingle(Form1.fSize));
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            try
            {
                curPage = curPage + 1;

                printInvoiceHeader(e, printFont, drawBrush);

                for (x = 0; x < str2.Length; x++)
                {
                    str3 = str2[x].Split(new char[] { ',' });
                    if (str3.Length == 3)
                    {
                        if (util_functions.isnumeric(str3[0]) && util_functions.isnumeric(str3[1]) && util_functions.isnumeric(str3[2]))
                            e.Graphics.DrawString(ar1[Convert.ToInt32(str3[0]) - 1], printFont, drawBrush, Convert.ToInt32(str3[1]) + globalX, Convert.ToInt32(str3[2]) + globalY, new StringFormat());
                    }
                }

                z = itemsY;
                y = 1;

                a = ar1.Length - 1;     // The string split funtion returns an empty string at the end so down count the amount of items by one
                for (x = curItemToPrint; x < a; x += 5)
                {
                    curItemToPrint += 5;

                    e.Graphics.DrawString(ar1[x], printFont, drawBrush, qtyX, z, new StringFormat());
                    e.Graphics.DrawString(ar1[x + 1], printFont, drawBrush, tallyX, z, new StringFormat());
                    e.Graphics.DrawString(ar1[x + 2], printFont, drawBrush, descX, z, new StringFormat());
                    e.Graphics.DrawString(String.Format("{0:0.00}", Convert.ToSingle(ar1[x + 3])), printFont, drawBrush, priceX, z, new StringFormat());
                    e.Graphics.DrawString(String.Format("{0:0.00}", Convert.ToSingle(ar1[x + 4])), printFont, drawBrush, amtX, z, new StringFormat());

                    // Due to floating point rounding issues, round the float and convert to an integer.  As we add to the integer, there are no floating point errors accumulating.
                    f1 = (float)Math.Round(float.Parse(ar1[x + 4]) * 100.0f, MidpointRounding.AwayFromZero);

                    invAmt = invAmt + (int)f1;
                    z += spacing;
                    itemsPrinted++;

                    y++;
                    if (y > itemsPerPage)
                    {
                        e.HasMorePages = true;
                        return;
                    }

                }

                a = itemsPerPage - y;
                if (a > 2)
                    a = 2;
                z += a * spacing;


                curAmt = (float)invAmt / 100.0f;
                str1 = String.Format("{0:0.00}", curAmt);
                e.Graphics.DrawString("TOTAL OF INVOICE", printFont, drawBrush, descX, z, new StringFormat());
                e.Graphics.DrawString(str1, printFont, drawBrush, amtX, z, new StringFormat());

                f1 = float.Parse(ar1[16]);
                if (f1 != 0.0f)
                {
                    str4 = String.Format("{0:0.00}", f1);
                    x = (int)e.Graphics.MeasureString(str1, printFont).Width - (int)e.Graphics.MeasureString(str4, printFont).Width;
                    z += spacing;
                    e.Graphics.DrawString("INVOICE DISCOUNT", printFont, drawBrush, descX, z, new StringFormat());
                    e.Graphics.DrawString(str4, printFont, drawBrush, amtX + x, z, new StringFormat());

                    str4 = String.Format("{0:0.00}", curAmt + f1);
                    x = (int)e.Graphics.MeasureString(str1, printFont).Width - (int)e.Graphics.MeasureString(str4, printFont).Width;
                    z += spacing;
                    e.Graphics.DrawString("TOTAL", printFont, drawBrush, descX, z, new StringFormat());
                    e.Graphics.DrawString(str4, printFont, drawBrush, amtX + x, z, new StringFormat());
                }

                e.HasMorePages = false;
            }
            catch (Exception e1)
            {
                MessageBox.Show("Error printing order.\n\n" + e1.Message);
                e.HasMorePages = false;
            }
        }

        static public void printInvoiceHeader(PrintPageEventArgs e, Font printFont, SolidBrush drawBrush)
        {
            int y;

            Pen drawPen = new Pen(drawBrush);
            Point startPt, endPt;

            e.Graphics.DrawString(curPage.ToString(), printFont, drawBrush, pgNumX, pgNumY, new StringFormat());

            y = captionY;
            e.Graphics.DrawString("Royal Metal Products", printFont, drawBrush, captionX, y, new StringFormat());
            y += spacing;
            e.Graphics.DrawString("100 Royal Way", printFont, drawBrush, captionX, y, new StringFormat());
            y += spacing;
            e.Graphics.DrawString("Temple, GA 30179", printFont, drawBrush, captionX, y, new StringFormat());
            y += spacing;
            e.Graphics.DrawString("(678) 563-0003", printFont, drawBrush, captionX, y, new StringFormat());
            y += spacing;
            e.Graphics.DrawString("Fax (678) 563-0093", printFont, drawBrush, captionX, y, new StringFormat());
            y += spacing;
            e.Graphics.DrawString("Watts 1-800-520-6593", printFont, drawBrush, captionX, y, new StringFormat());

            e.Graphics.DrawString("ORDERED", printFont, drawBrush, col1X, col1Y, new StringFormat());
            e.Graphics.DrawString("TALLY", printFont, drawBrush, col2X, col2Y, new StringFormat());
            e.Graphics.DrawString("DESCRIPTION", printFont, drawBrush, col3X, col3Y, new StringFormat());
            e.Graphics.DrawString("PRICE", printFont, drawBrush, col4X, col4Y, new StringFormat());
            e.Graphics.DrawString("AMOUNT", printFont, drawBrush, col5X, col5Y, new StringFormat());

            e.Graphics.DrawString("DATE ORDERED", printFont, drawBrush, dateX, dateY, new StringFormat());
            e.Graphics.DrawString("YOUR ORDER NO.", printFont, drawBrush, ordernoX, ordernoY, new StringFormat());
            e.Graphics.DrawString("SOLD TO:", printFont, drawBrush, soldtoX, soldtoY, new StringFormat());
            e.Graphics.DrawString("SHIP TO:", printFont, drawBrush, shiptoX, shiptoY, new StringFormat());
            e.Graphics.DrawString("TERMS: " + ar1[15], printFont, drawBrush, termsX, termsY, new StringFormat());
            e.Graphics.DrawString("DATE SHIPPED:", printFont, drawBrush, shippedX, shippedY, new StringFormat());
            e.Graphics.DrawString("SHIPPED VIA:", printFont, drawBrush, viaX, viaY, new StringFormat());

            startPt = new Point(10, col1Y - 5);
            endPt = new Point(840, col1Y - 5);
            e.Graphics.DrawLine(drawPen, startPt, endPt);
        }

        /// <summary>
        /// numCopies - 2
        /// </summary>
        /// 
        public static void Print_Quote(string quoteID, string printerName, short numCopies)
        {
            quoteNum = quoteID;
            Print_Quote_Customer_Copy(printerName, numCopies);
            Print_Quote_Royal_Copy(printerName, numCopies);
        }

        public static void Print_Quote_Customer_Copy(string printerName, short numCopies)
        {
            int x, y;
            string printResults;

            FileStream fp;
            ASCIIEncoding enc = new System.Text.ASCIIEncoding();
            PrintDocument printDocument1 = new PrintDocument();

            try
            {

                printResults = util_functions.Get_Web_Page("/admin/vb_Print_Quote4.cfm", "f_id=" + quoteNum.Trim());

                x = printResults.IndexOf("<>");
                if (x >= 0 && printResults.Length > x + 2)
                {
                    Form1.cfid = printResults.Substring(0, x);
                    y = Form1.cfid.IndexOf(":");
                    if (y >= 0)
                    {
                        Form1.cftoken = Form1.cfid.Substring(y + 1, Form1.cfid.Length - y - 1);
                        Form1.cfid = Form1.cfid.Substring(0, y);
                    }
                    printResults = printResults.Substring(x + 4, printResults.Length - x - 4);
                }
                else
                {
                    MessageBox.Show("Error: The quote was not found.");
                    return;
                }

                globalX = 0;
                globalY = 0;

                ar1 = printResults.Split(new string[] { "\r\n" }, StringSplitOptions.None);

                try
                {
                    fp = File.Open(Application.StartupPath + "\\printQuote.txt", FileMode.Open, FileAccess.Read);
                    buffer = new byte[fp.Length];

                    fp.Read(buffer, 0, buffer.Length);
                    str1 = enc.GetString(buffer, 0, buffer.Length);
                    str2 = str1.Split(new string[] { "\r\n" }, StringSplitOptions.None);

                    fp.Close();
                }
                catch
                {
                    MessageBox.Show("Error trying to read file " + Application.StartupPath + "\\printQuote.txt. This file is required for printing.");
                    return;
                }
                for (x = 0; x < str2.Length; x++)
                {
                    str3 = str2[x].Split(new char[] { ',' });
                    if (str3.Length == 3)
                    {
                        if (String.Compare(str3[0].Trim(), "i", true) == 0)
                        {
                            itemsX = Convert.ToInt32(str3[1]) + globalX;
                            itemsY = Convert.ToInt32(str3[2]) + globalY;
                        }
                        else if (String.Compare(str3[0].Trim(), "s", true) == 0)
                        {
                            spacing = Convert.ToInt32(str3[2]);
                        }
                        else if (String.Compare(str3[0].Trim(), "qty", true) == 0)
                        {
                            qtyX = Convert.ToInt32(str3[1]) + globalX;
                        }
                        else if (String.Compare(str3[0].Trim(), "desc", true) == 0)
                        {
                            descX = Convert.ToInt32(str3[1]) + globalX;
                        }
                        else if (String.Compare(str3[0].Trim(), "price", true) == 0)
                        {
                            priceX = Convert.ToInt32(str3[1]) + globalX;
                        }
                        else if (String.Compare(str3[0].Trim(), "amt", true) == 0)
                        {
                            amtX = Convert.ToInt32(str3[1]) + globalX;
                        }
                        else if (String.Compare(str3[0].Trim(), "p", true) == 0)
                        {
                            itemsPerPage = Convert.ToInt32(str3[1]);
                        }
                        else if (String.Compare(str3[0].Trim(), "g", true) == 0)
                        {
                            globalX = Convert.ToInt32(str3[1]);
                            globalY = Convert.ToInt32(str3[2]);
                        }
                        else if (String.Compare(str3[0].Trim(), "pgnum", true) == 0)
                        {
                            pgNumX = Convert.ToInt32(str3[1]) + globalX;
                            pgNumY = Convert.ToInt32(str3[2]) + globalY;
                        }
                        else if (String.Compare(str3[0].Trim(), "header", true) == 0)
                        {
                            headerX = Convert.ToInt32(str3[1]) + globalX;
                            headerY = Convert.ToInt32(str3[2]) + globalY;
                        }
                        else if (String.Compare(str3[0].Trim(), "sku", true) == 0)
                        {
                            skuX = Convert.ToInt32(str3[1]) + globalX;
                        }
                        else if (String.Compare(str3[0].Trim(), "total", true) == 0)
                        {
                            quoteTotalX = Convert.ToInt32(str3[1]) + globalX;
                        }
                        else if (String.Compare(str3[0].Trim(), "orderid", true) == 0)
                        {
                            ordernoX = Convert.ToInt32(str3[1]) + globalX;
                            ordernoY = Convert.ToInt32(str3[2]) + globalY;
                        }
                    }
                }

                curPrinterName = printerName;
                curItemToPrint = 7;
                itemsPrinted = 0;
                curPage = 0;
                printNumber = quoteNum;
                cubes = 0;

                printDocument1.PrintPage += new PrintPageEventHandler(Print_Quote_Page_Customer_Copy);
                printDocument1.PrinterSettings.Copies = numCopies;
                printDocument1.PrinterSettings.PrinterName = printerName;
                printDocument1.Print();
            }
            catch (Exception e1)
            {
                MessageBox.Show("An error occured while printing quote " + str3[0] + "\n\n" + quoteNum + "\n\n" + e1.Message);
            }
        }

        public static void Print_Quote_Page_Customer_Copy(object sender, PrintPageEventArgs e)
        {
            int a, x, y = 0, z = 0;
            string quoteNotes = "";
            SqlDataReader rdr;
            SqlCommand cmd;
            SqlConnection conn;

            Font printFont = new Font(Form1.fName, Convert.ToSingle(Form1.fSize));
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            conn = new SqlConnection("Data Source=Romeo;Initial Catalog=Royal;User ID=royal;password=wkjwuq");
            conn.Open();
            cmd = new SqlCommand("select quotes.notes from Quotes where ct = " + quoteNum.Trim(), conn);
            rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                rdr.Read();
                quoteNotes = rdr["notes"].ToString();
            }
            if (rdr != null)
                rdr.Close();
            if (conn != null)
                conn.Close();


            try
            {
                curPage = curPage + 1;

                printQuoteHeaderCustomerCopy(e, printFont, drawBrush);

                for (x = 0; x < str2.Length; x++)
                {
                    str3 = str2[x].Split(new char[] { ',' });
                    if (str3.Length == 3)
                    {
                        if (util_functions.isnumeric(str3[0]) && util_functions.isnumeric(str3[1]) && util_functions.isnumeric(str3[2]))
                            e.Graphics.DrawString(ar1[Convert.ToInt32(str3[0]) - 1], printFont, drawBrush, Convert.ToInt32(str3[1]) + globalX, Convert.ToInt32(str3[2]) + globalY, new StringFormat());
                    }
                }

                z = itemsY + spacing;
                y = 1;

                a = ar1.Length - 1;     // The string split funtion returns an empty string at the end so down count the amount of items by one
                for (x = curItemToPrint; x < a; x += 9)
                {
                    curItemToPrint += 9;

                    e.Graphics.DrawString(ar1[x], printFont, drawBrush, qtyX, z, new StringFormat());
                    e.Graphics.DrawString(ar1[x + 1], printFont, drawBrush, skuX, z, new StringFormat());
                    e.Graphics.DrawString(ar1[x + 2], printFont, drawBrush, descX, z, new StringFormat());
                    e.Graphics.DrawString(ar1[x + 3], printFont, drawBrush, priceX, z, new StringFormat());
                    e.Graphics.DrawString(ar1[x + 4], printFont, drawBrush, amtX, z, new StringFormat());

                    curQty = Convert.ToInt32(ar1[x]);
                    if (util_functions.isnumeric(ar1[x + 5]))
                    {
                        curBox = Convert.ToInt32(ar1[x + 5]);
                        palletsPerBox = Convert.ToInt32(ar1[x + 8]);
                    }
                    else
                    {
                        curBox = 0;
                        palletsPerBox = 0;
                    }
                    if (curBox > 0)
                        cubes = cubes + ((curQty / curBox) * Convert.ToSingle(ar1[x + 7]));

                    if (curBox > 0 && (int)(curQty / curBox) == (float)curQty / (float)curBox && palletsPerBox > 0 && (curQty / curBox) >= palletsPerBox)
                    {
                        curPallets = (int)((curQty / curBox) / palletsPerBox);
                        cubes = cubes + (curPallets * Convert.ToSingle(ar1[x + 6]));
                    }





                    z += spacing;
                    itemsPrinted++;

                    y++;
                    if (y > itemsPerPage)
                    {
                        e.HasMorePages = true;
                        return;
                    }

                }

                a = itemsPerPage - y;
                if (a > 2)
                    a = 2;
                z += a * spacing;
                e.Graphics.DrawString("Quote total:", printFont, drawBrush, quoteTotalX, z, new StringFormat());
                e.Graphics.DrawString(ar1[3], printFont, drawBrush, amtX, z, new StringFormat());
                e.Graphics.DrawString("Count: " + itemsPrinted.ToString(), printFont, drawBrush, qtyX, z, new StringFormat());
                z += spacing;
                e.Graphics.DrawString("Cubes: " + ar1[5] + "   Freight Charges: " + ar1[6], printFont, drawBrush, quoteTotalX, z, new StringFormat());
                z += spacing;
                e.Graphics.DrawString("Notes: " + quoteNotes, printFont, drawBrush, quoteTotalX, z, new StringFormat());

                e.HasMorePages = false;
            }
            catch (Exception e1)
            {
                MessageBox.Show("Error printing order.\n\n" + e1.Message);
                e.HasMorePages = false;
            }
        }

        static public void printQuoteHeaderCustomerCopy(PrintPageEventArgs e, Font printFont, SolidBrush drawBrush)
        {
            int y;

            Pen drawPen = new Pen(drawBrush);
            StringFormat stringF = new StringFormat();

            stringF.Alignment = StringAlignment.Center;

            e.Graphics.DrawString(curPage.ToString(), printFont, drawBrush, pgNumX, pgNumY, new StringFormat());
            e.Graphics.DrawString("Quote Number: " + printNumber, printFont, drawBrush, ordernoX, ordernoY, new StringFormat());

            y = headerY;
            e.Graphics.DrawString("Royal Metal Products", printFont, drawBrush, headerX, y, stringF);
            y += spacing;
            e.Graphics.DrawString("100 Royal Way", printFont, drawBrush, headerX, y, stringF);
            y += spacing;
            e.Graphics.DrawString("Temple, GA 30179", printFont, drawBrush, headerX, y, stringF);
            y += spacing;
            e.Graphics.DrawString("Ph: 800-520-6593", printFont, drawBrush, headerX, y, stringF);
            y += spacing;
            e.Graphics.DrawString("Fax: 678-563-0093", printFont, drawBrush, headerX, y, stringF);

            e.Graphics.DrawString("Qty", printFont, drawBrush, qtyX, itemsY, new StringFormat());
            e.Graphics.DrawString("Sku", printFont, drawBrush, skuX, itemsY, new StringFormat());
            e.Graphics.DrawString("Description", printFont, drawBrush, descX, itemsY, new StringFormat());
            e.Graphics.DrawString("Price", printFont, drawBrush, priceX, itemsY, new StringFormat());
            e.Graphics.DrawString("Ext Total", printFont, drawBrush, amtX, itemsY, new StringFormat());
        }

        public static void Print_Quote_Royal_Copy(string printerName, short numCopies)
        {
            int x, y;

            FileStream fp;
            ASCIIEncoding enc = new System.Text.ASCIIEncoding();
            PrintDocument printDocument1 = new PrintDocument();


            try
            {
                globalX = 0;
                globalY = 0;

                try
                {
                    fp = File.Open(Application.StartupPath + "\\printQuoteSummary.txt", FileMode.Open, FileAccess.Read);
                    buffer = new byte[fp.Length];

                    fp.Read(buffer, 0, buffer.Length);
                    str1 = enc.GetString(buffer, 0, buffer.Length);
                    str2 = str1.Split(new string[] { "\r\n" }, StringSplitOptions.None);

                    fp.Close();
                }
                catch
                {
                    MessageBox.Show("Error trying to read file " + Application.StartupPath + "\\printQuoteSummary.txt. This file is required for printing.");
                    return;
                }
                for (x = 0; x < str2.Length; x++)
                {
                    str3 = str2[x].Split(new char[] { ',' });
                    if (str3.Length == 3)
                    {
                        if (String.Compare(str3[0].Trim(), "i", true) == 0)
                        {
                            itemsX = Convert.ToInt32(str3[1]) + globalX;
                            itemsY = Convert.ToInt32(str3[2]) + globalY;
                        }
                        else if (String.Compare(str3[0].Trim(), "s", true) == 0)
                        {
                            spacing = Convert.ToInt32(str3[2]);
                        }
                        else if (String.Compare(str3[0].Trim(), "qty", true) == 0)
                        {
                            qtyX = Convert.ToInt32(str3[1]) + globalX;
                        }
                        else if (String.Compare(str3[0].Trim(), "desc", true) == 0)
                        {
                            descX = Convert.ToInt32(str3[1]) + globalX;
                        }
                        else if (String.Compare(str3[0].Trim(), "origPrice", true) == 0)
                        {
                            priceX = Convert.ToInt32(str3[1]) + globalX;
                        }
                        else if (String.Compare(str3[0].Trim(), "extPrice", true) == 0)
                        {
                            amtX = Convert.ToInt32(str3[1]) + globalX;
                        }
                        else if (String.Compare(str3[0].Trim(), "p", true) == 0)
                        {
                            itemsPerPage = Convert.ToInt32(str3[1]);
                        }
                        else if (String.Compare(str3[0].Trim(), "g", true) == 0)
                        {
                            globalX = Convert.ToInt32(str3[1]);
                            globalY = Convert.ToInt32(str3[2]);
                        }
                        else if (String.Compare(str3[0].Trim(), "sku", true) == 0)
                        {
                            skuX = Convert.ToInt32(str3[1]) + globalX;
                        }
                        else if (String.Compare(str3[0].Trim(), "total", true) == 0)
                        {
                            quoteTotalX = Convert.ToInt32(str3[1]) + globalX;
                        }
                        else if (String.Compare(str3[0].Trim(), "orderid", true) == 0)
                        {
                            ordernoX = Convert.ToInt32(str3[1]) + globalX;
                            ordernoY = Convert.ToInt32(str3[2]) + globalY;
                        }
                        else if (String.Compare(str3[0].Trim(), "origPrice", true) == 0)
                        {
                            priceX = Convert.ToInt32(str3[1]) + globalX;
                        }
                        else if (String.Compare(str3[0].Trim(), "extPrice", true) == 0)
                        {
                            amtX = Convert.ToInt32(str3[1]) + globalX;
                        }
                        else if (String.Compare(str3[0].Trim(), "totalDiscount", true) == 0)
                        {
                            discountX = Convert.ToInt32(str3[1]) + globalX;
                            discountY = Convert.ToInt32(str3[2]) + globalY;
                        }
                        else if (String.Compare(str3[0].Trim(), "totalDirectCost", true) == 0)
                        {
                            directCostX = Convert.ToInt32(str3[1]) + globalX;
                            directCostY = Convert.ToInt32(str3[2]) + globalY;
                        }
                        else if (String.Compare(str3[0].Trim(), "cNum", true) == 0)
                        {
                            customerX = Convert.ToInt32(str3[1]) + globalX;
                            customerY = Convert.ToInt32(str3[2]) + globalY;
                        }
                        else if (String.Compare(str3[0].Trim(), "quoteName", true) == 0)
                        {
                            quoteNameX = Convert.ToInt32(str3[1]) + globalX;
                            quoteNameY = Convert.ToInt32(str3[2]) + globalY;
                        }
                        else if (String.Compare(str3[0].Trim(), "newPrice", true) == 0)
                        {
                            newPriceX = Convert.ToInt32(str3[1]) + globalX;
                        }
                        else if (String.Compare(str3[0].Trim(), "extNewPrice", true) == 0)
                        {
                            newPriceExtX = Convert.ToInt32(str3[1]) + globalX;
                        }
                        else if (String.Compare(str3[0].Trim(), "dc", true) == 0)
                        {
                            dcX = Convert.ToInt32(str3[1]) + globalX;
                        }
                        else if (String.Compare(str3[0].Trim(), "extDC", true) == 0)
                        {
                            dcExtX = Convert.ToInt32(str3[1]) + globalX;
                        }
                        else if (String.Compare(str3[0].Trim(), "dcPercent", true) == 0)
                        {
                            dcPercX = Convert.ToInt32(str3[1]) + globalX;
                        }
                        else if (String.Compare(str3[0].Trim(), "customer", true) == 0)
                        {
                            customerNameX = Convert.ToInt32(str3[1]) + globalX;
                            customerNameY = Convert.ToInt32(str3[2]) + globalX;
                        }
                        else if (String.Compare(str3[0].Trim(), "job", true) == 0)
                        {
                            jobX = Convert.ToInt32(str3[1]) + globalX;
                            jobY = Convert.ToInt32(str3[2]) + globalX;
                        }
                        else if (String.Compare(str3[0].Trim(), "date", true) == 0)
                        {
                            dateX = Convert.ToInt32(str3[1]) + globalX;
                            dateY = Convert.ToInt32(str3[2]) + globalX;
                        }
                    }
                }

                curPrinterName = printerName;
                curItemToPrint = 0;
                itemsPrinted = 0;
                curPage = 0;
                printNumber = quoteNum;

                priceTotal = 0;
                newpricetotal = 0;
                costtotal = 0;
                dcExtTotal = 0;

                printDocument1.PrintPage += new PrintPageEventHandler(Print_Quote_Page_Royal_Copy);
                printDocument1.PrinterSettings.Copies = numCopies;
                printDocument1.PrinterSettings.PrinterName = printerName;
                printDocument1.DefaultPageSettings.Landscape = true;
                printDocument1.Print();
            }
            catch (Exception e1)
            {
                MessageBox.Show("An error occured while printing quote " + str3[0] + "\n\n" + quoteNum + "\n\n" + e1.Message);
            }
        }

        public static void Print_Quote_Page_Royal_Copy(object sender, PrintPageEventArgs e)
        {
            int a = 0, x, y = 0, z = 0;
            float f1, f2, f3, f4, f5, cubes=0.0f;
            string freight = "";

            Font printFont = new Font(Form1.fName, Convert.ToSingle(Form1.fSize) * 0.75f);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            SqlConnection conn = new SqlConnection("Data Source=Romeo;Initial Catalog=Royal;User ID=royal;password=wkjwuq");
            SqlDataReader rdr = null;

            try
            {
                curPage = curPage + 1;

                if (!printQuoteHeaderRoyalCopy(e, printFont, drawBrush))
                    return;
                //e.HasMorePages = false;
                //return;

                conn.Open();
                SqlCommand cmd = new SqlCommand("select quotes.totalCubes, quotes.freight, units.cost as ucost, QuoteSkus.* from ( QuoteSkus left outer join Units on QuoteSkus.unitID = Units.ct ) left outer join Quotes on QuoteSkus.quoteID = Quotes.ct where QuoteSkus.active = 1 and QuoteSkus.quoteID = " + quoteNum.Trim() + " order by QuoteSkus.ct asc", conn);
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    z = itemsY + spacing;
                    y = 1;
                    a = 1;

                    while (rdr.Read())
                    {
                        cubes = roundNumber(Convert.ToSingle(rdr["totalCubes"].ToString()), 2);
                        freight = rdr["freight"].ToString();

                        if (a > curItemToPrint)
                        {
                            if (y > itemsPerPage)
                            {
                                e.HasMorePages = true;

                                if (rdr != null)
                                    rdr.Close();

                                if (conn != null)
                                    conn.Close();
                                return;
                            }

                            if (util_functions.isnumeric(rdr["cost"].ToString()))
                                cost = Convert.ToSingle(rdr["cost"].ToString());
                            else if (util_functions.isnumeric(rdr["ucost"].ToString()))
                                cost = Convert.ToSingle(rdr["ucost"].ToString());
                            else
                                cost = 0;

                            f1 = roundNumber(Convert.ToSingle(rdr["qty"].ToString()) * Convert.ToSingle(rdr["price"].ToString()), 2);
                            f2 = roundNumber(Convert.ToSingle(rdr["price"].ToString()) * Convert.ToSingle(rdr["multiplier"].ToString()), 2);
                            f3 = roundNumber(Convert.ToSingle(rdr["qty"].ToString()) * f2, 2);
                            f4 = roundNumber(cost * Convert.ToSingle(rdr["qty"].ToString()), 2);
                            if (f2 != 0)
                                f5 = roundNumber(cost / f2, 2);
                            else
                                f5 = 0.0f;

                            dcExtTotal += f4;
                            priceTotal += f1;
                            newpricetotal += f3;
                            costtotal += cost;

                            e.Graphics.DrawString(rdr["qty"].ToString(), printFont, drawBrush, qtyX, z, new StringFormat());
                            e.Graphics.DrawString(rdr["sku"].ToString(), printFont, drawBrush, skuX, z, new StringFormat());
                            e.Graphics.DrawString(rdr["descrip"].ToString(), printFont, drawBrush, descX, z, new StringFormat());
                            e.Graphics.DrawString(String.Format("{0:0,0.00}", rdr["price"].ToString()), printFont, drawBrush, priceX, z, new StringFormat());
                            e.Graphics.DrawString(String.Format("{0:0,0.00}", f1.ToString()), printFont, drawBrush, amtX, z, new StringFormat());
                            e.Graphics.DrawString(String.Format("{0:0,0.00}", f2.ToString()), printFont, drawBrush, newPriceX, z, new StringFormat());
                            e.Graphics.DrawString(String.Format("{0:0,0.00}", f3.ToString()), printFont, drawBrush, newPriceExtX, z, new StringFormat());
                            e.Graphics.DrawString(cost.ToString(), printFont, drawBrush, dcX, z, new StringFormat());
                            e.Graphics.DrawString(f4.ToString(), printFont, drawBrush, dcExtX, z, new StringFormat());
                            e.Graphics.DrawString(f5.ToString(), printFont, drawBrush, dcPercX, z, new StringFormat());

                            curItemToPrint++;
                            y++;
                            z += spacing;
                        }

                        a++;
                    }

                    if (y + 1 > itemsPerPage)
                    {
                        e.HasMorePages = true;

                        if (rdr != null)
                            rdr.Close();

                        if (conn != null)
                            conn.Close();
                        return;
                    }


                    e.Graphics.DrawString(String.Format("{0:0,0.00}", priceTotal.ToString()), printFont, drawBrush, amtX, z, new StringFormat());
                    e.Graphics.DrawString(String.Format("{0:0,0.00}", newpricetotal.ToString()), printFont, drawBrush, newPriceExtX, z, new StringFormat());
                    e.Graphics.DrawString(String.Format("{0:0,0.000}", util_functions.roundNumber(costtotal, 3)).ToString(), printFont, drawBrush, dcX, z, new StringFormat());

                    z += 2 * spacing;

                    e.Graphics.DrawString("Quote Total: " + String.Format("{0:0,0.00}", newpricetotal.ToString()), printFont, drawBrush, quoteTotalX, z, new StringFormat());

                    if (priceTotal != 0.0f)
                        f4 = util_functions.roundNumber(newpricetotal / priceTotal, 2);
                    else
                        f4 = 0.0f;

                    e.Graphics.DrawString("Total Discount: " + String.Format("{0:0,0.00}", f4.ToString()), printFont, drawBrush, directCostX, z, new StringFormat());
                    e.Graphics.DrawString("Total Direct Cost: " + String.Format("{0:0,0.000}", util_functions.roundNumber(dcExtTotal / newpricetotal, 3)), printFont, drawBrush, discountX, z, new StringFormat());

                    z += spacing;
                    e.Graphics.DrawString("Cubes: " + cubes.ToString(), printFont, drawBrush, directCostX, z, new StringFormat());
                    e.Graphics.DrawString("Freight Charges: " + freight, printFont, drawBrush, discountX, z, new StringFormat());

                    e.HasMorePages = false;
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show("Error printing quote.\n\n" + e1.Message);
                e.HasMorePages = false;
            }

            if (rdr != null)
                rdr.Close();

            if (conn != null)
                conn.Close();
        }

        static public bool printQuoteHeaderRoyalCopy(PrintPageEventArgs e, Font printFont, SolidBrush drawBrush)
        {
            bool returnVal = true;
            int y;

            SqlConnection conn = new SqlConnection("Data Source=Romeo;Initial Catalog=Royal;User ID=royal;password=wkjwuq");
            SqlDataReader rdr = null;

            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from quotes where ct=" + quoteNum.Trim(), conn);
            rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                Pen drawPen = new Pen(drawBrush);
                StringFormat stringF = new StringFormat();

                stringF.Alignment = StringAlignment.Center;

                e.Graphics.DrawString(curPage.ToString(), printFont, drawBrush, pgNumX, pgNumY, new StringFormat());
                e.Graphics.DrawString("Quote Number: " + printNumber, printFont, drawBrush, ordernoX, ordernoY, new StringFormat());

                if (rdr.Read())
                {
                    y = customerY;
                    e.Graphics.DrawString(rdr["customerNum"].ToString(), printFont, drawBrush, customerX, y, stringF);
                    y += spacing;
                    e.Graphics.DrawString(rdr["Name"].ToString(), printFont, drawBrush, customerX, y, stringF);
                    y += spacing;
                    e.Graphics.DrawString(rdr["addr1"].ToString(), printFont, drawBrush, customerX, y, stringF);
                    y += spacing;
                    e.Graphics.DrawString(rdr["addr2"].ToString(), printFont, drawBrush, customerX, y, stringF);
                    y += spacing;
                    e.Graphics.DrawString(rdr["city"].ToString() + ", " + rdr["State"].ToString() + " " + rdr["zip"].ToString(), printFont, drawBrush, customerX, y, stringF);

                    y = customerY;
                    e.Graphics.DrawString(rdr["QuoteName"].ToString(), printFont, drawBrush, quoteNameX, y, stringF);
                    y += spacing;
                    e.Graphics.DrawString(rdr["contact"].ToString(), printFont, drawBrush, quoteNameX, y, stringF);
                    y += spacing;
                    e.Graphics.DrawString(rdr["mult"].ToString(), printFont, drawBrush, quoteNameX, y, stringF);
                }

                e.Graphics.DrawString(ar1[0], printFont, drawBrush, customerNameX, customerNameY, new StringFormat());
                e.Graphics.DrawString(ar1[1], printFont, drawBrush, jobX, jobY, new StringFormat());
                e.Graphics.DrawString(ar1[4], printFont, drawBrush, dateX, dateY, new StringFormat());

                e.Graphics.DrawString("Qty", printFont, drawBrush, qtyX, itemsY, new StringFormat());
                e.Graphics.DrawString("Sku", printFont, drawBrush, skuX, itemsY, new StringFormat());
                e.Graphics.DrawString("Description", printFont, drawBrush, descX, itemsY, new StringFormat());
                e.Graphics.DrawString("Original Price", printFont, drawBrush, priceX, itemsY, new StringFormat());
                e.Graphics.DrawString("Original Ext Total", printFont, drawBrush, amtX, itemsY, new StringFormat());
                e.Graphics.DrawString("Proposed Price", printFont, drawBrush, newPriceX, itemsY, new StringFormat());
                e.Graphics.DrawString("Proposed Ext Total", printFont, drawBrush, newPriceExtX, itemsY, new StringFormat());
                e.Graphics.DrawString("Actual DC", printFont, drawBrush, dcX, itemsY, new StringFormat());
                e.Graphics.DrawString("DC Ext Total", printFont, drawBrush, dcExtX, itemsY, new StringFormat());
                e.Graphics.DrawString("DC %", printFont, drawBrush, dcPercX, itemsY, new StringFormat());

            }
            else
            {
                returnVal = false;
                e.HasMorePages = false;
                MessageBox.Show("Error: The quote was not found.");
            }

            if (rdr != null)
                rdr.Close();

            if (conn != null)
                conn.Close();

            return returnVal;
        }

        public static void printErrText(string pText, string printerName)
        {
            int x, y;

            FileStream fp;
            ASCIIEncoding enc = new System.Text.ASCIIEncoding();
            PrintDocument printDocument1 = new PrintDocument();

            try
            {
                globalX = 0;
                globalY = 0;

                try
                {
                    fp = File.Open(Application.StartupPath + "\\print2.txt", FileMode.Open, FileAccess.Read);
                    buffer = new byte[fp.Length];

                    fp.Read(buffer, 0, buffer.Length);
                    str1 = enc.GetString(buffer, 0, buffer.Length);
                    str2 = str1.Split(new string[] { "\r\n" }, StringSplitOptions.None);

                    fp.Close();
                }
                catch
                {
                    MessageBox.Show("Error trying to read file " + Application.StartupPath + "\\print2.txt");
                    return;
                }

                for (x = 0; x < str2.Length; x++)
                {
                    str3 = str2[x].Split(new char[] { ',' });
                    if (str3.Length == 3)
                    {
                        if (String.Compare(str3[0].Trim(), "i", true) == 0)
                        {
                            itemsX = Convert.ToInt32(str3[1]) + globalX;
                            itemsY = Convert.ToInt32(str3[2]) + globalY;
                        }
                        else if (String.Compare(str3[0].Trim(), "s", true) == 0)
                        {
                            spacing = Convert.ToInt32(str3[2]);
                        }
                        else if (String.Compare(str3[0].Trim(), "qty", true) == 0)
                        {
                            qtyX = Convert.ToInt32(str3[1]) + globalX;
                        }
                        else if (String.Compare(str3[0].Trim(), "sku", true) == 0)
                        {
                            tallyX = Convert.ToInt32(str3[1]) + globalX;
                        }
                        else if (String.Compare(str3[0].Trim(), "desc", true) == 0)
                        {
                            descX = Convert.ToInt32(str3[1]) + globalX;
                        }
                        else if (String.Compare(str3[0].Trim(), "rprice", true) == 0)
                        {
                            priceX = Convert.ToInt32(str3[1]) + globalX;
                        }
                        else if (String.Compare(str3[0].Trim(), "price", true) == 0)
                        {
                            amtX = Convert.ToInt32(str3[1]) + globalX;
                        }
                        else if (String.Compare(str3[0].Trim(), "err", true) == 0)
                        {
                            errX = Convert.ToInt32(str3[1]);
                        }
                        else if (String.Compare(str3[0].Trim(), "p", true) == 0)
                        {
                            itemsPerPage = Convert.ToInt32(str3[1]);
                        }
                        else if (String.Compare(str3[0].Trim(), "g", true) == 0)
                        {
                            globalX = Convert.ToInt32(str3[1]);
                            globalY = Convert.ToInt32(str3[2]);
                        }
                    }
                }
                
                str2 = pText.Split(new string[] { "\r\n" }, StringSplitOptions.None);
                curItemToPrint = 0;
                printDocument1.PrintPage += new PrintPageEventHandler(Print_ErrText_Page);
                printDocument1.PrinterSettings.Copies = 1;
                printDocument1.PrinterSettings.PrinterName = printerName;
                printDocument1.Print();
            }
            catch (Exception e1)
            {
                MessageBox.Show("An error occured while printing error notes.\n\n" + e1.Message);
            }
        }

        public static void Print_ErrText_Page(object sender, PrintPageEventArgs e)
        {
            int a, x, y = 0, z = 0;
            string[] lineStr;

            Font printFont = new Font(Form1.fName2, Convert.ToSingle(Form1.fSize2));
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            try
            {
                z = itemsY;
                y = 1;

                a = str2.Length;

                for (x = curItemToPrint; x < a; x++)
                {
                    curItemToPrint++;

                    lineStr = str2[x].Split(new string[] { "\t" }, StringSplitOptions.None);
                    if (lineStr.Length > 5)
                    {
                        e.Graphics.DrawString(lineStr[0], printFont, drawBrush, qtyX, z, new StringFormat());
                        e.Graphics.DrawString(lineStr[1], printFont, drawBrush, tallyX, z, new StringFormat());
                        e.Graphics.DrawString(lineStr[2], printFont, drawBrush, descX, z, new StringFormat());
                        e.Graphics.DrawString(lineStr[3], printFont, drawBrush, priceX, z, new StringFormat());
                        e.Graphics.DrawString(lineStr[4], printFont, drawBrush, amtX, z, new StringFormat());
                        e.Graphics.DrawString(lineStr[5], printFont, drawBrush, errX, z, new StringFormat());
                    }
                    else
                        e.Graphics.DrawString(str2[x], printFont, drawBrush, qtyX, z, new StringFormat());

                    y++;
                    if (y > itemsPerPage)
                    {
                        e.HasMorePages = true;
                        return;
                    }

                    z += spacing;

                }

                e.HasMorePages = false;
            }
            catch (Exception e1)
            {
                MessageBox.Show("Error printing error notes.\n\n" + e1.Message);
                e.HasMorePages = false;
            }
        }

        public static void Set_Registry_Key(string keyName, string keyValue, string extraPathInfo)
        {
            RegistryKey key;

            key = Registry.CurrentUser.CreateSubKey("Software\\Laserfiche\\Snapshot8\\Profile\\CurrentUser" + extraPathInfo);
            key.SetValue(keyName, keyValue);
            key.Close();
        }

        /// <summary>
        /// decimalPlaces - 2
        /// </summary>
        public static float roundNumber(float inNum, int decimalPlaces)
        {
            float f1, numSign, mult;

            if (inNum >= 0)
                numSign = 1;
            else
                numSign = -1;

            inNum = inNum * numSign;

            mult = (float)Math.Pow(10, decimalPlaces);
            inNum *= mult;

            f1 = (float)Math.Truncate((inNum - (float)Math.Truncate(inNum)) * 10);

            if (f1 >= 5)
                f1 = (float)Math.Truncate(inNum) + 1;
            else
                f1 = (float)Math.Truncate(inNum);

            f1 /= mult;

            return f1 * numSign;
        }

        
    }

}