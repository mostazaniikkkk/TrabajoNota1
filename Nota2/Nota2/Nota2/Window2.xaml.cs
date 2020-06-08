﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Nota2
{
    /// <summary>
    /// Lógica de interacción para Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            fechaInicio.Text = Conexion.Date();
            win2 = this;
        }
        
        private void plan1_Checked(object sender, RoutedEventArgs e)
        {
            txtPoliza.Text = "Básica";
            fechaTermino.Text = Conexion.Date1();
            int primaMensual = 5000;
            int primaAnual = primaMensual * 12;

            txtPrimaMensual.Text = primaMensual.ToString();
            txtPrimaAnual.Text = primaAnual.ToString();
        }

        private void plan2_Checked(object sender, RoutedEventArgs e)
        {
            txtPoliza.Text = "Hospitalaria";
            fechaTermino.Text = Conexion.Date2();
            int primaMensual = 10000;
            int primaAnual = primaMensual * 12;

            txtPrimaMensual.Text = primaMensual.ToString();
            txtPrimaAnual.Text = primaAnual.ToString();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            txtPoliza.Text = "Co-pago";
            fechaTermino.Text = Conexion.Date3();
            int primaMensual = 15000;
            int primaAnual = primaMensual * 12;

            txtPrimaMensual.Text = primaMensual.ToString();
            txtPrimaAnual.Text = primaAnual.ToString();
        }
        internal static Window2 win2;
        internal string Status
        {
            get { return lblRut.Content.ToString(); }
            set { Dispatcher.Invoke(new Action(() => { lblRut.Content = value; })); }
        }
        internal string Status1
        {
            get { return lblUser.Content.ToString(); }
            set { Dispatcher.Invoke(new Action(() => { lblUser.Content = value; })); }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 win1 = new Window1();

            Window1.win1.Status = lblRut.Content.ToString();
            Window1.win1.Status1 = lblUser.Content.ToString();

            this.Close();
            win1.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(fechaInicio.Text);
            try
            {
                Console.WriteLine("ENTRATRY");
                if(plan1.IsChecked == true)
                {
                    Console.WriteLine("ENTRAPLAN1");
                    if (rSi.IsChecked == true)
                    {
                        Console.WriteLine("EntraRSi plan 1");
                        Conexion.GuardarContrato(txtUsuario.Text, "Plan1", txtPoliza.Text, fechaInicio.Text, fechaTermino.Text, 'S', int.Parse(txtPrimaMensual.Text), int.Parse(txtPrimaAnual.Text), txtObservacion.Text);
                    }
                    if (rNo.IsChecked == true)
                    {
                        Console.WriteLine("EntraRNo plan 1");
                        Conexion.GuardarContrato(txtUsuario.Text, "Plan1", txtPoliza.Text, fechaInicio.Text, fechaTermino.Text, 'N', int.Parse(txtPrimaMensual.Text), int.Parse(txtPrimaAnual.Text), txtObservacion.Text);
                        Console.WriteLine("lol");
                    }
                }
                else if (plan2.IsChecked == true)
                {
                    Console.WriteLine("ENTRAPLAN2");
                    if (rSi.IsChecked == true)
                    {
                        Conexion.GuardarContrato(txtUsuario.Text, "Plan2", txtPoliza.Text, fechaInicio.Text, fechaTermino.Text, 'S', int.Parse(txtPrimaMensual.Text), int.Parse(txtPrimaAnual.Text), txtObservacion.Text);
                    }
                    if (rNo.IsChecked == true)
                    {
                        Conexion.GuardarContrato(txtUsuario.Text, "Plan2", txtPoliza.Text, fechaInicio.Text, fechaTermino.Text, 'N', int.Parse(txtPrimaMensual.Text), int.Parse(txtPrimaAnual.Text), txtObservacion.Text);
                    }
                }
                else if (plan3.IsChecked == true)
                {
                    Console.WriteLine("ENTRAPLAN3");
                    if (rSi.IsChecked == true)
                    {
                        Conexion.GuardarContrato(txtUsuario.Text, "Plan3", txtPoliza.Text, fechaInicio.Text, fechaTermino.Text, 'S', int.Parse(txtPrimaMensual.Text), int.Parse(txtPrimaAnual.Text), txtObservacion.Text);
                    }
                    if (rNo.IsChecked == true)
                    {
                        Conexion.GuardarContrato(txtUsuario.Text, "Plan3", txtPoliza.Text, fechaInicio.Text, fechaTermino.Text, 'N', int.Parse(txtPrimaMensual.Text), int.Parse(txtPrimaAnual.Text), txtObservacion.Text);
                    }
                }

                MessageBoxResult result = MessageBox.Show("Contrato agregado exitosamente!");
                Console.WriteLine(result);

            }
            catch (Exception)
            {
                MessageBoxResult result = MessageBox.Show("Error, no se pudo agregar contrato...");
                Console.WriteLine(result);
            }
        }
    }
}
