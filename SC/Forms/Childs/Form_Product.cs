using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SCLibrary;
using SCLibrary.Sql;
using SCLibrary.Request;
using System.IO;
using System.Net;
using System.Collections.Specialized;

namespace SC
{
    public partial class Form_Product : Form
    {
        public Form_Product()
        {
            InitializeComponent();
            
        }
        DBMySQL db;
        RequestImage r_image;
        private string path_image = "";
        private string path_image_color = "";
        private void btn_nav_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool get_connection()
        {
            db = new DBMySQL();
            db.dbName = "dbptsinar";
            db.server = "192.168.100.18";
            db.password = "134340";
            db.username = "dani_7";
            
            return true;
        }
        //Rows[baris][kolom]
        List<string> list_colors_img = new List<string>();
        List<string> list_part = new List<string>();
        string design_id = "";
        string keyName = "";
        private void ProductForm_Load(object sender, EventArgs e)
        {
            keyName = this.Text;
            DataSet ds_image_desain = new DataSet();
            DBSql.DoGetData("select url_design_img from tbl_barangs where description='" + keyName.Split('$')[0] + "' and contract='"+ keyName.Split('$')[1] + "' and grade='A'", ds_image_desain);
            if (ds_image_desain.Tables[0].Rows.Count>0)
            {
                if (!String.IsNullOrEmpty(ds_image_desain.Tables[0].Rows[0][0].ToString()))
                {
                    if (ds_image_desain.Tables[0].Rows[0][0].ToString() != "-")
                    {
                        string url = "http://ultimindserver.mywire.org:3000/img_file/designs/" + ds_image_desain.Tables[0].Rows[0][0].ToString();
                        r_image = new RequestImage();
                        r_image.loadFromUrlAsync(url, delegate (Image img)
                        {
                            if (img != null)
                            {
                                pic_product.Image = img;
                            }
                            else
                            {
                                pic_product.Image = Properties.Resources.img_error;
                            }

                        });
                    }

                    DataSet ds = DBSql.DoGetData("select design_id from tbl_barangs where description='" + keyName.Split('$')[0] + "' and contract='" + keyName.Split('$')[1] + "' and grade='A'");
                    design_id = ds.Tables[0].Rows[0][0].ToString();

                    DataSet ds_colors = DBSql.DoGetData("select color_desc, url_color_img, part_no, design_id from tbl_barangs where description='" + keyName.Split('$')[0] + "' and contract='" + keyName.Split('$')[1] + "' and grade='A'");
                    for (int i = 0; i < ds_colors.Tables[0].Rows.Count; i++)
                    {
                        list_colors.Items.Add(ds_colors.Tables[0].Rows[i][0].ToString());
                        list_colors_img.Add(ds_colors.Tables[0].Rows[i][1].ToString());
                        list_part.Add(ds_colors.Tables[0].Rows[i][2].ToString());

                    }

                }
                else
                {
                    pic_product.Image = Properties.Resources.img_error;
                }
            }else
            {
                MessageBox.Show("Data Tidak ditemukan");
                return;
            }
            

        }

