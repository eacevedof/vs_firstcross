using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

using NsFirstapp.models;
using NsFirstapp.components;
using NsFirstapp.helpers;

namespace NsFirstapp.views
{
    public partial class ViewEdit : ContentPage
    {
        private ModelEmpleado oEmpleado;
        public ViewEdit(ModelEmpleado oEmpleado)
        {
            InitializeComponent();
            this.oEmpleado = oEmpleado;
            butUpdate.Clicked += ButUpdate_Clicked;
            butDelete.Clicked += ButDelete_Clicked;

            entFirstName.Text = oEmpleado.first_name;
            entLastName.Text = oEmpleado.last_name;
            entSalary.Text = oEmpleado.salary.ToString();
            dapBirthdate.Date = DateTime.Parse(oEmpleado.birth_date);
            swIsEnabled.IsToggled = oEmpleado.is_enabled;

        }//ViewEdit

        private void ButDelete_Clicked(object sender, EventArgs e)
        {
            
        }

        private void ButUpdate_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }//ViewEdit
}//NsFirstapp.views
