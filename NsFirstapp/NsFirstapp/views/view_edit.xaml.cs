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
            bool isConfirmed = await DisplayAlert("Confirmación", "¿Desea guardar el empleado?", "Sí", "No");
            if (!isConfirmed)
                return;

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

            ModelEmpleado oEmpelado = new ModelEmpleado
            {
                id = this.oEmpleado.id,
                is_enabled = swIsEnabled.IsToggled,
                first_name = entFirstName.Text,
                last_name = entLastName.Text,
                birth_date = dapBirthdate.Date.ToString(),
                salary = decimal.Parse(entSalary.Text)
            };

            using (var oCompData = new ComponentData())
            {
                oCompData.update_empleado(oEmpleado);
            }

            await DisplayAlert("Confirmación", "Empleado modificado correctamente", "Aceptar");
            //se recarga la pagina home
            await Navigation.PushAsync(new ViewHomepage());
        }//ButUpdate_Clicked
    }//ViewEdit
}//NsFirstapp.views