        private void btn_upload_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(path_image))
            {
                //NavFrame.SelectedPageIndex = 2;
                //MessageBox.Show("Data tidak dimasukan");
                this.Close();
                return;
            }
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("design_id", design_id);
            HttpUploadFile("http://ultimindserver.mywire.org:3000/data/upload/designs", path_image, "foto", "image/jpeg", nvc);
            path_image = "";
            MessageBox.Show("Data berhasil dimasukan");
            this.Close();
            
        }
        public static void HttpUploadFile(string url, string file, string paramName, string contentType, NameValueCollection nvc)
        {
            Console.WriteLine(string.Format("Uploading {0} to {1}", file, url));
            string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
            byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");

            HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(url);
            wr.ContentType = "multipart/form-data; boundary=" + boundary;
            wr.Method = "POST";
            wr.KeepAlive = true;
            wr.Credentials = System.Net.CredentialCache.DefaultCredentials;

            Stream rs = wr.GetRequestStream();

            string formdataTemplate = "Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}";
            foreach (string key in nvc.Keys)
            {
                rs.Write(boundarybytes, 0, boundarybytes.Length);
                string formitem = string.Format(formdataTemplate, key, nvc[key]);
                byte[] formitembytes = System.Text.Encoding.UTF8.GetBytes(formitem);
                rs.Write(formitembytes, 0, formitembytes.Length);
            }
            rs.Write(boundarybytes, 0, boundarybytes.Length);

            string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n";
            string header = string.Format(headerTemplate, paramName, file, contentType);
            byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);
            rs.Write(headerbytes, 0, headerbytes.Length);

            FileStream fileStream = new FileStream(file, FileMode.Open, FileAccess.Read);
            byte[] buffer = new byte[4096];
            int bytesRead = 0;
            while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
            {
                rs.Write(buffer, 0, bytesRead);
            }
            fileStream.Close();

            byte[] trailer = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
            rs.Write(trailer, 0, trailer.Length);
            rs.Close();

            WebResponse wresp = null;
            try
            {
                wresp = wr.GetResponse();
                Stream stream2 = wresp.GetResponseStream();
                StreamReader reader2 = new StreamReader(stream2);
                Console.WriteLine(string.Format("File uploaded, server response is: {0}", reader2.ReadToEnd()));

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error uploading file" + ex.Message);
                if (wresp != null)
                {
                    wresp.Close();
                    wresp = null;
                }
            }
            finally
            {
                wr = null;
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            
        }

        private void pic_colors_DoubleClick(object sender, EventArgs e)
        {
            //MessageBox.Show("Nanti pilih gambar");
            Dialog.ShowOpenFileDialog("Pilih Gambar", "Image Files|*.png;*.jpg;*.jpeg", delegate (bool ok, string path)
            {
                if (ok)
                {
                    var fileInfo = new FileInfo(path);
                    float fileSize = fileInfo.Length / 1024;
                    if (fileSize > 1024)
                    {
                        MessageBox.Show("File Terlalu Besar");
                        return;
                    }
                    path_image_color = path;
                    pic_colors.Image = Bitmap.FromFile(path);

                }
            });
        }

        private void list_colors_SelectedIndexChanged(object sender, EventArgs e)
        {
            //
        }

        private void list_colors_Click(object sender, EventArgs e)
        {
            lbl_part_no.Text = list_part[list_colors.SelectedIndex].ToString();
            txt_color_name.Text = list_colors.SelectedItem.ToString();
            if (list_colors_img[list_colors.SelectedIndex].ToString() == "-")
            {
                return;
            }
            string url = "http://ultimindserver.mywire.org:3000/img_file/colors/" + list_colors_img[list_colors.SelectedIndex].ToString();
            r_image = new RequestImage();
            r_image.loadFromUrlAsync(url, delegate (Image img)
            {
                if (img != null)
                {
                    pic_colors.Image = img;
                }
                else
                {
                    pic_colors.Image = Properties.Resources.img_error;
                }

            });
            //MessageBox.Show(list_colors_img[list_colors.SelectedIndex].ToString());
        }

        private void pic_product_DoubleClick(object sender, EventArgs e)
        {
            Dialog.ShowOpenFileDialog("Pilih Gambar", "Image Files|*.png;*.jpg;*.jpeg", delegate (bool ok, string path)
            {
                if (ok)
                {
                    var fileInfo = new FileInfo(path);
                    float fileSize = fileInfo.Length / 1024;
                    if (fileSize > 1024)
                    {
                        MessageBox.Show("File Terlalu Besar");
                        return;
                    }
                    path_image = path;
                    pic_product.Image = Bitmap.FromFile(path);

                }
            });
        }
    }
}
