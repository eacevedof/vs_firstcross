/*
 *@file: \NsFirstapp\NsFirstapp\helpers\HelperViewCellEmpleado.cs 1.0.0
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
namespace NsFirstapp.helpers
{
    class HelperViewCellEmpleado:ViewCell
    {
        public HelperViewCellEmpleado()
        {
            var lblId = new Label
            {
                TextColor = Color.White,
                Font = Font.BoldSystemFontOfSize(NamedSize.Medium),
                HorizontalOptions = LayoutOptions.End
            };

            lblId.SetBinding(Label.TextProperty, new Binding("id"));

            var lblFirstName = new Label
            {
                TextColor = Color.White,
                Font = Font.BoldSystemFontOfSize(NamedSize.Medium),
                HorizontalOptions = LayoutOptions.End
            };

            lblFirstName.SetBinding(Label.TextProperty, new Binding("first_name"));

            var lblLastName = new Label
            {
                TextColor = Color.White,
                Font = Font.BoldSystemFontOfSize(NamedSize.Medium),
                HorizontalOptions = LayoutOptions.End
            };

            lblLastName.SetBinding(Label.TextProperty, new Binding("last_name"));

            var lblSalary = new Label
            {
                TextColor = Color.White,
                Font = Font.BoldSystemFontOfSize(NamedSize.Medium),
                HorizontalOptions = LayoutOptions.End
            };
            lblSalary.SetBinding(Label.TextProperty, new Binding("salary"));

            var lblBirthdate = new Label
            {
                TextColor = Color.White,
                Font = Font.BoldSystemFontOfSize(NamedSize.Medium),
                HorizontalOptions = LayoutOptions.End
            };
            lblBirthdate.SetBinding(Label.TextProperty, new Binding("birth_date"));

            var swIsEnabled = new Switch
            {
                HorizontalOptions = LayoutOptions.End
            };
            swIsEnabled.SetBinding(Switch.IsToggledProperty, new Binding("is_enabled"));

            StackLayout oStackLayout1 = new StackLayout
            {
                Children = { lblId, lblFirstName, lblLastName},
                Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.FillAndExpand,
            };

            StackLayout oStackLayout2 = new StackLayout
            {
                Children = {lblSalary,lblBirthdate,swIsEnabled},
                Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.FillAndExpand,
            };

            this.View = new StackLayout
            {
                Children = {oStackLayout1,oStackLayout2},
                VerticalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Vertical
            };
        }//HelperViewCellEmpleado()

    }//HelperViewCellEmpleado
}//NsFirstapp.helpers
