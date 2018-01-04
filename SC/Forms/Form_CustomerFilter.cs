using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SCLibrary;

namespace SC
{
    public partial class Form_CustomerFilter : Form
    {
        public string filterSegment, filterRegion;
        public bool m_status_filter = false;
        public Form_CustomerFilter()
        {
            InitializeComponent();
            this.Load += Form_CustomerFilter_Load;
            this.FormClosing += Form_CustomerFilter_FormClosing;
        }

        private void Form_CustomerFilter_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!m_status_filter)
            {
                m_status_filter = false;
            }
        }

        private void Form_CustomerFilter_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        void LoadData()
        {
            DataTable dt_segment = DBSql.DoGetData("select distinct segment from tbl_customers").Tables[0];
            for (int i = 0; i < dt_segment.Rows.Count; i++)
            {
                Segment_ComboBox.Items.Add(dt_segment.Rows[i][0].ToString());
            }

            DataTable dt_region = DBSql.DoGetData("select distinct region_name from tbl_customers").Tables[0];
            for (int i = 0; i < dt_region.Rows.Count; i++)
            {
                Region_ComboBox.Items.Add(dt_region.Rows[i][0].ToString());
            }
        }

        private void Set_Button_Click(object sender, EventArgs e)
        {
            filterRegion = Region_ComboBox.Text;
            filterSegment = Segment_ComboBox.Text;
            m_status_filter = true;
            this.Close();
        }


    }
}
