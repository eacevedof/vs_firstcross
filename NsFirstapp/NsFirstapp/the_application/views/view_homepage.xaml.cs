/**
* @file: \NsFirstapp\NsFirstapp\views\view_homepage.xaml.cs 1.0.1
**/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using Xamarin.Forms;

using NSTheframework.Core;
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

            //Task.Delay(TimeSpan.FromSeconds(5)).Wait();
            //Task.Delay(10000).Wait();
            //DisplayAlert("trace","Model user","aceptar");

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

        /*
        El operador await se aplica a una tarea de un método asincrónico para suspender la ejecución del método 
        hasta que la tarea en espera se complete.La tarea representa el trabajo en curso.
        El método asincrónico en el que await se usa se debe modificar con la palabra clave async.Este tipo de método, 
        que se define mediante el modificador async y generalmente contiene una o más expresiones await, se denomina 
        método asincrónico.
        */
        public async void ButInsert_Clicked(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(entFirstName.Text))
            {
                await DisplayAlert("Error", "Debe ingresar nombres :)", "Aceptar");
                entFirstName.Focus();
                return;         
            }

            if (string.IsNullOrEmpty(entLastName.Text))
            {
                await DisplayAlert("Error", "Debe ingresar apellidos", "Aceptar");
                entLastName.Focus();
                return;
            }

            if (string.IsNullOrEmpty(entSalary.Text))
            {
                await DisplayAlert("Error", "Debe ingresar salario", "Aceptar");
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
                await DisplayAlert("Success", "Empleado creado correctamente", "Aceptar");
            }//ComponentData

            ComponentDbBuilder oBuild = new ComponentDbBuilder();
            oBuild.build_db();

            //Bug.pr("antes de crear tabla", "MODO OBJETO");
            //ModelUser oUser = new ModelUser();
            //Bug.pr("...new ComponentData()");
            //ComponentData oComp = new ComponentData();
            //Bug.pr("antes de oComp.table_baseuser()");
            //oComp.table_baseuser();
            //Bug.pr("despues de oComp.table_baseuser()");
            //await DisplayAlert("success", "tabla baseuser", "Aceptar");

            //Bug.pr("antes de crear tabla","MODO ESTATICO");
            //ModelUser.createtable();
            //Bug.pr("DESPUES de crear tabla", "MODO ESTATICO");
        }//ButInsert_Clicked

    }//ViewHomepage : ContentPage
}//NsFirstapp.views
