/**
* @file: \NsFirstapp\NsFirstapp\views\view_homepage.xaml.cs 1.0.1
**/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

using NsFirstapp.models;
using NsFirstapp.components;

namespace NsFirstapp.views
{
    public partial class ViewHomepage : ContentPage
    {
        public ViewHomepage()
        {
            InitializeComponent();
            butInsert.Clicked += ButInsert_Clicked;

            using (var oCompData = new ComponentData())
            {
                lvwEmpleados.ItemsSource = oCompData.get_empleados();
            }
        }//ViewHomepage

        public void ButInsert_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(entFirstName.Text))
            {
                DisplayAlert("Error", "Debe ingresar nombres", "Aceptar");
                entFirstName.Focus();
                return;         
            }

            if (string.IsNullOrEmpty(entLastName.Text))
            {
                DisplayAlert("Error", "Debe ingresar apellidos", "Aceptar");
                entLastName.Focus();
                return;
            }

            if (string.IsNullOrEmpty(entSalary.Text))
            {
                DisplayAlert("Error", "Debe ingresar salario", "Aceptar");
                entSalary.Focus();
                return;
            }

            ModelEmpleado oEmpelado = new ModelEmpleado
            {
                is_enabled = swIsEnabled.IsToggled,
                first_name = entFirstName.Text,
                last_name = entLastName.Text,
                birth_date = dapBirthdate.Date.ToString(),
                salary = decimal.Parse(entSalary.Text)
            };

            using (var oCompData = new ComponentData())
            {
                oCompData.insert_empleado(oEmpelado);
                lvwEmpleados.ItemsSource = oCompData.get_empleados();

                swIsEnabled.IsToggled = false;
                entFirstName.Text = string.Empty;
                entLastName.Text = string.Empty;
                entSalary.Text = string.Empty;

                dapBirthdate.Date = DateTime.Now;
                DisplayAlert("Success", "Empleado creado correctamente", "Aceptar");
            }
        }//ButInsert_Clicked

    }//ViewHomepage : ContentPage
}//NsFirstapp.views
