/*
 * @file: \NsFirstapp\NsFirstapp\views\view_edit.xaml.cs 1.0.1
 */

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

        public async void ButDelete_Clicked(object sender, EventArgs e)
        {
            bool isConfirmed = await DisplayAlert("Confirmación", "¿Desea borrar el empleado?", "Sí", "No");
            if (!isConfirmed)
                return;

            using (var oDb = new ComponentData())
            {
                oDb.delete_empleado(this.oEmpleado);
            }

            await DisplayAlert("Confirmación", "Empleado borrado correctamente", "Aceptar");
            //se recarga la pagina home
            await Navigation.PushAsync(new ViewHomepage());
        }//ButDelete_Clicked

        public async void ButUpdate_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(entFirstName.Text))
            {
                await DisplayAlert("Error", "Debe ingresar nombres", "Aceptar");
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

            bool isConfirmed = await DisplayAlert("Confirmación", "¿Desea guardar el empleado?", "Sí", "No");
            if (!isConfirmed)
                return;

            //OJO con esto, si la variable creada se llama igual a una variable global si en otra parte
            //de este mismo ambito se usa este nombre se dara prioridada a la global (aún sin usar this)
            //por esto no me actualizaba con el objeto oEmpleado local. 
            //He cambiado el nombre y ahora todo bien.
            ModelEmpleado oEmp = new ModelEmpleado
            {
                id = this.oEmpleado.id,
                is_enabled = swIsEnabled.IsToggled,
                first_name = entFirstName.Text,
                last_name = entLastName.Text,
                birth_date = dapBirthdate.Date.ToString(),
                salary = decimal.Parse(entSalary.Text)
            };

            //this.oEmpleado.first_name = entFirstName.Text;
            //this.oEmpleado.last_name = entLastName.Text;
            //this.oEmpleado.salary = decimal.Parse(entSalary.Text);
            //this.oEmpleado.birth_date = dapBirthdate.Date.ToString();
            //this.oEmpleado.is_enabled = swIsEnabled.IsToggled;

            using (var oCompData = new ComponentData())
            {
                oCompData.update_empleado(oEmp);
            }

            await DisplayAlert("Confirmación", "Empleado modificado correctamente", "Aceptar");
            //se recarga la pagina home
            await Navigation.PushAsync(new ViewHomepage());
        }//ButUpdate_Clicked
    }//ViewEdit
}//NsFirstapp.views
