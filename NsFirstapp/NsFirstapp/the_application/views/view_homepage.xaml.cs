/**
* @file: \NsFirstapp\NsFirstapp\views\view_homepage.xaml.cs 1.0.1
**/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

using NSTheapplication.Models;
using NSTheframework.Components;
using NsFirstapp.helpers;

namespace NsFirstapp.views
{
    public partial class ViewHomepage : ContentPage
    {
        public ViewHomepage()
        {
            InitializeComponent();
            butInsert.Clicked += ButInsert_Clicked;
            lvwEmpleados.ItemSelected += LvwEmpleados_ItemSelected;
            lvwEmpleados.ItemTemplate = new DataTemplate(typeof(HelperViewCellEmpleado));

            //ModelUser oUser = new ModelUser();

            using (var oCompData = new ComponentData())
            {
                lvwEmpleados.ItemsSource = oCompData.get_empleados();
            }
        }//ViewHomepage

        private void LvwEmpleados_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //al pinchar en un elemento del listview se lanza el evento "e" que lleva en el el objeto del registro
            //que en este caso es ModelEmployee, lo lleva como object así que le debemos hacer un cast.
            //Despues de configurar este evento, si lo dejamos tal cual y ejecutamos la app daria un error ya que 
            //hay que cambiar en \nsfirstapp\nsfirstapp\app.cs la variable "MainPage" esta debe pasar a ser una "NavigationPage"
            this.Navigation.PushAsync(new ViewEdit((ModelEmployee) e.SelectedItem));
        }

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

            ModelEmployee oEmpelado = new ModelEmployee
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
