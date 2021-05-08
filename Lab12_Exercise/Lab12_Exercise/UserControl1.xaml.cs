using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

using Autodesk.Navisworks.Api;

namespace Lab12_Exercise
{
    public partial class UserControl1 : Window
    {
        // fields 
        public Document doc;
        public string transformValue;
        public string axisValue;

        public UserControl1(Document document )
        {
            InitializeComponent();
            // assign doc
            doc = document;
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            // get selected radio btn
            RadioButton radioBtn = rpanel.Children.OfType<RadioButton>()
                  .FirstOrDefault(r => r.IsChecked.HasValue && r.IsChecked.Value);

            // get input values
            transformValue = tvalue.Text;
            axisValue = radioBtn.Content.ToString();

            // vector3D
            Vector3D vec3D = new Vector3D();
            Matrix3 mat3 = new Matrix3();

            // transform value convert to double
            double value = Convert.ToDouble(transformValue);

            switch (axisValue)
            {
                case "X":
                    // vector3D for X Axis
                    vec3D = new Vector3D(value, 0, 0);
                    break;
                case "Y":
                    // vector3D for Y Axis
                    vec3D = new Vector3D(0, value, 0);
                    break;
                case "Z":
                    // vector3D for Z Axis
                    vec3D = new Vector3D(0, 0, value);
                    break;
            }
            // create transform3D
            Transform3D trans3D = new Transform3D(mat3, vec3D);
            // override transform 
            doc.Models.OverridePermanentTransform(doc.CurrentSelection.SelectedItems, trans3D, true);
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
