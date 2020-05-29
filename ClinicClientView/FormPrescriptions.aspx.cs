﻿using ClinicBusinessLogic.Interfaces;
using ClinicBusinessLogic.ViewModels;
using ClinicImplementation.Implementations;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClinicClientView
{
    public partial class FormPrescriptions : System.Web.UI.Page
    {
        private readonly IPrescriptionLogic service = new PrescriptionLogic();

        List<PrescriptionViewModel> list;

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            list = service.GetAvailableList();
            try
            {
                if (list != null)
                {  
                    dataGridView.DataBind();
                    dataGridView.DataSource = list;
                    dataGridView.DataBind();
                    dataGridView.ShowHeaderWhenEmpty = true;
                    dataGridView.SelectedRowStyle.BackColor = Color.Silver;
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void ButtonRef_Click(object sender, EventArgs e)
        {
            LoadData();
            Response.Redirect("FormPrescriptions.aspx");
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormMain.aspx");
        }
    }
}